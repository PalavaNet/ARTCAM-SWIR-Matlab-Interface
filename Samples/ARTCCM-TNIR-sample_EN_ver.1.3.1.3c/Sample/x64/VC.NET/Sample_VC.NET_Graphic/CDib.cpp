/*
==============================================================================================
==============================================================================================
	[Program]
			CDib.cpp

==============================================================================================
*/


/////////////////////////////////////////////////////////////////////////////
//
//	Include file
//

#include "CDib.h"


/////////////////////////////////////////////////////////////////////////////
//
//	Constructor
//

CDib::CDib()
{
	::ZeroMemory(&m_BitmapInfoHeader, sizeof(BITMAPINFOHEADER));
	m_BitmapInfoHeader.biSize = sizeof(BITMAPINFOHEADER);

	m_lpImage	= NULL;

	m_lWidth	= 0;
	m_lHeight	= 0;
	m_lPitch	= 0;
	m_wBpp		= 0;

	m_Gdi.hDC		= NULL;
	m_Gdi.hBitmap	= NULL;
	m_Gdi.hPen		= NULL;
	m_Gdi.hFont		= NULL;

	m_Gdi.hOldBitmap	= NULL;
	m_Gdi.hOldPen		= NULL;
	m_Gdi.hOldFont		= NULL;
}


/////////////////////////////////////////////////////////////////////////////
//
//	Copy constructor
//

CDib::CDib(CDib& Dib)
{
	CDib();
	CreateCopy(&Dib);
}


/////////////////////////////////////////////////////////////////////////////
//
//	Destructor
//

CDib::~CDib()
{
	Release();
}


/////////////////////////////////////////////////////////////////////////////
//
//	Release
//

void CDib::Release(void)
{
	DeleteFont();
	DeletePen();

	if(m_Gdi.hBitmap){
		if(m_Gdi.hDC){
			::SelectObject(m_Gdi.hDC, m_Gdi.hOldBitmap);
		}

		::DeleteObject(m_Gdi.hBitmap);
		m_Gdi.hBitmap = NULL;
		m_Gdi.hOldBitmap = NULL;
		m_lpImage	= NULL;
	}

	if(m_Gdi.hDC){
		::DeleteDC(m_Gdi.hDC);
		m_Gdi.hDC = NULL;
	}

	if(m_lpImage){
		delete[] m_lpImage;
		m_lpImage = NULL;
	}


	::ZeroMemory(&m_BitmapInfoHeader, sizeof(BITMAPINFOHEADER));
	m_BitmapInfoHeader.biSize = sizeof(BITMAPINFOHEADER);

	m_lpImage	= NULL;

	m_lWidth	= 0;
	m_lHeight	= 0;
	m_lPitch	= 0;
	m_wBpp		= 0;

	m_Gdi.hDC		= NULL;
	m_Gdi.hBitmap	= NULL;
	m_Gdi.hPen		= NULL;

	m_Gdi.hOldBitmap	= NULL;
	m_Gdi.hOldPen		= NULL;
}


/////////////////////////////////////////////////////////////////////////////
//
//	Create DIBDIB operation
//

BOOL CDib::Create(HDC hDC, LONG lWidth, LONG lHeight, WORD wBpp)
{
	Release();

	m_BitmapInfoHeader.biWidth		 = lWidth;
	m_BitmapInfoHeader.biHeight		 = lHeight;
	m_BitmapInfoHeader.biPlanes		 = 1;
	m_BitmapInfoHeader.biBitCount	 = wBpp;
	m_BitmapInfoHeader.biCompression = BI_RGB;

	m_lWidth	= lWidth;
	m_lHeight	= lHeight;
	m_wBpp		= wBpp;
	m_lPitch	= ((lWidth * (wBpp/8) + 3) & ~3);


	if(NULL == (m_Gdi.hBitmap = ::CreateDIBSection(m_Gdi.hDC, (LPBITMAPINFO)&m_BitmapInfoHeader,
													DIB_RGB_COLORS, (LPVOID*)&m_lpImage, NULL, 0))){
		m_lpImage = new BYTE[m_lHeight * m_lPitch];
		if(m_lpImage){
			ZeroMemory(m_lpImage, m_lHeight * m_lPitch);
			return TRUE;
		}

		Release();
		return FALSE;
	}

	if(NULL == (m_Gdi.hDC = ::CreateCompatibleDC(NULL))){
		Release();
		return FALSE;
	}

	if(NULL == (m_Gdi.hOldBitmap = (HBITMAP)::SelectObject(m_Gdi.hDC, m_Gdi.hBitmap))){
		Release();
		return FALSE;
	}

	if(8 == m_BitmapInfoHeader.biBitCount){
		if(NULL == hDC){
			SetPalette(SP8_GRAY);
		} else {
			RGBQUAD rgb[256];
			::GetDIBColorTable(hDC, 0, 256, rgb);
			SetPalette(SP8_CUSTOM, rgb);
		}
	}

	return TRUE;
}


/////////////////////////////////////////////////////////////////////////////
//
//	Create DIB
//

BOOL CDib::CreateCopy(CDib* pCDib)
{
	if(Create(pCDib->GetDC(), pCDib->GetWidth(), pCDib->GetHeight(), pCDib->GetBPP())){
		memcpy(m_lpImage, pCDib->GetImage(), pCDib->GetSize());
		return TRUE;
	}
	return FALSE;
}


/////////////////////////////////////////////////////////////////////////////
//
//	Pallet setting
//

BOOL CDib::SetPalette(LONG Type, RGBQUAD* rgbQuad, LONG Start, LONG End)
{
	if(SP8_GRAY == Type){
		RGBQUAD rgb[256];
		for(int i=0; i<256; i++){
			rgb[i].rgbRed = i;
			rgb[i].rgbGreen = i;
			rgb[i].rgbBlue = i;
			rgb[i].rgbReserved = 0;
		}
		::SetDIBColorTable(m_Gdi.hDC, 0, 256, rgb);
	}
	else if(SP8_CUSTOM == Type){
		::SetDIBColorTable(m_Gdi.hDC, Start, End, rgbQuad);
	}

	return TRUE;
}


/////////////////////////////////////////////////////////////////////////////
//
//	Change to 24 bit color image for image copy and drawing
//

BOOL CDib::Convert24Bit(CDib* pCDibSrc)
{
	if(NULL == pCDibSrc || NULL == m_lpImage){
		return FALSE;
	}

	if(24 != m_wBpp){
		return FALSE;
	}


	LONG Width  = m_lWidth  < pCDibSrc->GetWidth()  ? m_lWidth  : pCDibSrc->GetWidth();
	LONG Height = m_lHeight < pCDibSrc->GetHeight() ? m_lHeight : pCDibSrc->GetHeight();

	LONG DestPitch = m_lPitch;
	LONG SrcPitch  = pCDibSrc->GetPitch();
	WORD SrcBpp    = pCDibSrc->GetBPP() / 8;

	LPBYTE pDestImage = m_lpImage;
	LPBYTE pSrcImage  = pCDibSrc->GetImage();


	// Monochrome 8 bit picture transfer
	if(1 == SrcBpp){
		for(int y=0; y<Height; y++){
			LPBYTE lpDest = pDestImage + (y * DestPitch);
			LPBYTE lpSrc  = pSrcImage  + (y * SrcPitch);
			for(int x=0; x<Width; x++){
				lpDest[0] = lpSrc[0];
				lpDest[1] = lpSrc[0];
				lpDest[2] = lpSrc[0];

				lpDest += 3;
				lpSrc  += SrcBpp;
			}
		}
	}

	// Monochromatic 10 bit/16 bit picture transfer
	else if(2 == SrcBpp){
		for(int y=0; y<Height; y++){
			LPBYTE lpDest = pDestImage + (y * DestPitch);
			LPBYTE lpSrc  = pSrcImage  + (y * SrcPitch);
			for(int x=0; x<Width; x++){
				lpDest[0] = (BYTE(lpSrc[1] << 6) | BYTE(lpSrc[0] >> 2));
				lpDest[1] = (BYTE(lpSrc[1] << 6) | BYTE(lpSrc[0] >> 2));
				lpDest[2] = (BYTE(lpSrc[1] << 6) | BYTE(lpSrc[0] >> 2));

				lpDest += 3;
				lpSrc  += SrcBpp;
			}
		}
	}

	// Color 24 bit transfer
	// Color 32 bit transfer
	else if(3 == SrcBpp || 4 == SrcBpp){
		for(int y=0; y<Height; y++){
			LPBYTE lpDest = pDestImage + (y * DestPitch);
			LPBYTE lpSrc  = pSrcImage  + (y * SrcPitch);
			for(int x=0; x<Width; x++){
				lpDest[0] = lpSrc[0];
				lpDest[1] = lpSrc[1];
				lpDest[2] = lpSrc[2];

				lpDest += 3;
				lpSrc  += SrcBpp;
			}
		}
	}

	// Color 48 bit transfer
	// Color 64 bit transfer
	else if(6 == SrcBpp || 8 == SrcBpp){
		for(int y=0; y<Height; y++){
			LPBYTE lpDest = pDestImage + (y * DestPitch);
			LPBYTE lpSrc  = pSrcImage  + (y * SrcPitch);
			for(int x=0; x<Width; x++){
				lpDest[0] = (BYTE(lpSrc[1] << 6) | BYTE(lpSrc[0] >> 2));
				lpDest[1] = (BYTE(lpSrc[3] << 6) | BYTE(lpSrc[2] >> 2));
				lpDest[2] = (BYTE(lpSrc[5] << 6) | BYTE(lpSrc[4] >> 2));

				lpDest += 3;
				lpSrc  += SrcBpp;
			}
		}
	}

	return TRUE;
}







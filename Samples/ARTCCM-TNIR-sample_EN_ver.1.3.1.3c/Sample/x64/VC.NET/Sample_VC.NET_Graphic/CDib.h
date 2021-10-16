/*
==============================================================================================
==============================================================================================
	[Program]
			CDib.h

==============================================================================================
*/

#pragma once

/////////////////////////////////////////////////////////////////////////////
//
//	Include file
//

#include <windows.h>
// Remark: When you include "windowsx.h", function name and macro overlaps and causes error.


enum {
	SP8_GRAY,
	SP8_CUSTOM,
};


/////////////////////////////////////////////////////////////////////////////
//
//	
//

class CDib{
private:
	BITMAPINFOHEADER	m_BitmapInfoHeader;		// Bitmap info header
	LPBYTE				m_lpImage;				// Pointer for image

	LONG				m_lWidth;				// Image width
	LONG				m_lHeight;				// Image height
	LONG				m_lPitch;				// Pitch for next line
	WORD				m_wBpp;					// Bit count(Color number)

	struct {
		HDC				hDC;					// Device context
		HBITMAP			hBitmap;				// Bitmap handle
		HPEN			hPen;					// Pen handlePen handle
		HFONT			hFont;					// Font

		HBITMAP			hOldBitmap;				// 
		HPEN			hOldPen;				// 
		HFONT			hOldFont;				// 
	} m_Gdi;



public:

	CDib();
	CDib(CDib& Dib);
	~CDib();

	BITMAPINFOHEADER	GetBmpInfoHeader(void) { return m_BitmapInfoHeader; }

	HDC		GetDC		(void) { return m_Gdi.hDC; }
	LPBYTE	GetImage	(void) { return m_lpImage; }

	LONG	GetWidth	(void) { return m_lWidth;  }
	LONG	GetHeight	(void) { return m_lHeight; }
	LONG	GetPitch	(void) { return m_lPitch;  }
	WORD	GetBPP		(void) { return m_wBpp;    }
	LONG	GetSize		(void) { return m_lPitch * m_lHeight; }

	int operator = (CDib& Dib) { Release(); return CreateCopy(&Dib); };

public:
	void	Release			(void);
	BOOL	Create			(HDC hDC, LONG lWidth, LONG lHeight, WORD wBpp);
	BOOL	CreateCopy		(CDib* pCDib);
	BOOL	SetPalette		(LONG Type=SP8_GRAY, RGBQUAD* rgbQuad=NULL, LONG Start=0, LONG End=256);
	BOOL	Convert24Bit	(CDib* pCDibSrc);

public:
	void	DeletePen		(void);
	BOOL	SelectPen		(int fnPenStyle, int nWidth, COLORREF crColor);
	BOOL	SelectPen		(LOGPEN* lpLP);
	BOOL	SelectSolidPen	(int nWidth, COLORREF Color);
	BOOL	SelectStockPen	(int Object);

	void	DeleteFont		(void);
	BOOL	SelectFont		(LOGFONT* lpLF);
	BOOL	SelectPointFont	(int nPointSize, LPTSTR lpszFaceName);
	BOOL	SelectStockFont	(int Object);

	// Drawing function
	BOOL	Polygon			(LPPOINT lpPoints, int nCount);

	POINT	MoveTo			(int x, int y);
	POINT	MoveTo			(POINT point);
	BOOL	LineTo			(int x, int y);
	BOOL	LineTo			(POINT point);

	BOOL	TextOut			(int x, int y, LPTSTR lpszString, int nCount=-1);
	int		DrawText		(LPTSTR lpszString, int nCount, LPRECT lpRect, UINT nFormat);

	BOOL	SetTextColor	(COLORREF crColor) { return ::SetTextColor(m_Gdi.hDC, crColor); }
	BOOL	SetBkMode		(int iBkMode)      { return ::SetBkMode(m_Gdi.hDC, iBkMode); }

};



/////////////////////////////////////////////////////////////////////////////
//
// Pen relation
//

inline void CDib::DeletePen(void)
{
	if(m_Gdi.hPen){
		if(m_Gdi.hOldPen){
			::SelectObject(m_Gdi.hDC, m_Gdi.hOldPen);
			m_Gdi.hOldPen = NULL;
		}
		::DeleteObject(m_Gdi.hPen);
		m_Gdi.hPen = NULL;
	}
}

inline BOOL CDib::SelectPen(int fnPenStyle, int nWidth, COLORREF crColor)
{
	DeletePen();

	if(m_Gdi.hDC){
		LOGPEN lp;
		lp.lopnStyle = fnPenStyle;
		lp.lopnWidth.x = nWidth;
		lp.lopnColor = crColor;

		if(m_Gdi.hPen = ::CreatePenIndirect(&lp))
			if(m_Gdi.hOldPen = (HPEN)::SelectObject(m_Gdi.hDC, m_Gdi.hPen))
				return TRUE;
	}

	return FALSE;
}

inline BOOL CDib::SelectPen(LOGPEN* lpLP)
{
	DeletePen();

	if(m_Gdi.hDC){
		if(m_Gdi.hPen = ::CreatePenIndirect(lpLP))
			if(m_Gdi.hOldPen = (HPEN)::SelectObject(m_Gdi.hDC, m_Gdi.hPen))
				return TRUE;
	}

	return FALSE;
}

inline BOOL CDib::SelectSolidPen(int nWidth, COLORREF Color)
{
	DeletePen();

	if(m_Gdi.hDC){
		LOGPEN lp;
		lp.lopnStyle   = PS_SOLID;
		lp.lopnWidth.x = nWidth;
		lp.lopnColor   = Color;

		if(m_Gdi.hPen = ::CreatePenIndirect(&lp))
			if(m_Gdi.hOldPen = (HPEN)::SelectObject(m_Gdi.hDC, m_Gdi.hPen))
				return TRUE;
	}

	return FALSE;
}

inline BOOL CDib::SelectStockPen(int Object)
{
	DeletePen();

	if(m_Gdi.hDC){
		if(m_Gdi.hPen = (HPEN)::GetStockObject(Object))
			if(m_Gdi.hOldPen = (HPEN)::SelectObject(m_Gdi.hDC, m_Gdi.hPen))
				return TRUE;
	}

	return FALSE;
}


/////////////////////////////////////////////////////////////////////////////
//
// Font relation
//

inline void CDib::DeleteFont(void)
{
	if(m_Gdi.hFont){
		if(m_Gdi.hOldFont){
			::SelectObject(m_Gdi.hDC, m_Gdi.hOldFont);
			m_Gdi.hOldFont = NULL;
		}
		::DeleteObject(m_Gdi.hFont);
		m_Gdi.hFont = NULL;
	}
}

inline BOOL CDib::SelectFont(LOGFONT* lpLF)
{
	DeleteFont();

	if(m_Gdi.hDC){
		if(m_Gdi.hFont = ::CreateFontIndirect(lpLF))
			if(m_Gdi.hOldFont = (HFONT)::SelectObject(m_Gdi.hDC, m_Gdi.hFont))
				return TRUE;
	}

	return FALSE;
}

inline BOOL CDib::SelectPointFont(int nPointSize, LPTSTR lpszFaceName)
{
	DeleteFont();

	if(m_Gdi.hDC){
		LOGFONT lf;
		ZeroMemory(&lf, sizeof(LOGFONT));
		lf.lfHeight = -MulDiv(nPointSize, ::GetDeviceCaps(m_Gdi.hDC, LOGPIXELSY), 72);
		wsprintf(lf.lfFaceName, lpszFaceName);

		if(m_Gdi.hFont = ::CreateFontIndirect(&lf))
			if(m_Gdi.hOldFont = (HFONT)::SelectObject(m_Gdi.hDC, m_Gdi.hFont))
				return TRUE;
	}

	return FALSE;
}

inline BOOL CDib::SelectStockFont(int Object)
{
	DeleteFont();

	if(m_Gdi.hDC){
		if(m_Gdi.hFont = (HFONT)::GetStockObject(Object))
			if(m_Gdi.hOldFont = (HFONT)::SelectObject(m_Gdi.hDC, m_Gdi.hFont))
				return TRUE;
	}

	return FALSE;
}


/////////////////////////////////////////////////////////////////////////////
//
// Related to drawing line
//

inline BOOL CDib::Polygon(LPPOINT lpPoints, int nCount)
{
	return ::Polygon(m_Gdi.hDC, lpPoints, nCount);
}


inline POINT CDib::MoveTo(int x, int y)
{
	POINT pt;
	::MoveToEx(m_Gdi.hDC, x, y, &pt);
	return pt;
}


inline POINT CDib::MoveTo(POINT point)
{
	return MoveTo(point.x, point.y);
}


inline BOOL CDib::LineTo(int x, int y)
{
	return ::LineTo(m_Gdi.hDC, x, y);
}


inline BOOL CDib::LineTo(POINT point)
{
	return LineTo(point.x, point.y);
}


inline BOOL CDib::TextOut(int x, int y, LPTSTR lpszString, int nCount)
{
	if(-1 == nCount){
		nCount = lstrlen(lpszString);
	}

	return ::TextOut(m_Gdi.hDC, x, y, lpszString, nCount);
}


inline int CDib::DrawText(LPTSTR lpszString, int nCount, LPRECT lpRect, UINT nFormat)
{
	return ::DrawText(m_Gdi.hDC, lpszString, nCount, lpRect, nFormat);
}



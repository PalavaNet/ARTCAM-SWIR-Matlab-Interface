// Sample_MFCView.cpp : CSample_MFCView Mounting of class
//

#include "stdafx.h"
#include "Sample_MFC.h"
#include "MainFrm.h"

#include "Sample_MFCDoc.h"
#include "Sample_MFCView.h"

#include "SetFilterDlg.h"
#include "SetSizeDlg.h"
#include "SetIODlg.h"
#include "SetMonitorDlg.h"
#include "SetMonitorDlg2.h"
#include "SetCorrection.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif


#define CAP_TIMER_ID	100
#define REC_TIMER_ID	200
#define TIMER_TIME		50

const int SUB_SAMPLE[] = { 1, 2, 4, 8 };
#define ArtCamGetWidth()	(m_CArtCamSdk.Width()  / SUB_SAMPLE[m_CArtCamSdk.GetSubSample() & 0x03])
#define ArtCamGetHeight()	(m_CArtCamSdk.Height() / SUB_SAMPLE[m_CArtCamSdk.GetSubSample() & 0x03])
#define ArtCamGetColor()	WORD(((m_CArtCamSdk.GetColorMode() + 7) / 8) * 8)
#define ArtCamGetBpp()		(((m_CArtCamSdk.GetColorMode() + 7) / 8))
#define ArtCamGetPitch()	((ArtCamGetWidth() * ArtCamGetBpp() + 3) & ~3)
#define ArtCamGetSize()		(ArtCamGetPitch() * ArtCamGetHeight())
#define SAFE_DELETE(x)  { if(x) delete[] x; x=NULL; }


// CSample_MFCView

IMPLEMENT_DYNCREATE(CSample_MFCView, CView)

BEGIN_MESSAGE_MAP(CSample_MFCView, CView)
	ON_WM_CREATE()
	ON_WM_DESTROY()
	ON_WM_TIMER()
	ON_WM_SIZE()
	ON_WM_HSCROLL()
	ON_WM_VSCROLL()
	ON_WM_MOUSEMOVE()
	ON_MESSAGE(WM_GRAPHPAINT, OnGraphPaint)
	ON_MESSAGE(WM_ERROR, OnError)
	ON_COMMAND(ID_FILE_SAVEIMAGE, OnFileSaveimage)
	ON_COMMAND(ID_FILE_REC, OnFileRec)
	ON_COMMAND(ID_FILE_EXIT, OnExit)
	ON_COMMAND(ID_SHOW_PREVIEW, OnShowPreview)
	ON_COMMAND(ID_SHOW_CALLBACK, OnShowCallback)
	ON_COMMAND(ID_SHOW_SNAPSHOT, OnShowSnapshot)
	ON_COMMAND(ID_SHOW_CAPTURE, OnShowCapture)
	ON_COMMAND(ID_SHOW_TRIGGER, OnShowTrigger)
	ON_COMMAND(ID_SHOW_STOP, OnShowStop)
	ON_COMMAND(ID_SET_FORMAT, OnSetFormat)
	ON_COMMAND(ID_SET_FILTER, OnSetFilter)
	ON_COMMAND(ID_SET_ANALOG, OnSetAnalog)
	ON_COMMAND(ID_SET_FILTER_APP, OnSetFilterApp)
	ON_COMMAND(ID_DLL_RELOAD, OnDllReload)
	ON_COMMAND(ID_DEVICE01, OnDevice01)
	ON_COMMAND(ID_DEVICE02, OnDevice02)
	ON_COMMAND(ID_DEVICE03, OnDevice03)
	ON_COMMAND(ID_DEVICE04, OnDevice04)
	ON_COMMAND(ID_DEVICE05, OnDevice05)
	ON_COMMAND(ID_DEVICE06, OnDevice06)
	ON_COMMAND(ID_DEVICE07, OnDevice07)
	ON_COMMAND(ID_DEVICE08, OnDevice08)
	ON_COMMAND(ID_SET_SIZE_APP, OnSetSizeApp)
	ON_COMMAND(ID_SET_IO_APP, OnSetIoApp)
	ON_COMMAND(ID_SET_MONITOR_APP, OnSetMonitorApp)
	ON_COMMAND(ID_SET_CORRECTION, OnSetCorrection)
END_MESSAGE_MAP()

// CSample_MFCView Construction/Destruction

CSample_MFCView::CSample_MFCView()
{
	theApp.m_pView = this;


	m_pImage = NULL;
	m_PreviewMode = -1;
	m_DllType = -1;
	m_CurrentCameraType = -1;
	m_DllCount = 0;
	m_DeviceCount = 0;
	m_SelectDevice = -1;

	m_BitMode =10;

	m_SaveFlg = FALSE;
	m_StopFlg = FALSE;

	m_DllSata  = -1;
	m_SataType = -1;
}

CSample_MFCView::~CSample_MFCView()
{
	SAFE_DELETE(m_pImage);
}

BOOL CSample_MFCView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify "CREATESTRUCT cs" at this position and adjust Window class or style.
	//  
	cs.style |= WS_HSCROLL;
	cs.style |= WS_VSCROLL;

	return CView::PreCreateWindow(cs);
}

// CSample_MFCView Drawing

void CSample_MFCView::OnDraw(CDC* pDC)
{
	CSample_MFCDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);


	if(0 != m_PreviewMode){
		DrawImage(pDC->m_hDC);
	}
}


// CSample_MFCView Diagnosis

#ifdef _DEBUG
void CSample_MFCView::AssertValid() const
{
	CView::AssertValid();
}

void CSample_MFCView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CSample_MFCDoc* CSample_MFCView::GetDocument() const // Version except debugging is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CSample_MFCDoc)));
	return (CSample_MFCDoc*)m_pDocument;
}
#endif //_DEBUG


// CSample_MFCView Message handler



int CSample_MFCView::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CView::OnCreate(lpCreateStruct) == -1)
		return -1;

	// Read DLL used before first
	TCHAR szFilePath[MAX_PATH]=_T("");
	TCHAR szExePath[3][MAX_PATH]={_T(""),_T(""),_T("")};
	GetModuleFileName(::GetModuleHandle(NULL), szExePath[0], MAX_PATH);
#if defined(__VS2005__) | (__VS2010__)
	_tsplitpath_s(szExePath[0], szExePath[1], MAX_PATH, szExePath[2], MAX_PATH, NULL, 0, NULL, 0);
#else
	_tsplitpath(szExePath[0], szExePath[1], szExePath[2], NULL, NULL);
#endif
	wsprintf(szFilePath, _T("%s%sSample.ini"), szExePath[1], szExePath[2]);

	m_DllType  = ::GetPrivateProfileInt(_T("Sample"), _T("DllType"),	-1, szFilePath);
	m_SataType = ::GetPrivateProfileInt(_T("Sample"), _T("CameraType"),	-1, szFilePath);

	OnDllReload();

	// Initialize camera
	if(-1 != m_DllType)
		OnDllChange(m_DllType, m_SataType);

	return 0;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	WM_DESTROY
//

void CSample_MFCView::OnDestroy()
{
	CView::OnDestroy();

	m_CArtCamSdk.Release();
	m_CArtCamSdk.FreeLibrary();

	TCHAR szFilePath[MAX_PATH]=_T("");
	TCHAR szExePath[3][MAX_PATH]={_T(""),_T(""),_T("")};
	GetModuleFileName(::GetModuleHandle(NULL), szExePath[0], MAX_PATH);
#if defined(__VS2005__) | (__VS2010__)
	_tsplitpath_s(szExePath[0], szExePath[1], MAX_PATH, szExePath[2], MAX_PATH, NULL, 0, NULL, 0);
#else
	_tsplitpath(szExePath[0], szExePath[1], szExePath[2], NULL, NULL);
#endif
	wsprintf(szFilePath, _T("%s%sSample.ini"), szExePath[1], szExePath[2]);

	TCHAR Data[32]=_T("");
	wsprintf(Data, _T("%d"), m_DllType);
	::WritePrivateProfileString(_T("Sample"), _T("DllType"), Data, szFilePath);

	wsprintf(Data, _T("%d"), m_SataType);
	::WritePrivateProfileString(_T("Sample"), _T("CameraType"), Data, szFilePath);

}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	WM_GRAPHPAINT
//

LRESULT CSample_MFCView::OnGraphPaint(WPARAM wParam, LPARAM lParam)
{
	if(0 == wParam){
		return OnError(wParam, lParam);
	}

	// When this message come, there is latest image in m_pImage
	LPGP_INFO pGpInfo = (LPGP_INFO)wParam;
	DrawImage(NULL);

	// Show FPS
	CString Fps;
	Fps.Format(_T("%.1ffps"), double(pGpInfo->lFps) / 10.0);
	static_cast<CMainFrame*>(theApp.m_pMainWnd)->SetStatusText(STATUS_FRAME, Fps);

	// Show explosure time(milli seconds)
	if(1300 <= LOWORD(m_CArtCamSdk.GetDllVersion())){
		CString sw;
		sw.Format(_T("%.2fms"), m_CArtCamSdk.GetRealExposureTime() / 1000.0);
		static_cast<CMainFrame*>(theApp.m_pMainWnd)->SetStatusText(STATUS_SW, sw);
	}

	m_SaveFlg = TRUE;

	return 1;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	WM_ERROR
//

LRESULT CSample_MFCView::OnError(WPARAM wParam, LPARAM lParam)
{
	if(0 <= lParam && lParam < ERRORCOUNT){
		static_cast<CMainFrame*>(theApp.m_pMainWnd)->SetStatusText(STATUS_TEXT, ERRORLIST[lParam]);
	}
	else {
		static_cast<CMainFrame*>(theApp.m_pMainWnd)->SetStatusText(STATUS_TEXT, ERRORLIST[ARTCAMSDK_UNKNOWN]);
	}

	return 1;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Still picture saving
//

void CSample_MFCView::OnFileSaveimage()
{
	CFileDialog FD(FALSE, NULL, _T("Select file"), OFN_HIDEREADONLY | OFN_OVERWRITEPROMPT, 
		_T("BITMAPFile(*.bmp)|*.bmp|JPEGFile(*.jpg)|*.jpg;*.jpeg|TIFFFile(*.tif)|*.tif;*.tiff|PNGFile(*.png)|*.png|RAWFile(*.raw)|*.raw||"), this);

	if(IDOK == FD.DoModal()){
#if defined(__VC6__)
		OPENFILENAME ofn = FD.m_ofn;
#else
		OPENFILENAME ofn = FD.GetOFN();
#endif
		// Set extension yourself
		TCHAR szTemp[4][MAX_PATH]={_T(""),_T(""),_T(""),_T("")};
#if defined(__VS2005__) | (__VS2010__)
		_tsplitpath_s(ofn.lpstrFile, szTemp[0], MAX_PATH, szTemp[1], MAX_PATH, szTemp[2], MAX_PATH, szTemp[3], MAX_PATH);
#else
		_tsplitpath(ofn.lpstrFile, szTemp[0], szTemp[1], szTemp[2], szTemp[3]);
#endif
		CString str;
		switch(ofn.nFilterIndex){
		case 1:	str.Format(_T("%s%s%s.bmp"), szTemp[0], szTemp[1], szTemp[2]);	m_CArtCamSdk.SaveImage(str, FILETYPE_BITMAP);		break;
		case 2:	str.Format(_T("%s%s%s.jpg"), szTemp[0], szTemp[1], szTemp[2]);	m_CArtCamSdk.SaveImage(str, FILETYPE_JPEG_HIGH);	break;
		case 3:	str.Format(_T("%s%s%s.tif"), szTemp[0], szTemp[1], szTemp[2]);	m_CArtCamSdk.SaveImage(str, FILETYPE_TIFF);			break;
		case 4:	str.Format(_T("%s%s%s.png"), szTemp[0], szTemp[1], szTemp[2]);	m_CArtCamSdk.SaveImage(str, FILETYPE_PNG);			break;
		case 5:	str.Format(_T("%s%s%s.raw"), szTemp[0], szTemp[1], szTemp[2]);	m_CArtCamSdk.SaveImage(str, FILETYPE_RAW);			break;
		break;
		}
	}
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Animated picture saving(Only for Directshow version)
//

void CSample_MFCView::OnFileRec()
{
	CFileDialog FD(FALSE, _T("avi"), _T("Select file"), OFN_HIDEREADONLY | OFN_OVERWRITEPROMPT, _T("AVIFile(*.avi)|*.avi||"), this);

	if(IDOK == FD.DoModal()){
		m_RecName = FD.GetPathName();

		// Pause
		m_CArtCamSdk.Close();

		// Display on different window while recording
		// When "hWnd" is NULL, window is created from SDK side and therefore the size is not important.
		m_CArtCamSdk.SetPreviewWindow(NULL, 0, 0, 0, 0);

		// 5 seconds recording
		m_CArtCamSdk.Record(m_RecName, 5000, 1);


		// Timing for record ending is not sent from SDK and therefore it needs to be stopped by software.
		// Just in case, run the timer for 1 sencond longer.
		SetTimer(REC_TIMER_ID, 6000, NULL);
	}
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	End
//

void CSample_MFCView::OnExit()
{
	GetParent()->PostMessage(WM_CLOSE);
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Draw image
//

struct BITMAPINFO2 {
	BITMAPINFOHEADER   bmiHeader;
	RGBQUAD            bmiColors[256];
};

LRESULT CSample_MFCView::DrawImage(HDC hDC)
{
	if(NULL == m_pImage){
		return 0;
	}

	BOOL Flg = FALSE;
	if(NULL == hDC){
		hDC = ::GetDC(m_hWnd);
		Flg = TRUE;
	}

	CPoint Pos;
	Pos.x = GetScrollPos(SB_HORZ);
	Pos.y = GetScrollPos(SB_VERT);


	if(hDC){
		LONG Width = ArtCamGetWidth();
		LONG Height = ArtCamGetHeight();
		LONG Bpp = ArtCamGetBpp();

		BITMAPINFO2 bm;
		bm.bmiHeader.biSize = sizeof(BITMAPINFOHEADER);
		bm.bmiHeader.biPlanes = 1;
		bm.bmiHeader.biCompression = BI_RGB;
		bm.bmiHeader.biSizeImage = 0;
		bm.bmiHeader.biXPelsPerMeter = 0;
		bm.bmiHeader.biYPelsPerMeter = 0;
		bm.bmiHeader.biClrUsed = 0;
		bm.bmiHeader.biClrImportant = 0;

		bm.bmiHeader.biWidth = Width;
		bm.bmiHeader.biHeight = Height;


		// Monochrome 8 bit picture transfer 
		if(1 == Bpp){
			bm.bmiHeader.biBitCount = 8;

			for(int i=0; i<256; i++){
				bm.bmiColors[i].rgbRed = i;
				bm.bmiColors[i].rgbGreen = i;
				bm.bmiColors[i].rgbBlue = i;
				bm.bmiColors[i].rgbReserved = 0;
			}
			::SetDIBColorTable(hDC, 0, 256, bm.bmiColors);

			SetDIBitsToDevice(hDC, -Pos.x, -Pos.y, bm.bmiHeader.biWidth, bm.bmiHeader.biHeight,
								0, 0, 0, bm.bmiHeader.biHeight, m_pImage, (BITMAPINFO*)&bm, DIB_RGB_COLORS);
		}

		// Monochromatic 10 bit/16 bit picture transfer
		else if(2 == Bpp){
			bm.bmiHeader.biBitCount = 8;

			for(int i=0; i<256; i++){
				bm.bmiColors[i].rgbRed = i;
				bm.bmiColors[i].rgbGreen = i;
				bm.bmiColors[i].rgbBlue = i;
				bm.bmiColors[i].rgbReserved = 0;
			}
			::SetDIBColorTable(hDC, 0, 256, bm.bmiColors);

			LONG Pitch = Width * Bpp;
			LPBYTE pTemp = new BYTE[bm.bmiHeader.biWidth * bm.bmiHeader.biHeight];
			if(pTemp){
				for(int y=0; y<bm.bmiHeader.biHeight; y++){

					LPBYTE pDest =        pTemp     + (y * Width);
					LPWORD pSrc  = LPWORD(m_pImage + (y * Pitch));

					for(int x=0; x<bm.bmiHeader.biWidth; x++){
						switch(m_BitMode){
						case 10:	pDest[0] = BYTE(pSrc[0] >> 2);	break;	// 10 bit
						case 12:	pDest[0] = BYTE(pSrc[0] >> 4);	break;	// 12 bit
						case 14:	pDest[0] = BYTE(pSrc[0] >> 6);	break;	// 14 bit
						case 16:	pDest[0] = BYTE(pSrc[0] >> 8);	break;	// 16 bit
						default:	pDest[0] = BYTE(pSrc[0]     );	break;	//  8 bit
						}

						pDest++;
						pSrc ++;
					}
				}


				SetDIBitsToDevice(hDC, -Pos.x, -Pos.y, bm.bmiHeader.biWidth, bm.bmiHeader.biHeight,
									0, 0, 0, bm.bmiHeader.biHeight, pTemp, (BITMAPINFO*)&bm, DIB_RGB_COLORS);
				delete[] pTemp;
			}
		}

		// Color 24 bit transfer
		else if(3 == Bpp){
			bm.bmiHeader.biBitCount = 24;
			SetDIBitsToDevice(hDC, -Pos.x, -Pos.y, bm.bmiHeader.biWidth, bm.bmiHeader.biHeight,
								0, 0, 0, bm.bmiHeader.biHeight, m_pImage, (BITMAPINFO*)&bm, DIB_RGB_COLORS);
		}

		// Color 32 bit transfer
		else if(4 == Bpp){
			bm.bmiHeader.biBitCount = 24;

			LPBYTE pTemp = new BYTE[bm.bmiHeader.biWidth * bm.bmiHeader.biHeight * 3];
			if(pTemp){
				for(int y=0; y<bm.bmiHeader.biHeight; y++){

					LPBYTE pDest = pTemp    + (y * bm.bmiHeader.biWidth * 3);
					LPBYTE pSrc  = m_pImage + (y * bm.bmiHeader.biWidth * 4);

					for(int x=0; x<bm.bmiHeader.biWidth; x++){
						pDest[0] = pSrc[0];
						pDest[1] = pSrc[1];
						pDest[2] = pSrc[2];

						pDest+=3;
						pSrc +=4;
					}
				}


				SetDIBitsToDevice(hDC, -Pos.x, -Pos.y, bm.bmiHeader.biWidth, bm.bmiHeader.biHeight,
									0, 0, 0, bm.bmiHeader.biHeight, pTemp, (BITMAPINFO*)&bm, DIB_RGB_COLORS);
				delete[] pTemp;
			}
		}

		// Color 48, 64 bit transfer
		else if(6 == Bpp || 8 == Bpp){
			bm.bmiHeader.biBitCount = 24;
			Bpp /= 2;

			LPBYTE pTemp = new BYTE[bm.bmiHeader.biWidth * bm.bmiHeader.biHeight * 3];
			if(pTemp){
				for(int y=0; y<bm.bmiHeader.biHeight; y++){

					LPBYTE pDest =        pTemp     + (y * bm.bmiHeader.biWidth * 3);
					LPWORD pSrc  = LPWORD(m_pImage) + (y * bm.bmiHeader.biWidth * Bpp);

					for(int x=0; x<bm.bmiHeader.biWidth; x++){
						switch(m_BitMode){
						case 10:	pDest[0] = BYTE(pSrc[0] >> 2);pDest[1] = BYTE(pSrc[1] >> 2);pDest[2] = BYTE(pSrc[2] >> 2);	break;	// 10 bit
						case 12:	pDest[0] = BYTE(pSrc[0] >> 4);pDest[1] = BYTE(pSrc[1] >> 4);pDest[2] = BYTE(pSrc[2] >> 4);	break;	// 12 bit
						case 14:	pDest[0] = BYTE(pSrc[0] >> 6);pDest[1] = BYTE(pSrc[1] >> 6);pDest[2] = BYTE(pSrc[2] >> 6);	break;	// 14 bit
						case 16:	pDest[0] = BYTE(pSrc[0] >> 8);pDest[1] = BYTE(pSrc[1] >> 8);pDest[2] = BYTE(pSrc[2] >> 8);	break;	// 16 bit
						default:	pDest[0] = BYTE(pSrc[0]     );pDest[1] = BYTE(pSrc[1]     );pDest[2] = BYTE(pSrc[2]     );	break;	//  8 bit
						}

						pDest+=3;
						pSrc +=Bpp;
					}
				}


				SetDIBitsToDevice(hDC, -Pos.x, -Pos.y, bm.bmiHeader.biWidth, bm.bmiHeader.biHeight,
									0, 0, 0, bm.bmiHeader.biHeight, pTemp, (BITMAPINFO*)&bm, DIB_RGB_COLORS);
				delete[] pTemp;
			}
		}


		if(Flg){
			::ReleaseDC(m_hWnd, hDC);
		}

		return 1;
	}

	return 0;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Draw line with SDK
//

void CSample_MFCView::OnShowPreview()
{
	// Not selected DLL
	if(-1 == m_DllType){
		AfxMessageBox(_T("Select DLL for the camera connected"));
		return;
	}

	// Delete timer
	if(3 == m_PreviewMode){
		KillTimer(CAP_TIMER_ID);
	}

	// Release device
	m_CArtCamSdk.Close();


	// Release area for image
	SAFE_DELETE(m_pImage);


	// Set window to be displayed
	// When setting NULL to hWnd,it is possible to create new window and show it.
	CRect rc;
	GetClientRect(&rc);
	m_CArtCamSdk.SetPreviewWindow(m_hWnd, 0, 0, rc.right, rc.bottom);

	// Display image
	m_CArtCamSdk.Preview();


	// Check menu
	CMenu* pShowMenu = GetParent()->GetMenu()->GetSubMenu(1);
	pShowMenu->CheckMenuItem(0, MF_BYPOSITION | MF_CHECKED);
	pShowMenu->CheckMenuItem(1, MF_BYPOSITION | MF_UNCHECKED);
	pShowMenu->CheckMenuItem(3, MF_BYPOSITION | MF_UNCHECKED);
	pShowMenu->CheckMenuItem(4, MF_BYPOSITION | MF_UNCHECKED);

	m_PreviewMode = 0;
	m_SaveFlg = TRUE;
	m_StopFlg = FALSE;
	GetParent()->GetMenu()->GetSubMenu(1)->ModifyMenu(6, MF_BYPOSITION | MF_STRING, ID_SHOW_STOP, _T("Pause"));

	ChangeScrollbar();
	Invalidate();
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Obtain image pointer and draw with application
//

void CSample_MFCView::OnShowCallback()
{
	// Not selected DLL
	if(-1 == m_DllType){
		AfxMessageBox(_T("Select DLL for the camera connected"));
		return;
	}

	// Delete timer
	if(3 == m_PreviewMode){
		KillTimer(CAP_TIMER_ID);
	}

	// Release device
	m_CArtCamSdk.Close();


	// Release area for image
	SAFE_DELETE(m_pImage);


	// If drawing by yourself, set all window size to 0.
	// An automatic display can be performed, if window size is set up even when using CallBackPreview
	m_CArtCamSdk.SetPreviewWindow(m_hWnd, 0, 0, 0, 0);


	// Secure the space for taking in
	m_pImage = new BYTE[ArtCamGetSize()];

	m_CArtCamSdk.CallBackPreview(m_hWnd, m_pImage, ArtCamGetSize(), 0);


	// Check menu
	CMenu* pShowMenu = GetParent()->GetMenu()->GetSubMenu(1);
	pShowMenu->CheckMenuItem(0, MF_BYPOSITION | MF_UNCHECKED);
	pShowMenu->CheckMenuItem(1, MF_BYPOSITION | MF_CHECKED);
	pShowMenu->CheckMenuItem(3, MF_BYPOSITION | MF_UNCHECKED);
	pShowMenu->CheckMenuItem(4, MF_BYPOSITION | MF_UNCHECKED);

	m_PreviewMode = 1;
	m_StopFlg = FALSE;
	GetParent()->GetMenu()->GetSubMenu(1)->ModifyMenu(6, MF_BYPOSITION | MF_STRING, ID_SHOW_STOP, _T("Pause"));

	ChangeScrollbar();
	Invalidate();
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Display one frame
//

void CSample_MFCView::OnShowSnapshot()
{
	// Not selected DLL
	if(-1 == m_DllType){
		AfxMessageBox(_T("Select DLL for the camera connected"));
		return;
	}

	// Delete timer
	if(3 == m_PreviewMode){
		KillTimer(CAP_TIMER_ID);
	}

	// Release device
	m_CArtCamSdk.Close();


	// Release area for image
	SAFE_DELETE(m_pImage);

	// Secure the space for taking in
	m_pImage = new BYTE[ArtCamGetSize()];

	m_CArtCamSdk.SnapShot(m_pImage, ArtCamGetSize(), 0);
	m_SaveFlg = TRUE;


	// Draw image
	DrawImage(NULL);

	// Check menu
	CMenu* pShowMenu = GetParent()->GetMenu()->GetSubMenu(1);
	pShowMenu->CheckMenuItem(0, MF_BYPOSITION | MF_UNCHECKED);
	pShowMenu->CheckMenuItem(1, MF_BYPOSITION | MF_UNCHECKED);
	pShowMenu->CheckMenuItem(3, MF_BYPOSITION | MF_UNCHECKED);
	pShowMenu->CheckMenuItem(4, MF_BYPOSITION | MF_UNCHECKED);

	m_PreviewMode = -1;
	m_StopFlg = FALSE;
	GetParent()->GetMenu()->GetSubMenu(1)->ModifyMenu(6, MF_BYPOSITION | MF_STRING, ID_SHOW_STOP, _T("Pause"));
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Draw line with SDK
//

void CSample_MFCView::OnShowCapture()
{
	// Not selected DLL
	if(-1 == m_DllType){
		AfxMessageBox(_T("Select DLL for the camera connected"));
		return;
	}

	// Release device
	m_CArtCamSdk.Close();

	// Release area for image
	SAFE_DELETE(m_pImage);

	// Secure the space for taking in
	m_pImage = new BYTE[ArtCamGetSize()];

	m_CArtCamSdk.Capture();


	// Check menu
	CMenu* pShowMenu = GetParent()->GetMenu()->GetSubMenu(1);
	pShowMenu->CheckMenuItem(0, MF_BYPOSITION | MF_UNCHECKED);
	pShowMenu->CheckMenuItem(1, MF_BYPOSITION | MF_UNCHECKED);
	pShowMenu->CheckMenuItem(3, MF_BYPOSITION | MF_CHECKED);
	pShowMenu->CheckMenuItem(4, MF_BYPOSITION | MF_UNCHECKED);

	m_PreviewMode = 3;
	m_StopFlg = FALSE;
	GetParent()->GetMenu()->GetSubMenu(1)->ModifyMenu(6, MF_BYPOSITION | MF_STRING, ID_SHOW_STOP, _T("Pause"));

	ChangeScrollbar();
	Invalidate();

	SetTimer(CAP_TIMER_ID, TIMER_TIME, NULL);
}


void CSample_MFCView::OnTimer(UINT_PTR nIDEvent)
{
	if(3 == m_PreviewMode && CAP_TIMER_ID == nIDEvent){
		KillTimer(CAP_TIMER_ID);

		m_CArtCamSdk.SnapShot(m_pImage, ArtCamGetSize(), 0);
		m_SaveFlg = TRUE;

		// Draw image
		DrawImage(NULL);

		SetTimer(CAP_TIMER_ID, TIMER_TIME, NULL);
	}

	// Finish recording
	if(REC_TIMER_ID == nIDEvent){
		m_CArtCamSdk.Close();
		KillTimer(REC_TIMER_ID);

		if(IDYES == MessageBox(_T("Recording completePlay /n file?"), _T("Complete"), MB_YESNO | MB_ICONQUESTION)){
			::ShellExecute(NULL, NULL, m_RecName, NULL, NULL, SW_SHOWNORMAL);
		}
	}

	CView::OnTimer(nIDEvent);
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Trigger mode
//

void CSample_MFCView::OnShowTrigger()
{
	// Not selected DLL
	if(-1 == m_DllType){
		AfxMessageBox(_T("Select DLL for the camera connected"));
		return;
	}

	// Delete timer
	if(3 == m_PreviewMode){
		KillTimer(CAP_TIMER_ID);
	}

	// Release device
	m_CArtCamSdk.Close();


	// Release area for image
	SAFE_DELETE(m_pImage);


	// If drawing by yourself, set all window size to 0.
	// An automatic display can be performed, if window size is set up even when using CallBackPreview
	m_CArtCamSdk.SetPreviewWindow(m_hWnd, 0, 0, 0, 0);



	// Secure the space for taking in
	m_pImage = new BYTE[ArtCamGetSize()];

	m_CArtCamSdk.Trigger(m_hWnd, m_pImage, ArtCamGetSize(), 0);


	// Check menu
	CMenu* pShowMenu = GetParent()->GetMenu()->GetSubMenu(1);
	pShowMenu->CheckMenuItem(0, MF_BYPOSITION | MF_UNCHECKED);
	pShowMenu->CheckMenuItem(1, MF_BYPOSITION | MF_UNCHECKED);
	pShowMenu->CheckMenuItem(3, MF_BYPOSITION | MF_UNCHECKED);
	pShowMenu->CheckMenuItem(4, MF_BYPOSITION | MF_CHECKED);

	m_PreviewMode = 4;
	m_StopFlg = FALSE;
	GetParent()->GetMenu()->GetSubMenu(1)->ModifyMenu(6, MF_BYPOSITION | MF_STRING, ID_SHOW_STOP, _T("Pause"));

	ChangeScrollbar();
	Invalidate();
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Display pause/resume
//

void CSample_MFCView::OnShowStop()
{
	// Stop only for animated picture
	if(0 == m_PreviewMode || 1 == m_PreviewMode){
		if(m_StopFlg){
			m_CArtCamSdk.StartPreview();
			m_StopFlg = FALSE;

			GetParent()->GetMenu()->GetSubMenu(1)->ModifyMenu(6, MF_BYPOSITION | MF_STRING, ID_SHOW_STOP, _T("Pause"));
		}
		else {
			m_CArtCamSdk.StopPreview();
			m_StopFlg = TRUE;

			GetParent()->GetMenu()->GetSubMenu(1)->ModifyMenu(6, MF_BYPOSITION | MF_STRING, ID_SHOW_STOP, _T("Resume"));
		}
	}
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Change DLL
//

BOOL CSample_MFCView::OnDllChange(LONG DllType, LONG SataType)
{
	// Release all devices before switching DLL
	// To display multiple images simulteously, you need to define CArtCamSdk plurally
	// When defined plurally, you do not need to relase to switch cameras
	m_CArtCamSdk.Release();
	m_CArtCamSdk.FreeLibrary();

	int i=0;


	CMenu* pMenu = GetParent()->GetMenu();
	CMenu* pDllMenu = pMenu->GetSubMenu(3);

	TCHAR szDllName[MAX_PATH]=_T("");
	pDllMenu->GetMenuString(DllType+1, szDllName, MAX_PATH, MF_BYPOSITION);
	for(i=0; i<lstrlen(szDllName); i++){
		if('\t' == szDllName[i]){
			szDllName[i] = '\0';
			break;
		}
	}
#if defined(__VS2005__) | (__VS2010__)
	_tcscat_s(szDllName, MAX_PATH, _T(".dll"));
#else
	_tcscat(szDllName, _T(".dll"));
#endif

	BOOL res = m_CArtCamSdk.LoadLibrary(szDllName);

	if(!res){
		CString Error;
		Error.Format(_T("DLL is not found.\nIt may have been relocated after executing."));
		AfxMessageBox(Error);
		return FALSE;
	}else{
		m_CurrentCameraType = HIWORD(m_CArtCamSdk.GetDllVersion());
	}
	// Initialize is to be called first
	// By setting Window Handle here, WMLERROR can be obtained
	if(!m_CArtCamSdk.Initialize(m_hWnd)){
		AfxMessageBox(_T("Failed to initialize SDK"));
		return FALSE;
	}

	m_DllType  = DllType;
	m_SataType = SataType;

	// Select SATA camera type when use Sata.dll
	if(-1 != SataType && ARTCAM_CAMERATYPE_SATA == m_CurrentCameraType){
		m_CArtCamSdk.SetCameraType(SataType);

		// Prefer to specify the Capture size
		switch(SataType){
		case	ARTCAM_CAMERATYPE_SATA_LVDS	: /*m_CArtCamSdk.SetCaptureWindowEx(1280,0,1280,1024,0,1024);*/ break;
		case 	ARTCAM_CAMERATYPE_SATA_300MI: /*m_CArtCamSdk.SetCaptureWindowEx(2048,0,2048,1536,0,1536);*/ break;
		case 	ARTCAM_CAMERATYPE_SATA_500MI: /*m_CArtCamSdk.SetCaptureWindowEx(2560,0,2560,1920,0,1920);*/ break;
		case 	ARTCAM_CAMERATYPE_SATA_MV413: /*m_CArtCamSdk.SetCaptureWindowEx(1280,0,1280,1024,0,1024);*/ break;
		case 	ARTCAM_CAMERATYPE_SATA_036MI: /*m_CArtCamSdk.SetCaptureWindowEx( 752,0, 640, 480,0, 480);*/ break;
		case 	ARTCAM_CAMERATYPE_SATA_267KY: /*m_CArtCamSdk.SetCaptureWindowEx(1360,0,1360,1024,0,1024);*/ break;
		case 	ARTCAM_CAMERATYPE_SATA_274KY: /*m_CArtCamSdk.SetCaptureWindowEx(1600,0,1600,1200,0,1200);*/ break;
		case 	ARTCAM_CAMERATYPE_SATA_625KY: /*m_CArtCamSdk.SetCaptureWindowEx(2456,0,2456,2041,0,2041);*/ break;
		case	ARTCAM_CAMERATYPE_SATA_130MI: /*m_CArtCamSdk.SetCaptureWindowEx(1280,0,1280,1024,0,1024);*/ break;
		case	ARTCAM_CAMERATYPE_SATA_200MI: /*m_CArtCamSdk.SetCaptureWindowEx(1600,0,1600,1200,0,1200);*/ break;
		default:							  /*m_CArtCamSdk.SetCaptureWindowEx(1280,0,1280,1024,0,1024);*/ break;
		}
	}

	CheckColorMode();



	// Check menu
	for(i=0; i<m_DllCount; i++){
		pDllMenu->CheckMenuItem(i+1, MF_BYPOSITION | MF_UNCHECKED);
	}
	pDllMenu->CheckMenuItem(DllType+1, MF_BYPOSITION | MF_CHECKED);

	if(-1 != SataType && ARTCAM_CAMERATYPE_SATA == m_CurrentCameraType){
		for(int type=0; type<ARTCAM_CAMERATYPE_SATA_200MI-ARTCAM_CAMERATYPE_SATA_LVDS+1; type++){
			pDllMenu->GetSubMenu(m_DllSata+1)->CheckMenuItem(type, MF_BYPOSITION | MF_UNCHECKED);
		}
		pDllMenu->GetSubMenu(m_DllSata+1)->CheckMenuItem(m_SataType, MF_BYPOSITION | MF_CHECKED);
	}


	// Device modification menu
	CMenu* pDeviceMenu = pMenu->GetSubMenu(4);

	TCHAR szName[10][256];
	TCHAR szDef[10][256] = { _T("0"), _T("1"), _T("2"), _T("3"), _T("4"), _T("5"), _T("6"), _T("7"), _T("8"), _T("9") };
	m_DeviceCount = m_CArtCamSdk.EnumDevice(szName);

	for(i=0; i<m_DeviceCount; i++){
		pDeviceMenu->ModifyMenu(i, MF_BYPOSITION | MF_STRING, ID_DEVICE01 + i, szName[i]);
	}
	for(; i<10; i++){
		pDeviceMenu->ModifyMenu(i, MF_BYPOSITION | MF_STRING, ID_DEVICE01 + i, szDef[i]);
	}

	m_SaveFlg = FALSE;

	// Device setting
	return OnDeviceChange(0);
}


void CSample_MFCView::OnDllReload()
{
	// Delete DLL list
	CMenu* pMenu = GetParent()->GetMenu();
	CMenu* pDllMenu = pMenu->GetSubMenu(3);
	for(int i=0; i<m_DllCount; i++){
		pDllMenu->DeleteMenu(1, MF_BYPOSITION);
	}
	m_DllCount = 0;
	m_DllSata  = -1;

	// Search for DLL
	TCHAR szDir[MAX_PATH]=_T("");
	TCHAR szExePath[3][MAX_PATH]={_T(""),_T(""),_T("")};
	GetModuleFileName(::GetModuleHandle(NULL), szExePath[0], MAX_PATH);
#if defined(__VS2005__) | (__VS2010__)
	_tsplitpath_s(szExePath[0], szExePath[1], MAX_PATH, szExePath[2], MAX_PATH, NULL, 0, NULL, 0);
#else
	_tsplitpath(szExePath[0], szExePath[1], szExePath[2], NULL, NULL);
#endif
	wsprintf(szDir, _T("%s%s"), szExePath[1], szExePath[2]);

	TCHAR szSearch[MAX_PATH]=_T("");
	wsprintf(szSearch, _T("%s\\*.dll"), szDir);

	HANDLE	hFindFile = NULL;
	WIN32_FIND_DATA	fd;
	ZeroMemory(&fd, sizeof(WIN32_FIND_DATA));

	if(INVALID_HANDLE_VALUE != (hFindFile = ::FindFirstFile(szSearch, &fd))){
		do {
			TCHAR szFileName[MAX_PATH]=_T("");
			wsprintf(szFileName, _T("%s\\%s"), szDir, fd.cFileName);

			DWORD dwResult = (::GetFileAttributes(szFileName) & FILE_ATTRIBUTE_DIRECTORY);

			if(FILE_ATTRIBUTE_DIRECTORY != dwResult){

				CArtCamSdk ArtCam;
				if(ArtCam.LoadLibrary(szFileName)){
					CString str;

					// Obtain version and show it
					TCHAR szDllName[MAX_PATH]=_T("");
#if defined(__VS2005__) | (__VS2010__)
					_tsplitpath_s(fd.cFileName, NULL, 0, NULL, 0, szDllName, MAX_PATH, NULL, 0);
#else
					_tsplitpath(fd.cFileName, NULL, NULL, szDllName, NULL);
#endif
					str.Format(_T("%s\tVersion %04d"), szDllName, LOWORD(ArtCam.GetDllVersion()));

					// Add to menu
					m_DllCount++;

					// Select SATA camera type when use Sata.dll
					if(ARTCAM_CAMERATYPE_SATA == HIWORD(ArtCam.GetDllVersion())){
						HMENU MenuSata = ::CreateMenu();
						::InsertMenu(MenuSata, 0, MF_BYPOSITION | MF_STRING, ID_DLL_SATA_LVDS,	_T("LVDS"));
						::InsertMenu(MenuSata, 1, MF_BYPOSITION | MF_STRING, ID_DLL_SATA_300MI, _T("300MI"));
						::InsertMenu(MenuSata, 2, MF_BYPOSITION | MF_STRING, ID_DLL_SATA_500MI, _T("500MI"));
						::InsertMenu(MenuSata, 3, MF_BYPOSITION | MF_STRING, ID_DLL_SATA_MV413, _T("MV413"));
						::InsertMenu(MenuSata, 4, MF_BYPOSITION | MF_STRING, ID_DLL_SATA_800MI, _T("800MI"));
						::InsertMenu(MenuSata, 5, MF_BYPOSITION | MF_STRING, ID_DLL_SATA_036MI, _T("036MI"));
						::InsertMenu(MenuSata, 6, MF_BYPOSITION | MF_STRING, ID_DLL_SATA_150P3, _T("150P3"));
						::InsertMenu(MenuSata, 7, MF_BYPOSITION | MF_STRING, ID_DLL_SATA_267KY, _T("267KY"));
						::InsertMenu(MenuSata, 8, MF_BYPOSITION | MF_STRING, ID_DLL_SATA_274KY, _T("274KY"));
						::InsertMenu(MenuSata, 9, MF_BYPOSITION | MF_STRING, ID_DLL_SATA_625KY, _T("625KY"));
						::InsertMenu(MenuSata,10, MF_BYPOSITION | MF_STRING, ID_DLL_SATA_130MI, _T("130MI"));
						::InsertMenu(MenuSata,11, MF_BYPOSITION | MF_STRING, ID_DLL_SATA_200MI, _T("200MI"));
						pDllMenu->AppendMenu(MF_STRING | MF_POPUP, (UINT_PTR)MenuSata, str);
						m_DllSata = m_DllCount-1;
					}
					else{
						pDllMenu->AppendMenu(MF_STRING, ID_DLL_RELOAD+m_DllCount, str);
					}
				}
			}
		}
		while(::FindNextFile(hFindFile, &fd));

		::FindClose(hFindFile);
		hFindFile = NULL;
	}
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Change device
//

BOOL CSample_MFCView::OnDeviceChange(LONG Number)
{
	// Not selected DLL
	if(-1 == m_DllType){
		AfxMessageBox(_T("Select DLL for the camera connected"));
		return FALSE;
	}


	// Release the operative device before switching device
	m_CArtCamSdk.Close();


	// To confirm whether the device is connected, use "GetDeviceName"
	// It can be found out easily with "GetDeviceName".
	// When area for obtain name is not secured, it results in error. Prepare alignment length of at least 32.
	TCHAR szName[256]=_T("");
	if(!m_CArtCamSdk.GetDeviceName(Number, szName, 256)){
		m_PreviewMode = -1;
		m_SelectDevice = -1;
		m_StopFlg = FALSE;
		GetParent()->GetMenu()->GetSubMenu(1)->ModifyMenu(6, MF_BYPOSITION | MF_STRING, ID_SHOW_STOP, _T("Pause"));
		return FALSE;
	}


	// A device will be changed, if a camera is displayed after changing the number of a device now
	// Notes: A device is not changed in this function simple substance
	//   After calling this function, a device is changed by initializing a device
	m_SelectDevice = Number;
	m_CArtCamSdk.SetDeviceNumber(Number);


	CMenu* pMenu = GetParent()->GetMenu();
	CMenu* pDeviceMenu = pMenu->GetSubMenu(4);

	for(int i=0; i<8; i++){
		pDeviceMenu->CheckMenuItem(i, MF_BYPOSITION | MF_UNCHECKED);
	}
	pDeviceMenu->CheckMenuItem(Number, MF_BYPOSITION | MF_CHECKED);


	switch(m_PreviewMode){
	case 0: OnShowPreview();  return TRUE;
	case 1: OnShowCallback(); return TRUE;
	case 3: OnShowCapture(); return TRUE;
	case 4: OnShowTrigger(); return TRUE;
	}

	return TRUE;
}

void CSample_MFCView::OnDevice01()	{ OnDeviceChange(0); }
void CSample_MFCView::OnDevice02()	{ OnDeviceChange(1); }
void CSample_MFCView::OnDevice03()	{ OnDeviceChange(2); }
void CSample_MFCView::OnDevice04()	{ OnDeviceChange(3); }
void CSample_MFCView::OnDevice05()	{ OnDeviceChange(4); }
void CSample_MFCView::OnDevice06()	{ OnDeviceChange(5); }
void CSample_MFCView::OnDevice07()	{ OnDeviceChange(6); }
void CSample_MFCView::OnDevice08()	{ OnDeviceChange(7); }


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Setting window
//

void CSample_MFCView::OnSetFormat()
{
	// Please use this function after stop image
	// In case of calling before stop
	// Stop with SDK and restart to display after close dialog

	// In this case it reflects image size of SDK when change size
	// Also there is possibility not to obtain image correctly if you don't refresh data saved in application

	m_CArtCamSdk.Close();
	m_CArtCamSdk.SetCameraDlg(m_hWnd);

	// Check the bit mode
	CheckColorMode();

	switch(m_PreviewMode){
	case 0: OnShowPreview();  return ;
	case 1: OnShowCallback(); return ;
	case 3: OnShowCapture(); return ;
	case 4: OnShowTrigger(); return ;
	}
}

void CSample_MFCView::OnSetFilter()
{
	// Please call this function
	// on condition that animated picture is displayed
	// It is possible to set while stop, but it is not recommended

	m_CArtCamSdk.SetImageDlg(m_hWnd);
}

void CSample_MFCView::OnSetAnalog()
{
	// Please call this function
	// on condition that animated picture is displayed
	// It is possible to set while stop, but it is not recommended

	m_CArtCamSdk.SetAnalogDlg(m_hWnd);
}

void CSample_MFCView::OnSetFilterApp()
{
	// A large quantity of functions  for setting are used inside
	// Please use on condition camera is connected

	// It is possible to set the number controlled inside of SDK
	// even if camera is not connected
	// but it is not recommended

	CSetFilterDlg SFD;
	SFD.m_pCArtCamSdk = &m_CArtCamSdk;
	SFD.m_Preview = m_PreviewMode;
	SFD.DoModal();
}

void CSample_MFCView::OnSetSizeApp()
{
	m_CArtCamSdk.Close();

	CSetSizeDlg SSD;
	SSD.m_pCArtCamSdk = &m_CArtCamSdk;
	SSD.DoModal();

	// Check the bit mode
	CheckColorMode();

	switch(m_PreviewMode){
	case 0: OnShowPreview();  return ;
	case 1: OnShowCallback(); return ;
	case 3: OnShowCapture(); return ;
	case 4: OnShowTrigger(); return ;
	}
}

void CSample_MFCView::OnSetIoApp()
{
	CSetIODlg SID;
	SID.m_pCArtCamSdk = &m_CArtCamSdk;
	SID.DoModal();
}

void CSample_MFCView::OnSetMonitorApp()
{
	switch(m_CurrentCameraType){
	case ARTCAM_CAMERATYPE_130MI_MOUT:
	case ARTCAM_CAMERATYPE_150P3_MOUT:
	{
	CSetMonitorDlg SMD;
	SMD.m_pCArtCamSdk = &m_CArtCamSdk;
		SMD.m_DllType = m_CurrentCameraType;
	SMD.DoModal();
	}
	break;
	case ARTCAM_CAMERATYPE_1000MI_HD2:
	{
		CSetMonitorDlg2 SMD;
		SMD.m_pCArtCamSdk = &m_CArtCamSdk;
		SMD.m_DllType = m_CurrentCameraType;
		SMD.DoModal();
	}
	break;
	}
}


void CSample_MFCView::OnSetCorrection()
{
	CSetCorrection	CSC;
	CSC.m_pCArtCamSdk = &m_CArtCamSdk;
	CSC.DoModal();
}

//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Menu
//

void CSample_MFCView::InitMenuPopup(CMenu* pPopupMenu)
{
	CMenu* pMenu = GetParent()->GetMenu();

	// Something related to file archive
	if(pPopupMenu == pMenu->GetSubMenu(0)){
		// Check if saving is available (if an image has been captured at least once, it is possible).
		if(m_SaveFlg){
			pPopupMenu->EnableMenuItem(0, MF_BYPOSITION | MF_ENABLED);
		} else {
			pPopupMenu->EnableMenuItem(0, MF_BYPOSITION | MF_GRAYED);
		}

		// Check is the camera is Directshow compatible
		// Only Directshow camera has recording function
		if(1300 <= LOWORD(m_CArtCamSdk.GetDllVersion()) || 
			ARTCAM_CAMERATYPE_DS == m_CurrentCameraType){
			pPopupMenu->EnableMenuItem(1, MF_BYPOSITION | MF_ENABLED);
		} else {
			pPopupMenu->EnableMenuItem(1, MF_BYPOSITION | MF_GRAYED);
		}
	}

	// Related to drawing line
	if(pPopupMenu == pMenu->GetSubMenu(1)){
		// Disable playback if device is not connected
		if(-1 == m_SelectDevice){
			pPopupMenu->EnableMenuItem(0, MF_BYPOSITION | MF_GRAYED);
			pPopupMenu->EnableMenuItem(1, MF_BYPOSITION | MF_GRAYED);
			pPopupMenu->EnableMenuItem(2, MF_BYPOSITION | MF_GRAYED);
			pPopupMenu->EnableMenuItem(3, MF_BYPOSITION | MF_GRAYED);
			pPopupMenu->EnableMenuItem(4, MF_BYPOSITION | MF_GRAYED);
		} else {
			pPopupMenu->EnableMenuItem(0, MF_BYPOSITION | MF_ENABLED);
			pPopupMenu->EnableMenuItem(1, MF_BYPOSITION | MF_ENABLED);
			pPopupMenu->EnableMenuItem(2, MF_BYPOSITION | MF_ENABLED);
			pPopupMenu->EnableMenuItem(3, MF_BYPOSITION | MF_ENABLED);

			// Remark: Trigger mode is not available in every model.
			switch(m_CurrentCameraType){
			case ARTCAM_CAMERATYPE_DS:
			case ARTCAM_CAMERATYPE_USTC:
			case ARTCAM_CAMERATYPE_CNV:
			case ARTCAM_CAMERATYPE_200SH:
			case ARTCAM_CAMERATYPE_098:
			case ARTCAM_CAMERATYPE_500P:
			case ARTCAM_CAMERATYPE_130MI_MOUT:
			case ARTCAM_CAMERATYPE_150P3_MOUT:
			case ARTCAM_CAMERATYPE_900MI:
				pPopupMenu->EnableMenuItem(4, MF_BYPOSITION | MF_GRAYED);
			break;

			default:
				pPopupMenu->EnableMenuItem(4, MF_BYPOSITION | MF_ENABLED);
			break;
			}
		}
	}

	// Switch to ON or OFF of setting window
	if(pPopupMenu == pMenu->GetSubMenu(2)){

		// Directshow is not available in every model.
		// Note that "SetAnalogDlg" is not available in many models.
		pPopupMenu->EnableMenuItem(0, MF_BYPOSITION | MF_ENABLED);
		pPopupMenu->EnableMenuItem(1, MF_BYPOSITION | MF_ENABLED);

		switch(m_CurrentCameraType){
		case ARTCAM_CAMERATYPE_USTC:
		case ARTCAM_CAMERATYPE_CNV:
			pPopupMenu->EnableMenuItem(2, MF_BYPOSITION | MF_GRAYED);
		break;

		default:
			pPopupMenu->EnableMenuItem(2, MF_BYPOSITION | MF_ENABLED);
		break;
		}
	
		switch(m_CurrentCameraType){
		case ARTCAM_CAMERATYPE_130MI_MOUT:
		case ARTCAM_CAMERATYPE_150P3_MOUT:
		case ARTCAM_CAMERATYPE_1000MI_HD2:
			pPopupMenu->EnableMenuItem(7, MF_BYPOSITION | MF_ENABLED);
		break;

		default:
			pPopupMenu->EnableMenuItem(7, MF_BYPOSITION | MF_GRAYED);
		break;
		}

		switch(m_CurrentCameraType){
		case ARTCAM_CAMERATYPE_008TNIR:
		case ARTCAM_CAMERATYPE_031TNIR:
		case ARTCAM_CAMERATYPE_0016TNIR:
			pPopupMenu->EnableMenuItem(8, MF_BYPOSITION | MF_ENABLED);
		break;

		default:
			pPopupMenu->EnableMenuItem(8, MF_BYPOSITION | MF_GRAYED);
		break;
		}
	}
	int i=0;

	// Active DLL
	if(pPopupMenu == pMenu->GetSubMenu(3)){
		for(i=0; i<m_DllCount+1; i++){
				pPopupMenu->EnableMenuItem(i, MF_BYPOSITION | MF_ENABLED);
			}			
		}

	// Active device
	if(pPopupMenu == pMenu->GetSubMenu(4)){
		for(i=0; i<m_DeviceCount; i++){
			pPopupMenu->EnableMenuItem(i, MF_BYPOSITION | MF_ENABLED);
			pPopupMenu->CheckMenuItem(i, MF_BYPOSITION | MF_UNCHECKED);
		}
		for(; i<10; i++){
			pPopupMenu->EnableMenuItem(i, MF_BYPOSITION | MF_GRAYED);
			pPopupMenu->CheckMenuItem(i, MF_BYPOSITION | MF_UNCHECKED);
		}

		pPopupMenu->CheckMenuItem(m_SelectDevice, MF_BYPOSITION | MF_CHECKED);
	}
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	
//

void CSample_MFCView::ChangeScrollbar(void)
{
	if(0 == m_PreviewMode){
		SetScrollPos(SB_HORZ, 0);
		SetScrollPos(SB_VERT, 0);
		ShowScrollBar(SB_HORZ, FALSE);
		ShowScrollBar(SB_VERT, FALSE);
		return;
	}


	CRect rc;
	GetClientRect(&rc);

	LONG lWidth  = ArtCamGetWidth();
	LONG lHeight = ArtCamGetHeight();

	LONG PosX = GetScrollPos(SB_HORZ);
	LONG PosY = GetScrollPos(SB_VERT);


	SCROLLINFO sc;
	sc.fMask	= SIF_RANGE | SIF_POS | SIF_PAGE;

	LONG OffsetH = 16;
	LONG OffsetV = 16;


	if(rc.right + OffsetH >= lWidth){
		ShowScrollBar(SB_HORZ, FALSE);
	} else {
		sc.nMin		= 0;
		sc.nMax		= lWidth;
		sc.nPage	= rc.right;
		sc.nPos		= PosX;
		SetScrollInfo(SB_HORZ, &sc);
	}

	if(rc.bottom + OffsetV >= lHeight){
		ShowScrollBar(SB_VERT, FALSE);
	} else {
		sc.nMin		= 0;
		sc.nMax		= lHeight;
		sc.nPage	= rc.bottom;
		sc.nPos		= PosY;
		SetScrollInfo(SB_VERT, &sc);
	}

	if(lWidth  - rc.right  < PosX)	SetScrollPos(SB_HORZ, lWidth  - rc.right);
	if(lHeight - rc.bottom < PosY)	SetScrollPos(SB_VERT, lHeight - rc.bottom);
	if(0.0 > PosX)					SetScrollPos(SB_HORZ, 0);
	if(0.0 > PosY)					SetScrollPos(SB_VERT, 0);
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Change size
//

void CSample_MFCView::OnSize(UINT nType, int cx, int cy)
{
	CView::OnSize(nType, cx, cy);

	if(0 == m_PreviewMode){
		CWnd* pChild = GetWindow(GW_CHILD);
		if(pChild){
			CRect rc;
			GetClientRect(&rc);


			// To avoiding changing aspect ratio, remove comment
/*
			// Calculation results in decimal figure. So apply floating-point calculations.
			double winW = rc.right;
			double winH = rc.bottom;
			double capW = ArtCamGetWidth();
			double capH = ArtCamGetHeight();

			if( (winW * capH) > (winH * capW) ){
				winW = winH * capW / capH;
				rc.right = LONG(winW);
			}
			else if( (winW * capH) < (winH * capW) ){
				winH = winW * capH / capW;
				rc.bottom = LONG(winH);
			}
*/
			pChild->SetWindowPos(&CWnd::wndTop, 0, 0, rc.right, rc.bottom, SWP_NOMOVE | SWP_NOZORDER | SWP_SHOWWINDOW);
		}
	}

	if(1 == m_PreviewMode || 3 == m_PreviewMode || 4 == m_PreviewMode){
		ChangeScrollbar();
	}
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	
//

void CSample_MFCView::OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar)
{
	SCROLLINFO sc;
	GetScrollInfo(SB_HORZ, &sc);

	switch(nSBCode){
	case SB_LEFT:			SetScrollPos(SB_HORZ, 0);									break;
	case SB_ENDSCROLL:																	break;
	case SB_LINELEFT:		SetScrollPos(SB_HORZ, GetScrollPos(SB_HORZ) - sc.nPage/4);	break;
	case SB_LINERIGHT:		SetScrollPos(SB_HORZ, GetScrollPos(SB_HORZ) + sc.nPage/4);	break;
	case SB_PAGELEFT:		SetScrollPos(SB_HORZ, GetScrollPos(SB_HORZ) - sc.nPage);	break;
	case SB_PAGERIGHT:		SetScrollPos(SB_HORZ, GetScrollPos(SB_HORZ) + sc.nPage);	break;
	case SB_RIGHT:			SetScrollPos(SB_HORZ, GetScrollLimit(SB_HORZ));				break;
	case SB_THUMBPOSITION:	nPos &= 0x0000FFFF;	SetScrollPos(SB_HORZ, nPos);			break;
	case SB_THUMBTRACK:		nPos &= 0x0000FFFF;	SetScrollPos(SB_HORZ, nPos);			break;
	}

	DrawImage(NULL);

	CView::OnHScroll(nSBCode, nPos, pScrollBar);
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	
//

void CSample_MFCView::OnVScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar)
{
	SCROLLINFO sc;
	GetScrollInfo(SB_VERT, &sc);

	switch(nSBCode){
	case SB_LEFT:			SetScrollPos(SB_VERT, 0);									break;
	case SB_ENDSCROLL:																	break;
	case SB_LINELEFT:		SetScrollPos(SB_VERT, GetScrollPos(SB_VERT) - sc.nPage/4);	break;
	case SB_LINERIGHT:		SetScrollPos(SB_VERT, GetScrollPos(SB_VERT) + sc.nPage/4);	break;
	case SB_PAGELEFT:		SetScrollPos(SB_VERT, GetScrollPos(SB_VERT) - sc.nPage);	break;
	case SB_PAGERIGHT:		SetScrollPos(SB_VERT, GetScrollPos(SB_VERT) + sc.nPage);	break;
	case SB_RIGHT:			SetScrollPos(SB_VERT, GetScrollLimit(SB_VERT));				break;
	case SB_THUMBPOSITION:	nPos &= 0x0000FFFF;	SetScrollPos(SB_VERT, nPos);			break;
	case SB_THUMBTRACK:		nPos &= 0x0000FFFF;	SetScrollPos(SB_VERT, nPos);			break;
	}

	DrawImage(NULL);

	CView::OnVScroll(nSBCode, nPos, pScrollBar);
}

//////////////////////////////////////////////////////////////////////////////////////////////
//
//	
//

void CSample_MFCView::OnMouseMove(UINT nFlags, CPoint point)
{
	CString strx, stry;
	strx.Format(_T("%d"), point.x + GetScrollPos(SB_HORZ));
	stry.Format(_T("%d"), point.y + GetScrollPos(SB_VERT));

	static_cast<CMainFrame*>(theApp.m_pMainWnd)->SetStatusText(STATUS_X, strx);
	static_cast<CMainFrame*>(theApp.m_pMainWnd)->SetStatusText(STATUS_Y, stry);

	CView::OnMouseMove(nFlags, point);
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
// 
//  


void CSample_MFCView::CheckColorMode(void)
{
	// Over ver.1300 
	if(1300 <= LOWORD(m_CArtCamSdk.GetDllVersion())){
		LONG ColorMode = m_CArtCamSdk.GetColorMode();
		switch(ColorMode){
			case 10:	case 42:	case 58:	m_BitMode = 10;	break;
			case 12:	case 44:	case 60:	m_BitMode = 12;	break;
			case 14:	case 46:	case 62:	m_BitMode = 14;	break;
			case 16:	case 48:	case 64:	m_BitMode = 16;	break;
			default:							m_BitMode = 8;	break;
		}
	}else{
		// Normal cameras output 10-bit data.
		m_BitMode = 10;
	}

	// On ArtCnvII  Data[15:0] -> Y[9:2] ... UV[6:0]Y[1:0]
	if(ARTCAM_CAMERATYPE_CNV == HIWORD(m_CArtCamSdk.GetDllVersion())){
		m_BitMode = 8;
	}
}

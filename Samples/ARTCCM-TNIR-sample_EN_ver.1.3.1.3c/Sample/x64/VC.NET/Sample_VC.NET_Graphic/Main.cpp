//==========================================================
//	ARTRAY Camera / Capture Module Software Developer Kit
//						Preview/Callback function sample
//						VC++.NET Win32 Project
//
//									(C) 2002-2005 Artray
//==========================================================




//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Include file
//

#include <windows.h>
#include <stdio.h>
#include <tchar.h>

// Library include
#include "CArtCamSdk.hpp"
#include "CDib.h"


// Various menu ID 
enum {
	IDM_SAVE = WM_USER + 1,
	IDM_EXIT,

	IDM_PREVIEW,
	IDM_CALLBACK,
	IDM_SNAPSHOT,
	IDM_CAPTURE,
	IDM_TRIGGER,

	IDM_FORMAT,
	IDM_FILTER,
	IDM_ANALOG,

	IDM_WIDEHI,
	IDM_WIDELOW,
	IDM_NORMALHI,
	IDM_NORMALLOW,

	ID_DLL_SATA_LVDS,	
	ID_DLL_SATA_300MI,
	ID_DLL_SATA_500MI,
	ID_DLL_SATA_MV413,
	ID_DLL_SATA_800MI,
	ID_DLL_SATA_036MI,
	ID_DLL_SATA_150P3,
	ID_DLL_SATA_267KY,
	ID_DLL_SATA_274KY,
	ID_DLL_SATA_625KY,
	ID_DLL_SATA_130MI,
	ID_DLL_SATA_200MI,


	IDM_DLL_RELOAD,
};



// WM_USER + 50 - WM_USER + 59 Reserved for device settings
#define IDM_DEVICE		WM_USER + 50


#define TIMER_ID	100
#define TIMER_TIME	50



CArtCamSdk	g_CArtCamSdk;
CDib		g_CDibCapture;		// Space for capture
CDib		g_CDibView;			// Space for display(only 24 bit color)

BOOL		g_Preview = -1;		// Preview display/Callback display
LONG		g_DllType = -1;		// DLL to be connected
LONG		g_DllSata = -1;		// DllCount of SATA
LONG		g_DllCount= 0;		// The number of DLL found
LONG		g_SataType= -1;		// SATA camera type
LONG		g_DeviceCount = 0;	// Number of detected device


const int SUB_SAMPLE[] = { 1, 2, 4, 8 };
#define ArtCamGetWidth()	(g_CArtCamSdk.Width()  / SUB_SAMPLE[g_CArtCamSdk.GetSubSample() & 0x03])
#define ArtCamGetHeight()	(g_CArtCamSdk.Height() / SUB_SAMPLE[g_CArtCamSdk.GetSubSample() & 0x03])
#define ArtCamGetColor()	WORD(((g_CArtCamSdk.GetColorMode() + 7) / 8) * 8)


struct SCROLL_CTRL{
	POINT	Pos;

	BOOL	MoveFlg;
	POINT	Start;
};

SCROLL_CTRL	g_ScrollCtrl;

struct MENU_LIST{
	HMENU	File;
	HMENU	Preview;
	HMENU	Set;
	HMENU	Dll;
	HMENU	Device;
	HMENU	Rate;
};

MENU_LIST g_Menu;

const TCHAR ERRORLIST[][128] = {
	_T(""),
	_T("Not initialized"),
	_T("Access to unavailable device was attempted"),
	_T("Failure of thread creation for capturing"),
	_T("Window creation failed"),
	_T("Not enough memory for image transfer/Failure for securing memory"),
	_T("Error for camera (device) settings"),
	_T("Error for camera (device) size settings"),
	_T("Capturing failed"),
	_T("Wrong argument"),
	_T("Directshow initialization error"),
	_T("Not supported"),
	_T("Unknow error"),
	_T("Device lost"),
	_T("File not found"),
	_T("FPGA Setting error"),
	_T("Failure of image transferring"),
};

const int ERRORCOUNT = sizeof(ERRORLIST)/(128 * sizeof(TCHAR));

LONG DefProc = NULL;


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Re-construct scroll bar
//

void ChangeScrollbar(HWND hWnd)
{
	if(0 == g_Preview){
		g_ScrollCtrl.Pos.x = 0;
		g_ScrollCtrl.Pos.y = 0;
		ShowScrollBar(hWnd, SB_HORZ, FALSE);
		ShowScrollBar(hWnd, SB_VERT, FALSE);
		return;
	}

	RECT rc;
	GetClientRect(hWnd, &rc);

	double dwScale = 1;

	LONG lWidth  = LONG(double(double(ArtCamGetWidth() ) * dwScale));
	LONG lHeight = LONG(double(double(ArtCamGetHeight()) * dwScale));

	LONG PosX = LONG(double(double(g_ScrollCtrl.Pos.x) * dwScale));
	LONG PosY = LONG(double(double(g_ScrollCtrl.Pos.y) * dwScale));


	SCROLLINFO sc;
	sc.fMask	= SIF_RANGE | SIF_POS | SIF_PAGE;

	LONG OffsetH = 16;
	LONG OffsetV = 16;


	if(rc.right + OffsetH >= lWidth){
		ShowScrollBar(hWnd, SB_HORZ, FALSE);
	} else {
		sc.nMin		= 0;
		sc.nMax		= lWidth;
		sc.nPage	= rc.right;
		sc.nPos		= PosX;
		SetScrollInfo(hWnd, SB_HORZ, &sc, TRUE);
	}

	if(rc.bottom + OffsetV >= lHeight){
		ShowScrollBar(hWnd, SB_VERT, FALSE);
	} else {
		sc.nMin		= 0;
		sc.nMax		= lHeight;
		sc.nPage	= rc.bottom;
		sc.nPos		= PosY;
		SetScrollInfo(hWnd, SB_VERT, &sc, TRUE);
	}


	double dwWidth  = double(ArtCamGetWidth ());
	double dwHeight = double(ArtCamGetHeight());

	if(dwWidth - (double(rc.right) / dwScale) < g_ScrollCtrl.Pos.x)
		g_ScrollCtrl.Pos.x = LONG(dwWidth - (double(rc.right) / dwScale));
	if(dwHeight - (double(rc.bottom) / dwScale) < g_ScrollCtrl.Pos.y)
		g_ScrollCtrl.Pos.y = LONG(dwHeight - (double(rc.bottom) / dwScale));
	if(0.0 > g_ScrollCtrl.Pos.x)
		g_ScrollCtrl.Pos.x = 0;
	if(0.0 > g_ScrollCtrl.Pos.y)
		g_ScrollCtrl.Pos.y = 0;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Draw image
//

LRESULT DrawImage(HWND hWnd, HDC hDC)
{
	BOOL Flg = FALSE;
	if(NULL == hDC){
		hDC = GetDC(hWnd);
		Flg = TRUE;
	}

	if(hDC){
		if(g_CDibView.GetImage()){
			// Convert to space for drawing
			g_CDibView.Convert24Bit(&g_CDibCapture);

			POINT pt;
			GetCursorPos(&pt);
			ScreenToClient(hWnd, &pt);

			pt.x += g_ScrollCtrl.Pos.x;
			pt.y += g_ScrollCtrl.Pos.y;

			// Draw the cross on cursor 
			g_CDibView.MoveTo(0, pt.y);
			g_CDibView.LineTo(g_CDibView.GetWidth(), pt.y);
			g_CDibView.MoveTo(pt.x, 0);
			g_CDibView.LineTo(pt.x, g_CDibView.GetHeight());

			// Display cursor coordinate
			TCHAR szText[256];
			wsprintf(szText, "(%d, %d)", pt.x, pt.y);
			g_CDibView.TextOut(pt.x+10, pt.y+10, szText);


			// Draw on picture
			::BitBlt(hDC, -g_ScrollCtrl.Pos.x, -g_ScrollCtrl.Pos.y, g_CDibView.GetWidth(), g_CDibView.GetHeight(),
							g_CDibView.GetDC(), 0, 0, SRCCOPY);
		}

		if(Flg){
			ReleaseDC(hWnd, hDC);
		}

		return 1;
	}

	return 0;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Draw line with SDK
//

BOOL OnPreview(HWND hWnd)
{
	// Not selected DLL
	if(-1 == g_DllType){
		MessageBox(hWnd, _T("Select DLL for the camera connected"), _T("Error"), MB_OK);
		return FALSE;
	}

	// Delete timer
	if(3 == g_Preview){
		KillTimer(hWnd, TIMER_ID);
	}


	// Release device
	g_CArtCamSdk.Close();


	// Release area for image
	g_CDibCapture.Release();
	g_CDibView.Release();


	// Set window to be displayed
	// When setting NULL to hWnd,it is possible to create new window and show it.
	RECT rc;
	GetClientRect(hWnd, &rc);
	g_CArtCamSdk.SetPreviewWindow(hWnd, 0, 0, rc.right, rc.bottom);


	// Display image
	g_CArtCamSdk.Preview();


	// Check menu
	::CheckMenuItem(g_Menu.Preview, 0, MF_BYPOSITION | MF_CHECKED);
	::CheckMenuItem(g_Menu.Preview, 1, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 3, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 4, MF_BYPOSITION | MF_UNCHECKED);

	g_Preview = 0;

	ChangeScrollbar(hWnd);
	InvalidateRect(hWnd, NULL, TRUE);

	return TRUE;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Obtain image pointer and draw with application
//

BOOL OnCallBack(HWND hWnd)
{
	// Not selected DLL
	if(-1 == g_DllType){
		MessageBox(hWnd, _T("Select DLL for the camera connected"), _T("Error"), MB_OK);
		return FALSE;
	}

	// Delete timer
	if(3 == g_Preview){
		KillTimer(hWnd, TIMER_ID);
	}


	// Release device
	g_CArtCamSdk.Close();


	// Release area for image
	g_CDibCapture.Release();
	g_CDibView.Release();


	// If drawing by yourself, set all window size to 0.
	// An automatic display can be performed, if window size is set up even when using CallBackPreview
	g_CArtCamSdk.SetPreviewWindow(hWnd, 0, 0, 0, 0);


	// Secure the space for taking in
	g_CDibCapture.Create(NULL, ArtCamGetWidth(), ArtCamGetHeight(), ArtCamGetColor());

	// Secure the space for display
	g_CDibView.Create(NULL, ArtCamGetWidth(), ArtCamGetHeight(), 24);
	g_CDibView.SelectPen(PS_SOLID, 1, RGB(255,0,0));
	g_CDibView.SelectPointFont(14, "MS UI Gothic");
	g_CDibView.SetTextColor(RGB(255,0,0));
	g_CDibView.SetBkMode(TRANSPARENT);

	g_CArtCamSdk.CallBackPreview(hWnd, g_CDibCapture.GetImage(), g_CDibCapture.GetSize(), 0);


	// Check menu
	::CheckMenuItem(g_Menu.Preview, 0, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 1, MF_BYPOSITION | MF_CHECKED);
	::CheckMenuItem(g_Menu.Preview, 3, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 4, MF_BYPOSITION | MF_UNCHECKED);

	g_Preview = 1;

	ChangeScrollbar(hWnd);
	InvalidateRect(hWnd, NULL, TRUE);

	return TRUE;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Display one frame
//

BOOL OnSnapShot(HWND hWnd)
{
	// Not selected DLL
	if(-1 == g_DllType){
		MessageBox(hWnd, _T("Select DLL for the camera connected"), _T("Error"), MB_OK);
		return FALSE;
	}

	// Delete timer
	if(3 == g_Preview){
		KillTimer(hWnd, TIMER_ID);
	}


	// Release device
	g_CArtCamSdk.Close();


	// Release area for image
	g_CDibCapture.Release();
	g_CDibView.Release();


	// Secure the space for taking in
	g_CDibCapture.Create(NULL, ArtCamGetWidth(), ArtCamGetHeight(), ArtCamGetColor());

	// Secure the space for display
	g_CDibView.Create(NULL, ArtCamGetWidth(), ArtCamGetHeight(), 24);
	g_CDibView.SelectPen(PS_SOLID, 1, RGB(255,0,0));
	g_CDibView.SelectPointFont(14, "MS UI Gothic");
	g_CDibView.SetTextColor(RGB(255,0,0));
	g_CDibView.SetBkMode(TRANSPARENT);

	g_CArtCamSdk.SnapShot(g_CDibCapture.GetImage(), g_CDibCapture.GetSize(), 0);


	// Draw image
	DrawImage(hWnd, NULL);

	// Check menu
	::CheckMenuItem(g_Menu.Preview, 0, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 1, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 3, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 4, MF_BYPOSITION | MF_UNCHECKED);

	g_Preview = -1;

	return TRUE;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Draw line with SDK
//

BOOL OnCapture(HWND hWnd)
{
	// Not selected DLL
	if(-1 == g_DllType){
		MessageBox(hWnd, _T("Select DLL for the camera connected"), _T("Error"), MB_OK);
		return FALSE;
	}


	// Release device
	g_CArtCamSdk.Close();


	// Set window to be displayed
	// When setting NULL to hWnd,it is possible to create new window and show it.
	RECT rc;
	GetClientRect(hWnd, &rc);
	g_CArtCamSdk.SetPreviewWindow(hWnd, 0, 0, rc.right, rc.bottom);


	// Display image
	// Display is controlled by SDK. Image information cannot be obtained.
	g_CArtCamSdk.Capture();


	// Check menu
	::CheckMenuItem(g_Menu.Preview, 0, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 1, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 3, MF_BYPOSITION | MF_CHECKED);
	::CheckMenuItem(g_Menu.Preview, 4, MF_BYPOSITION | MF_UNCHECKED);

	g_Preview = 3;


	// Release area for image
	g_CDibCapture.Release();
	g_CDibView.Release();


	// Secure the space for taking in
	g_CDibCapture.Create(NULL, ArtCamGetWidth(), ArtCamGetHeight(), ArtCamGetColor());

	// Secure the space for display
	g_CDibView.Create(NULL, ArtCamGetWidth(), ArtCamGetHeight(), 24);
	g_CDibView.SelectPen(PS_SOLID, 1, RGB(255,0,0));
	g_CDibView.SelectPointFont(14, "MS UI Gothic");
	g_CDibView.SetTextColor(RGB(255,0,0));
	g_CDibView.SetBkMode(TRANSPARENT);

	SetTimer(hWnd, TIMER_ID, TIMER_TIME, NULL);

	return TRUE;
}


LRESULT OnTimer(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
	if(3 == g_Preview && TIMER_ID == wParam){
		KillTimer(hWnd, TIMER_ID);

		g_CArtCamSdk.SnapShot(g_CDibCapture.GetImage(), g_CDibCapture.GetSize(), 0);

		// Draw image
		DrawImage(hWnd, NULL);

		SetTimer(hWnd, TIMER_ID, TIMER_TIME, NULL);

		return 1;
	}

	return 0;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Trigger mode
//

BOOL OnTrigger(HWND hWnd)
{
	// Not selected DLL
	if(-1 == g_DllType){
		MessageBox(hWnd, _T("Select DLL for the camera connected"), _T("Error"), MB_OK);
		return FALSE;
	}

	// Delete timer
	if(3 == g_Preview){
		KillTimer(hWnd, TIMER_ID);
	}


	// Release device
	g_CArtCamSdk.Close();


	// Release area for image
	g_CDibCapture.Release();
	g_CDibView.Release();


	// If drawing by yourself, set all window size to 0.
	// An automatic display can be performed, if window size is set up even when using CallBackPreview
	g_CArtCamSdk.SetPreviewWindow(hWnd, 0, 0, 0, 0);


	// Secure the space for taking in
	g_CDibCapture.Create(NULL, ArtCamGetWidth(), ArtCamGetHeight(), ArtCamGetColor());

	// Secure the space for display
	g_CDibView.Create(NULL, ArtCamGetWidth(), ArtCamGetHeight(), 24);
	g_CDibView.SelectPen(PS_SOLID, 1, RGB(255,0,0));
	g_CDibView.SelectPointFont(14, "MS UI Gothic");
	g_CDibView.SetTextColor(RGB(255,0,0));
	g_CDibView.SetBkMode(TRANSPARENT);

	g_CArtCamSdk.Trigger(hWnd, g_CDibCapture.GetImage(), g_CDibCapture.GetSize(), 0);


	// Check menu
	::CheckMenuItem(g_Menu.Preview, 0, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 1, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 3, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 4, MF_BYPOSITION | MF_CHECKED);

	g_Preview = 4;

	ChangeScrollbar(hWnd);
	InvalidateRect(hWnd, NULL, TRUE);

	return TRUE;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Change DLL
//

BOOL OnDllChange(HWND hWnd, LONG DllType, LONG CameraType)
{
	// Release all devices before switching DLL
	// To display multiple images simulteously, you need to define CArtCamSdk plurally
	// When defined plurally, you do not need to relase to switch cameras
	g_CArtCamSdk.Release();
	g_CArtCamSdk.FreeLibrary();

	int i=0;

	TCHAR szDllName[MAX_PATH]=_T("");
	::GetMenuString(g_Menu.Dll, DllType+1, szDllName, MAX_PATH, MF_BYPOSITION);
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

	BOOL res = g_CArtCamSdk.LoadLibrary(szDllName);
	if(!res){
		MessageBox(hWnd, _T("DLL is not found.\nDLL may have been relocated after executing"), _T("Error"), MB_OK);
		return FALSE;
	}

	// Initialize is to be called first
	// By setting Window Handle here, WMLERROR can be obtained
	if(!g_CArtCamSdk.Initialize(hWnd)){
		MessageBox(hWnd, _T("Failed to initialize SDK"), _T("Error"), MB_OK);
		return FALSE;
	}
	g_DllType = DllType;
	g_SataType = CameraType;
	LONG CurrentCameraType = HIWORD(g_CArtCamSdk.GetDllVersion());

	// 
	if(-1 != CameraType && ARTCAM_CAMERATYPE_SATA == CurrentCameraType){
		g_CArtCamSdk.SetCameraType(CameraType);
		g_CArtCamSdk.SetDeviceNumber(0);
	}


	// Check menu
	for(i=0; i<g_DllCount; i++){
		::CheckMenuItem(g_Menu.Dll, i+1, MF_BYPOSITION | MF_UNCHECKED);
	}
	::CheckMenuItem(g_Menu.Dll, DllType+1, MF_BYPOSITION | MF_CHECKED);

	if(-1 != CameraType && ARTCAM_CAMERATYPE_SATA == CurrentCameraType){
		for(int type=0; type<ARTCAM_CAMERATYPE_SATA_200MI-ARTCAM_CAMERATYPE_SATA_LVDS+1; type++){
			::CheckMenuItem(::GetSubMenu(g_Menu.Dll, g_DllSata+1), type, MF_BYPOSITION | MF_UNCHECKED);
		}
		::CheckMenuItem(::GetSubMenu(g_Menu.Dll, g_DllSata+1), g_SataType, MF_BYPOSITION | MF_CHECKED);
	}


	// Switch to ON or OFF of setting window
	switch(CurrentCameraType){
	case ARTCAM_CAMERATYPE_CNV:
		::EnableMenuItem(g_Menu.Set, 0, MF_BYPOSITION | MF_ENABLED);
		::EnableMenuItem(g_Menu.Set, 1, MF_BYPOSITION | MF_ENABLED);
		::EnableMenuItem(g_Menu.Set, 2, MF_BYPOSITION | MF_GRAYED);

		::EnableMenuItem(g_Menu.Rate, 0, MF_BYPOSITION | MF_ENABLED);
		::EnableMenuItem(g_Menu.Rate, 1, MF_BYPOSITION | MF_ENABLED);
		::EnableMenuItem(g_Menu.Rate, 2, MF_BYPOSITION | MF_ENABLED);
		::EnableMenuItem(g_Menu.Rate, 3, MF_BYPOSITION | MF_ENABLED);
	break;

	// Other
	default:
		::EnableMenuItem(g_Menu.Set, 0, MF_BYPOSITION | MF_ENABLED);
		::EnableMenuItem(g_Menu.Set, 1, MF_BYPOSITION | MF_ENABLED);
		::EnableMenuItem(g_Menu.Set, 2, MF_BYPOSITION | MF_ENABLED);

		::EnableMenuItem(g_Menu.Rate, 0, MF_BYPOSITION | MF_GRAYED);
		::EnableMenuItem(g_Menu.Rate, 1, MF_BYPOSITION | MF_GRAYED);
		::EnableMenuItem(g_Menu.Rate, 2, MF_BYPOSITION | MF_GRAYED);
		::EnableMenuItem(g_Menu.Rate, 3, MF_BYPOSITION | MF_GRAYED);
	break;
	}


	// Device modification menu
	for(i=0; i<g_DeviceCount; i++){
		::DeleteMenu(g_Menu.Device, 0, MF_BYPOSITION | MF_STRING);
	}


	TCHAR szName[10][256];
	g_DeviceCount = g_CArtCamSdk.EnumDevice(szName);
	for(i=0; i<g_DeviceCount; i++){
		::InsertMenu(g_Menu.Device, i, MF_BYPOSITION | MF_STRING, IDM_DEVICE + i, szName[i]);
	}
	::CheckMenuItem(g_Menu.Device, 0, MF_BYPOSITION | MF_CHECKED);

	switch(g_Preview){
	case 0:	return OnPreview(hWnd);
	case 1:	return OnCallBack(hWnd);
	case 3:	return OnCapture(hWnd);
	case 4:	return OnTrigger(hWnd);
	}

	return FALSE;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	OnDllReload
//

void OnDllReload()
{
	// Delete DLL list
	for(int i=0; i<g_DllCount; i++){
		::DeleteMenu(g_Menu.Dll, 1, MF_BYPOSITION | MF_STRING);
	}
	g_DllCount = 0;
	g_DllSata  = -1;

	// Search for DLL
	TCHAR szDir[MAX_PATH]		= _T("");
	TCHAR szExePath[3][MAX_PATH]= {_T(""),_T(""),_T("")};
	GetModuleFileName(::GetModuleHandle(NULL), szExePath[0], MAX_PATH);
#if defined(__VS2005__) | (__VS2010__)
	_tsplitpath_s(szExePath[0], szExePath[1], MAX_PATH, szExePath[2], MAX_PATH, NULL, 0, NULL, 0);
#else
	_tsplitpath(szExePath[0], szExePath[1], szExePath[2], NULL, NULL);
#endif
	wsprintf(szDir, _T("%s%s"), szExePath[1], szExePath[2]);

	TCHAR szSearch[MAX_PATH]	= _T("");
	wsprintf(szSearch,	_T("%s\\*.dll"),szDir);

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
					TCHAR szMenu[512];

					// Obtain version and show it
					TCHAR szDllName[MAX_PATH]=_T("");
#if defined(__VS2005__) | (__VS2010__)
					_tsplitpath_s(fd.cFileName, NULL, 0, NULL, 0, szDllName, MAX_PATH, NULL, 0);
#else
					_tsplitpath(fd.cFileName, NULL, NULL, szDllName, NULL);
#endif
					wsprintf(szMenu, _T("%s\tVersion %04d"), szDllName, LOWORD(ArtCam.GetDllVersion()));

					// Add to menu
					g_DllCount++;
					
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
						::AppendMenu(g_Menu.Dll, MF_STRING | MF_POPUP, (UINT_PTR)MenuSata, szMenu);
						g_DllSata = g_DllCount-1;
					}
					else{
						::AppendMenu(g_Menu.Dll, MF_STRING, IDM_DLL_RELOAD+g_DllCount, szMenu);
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

BOOL OnDeviceChange(HWND hWnd, LONG Number)
{
	// Not selected DLL
	if(-1 == g_DllType){
		MessageBox(hWnd, _T("Select DLL for the camera connected"), _T("Error"), MB_OK);
		return FALSE;
	}


	// Release the operative device before switching device
	g_CArtCamSdk.Close();

	// A device will be changed, if a camera is displayed after changing the number of a device now
	// Notes: A device is not changed in this function simple substance
	//   After calling this function, a device is changed by initializing a device
	g_CArtCamSdk.SetDeviceNumber(Number);

	for(int i=0; i<g_DeviceCount; i++){
		::CheckMenuItem(g_Menu.Device, i, MF_BYPOSITION | MF_UNCHECKED);
	}

	::CheckMenuItem(g_Menu.Device, Number, MF_BYPOSITION | MF_CHECKED);

	switch(g_Preview){
	case 0:	return OnPreview(hWnd);
	case 1:	return OnCallBack(hWnd);
	case 3:	return OnCapture(hWnd);
	case 4:	return OnTrigger(hWnd);
	}

	return FALSE;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Switch to Sampling rate
//

BOOL OnRateChange(HWND hWnd, LONG Number)
{
	// Not selected DLL
	if(-1 == g_DllType){
		MessageBox(hWnd, _T("Select DLL for the camera connected"), _T("Error"), MB_OK);
		return FALSE;
	}


	// Release the operative device before switching device
	g_CArtCamSdk.Close();

	g_CArtCamSdk.SetSamplingRate(Number);

	for(int i=0; i<4; i++){
		::CheckMenuItem(g_Menu.Rate, i, MF_BYPOSITION | MF_UNCHECKED);
	}

	::CheckMenuItem(g_Menu.Rate, Number, MF_BYPOSITION | MF_CHECKED);

	switch(g_Preview){
	case 0:	return OnPreview(hWnd);
	case 1:	return OnCallBack(hWnd);
	case 3:	return OnCapture(hWnd);
	case 4:	return OnTrigger(hWnd);
	}

	return FALSE;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	WM_CREATE
//

LRESULT OnCreate(HWND hWnd, WPARAM wParam, LPARAM lParam)
{

	TCHAR szFilePath[MAX_PATH]=_T("");
	TCHAR szExePath[3][MAX_PATH]={_T(""),_T(""),_T("")};
	GetModuleFileName(::GetModuleHandle(NULL), szExePath[0], MAX_PATH);
#if defined(__VS2005__) | (__VS2010__)
	_tsplitpath_s(szExePath[0], szExePath[1], MAX_PATH, szExePath[2], MAX_PATH, NULL, 0, NULL, 0);
#else
	_tsplitpath(szExePath[0], szExePath[1], szExePath[2], NULL, NULL);
#endif
	wsprintf(szFilePath, _T("%s%sSample.ini"), szExePath[1], szExePath[2]);
	g_DllType  = ::GetPrivateProfileInt(_T("Sample"), _T("DllType"),	-1, szFilePath);
	g_SataType = ::GetPrivateProfileInt(_T("Sample"), _T("CameraType"),	-1, szFilePath);

	return 1;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	WM_COMMAND
//

LRESULT OnCommand(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
	switch (LOWORD(wParam)){
	// Save file
	case IDM_SAVE:
//		g_CArtCamSdk.SaveImage("Image.bmp", FILETYPE_BITMAP);
//		g_CArtCamSdk.SaveImage("Image.raw", FILETYPE_RAW);
		g_CArtCamSdk.SaveImage("Imageh.jpg", FILETYPE_JPEG_HIGH);
//		g_CArtCamSdk.SaveImage("Imagen.jpg", FILETYPE_JPEG_NOMAL);
//		g_CArtCamSdk.SaveImage("Imagel.jpg", FILETYPE_JPEG_LOW);
//		g_CArtCamSdk.SaveImage("Image.png", FILETYPE_PNG);
//		g_CArtCamSdk.SaveImage("Image.tif", FILETYPE_TIFF);
	return 1;

	// End
	case IDM_EXIT:
		::PostMessage(hWnd, WM_CLOSE, 0, 0);
	return 1;

	// Draw with SDK
	case IDM_PREVIEW:
		OnPreview(hWnd);
	return 1;

	// Obtain pointer of image and draw
	case IDM_CALLBACK:
		OnCallBack(hWnd);
	return 1;

	// Obtain A image
	case IDM_SNAPSHOT:
		OnSnapShot(hWnd);
	return 1;

	// Capture snapshot in a low
	case IDM_CAPTURE:
		OnCapture(hWnd);
	return 1;

	// Trigger mode
	case IDM_TRIGGER:
		OnTrigger(hWnd);
	return 1;

	// Camera settings
	case IDM_FORMAT:
		// When show camera setting dialog,recommend to release display once.
		// Stop image refresh with SDK even when not stop with application.
		// In case of stop with SDK,it restarts when close dialog
		// There is possibility of illegality processing 
		// if you don't correspond setting with application when you change setting and close dialog.
		if(3 == g_Preview)	KillTimer(hWnd, TIMER_ID);

		g_CArtCamSdk.Close();
		g_CArtCamSdk.SetCameraDlg(hWnd);

		switch(g_Preview){
		case 0:	return OnPreview(hWnd);
		case 1:	return OnCallBack(hWnd);
		case 3:	return OnCapture(hWnd);
		case 4:	return OnTrigger(hWnd);
		}
	return 1;

	// Filter settings
	case IDM_FILTER:
		g_CArtCamSdk.SetImageDlg(hWnd);
	return 1;

	// Analog settings
	case IDM_ANALOG:
		g_CArtCamSdk.SetAnalogDlg(hWnd);
	return 1;

	// 
	case IDM_WIDEHI:		OnRateChange(hWnd, 0);	return 1;
	case IDM_WIDELOW:		OnRateChange(hWnd, 1);	return 1;
	case IDM_NORMALHI:		OnRateChange(hWnd, 2);	return 1;
	case IDM_NORMALLOW:		OnRateChange(hWnd, 3);	return 1;

	case IDM_DLL_RELOAD:	OnDllReload();			return 1;
	}


	// Change DLL
	UINT ID = LOWORD(wParam);
	LONG DllNumber = ID - IDM_DLL_RELOAD - 1;
	if(0 <= DllNumber && DllNumber < g_DllCount){
		OnDllChange(hWnd, DllNumber, -1);
	}
	else if(ID_DLL_SATA_LVDS <= ID && ID <= ID_DLL_SATA_200MI){
		LONG SataType = ID - ID_DLL_SATA_LVDS;
		OnDllChange(hWnd, g_DllSata, SataType);
	}


	// Change device
	for(int i=0; i<g_DeviceCount; i++){
		if(IDM_DEVICE + i == LOWORD(wParam)){
			OnDeviceChange(hWnd, i);
			return 1;
		}
	}

	return 0;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	WM_PAINT
//

LRESULT OnPaint(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
	PAINTSTRUCT psPaint;
	HDC hDC = BeginPaint(hWnd, &psPaint);
	if(hDC){
		DrawImage(hWnd, hDC);
		EndPaint(hWnd, &psPaint);
	}

	return 0;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	WM_ERROR
//

LRESULT OnError(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
	if(0 <= lParam && lParam < ERRORCOUNT-1){
		SetWindowText(hWnd, ERRORLIST[lParam]);
	}
	else {
		// Unknown error
		SetWindowText(hWnd, ERRORLIST[ARTCAMSDK_UNKNOWN]);
	}

	return 1;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	WM_GRAPHPAINT
//

LRESULT OnGraphPaint(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
	if(NULL == wParam){
		return OnError(hWnd, wParam, lParam);
	}


	// Once this message is sent, latest image is stored at "g_pImage"
	LPGP_INFO pGpInfo = (LPGP_INFO)wParam;
	DrawImage(hWnd, NULL);


	TCHAR Fps[256]=_T("");
#if defined(__VS2005__) | (__VS2010__)
	_stprintf_s(Fps, 256, _T("Sample  %.1f Fps"), double(pGpInfo->lFps) / 10.0);
#else
	_stprintf(Fps, _T("Sample  %.1f Fps"), double(pGpInfo->lFps) / 10.0);
#endif
	SetWindowText(hWnd, Fps);

	return 1;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	WM_DESTROY
//

LRESULT OnDestroy(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
	// Call "Release" when you end use of camera. (also called "destructor").
	// You need to call "Initialise" when you re-use camera after "Release".
	g_CArtCamSdk.Release();
	g_CDibCapture.Release();
	g_CDibView.Release();


	TCHAR szFilePath[MAX_PATH]=_T("");
	TCHAR szExePath[3][MAX_PATH]={_T(""),_T(""),_T("")};
	GetModuleFileName(::GetModuleHandle(NULL), szExePath[0], MAX_PATH);
	TCHAR Data[32]=_T("");

#if defined(__VS2005__) | (__VS2010__)
	_tsplitpath_s(szExePath[0], szExePath[1],MAX_PATH, szExePath[2],MAX_PATH,NULL,0, NULL,0);
#else
	_tsplitpath(szExePath[0], szExePath[1], szExePath[2],NULL, NULL);
#endif
	wsprintf(szFilePath,	_T("%s%sSample.ini"),	szExePath[1], szExePath[2]);
	wsprintf(Data, _T("%d"), g_DllType);
	::WritePrivateProfileString(_T("Sample"), _T("DllType"), Data, szFilePath);
	wsprintf(Data, _T("%d"), g_SataType);
	::WritePrivateProfileString(_T("Sample"), _T("CameraType"), Data, szFilePath);

	::PostQuitMessage(0);
	return 1;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	WM_SIZE
//

LRESULT OnSize(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
	if(0 == g_Preview){
		HWND hChild = GetWindow(hWnd, GW_CHILD);

		RECT rc;
		GetClientRect(hWnd, &rc);


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
		SetWindowPos(hChild, HWND_TOP, 0, 0, rc.right, rc.bottom, SWP_NOMOVE | SWP_NOZORDER | SWP_SHOWWINDOW);
	}

	if(1 == g_Preview || 3 == g_Preview || 4 == g_Preview){
		ChangeScrollbar(hWnd);
	}

	return 1;
}


/////////////////////////////////////////////////////////////////////////////
//
//	WM_HSCROLL
//

LRESULT OnHScroll(HWND hWnd, UINT nSBCode, UINT nPos, HWND ScrollBar)
{
	SCROLLINFO sc;
	GetScrollInfo(hWnd, SB_HORZ, &sc);

	switch(nSBCode){
	// Scroll to th left end
	case SB_LEFT:
		SetScrollPos(hWnd, SB_HORZ, 0, TRUE);
	break;

	// Finish scrolling
	case SB_ENDSCROLL:
	break;

	// Scroll to left
	case SB_LINELEFT:
		SetScrollPos(hWnd, SB_HORZ, GetScrollPos(hWnd, SB_HORZ) - sc.nPage/4, TRUE);
	break;

	// Scroll to right
	case SB_LINERIGHT:
		SetScrollPos(hWnd, SB_HORZ, GetScrollPos(hWnd, SB_HORZ) + sc.nPage/4, TRUE);
	break;

	// Scroll to the left page
	case SB_PAGELEFT:
		SetScrollPos(hWnd, SB_HORZ, GetScrollPos(hWnd, SB_HORZ) - sc.nPage, TRUE);
	break;

	// Scroll to the right page
	case SB_PAGERIGHT:
		SetScrollPos(hWnd, SB_HORZ, GetScrollPos(hWnd, SB_HORZ) + sc.nPage, TRUE);
	break;

	// Scroll to the right end
	case SB_RIGHT:
		SetScrollPos(hWnd, SB_HORZ, sc.nMax, TRUE);
	break;

	// Scroll to absolute position. The current position is appointed by argument "nPos".
	case SB_THUMBPOSITION:
		nPos &= 0x0000FFFF;
		SetScrollPos(hWnd, SB_HORZ, nPos, TRUE);
	break;

	// Drag scroll box to the current position. The current position is appointed by argument "nPos". 
	case SB_THUMBTRACK:
		nPos &= 0x0000FFFF;
		SetScrollPos(hWnd, SB_HORZ, nPos, TRUE);
	break;
	}

	g_ScrollCtrl.Pos.x = GetScrollPos(hWnd, SB_HORZ);
	DrawImage(hWnd, NULL);

	return 1;
}


/////////////////////////////////////////////////////////////////////////////
//
//	WM_VSCROLL
//

LRESULT OnVScroll(HWND hWnd, UINT nSBCode, UINT nPos, HWND ScrollBar)
{
	SCROLLINFO sc;
	GetScrollInfo(hWnd, SB_VERT, &sc);
	LONG pos = GetScrollPos(hWnd, SB_VERT);


	switch(nSBCode){
	// Scroll to th left end
	case SB_LEFT:
		SetScrollPos(hWnd, SB_VERT, 0, TRUE);
	break;

	// Finish scrolling
	case SB_ENDSCROLL:
	break;

	// Scroll to left
	case SB_LINELEFT:
		SetScrollPos(hWnd, SB_VERT, GetScrollPos(hWnd, SB_VERT) - sc.nPage/4, TRUE);
	break;

	// Scroll to right
	case SB_LINERIGHT:
		SetScrollPos(hWnd, SB_VERT, GetScrollPos(hWnd, SB_VERT) + sc.nPage/4, TRUE);
	break;

	// Scroll to the left page
	case SB_PAGELEFT:
		SetScrollPos(hWnd, SB_VERT, GetScrollPos(hWnd, SB_VERT) - sc.nPage, TRUE);
	break;

	// Scroll to the right page
	case SB_PAGERIGHT:
		SetScrollPos(hWnd, SB_VERT, GetScrollPos(hWnd, SB_VERT) + sc.nPage, TRUE);
	break;

	// Scroll to the right end
	case SB_RIGHT:
		SetScrollPos(hWnd, SB_VERT, sc.nMax, TRUE);
	break;

	// Scroll to absolute position. The current position is appointed by argument "nPos".
	case SB_THUMBPOSITION:
		nPos &= 0x0000FFFF;
		SetScrollPos(hWnd, SB_VERT, nPos, TRUE);
	break;

	// Drag scroll box to the current position. The current position is appointed by argument "nPos". 
	case SB_THUMBTRACK:
		nPos &= 0x0000FFFF;
		SetScrollPos(hWnd, SB_VERT, nPos, TRUE);
	break;
	}

	
	g_ScrollCtrl.Pos.y = GetScrollPos(hWnd, SB_VERT);
	DrawImage(hWnd, NULL);

	return 1;
}


/////////////////////////////////////////////////////////////////////////////
//
//	WM_MOUSEMOVE
//

LRESULT OnMouseMove(HWND hWnd, LONG xPos, LONG yPos)
{
	DrawImage(hWnd, NULL);

	return 1;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Window procedureWindow procedure
//

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	switch(uMsg){
	case WM_CREATE:		return OnCreate			(hWnd, wParam, lParam);
	case WM_COMMAND:	return OnCommand		(hWnd, wParam, lParam);
	case WM_PAINT:		return OnPaint			(hWnd, wParam, lParam);
	case WM_GRAPHPAINT:	return OnGraphPaint		(hWnd, wParam, lParam);
	case WM_ERROR:		return OnError			(hWnd, wParam, lParam);
	case WM_DESTROY:	return OnDestroy		(hWnd, wParam, lParam);
	case WM_SIZE:		return OnSize			(hWnd, wParam, lParam);
	case WM_TIMER:		return OnTimer			(hWnd, wParam, lParam);
	case WM_HSCROLL:	return OnHScroll		(hWnd, LOWORD(wParam), HIWORD(wParam), (HWND)lParam);
	case WM_VSCROLL:	return OnVScroll		(hWnd, LOWORD(wParam), HIWORD(wParam), (HWND)lParam);
	case WM_MOUSEMOVE:	return OnMouseMove		(hWnd, LOWORD(lParam), HIWORD(lParam));
	default:			return ::DefWindowProc	(hWnd, uMsg, wParam, lParam);
	}
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Window initializationInitialize window
//

HWND InitWindow(HINSTANCE hInstance, int nCmdShow)
{
	// Registrate window classRegister window class
	WNDCLASSEX wndclassex;
	ZeroMemory(&wndclassex,		sizeof(wndclassex));
	wndclassex.cbSize			= sizeof(wndclassex);
	wndclassex.style			= 0;
	wndclassex.lpfnWndProc		= WndProc;
	wndclassex.cbClsExtra		= 0;
	wndclassex.cbWndExtra		= 0;
	wndclassex.hInstance		= hInstance;
	wndclassex.hIcon			= LoadIcon(NULL, IDI_APPLICATION);
	wndclassex.hCursor			= LoadCursor(NULL, IDC_ARROW);
	wndclassex.hbrBackground	= reinterpret_cast<HBRUSH>(::GetStockObject(BLACK_BRUSH));
	wndclassex.lpszClassName	= _T("Sample");
	wndclassex.lpszMenuName		= 0;
	wndclassex.hIconSm			= NULL;

	if(0 == ::RegisterClassEx(&wndclassex))
		return NULL;

	// Window size settingWindow size settings
	RECT rcWndSize = {0, 0, 900, 600};
	DWORD dwStyle = WS_POPUPWINDOW | WS_CAPTION | WS_OVERLAPPEDWINDOW | WS_VSCROLL | WS_HSCROLL;
	if(0 == ::AdjustWindowRectEx(&rcWndSize, dwStyle, TRUE, NULL))
		return NULL;

	// Main window createMain window generation
	HWND hWnd = ::CreateWindowEx(NULL, _T("Sample"), _T("Sample"), dwStyle,
			(::GetSystemMetrics(SM_CXSCREEN) - (rcWndSize.right - rcWndSize.left)) / 2,
			(::GetSystemMetrics(SM_CYSCREEN) - (rcWndSize.bottom - rcWndSize.top)) / 2,
			rcWndSize.right - rcWndSize.left, rcWndSize.bottom - rcWndSize.top,
			HWND_DESKTOP, NULL, hInstance, NULL);

	if(NULL == hWnd)
		return NULL;


	// Create menu

	// File menu
	g_Menu.File = ::CreateMenu();
	::InsertMenu(g_Menu.File, 0, MF_BYPOSITION | MF_STRING, IDM_SAVE, _T("Save(&S)"));
	::InsertMenu(g_Menu.File, 1, MF_BYPOSITION | MF_STRING, IDM_EXIT, _T("End(&X)"));

	// Display type menu
	g_Menu.Preview = ::CreateMenu();
	::InsertMenu(g_Menu.Preview, 0, MF_BYPOSITION | MF_STRING, IDM_PREVIEW,	_T("Preview(&P)"));
	::InsertMenu(g_Menu.Preview, 1, MF_BYPOSITION | MF_STRING, IDM_CALLBACK,_T("Callback(&B)"));
	::InsertMenu(g_Menu.Preview, 2, MF_BYPOSITION | MF_STRING, IDM_SNAPSHOT,_T("Snapshot(&S)"));
	::InsertMenu(g_Menu.Preview, 3, MF_BYPOSITION | MF_STRING, IDM_CAPTURE,	_T("Capture(&C)"));
	::InsertMenu(g_Menu.Preview, 4, MF_BYPOSITION | MF_STRING, IDM_TRIGGER,	_T("Trigger(&T)"));

	// Settings menu
	g_Menu.Set = ::CreateMenu();
	::InsertMenu(g_Menu.Set, 0, MF_BYPOSITION | MF_STRING, IDM_FORMAT, _T("Format settings(&C)"));
	::InsertMenu(g_Menu.Set, 1, MF_BYPOSITION | MF_STRING, IDM_FILTER, _T("Filter settings(&F)"));
	::InsertMenu(g_Menu.Set, 2, MF_BYPOSITION | MF_STRING, IDM_ANALOG, _T("Analog settings(&A)"));

	// DLL selective menu
	g_Menu.Dll = ::CreateMenu();
	::InsertMenu(g_Menu.Dll,  0, MF_BYPOSITION | MF_STRING, IDM_DLL_RELOAD,	_T("Reload"));

	// Sampling rate menu
	g_Menu.Rate = ::CreateMenu();
	::InsertMenu(g_Menu.Rate,  0, MF_BYPOSITION | MF_STRING, IDM_WIDEHI,	_T("Wide HiSpeed"));
	::InsertMenu(g_Menu.Rate,  1, MF_BYPOSITION | MF_STRING, IDM_WIDELOW,	_T("Wide LowSpeed"));
	::InsertMenu(g_Menu.Rate,  2, MF_BYPOSITION | MF_STRING, IDM_NORMALHI,	_T("Normal HiSpeed"));
	::InsertMenu(g_Menu.Rate,  3, MF_BYPOSITION | MF_STRING, IDM_NORMALLOW,	_T("Normal LowSpeed"));

	// Check if there is DLL
	OnDllReload();

	// Device modification menu
	g_Menu.Device = ::CreateMenu();

	// Main menu
	HMENU hMenu = ::CreateMenu();
	::InsertMenu(hMenu, 0, MF_POPUP | MF_STRING, (UINT)g_Menu.File,    _T("File(&F)"));
	::InsertMenu(hMenu, 1, MF_POPUP | MF_STRING, (UINT)g_Menu.Preview, _T("Display(&V)"));
	::InsertMenu(hMenu, 2, MF_POPUP | MF_STRING, (UINT)g_Menu.Set,     _T("Settings(&S)"));
	::InsertMenu(hMenu, 3, MF_POPUP | MF_STRING, (UINT)g_Menu.Dll,     _T("DLL(&L)"));
	::InsertMenu(hMenu, 4, MF_POPUP | MF_STRING, (UINT)g_Menu.Device,  _T("Device(&D)"));
	::InsertMenu(hMenu, 5, MF_POPUP | MF_STRING, (UINT)g_Menu.Rate,    _T("Rate(&D)"));


	::SetMenu(hWnd, hMenu);


	// Focus settings
	::SetFocus(hWnd);
	::ShowWindow(hWnd, nCmdShow);
	if(0 == ::UpdateWindow(hWnd))
		return NULL;

	// Initialize camera
	if(-1 != g_DllType)
		OnDllChange(hWnd, g_DllType, g_SataType);

	SetTimer(hWnd, 1, 100, NULL);
	return hWnd;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	WinMain
//

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpszCmLine, int nCmdShow)
{
	HWND hWnd = InitWindow(hInstance, nCmdShow);

	// Message roop
	MSG msg;
	ZeroMemory(&msg, sizeof(msg));
	while(::GetMessage(&msg, NULL, 0, 0)){
		::TranslateMessage(&msg);
		::DispatchMessage(&msg);
	}

	return (int)msg.wParam;
}




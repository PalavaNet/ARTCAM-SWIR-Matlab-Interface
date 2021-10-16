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



// Various menu ID 
enum {
	IDM_SAVE = WM_USER + 1,
	IDM_EXIT,

	IDM_PREVIEW,
	IDM_CALLBACK,
	IDM_SNAPSHOT,
	IDM_CAPTURE,
	IDM_TRIGGER,

	IDM_FORMAT1,
	IDM_FORMAT2,
	IDM_FILTER1,
	IDM_FILTER2,
	IDM_ANALOG1,
	IDM_ANALOG2,


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



#define TIMER_ID	100
#define TIMER_TIME	50



CArtCamSdk	g_CArtCamSdk[2];
LPBYTE		g_pImage[2] = {NULL,NULL};		// Space for image data

BOOL		g_Preview = -1;		// Preview display/Callback display
LONG		g_DllType = -1;		// DLL to be connected
LONG		g_DllSata = -1;		// DllCount of SATA
LONG		g_DllCount= 0;		// The number of DLL found
LONG		g_SataType= -1;		// SATA camera type
LONG		g_DeviceCount = 0;	// Number of detected device
LONG		g_BitMode =10;		// 16 bit picture transferring mode


const int SUB_SAMPLE[] = { 1, 2, 4, 8 };
#define ArtCamGetWidth(n)	(g_CArtCamSdk[n].Width()  / SUB_SAMPLE[g_CArtCamSdk[n].GetSubSample() & 0x03])
#define ArtCamGetHeight(n)	(g_CArtCamSdk[n].Height() / SUB_SAMPLE[g_CArtCamSdk[n].GetSubSample() & 0x03])
#define ArtCamGetColor(n)	WORD(((g_CArtCamSdk[n].GetColorMode() + 7) / 8) * 8)
#define ArtCamGetBpp(n)		(((g_CArtCamSdk[n].GetColorMode() + 7) / 8))
#define ArtCamGetPitch(n)	((ArtCamGetWidth(n) * ArtCamGetBpp(n) + 3) & ~3)
#define ArtCamGetSize(n)	(ArtCamGetPitch(n) * ArtCamGetHeight(n))
#define SAFE_DELETE(x)  { if(x) delete[] x; x=NULL; }


struct MENU_LIST{
	HMENU	File;
	HMENU	Preview;
	HMENU	Set;
	HMENU	Dll;
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

const int ERRORCOUNT = sizeof(ERRORLIST)  / (128 * sizeof(TCHAR));

LONG DefProc = NULL;


//////////////////////////////////////////////////////////////////////////////////////////////
//
//  


void CheckColorMode(void)
{
	// Over ver.1300 
	if(1300 <= LOWORD(g_CArtCamSdk[0].GetDllVersion())){
		LONG ColorMode = g_CArtCamSdk[0].GetColorMode();
		switch(ColorMode){
			case 10:	case 42:	case 58:	g_BitMode = 10;	break;
			case 12:	case 44:	case 60:	g_BitMode = 12;	break;
			case 14:	case 46:	case 62:	g_BitMode = 14;	break;
			case 16:	case 48:	case 64:	g_BitMode = 16;	break;
			default:							g_BitMode = 8;	break;
		}
	}else{
		// Normal cameras output 10-bit data.
		g_BitMode = 10;
	}

	// On ArtCnvII  Data[15:0] -> Y[9:2] ... UV[6:0]Y[1:0]
	if(ARTCAM_CAMERATYPE_CNV == HIWORD(g_CArtCamSdk[0].GetDllVersion())){
		g_BitMode = 8;
	}
}



//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Draw image
//

struct BITMAPINFO2 {
	BITMAPINFOHEADER   bmiHeader;
	RGBQUAD            bmiColors[256];
};

LRESULT DrawImage(HWND hWnd, HDC hDC, LONG Number)
{
	LPBYTE pImage = g_pImage[Number];


	if(NULL == pImage){
		return 0;
	}

	BOOL Flg = FALSE;
	if(NULL == hDC){
		hDC = GetDC(hWnd);
		Flg = TRUE;
	}

	if(hDC){
		LONG Width = ArtCamGetWidth(Number);
		LONG Height = ArtCamGetHeight(Number);
		LONG Bpp = ArtCamGetBpp(Number);

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


		RECT rc;
		GetClientRect(hWnd, &rc);
		rc.right = rc.right < Width*2 ? rc.right : Width*2;

		rc.left   = 0 + (rc.right/2) * Number;
		rc.top    = 0;
		rc.right  = rc.right / 2;
		rc.bottom = Height;

		UINT Line = Height;



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

			SetDIBitsToDevice(hDC, rc.left, rc.top, rc.right, rc.bottom, 0, 0, 0, Line, pImage, (BITMAPINFO*)&bm, DIB_RGB_COLORS);
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

			LPBYTE pTemp = new BYTE[bm.bmiHeader.biWidth * bm.bmiHeader.biHeight];
			if(pTemp){
				for(int y=0; y<bm.bmiHeader.biHeight; y++){

					LPBYTE pDest =        pTemp   + (y * bm.bmiHeader.biWidth);
					LPWORD pSrc  = LPWORD(pImage) + (y * bm.bmiHeader.biWidth);

					for(int x=0; x<bm.bmiHeader.biWidth; x++){
						switch(g_BitMode){
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


				SetDIBitsToDevice(hDC, rc.left, rc.top, rc.right, rc.bottom, 0, 0, 0, Line, pTemp, (BITMAPINFO*)&bm, DIB_RGB_COLORS);
				delete[] pTemp;
			}
		}

		// Color 24 bit transfer
		else if(3 == Bpp){
			bm.bmiHeader.biBitCount = 24;
			SetDIBitsToDevice(hDC, rc.left, rc.top, rc.right, rc.bottom, 0, 0, 0, Line, pImage, (BITMAPINFO*)&bm, DIB_RGB_COLORS);
		}

		// Color 32 bit transfer
		else if(4 == Bpp){
			bm.bmiHeader.biBitCount = 24;

			LPBYTE pTemp = new BYTE[bm.bmiHeader.biWidth * bm.bmiHeader.biHeight * 3];
			if(pTemp){
				for(int y=0; y<bm.bmiHeader.biHeight; y++){

					LPBYTE pDest = pTemp    + (y * bm.bmiHeader.biWidth * 3);
					LPBYTE pSrc  = pImage + (y * bm.bmiHeader.biWidth * 4);

					for(int x=0; x<bm.bmiHeader.biWidth; x++){
						pDest[0] = pSrc[0];
						pDest[1] = pSrc[1];
						pDest[2] = pSrc[2];

						pDest+=3;
						pSrc +=4;
					}
				}


				SetDIBitsToDevice(hDC, rc.left, rc.top, rc.right, rc.bottom, 0, 0, 0, Line, pTemp, (BITMAPINFO*)&bm, DIB_RGB_COLORS);
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
					LPWORD pSrc  = LPWORD(pImage) + (y * bm.bmiHeader.biWidth * Bpp);

					for(int x=0; x<bm.bmiHeader.biWidth; x++){
						switch(g_BitMode){
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


				SetDIBitsToDevice(hDC, rc.left, rc.top, rc.right, rc.bottom, 0, 0, 0, Line, pTemp, (BITMAPINFO*)&bm, DIB_RGB_COLORS);
				delete[] pTemp;
			}
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
	g_CArtCamSdk[0].Close();
	g_CArtCamSdk[1].Close();


	// Release area for image
	SAFE_DELETE(g_pImage[0]);
	SAFE_DELETE(g_pImage[1]);


	// Set window to be displayed
	// When setting NULL to hWnd,it is possible to create new window and show it.
	RECT rc;
	GetClientRect(hWnd, &rc);
	g_CArtCamSdk[0].SetPreviewWindow(hWnd, 0, 0, rc.right/2, rc.bottom);
	g_CArtCamSdk[1].SetPreviewWindow(hWnd, rc.right/2, 0, rc.right, rc.bottom);


	// Display image
	g_CArtCamSdk[0].Preview();
	g_CArtCamSdk[1].Preview();


	// Check menu
	::CheckMenuItem(g_Menu.Preview, 0, MF_BYPOSITION | MF_CHECKED);
	::CheckMenuItem(g_Menu.Preview, 1, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 3, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 4, MF_BYPOSITION | MF_UNCHECKED);

	g_Preview = 0;

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
		MessageBox(hWnd, "Select DLL for the camera connected", "Error", MB_OK);
		return FALSE;
	}

	// Delete timer
	if(3 == g_Preview){
		KillTimer(hWnd, TIMER_ID);
	}


	// Release device
	g_CArtCamSdk[0].Close();
	g_CArtCamSdk[1].Close();


	// Release area for image
	SAFE_DELETE(g_pImage[0]);
	SAFE_DELETE(g_pImage[1]);


	// If drawing by yourself, set all window size to 0.
	// An automatic display can be performed, if window size is set up even when using CallBackPreview
	g_CArtCamSdk[0].SetPreviewWindow(hWnd, 0, 0, 0, 0);
	g_CArtCamSdk[1].SetPreviewWindow(hWnd, 0, 0, 0, 0);


	// Secure the space for taking in
	g_pImage[0] = new BYTE[ArtCamGetSize(0)];
	g_pImage[1] = new BYTE[ArtCamGetSize(1)];

	g_CArtCamSdk[0].CallBackPreview(hWnd, g_pImage[0], ArtCamGetSize(0), 0);
	g_CArtCamSdk[1].CallBackPreview(hWnd, g_pImage[1], ArtCamGetSize(1), 0);


	// Check menu
	::CheckMenuItem(g_Menu.Preview, 0, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 1, MF_BYPOSITION | MF_CHECKED);
	::CheckMenuItem(g_Menu.Preview, 3, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 4, MF_BYPOSITION | MF_UNCHECKED);

	g_Preview = 1;

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
	g_CArtCamSdk[0].Close();
	g_CArtCamSdk[1].Close();


	// Release area for image
	SAFE_DELETE(g_pImage[0]);
	SAFE_DELETE(g_pImage[1]);


	// Secure the space for taking in
	g_pImage[0] = new BYTE[ArtCamGetSize(0)];
	g_pImage[1] = new BYTE[ArtCamGetSize(1)];

	g_CArtCamSdk[0].SnapShot(g_pImage[0], ArtCamGetSize(0), 0);
	g_CArtCamSdk[1].SnapShot(g_pImage[1], ArtCamGetSize(1), 0);


	// Draw image
	DrawImage(hWnd, NULL, 0);
	DrawImage(hWnd, NULL, 1);

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

LRESULT OnCapture(HWND hWnd)
{
	// Not selected DLL
	if(-1 == g_DllType){
		MessageBox(hWnd, _T("Select DLL for the camera connected"), _T("Error"), MB_OK);
		return FALSE;
	}


	// Release device
	g_CArtCamSdk[0].Close();
	g_CArtCamSdk[1].Close();


	// Release area for image
	SAFE_DELETE(g_pImage[0]);
	SAFE_DELETE(g_pImage[1]);

	// Secure the space for taking in
	g_pImage[0] = new BYTE[ArtCamGetSize(0)];
	g_pImage[1] = new BYTE[ArtCamGetSize(1)];

	g_CArtCamSdk[0].Capture();
	g_CArtCamSdk[1].Capture();


	// Check menu
	::CheckMenuItem(g_Menu.Preview, 0, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 1, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 3, MF_BYPOSITION | MF_CHECKED);
	::CheckMenuItem(g_Menu.Preview, 4, MF_BYPOSITION | MF_UNCHECKED);

	g_Preview = 3;

	SetTimer(hWnd, TIMER_ID, TIMER_TIME, NULL);

	return TRUE;
}


LRESULT OnTimer(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
	if(3 == g_Preview && TIMER_ID == wParam){
		KillTimer(hWnd, TIMER_ID);

		g_CArtCamSdk[0].SnapShot(g_pImage[0], ArtCamGetSize(0), 0);
		g_CArtCamSdk[1].SnapShot(g_pImage[1], ArtCamGetSize(1), 0);

		// Draw image
		DrawImage(hWnd, NULL, 0);
		DrawImage(hWnd, NULL, 1);

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
	g_CArtCamSdk[0].Close();
	g_CArtCamSdk[1].Close();


	// Release area for image
	SAFE_DELETE(g_pImage[0]);
	SAFE_DELETE(g_pImage[1]);


	// If drawing by yourself, set all window size to 0.
	// An automatic display can be performed, if window size is set up even when using CallBackPreview
	g_CArtCamSdk[0].SetPreviewWindow(hWnd, 0, 0, 0, 0);
	g_CArtCamSdk[1].SetPreviewWindow(hWnd, 0, 0, 0, 0);


	// Secure the space for taking in
	g_pImage[0] = new BYTE[ArtCamGetSize(0)];
	g_pImage[1] = new BYTE[ArtCamGetSize(1)];

	g_CArtCamSdk[0].Trigger(hWnd, g_pImage[0], ArtCamGetSize(0), 0);
	g_CArtCamSdk[1].Trigger(hWnd, g_pImage[1], ArtCamGetSize(1), 0);


	// Check menu
	::CheckMenuItem(g_Menu.Preview, 0, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 1, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 3, MF_BYPOSITION | MF_UNCHECKED);
	::CheckMenuItem(g_Menu.Preview, 4, MF_BYPOSITION | MF_CHECKED);

	g_Preview = 4;

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
	g_CArtCamSdk[0].Release();
	g_CArtCamSdk[1].Release();
	g_CArtCamSdk[0].FreeLibrary();
	g_CArtCamSdk[1].FreeLibrary();

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

	BOOL res = g_CArtCamSdk[0].LoadLibrary(szDllName);
	if(!res){
		MessageBox(hWnd, _T("DLL is not found.\nDLL may have been relocated after executing"), _T("Error"), MB_OK);
		return FALSE;
	}else{
		g_CArtCamSdk[1].LoadLibrary(szDllName);
	}

	// In case of showing two cameras at the same time,
	// please follow the flow as Initialize -> SetDeviceNumber
	// When try to initialize the other camera after initialize one camera and display,
	// there is possibility of one camera take infuluence.
	if(!g_CArtCamSdk[0].Initialize(hWnd)){
		MessageBox(hWnd, _T("Failed to initialize SDK"), _T("Error"), MB_OK);
		return FALSE;
	}
	if(!g_CArtCamSdk[1].Initialize(hWnd)){
		MessageBox(hWnd, _T("Failed to initialize SDK"), _T("Error"), MB_OK);
		return FALSE;
	}
	g_DllType = DllType;
	g_SataType = CameraType;

	// Select SATA camera type when use Sata.dll
	if(-1 != CameraType && ARTCAM_CAMERATYPE_SATA == HIWORD(g_CArtCamSdk[0].GetDllVersion())){
		g_CArtCamSdk[0].SetCameraType(CameraType);
	}
	if(-1 != CameraType && ARTCAM_CAMERATYPE_SATA == HIWORD(g_CArtCamSdk[1].GetDllVersion())){
		g_CArtCamSdk[1].SetCameraType(CameraType);
	}


	// It is possible to know if device is connected after obtain device name.
	TCHAR szDeviceName[256]="";
	if(!g_CArtCamSdk[0].GetDeviceName(0, szDeviceName, 256)){
		g_CArtCamSdk[0].FreeLibrary();
	}
	if(!g_CArtCamSdk[1].GetDeviceName(1, szDeviceName, 256)){
		// No device
		// Please note that there is possibility of duplication access to one device
		// if there is access from two classes when only one device detected.
		// In this case, please release class or do not call function.

		// If you release class, it comes to be safe failure even when call function.
		g_CArtCamSdk[1].FreeLibrary();
	}


	g_CArtCamSdk[0].SetDeviceNumber(0);
	g_CArtCamSdk[1].SetDeviceNumber(1);

	// To operate 2 cameras simultenously, set camera clock to half.
	g_CArtCamSdk[0].SetHalfClock(TRUE);
	g_CArtCamSdk[1].SetHalfClock(TRUE);


	CheckColorMode();


	// Check menu
	for(i=0; i<g_DllCount; i++){
		::CheckMenuItem(g_Menu.Dll, i+1, MF_BYPOSITION | MF_UNCHECKED);
	}
	::CheckMenuItem(g_Menu.Dll, DllType+1, MF_BYPOSITION | MF_CHECKED);

	if(-1 != CameraType && ARTCAM_CAMERATYPE_SATA == HIWORD(g_CArtCamSdk[0].GetDllVersion())){
		for(int type=0; type<ARTCAM_CAMERATYPE_SATA_200MI-ARTCAM_CAMERATYPE_SATA_LVDS+1; type++){
			::CheckMenuItem(::GetSubMenu(g_Menu.Dll, g_DllSata+1), type, MF_BYPOSITION | MF_UNCHECKED);
		}
		::CheckMenuItem(::GetSubMenu(g_Menu.Dll, g_DllSata+1), g_SataType, MF_BYPOSITION | MF_CHECKED);
	}


	// Switch to ON or OFF of setting window
	switch(HIWORD(g_CArtCamSdk[0].GetDllVersion())){
	case ARTCAM_CAMERATYPE_CNV:
		::EnableMenuItem(g_Menu.Set, 0, MF_BYPOSITION | MF_ENABLED);
		::EnableMenuItem(g_Menu.Set, 1, MF_BYPOSITION | MF_ENABLED);
		::EnableMenuItem(g_Menu.Set, 2, MF_BYPOSITION | MF_GRAYED);
	break;

	// Other
	default:
		::EnableMenuItem(g_Menu.Set, 0, MF_BYPOSITION | MF_ENABLED);
		::EnableMenuItem(g_Menu.Set, 1, MF_BYPOSITION | MF_ENABLED);
		::EnableMenuItem(g_Menu.Set, 2, MF_BYPOSITION | MF_ENABLED);
	break;
	}


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
//	WM_CREATE
//

LRESULT OnCreate(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
	TCHAR szFilePath[MAX_PATH]="";
	TCHAR szExePath[3][MAX_PATH]={"","",""};
	GetModuleFileName(::GetModuleHandle(NULL), szExePath[0], MAX_PATH);
#if defined(__VS2005__) | (__VS2010__)
	_splitpath_s(szExePath[0], szExePath[1], MAX_PATH, szExePath[2], MAX_PATH, NULL, 0, NULL, 0);
#else
	_splitpath(szExePath[0], szExePath[1], szExePath[2], NULL, NULL);
#endif
	wsprintf(szFilePath, "%s%sSample.ini", szExePath[1], szExePath[2]);

	g_DllType = ::GetPrivateProfileInt("Sample", "DllType", -1, szFilePath);
	g_SataType = ::GetPrivateProfileInt("Sample", "CameraType", -1, szFilePath);

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
		g_CArtCamSdk[0].SaveImage("Image1.jpg", FILETYPE_JPEG_HIGH);
		g_CArtCamSdk[1].SaveImage("Image2.jpg", FILETYPE_JPEG_HIGH);
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

	// Camera settingsCamera setting
	case IDM_FORMAT1:
		// When show camera setting dialog,recommend to release display once.
		// Stop image refresh with SDK even when not stop with application.
		// In case of stop with SDK,it restarts when close dialog
		// There is possibility of illegality processing 
		// if you don't correspond setting with application when you change setting and close dialog.
		if(3 == g_Preview)	KillTimer(hWnd, TIMER_ID);

		g_CArtCamSdk[0].Close();
		g_CArtCamSdk[1].Close();
		g_CArtCamSdk[0].SetCameraDlg(hWnd);
		CheckColorMode();

		switch(g_Preview){
		case 0:	return OnPreview(hWnd);
		case 1:	return OnCallBack(hWnd);
		case 3:	return OnCapture(hWnd);
		case 4:	return OnTrigger(hWnd);
		}
	return 1;

	case IDM_FORMAT2:
		// When show camera setting dialog,recommend to release display once.
		// Stop image refresh with SDK even when not stop with application.
		// In case of stop with SDK,it restarts when close dialog
		// There is possibility of illegality processing 
		// if you don't correspond setting with application when you change setting and close dialog.
		if(3 == g_Preview)	KillTimer(hWnd, TIMER_ID);

		g_CArtCamSdk[0].Close();
		g_CArtCamSdk[1].Close();
		g_CArtCamSdk[1].SetCameraDlg(hWnd);
		CheckColorMode();

		switch(g_Preview){
		case 0:	return OnPreview(hWnd);
		case 1:	return OnCallBack(hWnd);
		case 3:	return OnCapture(hWnd);
		case 4:	return OnTrigger(hWnd);
		}
	return 1;

	// Filter settings
	case IDM_FILTER1:
		g_CArtCamSdk[0].SetImageDlg(hWnd);
	return 1;

	case IDM_FILTER2:
		g_CArtCamSdk[1].SetImageDlg(hWnd);
	return 1;

	// Analog settings
	case IDM_ANALOG1:
		g_CArtCamSdk[0].SetAnalogDlg(hWnd);
	return 1;

	case IDM_ANALOG2:
		g_CArtCamSdk[1].SetAnalogDlg(hWnd);
	return 1;


	case IDM_DLL_RELOAD:	OnDllReload();			return 1;
	}


	UINT ID = LOWORD(wParam);
	LONG DllNumber = ID - IDM_DLL_RELOAD - 1;
	if(0 <= DllNumber && DllNumber < g_DllCount){
		OnDllChange(hWnd, DllNumber, -1);
	}
	else if(ID_DLL_SATA_LVDS <= ID && ID <= ID_DLL_SATA_200MI){
		LONG SataType = ID - ID_DLL_SATA_LVDS;
		OnDllChange(hWnd, g_DllSata, SataType);
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
		DrawImage(hWnd, hDC, 0);
		DrawImage(hWnd, hDC, 1);
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
	DrawImage(hWnd, NULL, 0);
	DrawImage(hWnd, NULL, 1);


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
	g_CArtCamSdk[0].Release();
	g_CArtCamSdk[1].Release();
	SAFE_DELETE(g_pImage[0]);
	SAFE_DELETE(g_pImage[1]);


	TCHAR szFilePath[MAX_PATH]="";
	TCHAR szExePath[3][MAX_PATH]={"","",""};
	GetModuleFileName(::GetModuleHandle(NULL), szExePath[0], MAX_PATH);
#if defined(__VS2005__) | (__VS2010__)
	_splitpath_s(szExePath[0], szExePath[1], MAX_PATH, szExePath[2], MAX_PATH, NULL, 0, NULL, 0);
#else
	_splitpath(szExePath[0], szExePath[1], szExePath[2], NULL, NULL);
#endif
	wsprintf(szFilePath, "%s%sSample.ini", szExePath[1], szExePath[2]);


	TCHAR Data[32]="";
	wsprintf(Data, "%d", g_DllType);
	::WritePrivateProfileString("Sample", "DllType", Data, szFilePath);

	wsprintf(Data, "%d", g_SataType);
	::WritePrivateProfileString("Sample", "CameraType", Data, szFilePath);


	::PostQuitMessage(0);
	return 1;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	WM_SIZE
//

HWND ChildList[2] = {NULL, NULL};

static BOOL CALLBACK EnumChildProc(HWND hWnd, LPARAM lParam)
{
	for(int i=0; i<2; i++){
		if(NULL == ChildList[i]){
			ChildList[i] = hWnd;
			break;
		}
	}

	return 1;
}

LRESULT OnSize(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
	if(0 == g_Preview){
		ChildList[0] = NULL;
		ChildList[1] = NULL;

		// Child window enumeration 
		::LockWindowUpdate(hWnd);
		::EnumChildWindows(hWnd, ::EnumChildProc, NULL);
		::LockWindowUpdate(NULL);

		RECT rc;
		GetClientRect(hWnd, &rc);

		LONG Width[2]  = { rc.right/2, rc.right/2 };
		LONG Height[2] = { rc.bottom, rc.bottom };


		// To avoiding changing aspect ratio, remove comment
/*
		// Calculation results in decimal figure. So apply floating-point calculations.
		for(int i=0; i<2; i++){
			double winW = rc.right/2;
			double winH = rc.bottom;
			double capW = ArtCamGetWidth(i);
			double capH = ArtCamGetHeight(i);

			if( (winW * capH) > (winH * capW) ){
				winW = winH * capW / capH;
				Width[i] = LONG(winW);
			}
			else if( (winW * capH) < (winH * capW) ){
				winH = winW * capH / capW;
				Height[i] = LONG(winH);
			}
		}
*/
		SetWindowPos(ChildList[0], HWND_TOP,          0, 0, Width[0], Height[0], SWP_NOZORDER | SWP_SHOWWINDOW);
		SetWindowPos(ChildList[1], HWND_TOP, rc.right/2, 0, Width[0], Height[0], SWP_NOZORDER | SWP_SHOWWINDOW);
	}

	return 1;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Window procedure
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
	default:			return ::DefWindowProc	(hWnd, uMsg, wParam, lParam);
	}
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Window initialization
//

HWND InitWindow(HINSTANCE hInstance, int nCmdShow)
{
	// Registrate window class
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

	// Window size setting
	RECT rcWndSize = {0, 0, 900, 600};
	DWORD dwStyle = WS_POPUPWINDOW | WS_CAPTION | WS_OVERLAPPEDWINDOW;
	if(0 == ::AdjustWindowRectEx(&rcWndSize, dwStyle, TRUE, NULL))
		return NULL;

	// Main window create
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
	::InsertMenu(g_Menu.Set, 0, MF_BYPOSITION | MF_STRING, IDM_FORMAT1,	_T("Format settings1(&C)"));
	::InsertMenu(g_Menu.Set, 1, MF_BYPOSITION | MF_STRING, IDM_FORMAT2,	_T("Format settings2(&C)"));
	::InsertMenu(g_Menu.Set, 2, MF_BYPOSITION | MF_STRING, IDM_FILTER1,	_T("Filter settings1(&F)"));
	::InsertMenu(g_Menu.Set, 3, MF_BYPOSITION | MF_STRING, IDM_FILTER2,	_T("Filter settings2(&F)"));
	::InsertMenu(g_Menu.Set, 4, MF_BYPOSITION | MF_STRING, IDM_ANALOG1,	_T("Analog settings1(&A)"));
	::InsertMenu(g_Menu.Set, 5, MF_BYPOSITION | MF_STRING, IDM_ANALOG2,	_T("Analog settings2(&A)"));

	// DLL selective menu
	g_Menu.Dll = ::CreateMenu();
	::InsertMenu(g_Menu.Dll,  0, MF_BYPOSITION | MF_STRING, IDM_DLL_RELOAD,	_T("Reload"));


	// Check if there is DLL
	OnDllReload();

	// Main menu
	HMENU hMenu = ::CreateMenu();
	::InsertMenu(hMenu, 0, MF_POPUP | MF_STRING, (UINT)g_Menu.File,    _T("File(&F)"));
	::InsertMenu(hMenu, 1, MF_POPUP | MF_STRING, (UINT)g_Menu.Preview, _T("Display(&V)"));
	::InsertMenu(hMenu, 2, MF_POPUP | MF_STRING, (UINT)g_Menu.Set,     _T("Settings(&S)"));
	::InsertMenu(hMenu, 3, MF_POPUP | MF_STRING, (UINT)g_Menu.Dll,     _T("DLL(&L)"));


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

	return msg.wParam;
}




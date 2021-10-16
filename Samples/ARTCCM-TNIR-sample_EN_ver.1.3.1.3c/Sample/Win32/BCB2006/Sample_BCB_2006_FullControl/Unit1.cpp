//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
#include "Unit2.h"
#include "Unit3.h"
#include "Unit4.h"
#include "Unit5.h"
#include "Unit6.h"
#include "Unit7.h"

//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;

//---------------------------------------------------------------------------
LRESULT CALLBACK MsgProc(int nCode, WPARAM wp, LPARAM lp)
{
	if(nCode < 0)
		return CallNextHookEx(Form1->m_Hook, nCode, wp, lp);

	if(HC_ACTION == nCode){
		PMsg Msg = (PMsg)lp;

		// Display code. Sent from SDK when the new image is captured
		if(WM_GRAPHPAINT == Msg->message){
			Form1->m_SaveFlg = TRUE;
			Form1->DrawImage();
		}

		// Error Code
		if(WM_ERROR == Msg->message){
			switch(Msg->lParam){
			case ARTCAMSDK_NOERROR:         Form1->Caption = "Sample";	break;
			case ARTCAMSDK_NOT_INITIALIZE:  Form1->Caption = "Not initialized";	break;
			case ARTCAMSDK_DISABLEDDEVICE:  Form1->Caption = "Access to unavailable device was attempted";	break;
			case ARTCAMSDK_CREATETHREAD:    Form1->Caption = "Failure of thread creation for capturing";	break;
			case ARTCAMSDK_CREATEWINDOW:    Form1->Caption = "Window creation failed";	break;
			case ARTCAMSDK_OUTOFMEMORY:     Form1->Caption = "Not enough memory for image transfer/Failure for securing memory";	break;
			case ARTCAMSDK_CAMERASET:       Form1->Caption = "Error for camera (device) settings";	break;
			case ARTCAMSDK_CAPTURE:         Form1->Caption = "Capturing failed";	break;
			case ARTCAMSDK_PARAM:           Form1->Caption = "Wrong argument";	break;
			case ARTCAMSDK_DIRECTSHOW:      Form1->Caption = "Directshow initialization error";	break;
			case ARTCAMSDK_UNSUPPORTED:     Form1->Caption = "Not supported";	break;
			case ARTCAMSDK_UNKNOWN:         Form1->Caption = "Unknow error";	break;
			case ARTCAMSDK_CAPTURELOST:     Form1->Caption = "Device lost";	break;
			case ARTCAMSDK_FILENOTFOUND:    Form1->Caption = "File not found";	break;
			case ARTCAMSDK_FPGASET:         Form1->Caption = "FPGA setting error";	break;
			case ARTCAMSDK_TRANSIMAGEFAILED:Form1->Caption = "Failure of image transferring";	break;
			default:                        Form1->Caption = "Unknown error";	break;
			}
		}
	}

	return CallNextHookEx(Form1->m_Hook, nCode, wp, lp);
}


//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
		: TForm(Owner)
		, m_DllType(-1)
		, m_DllSata(-1)
		, m_DllCount(0)
		, m_CurrentCameraType(-1)
		, m_SataType(-1)
		, m_PreviewMode(-1)
		, m_SelectDevice(-1)
		, m_BmpCapture(NULL)
		, m_BmpDraw(NULL)
		, m_Hook(NULL)
{
	m_SaveFlg = FALSE;
	m_StopFlg = FALSE;

	Timer1->Enabled = false;
	RecTimer->Enabled = false;
}
//---------------------------------------------------------------------------
void __fastcall TForm1::FormCreate(TObject *Sender)
{
	OnDllReload();
	m_Hook = SetWindowsHookEx(WH_GETMESSAGE, (HOOKPROC)MsgProc, 0, GetCurrentThreadId());
}
//---------------------------------------------------------------------------
void __fastcall TForm1::SaveClick(TObject *Sender)
{
	SaveDialog1->Filter = "BITMAPFile(*.bmp)|*.bmp|JPEGFile(*.jpg)|*.jpg;*.jpeg|TIFFFile(*.tif)|*.tif;*.tiff|PNGFile(*.png)|*.png|RAWFile(*.raw)|*.raw||";
	SaveDialog1->Options << ofOverwritePrompt;

	if(SaveDialog1->Execute()){
		// Set extension yourself
		TCHAR szTemp[4][MAX_PATH]={"","","",""};
		_splitpath(SaveDialog1->FileName.c_str(), szTemp[0], szTemp[1], szTemp[2], szTemp[3]);

		AnsiString str;
		switch(SaveDialog1->FilterIndex){
		case 1:	str.printf("%s%s%s.bmp", szTemp[0], szTemp[1], szTemp[2]);	m_CArtCamSdk.SaveImage(str.c_str(), FILETYPE_BITMAP);		break;
		case 2:	str.printf("%s%s%s.jpg", szTemp[0], szTemp[1], szTemp[2]);	m_CArtCamSdk.SaveImage(str.c_str(), FILETYPE_JPEG_HIGH);	break;
		case 3:	str.printf("%s%s%s.tif", szTemp[0], szTemp[1], szTemp[2]);	m_CArtCamSdk.SaveImage(str.c_str(), FILETYPE_TIFF);			break;
		case 4:	str.printf("%s%s%s.png", szTemp[0], szTemp[1], szTemp[2]);	m_CArtCamSdk.SaveImage(str.c_str(), FILETYPE_PNG);			break;
		case 5:	str.printf("%s%s%s.raw", szTemp[0], szTemp[1], szTemp[2]);	m_CArtCamSdk.SaveImage(str.c_str(), FILETYPE_RAW);			break;
		}
	}
}
//---------------------------------------------------------------------------
void __fastcall TForm1::FileRecClick(TObject *Sender)
{
	SaveDialog1->Filter = "AVIFile(*.avi)|*.avi||";
	SaveDialog1->Options << ofOverwritePrompt;
	SaveDialog1->DefaultExt = "avi";

	if(SaveDialog1->Execute()){
		m_RecName = SaveDialog1->FileName;

		// Pause
		m_CArtCamSdk.Close();

		// Display on different window while recording
		// When "hWnd" is NULL, window is created from SDK side and therefore the size is not important.
		m_CArtCamSdk.SetPreviewWindow(NULL, 0, 0, 0, 0);

		// 5 seconds recording
		m_CArtCamSdk.Record(SaveDialog1->FileName.c_str(), 5000, 1);


		// Timing for record ending is not sent from SDK and therefore it needs to be stopped by software.
		// Just in case, run the timer for 1 sencond longer.
		RecTimer->Interval = 6000;
		RecTimer->Enabled = true;
	}
}
//---------------------------------------------------------------------------
void __fastcall TForm1::ExitClick(TObject *Sender)
{
	Close();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::PreviewClick(TObject *Sender)
{
	// Not selected DLL
	if(-1 == m_DllType){
		ShowMessage("Select DLL for the camera connected");
		return;
	}

	// Delete timer
	if(3 == m_PreviewMode){
		Timer1->Enabled = false;
	}

	// Release device
	m_CArtCamSdk.Close();

	// Set window to be displayed
	// New window is created when NULL is set in Handle.
	TRect rc = GetClientRect();
	m_CArtCamSdk.SetPreviewWindow(Handle, 0, 0, rc.right, rc.bottom);

	// Display image
	// Display is controlled by SDK. Image information cannot be obtained.
	m_CArtCamSdk.Preview();

	// Check menu
	ShowPreview->Checked  = true;
	ShowCallBack->Checked = false;
	ShowCapture->Checked  = false;
	ShowTrigger->Checked  = false;

	m_PreviewMode = 0;
	m_SaveFlg = TRUE;
	m_StopFlg = FALSE;
	ShowStop->Caption = "Pause";

	Invalidate();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::CallBackClick(TObject *Sender)
{
	// Not selected DLL
	if(-1 == m_DllType){
		ShowMessage("Select DLL for the camera connected");
		return;
	}

	// Delete timer
	if(3 == m_PreviewMode){
		Timer1->Enabled = false;
	}

	// Release device
	m_CArtCamSdk.Close();

	// If drawing by yourself, set all window size to 0.
	// An automatic display can be performed, if window size is set up even when using CallBackPreview
	m_CArtCamSdk.SetPreviewWindow(Handle, 0, 0, 0, 0);

	// Creat area for capturing
	CreateBitmap();

	// Capture image
	m_CArtCamSdk.CallBackPreview(Handle, m_BmpCapture, ArtCamGetSize(), 0);

	// Check menu
	ShowPreview->Checked  = false;
	ShowCallBack->Checked = true;
	ShowCapture->Checked  = false;
	ShowTrigger->Checked  = false;

	m_PreviewMode = 1;
	m_StopFlg = FALSE;
	ShowStop->Caption = "Pause";

	Invalidate();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::SnapShotClick(TObject *Sender)
{
	// Not selected DLL
	if(-1 == m_DllType){
		ShowMessage("Select DLL for the camera connected");
		return;
	}

	// Delete timer
	if(3 == m_PreviewMode){
		Timer1->Enabled = false;
	}

	// Release device
	m_CArtCamSdk.Close();

	// Creat area for capturing
	CreateBitmap();

	// Capture image
	m_CArtCamSdk.SnapShot(m_BmpCapture, ArtCamGetSize(), 0);

	// Draw image
	DrawImage();

	// Check menu
	ShowPreview->Checked  = false;
	ShowCallBack->Checked = false;
	ShowCapture->Checked  = false;
	ShowTrigger->Checked  = false;

//	Invalidate();
	m_PreviewMode = -1;
	m_StopFlg = FALSE;
	ShowStop->Caption = "Pause";
}
//---------------------------------------------------------------------------
void __fastcall TForm1::CaptureClick(TObject *Sender)
{
	// Not selected DLL
	if(-1 == m_DllType){
		ShowMessage("Select DLL for the camera connected");
		return;
	}

	// Release device
	m_CArtCamSdk.Close();

	// Set window to be displayed
	// New window is created when NULL is set in Handle.
	TRect rc = GetClientRect();
	m_CArtCamSdk.SetPreviewWindow(Handle, 0, 0, rc.right, rc.bottom);

	// Creat area for capturing
	CreateBitmap();

	// Display image
	m_CArtCamSdk.Capture();

	// Check menu
	ShowPreview->Checked  = false;
	ShowCallBack->Checked = false;
	ShowCapture->Checked  = true;
	ShowTrigger->Checked  = false;

	m_PreviewMode = 3;
	m_StopFlg = FALSE;
	ShowStop->Caption = "Pause";

	Invalidate();

	Timer1->Enabled = true;
	Timer1->Interval = 200;
}
//---------------------------------------------------------------------------
void __fastcall TForm1::TriggerClick(TObject *Sender)
{
	// Not selected DLL
	if(-1 == m_DllType){
		ShowMessage("Select DLL for the camera connected");
		return;
	}

	// Delete timer
	if(3 == m_PreviewMode){
		Timer1->Enabled = false;
	}

	// Release device
	m_CArtCamSdk.Close();

	// If drawing by yourself, set all window size to 0.
	// An automatic display can be performed, if window size is set up even when using CallBackPreview
	m_CArtCamSdk.SetPreviewWindow(Handle, 0, 0, 0, 0);

	// Creat area for capturing
	CreateBitmap();

	// Capture image
	m_CArtCamSdk.Trigger(Handle, m_BmpCapture, ArtCamGetSize(), 0);

	// Check menu
	ShowPreview->Checked  = false;
	ShowCallBack->Checked = false;
	ShowCapture->Checked  = false;
	ShowTrigger->Checked  = true;

	m_PreviewMode = 4;
	m_StopFlg = FALSE;
	ShowStop->Caption = "Pause";

	Invalidate();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::SetCameraClick(TObject *Sender)
{
	m_CArtCamSdk.SetCameraDlg(Handle);

	Invalidate();
	switch(m_PreviewMode){
	case 0:	PreviewClick(Sender); break;
	case 1:	CallBackClick(Sender); break;
	case 3:	CaptureClick(Sender); break;
	case 4:	TriggerClick(Sender); break;
	}
}
//---------------------------------------------------------------------------
void __fastcall TForm1::SetFilterClick(TObject *Sender)
{
	m_CArtCamSdk.SetImageDlg(Handle);
}
//---------------------------------------------------------------------------
void __fastcall TForm1::SetAnalogClick(TObject *Sender)
{
	m_CArtCamSdk.SetAnalogDlg(Handle);
}
//---------------------------------------------------------------------------
void TForm1::OnDeviceChange(TObject *Sender, LONG Number)
{
	// Not selected DLL
	if(-1 == m_DllType){
		ShowMessage("Select DLL for the camera connected");
		return;
	}


	// Release the operative device before switching device
	m_CArtCamSdk.Close();


	// To confirm whether the device is connected, use "GetDeviceName"
	// It can be found out easily with "GetDeviceName".
	// When area for obtain name is not secured, it results in error. Prepare alignment length of at least 32.
	TCHAR szName[256]="";
	if(!m_CArtCamSdk.GetDeviceName(Number, szName, 256)){
		m_PreviewMode = -1;
		m_SelectDevice = -1;
		m_StopFlg = FALSE;
		ShowStop->Caption = "Pause";
		return;
	}


	// A device will be changed, if a camera is displayed after changing the number of a device now
	// Notes: A device is not changed in this function simple substance
	//   After calling this function, a device is changed by initializing a device
	m_SelectDevice = Number;
	m_CArtCamSdk.SetDeviceNumber(Number);

	for(int i=0; i<8; i++){
		(*PopupDevice)[i]->Checked = false;
	}
	(*PopupDevice)[Number]->Checked = true;


	switch(m_PreviewMode){
	case 0:	PreviewClick(Sender); break;
	case 1:	CallBackClick(Sender); break;
	case 3:	CaptureClick(Sender); break;
	case 4:	TriggerClick(Sender); break;
	}
}
//---------------------------------------------------------------------------
void __fastcall TForm1::OnDllClick(TObject *Sender)
{
	 TMenuItem *temp;
	 temp = dynamic_cast<TMenuItem *>(Sender);
	 int id = PopupDll->IndexOf(temp);
	 if(id > -1){
		OnDllChange(Sender, id-1, -1);
	 }else{
	  int type = (*PopupDll)[m_DllSata+1]->IndexOf(temp);
	  if(ARTCAM_CAMERATYPE_SATA_LVDS <= type && type <= ARTCAM_CAMERATYPE_SATA_200MI){
		OnDllChange(Sender, m_DllSata, type);
	  }
	 }
}
//---------------------------------------------------------------------------
void TForm1::OnDllReload()
{
	// Delete DLL list
	for(int i=0; i<m_DllCount; i++){
		MainMenu1->Items->Items[3]->Delete(1);
	}
	m_DllCount = 0;
	m_DllSata  = -1;

	// Search for DLL
	TCHAR szDir[MAX_PATH]="";
	TCHAR szExePath[3][MAX_PATH]={"","",""};
	GetModuleFileName(::GetModuleHandle(NULL), szExePath[0], MAX_PATH);
	_splitpath(szExePath[0], szExePath[1], szExePath[2], NULL, NULL);
	wsprintf(szDir, "%s%s", szExePath[1], szExePath[2]);

	TCHAR szSearch[MAX_PATH]="";
	wsprintf(szSearch, "%s\\*.dll", szDir);

	HANDLE	hFindFile = NULL;
	WIN32_FIND_DATA	fd;
	ZeroMemory(&fd, sizeof(WIN32_FIND_DATA));

	if(INVALID_HANDLE_VALUE != (hFindFile = ::FindFirstFile(szSearch, &fd))){
		do {
			TCHAR szFileName[MAX_PATH]="";
			wsprintf(szFileName, "%s\\%s", szDir, fd.cFileName);

			DWORD dwResult = (::GetFileAttributes(szFileName) & FILE_ATTRIBUTE_DIRECTORY);

			if(FILE_ATTRIBUTE_DIRECTORY != dwResult){

				CArtCamSdk ArtCam;
				if(ArtCam.LoadLibrary(szFileName)){
					AnsiString str;
					// Obtain version and show it
					TCHAR szDllName[MAX_PATH]="";
					_splitpath(fd.cFileName, NULL, NULL, szDllName, NULL);
					str.printf("%s\tVersion %04d", szDllName, LOWORD(ArtCam.GetDllVersion()));

					// Add menu
					m_DllCount++;

					// Select SATA camera type when use Sata.dll
					if(ARTCAM_CAMERATYPE_SATA == HIWORD(ArtCam.GetDllVersion())){
						TPopupMenu *MenuSata = new TPopupMenu(this);
						MenuSata->AutoHotkeys = false;
						MenuSata->Items->Caption = str;
						int count = ARTCAM_CAMERATYPE_SATA_200MI + 1;
						AnsiString CameraName[12]={"LVDS",
												   "300MI",
												   "500MI",
												   "MV413",
												   "800MI",
												   "036MI",
												   "150P3",
												   "267KY",
												   "274KY",
												   "625KY",
												   "130MI",
												   "200MI",};
						for(int i=0; i<count; i++){
							TMenuItem *temp = new TMenuItem(this);
							temp->AutoHotkeys = false;
							temp->Caption = CameraName[i];
							temp->OnClick = OnDllClick;
							MenuSata->Items->Add(temp);
						}
						PopupDll->Add(MenuSata->Items);
						m_DllSata = m_DllCount-1;
					}
					else{

						TMenuItem *sub = new TMenuItem(this);
						sub->AutoHotkeys = false;
						sub->Caption = str;
						sub->OnClick = OnDllClick;
						PopupDll->Add(sub);
					}
				}
			}
		}
		while(::FindNextFile(hFindFile, &fd));

		::FindClose(hFindFile);
		hFindFile = NULL;
	}
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Device0Click(TObject *Sender) { OnDeviceChange(Sender, 0); }
void __fastcall TForm1::Device1Click(TObject *Sender) { OnDeviceChange(Sender, 1); }
void __fastcall TForm1::Device2Click(TObject *Sender) { OnDeviceChange(Sender, 2); }
void __fastcall TForm1::Device3Click(TObject *Sender) { OnDeviceChange(Sender, 3); }
void __fastcall TForm1::Device4Click(TObject *Sender) { OnDeviceChange(Sender, 4); }
void __fastcall TForm1::Device5Click(TObject *Sender) { OnDeviceChange(Sender, 5); }
void __fastcall TForm1::Device6Click(TObject *Sender) { OnDeviceChange(Sender, 6); }
void __fastcall TForm1::Device7Click(TObject *Sender) { OnDeviceChange(Sender, 7); }
void __fastcall TForm1::Device8Click(TObject *Sender) { OnDeviceChange(Sender, 8); }
void __fastcall TForm1::Device9Click(TObject *Sender) { OnDeviceChange(Sender, 9); }
//---------------------------------------------------------------------------
void TForm1::OnDllChange(TObject *Sender, LONG Number, LONG CameraType)
{
	// Release all devices before switching DLL
	// To display multiple images simulteously, you need to define CArtCamSdk plurally
	// When defined plurally, you do not need to relase to switch cameras
	m_CArtCamSdk.Release();
	m_CArtCamSdk.FreeLibrary();

	TCHAR szDllName[MAX_PATH]="";
	int i;
	AnsiString str = (*PopupDll)[Number+1]->Caption;
	AnsiString str2 = str.SubString(1, str.AnsiPos('\t')-1);
	str2 += ".dll";
	strcpy(szDllName, str2.c_str());
	BOOL res = m_CArtCamSdk.LoadLibrary(szDllName);
	if(!res){
		ShowMessage("DLL is not found.\nIt may have been relocated after executing.");
		return;
	}else{
		m_CurrentCameraType = HIWORD(m_CArtCamSdk.GetDllVersion());
	}

	// Initialize is to be called first
	// By setting Window Handle here, WMLERROR can be obtained
	if(!m_CArtCamSdk.Initialize(Handle)){
		ShowMessage("Failed to initialize SDK");
		return;
	}

	m_DllType  = Number;
	m_SataType = CameraType;
	// Select SATA camera type when use Sata.dll
	if(-1 != CameraType && ARTCAM_CAMERATYPE_SATA == m_CurrentCameraType){
		m_CArtCamSdk.SetCameraType(CameraType);

		// Prefer to specify the Capture size
		switch(m_SataType){
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

	// Check menu

	for(i=0; i<m_DllCount; i++){
		(*PopupDll)[i+1]->Checked = false;
	}
	(*PopupDll)[Number+1]->Checked = true;

	if(-1 != CameraType && ARTCAM_CAMERATYPE_SATA == m_CurrentCameraType){
		for(int type=0; type<ARTCAM_CAMERATYPE_SATA_200MI-ARTCAM_CAMERATYPE_SATA_LVDS+1; type++){
			(*PopupDll)[m_DllSata+1]->Items[type]->Checked = false;
		}
		(*PopupDll)[m_DllSata+1]->Items[m_SataType]->Checked = true;
	}

	TCHAR szName[8][256];
	LONG DeviceCount = m_CArtCamSdk.EnumDevice(szName);
	for(i=0; i<DeviceCount; i++){
		(*PopupDevice)[i]->Caption = szName[i];
		(*PopupDevice)[i]->Enabled = true;
	}
	for(; i<8; i++){
		(*PopupDevice)[i]->Caption = IntToStr(i);
		(*PopupDevice)[i]->Enabled = false;
		(*PopupDevice)[i]->Checked = false;
	}

	m_SaveFlg = FALSE;

	// Device setting
	OnDeviceChange(Sender, 0);
}
//---------------------------------------------------------------------------
void TForm1::DrawImage(void)
{
	// Convert to space for drawing
	LONG SrcBpp = ArtCamGetBpp();
	LONG SrcPitch = m_BmpDraw->Width * SrcBpp;

	if(1 == SrcBpp){
		for(int y=0; y<m_BmpDraw->Height; y++){
			LPBYTE lpDest = (LPBYTE)m_BmpDraw->ScanLine[y];
			LPBYTE lpSrc  = (LPBYTE)m_BmpCapture + ((m_BmpDraw->Height - y - 1) * SrcPitch);
			for(int x=0; x<m_BmpDraw->Width; x++){
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
		for(int y=0; y<m_BmpDraw->Height; y++){
			LPBYTE lpDest = (LPBYTE)m_BmpDraw->ScanLine[y];
			LPBYTE lpSrc  = (LPBYTE)m_BmpCapture + ((m_BmpDraw->Height - y - 1) * SrcPitch);
			for(int x=0; x<m_BmpDraw->Width; x++){
				lpDest[0] = (BYTE(lpSrc[1] << 6) | BYTE(lpSrc[0] >> 2));
				lpDest[1] = (BYTE(lpSrc[1] << 6) | BYTE(lpSrc[0] >> 2));
				lpDest[2] = (BYTE(lpSrc[1] << 6) | BYTE(lpSrc[0] >> 2));

				lpDest += 3;
				lpSrc  += SrcBpp;
			}
		}
	}

	// Color 24 bit transfer
	else if(3 == SrcBpp){
		memcpy(m_BmpDraw->ScanLine[m_BmpDraw->Height-1], m_BmpCapture, ArtCamGetSize());
	}

	// Color 32 bit transfer
	else if(4 == SrcBpp){
		for(int y=0; y<m_BmpDraw->Height; y++){
			LPBYTE lpDest = (LPBYTE)m_BmpDraw->ScanLine[y];
			LPBYTE lpSrc  = (LPBYTE)m_BmpCapture + ((m_BmpDraw->Height - y - 1) * SrcPitch);
			for(int x=0; x<m_BmpDraw->Width; x++){
				lpDest[0] = lpSrc[0];
				lpDest[1] = lpSrc[1];
				lpDest[2] = lpSrc[2];

				lpDest += 3;
				lpSrc  += SrcBpp;
			}
		}
	}

	// Color 48, 64 bit transfer
	else if(6 == SrcBpp || 8 == SrcBpp){
		for(int y=0; y<m_BmpDraw->Height; y++){
			LPBYTE lpDest = (LPBYTE)m_BmpDraw->ScanLine[y];
			LPBYTE lpSrc  = (LPBYTE)m_BmpCapture + ((m_BmpDraw->Height - y - 1) * SrcPitch);
			for(int x=0; x<m_BmpDraw->Width; x++){
				lpDest[0] = (BYTE(lpSrc[1] << 6) | BYTE(lpSrc[0] >> 2));
				lpDest[1] = (BYTE(lpSrc[3] << 6) | BYTE(lpSrc[2] >> 2));
				lpDest[2] = (BYTE(lpSrc[5] << 6) | BYTE(lpSrc[4] >> 2));

				lpDest += 3;
				lpSrc  += SrcBpp;
			}
		}
	}


	// Draw the cross on cursor 
	POINT pt;
	GetCursorPos(&pt);
	pt = ScreenToClient(pt);

	m_BmpDraw->Canvas->MoveTo(0, pt.y);
	m_BmpDraw->Canvas->LineTo(m_BmpDraw->Width, pt.y);
	m_BmpDraw->Canvas->MoveTo(pt.x, 0);
	m_BmpDraw->Canvas->LineTo(pt.x, m_BmpDraw->Height);

	// Draw image
	Canvas->Draw(0, 0, m_BmpDraw);
}
//---------------------------------------------------------------------------
void TForm1::CreateBitmap(void)
{
	// Release area for image
	if(m_BmpCapture){
		delete[] m_BmpCapture;
		m_BmpCapture = NULL;
	}

	if(m_BmpDraw){
		delete m_BmpDraw;
		m_BmpDraw = NULL;
	}

	// Creat area for display
	m_BmpCapture = new BYTE[ArtCamGetSize()];


	m_BmpDraw = new Graphics::TBitmap;
	m_BmpDraw->Width = ArtCamGetWidth();
	m_BmpDraw->Height = ArtCamGetHeight();
	m_BmpDraw->Canvas->Pen->Color = clRed;
	m_BmpDraw->PixelFormat = pf24bit;
}

//---------------------------------------------------------------------------

void __fastcall TForm1::Timer1Timer(TObject *Sender)
{
	if(Timer1 == Sender){
		m_CArtCamSdk.SnapShot(m_BmpCapture, ArtCamGetSize(), 0);
		m_SaveFlg = TRUE;

	// Draw image
		DrawImage();
	}
	else if(RecTimer == Sender){
		RecTimer->Enabled = false;
		m_CArtCamSdk.Close();

		if(IDYES == MessageBox(Handle, "Recording completePlay /n file?", "Complete", MB_YESNO | MB_ICONQUESTION)){
			::ShellExecute(NULL, NULL, m_RecName.c_str(), NULL, NULL, SW_SHOWNORMAL);
		}
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormDestroy(TObject *Sender)
{
	UnhookWindowsHookEx(m_Hook);
	m_Hook = NULL;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormResize(TObject *Sender)
{
	// In Preview Mode, display size varies when size of child window is changed.
	if(0 == m_PreviewMode){
		HWND hChild = GetWindow(Handle, GW_CHILD);

		RECT rc = GetClientRect();

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

	ChangeScrollbar();
}
//---------------------------------------------------------------------------


void __fastcall TForm1::SetUserSizeClick(TObject *Sender)
{
	if(m_CArtCamSdk.IsInit()){
		m_CArtCamSdk.Close();
		Form3->m_pCArtCamSdk = &m_CArtCamSdk;
		Form3->ShowModal();
		ReDraw();
	}
}
//---------------------------------------------------------------------------

void TForm1::ReDraw(void)
{
	Invalidate();
	switch(m_PreviewMode){
	case 0:	PreviewClick(NULL); break;
	case 1:	CallBackClick(NULL); break;
	case 3:	CaptureClick(NULL); break;
	case 4:	TriggerClick(NULL); break;
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::SetUserFilterClick(TObject *Sender)
{
	if(m_CArtCamSdk.IsInit()){
		Form2->m_pCArtCamSdk = &m_CArtCamSdk;
		Form2->m_Preview = m_PreviewMode;
		Form2->Show();
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::SetUserIOClick(TObject *Sender)
{
	if(m_CArtCamSdk.IsInit()){
		Form4->m_pCArtCamSdk = &m_CArtCamSdk;
		Form4->m_Preview = m_PreviewMode;
		Form4->Show();
	}
}
//---------------------------------------------------------------------------

void TForm1::ChangeScrollbar(void)
{
	if(0 == m_PreviewMode){
		SetScrollPos(Handle, SB_HORZ, 0, TRUE);
		SetScrollPos(Handle, SB_VERT, 0, TRUE);
		ShowScrollBar(Handle, SB_HORZ, FALSE);
		ShowScrollBar(Handle, SB_VERT, FALSE);
		return;
	}


	TRect rc = GetClientRect();

	LONG lWidth  = ArtCamGetWidth();
	LONG lHeight = ArtCamGetHeight();

	LONG PosX = GetScrollPos(Handle, SB_HORZ);
	LONG PosY = GetScrollPos(Handle, SB_VERT);


	SCROLLINFO sc;
	sc.cbSize	= sizeof(SCROLLINFO);
	sc.fMask	= SIF_RANGE | SIF_POS | SIF_PAGE;

	LONG OffsetH = 16;
	LONG OffsetV = 16;


	if(rc.right + OffsetH >= lWidth){
		ShowScrollBar(Handle, SB_HORZ, FALSE);
	} else {
		sc.nMin		= 0;
		sc.nMax		= lWidth;
		sc.nPage	= rc.right;
		sc.nPos		= PosX;
		SetScrollInfo(Handle, SB_HORZ, &sc, TRUE);
	}

	if(rc.bottom + OffsetV >= lHeight){
		ShowScrollBar(Handle, SB_VERT, FALSE);
	} else {
		sc.nMin		= 0;
		sc.nMax		= lHeight;
		sc.nPage	= rc.bottom;
		sc.nPos		= PosY;
		SetScrollInfo(Handle, SB_VERT, &sc, TRUE);
	}

	if(lWidth  - rc.right  < PosX)	SetScrollPos(Handle, SB_HORZ, lWidth  - rc.right, FALSE);
	if(lHeight - rc.bottom < PosY)	SetScrollPos(Handle, SB_VERT, lHeight - rc.bottom, FALSE);
	if(0.0 > PosX)					SetScrollPos(Handle, SB_HORZ, 0, FALSE);
	if(0.0 > PosY)					SetScrollPos(Handle, SB_VERT, 0, FALSE);

}
//---------------------------------------------------------------------------

void __fastcall TForm1::PopupFileClick(TObject *Sender)
{
	// Check if saving is available (if an image has been captured at least once, it is possible).
	if(m_SaveFlg){
		FileSave->Enabled = true;
	} else {
		FileSave->Enabled = false;
	}

	// Check is the camera is Directshow compatible
	// Only Directshow camera has recording function
	if(1300 <= LOWORD(m_CArtCamSdk.GetDllVersion()) || 
		ARTCAM_CAMERATYPE_DS == m_CurrentCameraType){
		FileRec->Enabled = true;
	} else {
		FileRec->Enabled = false;
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::PopupShowClick(TObject *Sender)
{
	// Disable playback if device is not connected
	if(-1 == m_SelectDevice){
		ShowPreview->Enabled = false;
		ShowCallBack->Enabled = false;
		ShowSnapShot->Enabled = false;
		ShowCapture->Enabled = false;
		ShowTrigger->Enabled = false;
	} else {
		ShowPreview->Enabled = true;
		ShowCallBack->Enabled = true;
		ShowSnapShot->Enabled = true;
		ShowCapture->Enabled = true;

		// Remark: Trigger mode is not available in every model.
		switch(m_CurrentCameraType){
		case ARTCAM_CAMERATYPE_DS:		// DS
		case ARTCAM_CAMERATYPE_USTC:	// UST
		case ARTCAM_CAMERATYPE_CNV:		// CNV
		case ARTCAM_CAMERATYPE_200SH:	// 200SH
		case ARTCAM_CAMERATYPE_098:		// 098
		case ARTCAM_CAMERATYPE_500P:	// 500P
			ShowTrigger->Enabled = false;
		break;

		default:
			ShowTrigger->Enabled = true;
		break;
		}
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::PopupSetClick(TObject *Sender)
{
	// Directshow is not available in every model.
	// Note that "SetAnalogDlg" is not available in many models.
	SetCamera->Enabled = true;
	SetFilter->Enabled = true;

	switch(m_CurrentCameraType){
//	case ARTCAM_CAMERATYPE_DS:		// DS
	case ARTCAM_CAMERATYPE_USTC:    // UST
	case ARTCAM_CAMERATYPE_CNV:		// CNV
		SetAnalog->Enabled = false;
		SetCorrection->Enabled	= false;
	break;

	case ARTCAM_CAMERATYPE_008TNIR:
	case ARTCAM_CAMERATYPE_031TNIR:
	case ARTCAM_CAMERATYPE_0016TNIR:
		SetAnalog->Enabled		= false;
		SetCorrection->Enabled	= true;
	break;

	default:
		SetAnalog->Enabled = true;
		SetCorrection->Enabled	= false;
	break;
	}

}
//---------------------------------------------------------------------------



void __fastcall TForm1::SetUserMonitorClick(TObject *Sender)
{
	if(m_CArtCamSdk.IsInit()){
		switch(m_CurrentCameraType){
			case ARTCAM_CAMERATYPE_130MI_MOUT:
			case ARTCAM_CAMERATYPE_150P3_MOUT:
		Form5->m_pCArtCamSdk = &m_CArtCamSdk;
		Form5->Show();
			break;
			case ARTCAM_CAMERATYPE_1000MI_HD2:
				Form7->m_pCArtCamSdk = &m_CArtCamSdk;
				Form7->m_DllType = m_CurrentCameraType;
				Form7->Show();
			break;
		}
    }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ReloadClick(TObject *Sender)
{
	OnDllReload();	
}
//---------------------------------------------------------------------------


void __fastcall TForm1::SetCorrectionClick(TObject *Sender)
{
	if(m_CArtCamSdk.IsInit()){
		Form6->m_pCArtCamSdk = &m_CArtCamSdk;
		Form6->Show();
	}
}
//---------------------------------------------------------------------------


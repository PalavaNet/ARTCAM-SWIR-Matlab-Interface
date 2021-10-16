//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"

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
		, m_SataType(-1)
		, m_PreviewMode(1)
		, m_BmpDraw(NULL)
		, m_Hook(NULL)
{
	Timer1->Enabled = false;
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
	m_CArtCamSdk.SaveImage("Temp.jpg", FILETYPE_JPEG_NOMAL);
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

	Invalidate();
	m_PreviewMode = 0;
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
	m_CArtCamSdk.CallBackPreview(Handle, (LPBYTE)m_BmpDraw->ScanLine[m_BmpDraw->Height-1], ArtCamGetSize(), 0);

	// Check menu
	ShowPreview->Checked  = false;
	ShowCallBack->Checked = true;
	ShowCapture->Checked  = false;
	ShowTrigger->Checked  = false;

	Invalidate();
	m_PreviewMode = 1;
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
	m_CArtCamSdk.SnapShot((LPBYTE)m_BmpDraw->ScanLine[m_BmpDraw->Height-1], ArtCamGetSize(), 0);

	// Draw image
	DrawImage();

	// Check menu
	ShowPreview->Checked  = false;
	ShowCallBack->Checked = false;
	ShowCapture->Checked  = false;
	ShowTrigger->Checked  = false;

//	Invalidate();
	m_PreviewMode = -1;
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

	Invalidate();
	m_PreviewMode = 3;

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
	m_CArtCamSdk.Trigger(Handle, (LPBYTE)m_BmpDraw->ScanLine[m_BmpDraw->Height-1], ArtCamGetSize(), 0);

	// Check menu
	ShowPreview->Checked  = false;
	ShowCallBack->Checked = false;
	ShowCapture->Checked  = false;
	ShowTrigger->Checked  = true;

	Invalidate();
	m_PreviewMode = 4;
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

	// A device will be changed, if a camera is displayed after changing the number of a device now
	// Notes: A device is not changed in this function simple substance
	//   After calling this function, a device is changed by initializing a device
	m_CArtCamSdk.SetDeviceNumber(Number);

	for(int i=0; i<10; i++){
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
void __fastcall TForm1::Device0Click(TObject *Sender) { OnDeviceChange(Sender,  0); }
void __fastcall TForm1::Device1Click(TObject *Sender) { OnDeviceChange(Sender,  1); }
void __fastcall TForm1::Device2Click(TObject *Sender) { OnDeviceChange(Sender,  2); }
void __fastcall TForm1::Device3Click(TObject *Sender) { OnDeviceChange(Sender,  3); }
void __fastcall TForm1::Device4Click(TObject *Sender) { OnDeviceChange(Sender,  4); }
void __fastcall TForm1::Device5Click(TObject *Sender) { OnDeviceChange(Sender,  5); }
void __fastcall TForm1::Device6Click(TObject *Sender) { OnDeviceChange(Sender,  6); }
void __fastcall TForm1::Device7Click(TObject *Sender) { OnDeviceChange(Sender,  7); }
void __fastcall TForm1::Device8Click(TObject *Sender) { OnDeviceChange(Sender,  8); }
void __fastcall TForm1::Device9Click(TObject *Sender) { OnDeviceChange(Sender,  9); }
//---------------------------------------------------------------------------
void TForm1::OnDllChange(TObject *Sender, LONG Number, LONG CameraType)
{
	// Release all devices before switching DLL
	// To display multiple images simulteously, you need to define CArtCamSdk plurally
	// When defined plurally, you do not need to relase to switch cameras
	m_CArtCamSdk.Release();
	m_CArtCamSdk.FreeLibrary();

	m_DllType = Number;
 	m_SataType = CameraType;

	TCHAR szDllName[MAX_PATH]="";
	int i;
	AnsiString str = (*PopupDll)[Number+1]->Caption;
	AnsiString str2 = str.SubString(1, str.AnsiPos('\t')-1);
	str2 += ".dll";
	strcpy(szDllName, str2.c_str());
	BOOL res = m_CArtCamSdk.LoadLibrary(szDllName);
	if(!res){
		ShowMessage("DLL is not found. \nDLL may have been relocated after executing");
		return;
	}

	// Initialize is to be called first
	// By setting Window Handle here, WMLERROR can be obtained
	if(!m_CArtCamSdk.Initialize(Handle)){
		ShowMessage("Failed to initialize SDK");
		return;
	}

	// 
	if(-1 != CameraType && ARTCAM_CAMERATYPE_SATA == HIWORD(m_CArtCamSdk.GetDllVersion())){
		m_CArtCamSdk.SetCameraType(CameraType);
	}

	// Check menu
	for(i=0; i<m_DllCount; i++){
		(*PopupDll)[i+1]->Checked = false;
	}
	(*PopupDll)[Number+1]->Checked = true;

	if(-1 != CameraType && ARTCAM_CAMERATYPE_SATA == HIWORD(m_CArtCamSdk.GetDllVersion())){
		for(int type=0; type<ARTCAM_CAMERATYPE_SATA_200MI-ARTCAM_CAMERATYPE_SATA_LVDS+1; type++){
			(*PopupDll)[m_DllSata+1]->Items[type]->Checked = false;
		}
		(*PopupDll)[m_DllSata+1]->Items[m_SataType]->Checked = true;
	}

	TCHAR szName[10][256];
	LONG DeviceCount = m_CArtCamSdk.EnumDevice(szName);
	for(i=0; i<DeviceCount; i++){
		(*PopupDevice)[i]->Caption = szName[i];
		(*PopupDevice)[i]->Enabled = true;
	}
	for(; i<10; i++){
		(*PopupDevice)[i]->Caption = IntToStr(i);
		(*PopupDevice)[i]->Enabled = false;
		(*PopupDevice)[i]->Checked = false;
	}

	(*PopupDevice)[0]->Checked = true;



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
		MainMenu1->Items->Items[4]->Delete(1);
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
void TForm1::DrawImage(void)
{
	// Draw image
	Canvas->Draw(0, 0, m_BmpDraw);
}
//---------------------------------------------------------------------------
void TForm1::CreateBitmap(void)
{
	// Release area for image
	if(m_BmpDraw){
		delete m_BmpDraw;
		m_BmpDraw = NULL;
	}

	// Creat area for display
	m_BmpDraw = new Graphics::TBitmap;
	m_BmpDraw->Width = ArtCamGetWidth();
	m_BmpDraw->Height = ArtCamGetHeight();
	m_BmpDraw->Canvas->Pen->Color = clRed;

	// Generate palette when 8 bit monochrome image
	if(1 == ArtCamGetBpp()){
		m_BmpDraw->PixelFormat = pf8bit;
		TMaxLogPalette pal;
		for(int i=0; i<256; i++){
			pal.palPalEntry[i].peRed   = i;
			pal.palPalEntry[i].peGreen = i;
			pal.palPalEntry[i].peBlue  = i;
			pal.palPalEntry[i].peFlags = 0;
		}
		pal.palNumEntries = 256;
		pal.palVersion = 0x0300;
		m_BmpDraw->Palette = CreatePalette(PLogPalette(&pal));
	}
	// 24 bit color
	else if(3 == ArtCamGetBpp()){
		m_BmpDraw->PixelFormat = pf24bit;
	}

	// To use other color number, 
	// please refer to
	// Sample_BCB6_Graphic&Allbpp
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Timer1Timer(TObject *Sender)
{
	m_CArtCamSdk.SnapShot((LPBYTE)m_BmpDraw->ScanLine[m_BmpDraw->Height-1], ArtCamGetSize(), 0);

	// Draw image
	DrawImage();
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
}
//---------------------------------------------------------------------------


void __fastcall TForm1::ReloadClick(TObject *Sender)
{
	OnDllReload();	
}
//---------------------------------------------------------------------------


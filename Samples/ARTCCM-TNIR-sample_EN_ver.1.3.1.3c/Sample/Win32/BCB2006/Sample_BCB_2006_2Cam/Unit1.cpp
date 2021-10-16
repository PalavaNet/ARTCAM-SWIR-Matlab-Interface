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
			default:                        Form1->Caption = "Unknow error";	break;
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
		, m_Hook(NULL)
{
    m_BmpDraw[0] = NULL;
    m_BmpDraw[1] = NULL;
	Timer1->Enabled = false;
	m_SetDeviceFlg[0] = false;
	m_SetDeviceFlg[1] = false;
	
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
	m_CArtCamSdk[0].SaveImage("Temp1.jpg", FILETYPE_JPEG_NOMAL);
	m_CArtCamSdk[1].SaveImage("Temp2.jpg", FILETYPE_JPEG_NOMAL);
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
	if(m_SetDeviceFlg[0] == false){	return;	}
	if(m_SetDeviceFlg[1] == false){	return;	}

	// Delete timer
	if(3 == m_PreviewMode){
		Timer1->Enabled = false;
	}

	// Release device
	m_CArtCamSdk[0].Close();
	m_CArtCamSdk[1].Close();

	// Set window to be displayed
	// New window is created when NULL is set in Handle.
	TRect rc = GetClientRect();
	m_CArtCamSdk[0].SetPreviewWindow(Handle, 0, 0, rc.right/2, rc.bottom);
	m_CArtCamSdk[1].SetPreviewWindow(Handle, rc.right/2, 0, rc.right, rc.bottom);

	// Display image
	// Display is controlled by SDK. Image information cannot be obtained.
	m_CArtCamSdk[0].Preview();
	m_CArtCamSdk[1].Preview();

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

	if(m_SetDeviceFlg[0] == false){	return;	}
	if(m_SetDeviceFlg[1] == false){	return;	}

	// Delete timer
	if(3 == m_PreviewMode){
		Timer1->Enabled = false;
	}

	// Release device
	m_CArtCamSdk[0].Close();
	m_CArtCamSdk[1].Close();

	// If drawing by yourself, set all window size to 0.
	// An automatic display can be performed, if window size is set up even when using CallBackPreview
	m_CArtCamSdk[0].SetPreviewWindow(Handle, 0, 0, 0, 0);
	m_CArtCamSdk[1].SetPreviewWindow(Handle, 0, 0, 0, 0);

	// Creat area for capturing
	CreateBitmap();

	// Capture image
	m_CArtCamSdk[0].CallBackPreview(Handle, (LPBYTE)m_BmpDraw[0]->ScanLine[m_BmpDraw[0]->Height-1], ArtCamGetSize(0), 0);
	m_CArtCamSdk[1].CallBackPreview(Handle, (LPBYTE)m_BmpDraw[1]->ScanLine[m_BmpDraw[1]->Height-1], ArtCamGetSize(1), 0);

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

	if(m_SetDeviceFlg[0] == false){	return;	}
	if(m_SetDeviceFlg[1] == false){	return;	}
	// Delete timer
	if(3 == m_PreviewMode){
		Timer1->Enabled = false;
	}

	// Release device
	m_CArtCamSdk[0].Close();
	m_CArtCamSdk[1].Close();

	// Creat area for capturing
	CreateBitmap();

	// Capture image
	m_CArtCamSdk[0].SnapShot((LPBYTE)m_BmpDraw[0]->ScanLine[m_BmpDraw[0]->Height-1], ArtCamGetSize(0), 0);
	m_CArtCamSdk[1].SnapShot((LPBYTE)m_BmpDraw[1]->ScanLine[m_BmpDraw[1]->Height-1], ArtCamGetSize(1), 0);

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

	if(m_SetDeviceFlg[0] == false){	return;	}
	if(m_SetDeviceFlg[1] == false){	return;	}

	// Release device
	m_CArtCamSdk[0].Close();
	m_CArtCamSdk[1].Close();

	// Set window to be displayed
	// New window is created when NULL is set in Handle.
	m_CArtCamSdk[0].SetPreviewWindow(Handle, 0, 0, 0, 0);
	m_CArtCamSdk[1].SetPreviewWindow(Handle, 0, 0, 0, 0);

	// Creat area for capturing
	CreateBitmap();

	// Display image
	m_CArtCamSdk[0].Capture();
	m_CArtCamSdk[1].Capture();

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

	if(m_SetDeviceFlg[0] == false){	return;	}
	if(m_SetDeviceFlg[1] == false){	return;	}

	// Delete timer
	if(3 == m_PreviewMode){
		Timer1->Enabled = false;
	}

	// Release device
	m_CArtCamSdk[0].Close();
	m_CArtCamSdk[1].Close();

	// If drawing by yourself, set all window size to 0.
	// An automatic display can be performed, if window size is set up even when using CallBackPreview
	m_CArtCamSdk[0].SetPreviewWindow(Handle, 0, 0, 0, 0);
	m_CArtCamSdk[1].SetPreviewWindow(Handle, 0, 0, 0, 0);

	// Creat area for capturing
	CreateBitmap();

	// Capture image
	m_CArtCamSdk[0].Trigger(Handle, (LPBYTE)m_BmpDraw[0]->ScanLine[m_BmpDraw[0]->Height-1], ArtCamGetSize(0), 0);
	m_CArtCamSdk[1].Trigger(Handle, (LPBYTE)m_BmpDraw[1]->ScanLine[m_BmpDraw[1]->Height-1], ArtCamGetSize(1), 0);

	// Check menu
	ShowPreview->Checked  = false;
	ShowCallBack->Checked = false;
	ShowCapture->Checked  = false;
	ShowTrigger->Checked  = true;

	Invalidate();
	m_PreviewMode = 4;
}
//---------------------------------------------------------------------------
void __fastcall TForm1::SetCameraClick1(TObject *Sender)
{
	m_CArtCamSdk[0].SetCameraDlg(Handle);

	Invalidate();
	switch(m_PreviewMode){
	case 0:	PreviewClick(Sender); break;
	case 1:	CallBackClick(Sender); break;
	case 3:	CaptureClick(Sender); break;
	case 4:	TriggerClick(Sender); break;
	}
}
//---------------------------------------------------------------------------
void __fastcall TForm1::SetCameraClick2(TObject *Sender)
{
	m_CArtCamSdk[1].SetCameraDlg(Handle);

	Invalidate();
	switch(m_PreviewMode){
	case 0:	PreviewClick(Sender); break;
	case 1:	CallBackClick(Sender); break;
	case 3:	CaptureClick(Sender); break;
	case 4:	TriggerClick(Sender); break;
	}
}
//---------------------------------------------------------------------------
void __fastcall TForm1::SetFilterClick1(TObject *Sender)
{
	m_CArtCamSdk[0].SetImageDlg(Handle);
}//---------------------------------------------------------------------------
void __fastcall TForm1::SetFilterClick2(TObject *Sender)
{
	m_CArtCamSdk[1].SetImageDlg(Handle);
}
//---------------------------------------------------------------------------
void __fastcall TForm1::SetAnalogClick1(TObject *Sender)
{
	m_CArtCamSdk[0].SetAnalogDlg(Handle);
}//---------------------------------------------------------------------------
void __fastcall TForm1::SetAnalogClick2(TObject *Sender)
{
	m_CArtCamSdk[1].SetAnalogDlg(Handle);
}
//---------------------------------------------------------------------------
void TForm1::OnDllChange(TObject *Sender, LONG Number, LONG CameraType)
{
	// Release all devices before switching DLL
	// To display multiple images simulteously, you need to define CArtCamSdk plurally
	// When defined plurally, you do not need to relase to switch cameras
	m_CArtCamSdk[0].Release();
	m_CArtCamSdk[1].Release();
	m_CArtCamSdk[0].FreeLibrary();
	m_CArtCamSdk[1].FreeLibrary();

	m_DllType = Number;
 	m_SataType = CameraType;

	TCHAR szDllName[MAX_PATH]="";
	int i;
	AnsiString str = (*PopupDll)[Number+1]->Caption;
	AnsiString str2 = str.SubString(1, str.AnsiPos('\t')-1);
	str2 += ".dll";
	strcpy(szDllName, str2.c_str());
	if(!m_CArtCamSdk[0].LoadLibrary(szDllName)){
		ShowMessage("DLL is not found. \nDLL may have been relocated after executing");
		return;
	}
	if(!m_CArtCamSdk[1].LoadLibrary(szDllName)){
		ShowMessage("DLL is not found. \nDLL may have been relocated after executing");
		return;
	}

	// Check selected DLL
	for(i=0; i<m_DllCount; i++){
		(*PopupDll)[i+1]->Checked = false;
	}
	(*PopupDll)[Number+1]->Checked = true;

	// Initialize is to be called firstCall "Initialize" first
	// By setting Window Handle here, WMLERROR can be obtainedBy setting "Window handle" here, "WM_ERROR" can be obtained
	if(!m_CArtCamSdk[0].Initialize(Handle)){
		ShowMessage("Failed to initialize SDK");
		return;
	}
	if(!m_CArtCamSdk[1].Initialize(Handle)){
		ShowMessage("Failed to initialize SDK");
		return;
	}

	//Sata cameras are not supported for multiple capturing
/*
	if(-1 != CameraType && ARTCAM_CAMERATYPE_SATA == HIWORD(m_CArtCamSdk[0].GetDllVersion())){
		m_CArtCamSdk[0].SetCameraType(CameraType);
	}
	if(-1 != CameraType && ARTCAM_CAMERATYPE_SATA == HIWORD(m_CArtCamSdk[1].GetDllVersion())){
		m_CArtCamSdk[1].SetCameraType(CameraType);
	}
*/

	if(0 == m_CArtCamSdk[0].SetDeviceNumber(0)){
		m_CArtCamSdk[0].Release();
		m_SetDeviceFlg[0] = false;
	}else{
		m_SetDeviceFlg[0] = true;
	}
	if(0 == m_CArtCamSdk[1].SetDeviceNumber(1)){
		m_CArtCamSdk[1].Release();
		m_SetDeviceFlg[1] = false;
	}else{
		m_SetDeviceFlg[1] = true;
	}

	// To operate 2 cameras simultenously, set camera clock to half.
	m_CArtCamSdk[0].SetHalfClock(TRUE);
	m_CArtCamSdk[1].SetHalfClock(TRUE);


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

					// Check menu
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
	Image1->Canvas->Draw(0, 0, m_BmpDraw[0]);
 	Image2->Canvas->Draw(0, 0, m_BmpDraw[1]);
}
//---------------------------------------------------------------------------
void TForm1::CreateBitmap(void)
{
	// Release area for image
	if(m_BmpDraw[0])	delete m_BmpDraw[0];
	if(m_BmpDraw[1])	delete m_BmpDraw[1];
	m_BmpDraw[0] = NULL;
	m_BmpDraw[1] = NULL;


	// Creat area for display
	for(int i=0; i<2; i++){
		m_BmpDraw[i] = new Graphics::TBitmap;
		m_BmpDraw[i]->Width  = ArtCamGetWidth (i);
		m_BmpDraw[i]->Height = ArtCamGetHeight(i);
		m_BmpDraw[i]->Canvas->Pen->Color = clRed;

		// Generate palette when 8 bit monochrome image
		if(1 == ArtCamGetBpp(i)){
			m_BmpDraw[i]->PixelFormat = pf8bit;
			TMaxLogPalette pal;
			for(int i=0; i<256; i++){
				pal.palPalEntry[i].peRed   = i;
				pal.palPalEntry[i].peGreen = i;
				pal.palPalEntry[i].peBlue  = i;
				pal.palPalEntry[i].peFlags = 0;
			}
			pal.palNumEntries = 256;
			pal.palVersion = 0x0300;
			m_BmpDraw[i]->Palette = CreatePalette(PLogPalette(&pal));
		}
		// 24 bit color
		else if(3 == ArtCamGetBpp(i)){
			m_BmpDraw[i]->PixelFormat = pf24bit;
		}
	}

	// To use other color number,
	// Sample_BCB6_Graphic&Allbpp
	// please refer to **

}
//---------------------------------------------------------------------------

void __fastcall TForm1::Timer1Timer(TObject *Sender)
{
	m_CArtCamSdk[0].SnapShot((LPBYTE)m_BmpDraw[0]->ScanLine[m_BmpDraw[0]->Height-1], ArtCamGetSize(0), 0);
	m_CArtCamSdk[1].SnapShot((LPBYTE)m_BmpDraw[1]->ScanLine[m_BmpDraw[1]->Height-1], ArtCamGetSize(1), 0);

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
		HWND Child1 = GetWindow(Handle, GW_CHILD);
		HWND Child2 = GetWindow(Child1, GW_HWNDNEXT);
		RECT rc = GetClientRect();

		SetWindowPos(Child1, HWND_TOP, 0, 0, rc.right / 2, rc.bottom, SWP_NOMOVE | SWP_NOZORDER | SWP_SHOWWINDOW);
		SetWindowPos(Child2, HWND_TOP, rc.right / 2, 0, rc.right / 2, rc.bottom, SWP_NOZORDER | SWP_SHOWWINDOW);
	}
}
//---------------------------------------------------------------------------


void __fastcall TForm1::ReloadClick(TObject *Sender)
{
	OnDllReload();	
}
//---------------------------------------------------------------------------


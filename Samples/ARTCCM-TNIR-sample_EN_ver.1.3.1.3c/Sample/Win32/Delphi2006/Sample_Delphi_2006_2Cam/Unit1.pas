unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons, Menus, ArtCam, AppEvnts, ExtCtrls;

type
  TForm1 = class(TForm)
    MainMenu1: TMainMenu;
    PopupFile: TMenuItem;
    FileSave: TMenuItem;
    FileExit: TMenuItem;
    PopupShow: TMenuItem;
    ShowPreview: TMenuItem;
    ShowCallBack: TMenuItem;
    ShowSnapShot: TMenuItem;
    ShowCapture: TMenuItem;
    ShowTrigger: TMenuItem;
    PopupSet: TMenuItem;
    SetCamera1: TMenuItem;
    SetCamera2: TMenuItem;
    SetFilter1: TMenuItem;
    SetFilter2: TMenuItem;
    SetAnalog1: TMenuItem;
    SetAnalog2: TMenuItem;
    PopupDll: TMenuItem;
    Timer1: TTimer;
    Reload: TMenuItem;
    Image1: TImage;
    Image2: TImage;

    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure SaveClick(Sender: TObject);
    procedure ExitClick(Sender: TObject);
    procedure PreviewClick(Sender: TObject);
    procedure CallBackClick(Sender: TObject);
    procedure SnapShotClick(Sender: TObject);
    procedure CaptureClick(Sender: TObject);
    procedure TriggerClick(Sender: TObject);
    procedure SetCameraClick1(Sender: TObject);
    procedure SetCameraClick2(Sender: TObject);
    procedure SetFilterClick1(Sender: TObject);
    procedure SetFilterClick2(Sender: TObject);
    procedure SetAnalogClick1(Sender: TObject);
    procedure SetAnalogClick2(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure FormResize(Sender: TObject);
    procedure ReloadClick(Sender: TObject);
    procedure OnDllClick(Sender: TObject);
  private
    { Private declaration }
  public
    procedure CreateBitmap;
    procedure DrawImage;
    procedure DllChange(Sender: TObject; Number: Integer; CameraType: Integer);
    procedure DllReload;
    function ArtCamGetWidth: Integer;
    function ArtCamGetHeight: Integer;
    function ArtCamGetColor: Integer;
    function ArtCamGetBpp: Integer;
    function ArtCamGetSize: Integer;
  end;

  function MsgProc(code: integer; wparam: WPARAM; lparam: LPARAM): LRESULT; stdcall;

var
  Form1: TForm1;
  BmpDraw: array[0..1] of TBitmap;
  ArtCam1: array[0..1] of TArtCam;
  Hook: HHOOK;
  PreviewMode: Integer;
  SetDeviceFlg: array[0..1] of Boolean;
  DllType: Integer;
  DllSata: Integer;
  DllCount: Integer;
  SataType: Integer;

const
  SUB_SAMPLE: array[0..3] of Integer = (1, 2, 4, 8);

implementation

{$R *.dfm}


//////////////////////////////////////////////////
// Receive capture message
//////////////////////////////////////////////////
function MsgProc(code: integer; wparam: WPARAM; lparam: LPARAM): LRESULT; stdcall;
var
  Msg: PMsg;
begin
  if code < 0 then begin
    result := CallNextHookEx(Hook, code, wparam, lparam);
    exit;
  end;

  if code = HC_ACTION then begin
    Msg := PMsg(lparam);

    case Msg.message of
      // Display code. Sent from SDK when the new image is captured
      UINT(WM_GRAPHPAINT): begin
        Form1.DrawImage;
      end;

      // Error Code
      UINT(WM_ERROR): begin
        case ARTCAMSDK_ERROR(Msg.lParam) of
          ARTCAMSDK_NOERROR:        Form1.Caption := 'Sample';
          ARTCAMSDK_NOT_INITIALIZE:		Form1.Caption := 'Sample Not initialized';
          ARTCAMSDK_DISABLEDDEVICE:		Form1.Caption := 'Sample Access to unavailable device was attempted';
          ARTCAMSDK_CREATETHREAD:		Form1.Caption := 'Sample Failure of thread creation for capturing';
          ARTCAMSDK_CREATEWINDOW:		Form1.Caption := 'Sample Window creation failed';
          ARTCAMSDK_OUTOFMEMORY:		Form1.Caption := 'Sample Not enough memory for image transfer/Failure for securing memory';
          ARTCAMSDK_CAMERASET:			Form1.Caption := 'Sample Error for camera (device) settings';
          ARTCAMSDK_CAMERASIZE:			Form1.Caption := 'Sample Error for camera (device) size settings';
          ARTCAMSDK_CAPTURE:			Form1.Caption := 'Sample Capturing failed';
          ARTCAMSDK_PARAM:				Form1.Caption := 'Sample Wrong argument';
          ARTCAMSDK_DIRECTSHOW:			Form1.Caption := 'Sample Directshow initialization error';
          ARTCAMSDK_UNSUPPORTED:		Form1.Caption := 'Sample Not supported';
          ARTCAMSDK_UNKNOWN:			Form1.Caption := 'Sample Unknow error';
          ARTCAMSDK_CAPTURELOST:		Form1.Caption := 'Sample Device lost';
          ARTCAMSDK_FILENOTFOUND:		Form1.Caption := 'Sample File not found';
          ARTCAMSDK_FPGASET:			Form1.Caption := 'Sample FPGA settings error';
          ARTCAMSDK_TRANSIMAGEFAILED:	Form1.Caption := 'Sample Failure of image transferring';
        end;
      end;
    end;
  end;

  result := CallNextHookEx(Hook, code, wparam, lparam);
end;


//////////////////////////////////////////////////
// Initialization of camera
//////////////////////////////////////////////////
procedure TForm1.FormCreate(Sender: TObject);
begin
  Timer1.Enabled := false;
  DllType := -1;
  DllSata := -1;
  DllCount:= 0;
  SataType:= -1;

  // Build class
  ArtCam1[0] := TArtCam.Create;
  ArtCam1[1] := TArtCam.Create;


  DllReload();

  // Receive DLL message by hook
  Hook := SetWindowsHookEx(WH_GETMESSAGE, MsgProc, 0, GetCurrentThreadID);
end;


//////////////////////////////////////////////////
// Release camera
//////////////////////////////////////////////////
procedure TForm1.FormDestroy(Sender: TObject);
begin
  ArtCam1[0].Release();
  ArtCam1[1].Release();

  UnHookWindowsHookEx(Hook);
end;


//////////////////////////////////////////////////
// Save image
//////////////////////////////////////////////////
procedure TForm1.SaveClick(Sender: TObject);
begin
  if not ArtCam1[0].IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  ArtCam1[0].SaveImage('Image1.png', FILETYPE_PNG);
  ArtCam1[1].SaveImage('Image2.png', FILETYPE_PNG);
end;


//////////////////////////////////////////////////
// End
//////////////////////////////////////////////////
procedure TForm1.ExitClick(Sender: TObject);
begin
  CLose;
end;


//////////////////////////////////////////////////
// Preview
//////////////////////////////////////////////////
procedure TForm1.PreviewClick(Sender: TObject);
var
  rc:  TRect;
begin
  if not ArtCam1[0].IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  Timer1.Enabled := false;

  if SetDeviceFlg[0] = false then begin exit; end;
  if SetDeviceFlg[1] = false then begin exit; end;


  rc := GetClientRect();

  // Release device
  ArtCam1[0].Close;
  ArtCam1[1].Close;

  // Set window to be displayed
  // When setting NULL to Handle,it is possible to create new window and show it.
  ArtCam1[0].SetPreviewWindow(Form1.Handle, 0, 0, rc.Right div 2, rc.Bottom);
  ArtCam1[1].SetPreviewWindow(Form1.Handle, rc.Right div 2, 0, rc.Right, rc.Bottom);

  // Display image
  // Display is controlled by SDK. Image information cannot be obtained.
  ArtCam1[0].Preview;
  ArtCam1[1].Preview;

  // Check menu
  ShowPreview.Checked := true;
  ShowCallBack.Checked := false;
  ShowCapture.Checked := false;
  ShowTrigger.Checked := false;

  Image1.Hide;
  Image2.Hide;

  PreviewMode := 0;
  Invalidate;
end;


//////////////////////////////////////////////////
// Callback
//////////////////////////////////////////////////
procedure TForm1.CallBackClick(Sender: TObject);
begin
  if not ArtCam1[0].IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  Timer1.Enabled := false;

  if SetDeviceFlg[0] = false then begin exit; end;
  if SetDeviceFlg[1] = false then begin exit; end;

  // Release device
  ArtCam1[0].Close;
  ArtCam1[1].Close;

  // If drawing by yourself, set all window size to 0.
  // An automatic display can be performed, if window size is set up even when using CallBackPreview
  ArtCam1[0].SetPreviewWindow(Form1.Handle, 0, 0, 0, 0);
  ArtCam1[1].SetPreviewWindow(Form1.Handle, 0, 0, 0, 0);

  // Creat area for capturing
  CreateBitmap;

  // Capture image
  ArtCam1[0].CallBackPreview(Form1.Handle, BmpDraw[0].ScanLine[BmpDraw[0].Height-1], ArtCamGetSize, FALSE);
  ArtCam1[1].CallBackPreview(Form1.Handle, BmpDraw[1].ScanLine[BmpDraw[1].Height-1], ArtCamGetSize, FALSE);

  // Check menu
  ShowPreview.Checked := false;
  ShowCallBack.Checked := true;
  ShowCapture.Checked := false;
  ShowTrigger.Checked := false;

  Image1.Show;
  Image2.Show;

  PreviewMode := 1;

  Invalidate;
end;


//////////////////////////////////////////////////
// Snapshot
//////////////////////////////////////////////////
procedure TForm1.SnapShotClick(Sender: TObject);
begin
  if not ArtCam1[0].IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  Timer1.Enabled := false;

  if SetDeviceFlg[0] = false then begin exit; end;
  if SetDeviceFlg[1] = false then begin exit; end;

  // Release device
  ArtCam1[0].Close;
  ArtCam1[1].Close;

  // Creat area for capturing
  CreateBitmap;

  // Capture image
  ArtCam1[0].SnapShot(BmpDraw[0].ScanLine[BmpDraw[0].Height-1], ArtCamGetSize, FALSE);
  ArtCam1[1].SnapShot(BmpDraw[1].ScanLine[BmpDraw[1].Height-1], ArtCamGetSize, FALSE);

  // Draw image
  DrawImage;

  // Check menu
  ShowPreview.Checked := false;
  ShowCallBack.Checked := false;
  ShowCapture.Checked := false;
  ShowTrigger.Checked := false;

  Image1.Show;
  Image2.Show;

  PreviewMode := -1;
end;


//////////////////////////////////////////////////
// Capture
//////////////////////////////////////////////////
procedure TForm1.CaptureClick(Sender: TObject);
begin
  if not ArtCam1[0].IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  Timer1.Enabled := false;

  if SetDeviceFlg[0] = false then begin exit; end;
  if SetDeviceFlg[1] = false then begin exit; end;

  // Release device
  ArtCam1[0].Close;
  ArtCam1[1].Close;

  // Creat area for capturing
  CreateBitmap;

  // Display image
  ArtCam1[0].Capture;
  ArtCam1[1].Capture;

  Timer1.Interval := 200;
  Timer1.Enabled := true;

  // Check menu
  ShowPreview.Checked := false;
  ShowCallBack.Checked := false;
  ShowCapture.Checked := true;
  ShowTrigger.Checked := false;

  Image1.Show;
  Image2.Show;

  PreviewMode := 3;

  Invalidate;
end;


//////////////////////////////////////////////////
// Trigger
//////////////////////////////////////////////////
procedure TForm1.TriggerClick(Sender: TObject);
begin
  if not ArtCam1[0].IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  Timer1.Enabled := false;

  if SetDeviceFlg[0] = false then begin exit; end;
  if SetDeviceFlg[1] = false then begin exit; end;

  // Release device
  ArtCam1[0].Close;
  ArtCam1[1].Close;

  // If drawing by yourself, set all window size to 0.
  // An automatic display can be performed, if window size is set up even when using CallBackPreview
  ArtCam1[0].SetPreviewWindow(Form1.Handle, 0, 0, 0, 0);
  ArtCam1[1].SetPreviewWindow(Form1.Handle, 0, 0, 0, 0);

  // Creat area for capturing
  CreateBitmap;

  // Capture image
  ArtCam1[0].Trigger(Form1.Handle, BmpDraw[0].ScanLine[BmpDraw[0].Height-1], ArtCamGetSize, FALSE);
  ArtCam1[1].Trigger(Form1.Handle, BmpDraw[1].ScanLine[BmpDraw[1].Height-1], ArtCamGetSize, FALSE);

  // Check menu
  ShowPreview.Checked := false;
  ShowCallBack.Checked := false;
  ShowCapture.Checked := false;
  ShowTrigger.Checked := true;

  Image1.Show;
  Image2.Show;

  PreviewMode := 4;

  Invalidate;
end;


//////////////////////////////////////////////////
// Camera settings
//////////////////////////////////////////////////
procedure TForm1.SetCameraClick1(Sender: TObject);
begin
  if not ArtCam1[0].IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  ArtCam1[0].SetCameraDlg(Form1.Handle);

  Invalidate;

  case PreviewMode of
  0: PreviewClick(Sender);
  1: CallBackClick(Sender);
  3: CaptureClick(Sender);
  4: TriggerClick(Sender);
  end;
end;

procedure TForm1.SetCameraClick2(Sender: TObject);
begin
  if not ArtCam1[1].IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  ArtCam1[1].SetCameraDlg(Form1.Handle);

  Invalidate;

  case PreviewMode of
  0: PreviewClick(Sender);
  1: CallBackClick(Sender);
  3: CaptureClick(Sender);
  4: TriggerClick(Sender);
  end;
end;


//////////////////////////////////////////////////
// Filter settings
//////////////////////////////////////////////////
procedure TForm1.SetFilterClick1(Sender: TObject);
begin
  if not ArtCam1[0].IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  ArtCam1[0].SetImageDlg(Form1.Handle);
end;

procedure TForm1.SetFilterClick2(Sender: TObject);
begin
  if not ArtCam1[1].IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  ArtCam1[1].SetImageDlg(Form1.Handle);
end;


//////////////////////////////////////////////////
// Analog settings
//////////////////////////////////////////////////
procedure TForm1.SetAnalogClick1(Sender: TObject);
begin
  if not ArtCam1[0].IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  ArtCam1[0].SetAnalogDlg(Form1.Handle);
end;

procedure TForm1.SetAnalogClick2(Sender: TObject);
begin
  if not ArtCam1[1].IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  ArtCam1[1].SetAnalogDlg(Form1.Handle);
end;


procedure TForm1.DllReload;
var
  i: Integer;
  strExePath: String;
  str: String;
  Rec: TSearchRec;
  ArtCam: TArtCam;
  CameraName:array[0..11]of String;
  MenuSata: TPopupMenu;
  temp: TMenuItem;
begin
	// Delete DLL list
	for i:=0 to DllCount-1 do begin
		MainMenu1.Items.Items[3].Delete(1);
  end;
	DllCount := 0;
	DllSata  := -1;

	// Search for DLL
  strExePath := ExtractFilePath(Application.Exename);
  if(FindFirst(strExePath + '\*.dll', faAnyFile, Rec) = 0) then  begin
    repeat
      if((Rec.Name <> '.')and(Rec.Name <> '..')) then begin
        if  (Rec.Attr <> faDirectory)  then  begin
          ArtCam := TArtCam.Create;
		  		if true = ArtCam.LoadLibrary(PChar(Rec.name)) then begin
			    	// Obtain version and show it
            str := Rec.Name + #09 + 'Version ' + IntToStr(LOWORD(ArtCam.GetDllVersion()));

					  // Add to menu
					  Inc(DllCount);

			  		// Select SATA camera type when use Sata.dll
				  	if (ARTCAM_CAMERATYPE_SATA = ARTCAM_CAMERATYPE(HIWORD(ArtCam.GetDllVersion()))) then begin
					  	MenuSata := TPopupMenu.Create(Self);
//					  MenuSata.AutoHotkeys := False;
			  			MenuSata.Items.Caption := str;
              CameraName[0] := 'LVDS';
              CameraName[1] := '300MI';
              CameraName[2] := '500MI';
              CameraName[3] := 'MV413';
              CameraName[4] := '800MI';
              CameraName[5] := '036MI';
              CameraName[6] := '150P3';
              CameraName[7] := '267KY';
              CameraName[8] := '274KY';
              CameraName[9] := '625KY';
              CameraName[10]:= '130MI';
              CameraName[11]:= '200MI';

  						for i:=0 to 11 do begin
	  						temp :=TMenuItem.Create(Self);
//    					temp->AutoHotkeys = false;
			  				temp.Caption := CameraName[i];
				  			temp.OnClick := OnDllClick;
					  		MenuSata.Items.Add(temp);
						  end;
				  		PopupDll.Add(MenuSata.Items);
				  		DllSata := DllCount-1;
             end
             else begin
  						temp :=TMenuItem.Create(Self);
//    				temp->AutoHotkeys = false;
		  				temp.Caption := str;
			  			temp.OnClick := OnDllClick;
				  		PopupDll.Add(temp);
              end;
            end;
          end;
        end;
    until (FindNext(Rec) <> 0);
    FindClose(Rec);
  end;
end;


procedure TForm1.OnDllClick(Sender: TObject);
var
  temp: TMenuItem;
  id: Integer;
  cam: Integer;
begin
	 temp := Sender as TMenuItem;
	 id := PopupDll.IndexOf(temp);
	 if id > -1 then begin
   		DllChange(Sender, id-1, -1);
	 end
   else begin
	  cam := PopupDll[DllSata+1].IndexOf(temp);
	  if (ARTCAM_CAMERATYPE_SATA_LVDS <= ARTCAM_CAMERATYPE_SATA1(cam)) and (ARTCAM_CAMERATYPE_SATA1(cam) <= ARTCAM_CAMERATYPE_SATA_200MI) then begin
  		DllChange(Sender, DllSata, cam);
	  end;
   end;
end;


//////////////////////////////////////////////////
// Change DLL
//////////////////////////////////////////////////
procedure TForm1.DllChange(Sender: TObject; Number: Integer; CameraType: Integer);

var
  i: Integer;
  Error: string;
  sl:TStringList;
begin
  // Release all devices before switching DLL
  // Need to define TArtCam plurally in case of displaying plural cameras at the same time
  // When defined plurally, you do not need to relase to switch cameras
  if ArtCam1[0].IsInit then begin
    ArtCam1[0].Release;
    Timer1.Enabled := false;
  end;

  if ArtCam1[1].IsInit then begin
    ArtCam1[1].Release;
  end;

  DllType := Number;
  SataType := CameraType;

  sl := TStringList.Create;
  sl.Delimiter := #9; // Tab
  sl.DelimitedText := PopupDll[Number+1].Caption;

  // Read DLL
  if not ArtCam1[0].LoadLibrary(PChar(sl.Strings[0])) then begin
    Error := 'DLL is not found.\nIt may have been relocated after executing.';
    ShowMessage(Error);
    sl.Free;
    exit;
  end;

  ArtCam1[1].LoadLibrary(PChar(sl.Strings[0]));
  sl.Free;

  ArtCam1[0].Initialize(Form1.Handle);
  ArtCam1[1].Initialize(Form1.Handle);

  if not ArtCam1[0].SetDeviceNumber(0) then
    begin
      ArtCam1[0].Release;
      SetDeviceFlg[0] := false;
    end else
    begin
      SetDeviceFlg[0] := true;
 	end;

  if not ArtCam1[1].SetDeviceNumber(1) then
  begin
    ArtCam1[1].Release;
    SetDeviceFlg[1] := false;
  end else
  begin
    SetDeviceFlg[1] := true;
  end;


  // To operate 2 cameras simultenously, set camera clock to half.
  ArtCam1[0].SetHalfClock(1);
  ArtCam1[1].SetHalfClock(1);


  // Check DLL
	for i := 0 to DllCount-1 do begin
		PopupDll[i+1].Checked := false;
  end;
	PopupDll[Number+1].Checked := true;



  case PreviewMode of
  0: PreviewClick(Sender);
  1: CallBackClick(Sender);
  3: CaptureClick(Sender);
  4: TriggerClick(Sender);
  end;

end;


//////////////////////////////////////////////////
// For capture
//////////////////////////////////////////////////
procedure TForm1.Timer1Timer(Sender: TObject);
begin
  if Timer1 = Sender then begin
    ArtCam1[0].SnapShot(BmpDraw[0].ScanLine[ArtCam1[0].Height-1], ArtCamGetSize, FALSE);
    ArtCam1[1].SnapShot(BmpDraw[1].ScanLine[ArtCam1[1].Height-1], ArtCamGetSize, FALSE);
    DrawImage;
  end;
end;


//////////////////////////////////////////////////
// Change window size
//////////////////////////////////////////////////
procedure TForm1.FormResize(Sender: TObject);
var
  Child1: HWND;
  Child2: HWND;
  rc: TRect;
begin
  // In Preview Mode, display size varies when size of child window is changed.
  if PreviewMode = 0 then begin
    Child1 := GetWindow(Form1.Handle, GW_CHILD);
    Child2 := GetWindow(Child1, GW_HWNDNEXT);
    rc := GetClientRect();

    SetWindowPos(Child1, HWND_TOP, 0, 0, rc.Right div 2, rc.Bottom, SWP_NOMOVE or SWP_NOZORDER or SWP_SHOWWINDOW);
    SetWindowPos(Child2, HWND_TOP, rc.Right div 2, 0, rc.Right div 2, rc.Bottom, SWP_NOZORDER or SWP_SHOWWINDOW);
  end;
end;


procedure TForm1.ReloadClick(Sender: TObject);
begin
 DllReload();
end;

//////////////////////////////////////////////////
// Obtain camera size etc.
//////////////////////////////////////////////////
function TForm1.ArtCamGetWidth: Integer;
begin
  result := ArtCam1[0].Width div SUB_SAMPLE[LONG(ArtCam1[0].GetSubSample)];
end;

function TForm1.ArtCamGetHeight: Integer;
begin
  result := ArtCam1[0].Height div SUB_SAMPLE[LONG(ArtCam1[0].GetSubSample)];
end;

function TForm1.ArtCamGetColor: Integer;
begin
  result := ((ArtCam1[0].GetColorMode + 7) div 8) * 8;
end;

function TForm1.ArtCamGetBpp: Integer;
begin
  result := ((ArtCam1[0].GetColorMode + 7) div 8);
end;

function TForm1.ArtCamGetSize: Integer;
begin
  result := ArtCamGetWidth * ArtCamGetHeight * ArtCamGetBpp;
end;


//////////////////////////////////////////////////
// Create bit-map
//////////////////////////////////////////////////
procedure TForm1.CreateBitmap;
var
  pal: TMaxLogPalette;
  i: Integer;
begin
  // Space for display
  BmpDraw[0] := TBitmap.Create;
  BmpDraw[0].Width := ArtCamGetWidth;
  BmpDraw[0].Height := ArtCamGetHeight;
  BmpDraw[1] := TBitmap.Create;
  BmpDraw[1].Width := ArtCamGetWidth;
  BmpDraw[1].Height := ArtCamGetHeight;

  case ArtCamGetBpp of
    1: begin
      BmpDraw[0].PixelFormat := pf8bit;
      BmpDraw[1].PixelFormat := pf8bit;

      // In case of 8 bit monochro, create pallet.
      for i := 0 to 255 do begin
        pal.palPalEntry[i].peRed   := i;
        pal.palPalEntry[i].peGreen := i;
        pal.palPalEntry[i].peBlue  := i;
        pal.palPalEntry[i].peFlags := 0;
      end;

      pal.palNumEntries := 256;
      pal.palVersion := $0300;
      BmpDraw[0].Palette := CreatePalette(PLogPalette(@pal)^);
      BmpDraw[1].Palette := CreatePalette(PLogPalette(@pal)^);
    end;

    // 24 bit color
    3: begin
      BmpDraw[0].PixelFormat := pf24bit;
      BmpDraw[1].PixelFormat := pf24bit;
    end;
  end;

  // To use other color number,
  // please refer to **
  // Sample_Delphi7_Graphic&Allbpp

end;


//////////////////////////////////////////////////
// Display
//////////////////////////////////////////////////
procedure TForm1.DrawImage;
begin
  if BmpDraw[0]=nil then begin exit; end;
  if BmpDraw[0].Empty then begin exit; end;

  // Draw image
  Image1.Canvas.Draw(0, 0, BmpDraw[0]);
  Image2.Canvas.Draw(0, 0, BmpDraw[1]);
end;


end.


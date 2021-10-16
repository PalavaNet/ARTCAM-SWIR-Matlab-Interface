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
    SetCamera: TMenuItem;
    SetFilter: TMenuItem;
    SetAnalog: TMenuItem;
    PopupDll: TMenuItem;
    PopupDevice: TMenuItem;
    Device0: TMenuItem;
    Device1: TMenuItem;
    Device2: TMenuItem;
    Device3: TMenuItem;
    Device4: TMenuItem;
    Device5: TMenuItem;
    Device6: TMenuItem;
    Device7: TMenuItem;
    Timer1: TTimer;
    Reload: TMenuItem;
    procedure ReloadClick(Sender: TObject);

    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure SaveClick(Sender: TObject);
    procedure ExitClick(Sender: TObject);
    procedure PreviewClick(Sender: TObject);
    procedure CallBackClick(Sender: TObject);
    procedure SnapShotClick(Sender: TObject);
    procedure CaptureClick(Sender: TObject);
    procedure TriggerClick(Sender: TObject);
    procedure SetCameraClick(Sender: TObject);
    procedure SetFilterClick(Sender: TObject);
    procedure SetAnalogClick(Sender: TObject);
    procedure Device0Click(Sender: TObject);
    procedure Device1Click(Sender: TObject);
    procedure Device2Click(Sender: TObject);
    procedure Device3Click(Sender: TObject);
    procedure Device4Click(Sender: TObject);
    procedure Device5Click(Sender: TObject);
    procedure Device6Click(Sender: TObject);
    procedure Device7Click(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure FormResize(Sender: TObject);
    procedure OnDllClick(Sender: TObject);
  private
    { Private declaration }
  public
    procedure CreateBitmap;
    procedure DrawImage;
    procedure DeviceChange(Sender: TObject; Number: Integer);
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
  BmpDraw: TBitmap;
  BmpCapture: TBitmap;
  ArtCam1: TArtCam;
  Hook: HHOOK;
  PreviewMode: Integer;
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
  ArtCam1 := TArtCam.Create;


  DllReload();


  // Receive DLL message by hook
  Hook := SetWindowsHookEx(WH_GETMESSAGE, MsgProc, 0, GetCurrentThreadID);
end;


//////////////////////////////////////////////////
// Release camera
//////////////////////////////////////////////////
procedure TForm1.FormDestroy(Sender: TObject);
begin
  ArtCam1.Release();

  UnHookWindowsHookEx(Hook);
end;


//////////////////////////////////////////////////
// Save image
//////////////////////////////////////////////////
procedure TForm1.SaveClick(Sender: TObject);
begin
  if not ArtCam1.IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  ArtCam1.SaveImage('image.png', FILETYPE_PNG);
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
begin
  if not ArtCam1.IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  Timer1.Enabled := false;

  // Release device
  ArtCam1.Close;

  // Set window to be displayed
  // When setting NULL to Handle,it is possible to create new window and show it.
  ArtCam1.SetPreviewWindow(Form1.Handle, 0, 0, Form1.Width, Form1.Height);

  // Display image
  // Display is controlled by SDK. Image information cannot be obtained.
  ArtCam1.Preview;

  // Check menu
  ShowPreview.Checked := true;
  ShowCallBack.Checked := false;
  ShowCapture.Checked := false;
  ShowTrigger.Checked := false;

  PreviewMode := 0;
  Invalidate;
end;


//////////////////////////////////////////////////
// Callback
//////////////////////////////////////////////////
procedure TForm1.CallBackClick(Sender: TObject);
begin
  if not ArtCam1.IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  Timer1.Enabled := false;

  // Release device
  ArtCam1.Close;

  // If drawing by yourself, set all window size to 0.
  // An automatic display can be performed, if window size is set up even when using CallBackPreview
  ArtCam1.SetPreviewWindow(Form1.Handle, 0, 0, 0, 0);

  // Creat area for capturing
  CreateBitmap;

  // Capture image
  ArtCam1.CallBackPreview(Form1.Handle, BmpCapture.ScanLine[BmpDraw.Height-1], ArtCamGetSize, FALSE);

  // Check menu
  ShowPreview.Checked := false;
  ShowCallBack.Checked := true;
  ShowCapture.Checked := false;
  ShowTrigger.Checked := false;

  PreviewMode := 1;

  Invalidate;
end;


//////////////////////////////////////////////////
// Snapshot
//////////////////////////////////////////////////
procedure TForm1.SnapShotClick(Sender: TObject);
begin
  if not ArtCam1.IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  Timer1.Enabled := false;

  // Release device
  ArtCam1.Close;

  // Creat area for capturing
  CreateBitmap;

  // Capture image
  ArtCam1.SnapShot(BmpCapture.ScanLine[BmpDraw.Height-1], ArtCamGetSize, FALSE);

  // Draw image
  DrawImage;

  // Check menu
  ShowPreview.Checked := false;
  ShowCallBack.Checked := false;
  ShowCapture.Checked := false;
  ShowTrigger.Checked := false;

  PreviewMode := -1;
end;


//////////////////////////////////////////////////
// Capture
//////////////////////////////////////////////////
procedure TForm1.CaptureClick(Sender: TObject);
begin
  if not ArtCam1.IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  Timer1.Enabled := false;

  // Release device
  ArtCam1.Close;

  // Creat area for capturing
  CreateBitmap;

  // Display image
  ArtCam1.Capture;

  Timer1.Interval := 200;
  Timer1.Enabled := true;

  // Check menu
  ShowPreview.Checked := false;
  ShowCallBack.Checked := false;
  ShowCapture.Checked := true;
  ShowTrigger.Checked := false;

  PreviewMode := 3;

  Invalidate;
end;


//////////////////////////////////////////////////
// Trigger
//////////////////////////////////////////////////
procedure TForm1.TriggerClick(Sender: TObject);
begin
  if not ArtCam1.IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  Timer1.Enabled := false;

  // Release device
  ArtCam1.Close;

  // If drawing by yourself, set all window size to 0.
  // An automatic display can be performed, if window size is set up even when using CallBackPreview
  ArtCam1.SetPreviewWindow(Form1.Handle, 0, 0, 0, 0);

  // Creat area for capturing
  CreateBitmap;

  // Capture image
  ArtCam1.Trigger(Form1.Handle, BmpCapture.ScanLine[BmpDraw.Height-1], ArtCamGetSize, FALSE);

  // Check menu
  ShowPreview.Checked := false;
  ShowCallBack.Checked := false;
  ShowCapture.Checked := false;
  ShowTrigger.Checked := true;

  PreviewMode := 4;

  Invalidate;
end;


//////////////////////////////////////////////////
// Camera settings
//////////////////////////////////////////////////
procedure TForm1.SetCameraClick(Sender: TObject);
begin
  if not ArtCam1.IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  ArtCam1.SetCameraDlg(Form1.Handle);

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
procedure TForm1.SetFilterClick(Sender: TObject);
begin
  if not ArtCam1.IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  ArtCam1.SetImageDlg(Form1.Handle);
end;


//////////////////////////////////////////////////
// Analog settings
//////////////////////////////////////////////////
procedure TForm1.SetAnalogClick(Sender: TObject);
begin
  if not ArtCam1.IsInit then begin ShowMessage('Select DLL of camera which is connected'); exit; end;
  ArtCam1.SetAnalogDlg(Form1.Handle);
end;


//////////////////////////////////////////////////
// Change device
//////////////////////////////////////////////////
procedure TForm1.DeviceChange(Sender: TObject; Number: Integer);
var
  i: Integer;
  DeviceName: array[0..255] of AnsiChar;

begin
  // Release the operative device before switching device
  ArtCam1.Close;


  // To confirm whether the device is connected, use "GetDeviceName"
  // It can be found out easily with "GetDeviceName".
  // When area for obtain name is not secured, it results in error. Prepare alignment length of at least 32.
  if not ArtCam1.GetDeviceName(Number, DeviceName, 256) then begin
    PreviewMode := -1;
    exit;
  end;


  // A device will be changed, if a camera is displayed after changing the number of a device now
  // Notes: A device is not changed in this function simple substance
  //   After calling this function, a device is changed by initializing a device
  ArtCam1.SetDeviceNumber(Number);

  for i := 0 to 7 do begin
    PopupDevice[i].Checked := false;
  end;
  PopupDevice[Number].Checked := true;


  case PreviewMode of
  0: PreviewClick(Sender);
  1: CallBackClick(Sender);
  3: CaptureClick(Sender);
  4: TriggerClick(Sender);
  end;
end;


//////////////////////////////////////////////////
// Select device
//////////////////////////////////////////////////
procedure TForm1.Device0Click(Sender: TObject); begin DeviceChange(Sender, 0); end;
procedure TForm1.Device1Click(Sender: TObject); begin DeviceChange(Sender, 1); end;
procedure TForm1.Device2Click(Sender: TObject); begin DeviceChange(Sender, 2); end;
procedure TForm1.Device3Click(Sender: TObject); begin DeviceChange(Sender, 3); end;
procedure TForm1.Device4Click(Sender: TObject); begin DeviceChange(Sender, 4); end;
procedure TForm1.Device5Click(Sender: TObject); begin DeviceChange(Sender, 5); end;
procedure TForm1.Device6Click(Sender: TObject); begin DeviceChange(Sender, 6); end;
procedure TForm1.Device7Click(Sender: TObject); begin DeviceChange(Sender, 7); end;

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
  DevName: DeviceNameList;
  DevCount: Integer;
  i: Integer;
  Error: string;
  res: Boolean;
  sl:TStringList;
begin
  // Release all devices before switching DLL
  // Need to define TArtCam plurally in case of displaying plural cameras at the same time
  // When defined plurally, you do not need to relase to switch cameras
  if ArtCam1.IsInit then begin
    ArtCam1.Release;
    Timer1.Enabled := false;
  end;

  DllType := Number;
  SataType := CameraType;
  res := false;

  sl := TStringList.Create;
  sl.Delimiter := #9; // Tab
  sl.DelimitedText := PopupDll[Number+1].Caption;
	res := ArtCam1.LoadLibrary(PChar(sl.Strings[0]));
  sl.Free;

  // Read DLL
  if not res then begin
    Error := 'DLL is not found.\nIt may have been relocated after executing.';
    ShowMessage(Error);
    exit;
  end;

  // Initialize is to be called first
  // By setting Window Handle here, WMLERROR can be obtained
  if not ArtCam1.Initialize(Handle) then begin
    ShowMessage('SDK initialization error');
    exit;
  end;


  // Select SATA camera type when use Sata.dll
  if (-1 <> CameraType) and (ARTCAM_CAMERATYPE_SATA = ARTCAM_CAMERATYPE(HIWORD(ArtCam1.GetDllVersion()))) then begin
    ArtCam1.SetCameraType(CameraType);
  end;



  // Check menu
	for i := 0 to DllCount-1 do begin
		PopupDll[i+1].Checked := false;
  end;
	PopupDll[Number+1].Checked := true;

	if(-1 <> CameraType) and (ARTCAM_CAMERATYPE_SATA = ARTCAM_CAMERATYPE(HIWORD(ArtCam1.GetDllVersion()))) then begin
		for i:=0 to 11 do begin
			PopupDll[DllSata+1].Items[i].Checked := false;
		end;
		PopupDll[DllSata+1].Items[SataType].Checked := true;
	end;

  DevCount := ArtCam1.EnumDevice(DevName);
  for i := 0 to DevCount-1 do begin
    ArtCam1.GetDeviceName(i, DevName[i], 256);
    PopupDevice[i].Caption := DevName[i];
    PopupDevice[i].Enabled := true;
  end;

  for i := DevCount to 7 do begin
    PopupDevice[i].Caption := IntToStr(i);
    PopupDevice[i].Enabled := false;
  end;

  // Device setting
  DeviceChange(Sender, 0);
end;


//////////////////////////////////////////////////
// For capture
//////////////////////////////////////////////////
procedure TForm1.Timer1Timer(Sender: TObject);
begin
  if Timer1 = Sender then begin
    ArtCam1.SnapShot(BmpDraw.ScanLine[ArtCam1.Height-1], ArtCamGetSize, FALSE);
    DrawImage;
  end;
end;


//////////////////////////////////////////////////
// Change window size
//////////////////////////////////////////////////
procedure TForm1.FormResize(Sender: TObject);
var
  Child: HWND;
  rc: TRect;
{
  winW: Double;
  winH: Double;
  capW: Double;
  capH: Double;
}
begin
  // In Preview Mode, display size varies when size of child window is changed.
  if PreviewMode = 0 then begin
    Child := GetWindow(Form1.Handle, GW_CHILD);
    rc := GetClientRect();

    // To avoiding changing aspect ratio, remove comment
{
    // Use the real number once because calculation turns to the decimal fraction unit.
    winW := rc.Right;
    winH := rc.Bottom;
    capW := ArtCamGetWidth;
    capH := ArtCamGetHeight;

    if (winW * capH) > (winH * capW) then begin
      winW := winH * capW / capH;
      rc.Right := Trunc(winW);
    end
    else
    if (winW * capH) < (winH * capW) then begin
      winH := winW * capH / capW;
      rc.Bottom := Trunc(winH);
    end;
 }

    SetWindowPos(Child, HWND_TOP, 0, 0, rc.Right, rc.Bottom, SWP_NOMOVE or SWP_NOZORDER or SWP_SHOWWINDOW);
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
  result := ArtCam1.Width div SUB_SAMPLE[LONG(ArtCam1.GetSubSample)];
end;

function TForm1.ArtCamGetHeight: Integer;
begin
  result := ArtCam1.Height div SUB_SAMPLE[LONG(ArtCam1.GetSubSample)];
end;

function TForm1.ArtCamGetColor: Integer;
begin
  result := ((ArtCam1.GetColorMode + 7) div 8) * 8;
end;

function TForm1.ArtCamGetBpp: Integer;
begin
  result := ((ArtCam1.GetColorMode + 7) div 8);
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
  BmpDraw := TBitmap.Create;
  BmpDraw.Width := ArtCamGetWidth;
  BmpDraw.Height := ArtCamGetHeight;
  BmpDraw.PixelFormat := pf24bit;

  // Appoint red pen
  BmpDraw.Canvas.Pen.Color := clRed;

  // Space for taking in
  BmpCapture := TBitmap.Create;
  BmpCapture.Width := ArtCamGetWidth;
  BmpCapture.Height := ArtCamGetHeight;

  case ArtCamGetBpp of
    1: begin
      BmpCapture.PixelFormat := pf8bit;

      // In case of 8 bit monochro, create pallet.
      for i := 0 to 255 do begin
        pal.palPalEntry[i].peRed   := i;
        pal.palPalEntry[i].peGreen := i;
        pal.palPalEntry[i].peBlue  := i;
        pal.palPalEntry[i].peFlags := 0;
      end;

      pal.palNumEntries := 256;
      pal.palVersion := $0300;
      BmpCapture.Palette := CreatePalette(PLogPalette(@pal)^);
    end;

    2: begin BmpCapture.PixelFormat := pf16bit; end;
    3: begin BmpCapture.PixelFormat := pf24bit; end;
    4: begin BmpCapture.PixelFormat := pf32bit; end;

    6: begin
      // You cannot appoint pf48bit. So increase data volume by doubling horizontal size.
      // By aligning size, there will be no problem with alignment length of area for capturing.
      BmpCapture.Width := ArtCamGetWidth * 2;
      BmpCapture.Height := ArtCamGetHeight;
      BmpCapture.PixelFormat := pf24bit;
    end;

    8: begin
      // You cannot appoint pf64bit. So increase data volume by doubling horizontal size.
      // By aligning size, there will be no problem with alignment length of area for capturing.
      BmpCapture.Width := ArtCamGetWidth * 2;
      BmpCapture.Height := ArtCamGetHeight;
      BmpCapture.PixelFormat := pf32bit;
    end;
  end;

end;


//////////////////////////////////////////////////
// Display
//////////////////////////////////////////////////
procedure TForm1.DrawImage;
var
  pt: TPoint;
  x: Integer;
  y: Integer;
  dx: Integer;
  sx: Integer;
  pDest: PByteArray;
  pSrc : PByteArray;
  SrcBpp: Integer;
begin
  if BmpDraw=nil then begin exit; end;
  if BmpDraw.Empty then begin exit; end;

  SrcBpp := ArtCamGetBpp;


  // For capturing->Draw for display
  case SrcBpp of
    // Draw when bit calculation is not required
    1, 3, 4: begin
      BmpDraw.Canvas.Draw(0, 0, BmpCapture);
    end;

    // In 16 bit, shift calculation is required in the unit of pixel.
    2: begin
      for y := 0 to BmpDraw.Height-1 do begin
        pDest := BmpDraw.ScanLine[y];
        pSrc  := BmpCapture.ScanLine[y];
        dx := 0;
        sx := 0;

        for x := 0 to BmpDraw.Width-1 do begin
          pDest[dx  ] := (pSrc[sx+1] shl 6) or (pSrc[sx] shr 2);
          pDest[dx+1] := (pSrc[sx+1] shl 6) or (pSrc[sx] shr 2);
          pDest[dx+2] := (pSrc[sx+1] shl 6) or (pSrc[sx] shr 2);

          dx := dx + 3;
          sx := sx + SrcBpp;
        end;
      end;
    end;

    6, 8: begin
      for y := 0 to BmpDraw.Height-1 do begin
        pDest := BmpDraw.ScanLine[y];
        pSrc  := BmpCapture.ScanLine[y];
        dx := 0;
        sx := 0;

        for x := 0 to BmpDraw.Width-1 do begin
          pDest[dx  ] := (pSrc[sx+1] shl 6) or (pSrc[sx  ] shr 2);
          pDest[dx+1] := (pSrc[sx+3] shl 6) or (pSrc[sx+2] shr 2);
          pDest[dx+2] := (pSrc[sx+5] shl 6) or (pSrc[sx+4] shr 2);

          dx := dx + 3;
          sx := sx + SrcBpp;
        end;
      end;
    end;
  end;


  // Line drawing
  GetCursorPos(pt);
  pt := ScreenToClient(pt);

  // Draw the line to bitmap not to flicker
  BmpDraw.Canvas.MoveTo(0, pt.y);
  BmpDraw.Canvas.LineTo(BmpDraw.Width, pt.y);
  BmpDraw.Canvas.MoveTo(pt.x, 0);
  BmpDraw.Canvas.LineTo(pt.x, BmpDraw.Height);

  // Draw image
  Canvas.Draw(0, 0, BmpDraw);
end;


end.


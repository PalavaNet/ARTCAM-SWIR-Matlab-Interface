unit Unit3;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ArtCam;

type
  TForm3 = class(TForm)
    LabelFps: TLabel;
    GroupBox1: TGroupBox;
    Label3: TLabel;
    Label1: TLabel;
    Label2: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    EditHT: TEdit;
    EditHE: TEdit;
    EditHS: TEdit;
    EditVS: TEdit;
    EditVT: TEdit;
    EditVE: TEdit;
    GroupBox2: TGroupBox;
    RadioSubSample1: TRadioButton;
    RadioSubSample2: TRadioButton;
    RadioSubSample4: TRadioButton;
    RadioSubSample8: TRadioButton;
    GroupBox3: TGroupBox;
    LabelVideo: TLabel;
    GroupBox4: TGroupBox;
    RadioRateWH: TRadioButton;
    RadioRateWL: TRadioButton;
    RadioRateNH: TRadioButton;
    RadioRateNL: TRadioButton;
    GroupBox5: TGroupBox;
    RadioChannel1: TRadioButton;
    RadioChannel2: TRadioButton;
    RadioChannel3: TRadioButton;
    RadioChannel4: TRadioButton;
    RadioChannel5: TRadioButton;
    RadioChannel6: TRadioButton;
    GroupBox6: TGroupBox;
    RadioColor08: TRadioButton;
    RadioColor16: TRadioButton;
    RadioColor24: TRadioButton;
    RadioColor48: TRadioButton;
    RadioColor32: TRadioButton;
    RadioColor64: TRadioButton;
    EditFps: TEdit;
    GroupBox7: TGroupBox;
    EditCode1: TEdit;
    EditCode2: TEdit;
    EditCode3: TEdit;
    EditCode4: TEdit;
    CheckCode: TCheckBox;
    EditCode8: TEdit;
    EditCode7: TEdit;
    EditCode6: TEdit;
    EditCode5: TEdit;
    Button1: TButton;
    Button2: TButton;
    procedure Button2Click(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declaration }
  public
    m_pCArtCamSdk: ^TArtCam;
    m_DllType: ARTCAM_CAMERATYPE;
    m_SubCode: bool;

    procedure InitCameraSize;
    procedure InitColorMode;
    procedure InitSubSample;
    procedure InitCNV;
    procedure InitSubCode;

    constructor NilSet;

  end;

var
  Form3: TForm3;

implementation

uses Unit1;

{$R *.dfm}


constructor TForm3.NilSet;
begin
  m_pCArtCamSdk := nil;
end;

procedure TForm3.FormShow(Sender: TObject);
begin
  if nil = m_pCArtCamSdk then begin
    exit;
  end;


  // Change operation for each DLL
  // For each DLL function, please refer to manual.
  m_DllType := ARTCAM_CAMERATYPE(HIWORD(m_pCArtCamSdk.GetDllVersion()));


  // Set size for camera
  InitCameraSize;

  // Set color mode
  InitColorMode;

  // Set information for sub-sampling.
  InitSubSample;

  // Initialize CNV.
  InitCNV;

  // Obtain sub-code
  InitSubCode();


  // Frame rate for Directshow
  if ARTCAM_CAMERATYPE_DS = m_DllType then begin
    EditFps.Text := IntToStr(m_pCArtCamSdk.Fps());
  end
  // For all others, this is the waiting period between frames
  else begin
    LabelFps.Caption := 'Waiting time  (ms)';
    EditFps.Text := IntToStr(m_pCArtCamSdk.GetWaitTime());
  end;
end;


//////////////////////////////////////////////////
procedure TForm3.InitCameraSize;
var
  lHT: Integer;
  lHS: Integer;
  lHE: Integer;
  lVT: Integer;
  lVS: Integer;
  lVE: Integer;
begin

  // Cameras that do not allow size settings
  case m_DllType of

    ARTCAM_CAMERATYPE_DS: begin
      EditHT.Enabled := False;
      EditHS.Enabled := False;
      EditVT.Enabled := False;
      EditVS.Enabled := False;

      EditHT.Text := IntToStr(m_pCArtCamSdk.Width());
      EditHE.Text := IntToStr(m_pCArtCamSdk.Width());
      EditHS.Text := '0';
      EditVT.Text := IntToStr(m_pCArtCamSdk.Height());
      EditVE.Text := IntToStr(m_pCArtCamSdk.Height());
      EditVS.Text := '0';
    end;

    ARTCAM_CAMERATYPE_CNV,
    ARTCAM_CAMERATYPE_098,
    ARTCAM_CAMERATYPE_500P,
    ARTCAM_CAMERATYPE_150P2: begin
      EditHT.Enabled := False;
      EditHE.Enabled := False;
      EditHS.Enabled := False;
      EditVT.Enabled := False;
      EditVE.Enabled := False;
      EditVS.Enabled := False;

      EditHT.Text := IntToStr(m_pCArtCamSdk.Width());
      EditHE.Text := IntToStr(m_pCArtCamSdk.Width());
      EditHS.Text := '0';
      EditVT.Text := IntToStr(m_pCArtCamSdk.Height());
      EditVE.Text := IntToStr(m_pCArtCamSdk.Height());
      EditVS.Text := '0';
    end;

    ARTCAM_CAMERATYPE_130MI,
    ARTCAM_CAMERATYPE_200MI,
    ARTCAM_CAMERATYPE_300MI,
    ARTCAM_CAMERATYPE_320P,
    ARTCAM_CAMERATYPE_200SH: begin
      EditVT.Enabled := False;
      EditHT.Enabled := False;

      m_pCArtCamSdk.GetCaptureWindowEx(@lHT, @lHS, @lHE, @lVT, @lVS, @lVE);

      EditHT.Text := IntToStr(lHT);
      EditHE.Text := IntToStr(lHE);
      EditHS.Text := IntToStr(lHS);
      EditVT.Text := IntToStr(lVT);
      EditVE.Text := IntToStr(lVE);
      EditVS.Text := IntToStr(lVS);
    end;

    else begin
      m_pCArtCamSdk.GetCaptureWindowEx(@lHT, @lHS, @lHE, @lVT, @lVS, @lVE);

      EditHT.Text := IntToStr(lHT);
      EditHE.Text := IntToStr(lHE);
      EditHS.Text := IntToStr(lHS);
      EditVT.Text := IntToStr(lVT);
      EditVE.Text := IntToStr(lVE);
      EditVS.Text := IntToStr(lVS);
    end;
  end;

end;

//////////////////////////////////////////////////
procedure TForm3.InitColorMode;
begin
  // Color number
  case m_pCArtCamSdk.GetColorMode() of
    8:  RadioColor08.Checked := true;
    16: RadioColor16.Checked := true;
    24: RadioColor24.Checked := true;
    32: RadioColor32.Checked := true;
    48: RadioColor48.Checked := true;
    64: RadioColor64.Checked := true;
  end;

  case m_DllType of
    ARTCAM_CAMERATYPE_DS: begin
      RadioColor08.Enabled := false;
      RadioColor16.Enabled := false;
      RadioColor32.Enabled := false;
      RadioColor48.Enabled := false;
      RadioColor64.Enabled := false;
    end;

    ARTCAM_CAMERATYPE_CNV: begin
      RadioColor32.Enabled := false;
      RadioColor48.Enabled := false;
      RadioColor64.Enabled := false;
    end;

    ARTCAM_CAMERATYPE_320P,
    ARTCAM_CAMERATYPE_200SH: begin
      RadioColor16.Enabled := false;
      RadioColor32.Enabled := false;
      RadioColor48.Enabled := false;
      RadioColor64.Enabled := false;
    end;
  end;

end;

//////////////////////////////////////////////////
procedure TForm3.InitSubSample;
begin
  // Sub-sampling
  case m_pCArtCamSdk.GetSubSample() of
    SUBSAMPLE_1:  RadioSubSample1.Checked := true;
    SUBSAMPLE_2:  RadioSubSample2.Checked := true;
    SUBSAMPLE_4:  RadioSubSample4.Checked := true;
    SUBSAMPLE_8:  RadioSubSample8.Checked := true;
  end;

  case m_DllType of
    ARTCAM_CAMERATYPE_130MI,
    ARTCAM_CAMERATYPE_200MI,
    ARTCAM_CAMERATYPE_300MI: begin
      RadioSubSample8.Enabled := false;
    end;

    else begin
      RadioSubSample1.Enabled := false;
      RadioSubSample2.Enabled := false;
      RadioSubSample4.Enabled := false;
      RadioSubSample8.Enabled := false;
    end;
  end;

end;

//////////////////////////////////////////////////
procedure TForm3.InitCNV;
begin
  // For CNV only
  if ARTCAM_CAMERATYPE_CNV = m_DllType then begin
    case VIDEOFORMAT(m_pCArtCamSdk.GetVideoFormat(nil)) of
      VIDEOFORMAT_NTSC:   LabelVideo.Caption := 'VideoFormat : NTSC';
      VIDEOFORMAT_PAL:    LabelVideo.Caption := 'VideoFormat : PAL';
      VIDEOFORMAT_PALM:   LabelVideo.Caption := 'VideoFormat : PALM';
      VIDEOFORMAT_SECAM:  LabelVideo.Caption := 'VideoFormat : SECAM';
    end;

    case SAMPLING_RATE(m_pCArtCamSdk.GetSamplingRate(nil)) of
      WIDE_HISPEED:     RadioRateWH.Checked := true;
      WIDE_LOWSPEED:    RadioRateWL.Checked := true;
      NORMAL_HISPEED:   RadioRateNH.Checked := true;
      NORMAL_LOWSPEED:  RadioRateNL.Checked := true;
    end;
  end

  else begin
    RadioRateWH.Enabled := false;
    RadioRateWL.Enabled := false;
    RadioRateNH.Enabled := false;
    RadioRateNL.Enabled := false;

    RadioChannel1.Enabled := false;
    RadioChannel2.Enabled := false;
    RadioChannel3.Enabled := false;
    RadioChannel4.Enabled := false;
    RadioChannel5.Enabled := false;
    RadioChannel6.Enabled := false;
  end;
end;

//////////////////////////////////////////////////
procedure TForm3.InitSubCode;
var
  Error: BOOL;
begin
  m_SubCode := FALSE;
  EditCode1.Text := IntToStr(m_pCArtCamSdk.ReadSromID(0, @Error));

  if FALSE = Error then begin
    EditCode1.Enabled := false;
    EditCode2.Enabled := false;
    EditCode3.Enabled := false;
    EditCode4.Enabled := false;
    EditCode5.Enabled := false;
    EditCode6.Enabled := false;
    EditCode7.Enabled := false;
    EditCode8.Enabled := false;

    CheckCode.Enabled := false;
    exit;
  end;


  EditCode2.Text := IntToStr(m_pCArtCamSdk.ReadSromID(1, @Error));
  EditCode3.Text := IntToStr(m_pCArtCamSdk.ReadSromID(2, @Error));
  EditCode4.Text := IntToStr(m_pCArtCamSdk.ReadSromID(3, @Error));
  EditCode5.Text := IntToStr(m_pCArtCamSdk.ReadSromID(4, @Error));
  EditCode6.Text := IntToStr(m_pCArtCamSdk.ReadSromID(5, @Error));
  EditCode7.Text := IntToStr(m_pCArtCamSdk.ReadSromID(6, @Error));
  EditCode8.Text := IntToStr(m_pCArtCamSdk.ReadSromID(7, @Error));

  m_SubCode := TRUE;
end;

//////////////////////////////////////////////////
procedure TForm3.Button2Click(Sender: TObject);
begin
  Hide;
end;

//////////////////////////////////////////////////
procedure TForm3.Button1Click(Sender: TObject);
var
  lHT: Integer;
  lHS: Integer;
  lHE: Integer;
  lVT: Integer;
  lVS: Integer;
  lVE: Integer;
  lFps: Integer;
  Code: BYTE;
  CameraInfo: ArtCam.CAMERAINFO;

begin
  // Check size before reflecting
  lHT   := StrToInt(EditHT.Text);
  lHE   := StrToInt(EditHE.Text);
  lHS   := StrToInt(EditHS.Text);
  lVT   := StrToInt(EditVT.Text);
  lVE   := StrToInt(EditVE.Text);
  lVS   := StrToInt(EditVS.Text);
  lFps  := StrToInt(EditFps.Text);

  CameraInfo.lSize := SizeOf(ArtCam.CAMERAINFO);
  m_pCArtCamSdk.GetCameraInfo(@CameraInfo);

  // Size 0 represents error
  if (0 = lVT) or (0 = lVE) or (0 = lHT) or (0 = lHE) then begin
    ShowMessage('Set size is wrong');
    exit;
  end;

  // Effective resolution larger than maximum resolution results in error.
  if (lVT < lVE + lVS) or (lHT < lHE + lHS)  then begin
    ShowMessage('Set size is wrong');
    exit;
  end;

  if (lVT > CameraInfo.lHeight) or (lHT > CameraInfo.lWidth)  then begin
    ShowMessage('Set size is wrong');
    exit;
  end;




  // When waiting period is set 0, there will be excessive load on CPU.
  if not (ARTCAM_CAMERATYPE_DS = m_DllType) then begin
    if 0 >= lFps then begin
      ShowMessage('Set at least 1 for waiting period. /n performance will deteriorate.');
      exit;
    end;
  end;



  // Size & frame rate settings.
  case m_DllType of
	  ARTCAM_CAMERATYPE_DS: begin
	    m_pCArtCamSdk.SetCaptureWindow(lHE, lVE, lFps);
	  end;

	  ARTCAM_CAMERATYPE_CNV: begin
	    if RadioRateWH.Checked then m_pCArtCamSdk.SetSamplingRate(0);
	    if RadioRateWL.Checked then m_pCArtCamSdk.SetSamplingRate(1);
	    if RadioRateNH.Checked then m_pCArtCamSdk.SetSamplingRate(2);
	    if RadioRateNL.Checked then m_pCArtCamSdk.SetSamplingRate(3);

	    if RadioChannel1.Checked then m_pCArtCamSdk.SetCrossbar(0, 0);
	    if RadioChannel2.Checked then m_pCArtCamSdk.SetCrossbar(1, 0);
	    if RadioChannel3.Checked then m_pCArtCamSdk.SetCrossbar(2, 0);
	    if RadioChannel4.Checked then m_pCArtCamSdk.SetCrossbar(3, 0);
	    if RadioChannel5.Checked then m_pCArtCamSdk.SetCrossbar(4, 0);
	    if RadioChannel6.Checked then m_pCArtCamSdk.SetCrossbar(5, 0);
	  end;

	  ARTCAM_CAMERATYPE_098,
	  ARTCAM_CAMERATYPE_500P,
	  ARTCAM_CAMERATYPE_150P2: begin
	  end;

	  else begin
	    m_pCArtCamSdk.SetCaptureWindowEx(lHT, lHS, lHE, lVT, lVS, lVE);
	    m_pCArtCamSdk.SetWaitTime(lFps);
	  end;
  end;


  // Invalid values cannot be set at dialog
  // It reflects without modification
  // There is no problem since inactive camera returns error as well
  if RadioSubSample1.Checked then m_pCArtCamSdk.SetSubSample(SUBSAMPLE_1);
  if RadioSubSample2.Checked then m_pCArtCamSdk.SetSubSample(SUBSAMPLE_2);
  if RadioSubSample4.Checked then m_pCArtCamSdk.SetSubSample(SUBSAMPLE_4);
  if RadioSubSample8.Checked then m_pCArtCamSdk.SetSubSample(SUBSAMPLE_8);

  if RadioColor08.Checked then m_pCArtCamSdk.SetColorMode( 8);
  if RadioColor16.Checked then m_pCArtCamSdk.SetColorMode(16);
  if RadioColor24.Checked then m_pCArtCamSdk.SetColorMode(24);
  if RadioColor32.Checked then m_pCArtCamSdk.SetColorMode(32);
  if RadioColor48.Checked then m_pCArtCamSdk.SetColorMode(48);
  if RadioColor64.Checked then m_pCArtCamSdk.SetColorMode(64);


  // Write sub-code
  // Make sure writing is correct
  if CheckCode.Checked then begin
    Code := StrToInt(EditCode1.Text);
    m_pCArtCamSdk.WriteSromID(0, Code);
    Code := StrToInt(EditCode2.Text);
    m_pCArtCamSdk.WriteSromID(1, Code);
    Code := StrToInt(EditCode3.Text);
    m_pCArtCamSdk.WriteSromID(2, Code);
    Code := StrToInt(EditCode4.Text);
    m_pCArtCamSdk.WriteSromID(3, Code);
    Code := StrToInt(EditCode5.Text);
    m_pCArtCamSdk.WriteSromID(4, Code);
    Code := StrToInt(EditCode6.Text);
    m_pCArtCamSdk.WriteSromID(5, Code);
    Code := StrToInt(EditCode7.Text);
    m_pCArtCamSdk.WriteSromID(6, Code);
    Code := StrToInt(EditCode8.Text);
    m_pCArtCamSdk.WriteSromID(7, Code);
  end;


  Form1.ReDraw();
  Hide();
end;

end.

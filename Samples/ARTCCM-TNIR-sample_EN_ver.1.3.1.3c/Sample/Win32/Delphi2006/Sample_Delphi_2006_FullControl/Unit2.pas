unit Unit2;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ArtCam, ComCtrls;

type
  TForm2 = class(TForm)
    GroupBox1: TGroupBox;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    EditBrightness: TEdit;
    EditContrast: TEdit;
    EditHue: TEdit;
    EditSaturation: TEdit;
    EditSharpness: TEdit;
    EditGamma: TEdit;
    UpDownBrightness: TUpDown;
    UpDownContrast: TUpDown;
    UpDownHue: TUpDown;
    UpDownSaturation: TUpDown;
    UpDownSharpness: TUpDown;
    UpDownGamma: TUpDown;
    GroupBox2: TGroupBox;
    Label7: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    Label10: TLabel;
    Label11: TLabel;
    Label12: TLabel;
    EditExposureTime: TEdit;
    EditColorGainB: TEdit;
    EditColorGainG2: TEdit;
    EditColorGainG1: TEdit;
    EditColorGainR: TEdit;
    EditGlobalGain: TEdit;
    UpDownGlobalGain: TUpDown;
    UpDownColorGainR: TUpDown;
    UpDownColorGainG1: TUpDown;
    UpDownColorGainG2: TUpDown;
    UpDownColorGainB: TUpDown;
    UpDownExposureTime: TUpDown;
    GroupBox3: TGroupBox;
    CheckAWB: TCheckBox;
    GroupBox4: TGroupBox;
    RadioBayer1: TRadioButton;
    RadioBayer2: TRadioButton;
    RadioBayer3: TRadioButton;
    RadioBayer4: TRadioButton;
    GroupBox5: TGroupBox;
    Label13: TLabel;
    Label14: TLabel;
    Label15: TLabel;
    EditBayerGainB: TEdit;
    EditBayerGainG: TEdit;
    EditBayerGainR: TEdit;
    UpDownBayerGainR: TUpDown;
    UpDownBayerGainG: TUpDown;
    UpDownBayerGainB: TUpDown;
    GroupBox6: TGroupBox;
    RadioAI1: TRadioButton;
    RadioAI2: TRadioButton;
    RadioAI3: TRadioButton;
    GroupBox7: TGroupBox;
    CheckMirrorV: TCheckBox;
    CheckMirrorH: TCheckBox;
    CheckHalfClock: TCheckBox;
    GroupBox8: TGroupBox;
    RadioChannel1: TRadioButton;
    RadioChannel2: TRadioButton;
    RadioChannel3: TRadioButton;
    RadioChannel4: TRadioButton;
    RadioChannel5: TRadioButton;
    RadioChannel6: TRadioButton;
    Button1: TButton;
    procedure FormShow(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure CheckAWBClick(Sender: TObject);
    procedure RadioBayer1Click(Sender: TObject);
    procedure RadioBayer2Click(Sender: TObject);
    procedure RadioBayer3Click(Sender: TObject);
    procedure RadioBayer4Click(Sender: TObject);
    procedure RadioAI1Click(Sender: TObject);
    procedure RadioAI2Click(Sender: TObject);
    procedure RadioAI3Click(Sender: TObject);
    procedure CheckMirrorVClick(Sender: TObject);
    procedure CheckMirrorHClick(Sender: TObject);
    procedure CheckHalfClockClick(Sender: TObject);
    procedure RadioChannel1Click(Sender: TObject);
    procedure RadioChannel2Click(Sender: TObject);
    procedure RadioChannel3Click(Sender: TObject);
    procedure RadioChannel4Click(Sender: TObject);
    procedure RadioChannel5Click(Sender: TObject);
    procedure RadioChannel6Click(Sender: TObject);
    procedure EditBrightnessChange(Sender: TObject);
    procedure EditContrastChange(Sender: TObject);
    procedure EditHueChange(Sender: TObject);
    procedure EditSaturationChange(Sender: TObject);
    procedure EditSharpnessChange(Sender: TObject);
    procedure EditGammaChange(Sender: TObject);
    procedure EditBayerGainRChange(Sender: TObject);
    procedure EditBayerGainGChange(Sender: TObject);
    procedure EditBayerGainBChange(Sender: TObject);
    procedure EditGlobalGainChange(Sender: TObject);
    procedure EditColorGainRChange(Sender: TObject);
    procedure EditColorGainG1Change(Sender: TObject);
    procedure EditColorGainG2Change(Sender: TObject);
    procedure EditColorGainBChange(Sender: TObject);
    procedure EditExposureTimeChange(Sender: TObject);
  private
    { Private declaration }
  public
    m_pCArtCamSdk: ^TArtCam;
    m_DllType: ARTCAM_CAMERATYPE;
    m_Preview: Integer;
    m_Init: bool;

    procedure InitControl(FilterType: ARTCAM_FILTERTYPE; Edit: TEdit; UpDown: TUpDown; Min: Integer; Max: Integer);
    constructor NilSet;
  end;

var
  Form2: TForm2;

implementation

{$R *.dfm}

constructor TForm2.NilSet;
begin
  m_pCArtCamSdk := nil;
  m_Init := false;
end;

procedure TForm2.FormShow(Sender: TObject);
var
  DllType: Integer;
  Error: BOOL;
  Data: Integer;
  CameraInfo: ArtCam.CAMERAINFO;

begin
  m_Init := false;

  if nil = m_pCArtCamSdk then begin
    exit;
  end;


  // Change operation for each DLL
  // For each DLL function, please refer to manual.
  DllType := HIWORD(m_pCArtCamSdk.GetDllVersion());
  m_DllType := ARTCAM_CAMERATYPE(DllType);

  CameraInfo.lSize := SizeOf(ArtCam.CAMERAINFO);
  m_pCArtCamSdk.GetCameraInfo(@CameraInfo);

  // Range for value is set while determination of availability is done. 
  if ARTCAM_CAMERATYPE_CNV = m_DllType then begin
    InitControl(ARTCAM_FILTERTYPE_BRIGHTNESS,   EditBrightness, UpDownBrightness,   0,  255);
    InitControl(ARTCAM_FILTERTYPE_CONTRAST,     EditContrast,   UpDownContrast,     0,  255);
    InitControl(ARTCAM_FILTERTYPE_HUE,          EditHue,        UpDownHue,          0,  255);
    InitControl(ARTCAM_FILTERTYPE_SATURATION,   EditSaturation, UpDownSaturation,   0,  255);
    InitControl(ARTCAM_FILTERTYPE_SHARPNESS,    EditSharpness,  UpDownSharpness,    0,    0);
    InitControl(ARTCAM_FILTERTYPE_GAMMA,        EditGamma,      UpDownGamma,        0,    0);

    InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_R, EditBayerGainR, UpDownBayerGainR,   0,    0);
    InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_G, EditBayerGainG, UpDownBayerGainG,   0,    0);
    InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_B, EditBayerGainB, UpDownBayerGainB,   0,    0);
  end
  else begin
    InitControl(ARTCAM_FILTERTYPE_BRIGHTNESS,   EditBrightness, UpDownBrightness, -255, 255);
    InitControl(ARTCAM_FILTERTYPE_CONTRAST,     EditContrast,   UpDownContrast,   -127, 127);
    InitControl(ARTCAM_FILTERTYPE_HUE,          EditHue,        UpDownHue,        -360, 360);
    InitControl(ARTCAM_FILTERTYPE_SATURATION,   EditSaturation, UpDownSaturation, -255, 255);
    InitControl(ARTCAM_FILTERTYPE_SHARPNESS,    EditSharpness,  UpDownSharpness,     0,  30);
    InitControl(ARTCAM_FILTERTYPE_GAMMA,        EditGamma,      UpDownGamma,         0, 200);

    InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_R, EditBayerGainR, UpDownBayerGainR,    0, 200);
    InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_G, EditBayerGainG, UpDownBayerGainG,    0, 200);
    InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_B, EditBayerGainB, UpDownBayerGainB,    0, 200);
  end;


  InitControl(ARTCAM_FILTERTYPE_GLOBAL_GAIN,    EditGlobalGain,   UpDownGlobalGain,   CameraInfo.lGlobalGainMin, CameraInfo.lGlobalGainMax);
  InitControl(ARTCAM_FILTERTYPE_COLOR_GAIN_R,   EditColorGainR,   UpDownColorGainR,   CameraInfo.lColorGainMin,  CameraInfo.lColorGainMax);
  InitControl(ARTCAM_FILTERTYPE_COLOR_GAIN_G1,  EditColorGainG1,  UpDownColorGainG1,  CameraInfo.lColorGainMin,  CameraInfo.lColorGainMax);
  InitControl(ARTCAM_FILTERTYPE_COLOR_GAIN_G2,  EditColorGainG2,  UpDownColorGainG2,  CameraInfo.lColorGainMin,  CameraInfo.lColorGainMax);
  InitControl(ARTCAM_FILTERTYPE_COLOR_GAIN_B,   EditColorGainB,   UpDownColorGainB,   CameraInfo.lColorGainMin,  CameraInfo.lColorGainMax);
  InitControl(ARTCAM_FILTERTYPE_EXPOSURETIME,   EditExposureTime, UpDownExposureTime, CameraInfo.lExposureMin,   CameraInfo.lExposureMax);


  // Auto white balance
  Error := FALSE;
  Data := m_pCArtCamSdk.GetFilterValue(ARTCAM_FILTERTYPE_BAYER_GAIN_AUTO, @Error);
  if FALSE = Error then begin
    CheckAWB.Enabled := FALSE;
  end;

  if 0<>Data then begin
    CheckAWB.Checked := TRUE;
  end;


  // Bayer conversion mode
  Error := FALSE;
  Data := m_pCArtCamSdk.GetFilterValue(ARTCAM_FILTERTYPE_BAYERMODE, @Error);
  if FALSE = Error then begin
    RadioBayer1.Enabled := false;
    RadioBayer2.Enabled := false;
    RadioBayer3.Enabled := false;
    RadioBayer4.Enabled := false;
  end;

  case Data of
    0:  RadioBayer1.Checked := true;
    1:  RadioBayer2.Checked := true;
    2:  RadioBayer3.Checked := true;
    3:  RadioBayer4.Checked := true;
  end;


  // Mirror reversal
  if m_pCArtCamSdk.GetMirrorV() then  CheckMirrorV.Checked := true;
  if m_pCArtCamSdk.GetMirrorH() then  CheckMirrorH.Checked := true;

  // Horizotal reversal is only available in 036MI.
  if ARTCAM_CAMERATYPE_036MI <> m_DllType then begin
    CheckMirrorH.Enabled := false;
  end;

  // Vertical reversal is not available in following models.
  case m_DllType of
    ARTCAM_CAMERATYPE_DS,
    ARTCAM_CAMERATYPE_USTC,
    ARTCAM_CAMERATYPE_CNV,
    ARTCAM_CAMERATYPE_150P,
    ARTCAM_CAMERATYPE_150P2,
    ARTCAM_CAMERATYPE_098: begin
      CheckMirrorV.Enabled := false;
    end;
  end;

  // Auto iris
  Error := FALSE;
  Data := m_pCArtCamSdk.GetAutoIris(@Error);
  case AI_TYPE(Data) of
    AI_NONE:      RadioAI1.Checked := true;
    AI_EXPOSURE:  RadioAI2.Checked := true;
    AI_GAIN:      RadioAI3.Checked := true;
  end;

  if FALSE = Error then begin
    RadioAI1.Enabled := false;
    RadioAI2.Enabled := false;
    RadioAI3.Enabled := false;
  end;

  // Camera without shutter function
  case m_DllType of
    ARTCAM_CAMERATYPE_150P,
    ARTCAM_CAMERATYPE_320P,
    ARTCAM_CAMERATYPE_098: begin
      RadioAI2.Enabled := false;
    end;
  end;


  // Half clock
  Error := FALSE;
  if 0 <> m_pCArtCamSdk.GetHalfClock(@Error) then CheckHalfClock.Checked := true;
  if FALSE = Error then begin
    CheckHalfClock.Enabled := false;
  end;


  // Channel
  if ARTCAM_CAMERATYPE_CNV <> m_DllType then begin
    RadioChannel1.Enabled := false;
    RadioChannel2.Enabled := false;
    RadioChannel3.Enabled := false;
    RadioChannel4.Enabled := false;
    RadioChannel5.Enabled := false;
    RadioChannel6.Enabled := false;
  end;

  m_Init := true;
end;

procedure TForm2.InitControl(FilterType: ARTCAM_FILTERTYPE; Edit: TEdit; UpDown: TUpDown; Min: Integer; Max: Integer);
var
  Error: BOOL;
  Data: Integer;
begin
  Error := FALSE;
  Data := m_pCArtCamSdk.GetFilterValue(FilterType, @Error);

  // Error occurrence(no response)
  if FALSE = Error then begin
    Edit.Enabled := FALSE;
    exit;
  end;

  UpDown.Min := Min;
  UpDown.Max := Max;
  Edit.Text := IntToStr(Data);
end;


procedure TForm2.Button1Click(Sender: TObject);
begin
  m_Init := false;
  Hide();
end;

procedure TForm2.CheckAWBClick(Sender: TObject);
begin
  if CheckAWB.Checked then begin
    m_pCArtCamSdk.SetFilterValue(ARTCAM_FILTERTYPE_BAYER_GAIN_AUTO, 1);
  end
  else begin
    m_pCArtCamSdk.SetFilterValue(ARTCAM_FILTERTYPE_BAYER_GAIN_AUTO, 0);
  end;
end;

procedure TForm2.RadioBayer1Click(Sender: TObject); begin m_pCArtCamSdk.SetFilterValue(ARTCAM_FILTERTYPE_BAYERMODE, 0); end;
procedure TForm2.RadioBayer2Click(Sender: TObject); begin m_pCArtCamSdk.SetFilterValue(ARTCAM_FILTERTYPE_BAYERMODE, 1); end;
procedure TForm2.RadioBayer3Click(Sender: TObject); begin m_pCArtCamSdk.SetFilterValue(ARTCAM_FILTERTYPE_BAYERMODE, 2); end;
procedure TForm2.RadioBayer4Click(Sender: TObject); begin m_pCArtCamSdk.SetFilterValue(ARTCAM_FILTERTYPE_BAYERMODE, 3); end;

procedure TForm2.RadioAI1Click(Sender: TObject); begin m_pCArtCamSdk.SetAutoIris(0); end;
procedure TForm2.RadioAI2Click(Sender: TObject); begin m_pCArtCamSdk.SetAutoIris(1); end;
procedure TForm2.RadioAI3Click(Sender: TObject); begin m_pCArtCamSdk.SetAutoIris(2); end;

procedure TForm2.CheckMirrorVClick(Sender: TObject);
begin
  if CheckMirrorV.Checked then begin
    m_pCArtCamSdk.SetMirrorV(TRUE);
  end
  else begin
    m_pCArtCamSdk.SetMirrorV(FALSE);
  end;
end;

procedure TForm2.CheckMirrorHClick(Sender: TObject);
begin
  if CheckMirrorH.Checked then begin
    m_pCArtCamSdk.SetMirrorH(TRUE);
  end
  else begin
    m_pCArtCamSdk.SetMirrorH(FALSE);
  end;
end;

procedure TForm2.CheckHalfClockClick(Sender: TObject);
begin
  if -1 <> m_Preview then begin
    // To switch clock, display needs to be stopped.
    m_pCArtCamSdk.StopPreview();
  end;

  if CheckHalfClock.Checked then begin
    m_pCArtCamSdk.SetHalfClock(1);
  end
  else begin
    m_pCArtCamSdk.SetHalfClock(0);
  end;

  if-1 <> m_Preview then begin;
    // Resume display
    m_pCArtCamSdk.StartPreview();
  end;
end;

procedure TForm2.RadioChannel1Click(Sender: TObject); begin m_pCArtCamSdk.SetCrossbar(0, 0); end;
procedure TForm2.RadioChannel2Click(Sender: TObject); begin m_pCArtCamSdk.SetCrossbar(1, 0); end;
procedure TForm2.RadioChannel3Click(Sender: TObject); begin m_pCArtCamSdk.SetCrossbar(2, 0); end;
procedure TForm2.RadioChannel4Click(Sender: TObject); begin m_pCArtCamSdk.SetCrossbar(3, 0); end;
procedure TForm2.RadioChannel5Click(Sender: TObject); begin m_pCArtCamSdk.SetCrossbar(4, 0); end;
procedure TForm2.RadioChannel6Click(Sender: TObject); begin m_pCArtCamSdk.SetCrossbar(5, 0); end;


procedure TForm2.EditBrightnessChange(Sender: TObject);
begin
  if m_Init then m_pCArtCamSdk.SetBrightness(StrToInt(EditBrightness.Text));
end;


procedure TForm2.EditContrastChange(Sender: TObject);
begin
  if m_Init then m_pCArtCamSdk.SetContrast(StrToInt(EditContrast.Text));
end;


procedure TForm2.EditHueChange(Sender: TObject);
begin
  if m_Init then m_pCArtCamSdk.SetHue(StrToInt(EditHue.Text));
end;


procedure TForm2.EditSaturationChange(Sender: TObject);
begin
  if m_Init then m_pCArtCamSdk.SetSaturation(StrToInt(EditSaturation.Text));
end;


procedure TForm2.EditSharpnessChange(Sender: TObject);
begin
  if m_Init then m_pCArtCamSdk.SetSharpness(StrToInt(EditSharpness.Text));
end;


procedure TForm2.EditGammaChange(Sender: TObject);
begin
  if m_Init then m_pCArtCamSdk.SetGamma(StrToInt(EditGamma.Text));
end;


procedure TForm2.EditBayerGainRChange(Sender: TObject);
begin
  if m_Init then m_pCArtCamSdk.SetBayerGainRed(StrToInt(EditBayerGainR.Text));
end;


procedure TForm2.EditBayerGainGChange(Sender: TObject);
begin
  if m_Init then m_pCArtCamSdk.SetBayerGainGreen(StrToInt(EditBayerGainG.Text));
end;


procedure TForm2.EditBayerGainBChange(Sender: TObject);
begin
  if m_Init then m_pCArtCamSdk.SetBayerGainBlue(StrToInt(EditBayerGainB.Text));
end;


procedure TForm2.EditGlobalGainChange(Sender: TObject);
begin
  if m_Init then m_pCArtCamSdk.SetGlobalGain(StrToInt(EditGlobalGain.Text));
end;


procedure TForm2.EditColorGainRChange(Sender: TObject);
begin
  if m_Init then m_pCArtCamSdk.SetColorGainRed(StrToInt(EditColorGainR.Text));
end;


procedure TForm2.EditColorGainG1Change(Sender: TObject);
begin
  if m_Init then m_pCArtCamSdk.SetColorGainGreen1(StrToInt(EditColorGainG1.Text));
end;


procedure TForm2.EditColorGainG2Change(Sender: TObject);
begin
  if m_Init then m_pCArtCamSdk.SetColorGainGreen2(StrToInt(EditColorGainG2.Text));
end;


procedure TForm2.EditColorGainBChange(Sender: TObject);
begin
  if m_Init then m_pCArtCamSdk.SetColorGainBlue(StrToInt(EditColorGainB.Text));
end;


procedure TForm2.EditExposureTimeChange(Sender: TObject);
begin
  if m_Init then m_pCArtCamSdk.SetExposureTime(StrToInt(EditExposureTime.Text));
end;



end.

unit Unit7;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls, ArtCam, ExtCtrls;

type
  TForm7 = class(TForm)
	CheckColor: TCheckBox;
	CheckAWB: TCheckBox;
	GroupBox1: TGroupBox;
	TrackGainR: TTrackBar;
	EditGainR: TEdit;
	UpDownGainR: TUpDown;
	UpDownGainG: TUpDown;
	EditGainG: TEdit;
	TrackGainG: TTrackBar;
	UpDownGainB: TUpDown;
	EditGainB: TEdit;
	TrackGainB: TTrackBar;
	GroupBox2: TGroupBox;
	Label1: TLabel;
	Label2: TLabel;
	Label3: TLabel;
	GroupBox3: TGroupBox;
	TrackGainGlobal: TTrackBar;
	EditGainGlobal: TEdit;
	UpDownGainGlobal: TUpDown;
	TrackExposureTime: TTrackBar;
	EditExposureTime: TEdit;
	UpDownExposureTime: TUpDown;
	Label4: TLabel;
	Label5: TLabel;
	CheckMirrorV: TCheckBox;
	CheckMirrorH: TCheckBox;
	GroupBox4: TGroupBox;
	RadioCursor_1: TRadioButton;
	RadioCursor_2: TRadioButton;
	CheckCursorOn: TCheckBox;
	TrackPosX: TTrackBar;
	TrackPosY: TTrackBar;
	TrackSizeX: TTrackBar;
	EditPosX: TEdit;
	UpDownPosX: TUpDown;
	EditPosY: TEdit;
	UpDownPosY: TUpDown;
	EditSizeX: TEdit;
	UpDownSizeX: TUpDown;
	TrackSizeY: TTrackBar;
	EditSizeY: TEdit;
	UpDownSizeY: TUpDown;
	Label6: TLabel;
	Label7: TLabel;
	Label8: TLabel;
	Label9: TLabel;
	Image1: TImage;
	ButtonInitSettings: TButton;
	ButtonSaveSettings: TButton;
	ButtonOK: TButton;
	ButtonDefault: TButton;
	ButtonCancel: TButton;
	procedure FormShow(Sender: TObject);
	procedure RadioCursor_1Click(Sender: TObject);
	procedure RadioCursor_2Click(Sender: TObject);
	procedure CheckCursorOnClick(Sender: TObject);
	procedure TrackGainRChange(Sender: TObject);
	procedure TrackGainGChange(Sender: TObject);
	procedure TrackGainBChange(Sender: TObject);
	procedure TrackGainGlobalChange(Sender: TObject);
	procedure TrackExposureTimeChange(Sender: TObject);
	procedure TrackPosXChange(Sender: TObject);
	procedure TrackPosYChange(Sender: TObject);
	procedure TrackSizeXChange(Sender: TObject);
	procedure TrackSizeYChange(Sender: TObject);
	procedure EditGainRChange(Sender: TObject);
	procedure EditGainGChange(Sender: TObject);
	procedure EditGainBChange(Sender: TObject);
	procedure EditGainGlobalChange(Sender: TObject);
	procedure EditExposureTimeChange(Sender: TObject);
	procedure EditPosXChange(Sender: TObject);
	procedure EditPosYChange(Sender: TObject);
	procedure EditSizeXChange(Sender: TObject);
	procedure EditSizeYChange(Sender: TObject);
	procedure CheckMirrorVClick(Sender: TObject);
	procedure CheckMirrorHClick(Sender: TObject);
	procedure CheckColorClick(Sender: TObject);
	procedure CheckAWBClick(Sender: TObject);
	procedure ButtonDefaultClick(Sender: TObject);
	procedure ButtonOKClick(Sender: TObject);
	procedure ButtonCancelClick(Sender: TObject);
	procedure ButtonInitSettingsClick(Sender: TObject);
	procedure ButtonSaveSettingsClick(Sender: TObject);
	procedure FormPaint(Sender: TObject);
	procedure Image1MouseDown(Sender: TObject; Button: TMouseButton; Shift: TShiftState; X: Integer; Y: Integer);
  type POINT = record
    x:  LONG;
    y:  LONG;
  end;
  type _M_CURSOR = record
		Enable:	BOOL;
		SizeX:	LONG;
		SizeY:	LONG;
		Pos:  	POINT;
		Color:	LONG;
  end;
  private
    { Private declarations }
  public
    m_pCArtCamSdk: ^TArtCam;
    m_DllType: ARTCAM_CAMERATYPE;
    m_CursorNumber: Integer;
    m_Init:         BOOL;

	m_Cursor: array[0..1] of _M_CURSOR;

	procedure InitControl(TrackBar: TTrackBar; Edit: TEdit; UpDown: TUpDown; Min: LONG; Max: LONG; Now: LONG; Tic: LONG);
	procedure SetUpDownTrack(UpDown: TUpDown; TrackBar: TTrackBar; Value: LONG);
	procedure ChangeCursor();
	constructor NilSet;
	end;

var
  Form7: TForm7;

implementation

{$R *.dfm}

constructor TForm7.NilSet;
begin
  m_pCArtCamSdk := nil;
  m_Init := FALSE;
end;

procedure TForm7.InitControl(TrackBar: TTrackBar; Edit: TEdit; UpDown: TUpDown; Min: LONG; Max: LONG; Now: LONG; Tic: LONG);
begin
	TrackBar.Min := Min;
	TrackBar.Max := Max;
	TrackBar.SetTick(Tic);
	TrackBar.Position := Now;

	UpDown.Min := Min;
	UpDown.Max := Max;
	UpDown.Position := Now;
	UpDown.Associate := Edit;

	Edit.Text := IntToStr(Now);
end;

procedure TForm7.FormShow(Sender: TObject);
var
	i		:Integer;
	Width 	:LONG;
	Height	:LONG;
  Error : BOOL;
begin
  if nil = m_pCArtCamSdk then begin
    exit;
  end;

  m_Init := FALSE;
  Error := FALSE;
	if(m_pCArtCamSdk.Monitor_GetColorMode(@Error)) then begin
		CheckColor.Checked := true;
	end
	else begin
		CheckAWB.Enabled := false;
	end;

	if(1 = m_pCArtCamSdk.Monitor_GetBayerGainAuto(@Error)) then begin
		CheckAWB.Checked := true;

		TrackGainR.Enabled := false;
		TrackGainG.Enabled := false;
		TrackGainB.Enabled := false;

		EditGainR.Enabled := false;
		EditGainG.Enabled := false;
		EditGainB.Enabled := false;

		UpDownGainR.Enabled := false;
		UpDownGainG.Enabled := false;
		UpDownGainB.Enabled := false;
	end;


	// Bayer
	InitControl(TrackGainR, EditGainR, UpDownGainR, 0, 1023, m_pCArtCamSdk.Monitor_GetBayerGainRed(@Error),   64);
	InitControl(TrackGainG, EditGainG, UpDownGainG, 0, 1023, m_pCArtCamSdk.Monitor_GetBayerGainGreen(@Error), 64);
	InitControl(TrackGainB, EditGainB, UpDownGainB, 0, 1023, m_pCArtCamSdk.Monitor_GetBayerGainBlue(@Error),  64);

	// Gain / Shutter / Mirror
	case (m_DllType) of
		ARTCAM_CAMERATYPE_1000MI_HD2: begin
			InitControl(TrackGainGlobal,   EditGainGlobal, 	UpDownGainGlobal, 0, 127, m_pCArtCamSdk.GetGlobalGain(@Error), 64);
			InitControl(TrackExposureTime, EditExposureTime,UpDownExposureTime, 1, 8191, m_pCArtCamSdk.GetExposureTime(@Error), 64);
			if(m_pCArtCamSdk.GetMirrorV()) then begin	CheckMirrorV.Checked := true;	end;
			if(m_pCArtCamSdk.GetMirrorH()) then begin	CheckMirrorH.Checked := true;	end;
		end;
	end;

	for i:=0 to 1 do begin
		// Show Cursor ON/OFF
		If (1 = m_pCArtCamSdk.Monitor_GetCrossCursorMode(i, @Error)) then begin
      m_Cursor[i].Enable:= true;
    end
    else begin
      m_Cursor[i].Enable:= false;
    end;

		// Position
		m_pCArtCamSdk.Monitor_GetCrossCursorPos(i, @m_Cursor[i].Pos.x, @m_Cursor[i].Pos.y);

		// Size
		m_pCArtCamSdk.Monitor_GetCrossCursorSize(i, @m_Cursor[i].SizeX, @m_Cursor[i].SizeY);

		// Color
		m_Cursor[i].Color := m_pCArtCamSdk.Monitor_GetCrossCursorColorRGB(i, @Error);
	end;
	RadioCursor_1.Checked := true;
	if(m_Cursor[m_CursorNumber].Enable) then begin
  	CheckCursorOn.Checked := true;
  end
	else begin
    CheckCursorOn.Checked := false;
  end;


	Width  := 1280;
	Height := 1024;
	if(ARTCAM_CAMERATYPE_1000MI_HD2 = m_DllType) then begin
		case (m_pCArtCamSdk.Width()) of
		3664,
		1920: begin
			Width := 1920;
			Height := 1080;
		end;
		1280: begin
			Width := 1280;
			Height := 720;
		end;
	  end;
  end;

	InitControl(TrackPosX, EditPosX, UpDownPosX, 0, Width, m_Cursor[m_CursorNumber].Pos.x, 64);
	InitControl(TrackPosY, EditPosY, UpDownPosY, 0, Height, m_Cursor[m_CursorNumber].Pos.y, 64);
	InitControl(TrackSizeX, EditSizeX, UpDownSizeX, 0, 7, m_Cursor[m_CursorNumber].SizeX, 64);
	InitControl(TrackSizeY, EditSizeY, UpDownSizeY, 0, 7, m_Cursor[m_CursorNumber].SizeY, 64);

	Invalidate();

  m_Init := TRUE;
end;

procedure TForm7.SetUpDownTrack(UpDown: TUpDown; TrackBar: TTrackBar; Value: LONG);
begin
	TrackBar.Position := Value;
	UpDown.Position := Value;
end;

procedure TForm7.ChangeCursor();
var
	Flg: BOOL;
begin
	if(m_Cursor[m_CursorNumber].Enable) then begin	CheckCursorOn.Checked := true; end
	else begin										CheckCursorOn.Checked := false; end;

	Flg := m_Cursor[m_CursorNumber].Enable;

	TrackPosX.Enabled := Flg;	UpDownPosX.Enabled := Flg;	EditPosX.Enabled := Flg;
	TrackPosY.Enabled := Flg;	UpDownPosY.Enabled := Flg;	EditPosY.Enabled := Flg;
	TrackSizeX.Enabled := Flg;	UpDownSizeX.Enabled := Flg;	EditSizeX.Enabled := Flg;
	TrackSizeY.Enabled := Flg;	UpDownSizeY.Enabled := Flg;	EditSizeY.Enabled := Flg;

	EditPosX.Text := IntToStr(m_Cursor[m_CursorNumber].Pos.x);
	EditPosY.Text := IntToStr(m_Cursor[m_CursorNumber].Pos.y);
	EditSizeX.Text := IntToStr(m_Cursor[m_CursorNumber].SizeX);
	EditSizeY.Text := IntToStr(m_Cursor[m_CursorNumber].SizeY);

	Invalidate();
end;

procedure TForm7.RadioCursor_1Click(Sender: TObject);
begin
	m_CursorNumber := 0;
	ChangeCursor();
end;

procedure TForm7.RadioCursor_2Click(Sender: TObject);
begin
	m_CursorNumber := 1;
	ChangeCursor();
end;

procedure TForm7.CheckCursorOnClick(Sender: TObject);
var
	Flg: Integer;
begin
  If(CheckCursorOn.Checked) then begin  Flg := 1; end
  Else begin  Flg := 0; end;
	m_pCArtCamSdk.Monitor_SetCrossCursorMode(m_CursorNumber, Flg);
	m_Cursor[m_CursorNumber].Enable := CheckCursorOn.Checked;
	ChangeCursor();
end;

procedure TForm7.TrackGainRChange(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	EditGainR.Text := IntToStr(TrackGainR.Position);
end;

procedure TForm7.TrackGainGChange(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	EditGainG.Text := IntToStr(TrackGainG.Position);
end;

procedure TForm7.TrackGainBChange(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	EditGainB.Text := IntToStr(TrackGainB.Position);
end;

procedure TForm7.TrackGainGlobalChange(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	EditGainGlobal.Text := IntToStr(TrackGainGlobal.Position);
end;

procedure TForm7.TrackExposureTimeChange(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	EditExposureTime.Text := IntToStr(TrackExposureTime.Position);
end;

procedure TForm7.TrackPosXChange(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	EditPosX.Text := IntToStr(TrackPosX.Position);
end;

procedure TForm7.TrackPosYChange(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	EditPosY.Text := IntToStr(TrackPosY.Position);
end;

procedure TForm7.TrackSizeXChange(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	EditSizeX.Text := IntToStr(TrackSizeX.Position);
end;

procedure TForm7.TrackSizeYChange(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	EditSizeY.Text := IntToStr(TrackSizeY.Position);
end;

procedure TForm7.EditGainRChange(Sender: TObject);
var
	Value: Integer;
begin
  if(false = m_Init) then begin exit; end;
	Value := StrToInt(EditGainR.Text);
	SetUpDownTrack(UpDownGainR, TrackGainR, Value);
	m_pCArtCamSdk.Monitor_SetBayerGainRed(Value);
end;

procedure TForm7.EditGainGChange(Sender: TObject);
var
	Value: Integer;
begin
  if(false = m_Init) then begin exit; end;
	Value := StrToInt(EditGainG.Text);
	SetUpDownTrack(UpDownGainG, TrackGainG, Value);
	m_pCArtCamSdk.Monitor_SetBayerGainGreen(Value);
end;

procedure TForm7.EditGainBChange(Sender: TObject);
var
	Value: Integer;
begin
  if(false = m_Init) then begin exit; end;
	Value := StrToInt(EditGainB.Text);
	SetUpDownTrack(UpDownGainB, TrackGainB, Value);
	m_pCArtCamSdk.Monitor_SetBayerGainBlue(Value);
end;

procedure TForm7.EditGainGlobalChange(Sender: TObject);
var
	Value: Integer;
begin
  if(false = m_Init) then begin exit; end;
	Value := StrToInt(EditGainGlobal.Text);
	SetUpDownTrack(UpDownGainGlobal, TrackGainGlobal, Value);
	m_pCArtCamSdk.SetGlobalGain(Value);
end;

procedure TForm7.EditExposureTimeChange(Sender: TObject);
var
	Value: Integer;
begin
  if(false = m_Init) then begin exit; end;
	Value := StrToInt(EditExposureTime.Text);
	SetUpDownTrack(UpDownExposureTime, TrackExposureTime, Value);
	m_pCArtCamSdk.SetExposureTime(Value);
end;

procedure TForm7.EditPosXChange(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	m_Cursor[m_CursorNumber].Pos.x := StrToInt(EditPosX.Text);
	SetUpDownTrack(UpDownPosX, TrackPosX, m_Cursor[m_CursorNumber].Pos.x);
	m_pCArtCamSdk.Monitor_SetCrossCursorPos(m_CursorNumber, m_Cursor[m_CursorNumber].Pos.x, m_Cursor[m_CursorNumber].Pos.y);
end;

procedure TForm7.EditPosYChange(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	m_Cursor[m_CursorNumber].Pos.y := StrToInt(EditPosY.Text);
	SetUpDownTrack(UpDownPosY, TrackPosY, m_Cursor[m_CursorNumber].Pos.y);
	m_pCArtCamSdk.Monitor_SetCrossCursorPos(m_CursorNumber, m_Cursor[m_CursorNumber].Pos.x, m_Cursor[m_CursorNumber].Pos.y);
end;

procedure TForm7.EditSizeXChange(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	m_Cursor[m_CursorNumber].SizeX := StrToInt(EditSizeX.Text);
	SetUpDownTrack(UpDownSizeX, TrackSizeX, m_Cursor[m_CursorNumber].SizeX);
	m_pCArtCamSdk.Monitor_SetCrossCursorSize(m_CursorNumber, m_Cursor[m_CursorNumber].SizeX, m_Cursor[m_CursorNumber].SizeY);
end;

procedure TForm7.EditSizeYChange(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	m_Cursor[m_CursorNumber].SizeY := StrToInt(EditSizeY.Text);
	SetUpDownTrack(UpDownSizeY, TrackSizeY, m_Cursor[m_CursorNumber].SizeY);
	m_pCArtCamSdk.Monitor_SetCrossCursorSize(m_CursorNumber, m_Cursor[m_CursorNumber].SizeX, m_Cursor[m_CursorNumber].SizeY);
end;

procedure TForm7.CheckMirrorVClick(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	m_pCArtCamSdk.SetMirrorV(CheckMirrorV.Checked);
end;

procedure TForm7.CheckMirrorHClick(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	m_pCArtCamSdk.SetMirrorH(CheckMirrorH.Checked);
end;

procedure TForm7.CheckColorClick(Sender: TObject);
begin
  if(false = m_Init) then begin exit; end;
	CheckAWBClick(Sender);
end;

procedure TForm7.CheckAWBClick(Sender: TObject);
var
	Color: BOOL;
	AWB : BOOL;
  Flg: BOOL;
  Error: BOOL;
begin
  if(false = m_Init) then begin exit; end;
	Color := CheckColor.Checked;
	AWB := CheckAWB.Checked;

	m_pCArtCamSdk.Monitor_SetColorMode(Color);
  if AWB then begin	m_pCArtCamSdk.Monitor_SetBayerGainAuto(1);  End
  Else begin        m_pCArtCamSdk.Monitor_SetBayerGainAuto(0);  End;

  Flg := Color And (Not AWB);
	TrackGainR.Enabled := (Flg);
	TrackGainG.Enabled := (Flg);
	TrackGainB.Enabled := (Flg);

	EditGainR.Enabled := (Flg);
	EditGainG.Enabled := (Flg);
	EditGainB.Enabled := (Flg);

	UpDownGainR.Enabled := (Flg);
	UpDownGainG.Enabled := (Flg);
	UpDownGainB.Enabled := (Flg);

	if(true = Flg)then begin
		SetUpDownTrack(UpDownGainR,	TrackGainR,	m_pCArtCamSdk.Monitor_GetBayerGainRed(@Error) 	);
		SetUpDownTrack(UpDownGainG,	TrackGainG,	m_pCArtCamSdk.Monitor_GetBayerGainGreen(@Error)	);
		SetUpDownTrack(UpDownGainB,	TrackGainB,	m_pCArtCamSdk.Monitor_GetBayerGainBlue(@Error)	);
	end;

end;

procedure TForm7.ButtonDefaultClick(Sender: TObject);
begin
	case (m_DllType) of
	ARTCAM_CAMERATYPE_1000MI_HD2: begin
		// Bayer
		SetUpDownTrack(UpDownGainR,			TrackGainR,	256);
		SetUpDownTrack(UpDownGainG,			TrackGainG,	256);
		SetUpDownTrack(UpDownGainB,			TrackGainB,	256);
		SetUpDownTrack(UpDownGainGlobal,	TrackGainGlobal,	64);
		SetUpDownTrack(UpDownExposureTime,	TrackExposureTime,	2748);

		SetUpDownTrack(UpDownPosX, TrackPosX,	360);
		SetUpDownTrack(UpDownPosY, TrackPosY,	360);
		SetUpDownTrack(UpDownSizeX, TrackSizeX,	4);
		SetUpDownTrack(UpDownSizeY, TrackSizeY,	4);
	end;
	end;
end;

procedure TForm7.ButtonOKClick(Sender: TObject);
begin
	Close();
end;

procedure TForm7.ButtonCancelClick(Sender: TObject);
begin
	Close();
end;

procedure TForm7.ButtonInitSettingsClick(Sender: TObject);
var
  Error:  BOOL;
	i:		Integer;
begin
	m_pCArtCamSdk.Monitor_InitRegisterSettings(0);

	SetUpDownTrack(UpDownGainR,	TrackGainR,	m_pCArtCamSdk.Monitor_GetBayerGainRed(@Error)	  );
	SetUpDownTrack(UpDownGainG,	TrackGainG,	m_pCArtCamSdk.Monitor_GetBayerGainGreen(@Error)	);
	SetUpDownTrack(UpDownGainB,	TrackGainB,	m_pCArtCamSdk.Monitor_GetBayerGainBlue(@Error)	);

	for i := 0 To 1 do begin
		If (1 = m_pCArtCamSdk.Monitor_GetCrossCursorMode(i, @Error)) then begin m_Cursor[i].Enable := true; end else begin m_Cursor[i].Enable := false; end;
		m_pCArtCamSdk.Monitor_GetCrossCursorPos(i, @m_Cursor[i].Pos.x, @m_Cursor[i].Pos.y);
		m_pCArtCamSdk.Monitor_GetCrossCursorSize(i, @m_Cursor[i].SizeX, @m_Cursor[i].SizeY);
		m_Cursor[i].Color := m_pCArtCamSdk.Monitor_GetCrossCursorColorRGB(i, @Error);
	end;
	CheckCursorOn.Checked := m_Cursor[m_CursorNumber].Enable;

	SetUpDownTrack(UpDownPosX, TrackPosX,	m_Cursor[m_CursorNumber].Pos.x);
	SetUpDownTrack(UpDownPosY, TrackPosY,	m_Cursor[m_CursorNumber].Pos.y);
	SetUpDownTrack(UpDownSizeX, TrackSizeX,	m_Cursor[m_CursorNumber].SizeX);
	SetUpDownTrack(UpDownSizeY, TrackSizeY,	m_Cursor[m_CursorNumber].SizeY);

	Invalidate();

end;

procedure TForm7.ButtonSaveSettingsClick(Sender: TObject);
begin
	m_pCArtCamSdk.Monitor_SaveCurrentSettings();
end;

procedure TForm7.FormPaint(Sender: TObject);
var
	color:	LONG;
	w:		Integer;
	rc:		TRect;
	rc1:	TRect;
  Error:  BOOL;
	i:		Integer;
const
  arColor: array[0..15] Of COLORREF = (
		$00FFFFFF,
		$00000000,
		$0000FFFF,
		$000000FF,
		$00FF0000,
		$0000FF00,
		$00004080,
		$00808080,
		$00FF8000,
		$00FF0080,
		$00FF80FF,
		$00008080,
		$00400080,
		$00FFFF80,
		$000080FF,
		$00808040
  );

begin

	Image1.Canvas.Pen.Color := clBlack;
	Image1.Canvas.Rectangle(Image1.ClientRect);

	rc := Image1.ClientRect;
	Inc(rc.Left);  Inc(rc.Top);
	Dec(rc.Right); Dec(rc.Bottom);
	color := m_pCArtCamSdk.Monitor_GetCrossCursorColorRGB(m_CursorNumber, @Error);
	w := Trunc((rc.right - rc.left) / 16);

	for i := 0 To 15 do begin
		rc1.left := rc.left+w*i;		rc1.top := rc.top;
		rc1.right :=rc.left+w*(i+1);	rc1.bottom := rc.bottom;
		if(15=i) then begin rc1.right := rc.right;	end;
		Image1.Canvas.Brush.Color := arColor[i];
		Image1.Canvas.FillRect(rc1);

		if(color = i) then begin
			Image1.Canvas.Pen.Color := clRed;
			Image1.Canvas.Rectangle(rc1);
		end;
	end;

end;

procedure TForm7.Image1MouseDown(Sender: TObject; Button: TMouseButton; Shift: TShiftState; X: Integer; Y: Integer);
var
	w:		LONG;
	rc:		TRect;
	rc1:	TRect;
	i:		Integer;
begin
	rc := Image1.ClientRect;
	Inc(rc.Left);  Inc(rc.Top);
	Dec(rc.Right); Dec(rc.Bottom);
	w := Trunc((rc.right - rc.left) / 16);

	for i := 0 To 15 do begin
		rc1.left := rc.left+w*i;		rc1.top := rc.top;
		rc1.right :=rc.left+w*(i+1);	rc1.bottom := rc.bottom;
		if(15=i) then begin rc1.right := rc.right; end;
		if((rc1.left<X) And (X<rc1.right) And (rc1.top<Y) And (Y<rc1.Bottom)) then begin
			m_pCArtCamSdk.Monitor_SetCrossCursorColorRGB(m_CursorNumber, i);
			Invalidate();
			break;
			end;
	end;
end;

end.

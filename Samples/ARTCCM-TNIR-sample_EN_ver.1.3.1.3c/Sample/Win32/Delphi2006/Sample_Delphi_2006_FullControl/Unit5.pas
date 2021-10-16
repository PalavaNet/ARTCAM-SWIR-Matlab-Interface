unit Unit5;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls, ArtCam;

type
  TForm5 = class(TForm)
    ComboBox1: TComboBox;
    ComboBox2: TComboBox;
    CheckBox1: TCheckBox;
    CheckBox2: TCheckBox;
    CheckBox3: TCheckBox;
    CheckBox4: TCheckBox;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    TrackBar1: TTrackBar;
    TrackBar2: TTrackBar;
    TrackBar3: TTrackBar;
    TrackBar4: TTrackBar;
    TrackBar5: TTrackBar;
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
    Edit5: TEdit;
    Button5: TButton;
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    procedure Button3Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure TrackBar5Change(Sender: TObject);
    procedure TrackBar4Change(Sender: TObject);
    procedure TrackBar3Change(Sender: TObject);
    procedure TrackBar2Change(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure KeyValueCheck(Sender: TObject; var Key: Char);
    procedure Edit1Change(Sender: TObject);
    procedure Edit2Change(Sender: TObject);
    procedure Edit3Change(Sender: TObject);
    procedure Edit4Change(Sender: TObject);
    procedure Edit5Change(Sender: TObject);
    procedure TrackBar1Change(Sender: TObject);
    procedure ComboBox2Change(Sender: TObject);
    procedure ComboBox1Change(Sender: TObject);
    procedure CheckBox4Click(Sender: TObject);
    procedure CheckBox3Click(Sender: TObject);
    procedure CheckBox2Click(Sender: TObject);
    procedure CheckBox1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure FormShow(Sender: TObject);

  private
    { Private declarations }
  public
    m_pCArtCamSdk: ^TArtCam;

  constructor NilSet;
  
  end;

var
  Form5: TForm5;
  lRed :          LONG;
  lBlue:          LONG;
  lGreen:         LONG;
  lGlobalGain:    LONG;
  lShutterWidth:  LONG;


implementation

{$R *.dfm}

constructor TForm5.NilSet;
begin
  m_pCArtCamSdk := nil;
end;

procedure TForm5.FormCreate(Sender: TObject);
begin
  SetWindowLong(Edit1.Handle,GWL_STYLE,
                GetWindowLong(Edit1.Handle,GWL_STYLE)
                or ES_RIGHT
                or ES_NUMBER);
  SetWindowPos(Edit1.Handle,0,0,0,0,0,
               SWP_NOMOVE or SWP_NOSIZE or
               SWP_NOZORDER or SWP_FRAMECHANGED);

  SetWindowLong(Edit2.Handle,GWL_STYLE,
                GetWindowLong(Edit2.Handle,GWL_STYLE)
                or ES_RIGHT
                or ES_NUMBER);
  SetWindowPos(Edit2.Handle,0,0,0,0,0,
               SWP_NOMOVE or SWP_NOSIZE or
               SWP_NOZORDER or SWP_FRAMECHANGED);

  SetWindowLong(Edit3.Handle,GWL_STYLE,
                GetWindowLong(Edit3.Handle,GWL_STYLE)
                or ES_RIGHT
                or ES_NUMBER);
  SetWindowPos(Edit3.Handle,0,0,0,0,0,
               SWP_NOMOVE or SWP_NOSIZE or
               SWP_NOZORDER or SWP_FRAMECHANGED);

  SetWindowLong(Edit4.Handle,GWL_STYLE,
                GetWindowLong(Edit4.Handle,GWL_STYLE)
                or ES_RIGHT
                or ES_NUMBER);
  SetWindowPos(Edit4.Handle,0,0,0,0,0,
               SWP_NOMOVE or SWP_NOSIZE or
               SWP_NOZORDER or SWP_FRAMECHANGED);

  SetWindowLong(Edit5.Handle,GWL_STYLE,
                GetWindowLong(Edit5.Handle,GWL_STYLE)
                or ES_RIGHT
                or ES_NUMBER);
  SetWindowPos(Edit5.Handle,0,0,0,0,0,
               SWP_NOMOVE or SWP_NOSIZE or
               SWP_NOZORDER or SWP_FRAMECHANGED);
end;

procedure TForm5.TrackBar1Change(Sender: TObject);
begin
    lRed := TrackBar1.Position;
    m_pCArtCamSdk.Monitor_SetBayerGainRed(lRed);
    Edit1.Text := IntToStr(lRed);
end;

procedure TForm5.TrackBar2Change(Sender: TObject);
begin
    lGreen := TrackBar2.Position;
    m_pCArtCamSdk.Monitor_SetBayerGainGreen(lGreen);
    Edit2.Text := IntToStr(lGreen);
end;

procedure TForm5.TrackBar3Change(Sender: TObject);
begin
    lBlue := TrackBar3.Position;
    m_pCArtCamSdk.Monitor_SetBayerGainBlue(lBlue);
    Edit3.Text := IntToStr(lBlue);
end;

procedure TForm5.TrackBar4Change(Sender: TObject);
begin
    lGlobalGain := TrackBar4.Position;
    m_pCArtCamSdk.SetGlobalGain(lGlobalGain);
    Edit4.Text := IntToStr(lGlobalGain);
end;

procedure TForm5.TrackBar5Change(Sender: TObject);
begin
    lShutterWidth := TrackBar5.Position;
    m_pCArtCamSdk.SetExposureTime(lShutterWidth);
    Edit5.Text := IntToStr(lShutterWidth);
end;

procedure TForm5.Button1Click(Sender: TObject);
begin
    m_pCArtCamSdk.Monitor_SetPreviewMode(true);
end;

procedure TForm5.Button2Click(Sender: TObject);
begin
  m_pCArtCamSdk.Monitor_SetPreviewMode(false);
end;

procedure TForm5.Button3Click(Sender: TObject);
var dwVFlip: DWORD;
    wReg0xE4: DWORD;
begin
	//
	lShutterWidth	:= m_pCArtCamSdk.GetExposureTime(nil);
	lGlobalGain		:= m_pCArtCamSdk.GetGlobalGain(nil);
	dwVFlip	:= m_pCArtCamSdk.ReadRegister($20,nil);

	// 
	m_pCArtCamSdk.Fpga_WriteRegister($B6, $03);

	// Shutter
	m_pCArtCamSdk.Fpga_WriteRegister($C0, $09);
	m_pCArtCamSdk.Fpga_WriteRegister($C1, BYTE(lShutterWidth shr 8));
	m_pCArtCamSdk.Fpga_WriteRegister($C2, BYTE(lShutterWidth));

	// Gain
	m_pCArtCamSdk.Fpga_WriteRegister($C3, $35);
	m_pCArtCamSdk.Fpga_WriteRegister($C4, BYTE(lGlobalGain shr 8));
	m_pCArtCamSdk.Fpga_WriteRegister($C5, BYTE(lGlobalGain));

	// Vertical mirror
	m_pCArtCamSdk.Fpga_WriteRegister($C6, $20);
	m_pCArtCamSdk.Fpga_WriteRegister($C7, BYTE(dwVFlip shr 8));
	m_pCArtCamSdk.Fpga_WriteRegister($C8, BYTE(dwVFlip));


	//
  wReg0xE4 := m_pCArtCamSdk.Fpga_ReadRegister($E4,nil);

	wReg0xE4 := wReg0xE4 or $0001;
	m_pCArtCamSdk.Fpga_WriteRegister($E4, wReg0xE4);
	wReg0xE4 := wReg0xE4 and $FFFE;
	m_pCArtCamSdk.Fpga_WriteRegister($E4, wReg0xE4);
                                              

end;

procedure TForm5.Button5Click(Sender: TObject);
begin
  Hide;
end;

procedure TForm5.CheckBox1Click(Sender: TObject);
begin
  m_pCArtCamSdk.Monitor_SetColorMode(CheckBox1.Checked);
end;

procedure TForm5.CheckBox2Click(Sender: TObject);
begin
  if (CheckBox2.Checked) then begin
  m_pCArtCamSdk.Monitor_SetBayerGainAuto(1);
  end
  else begin
  m_pCArtCamSdk.Monitor_SetBayerGainAuto(0);
  end;
end;

procedure TForm5.CheckBox3Click(Sender: TObject);
begin
  if (CheckBox3.Checked)  then begin
    m_pCArtCamSdk.Monitor_SetBayerGainLock(1);
  end
  else begin
    m_pCArtCamSdk.Monitor_SetBayerGainLock(0);
  end;
end;

procedure TForm5.CheckBox4Click(Sender: TObject);
begin
    m_pCArtCamSdk.SetMirrorV(CheckBox4.Checked)
end;

procedure TForm5.ComboBox1Change(Sender: TObject);
begin
  m_pCArtCamSdk.Monitor_SetCameraClock(ComboBox1.ItemIndex);
end;

procedure TForm5.ComboBox2Change(Sender: TObject);
begin
  case ComboBox2.ItemIndex of
    0: begin
       m_pCArtCamSdk.Monitor_SetPreviewSize(800,600);
       end;
    1: begin
      m_pCArtCamSdk.Monitor_SetPreviewSize(1024,768);
    end;
    else begin
      m_pCArtCamSdk.Monitor_SetPreviewSize(1280,1024);
    end;

  end;
end;

procedure TForm5.KeyValueCheck(Sender: TObject; var Key: Char);
begin
  if  (Key < '0') or (Key > '9') then Key:= #0;
end;

procedure TForm5.Edit1Change(Sender: TObject);
begin
  if not (Edit1.Text = '') then begin
    m_pCArtCamSdk.Monitor_SetBayerGainRed(StrToInt(Edit1.Text));
  end;
end;

procedure TForm5.Edit2Change(Sender: TObject);
begin
  if not (Edit2.Text = '') then begin
    m_pCArtCamSdk.Monitor_SetBayerGainGreen(StrToInt(Edit2.Text));
  end;
end;

procedure TForm5.Edit3Change(Sender: TObject);
begin
  if not (Edit3.Text = '') then begin
    m_pCArtCamSdk.Monitor_SetBayerGainBlue(StrToInt(Edit3.Text));
  end;
end;

procedure TForm5.Edit4Change(Sender: TObject);
begin
  if not (Edit4.Text = '') then begin
    m_pCArtCamSdk.SetGlobalGain(StrToInt(Edit4.Text));
  end;
end;

procedure TForm5.Edit5Change(Sender: TObject);
begin
  if not (Edit5.Text = '') then begin
    m_pCArtCamSdk.SetExposureTime(StrToInt(Edit5.Text));
  end;
end;

procedure TForm5.FormShow(Sender: TObject);
var
  pWidth:  integer;
  pHeight: integer;
begin
  if nil = m_pCArtCamSdk then begin
    exit;
  end;

  case m_pCArtCamSdk.Monitor_GetCameraClock(nil) of
     2: begin
        ComboBox1.ItemIndex := 1;
     end;
     5: begin
        ComboBox1.ItemIndex := 2;
     end;

     else begin
        ComboBox1.ItemIndex := 0;
     end;
  end;

  m_pCArtCamSdk.Monitor_GetPreviewSize(@pWidth,@pHeight);
    case pWidth of
      800: begin
        ComboBox2.ItemIndex :=0;
      end;
      1024: begin
        ComboBox2.ItemIndex :=1;
      end;
      else begin
        ComboBox2.ItemIndex :=2;
      end;
    end;

  CheckBox1.Checked := m_pCArtCamSdk.Monitor_GetColorMode(nil);

  if (m_pCArtCamSdk.Monitor_GetBayerGainAuto(nil) = 1) then begin
    CheckBox2.Checked :=true;
  end
  else begin
    CheckBox2.Checked := false;
  end;

  if (m_pCArtCamSdk.Monitor_GetBayerGainLock(nil) = 1) then begin
    CheckBox3.Checked :=true;
  end
  else begin
    CheckBox3.Checked := false;
  end;

   CheckBox4.Checked := m_pCArtCamSdk.GetMirrorV();


   lRed  := m_pCArtCamSdk.Monitor_GetBayerGainRed(nil);
   lBlue := m_pCArtCamSdk.Monitor_GetBayerGainBlue(nil);
   lGreen:= m_pCArtCamSdk.Monitor_GetBayerGainGreen(nil);

   TrackBar1.Position := lRed;
   TrackBar2.Position := lGreen;
   TrackBar3.Position := lBlue;

   Edit1.Text := IntToStr(lRed);
   Edit2.Text := IntToStr(lGreen);
   Edit3.Text := IntToStr(lBlue);


   lGlobalGain   := m_pCArtCamSdk.GetGlobalGain(nil);
   lShutterWidth := m_pCArtCamSdk.GetExposureTime(nil);

   TrackBar4.Position := lGlobalGain;
   TrackBar5.Position := lShutterWidth;

   Edit4.Text := IntToStr(lGlobalGain);
   Edit5.Text := IntToStr(lShutterWidth);



  end;

end.

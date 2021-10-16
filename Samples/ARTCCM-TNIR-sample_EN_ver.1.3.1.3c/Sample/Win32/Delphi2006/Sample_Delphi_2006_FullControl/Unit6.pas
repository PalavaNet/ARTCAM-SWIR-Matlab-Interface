unit Unit6;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ArtCam, StdCtrls;

type
  TForm6 = class(TForm)
	checkCorrectionEnable: TCheckBox;
	checkDotfilterEnable: TCheckBox;
	buttonUpdateLow: TButton;
	buttonUpdateHigh: TButton;
	buttonSaveMask: TButton;
	buttonLoadMask: TButton;
	buttonOK: TButton;
	GroupBox1: TGroupBox;
	SaveDialog1: TSaveDialog;
	OpenDialog1: TOpenDialog;
    procedure buttonOKClick(Sender: TObject);
  procedure FormShow(Sender: TObject);
	procedure buttonUpdateLowClick(Sender: TObject);
	procedure buttonUpdateHighClick(Sender: TObject);
	procedure buttonSaveMaskClick(Sender: TObject);
	procedure buttonLoadMaskClick(Sender: TObject);
	procedure checkCorrectionEnableClick(Sender: TObject);
	procedure checkDotfilterEnableClick(Sender: TObject);
  private
    { Private declarations }
  public
    m_pCArtCamSdk: ^TArtCam;
    constructor NilSet;
  end;

var
  Form6: TForm6;

implementation

{$R *.dfm}

constructor TForm6.NilSet;
begin
  m_pCArtCamSdk := nil;
end;

procedure TForm6.FormShow(Sender: TObject);
var
  MaskFilter: Integer;
  DotFilter: Integer;
  Error : BOOL;
begin
  if nil = m_pCArtCamSdk then begin
    exit;
  end;

  Error := FALSE;
	MaskFilter := m_pCArtCamSdk.GetMaskFilter(@Error);
	DotFilter := m_pCArtCamSdk.GetDotFilter(@Error);
	if(1 = DotFilter)	then begin checkDotfilterEnable.Checked := true;  end;
	if(1 = MaskFilter)then begin checkCorrectionEnable.Checked := true; end;
end;

procedure TForm6.buttonUpdateLowClick(Sender: TObject);
begin
	m_pCArtCamSdk.UpdateMaskData(MASKTYPE_LOW);
end;

procedure TForm6.buttonUpdateHighClick(Sender: TObject);
begin
	m_pCArtCamSdk.UpdateMaskData(MASKTYPE_HIGH);
end;

procedure TForm6.buttonOKClick(Sender: TObject);
begin
  Form6.Close();
end;

procedure TForm6.buttonSaveMaskClick(Sender: TObject);
var
  Path: String;
  Ext: String;
  Body: String;
begin
	SaveDialog1.DefaultExt := 'msk';
	SaveDialog1.FileName := 'Default.msk';
	SaveDialog1.Filter := 'MSK file(*.msk)|*.msk||';
	SaveDialog1.Options := [ofOverWritePrompt];

	if SaveDialog1.Execute() then begin
		// Set extension yourselfSet extension yourself.
		Path := ExtractFilePath(SaveDialog1.FileName);
		Ext := ExtractFileExt(SaveDialog1.FileName);

		// Generate file name without extension
		Body := Copy(name, 1, length(Path)-length(Ext));
		Path := Body + '.msk'; 

		m_pCArtCamSdk.SaveMaskFile(PAnsiChar(Path));
	end;

end;

procedure TForm6.buttonLoadMaskClick(Sender: TObject);
begin
	OpenDialog1.DefaultExt := 'msk';
	OpenDialog1.FileName := 'Default.msk';
	OpenDialog1.Filter := 'MSK file(*.msk)|*.msk||';
	OpenDialog1.Options := [ofOverWritePrompt];

	if OpenDialog1.Execute() then begin
		m_pCArtCamSdk.LoadMaskFile(PAnsiChar(OpenDialog1.FileName));
	end;

end;

procedure TForm6.checkCorrectionEnableClick(Sender: TObject);
var
  Enable: Integer;
begin
  if checkCorrectionEnable.Checked = true then begin Enable := 1; end else begin Enable := 0; end;
	m_pCArtCamSdk.SetMaskFilter(Enable);

end;

procedure TForm6.checkDotfilterEnableClick(Sender: TObject);
var
  Enable: Integer;
begin
  if checkDotfilterEnable.Checked = true then begin Enable := 1; end else begin Enable := 0; end;
	m_pCArtCamSdk.SetDotFilter(Enable);
end;



end.

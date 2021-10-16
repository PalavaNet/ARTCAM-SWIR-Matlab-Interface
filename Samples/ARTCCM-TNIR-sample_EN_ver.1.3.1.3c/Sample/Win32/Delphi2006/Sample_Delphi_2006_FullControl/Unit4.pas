unit Unit4;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ArtCam;

type
  TForm4 = class(TForm)
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    CheckRead1: TCheckBox;
    CheckRead2: TCheckBox;
    CheckRead3: TCheckBox;
    CheckRead4: TCheckBox;
    CheckRead5: TCheckBox;
    CheckRead6: TCheckBox;
    CheckRead7: TCheckBox;
    CheckRead8: TCheckBox;
    CheckWrite1: TCheckBox;
    CheckWrite2: TCheckBox;
    CheckWrite3: TCheckBox;
    CheckWrite4: TCheckBox;
    CheckWrite5: TCheckBox;
    CheckWrite6: TCheckBox;
    CheckWrite7: TCheckBox;
    CheckWrite8: TCheckBox;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    procedure FormShow(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declaration }
  public
    m_pCArtCamSdk: ^TArtCam;
    m_DllType: ARTCAM_CAMERATYPE;
  end;

var
  Form4: TForm4;

implementation

{$R *.dfm}

procedure TForm4.FormShow(Sender: TObject);
begin
  if nil = m_pCArtCamSdk then begin
    exit;
  end;

  // Change operation for each DLL
  // For each DLL function, please refer to manual.
  m_DllType := ARTCAM_CAMERATYPE(HIWORD(m_pCArtCamSdk.GetDllVersion()));


  case m_DllType of
    ARTCAM_CAMERATYPE_130MI,
    ARTCAM_CAMERATYPE_200MI,
    ARTCAM_CAMERATYPE_300MI: begin

	 		Button1.Enabled := TRUE;
			CheckRead1.Enabled := TRUE;
			CheckRead2.Enabled := TRUE;
			CheckRead3.Enabled := TRUE;
			CheckRead4.Enabled := TRUE;
			CheckRead5.Enabled := TRUE;
			CheckRead6.Enabled := TRUE;
			CheckRead7.Enabled := TRUE;
			CheckRead8.Enabled := TRUE;

			Button2.Enabled := TRUE;
			CheckWrite1.Enabled := TRUE;
			CheckWrite2.Enabled := TRUE;
			CheckWrite3.Enabled := TRUE;
			CheckWrite4.Enabled := TRUE;
			CheckWrite5.Enabled := TRUE;
			CheckWrite6.Enabled := TRUE;
			CheckWrite7.Enabled := TRUE;
			CheckWrite8.Enabled := TRUE;
  end;

end;
end;

procedure TForm4.Button1Click(Sender: TObject);
begin
//  Read
end;

procedure TForm4.Button2Click(Sender: TObject);
begin
//  Write
end;

procedure TForm4.Button3Click(Sender: TObject);
begin
  Hide;
end;

end.

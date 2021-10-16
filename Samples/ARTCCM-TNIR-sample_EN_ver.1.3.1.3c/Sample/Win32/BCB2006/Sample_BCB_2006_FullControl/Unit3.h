//---------------------------------------------------------------------------

#ifndef Unit3H
#define Unit3H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include "CArtCamSdk.hpp"
//---------------------------------------------------------------------------
class TForm3 : public TForm
{
__published:	// Component for admistering IDE
    TGroupBox *GroupBox1;
    TLabel *Label1;
    TLabel *Label2;
    TLabel *Label3;
    TLabel *Label4;
    TLabel *Label5;
    TEdit *EditHT;
    TEdit *EditHE;
    TEdit *EditHS;
    TEdit *EditVT;
    TEdit *EditVS;
    TEdit *EditVE;
    TGroupBox *GroupBox2;
    TRadioButton *RadioSubSample1;
    TRadioButton *RadioSubSample2;
    TRadioButton *RadioSubSample4;
    TRadioButton *RadioSubSample8;
    TGroupBox *GroupBox3;
    TLabel *LabelVideo;
    TGroupBox *GroupBox4;
    TGroupBox *GroupBox5;
    TRadioButton *RadioChannel1;
    TRadioButton *RadioChannel2;
    TRadioButton *RadioChannel3;
    TRadioButton *RadioChannel4;
    TRadioButton *RadioChannel5;
    TRadioButton *RadioChannel6;
    TRadioButton *RadioRateWH;
    TRadioButton *RadioRateWL;
    TRadioButton *RadioRateNH;
    TRadioButton *RadioRateNL;
    TGroupBox *GroupBox6;
    TRadioButton *RadioColor08;
    TRadioButton *RadioColor16;
    TRadioButton *RadioColor24;
    TRadioButton *RadioColor48;
    TRadioButton *RadioColor32;
    TRadioButton *RadioColor64;
    TLabel *LabelFps;
    TEdit *EditFps;
    TGroupBox *GroupBox7;
    TCheckBox *CheckCode;
    TEdit *EditCode1;
    TEdit *EditCode2;
    TEdit *EditCode3;
    TEdit *EditCode4;
    TEdit *EditCode8;
    TEdit *EditCode7;
    TEdit *EditCode6;
    TEdit *EditCode5;
    TButton *Button1;
    TButton *Button2;
    void __fastcall FormShow(TObject *Sender);
    void __fastcall Button1Click(TObject *Sender);
    void __fastcall Button2Click(TObject *Sender);
private:	// User declaration

public:		// User declaration
	CArtCamSdk*		m_pCArtCamSdk;
	LONG			m_DllType;
	BOOL			m_SubCode;
	CAMERAINFO		m_CameraInfo;

	void	InitCameraSize();
	void	InitColorMode();
	void	InitSubSample();
	void	InitCNV();
	void	InitSubCode();

    __fastcall TForm3(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm3 *Form3;
//---------------------------------------------------------------------------
#endif

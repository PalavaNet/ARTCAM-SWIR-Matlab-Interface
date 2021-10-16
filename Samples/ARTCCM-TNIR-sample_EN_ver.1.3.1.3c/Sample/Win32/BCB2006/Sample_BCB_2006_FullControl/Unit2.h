//---------------------------------------------------------------------------

#ifndef Unit2H
#define Unit2H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include "CArtCamSdk.hpp"
#include <ComCtrls.hpp>
//---------------------------------------------------------------------------
class TForm2 : public TForm
{
__published:	// Component for admistering IDE
    TGroupBox *GroupBox1;
    TLabel *Label1;
    TLabel *Label2;
    TLabel *Label3;
    TLabel *Label4;
    TLabel *Label5;
    TLabel *Label6;
    TEdit *EditBrightness;
    TEdit *EditContrast;
    TEdit *EditHue;
    TEdit *EditSaturation;
    TEdit *EditSharpness;
    TEdit *EditGamma;
    TGroupBox *GroupBox2;
    TLabel *Label7;
    TEdit *EditExposureTime;
    TEdit *EditColorGainB;
    TLabel *Label8;
    TLabel *Label9;
    TLabel *Label10;
    TEdit *EditColorGainG2;
    TEdit *EditColorGainG1;
    TEdit *EditColorGainR;
    TLabel *Label11;
    TEdit *EditGlobalGain;
    TLabel *Label12;
    TGroupBox *GroupBox3;
    TCheckBox *CheckAWB;
    TGroupBox *GroupBox4;
    TRadioButton *RadioBayer1;
    TRadioButton *RadioBayer2;
    TRadioButton *RadioBayer3;
    TRadioButton *RadioBayer4;
    TGroupBox *GroupBox5;
    TLabel *Label13;
    TEdit *EditBayerGainB;
    TEdit *EditBayerGainG;
    TLabel *Label14;
    TEdit *EditBayerGainR;
    TLabel *Label15;
    TGroupBox *GroupBox6;
    TRadioButton *RadioAI1;
    TRadioButton *RadioAI2;
    TRadioButton *RadioAI3;
    TGroupBox *GroupBox7;
    TCheckBox *CheckMirrorV;
    TCheckBox *CheckMirrorH;
    TCheckBox *CheckHalfClock;
    TGroupBox *GroupBox8;
    TRadioButton *RadioChannel1;
    TRadioButton *RadioChannel2;
    TRadioButton *RadioChannel3;
    TRadioButton *RadioChannel4;
    TRadioButton *RadioChannel5;
    TRadioButton *RadioChannel6;
    TButton *Button1;
    TUpDown *UpDownBrightness;
    TUpDown *UpDownContrast;
    TUpDown *UpDownHue;
    TUpDown *UpDownSaturation;
    TUpDown *UpDownSharpness;
    TUpDown *UpDownGamma;
    TUpDown *UpDownBayerGainR;
    TUpDown *UpDownBayerGainG;
    TUpDown *UpDownBayerGainB;
    TUpDown *UpDownGlobalGain;
    TUpDown *UpDownColorGainR;
    TUpDown *UpDownColorGainG1;
    TUpDown *UpDownColorGainG2;
    TUpDown *UpDownColorGainB;
    TUpDown *UpDownExposureTime;
    void __fastcall FormShow(TObject *Sender);
    void __fastcall Button1Click(TObject *Sender);
    void __fastcall CheckAWBClick(TObject *Sender);
    void __fastcall RadioBayer1Click(TObject *Sender);
    void __fastcall RadioBayer2Click(TObject *Sender);
    void __fastcall RadioBayer3Click(TObject *Sender);
    void __fastcall RadioBayer4Click(TObject *Sender);
    void __fastcall RadioAI1Click(TObject *Sender);
    void __fastcall RadioAI2Click(TObject *Sender);
    void __fastcall RadioAI3Click(TObject *Sender);
    void __fastcall CheckMirrorVClick(TObject *Sender);
    void __fastcall CheckMirrorHClick(TObject *Sender);
    void __fastcall CheckHalfClockClick(TObject *Sender);
    void __fastcall RadioChannel1Click(TObject *Sender);
    void __fastcall RadioChannel2Click(TObject *Sender);
    void __fastcall RadioChannel3Click(TObject *Sender);
    void __fastcall RadioChannel4Click(TObject *Sender);
    void __fastcall RadioChannel5Click(TObject *Sender);
    void __fastcall RadioChannel6Click(TObject *Sender);
    void __fastcall EditBrightnessChange(TObject *Sender);
    void __fastcall EditContrastChange(TObject *Sender);
    void __fastcall EditHueChange(TObject *Sender);
    void __fastcall EditSaturationChange(TObject *Sender);
    void __fastcall EditSharpnessChange(TObject *Sender);
    void __fastcall EditGammaChange(TObject *Sender);
    void __fastcall EditBayerGainRChange(TObject *Sender);
    void __fastcall EditBayerGainGChange(TObject *Sender);
    void __fastcall EditBayerGainBChange(TObject *Sender);
    void __fastcall EditGlobalGainChange(TObject *Sender);
    void __fastcall EditColorGainRChange(TObject *Sender);
    void __fastcall EditColorGainG1Change(TObject *Sender);
    void __fastcall EditColorGainG2Change(TObject *Sender);
    void __fastcall EditColorGainBChange(TObject *Sender);
    void __fastcall EditExposureTimeChange(TObject *Sender);
private:	// User declaration

public:		// User declaration
	CArtCamSdk*		m_pCArtCamSdk;
	LONG			m_DllType;
	BOOL			m_Preview;
	BOOL			m_Init;
	CAMERAINFO		m_CameraInfo;

	BOOL	InitControl(LONG FilterType, TEdit* Edit, TUpDown* UpDonw, LONG Min, LONG Max);

    __fastcall TForm2(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm2 *Form2;
//---------------------------------------------------------------------------
#endif

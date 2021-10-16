//---------------------------------------------------------------------------

#ifndef Unit4H
#define Unit4H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include "CArtCamSdk.hpp"
//---------------------------------------------------------------------------
class TForm4 : public TForm
{
__published:	// Component for admistering IDE
    TGroupBox *GroupBox1;
    TGroupBox *GroupBox2;
    TCheckBox *CheckRead1;
    TCheckBox *CheckRead2;
    TCheckBox *CheckRead3;
    TCheckBox *CheckRead4;
    TCheckBox *CheckRead5;
    TCheckBox *CheckRead6;
    TCheckBox *CheckRead7;
    TCheckBox *CheckRead8;
    TCheckBox *CheckWrite1;
    TCheckBox *CheckWrite2;
    TCheckBox *CheckWrite3;
    TCheckBox *CheckWrite4;
    TCheckBox *CheckWrite5;
    TCheckBox *CheckWrite6;
    TCheckBox *CheckWrite7;
    TCheckBox *CheckWrite8;
    TButton *Button1;
    TButton *Button2;
    TButton *Button3;
    void __fastcall Button1Click(TObject *Sender);
    void __fastcall Button2Click(TObject *Sender);
    void __fastcall Button3Click(TObject *Sender);
    void __fastcall FormShow(TObject *Sender);
private:	// User declaration

public:		// User declaration
	CArtCamSdk*		m_pCArtCamSdk;
	LONG			m_DllType;
	BOOL			m_Preview;
	BOOL			m_Init;

    __fastcall TForm4(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm4 *Form4;
//---------------------------------------------------------------------------
#endif

//$$---- Form HDR ----
//---------------------------------------------------------------------------

#ifndef Unit6H
#define Unit6H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include "CArtCamSdk.hpp"
#include <Dialogs.hpp>
//---------------------------------------------------------------------------
class TForm6 : public TForm
{
__published:	// IDE-managed Components
	TCheckBox *checkCorrectionEnable;
	TCheckBox *checkDotfilterEnable;
	TButton *buttonUpdateLow;
	TButton *buttonUpdateHigh;
	TButton *buttonSaveMask;
	TButton *buttonLoadMask;
	TButton *buttonOK;
	TGroupBox *GroupBox1;
	TSaveDialog *SaveDialog1;
	TOpenDialog *OpenDialog1;
    void __fastcall FormShow(TObject *Sender);
	void __fastcall buttonUpdateLowClick(TObject *Sender);
	void __fastcall buttonUpdateHighClick(TObject *Sender);
	void __fastcall buttonSaveMaskClick(TObject *Sender);
	void __fastcall buttonLoadMaskClick(TObject *Sender);
	void __fastcall checkCorrectionEnableClick(TObject *Sender);
	void __fastcall checkDotfilterEnableClick(TObject *Sender);
	void __fastcall buttonOKClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
	CArtCamSdk*		m_pCArtCamSdk;

	__fastcall TForm6(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm6 *Form6;
//---------------------------------------------------------------------------
#endif

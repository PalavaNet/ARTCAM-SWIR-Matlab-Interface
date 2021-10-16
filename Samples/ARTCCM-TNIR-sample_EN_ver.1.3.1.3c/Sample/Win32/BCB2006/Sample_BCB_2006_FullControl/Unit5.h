//---------------------------------------------------------------------------

#ifndef Unit5H
#define Unit5H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include "CArtCamSdk.hpp"
//---------------------------------------------------------------------------
class TForm5 : public TForm
{
__published:	// IDE-managed Components
	TComboBox	*ComboBox1;
	TComboBox	*ComboBox2;
	TCheckBox   *CheckBox1;
	TCheckBox   *CheckBox2;
	TCheckBox   *CheckBox3;
	TCheckBox   *CheckBox4;
	TButton     *Button1;
	TButton     *Button2;
	TButton     *Button3;
	TTrackBar   *TrackBar1;
	TTrackBar   *TrackBar2;
	TTrackBar   *TrackBar3;
	TTrackBar   *TrackBar4;
	TTrackBar   *TrackBar5;
	TEdit       *Edit1;
	TEdit       *Edit2;
	TEdit       *Edit3;
	TEdit       *Edit4;
	TEdit       *Edit5;
	TButton     *Button5;
	TGroupBox   *GroupBox1;
	TGroupBox   *GroupBox2;
	TLabel      *Label1;
	TLabel      *Label2;
	TLabel      *Label3;
	TLabel      *Label4;
	TLabel      *Label5;
	void __fastcall FormShow(TObject *Sender);
	void __fastcall ComboBox1Change(TObject *Sender);
	void __fastcall ComboBox2Change(TObject *Sender);
	void __fastcall Button1Click(TObject *Sender);
	void __fastcall Button2Click(TObject *Sender);
	void __fastcall CheckBox1Click(TObject *Sender);
	void __fastcall CheckBox2Click(TObject *Sender);
	void __fastcall CheckBox3Click(TObject *Sender);
	void __fastcall CheckBox4Click(TObject *Sender);
	void __fastcall TrackBar1Change(TObject *Sender);
	void __fastcall TrackBar2Change(TObject *Sender);
	void __fastcall TrackBar3Change(TObject *Sender);
	void __fastcall TrackBar4Change(TObject *Sender);
	void __fastcall TrackBar5Change(TObject *Sender);
	void __fastcall Edit1Change(TObject *Sender);
	void __fastcall KeyValueCheck(TObject *Sender, char &Key);
	void __fastcall Edit2Change(TObject *Sender);
	void __fastcall Edit3Change(TObject *Sender);
	void __fastcall Edit4Change(TObject *Sender);
	void __fastcall Edit5Change(TObject *Sender);
	void __fastcall Button5Click(TObject *Sender);
	void __fastcall Button3Click(TObject *Sender);


private:	// User declarations
public:		// User declarations
	CArtCamSdk*		m_pCArtCamSdk;
	LONG			lRed;
	LONG			lGreen;
	LONG			lBlue;
	LONG			lGlobalGain;
	LONG			lShutterWidth;
 	void			ColorCheck();

	__fastcall TForm5(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm5 *Form5;
//---------------------------------------------------------------------------
#endif

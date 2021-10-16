//$$---- Form HDR ----
//---------------------------------------------------------------------------

#ifndef Unit7H
#define Unit7H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include <ExtCtrls.hpp>
#include "CArtCamSdk.hpp"
//---------------------------------------------------------------------------
class TForm7 : public TForm
{
__published:	// IDE-managed Components
	TCheckBox *CheckColor;
	TCheckBox *CheckAWB;
	TGroupBox *GroupBox1;
	TTrackBar *TrackGainR;
	TEdit *EditGainR;
	TUpDown *UpDownGainR;
	TUpDown *UpDownGainG;
	TEdit *EditGainG;
	TTrackBar *TrackGainG;
	TUpDown *UpDownGainB;
	TEdit *EditGainB;
	TTrackBar *TrackGainB;
	TGroupBox *GroupBox2;
	TLabel *Label1;
	TLabel *Label2;
	TLabel *Label3;
	TGroupBox *GroupBox3;
	TTrackBar *TrackGainGlobal;
	TEdit *EditGainGlobal;
	TUpDown *UpDownGainGlobal;
	TTrackBar *TrackExposureTime;
	TEdit *EditExposureTime;
	TUpDown *UpDownExposureTime;
	TLabel *Label4;
	TLabel *Label5;
	TCheckBox *CheckMirrorV;
	TCheckBox *CheckMirrorH;
	TGroupBox *GroupBox4;
	TRadioButton *RadioCursor_1;
	TRadioButton *RadioCursor_2;
	TCheckBox *CheckCursorOn;
	TTrackBar *TrackPosX;
	TTrackBar *TrackPosY;
	TTrackBar *TrackSizeX;
	TEdit *EditPosX;
	TUpDown *UpDownPosX;
	TEdit *EditPosY;
	TUpDown *UpDownPosY;
	TEdit *EditSizeX;
	TUpDown *UpDownSizeX;
	TTrackBar *TrackSizeY;
	TEdit *EditSizeY;
	TUpDown *UpDownSizeY;
	TLabel *Label6;
	TLabel *Label7;
	TLabel *Label8;
	TLabel *Label9;
	TImage *Image1;
	TButton *ButtonInitSettings;
	TButton *ButtonSaveSettings;
	TButton *ButtonOK;
	TButton *ButtonDefault;
	TButton *ButtonCancel;
	void __fastcall FormShow(TObject *Sender);
	void __fastcall RadioCursor_1Click(TObject *Sender);
	void __fastcall RadioCursor_2Click(TObject *Sender);
	void __fastcall CheckCursorOnClick(TObject *Sender);
	void __fastcall TrackGainRChange(TObject *Sender);
	void __fastcall EditGainRChange(TObject *Sender);
	void __fastcall TrackGainGChange(TObject *Sender);
	void __fastcall TrackGainBChange(TObject *Sender);
	void __fastcall TrackGainGlobalChange(TObject *Sender);
	void __fastcall TrackExposureTimeChange(TObject *Sender);
	void __fastcall TrackPosXChange(TObject *Sender);
	void __fastcall TrackPosYChange(TObject *Sender);
	void __fastcall TrackSizeXChange(TObject *Sender);
	void __fastcall TrackSizeYChange(TObject *Sender);
	void __fastcall EditGainGChange(TObject *Sender);
	void __fastcall EditGainBChange(TObject *Sender);
	void __fastcall EditGainGlobalChange(TObject *Sender);
	void __fastcall EditExposureTimeChange(TObject *Sender);
	void __fastcall EditPosXChange(TObject *Sender);
	void __fastcall EditPosYChange(TObject *Sender);
	void __fastcall EditSizeXChange(TObject *Sender);
	void __fastcall EditSizeYChange(TObject *Sender);
	void __fastcall CheckMirrorVClick(TObject *Sender);
	void __fastcall CheckMirrorHClick(TObject *Sender);
	void __fastcall CheckColorClick(TObject *Sender);
	void __fastcall CheckAWBClick(TObject *Sender);
	void __fastcall ButtonDefaultClick(TObject *Sender);
	void __fastcall ButtonOKClick(TObject *Sender);
	void __fastcall ButtonCancelClick(TObject *Sender);
	void __fastcall ButtonInitSettingsClick(TObject *Sender);
	void __fastcall ButtonSaveSettingsClick(TObject *Sender);
	void __fastcall FormPaint(TObject *Sender);
	void __fastcall Image1MouseDown(TObject *Sender, TMouseButton Button,
		  TShiftState Shift, int X, int Y);
private:	// User declarations
public:		// User declarations
	CArtCamSdk*		m_pCArtCamSdk;
	LONG			m_DllType;
	LONG			m_CursorNumber;
	BOOL			m_Init;

	typedef struct _M_CURSOR{
		BOOL		Enable;
		LONG		SizeX;
		LONG		SizeY;
		POINT		Pos;
		LONG		Color;
	}M_CURSOR;

	M_CURSOR		m_Cursor[2];

	bool InitControl(TTrackBar* TrackBar, TEdit* Edit, TUpDown* UpDown, LONG Min, LONG Max, LONG Now, LONG Tic);
	void SetUpDownTrack(TUpDown* UpDown, TTrackBar* TrackBar, LONG Value);
	void ChangeCursor(void);



	__fastcall TForm7(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm7 *Form7;
//---------------------------------------------------------------------------
#endif

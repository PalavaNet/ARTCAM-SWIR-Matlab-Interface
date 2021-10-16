//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Menus.hpp>
#include "CArtCamSdk.hpp"
#include <ExtCtrls.hpp>
#include <AppEvnts.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// Component for admistering IDE
	TMainMenu *MainMenu1;
	TMenuItem *PopupFile;
	TMenuItem *PopupShow;
	TMenuItem *PopupSet;
	TMenuItem *PopupDll;
	TMenuItem *FileSave;
	TMenuItem *FileExit;
	TMenuItem *ShowPreview;
	TMenuItem *ShowCallBack;
	TMenuItem *ShowSnapShot;
	TMenuItem *ShowCapture;
	TMenuItem *ShowTrigger;
	TMenuItem *SetCamera1;
	TMenuItem *SetCamera2;
	TMenuItem *SetFilter1;
	TMenuItem *SetFilter2;
	TMenuItem *SetAnalog1;
	TMenuItem *SetAnalog2;
	TTimer *Timer1;
    TImage *Image1;
    TImage *Image2;

	void __fastcall FormCreate(TObject *Sender);
	void __fastcall FormDestroy(TObject *Sender);
	void __fastcall SaveClick(TObject *Sender);
	void __fastcall ExitClick(TObject *Sender);
	void __fastcall PreviewClick(TObject *Sender);
	void __fastcall CallBackClick(TObject *Sender);
	void __fastcall SnapShotClick(TObject *Sender);
	void __fastcall CaptureClick(TObject *Sender);
	void __fastcall TriggerClick(TObject *Sender);
	void __fastcall SetCameraClick1(TObject *Sender);
	void __fastcall SetCameraClick2(TObject *Sender);
	void __fastcall SetFilterClick1(TObject *Sender);
	void __fastcall SetFilterClick2(TObject *Sender);
	void __fastcall SetAnalogClick1(TObject *Sender);
	void __fastcall SetAnalogClick2(TObject *Sender);

	void __fastcall Timer1Timer(TObject *Sender);
	void __fastcall FormResize(TObject *Sender);
	void __fastcall ReloadClick(TObject *Sender);

private:	// User declaration
	LONG					m_DllType;
	LONG					m_DllSata;
	LONG					m_DllCount;
	LONG					m_SataType;
	LONG					m_PreviewMode;
	CArtCamSdk				m_CArtCamSdk[2];
	Graphics::TBitmap*		m_BmpDraw[2];
	BOOL					m_SetDeviceFlg[2];

	void	OnDllChange(TObject *Sender, LONG Number, LONG CameraType);
	void	CreateBitmap(void);
	void			OnDllReload		(void);
	void __fastcall	OnDllClick		(TObject *Sender);

public:		// User declaration
	HHOOK	m_Hook;
	void	DrawImage(void);

	__fastcall TForm1(TComponent* Owner);
};

const int SUB_SAMPLE[] = { 1, 2, 4, 8 };
#define ArtCamGetWidth(n)	(m_CArtCamSdk[n].Width()  / SUB_SAMPLE[m_CArtCamSdk[n].GetSubSample()])
#define ArtCamGetHeight(n)	(m_CArtCamSdk[n].Height() / SUB_SAMPLE[m_CArtCamSdk[n].GetSubSample()])
#define ArtCamGetColor(n)	WORD(((m_CArtCamSdk[n].GetColorMode() + 7) / 8) * 8)
#define ArtCamGetBpp(n)		(((m_CArtCamSdk[n].GetColorMode() + 7) / 8))
#define ArtCamGetPitch(n)	((ArtCamGetWidth(n) * ArtCamGetBpp(n) + 3) & ~3)
#define ArtCamGetSize(n)	(ArtCamGetPitch(n) * ArtCamGetHeight(n))



//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
 
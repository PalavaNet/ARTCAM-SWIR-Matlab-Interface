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
#include <Dialogs.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// Component for admistering IDE
	TMainMenu *MainMenu1;
	TMenuItem *PopupFile;
	TMenuItem *PopupShow;
	TMenuItem *PopupSet;
	TMenuItem *PopupDevice;
	TMenuItem *PopupDll;
	TMenuItem *FileSave;
	TMenuItem *FileExit;
	TMenuItem *ShowPreview;
	TMenuItem *ShowCallBack;
	TMenuItem *ShowSnapShot;
	TMenuItem *ShowCapture;
	TMenuItem *ShowTrigger;
	TMenuItem *SetCamera;
	TMenuItem *SetFilter;
	TMenuItem *SetAnalog;
	TMenuItem *Device0;
	TMenuItem *Device1;
	TMenuItem *Device2;
	TMenuItem *Device3;
	TMenuItem *Device4;
	TMenuItem *Device5;
	TMenuItem *Device6;
	TMenuItem *Device7;
	TTimer *Timer1;
	TMenuItem *FileRec;
	TMenuItem *N4;
	TMenuItem *ShowStop;
	TMenuItem *N5;
	TMenuItem *SetUserSize;
	TMenuItem *SetUserFilter;
    TMenuItem *SetUserIO;
	TSaveDialog *SaveDialog1;
	TTimer *RecTimer;
	TMenuItem *SetUserMonitor;
	TMenuItem *Reload;
	TMenuItem *N1;
	TMenuItem *SetCorrection;

	void __fastcall FormCreate(TObject *Sender);
	void __fastcall FormDestroy(TObject *Sender);
	void __fastcall SaveClick(TObject *Sender);
	void __fastcall ExitClick(TObject *Sender);
	void __fastcall PreviewClick(TObject *Sender);
	void __fastcall CallBackClick(TObject *Sender);
	void __fastcall SnapShotClick(TObject *Sender);
	void __fastcall CaptureClick(TObject *Sender);
	void __fastcall TriggerClick(TObject *Sender);
	void __fastcall SetCameraClick(TObject *Sender);
	void __fastcall SetFilterClick(TObject *Sender);
	void __fastcall SetAnalogClick(TObject *Sender);
	void __fastcall Device0Click(TObject *Sender);
	void __fastcall Device1Click(TObject *Sender);
	void __fastcall Device2Click(TObject *Sender);
	void __fastcall Device3Click(TObject *Sender);
	void __fastcall Device4Click(TObject *Sender);
	void __fastcall Device5Click(TObject *Sender);
	void __fastcall Device6Click(TObject *Sender);
	void __fastcall Device7Click(TObject *Sender);
	void __fastcall Device8Click(TObject *Sender);
	void __fastcall Device9Click(TObject *Sender);
	void __fastcall Timer1Timer(TObject *Sender);
	void __fastcall FormResize(TObject *Sender);
	void __fastcall SetUserSizeClick(TObject *Sender);
	void __fastcall SetUserFilterClick(TObject *Sender);
    void __fastcall SetUserIOClick(TObject *Sender);
	void __fastcall FileRecClick(TObject *Sender);
	void __fastcall PopupFileClick(TObject *Sender);
	void __fastcall PopupShowClick(TObject *Sender);
	void __fastcall PopupSetClick(TObject *Sender);
	void __fastcall SetUserMonitorClick(TObject *Sender);
	void __fastcall ReloadClick(TObject *Sender);
	void __fastcall SetCorrectionClick(TObject *Sender);

private:	// User declaration
	LONG					m_DllType;
	LONG					m_DllSata;
	LONG					m_DllCount;
	LONG					m_CurrentCameraType;
	LONG					m_SataType;
	LONG					m_PreviewMode;
	CArtCamSdk				m_CArtCamSdk;
	LPBYTE					m_BmpCapture;
	Graphics::TBitmap*		m_BmpDraw;

	LONG			m_SelectDevice;		// Number of chosen device
	BOOL			m_StopFlg;			// Determination of stoppage
	AnsiString		m_RecName;

	void			OnDllChange		(TObject *Sender, LONG Number, LONG CameraType);
	void			OnDeviceChange	(TObject *Sender, LONG Number);
	void			CreateBitmap	(void);
	void			ChangeScrollbar	(void);
	void			OnDllReload		(void);
	void __fastcall	OnDllClick		(TObject *Sender);

public:		// User declaration
	HHOOK	m_Hook;
	BOOL	m_SaveFlg;			// Deicide if save is available
	void	DrawImage(void);
	void	ReDraw(void);

	__fastcall TForm1(TComponent* Owner);
};

const int SUB_SAMPLE[] = { 1, 2, 4, 8 };
#define ArtCamGetWidth()	(m_CArtCamSdk.Width()  / SUB_SAMPLE[m_CArtCamSdk.GetSubSample()])
#define ArtCamGetHeight()	(m_CArtCamSdk.Height() / SUB_SAMPLE[m_CArtCamSdk.GetSubSample()])
#define ArtCamGetColor()	WORD(((m_CArtCamSdk.GetColorMode() + 7) / 8) * 8)
#define ArtCamGetBpp()		(((m_CArtCamSdk.GetColorMode() + 7) / 8))
#define ArtCamGetPitch()	((ArtCamGetWidth() * ArtCamGetBpp() + 3) & ~3)
#define ArtCamGetSize()		(ArtCamGetPitch() * ArtCamGetHeight())



//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
 
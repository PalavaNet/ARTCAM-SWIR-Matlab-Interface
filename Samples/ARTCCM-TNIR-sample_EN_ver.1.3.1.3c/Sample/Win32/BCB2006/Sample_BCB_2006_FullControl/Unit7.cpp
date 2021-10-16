//$$---- Form CPP ----
//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit7.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm7 *Form7;
//---------------------------------------------------------------------------
__fastcall TForm7::TForm7(TComponent* Owner)
	: TForm(Owner)
{
	m_pCArtCamSdk = NULL;
	m_Init = FALSE;
}
//---------------------------------------------------------------------------


bool TForm7::InitControl(TTrackBar* TrackBar, TEdit* Edit, TUpDown* UpDown, LONG Min, LONG Max, LONG Now, LONG Tic)
{
	TrackBar->Min = Min;
	TrackBar->Max = Max;
	TrackBar->SetTick(Tic);
	TrackBar->Position = Now;


	UpDown->Min = Min;
	UpDown->Max = Max;
	UpDown->Position = Now;
	UpDown->Associate = Edit;

	Edit->Text = IntToStr(Now);


	return true;
}
//---------------------------------------------------------------------------


void __fastcall TForm7::FormShow(TObject *Sender)
{
	if(NULL == m_pCArtCamSdk){
		return;
	}

	m_Init = FALSE;

	if(m_pCArtCamSdk->Monitor_GetColorMode()){
		CheckColor->Checked = true;
	}else{
		CheckAWB->Enabled = false;
	}

	if(m_pCArtCamSdk->Monitor_GetBayerGainAuto()){
		CheckAWB->Checked = true;

		TrackGainR->Enabled = false;
		TrackGainG->Enabled = false;
		TrackGainB->Enabled = false;

		EditGainR->Enabled = false;
		EditGainG->Enabled = false;
		EditGainB->Enabled = false;

		UpDownGainR->Enabled = false;
		UpDownGainG->Enabled = false;
		UpDownGainB->Enabled = false;
	}


	// Bayer
	InitControl(TrackGainR, EditGainR, UpDownGainR, 0, 1023, m_pCArtCamSdk->Monitor_GetBayerGainRed(),   64);
	InitControl(TrackGainG, EditGainG, UpDownGainG, 0, 1023, m_pCArtCamSdk->Monitor_GetBayerGainGreen(), 64);
	InitControl(TrackGainB, EditGainB, UpDownGainB, 0, 1023, m_pCArtCamSdk->Monitor_GetBayerGainBlue(),  64);

	// GlobalGain, Shutter, Mirror
	switch(m_DllType){
		case ARTCAM_CAMERATYPE_1000MI_HD2:
		InitControl(TrackGainGlobal,   EditGainGlobal, 	UpDownGainGlobal, 0, 127, m_pCArtCamSdk->GetGlobalGain(), 64);
		InitControl(TrackExposureTime, EditExposureTime,UpDownExposureTime, 1, 8191, m_pCArtCamSdk->GetExposureTime(), 64);
		if(m_pCArtCamSdk->GetMirrorV())	CheckMirrorV->Checked = true;
		break;
	}

	for(int i=0; i<2; i++){
		// Cross cursor ON/OFF
		m_Cursor[i].Enable= m_pCArtCamSdk->Monitor_GetCrossCursorMode(i);

		// Position
		m_pCArtCamSdk->Monitor_GetCrossCursorPos(i, &m_Cursor[i].Pos.x, &m_Cursor[i].Pos.y);

		// Size
		m_pCArtCamSdk->Monitor_GetCrossCursorSize(i, &m_Cursor[i].SizeX, &m_Cursor[i].SizeY);

		// Color
		m_Cursor[i].Color = m_pCArtCamSdk->Monitor_GetCrossCursorColorRGB(i);
	}
	RadioCursor_1->Checked = true;
	if(m_Cursor[m_CursorNumber].Enable)	CheckCursorOn->Checked = true;
	else								CheckCursorOn->Checked = false;

	
	LONG Width  = 1280;
	LONG Height = 1024;
	if(ARTCAM_CAMERATYPE_1000MI_HD2 == m_DllType){
		switch(m_pCArtCamSdk->Width()){
		case 3664:
		case 1920:
			Width = 1920;
			Height = 1080;
		break;
		case 1280:
			Width = 1280;
			Height = 720;
		break;
		}
	}
	
	InitControl(TrackPosX, EditPosX, UpDownPosX, 0, Width, m_Cursor[m_CursorNumber].Pos.x, 64);
	InitControl(TrackPosY, EditPosY, UpDownPosY, 0, Height, m_Cursor[m_CursorNumber].Pos.y, 64);
	InitControl(TrackSizeX, EditSizeX, UpDownSizeX, 0, 7, m_Cursor[m_CursorNumber].SizeX, 64);
	InitControl(TrackSizeY, EditSizeY, UpDownSizeY, 0, 7, m_Cursor[m_CursorNumber].SizeY, 64);

	Invalidate();

	m_Init = TRUE;
}
//---------------------------------------------------------------------------
void TForm7::SetUpDownTrack(TUpDown* UpDown, TTrackBar* TrackBar, LONG Value)
{
	TrackBar->Position = Value;
	UpDown->Position = Value;
 }
//---------------------------------------------------------------------------

void TForm7::ChangeCursor(void)
{
	if(m_Cursor[m_CursorNumber].Enable)	CheckCursorOn->Checked = true;
	else								CheckCursorOn->Checked = false;


	BOOL Flg = m_Cursor[m_CursorNumber].Enable;

	TrackPosX->Enabled = Flg;	UpDownPosX->Enabled = Flg;	EditPosX->Enabled = Flg;
	TrackPosY->Enabled = Flg;	UpDownPosY->Enabled = Flg;	EditPosY->Enabled = Flg;
	TrackSizeX->Enabled = Flg;	UpDownSizeX->Enabled = Flg;	EditSizeX->Enabled = Flg;
	TrackSizeY->Enabled = Flg;	UpDownSizeY->Enabled = Flg;	EditSizeY->Enabled = Flg;

	EditPosX->Text = IntToStr(m_Cursor[m_CursorNumber].Pos.x);
	EditPosY->Text = IntToStr(m_Cursor[m_CursorNumber].Pos.y);
	EditSizeX->Text = IntToStr(m_Cursor[m_CursorNumber].SizeX);
	EditSizeY->Text = IntToStr(m_Cursor[m_CursorNumber].SizeY);

	Invalidate();
}
//---------------------------------------------------------------------------

void __fastcall TForm7::RadioCursor_1Click(TObject *Sender)
{
	m_CursorNumber = 0;
	ChangeCursor();

}
//---------------------------------------------------------------------------

void __fastcall TForm7::RadioCursor_2Click(TObject *Sender)
{
	m_CursorNumber = 1;
	ChangeCursor();
}
//---------------------------------------------------------------------------

void __fastcall TForm7::CheckCursorOnClick(TObject *Sender)
{
	bool Flg = CheckCursorOn->Checked;
	m_pCArtCamSdk->Monitor_SetCrossCursorMode(m_CursorNumber, Flg);
	m_Cursor[m_CursorNumber].Enable = Flg;
	Sleep(60);
	ChangeCursor();
}
//---------------------------------------------------------------------------

void __fastcall TForm7::TrackGainRChange(TObject *Sender)		{	if(!m_Init) return;	EditGainR->Text 		= IntToStr(TrackGainR->Position);		}
void __fastcall TForm7::TrackGainGChange(TObject *Sender)		{	if(!m_Init) return;	EditGainG->Text			= IntToStr(TrackGainG->Position);		}
void __fastcall TForm7::TrackGainBChange(TObject *Sender)		{	if(!m_Init) return;	EditGainB->Text 		= IntToStr(TrackGainB->Position);		}
void __fastcall TForm7::TrackGainGlobalChange(TObject *Sender)	{	if(!m_Init) return;	EditGainGlobal->Text	= IntToStr(TrackGainGlobal->Position);	}
void __fastcall TForm7::TrackExposureTimeChange(TObject *Sender){	if(!m_Init) return;	EditExposureTime->Text	= IntToStr(TrackExposureTime->Position);}
void __fastcall TForm7::TrackPosXChange(TObject *Sender)		{	if(!m_Init) return;	EditPosX->Text			= IntToStr(TrackPosX->Position);		}
void __fastcall TForm7::TrackPosYChange(TObject *Sender)		{	if(!m_Init) return;	EditPosY->Text			= IntToStr(TrackPosY->Position);		}
void __fastcall TForm7::TrackSizeXChange(TObject *Sender)		{	if(!m_Init) return;	EditSizeX->Text			= IntToStr(TrackSizeX->Position);		}
void __fastcall TForm7::TrackSizeYChange(TObject *Sender)		{	if(!m_Init) return;	EditSizeY->Text			= IntToStr(TrackSizeY->Position);		}
//---------------------------------------------------------------------------

void __fastcall TForm7::EditGainRChange(TObject *Sender)
{
	if(!m_Init) return;
		int Value = StrToInt(EditGainR->Text);
	SetUpDownTrack(UpDownGainR, TrackGainR, Value);
	m_pCArtCamSdk->Monitor_SetBayerGainRed(Value);
}
//---------------------------------------------------------------------------
void __fastcall TForm7::EditGainGChange(TObject *Sender)
{
	if(!m_Init) return;
	int Value = StrToInt(EditGainG->Text);
	SetUpDownTrack(UpDownGainG, TrackGainG, Value);
	m_pCArtCamSdk->Monitor_SetBayerGainGreen(Value);
}
//---------------------------------------------------------------------------

void __fastcall TForm7::EditGainBChange(TObject *Sender)
{
	if(!m_Init) return;
	int Value = StrToInt(EditGainB->Text);
	SetUpDownTrack(UpDownGainB, TrackGainB, Value);
	m_pCArtCamSdk->Monitor_SetBayerGainBlue(Value);
}
//---------------------------------------------------------------------------

void __fastcall TForm7::EditGainGlobalChange(TObject *Sender)
{
	if(!m_Init) return;
	int Value = StrToInt(EditGainGlobal->Text);
	SetUpDownTrack(UpDownGainGlobal, TrackGainGlobal, Value);
	m_pCArtCamSdk->SetGlobalGain(Value);
}
//---------------------------------------------------------------------------

void __fastcall TForm7::EditExposureTimeChange(TObject *Sender)
{
	if(!m_Init) return;
	int Value = StrToInt(EditExposureTime->Text);
	SetUpDownTrack(UpDownExposureTime, TrackExposureTime, Value);
	m_pCArtCamSdk->SetExposureTime(Value);
}
//---------------------------------------------------------------------------

void __fastcall TForm7::EditPosXChange(TObject *Sender)
{
	if(!m_Init) return;
	m_Cursor[m_CursorNumber].Pos.x = StrToInt(EditPosX->Text);
	SetUpDownTrack(UpDownPosX, TrackPosX, m_Cursor[m_CursorNumber].Pos.x);
	m_pCArtCamSdk->Monitor_SetCrossCursorPos(m_CursorNumber, m_Cursor[m_CursorNumber].Pos.x, m_Cursor[m_CursorNumber].Pos.y);
}
//---------------------------------------------------------------------------

void __fastcall TForm7::EditPosYChange(TObject *Sender)
{
	if(!m_Init) return;
	m_Cursor[m_CursorNumber].Pos.y = StrToInt(EditPosY->Text);
	SetUpDownTrack(UpDownPosY, TrackPosY, m_Cursor[m_CursorNumber].Pos.y);
	m_pCArtCamSdk->Monitor_SetCrossCursorPos(m_CursorNumber, m_Cursor[m_CursorNumber].Pos.x, m_Cursor[m_CursorNumber].Pos.y);
}
//---------------------------------------------------------------------------

void __fastcall TForm7::EditSizeXChange(TObject *Sender)
{
	if(!m_Init) return;
	m_Cursor[m_CursorNumber].SizeX = StrToInt(EditSizeX->Text);
	SetUpDownTrack(UpDownSizeX, TrackSizeX, m_Cursor[m_CursorNumber].SizeX);
	m_pCArtCamSdk->Monitor_SetCrossCursorSize(m_CursorNumber, m_Cursor[m_CursorNumber].SizeX, m_Cursor[m_CursorNumber].SizeY);
}
//---------------------------------------------------------------------------

void __fastcall TForm7::EditSizeYChange(TObject *Sender)
{
	if(!m_Init) return;
	m_Cursor[m_CursorNumber].SizeY = StrToInt(EditSizeY->Text);
	SetUpDownTrack(UpDownSizeY, TrackSizeY, m_Cursor[m_CursorNumber].SizeY);
	m_pCArtCamSdk->Monitor_SetCrossCursorSize(m_CursorNumber, m_Cursor[m_CursorNumber].SizeX, m_Cursor[m_CursorNumber].SizeY);
}
//---------------------------------------------------------------------------

void __fastcall TForm7::CheckColorClick(TObject *Sender)
{
	CheckAWBClick(Sender);
}
//---------------------------------------------------------------------------

void __fastcall TForm7::CheckAWBClick(TObject *Sender)
{
	bool Color = CheckColor->Checked;
	bool AWB = CheckAWB->Checked;

	m_pCArtCamSdk->Monitor_SetColorMode(Color);
	m_pCArtCamSdk->Monitor_SetBayerGainAuto(AWB);

	TrackGainR->Enabled = (Color && !AWB);
	TrackGainG->Enabled = (Color && !AWB);
	TrackGainB->Enabled = (Color && !AWB);

	EditGainR->Enabled = (Color && !AWB);
	EditGainG->Enabled = (Color && !AWB);
	EditGainB->Enabled = (Color && !AWB);

	UpDownGainR->Enabled = (Color && !AWB);
	UpDownGainG->Enabled = (Color && !AWB);
	UpDownGainB->Enabled = (Color && !AWB);

	if(Color && !AWB){
		SetUpDownTrack(UpDownGainR,	TrackGainR,	m_pCArtCamSdk->Monitor_GetBayerGainRed()	);
		SetUpDownTrack(UpDownGainG,	TrackGainG,	m_pCArtCamSdk->Monitor_GetBayerGainGreen()	);
		SetUpDownTrack(UpDownGainB,	TrackGainB,	m_pCArtCamSdk->Monitor_GetBayerGainBlue()	);
	}
}
//---------------------------------------------------------------------------


void __fastcall TForm7::CheckMirrorVClick(TObject *Sender)
{
	int flg = CheckMirrorV->Checked ? 1 : 0;
	m_pCArtCamSdk->SetMirrorV(flg);
}
//---------------------------------------------------------------------------

void __fastcall TForm7::CheckMirrorHClick(TObject *Sender)
{
	int flg = CheckMirrorH->Checked ? 1 : 0;
	m_pCArtCamSdk->SetMirrorH(flg);
}
//---------------------------------------------------------------------------
void __fastcall TForm7::ButtonDefaultClick(TObject *Sender)
{
	switch(m_DllType){
	case ARTCAM_CAMERATYPE_1000MI_HD2:
		// Bayer
		SetUpDownTrack(UpDownGainR,			TrackGainR,	256);
		SetUpDownTrack(UpDownGainG,			TrackGainG,	256);
		SetUpDownTrack(UpDownGainB,			TrackGainB,	256);
		SetUpDownTrack(UpDownGainGlobal,	TrackGainGlobal,	64);
		SetUpDownTrack(UpDownExposureTime,	TrackExposureTime,	2748);

		SetUpDownTrack(UpDownPosX, TrackPosX,	360);
		SetUpDownTrack(UpDownPosY, TrackPosY,	360);
		SetUpDownTrack(UpDownSizeX, TrackSizeX,	4);
		SetUpDownTrack(UpDownSizeY, TrackSizeY,	4);
	break;
	}

}
//---------------------------------------------------------------------------

void __fastcall TForm7::ButtonOKClick(TObject *Sender)
{
	this->Close();
}
//---------------------------------------------------------------------------

void __fastcall TForm7::ButtonCancelClick(TObject *Sender)
{
	this->Close();
}
//---------------------------------------------------------------------------

void __fastcall TForm7::ButtonInitSettingsClick(TObject *Sender)
{
	m_pCArtCamSdk->Monitor_InitRegisterSettings();

	SetUpDownTrack(UpDownGainR,	TrackGainR,	m_pCArtCamSdk->Monitor_GetBayerGainRed()	);
	SetUpDownTrack(UpDownGainG,	TrackGainG,	m_pCArtCamSdk->Monitor_GetBayerGainGreen()	);
	SetUpDownTrack(UpDownGainB,	TrackGainB,	m_pCArtCamSdk->Monitor_GetBayerGainBlue()	);

	for(int i=0; i<2; i++){
		m_Cursor[i].Enable= m_pCArtCamSdk->Monitor_GetCrossCursorMode(i);
		m_pCArtCamSdk->Monitor_GetCrossCursorPos(i, &m_Cursor[i].Pos.x, &m_Cursor[i].Pos.y);
		m_pCArtCamSdk->Monitor_GetCrossCursorSize(i, &m_Cursor[i].SizeX, &m_Cursor[i].SizeY);
		m_Cursor[i].Color = m_pCArtCamSdk->Monitor_GetCrossCursorColorRGB(i);
	}
	CheckCursorOn->Checked = m_Cursor[m_CursorNumber].Enable;

	SetUpDownTrack(UpDownPosX, TrackPosX,	m_Cursor[m_CursorNumber].Pos.x);
	SetUpDownTrack(UpDownPosY, TrackPosY,	m_Cursor[m_CursorNumber].Pos.y);
	SetUpDownTrack(UpDownSizeX, TrackSizeX,	m_Cursor[m_CursorNumber].SizeX);
	SetUpDownTrack(UpDownSizeY, TrackSizeY,	m_Cursor[m_CursorNumber].SizeY);

	Invalidate();

}
//---------------------------------------------------------------------------

void __fastcall TForm7::ButtonSaveSettingsClick(TObject *Sender)
{
	m_pCArtCamSdk->Monitor_SaveCurrentSettings();
}
//---------------------------------------------------------------------------

void __fastcall TForm7::FormPaint(TObject *Sender)
{

	const COLORREF Color[16]= {
		0x00FFFFFF,
		0x00000000,
		0x0000FFFF,
		0x000000FF,
		0x00FF0000,
		0x0000FF00,
		0x00004080,
		0x00808080,
		0x00FF8000,
		0x00FF0080,
		0x00FF80FF,
		0x00008080,
		0x00400080,
		0x00FFFF80,
		0x000080FF,
		0x00808040,
	};

	Image1->Canvas->Pen->Color = clBlack;
	Image1->Canvas->Rectangle(Image1->ClientRect);

	TRect rc = Image1->ClientRect;
	rc.Left++;	rc.Top++;
	rc.Right--;	rc.Bottom--;
	LONG color = m_pCArtCamSdk->Monitor_GetCrossCursorColorRGB(m_CursorNumber);

	for(int i=0; i<16; i++){
		LONG w = rc.Width() / 16;
		TRect rc1(rc.left+w*i, rc.top, rc.left+w*(i+1), rc.bottom);
		if(15==i) rc1.right = rc.right;
		Image1->Canvas->Brush->Color = Color[i];
		Image1->Canvas->FillRect(rc1);

		if(color == i){
			Image1->Canvas->Pen->Color = clRed;
			Image1->Canvas->Rectangle(rc1);
		}

	}


}
//---------------------------------------------------------------------------

void __fastcall TForm7::Image1MouseDown(TObject *Sender, TMouseButton Button,
	  TShiftState Shift, int X, int Y)
{
	TRect rc = Image1->ClientRect;
	rc.Left++;	rc.Top++;
	rc.Right--;	rc.Bottom--;

	for(int i=0; i<16; i++){
		LONG w = rc.Width() / 16;
		TRect rc1(rc.left+w*i, rc.top, rc.left+w*(i+1), rc.bottom);
		if(15==i) rc1.right = rc.right;
			if((rc1.left<X) && (X<rc1.right) && (rc1.top<Y) && (Y<rc1.Bottom)){
			m_pCArtCamSdk->Monitor_SetCrossCursorColorRGB(m_CursorNumber, i);
			Invalidate();
			break;
		}
	}
}
//---------------------------------------------------------------------------


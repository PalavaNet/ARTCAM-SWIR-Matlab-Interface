//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit2.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm2 *Form2;
//---------------------------------------------------------------------------
__fastcall TForm2::TForm2(TComponent* Owner)
    : TForm(Owner)
{
	m_pCArtCamSdk = NULL;
	m_Init = FALSE;
}
//---------------------------------------------------------------------------
void __fastcall TForm2::FormShow(TObject *Sender)
{
	m_Init = FALSE;

	if(NULL == m_pCArtCamSdk){
		return;
	}

	// Change operation for each DLL
	// For each DLL function, please refer to manual.
	m_DllType = HIWORD(m_pCArtCamSdk->GetDllVersion());

	// Get camera information
	m_CameraInfo.lSize = sizeof(CAMERAINFO);
	m_pCArtCamSdk->GetCameraInfo(&m_CameraInfo);


	// Range for value is set while determination of availability is done. 
	if(ARTCAM_CAMERATYPE_CNV == m_DllType){
		InitControl(ARTCAM_FILTERTYPE_BRIGHTNESS,		EditBrightness,		UpDownBrightness,	   0,	255);
		InitControl(ARTCAM_FILTERTYPE_CONTRAST,			EditContrast,		UpDownContrast,		   0,	255);
		InitControl(ARTCAM_FILTERTYPE_HUE,				EditHue,			UpDownHue,			   0,	255);
		InitControl(ARTCAM_FILTERTYPE_SATURATION,		EditSaturation,		UpDownSaturation,	   0,	255);
		InitControl(ARTCAM_FILTERTYPE_SHARPNESS,		EditSharpness,		UpDownSharpness,	   0,	  0);
		InitControl(ARTCAM_FILTERTYPE_GAMMA,			EditGamma,			UpDownGamma,		   0,	  0);

		InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_R,		EditBayerGainR,		UpDownBayerGainR,	   0,	  0);
		InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_G,		EditBayerGainG,		UpDownBayerGainG,	   0,	  0);
		InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_B,		EditBayerGainB,		UpDownBayerGainB,	   0,	  0);
	} else {
		InitControl(ARTCAM_FILTERTYPE_BRIGHTNESS,		EditBrightness,		UpDownBrightness,	-255,	255);
		InitControl(ARTCAM_FILTERTYPE_CONTRAST,			EditContrast,		UpDownContrast,		-127,	127);
		InitControl(ARTCAM_FILTERTYPE_HUE,				EditHue,			UpDownHue,			-360,	360);
		InitControl(ARTCAM_FILTERTYPE_SATURATION,		EditSaturation,		UpDownSaturation,	-255,	255);
		InitControl(ARTCAM_FILTERTYPE_SHARPNESS,		EditSharpness,		UpDownSharpness,	   0,	 30);
		InitControl(ARTCAM_FILTERTYPE_GAMMA,			EditGamma,			UpDownGamma,		   0,	200);

		InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_R,		EditBayerGainR,		UpDownBayerGainR,	   0,	200);
		InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_G,		EditBayerGainG,		UpDownBayerGainG,	   0,	200);
		InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_B,		EditBayerGainB,		UpDownBayerGainB,	   0,	200);
	}

	InitControl(ARTCAM_FILTERTYPE_GLOBAL_GAIN,		EditGlobalGain,		UpDownGlobalGain,	m_CameraInfo.lGlobalGainMin, m_CameraInfo.lGlobalGainMax);
	InitControl(ARTCAM_FILTERTYPE_COLOR_GAIN_R,		EditColorGainR,		UpDownColorGainR,	m_CameraInfo.lColorGainMin,  m_CameraInfo.lColorGainMax);
	InitControl(ARTCAM_FILTERTYPE_COLOR_GAIN_G1,	EditColorGainG1,	UpDownColorGainG1,	m_CameraInfo.lColorGainMin,  m_CameraInfo.lColorGainMax);
	InitControl(ARTCAM_FILTERTYPE_COLOR_GAIN_G2,	EditColorGainG2,	UpDownColorGainG2,	m_CameraInfo.lColorGainMin,  m_CameraInfo.lColorGainMax);
	InitControl(ARTCAM_FILTERTYPE_COLOR_GAIN_B,		EditColorGainB,		UpDownColorGainB,	m_CameraInfo.lColorGainMin,  m_CameraInfo.lColorGainMax);
	InitControl(ARTCAM_FILTERTYPE_EXPOSURETIME,		EditExposureTime,	UpDownExposureTime,	m_CameraInfo.lExposureMin,   m_CameraInfo.lExposureMax);


	// Auto white balance
	BOOL Error = FALSE;
	LONG Data = m_pCArtCamSdk->GetFilterValue(ARTCAM_FILTERTYPE_BAYER_GAIN_AUTO, &Error);
	if(!Error){
		CheckAWB->Enabled = FALSE;
	}
	if(Data){
		CheckAWB->Checked = TRUE;
	}


	// Bayer conversion mode
	Error = FALSE;
	Data = m_pCArtCamSdk->GetFilterValue(ARTCAM_FILTERTYPE_BAYERMODE, &Error);
	if(!Error){
		RadioBayer1->Enabled = FALSE;
		RadioBayer2->Enabled = FALSE;
		RadioBayer3->Enabled = FALSE;
		RadioBayer4->Enabled = FALSE;
	}

	switch(Data){
	case 0:	RadioBayer1->Checked = TRUE; break;
	case 1:	RadioBayer2->Checked = TRUE; break; 
	case 2:	RadioBayer3->Checked = TRUE; break;
	case 3:	RadioBayer4->Checked = TRUE; break;
	}


	// Mirror reversal
	if(m_pCArtCamSdk->GetMirrorV())	CheckMirrorV->Checked = TRUE;
	if(m_pCArtCamSdk->GetMirrorH())	CheckMirrorH->Checked = TRUE;

	// Horizotal reversal
	if(ARTCAM_CAMERATYPE_036MI != m_DllType){
		CheckMirrorH->Enabled = FALSE;
	}

	// Vertical reversal is not available in following models.
	switch(m_DllType){
	case ARTCAM_CAMERATYPE_DS:
	case ARTCAM_CAMERATYPE_USTC:
	case ARTCAM_CAMERATYPE_CNV:
	case ARTCAM_CAMERATYPE_150P:
	case ARTCAM_CAMERATYPE_150P2:
	case ARTCAM_CAMERATYPE_098:
		CheckMirrorV->Enabled = FALSE;
	break;
	}


	// Auto iris
	Error = FALSE;
	Data = m_pCArtCamSdk->GetAutoIris(&Error);
	switch(Data){
	case AI_NONE:		RadioAI1->Checked = TRUE;	break;
	case AI_EXPOSURE:	RadioAI2->Checked = TRUE;	break;
	case AI_GAIN:		RadioAI3->Checked = TRUE;	break;
	}

	if(!Error){
		RadioAI1->Enabled = FALSE;
		RadioAI2->Enabled = FALSE;
		RadioAI3->Enabled = FALSE;
	}

	// Camera without shutter function
	switch(m_DllType){
	case ARTCAM_CAMERATYPE_150P:
	case ARTCAM_CAMERATYPE_320P:
	case ARTCAM_CAMERATYPE_098:
		RadioAI2->Enabled = FALSE;
	break;
	}


	// Half clock
	Error = FALSE;
	if(m_pCArtCamSdk->GetHalfClock(&Error))	CheckHalfClock->Checked = TRUE;
	if(!Error){
		CheckHalfClock->Enabled = FALSE;
	}


	// Channel
	if(ARTCAM_CAMERATYPE_CNV != m_DllType){
		RadioChannel1->Enabled = FALSE;
		RadioChannel2->Enabled = FALSE;
		RadioChannel3->Enabled = FALSE;
		RadioChannel4->Enabled = FALSE;
		RadioChannel5->Enabled = FALSE;
		RadioChannel6->Enabled = FALSE;
	}

	m_Init = TRUE;
}
//---------------------------------------------------------------------------


BOOL TForm2::InitControl(LONG FilterType, TEdit* Edit, TUpDown* UpDonw, LONG Min, LONG Max)
{
	BOOL Error = 0;
	LONG Data = m_pCArtCamSdk->GetFilterValue(FilterType, &Error);


	// Error occurrence(no response)
	if(!Error){
		Edit->Enabled = FALSE;
		return FALSE;
	}

	UpDonw->Min = Min;
	UpDonw->Max = Max;
	Edit->Text = IntToStr(Data);

	return TRUE;
}
//---------------------------------------------------------------------------

void __fastcall TForm2::Button1Click(TObject *Sender)
{
	m_Init = FALSE;
	Hide();
}
//---------------------------------------------------------------------------

void __fastcall TForm2::CheckAWBClick(TObject *Sender)
{
	if(CheckAWB->Checked){
		m_pCArtCamSdk->SetFilterValue(ARTCAM_FILTERTYPE_BAYER_GAIN_AUTO, TRUE);
	} else {
		m_pCArtCamSdk->SetFilterValue(ARTCAM_FILTERTYPE_BAYER_GAIN_AUTO, FALSE);
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm2::RadioBayer1Click(TObject *Sender)
{
	m_pCArtCamSdk->SetFilterValue(ARTCAM_FILTERTYPE_BAYERMODE, 0);
}
//---------------------------------------------------------------------------

void __fastcall TForm2::RadioBayer2Click(TObject *Sender)
{
	m_pCArtCamSdk->SetFilterValue(ARTCAM_FILTERTYPE_BAYERMODE, 1);
}
//---------------------------------------------------------------------------


void __fastcall TForm2::RadioBayer3Click(TObject *Sender)
{
	m_pCArtCamSdk->SetFilterValue(ARTCAM_FILTERTYPE_BAYERMODE, 2);

}
//---------------------------------------------------------------------------

void __fastcall TForm2::RadioBayer4Click(TObject *Sender)
{
	m_pCArtCamSdk->SetFilterValue(ARTCAM_FILTERTYPE_BAYERMODE, 3);
}
//---------------------------------------------------------------------------

void __fastcall TForm2::RadioAI1Click(TObject *Sender)
{
	m_pCArtCamSdk->SetAutoIris(AI_NONE);

}
//---------------------------------------------------------------------------

void __fastcall TForm2::RadioAI2Click(TObject *Sender)
{
	m_pCArtCamSdk->SetAutoIris(AI_EXPOSURE);

}
//---------------------------------------------------------------------------

void __fastcall TForm2::RadioAI3Click(TObject *Sender)
{
	m_pCArtCamSdk->SetAutoIris(AI_GAIN);

}
//---------------------------------------------------------------------------

void __fastcall TForm2::CheckMirrorVClick(TObject *Sender)
{
	if(CheckMirrorV->Checked){
		m_pCArtCamSdk->SetMirrorV(TRUE);
	} else {
		m_pCArtCamSdk->SetMirrorV(FALSE);
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm2::CheckMirrorHClick(TObject *Sender)
{
	if(CheckMirrorH->Checked){
		m_pCArtCamSdk->SetMirrorH(TRUE);
	} else {
		m_pCArtCamSdk->SetMirrorH(FALSE);
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm2::CheckHalfClockClick(TObject *Sender)
{
	if(-1 != m_Preview){
		// To switch clock, display needs to be stopped.
//		SetCursor(::LoadCursor(NULL, IDC_WAIT));
		m_pCArtCamSdk->StopPreview();
	}

	LONG Flg = CheckHalfClock->Checked;
	m_pCArtCamSdk->SetHalfClock(Flg);

	if(-1 != m_Preview){
		// Resume display
		m_pCArtCamSdk->StartPreview();
//		SetCursor(::LoadCursor(NULL, IDC_ARROW));
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm2::RadioChannel1Click(TObject *Sender){	m_pCArtCamSdk->SetCrossbar(0, 0);	}
void __fastcall TForm2::RadioChannel2Click(TObject *Sender){	m_pCArtCamSdk->SetCrossbar(1, 0);	}
void __fastcall TForm2::RadioChannel3Click(TObject *Sender){	m_pCArtCamSdk->SetCrossbar(2, 0);	}
void __fastcall TForm2::RadioChannel4Click(TObject *Sender){	m_pCArtCamSdk->SetCrossbar(3, 0);	}
void __fastcall TForm2::RadioChannel5Click(TObject *Sender){	m_pCArtCamSdk->SetCrossbar(4, 0);	}
void __fastcall TForm2::RadioChannel6Click(TObject *Sender){	m_pCArtCamSdk->SetCrossbar(5, 0);	}
//---------------------------------------------------------------------------

void __fastcall TForm2::EditBrightnessChange(TObject *Sender)
{
	if(m_Init) m_pCArtCamSdk->SetBrightness(StrToInt(EditBrightness->Text));
}
//---------------------------------------------------------------------------

void __fastcall TForm2::EditContrastChange(TObject *Sender)
{
	if(m_Init) m_pCArtCamSdk->SetContrast(StrToInt(EditContrast->Text));
}
//---------------------------------------------------------------------------

void __fastcall TForm2::EditHueChange(TObject *Sender)
{
	if(m_Init) m_pCArtCamSdk->SetHue(StrToInt(EditHue->Text));
}
//---------------------------------------------------------------------------

void __fastcall TForm2::EditSaturationChange(TObject *Sender)
{
	if(m_Init) m_pCArtCamSdk->SetSaturation(StrToInt(EditSaturation->Text));
}
//---------------------------------------------------------------------------

void __fastcall TForm2::EditSharpnessChange(TObject *Sender)
{
	if(m_Init) m_pCArtCamSdk->SetSharpness(StrToInt(EditSharpness->Text));
}
//---------------------------------------------------------------------------

void __fastcall TForm2::EditGammaChange(TObject *Sender)
{
	if(m_Init) m_pCArtCamSdk->SetGamma(StrToInt(EditGamma->Text));
}
//---------------------------------------------------------------------------

void __fastcall TForm2::EditBayerGainRChange(TObject *Sender)
{
	if(m_Init) m_pCArtCamSdk->SetBayerGainRed(StrToInt(EditBayerGainR->Text));
}
//---------------------------------------------------------------------------

void __fastcall TForm2::EditBayerGainGChange(TObject *Sender)
{
	if(m_Init) m_pCArtCamSdk->SetBayerGainGreen(StrToInt(EditBayerGainG->Text));
}
//---------------------------------------------------------------------------

void __fastcall TForm2::EditBayerGainBChange(TObject *Sender)
{
	if(m_Init) m_pCArtCamSdk->SetBayerGainBlue(StrToInt(EditBayerGainB->Text));
}
//---------------------------------------------------------------------------

void __fastcall TForm2::EditGlobalGainChange(TObject *Sender)
{
	if(m_Init) m_pCArtCamSdk->SetGlobalGain(StrToInt(EditGlobalGain->Text));
}
//---------------------------------------------------------------------------

void __fastcall TForm2::EditColorGainRChange(TObject *Sender)
{
	if(m_Init) m_pCArtCamSdk->SetColorGainRed(StrToInt(EditColorGainR->Text));
}
//---------------------------------------------------------------------------

void __fastcall TForm2::EditColorGainG1Change(TObject *Sender)
{
	if(m_Init) m_pCArtCamSdk->SetColorGainGreen1(StrToInt(EditColorGainG1->Text));
}
//---------------------------------------------------------------------------

void __fastcall TForm2::EditColorGainG2Change(TObject *Sender)
{
	if(m_Init) m_pCArtCamSdk->SetColorGainGreen2(StrToInt(EditColorGainG2->Text));
}
//---------------------------------------------------------------------------

void __fastcall TForm2::EditColorGainBChange(TObject *Sender)
{
	if(m_Init) m_pCArtCamSdk->SetColorGainBlue(StrToInt(EditColorGainB->Text));
}
//---------------------------------------------------------------------------

void __fastcall TForm2::EditExposureTimeChange(TObject *Sender)
{
	if(m_Init) m_pCArtCamSdk->SetExposureTime(StrToInt(EditExposureTime->Text));
}
//---------------------------------------------------------------------------



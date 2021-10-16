//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
#include "Unit3.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"
TForm3 *Form3;
//---------------------------------------------------------------------------

__fastcall TForm3::TForm3(TComponent* Owner)
	: TForm(Owner)
{
	m_pCArtCamSdk = NULL;
}
//---------------------------------------------------------------------------

void __fastcall TForm3::FormShow(TObject *Sender)
{
	if(NULL == m_pCArtCamSdk){
		return;
	}

	// Change operation for each DLL
	// For each DLL function, please refer to manual.
	m_DllType = HIWORD(m_pCArtCamSdk->GetDllVersion());

	// Get camera information
	m_CameraInfo.lSize = sizeof(CAMERAINFO);
	m_pCArtCamSdk->GetCameraInfo(&m_CameraInfo);


	// Set size for camera
	InitCameraSize();

	// Set color mode
	InitColorMode();

	// Set information for sub-sampling.
	InitSubSample();

	// Initialize CNV.
	InitCNV();

	// Obtain sub-code
	InitSubCode();


	// Frame rate for Directshow
	if(ARTCAM_CAMERATYPE_DS == m_DllType){
		EditFps->Text = IntToStr(m_pCArtCamSdk->Fps());
	}
	// For all others, this is the waiting period between frames
	else {
		LabelFps->Caption = "Waiting time  (ms)";
		EditFps->Text = IntToStr(m_pCArtCamSdk->GetWaitTime());
	}

}
//---------------------------------------------------------------------------

//	This involves characteristics of each camera, and therefore settings need to be cleared seperated.
void TForm3::InitCameraSize()
{
	LONG lHT, lHS, lHE, lVT, lVS, lVE;

	// Cameras that do not allow size settings
	switch(m_DllType){
	case ARTCAM_CAMERATYPE_DS:
		EditHT->Enabled = False;
		EditHS->Enabled = False;
		EditVT->Enabled = False;
		EditVS->Enabled = False;

		EditHT->Text	= IntToStr(m_pCArtCamSdk->Width());
		EditHE->Text	= IntToStr(m_pCArtCamSdk->Width());
		EditHS->Text	= "0";
		EditVT->Text	= IntToStr(m_pCArtCamSdk->Height());
		EditVE->Text	= IntToStr(m_pCArtCamSdk->Height());
		EditVS->Text	= "0";
	break;

	case ARTCAM_CAMERATYPE_CNV:
	case ARTCAM_CAMERATYPE_098:
	case ARTCAM_CAMERATYPE_500P:
	case ARTCAM_CAMERATYPE_150P2:
		EditHT->Enabled = False;
		EditHE->Enabled = False;
		EditHS->Enabled = False;
		EditVT->Enabled = False;
		EditVE->Enabled = False;
		EditVS->Enabled = False;

		EditHT->Text	= IntToStr(m_pCArtCamSdk->Width());
		EditHE->Text	= IntToStr(m_pCArtCamSdk->Width());
		EditHS->Text	= "0";
		EditVT->Text	= IntToStr(m_pCArtCamSdk->Height());
		EditVE->Text	= IntToStr(m_pCArtCamSdk->Height());
		EditVS->Text	= "0";
	break;

	case ARTCAM_CAMERATYPE_130MI:
	case ARTCAM_CAMERATYPE_200MI:
	case ARTCAM_CAMERATYPE_300MI:
	case ARTCAM_CAMERATYPE_320P:
	case ARTCAM_CAMERATYPE_200SH:
		EditVT->Enabled = False;
		EditHT->Enabled = False;

		m_pCArtCamSdk->GetCaptureWindowEx(&lHT, &lHS, &lHE, &lVT, &lVS, &lVE);

		EditHT->Text	= IntToStr(lHT);
		EditHE->Text	= IntToStr(lHE);
		EditHS->Text	= IntToStr(lHS);
		EditVT->Text	= IntToStr(lVT);
		EditVE->Text	= IntToStr(lVE);
		EditVS->Text	= IntToStr(lVS);
	break;

	default:
		m_pCArtCamSdk->GetCaptureWindowEx(&lHT, &lHS, &lHE, &lVT, &lVS, &lVE);

		EditHT->Text	= IntToStr(lHT);
		EditHE->Text	= IntToStr(lHE);
		EditHS->Text	= IntToStr(lHS);
		EditVT->Text	= IntToStr(lVT);
		EditVE->Text	= IntToStr(lVE);
		EditVS->Text	= IntToStr(lVS);
	break;
	}

}
//---------------------------------------------------------------------------

void TForm3::InitColorMode()
{
	// Color number
	switch(m_pCArtCamSdk->GetColorMode()){
	case 8: 	RadioColor08->Checked = TRUE;	break;
	case 16:	RadioColor16->Checked = TRUE;	break;
	case 24:	RadioColor24->Checked = TRUE;	break;
	case 32:	RadioColor32->Checked = TRUE;	break;
	case 48:	RadioColor48->Checked = TRUE;	break;
	case 64:	RadioColor64->Checked = TRUE;	break;
	}

	switch(m_DllType){
	case ARTCAM_CAMERATYPE_DS:
		RadioColor08->Enabled = False;
		RadioColor16->Enabled = False;
		RadioColor32->Enabled = False;
		RadioColor48->Enabled = False;
		RadioColor64->Enabled = False;
	break;

	case ARTCAM_CAMERATYPE_CNV:
		RadioColor32->Enabled = False;
		RadioColor48->Enabled = False;
		RadioColor64->Enabled = False;
	break;

	case ARTCAM_CAMERATYPE_320P:
	case ARTCAM_CAMERATYPE_200SH:
		RadioColor16->Enabled = False;
		RadioColor32->Enabled = False;
		RadioColor48->Enabled = False;
		RadioColor64->Enabled = False;
	break;
	}
}
//---------------------------------------------------------------------------

void TForm3::InitSubSample()
{
	// Sub-sampling
	switch(m_pCArtCamSdk->GetSubSample()){
	case SUBSAMPLE_1:	RadioSubSample1->Checked = TRUE;	break;
	case SUBSAMPLE_2:	RadioSubSample2->Checked = TRUE;	break;
	case SUBSAMPLE_4:	RadioSubSample4->Checked = TRUE;	break;
	case SUBSAMPLE_8:	RadioSubSample8->Checked = TRUE;	break;
	}

	switch(m_DllType){
	case ARTCAM_CAMERATYPE_130MI:
	case ARTCAM_CAMERATYPE_200MI:
	case ARTCAM_CAMERATYPE_300MI:
		RadioSubSample8->Enabled = False;
	break;

	default:
		RadioSubSample1->Enabled = False;
		RadioSubSample2->Enabled = False;
		RadioSubSample4->Enabled = False;
		RadioSubSample8->Enabled = False;
	break;
	}
}
//---------------------------------------------------------------------------

void TForm3::InitCNV()
{
	// For CNV only
	if(ARTCAM_CAMERATYPE_CNV == m_DllType){
		switch(m_pCArtCamSdk->GetVideoFormat()){
		case VIDEOFORMAT_NTSC:		LabelVideo->Caption = "VideoFormat : NTSC";		break;
		case VIDEOFORMAT_PAL:		LabelVideo->Caption = "VideoFormat : PAL";		break;
		case VIDEOFORMAT_PALM:		LabelVideo->Caption = "VideoFormat : PALM";		break;
		case VIDEOFORMAT_SECAM:		LabelVideo->Caption = "VideoFormat : SECAM";	break;
		}

		switch(m_pCArtCamSdk->GetSamplingRate()){
		case WIDE_HISPEED:		RadioRateWH->Checked = TRUE;		break;
		case WIDE_LOWSPEED:		RadioRateWL->Checked = TRUE;		break;
		case NORMAL_HISPEED:	RadioRateNH->Checked = TRUE;		break;
		case NORMAL_LOWSPEED:	RadioRateNL->Checked = TRUE;		break;
		}
	}
	else {
		RadioRateWH->Enabled = False;
		RadioRateWL->Enabled = False;
		RadioRateNH->Enabled = False;
		RadioRateNL->Enabled = False;

		RadioChannel1->Enabled = False;
		RadioChannel2->Enabled = False;
		RadioChannel3->Enabled = False;
		RadioChannel4->Enabled = False;
		RadioChannel5->Enabled = False;
		RadioChannel6->Enabled = False;
	}
}
//---------------------------------------------------------------------------

void TForm3::InitSubCode()
{
	m_SubCode = FALSE;

	BOOL Error = FALSE;
	EditCode1->Text = IntToStr((BYTE)m_pCArtCamSdk->ReadSromID(0, &Error));

	if(!Error){
		EditCode1->Enabled = False;
		EditCode2->Enabled = False;
		EditCode3->Enabled = False;
		EditCode4->Enabled = False;
		EditCode5->Enabled = False;
		EditCode6->Enabled = False;
		EditCode7->Enabled = False;
		EditCode8->Enabled = False;

		CheckCode->Enabled = False;
		return;
	}

	EditCode2->Text = IntToStr((BYTE)m_pCArtCamSdk->ReadSromID(1, &Error));
	EditCode3->Text = IntToStr((BYTE)m_pCArtCamSdk->ReadSromID(2, &Error));
	EditCode4->Text = IntToStr((BYTE)m_pCArtCamSdk->ReadSromID(3, &Error));
	EditCode5->Text = IntToStr((BYTE)m_pCArtCamSdk->ReadSromID(4, &Error));
	EditCode6->Text = IntToStr((BYTE)m_pCArtCamSdk->ReadSromID(5, &Error));
	EditCode7->Text = IntToStr((BYTE)m_pCArtCamSdk->ReadSromID(6, &Error));
	EditCode8->Text = IntToStr((BYTE)m_pCArtCamSdk->ReadSromID(7, &Error));

	m_SubCode = TRUE;
}
//---------------------------------------------------------------------------

void __fastcall TForm3::Button1Click(TObject *Sender)
{
	// Check size before reflecting
	LONG lHT, lHS, lHE, lVT, lVS, lVE, lFps;
	lHT		= StrToInt(EditHT->Text);
	lHE		= StrToInt(EditHE->Text);
	lHS		= StrToInt(EditHS->Text);
	lVT		= StrToInt(EditVT->Text);
	lVE		= StrToInt(EditVE->Text);
	lVS		= StrToInt(EditVS->Text);
	lFps	= StrToInt(EditFps->Text);


	// Size 0 represents error
	if(0 == lVT || 0 == lVE || 0 == lHT || 0 == lHE){
		ShowMessage("Set size is wrong");
		return;
	}

	// Effective resolution larger than maximum resolution results in error.
	if( (lVT < lVE + lVS) || (lHT < lHE + lHS) ){
		ShowMessage("Set size is wrong");
		return;
	}

	if( (lVT > m_CameraInfo.lHeight) || (lHT > m_CameraInfo.lWidth) ){
		ShowMessage("Set size is wrong");
		return;
	}




	// When waiting period is set 0, there will be excessive load on CPU.
	if(ARTCAM_CAMERATYPE_DS != m_DllType){
		if(0 >= lFps){
			ShowMessage("Set at least 1 for waiting period. /n performance will deteriorate.");
			return;
		}
	}



	// Size & frame rate settings.
	switch(m_DllType){
	case ARTCAM_CAMERATYPE_DS:
		m_pCArtCamSdk->SetCaptureWindow(lHE, lVE, lFps);
	break;

	case ARTCAM_CAMERATYPE_CNV:
		if(RadioRateWH->Checked) m_pCArtCamSdk->SetSamplingRate(WIDE_HISPEED);
		if(RadioRateWL->Checked) m_pCArtCamSdk->SetSamplingRate(WIDE_LOWSPEED);
		if(RadioRateNH->Checked) m_pCArtCamSdk->SetSamplingRate(NORMAL_HISPEED);
		if(RadioRateNL->Checked) m_pCArtCamSdk->SetSamplingRate(NORMAL_LOWSPEED);

		if(RadioChannel1->Checked) m_pCArtCamSdk->SetCrossbar(0, 0);
		if(RadioChannel2->Checked) m_pCArtCamSdk->SetCrossbar(1, 0);
		if(RadioChannel3->Checked) m_pCArtCamSdk->SetCrossbar(2, 0);
		if(RadioChannel4->Checked) m_pCArtCamSdk->SetCrossbar(3, 0);
		if(RadioChannel5->Checked) m_pCArtCamSdk->SetCrossbar(4, 0);
		if(RadioChannel6->Checked) m_pCArtCamSdk->SetCrossbar(5, 0);
	break;

	case ARTCAM_CAMERATYPE_098:
	case ARTCAM_CAMERATYPE_500P:
	case ARTCAM_CAMERATYPE_150P2:
	break;

	default:
		m_pCArtCamSdk->SetCaptureWindowEx(lHT, lHS, lHE, lVT, lVS, lVE);
		m_pCArtCamSdk->SetWaitTime(lFps);
	break;
	}

	// Invalid values cannot be set at dialog
	// It reflects without modification
	// There is no problem since inactive camera returns error as well
	if(RadioSubSample1->Checked) m_pCArtCamSdk->SetSubSample(SUBSAMPLE_1);
	if(RadioSubSample2->Checked) m_pCArtCamSdk->SetSubSample(SUBSAMPLE_2);
	if(RadioSubSample4->Checked) m_pCArtCamSdk->SetSubSample(SUBSAMPLE_4);
	if(RadioSubSample8->Checked) m_pCArtCamSdk->SetSubSample(SUBSAMPLE_8);

	if(RadioColor08->Checked) m_pCArtCamSdk->SetColorMode( 8);
	if(RadioColor16->Checked) m_pCArtCamSdk->SetColorMode(16);
	if(RadioColor24->Checked) m_pCArtCamSdk->SetColorMode(24);
	if(RadioColor32->Checked) m_pCArtCamSdk->SetColorMode(32);
	if(RadioColor48->Checked) m_pCArtCamSdk->SetColorMode(48);
	if(RadioColor64->Checked) m_pCArtCamSdk->SetColorMode(64);


	// Write sub-code
	// Make sure writing is correct
	if(CheckCode->Checked){
		BYTE m_Code[8];
		m_Code[0]	= StrToInt(EditCode1->Text);
		m_Code[1]	= StrToInt(EditCode2->Text);
		m_Code[2]	= StrToInt(EditCode3->Text);
		m_Code[3]	= StrToInt(EditCode4->Text);
		m_Code[4]	= StrToInt(EditCode5->Text);
		m_Code[5]	= StrToInt(EditCode6->Text);
		m_Code[6]	= StrToInt(EditCode7->Text);
		m_Code[7]	= StrToInt(EditCode8->Text);

		m_pCArtCamSdk->WriteSromID(0, m_Code[0]);
		m_pCArtCamSdk->WriteSromID(1, m_Code[1]);
		m_pCArtCamSdk->WriteSromID(2, m_Code[2]);
		m_pCArtCamSdk->WriteSromID(3, m_Code[3]);
		m_pCArtCamSdk->WriteSromID(4, m_Code[4]);
		m_pCArtCamSdk->WriteSromID(5, m_Code[5]);
		m_pCArtCamSdk->WriteSromID(6, m_Code[6]);
		m_pCArtCamSdk->WriteSromID(7, m_Code[7]);
	}


	Form1->ReDraw();
	Hide();
}
//---------------------------------------------------------------------------

void __fastcall TForm3::Button2Click(TObject *Sender)
{
	Hide();
}
//---------------------------------------------------------------------------


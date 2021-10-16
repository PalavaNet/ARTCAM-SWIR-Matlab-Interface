// SetFilterDlg.cpp : Mounting file
//

#include "stdafx.h"
#include "Sample_MFC.h"
#include "SetFilterDlg.h"


// CSetFilterDlg Dialog

IMPLEMENT_DYNAMIC(CSetFilterDlg, CDialog)
CSetFilterDlg::CSetFilterDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CSetFilterDlg::IDD, pParent)
{
	m_Init = FALSE;
	m_DllType = -1;
	m_pCArtCamSdk = NULL;
	m_Preview = -1;
}

CSetFilterDlg::~CSetFilterDlg()
{
}

void CSetFilterDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CSetFilterDlg, CDialog)
	ON_BN_CLICKED(IDC_MIRROR_V, OnBnClickedMirrorV)
	ON_BN_CLICKED(IDC_MIRROR_H, OnBnClickedMirrorH)
	ON_BN_CLICKED(IDC_AWB, OnBnClickedAutoWB)
	ON_BN_CLICKED(IDR_BAYER1, OnBnClickedBayer1)
	ON_BN_CLICKED(IDR_BAYER2, OnBnClickedBayer2)
	ON_BN_CLICKED(IDR_BAYER3, OnBnClickedBayer3)
	ON_BN_CLICKED(IDR_BAYER4, OnBnClickedBayer4)
	ON_BN_CLICKED(IDR_AI1, OnBnClickedAi1)
	ON_BN_CLICKED(IDR_AI2, OnBnClickedAi2)
	ON_BN_CLICKED(IDR_AI3, OnBnClickedAi3)
	ON_BN_CLICKED(IDC_HALFCLOCK, OnBnClickedHalfclock)
	ON_BN_CLICKED(IDR_CHANNEL1, OnBnClickedChannel1)
	ON_BN_CLICKED(IDR_CHANNEL2, OnBnClickedChannel2)
	ON_BN_CLICKED(IDR_CHANNEL3, OnBnClickedChannel3)
	ON_BN_CLICKED(IDR_CHANNEL4, OnBnClickedChannel4)
	ON_BN_CLICKED(IDR_CHANNEL5, OnBnClickedChannel5)
	ON_BN_CLICKED(IDR_CHANNEL6, OnBnClickedChannel6)
END_MESSAGE_MAP()


// CSetFilterDlg Message handler

BOOL CSetFilterDlg::OnInitDialog()
{
	m_Init = FALSE;

	CDialog::OnInitDialog();


	// Change operation for each DLL
	// For each DLL function, please refer to manual.
	m_DllType = HIWORD(m_pCArtCamSdk->GetDllVersion());

	// Get camera information
	m_CameraInfo.lSize = sizeof(CAMERAINFO);
	m_pCArtCamSdk->GetCameraInfo(&m_CameraInfo);


	// Range for value is set while determination of availability is done. 
	if(ARTCAM_CAMERATYPE_CNV == m_DllType){
		InitControl(ARTCAM_FILTERTYPE_BRIGHTNESS,		IDE_BRIGHTNESS,		IDS_BRIGHTNESS,		0,	255);
		InitControl(ARTCAM_FILTERTYPE_CONTRAST,			IDE_CONTRAST,		IDS_CONTRAST,		0,	255);
		InitControl(ARTCAM_FILTERTYPE_HUE,				IDE_HUE,			IDS_HUE,			0,	255);
		InitControl(ARTCAM_FILTERTYPE_SATURATION,		IDE_SATURATION,		IDS_SATURATION,		0,	255);
		InitControl(ARTCAM_FILTERTYPE_SHARPNESS,		IDE_SHARPNESS,		IDS_SHARPNESS,		0,	  0);
		InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_R,		IDE_BAYER_GAIN_R,	IDS_BAYER_GAIN_R,	0,	  0);
		InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_G,		IDE_BAYER_GAIN_G,	IDS_BAYER_GAIN_G,	0,	  0);
		InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_B,		IDE_BAYER_GAIN_B,	IDS_BAYER_GAIN_B,	0,	  0);
		InitControl(ARTCAM_FILTERTYPE_GAMMA,			IDE_GAMMA,			IDS_GAMMA,			0,	  0);
	} else {
		InitControl(ARTCAM_FILTERTYPE_BRIGHTNESS,		IDE_BRIGHTNESS,		IDS_BRIGHTNESS,		-255,	255);
		InitControl(ARTCAM_FILTERTYPE_CONTRAST,			IDE_CONTRAST,		IDS_CONTRAST,		-127,	127);
		InitControl(ARTCAM_FILTERTYPE_HUE,				IDE_HUE,			IDS_HUE,			-360,	360);
		InitControl(ARTCAM_FILTERTYPE_SATURATION,		IDE_SATURATION,		IDS_SATURATION,		-255,	255);
		InitControl(ARTCAM_FILTERTYPE_SHARPNESS,		IDE_SHARPNESS,		IDS_SHARPNESS,		   0,	 30);
		InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_R,		IDE_BAYER_GAIN_R,	IDS_BAYER_GAIN_R,	   0,	400);
		InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_G,		IDE_BAYER_GAIN_G,	IDS_BAYER_GAIN_G,	   0,	400);
		InitControl(ARTCAM_FILTERTYPE_BAYER_GAIN_B,		IDE_BAYER_GAIN_B,	IDS_BAYER_GAIN_B,	   0,	400);
		InitControl(ARTCAM_FILTERTYPE_GAMMA,			IDE_GAMMA,			IDS_GAMMA,			   0,	200);
	}


	InitControl(ARTCAM_FILTERTYPE_GLOBAL_GAIN,		IDE_GLOBAL_GAIN,	IDS_GLOBAL_GAIN,	m_CameraInfo.lGlobalGainMin, m_CameraInfo.lGlobalGainMax);
	InitControl(ARTCAM_FILTERTYPE_COLOR_GAIN_R,		IDE_COLOR_GAIN_R,	IDS_COLOR_GAIN_R,	m_CameraInfo.lColorGainMin,  m_CameraInfo.lColorGainMax);
	InitControl(ARTCAM_FILTERTYPE_COLOR_GAIN_G1,	IDE_COLOR_GAIN_G1,	IDS_COLOR_GAIN_G1,	m_CameraInfo.lColorGainMin,  m_CameraInfo.lColorGainMax);
	InitControl(ARTCAM_FILTERTYPE_COLOR_GAIN_G2,	IDE_COLOR_GAIN_G2,	IDS_COLOR_GAIN_G2,	m_CameraInfo.lColorGainMin,  m_CameraInfo.lColorGainMax);
	InitControl(ARTCAM_FILTERTYPE_COLOR_GAIN_B,		IDE_COLOR_GAIN_B,	IDS_COLOR_GAIN_B,	m_CameraInfo.lColorGainMin,  m_CameraInfo.lColorGainMax);
	InitControl(ARTCAM_FILTERTYPE_EXPOSURETIME,		IDE_EXPOSURETIME,	IDS_EXPOSURETIME,	m_CameraInfo.lExposureMin,   m_CameraInfo.lExposureMax);


	// Auto white balance
	BOOL Error = FALSE;
	LONG Data = m_pCArtCamSdk->GetFilterValue(ARTCAM_FILTERTYPE_BAYER_GAIN_AUTO, &Error);
	if(!Error){
		GetDlgItem(IDC_AWB)->EnableWindow(FALSE);
	}
	if(Data){
		CheckDlgButton(IDC_AWB, BST_CHECKED);
	}


	// Bayer conversion mode
	Error = FALSE;
	Data = m_pCArtCamSdk->GetFilterValue(ARTCAM_FILTERTYPE_BAYERMODE, &Error);
	if(!Error){
		GetDlgItem(IDR_BAYER1)->EnableWindow(FALSE);
		GetDlgItem(IDR_BAYER2)->EnableWindow(FALSE);
		GetDlgItem(IDR_BAYER3)->EnableWindow(FALSE);
		GetDlgItem(IDR_BAYER4)->EnableWindow(FALSE);
	}

	switch(Data){
	case 0:	CheckDlgButton(IDR_BAYER1, BST_CHECKED); break;
	case 1:	CheckDlgButton(IDR_BAYER2, BST_CHECKED); break; 
	case 2:	CheckDlgButton(IDR_BAYER3, BST_CHECKED); break;
	case 3:	CheckDlgButton(IDR_BAYER4, BST_CHECKED); break;
	}


	// Mirror reversal
	if(m_pCArtCamSdk->GetMirrorV())	CheckDlgButton(IDC_MIRROR_V, BST_CHECKED);
	if(m_pCArtCamSdk->GetMirrorH())	CheckDlgButton(IDC_MIRROR_H, BST_CHECKED);

	// Horizotal reversal
	switch(m_DllType){
	case ARTCAM_CAMERATYPE_036MI:
	case ARTCAM_CAMERATYPE_200MI:
	case ARTCAM_CAMERATYPE_900MI:
	break;
	default:
		GetDlgItem(IDC_MIRROR_H)->EnableWindow(FALSE);
	}

	// Vertical reversal is not available in following models.
	switch(m_DllType){
	case ARTCAM_CAMERATYPE_DS:
	case ARTCAM_CAMERATYPE_USTC:
	case ARTCAM_CAMERATYPE_CNV:
	case ARTCAM_CAMERATYPE_150P:
	case ARTCAM_CAMERATYPE_150P2:
	case ARTCAM_CAMERATYPE_098:
		GetDlgItem(IDC_MIRROR_V)->EnableWindow(FALSE);
	break;
	}


	// Auto iris
	Error = FALSE;
	Data = m_pCArtCamSdk->GetAutoIris(&Error);
	switch(Data){
	case AI_NONE:		CheckDlgButton(IDR_AI1, BST_CHECKED);	break;
	case AI_EXPOSURE:	CheckDlgButton(IDR_AI2, BST_CHECKED);	break;
	case AI_GAIN:		CheckDlgButton(IDR_AI3, BST_CHECKED);	break;
	}

	if(!Error){
		GetDlgItem(IDR_AI1)->EnableWindow(FALSE);
		GetDlgItem(IDR_AI2)->EnableWindow(FALSE);
		GetDlgItem(IDR_AI3)->EnableWindow(FALSE);
	}

	// Camera without shutter function
	switch(m_DllType){
	case ARTCAM_CAMERATYPE_150P:
	case ARTCAM_CAMERATYPE_320P:
	case ARTCAM_CAMERATYPE_098:
		GetDlgItem(IDR_AI2)->EnableWindow(FALSE);
	break;
	}


	// Half clock
	Error = FALSE;
	if(m_pCArtCamSdk->GetHalfClock(&Error))	CheckDlgButton(IDC_HALFCLOCK, BST_CHECKED);
	if(!Error){
		GetDlgItem(IDC_HALFCLOCK)->EnableWindow(FALSE);
	}


	// Channel
	if(ARTCAM_CAMERATYPE_CNV != m_DllType){
		GetDlgItem(IDR_CHANNEL1)->EnableWindow(FALSE);
		GetDlgItem(IDR_CHANNEL2)->EnableWindow(FALSE);
		GetDlgItem(IDR_CHANNEL3)->EnableWindow(FALSE);
		GetDlgItem(IDR_CHANNEL4)->EnableWindow(FALSE);
		GetDlgItem(IDR_CHANNEL5)->EnableWindow(FALSE);
		GetDlgItem(IDR_CHANNEL6)->EnableWindow(FALSE);
	}

	m_Init = TRUE;

	return TRUE;
}


BOOL CSetFilterDlg::InitControl(LONG FilterType, UINT EditID, UINT SpinID, LONG Min, LONG Max)
{
	BOOL Error = 0;
	LONG Data = m_pCArtCamSdk->GetFilterValue(FilterType, &Error);


	CSpinButtonCtrl* Spin = (CSpinButtonCtrl*)GetDlgItem(SpinID);
	if(Spin){
		Spin->SetRange32(int(Min), int(Max));
		Spin->SetPos(Data);
		Spin->SetBuddy(GetDlgItem(EditID));
	}

	// Error occurrence(no response)
	if(!Error){
		GetDlgItem(EditID)->EnableWindow(FALSE);
		return FALSE;
	}

	SetDlgItemInt(EditID, Data);

	return TRUE;
}


void CSetFilterDlg::OnOK()
{

	CDialog::OnOK();
}

void CSetFilterDlg::OnCancel()
{

	CDialog::OnCancel();
}


BOOL CSetFilterDlg::OnCommand(WPARAM wParam, LPARAM lParam)
{
	if(EN_CHANGE == HIWORD(wParam)){
		switch(LOWORD(wParam)){
		case IDE_BRIGHTNESS:	SetControl(ARTCAM_FILTERTYPE_BRIGHTNESS,	IDE_BRIGHTNESS,		IDS_BRIGHTNESS);	break;
		case IDE_CONTRAST:		SetControl(ARTCAM_FILTERTYPE_CONTRAST,		IDE_CONTRAST,		IDS_CONTRAST);		break;
		case IDE_HUE:			SetControl(ARTCAM_FILTERTYPE_HUE,			IDE_HUE,			IDS_HUE);			break;
		case IDE_SATURATION:	SetControl(ARTCAM_FILTERTYPE_SATURATION,	IDE_SATURATION,		IDS_SATURATION);	break;
		case IDE_SHARPNESS:		SetControl(ARTCAM_FILTERTYPE_SHARPNESS,		IDE_SHARPNESS,		IDS_SHARPNESS);		break;
		case IDE_BAYER_GAIN_R:	SetControl(ARTCAM_FILTERTYPE_BAYER_GAIN_R,	IDE_BAYER_GAIN_R,	IDS_BAYER_GAIN_R);	break;
		case IDE_BAYER_GAIN_G:	SetControl(ARTCAM_FILTERTYPE_BAYER_GAIN_G,	IDE_BAYER_GAIN_G,	IDS_BAYER_GAIN_G);	break;
		case IDE_BAYER_GAIN_B:	SetControl(ARTCAM_FILTERTYPE_BAYER_GAIN_B,	IDE_BAYER_GAIN_B,	IDS_BAYER_GAIN_B);	break;
		case IDE_GAMMA:			SetControl(ARTCAM_FILTERTYPE_GAMMA,			IDE_GAMMA,			IDS_GAMMA);			break;
		case IDE_GLOBAL_GAIN:	SetControl(ARTCAM_FILTERTYPE_GLOBAL_GAIN,	IDE_GLOBAL_GAIN,	IDS_GLOBAL_GAIN);	break;
		case IDE_COLOR_GAIN_R:	SetControl(ARTCAM_FILTERTYPE_COLOR_GAIN_R,	IDE_COLOR_GAIN_R,	IDS_COLOR_GAIN_R);	break;
		case IDE_COLOR_GAIN_G1:	SetControl(ARTCAM_FILTERTYPE_COLOR_GAIN_G1,	IDE_COLOR_GAIN_G1,	IDS_COLOR_GAIN_G1);	break;
		case IDE_COLOR_GAIN_G2:	SetControl(ARTCAM_FILTERTYPE_COLOR_GAIN_G2,	IDE_COLOR_GAIN_G2,	IDS_COLOR_GAIN_G2);	break;
		case IDE_COLOR_GAIN_B:	SetControl(ARTCAM_FILTERTYPE_COLOR_GAIN_B,	IDE_COLOR_GAIN_B,	IDS_COLOR_GAIN_B);	break;
		case IDE_EXPOSURETIME:	SetControl(ARTCAM_FILTERTYPE_EXPOSURETIME,	IDE_EXPOSURETIME,	IDS_EXPOSURETIME);	break;
		}
	}

	return CDialog::OnCommand(wParam, lParam);
}



BOOL CSetFilterDlg::SetControl(LONG FilterType, UINT EditID, UINT SpinID)
{
	if(m_Init){
		LONG Data = GetDlgItemInt(EditID);

		// Set the value to spin (rounds automatically by determining whether it is moving range or not).
		CSpinButtonCtrl* Spin = (CSpinButtonCtrl*)GetDlgItem(SpinID);
		if(Spin){
			Spin->SetPos(Data);

			// Re-acquisition
			Data = GetDlgItemInt(EditID);
		}

		m_pCArtCamSdk->SetFilterValue(FilterType, Data);
	}

	return TRUE;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Mirror reversal
//

void CSetFilterDlg::OnBnClickedMirrorV()
{
	if(IsDlgButtonChecked(IDC_MIRROR_V)){
		m_pCArtCamSdk->SetMirrorV(TRUE);
	} else {
		m_pCArtCamSdk->SetMirrorV(FALSE);
	}
}

void CSetFilterDlg::OnBnClickedMirrorH()
{
	if(IsDlgButtonChecked(IDC_MIRROR_H)){
		m_pCArtCamSdk->SetMirrorH(TRUE);
	} else {
		m_pCArtCamSdk->SetMirrorH(FALSE);
	}
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Auto white balance
//

void CSetFilterDlg::OnBnClickedAutoWB()
{
	if(IsDlgButtonChecked(IDC_AWB)){
		m_pCArtCamSdk->SetFilterValue(ARTCAM_FILTERTYPE_BAYER_GAIN_AUTO, TRUE);
	} else {
		m_pCArtCamSdk->SetFilterValue(ARTCAM_FILTERTYPE_BAYER_GAIN_AUTO, FALSE);
	}
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Bayer conversion mode
//

void CSetFilterDlg::OnBnClickedBayer1()
{
	m_pCArtCamSdk->SetFilterValue(ARTCAM_FILTERTYPE_BAYERMODE, 0);
}

void CSetFilterDlg::OnBnClickedBayer2()
{
	m_pCArtCamSdk->SetFilterValue(ARTCAM_FILTERTYPE_BAYERMODE, 1);
}

void CSetFilterDlg::OnBnClickedBayer3()
{
	m_pCArtCamSdk->SetFilterValue(ARTCAM_FILTERTYPE_BAYERMODE, 2);
}

void CSetFilterDlg::OnBnClickedBayer4()
{
	m_pCArtCamSdk->SetFilterValue(ARTCAM_FILTERTYPE_BAYERMODE, 3);
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Auto iris
//

void CSetFilterDlg::OnBnClickedAi1()
{
	m_pCArtCamSdk->SetAutoIris(AI_NONE);
}

void CSetFilterDlg::OnBnClickedAi2()
{
	m_pCArtCamSdk->SetAutoIris(AI_EXPOSURE);
}

void CSetFilterDlg::OnBnClickedAi3()
{
	m_pCArtCamSdk->SetAutoIris(AI_GAIN);
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Half clock
//

void CSetFilterDlg::OnBnClickedHalfclock()
{
	LONG Flg = IsDlgButtonChecked(IDC_HALFCLOCK);
	if(-1 != m_Preview){
		// To switch clock, display needs to be stopped.
		SetCursor(::LoadCursor(NULL, IDC_WAIT));
		m_pCArtCamSdk->StopPreview();
	}
	m_pCArtCamSdk->SetHalfClock(Flg);

	if(-1 != m_Preview){
		// Resume display
		m_pCArtCamSdk->StartPreview();
		SetCursor(::LoadCursor(NULL, IDC_ARROW));
	}
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Change Channels
//

void CSetFilterDlg::OnBnClickedChannel1(){	m_pCArtCamSdk->SetCrossbar(0, 0);	}
void CSetFilterDlg::OnBnClickedChannel2(){	m_pCArtCamSdk->SetCrossbar(1, 0);	}
void CSetFilterDlg::OnBnClickedChannel3(){	m_pCArtCamSdk->SetCrossbar(2, 0);	}
void CSetFilterDlg::OnBnClickedChannel4(){	m_pCArtCamSdk->SetCrossbar(3, 0);	}
void CSetFilterDlg::OnBnClickedChannel5(){	m_pCArtCamSdk->SetCrossbar(4, 0);	}
void CSetFilterDlg::OnBnClickedChannel6(){	m_pCArtCamSdk->SetCrossbar(5, 0);	}


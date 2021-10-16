// SetSizeDlg.cpp : Mounting file
//

#include "stdafx.h"
#include "Sample_MFC.h"
#include "SetSizeDlg.h"


// CSetSizeDlg Dialog

IMPLEMENT_DYNAMIC(CSetSizeDlg, CDialog)
CSetSizeDlg::CSetSizeDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CSetSizeDlg::IDD, pParent)
	, m_TV(0)
	, m_EV(0)
	, m_EVS(0)
	, m_TH(0)
	, m_EH(0)
	, m_EHS(0)
	, m_FPS(0)
	, m_SubSample(FALSE)
	, m_ColorMode(FALSE)
	, m_SamplingRate(FALSE)
	, m_Channel(FALSE)
	, m_Code1(0)
	, m_Code2(0)
	, m_Code3(0)
	, m_Code4(0)
	, m_Code5(0)
	, m_Code6(0)
	, m_Code7(0)
	, m_Code8(0)
{
	m_Init = FALSE;
	m_SubCode = FALSE;
	m_pCArtCamSdk = NULL;
	m_DllType = -1;
}

CSetSizeDlg::~CSetSizeDlg()
{
}

void CSetSizeDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDE_TV, m_TV);
	DDX_Text(pDX, IDE_EV, m_EV);
	DDX_Text(pDX, IDE_EVS, m_EVS);
	DDX_Text(pDX, IDE_TH, m_TH);
	DDX_Text(pDX, IDE_EH, m_EH);
	DDX_Text(pDX, IDE_EHS, m_EHS);
	DDX_Text(pDX, IDE_FPS, m_FPS);
	DDX_Radio(pDX, IDR_SUBSAMPLE1, m_SubSample);
	DDX_Radio(pDX, IDR_COLOR8, m_ColorMode);
	DDX_Radio(pDX, IDR_RATE_WH, m_SamplingRate);
	DDX_Radio(pDX, IDR_CHANNEL1, m_Channel);
	DDX_Text(pDX, IDE_CODE1, m_Code1);
	DDX_Text(pDX, IDE_CODE2, m_Code2);
	DDX_Text(pDX, IDE_CODE3, m_Code3);
	DDX_Text(pDX, IDE_CODE4, m_Code4);
	DDX_Text(pDX, IDE_CODE5, m_Code5);
	DDX_Text(pDX, IDE_CODE6, m_Code6);
	DDX_Text(pDX, IDE_CODE7, m_Code7);
	DDX_Text(pDX, IDE_CODE8, m_Code8);
}


BEGIN_MESSAGE_MAP(CSetSizeDlg, CDialog)
END_MESSAGE_MAP()


// CSetSizeDlg Message handler

BOOL CSetSizeDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	m_Init = FALSE;

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
		m_FPS = m_pCArtCamSdk->Fps();
	}
	// For all others, this is the waiting period between frames
	else {
		SetDlgItemText(IDS_FPS, _T("Waiting time  (ms)"));
		m_FPS = m_pCArtCamSdk->GetWaitTime();
	}


	UpdateData(FALSE);

	m_Init = TRUE;

	return TRUE;
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Reflect setting
//

void CSetSizeDlg::OnOK()
{
	// Check size before reflecting
	UpdateData(TRUE);


	// Size 0 represents error
	if(0 == m_TV || 0 == m_EV || 0 == m_TH || 0 == m_EH){
		AfxMessageBox(_T("Set size is wrong"), MB_ICONERROR | MB_OK);
		return;
	}

	// Effective resolution larger than maximum resolution results in error.
	if( (m_TV < m_EV + m_EVS) || (m_TH < m_EH + m_EHS) ){
		AfxMessageBox(_T("Set size is wrong"), MB_ICONERROR | MB_OK);
		return;
	}

	if( (m_TV > m_CameraInfo.lHeight) || (m_TH > m_CameraInfo.lWidth) ){
		AfxMessageBox(_T("Set size is wrong"), MB_ICONERROR | MB_OK);
//		return;
	}




	// When waiting period is set 0, there will be excessive load on CPU.
	if(ARTCAM_CAMERATYPE_DS != m_DllType){
		if(0 >= m_FPS){
			AfxMessageBox(_T("Set at least 1 for waiting period. /n performance will deteriorate."), MB_ICONERROR | MB_OK);
			return;
		}
	}



	// Size & frame rate settings.
	switch(m_DllType){
	case ARTCAM_CAMERATYPE_DS:
		m_pCArtCamSdk->SetCaptureWindow(m_EH, m_EV, m_FPS);
	break;

	case ARTCAM_CAMERATYPE_CNV:
		m_pCArtCamSdk->SetSamplingRate(m_SamplingRate);
		m_pCArtCamSdk->SetCrossbar(m_Channel, 0);
	break;

	case ARTCAM_CAMERATYPE_098:
	case ARTCAM_CAMERATYPE_500P:
	case ARTCAM_CAMERATYPE_150P2:
	case ARTCAM_CAMERATYPE_150P3:
	case ARTCAM_CAMERATYPE_267KY:
	case ARTCAM_CAMERATYPE_274KY:
	case ARTCAM_CAMERATYPE_625KY:
	case ARTCAM_CAMERATYPE_445KY:
	break;

	default:
		m_pCArtCamSdk->SetCaptureWindowEx(m_TH, m_EHS, m_EH, m_TV, m_EVS, m_EV);
		m_pCArtCamSdk->SetWaitTime(m_FPS);
	break;
	}


	// Invalid values cannot be set at dialog
	// It reflects without modification
	// There is no problem since inactive camera returns error as well
	switch(m_SubSample){
	case 0:	m_pCArtCamSdk->SetSubSample(SUBSAMPLE_1);	break;
	case 1:	m_pCArtCamSdk->SetSubSample(SUBSAMPLE_2);	break;
	case 2:	m_pCArtCamSdk->SetSubSample(SUBSAMPLE_4);	break;
	case 3:	m_pCArtCamSdk->SetSubSample(SUBSAMPLE_8);	break;
	case 4:	m_pCArtCamSdk->SetSubSample(BINNING_2);		break;
	case 5:	m_pCArtCamSdk->SetSubSample(BINNING_4);		break;
	}

	switch(m_ColorMode){
	case 0:	m_pCArtCamSdk->SetColorMode( 8);	break;
	case 1:	m_pCArtCamSdk->SetColorMode(16);	break;
	case 2:	m_pCArtCamSdk->SetColorMode(24);	break;
	case 3:	m_pCArtCamSdk->SetColorMode(32);	break;
	case 4:	m_pCArtCamSdk->SetColorMode(48);	break;
	case 5:	m_pCArtCamSdk->SetColorMode(64);	break;
	}


	// Write sub-code
	// Make sure writing is correct
	if(IsDlgButtonChecked(IDC_WRITECODE)){
		m_pCArtCamSdk->WriteSromID(0, m_Code1);
		m_pCArtCamSdk->WriteSromID(1, m_Code2);
		m_pCArtCamSdk->WriteSromID(2, m_Code3);
		m_pCArtCamSdk->WriteSromID(3, m_Code4);
		m_pCArtCamSdk->WriteSromID(4, m_Code5);
		m_pCArtCamSdk->WriteSromID(5, m_Code6);
		m_pCArtCamSdk->WriteSromID(6, m_Code7);
		m_pCArtCamSdk->WriteSromID(7, m_Code8);
	}

	CDialog::OnOK();
}

void CSetSizeDlg::OnCancel()
{

	CDialog::OnCancel();
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	This involves characteristics of each camera, and therefore settings need to be cleared seperated.
//

void CSetSizeDlg::InitCameraSize()
{
	// Cameras that do not allow size settings
	LONG Size[6]={0,0,0,0,0,0};
	switch(m_DllType){
	case ARTCAM_CAMERATYPE_DS:
		GetDlgItem(IDE_TV)->EnableWindow(FALSE);
		GetDlgItem(IDE_EVS)->EnableWindow(FALSE);
		GetDlgItem(IDE_TH)->EnableWindow(FALSE);
		GetDlgItem(IDE_EHS)->EnableWindow(FALSE);

		m_TV	= m_pCArtCamSdk->Height();
		m_EV	= m_pCArtCamSdk->Height();
		m_EVS	= 0;
		m_TH	= m_pCArtCamSdk->Width();
		m_EH	= m_pCArtCamSdk->Width();
		m_EHS	= 0;
	break;

	case ARTCAM_CAMERATYPE_CNV:
	case ARTCAM_CAMERATYPE_098:
	case ARTCAM_CAMERATYPE_500P:
	case ARTCAM_CAMERATYPE_150P2:
	case ARTCAM_CAMERATYPE_150P3:
	case ARTCAM_CAMERATYPE_267KY:
	case ARTCAM_CAMERATYPE_274KY:
	case ARTCAM_CAMERATYPE_625KY:
	case ARTCAM_CAMERATYPE_445KY:

		GetDlgItem(IDE_TV)->EnableWindow(FALSE);
		GetDlgItem(IDE_EV)->EnableWindow(FALSE);
		GetDlgItem(IDE_EVS)->EnableWindow(FALSE);
		GetDlgItem(IDE_TH)->EnableWindow(FALSE);
		GetDlgItem(IDE_EH)->EnableWindow(FALSE);
		GetDlgItem(IDE_EHS)->EnableWindow(FALSE);

		m_TV	= m_pCArtCamSdk->Height();
		m_EV	= m_pCArtCamSdk->Height();
		m_EVS	= 0;
		m_TH	= m_pCArtCamSdk->Width();
		m_EH	= m_pCArtCamSdk->Width();
		m_EHS	= 0;
	break;

	case ARTCAM_CAMERATYPE_130MI:
	case ARTCAM_CAMERATYPE_200MI:
	case ARTCAM_CAMERATYPE_300MI:
	case ARTCAM_CAMERATYPE_320P:
	case ARTCAM_CAMERATYPE_200SH:
	case ARTCAM_CAMERATYPE_130MI_MOUT:
		GetDlgItem(IDE_TV)->EnableWindow(FALSE);
		GetDlgItem(IDE_TH)->EnableWindow(FALSE);
		m_pCArtCamSdk->GetCaptureWindowEx(&m_TH, &m_EHS, &m_EH, &m_TV, &m_EVS, &m_EV);
	break;

	default:
		m_pCArtCamSdk->GetCaptureWindowEx(&m_TH, &m_EHS, &m_EH, &m_TV, &m_EVS, &m_EV);
	break;
	}

}

void CSetSizeDlg::InitColorMode()
{
	// Color number
	switch((m_pCArtCamSdk->GetColorMode() + 7) & ~7){
	case 8: 	m_ColorMode = 0;	break;
	case 16:	m_ColorMode = 1;	break;
	case 24:	m_ColorMode = 2;	break;
	case 32:	m_ColorMode = 3;	break;
	case 48:	m_ColorMode = 4;	break;
	case 64:	m_ColorMode = 5;	break;
	}

	switch(m_DllType){
	case ARTCAM_CAMERATYPE_DS:
		GetDlgItem(IDR_COLOR8 )->EnableWindow(FALSE);
		GetDlgItem(IDR_COLOR16)->EnableWindow(FALSE);
		GetDlgItem(IDR_COLOR32)->EnableWindow(FALSE);
		GetDlgItem(IDR_COLOR48)->EnableWindow(FALSE);
		GetDlgItem(IDR_COLOR64)->EnableWindow(FALSE);
	break;

	case ARTCAM_CAMERATYPE_CNV:
		GetDlgItem(IDR_COLOR32)->EnableWindow(FALSE);
		GetDlgItem(IDR_COLOR48)->EnableWindow(FALSE);
		GetDlgItem(IDR_COLOR64)->EnableWindow(FALSE);
	break;

	case ARTCAM_CAMERATYPE_320P:
	case ARTCAM_CAMERATYPE_200SH:
		GetDlgItem(IDR_COLOR16)->EnableWindow(FALSE);
		GetDlgItem(IDR_COLOR32)->EnableWindow(FALSE);
		GetDlgItem(IDR_COLOR48)->EnableWindow(FALSE);
		GetDlgItem(IDR_COLOR64)->EnableWindow(FALSE);
	break;
	}
}

void CSetSizeDlg::InitSubSample()
{
	// Sub-sampling
	switch(m_pCArtCamSdk->GetSubSample()){
	case SUBSAMPLE_1:	m_SubSample = 0;	break;
	case SUBSAMPLE_2:	m_SubSample = 1;	break;
	case SUBSAMPLE_4:	m_SubSample = 2;	break;
	case SUBSAMPLE_8:	m_SubSample = 3;	break;
	case BINNING_2:		m_SubSample = 4;	break;
	case BINNING_4:		m_SubSample = 5;	break;
	}
}

void CSetSizeDlg::InitCNV()
{
	// For CNV only
	if(ARTCAM_CAMERATYPE_CNV == m_DllType){
		switch(m_pCArtCamSdk->GetVideoFormat()){
		case VIDEOFORMAT_NTSC:		SetDlgItemText(IDS_VIDEO, _T("VideoFormat : NTSC"));	break;
		case VIDEOFORMAT_PAL:		SetDlgItemText(IDS_VIDEO, _T("VideoFormat : PAL"));		break;
		case VIDEOFORMAT_PALM:		SetDlgItemText(IDS_VIDEO, _T("VideoFormat : PALM"));	break;
		case VIDEOFORMAT_SECAM:		SetDlgItemText(IDS_VIDEO, _T("VideoFormat : SECAM"));	break;
		}

		switch(m_pCArtCamSdk->GetSamplingRate()){
		case WIDE_HISPEED:		m_SamplingRate = 0;		break;
		case WIDE_LOWSPEED:		m_SamplingRate = 1;		break;
		case NORMAL_HISPEED:	m_SamplingRate = 2;		break;
		case NORMAL_LOWSPEED:	m_SamplingRate = 3;		break;
		}
	}
	else {
		GetDlgItem(IDR_RATE_WH)->EnableWindow(FALSE);
		GetDlgItem(IDR_RATE_WL)->EnableWindow(FALSE);
		GetDlgItem(IDR_RATE_NH)->EnableWindow(FALSE);
		GetDlgItem(IDR_RATE_NL)->EnableWindow(FALSE);

		GetDlgItem(IDR_CHANNEL1)->EnableWindow(FALSE);
		GetDlgItem(IDR_CHANNEL2)->EnableWindow(FALSE);
		GetDlgItem(IDR_CHANNEL3)->EnableWindow(FALSE);
		GetDlgItem(IDR_CHANNEL4)->EnableWindow(FALSE);
		GetDlgItem(IDR_CHANNEL5)->EnableWindow(FALSE);
		GetDlgItem(IDR_CHANNEL6)->EnableWindow(FALSE);
	}
}


void CSetSizeDlg::InitSubCode()
{
	BOOL Error = FALSE;
	m_Code1 = (BYTE)m_pCArtCamSdk->ReadSromID(0, &Error);
	if(!Error){
		GetDlgItem(IDE_CODE1)->EnableWindow(FALSE);
		GetDlgItem(IDE_CODE2)->EnableWindow(FALSE);
		GetDlgItem(IDE_CODE3)->EnableWindow(FALSE);
		GetDlgItem(IDE_CODE4)->EnableWindow(FALSE);
		GetDlgItem(IDE_CODE5)->EnableWindow(FALSE);
		GetDlgItem(IDE_CODE6)->EnableWindow(FALSE);
		GetDlgItem(IDE_CODE7)->EnableWindow(FALSE);
		GetDlgItem(IDE_CODE8)->EnableWindow(FALSE);

		GetDlgItem(IDC_WRITECODE)->EnableWindow(FALSE);
		return;
	}

	m_Code2 = (BYTE)m_pCArtCamSdk->ReadSromID(1, &Error);
	m_Code3 = (BYTE)m_pCArtCamSdk->ReadSromID(2, &Error);
	m_Code4 = (BYTE)m_pCArtCamSdk->ReadSromID(3, &Error);
	m_Code5 = (BYTE)m_pCArtCamSdk->ReadSromID(4, &Error);
	m_Code6 = (BYTE)m_pCArtCamSdk->ReadSromID(5, &Error);
	m_Code7 = (BYTE)m_pCArtCamSdk->ReadSromID(6, &Error);
	m_Code8 = (BYTE)m_pCArtCamSdk->ReadSromID(7, &Error);

	m_SubCode = TRUE;
}





// SetMonitorDlg.cpp : Mounting file
//

#include "stdafx.h"
#include "Sample_MFC.h"
#include "SetMonitorDlg.h"
#include ".\setmonitordlg.h"


// CSetMonitorDlg Dialog

IMPLEMENT_DYNAMIC(CSetMonitorDlg, CDialog)
CSetMonitorDlg::CSetMonitorDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CSetMonitorDlg::IDD, pParent)
	, m_PresetColor(0)
	, m_CursorNumber(0)
{
	m_Init = FALSE;
	m_StartPos.x = 0;
	m_StartPos.y = 0;

	m_AutoIrisMin = 0;
	m_AutoIrisMax = 0;

	ZeroMemory(&m_Cursor, sizeof(M_CURSOR) * 2);
}

CSetMonitorDlg::~CSetMonitorDlg()
{
}

void CSetMonitorDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_SENSOR, m_ComboSenSor);
	DDX_Control(pDX, IDC_SIZE2, m_ComboSize);
}


BEGIN_MESSAGE_MAP(CSetMonitorDlg, CDialog)
	ON_WM_HSCROLL()
	ON_BN_CLICKED(IDB_DEFAULT, OnBnClickedDefault)
	ON_BN_CLICKED(IDC_LIVE, OnBnClickedLive)
	ON_BN_CLICKED(IDB_SNAPSHOT, OnBnClickedSnapshot)
	ON_BN_CLICKED(IDC_COLOR, OnBnClickedColor)
	ON_BN_CLICKED(IDC_AWB, OnBnClickedAwb)
	ON_CBN_SELCHANGE(IDC_SIZE2, OnCbnSelchangeSize2)
	ON_CBN_SELCHANGE(IDC_SENSOR, OnCbnSelchangeSensor)
	ON_BN_CLICKED(IDC_AWB_LOCK, OnBnClickedAwbLock)
	ON_BN_CLICKED(IDC_VFLIP, OnBnClickedVflip)
	ON_BN_CLICKED(IDC_WRITE, OnBnClickedWrite)
	ON_BN_CLICKED(IDC_CURSOR_ON, OnBnClickedCusorOn)
	ON_BN_CLICKED(IDC_M_AUTOEXPOSURE, OnBnClickedMAutoiris)
	ON_BN_CLICKED(IDC_M_AUTOGAIN,	  OnBnClickedMAutoiris)
	ON_BN_CLICKED(IDC_INIT_MON, OnBnClickedInitMon)
	ON_BN_CLICKED(IDC_SEL_CURSOR2, OnBnClickedSelCursor2)
	ON_BN_CLICKED(IDC_SEL_CURSOR1, OnBnClickedSelCursor1)
	ON_WM_LBUTTONDOWN()
	ON_WM_PAINT()
END_MESSAGE_MAP()


// CSetMonitorDlg Message handler


/////////////////////////////////////////////////////////////////////////////
//
//	WM_INITDIALOG
//
//

BOOL CSetMonitorDlg::InitControl(UINT SliderID, UINT EditID, UINT SpinID, LONG Min, LONG Max, LONG Now, LONG Tic)
{
	CSliderCtrl*		SliderCtrl = (CSliderCtrl*)GetDlgItem(SliderID);
	CSpinButtonCtrl*	SpinCtrl   = (CSpinButtonCtrl*)GetDlgItem(SpinID);

	SliderCtrl->SetRange(Min, Max, TRUE);
	SliderCtrl->SetTic(Tic);
	SliderCtrl->SetPos(Now);

	SpinCtrl->SetRange((short)Min, (short)Max);
	SpinCtrl->SetBuddy(GetDlgItem(EditID));
	SpinCtrl->SetPos(Now);

	SetDlgItemInt(EditID, Now, TRUE);

	return TRUE;
}

BOOL CSetMonitorDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	m_Init = FALSE;

	switch(m_pCArtCamSdk->Monitor_GetAutoIrisMode()){
		case AI_BOTH:
			CheckDlgButton(IDC_M_AUTOEXPOSURE, BST_CHECKED);
			CheckDlgButton(IDC_M_AUTOGAIN    , BST_CHECKED);
		break;
		case AI_EXPOSURE:
			CheckDlgButton(IDC_M_AUTOEXPOSURE, BST_CHECKED);
		break;
		case AI_GAIN:
			CheckDlgButton(IDC_M_AUTOGAIN    , BST_CHECKED);
		break;
		case AI_NONE:
		default:
			CheckDlgButton(IDC_M_AUTOEXPOSURE, BST_UNCHECKED);
			CheckDlgButton(IDC_M_AUTOGAIN    , BST_UNCHECKED);
		break;
	}

	m_pCArtCamSdk->Monitor_GetAutoIrisRange(&m_AutoIrisMin, &m_AutoIrisMax);

	CSpinButtonCtrl*	SpinMin   = (CSpinButtonCtrl*)GetDlgItem(IDSP_AI_MIN);
	CSpinButtonCtrl*	SpinMax   = (CSpinButtonCtrl*)GetDlgItem(IDSP_AI_MAX);

	SpinMin->SetRange(0, 255);
	SpinMax->SetRange(0, 255);
	SpinMin->SetBuddy(GetDlgItem(IDE_AI_MIN));
	SpinMax->SetBuddy(GetDlgItem(IDE_AI_MAX));
	SpinMin->SetPos(m_AutoIrisMin);
	SpinMax->SetPos(m_AutoIrisMax);

	if(m_pCArtCamSdk->Monitor_GetColorMode()){
		CheckDlgButton(IDC_COLOR, BST_CHECKED);
	}else{
		GetDlgItem(IDC_AWB)->EnableWindow(FALSE);
		GetDlgItem(IDC_AWB_LOCK)->EnableWindow(FALSE);
	}

	if(m_pCArtCamSdk->Monitor_GetBayerGainAuto()){
		CheckDlgButton(IDC_AWB, BST_CHECKED);

		GetDlgItem(IDS_R_GAIN)->EnableWindow(FALSE);
		GetDlgItem(IDS_G_GAIN)->EnableWindow(FALSE);
		GetDlgItem(IDS_B_GAIN)->EnableWindow(FALSE);

		GetDlgItem(IDE_R_GAIN)->EnableWindow(FALSE);
		GetDlgItem(IDE_G_GAIN)->EnableWindow(FALSE);
		GetDlgItem(IDE_B_GAIN)->EnableWindow(FALSE);

		GetDlgItem(IDSP_R_GAIN)->EnableWindow(FALSE);
		GetDlgItem(IDSP_G_GAIN)->EnableWindow(FALSE);
		GetDlgItem(IDSP_B_GAIN)->EnableWindow(FALSE);
	}else{
		GetDlgItem(IDC_AWB_LOCK)->EnableWindow(FALSE);
	}

	if(m_pCArtCamSdk->Monitor_GetBayerGainLock()){
		CheckDlgButton(IDC_AWB_LOCK, BST_CHECKED);
	}


    m_ComboSize.AddString(_T("800x600"));
	m_ComboSize.AddString(_T("1024x768"));
	m_ComboSize.AddString(_T("1280x720"));
	m_ComboSize.AddString(_T("1280x1024"));

	LONG lWidth = 0; LONG lHeight = 0;
	m_pCArtCamSdk->Monitor_GetPreviewSize(&lWidth,&lHeight);
	switch(lWidth){
		case  800: m_ComboSize.SetCurSel(0); break;
		case 1024: m_ComboSize.SetCurSel(1); break;
		case 1280: 
			if(lHeight == 1024)		{m_ComboSize.SetCurSel(3);	break;	}
			else if(lHeight == 720){m_ComboSize.SetCurSel(2);	break;	}
		default:
			break;
	}
	

	m_ComboSenSor.AddString(_T("16 MHz"));
	m_ComboSenSor.AddString(_T("24 MHz"));
	m_ComboSenSor.AddString(_T("48 MHz"));
	LONG lCameraClock = m_pCArtCamSdk->Monitor_GetCameraClock();
		switch(lCameraClock){
			case 2:   m_ComboSenSor.SetCurSel(1); break;
			case 5:   m_ComboSenSor.SetCurSel(2); break;
			default:  m_ComboSenSor.SetCurSel(0); break;
		}

	// Bayer
	InitControl(IDS_R_GAIN, IDE_R_GAIN, IDSP_R_GAIN, 0, 1023, m_pCArtCamSdk->Monitor_GetBayerGainRed(), 64);
	InitControl(IDS_G_GAIN, IDE_G_GAIN, IDSP_G_GAIN, 0, 1023, m_pCArtCamSdk->Monitor_GetBayerGainGreen(), 64);
	InitControl(IDS_B_GAIN, IDE_B_GAIN, IDSP_B_GAIN, 0, 1023, m_pCArtCamSdk->Monitor_GetBayerGainBlue(), 64);

	// Gain / Shutter / Mirror reversal settings
	switch(m_DllType){
		case ARTCAM_CAMERATYPE_130MI_MOUT:
		InitControl(IDS_MGLOBALGAIN, IDE_MGLOBALGAIN, IDSP_MGLOBALGAIN, 0, 63, m_pCArtCamSdk->GetGlobalGain(), 64);
		InitControl(IDS_MSHUTTERWIDTH, IDE_MSHUTTERWIDTH, IDSP_MSHUTTERWIDTH, 1, 16383, m_pCArtCamSdk->GetExposureTime(), 64);
		if(m_pCArtCamSdk->GetMirrorV()) CheckDlgButton(IDC_VFLIP, BST_CHECKED);
		break;
		case ARTCAM_CAMERATYPE_150P3_MOUT:
		InitControl(IDS_MGLOBALGAIN, IDE_MGLOBALGAIN, IDSP_MGLOBALGAIN, 0, 1023, m_pCArtCamSdk->GetGlobalGain(), 64);
		InitControl(IDS_MSHUTTERWIDTH, IDE_MSHUTTERWIDTH, IDSP_MSHUTTERWIDTH, 8, 1068, m_pCArtCamSdk->GetExposureTime(), 64);
		GetDlgItem(IDC_VFLIP)->EnableWindow(FALSE);
		break;
	}


	// Preview mode
	if(m_pCArtCamSdk->Monitor_GetPreviewMode()){
		CheckDlgButton(IDC_LIVE, BST_CHECKED);
	}

	CheckDlgButton(IDC_SEL_CURSOR1, BST_CHECKED);

	for(int i=0; i<2; i++){
		// Show cursor ON/OFF
		m_Cursor[i].Enable= m_pCArtCamSdk->Monitor_GetCrossCursorMode(i);

		// Position of cursor
		m_pCArtCamSdk->Monitor_GetCrossCursorPos(i, &m_Cursor[i].Pos.x, &m_Cursor[i].Pos.y);

		// Size of cursor
		m_pCArtCamSdk->Monitor_GetCrossCursorSize(i, &m_Cursor[i].SizeX, &m_Cursor[i].SizeY);

		// Color of cursor
		m_Cursor[i].Color[0] = m_pCArtCamSdk->Monitor_GetCrossCursorColorR(i);
		m_Cursor[i].Color[1] = m_pCArtCamSdk->Monitor_GetCrossCursorColorG(i);
		m_Cursor[i].Color[2] = m_pCArtCamSdk->Monitor_GetCrossCursorColorB(i);
	}

	if(m_Cursor[m_CursorNumber].Enable)	CheckDlgButton(IDC_CURSOR_ON, BST_CHECKED);
	else								CheckDlgButton(IDC_CURSOR_ON, BST_UNCHECKED);

	InitControl(IDS_XPOS, IDE_XPOS, IDSP_XPOS, 0, 1280, m_Cursor[m_CursorNumber].Pos.x, 64);
	InitControl(IDS_YPOS, IDE_YPOS, IDSP_YPOS, 0, 1024, m_Cursor[m_CursorNumber].Pos.y, 64);
	InitControl(IDS_C_SIZEX, IDE_C_SIZEX, IDSP_C_SIZEX, 0, 1280, m_Cursor[m_CursorNumber].SizeX, 64);
	InitControl(IDS_C_SIZEY, IDE_C_SIZEY, IDSP_C_SIZEY, 0, 1024, m_Cursor[m_CursorNumber].SizeY, 64);

	// Preset color of cursor
	m_PresetColor = 0;
	UpdateData(FALSE);


	m_Init = TRUE;
	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
//
//	ChangeCursor
//
//
//


void CSetMonitorDlg::ChangeCursor(void)
{
	if(m_Cursor[m_CursorNumber].Enable)	CheckDlgButton(IDC_CURSOR_ON, BST_CHECKED  );
	else								CheckDlgButton(IDC_CURSOR_ON, BST_UNCHECKED);


	BOOL Flg = m_Cursor[m_CursorNumber].Enable;

	GetDlgItem(IDS_XPOS  )->EnableWindow(Flg);	GetDlgItem(IDSP_XPOS  )->EnableWindow(Flg);		GetDlgItem(IDE_XPOS  )->EnableWindow(Flg);
	GetDlgItem(IDS_YPOS  )->EnableWindow(Flg);	GetDlgItem(IDSP_YPOS  )->EnableWindow(Flg);		GetDlgItem(IDE_YPOS  )->EnableWindow(Flg);
	GetDlgItem(IDS_C_SIZEX)->EnableWindow(Flg);	GetDlgItem(IDSP_C_SIZEX)->EnableWindow(Flg);	GetDlgItem(IDE_C_SIZEX)->EnableWindow(Flg);
	GetDlgItem(IDS_C_SIZEY)->EnableWindow(Flg);	GetDlgItem(IDSP_C_SIZEY)->EnableWindow(Flg);	GetDlgItem(IDE_C_SIZEY)->EnableWindow(Flg);


	SetSpinSlier(IDSP_XPOS,		IDS_XPOS,		m_Cursor[m_CursorNumber].Pos.x);	
	SetSpinSlier(IDSP_YPOS,		IDS_YPOS,		m_Cursor[m_CursorNumber].Pos.y);
	SetSpinSlier(IDSP_C_SIZEX,	IDS_C_SIZEX,	m_Cursor[m_CursorNumber].SizeX);
	SetSpinSlier(IDSP_C_SIZEY,	IDS_C_SIZEY,	m_Cursor[m_CursorNumber].SizeY);
	SetSpinSlier(IDSP_COLOR_R,	IDS_COLOR_R,	m_Cursor[m_CursorNumber].Color[0]);
	SetSpinSlier(IDSP_COLOR_G,	IDS_COLOR_G,	m_Cursor[m_CursorNumber].Color[1]);
	SetSpinSlier(IDSP_COLOR_B,	IDS_COLOR_B,	m_Cursor[m_CursorNumber].Color[2]);

	Invalidate();
}

void CSetMonitorDlg::OnBnClickedSelCursor1()
{
	m_CursorNumber = 0;
	ChangeCursor();
}


void CSetMonitorDlg::OnBnClickedSelCursor2()
{
	m_CursorNumber = 1;
	ChangeCursor();
}

void CSetMonitorDlg::OnBnClickedCusorOn()
{
	BOOL Flg = IsDlgButtonChecked(IDC_CURSOR_ON);
	m_pCArtCamSdk->Monitor_SetCrossCursorMode(m_CursorNumber, Flg);
	m_Cursor[m_CursorNumber].Enable = Flg;
	Sleep(60);
	ChangeCursor();
}



/////////////////////////////////////////////////////////////////////////////
//
//	IDOK
//
//


void CSetMonitorDlg::OnOK()
{

	CDialog::OnOK();
}


/////////////////////////////////////////////////////////////////////////////
//
//	IDCANCEL
//
//

void CSetMonitorDlg::OnCancel()
{

	CDialog::OnCancel();
}


/////////////////////////////////////////////////////////////////////////////
//
//	WM_HSCROLL
//
//

void CSetMonitorDlg::OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar)
{
	CSliderCtrl* SliderCtrl = (CSliderCtrl*)pScrollBar;

	if(SliderCtrl && m_Init){
		LONG Pos = SliderCtrl->GetPos();

		switch(SliderCtrl->GetDlgCtrlID()){
		case IDS_R_GAIN:	SetDlgItemInt(IDE_R_GAIN, Pos);	break;
		case IDS_G_GAIN:	SetDlgItemInt(IDE_G_GAIN, Pos);	break;
		case IDS_B_GAIN:	SetDlgItemInt(IDE_B_GAIN, Pos);	break;
		case IDS_MGLOBALGAIN:	SetDlgItemInt(IDE_MGLOBALGAIN, Pos);	break;
		case IDS_MSHUTTERWIDTH:	SetDlgItemInt(IDE_MSHUTTERWIDTH, Pos);	break;
		case IDS_XPOS:			SetDlgItemInt(IDE_XPOS, Pos);												break;
		case IDS_YPOS:			SetDlgItemInt(IDE_YPOS, Pos);												break;
		case IDS_C_SIZEX:		SetDlgItemInt(IDE_C_SIZEX, Pos);	m_Cursor[m_CursorNumber].Pos.x = Pos;	break;
		case IDS_C_SIZEY:		SetDlgItemInt(IDE_C_SIZEY, Pos);	m_Cursor[m_CursorNumber].Pos.y = Pos;	break;
		}
	}

	CDialog::OnHScroll(nSBCode, nPos, pScrollBar);
}


/////////////////////////////////////////////////////////////////////////////
//
//	
//
//

void CSetMonitorDlg::OnBnClickedLive()
{
	m_pCArtCamSdk->Monitor_SetPreviewMode(TRUE);
	CheckDlgButton(IDC_LIVE, BST_CHECKED);
}


/////////////////////////////////////////////////////////////////////////////
//
//	
//
//

void CSetMonitorDlg::OnBnClickedSnapshot()
{
	m_pCArtCamSdk->Monitor_SetPreviewMode(FALSE);
	CheckDlgButton(IDC_LIVE, BST_UNCHECKED);
}


/////////////////////////////////////////////////////////////////////////////
//
//	
//
//

void CSetMonitorDlg::OnBnClickedColor()
{
	OnBnClickedAwb();
}


/////////////////////////////////////////////////////////////////////////////
//
//	
//
//

void CSetMonitorDlg::OnBnClickedAwb()
{
	BOOL Color = IsDlgButtonChecked(IDC_COLOR);
	BOOL AWB = IsDlgButtonChecked(IDC_AWB);
	BOOL Lock = IsDlgButtonChecked(IDC_AWB_LOCK);

	m_pCArtCamSdk->Monitor_SetColorMode(Color);
	m_pCArtCamSdk->Monitor_SetBayerGainAuto(AWB);
	m_pCArtCamSdk->Monitor_SetBayerGainLock(Lock);


	GetDlgItem(IDS_R_GAIN)->EnableWindow(Color && !AWB);
	GetDlgItem(IDS_G_GAIN)->EnableWindow(Color && !AWB);
	GetDlgItem(IDS_B_GAIN)->EnableWindow(Color && !AWB);

	GetDlgItem(IDE_R_GAIN)->EnableWindow(Color && !AWB);
	GetDlgItem(IDE_G_GAIN)->EnableWindow(Color && !AWB);
	GetDlgItem(IDE_B_GAIN)->EnableWindow(Color && !AWB);

	GetDlgItem(IDSP_R_GAIN)->EnableWindow(Color && !AWB);
	GetDlgItem(IDSP_G_GAIN)->EnableWindow(Color && !AWB);
	GetDlgItem(IDSP_B_GAIN)->EnableWindow(Color && !AWB);

	if(!Color){
		GetDlgItem(IDC_AWB)->EnableWindow(FALSE);
		GetDlgItem(IDC_AWB_LOCK)->EnableWindow(FALSE);
	}else{
		GetDlgItem(IDC_AWB)->EnableWindow(TRUE);
		if(!AWB){
			GetDlgItem(IDC_AWB_LOCK)->EnableWindow(FALSE);
		}else{
			GetDlgItem(IDC_AWB_LOCK)->EnableWindow(TRUE);
		}
	}
}


/////////////////////////////////////////////////////////////////////////////
//
//	
//
//

void CSetMonitorDlg::OnBnClickedAwbLock()
{
	OnBnClickedAwb();
}


/////////////////////////////////////////////////////////////////////////////
//
//	
//
//

void CSetMonitorDlg::OnBnClickedVflip()
{
	m_pCArtCamSdk->SetMirrorV(IsDlgButtonChecked(IDC_VFLIP));
}



/////////////////////////////////////////////////////////////////////////////
//
// Change size
//
//

void CSetMonitorDlg::OnCbnSelchangeSize2()
{
	LONG lWidth = 0; LONG lHeight = 0;
	switch(m_ComboSize.GetCurSel()){
		case 0: lWidth = 800; lHeight = 600; break;
		case 1: lWidth = 1024; lHeight = 768; break;
		case 2: lWidth = 1280;	lHeight = 720;	break;
		case 3: lWidth = 1280;	lHeight = 1024;	break;
		default: lWidth = 1280; lHeight = 1024; break;
	}
	m_pCArtCamSdk->Monitor_SetPreviewSize(lWidth,lHeight);
}


/////////////////////////////////////////////////////////////////////////////
//
//	Change working clock
//
//

void CSetMonitorDlg::OnCbnSelchangeSensor()
{
	m_pCArtCamSdk->Monitor_SetCameraClock(m_ComboSenSor.GetCurSel());
}


/////////////////////////////////////////////////////////////////////////////
//
//	Default
//
//

void CSetMonitorDlg::OnBnClickedDefault()
{
	switch(m_DllType){
	case ARTCAM_CAMERATYPE_130MI_MOUT:
		// Bayer
		SetSpinSlier(IDSP_R_GAIN,	IDS_R_GAIN,		256);
		SetSpinSlier(IDSP_G_GAIN,	IDS_G_GAIN,		256);
		SetSpinSlier(IDSP_B_GAIN,	IDS_B_GAIN,		256);
		SetSpinSlier(IDSP_MGLOBALGAIN, IDS_MGLOBALGAIN, 14);
		SetSpinSlier(IDSP_MSHUTTERWIDTH, IDS_MSHUTTERWIDTH, 1095);
	break;
	case ARTCAM_CAMERATYPE_150P3_MOUT:
		// Bayer
		SetSpinSlier(IDSP_R_GAIN,	IDS_R_GAIN,		256);
		SetSpinSlier(IDSP_G_GAIN,	IDS_G_GAIN,		256);
		SetSpinSlier(IDSP_B_GAIN,	IDS_B_GAIN,		256);
		SetSpinSlier(IDSP_MGLOBALGAIN, IDS_MGLOBALGAIN, 512);
		SetSpinSlier(IDSP_MSHUTTERWIDTH, IDS_MSHUTTERWIDTH, 64);

		SetSpinSlier(IDSP_XPOS,		IDS_XPOS,		640);
		SetSpinSlier(IDSP_YPOS,		IDS_YPOS,		512);
		SetSpinSlier(IDSP_C_SIZEX,	IDS_C_SIZEX,	640);
		SetSpinSlier(IDSP_C_SIZEY,	IDS_C_SIZEY,	512);

		SetSpinSlier(IDSP_COLOR_R,		IDS_COLOR_R,	0);
		SetSpinSlier(IDSP_COLOR_G,		IDS_COLOR_G,	255);
		SetSpinSlier(IDSP_COLOR_B,		IDS_COLOR_B,	0);

	break;
	}
}

/////////////////////////////////////////////////////////////////////////////
//
//	WM_COMMAND
//
//

BOOL CSetMonitorDlg::SetSpinSlier(UINT Spin, UINT Slider, LONG Pos)
{
	::SendMessage(::GetDlgItem(m_hWnd, Spin), UDM_SETPOS, 0, (LPARAM)MAKELONG((short)Pos, 0));
	::SendMessage(::GetDlgItem(m_hWnd, Slider), TBM_SETPOS, TRUE, Pos);
	return TRUE;
}

BOOL CSetMonitorDlg::OnCommand(WPARAM wParam, LPARAM lParam)
{
	if(EN_CHANGE == HIWORD(wParam) && m_Init){
		LONG Pos = 0;
		switch(LOWORD(wParam)){
		case IDE_R_GAIN:		Pos = GetDlgItemInt(IDE_R_GAIN);	SetSpinSlier(IDSP_R_GAIN, IDS_R_GAIN, Pos);	m_pCArtCamSdk->Monitor_SetBayerGainRed(Pos);	break;
		case IDE_G_GAIN:		Pos = GetDlgItemInt(IDE_G_GAIN);	SetSpinSlier(IDSP_G_GAIN, IDS_G_GAIN, Pos);	m_pCArtCamSdk->Monitor_SetBayerGainGreen(Pos);	break;
		case IDE_B_GAIN:		Pos = GetDlgItemInt(IDE_B_GAIN);	SetSpinSlier(IDSP_B_GAIN, IDS_B_GAIN, Pos);	m_pCArtCamSdk->Monitor_SetBayerGainBlue(Pos);	break;
		case IDE_MGLOBALGAIN:	Pos = GetDlgItemInt(IDE_MGLOBALGAIN);	SetSpinSlier(IDSP_MGLOBALGAIN, IDS_MGLOBALGAIN, Pos);	m_pCArtCamSdk->SetGlobalGain(Pos);	break;
		case IDE_MSHUTTERWIDTH: Pos = GetDlgItemInt(IDE_MSHUTTERWIDTH);	SetSpinSlier(IDSP_MSHUTTERWIDTH, IDS_MSHUTTERWIDTH, Pos);	m_pCArtCamSdk->SetExposureTime(Pos);	break;
		case IDE_XPOS:			Pos = GetDlgItemInt(IDE_XPOS);			SetSpinSlier(IDSP_XPOS, IDS_XPOS, Pos);			m_Cursor[m_CursorNumber].Pos.x = Pos; m_pCArtCamSdk->Monitor_SetCrossCursorPos(m_CursorNumber, m_Cursor[m_CursorNumber].Pos.x,  m_Cursor[m_CursorNumber].Pos.y);		break;
		case IDE_YPOS:			Pos = GetDlgItemInt(IDE_YPOS);			SetSpinSlier(IDSP_YPOS, IDS_YPOS, Pos);			m_Cursor[m_CursorNumber].Pos.y = Pos; m_pCArtCamSdk->Monitor_SetCrossCursorPos(m_CursorNumber, m_Cursor[m_CursorNumber].Pos.x,  m_Cursor[m_CursorNumber].Pos.y);		break;
		case IDE_C_SIZEX:		Pos = GetDlgItemInt(IDE_C_SIZEX);		SetSpinSlier(IDSP_C_SIZEX, IDS_C_SIZEX, Pos);	m_Cursor[m_CursorNumber].SizeX = Pos; m_pCArtCamSdk->Monitor_SetCrossCursorSize(m_CursorNumber, m_Cursor[m_CursorNumber].SizeX, m_Cursor[m_CursorNumber].SizeY);		break;
		case IDE_C_SIZEY:		Pos = GetDlgItemInt(IDE_C_SIZEY);		SetSpinSlier(IDSP_C_SIZEY, IDS_C_SIZEY, Pos);	m_Cursor[m_CursorNumber].SizeY = Pos; m_pCArtCamSdk->Monitor_SetCrossCursorSize(m_CursorNumber, m_Cursor[m_CursorNumber].SizeX, m_Cursor[m_CursorNumber].SizeY);		break;
		case IDE_COLOR_R:		Pos = GetDlgItemInt(IDE_COLOR_R);		SetSpinSlier(IDSP_COLOR_R, IDS_COLOR_R, Pos);	m_pCArtCamSdk->Monitor_SetCrossCursorColorR(m_CursorNumber, Pos);		break;
		case IDE_COLOR_G:		Pos = GetDlgItemInt(IDE_COLOR_G);		SetSpinSlier(IDSP_COLOR_G, IDS_COLOR_G, Pos);	m_pCArtCamSdk->Monitor_SetCrossCursorColorG(m_CursorNumber, Pos);		break;
		case IDE_COLOR_B:		Pos = GetDlgItemInt(IDE_COLOR_B);		SetSpinSlier(IDSP_COLOR_B, IDS_COLOR_B, Pos);	m_pCArtCamSdk->Monitor_SetCrossCursorColorB(m_CursorNumber, Pos);		break;
		case IDE_AI_MIN:		m_AutoIrisMin = GetDlgItemInt(IDE_AI_MIN);												m_pCArtCamSdk->Monitor_SetAutoIrisRange(m_AutoIrisMin, m_AutoIrisMax);	break;
		case IDE_AI_MAX:		m_AutoIrisMax = GetDlgItemInt(IDE_AI_MAX);												m_pCArtCamSdk->Monitor_SetAutoIrisRange(m_AutoIrisMin, m_AutoIrisMax);	break;
		}
	}

	return CDialog::OnCommand(wParam, lParam);
}


void CSetMonitorDlg::OnBnClickedWrite()
{
	if(m_pCArtCamSdk->Monitor_GetPreviewMode()){
		int res = MessageBox(_T("After the camera power is turned off, these settings are enabled.\r\nAre you sure to save now?"),_T("Warning"),MB_YESNO);
		if(res == IDYES)	m_pCArtCamSdk->Monitor_SaveCurrentSettings();
	}else{
		MessageBox(_T("Don't save settings while displaying a still image."), _T("Warning"));
	}
}



void CSetMonitorDlg::OnBnClickedChangeColor()
{
	UpdateData(TRUE);

	int iRGB[3] = {0,0,0};
	switch(m_PresetColor){
	case 0:														return;		// Manual
	case 1:		iRGB[0] = 255;	iRGB[1] =   0;	iRGB[2] =   0;	break;		// Red
	case 2:		iRGB[0] =   0;	iRGB[1] = 255;	iRGB[2] =   0;	break;		// Green
	case 3:		iRGB[0] =   0;	iRGB[1] =   0;	iRGB[2] = 255;	break;		// Blue
	case 4:		iRGB[0] = 255;	iRGB[1] = 255;	iRGB[2] =   0;	break;		// Yellow
	case 5:		iRGB[0] = 255;	iRGB[1] =   0;	iRGB[2] = 255;	break;		// Purple
	case 6:		iRGB[0] =   0;	iRGB[1] =   0;	iRGB[2] =   0;	break;		// Black
	case 7:		iRGB[0] = 255;	iRGB[1] = 255;	iRGB[2] = 255;	break;		// White
	default:	break;
	}

	SetSpinSlier(IDSP_COLOR_R,	IDS_COLOR_R,	iRGB[0]);
	SetSpinSlier(IDSP_COLOR_G,	IDS_COLOR_G,	iRGB[1]);
	SetSpinSlier(IDSP_COLOR_B,	IDS_COLOR_B,	iRGB[2]);

	UpdateData(FALSE);
}


void CSetMonitorDlg::OnBnClickedMAutoiris()
{
	BOOL bExp  = IsDlgButtonChecked(IDC_M_AUTOEXPOSURE);
	BOOL bGain = IsDlgButtonChecked(IDC_M_AUTOGAIN    );

	LONG Value = AI_NONE;
	if(bExp){
		if(bGain){
			Value = AI_BOTH;
		}else{
			Value = AI_EXPOSURE;
		}
	}else{
		if(bGain){
			Value = AI_GAIN;
		}
	}

	m_pCArtCamSdk->Monitor_SetAutoIrisMode(Value);
}


void CSetMonitorDlg::OnBnClickedInitMon()
{
	m_pCArtCamSdk->Monitor_InitRegisterSettings();
}



void CSetMonitorDlg::OnLButtonDown(UINT nFlags, CPoint point)
{
	CRect rc;
	GetDlgItem(IDC_C_COLOR)->GetWindowRect(&rc);
	ScreenToClient(&rc);
	if(rc.PtInRect(point)){
		COLORREF color = RGB(m_Cursor[m_CursorNumber].Color[0], m_Cursor[m_CursorNumber].Color[1], m_Cursor[m_CursorNumber].Color[2]);
		CColorDialog cd(color);
		if(IDOK == cd.DoModal()){
			m_Cursor[m_CursorNumber].Color[0] = BYTE(cd.GetColor()      );
			m_Cursor[m_CursorNumber].Color[1] = BYTE(cd.GetColor() >>  8);
			m_Cursor[m_CursorNumber].Color[2] = BYTE(cd.GetColor() >> 16);

			if(m_pCArtCamSdk){
				m_pCArtCamSdk->Monitor_SetCrossCursorColorR(m_CursorNumber, m_Cursor[m_CursorNumber].Color[0]);
				m_pCArtCamSdk->Monitor_SetCrossCursorColorG(m_CursorNumber, m_Cursor[m_CursorNumber].Color[1]);
				m_pCArtCamSdk->Monitor_SetCrossCursorColorB(m_CursorNumber, m_Cursor[m_CursorNumber].Color[2]);
			}
			Invalidate();
		}
	}


	CDialog::OnLButtonDown(nFlags, point);
}

void CSetMonitorDlg::OnPaint()
{
	CPaintDC dc(this);

	CRect rc;
	GetDlgItem(IDC_C_COLOR)->GetWindowRect(&rc);
	ScreenToClient(&rc);
	dc.FillSolidRect(&rc, RGB(m_Cursor[m_CursorNumber].Color[0], m_Cursor[m_CursorNumber].Color[1], m_Cursor[m_CursorNumber].Color[2]));



}
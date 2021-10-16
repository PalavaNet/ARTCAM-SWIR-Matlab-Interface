// SetMonitorDlg2.cpp : Mounting file
//

#include "stdafx.h"
#include "Sample_MFC.h"
#include "SetMonitorDlg2.h"


// CSetMonitorDlg2 Dialog

IMPLEMENT_DYNAMIC(CSetMonitorDlg2, CDialog)
CSetMonitorDlg2::CSetMonitorDlg2(CWnd* pParent /*=NULL*/)
	: CDialog(CSetMonitorDlg2::IDD, pParent)
{
	m_Init = FALSE;
	m_CursorNumber = 0;
	ZeroMemory(&m_Cursor, sizeof(M_CURSOR) * 2);
}

CSetMonitorDlg2::~CSetMonitorDlg2()
{
}

void CSetMonitorDlg2::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CSetMonitorDlg2, CDialog)
	ON_WM_HSCROLL()
	ON_BN_CLICKED(IDB_DEFAULT, OnBnClickedDefault)
	ON_BN_CLICKED(IDC_COLOR, OnBnClickedColor)
	ON_BN_CLICKED(IDC_AWB, OnBnClickedAwb)
	ON_BN_CLICKED(IDC_VFLIP, OnBnClickedVflip)
	ON_BN_CLICKED(IDC_HFLIP, OnBnClickedHflip)
	ON_BN_CLICKED(IDC_WRITE, OnBnClickedWrite)
	ON_BN_CLICKED(IDC_CURSOR_ON, OnBnClickedCusorOn)
	ON_BN_CLICKED(IDC_INIT_MON, OnBnClickedInitMon)
	ON_BN_CLICKED(IDC_SEL_CURSOR2, OnBnClickedSelCursor2)
	ON_BN_CLICKED(IDC_SEL_CURSOR1, OnBnClickedSelCursor1)
	ON_WM_LBUTTONDOWN()
	ON_WM_PAINT()
END_MESSAGE_MAP()


// CSetMonitorDlg2 Message handler


/////////////////////////////////////////////////////////////////////////////
//
//	WM_INITDIALOG
//
//

BOOL CSetMonitorDlg2::InitControl(UINT SliderID, UINT EditID, UINT SpinID, LONG Min, LONG Max, LONG Now, LONG Tic)
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

BOOL CSetMonitorDlg2::OnInitDialog()
{
	CDialog::OnInitDialog();

	m_Init = FALSE;

	if(m_pCArtCamSdk->Monitor_GetColorMode()){
		CheckDlgButton(IDC_COLOR, BST_CHECKED);
	}else{
		GetDlgItem(IDC_AWB)->EnableWindow(FALSE);
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
	}


	// Bayer
	InitControl(IDS_R_GAIN, IDE_R_GAIN, IDSP_R_GAIN, 0, 1023, m_pCArtCamSdk->Monitor_GetBayerGainRed(), 64);
	InitControl(IDS_G_GAIN, IDE_G_GAIN, IDSP_G_GAIN, 0, 1023, m_pCArtCamSdk->Monitor_GetBayerGainGreen(), 64);
	InitControl(IDS_B_GAIN, IDE_B_GAIN, IDSP_B_GAIN, 0, 1023, m_pCArtCamSdk->Monitor_GetBayerGainBlue(), 64);

	// Gain, Shutter, Mirror
	switch(m_DllType){
		case ARTCAM_CAMERATYPE_1000MI_HD2:
		InitControl(IDS_MGLOBALGAIN, IDE_MGLOBALGAIN, IDSP_MGLOBALGAIN, 0, 127, m_pCArtCamSdk->GetGlobalGain(), 64);
		InitControl(IDS_MSHUTTERWIDTH, IDE_MSHUTTERWIDTH, IDSP_MSHUTTERWIDTH, 1, 8191, m_pCArtCamSdk->GetExposureTime(), 64);
		if(m_pCArtCamSdk->GetMirrorV()) CheckDlgButton(IDC_VFLIP, BST_CHECKED);
		if(m_pCArtCamSdk->GetMirrorH()) CheckDlgButton(IDC_HFLIP, BST_CHECKED);
		break;
	}

	for(int i=0; i<2; i++){
		// ON/OFF
		m_Cursor[i].Enable= m_pCArtCamSdk->Monitor_GetCrossCursorMode(i);

		// Position
		m_pCArtCamSdk->Monitor_GetCrossCursorPos(i, &m_Cursor[i].Pos.x, &m_Cursor[i].Pos.y);

		// Size
		m_pCArtCamSdk->Monitor_GetCrossCursorSize(i, &m_Cursor[i].SizeX, &m_Cursor[i].SizeY);

		// Color
		m_Cursor[i].Color = m_pCArtCamSdk->Monitor_GetCrossCursorColorRGB(i);
	}
	CheckDlgButton(IDC_SEL_CURSOR1, BST_CHECKED);
	if(m_Cursor[m_CursorNumber].Enable)	CheckDlgButton(IDC_CURSOR_ON, BST_CHECKED);
	else								CheckDlgButton(IDC_CURSOR_ON, BST_UNCHECKED);

	
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
	
	InitControl(IDS_XPOS, IDE_XPOS, IDSP_XPOS, 0, Width, m_Cursor[m_CursorNumber].Pos.x, 64);
	InitControl(IDS_YPOS, IDE_YPOS, IDSP_YPOS, 0, Height, m_Cursor[m_CursorNumber].Pos.y, 64);
	InitControl(IDS_C_SIZEX, IDE_C_SIZEX, IDSP_C_SIZEX, 0, 7, m_Cursor[m_CursorNumber].SizeX, 64);
	InitControl(IDS_C_SIZEY, IDE_C_SIZEY, IDSP_C_SIZEY, 0, 7, m_Cursor[m_CursorNumber].SizeY, 64);

	UpdateData(FALSE);
	Invalidate();

	m_Init = TRUE;
	return TRUE;
}




/////////////////////////////////////////////////////////////////////////////
//
//	ChangeCursor
//
//


void CSetMonitorDlg2::ChangeCursor(void)
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

	Invalidate();
}

void CSetMonitorDlg2::OnBnClickedSelCursor1()
{
	m_CursorNumber = 0;
	ChangeCursor();
}


void CSetMonitorDlg2::OnBnClickedSelCursor2()
{
	m_CursorNumber = 1;
	ChangeCursor();
}

void CSetMonitorDlg2::OnBnClickedCusorOn()
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

void CSetMonitorDlg2::OnOK()
{
	CDialog::OnOK();
}


/////////////////////////////////////////////////////////////////////////////
//
//	IDCANCEL
//
//

void CSetMonitorDlg2::OnCancel()
{
	CDialog::OnCancel();
}

/////////////////////////////////////////////////////////////////////////////
//
//	WM_HSCROLL
//
//

void CSetMonitorDlg2::OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar)
{
	CSliderCtrl* SliderCtrl = (CSliderCtrl*)pScrollBar;

	if(SliderCtrl && m_Init){
		LONG Pos = SliderCtrl->GetPos();

		switch(SliderCtrl->GetDlgCtrlID()){
		case IDS_R_GAIN:		SetDlgItemInt(IDE_R_GAIN, Pos);												break;
		case IDS_G_GAIN:		SetDlgItemInt(IDE_G_GAIN, Pos);												break;
		case IDS_B_GAIN:		SetDlgItemInt(IDE_B_GAIN, Pos);												break;
		case IDS_MGLOBALGAIN:	SetDlgItemInt(IDE_MGLOBALGAIN, Pos);										break;
		case IDS_MSHUTTERWIDTH:	SetDlgItemInt(IDE_MSHUTTERWIDTH, Pos);										break;
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

void CSetMonitorDlg2::OnBnClickedColor()
{
	OnBnClickedAwb();
}


/////////////////////////////////////////////////////////////////////////////
//
//	
//
//

void CSetMonitorDlg2::OnBnClickedAwb()
{
	BOOL Color = IsDlgButtonChecked(IDC_COLOR);
	BOOL AWB = IsDlgButtonChecked(IDC_AWB);

	m_pCArtCamSdk->Monitor_SetColorMode(Color);
	m_pCArtCamSdk->Monitor_SetBayerGainAuto(AWB);


	GetDlgItem(IDS_R_GAIN)->EnableWindow(Color && !AWB);
	GetDlgItem(IDS_G_GAIN)->EnableWindow(Color && !AWB);
	GetDlgItem(IDS_B_GAIN)->EnableWindow(Color && !AWB);

	GetDlgItem(IDE_R_GAIN)->EnableWindow(Color && !AWB);
	GetDlgItem(IDE_G_GAIN)->EnableWindow(Color && !AWB);
	GetDlgItem(IDE_B_GAIN)->EnableWindow(Color && !AWB);

	GetDlgItem(IDSP_R_GAIN)->EnableWindow(Color && !AWB);
	GetDlgItem(IDSP_G_GAIN)->EnableWindow(Color && !AWB);
	GetDlgItem(IDSP_B_GAIN)->EnableWindow(Color && !AWB);

	if(!Color)	GetDlgItem(IDC_AWB)->EnableWindow(FALSE);
	else		GetDlgItem(IDC_AWB)->EnableWindow(TRUE);
}


/////////////////////////////////////////////////////////////////////////////
//
//	
//
//

void CSetMonitorDlg2::OnBnClickedVflip()
{
	m_pCArtCamSdk->SetMirrorV(IsDlgButtonChecked(IDC_VFLIP));
}


/////////////////////////////////////////////////////////////////////////////
//
//	
//
//

void CSetMonitorDlg2::OnBnClickedHflip()
{
	m_pCArtCamSdk->SetMirrorH(IsDlgButtonChecked(IDC_HFLIP));
}


/////////////////////////////////////////////////////////////////////////////
//
//
//

void CSetMonitorDlg2::OnBnClickedDefault()
{
	switch(m_DllType){
	case ARTCAM_CAMERATYPE_1000MI_HD2:
		// Bayer
		SetSpinSlier(IDSP_R_GAIN,	IDS_R_GAIN,		256);
		SetSpinSlier(IDSP_G_GAIN,	IDS_G_GAIN,		256);
		SetSpinSlier(IDSP_B_GAIN,	IDS_B_GAIN,		256);
		SetSpinSlier(IDSP_MGLOBALGAIN, IDS_MGLOBALGAIN, 64);
		SetSpinSlier(IDSP_MSHUTTERWIDTH, IDS_MSHUTTERWIDTH, 2748);

		SetSpinSlier(IDSP_XPOS,		IDS_XPOS,		360);
		SetSpinSlier(IDSP_YPOS,		IDS_YPOS,		360);
		SetSpinSlier(IDSP_C_SIZEX,	IDS_C_SIZEX,	4);
		SetSpinSlier(IDSP_C_SIZEY,	IDS_C_SIZEY,	4);

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
//

BOOL CSetMonitorDlg2::SetSpinSlier(UINT Spin, UINT Slider, LONG Pos)
{
	::SendMessage(::GetDlgItem(m_hWnd, Spin), UDM_SETPOS, 0, (LPARAM)MAKELONG((short)Pos, 0));
	::SendMessage(::GetDlgItem(m_hWnd, Slider), TBM_SETPOS, TRUE, Pos);
	return TRUE;
}


BOOL CSetMonitorDlg2::OnCommand(WPARAM wParam, LPARAM lParam)
{
	if(EN_CHANGE == HIWORD(wParam) && m_Init){
		LONG Pos = 0;
		switch(LOWORD(wParam)){
		case IDE_R_GAIN:		Pos = GetDlgItemInt(IDE_R_GAIN);		SetSpinSlier(IDSP_R_GAIN, IDS_R_GAIN, Pos);					m_pCArtCamSdk->Monitor_SetBayerGainRed(Pos);				break;
		case IDE_G_GAIN:		Pos = GetDlgItemInt(IDE_G_GAIN);		SetSpinSlier(IDSP_G_GAIN, IDS_G_GAIN, Pos);					m_pCArtCamSdk->Monitor_SetBayerGainGreen(Pos);				break;
		case IDE_B_GAIN:		Pos = GetDlgItemInt(IDE_B_GAIN);		SetSpinSlier(IDSP_B_GAIN, IDS_B_GAIN, Pos);					m_pCArtCamSdk->Monitor_SetBayerGainBlue(Pos);				break;
		case IDE_MGLOBALGAIN:	Pos = GetDlgItemInt(IDE_MGLOBALGAIN);	SetSpinSlier(IDSP_MGLOBALGAIN, IDS_MGLOBALGAIN, Pos);		m_pCArtCamSdk->SetGlobalGain(Pos);							break;
		case IDE_MSHUTTERWIDTH: Pos = GetDlgItemInt(IDE_MSHUTTERWIDTH);	SetSpinSlier(IDSP_MSHUTTERWIDTH, IDS_MSHUTTERWIDTH, Pos);	m_pCArtCamSdk->SetExposureTime(Pos);						break;
		case IDE_XPOS:			Pos = GetDlgItemInt(IDE_XPOS);			SetSpinSlier(IDSP_XPOS, IDS_XPOS, Pos);			m_Cursor[m_CursorNumber].Pos.x = Pos; m_pCArtCamSdk->Monitor_SetCrossCursorPos(m_CursorNumber, m_Cursor[m_CursorNumber].Pos.x,  m_Cursor[m_CursorNumber].Pos.y);		break;
		case IDE_YPOS:			Pos = GetDlgItemInt(IDE_YPOS);			SetSpinSlier(IDSP_YPOS, IDS_YPOS, Pos);			m_Cursor[m_CursorNumber].Pos.y = Pos; m_pCArtCamSdk->Monitor_SetCrossCursorPos(m_CursorNumber, m_Cursor[m_CursorNumber].Pos.x,  m_Cursor[m_CursorNumber].Pos.y);		break;
		case IDE_C_SIZEX:		Pos = GetDlgItemInt(IDE_C_SIZEX);		SetSpinSlier(IDSP_C_SIZEX, IDS_C_SIZEX, Pos);	m_Cursor[m_CursorNumber].SizeX = Pos; m_pCArtCamSdk->Monitor_SetCrossCursorSize(m_CursorNumber, m_Cursor[m_CursorNumber].SizeX, m_Cursor[m_CursorNumber].SizeY);		break;
		case IDE_C_SIZEY:		Pos = GetDlgItemInt(IDE_C_SIZEY);		SetSpinSlier(IDSP_C_SIZEY, IDS_C_SIZEY, Pos);	m_Cursor[m_CursorNumber].SizeY = Pos; m_pCArtCamSdk->Monitor_SetCrossCursorSize(m_CursorNumber, m_Cursor[m_CursorNumber].SizeX, m_Cursor[m_CursorNumber].SizeY);		break;
		}
	}


	return CDialog::OnCommand(wParam, lParam);
}


void CSetMonitorDlg2::OnBnClickedWrite()
{
	m_pCArtCamSdk->Monitor_SaveCurrentSettings();
}



void CSetMonitorDlg2::OnBnClickedInitMon()
{
	m_pCArtCamSdk->Monitor_InitRegisterSettings();
}

void CSetMonitorDlg2::OnLButtonDown(UINT nFlags, CPoint point)
{
	CRect rc;
	GetDlgItem(IDC_C_COLOR)->GetWindowRect(&rc);
	ScreenToClient(&rc);
	rc.DeflateRect(1,1,1,1);
	
	if(rc.PtInRect(point)){

		for(int i=0; i<16; i++){
			LONG w = rc.Width() / 16;
			CRect rc1(rc.left+w*i, rc.top, rc.left+w*(i+1), rc.bottom);
			if(15==i) rc1.right = rc.right;

			if(rc1.PtInRect(point)){
				m_pCArtCamSdk->Monitor_SetCrossCursorColorRGB(m_CursorNumber, i);
				Invalidate(FALSE);
				break;
			}
		}

	}

	CDialog::OnLButtonDown(nFlags, point);
}

void CSetMonitorDlg2::OnPaint()
{
	CPaintDC dc(this);

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

	CPen Pen(PS_SOLID, 1, RGB(255,0,0));
	CPen* pOld = dc.SelectObject(&Pen);

	CRect rc;
	GetDlgItem(IDC_C_COLOR)->GetWindowRect(&rc);
	ScreenToClient(&rc);
	rc.DeflateRect(1,1,1,1);

	LONG color = m_pCArtCamSdk->Monitor_GetCrossCursorColorRGB(m_CursorNumber);

	for(int i=0; i<16; i++){
		LONG w = rc.Width() / 16;
		CRect rc1(rc.left+w*i, rc.top, rc.left+w*(i+1), rc.bottom);
		if(15==i) rc1.right = rc.right;
		dc.FillSolidRect(&rc1, Color[i]);

		if(color == i){
			dc.MoveTo(rc1.left, rc1.top);
			dc.LineTo(rc1.right-1, rc1.top);
			dc.LineTo(rc1.right-1, rc1.bottom-1);
			dc.LineTo(rc1.left, rc1.bottom-1);
			dc.LineTo(rc1.left, rc1.top);
		}
	}

	dc.SelectObject(pOld);
	Pen.DeleteObject();
}

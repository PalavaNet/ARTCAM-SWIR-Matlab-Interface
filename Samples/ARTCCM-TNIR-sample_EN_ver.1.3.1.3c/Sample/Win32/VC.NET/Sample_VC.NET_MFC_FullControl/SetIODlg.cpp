// SetIODlg.cpp : Mounting file
//

#include "stdafx.h"
#include "Sample_MFC.h"
#include "SetIODlg.h"


// CSetIODlg Dialog

IMPLEMENT_DYNAMIC(CSetIODlg, CDialog)
CSetIODlg::CSetIODlg(CWnd* pParent /*=NULL*/)
	: CDialog(CSetIODlg::IDD, pParent)
	, m_IOR0(FALSE)
	, m_IOR1(FALSE)
	, m_IOR2(FALSE)
	, m_IOR3(FALSE)
	, m_IOR4(FALSE)
	, m_IOR5(FALSE)
	, m_IOR6(FALSE)
	, m_IOR7(FALSE)
	, m_IOW0(FALSE)
	, m_IOW1(FALSE)
	, m_IOW2(FALSE)
	, m_IOW3(FALSE)
	, m_IOW4(FALSE)
	, m_IOW5(FALSE)
	, m_IOW6(FALSE)
	, m_IOW7(FALSE)
{
	m_pCArtCamSdk = NULL;
	m_DllType = -1;
}

CSetIODlg::~CSetIODlg()
{
}

void CSetIODlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Check(pDX, IDC_IOR0, m_IOR0);
	DDX_Check(pDX, IDC_IOR1, m_IOR1);
	DDX_Check(pDX, IDC_IOR2, m_IOR2);
	DDX_Check(pDX, IDC_IOR3, m_IOR3);
	DDX_Check(pDX, IDC_IOR4, m_IOR4);
	DDX_Check(pDX, IDC_IOR5, m_IOR5);
	DDX_Check(pDX, IDC_IOR6, m_IOR6);
	DDX_Check(pDX, IDC_IOR7, m_IOR7);
	DDX_Check(pDX, IDC_IOW0, m_IOW0);
	DDX_Check(pDX, IDC_IOW1, m_IOW1);
	DDX_Check(pDX, IDC_IOW2, m_IOW2);
	DDX_Check(pDX, IDC_IOW3, m_IOW3);
	DDX_Check(pDX, IDC_IOW4, m_IOW4);
	DDX_Check(pDX, IDC_IOW5, m_IOW5);
	DDX_Check(pDX, IDC_IOW6, m_IOW6);
	DDX_Check(pDX, IDC_IOW7, m_IOW7);
}


BEGIN_MESSAGE_MAP(CSetIODlg, CDialog)
	ON_BN_CLICKED(IDB_READ, OnBnClickedRead)
	ON_BN_CLICKED(IDB_WRITE, OnBnClickedWrite)
END_MESSAGE_MAP()


// CSetIODlg Message handler

BOOL CSetIODlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Change operation for each DLL
	// For each DLL function, please refer to manual.
	m_DllType = HIWORD(m_pCArtCamSdk->GetDllVersion());


	switch(m_DllType){
	case ARTCAM_CAMERATYPE_036MI:
	case ARTCAM_CAMERATYPE_130MI:
	case ARTCAM_CAMERATYPE_200MI:
	case ARTCAM_CAMERATYPE_300MI:
	case ARTCAM_CAMERATYPE_500MI:
	case ARTCAM_CAMERATYPE_900MI:
	case ARTCAM_CAMERATYPE_OV210:
		GetDlgItem(IDB_READ)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOR0)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOR1)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOR2)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOR3)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOR4)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOR5)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOR6)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOR7)->EnableWindow(TRUE);

		GetDlgItem(IDB_WRITE)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOW0)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOW1)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOW2)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOW3)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOW4)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOW5)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOW6)->EnableWindow(TRUE);
		GetDlgItem(IDC_IOW7)->EnableWindow(TRUE);
	break;
	}


	return TRUE;
}

void CSetIODlg::OnBnClickedRead()
{
	BYTE Data = 0x00;
	if(m_pCArtCamSdk->GetIOPort(&Data, NULL, 0)){
		m_IOR0 = (Data & 0x01) ? TRUE : FALSE;
		m_IOR1 = (Data & 0x02) ? TRUE : FALSE;
		m_IOR2 = (Data & 0x04) ? TRUE : FALSE;
		m_IOR3 = (Data & 0x08) ? TRUE : FALSE;
		m_IOR4 = (Data & 0x10) ? TRUE : FALSE;
		m_IOR5 = (Data & 0x20) ? TRUE : FALSE;
		m_IOR6 = (Data & 0x40) ? TRUE : FALSE;
		m_IOR7 = (Data & 0x80) ? TRUE : FALSE;

		UpdateData(FALSE);
	}
}

void CSetIODlg::OnBnClickedWrite()
{
	UpdateData(TRUE);

	BYTE Data = 0x00;
	if(m_IOW0) Data |= 0x01;
	if(m_IOW1) Data |= 0x02;
	if(m_IOW2) Data |= 0x04;
	if(m_IOW3) Data |= 0x08;
	if(m_IOW4) Data |= 0x10;
	if(m_IOW5) Data |= 0x20;
	if(m_IOW6) Data |= 0x40;
	if(m_IOW7) Data |= 0x80;

	m_pCArtCamSdk->SetIOPort(Data, 0, 0);

}








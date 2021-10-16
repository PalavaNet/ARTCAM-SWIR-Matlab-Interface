// SetCorrection.cpp : Mounting file
//

#include "stdafx.h"
#include "Sample_MFC.h"
#include "SetCorrection.h"


// CSetCorrection Dialog

IMPLEMENT_DYNAMIC(CSetCorrection, CDialog)

CSetCorrection::CSetCorrection(CWnd* pParent /*=NULL*/)
	: CDialog(CSetCorrection::IDD, pParent)
{
	m_pCArtCamSdk = NULL;
}

CSetCorrection::~CSetCorrection()
{
}

void CSetCorrection::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CSetCorrection, CDialog)
	ON_BN_CLICKED(IDC_UPDATE_LOW,			OnBnClickedUpdateLow)
	ON_BN_CLICKED(IDC_UPDATE_HIGH,			OnBnClickedUpdateHigh)
	ON_BN_CLICKED(IDC_SAVE_MASK,			OnBnClickedSaveMask)
	ON_BN_CLICKED(IDC_LOAD_MASK,			OnBnClickedLoadMask)
	ON_BN_CLICKED(IDC_CORRECTION_ENABLE,	OnBnClickedCorrectionEnable)
	ON_BN_CLICKED(IDC_DOTFILTER_ENABLE,		OnBnClickedDotfilterEnable)
END_MESSAGE_MAP()


// CSetCorrection Message handler


BOOL CSetCorrection::OnInitDialog()
{
	CDialog::OnInitDialog();

	if(m_pCArtCamSdk){
		LONG MaskFilter   = m_pCArtCamSdk->GetMaskFilter();
		LONG DotFilter = m_pCArtCamSdk->GetDotFilter();
		
		if(DotFilter)	CheckDlgButton(IDC_DOTFILTER_ENABLE,  BST_CHECKED);
		if(MaskFilter)	CheckDlgButton(IDC_CORRECTION_ENABLE, BST_CHECKED);
	}

	return TRUE;
}


void CSetCorrection::OnBnClickedUpdateLow()
{
	if(m_pCArtCamSdk){
		m_pCArtCamSdk->UpdateMaskData(MASKTYPE_LOW);
	}
}


void CSetCorrection::OnBnClickedUpdateHigh()
{
	if(m_pCArtCamSdk){
		m_pCArtCamSdk->UpdateMaskData(MASKTYPE_HIGH);
	}
}


void CSetCorrection::OnBnClickedSaveMask()
{
	if(m_pCArtCamSdk){
		CFileDialog FD(FALSE, _T("msk"), _T("Default.msk"), OFN_HIDEREADONLY | OFN_OVERWRITEPROMPT, 
			_T("MSK file(*.msk)|*.msk||"), this);

		if(IDOK == FD.DoModal()){
#if defined(__VC6__)
			OPENFILENAME ofn = FD.m_ofn;
#else
			OPENFILENAME ofn = FD.GetOFN();
#endif
			// Set extension yourself
			TCHAR szTemp[4][MAX_PATH]={_T(""),_T(""),_T(""),_T("")};
#if defined(__VS2005__) | (__VS2010__) || defined(__VS2010__)
			_tsplitpath_s(ofn.lpstrFile, szTemp[0], MAX_PATH, szTemp[1], MAX_PATH, szTemp[2], MAX_PATH, szTemp[3], MAX_PATH);
#else
			_tsplitpath(ofn.lpstrFile, szTemp[0], szTemp[1], szTemp[2], szTemp[3]);
#endif
			CString str;
			str.Format(_T("%s%s%s.msk"), szTemp[0], szTemp[1], szTemp[2]);	
			m_pCArtCamSdk->SaveMaskFile(str);
		}
	}
}


void CSetCorrection::OnBnClickedLoadMask()
{
	if(m_pCArtCamSdk){
		CFileDialog FD(TRUE, _T("msk"), _T("Default.msk"), OFN_HIDEREADONLY, 
			_T("MSK file(*.msk)|*.msk||"), this);

		if(IDOK == FD.DoModal()){
#if defined(__VC6__)
			OPENFILENAME ofn = FD.m_ofn;
#else
			OPENFILENAME ofn = FD.GetOFN();
#endif
			m_pCArtCamSdk->LoadMaskFile(ofn.lpstrFile);
		}
	}
}


void CSetCorrection::OnBnClickedCorrectionEnable()
{
	if(m_pCArtCamSdk){
		LONG Enable = (IsDlgButtonChecked(IDC_CORRECTION_ENABLE) == BST_CHECKED) ? 1 : 0;
		m_pCArtCamSdk->SetMaskFilter(Enable);
	}
}


void CSetCorrection::OnBnClickedDotfilterEnable()
{
	if(m_pCArtCamSdk){
		LONG Enable = (IsDlgButtonChecked(IDC_DOTFILTER_ENABLE) == BST_CHECKED) ? 1 : 0;
		m_pCArtCamSdk->SetDotFilter(Enable);
	}	
}

#pragma once

#include "CArtCamSdk.hpp"


// CSetCorrection Dialog

class CSetCorrection : public CDialog
{
	DECLARE_DYNAMIC(CSetCorrection)

public:
	CSetCorrection(CWnd* pParent = NULL);   // Standard constructor
	virtual ~CSetCorrection();

// Dialog data
	enum { IDD = IDD_SETCORRECTION };

public:
	CArtCamSdk*	m_pCArtCamSdk;

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV Support

	DECLARE_MESSAGE_MAP()
public:
	virtual BOOL OnInitDialog();
	afx_msg void OnBnClickedUpdateLow();
	afx_msg void OnBnClickedUpdateHigh();
	afx_msg void OnBnClickedSaveMask();
	afx_msg void OnBnClickedLoadMask();
	afx_msg void OnBnClickedCorrectionEnable();
	afx_msg void OnBnClickedDotfilterEnable();
};

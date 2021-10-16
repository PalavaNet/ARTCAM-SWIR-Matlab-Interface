#pragma once

#include "CArtCamSdk.hpp"

// CSetFilterDlg Dialog

class CSetFilterDlg : public CDialog
{
	DECLARE_DYNAMIC(CSetFilterDlg)


	BOOL			m_Init;
	LONG			m_DllType;

public:
	CArtCamSdk*		m_pCArtCamSdk;
	CAMERAINFO		m_CameraInfo;
	BOOL			m_Preview;

		BOOL	InitControl	(LONG FilterType, UINT EditID, UINT SpinID, LONG Min, LONG Max);
	BOOL	SetControl	(LONG FilterType, UINT EditID, UINT SpinID);


public:
	CSetFilterDlg(CWnd* pParent = NULL);   // Standard constructor
	virtual ~CSetFilterDlg();

// Dialog data
	enum { IDD = IDD_SETFILTER };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV Support

	DECLARE_MESSAGE_MAP()
public:
	virtual BOOL OnInitDialog();
	virtual void OnOK();
	virtual void OnCancel();
	virtual BOOL OnCommand(WPARAM wParam, LPARAM lParam);
	afx_msg void OnBnClickedMirrorV();
	afx_msg void OnBnClickedMirrorH();
	afx_msg void OnBnClickedAutoWB();
	afx_msg void OnBnClickedBayer1();
	afx_msg void OnBnClickedBayer2();
	afx_msg void OnBnClickedBayer3();
	afx_msg void OnBnClickedBayer4();
	afx_msg void OnBnClickedAi1();
	afx_msg void OnBnClickedAi2();
	afx_msg void OnBnClickedAi3();
	afx_msg void OnBnClickedHalfclock();
	afx_msg void OnBnClickedChannel1();
	afx_msg void OnBnClickedChannel2();
	afx_msg void OnBnClickedChannel3();
	afx_msg void OnBnClickedChannel4();
	afx_msg void OnBnClickedChannel5();
	afx_msg void OnBnClickedChannel6();
};

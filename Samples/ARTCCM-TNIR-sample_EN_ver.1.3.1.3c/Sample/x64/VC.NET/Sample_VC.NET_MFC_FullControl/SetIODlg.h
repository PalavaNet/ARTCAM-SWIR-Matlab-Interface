#pragma once


// CSetIODlg Dialog

class CSetIODlg : public CDialog
{
	DECLARE_DYNAMIC(CSetIODlg)

public:
	CArtCamSdk*		m_pCArtCamSdk;
	LONG			m_DllType;

public:
	CSetIODlg(CWnd* pParent = NULL);   // Standard constructor
	virtual ~CSetIODlg();

// Dialog data
	enum { IDD = IDD_SETIO };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV Support

	DECLARE_MESSAGE_MAP()
	virtual BOOL OnInitDialog();
	afx_msg void OnBnClickedRead();
	afx_msg void OnBnClickedWrite();
	BOOL m_IOR0;
	BOOL m_IOR1;
	BOOL m_IOR2;
	BOOL m_IOR3;
	BOOL m_IOR4;
	BOOL m_IOR5;
	BOOL m_IOR6;
	BOOL m_IOR7;
	BOOL m_IOW0;
	BOOL m_IOW1;
	BOOL m_IOW2;
	BOOL m_IOW3;
	BOOL m_IOW4;
	BOOL m_IOW5;
	BOOL m_IOW6;
	BOOL m_IOW7;
};

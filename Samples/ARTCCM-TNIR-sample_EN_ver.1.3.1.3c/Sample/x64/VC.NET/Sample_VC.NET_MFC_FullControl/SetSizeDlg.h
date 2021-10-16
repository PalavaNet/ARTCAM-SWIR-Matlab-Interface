#pragma once


// CSetSizeDlg Dialog

class CSetSizeDlg : public CDialog
{
	DECLARE_DYNAMIC(CSetSizeDlg)


	BOOL	m_Init;
	BOOL	m_SubCode;

public:
	CArtCamSdk*		m_pCArtCamSdk;
	CAMERAINFO		m_CameraInfo;
	LONG			m_DllType;


	void	InitCameraSize();
	void	InitColorMode();
	void	InitSubSample();
	void	InitCNV();
	void	InitSubCode();

public:
	CSetSizeDlg(CWnd* pParent = NULL);   // Standard constructor
	virtual ~CSetSizeDlg();

// Dialog data
	enum { IDD = IDD_SETSIZE };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	virtual BOOL OnInitDialog();
	virtual void OnOK();
	virtual void OnCancel();
	long m_TV;
	long m_EV;
	long m_EVS;
	long m_TH;
	long m_EH;
	long m_EHS;
	long m_FPS;
	BOOL m_SubSample;
	BOOL m_ColorMode;
	BOOL m_SamplingRate;
	BOOL m_Channel;
	BYTE m_Code1;
	BYTE m_Code2;
	BYTE m_Code3;
	BYTE m_Code4;
	BYTE m_Code5;
	BYTE m_Code6;
	BYTE m_Code7;
	BYTE m_Code8;
};

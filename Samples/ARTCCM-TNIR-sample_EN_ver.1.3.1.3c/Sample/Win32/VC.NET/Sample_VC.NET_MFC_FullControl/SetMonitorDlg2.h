#pragma once


// CSetMonitorDlg2 Dialog

class CSetMonitorDlg2 : public CDialog
{
	DECLARE_DYNAMIC(CSetMonitorDlg2)

	BOOL			m_Init;
	LONG			m_DllType;

	typedef struct _M_CURSOR{
		BOOL		Enable;
		LONG		SizeX;
		LONG		SizeY;
		POINT		Pos;
		LONG		Color;
	}M_CURSOR;

	M_CURSOR		m_Cursor[2];

public:
	CArtCamSdk*		m_pCArtCamSdk;

	BOOL	InitControl		(UINT SliderID, UINT EditID, UINT SpinID, LONG Min, LONG Max, LONG Now, LONG Tic);
	BOOL	SetSpinSlier	(UINT Spin, UINT Slider, LONG Pos);
	void	ChangeCursor	(void);	

public:
	CSetMonitorDlg2(CWnd* pParent = NULL);   // Standard constructor
	virtual ~CSetMonitorDlg2();

// Dialog data
	enum { IDD = IDD_SETMONITOR2 };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV Support

	DECLARE_MESSAGE_MAP()
public:
	virtual BOOL OnInitDialog();
	virtual void OnOK();
	virtual void OnCancel();
	afx_msg void OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar);
	virtual BOOL OnCommand(WPARAM wParam, LPARAM lParam);
	afx_msg void OnBnClickedDefault();
	afx_msg void OnBnClickedColor();
	afx_msg void OnBnClickedAwb();
	afx_msg void OnBnClickedVflip();
	afx_msg void OnBnClickedHflip();
	afx_msg void OnBnClickedWrite();
	afx_msg void OnBnClickedCusorOn();
private:
	int	m_CursorNumber;
public:
	afx_msg void OnBnClickedChangeColor();
	afx_msg void OnBnClickedInitMon();
	afx_msg void OnBnClickedSelCursor2();
	afx_msg void OnBnClickedSelCursor1();
	afx_msg void OnLButtonDown(UINT nFlags, CPoint point);
	afx_msg void OnPaint();
};

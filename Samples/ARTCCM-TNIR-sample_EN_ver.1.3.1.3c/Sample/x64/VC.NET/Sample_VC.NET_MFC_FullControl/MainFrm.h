// MainFrm.h : Interface for CMainFrame class
//


#pragma once
class CMainFrame : public CFrameWnd
{
	
protected: // Only created from serialization
	CMainFrame();
	DECLARE_DYNCREATE(CMainFrame)

// Attribute
public:

// Operation
public:
	void	SetStatusText	(LONG Index, LPCTSTR Text);

// Override
public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);

// Mounting
public:
	virtual ~CMainFrame();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:  // Member for control bar
	CStatusBar  m_wndStatusBar;

// Function for allocating message generated
protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnInitMenuPopup(CMenu* pPopupMenu, UINT nIndex, BOOL bSysMenu);
protected:
	virtual BOOL OnCommand(WPARAM wParam, LPARAM lParam);
};


inline void CMainFrame::SetStatusText(LONG Index, LPCTSTR Text)
{
	m_wndStatusBar.SetPaneText(Index, Text);
}

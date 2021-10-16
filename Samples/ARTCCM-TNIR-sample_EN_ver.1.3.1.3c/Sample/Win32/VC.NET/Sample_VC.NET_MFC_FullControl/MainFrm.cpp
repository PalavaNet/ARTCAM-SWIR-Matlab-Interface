// MainFrm.cpp : Mounting of CMainFrame class
//

#include "stdafx.h"
#include "Sample_MFC.h"

#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMainFrame

IMPLEMENT_DYNCREATE(CMainFrame, CFrameWnd)

BEGIN_MESSAGE_MAP(CMainFrame, CFrameWnd)
	ON_WM_CREATE()
	ON_WM_INITMENUPOPUP()
END_MESSAGE_MAP()

// CMainFrame Construction/Destruction

CMainFrame::CMainFrame()
{
	m_bAutoMenuEnable = FALSE;
}

CMainFrame::~CMainFrame()
{
}


int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CFrameWnd::OnCreate(lpCreateStruct) == -1)
		return -1;

	m_wndStatusBar.Create(this);
	m_wndStatusBar.SetIndicators(indicators, sizeof(indicators)/sizeof(UINT));
	m_wndStatusBar.SetPaneInfo(STATUS_TEXT,	STATUS_TEXT,	SBPS_STRETCH,	0);
	m_wndStatusBar.SetPaneInfo(STATUS_SW,		STATUS_SW,		SBPS_NORMAL,	45);
	m_wndStatusBar.SetPaneInfo(STATUS_FRAME,	STATUS_FRAME,	SBPS_NORMAL,	40);
	m_wndStatusBar.SetPaneInfo(STATUS_X,		STATUS_X,		SBPS_NORMAL,	35);
	m_wndStatusBar.SetPaneInfo(STATUS_Y,		STATUS_Y,		SBPS_NORMAL,	35);

	return 0;
}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	if( !CFrameWnd::PreCreateWindow(cs) )
		return FALSE;

	// TODO: Modify "CREATESTRUCT cs" at this position and adjust Window class or style.
	//  

	return TRUE;
}


// CMain diagnosis

#ifdef _DEBUG
void CMainFrame::AssertValid() const
{
	CFrameWnd::AssertValid();
}

void CMainFrame::Dump(CDumpContext& dc) const
{
	CFrameWnd::Dump(dc);
}

#endif //_DEBUG


// CMainFrame Message handler


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	Menu display
//

void CMainFrame::OnInitMenuPopup(CMenu* pPopupMenu, UINT nIndex, BOOL bSysMenu)
{
	CFrameWnd::OnInitMenuPopup(pPopupMenu, nIndex, bSysMenu);

	// Enable/disable depending on condition
	theApp.m_pView->InitMenuPopup(pPopupMenu);
}


//////////////////////////////////////////////////////////////////////////////////////////////
//
//	
//

BOOL CMainFrame::OnCommand(WPARAM wParam, LPARAM lParam)
{
	UINT ID = LOWORD(wParam);
	LONG DllNumber = ID - ID_DLL_RELOAD - 1;

	if(0 <= DllNumber && DllNumber < theApp.m_pView->m_DllCount){
		theApp.m_pView->OnDllChange(DllNumber, -1);
	}
	else if(ID_DLL_SATA_LVDS <= ID && ID <= ID_DLL_SATA_200MI){
		LONG SataType = ID - ID_DLL_SATA_LVDS;
		theApp.m_pView->OnDllChange(theApp.m_pView->m_DllSata, SataType);
	}

	return CFrameWnd::OnCommand(wParam, lParam);
}

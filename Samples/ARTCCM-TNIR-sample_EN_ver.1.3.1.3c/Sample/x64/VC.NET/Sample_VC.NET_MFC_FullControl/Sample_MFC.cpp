// Sample_MFC.cpp : Defines class operation of application.
//

#include "stdafx.h"
#include "Sample_MFC.h"
#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CSample_MFCApp

BEGIN_MESSAGE_MAP(CSample_MFCApp, CWinApp)
	ON_COMMAND(ID_APP_ABOUT, OnAppAbout)
	// Basic document command of standard file
	ON_COMMAND(ID_FILE_NEW, CWinApp::OnFileNew)
	ON_COMMAND(ID_FILE_OPEN, CWinApp::OnFileOpen)
END_MESSAGE_MAP()


// CSample_MFCApp Construction

CSample_MFCApp::CSample_MFCApp()
{
	// TODO: Add construction code at this position.
	// Describe all the important initial process among InitInstance.
}


// This is the only CSample_MFCApp object.

CSample_MFCApp theApp;

// CSample_MFCApp initialization

BOOL CSample_MFCApp::InitInstance()
{
	// In order to make visual style effective for application manifest
	// In the following case, InitCommonControls() is required at Windows XP:
	// *When appointing use of ComCtl32.dll Version6 or later to enable visual style with application manifestation.
	InitCommonControls();

	CWinApp::InitInstance();

	// Standard initialization
	// In case of reducing size of the final executable file without these functions,
	// Please delete unnecessary initialized routine
	// below
	// Modify registry key that stores settings.
	// TODO: Modify this letter string
	// to company/organization name.
	SetRegistryKey(_T("Local application generated at application wizard"));
	LoadStdProfileSettings(4);  // Load option of standard INI file (includes MRU).
	// Register document template for application.
	// Document template functions to unite document, frame window and view.
	CSingleDocTemplate* pDocTemplate;
	pDocTemplate = new CSingleDocTemplate(
		IDR_MAINFRAME,
		RUNTIME_CLASS(CSample_MFCDoc),
		RUNTIME_CLASS(CMainFrame),       // Main SDI frame window
		RUNTIME_CLASS(CSample_MFCView));
	AddDocTemplate(pDocTemplate);
	// Analyze command line of standard shell command such as DDE and file open.
	CCommandLineInfo cmdInfo;
	ParseCommandLine(cmdInfo);
	// Dispatch command appointed by command line.
	// When application starts with /RegServer, Register, /Unregserver or /Unregister, "false" is returned.
	if (!ProcessShellCommand(cmdInfo))
		return FALSE;
	// Display and update because main window is initialized.
	m_pMainWnd->ShowWindow(SW_SHOW);
	m_pMainWnd->UpdateWindow();
	// Call "DragAcceptFiles" only when suffix exists.
	// With SDI application, this call needs to occur straight after "ProcessShellCommand".
	return TRUE;
}



// AboutDlg  dialog used for version information of application.

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog data
	enum { IDD = IDD_ABOUTBOX };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV Support

// Mounting
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()

// Application command to execute dialog
void CSample_MFCApp::OnAppAbout()
{
	CAboutDlg aboutDlg;
	aboutDlg.DoModal();
}


// CSample_MFCApp Message handler


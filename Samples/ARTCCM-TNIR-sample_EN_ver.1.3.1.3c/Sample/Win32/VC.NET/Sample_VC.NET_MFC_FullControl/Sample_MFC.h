// Sample_MFC.h : Sample_MFC Main header file of application
//
#pragma once

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // Main symbol


#include "Sample_MFCDoc.h"
#include "Sample_MFCView.h"


static UINT indicators[] =
{
	ID_SEPARATOR,
	ID_SEPARATOR,
	ID_SEPARATOR,
	ID_SEPARATOR,
	ID_SEPARATOR,
};

enum {
	STATUS_TEXT = 0,
	STATUS_SW,
	STATUS_FRAME,
	STATUS_X,
	STATUS_Y,
};



// CSample_MFCApp:
// Please refer to Sample_MFC.cpp about mounting of this class
//

class CSample_MFCApp : public CWinApp
{
public:
	CSample_MFCView*	m_pView;


public:
	CSample_MFCApp();


// Override
public:
	virtual BOOL InitInstance();

// Mounting
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CSample_MFCApp theApp;

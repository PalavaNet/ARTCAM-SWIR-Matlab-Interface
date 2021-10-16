// Sample_MFCDoc.cpp : CSample_MFCDoc Mounting of class
//

#include "stdafx.h"
#include "Sample_MFC.h"

#include "Sample_MFCDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CSample_MFCDoc

IMPLEMENT_DYNCREATE(CSample_MFCDoc, CDocument)

BEGIN_MESSAGE_MAP(CSample_MFCDoc, CDocument)
END_MESSAGE_MAP()


// CSample_MFCDoc Construction/Destruction

CSample_MFCDoc::CSample_MFCDoc()
{
	// TODO: Add the code here for construction to be called only one time

}

CSample_MFCDoc::~CSample_MFCDoc()
{
}

BOOL CSample_MFCDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: Add re-initialization process here
	// (SDI Reuse this document for document)

	return TRUE;
}




// CSample_MFCDoc Serial conversion

void CSample_MFCDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: Add code here for house
	}
	else
	{
		// TODO: Add code here for read
	}
}


// CSample_MFCDoc Diagnosis

#ifdef _DEBUG
void CSample_MFCDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CSample_MFCDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// CSample_MFCDoc Command

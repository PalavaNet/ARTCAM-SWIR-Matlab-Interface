// Sample_MFCDoc.h : CSample_MFCDoc Interface of class
//


#pragma once

class CSample_MFCDoc : public CDocument
{
protected: // Only created from serialization
	CSample_MFCDoc();
	DECLARE_DYNCREATE(CSample_MFCDoc)

// Attribute
public:

// Operation
public:

// Override
	public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);

// Mounting
public:
	virtual ~CSample_MFCDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Function for allocating message generated
protected:
	DECLARE_MESSAGE_MAP()
};



// Sample_MFCView.h : CSample_MFCView Interface of class
//


#pragma once

#include "CArtCamSdk.hpp"

const TCHAR ERRORLIST[][128] = {
	_T(""),
	_T("Not initialized"),
	_T("Access to unavailable device was attempted"),
	_T("Failure of thread creation for capturing"),
	_T("Window creation failed"),
	_T("Not enough memory for image transfer/Failure for securing memory"),
	_T("Error for camera (device) settings"),
	_T("Error for camera (device) size settings"),
	_T("Capturing failed"),
	_T("Wrong argument"),
	_T("Directshow initialization error"),
	_T("Not supported"),
	_T("Unknow error"),
	_T("Device lost"),
	_T("File not found"),
	_T("FPGA setting error"),
	_T("Failure of image transferring"),
};

const int ERRORCOUNT		= sizeof(ERRORLIST)			/ (128 * sizeof(TCHAR));





class CSample_MFCView : public CView
{
public:
	CArtCamSdk	m_CArtCamSdk;
	LPBYTE		m_pImage;			// Space for image data
	BOOL		m_PreviewMode;		// Preview display/Callback display
	LONG		m_DllType;			// DLL to be connected
	LONG		m_DllSata;			// 
	LONG		m_DllCount;			// 
	LONG		m_CurrentCameraType;// Current camera type
	LONG		m_SataType;			// SATA camera type
	LONG		m_DeviceCount;		// Number of detected device
	LONG		m_SelectDevice;		// Number of chosen device

	BOOL		m_SaveFlg;			// Deicide if save is available
	BOOL		m_StopFlg;			// Determination of stoppage
	CString		m_RecName;			// Name of recorded file

	LONG		m_BitMode;			// 16 bit picture transferring mode


	LRESULT	DrawImage		(HDC hDC);
	BOOL		OnDllChange		(LONG DllType, LONG SataType);
	BOOL	OnDeviceChange	(LONG Number);
	void	ChangeScrollbar	(void);
	void	CheckColorMode	(void);


	void InitMenuPopup(CMenu* pPopupMenu);



protected: // Only created from serialization
	CSample_MFCView();
	DECLARE_DYNCREATE(CSample_MFCView)

// Attribute
public:
	CSample_MFCDoc* GetDocument() const;

// Operation
public:

// Override
	public:
	virtual void OnDraw(CDC* pDC);  // Override to draw this view
virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:

// Mounting
public:
	virtual ~CSample_MFCView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif


// Function for allocating message generated
protected:
	DECLARE_MESSAGE_MAP()
public:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnDestroy();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg void OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar);
	afx_msg void OnVScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar);
	afx_msg void OnMouseMove(UINT nFlags, CPoint point);
	afx_msg LRESULT OnGraphPaint(WPARAM wParam, LPARAM lParam);
	afx_msg LRESULT OnError(WPARAM wParam, LPARAM lParam);
	afx_msg void OnFileSaveimage();
	afx_msg void OnFileRec();
	afx_msg void OnExit();
	afx_msg void OnShowPreview();
	afx_msg void OnShowCallback();
	afx_msg void OnShowSnapshot();
	afx_msg void OnShowCapture();
	afx_msg void OnShowTrigger();
	afx_msg void OnShowStop();
	afx_msg void OnSetFormat();
	afx_msg void OnSetFilter();
	afx_msg void OnSetAnalog();
	afx_msg void OnSetFilterApp();
	afx_msg void OnDllReload();
	afx_msg void OnDevice01();
	afx_msg void OnDevice02();
	afx_msg void OnDevice03();
	afx_msg void OnDevice04();
	afx_msg void OnDevice05();
	afx_msg void OnDevice06();
	afx_msg void OnDevice07();
	afx_msg void OnDevice08();
	afx_msg void OnSetSizeApp();
	afx_msg void OnSetIoApp();
	afx_msg void OnSetMonitorApp();
	afx_msg void OnSetCorrection();
};

#ifndef _DEBUG  // Debugging version of Sample_MFCView.cpp
inline CSample_MFCDoc* CSample_MFCView::GetDocument() const
   { return reinterpret_cast<CSample_MFCDoc*>(m_pDocument); }
#endif


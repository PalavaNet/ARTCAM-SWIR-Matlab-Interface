// stdafx.h : Describe standard system include file
// or include file which is only for project
// is frequently referred and seldom changed.This describes standard system include file or include file for project that is referred many times and not changed much.

#pragma once

#ifndef VC_EXTRALEAN
#define VC_EXTRALEAN		// Eliminate un-used part from Windows header.
#endif

#ifdef __VS2010__
#include <SDKDDKVer.h>
#else

// Change the following definitions when you need to appoint platform before definitions appointed below.
// Refer to MSDN for update info regarding values that responds to different platform.
#ifndef WINVER				// Permit use of specific function to Windows95/NT or later version.
#define WINVER 0x0400		// Adjust to the appropriate value for Windows98/2000 or later version.
#endif

#ifndef _WIN32_WINNT		// Permit use of specific function to Windows NT or later version.
#define _WIN32_WINNT 0x0400		// Adjust to the appropriate value for Windows98/2000 or later version.
#endif						

#ifndef _WIN32_WINDOWS		// Permit use of specific function to Windows98
#define _WIN32_WINDOWS 0x0410 // Adjust to the appropriate value for Windows Me or later version.
#endif

#ifndef _WIN32_IE			// Permit use of specific function to IE4.0 or later version.
#define _WIN32_IE 0x0400	// Adjust to the appropriate value for IE5.0 or later version.
#endif
#endif // _VS2010

#define _ATL_CSTRING_EXPLICIT_CONSTRUCTORS	// A part of CString constructor is explicit.

// Release hiding a part of MFC warning message that is general and safe when ignored.
#define _AFX_ALL_WARNINGS

#include <afxwin.h>         // Core and standard component of MFC
#include <afxext.h>         // Expansion part of MFC

#include <afxdtctl.h>		// Internet Explorer4 common control support of MFC
#ifndef _AFX_NO_AFXCMN_SUPPORT
#include <afxcmn.h>			// Windows common control support of MFC
#endif // _AFX_NO_AFXCMN_SUPPORT


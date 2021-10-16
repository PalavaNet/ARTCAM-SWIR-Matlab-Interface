//==========================================================
//	ARTRAY Camera / Capture Module Software Developer Kit
//
//						Version 1.20		2003.9.4
//						Version 1.21		2003.9.18
//						Version 1.22		2003.10.10
//						Version 1.23		2004.1.21
//						Version 1.235		2004.3.19
//						Version 1.24		2004.7.9
//						Version 1.245		2004.8.17
//						Version 1.25		2004.9.1
//						Version 1.26		2004.10.28
//						Version 1.27		2005.3.8
//						Version 1.275		2005.4.18
//						Version 1.276		2005.9.5
//						Version 1.277		2005.12.22
//						Version 1.280		2007.4.4
//						Version 1.300		2011.9.16
//						Version 1.301		2011.11.21
//
//									(C) 2002-2011 Artray
//==========================================================


#ifndef _ARTCAMSDK_
#define _ARTCAMSDK_

#include <windows.h>



#ifdef ARTCAM_EXPORTS
#define ARTCAMSDK_API __declspec(dllexport)
#else
#define ARTCAMSDK_API __declspec(dllimport)
#endif




#define WM_GRAPHNOTIFY  WM_APP + 1		// Not used in this version.
#define WM_GRAPHPAINT	WM_APP + 2		// Sent to application when an image is updated.
#define WM_ERROR		WM_APP + 3		// Sent to application when an error occurs


#define  HACAM  DWORD

enum {
	ARTCAM_CAMERATYPE_DS			= 1,	// DirectShow Camera
	ARTCAM_CAMERATYPE_DISABLE1		= 2,	// Invalid
	ARTCAM_CAMERATYPE_USTC			= 3,	// ARTUST
	ARTCAM_CAMERATYPE_CNV			= 4,	// ARTCNV
	ARTCAM_CAMERATYPE_DISABLE2		= 5,	// Invalid
	ARTCAM_CAMERATYPE_130MI			= 6,	// ARTCAM-130MI
	ARTCAM_CAMERATYPE_DISABLE3		= 7,	// Invalid
	ARTCAM_CAMERATYPE_200MI			= 8,	// ARTCAM-200MI
	ARTCAM_CAMERATYPE_300MI			= 9,	// ARTCAM-300MI
	ARTCAM_CAMERATYPE_150P			= 10,	// ARTCAM-150P
	ARTCAM_CAMERATYPE_320P			= 11,	// ARTCAM-320P
	ARTCAM_CAMERATYPE_DISABLE4		= 12,	// Invalid
	ARTCAM_CAMERATYPE_200SH			= 13,	// ARTCAM-200SH
	ARTCAM_CAMERATYPE_098			= 14,	// ARTCAM-098
	ARTCAM_CAMERATYPE_036MI			= 15,	// ARTCAM-036MI
	ARTCAM_CAMERATYPE_500P			= 16,	// ARTCAM-500P
	ARTCAM_CAMERATYPE_150P2			= 17,	// ARTCAM-150PII
	ARTCAM_CAMERATYPE_036MIST		= 18,	// ARTCAM-036MIST
	ARTCAM_CAMERATYPE_500MI			= 19,	// ARTCAM-500MI
	ARTCAM_CAMERATYPE_DISABLE5		= 20,	// Invalid
	ARTCAM_CAMERATYPE_DISABLE6		= 21,	// Invalid
	ARTCAM_CAMERATYPE_150P3			= 22,	// ARTCAM-150PIII
	ARTCAM_CAMERATYPE_130MI_MOUT	= 23,	// ARTCAM-130MI MOUT
	ARTCAM_CAMERATYPE_150P3_MOUT	= 24,	// ARTCAM-150PIII MOUT
	ARTCAM_CAMERATYPE_267KY			= 25,	// ARTCAM-267KY
	ARTCAM_CAMERATYPE_274KY			= 26,	// ARTCAM-274KY
	ARTCAM_CAMERATYPE_625KY			= 27,	// ARTCAM-625KY
	ARTCAM_CAMERATYPE_V135MI		= 28,	// ARTCAM-V135MI
	ARTCAM_CAMERATYPE_445KY			= 29,	// ARTCAM-445KY
	ARTCAM_CAMERATYPE_098II			= 30,	// ARTCAM-098II
	ARTCAM_CAMERATYPE_MV413			= 31,	// ARTCAM-MV413USB
	ARTCAM_CAMERATYPE_OV210			= 32,	// ARTCAM-OV210
	ARTCAM_CAMERATYPE_850SH			= 33,	// ARTCAM-850SH
	ARTCAM_CAMERATYPE_1251SH		= 34,	// ARTCAM-1252SH
	ARTCAM_CAMERATYPE_D131			= 35,	// ARTCAM-D131
	ARTCAM_CAMERATYPE_900MI			= 36,	// ARTCAM-900MI
	ARTCAM_CAMERATYPE_1000MI		= 37,	// ARTCAM-1000MI
	ARTCAM_CAMERATYPE_500P2			= 38,	// ARTCAM-500P2
	ARTCAM_CAMERATYPE_035KY			= 39,	// ARTCAM-035KY
	ARTCAM_CAMERATYPE_1000MI_HD2	= 40,	// ARTCAM-1000MI-HD2
	ARTCAM_CAMERATYPE_006MAT		= 41,	// ARTCAM-006MAT
	ARTCAM_CAMERATYPE_150P5_HD2		= 42,	// ARTCAM-150P5-HD2
	ARTCAM_CAMERATYPE_130MI_HD2		= 43,	// ARTCAM-130MI-HD2

	
	ARTCAM_CAMERATYPE_300MI_STR2	= 104,	// ARTCAM-300MI Str2
	ARTCAM_CAMERATYPE_500MI_STR2	= 105,	// ARTCAM-500MI Str2
	ARTCAM_CAMERATYPE_D131_EIO		= 110,  // ARTCAM-D131  EIO
	ARTCAM_CAMERATYPE_022MI_EIO		= 111,  // ARTCAM-022   EIO
	
	ARTCAM_CAMERATYPE_008TNIR		= 126,	// ARTCAM-008TNIR
	ARTCAM_CAMERATYPE_031TNIR		= 127,	// ARTCAM-031TNIR
	ARTCAM_CAMERATYPE_0016TNIR		= 128,	// ARTCAM-0016TNIR

	ARTCAM_CAMERATYPE_SATA			= 201,	// SATA CAMERA


	// USB3.0 Cameras
	ARTCAM_CAMERATYPE_USB3_900MI	= 301,	// ARTCAM-900MI-USB3
	ARTCAM_CAMERATYPE_USB3_500MI	= 302,	// ARTCAM-500MI-USB3
	ARTCAM_CAMERATYPE_USB3_150P3	= 303,	// ARTCAM-150P3-USB3
	ARTCAM_CAMERATYPE_USB3_445KY	= 304,	// ARTCAM-445KY2-USB3
	ARTCAM_CAMERATYPE_USB3_1400MI	= 305,	// ARTCAM-1400MI-USB3
	ARTCAM_CAMERATYPE_USB3_267KY	= 306,	// ARTCAM-267KY-USB3
	ARTCAM_CAMERATYPE_USB3_655KY	= 307,	// ARTCAM-655KY-USB3
	ARTCAM_CAMERATYPE_USB3_274KY	= 308,	// ARTCAM-274KY-USB3
	ARTCAM_CAMERATYPE_USB3_424KY	= 309,	// ARTCAM-424KY-USB3
	ARTCAM_CAMERATYPE_USB3_2900KAI	= 310,	// ARTCAM-2900KAI-USB3
	ARTCAM_CAMERATYPE_USB3_810KAI	= 311,	// ARTCAM-810KAI-USB3
	ARTCAM_CAMERATYPE_USB3_1000MI	= 312,	// ARTCAM-1000MI-USB3
	ARTCAM_CAMERATYPE_USB3_2000CMV	= 313,	// ARTCAM-2000CMV-USB3
	ARTCAM_CAMERATYPE_USB3_1600KAI	= 314,	// ARTCAM-1600KAI-USB3
	ARTCAM_CAMERATYPE_USB3_410KAI	= 315,	// ARTCAM-410KAI-USB3
	ARTCAM_CAMERATYPE_USB3_100KAI	= 316,	// ARTCAM-100KAI-USB3
	ARTCAM_CAMERATYPE_USB3_210KAI	= 317,	// ARTCAM-210KAI-USB3

	// WOM Cameras
	ARTCAM_CAMERATYPE_036MI2_WOM	= 400,	// ARTCAM-036MI WOM 
	ARTCAM_CAMERATYPE_130MI_WOM		= 401,	// ARTCAM-130MI WOM 
	ARTCAM_CAMERATYPE_300MI_WOM		= 402,	// ARTCAM-300MI WOM 
	ARTCAM_CAMERATYPE_500MI_WOM		= 403,	// ARTCAM-500MI WOM 
	ARTCAM_CAMERATYPE_900MI_WOM		= 404,	// ARTCAM-900MI WOM
	ARTCAM_CAMERATYPE_1000MI_WOM	= 405,	// ARTCAM-1000MI WOM
	ARTCAM_CAMERATYPE_1400MI_WOM	= 406,	// ARTCAM-1400MI WOM
	ARTCAM_CAMERATYPE_IMX035_WOM	= 407,	// ARTCAM-IMX035 WOM
	ARTCAM_CAMERATYPE_130HP_WOM		= 408,	// ARTCAM-130HP WOM

	
	ARTCAM_CAMERATYPE_150P5_WOM		= 420,	// ARTCAM-150P3 WOM 
	ARTCAM_CAMERATYPE_267KY_WOM		= 421,	// ARTCAM-267KY WOM 
	ARTCAM_CAMERATYPE_274KY_WOM		= 422,	// ARTCAM-274KY WOM 
	ARTCAM_CAMERATYPE_445KY2_WOM	= 423,	// ARTCAM-445KY2 WOM
	ARTCAM_CAMERATYPE_500P2_WOM		= 424,	// ARTCAM-500P2 WOM 
	ARTCAM_CAMERATYPE_655KY_WOM		= 425,	// ARTCAM-655KY WOM 
	ARTCAM_CAMERATYPE_424KY_WOM		= 426,	// ARTCAM-424KY WOM
	ARTCAM_CAMERATYPE_445KY3_WOM	= 427,	// ARTCAM-445KY2 WOM
	ARTCAM_CAMERATYPE_285CX_WOM		= 428,	// ARTCAM-285CX WOM
	ARTCAM_CAMERATYPE_407UV_WOM		= 429,	// ARTCAM-407UV WOM
	ARTCAM_CAMERATYPE_130E2V_WOM	= 430,	// ARTCAM-130E2V WOM
	ARTCAM_CAMERATYPE_130XQE_WOM	= 431,	// ARTCAM-130XQE WOM
	ARTCAM_CAMERATYPE_0134AR_WOM	= 432,	// ARTCAM_0134AR WOM
	ARTCAM_CAMERATYPE_092XQE_WOM	= 433,	// ARTCAM-092XQE WOM
	ARTCAM_CAMERATYPE_265IMX_WOM	= 434,  // ARTCAM-265IMX WOM
	ARTCAM_CAMERATYPE_264IMX_WOM	= 435,  // ARTCAM-264IMX WOM
	ARTCAM_CAMERATYPE_130UV_WOM		= 436,	// ARTCAM-130UV WOM
	ARTCAM_CAMERATYPE_092UV_WOM		= 437,	// ARTCAM-092UV WOM

	//USB3 Type2
	ARTCAM_CAMERATYPE_500MI_USB3_T2  = 500,	// ARTCAM-500MI-USB3-T2
	ARTCAM_CAMERATYPE_1000MI_USB3_T2 = 501,	// ARTCAM-1000MI-USB3-T2
	ARTCAM_CAMERATYPE_1400MI_USB3_T2 = 502,	// ARTCAM-1400MI-USB3-T2
	ARTCAM_CAMERATYPE_034MI_USB3_T2  = 503,	// ARTCAM-034MI-USB3-T2
	ARTCAM_CAMERATYPE_178IMX_USB3_T2 = 504,	// ARTCAM-178IMX-USB3-T2
	ARTCAM_CAMERATYPE_174IMX_USB3_T2 = 505,	// ARTCAM-174IMX-USB3-T2

	ARTCAM_CAMERATYPE_410KAI_USB3_T2	= 509,	//
	ARTCAM_CAMERATYPE_810KAI_USB3_T2	= 510,	//
	ARTCAM_CAMERATYPE_1600KAI_USB3_T2	= 511,	//
	ARTCAM_CAMERATYPE_2900KAI_USB3_T2	= 512,	//

	ARTCAM_CAMERATYPE_130SWIR_USB3_T2   = 515,	//
	ARTCAM_CAMERATYPE_032TNIR_USB3_T2   = 516,	//
	ARTCAM_CAMERATYPE_009TNIR_USB3_T2   = 517,	//
	ARTCAM_CAMERATYPE_L256TNIR_USB3_T2  = 518,	//
	ARTCAM_CAMERATYPE_L512TNIR_USB3_T2  = 519,	//
	ARTCAM_CAMERATYPE_131TNIR_USB3_T2	= 520,	//

	ARTCAM_CAMERATYPE_250IMX_USB3_T2    = 522,
	ARTCAM_CAMERATYPE_252IMX_USB3_T2    = 523,
	ARTCAM_CAMERATYPE_264IMX_USB3_T2    = 524,
	ARTCAM_CAMERATYPE_265IMX_USB3_T2    = 525,
	ARTCAM_CAMERATYPE_L1024TNIR_USB3_T2 = 526,
	ARTCAM_CAMERATYPE_2020UV_USB3_T2    = 527,
	ARTCAM_CAMERATYPE_226IMX_USB3_T2	= 528,
	ARTCAM_CAMERATYPE_990SWIR			= 534,
	ARTCAM_CAMERATYPE_990SWIR_TEC		= 535,
	ARTCAM_CAMERATYPE_991SWIR			= 536,
	ARTCAM_CAMERATYPE_991SWIR_TEC		= 537,

};

// SATA Camera type
enum {
	ARTCAM_CAMERATYPE_SATA_LVDS		= 0,
	ARTCAM_CAMERATYPE_SATA_300MI	= 1,
	ARTCAM_CAMERATYPE_SATA_500MI	= 2,
	ARTCAM_CAMERATYPE_SATA_MV413	= 3,
	ARTCAM_CAMERATYPE_SATA_800MI	= 4,
	ARTCAM_CAMERATYPE_SATA_036MI	= 5,
	ARTCAM_CAMERATYPE_SATA_150P		= 6,
	ARTCAM_CAMERATYPE_SATA_267KY	= 7,
	ARTCAM_CAMERATYPE_SATA_274KY	= 8,
	ARTCAM_CAMERATYPE_SATA_625KY	= 9,
	ARTCAM_CAMERATYPE_SATA_130MI	=10,
	ARTCAM_CAMERATYPE_SATA_200MI	=11,
};


// Error Code
enum {
	ARTCAMSDK_NOERROR = 0,			// Normal
	ARTCAMSDK_NOT_INITIALIZE,		// Not initialized
	ARTCAMSDK_DISABLEDDEVICE,		// Access to unavailable device was attempted
	ARTCAMSDK_CREATETHREAD,			// Failure of thread creation for capturing
	ARTCAMSDK_CREATEWINDOW,			// Window creation failed
	ARTCAMSDK_OUTOFMEMORY,			// Not enough memory for image transfer/Failure for securing memory
	ARTCAMSDK_CAMERASET,			// Error for camera (device) settings
	ARTCAMSDK_CAMERASIZE,			// Error for camera (device) size settings
	ARTCAMSDK_CAPTURE,				// Capturing failed
	ARTCAMSDK_PARAM,				// Wrong argument
	ARTCAMSDK_DIRECTSHOW,			// Directshow initialization error
	ARTCAMSDK_UNSUPPORTED,			// Not supported
	ARTCAMSDK_UNKNOWN,				// Unknow error
	ARTCAMSDK_CAPTURELOST,			// Device lost
	ARTCAMSDK_FILENOTFOUND,			// File not found
	ARTCAMSDK_FPGASET,				// FPGA settings error
	ARTCAMSDK_TRANSIMAGEFAILED,		// Failure of image transferring
};                                     
                                       
// Information for transferring
typedef struct GP_INFO {
	LONG	lSize;			// Size of this struct
	LONG	lWidth;			// Width of image
	LONG	lHeight;		// Height of image
	LONG	lBpp;			// Byte per pixcel
	LONG	lFps;			// Frame rate (x10)
	LPBYTE	pImage;			// The pointer to the captured image
} *LPGP_INFO;

// Camera information
typedef struct CAMERAINFO {
	LONG	lSize;				// Size of this struct
	LONG	lWidth;				// H-Effective
	LONG	lHeight;			// V-Effective
	LONG	lGlobalGainMin;		// Min value of Global Gain (Return -1 if disabled)
	LONG	lGlobalGainMax;		// Max value of Global Gain(Return -1 if disabled)
	LONG	lColorGainMin;		// Min value of Color Gain(Return -1 if disabled)
	LONG	lColorGainMax;		// Max value of Colof Gain(Return -1 if disabled)
	LONG	lExposureMin;		// Min value of Shutter Width(Return -1 if disabled)
	LONG	lExposureMax;		// Max value of Shutter Width(Return -1 if disabled)
	double	dExposureExMin;		// Min value of Shutter Width(Return -1 if disabled)
	double	dExposureExMax;		// Min value of Shutter Width(Return -1 if disabled)
} *LPCAMERAINFO;

// Type of image filter
enum {
	ARTCAM_FILTERTYPE_RESERVE = 0,			// Reserved
	ARTCAM_FILTERTYPE_BRIGHTNESS,			// Brightness
	ARTCAM_FILTERTYPE_CONTRAST,				// Contrast
	ARTCAM_FILTERTYPE_HUE,					// Hue
	ARTCAM_FILTERTYPE_SATURATION,			// Saturation
	ARTCAM_FILTERTYPE_SHARPNESS,			// Sharpness
	ARTCAM_FILTERTYPE_BAYER_GAIN_RGB,		// Bayer coversion color gain
	ARTCAM_FILTERTYPE_BAYER_GAIN_R,			// Color gain (red only) for bayer conversion
	ARTCAM_FILTERTYPE_BAYER_GAIN_G,			// Color gain (green only) for bayer conversion
	ARTCAM_FILTERTYPE_BAYER_GAIN_B,			// Color gain (Blue only) for bayer conversion
	ARTCAM_FILTERTYPE_BAYER_GAIN_AUTO,		// Auto white balance
	ARTCAM_FILTERTYPE_GAMMA,				// Gumma
	ARTCAM_FILTERTYPE_BAYERMODE,			// Bayer conversion mode
	ARTCAM_FILTERTYPE_GLOBAL_GAIN,			// Global gain for camera
	ARTCAM_FILTERTYPE_COLOR_GAIN_R,			// Color gain (red) for camera
	ARTCAM_FILTERTYPE_COLOR_GAIN_G1,		// Color gain (green1) for camera
	ARTCAM_FILTERTYPE_COLOR_GAIN_G2,		// Color gain (green2) for camera
	ARTCAM_FILTERTYPE_COLOR_GAIN_B,			// Color gain (blue) for camera
	ARTCAM_FILTERTYPE_EXPOSURETIME,			// Exposure time (shutter speed)
	ARTCAM_FILTERTYPE_GRAY_MODE,			// Convert mode for gray scale
	ARTCAM_FILTERTYPE_GRAY_GAIN_R,			// Color gain (red) for gray scale
	ARTCAM_FILTERTYPE_GRAY_GAIN_G1,			// Color gain (green1) for gray scale
	ARTCAM_FILTERTYPE_GRAY_GAIN_G2,			// Color gain (green2) for gray scale
	ARTCAM_FILTERTYPE_GRAY_GAIN_B,			// Color gain (blue) for gray scale
	ARTCAM_FILTERTYPE_GRAY_OFFSET_R,		// Color offset (red) for gray scale
	ARTCAM_FILTERTYPE_GRAY_OFFSET_G1,		// Color offset (green1) for gray scale
	ARTCAM_FILTERTYPE_GRAY_OFFSET_G2,		// Color offset (green2) for gray scale
	ARTCAM_FILTERTYPE_GRAY_OFFSET_B,		// Color offset (blue) for gray scale
};

// Compatibility with previous versions
#define ARTCAM_FILTERTYPE_RGB_GAIN		ARTCAM_FILTERTYPE_BAYER_GAIN_RGB
#define ARTCAM_FILTERTYPE_R_GAIN		ARTCAM_FILTERTYPE_BAYER_GAIN_R
#define ARTCAM_FILTERTYPE_G_GAIN		ARTCAM_FILTERTYPE_BAYER_GAIN_G
#define ARTCAM_FILTERTYPE_B_GAIN		ARTCAM_FILTERTYPE_BAYER_GAIN_B
#define ARTCAM_FILTERTYPE_AUTO_GAIN		ARTCAM_FILTERTYPE_BAYER_GAIN_AUTO


// Pixel skipping transfer mode
enum {
	SUBSAMPLE_1 = 0,	// Full size
	SUBSAMPLE_2,		// 1/2
	SUBSAMPLE_4,		// 1/4
	SUBSAMPLE_8,		// 1/8
	BINNING_2   = 0x11,    
	BINNING_4	= 0x12,
};


// Auto iris mode
enum {
	AI_NONE = 0,		// Invalid
	AI_EXPOSURE,		// Exposure time
	AI_GAIN,			// Gain
	AI_BOTH,			// Exposure time + Gain
};


// Convert mode for gray scale
enum {
	GRAY_NONE = 0,		// Disable
	GRAY_BAYERCONVERT,	// Calculate from Bayer array
	GRAY_GRAYSCALE,		// Get LUMA data from Color-converted image
};


// Video format
enum {
	VIDEOFORMAT_NTSC = 0,	// NTSC
	VIDEOFORMAT_PAL,		// PAL
	VIDEOFORMAT_PALM,		// PALM
	VIDEOFORMAT_SECAM,		// SECAM
};

// Sampling rate
enum {
	WIDE_HISPEED = 0,	// 
	WIDE_LOWSPEED,		// 
	NORMAL_HISPEED,		// 
	NORMAL_LOWSPEED,	// 
};


// Format for image saving
enum {
	FILETYPE_BITMAP = 0,	// Bitmap saving (large size).
	FILETYPE_RAW,			// Only data is saved (large size)
	FILETYPE_JPEG_HIGH,		// Save in high-quality JPEG format (medium size). Characters and lines are distorted.
	FILETYPE_JPEG_NOMAL,	// Save in standard JPEG format (small size). Small patterns are distorted.
	FILETYPE_JPEG_LOW,		// Save in low-quality JPEG (small size). Block noise are seen.
	FILETYPE_PNG,			// Save as PNG. 16 bits image can be saved correctly. Size=Medium
	FILETYPE_TIFF,			// Save as TIFF. 16 bits image can be saved correctly. Size=Large
};


/*
 *Remark*
 16 bit image cannot be read in every image-processing software or in every environment.
 16 bit PNG and TIFF saved by this SDK can be read by our Veiwer Software Version2 or later and Adobe Photoshop6.
 For all other software, deterioration of image or an error may be experienced.
 Since it saves as a 16-bit gray scale picture when saved by 16-bit bitmap   The color palette etc. is not saved. 
 Since it saves as a 16-bit gray scale picture when saved by 16-bit bitmap   The color palette etc. is not saved.
 
 In case it saves by 16 bits which needs to prepare a 16-bit palette by the software side, 
 or needs to prepare the device context of gray scale, we recommend you to save by TIFF or PNG. 
 In JPEG, it cannot save other than a color picture. 
 Especially about a 16-bit picture, data of 8 bits of low ranks is omitted and saved. 
*/


enum {
	MASKTYPE_LOW = 0,
	MASKTYPE_HIGH,
};




#ifdef __cplusplus
extern "C"{
#endif

	ARTCAMSDK_API DWORD		ArtCam_GetDllVersion		(void);
	ARTCAMSDK_API LONG		ArtCam_GetLastError			(HACAM hACam);

	ARTCAMSDK_API HACAM		ArtCam_Initialize			(HWND hWnd);
	ARTCAMSDK_API BOOL		ArtCam_Release				(HACAM hACam);

	ARTCAMSDK_API BOOL		ArtCam_Preview				(HACAM hACam);
	ARTCAMSDK_API BOOL		ArtCam_Record				(HACAM hACam, LPCTSTR lpAviName, UINT RecTime, BOOL fShow);
	ARTCAMSDK_API BOOL		ArtCam_CallBackPreview		(HACAM hACam, HWND hWnd, LPBYTE lpImage, LONG Size, BOOL TopDown);
	ARTCAMSDK_API BOOL		ArtCam_Close				(HACAM hACam);

	// 1230
	ARTCAMSDK_API BOOL		ArtCam_SnapShot				(HACAM hACam, LPBYTE lpImage, LONG Size, BOOL TopDown);

	// 1250
	ARTCAMSDK_API BOOL		ArtCam_Capture				(HACAM hACam);

	// 1260
	ARTCAMSDK_API BOOL		ArtCam_Trigger				(HACAM hACam, HWND hWnd, LPBYTE lpImage, LONG Size, BOOL TopDown);
	ARTCAMSDK_API BOOL		ArtCam_SaveImage			(HACAM hACam, LPCTSTR lpSaveName, LONG FileType);


	ARTCAMSDK_API BOOL		ArtCam_SetPreviewWindow		(HACAM hACam, HWND hWnd, LONG Left, LONG Top, LONG Right, LONG Bottom);
	ARTCAMSDK_API BOOL		ArtCam_SetCaptureWindow		(HACAM hACam, LONG Width, LONG Height, LONG Fps);
	ARTCAMSDK_API BOOL		ArtCam_SetCaptureWindowEx	(HACAM hACam, LONG HTotal, LONG HStart, LONG HEffective, LONG VTotal, LONG VStart, LONG VEffective);
	ARTCAMSDK_API BOOL		ArtCam_GetCaptureWindowEx	(HACAM hACam, LONG* HTotal, LONG* HStart, LONG* HEffective, LONG* VTotal, LONG* VStart, LONG* VEffective);

	ARTCAMSDK_API BOOL		ArtCam_SetColorMode			(HACAM hACam, LONG ColorMode);
	ARTCAMSDK_API LONG		ArtCam_GetColorMode			(HACAM hACam);

	ARTCAMSDK_API BOOL		ArtCam_SetCrossbar			(HACAM hACam, LONG Output, LONG Input);
	ARTCAMSDK_API BOOL		ArtCam_SetDeviceNumber		(HACAM hACam, LONG Number);
	ARTCAMSDK_API LONG		ArtCam_EnumDevice			(HACAM hACam, TCHAR szDeviceName[10][256]);
	ARTCAMSDK_API BOOL		ArtCam_GetDeviceName		(HACAM hACam, LONG index, LPSTR szDeviceName, LONG nSize);

	ARTCAMSDK_API BOOL		ArtCam_StartPreview			(HACAM hACam);
	ARTCAMSDK_API BOOL		ArtCam_StopPreview			(HACAM hACam);
	ARTCAMSDK_API BOOL		ArtCam_GetImage				(HACAM hACam, LPBYTE lpImage, LONG Size, BOOL TopDown);

	ARTCAMSDK_API LONG		ArtCam_Width				(HACAM hACam);
	ARTCAMSDK_API LONG		ArtCam_Height				(HACAM hACam);
	ARTCAMSDK_API LONG		ArtCam_Fps					(HACAM hACam);

	ARTCAMSDK_API BOOL		ArtCam_SetCameraDlg			(HACAM hACam, HWND hWnd);
	ARTCAMSDK_API BOOL		ArtCam_SetImageDlg			(HACAM hACam, HWND hWnd);
	ARTCAMSDK_API BOOL		ArtCam_SetAnalogDlg			(HACAM hACam, HWND hWnd);

	// 1230
	ARTCAMSDK_API BOOL		ArtCam_SetIOPort			(HACAM hACam, BYTE byteData, LONG longData, DWORD Reserve);
	ARTCAMSDK_API BOOL		ArtCam_GetIOPort			(HACAM hACam, LPBYTE byteData, LPLONG longData, DWORD Reserve);

	ARTCAMSDK_API BOOL		ArtCam_SetFilterValue		(HACAM hACam, LONG FilterType, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetFilterValue		(HACAM hACam, LONG FilterType, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetSubSample			(HACAM hACam, LONG SubSampleMode);
	ARTCAMSDK_API LONG		ArtCam_GetSubSample			(HACAM hACam);

	ARTCAMSDK_API BOOL		ArtCam_SetWaitTime			(HACAM hACam, LONG WaitTime);
	ARTCAMSDK_API LONG		ArtCam_GetWaitTime			(HACAM hACam);

	// 1240
	ARTCAMSDK_API BOOL		ArtCam_SetMirrorV			(HACAM hACam, BOOL Flg);
	ARTCAMSDK_API BOOL		ArtCam_GetMirrorV			(HACAM hACam);

	ARTCAMSDK_API BOOL		ArtCam_SetMirrorH			(HACAM hACam, BOOL Flg);
	ARTCAMSDK_API BOOL		ArtCam_GetMirrorH			(HACAM hACam);

	ARTCAMSDK_API BOOL		ArtCam_SetBrightness		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetBrightness		(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetContrast			(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetContrast			(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetHue				(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetHue				(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetSaturation		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetSaturation		(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetSharpness			(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetSharpness			(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetBayerGainRGB		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetBayerGainRGB		(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetBayerGainRed		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetBayerGainRed		(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetBayerGainGreen	(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetBayerGainGreen	(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetBayerGainBlue		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetBayerGainBlue		(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetBayerGainAuto		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetBayerGainAuto		(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetGamma				(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetGamma				(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetBayerMode			(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetBayerMode			(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetGlobalGain		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetGlobalGain		(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetColorGainRed		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetColorGainRed		(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetColorGainGreen1	(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetColorGainGreen1	(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetColorGainGreen2	(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetColorGainGreen2	(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetColorGainBlue		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetColorGainBlue		(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetExposureTime		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetExposureTime		(HACAM hACam, LPBOOL Error);

	// 1260
	ARTCAMSDK_API BOOL		ArtCam_SetHalfClock			(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetHalfClock			(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetAutoIris			(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetAutoIris			(HACAM hACam, LPBOOL Error);

	// 1275
	ARTCAMSDK_API BOOL		ArtCam_SetSamplingRate		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetSamplingRate		(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API LONG		ArtCam_GetVideoFormat		(HACAM hACam, LPBOOL Error);

	// 1276
	ARTCAMSDK_API BOOL		ArtCam_WriteSromID			(HACAM hACam, LONG Address, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_ReadSromID			(HACAM hACam, LONG Address, LPBOOL Error);


	// 1280
	ARTCAMSDK_API BOOL		ArtCam_GetCameraInfo		(HACAM hACam, LPCAMERAINFO pInfo);
	ARTCAMSDK_API LONG		ArtCam_GetSatus			(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_WriteRegister		(HACAM hACam, BYTE Address, DWORD Value);
	ARTCAMSDK_API DWORD		ArtCam_ReadRegister			(HACAM hACam, BYTE Address, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetGrayMode			(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetGrayMode			(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_SetGrayGainR			(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetGrayGainR			(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_SetGrayGainG1		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetGrayGainG1		(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_SetGrayGainG2		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetGrayGainG2		(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_SetGrayGainB			(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetGrayGainB			(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_SetGrayOffsetR		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetGrayOffsetR		(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_SetGrayOffsetG1		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetGrayOffsetG1		(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_SetGrayOffsetG2		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetGrayOffsetG2		(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_SetGrayOffsetB		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetGrayOffsetB		(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_SetCameraType		(HACAM hACam, LONG Flg);
	ARTCAMSDK_API LONG		ArtCam_GetCameraType		(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_Fpga_WriteRegister	(HACAM hACam, BYTE Address, DWORD Value);
	ARTCAMSDK_API DWORD		ArtCam_Fpga_ReadRegister	(HACAM hACam, BYTE Address, LPBOOL Error);

	ARTCAMSDK_API BOOL		ArtCam_Monitor_SetPreviewMode		(HACAM hACam, BOOL Preview);
	ARTCAMSDK_API BOOL		ArtCam_Monitor_GetPreviewMode		(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_Monitor_SetPreviewSize		(HACAM hACam, LONG Width, LONG Height);
	ARTCAMSDK_API BOOL		ArtCam_Monitor_GetPreviewSize		(HACAM hACam, LONG* Width, LONG* Height);
	ARTCAMSDK_API BOOL		ArtCam_Monitor_SetColorMode			(HACAM hACam, BOOL ColorMode);
	ARTCAMSDK_API BOOL		ArtCam_Monitor_GetColorMode			(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_Monitor_SetCameraClock		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_Monitor_GetCameraCLock		(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_Monitor_SetBayerGainAuto		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_Monitor_GetBayerGainAuto		(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_Monitor_SetBayerGainLock		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_Monitor_GetBayerGainLock		(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_Monitor_SetBayerGainRed		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_Monitor_GetBayerGainRed		(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_Monitor_SetBayerGainGreen	(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_Monitor_GetBayerGainGreen	(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_Monitor_SetBayerGainBlue		(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_Monitor_GetBayerGainBlue		(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API LONG		ArtCam_GetRealExposureTime			(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_SetRealExposureTime			(HACAM hACam, LONG Value);

	ARTCAMSDK_API BOOL		ArtCam_SaveMaskFile					(HACAM hACam, LPCTSTR szFileName); 
	ARTCAMSDK_API BOOL		ArtCam_LoadMaskFile					(HACAM hACam, LPCTSTR szFileName);
	ARTCAMSDK_API BOOL		ArtCam_UpdateMaskData				(HACAM hACam, LONG Flg);

	ARTCAMSDK_API BOOL		ArtCam_SetPeltier					(HACAM hACam, LONG Value);	
	ARTCAMSDK_API LONG		ArtCam_GetPeltier					(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API LONG		ArtCam_GetTemperature				(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_SetDotFilter					(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetDotFilter					(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_SetMaskFilter				(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		ArtCam_GetMaskFilter				(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		ArtCam_SetInternalCorrection		(HACAM hACam, BOOL Enable);
	ARTCAMSDK_API BOOL		ArtCam_GetInternalCorrection		(HACAM hACam, LPBOOL Error);

	ARTCAMSDK_API BOOL		LoadConfigFile						(HACAM hACam, LPCTSTR  szFileName);
	ARTCAMSDK_API BOOL		SetConfigFilter						(HACAM hACam, LONG Value);
	ARTCAMSDK_API LONG		GetConfigFilter						(HACAM hACam);

	ARTCAMSDK_API double	GetTemperatureEx					(HACAM hACam, LPBOOL Error);
	ARTCAMSDK_API BOOL		SetExposureTimeEx					(HACAM hACam, double Value);
	ARTCAMSDK_API double	GetExposureTimeEx					(HACAM hACam, LPBOOL Error);

#ifdef __cplusplus
}			// extern "C"{
#endif

#endif		// #ifndef _ARTCAM_SDK_





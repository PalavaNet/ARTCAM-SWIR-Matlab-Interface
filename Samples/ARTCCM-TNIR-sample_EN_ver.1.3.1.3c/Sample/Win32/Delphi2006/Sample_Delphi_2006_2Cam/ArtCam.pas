unit ArtCam;

interface

uses
  Windows;

type
  HACAM  = DWORD;
  LONG   = longint;
  LPBYTE = ^Byte;
  LPLONG = ^LONG;
  LPBOOL = ^BOOL;

  DeviceNameList = array[0..9, 0..255] of AnsiChar;


    DLL_MESSAGE = (
        WM_GRAPHNOTIFY = $8001,     // Not used in this version.
        WM_GRAPHPAINT,              // Sent to application when an image is updated.
        WM_ERROR                    // Sent to application when an error occurs
    );                                 

    ARTCAM_CAMERATYPE = (
		//USB2.0 Cameras
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
		ARTCAM_CAMERATYPE_625KY			= 27,	// ARTCAM-274KY
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

		ARTCAM_CAMERATYPE_300MI_MOUT	= 123,	// ARTCAM-300MI MOUT

		ARTCAM_CAMERATYPE_008TNIR		= 126,	// ARTCAM-008TNIR
		ARTCAM_CAMERATYPE_031TNIR		= 127,	// ARTCAM-031TNIR
		ARTCAM_CAMERATYPE_0016TNIR		= 128,	// ARTCAM-0016TNIR

		// SATA Cameras
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
		ARTCAM_CAMERATYPE_USB3_810KAI	= 311,	// ARTCAM-810KAI
		ARTCAM_CAMERATYPE_USB3_1000MI	= 312,	// ARTCAM-1000MI
		ARTCAM_CAMERATYPE_USB3_2000CMV	= 313,	// ARTCAM-2000CMV-USB3
		ARTCAM_CAMERATYPE_USB3_1600KAI	= 314,	// ARTCAM-1600KAI-USB3
		ARTCAM_CAMERATYPE_USB3_410KAI	= 315,	// ARTCAM-410KAI-USB3
		ARTCAM_CAMERATYPE_USB3_100KAI	= 316,	// ARTCAM-100KAI-USB3
		ARTCAM_CAMERATYPE_USB3_210KAI	= 317,	// ARTCAM-210KAI-USB3

		// WOM Cameras
		ARTCAM_CAMERATYPE_036MI_WOM		= 400,	// ARTCAM-036MI WOM
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
		ARTCAM_CAMERATYPE_445KY3_WOM	= 427,	// ARTCAM-445KY3 WOM
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

		ARTCAM_CAMERATYPE_130SWIR_USB3_T2	= 515,
		ARTCAM_CAMERATYPE_032TNIR_USB3_T2	= 516,
		ARTCAM_CAMERATYPE_009TNIR_USB3_T2	= 517,
		ARTCAM_CAMERATYPE_L256TNIR_USB3_T2	= 518,
		ARTCAM_CAMERATYPE_L512TNIR_USB3_T2	= 519,
		ARTCAM_CAMERATYPE_131TNIR_USB3_T2	= 520,

		ARTCAM_CAMERATYPE_250IMX_USB3_T2	= 522,
		ARTCAM_CAMERATYPE_252IMX_USB3_T2	= 523,
		ARTCAM_CAMERATYPE_264IMX_USB3_T2	= 524,
		ARTCAM_CAMERATYPE_265IMX_USB3_T2	= 525,
		ARTCAM_CAMERATYPE_L1024TNIR_USB3_T2	= 526,
		ARTCAM_CAMERATYPE_2020UV_USB3_T2	= 527,
		ARTCAM_CAMERATYPE_226IMX_USB3_T2	= 528

	);

	// SATA Camera type
    ARTCAM_CAMERATYPE_SATA1 = (
		ARTCAM_CAMERATYPE_SATA_LVDS = 0,    //
		ARTCAM_CAMERATYPE_SATA_300MI,       //
		ARTCAM_CAMERATYPE_SATA_500MI,       //
		ARTCAM_CAMERATYPE_SATA_MV413,       //
		ARTCAM_CAMERATYPE_SATA_800MI,       //
		ARTCAM_CAMERATYPE_SATA_036MI,       //
		ARTCAM_CAMERATYPE_SATA_150P,        //
		ARTCAM_CAMERATYPE_SATA_267KY,		//
		ARTCAM_CAMERATYPE_SATA_274KY,		//
		ARTCAM_CAMERATYPE_SATA_625KY,		//
		ARTCAM_CAMERATYPE_SATA_130MI,		//
		ARTCAM_CAMERATYPE_SATA_200MI		//
    );

	// Error Code
    ARTCAMSDK_ERROR = (
        ARTCAMSDK_NOERROR = 0,      // Normal
        ARTCAMSDK_NOT_INITIALIZE,   // Not initialized
        ARTCAMSDK_DISABLEDDEVICE,   // Access to unavailable device was attempted
        ARTCAMSDK_CREATETHREAD,     // Failure of thread creation for capturing
        ARTCAMSDK_CREATEWINDOW,     // Window creation failed
        ARTCAMSDK_OUTOFMEMORY,      // Not enough memory for image transfer/Failure for securing memory
        ARTCAMSDK_CAMERASET,        // Error for camera (device) settings
        ARTCAMSDK_CAMERASIZE,       // Error for camera (device) size settings
        ARTCAMSDK_CAPTURE,          // Capturing failed
        ARTCAMSDK_PARAM,            // Wrong argument
        ARTCAMSDK_DIRECTSHOW,       // Directshow initialization error
        ARTCAMSDK_UNSUPPORTED,      // Not supported
        ARTCAMSDK_UNKNOWN,          // Unknow error
        ARTCAMSDK_CAPTURELOST,      // Device lost
        ARTCAMSDK_FILENOTFOUND,     // File not found
        ARTCAMSDK_FPGASET,          // FPGA settings error
		ARTCAMSDK_TRANSIMAGEFAILED	// Failure of image transferring
    );

	// Information for transferring
    GP_INFO = record
      lSize:      LONG;             // Size of this struct
      lWidth:     LONG;             // Width of image
      lHeight:    LONG;             // Height of image
      lBpp:       LONG;             // Byte per pixcel
      lFps:       LONG;             // Frame rate (x10)
      pImage:     LPBYTE;           // The pointer to the captured image
    end;

	// Camera information
    CAMERAINFO = record
      lSize:            LONG;       // Size of this struct
      lWidth:           LONG;       // H-Effective
      lHeight:          LONG;       // V-Effective
      lGlobalGainMin:   LONG;       // Min value of Global Gain (Return -1 if disabled)
      lGlobalGainMax:   LONG;       // Max value of Global Gain(Return -1 if disabled)
      lColorGainMin:    LONG;       // Min value of Color Gain(Return -1 if disabled)
      lColorGainMax:    LONG;       // Max value of Colof Gain(Return -1 if disabled)
      lExposureMin:     LONG;       // Min value of Shutter Width(Return -1 if disabled)
      lExposureMax:     LONG;       // Max value of Shutter Width(Return -1 if disabled)
    end;

    LPCAMERAINFO = ^CAMERAINFO;

	// Type of image filter
    ARTCAM_FILTERTYPE = (
        ARTCAM_FILTERTYPE_RESERVE = 0,          // Reserved
        ARTCAM_FILTERTYPE_BRIGHTNESS,           // Brightness
        ARTCAM_FILTERTYPE_CONTRAST,             // Contrast
        ARTCAM_FILTERTYPE_HUE,                  // Hue
        ARTCAM_FILTERTYPE_SATURATION,           // Saturation
        ARTCAM_FILTERTYPE_SHARPNESS,            // Sharpness
        ARTCAM_FILTERTYPE_BAYER_GAIN_RGB,       // Bayer coversion color gain
        ARTCAM_FILTERTYPE_BAYER_GAIN_R,         // Color gain (red only) for bayer conversion
        ARTCAM_FILTERTYPE_BAYER_GAIN_G,         // Color gain (green only) for bayer conversion
        ARTCAM_FILTERTYPE_BAYER_GAIN_B,         // Color gain (Blue only) for bayer conversion
        ARTCAM_FILTERTYPE_BAYER_GAIN_AUTO,      // Auto white balance
        ARTCAM_FILTERTYPE_GAMMA,                // Gumma
        ARTCAM_FILTERTYPE_BAYERMODE,            // Bayer conversion mode
        ARTCAM_FILTERTYPE_GLOBAL_GAIN,          // Global gain for camera
        ARTCAM_FILTERTYPE_COLOR_GAIN_R,         // Color gain (red) for camera
        ARTCAM_FILTERTYPE_COLOR_GAIN_G1,        // Color gain (green1) for camera
        ARTCAM_FILTERTYPE_COLOR_GAIN_G2,        // Color gain (green2) for camera
        ARTCAM_FILTERTYPE_COLOR_GAIN_B,         // Color gain (blue) for camera
        ARTCAM_FILTERTYPE_EXPOSURETIME,         // Exposure time (shutter speed)
        ARTCAM_FILTERTYPE_GRAY_MODE,            // Convert mode for gray scale
        ARTCAM_FILTERTYPE_GRAY_GAIN_R,          // Color gain (red) for gray scale
        ARTCAM_FILTERTYPE_GRAY_GAIN_G1,         // Color gain (green1) for gray scale
        ARTCAM_FILTERTYPE_GRAY_GAIN_G2,         // Color gain (green2) for gray scale
        ARTCAM_FILTERTYPE_GRAY_GAIN_B,          // Color gain (blue) for gray scale
        ARTCAM_FILTERTYPE_GRAY_OFFSET_R,        // Color offset (red) for gray scale
        ARTCAM_FILTERTYPE_GRAY_OFFSET_G1,       // Color offset (green1) for gray scale
        ARTCAM_FILTERTYPE_GRAY_OFFSET_G2,       // Color offset (green2) for gray scale
        ARTCAM_FILTERTYPE_GRAY_OFFSET_B,         //Color offset (blue) for gray scale

		// For TNIR Cameras
		ARTCAM_FILTERTYPE_PELTIER = 100,		// Peltier control
		ARTCAM_FILTERTYPE_TEMPERATURE,			// sensor temperature (only received),
		ARTCAM_FILTERTYPE_DOTFILTER,			// pixel correction filter
		ARTCAM_FILTERTYPE_MASKFILTER,			// mask correction filter
		ARTCAM_FILTERTYPE_GAINMODE				// High Gain, Low Gain
    );

	// Pixel skipping transfer mode
    SUBSAMPLE = (
        SUBSAMPLE_1 = 0,    // Full size
        SUBSAMPLE_2,        // 1/2
        SUBSAMPLE_4,        // 1/4
        SUBSAMPLE_8,        // 1/8
        BINNING_2   = 17,
		BINNING_4	= 18
    );

	// Auto iris mode
    AI_TYPE = (
        AI_NONE = 0,        // Invalid
        AI_EXPOSURE,        // Exposure time
        AI_GAIN,            // Gain
        AI_BOTH				// Exposure time + Gain
    );

	// Convert mode for gray scale
    GRAY_TYPE = (
        GRAY_NONE = 0,      // Disable
        GRAY_BAYERCONVERT,  // Calculate from Bayer array
        GRAY_GRAYSCALE      // Get LUMA data from Color-converted image
    );

	// Video format
    VIDEOFORMAT = (
        VIDEOFORMAT_NTSC = 0,   // NTSC
        VIDEOFORMAT_PAL,        // PAL
        VIDEOFORMAT_PALM,       // PALM
        VIDEOFORMAT_SECAM       // SECAM
    );

	// Sampling rate
    SAMPLING_RATE = (
        WIDE_HISPEED = 0,   // 
        WIDE_LOWSPEED,      // 
        NORMAL_HISPEED,     // 
        NORMAL_LOWSPEED     //
    );


	// Format for image saving
    FILETYPE = (
        FILETYPE_BITMAP = 0,    // Bitmap saving (large size).
        FILETYPE_RAW,           // Only data is saved (large size)
        FILETYPE_JPEG_HIGH,     // Save in high-quality JPEG format (medium size). Characters and lines are distorted.
        FILETYPE_JPEG_NOMAL,    // Save in standard JPEG format (small size). Small patterns are distorted.
        FILETYPE_JPEG_LOW,      // Save in low-quality JPEG (small size). Block noise are seen.
        FILETYPE_PNG,           // Save as PNG. 16 bits image can be saved correctly. Size=Medium
        FILETYPE_TIFF           // Save as TIFF. 16 bits image can be saved correctly. Size=Large
    );

	// For TNIR Cameras
	MASKTYPE = (
		MASKTYPE_LOW = 0,
		MASKTYPE_HIGH
    );


  AC_GetDllVersion      = function : DWORD; cdecl;
  AC_GetLastError       = function (hACam: HACAM): LONG; cdecl;

  AC_Initialize         = function (hWnd: HWND): HACAM; cdecl;
  AC_Release            = function (hACam: HACAM): BOOL; cdecl;

  AC_Preview            = function (hACam: HACAM): BOOL; cdecl;
  AC_Record             = function (hACam: HACAM; lpAviName: LPCTSTR; RecTime: UINT; fShow: BOOL): BOOL; cdecl;
  AC_CallBackPreview    = function (hACam: HACAM; hWnd: HWND; lpImage: LPBYTE; Size: LONG; TopDown: BOOL): BOOL; cdecl;
  AC_Close              = function (hACam: HACAM): BOOL; cdecl;

  // 1230
  AC_SnapShot           = function (hACam: HACAM; lpImage: LPBYTE; Size: LONG; TopDown: BOOL): BOOL; cdecl;

  // 1250
  AC_Capture            = function (hACam: HACAM): BOOL; cdecl;

  // 1260
  AC_Trigger            = function (hACam: HACAM; hWnd: HWND; lpImage: LPBYTE; Size: LONG; TopDown: BOOL): BOOL; cdecl;
  AC_SaveImage          = function (hACam: HACAM; lpSaveName: LPCTSTR; FileType: LONG): BOOL; cdecl;


  AC_SetPreviewWindow   = function (hACam: HACAM; hWnd: HWND; Left: LONG; Top: LONG; Right: LONG; Bottom: LONG): BOOL; cdecl;
  AC_SetCaptureWindow   = function (hACam: HACAM; Width: LONG; Height: LONG; Fps: LONG): BOOL; cdecl;
  AC_SetCaptureWindowEx = function (hACam: HACAM; HTotal: LONG; HStart: LONG; HEffective: LONG; VTotal: LONG; VStart: LONG; VEffective: LONG): BOOL; cdecl;
  AC_GetCaptureWindowEx = function (hACam: HACAM; HTotal: LPLONG; HStart: LPLONG; HEffective: LPLONG; VTotal: LPLONG; VStart: LPLONG; VEffective: LPLONG): BOOL; cdecl;

  AC_SetColorMode       = function (hACam: HACAM; ColorMode: LONG): BOOL; cdecl;
  AC_GetColorMode       = function (hACam: HACAM): LONG; cdecl;

  AC_SetCrossbar        = function (hACam: HACAM; Output: LONG; Input: LONG): BOOL; cdecl;
  AC_SetDeviceNumber    = function (hACam: HACAM; Number: LONG): BOOL; cdecl;
  AC_EnumDevice         = function (hACam: HACAM; szDeviceName: DeviceNameList): LONG; cdecl;
  AC_GetDeviceName      = function (hACam: HACAM; index: LONG; szDeviceName: LPSTR; nSize: LONG): BOOL; cdecl;

  AC_StartPreview       = function (hACam: HACAM): BOOL; cdecl;
  AC_StopPreview        = function (hACam: HACAM): BOOL; cdecl;
  AC_GetImage           = function (hACam: HACAM; lpImage: LPBYTE; Size: LONG; TopDown: BOOL): BOOL; cdecl;

  AC_Width              = function (hACam: HACAM): LONG; cdecl;
  AC_Height             = function (hACam: HACAM): LONG; cdecl;
  AC_Fps                = function (hACam: HACAM): LONG; cdecl;

  AC_SetCameraDlg       = function (hACam: HACAM; hWnd: HWND): BOOL; cdecl;
  AC_SetImageDlg        = function (hACam: HACAM; hWnd: HWND): BOOL; cdecl;
  AC_SetAnalogDlg       = function (hACam: HACAM; hWnd: HWND): BOOL; cdecl;

  // 1230
  AC_SetIOPort          = function (hACam: HACAM; byteData: BYTE; longData: LONG; Reserve: DWORD): BOOL; cdecl;
  AC_GetIOPort          = function (hACam: HACAM; byteData: LPBYTE; longData: LPLONG; Reserve: DWORD): BOOL; cdecl;
  AC_SetFilterValue     = function (hACam: HACAM; FilterType: LONG; Value: LONG): BOOL; cdecl;
  AC_GetFilterValue     = function (hACam: HACAM; FilterType: LONG; Error: LPBOOL): LONG; cdecl;
  AC_SetSubSample       = function (hACam: HACAM; SubSampleMode: LONG): BOOL; cdecl;
  AC_GetSubSample       = function (hACam: HACAM): LONG; cdecl;
  AC_SetWaitTime        = function (hACam: HACAM; WaitTime: LONG): BOOL; cdecl;
  AC_GetWaitTime        = function (hACam: HACAM): LONG; cdecl;

  // 1240
  AC_SetMirrorV         = function (hACam: HACAM; Flg: BOOL): BOOL; cdecl;
  AC_GetMirrorV         = function (hACam: HACAM): BOOL; cdecl;
  AC_SetMirrorH         = function (hACam: HACAM; Flg: BOOL): BOOL; cdecl;
  AC_GetMirrorH         = function (hACam: HACAM): BOOL; cdecl;

  AC_SetBrightness      = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetBrightness      = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetContrast        = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetContrast        = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetHue             = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetHue             = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetSaturation      = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetSaturation      = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetSharpness       = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetSharpness       = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetBayerGainRGB    = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetBayerGainRGB    = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetBayerGainRed    = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetBayerGainRed    = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetBayerGainGreen  = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetBayerGainGreen  = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetBayerGainBlue   = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetBayerGainBlue   = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetBayerGainAuto   = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetBayerGainAuto   = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetGamma           = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetGamma           = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetBayerMode       = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetBayerMode       = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetGlobalGain      = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetGlobalGain      = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetColorGainRed    = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetColorGainRed    = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetColorGainGreen1 = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetColorGainGreen1 = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetColorGainGreen2 = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetColorGainGreen2 = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetColorGainBlue   = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetColorGainBlue   = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetExposureTime    = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetExposureTime    = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;

  // 1260
  AC_SetHalfClock       = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetHalfClock       = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetAutoIris        = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetAutoIris        = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;

  // 1275
  AC_SetSamplingRate    = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetSamplingRate    = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_GetVideoFormat     = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;

  // 1276
  AC_WriteSromID        = function (hACam: HACAM; Address: LONG; Value: LONG): BOOL; cdecl;
  AC_ReadSromID         = function (hACam: HACAM; Address: LONG; Error: LPBOOL): LONG; cdecl;

  // 1280
  AC_GetCameraInfo      = function (hACam: HACAM; pInfo: LPCAMERAINFO): BOOL; cdecl;
  AC_GetStatus          = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;

  AC_WriteRegister      = function (hACam: HACAM; Address: BYTE; Value: DWORD): BOOL; cdecl;
  AC_ReadRegister       = function (hACam: HACAM; Address: BYTE; Error: LPBOOL): DWORD; cdecl;
  AC_WriteRegisterEx    = function (hACam: HACAM; Address: DWORD; Value: DWORD): BOOL; cdecl;
  AC_ReadRegisterEx     = function (hACam: HACAM; Address: DWORD; Error: LPBOOL): DWORD; cdecl;
  AC_SetCrcCheckMode    = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetCrcCheckMode    = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetLChannelValue   = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetLChannelValue   = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetChannelProfileMode =  function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetChannelProfile  = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;

  AC_SetGrayMode        = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetGrayMode        = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetGrayGainR       = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetGrayGainR       = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetGrayGainG1      = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetGrayGainG1      = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetGrayGainG2      = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetGrayGainG2      = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetGrayGainB       = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetGrayGainB       = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetGrayOffsetR     = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetGrayOffsetR     = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetGrayOffsetG1    = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetGrayOffsetG1    = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetGrayOffsetG2    = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetGrayOffsetG2    = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetGrayOffsetB     = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_GetGrayOffsetB     = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;

  // 1300
  AC_GetRealExposureTime= function (hACam: HACAM; Error: LPBOOL):LONG; cdecl;
  AC_SetRealExposureTime= function (hACam: HACAM; Value: LONG):BOOL; cdecl;

  // 1311
  AC_LoadConfigFile		= function (hACam: HACAM; szFileName: LPCTSTR):BOOL; cdecl;
  AC_SetConfigFilter	= function (hACam: HACAM; Value: LONG):BOOL; cdecl;
  AC_GetConfigFilter	= function (hACam: HACAM):LONG; cdecl;

  // SATA
  AC_SetCameraType      = function (hACam: HACAM; Flg: LONG): BOOL; cdecl;
  AC_GetCameraType      = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetSyncV           = function (hACam: HACAM; Flg: LONG): BOOL; cdecl;
  AC_GetSyncV           = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_SetSyncH           = function (hACam: HACAM; Flg: LONG): BOOL; cdecl;
  AC_GetSyncH           = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;

  // MOUT
  AC_Fpga_WriteRegister = function (hACam: HACAM; Address: BYTE; Value: DWORD): BOOL; cdecl;
  AC_Fpga_ReadRegister  = function (hACam: HACAM; Address: BYTE; Error: LPBOOL): DWORD; cdecl;

  AC_Monitor_SetPreviewMode     = function (hACam: HACAM; Preview: BOOL): BOOL; cdecl;
  AC_Monitor_GetPreviewMode     = function (hACam: HACAM; Error: LPBOOL): BOOL; cdecl;
  AC_Monitor_SetPreviewSize     = function (hACam: HACAM; Width: LONG; Height: LONG): BOOL; cdecl;
  AC_Monitor_GetPreviewSize     = function (hACam: HACAM; LPWidth: LPLONG; LPHeight: LPLONG): BOOL; cdecl;
  AC_Monitor_SetColorMode       = function (hACam: HACAM; ColorMode: BOOL): BOOL; cdecl;
  AC_Monitor_GetColorMode       = function (hACam: HACAM; Error: LPBOOL): BOOL; cdecl;
  AC_Monitor_SetCameraClock     = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_Monitor_GetCameraClock     = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_Monitor_SetBayerGainAuto   = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_Monitor_GetBayerGainAuto   = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_Monitor_SetBayerGainLock	= function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_Monitor_GetBayerGainLock   = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_Monitor_SetBayerGainRed    = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_Monitor_GetBayerGainRed    = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_Monitor_SetBayerGainGreen  = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_Monitor_GetBayerGainGreen  = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_Monitor_SetBayerGainBlue   = function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_Monitor_GetBayerGainBlue   = function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;

  AC_Monitor_SaveCurrentSettings  = function 	(hACam: HACAM): BOOL; cdecl;
  AC_Monitor_InitRegisterSettings = function 	(hACam: HACAM; Flg: LONG): BOOL; cdecl;

  AC_Monitor_SetCrossCursorMode =   function (hACam: HACAM; CursorNum: LONG; Value: LONG): BOOL; cdecl;
  AC_Monitor_GetCrossCursorMode =   function (hACam: HACAM; CursorNum: LONG; Error: LPBOOL): LONG; cdecl;
  AC_Monitor_SetCrossCursorColorR = function (hACam: HACAM; CursorNum: LONG; Value: LONG): BOOL; cdecl;
  AC_Monitor_GetCrossCursorColorR = function (hACam: HACAM; CursorNum: LONG; Error: LPBOOL): LONG; cdecl;
  AC_Monitor_SetCrossCursorColorG = function (hACam: HACAM; CursorNum: LONG; Value: LONG): BOOL; cdecl;
  AC_Monitor_GetCrossCursorColorG = function (hACam: HACAM; CursorNum: LONG; Error: LPBOOL): LONG; cdecl;
  AC_Monitor_SetCrossCursorColorB = function (hACam: HACAM; CursorNum: LONG; Value: LONG): BOOL; cdecl;
  AC_Monitor_GetCrossCursorColorB = function (hACam: HACAM; CursorNum: LONG; Error: LPBOOL): LONG; cdecl;
  AC_Monitor_SetCrossCursorColorRGB = function (hACam: HACAM; CursorNum: LONG; Value: LONG): BOOL; cdecl;
  AC_Monitor_GetCrossCursorColorRGB = function (hACam: HACAM; CursorNum: LONG; Error: LPBOOL): LONG; cdecl;
  AC_Monitor_SetCrossCursorPos  =   function (hACam: HACAM; CursorNum: LONG; ValueX: LONG; ValueY: LONG): BOOL; cdecl;
  AC_Monitor_GetCrossCursorPos  =   function (hACam: HACAM; CursorNum: LONG; ValueX: LPLONG; ValueY: LPLONG): BOOL; cdecl;
  AC_Monitor_SetCrossCursorSize =   function (hACam: HACAM; CursorNum: LONG; ValueX: LONG; ValueY: LONG): BOOL; cdecl;
  AC_Monitor_GetCrossCursorSize =   function (hACam: HACAM; CursorNum: LONG; ValueX: LPLONG; ValueY: LPLONG): BOOL; cdecl;

  AC_Monitor_SetAutoIrisMode  =     function (hACam: HACAM; Value: LONG): BOOL; cdecl;
  AC_Monitor_GetAutoIrisMode  =     function (hACam: HACAM; Error: LPBOOL): LONG; cdecl;
  AC_Monitor_SetAutoIrisRange =     function (hACam: HACAM; Min: LONG; Max: LONG): BOOL; cdecl;
  AC_Monitor_GetAutoIrisRange =     function (hACam: HACAM; Min: LPLONG; Max: LPLONG): BOOL; cdecl;
  AC_Monitor_LoadFirmware     =     function (hACam: HACAM; szFileName: LPCTSTR): BOOL; cdecl;

  // TNIR
  AC_SaveMaskFile	= function (hACam: HACAM; szFileName: LPCTSTR):	BOOL; cdecl;
  AC_LoadMaskFile	= function (hACam: HACAM; szFileName: LPCTSTR):	BOOL; cdecl;
  AC_UpdateMaskData	= function (hACam: HACAM; Flg: MASKTYPE):		BOOL; cdecl;
  AC_SetPeltier		= function (hACam: HACAM; Value: LONG):			BOOL; cdecl;
  AC_GetPeltier		= function (hACam: HACAM; Error: LPBOOL):		LONG; cdecl;
  AC_GetTemperature	= function (hACam: HACAM; Error: LPBOOL):		LONG; cdecl;
  AC_SetDotFilter	= function (hACam: HACAM; Value: LONG):			BOOL; cdecl;
  AC_GetDotFilter	= function (hACam: HACAM; Error: LPBOOL):		LONG; cdecl;
  AC_SetMaskFilter	= function (hACam: HACAM; Value: LONG):			BOOL; cdecl;
  AC_GetMaskFilter	= function (hACam: HACAM; Error: LPBOOL):		LONG; cdecl;

  AC_SetInternalCorrection	= function (hACam: HACAM; Enable: LONG):		BOOL; cdecl;
  AC_GetInternalCorrection	= function (hACam: HACAM; Error: LPBOOL):		BOOL; cdecl;


  TArtCam = class

  protected
    FDLLHandle: THandle;
    SdkHandle:  HACAM;

    F_GetDllVersion:        AC_GetDllVersion;
    F_GetLastError:         AC_GetLastError;

    F_Initialize:           AC_Initialize;
    F_Release:              AC_Release;

    F_Preview:              AC_Preview;
    F_Record:               AC_Record;
    F_CallBackPreview:      AC_CallBackPreview;
    F_Close:                AC_Close;

    //1230
    F_SnapShot:             AC_SnapShot;

    //1250
    F_Capture:              AC_Capture;

    //1260
    F_Trigger:              AC_Trigger;
    F_SaveImage:            AC_SaveImage;


    F_SetPreviewWindow:     AC_SetPreviewWindow;
    F_SetCaptureWindow:     AC_SetCaptureWindow;
    F_SetCaptureWindowEx:   AC_SetCaptureWindowEx;
    F_GetCaptureWindowEx:   AC_GetCaptureWindowEx;

    F_SetColorMode:         AC_SetColorMode;
    F_GetColorMode:         AC_GetColorMode;

    F_SetCrossbar:          AC_SetCrossbar;
    F_SetDeviceNumber:      AC_SetDeviceNumber;
    F_EnumDevice:           AC_EnumDevice;
    F_GetDeviceName:        AC_GetDeviceName;

    F_StartPreview:         AC_StartPreview;
    F_StopPreview:          AC_StopPreview;
    F_GetImage:             AC_GetImage;

    F_Width:                AC_Width;
    F_Height:               AC_Height;
    F_Fps:                  AC_Fps;

    F_SetCameraDlg:         AC_SetCameraDlg;
    F_SetImageDlg:          AC_SetImageDlg;
    F_SetAnalogDlg:         AC_SetAnalogDlg;

    //1230
    F_SetIOPort:            AC_SetIOPort;
    F_GetIOPort:            AC_GetIOPort;
    F_SetFilterValue:       AC_SetFilterValue;
    F_GetFilterValue:       AC_GetFilterValue;
    F_SetSubSample:         AC_SetSubSample;
    F_GetSubSample:         AC_GetSubSample;
    F_SetWaitTime:          AC_SetWaitTime;
    F_GetWaitTime:          AC_GetWaitTime;

    //1240
    F_SetMirrorV:           AC_SetMirrorV;
    F_GetMirrorV:           AC_GetMirrorV;
    F_SetMirrorH:           AC_SetMirrorH;
    F_GetMirrorH:           AC_GetMirrorH;
    F_SetBrightness:        AC_SetBrightness;
    F_GetBrightness:        AC_GetBrightness;

    F_SetContrast:          AC_SetContrast;
    F_GetContrast:          AC_GetContrast;
    F_SetHue:               AC_SetHue;
    F_GetHue:               AC_GetHue;
    F_SetSaturation:        AC_SetSaturation;
    F_GetSaturation:        AC_GetSaturation;
    F_SetSharpness:         AC_SetSharpness;
    F_GetSharpness:         AC_GetSharpness;
    F_SetBayerGainRGB:      AC_SetBayerGainRGB;
    F_GetBayerGainRGB:      AC_GetBayerGainRGB;
    F_SetBayerGainRed:      AC_SetBayerGainRed;
    F_GetBayerGainRed:      AC_GetBayerGainRed;
    F_SetBayerGainGreen:    AC_SetBayerGainGreen;
    F_GetBayerGainGreen:    AC_GetBayerGainGreen;
    F_SetBayerGainBlue:     AC_SetBayerGainBlue;
    F_GetBayerGainBlue:     AC_GetBayerGainBlue;
    F_SetBayerGainAuto:     AC_SetBayerGainAuto;
    F_GetBayerGainAuto:     AC_GetBayerGainAuto;
    F_SetGamma:             AC_SetGamma;
    F_GetGamma:             AC_GetGamma;
    F_SetBayerMode:         AC_SetBayerMode;
    F_GetBayerMode:         AC_GetBayerMode;
    F_SetGlobalGain:        AC_SetGlobalGain;
    F_GetGlobalGain:        AC_GetGlobalGain;
    F_SetColorGainRed:      AC_SetColorGainRed;
    F_GetColorGainRed:      AC_GetColorGainRed;
    F_SetColorGainGreen1:   AC_SetColorGainGreen1;
    F_GetColorGainGreen1:   AC_GetColorGainGreen1;
    F_SetColorGainGreen2:   AC_SetColorGainGreen2;
    F_GetColorGainGreen2:   AC_GetColorGainGreen2;
    F_SetColorGainBlue:     AC_SetColorGainBlue;
    F_GetColorGainBlue:     AC_GetColorGainBlue;
    F_SetExposureTime:      AC_SetExposureTime;
    F_GetExposureTime:      AC_GetExposureTime;

    //1260
    F_SetHalfClock:         AC_SetHalfClock;
    F_GetHalfClock:         AC_GetHalfClock;
    F_SetAutoIris:          AC_SetAutoIris;
    F_GetAutoIris:          AC_GetAutoIris;

    //1275
    F_SetSamplingRate:      AC_SetSamplingRate;
    F_GetSamplingRate:      AC_GetSamplingRate;
    F_GetVideoFormat:       AC_GetVideoFormat;

    // 1276
    F_WriteSromID:          AC_WriteSromID;
    F_ReadSromID:           AC_ReadSromID;

    // 1280
    F_GetCameraInfo:        AC_GetCameraInfo;
    F_GetStatus:            AC_GetStatus;

    F_WriteRegister:        AC_WriteRegister;
    F_ReadRegister:         AC_ReadRegister;
    
    F_WriteRegisterEx:      AC_WriteRegisterEx;
    F_ReadRegisterEx:       AC_ReadRegisterEx;
    
   	F_SetCrcCheckMode:		AC_SetCrcCheckMode;
	F_GetCrcCheckMode:		AC_GetCrcCheckMode;

   	F_SetLChannelValue:		AC_SetLChannelValue;
	F_GetLChannelValue:		AC_GetLChannelValue;
	F_SetChannelProfileMode:	AC_SetChannelProfileMode;
	F_GetChannelProfile:	AC_GetChannelProfile;
	
    F_SetGrayMode:          AC_SetGrayMode;
    F_GetGrayMode:          AC_GetGrayMode;
    F_SetGrayGainR:         AC_SetGrayGainR;
    F_GetGrayGainR:         AC_GetGrayGainR;
    F_SetGrayGainG1:        AC_SetGrayGainG1;
    F_GetGrayGainG1:        AC_GetGrayGainG1;
    F_SetGrayGainG2:        AC_SetGrayGainG2;
    F_GetGrayGainG2:        AC_GetGrayGainG2;
    F_SetGrayGainB:         AC_SetGrayGainB;
    F_GetGrayGainB:         AC_GetGrayGainB;
    F_SetGrayOffsetR:       AC_SetGrayOffsetR;
    F_GetGrayOffsetR:       AC_GetGrayOffsetR;
    F_SetGrayOffsetG1:      AC_SetGrayOffsetG1;
    F_GetGrayOffsetG1:      AC_GetGrayOffsetG1;
    F_SetGrayOffsetG2:      AC_SetGrayOffsetG2;
    F_GetGrayOffsetG2:      AC_GetGrayOffsetG2;
    F_SetGrayOffsetB:       AC_SetGrayOffsetB;
    F_GetGrayOffsetB:       AC_GetGrayOffsetB;

	// 1300
    F_GetRealExposureTime:     AC_GetRealExposureTime;
    F_SetRealExposureTime:     AC_SetRealExposureTime;

	// 1311
    F_LoadConfigFile:		AC_LoadConfigFile;
    F_SetConfigFilter:		AC_SetConfigFilter;
    F_GetConfigFilter:		AC_GetConfigFilter;

    // SATA
    F_SetCameraType:        AC_SetCameraType;
    F_GetCameraType:        AC_GetCameraType;
    
	F_SetSyncV:				AC_SetSyncV;
	F_GetSyncV:				AC_GetSyncV;
	F_SetSyncH:				AC_SetSyncH;
	F_GetSyncH:				AC_GetSyncH;

    // MOUT
    F_Fpga_WriteRegister:   AC_Fpga_WriteRegister;
    F_Fpga_ReadRegister:    AC_Fpga_ReadRegister;

    F_Monitor_SetPreviewMode:       AC_Monitor_SetPreviewMode;
    F_Monitor_GetPreviewMode:       AC_Monitor_GetPreviewMode;
    F_Monitor_SetPreviewSize:       AC_Monitor_SetPreviewSize;
    F_Monitor_GetPreviewSize:       AC_Monitor_GetPreviewSize;
    F_Monitor_SetColorMode:         AC_Monitor_SetColorMode;
    F_Monitor_GetColorMode:         AC_Monitor_GetColorMode;
    F_Monitor_SetCameraClock:       AC_Monitor_SetCameraClock;
    F_Monitor_GetCameraClock:       AC_Monitor_GetCameraClock;
    F_Monitor_SetBayerGainAuto:     AC_Monitor_SetBayerGainAuto;
    F_Monitor_GetBayerGainAuto:     AC_Monitor_GetBayerGainAuto;
    F_Monitor_SetBayerGainLock:		AC_Monitor_SetBayerGainLock;
    F_Monitor_GetBayerGainLock:		AC_Monitor_GetBayerGainLock;
    F_Monitor_SetBayerGainRed:      AC_Monitor_SetBayerGainRed;
    F_Monitor_GetBayerGainRed:      AC_Monitor_GetBayerGainRed;
    F_Monitor_SetBayerGainGreen:    AC_Monitor_SetBayerGainGreen;
    F_Monitor_GetBayerGainGreen:    AC_Monitor_GetBayerGainGreen;
    F_Monitor_SetBayerGainBlue:     AC_Monitor_SetBayerGainBlue;
    F_Monitor_GetBayerGainBlue:     AC_Monitor_GetBayerGainBlue;

    F_Monitor_SaveCurrentSettings:  AC_Monitor_SaveCurrentSettings;
    F_Monitor_InitRegisterSettings: AC_Monitor_InitRegisterSettings;
    
    F_Monitor_SetCrossCursorMode:   AC_Monitor_SetCrossCursorMode;
    F_Monitor_GetCrossCursorMode:   AC_Monitor_GetCrossCursorMode;
    F_Monitor_SetCrossCursorColorR:	AC_Monitor_SetCrossCursorColorR;
    F_Monitor_GetCrossCursorColorR:	AC_Monitor_GetCrossCursorColorR;
    F_Monitor_SetCrossCursorColorG:	AC_Monitor_SetCrossCursorColorG;
    F_Monitor_GetCrossCursorColorG:	AC_Monitor_GetCrossCursorColorG;
    F_Monitor_SetCrossCursorColorB:	AC_Monitor_SetCrossCursorColorB;
    F_Monitor_GetCrossCursorColorB:	AC_Monitor_GetCrossCursorColorB;
    F_Monitor_SetCrossCursorColorRGB:	AC_Monitor_SetCrossCursorColorRGB;
    F_Monitor_GetCrossCursorColorRGB:	AC_Monitor_GetCrossCursorColorRGB;
    F_Monitor_SetCrossCursorPos:	AC_Monitor_SetCrossCursorPos;
    F_Monitor_GetCrossCursorPos:	AC_Monitor_GetCrossCursorPos;
    F_Monitor_SetCrossCursorSize:	AC_Monitor_SetCrossCursorSize;
    F_Monitor_GetCrossCursorSize:	AC_Monitor_GetCrossCursorSize;

    F_Monitor_SetAutoIrisMode:		AC_Monitor_SetAutoIrisMode;
    F_Monitor_GetAutoIrisMode:		AC_Monitor_GetAutoIrisMode;
    F_Monitor_SetAutoIrisRange:		AC_Monitor_SetAutoIrisRange;
    F_Monitor_GetAutoIrisRange:		AC_Monitor_GetAutoIrisRange;
    F_Monitor_LoadFirmware:     	AC_Monitor_LoadFirmware;

    // TNIR
	F_SaveMaskFile: 					AC_SaveMaskFile;
	F_LoadMaskFile: 					AC_LoadMaskFile;
	F_UpdateMaskData: 				AC_UpdateMaskData;
	F_SetPeltier: 					AC_SetPeltier;
	F_GetPeltier: 					AC_GetPeltier;
	F_GetTemperature: 				AC_GetTemperature;
	F_SetDotFilter: 					AC_SetDotFilter;
	F_GetDotFilter: 					AC_GetDotFilter;
	F_SetMaskFilter: 				AC_SetMaskFilter;
	F_GetMaskFilter: 				AC_GetMaskFilter;
	F_SetInternalCorrection:		AC_SetInternalCorrection;
	F_GetInternalCorrection:		AC_GetInternalCorrection;

    procedure NullSet;

  public
    constructor Create;
    destructor Destroy; override;

    function IsInit:            Boolean;

    function LoadLibrary        (lpLibFileName: PChar): Boolean;
    procedure FreeLibrary;

    function GetDllVersion:     DWORD;
    function GetLastError:      LONG;

    function Initialize         (hWnd: HWND): Boolean;
    function Release:           BOOL;

    function Preview:           BOOL;
    function RecordA            (lpAviName: LPCTSTR; RecTime: UINT; fShow: BOOL): BOOL;
    function CallBackPreview    (hWnd: HWND; lpImage: LPBYTE; Size: LONG; TopDown: BOOL): BOOL;
    function Close:             BOOL;

    // 1230
    function SnapShot           (lpImage: LPBYTE; Size: LONG; TopDown: BOOL): BOOL;

    // 1250
    function Capture:           BOOL;

    // 1260
    function Trigger            (hWnd: HWND; lpImage: LPBYTE; Size: LONG; TopDown: BOOL): BOOL;
    function SaveImage          (lpSaveName: LPCTSTR; FileType: FILETYPE): BOOL;


    function SetPreviewWindow   (hWnd: HWND; Left: LONG; Top: LONG; Right: LONG; Bottom: LONG): BOOL;
    function SetCaptureWindow   (Width: LONG; Height: LONG; Fps: LONG): BOOL;
    function SetCaptureWindowEx (HTotal: LONG; HStart: LONG; HEffective: LONG; VTotal: LONG; VStart: LONG; VEffective: LONG): BOOL;
    function GetCaptureWindowEx (HTotal: LPLONG; HStart: LPLONG; HEffective: LPLONG; VTotal: LPLONG; VStart: LPLONG; VEffective: LPLONG): BOOL;

    function SetColorMode       (ColorMode: LONG): BOOL;
    function GetColorMode:      LONG;

    function SetCrossbar        (Output: LONG; Input: LONG): BOOL;
    function SetDeviceNumber    (Number: LONG): BOOL;
    function EnumDevice         (szDeviceName: DeviceNameList): LONG;
    function GetDeviceName      (index: LONG; szDeviceName: LPSTR; nSize: LONG): BOOL;

    function StartPreview:      BOOL;
    function StopPreview:       BOOL;
    function GetImage           (lpImage: LPBYTE; Size: LONG; TopDown: BOOL): BOOL;

    function Width:             LONG;
    function Height:            LONG;
    function Fps:               LONG;

    function SetCameraDlg       (hWnd: HWND): BOOL;
    function SetImageDlg        (hWnd: HWND): BOOL;
    function SetAnalogDlg       (hWnd: HWND): BOOL;

    // 1230
    function SetIOPort          (byteData: BYTE; longData: LONG; Reserve: DWORD): BOOL;
    function GetIOPort          (byteData: LPBYTE; longData: LPLONG; Reserve: DWORD): BOOL;
    function SetFilterValue     (FilterType: ARTCAM_FILTERTYPE; Value: LONG): BOOL;
    function GetFilterValue     (FilterType: ARTCAM_FILTERTYPE; Error: LPBOOL): LONG;

    function SetSubSample       (SubSampleMode: SUBSAMPLE): BOOL;
    function GetSubSample:      SUBSAMPLE;
    function SetWaitTime        (WaitTime: LONG): BOOL;
    function GetWaitTime:       LONG;

    // 1240
    function SetMirrorV         (Flg: BOOL): BOOL;
    function GetMirrorV:        BOOL;
    function SetMirrorH         (Flg: BOOL): BOOL;
    function GetMirrorH:        BOOL;

    function SetBrightness      (Value: LONG): BOOL;
    function GetBrightness      (Error: LPBOOL): LONG;
    function SetContrast        (Value: LONG): BOOL;
    function GetContrast        (Error: LPBOOL): LONG;
    function SetHue             (Value: LONG): BOOL;
    function GetHue             (Error: LPBOOL): LONG;
    function SetSaturation      (Value: LONG): BOOL;
    function GetSaturation      (Error: LPBOOL): LONG;
    function SetSharpness       (Value: LONG): BOOL;
    function GetSharpness       (Error: LPBOOL): LONG;
    function SetBayerGainRGB    (Value: LONG): BOOL;
    function GetBayerGainRGB    (Error: LPBOOL): LONG;
    function SetBayerGainRed    (Value: LONG): BOOL;
    function GetBayerGainRed    (Error: LPBOOL): LONG;
    function SetBayerGainGreen  (Value: LONG): BOOL;
    function GetBayerGainGreen  (Error: LPBOOL): LONG;
    function SetBayerGainBlue   (Value: LONG): BOOL;
    function GetBayerGainBlue   (Error: LPBOOL): LONG;
    function SetBayerGainAuto   (Value: LONG): BOOL;
    function GetBayerGainAuto   (Error: LPBOOL): LONG;
    function SetGamma           (Value: LONG): BOOL;
    function GetGamma           (Error: LPBOOL): LONG;
    function SetBayerMode       (Value: LONG): BOOL;
    function GetBayerMode       (Error: LPBOOL): LONG;
    function SetGlobalGain      (Value: LONG): BOOL;
    function GetGlobalGain      (Error: LPBOOL): LONG;
    function SetColorGainRed    (Value: LONG): BOOL;
    function GetColorGainRed    (Error: LPBOOL): LONG;
    function SetColorGainGreen1 (Value: LONG): BOOL;
    function GetColorGainGreen1 (Error: LPBOOL): LONG;
    function SetColorGainGreen2 (Value: LONG): BOOL;
    function GetColorGainGreen2 (Error: LPBOOL): LONG;
    function SetColorGainBlue   (Value: LONG): BOOL;
    function GetColorGainBlue   (Error: LPBOOL): LONG;
    function SetExposureTime    (Value: LONG): BOOL;
    function GetExposureTime    (Error: LPBOOL): LONG;

    // 1260
    function SetHalfClock       (Value: LONG): BOOL;
    function GetHalfClock       (Error: LPBOOL): LONG;
    function SetAutoIris        (Value: LONG): BOOL;
    function GetAutoIris        (Error: LPBOOL): LONG;

    // 1275
    function SetSamplingRate    (Value: LONG): BOOL;
    function GetSamplingRate    (Error: LPBOOL): LONG;
    function GetVideoFormat     (Error: LPBOOL): LONG;

    // 1276
    function WriteSromID        (Address: LONG; Value: LONG): BOOL;
    function ReadSromID         (Address: LONG; Error: LPBOOL): LONG;

    // 1280
    function GetCameraInfo      (pInfo: LPCAMERAINFO): BOOL; cdecl;
    function GetStatus          (Error: LPBOOL): LONG; cdecl;

    function WriteRegister      (Address: BYTE; Value: DWORD): BOOL; cdecl;
    function ReadRegister       (Address: BYTE; Error: LPBOOL): DWORD; cdecl;
    function WriteRegisterEx   	(Address: DWORD; Value: DWORD): BOOL; cdecl;
    function ReadRegisterEx    	(Address: DWORD; Error: LPBOOL): DWORD; cdecl;

    function SetCrcCheckMode  	(Value: LONG): BOOL; cdecl;
    function GetCrcCheckMode  	(Error: LPBOOL): LONG; cdecl;
    function SetLChannelValue  	(Value: LONG): BOOL; cdecl;
    function GetLChannelValue  	(Error: LPBOOL): LONG; cdecl;
    function SetChannelProfileMode	(Value: LONG): BOOL; cdecl;
    function GetChannelProfile  	(Error: LPBOOL): LONG; cdecl;

    function SetGrayMode        (Value: LONG): BOOL; cdecl;
    function GetGrayMode        (Error: LPBOOL): LONG; cdecl;
    function SetGrayGainR       (Value: LONG): BOOL; cdecl;
    function GetGrayGainR       (Error: LPBOOL): LONG; cdecl;
    function SetGrayGainG1      (Value: LONG): BOOL; cdecl;
    function GetGrayGainG1      (Error: LPBOOL): LONG; cdecl;
    function SetGrayGainG2      (Value: LONG): BOOL; cdecl;
    function GetGrayGainG2      (Error: LPBOOL): LONG; cdecl;
    function SetGrayGainB       (Value: LONG): BOOL; cdecl;
    function GetGrayGainB       (Error: LPBOOL): LONG; cdecl;
    function SetGrayOffsetR     (Value: LONG): BOOL; cdecl;
    function GetGrayOffsetR     (Error: LPBOOL): LONG; cdecl;
    function SetGrayOffsetG1    (Value: LONG): BOOL; cdecl;
    function GetGrayOffsetG1    (Error: LPBOOL): LONG; cdecl;
    function SetGrayOffsetG2    (Value: LONG): BOOL; cdecl;
    function GetGrayOffsetG2    (Error: LPBOOL): LONG; cdecl;
    function SetGrayOffsetB     (Value: LONG): BOOL; cdecl;
    function GetGrayOffsetB     (Error: LPBOOL): LONG; cdecl;

    // 1300
    function GetRealExposureTime	(Error: LPBOOL): LONG; cdecl;
    function SetRealExposureTime	(Value: LONG): BOOL; cdecl;

    // 1311
    function LoadConfigFile		(szFileName: LPCTSTR): BOOL; cdecl;
    function SetConfigFilter	(Value: LONG): BOOL; cdecl;
    function GetConfigFilter	(): LONG; cdecl;

    // SATA
    function SetCameraType  (Flg: LONG): BOOL; cdecl;
    function GetCameraType  (Error: LPBOOL): LONG; cdecl;
    function SetSyncV		(Flg: LONG): BOOL; cdecl;
    function GetSyncV		(Error: LPBOOL): LONG; cdecl;
    function SetSyncH		(Flg: LONG): BOOL; cdecl;
    function GetSyncH		(Error: LPBOOL): LONG; cdecl;

    // MOUT
    function Fpga_WriteRegister (Address: BYTE; Value: DWORD): BOOL; cdecl;
    function Fpga_ReadRegister  (Address: BYTE; Error: LPBOOL): DWORD; cdecl;

    function Monitor_SetPreviewMode     (Preview: BOOL): BOOL; cdecl;
    function Monitor_GetPreviewMode     (Error: LPBOOL): BOOL; cdecl;
    function Monitor_SetPreviewSize     (Width: LONG; Height: LONG): BOOL; cdecl;
    function Monitor_GetPreviewSize     (LPWidth: LPLONG; LPHeight: LPLONG): BOOL; cdecl;
    function Monitor_SetColorMode       (ColorMode: BOOL): BOOL; cdecl;
    function Monitor_GetColorMode       (Error: LPBOOL): BOOL; cdecl;
    function Monitor_SetCameraClock     (Value: LONG): BOOL; cdecl;
    function Monitor_GetCameraClock     (Error: LPBOOL): LONG; cdecl;
    function Monitor_SetBayerGainAuto   (Value: LONG): BOOL; cdecl;
    function Monitor_GetBayerGainAuto   (Error: LPBOOL): LONG; cdecl;
	function Monitor_SetBayerGainLock	(Value: LONG): BOOL; cdecl;
	function Monitor_GetBayerGainLock	(Error: LPBOOL): LONG; cdecl;
    function Monitor_SetBayerGainRed    (Value: LONG): BOOL; cdecl;
    function Monitor_GetBayerGainRed    (Error: LPBOOL): LONG; cdecl;
    function Monitor_SetBayerGainGreen  (Value: LONG): BOOL; cdecl;
    function Monitor_GetBayerGainGreen  (Error: LPBOOL): LONG; cdecl;
    function Monitor_SetBayerGainBlue   (Value: LONG): BOOL; cdecl;
    function Monitor_GetBayerGainBlue   (Error: LPBOOL): LONG; cdecl;
    
    function Monitor_SaveCurrentSettings	():BOOL; cdecl;
    function Monitor_InitRegisterSettings	(Flg: LONG): BOOL; cdecl;

	function Monitor_SetCrossCursorMode	(CursorNum: LONG; Value: LONG): BOOL; cdecl;
	function Monitor_GetCrossCursorMode	(CursorNum: LONG; Error: LPBOOL): LONG; cdecl;
	function Monitor_SetCrossCursorColorR	(CursorNum: LONG; Value: LONG): BOOL; cdecl;
	function Monitor_GetCrossCursorColorR	(CursorNum: LONG; Error: LPBOOL): LONG; cdecl;
	function Monitor_SetCrossCursorColorG	(CursorNum: LONG; Value: LONG): BOOL; cdecl;
	function Monitor_GetCrossCursorColorG	(CursorNum: LONG; Error: LPBOOL): LONG; cdecl;
	function Monitor_SetCrossCursorColorB	(CursorNum: LONG; Value: LONG): BOOL; cdecl;
	function Monitor_GetCrossCursorColorB	(CursorNum: LONG; Error: LPBOOL): LONG; cdecl;
	function Monitor_SetCrossCursorColorRGB	(CursorNum: LONG; Value: LONG): BOOL; cdecl;
	function Monitor_GetCrossCursorColorRGB	(CursorNum: LONG; Error: LPBOOL): LONG; cdecl;
	function Monitor_SetCrossCursorPos	(CursorNum: LONG; ValueX: LONG; ValueY: LONG): BOOL; cdecl;
	function Monitor_GetCrossCursorPos	(CursorNum: LONG; ValueX: LPLONG; ValueY: LPLONG): BOOL; cdecl;
	function Monitor_SetCrossCursorSize	(CursorNum: LONG; ValueX: LONG; ValueY: LONG): BOOL; cdecl;
	function Monitor_GetCrossCursorSize	(CursorNum: LONG; ValueX: LPLONG; ValueY: LPLONG): BOOL; cdecl;

	function Monitor_SetAutoIrisMode	(Value: LONG): BOOL; cdecl;
	function Monitor_GetAutoIrisMode	(Error: LPBOOL): LONG; cdecl;
	function Monitor_SetAutoIrisRange	(Min: LONG; Max: LONG): BOOL; cdecl;
	function Monitor_GetAutoIrisRange	(Min: LPLONG; Max: LPLONG): BOOL; cdecl;
	function Monitor_LoadFirmware		(szFileName: LPCTSTR): BOOL; cdecl;

    // TNIR
	function SaveMaskFile				(szFileName: LPCTSTR):	BOOL; cdecl;
	function LoadMaskFile				(szFileName: LPCTSTR):	BOOL; cdecl;
	function UpdateMaskData				(Flg: MASKTYPE):		BOOL; cdecl;
	function SetPeltier					(Value: LONG):			BOOL; cdecl;
	function GetPeltier					(Error: LPBOOL):		LONG; cdecl;
	function GetTemperature				(Error: LPBOOL):		LONG; cdecl;
	function SetDotFilter				(Value: LONG):			BOOL; cdecl;
	function GetDotFilter				(Error: LPBOOL):		LONG; cdecl;
	function SetMaskFilter				(Value: LONG):			BOOL; cdecl;
	function GetMaskFilter				(Error: LPBOOL):		LONG; cdecl;
	function SetInternalCorrection		(Enable: LONG):			BOOL; cdecl;
	function GetInternalCorrection		(Error: LPBOOL):		BOOL; cdecl;
  end;


const
  SUB_SAMPLE: array[0..3] of Integer = (1, 2, 4, 8);

implementation



procedure TArtCam.NullSet;
begin
  @F_GetDllVersion              := nil;
  @F_GetLastError               := nil;
  @F_Initialize                 := nil;
  @F_Release                    := nil;
  @F_Preview                    := nil;
  @F_Record                     := nil;
  @F_CallBackPreview            := nil;
  @F_Close                      := nil;
  @F_SnapShot                   := nil;
  @F_Capture                    := nil;
  @F_Trigger                    := nil;
  @F_SaveImage                  := nil;
  @F_SetPreviewWindow           := nil;
  @F_SetCaptureWindow           := nil;
  @F_SetCaptureWindowEx         := nil;
  @F_GetCaptureWindowEx         := nil;
  @F_SetColorMode               := nil;
  @F_GetColorMode               := nil;
  @F_SetCrossbar                := nil;
  @F_SetDeviceNumber            := nil;
  @F_EnumDevice                 := nil;
  @F_GetDeviceName              := nil;
  @F_StartPreview               := nil;
  @F_StopPreview                := nil;
  @F_GetImage                   := nil;
  @F_Width                      := nil;
  @F_Height                     := nil;
  @F_Fps                        := nil;
  @F_SetCameraDlg               := nil;
  @F_SetImageDlg                := nil;
  @F_SetAnalogDlg               := nil;
  @F_SetIOPort                  := nil;
  @F_GetIOPort                  := nil;
  @F_SetFilterValue             := nil;
  @F_GetFilterValue             := nil;
  @F_SetSubSample               := nil;
  @F_GetSubSample               := nil;
  @F_SetWaitTime                := nil;
  @F_GetWaitTime                := nil;
  @F_SetMirrorV                 := nil;
  @F_GetMirrorV                 := nil;
  @F_SetMirrorH                 := nil;
  @F_GetMirrorH                 := nil;
  @F_SetBrightness              := nil;
  @F_GetBrightness              := nil;
  @F_SetContrast                := nil;
  @F_GetContrast                := nil;
  @F_SetHue                     := nil;
  @F_GetHue                     := nil;
  @F_SetSaturation              := nil;
  @F_GetSaturation              := nil;
  @F_SetSharpness               := nil;
  @F_GetSharpness               := nil;
  @F_SetBayerGainRGB            := nil;
  @F_GetBayerGainRGB            := nil;
  @F_SetBayerGainRed            := nil;
  @F_GetBayerGainRed            := nil;
  @F_SetBayerGainGreen          := nil;
  @F_GetBayerGainGreen          := nil;
  @F_SetBayerGainBlue           := nil;
  @F_GetBayerGainBlue           := nil;
  @F_SetBayerGainAuto           := nil;
  @F_GetBayerGainAuto           := nil;
  @F_SetGamma                   := nil;
  @F_GetGamma                   := nil;
  @F_SetBayerMode               := nil;
  @F_GetBayerMode               := nil;
  @F_SetGlobalGain              := nil;
  @F_GetGlobalGain              := nil;
  @F_SetColorGainRed            := nil;
  @F_GetColorGainRed            := nil;
  @F_SetColorGainGreen1         := nil;
  @F_GetColorGainGreen1         := nil;
  @F_SetColorGainGreen2         := nil;
  @F_GetColorGainGreen2         := nil;
  @F_SetColorGainBlue           := nil;
  @F_GetColorGainBlue           := nil;
  @F_SetExposureTime            := nil;
  @F_GetExposureTime            := nil;
  @F_SetHalfClock               := nil;
  @F_GetHalfClock               := nil;
  @F_SetAutoIris                := nil;
  @F_GetAutoIris                := nil;
  @F_SetSamplingRate            := nil;
  @F_GetSamplingRate            := nil;
  @F_GetVideoFormat             := nil;
  @F_WriteSromID                := nil;
  @F_ReadSromID                 := nil;
  @F_GetCameraInfo              := nil;
  @F_GetStatus                  := nil;
  @F_WriteRegister              := nil;
  @F_ReadRegister               := nil;
  @F_WriteRegisterEx              := nil;
  @F_ReadRegisterEx               := nil;
  @F_SetCrcCheckMode			:= nil;
  @F_GetCrcCheckMode			:= nil;
  @F_SetLChannelValue			:= nil;
  @F_GetLChannelValue			:= nil;
  @F_SetChannelProfileMode		:= nil;
  @F_GetChannelProfile			:= nil;
  @F_SetGrayMode                := nil;
  @F_GetGrayMode                := nil;
  @F_SetGrayGainR               := nil;
  @F_GetGrayGainR               := nil;
  @F_SetGrayGainG1              := nil;
  @F_GetGrayGainG1              := nil;
  @F_SetGrayGainG2              := nil;
  @F_GetGrayGainG2              := nil;
  @F_SetGrayGainB               := nil;
  @F_GetGrayGainB               := nil;
  @F_SetGrayOffsetR             := nil;
  @F_GetGrayOffsetR             := nil;
  @F_SetGrayOffsetG1            := nil;
  @F_GetGrayOffsetG1            := nil;
  @F_SetGrayOffsetG2            := nil;
  @F_GetGrayOffsetG2            := nil;
  @F_SetGrayOffsetB             := nil;
  @F_GetGrayOffsetB             := nil;
  @F_SetCameraType              := nil;
  @F_GetCameraType              := nil;
  @F_SetSyncV					:= nil;
  @F_GetSyncV					:= nil;
  @F_SetSyncH					:= nil;
  @F_GetSyncH					:= nil;
  @F_Fpga_WriteRegister         := nil;
  @F_Fpga_ReadRegister          := nil;
  @F_Monitor_SetPreviewMode     := nil;
  @F_Monitor_GetPreviewMode     := nil;
  @F_Monitor_SetPreviewSize     := nil;
  @F_Monitor_GetPreviewSize     := nil;
  @F_Monitor_SetColorMode       := nil;
  @F_Monitor_GetColorMode       := nil;
  @F_Monitor_SetCameraClock     := nil;
  @F_Monitor_GetCameraClock     := nil;
  @F_Monitor_SetBayerGainAuto   := nil;
  @F_Monitor_GetBayerGainAuto   := nil;
  @F_Monitor_SetBayerGainLock	:= nil;
  @F_Monitor_GetBayerGainLock	:= nil;
  @F_Monitor_SetBayerGainRed    := nil;
  @F_Monitor_GetBayerGainRed    := nil;
  @F_Monitor_SetBayerGainGreen  := nil;
  @F_Monitor_GetBayerGainGreen  := nil;
  @F_Monitor_SetBayerGainBlue   := nil;
  @F_Monitor_GetBayerGainBlue   := nil;
  @F_Monitor_SaveCurrentSettings 	:= nil;
  @F_Monitor_InitRegisterSettings	:= nil;
  @F_Monitor_SetCrossCursorMode	:= nil;
  @F_Monitor_GetCrossCursorMode	:= nil;
  @F_Monitor_SetCrossCursorColorR	:= nil;
  @F_Monitor_GetCrossCursorColorR	:= nil;
  @F_Monitor_SetCrossCursorColorG	:= nil;
  @F_Monitor_GetCrossCursorColorG	:= nil;
  @F_Monitor_SetCrossCursorColorB	:= nil;
  @F_Monitor_GetCrossCursorColorB	:= nil;
  @F_Monitor_SetCrossCursorColorRGB	:= nil;
  @F_Monitor_GetCrossCursorColorRGB	:= nil;
  @F_Monitor_SetCrossCursorPos	:= nil;
  @F_Monitor_GetCrossCursorPos	:= nil;
  @F_Monitor_SetCrossCursorSize := nil;
  @F_Monitor_GetCrossCursorSize := nil;
  @F_Monitor_SetAutoIrisMode	:= nil;
  @F_Monitor_GetAutoIrisMode	:= nil;
  @F_Monitor_SetAutoIrisRange	:= nil;
  @F_Monitor_GetAutoIrisRange	:= nil;
  @F_Monitor_LoadFirmware		:= nil;
  @F_GetRealExposureTime		:= nil;
  @F_SetRealExposureTime		:= nil;

  @F_SaveMaskFile		:= nil;
  @F_LoadMaskFile		:= nil;
  @F_UpdateMaskData		:= nil;
  @F_SetPeltier			:= nil;
  @F_GetPeltier			:= nil;
  @F_GetTemperature		:= nil;
  @F_SetDotFilter		:= nil;
  @F_GetDotFilter		:= nil;
  @F_SetMaskFilter		:= nil;
  @F_GetMaskFilter		:= nil;
  @F_SetInternalCorrection	:= nil;
  @F_GetInternalCorrection	:= nil;

  @F_LoadConfigFile		:= nil;
  @F_SetConfigFilter	:= nil;
  @F_GetConfigFilter	:= nil;

  FDLLHandle := 0;
  SdkHandle := 0;
end;

constructor TArtCam.Create;
begin
  NullSet;
end;

destructor TArtCam.Destroy;
begin
  FreeLibrary;
end;

function TArtCam.IsInit: Boolean;
begin
  if SdkHandle<>0 then
    begin
      Result := true;
    exit;
  end;

  Result := false;
end;

function TArtCam.LoadLibrary(lpLibFileName: PChar): Boolean;
begin
  FDLLHandle := Windows.LoadLibrary(lpLibFileName);
  if FDLLHandle<>0 then begin
    @F_GetDllVersion:=        GetProcAddress(FDLLHandle, 'ArtCam_GetDllVersion');
    @F_GetLastError:=         GetProcAddress(FDLLHandle, 'ArtCam_GetLastError');

    @F_Initialize:=           GetProcAddress(FDLLHandle, 'ArtCam_Initialize');
    @F_Release:=              GetProcAddress(FDLLHandle, 'ArtCam_Release');

    @F_Preview:=              GetProcAddress(FDLLHandle, 'ArtCam_Preview');
    @F_Record:=               GetProcAddress(FDLLHandle, 'ArtCam_Record');
    @F_CallBackPreview:=      GetProcAddress(FDLLHandle, 'ArtCam_CallBackPreview');
    @F_Close:=                GetProcAddress(FDLLHandle, 'ArtCam_Close');

    // 1230
    @F_SnapShot:=             GetProcAddress(FDLLHandle, 'ArtCam_SnapShot');

    // 1250
    @F_Capture:=              GetProcAddress(FDLLHandle, 'ArtCam_Capture');

    // 1260
    @F_Trigger:=              GetProcAddress(FDLLHandle, 'ArtCam_Trigger');
    @F_SaveImage:=            GetProcAddress(FDLLHandle, 'ArtCam_SaveImage');


    @F_SetPreviewWindow:=     GetProcAddress(FDLLHandle, 'ArtCam_SetPreviewWindow');
    @F_SetCaptureWindow:=     GetProcAddress(FDLLHandle, 'ArtCam_SetCaptureWindow');
    @F_SetCaptureWindowEx:=   GetProcAddress(FDLLHandle, 'ArtCam_SetCaptureWindowEx');
    @F_GetCaptureWindowEx:=   GetProcAddress(FDLLHandle, 'ArtCam_GetCaptureWindowEx');

    @F_SetColorMode:=         GetProcAddress(FDLLHandle, 'ArtCam_SetColorMode');
    @F_GetColorMode:=         GetProcAddress(FDLLHandle, 'ArtCam_GetColorMode');

    @F_SetCrossbar:=          GetProcAddress(FDLLHandle, 'ArtCam_SetCrossbar');
    @F_SetDeviceNumber:=      GetProcAddress(FDLLHandle, 'ArtCam_SetDeviceNumber');
    @F_EnumDevice:=           GetProcAddress(FDLLHandle, 'ArtCam_EnumDevice');
    @F_GetDeviceName:=        GetProcAddress(FDLLHandle, 'ArtCam_GetDeviceName');

    @F_StartPreview:=         GetProcAddress(FDLLHandle, 'ArtCam_StartPreview');
    @F_StopPreview:=          GetProcAddress(FDLLHandle, 'ArtCam_StopPreview');
    @F_GetImage:=             GetProcAddress(FDLLHandle, 'ArtCam_GetImage');

    @F_Width:=                GetProcAddress(FDLLHandle, 'ArtCam_Width');
    @F_Height:=               GetProcAddress(FDLLHandle, 'ArtCam_Height');
    @F_Fps:=                  GetProcAddress(FDLLHandle, 'ArtCam_Fps');

    @F_SetCameraDlg:=         GetProcAddress(FDLLHandle, 'ArtCam_SetCameraDlg');
    @F_SetImageDlg:=          GetProcAddress(FDLLHandle, 'ArtCam_SetImageDlg');
    @F_SetAnalogDlg:=         GetProcAddress(FDLLHandle, 'ArtCam_SetAnalogDlg');

    // 1230
    @F_SetIOPort:=            GetProcAddress(FDLLHandle, 'ArtCam_SetIOPort');
    @F_GetIOPort:=            GetProcAddress(FDLLHandle, 'ArtCam_GetIOPort');

    @F_SetFilterValue:=       GetProcAddress(FDLLHandle, 'ArtCam_SetFilterValue');
    @F_GetFilterValue:=       GetProcAddress(FDLLHandle, 'ArtCam_GetFilterValue');

    @F_SetSubSample:=         GetProcAddress(FDLLHandle, 'ArtCam_SetSubSample');
    @F_GetSubSample:=         GetProcAddress(FDLLHandle, 'ArtCam_GetSubSample');

    @F_SetWaitTime:=          GetProcAddress(FDLLHandle, 'ArtCam_SetWaitTime');
    @F_GetWaitTime:=          GetProcAddress(FDLLHandle, 'ArtCam_GetWaitTime');

    // 1240
    @F_SetMirrorV:=           GetProcAddress(FDLLHandle, 'ArtCam_SetMirrorV');
    @F_GetMirrorV:=           GetProcAddress(FDLLHandle, 'ArtCam_GetMirrorV');

    @F_SetMirrorH:=           GetProcAddress(FDLLHandle, 'ArtCam_SetMirrorH');
    @F_GetMirrorH:=           GetProcAddress(FDLLHandle, 'ArtCam_GetMirrorH');

    @F_SetBrightness:=        GetProcAddress(FDLLHandle, 'ArtCam_SetBrightness');
    @F_GetBrightness:=        GetProcAddress(FDLLHandle, 'ArtCam_GetBrightness');

    @F_SetContrast:=          GetProcAddress(FDLLHandle, 'ArtCam_SetContrast');
    @F_GetContrast:=          GetProcAddress(FDLLHandle, 'ArtCam_GetContrast');

    @F_SetHue:=               GetProcAddress(FDLLHandle, 'ArtCam_SetHue');
    @F_GetHue:=               GetProcAddress(FDLLHandle, 'ArtCam_GetHue');

    @F_SetSaturation:=        GetProcAddress(FDLLHandle, 'ArtCam_SetSaturation');
    @F_GetSaturation:=        GetProcAddress(FDLLHandle, 'ArtCam_GetSaturation');

    @F_SetSharpness:=         GetProcAddress(FDLLHandle, 'ArtCam_SetSharpness');
    @F_GetSharpness:=         GetProcAddress(FDLLHandle, 'ArtCam_GetSharpness');

    @F_SetBayerGainRGB:=      GetProcAddress(FDLLHandle, 'ArtCam_SetBayerGainRGB');
    @F_GetBayerGainRGB:=      GetProcAddress(FDLLHandle, 'ArtCam_GetBayerGainRGB');

    @F_SetBayerGainRed:=      GetProcAddress(FDLLHandle, 'ArtCam_SetBayerGainRed');
    @F_GetBayerGainRed:=      GetProcAddress(FDLLHandle, 'ArtCam_GetBayerGainRed');

    @F_SetBayerGainGreen:=    GetProcAddress(FDLLHandle, 'ArtCam_SetBayerGainGreen');
    @F_GetBayerGainGreen:=    GetProcAddress(FDLLHandle, 'ArtCam_GetBayerGainGreen');

    @F_SetBayerGainBlue:=     GetProcAddress(FDLLHandle, 'ArtCam_SetBayerGainBlue');
    @F_GetBayerGainBlue:=     GetProcAddress(FDLLHandle, 'ArtCam_GetBayerGainBlue');

    @F_SetBayerGainAuto:=     GetProcAddress(FDLLHandle, 'ArtCam_SetBayerGainAuto');
    @F_GetBayerGainAuto:=     GetProcAddress(FDLLHandle, 'ArtCam_GetBayerGainAuto');

    @F_SetGamma:=             GetProcAddress(FDLLHandle, 'ArtCam_SetGamma');
    @F_GetGamma:=             GetProcAddress(FDLLHandle, 'ArtCam_GetGamma');

    @F_SetBayerMode:=         GetProcAddress(FDLLHandle, 'ArtCam_SetBayerMode');
    @F_GetBayerMode:=         GetProcAddress(FDLLHandle, 'ArtCam_GetBayerMode');

    @F_SetGlobalGain:=        GetProcAddress(FDLLHandle, 'ArtCam_SetGlobalGain');
    @F_GetGlobalGain:=        GetProcAddress(FDLLHandle, 'ArtCam_GetGlobalGain');

    @F_SetColorGainRed:=      GetProcAddress(FDLLHandle, 'ArtCam_SetColorGainRed');
    @F_GetColorGainRed:=      GetProcAddress(FDLLHandle, 'ArtCam_GetColorGainRed');

    @F_SetColorGainGreen1:=   GetProcAddress(FDLLHandle, 'ArtCam_SetColorGainGreen1');
    @F_GetColorGainGreen1:=   GetProcAddress(FDLLHandle, 'ArtCam_GetColorGainGreen1');

    @F_SetColorGainGreen2:=   GetProcAddress(FDLLHandle, 'ArtCam_SetColorGainGreen2');
    @F_GetColorGainGreen2:=   GetProcAddress(FDLLHandle, 'ArtCam_GetColorGainGreen2');

    @F_SetColorGainBlue:=     GetProcAddress(FDLLHandle, 'ArtCam_SetColorGainBlue');
    @F_GetColorGainBlue:=     GetProcAddress(FDLLHandle, 'ArtCam_GetColorGainBlue');

    @F_SetExposureTime:=      GetProcAddress(FDLLHandle, 'ArtCam_SetExposureTime');
    @F_GetExposureTime:=      GetProcAddress(FDLLHandle, 'ArtCam_GetExposureTime');

    // 1260
    @F_SetHalfClock:=         GetProcAddress(FDLLHandle, 'ArtCam_SetHalfClock');
    @F_GetHalfClock:=         GetProcAddress(FDLLHandle, 'ArtCam_GetHalfClock');

    @F_SetAutoIris:=          GetProcAddress(FDLLHandle, 'ArtCam_SetAutoIris');
    @F_GetAutoIris:=          GetProcAddress(FDLLHandle, 'ArtCam_GetAutoIris');

    // 1275
    @F_SetSamplingRate:=      GetProcAddress(FDLLHandle, 'ArtCam_SetSamplingRate');
    @F_GetSamplingRate:=      GetProcAddress(FDLLHandle, 'ArtCam_GetSamplingRate');
    @F_GetVideoFormat:=       GetProcAddress(FDLLHandle, 'ArtCam_GetVideoFormat');

    // 1276
    @F_WriteSromID:=          GetProcAddress(FDLLHandle, 'ArtCam_WriteSromID');
    @F_ReadSromID:=           GetProcAddress(FDLLHandle, 'ArtCam_ReadSromID');

    // 1280
    @F_GetCameraInfo:=        GetProcAddress(FDLLHandle, 'ArtCam_GetCameraInfo');
    @F_GetStatus:=            GetProcAddress(FDLLHandle, 'ArtCam_GetStatus');

    @F_WriteRegister:=        GetProcAddress(FDLLHandle, 'ArtCam_WriteRegister');
    @F_ReadRegister:=         GetProcAddress(FDLLHandle, 'ArtCam_ReadRegister');

    @F_WriteRegisterEx:=  		GetProcAddress(FDLLHandle, 'ArtCam_WriteRegisterEx');
    @F_ReadRegisterEx:=         GetProcAddress(FDLLHandle, 'ArtCam_ReadRegisterEx');
    
    @F_SetCrcCheckMode:=        GetProcAddress(FDLLHandle, 'ArtCam_SetCrcCheckMode');
    @F_GetCrcCheckMode:=        GetProcAddress(FDLLHandle, 'ArtCam_GetCrcCheckMode');
    
    @F_SetLChannelValue:=    	GetProcAddress(FDLLHandle, 'ArtCam_SetLChannelValue');
    @F_GetLChannelValue:=     	GetProcAddress(FDLLHandle, 'ArtCam_GetLChannelValue');
    @F_SetChannelProfileMode:=	GetProcAddress(FDLLHandle, 'ArtCam_SetChannelProfileMode');
    @F_GetChannelProfile:=     	GetProcAddress(FDLLHandle, 'ArtCam_GetChannelProfile');

    @F_SetGrayMode:=          GetProcAddress(FDLLHandle, 'ArtCam_SetGrayMode');
    @F_GetGrayMode:=          GetProcAddress(FDLLHandle, 'ArtCam_GetGrayMode');

    @F_SetGrayGainR:=         GetProcAddress(FDLLHandle, 'ArtCam_SetGrayGainR');
    @F_GetGrayGainR:=         GetProcAddress(FDLLHandle, 'ArtCam_GetGrayGainR');

    @F_SetGrayGainG1:=        GetProcAddress(FDLLHandle, 'ArtCam_SetGrayGainG1');
    @F_GetGrayGainG1:=        GetProcAddress(FDLLHandle, 'ArtCam_GetGrayGainG1');

    @F_SetGrayGainG2:=        GetProcAddress(FDLLHandle, 'ArtCam_SetGrayGainG2');
    @F_GetGrayGainG2:=        GetProcAddress(FDLLHandle, 'ArtCam_GetGrayGainG2');

    @F_SetGrayGainB:=         GetProcAddress(FDLLHandle, 'ArtCam_SetGrayGainB');
    @F_GetGrayGainB:=         GetProcAddress(FDLLHandle, 'ArtCam_GetGrayGainB');

    @F_SetGrayOffsetR:=       GetProcAddress(FDLLHandle, 'ArtCam_SetGrayOffsetR');
    @F_GetGrayOffsetR:=       GetProcAddress(FDLLHandle, 'ArtCam_GetGrayOffsetR');

    @F_SetGrayOffsetG1:=      GetProcAddress(FDLLHandle, 'ArtCam_SetGrayOffsetG1');
    @F_GetGrayOffsetG1:=      GetProcAddress(FDLLHandle, 'ArtCam_GetGrayOffsetG1');

    @F_SetGrayOffsetG2:=      GetProcAddress(FDLLHandle, 'ArtCam_SetGrayOffsetG2');
    @F_GetGrayOffsetG2:=      GetProcAddress(FDLLHandle, 'ArtCam_GetGrayOffsetG2');

    @F_SetGrayOffsetB:=       GetProcAddress(FDLLHandle, 'ArtCam_SetGrayOffsetB');
    @F_GetGrayOffsetB:=       GetProcAddress(FDLLHandle, 'ArtCam_GetGrayOffsetB');
	// 1300
    @F_GetRealExposureTime:=  GetProcAddress(FDLLHandle, 'ArtCam_GetRealExposureTime');
    @F_SetRealExposureTime:=  GetProcAddress(FDLLHandle, 'ArtCam_SetRealExposureTime');

	// 1300
	@F_LoadConfigFile:=		GetProcAddress(FDLLHandle, 'ArtCam_LoadConfigFileA');
	@F_SetConfigFilter:=	GetProcAddress(FDLLHandle, 'ArtCam_SetConfigFilter');
	@F_GetConfigFilter:=	GetProcAddress(FDLLHandle, 'ArtCam_GetConfigFilter');

    // SATA
    @F_SetCameraType:=        GetProcAddress(FDLLHandle, 'ArtCam_SetCameraType');
    @F_GetCameraType:=        GetProcAddress(FDLLHandle, 'ArtCam_GetCameraType');
    
    @F_SetSyncV:=				GetProcAddress(FDLLHandle, 'ArtCam_SetSyncV');
    @F_GetSyncV:=        		GetProcAddress(FDLLHandle, 'ArtCam_GetSyncV');
    @F_SetSyncH:=        		GetProcAddress(FDLLHandle, 'ArtCam_SetSyncH');
    @F_GetSyncH:=        		GetProcAddress(FDLLHandle, 'ArtCam_GetSyncH');

    // MOUT
    @F_Fpga_WriteRegister:=       GetProcAddress(FDLLHandle, 'ArtCam_Fpga_WriteRegister');
    @F_Fpga_ReadRegister:=        GetProcAddress(FDLLHandle, 'ArtCam_Fpga_ReadRegister');

    @F_Monitor_SetPreviewMode:=   GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetPreviewMode');
    @F_Monitor_GetPreviewMode:=   GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetPreviewMode');

    @F_Monitor_SetPreviewSize:=   GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetPreviewSize');
    @F_Monitor_GetPreviewSize:=   GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetPreviewSize');

    @F_Monitor_SetColorMode:=     GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetColorMode');
    @F_Monitor_GetColorMode:=     GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetColorMode');

    @F_Monitor_SetCameraClock:=   GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetCameraClock');
    @F_Monitor_GetCameraClock:=   GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetCameraClock');

    @F_Monitor_SetBayerGainAuto:= GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetBayerGainAuto');
    @F_Monitor_GetBayerGainAuto:= GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetBayerGainAuto');
    
    @F_Monitor_SetBayerGainLock:= GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetBayerGainLock');
    @F_Monitor_GetBayerGainLock:= GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetBayerGainLock');

    @F_Monitor_SetBayerGainRed:=  GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetBayerGainRed');
    @F_Monitor_GetBayerGainRed:=  GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetBayerGainRed');

    @F_Monitor_SetBayerGainGreen:=GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetBayerGainGreen');
    @F_Monitor_GetBayerGainGreen:=GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetBayerGainGreen');

    @F_Monitor_SetBayerGainBlue:= GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetBayerGainBlue');
    @F_Monitor_GetBayerGainBlue:= GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetBayerGainBlue');
    
    @F_Monitor_SaveCurrentSettings:= 	GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SaveCurrentSettings');
    @F_Monitor_InitRegisterSettings:= 	GetProcAddress(FDLLHandle, 'ArtCam_Monitor_InitRegisterSettings');
    
    @F_Monitor_SetCrossCursorMode:= 	GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetCrossCursorMode');
    @F_Monitor_GetCrossCursorMode:= 	GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetCrossCursorMode');
    @F_Monitor_SetCrossCursorColorR:= 	GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetCrossCursorColorR');
    @F_Monitor_GetCrossCursorColorR:= 	GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetCrossCursorColorR');
    @F_Monitor_SetCrossCursorColorG:= 	GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetCrossCursorColorG');
    @F_Monitor_GetCrossCursorColorG:= 	GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetCrossCursorColorG');
    @F_Monitor_SetCrossCursorColorB:= 	GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetCrossCursorColorB');
    @F_Monitor_GetCrossCursorColorB:= 	GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetCrossCursorColorB');
    @F_Monitor_SetCrossCursorColorRGB:= GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetCrossCursorColorRGB');
    @F_Monitor_GetCrossCursorColorRGB:= GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetCrossCursorColorRGB');
    @F_Monitor_SetCrossCursorPos:= 		GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetCrossCursorPos');
    @F_Monitor_GetCrossCursorPos:=		GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetCrossCursorPos');
    @F_Monitor_SetCrossCursorSize:= 	GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetCrossCursorSize');
    @F_Monitor_GetCrossCursorSize:= 	GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetCrossCursorSize');
    
    @F_Monitor_SetAutoIrisMode:= 		GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetAutoIrisMode');
    @F_Monitor_GetAutoIrisMode:= 		GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetAutoIrisMode');
    @F_Monitor_SetAutoIrisRange:=		GetProcAddress(FDLLHandle, 'ArtCam_Monitor_SetAutoIrisRange');
    @F_Monitor_GetAutoIrisRange:= 		GetProcAddress(FDLLHandle, 'ArtCam_Monitor_GetAutoIrisRange');
    @F_Monitor_LoadFirmware:=	 		GetProcAddress(FDLLHandle, 'ArtCam_Monitor_LoadFirmware');

	@F_SaveMaskFile:= 	GetProcAddress(FDLLHandle, 'ArtCam_SaveMaskFile');
	@F_LoadMaskFile:= 	GetProcAddress(FDLLHandle, 'ArtCam_LoadMaskFile');
	@F_UpdateMaskData:= GetProcAddress(FDLLHandle, 'ArtCam_UpdateMaskData');
	@F_SetPeltier:= 	GetProcAddress(FDLLHandle, 'ArtCam_SetPeltier');
	@F_GetPeltier:= 	GetProcAddress(FDLLHandle, 'ArtCam_GetPeltier');
	@F_GetTemperature:= GetProcAddress(FDLLHandle, 'ArtCam_GetTemperature');
	@F_SetDotFilter:= 	GetProcAddress(FDLLHandle, 'ArtCam_SetDotFilter');
	@F_GetDotFilter:= 	GetProcAddress(FDLLHandle, 'ArtCam_GetDotFilter');
	@F_SetMaskFilter:= 	GetProcAddress(FDLLHandle, 'ArtCam_SetMaskFilter');
	@F_GetMaskFilter:= 	GetProcAddress(FDLLHandle, 'ArtCam_GetMaskFilter');
	@F_SetInternalCorrection:= 	GetProcAddress(FDLLHandle, 'ArtCam_SetInternalCorrection');
	@F_GetInternalCorrection:= 	GetProcAddress(FDLLHandle, 'ArtCam_GetInternalCorrection');




    Result := true;
    exit;
  end;

  Result := false;
end;

procedure TArtCam.FreeLibrary;
begin
  if FDLLHandle<>0 then Windows.FreeLibrary(FDLLHandle);
  NullSet;
end;


function TArtCam.GetDllVersion: DWORD;
begin
  if @F_GetDllVersion<>nil then
  begin
    Result := F_GetDllVersion();
    exit;
  end;

  Result := 0;
end;

function TArtCam.GetLastError: LONG;
begin
  if @F_GetLastError<>nil then
  begin
    Result := F_GetLastError(SdkHandle);
    exit;
  end;

  Result := 0;
end;


function TArtCam.Initialize (hWnd: HWND): Boolean;
begin
  if @F_Release<>nil then
  begin
    SdkHandle := F_Initialize(hWnd);
    if SdkHandle<>0 then
      begin
        Result := true;
      exit;
    end;
  end;

  Result := false;
end;

function TArtCam.Release: BOOL;
begin
  if @F_Release<>nil then
  begin
    Result := F_Release(SdkHandle);
    exit;
  end;

  Result := FALSE;
end;


function TArtCam.Preview: BOOL;
begin
  if @F_Preview<>nil then
  begin
    Result := F_Preview(SdkHandle);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.RecordA (lpAviName: LPCTSTR; RecTime: UINT; fShow: BOOL): BOOL;
begin
  if @F_Record<>nil then
  begin
    Result := F_Record(SdkHandle, lpAviName, RecTime, fShow);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.CallBackPreview (hWnd: HWND; lpImage: LPBYTE; Size: LONG; TopDown: BOOL): BOOL;
begin
  if @F_CallBackPreview<>nil then
  begin
    Result := F_CallBackPreview(SdkHandle, hWnd, lpImage, Size, TopDown);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Close: BOOL;
begin
  if @F_Close<>nil then
  begin
    Result := F_Close(SdkHandle);
    exit;
  end;

  Result := FALSE;
end;


// 1230
function TArtCam.SnapShot (lpImage: LPBYTE; Size: LONG; TopDown: BOOL): BOOL;
begin
  if @F_SnapShot<>nil then
  begin
    Result := F_SnapShot(SdkHandle, lpImage, Size, TopDown);
    exit;
  end;

  Result := FALSE;
end;


// 1250
function TArtCam.Capture: BOOL;
begin
  if @F_Capture<>nil then
  begin
    Result := F_Capture(SdkHandle);
    exit;
  end;

  Result := FALSE;
end;


// 1260
function TArtCam.Trigger (hWnd: HWND; lpImage: LPBYTE; Size: LONG; TopDown: BOOL): BOOL;
begin
  if @F_Trigger<>nil then
  begin
    Result := F_Trigger(SdkHandle, hWnd, lpImage, Size, TopDown);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.SaveImage (lpSaveName: LPCTSTR; FileType: FILETYPE): BOOL;
begin
  if @F_SaveImage<>nil then
  begin
    Result := F_SaveImage(SdkHandle, lpSaveName, LONG(FileType));
    exit;
  end;

  Result := FALSE;
end;



function TArtCam.SetPreviewWindow (hWnd: HWND; Left: LONG; Top: LONG; Right: LONG; Bottom: LONG): BOOL;
begin
  if @F_SetPreviewWindow<>nil then
  begin
    Result := F_SetPreviewWindow(SdkHandle, hWnd, Left, Top, Right, Bottom);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.SetCaptureWindow (Width: LONG; Height: LONG; Fps: LONG): BOOL;
begin
  if @F_SetCaptureWindow<>nil then
  begin
    Result := F_SetCaptureWindow(SdkHandle, Width, Height, Fps);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.SetCaptureWindowEx (HTotal: LONG; HStart: LONG; HEffective: LONG; VTotal: LONG; VStart: LONG; VEffective: LONG): BOOL;
begin
  if @F_SetCaptureWindowEx<>nil then
  begin
    Result := F_SetCaptureWindowEx(SdkHandle, HTotal, HStart, HEffective, VTotal, VStart, VEffective);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetCaptureWindowEx (HTotal: LPLONG; HStart: LPLONG; HEffective: LPLONG; VTotal: LPLONG; VStart: LPLONG; VEffective: LPLONG): BOOL;
begin
  if @F_GetCaptureWindowEx<>nil then
  begin
    Result := F_GetCaptureWindowEx(SdkHandle, HTotal, HStart, HEffective, VTotal, VStart, VEffective);
    exit;
  end;

  Result := FALSE;
end;


function TArtCam.SetColorMode (ColorMode: LONG): BOOL;
begin
  if @F_SetColorMode<>nil then
  begin
    Result := F_SetColorMode(SdkHandle, ColorMode);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetColorMode: LONG;
begin
  if @F_GetColorMode<>nil then
  begin
    Result := F_GetColorMode(SdkHandle);
    exit;
  end;

  Result := 0;
end;


function TArtCam.SetCrossbar (Output: LONG; Input: LONG): BOOL;
begin
  if @F_SetCrossbar<>nil then
  begin
    Result := F_SetCrossbar(SdkHandle, Output, Input);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.SetDeviceNumber (Number: LONG): BOOL;
begin
  if @F_SetDeviceNumber<>nil then
  begin
    Result := F_SetDeviceNumber(SdkHandle, Number);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.EnumDevice (szDeviceName: DeviceNameList): LONG;
begin
  if @F_EnumDevice<>nil then
  begin
    Result := F_EnumDevice(SdkHandle, szDeviceName);
    exit;
  end;

  Result := 0;
end;

function TArtCam.GetDeviceName (index: LONG; szDeviceName: LPSTR; nSize: LONG): BOOL;
begin
  if @F_GetDeviceName<>nil then
  begin
    Result := F_GetDeviceName(SdkHandle, index, szDeviceName, nSize);
    exit;
  end;

  Result := FALSE;
end;


function TArtCam.StartPreview: BOOL;
begin
  if @F_StartPreview<>nil then
  begin
    Result := F_StartPreview(SdkHandle);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.StopPreview: BOOL;
begin
  if @F_StopPreview<>nil then
  begin
    Result := F_StopPreview(SdkHandle);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetImage (lpImage: LPBYTE; Size: LONG; TopDown: BOOL): BOOL;
begin
  if @F_GetImage<>nil then
  begin
    Result := F_GetImage(SdkHandle, lpImage, Size, TopDown);
    exit;
  end;

  Result := FALSE;
end;


function TArtCam.Width: LONG;
begin
  if @F_Width<>nil then
  begin
    Result := F_Width(SdkHandle);
    exit;
  end;

  Result := 0;
end;

function TArtCam.Height: LONG;
begin
  if @F_Height<>nil then
  begin
    Result := F_Height(SdkHandle);
    exit;
  end;

  Result := 0;
end;

function TArtCam.Fps: LONG;
begin
  if @F_Fps<>nil then
  begin
    Result := F_Fps(SdkHandle);
    exit;
  end;

  Result := 0;
end;


function TArtCam.SetCameraDlg (hWnd: HWND): BOOL;
begin
  if @F_SetCameraDlg<>nil then
  begin
    Result := F_SetCameraDlg(SdkHandle, hWnd);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.SetImageDlg (hWnd: HWND): BOOL;
begin
  if @F_SetImageDlg<>nil then
  begin
    Result := F_SetImageDlg(SdkHandle, hWnd);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.SetAnalogDlg (hWnd: HWND): BOOL;
begin
  if @F_SetAnalogDlg<>nil then
  begin
    Result := F_SetAnalogDlg(SdkHandle, hWnd);
    exit;
  end;

  Result := FALSE;
end;


// 1230
function TArtCam.SetIOPort (byteData: BYTE; longData: LONG; Reserve: DWORD): BOOL;
begin
  if @F_SetIOPort<>nil then
  begin
    Result := F_SetIOPort(SdkHandle, byteData, longData, Reserve);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetIOPort (byteData: LPBYTE; longData: LPLONG; Reserve: DWORD): BOOL;
begin
  if @F_GetIOPort<>nil then
  begin
    Result := F_GetIOPort(SdkHandle, byteData, longData, Reserve);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.SetFilterValue (FilterType: ARTCAM_FILTERTYPE; Value: LONG): BOOL;
begin
  if @F_SetFilterValue<>nil then
  begin
    Result := F_SetFilterValue(SdkHandle, LONG(FilterType), Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetFilterValue (FilterType: ARTCAM_FILTERTYPE; Error: LPBOOL): LONG;
begin
  if @F_GetFilterValue<>nil then
  begin
    Result := F_GetFilterValue(SdkHandle, LONG(FilterType), Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetSubSample (SubSampleMode: SUBSAMPLE): BOOL;
begin
  if @F_SetSubSample<>nil then
  begin
    Result := F_SetSubSample(SdkHandle, LONG(SubSampleMode));
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetSubSample: SUBSAMPLE;
begin
  if @F_GetSubSample<>nil then
  begin
    Result := SUBSAMPLE(F_GetSubSample(SdkHandle));
    exit;
  end;

  Result := SUBSAMPLE_1;
end;

function TArtCam.SetWaitTime (WaitTime: LONG): BOOL;
begin
  if @F_SetWaitTime<>nil then
  begin
    Result := F_SetWaitTime(SdkHandle, WaitTime);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetWaitTime: LONG;
begin
  if @F_GetWaitTime<>nil then
  begin
    Result := F_GetWaitTime(SdkHandle);
    exit;
  end;

  Result := 0;
end;


// 1240
function TArtCam.SetMirrorV (Flg: BOOL): BOOL;
begin
  if @F_SetMirrorV<>nil then
  begin
    Result := F_SetMirrorV(SdkHandle, Flg);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetMirrorV: BOOL;
begin
  if @F_GetMirrorV<>nil then
  begin
    Result := F_GetMirrorV(SdkHandle);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.SetMirrorH (Flg: BOOL): BOOL;
begin
  if @F_SetMirrorH<>nil then
  begin
    Result := F_SetMirrorH(SdkHandle, Flg);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetMirrorH: BOOL;
begin
  if @F_GetMirrorH<>nil then
  begin
    Result := F_GetMirrorH(SdkHandle);
    exit;
  end;

  Result := FALSE;
end;


function TArtCam.SetBrightness (Value: LONG): BOOL;
begin
  if @F_SetBrightness<>nil then
  begin
    Result := F_SetBrightness(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetBrightness (Error: LPBOOL): LONG;
begin
  if @F_GetBrightness<>nil then
  begin
    Result := F_GetBrightness(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetContrast (Value: LONG): BOOL;
begin
  if @F_SetContrast<>nil then
  begin
    Result := F_SetContrast(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetContrast (Error: LPBOOL): LONG;
begin
  if @F_GetContrast<>nil then
  begin
    Result := F_GetContrast(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetHue (Value: LONG): BOOL;
begin
  if @F_SetHue<>nil then
  begin
    Result := F_SetHue(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetHue (Error: LPBOOL): LONG;
begin
  if @F_GetHue<>nil then
  begin
    Result := F_GetHue(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetSaturation (Value: LONG): BOOL;
begin
  if @F_SetSaturation<>nil then
  begin
    Result := F_SetSaturation(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetSaturation (Error: LPBOOL): LONG;
begin
  if @F_GetSaturation<>nil then
  begin
    Result := F_GetSaturation(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetSharpness (Value: LONG): BOOL;
begin
  if @F_SetSharpness<>nil then
  begin
    Result := F_SetSharpness(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetSharpness (Error: LPBOOL): LONG;
begin
  if @F_GetSharpness<>nil then
  begin
    Result := F_GetSharpness(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetBayerGainRGB (Value: LONG): BOOL;
begin
  if @F_SetBayerGainRGB<>nil then
  begin
    Result := F_SetBayerGainRGB(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetBayerGainRGB (Error: LPBOOL): LONG;
begin
  if @F_GetBayerGainRGB<>nil then
  begin
    Result := F_GetBayerGainRGB(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetBayerGainRed (Value: LONG): BOOL;
begin
  if @F_SetBayerGainRed<>nil then
  begin
    Result := F_SetBayerGainRed(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetBayerGainRed (Error: LPBOOL): LONG;
begin
  if @F_GetBayerGainRed<>nil then
  begin
    Result := F_GetBayerGainRed(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetBayerGainGreen (Value: LONG): BOOL;
begin
  if @F_SetBayerGainGreen<>nil then
  begin
    Result := F_SetBayerGainGreen(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetBayerGainGreen (Error: LPBOOL): LONG;
begin
  if @F_GetBayerGainGreen<>nil then
  begin
    Result := F_GetBayerGainGreen(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetBayerGainBlue (Value: LONG): BOOL;
begin
  if @F_SetBayerGainBlue<>nil then
  begin
    Result := F_SetBayerGainBlue(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetBayerGainBlue (Error: LPBOOL): LONG;
begin
  if @F_GetBayerGainBlue<>nil then
  begin
    Result := F_GetBayerGainBlue(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetBayerGainAuto (Value: LONG): BOOL;
begin
  if @F_SetBayerGainAuto<>nil then
  begin
    Result := F_SetBayerGainAuto(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetBayerGainAuto (Error: LPBOOL): LONG;
begin
  if @F_GetBayerGainAuto<>nil then
  begin
    Result := F_GetBayerGainAuto(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetGamma (Value: LONG): BOOL;
begin
  if @F_SetGamma<>nil then
  begin
    Result := F_SetGamma(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetGamma (Error: LPBOOL): LONG;
begin
  if @F_GetGamma<>nil then
  begin
    Result := F_GetGamma(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetBayerMode (Value: LONG): BOOL;
begin
  if @F_SetBayerMode<>nil then
  begin
    Result := F_SetBayerMode(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetBayerMode (Error: LPBOOL): LONG;
begin
  if @F_GetBayerMode<>nil then
  begin
    Result := F_GetBayerMode(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetGlobalGain (Value: LONG): BOOL;
begin
  if @F_SetGlobalGain<>nil then
  begin
    Result := F_SetGlobalGain(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetGlobalGain (Error: LPBOOL): LONG;
begin
  if @F_GetGlobalGain<>nil then
  begin
    Result := F_GetGlobalGain(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetColorGainRed (Value: LONG): BOOL;
begin
  if @F_SetColorGainRed<>nil then
  begin
    Result := F_SetColorGainRed(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetColorGainRed (Error: LPBOOL): LONG;
begin
  if @F_GetColorGainRed<>nil then
  begin
    Result := F_GetColorGainRed(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetColorGainGreen1 (Value: LONG): BOOL;
begin
  if @F_SetColorGainGreen1<>nil then
  begin
    Result := F_SetColorGainGreen1(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetColorGainGreen1 (Error: LPBOOL): LONG;
begin
  if @F_GetColorGainGreen1<>nil then
  begin
    Result := F_GetColorGainGreen1(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetColorGainGreen2 (Value: LONG): BOOL;
begin
  if @F_SetColorGainGreen2<>nil then
  begin
    Result := F_SetColorGainGreen2(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetColorGainGreen2 (Error: LPBOOL): LONG;
begin
  if @F_GetColorGainGreen2<>nil then
  begin
    Result := F_GetColorGainGreen2(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetColorGainBlue (Value: LONG): BOOL;
begin
  if @F_SetColorGainBlue<>nil then
  begin
    Result := F_SetColorGainBlue(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetColorGainBlue (Error: LPBOOL): LONG;
begin
  if @F_GetColorGainBlue<>nil then
  begin
    Result := F_GetColorGainBlue(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetExposureTime (Value: LONG): BOOL;
begin
  if @F_SetExposureTime<>nil then
  begin
    Result := F_SetExposureTime(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetExposureTime (Error: LPBOOL): LONG;
begin
  if @F_GetExposureTime<>nil then
  begin
    Result := F_GetExposureTime(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

// 1260
function TArtCam.SetHalfClock (Value: LONG): BOOL;
begin
  if @F_SetHalfClock<>nil then
  begin
    Result := F_SetHalfClock(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetHalfClock (Error: LPBOOL): LONG;
begin
  if @F_GetHalfClock<>nil then
  begin
    Result := F_GetHalfClock(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetAutoIris (Value: LONG): BOOL;
begin
  if @F_SetAutoIris<>nil then
  begin
    Result := F_SetAutoIris(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetAutoIris (Error: LPBOOL): LONG;
begin
  if @F_GetAutoIris<>nil then
  begin
    Result := F_GetAutoIris(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;


// 1275
function TArtCam.SetSamplingRate (Value: LONG): BOOL;
begin
  if @F_SetSamplingRate<>nil then
  begin
    Result := F_SetSamplingRate(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetSamplingRate (Error: LPBOOL): LONG;
begin
  if @F_GetSamplingRate<>nil then
  begin
    Result := F_GetSamplingRate(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.GetVideoFormat (Error: LPBOOL): LONG;
begin
  if @F_GetVideoFormat<>nil then
  begin
    Result := F_GetVideoFormat(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;


// 1276
function TArtCam.WriteSromID (Address: LONG; Value: LONG): BOOL;
begin
  if @F_WriteSromID<>nil then
  begin
    Result := F_WriteSromID(SdkHandle, Address, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.ReadSromID (Address: LONG; Error: LPBOOL): LONG;
begin
  if @F_ReadSromID<>nil then
  begin
    Result := F_ReadSromID(SdkHandle, Address, Error);
    exit;
  end;

  Result := 0;
end;


// 1280
function TArtCam.GetCameraInfo (pInfo: LPCAMERAINFO): BOOL;
begin
  if @F_GetCameraInfo<>nil then
  begin
    Result := F_GetCameraInfo(SdkHandle, pInfo);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetStatus (Error: LPBOOL): LONG;
begin
  if @F_GetStatus<>nil then
  begin
    Result := F_GetStatus(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.WriteRegister (Address: BYTE; Value: DWORD): BOOL;
begin
  if @F_WriteRegister<>nil then
  begin
    Result := F_WriteRegister(SdkHandle, Address, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.ReadRegister (Address: BYTE; Error: LPBOOL): DWORD;
begin
  if @F_ReadRegister<>nil then
  begin
    Result := F_ReadRegister(SdkHandle, Address, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.WriteRegisterEx   	(Address: DWORD; Value: DWORD): BOOL;
begin
  if @F_WriteRegisterEx<>nil then
  begin
    Result := F_WriteRegisterEx(SdkHandle, Address, Value);
    exit;
  end;
  
  Result := FALSE;
end;
    
function TArtCam.ReadRegisterEx    	(Address: DWORD; Error: LPBOOL): DWORD;
begin
  if @F_ReadRegisterEx<>nil then
  begin 
    Result := F_ReadRegisterEx(SdkHandle, Address, Error);
    exit;
  end;
  
  Result := 0;
end;

function TArtCam.SetCrcCheckMode  	(Value: LONG): BOOL; 
begin
  if @F_SetCrcCheckMode<>nil then
  begin
    Result := F_SetCrcCheckMode(SdkHandle, Value);
    exit;
  end;
  
  Result := FALSE;
end;


function TArtCam.GetCrcCheckMode  	(Error: LPBOOL): LONG;
begin
  if @F_GetCrcCheckMode<>nil then
  begin
    Result := F_GetCrcCheckMode(SdkHandle, Error);
    exit;
  end;
    
  Result := 0;
end;

function TArtCam.SetLChannelValue  	(Value: LONG): BOOL; 
begin
  if @F_SetLChannelValue<>nil then
  begin
    Result := F_SetLChannelValue(SdkHandle, Value);
    exit;
  end;
  
  Result := FALSE;
end;

function TArtCam.GetLChannelValue  	(Error: LPBOOL): LONG; 
begin
  if @F_GetCrcCheckMode<>nil then
  begin
    Result := F_GetCrcCheckMode(SdkHandle, Error);
    exit;
  end;
  
  Result := 0;
end;

function TArtCam.SetChannelProfileMode	(Value: LONG): BOOL; 
Begin
  if @F_SetChannelProfileMode<>nil then
  begin
    Result := F_SetChannelProfileMode(SdkHandle, Value);
    exit;
  end;
  
  Result := FALSE;
end;
 
function TArtCam.GetChannelProfile  	(Error: LPBOOL): LONG;
Begin
  if @F_GetChannelProfile<>nil then
  begin
    Result := F_GetChannelProfile(SdkHandle, Error);
    exit;
  end;
  
  Result := 0;
end;

function TArtCam.SetGrayMode (Value: LONG): BOOL;
begin
  if @F_SetGrayMode<>nil then
  begin
    Result := F_SetGrayMode(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetGrayMode (Error: LPBOOL): LONG;
begin
  if @F_GetGrayMode<>nil then
  begin
    Result := F_GetGrayMode(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetGrayGainR (Value: LONG): BOOL;
begin
  if @F_SetGrayGainR<>nil then
  begin
    Result := F_SetGrayGainR(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetGrayGainR (Error: LPBOOL): LONG;
begin
  if @F_GetGrayGainR<>nil then
  begin
    Result := F_GetGrayGainR(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetGrayGainG1 (Value: LONG): BOOL;
begin
  if @F_SetGrayGainG1<>nil then
  begin
    Result := F_SetGrayGainG1(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetGrayGainG1 (Error: LPBOOL): LONG;
begin
  if @F_GetGrayGainG1<>nil then
  begin
    Result := F_GetGrayGainG1(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetGrayGainG2 (Value: LONG): BOOL;
begin
  if @F_SetGrayGainG2<>nil then
  begin
    Result := F_SetGrayGainG2(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetGrayGainG2 (Error: LPBOOL): LONG;
begin
  if @F_GetGrayGainG2<>nil then
  begin
    Result := F_GetGrayGainG2(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetGrayGainB (Value: LONG): BOOL;
begin
  if @F_SetGrayGainB<>nil then
  begin
    Result := F_SetGrayGainB(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetGrayGainB (Error: LPBOOL): LONG;
begin
  if @F_GetGrayGainB<>nil then
  begin
    Result := F_GetGrayGainB(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetGrayOffsetR (Value: LONG): BOOL;
begin
  if @F_SetGrayOffsetR<>nil then
  begin
    Result := F_SetGrayOffsetR(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetGrayOffsetR (Error: LPBOOL): LONG;
begin
  if @F_GetGrayOffsetR<>nil then
  begin
    Result := F_GetGrayOffsetR(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetGrayOffsetG1 (Value: LONG): BOOL;
begin
  if @F_SetGrayOffsetG1<>nil then
  begin
    Result := F_SetGrayOffsetG1(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetGrayOffsetG1 (Error: LPBOOL): LONG;
begin
  if @F_GetGrayOffsetG1<>nil then
  begin
    Result := F_GetGrayOffsetG1(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetGrayOffsetG2 (Value: LONG): BOOL;
begin
  if @F_SetGrayOffsetG2<>nil then
  begin
    Result := F_SetGrayOffsetG2(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetGrayOffsetG2 (Error: LPBOOL): LONG;
begin
  if @F_GetGrayOffsetG2<>nil then
  begin
    Result := F_GetGrayOffsetG2(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetGrayOffsetB (Value: LONG): BOOL;
begin
  if @F_SetGrayOffsetB<>nil then
  begin
    Result := F_SetGrayOffsetB(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetGrayOffsetB (Error: LPBOOL): LONG;
begin
  if @F_GetGrayOffsetB<>nil then
  begin
    Result := F_GetGrayOffsetB(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;


// SATA
function TArtCam.SetCameraType (Flg: LONG): BOOL;
begin
  if @F_SetCameraType<>nil then
  begin
    Result := F_SetCameraType(SdkHandle, Flg);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetCameraType (Error: LPBOOL): LONG;
begin
  if @F_GetCameraType<>nil then
  begin
    Result := F_GetCameraType(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetSyncV	(Flg: LONG): BOOL; 
begin
  if @F_SetSyncV<>nil then
  begin
    Result := F_SetSyncV(SdkHandle, Flg);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetSyncV	(Error: LPBOOL): LONG;
begin
  if @F_GetSyncV<>nil then
  begin
    Result := F_GetSyncV(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetSyncH	(Flg: LONG): BOOL;
begin
  if @F_SetSyncH<>nil then
  begin
    Result := F_SetSyncH(SdkHandle, Flg);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetSyncH	(Error: LPBOOL): LONG;
begin
  if @F_GetSyncH<>nil then
  begin
    Result := F_GetSyncH(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;


// MOUT
function TArtCam.Fpga_WriteRegister (Address: BYTE; Value: DWORD): BOOL;
begin
  if @F_Fpga_WriteRegister<>nil then
  begin
    Result := F_Fpga_WriteRegister(SdkHandle, Address, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Fpga_ReadRegister (Address: BYTE; Error: LPBOOL): DWORD;
begin
  if @F_Fpga_ReadRegister<>nil then
  begin
    Result := F_Fpga_ReadRegister(SdkHandle, Address, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.Monitor_SetPreviewMode (Preview: BOOL): BOOL;
begin
  if @F_Monitor_SetPreviewMode<>nil then
  begin
    Result := F_Monitor_SetPreviewMode(SdkHandle, Preview);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetPreviewMode (Error: LPBOOL): BOOL;
begin
  if @F_Monitor_GetPreviewMode<>nil then
  begin
    Result := F_Monitor_GetPreviewMode(SdkHandle, Error);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_SetPreviewSize (Width: LONG; Height: LONG): BOOL;
begin
  if @F_Monitor_SetPreviewSize<>nil then
  begin
    Result := F_Monitor_SetPreviewSize(SdkHandle, Width, Height);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetPreviewSize (LPWidth: LPLONG; LPHeight: LPLONG): BOOL;
begin
  if @F_Monitor_GetPreviewSize<>nil then
  begin
    Result := F_Monitor_GetPreviewSize(SdkHandle, LPWidth, LPHeight);
    exit;
  end;

  Result := FALSE;
end;


function TArtCam.Monitor_SetColorMode (ColorMode: BOOL): BOOL;
begin
  if @F_Monitor_SetColorMode<>nil then
  begin
    Result := F_Monitor_SetColorMode(SdkHandle, ColorMode);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetColorMode (Error: LPBOOL): BOOL;
begin
  if @F_Monitor_GetColorMode<>nil then
  begin
    Result := F_Monitor_GetColorMode(SdkHandle, Error);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_SetCameraClock (Value: LONG): BOOL;
begin
  if @F_Monitor_SetCameraClock<>nil then
  begin
    Result := F_Monitor_SetCameraClock(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetCameraClock (Error: LPBOOL): LONG;
begin
  if @F_Monitor_GetCameraClock<>nil then
  begin
    Result := F_Monitor_GetCameraClock(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.Monitor_SetBayerGainAuto (Value: LONG): BOOL;
begin
  if @F_Monitor_SetBayerGainAuto<>nil then
  begin
    Result := F_Monitor_SetBayerGainAuto(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetBayerGainAuto (Error: LPBOOL): LONG;
begin
  if @F_Monitor_GetBayerGainAuto<>nil then
  begin
    Result := F_Monitor_GetBayerGainAuto(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.Monitor_SetBayerGainLock	(Value: LONG): BOOL;
begin
  if @F_Monitor_SetBayerGainLock<>nil then
  begin
    Result := F_Monitor_SetBayerGainLock(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetBayerGainLock	(Error: LPBOOL): LONG;
begin
  if @F_Monitor_GetBayerGainLock<>nil then
  begin
    Result := F_Monitor_GetBayerGainLock(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.Monitor_SetBayerGainRed (Value: LONG): BOOL;
begin
  if @F_Monitor_SetBayerGainRed<>nil then
  begin
    Result := F_Monitor_SetBayerGainRed(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetBayerGainRed (Error: LPBOOL): LONG;
begin
  if @F_Monitor_GetBayerGainRed<>nil then
  begin
    Result := F_Monitor_GetBayerGainRed(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.Monitor_SetBayerGainGreen (Value: LONG): BOOL;
begin
  if @F_Monitor_SetBayerGainGreen<>nil then
  begin
    Result := F_Monitor_SetBayerGainGreen(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetBayerGainGreen (Error: LPBOOL): LONG;
begin
  if @F_Monitor_GetBayerGainGreen<>nil then
  begin
    Result := F_Monitor_GetBayerGainGreen(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.Monitor_SetBayerGainBlue (Value: LONG): BOOL;
begin
  if @F_Monitor_SetBayerGainBlue<>nil then
  begin
    Result := F_Monitor_SetBayerGainBlue(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetBayerGainBlue (Error: LPBOOL): LONG;
begin
  if @F_Monitor_GetBayerGainBlue<>nil then
  begin
    Result := F_Monitor_GetBayerGainBlue(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.Monitor_SaveCurrentSettings:	BOOL;
begin
  if @F_Monitor_SaveCurrentSettings<>nil then
  begin
    Result := F_Monitor_SaveCurrentSettings(SdkHandle);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_InitRegisterSettings	(Flg: LONG): BOOL;
begin
  if @F_Monitor_InitRegisterSettings<>nil then
  begin
    Result := F_Monitor_InitRegisterSettings(SdkHandle, Flg);
    exit;
  end;

  Result := FALSE;
end;
    
function TArtCam.Monitor_SetCrossCursorMode	(CursorNum: LONG; Value: LONG): BOOL;
begin
  if @F_Monitor_SetCrossCursorMode<>nil then
  begin
    Result := F_Monitor_SetCrossCursorMode(SdkHandle, CursorNum, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetCrossCursorMode	(CursorNum: LONG; Error: LPBOOL): LONG;
begin
  if @F_Monitor_GetCrossCursorMode<>nil then
  begin
    Result := F_Monitor_GetCrossCursorMode(SdkHandle, CursorNum, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.Monitor_SetCrossCursorColorR	(CursorNum: LONG; Value: LONG): BOOL;
begin
  if @F_Monitor_SetCrossCursorColorR<>nil then
  begin
    Result := F_Monitor_SetCrossCursorColorR(SdkHandle, CursorNum, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetCrossCursorColorR	(CursorNum: LONG; Error: LPBOOL): LONG;
begin
  if @F_Monitor_GetCrossCursorColorR<>nil then
  begin
    Result := F_Monitor_GetCrossCursorColorR(SdkHandle, CursorNum, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.Monitor_SetCrossCursorColorG	(CursorNum: LONG; Value: LONG): BOOL;
begin
  if @F_Monitor_SetCrossCursorColorG<>nil then
  begin
    Result := F_Monitor_SetCrossCursorColorG(SdkHandle, CursorNum, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetCrossCursorColorG	(CursorNum: LONG; Error: LPBOOL): LONG;
begin
  if @F_Monitor_GetCrossCursorColorG<>nil then
  begin
    Result := F_Monitor_GetCrossCursorColorG(SdkHandle, CursorNum, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.Monitor_SetCrossCursorColorB	(CursorNum: LONG; Value: LONG): BOOL;
begin
  if @F_Monitor_SetCrossCursorColorB<>nil then
  begin
    Result := F_Monitor_SetCrossCursorColorB(SdkHandle, CursorNum, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetCrossCursorColorB	(CursorNum: LONG; Error: LPBOOL): LONG;
begin
  if @F_Monitor_GetCrossCursorColorB<>nil then
  begin
    Result := F_Monitor_GetCrossCursorColorB(SdkHandle, CursorNum, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.Monitor_SetCrossCursorColorRGB	(CursorNum: LONG; Value: LONG): BOOL;
begin
  if @F_Monitor_SetCrossCursorColorRGB<>nil then
  begin
    Result := F_Monitor_SetCrossCursorColorRGB(SdkHandle, CursorNum, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetCrossCursorColorRGB	(CursorNum: LONG; Error: LPBOOL): LONG;
begin
  if @F_Monitor_GetCrossCursorColorRGB<>nil then
  begin
    Result := F_Monitor_GetCrossCursorColorRGB(SdkHandle, CursorNum, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.Monitor_SetCrossCursorPos	(CursorNum: LONG; ValueX: LONG; ValueY: LONG): BOOL;
begin
  if @F_Monitor_SetCrossCursorPos<>nil then
  begin
    Result := F_Monitor_SetCrossCursorPos(SdkHandle, CursorNum, ValueX, ValueY);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetCrossCursorPos	(CursorNum: LONG; ValueX: LPLONG; ValueY: LPLONG): BOOL;
begin
  if @F_Monitor_GetCrossCursorPos<>nil then
  begin
    Result := F_Monitor_GetCrossCursorPos(SdkHandle, CursorNum, ValueX, ValueY);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_SetCrossCursorSize	(CursorNum: LONG; ValueX: LONG; ValueY: LONG): BOOL;
begin
  if @F_Monitor_SetCrossCursorSize<>nil then
  begin
    Result := F_Monitor_SetCrossCursorSize(SdkHandle, CursorNum, ValueX, ValueY);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetCrossCursorSize	(CursorNum: LONG; ValueX: LPLONG; ValueY: LPLONG): BOOL;
begin
  if @F_Monitor_GetCrossCursorSize<>nil then
  begin
    Result := F_Monitor_GetCrossCursorSize(SdkHandle, CursorNum, ValueX, ValueY);
    exit;
  end;

  Result := FALSE;
end;


function TArtCam.Monitor_SetAutoIrisMode	(Value: LONG): BOOL;
begin
  if @F_Monitor_SetAutoIrisMode<>nil then
  begin
    Result := F_Monitor_SetAutoIrisMode(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetAutoIrisMode	(Error: LPBOOL): LONG;
begin
  if @F_Monitor_GetAutoIrisMode<>nil then
  begin
    Result := F_Monitor_GetAutoIrisMode(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.Monitor_SetAutoIrisRange	(Min: LONG; Max: LONG): BOOL;
begin
  if @F_Monitor_SetAutoIrisRange<>nil then
  begin
    Result := F_Monitor_SetAutoIrisRange(SdkHandle, Min, Max);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_GetAutoIrisRange	(Min: LPLONG; Max: LPLONG): BOOL;
begin
  if @F_Monitor_GetAutoIrisRange<>nil then
  begin
    Result := F_Monitor_GetAutoIrisRange(SdkHandle, Min, Max);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.Monitor_LoadFirmware		(szFileName: LPCTSTR): BOOL;
begin
  if @F_Monitor_LoadFirmware<>nil then
  begin
    Result := F_Monitor_LoadFirmware(SdkHandle, szFileName);
    exit;
  end;

  Result := FALSE;
end;

function TArtCam.GetRealExposureTime	(Error: LPBOOL):	LONG;
begin
  if @F_GetRealExposureTime<>nil then
  begin
    Result := F_GetRealExposureTime(SdkHandle, Error);
    exit;
  end;

  Result := 0;
end;

function TArtCam.SetRealExposureTime	(Value: LONG):	BOOL;
begin
  if @F_SetRealExposureTime<>nil then
  begin
    Result := F_SetRealExposureTime(SdkHandle, Value);
    exit;
  end;

  Result := FALSE;
end;
// TNIR
function TArtCam.SaveMaskFile (szFileName: LPCTSTR): BOOL;
begin
	if	@F_SaveMaskFile		<>nil then
	begin
		Result := F_SaveMaskFile(SdkHandle, szFileName);
		exit;
	end;
	Result:= FALSE;
end;

function TArtCam.LoadMaskFile (szFileName: LPCTSTR): BOOL;
begin
	if	@F_LoadMaskFile		<>nil then
	begin
		Result := F_LoadMaskFile(SdkHandle, szFileName);
		exit;
	end;

	Result:= FALSE;
end;

function TArtCam.UpdateMaskData (Flg: MASKTYPE): BOOL;
begin
	if	@F_UpdateMaskData	<>nil then
	begin
		Result := F_UpdateMaskData(SdkHandle, Flg);	
		exit;
	end;
	Result:= FALSE;
end;

function TArtCam.SetPeltier (Value: LONG): BOOL;
begin
	if	@F_SetPeltier		<>nil then
	begin
		Result := F_SetPeltier(SdkHandle, 		Value);
		exit;
	end;
	Result:= FALSE;
end;

function TArtCam.GetPeltier (Error: LPBOOL): LONG;
begin
	if	@F_GetPeltier		<>nil then
	begin
		Result := F_GetPeltier(SdkHandle, Error);
		exit;
	end;
	Result:= 0;
end;

function TArtCam.GetTemperature (Error: LPBOOL): LONG;
begin
	if	@F_GetTemperature	<>nil then
	begin
		Result := F_GetTemperature(SdkHandle, Error);
		exit;
	end;
	Result:= 0;
end;

function TArtCam.SetDotFilter (Value: LONG): BOOL;
begin
	if	@F_SetDotFilter		<>nil then
	begin
		Result := F_SetDotFilter(SdkHandle,  Value);
		exit;
	end;
	Result:= FALSE;
end;

function TArtCam.GetDotFilter (Error: LPBOOL): LONG;
begin
	if	@F_GetDotFilter		<>nil then
	begin
		Result := F_GetDotFilter(SdkHandle, 	Error);
		exit;
	end;
	Result:= 0;
end;

function TArtCam.SetMaskFilter (Value: LONG): BOOL;
begin
	if	@F_SetMaskFilter	<>nil then
	begin
		Result := F_SetMaskFilter(SdkHandle, 	Value);
		exit;
	end;
	Result:= FALSE;
end;

function TArtCam.GetMaskFilter (Error: LPBOOL): LONG;
begin
	if	@F_GetMaskFilter	<>nil then
	begin
		Result := F_GetMaskFilter(SdkHandle, Error);
		exit;
	end;
	Result:= 0;
end;


function TArtCam.SetInternalCorrection (Enable: LONG): BOOL;
begin
	if	@F_SetInternalCorrection	<>nil then
	begin
		Result := F_SetInternalCorrection(SdkHandle, 	Enable);
		exit;
	end;
	Result:= FALSE;
end;

function TArtCam.GetInternalCorrection (Error: LPBOOL): BOOL;
begin
	if	@F_GetInternalCorrection	<>nil then
	begin
		Result := F_GetInternalCorrection(SdkHandle, Error);
		exit;
	end;
	Result:= FALSE;
end;


function TArtCam.LoadConfigFile (szFileName: LPCTSTR): BOOL;
begin
	if	@F_LoadConfigFile	<>nil then
	begin
		Result := F_LoadConfigFile(SdkHandle, szFileName);
		exit;
	end;
	Result:= FALSE;
end;


function TArtCam.SetConfigFilter (Value: LONG): BOOL;
begin
	if	@F_SetConfigFilter	<>nil then
	begin
		Result := F_SetConfigFilter(SdkHandle, Value);
		exit;
	end;
	Result:= FALSE;
end;

function TArtCam.GetConfigFilter (): LONG;
begin
	if	@F_GetConfigFilter	<>nil then
	begin
		Result := F_GetConfigFilter(SdkHandle);
		exit;
	end;
	Result:= 0;
end;


end.


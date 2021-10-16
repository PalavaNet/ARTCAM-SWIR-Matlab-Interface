'=============================
'	ARTRAY Camera / Capture Module Software Developer Kit
'
'						Version 1.300		2011.9.8
'						Version 1.301		2012.12.20
'
'									(C) 2002-2011 Artray
'=============================
Imports System
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Threading

Namespace ArtCamSdk

	Public Enum DLL_MESSAGE
		WM_GRAPHNOTIFY = &H8001	 ' Not used in this version.
		WM_GRAPHPAINT			 ' Sent to application when an image is updated.
		WM_ERROR				 ' Sent to application when an error occurs
	End Enum                       
                                   
	Public Enum ARTCAM_CAMERATYPE
		ARTCAM_CAMERATYPE_DS		= 1		' DirectShow Camera
		ARTCAM_CAMERATYPE_DISABLE1	= 2		' Invalid
		ARTCAM_CAMERATYPE_USTC		= 3		' ARTUST
		ARTCAM_CAMERATYPE_CNV		= 4		' ARTCNV
		ARTCAM_CAMERATYPE_DISABLE2 	= 5		' Invalid
		ARTCAM_CAMERATYPE_130MI		= 6		' ARTCAM-130MI
		ARTCAM_CAMERATYPE_DISABLE3	= 7		' Invalid
		ARTCAM_CAMERATYPE_200MI		= 8		' ARTCAM-200MI
		ARTCAM_CAMERATYPE_300MI		= 9		' ARTCAM-300MI
		ARTCAM_CAMERATYPE_150P		= 10	' ARTCAM-150P
		ARTCAM_CAMERATYPE_320P		= 11	' ARTCAM-320P
		ARTCAM_CAMERATYPE_DISABLE4	= 12	' Invalid
		ARTCAM_CAMERATYPE_200SH		= 13	' ARTCAM-200SH
		ARTCAM_CAMERATYPE_098		= 14	' ARTCAM-098
		ARTCAM_CAMERATYPE_036MI		= 15	' ARTCAM-036MI
		ARTCAM_CAMERATYPE_500P		= 16	' ARTCAM-500P
		ARTCAM_CAMERATYPE_150P2		= 17	' ARTCAM-150P2
		ARTCAM_CAMERATYPE_036MIST	= 18	' ARTCAM-036MIST
		ARTCAM_CAMERATYPE_500MI		= 19	' ARTCAM-500MI
		ARTCAM_CAMERATYPE_DISABLE5	= 20	' Invalid
		ARTCAM_CAMERATYPE_DISABLE6	= 21	' Invalid
		ARTCAM_CAMERATYPE_150P3		= 22	' ARTCAM-150P3
		ARTCAM_CAMERATYPE_130MI_MOUT= 23	' ARTCAM-130MI MOUT
		ARTCAM_CAMERATYPE_150P3_MOUT= 24	' ARTCAM-150P3 MOUT
		ARTCAM_CAMERATYPE_267KY		= 25	' ARTCAM-267KY
		ARTCAM_CAMERATYPE_274KY		= 26	' ARTCAM-274KY
		ARTCAM_CAMERATYPE_625KY		= 27	' ARTCAM-274KY
		ARTCAM_CAMERATYPE_V135MI	= 28	' ARTCAM-V135MI
		ARTCAM_CAMERATYPE_445KY		= 29	' ARTCAM-445KY
		ARTCAM_CAMERATYPE_098II		= 30	' ARTCAM-098II
		ARTCAM_CAMERATYPE_MV413		= 31	' ARTCAM-MV413USB
		ARTCAM_CAMERATYPE_OV210		= 32	' ARTCAM-OV210
		ARTCAM_CAMERATYPE_850SH		= 33	' ARTCAM-850SH
		ARTCAM_CAMERATYPE_1251SH	= 34	' ARTCAM-1252SH
		ARTCAM_CAMERATYPE_D131		= 35	' ARTCAM-D131
		ARTCAM_CAMERATYPE_900MI		= 36	' ARTCAM-900MI
		ARTCAM_CAMERATYPE_1000MI	= 37	' ARTCAM-1000MI
		ARTCAM_CAMERATYPE_500P2		= 38	' ARTCAM-500P2
		ARTCAM_CAMERATYPE_035KY		= 39	' ARTCAM-035KY
		ARTCAM_CAMERATYPE_1000MI_HD2= 40	' ARTCAM-1000MI-HD2
		ARTCAM_CAMERATYPE_006MAT	= 41	' ARTCAM-006MAT
		ARTCAM_CAMERATYPE_150P5_HD2	= 42	' ARTCAM-150P5-HD2
		ARTCAM_CAMERATYPE_130MI_HD2	= 43	' ARTCAM-130MI-HD2

		ARTCAM_CAMERATYPE_008TNIR	= 126	' ARTCAM-008TNIR
		ARTCAM_CAMERATYPE_031TNIR	= 127	' ARTCAM-031TNIR
		ARTCAM_CAMERATYPE_0016TNIR	= 128	' ARTCAM-0016TNIR

		' SATA Series
		ARTCAM_CAMERATYPE_SATA = 201	'  SATA CAMERA

		'  USB3.0 Series
		ARTCAM_CAMERATYPE_USB3_900MI	= 301	' ARTCAM-900MI-USB3
		ARTCAM_CAMERATYPE_USB3_500MI	= 302	' ARTCAM-500MI-USB3
		ARTCAM_CAMERATYPE_USB3_150P3	= 303	' ARTCAM-150P3-USB3
		ARTCAM_CAMERATYPE_USB3_445KY	= 304	' ARTCAM-445KY2-USB3
		ARTCAM_CAMERATYPE_USB3_1400MI	= 305	' ARTCAM-1400MI-USB3
		ARTCAM_CAMERATYPE_USB3_267KY	= 306	' ARTCAM-267KY-USB3
		ARTCAM_CAMERATYPE_USB3_655KY	= 307	' ARTCAM-655KY-USB3
		ARTCAM_CAMERATYPE_USB3_274KY	= 308	' ARTCAM-274KY-USB3
		ARTCAM_CAMERATYPE_USB3_424KY	= 309	' ARTCAM-424KY-USB3
		ARTCAM_CAMERATYPE_USB3_2900KAI	= 310	' ARTCAM-2900KAI-USB3
		ARTCAM_CAMERATYPE_USB3_810KAI	= 311	' ARTCAM-810KAI-USB3
		ARTCAM_CAMERATYPE_USB3_1000MI	= 312	' ARTCAM-1000MI-USB3
		ARTCAM_CAMERATYPE_USB3_2000CMV	= 313	' ARTCAM-2000CMV-USB3
		ARTCAM_CAMERATYPE_USB3_1600KAI	= 314	' ARTCAM-1600KAI-USB3
		ARTCAM_CAMERATYPE_USB3_410KAI	= 315	' ARTCAM-410KAI-USB3
		ARTCAM_CAMERATYPE_USB3_100KAI	= 316	' ARTCAM-100KAI-USB3
		ARTCAM_CAMERATYPE_USB3_210KAI	= 317	' ARTCAM-210KAI-USB3

		' WOM Series
		ARTCAM_CAMERATYPE_036MI2_WOM	= 400	' ARTCAM-036MI WOM 
		ARTCAM_CAMERATYPE_130MI_WOM		= 401	' ARTCAM-130MI WOM 
		ARTCAM_CAMERATYPE_300MI_WOM		= 402	' ARTCAM-300MI WOM 
		ARTCAM_CAMERATYPE_500MI_WOM		= 403	' ARTCAM-500MI WOM 
		ARTCAM_CAMERATYPE_900MI_WOM		= 404	' ARTCAM-900MI WOM 
		ARTCAM_CAMERATYPE_1000MI_WOM	= 405	' ARTCAM-1000MI WOM
		ARTCAM_CAMERATYPE_1400MI_WOM	= 406	' ARTCAM-1100MI WOM
		ARTCAM_CAMERATYPE_IMX035_WOM	= 407	' ARTCAM-IMX035 WOM
		ARTCAM_CAMERATYPE_130HP_WOM		= 408	' ARTCAM-130HP WOM

		ARTCAM_CAMERATYPE_150P5_WOM		= 420	' ARTCAM-150P3 WOM 
		ARTCAM_CAMERATYPE_267KY_WOM		= 421	' ARTCAM-267KY WOM 
		ARTCAM_CAMERATYPE_274KY_WOM		= 422	' ARTCAM-274KY WOM 
		ARTCAM_CAMERATYPE_445KY2_WOM	= 423	' ARTCAM-445KY2 WOM
		ARTCAM_CAMERATYPE_500P2_WOM		= 424	' ARTCAM-500P2 WOM 
		ARTCAM_CAMERATYPE_655KY_WOM		= 425	' ARTCAM-655KY WOM 
		ARTCAM_CAMERATYPE_424KY_WOM		= 426	' ARTCAM-424KY WOM
		ARTCAM_CAMERATYPE_445KY3_WOM	= 427	' ARTCAM-445KY2 WOM
		ARTCAM_CAMERATYPE_285CX_WOM		= 428	' ARTCAM-285CX WOM
		ARTCAM_CAMERATYPE_407UV_WOM		= 429	' ARTCAM-407UV WOM
		ARTCAM_CAMERATYPE_130E2V_WOM	= 430	' ARTCAM-130E2V WOM
		ARTCAM_CAMERATYPE_130XQE_WOM	= 431	' ARTCAM-130XQE WOM
		ARTCAM_CAMERATYPE_0134AR_WOM	= 432	' ARTCAM_0134AR WOM
		ARTCAM_CAMERATYPE_092XQE_WOM	= 433	' ARTCAM-092XQE WOM
		ARTCAM_CAMERATYPE_265IMX_WOM	= 434	' ARTCAM-265IMX WOM
		ARTCAM_CAMERATYPE_264IMX_WOM	= 435	' ARTCAM-264IMX WOM
		ARTCAM_CAMERATYPE_130UV_WOM		= 436	' ARTCAM-130UV WOM
		ARTCAM_CAMERATYPE_092UV_WOM		= 437	' ARTCAM-092UV WOM

		' USB3 Type2
		ARTCAM_CAMERATYPE_500MI_USB3_T2  = 500	' ARTCAM-500MI-USB3-T2
		ARTCAM_CAMERATYPE_1000MI_USB3_T2 = 501	' ARTCAM-1000MI-USB3-T2
		ARTCAM_CAMERATYPE_1400MI_USB3_T2 = 502	' ARTCAM-1400MI-USB3-T2
		ARTCAM_CAMERATYPE_034MI_USB3_T2  = 503	' ARTCAM-034MI-USB3-T2
		ARTCAM_CAMERATYPE_178IMX_USB3_T2 = 504	' ARTCAM-178IMX-USB3-T2
		ARTCAM_CAMERATYPE_174IMX_USB3_T2 = 505	' ARTCAM-174IMX-USB3-T2

		ARTCAM_CAMERATYPE_410KAI_USB3_T2	= 509	' 
		ARTCAM_CAMERATYPE_810KAI_USB3_T2	= 510	' 
		ARTCAM_CAMERATYPE_1600KAI_USB3_T2	= 511	' 
		ARTCAM_CAMERATYPE_2900KAI_USB3_T2	= 512	' 

		ARTCAM_CAMERATYPE_130SWIR_USB3_T2	= 515
		ARTCAM_CAMERATYPE_032TNIR_USB3_T2	= 516
		ARTCAM_CAMERATYPE_009TNIR_USB3_T2	= 517
		ARTCAM_CAMERATYPE_L256TNIR_USB3_T2	= 518
		ARTCAM_CAMERATYPE_L512TNIR_USB3_T2	= 519
		ARTCAM_CAMERATYPE_131TNIR_USB3_T2	= 520

		ARTCAM_CAMERATYPE_250IMX_USB3_T2	= 522
		ARTCAM_CAMERATYPE_252IMX_USB3_T2	= 523
		ARTCAM_CAMERATYPE_264IMX_USB3_T2	= 524
		ARTCAM_CAMERATYPE_265IMX_USB3_T2	= 525
		ARTCAM_CAMERATYPE_L1024TNIR_USB3_T2	= 526
		ARTCAM_CAMERATYPE_2020UV_USB3_T2	= 527
		ARTCAM_CAMERATYPE_226IMX_USB3_T2	= 528
		ARTCAM_CAMERATYPE_990SWIR			= 534
		ARTCAM_CAMERATYPE_990SWIR_TEC		= 535
		ARTCAM_CAMERATYPE_991SWIR			= 536
		ARTCAM_CAMERATYPE_991SWIR_TEC		= 537
	End Enum

	'  SATA Camera type
	Public Enum ARTCAM_CAMERATYPE_SATA
		ARTCAM_CAMERATYPE_SATA_LVDS		= 0
		ARTCAM_CAMERATYPE_SATA_300MI	= 1
		ARTCAM_CAMERATYPE_SATA_500MI	= 2
		ARTCAM_CAMERATYPE_SATA_MV413	= 3
		ARTCAM_CAMERATYPE_SATA_800MI	= 4
		ARTCAM_CAMERATYPE_SATA_036MI	= 5
		ARTCAM_CAMERATYPE_SATA_150P		= 6
		ARTCAM_CAMERATYPE_SATA_267KY	= 7
		ARTCAM_CAMERATYPE_SATA_274KY	= 8
		ARTCAM_CAMERATYPE_SATA_625KY	= 9
		ARTCAM_CAMERATYPE_SATA_130MI	=10
		ARTCAM_CAMERATYPE_SATA_200MI	=11
	End Enum

    Public Enum VGA_MODE
        VGA_MODE_800_600 = 0    ' 800   x    600
        VGA_MODE_1024_768       '1024   x    768
        VGA_MODE_1280_1024      '1280   x   1024
        VGA_MODE_NUM
    End Enum

    Public Enum VGA_SENSOR_CLOCK
        VGA_SENSOR_CLOCK_16 = 0
        VGA_SENSOR_CLOCK_24
        VGA_SENSOR_CLOCK_48
        VGA_SENSOR_CLOCK_NUM
    End Enum


	'  Error Code
	Public Enum ARTCAMSDK_ERROR
		ARTCAMSDK_NOERROR = 0		'  Normal
		ARTCAMSDK_NOT_INITIALIZE	'  Not initialized
		ARTCAMSDK_DISABLEDDEVICE	'  Access to unavailable device was attempted
		ARTCAMSDK_CREATETHREAD		'  Failure of thread creation for capturing
		ARTCAMSDK_CREATEWINDOW		'  Window creation failed
		ARTCAMSDK_OUTOFMEMORY		'  Not enough memory for image transfer/Failure for securing memory
		ARTCAMSDK_CAMERASET			'  Error for camera (device) settings
		ARTCAMSDK_CAMERASIZE		'  Error for camera (device) size settings
		ARTCAMSDK_CAPTURE			'  Capturing failed
		ARTCAMSDK_PARAM				'  Wrong argument
		ARTCAMSDK_DIRECTSHOW		'  Directshow initialization error
		ARTCAMSDK_UNSUPPORTED		'  Not supported
		ARTCAMSDK_UNKNOWN			'  Unknow error
		ARTCAMSDK_CAPTURELOST		'  Device lost
		ARTCAMSDK_FILENOTFOUND		'  File not found
		ARTCAMSDK_FPGASET			'  FPGA settings error
        ARTCAMSDK_TRANSIMAGEFAILED  '  Failure of image transferring
	End Enum

	'  Information for transferring
	Public Structure GP_INFO
		Public lSize	As Integer	' size of struct sizeof(GP_INFO)
		Public lWidth	As Integer	' Width of image
		Public lHeight	As Integer	' Height of image
		Public lBpp		As Integer	' Byte per pixcel
		Public lFps		As Integer	' Frame rate (x10)
		Public pImage	As Byte()	' The pointer to the captured image
	End Structure

	'  Camera information
	Public Structure CAMERAINFO
		Public lSize As Integer				' Size of this struct
		Public lWidth As Integer			' H-Effective
		Public lHeight As Integer			' V-Effective
		Public lGlobalGainMin As Integer	' Min value of Global Gain (Return -1 if disabled)
		Public lGlobalGainMax As Integer	' Max value of Global Gain(Return -1 if disabled)
		Public lColorGainMin As Integer		' Min value of Color Gain(Return -1 if disabled)
		Public lColorGainMax As Integer		' Max value of Colof Gain(Return -1 if disabled)
		Public lExposureMin As Integer		' Min value of Shutter Width(Return -1 if disabled)
		Public lExposureMax As Integer		' Max value of Shutter Width(Return -1 if disabled)
		Public dExposureExMin As Double		' Min value of Shutter Width(Return -1 if disabled)
		Public dExposureExMax As Double		' Max value of Shutter Width(Return -1 if disabled)

	End Structure

	'  Type of image filter
	Public Enum ARTCAM_FILTERTYPE
		ARTCAM_FILTERTYPE_RESERVE = 0		'  Reserved
		ARTCAM_FILTERTYPE_BRIGHTNESS		'  Brightness
		ARTCAM_FILTERTYPE_CONTRAST			'  Contrast
		ARTCAM_FILTERTYPE_HUE				'  Hue
		ARTCAM_FILTERTYPE_SATURATION		'  Saturation
		ARTCAM_FILTERTYPE_SHARPNESS			'  Sharpness
		ARTCAM_FILTERTYPE_BAYER_GAIN_RGB	'  Bayer coversion color gain
		ARTCAM_FILTERTYPE_BAYER_GAIN_R		'  Color gain (red only) for bayer conversion
		ARTCAM_FILTERTYPE_BAYER_GAIN_G		'  Color gain (green only) for bayer conversion
		ARTCAM_FILTERTYPE_BAYER_GAIN_B		'  Color gain (Blue only) for bayer conversion
		ARTCAM_FILTERTYPE_BAYER_GAIN_AUTO	'  Auto white balance
		ARTCAM_FILTERTYPE_GAMMA				'  Gumma
		ARTCAM_FILTERTYPE_BAYERMODE			'  Bayer conversion mode
		ARTCAM_FILTERTYPE_GLOBAL_GAIN		'  Global gain for camera
		ARTCAM_FILTERTYPE_COLOR_GAIN_R		'  Color gain (red) for camera
		ARTCAM_FILTERTYPE_COLOR_GAIN_G1		'  Color gain (green1) for camera
		ARTCAM_FILTERTYPE_COLOR_GAIN_G2		'  Color gain (green2) for camera
		ARTCAM_FILTERTYPE_COLOR_GAIN_B		'  Color gain (blue) for camera
		ARTCAM_FILTERTYPE_EXPOSURETIME		'  Exposure time (shutter speed)
		ARTCAM_FILTERTYPE_GRAY_MODE			'  Convert mode for gray scale
		ARTCAM_FILTERTYPE_GRAY_GAIN_R		'  Color gain (red) for gray scale
		ARTCAM_FILTERTYPE_GRAY_GAIN_G1		'  Color gain (green1) for gray scale
		ARTCAM_FILTERTYPE_GRAY_GAIN_G2		'  Color gain (green2) for gray scale
		ARTCAM_FILTERTYPE_GRAY_GAIN_B		'  Color gain (blue) for gray scale
		ARTCAM_FILTERTYPE_GRAY_OFFSET_R		'  Color offset (red) for gray scale
		ARTCAM_FILTERTYPE_GRAY_OFFSET_G1	'  Color offset (green1) for gray scale
		ARTCAM_FILTERTYPE_GRAY_OFFSET_G2	'  Color offset (green2) for gray scale
		ARTCAM_FILTERTYPE_GRAY_OFFSET_B		'  Color offset (blue) for gray scale
		
		ARTCAM_FILTERTYPE_PELTIER = 100		'  Peltier control
		ARTCAM_FILTERTYPE_TEMPERATURE		'  sensor temperature (only received),
		ARTCAM_FILTERTYPE_DOTFILTER			'  pixel correction filter
		ARTCAM_FILTERTYPE_MASKFILTER		'  mask correction filter
		ARTCAM_FILTERTYPE_GAINMODE			'  High Gain, Low Gain
		
	End Enum

	'  Pixel skipping transfer mode
	Public Enum SUBSAMPLE
		SUBSAMPLE_1 = 0	'  Full size
		SUBSAMPLE_2		'  1/2
		SUBSAMPLE_4		'  1/4
		SUBSAMPLE_8		'  1/8
		BINNING_2 = 17     
		BINNING_4 = 18     
	End Enum

	'  Auto iris mode
	Public Enum AI_TYPE
		AI_NONE = 0		'  Invalid
		AI_EXPOSURE		'  Exposure time
		AI_GAIN			'  Gain
		AI_BOTH			'  Exposure time + Gain
	End Enum               
                           
	'  Convert mode for gray scale
	Public Enum GRAY_TYPE
		GRAY_NONE = 0		'  Disable
		GRAY_BAYERCONVERT	'  Calculate from Bayer array
		GRAY_GRAYSCALE		'  Get LUMA data from Color-converted image
	End Enum                   

    ' Video format
    Public Enum VIDEOFORMAT
        VIDEOFORMAT_NTSC = 0    ' NTSC
        VIDEOFORMAT_PAL         ' PAL
        VIDEOFORMAT_PALM        ' PALM
        VIDEOFORMAT_SECAM       ' SECAM
    End Enum

    ' Sampling rate
    Public Enum SAMPLING_RATE
        WIDE_HISPEED = 0    ' 
        WIDE_LOWSPEED       ' 
        NORMAL_HISPEED      ' 
        NORMAL_LOWSPEED     ' 
    End Enum

	'  Format for image saving
	Public Enum FILETYPE
		FILETYPE_BITMAP = 0	'  Bitmap saving (large size).
		FILETYPE_RAW		'  Only data is saved (large size)
		FILETYPE_JPEG_HIGH	'  Save in high-quality JPEG format (medium size). Characters and lines are distorted.
		FILETYPE_JPEG_NOMAL	'  Save in standard JPEG format (small size). Small patterns are distorted.
		FILETYPE_JPEG_LOW	'  Save in low-quality JPEG (small size). Block noise are seen.
		FILETYPE_PNG		'  Save as PNG. 16 bits image can be saved correctly. Size=Medium
		FILETYPE_TIFF		'  Save as TIFF. 16 bits image can be saved correctly. Size=Large
	End Enum                   
                               
	'*Remark*               
	' 16 bit image cannot be read in every image-processing software or in every environment.
	' 16 bit PNG and TIFF saved by this SDK can be read by our Veiwer Software Version2 or later and Adobe Photoshop6.
	' For all other software, deterioration of image or an error may be experienced.
	' Since it saves as a 16-bit gray scale picture when saved by 16-bit bitmap   The color palette etc. is not saved. 
	' Since it saves as a 16-bit gray scale picture when saved by 16-bit bitmap   The color palette etc. is not saved.
	' 
	' In case it saves by 16 bits which needs to prepare a 16-bit palette by the software side, 
	' or needs to prepare the device context of gray scale, we recommend you to save by TIFF or PNG. 
	' In JPEG, it cannot save other than a color picture. 
	' Especially about a 16-bit picture, data of 8 bits of low ranks is omitted and saved. 
	'
	'
	'
	'
    Public Enum MASKTYPE
		MASKTYPE_LOW = 0
		MASKTYPE_HIGH
	End Enum




	Public Class CArtCam

		Implements IDisposable

		<DllImport("kernel32.dll", EntryPoint:="LoadLibrary")> _
		 Private Shared Function Win32LoadLibrary(ByVal lpFileName As String) As IntPtr
		End Function
		<DllImport("kernel32.dll", EntryPoint:="GetProcAddress")> _
		 Private Shared Function Win32GetProcAddress(ByVal hModule As IntPtr, ByVal lpProcName As String) As IntPtr
		End Function
		<DllImport("kernel32.dll", EntryPoint:="GetLastError")> _
		 Private Shared Function Win32GetLastError() As Integer
		End Function
		<DllImport("kernel32.dll", EntryPoint:="FreeLibrary")> _
		 Private Shared Function Win32FreeLibrary(ByVal hModule As IntPtr) As Boolean
		End Function



        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETDLLVERSION	()							As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETLASTERROR		(ByVal hACam As Integer)	As Integer

        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_INITIALIZE		(ByVal hWnd As IntPtr)		As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_RELEASE			(ByVal hACam As Integer)	As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_PREVIEW			(ByVal hACam As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_RECORD			(ByVal hACam As Integer, ByVal lpAviName As String, ByVal RecTime As Integer, ByVal fShow As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_CALLBACKPREVIEWA	(ByVal hACam As Integer, ByVal hWnd As IntPtr, ByVal lpImage As Byte(), ByVal Size As Integer, ByVal TopDown As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_CALLBACKPREVIEWP	(ByVal hACam As Integer, ByVal hWnd As IntPtr, ByVal lpImage As IntPtr, ByVal Size As Integer, ByVal TopDown As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SNAPSHOTA		(ByVal hACam As Integer, ByVal lpImage As Byte(), ByVal Size As Integer, ByVal TopDown As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SNAPSHOTP		(ByVal hACam As Integer, ByVal lpImage As IntPtr, ByVal Size As Integer, ByVal TopDown As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_CLOSE			(ByVal hACam As Integer) As Integer

        ' 1250
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_CAPTURE			(ByVal hACam As Integer) As Integer
                                  
        ' 1260                    
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_TRIGGERA				(ByVal hACam As Integer, ByVal hWnd As IntPtr, ByVal lpImage As Byte(), ByVal Size As Integer, ByVal TopDown As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_TRIGGERP				(ByVal hACam As Integer, ByVal hWnd As IntPtr, ByVal lpImage As IntPtr, ByVal Size As Integer, ByVal TopDown As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SAVEIMAGE			(ByVal hACam As Integer, ByVal lpSaveName As String, ByVal FileType As FILETYPE) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETPREVIEWWINDOW		(ByVal hACam As Integer, ByVal hWnd As IntPtr, ByVal Left As Integer, ByVal Top As Integer, ByVal Right As Integer, ByVal Bottom As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETCAPTUREWINDOW		(ByVal hACam As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Frame As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETCAPTUREWINDOWEX	(ByVal hACam As Integer, ByVal HTotal As Integer, ByVal HStart As Integer, ByVal HEffective As Integer, ByVal VTotal As Integer, ByVal VStart As Integer, ByVal VEffective As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETCAPTUREWINDOWEX	(ByVal hACam As Integer, ByRef HTotal As Integer, ByRef HStart As Integer, ByRef HEffective As Integer, ByRef VTotal As Integer, ByRef VStart As Integer, ByRef VEffective As Integer) As Integer

        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETCOLORMODE			(ByVal hACam As Integer, ByVal ColorMode As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETCOLORMODE			(ByVal hACam As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETCROSSBAR			(ByVal hACam As Integer, ByVal Output As Integer, ByVal Input As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETDEVICENUMBER		(ByVal hACam As Integer, ByVal Number As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_ENUMDEVICE			(ByVal hACam As Integer, ByVal szDeviceName As StringBuilder) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETDEVICENAME		(ByVal hACam As Integer, ByVal index As Integer, ByVal szDeviceName As System.Text.StringBuilder, ByVal Size As Integer) As Integer

        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_STARTPREVIEW			(ByVal hACam As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_STOPPREVIEW			(ByVal hACam As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETIMAGEA			(ByVal hACam As Integer, ByVal lpImage As Byte(), ByVal Size As Integer, ByVal TopDown As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETIMAGEP			(ByVal hACam As Integer, ByVal lpImage As IntPtr, ByVal Size As Integer, ByVal TopDown As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_WIDTH				(ByVal hACam As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_HEIGHT				(ByVal hACam As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_FPS					(ByVal hACam As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETCAMERADLG			(ByVal hACam As Integer, ByVal hWnd As IntPtr) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETIMAGEDLG			(ByVal hACam As Integer, ByVal hWnd As IntPtr) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETANALOGDLG			(ByVal hACam As Integer, ByVal hWnd As IntPtr) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETIOPORT			(ByVal hACam As Integer, ByVal byteData As Integer, ByVal longData As Integer, ByVal Reserve As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETIOPORT			(ByVal hACam As Integer, ByRef byteData As Byte, ByRef longData As Integer, ByVal Reserve As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETFILTERVALUE		(ByVal hACam As Integer, ByVal FilterType As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETFILTERVALUE		(ByVal hACam As Integer, ByVal FilterType As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETSUBSAMPLE			(ByVal hACam As Integer, ByVal SubSampleMode As SUBSAMPLE) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETSUBSAMPLE			(ByVal hACam As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETWAITTIME			(ByVal hACam As Integer, ByVal WaitTime As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETWAITTIME			(ByVal hACam As Integer) As Integer
                                  
        ' 1240                    
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETMIRRORV			(ByVal hACam As Integer, ByVal Flg As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETMIRRORV			(ByVal hACam As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETMIRRORH			(ByVal hACam As Integer, ByVal Flg As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETMIRRORH			(ByVal hACam As Integer) As Integer

        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETBRIGHTNESS		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETBRIGHTNESS		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETCONTRAST			(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETCONTRAST			(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETHUE				(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETHUE				(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETSATURATION		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETSATURATION		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETSHARPNESS			(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETSHARPNESS			(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETBAYERGAINRGB		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETBAYERGAINRGB		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETBAYERGAINRED		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETBAYERGAINRED		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETBAYERGAINGREEN	(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETBAYERGAINGREEN	(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETBAYERGAINBLUE		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETBAYERGAINBLUE		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETBAYERGAINAUTO		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETBAYERGAINAUTO		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETGAMMA				(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETGAMMA				(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETBAYERMODE			(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETBAYERMODE			(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETGLOBALGAIN		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETGLOBALGAIN		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETCOLORGAINRED		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETCOLORGAINRED		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETCOLORGAINGREEN1	(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETCOLORGAINGREEN1	(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETCOLORGAINGREEN2	(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETCOLORGAINGREEN2	(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETCOLORGAINBLUE		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETCOLORGAINBLUE		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETEXPOSURETIME		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETEXPOSURETIME		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        ' 1260                    
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETHALFCLOCK			(ByVal hACam As Integer, ByVal Value As Integer) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETHALFCLOCK			(ByVal hACam As Integer, ByRef pError As Integer) As Integer
                                  
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETAUTOIRIS			(ByVal hACam As Integer, ByVal Value As AI_TYPE) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETAUTOIRIS			(ByVal hACam As Integer, ByRef pError As Integer) As AI_TYPE
                                  
        ' 1275                    
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETSAMPLINGRATE		(ByVal hACam As Integer, ByVal Value As SAMPLING_RATE) As Integer
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETSAMPLINGRATE		(ByVal hACam As Integer, ByRef pError As Integer) As SAMPLING_RATE
        <UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETVIDEOFORMAT		(ByVal hACam As Integer, ByRef pError As Integer) As VIDEOFORMAT
		                            
		' 1276                    
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_WRITESROMID			(ByVal hACam As Integer, ByVal Address As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_READSROMID			(ByVal hACam As Integer, ByVal Address As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETCAMERAINFO		(ByVal hACam As Integer, ByRef pInfo As CAMERAINFO) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETSTATUS			(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_WRITEREGISTER		(ByVal hACam As Integer, ByVal Address As Byte, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_READREGISTER			(ByVal hACam As Integer, ByVal Address As Byte, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_WRITEREGISTEREX		(ByVal hACam As Integer, ByVal Address As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_READREGISTEREX		(ByVal hACam As Integer, ByVal Address As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETGRAYMODE			(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETGRAYMODE			(ByVal hACam As Integer, ByRef pError As Integer) As Integer

		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETGRAYGAINR			(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETGRAYGAINR			(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETGRAYGAING1		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETGRAYGAING1		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETGRAYGAING2		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETGRAYGAING2		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETGRAYGAINB			(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETGRAYGAINB			(ByVal hACam As Integer, ByRef pError As Integer) As Integer

		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETGRAYOFFSETR		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETGRAYOFFSETR		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETGRAYOFFSETG1		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETGRAYOFFSETG1		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETGRAYOFFSETG2		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETGRAYOFFSETG2		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETGRAYOFFSETB		(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETGRAYOFFSETB		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETCAMERATYPE		(ByVal hACam As Integer, ByVal Flg As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETCAMERATYPE		(ByVal hACam As Integer, ByRef pError As Integer) As Integer

		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETSYNCV				(ByVal hACam As Integer, ByVal Flg As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETSYNCV				(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETSYNCH				(ByVal hACam As Integer, ByVal Flg As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETSYNCH				(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_FPGA_WRITEREGISTER	(ByVal hACam As Integer, ByVal Address As Byte, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_FPGA_READREGISTER	(ByVal hACam As Integer, ByVal Address As Byte, ByRef pError As Integer) As Integer

		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETPREVIEWMODE	(ByVal hACam As Integer, ByVal Preview As Boolean) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETPREVIEWMODE	(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETPREVIEWSIZE	(ByVal hACam As Integer, ByVal Width As Integer, ByVal Height As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETPREVIEWSIZE	(ByVal hACam As Integer, ByRef Width As Integer, ByRef Height As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETCOLORMODE		(ByVal hACam As Integer, ByVal ColorMode As Boolean) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETCOLORMODE		(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETCAMERACLOCK	(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETCAMERACLOCK	(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETBAYERGAINAUTO	(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETBAYERGAINAUTO	(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETBAYERGAINLOCK	(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETBAYERGAINLOCK	(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETBAYERGAINRED	(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETBAYERGAINRED	(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETBAYERGAINGREEN(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETBAYERGAINGREEN(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETBAYERGAINBLUE	(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETBAYERGAINBLUE	(ByVal hACam As Integer, ByRef pError As Integer) As Integer
	                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SAVECURRENTSETTINGS		(ByVal hACam As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_INITREGISTERSETTINGS		(ByVal hACam As Integer, ByVal Flg As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETCROSSCURSORMODE		(ByVal hACam As Integer, ByVal CursorNum As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETCROSSCURSORMODE		(ByVal hACam As Integer, ByVal CursorNum As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETCROSSCURSORCOLORR		(ByVal hACam As Integer, ByVal CursorNum As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETCROSSCURSORCOLORR		(ByVal hACam As Integer, ByVal CursorNum As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETCROSSCURSORCOLORG		(ByVal hACam As Integer, ByVal CursorNum As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETCROSSCURSORCOLORG		(ByVal hACam As Integer, ByVal CursorNum As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETCROSSCURSORCOLORB		(ByVal hACam As Integer, ByVal CursorNum As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETCROSSCURSORCOLORB		(ByVal hACam As Integer, ByVal CursorNum As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETCROSSCURSORCOLORRGB	(ByVal hACam As Integer, ByVal CursorNum As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETCROSSCURSORCOLORRGB	(ByVal hACam As Integer, ByVal CursorNum As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETCROSSCURSORPOS		(ByVal hACam As Integer, ByVal CursorNum As Integer, ByVal ValueX As Integer, ByVal ValueY As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETCROSSCURSORPOS		(ByVal hACam As Integer, ByVal CursorNum As Integer, ByRef ValueX As Integer, ByRef ValueY As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETCROSSCURSORSIZE		(ByVal hACam As Integer, ByVal CursorNum As Integer, ByVal ValueX As Integer, ByVal ValueY As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETCROSSCURSORSIZE		(ByVal hACam As Integer, ByVal CursorNum As Integer, ByRef ValueX As Integer, ByRef ValueY As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETAUTOIRISMODE			(ByVal hACam As Integer, ByVal Value As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETAUTOIRISMODE			(ByVal hACam As Integer, ByRef pError As Integer) As Integer
		                            
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_SETAUTOIRISRANGE			(ByVal hACam As Integer, ByVal Min As Integer, ByVal Max As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_GETAUTOIRISRANGE			(ByVal hACam As Integer, ByRef Min As Integer, ByRef Max As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_MONITOR_LOADFIRMWARE				(ByVal hACam As Integer, ByVal szFileName As StringBuilder) As Integer

		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETREALEXPOSURETIME				(ByVal hACam As Integer, ByRef outError As Integer) As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETREALEXPOSURETIME				(ByVal hACam As Integer, ByVal Value As Integer) As Integer

		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SAVEMASKFILE						(ByVal hACam As Integer, ByVal szFileName As StringBuilder)	As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_LOADMASKFILE						(ByVal hACam As Integer, ByVal szFileName As StringBuilder)	As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_UPDATEMASKDATA					(ByVal hACam As Integer, ByVal Flg As MASKTYPE)				As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETPELTIER						(ByVal hACam As Integer, ByVal Value As Integer)			As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETPELTIER						(ByVal hACam As Integer, ByRef pError As Integer)			As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETTEMPERATURE					(ByVal hACam As Integer, ByRef pError As Integer)			As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETDOTFILTER						(ByVal hACam As Integer, ByVal Value As Integer)			As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETDOTFILTER						(ByVal hACam As Integer, ByRef pError As Integer)			As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETMASKFILTER					(ByVal hACam As Integer, ByVal Value As Integer)			As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETMASKFILTER					(ByVal hACam As Integer, ByRef pError As Integer)			As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETINTERNALCORRECTION			(ByVal hACam As Integer, ByVal Enable As Integer)			As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETINTERNALCORRECTION			(ByVal hACam As Integer, ByRef pError As Integer)			As Integer

		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_LOADCONFIGFILE					(ByVal hACam As Integer, ByVal szFileName As StringBuilder)	As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETCONFIGFILTER					(ByVal hACam As Integer, ByVal Value As Integer)			As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETCONFIGFILTER					(ByVal hACam As Integer)			As Integer

		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETTEMPERATUREEX					(ByVal hACam As Integer, ByRef pError As Integer)			As Double
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_SETEXPOSURETIMEEX				(ByVal hACam As Integer, ByVal Enable As Double)			As Integer
		<UnmanagedFunctionPointer(CallingConvention.Cdecl)> Private Delegate Function DELEGATE_GETEXPOSURETIMEEX				(ByVal hACam As Integer, ByRef pError As Integer)			As Double

		Private m_hArtCamSdk As IntPtr = IntPtr.Zero
		Private m_hACam As Integer = 0
		Public m_Error As Integer = 1


		Private m_GetDllVersion As DELEGATE_GETDLLVERSION
		Private m_GetLastError As DELEGATE_GETLASTERROR

		Private m_Initialize As DELEGATE_INITIALIZE
		Private m_Release As DELEGATE_RELEASE
		Private m_Preview As DELEGATE_PREVIEW
		Private m_Record As DELEGATE_RECORD
		Private m_CallBackPreviewA As DELEGATE_CALLBACKPREVIEWA
		Private m_CallBackPreviewP As DELEGATE_CALLBACKPREVIEWP
		Private m_SnapShotA As DELEGATE_SNAPSHOTA
		Private m_SnapShotP As DELEGATE_SNAPSHOTP
		Private m_Close As DELEGATE_CLOSE
		Private m_Capture As DELEGATE_CAPTURE
		Private m_TriggerA As DELEGATE_TRIGGERA
		Private m_TriggerP As DELEGATE_TRIGGERP
		Private m_SaveImage As DELEGATE_SAVEIMAGE

		Private m_SetPreviewWindow As DELEGATE_SETPREVIEWWINDOW
		Private m_SetCaptureWindow As DELEGATE_SETCAPTUREWINDOW
		Private m_SetCaptureWindowEx As DELEGATE_SETCAPTUREWINDOWEX
		Private m_GetCaptureWindowEx As DELEGATE_GETCAPTUREWINDOWEX

		Private m_SetColorMode As DELEGATE_SETCOLORMODE
		Private m_GetColorMode As DELEGATE_GETCOLORMODE

		Private m_SetCrossbar As DELEGATE_SETCROSSBAR
		Private m_SetDeviceNumber As DELEGATE_SETDEVICENUMBER
		Private m_EnumDevice As DELEGATE_ENUMDEVICE
		Private m_GetDeviceName As DELEGATE_GETDEVICENAME

		Private m_StartPreview As DELEGATE_STARTPREVIEW
		Private m_StopPreview As DELEGATE_STOPPREVIEW
		Private m_GetImageA As DELEGATE_GETIMAGEA
		Private m_GetImageP As DELEGATE_GETIMAGEP

		Private m_Width As DELEGATE_WIDTH
		Private m_Height As DELEGATE_HEIGHT
		Private m_Fps As DELEGATE_FPS

		Private m_SetCameraDlg As DELEGATE_SETCAMERADLG
		Private m_SetImageDlg As DELEGATE_SETIMAGEDLG
		Private m_SetAnalogDlg As DELEGATE_SETANALOGDLG

		Private m_SetIOPort As DELEGATE_SETIOPORT
		Private m_GetIOPort As DELEGATE_GETIOPORT
		Private m_SetFilterValue As DELEGATE_SETFILTERVALUE
		Private m_GetFilterValue As DELEGATE_GETFILTERVALUE

		Private m_SetSubSample As DELEGATE_SETSUBSAMPLE
		Private m_GetSubSample As DELEGATE_GETSUBSAMPLE
		Private m_SetWaitTime As DELEGATE_SETWAITTIME
		Private m_GetWaitTime As DELEGATE_GETWAITTIME

		Private m_SetMirrorV As DELEGATE_SETMIRRORV
		Private m_GetMirrorV As DELEGATE_GETMIRRORV
		Private m_SetMirrorH As DELEGATE_SETMIRRORH
		Private m_GetMirrorH As DELEGATE_GETMIRRORH

		Private m_SetBrightness As DELEGATE_SETBRIGHTNESS
		Private m_GetBrightness As DELEGATE_GETBRIGHTNESS
		Private m_SetContrast As DELEGATE_SETCONTRAST
		Private m_GetContrast As DELEGATE_GETCONTRAST
		Private m_SetHue As DELEGATE_SETHUE
		Private m_GetHue As DELEGATE_GETHUE
		Private m_SetSaturation As DELEGATE_SETSATURATION
		Private m_GetSaturation As DELEGATE_GETSATURATION
		Private m_SetSharpness As DELEGATE_SETSHARPNESS
		Private m_GetSharpness As DELEGATE_GETSHARPNESS
		Private m_SetBayerGainRGB As DELEGATE_SETBAYERGAINRGB
		Private m_GetBayerGainRGB As DELEGATE_GETBAYERGAINRGB
		Private m_SetBayerGainRed As DELEGATE_SETBAYERGAINRED
		Private m_GetBayerGainRed As DELEGATE_GETBAYERGAINRED
		Private m_SetBayerGainGreen As DELEGATE_SETBAYERGAINGREEN
		Private m_GetBayerGainGreen As DELEGATE_GETBAYERGAINGREEN
		Private m_SetBayerGainBlue As DELEGATE_SETBAYERGAINBLUE
		Private m_GetBayerGainBlue As DELEGATE_GETBAYERGAINBLUE
		Private m_SetBayerGainAuto As DELEGATE_SETBAYERGAINAUTO
		Private m_GetBayerGainAuto As DELEGATE_GETBAYERGAINAUTO
		Private m_SetGamma As DELEGATE_SETGAMMA
		Private m_GetGamma As DELEGATE_GETGAMMA
		Private m_SetBayerMode As DELEGATE_SETBAYERMODE
		Private m_GetBayerMode As DELEGATE_GETBAYERMODE

		Private m_SetGlobalGain As DELEGATE_SETGLOBALGAIN
		Private m_GetGlobalGain As DELEGATE_GETGLOBALGAIN
		Private m_SetColorGainRed As DELEGATE_SETCOLORGAINRED
		Private m_GetColorGainRed As DELEGATE_GETCOLORGAINRED
		Private m_SetColorGainGreen1 As DELEGATE_SETCOLORGAINGREEN1
		Private m_GetColorGainGreen1 As DELEGATE_GETCOLORGAINGREEN1
		Private m_SetColorGainGreen2 As DELEGATE_SETCOLORGAINGREEN2
		Private m_GetColorGainGreen2 As DELEGATE_GETCOLORGAINGREEN2
		Private m_SetColorGainBlue As DELEGATE_SETCOLORGAINBLUE
		Private m_GetColorGainBlue As DELEGATE_GETCOLORGAINBLUE
		Private m_SetExposureTime As DELEGATE_SETEXPOSURETIME
		Private m_GetExposureTime As DELEGATE_GETEXPOSURETIME

		Private m_SetHalfClock As DELEGATE_SETHALFCLOCK
		Private m_GetHalfClock As DELEGATE_GETHALFCLOCK
		Private m_SetAutoIris As DELEGATE_SETAUTOIRIS
		Private m_GetAutoIris As DELEGATE_GETAUTOIRIS

		Private m_SetSamplingRate As DELEGATE_SETSAMPLINGRATE
		Private m_GetSamplingRate As DELEGATE_GETSAMPLINGRATE
		Private m_GetVideoFormat As DELEGATE_GETVIDEOFORMAT

		Private m_WriteSromID As DELEGATE_WRITESROMID
		Private m_ReadSromID As DELEGATE_READSROMID

		Private m_GetCameraInfo As DELEGATE_GETCAMERAINFO
		Private m_GetStatus As DELEGATE_GETSTATUS

		Private m_WriteRegister As DELEGATE_WRITEREGISTER
		Private m_ReadRegister As DELEGATE_READREGISTER

		Private m_WriteRegisterEx As DELEGATE_WRITEREGISTEREX
		Private m_ReadRegisterEx As DELEGATE_READREGISTEREX

		Private m_SetGrayMode As DELEGATE_SETGRAYMODE
		Private m_GetGrayMode As DELEGATE_GETGRAYMODE
		Private m_SetGrayGainR As DELEGATE_SETGRAYGAINR
		Private m_GetGrayGainR As DELEGATE_GETGRAYGAINR
		Private m_SetGrayGainG1 As DELEGATE_SETGRAYGAING1
		Private m_GetGrayGainG1 As DELEGATE_GETGRAYGAING1
		Private m_SetGrayGainG2 As DELEGATE_SETGRAYGAING2
		Private m_GetGrayGainG2 As DELEGATE_GETGRAYGAING2
		Private m_SetGrayGainB As DELEGATE_SETGRAYGAINB
		Private m_GetGrayGainB As DELEGATE_GETGRAYGAINB
		Private m_SetGrayOffsetR As DELEGATE_SETGRAYOFFSETR
		Private m_GetGrayOffsetR As DELEGATE_GETGRAYOFFSETR
		Private m_SetGrayOffsetG1 As DELEGATE_SETGRAYOFFSETG1
		Private m_GetGrayOffsetG1 As DELEGATE_GETGRAYOFFSETG1
		Private m_SetGrayOffsetG2 As DELEGATE_SETGRAYOFFSETG2
		Private m_GetGrayOffsetG2 As DELEGATE_GETGRAYOFFSETG2
		Private m_SetGrayOffsetB As DELEGATE_SETGRAYOFFSETB
		Private m_GetGrayOffsetB As DELEGATE_GETGRAYOFFSETB

		Private m_SetCameraType As DELEGATE_SETCAMERATYPE
		Private m_GetCameraType As DELEGATE_GETCAMERATYPE

		Private m_SetSyncV As DELEGATE_SETSYNCV
		Private m_GetSyncV As DELEGATE_GETSYNCV
		Private m_SetSyncH As DELEGATE_SETSYNCH
		Private m_GetSyncH As DELEGATE_GETSYNCH

		Private m_Fpga_WriteRegister As DELEGATE_FPGA_WRITEREGISTER
		Private m_Fpga_ReadRegister As DELEGATE_FPGA_READREGISTER

		Private m_Monitor_SetPreviewMode As DELEGATE_MONITOR_SETPREVIEWMODE
		Private m_Monitor_GetPreviewMode As DELEGATE_MONITOR_GETPREVIEWMODE
		Private m_Monitor_SetPreviewSize As DELEGATE_MONITOR_SETPREVIEWSIZE
		Private m_Monitor_GetPreviewSize As DELEGATE_MONITOR_GETPREVIEWSIZE
		Private m_Monitor_SetColorMode As DELEGATE_MONITOR_SETCOLORMODE
		Private m_Monitor_GetColorMode As DELEGATE_MONITOR_GETCOLORMODE
		Private m_Monitor_SetCameraClock As DELEGATE_MONITOR_SETCAMERACLOCK
		Private m_Monitor_GetCameraClock As DELEGATE_MONITOR_GETCAMERACLOCK
		Private m_Monitor_SetBayerGainAuto As DELEGATE_MONITOR_SETBAYERGAINAUTO
		Private m_Monitor_GetBayerGainAuto As DELEGATE_MONITOR_GETBAYERGAINAUTO
		Private m_Monitor_SetBayerGainLock As DELEGATE_MONITOR_SETBAYERGAINLOCK
		Private m_Monitor_GetBayerGainLock As DELEGATE_MONITOR_GETBAYERGAINLOCK
		Private m_Monitor_SetBayerGainRed As DELEGATE_MONITOR_SETBAYERGAINRED
		Private m_Monitor_GetBayerGainRed As DELEGATE_MONITOR_GETBAYERGAINRED
		Private m_Monitor_SetBayerGainGreen As DELEGATE_MONITOR_SETBAYERGAINGREEN
		Private m_Monitor_GetBayerGainGreen As DELEGATE_MONITOR_GETBAYERGAINGREEN
		Private m_Monitor_SetBayerGainBlue As DELEGATE_MONITOR_SETBAYERGAINBLUE
		Private m_Monitor_GetBayerGainBlue As DELEGATE_MONITOR_GETBAYERGAINBLUE

		Private m_Monitor_SaveCurrentSettings As DELEGATE_MONITOR_SAVECURRENTSETTINGS
		Private m_Monitor_InitRegisterSettings As DELEGATE_MONITOR_INITREGISTERSETTINGS
		Private m_Monitor_SetCrossCursorMode As DELEGATE_MONITOR_SETCROSSCURSORMODE
		Private m_Monitor_GetCrossCursorMode As DELEGATE_MONITOR_GETCROSSCURSORMODE
		Private m_Monitor_SetCrossCursorColorR As DELEGATE_MONITOR_SETCROSSCURSORCOLORR
		Private m_Monitor_GetCrossCursorColorR As DELEGATE_MONITOR_GETCROSSCURSORCOLORR
		Private m_Monitor_SetCrossCursorColorG As DELEGATE_MONITOR_SETCROSSCURSORCOLORG
		Private m_Monitor_GetCrossCursorColorG As DELEGATE_MONITOR_GETCROSSCURSORCOLORG
		Private m_Monitor_SetCrossCursorColorB As DELEGATE_MONITOR_SETCROSSCURSORCOLORB
		Private m_Monitor_GetCrossCursorColorB As DELEGATE_MONITOR_GETCROSSCURSORCOLORB
		Private m_Monitor_SetCrossCursorColorRGB As DELEGATE_MONITOR_SETCROSSCURSORCOLORRGB
		Private m_Monitor_GetCrossCursorColorRGB As DELEGATE_MONITOR_GETCROSSCURSORCOLORRGB
		Private m_Monitor_SetCrossCursorPos As DELEGATE_MONITOR_SETCROSSCURSORPOS
		Private m_Monitor_GetCrossCursorPos As DELEGATE_MONITOR_GETCROSSCURSORPOS
		Private m_Monitor_SetCrossCursorSize As DELEGATE_MONITOR_SETCROSSCURSORSIZE
		Private m_Monitor_GetCrossCursorSize As DELEGATE_MONITOR_GETCROSSCURSORSIZE

		Private m_Monitor_SetAutoIrisMode As DELEGATE_MONITOR_SETAUTOIRISMODE
		Private m_Monitor_GetAutoIrisMode As DELEGATE_MONITOR_GETAUTOIRISMODE
		Private m_Monitor_SetAutoIrisRange As DELEGATE_MONITOR_SETAUTOIRISRANGE
		Private m_Monitor_GetAutoIrisRange As DELEGATE_MONITOR_GETAUTOIRISRANGE
		Private m_Monitor_LoadFirmware As DELEGATE_MONITOR_LOADFIRMWARE

		Private m_GetRealExposureTime As DELEGATE_GETREALEXPOSURETIME
		Private m_SetRealExposureTime As DELEGATE_SETREALEXPOSURETIME

		Private m_SaveMaskFile As DELEGATE_SAVEMASKFILE
		Private m_LoadMaskFile As DELEGATE_LOADMASKFILE
		Private m_UpdateMaskData As DELEGATE_UPDATEMASKDATA
                                        
		Private m_SetPeltier As DELEGATE_SETPELTIER
		Private m_GetPeltier As DELEGATE_GETPELTIER
		Private m_GetTemperature As DELEGATE_GETTEMPERATURE
		Private m_SetDotFilter As DELEGATE_SETDOTFILTER
		Private m_GetDotFilter As DELEGATE_GETDOTFILTER
		Private m_SetMaskFilter As DELEGATE_SETMASKFILTER
		Private m_GetMaskFilter As DELEGATE_GETMASKFILTER
		Private m_SetInternalCorrection As DELEGATE_SETINTERNALCORRECTION
		Private m_GetInternalCorrection As DELEGATE_GETINTERNALCORRECTION

		Private m_LoadConfigFile As DELEGATE_LOADCONFIGFILE	
		Private m_SetConfigFilter As DELEGATE_SETCONFIGFILTER
		Private m_GetConfigFilter As DELEGATE_GETCONFIGFILTER

		Private m_GetTemperatureEx As DELEGATE_GETTEMPERATUREEX
		Private m_SetExposureTimeEx As DELEGATE_SETEXPOSURETIMEEX
		Private m_GetExposureTimeEx As DELEGATE_GETEXPOSURETIMEEX


		Private disposedValue As Boolean = False 

		Public Sub New()
			NothingSet()
		End Sub

		' IDisposable
		Protected Overridable Sub Dispose(ByVal disposing As Boolean)
			If Not Me.disposedValue Then
				If disposing Then
					FreeLibrary()
				End If

			End If
			Me.disposedValue = True
		End Sub

#Region " IDisposable Support "
		Public Sub Dispose() Implements IDisposable.Dispose
			Dispose(True)
			GC.SuppressFinalize(Me)
		End Sub
#End Region

		Public Function IsInit() As Boolean
			Return IsValid(m_hArtCamSdk)
		End Function

		Protected Function IsValid(ByVal p As IntPtr) As Boolean
			Return IIf((p.Equals(IntPtr.Zero)), False, True)
		End Function

		Protected Function NothingSet() As Integer
			m_hArtCamSdk = IntPtr.Zero
			m_hACam = 0
			m_Error = 1

			m_GetDllVersion = Nothing
			m_GetLastError = Nothing
			m_Initialize = Nothing
			m_Release = Nothing
			m_Preview = Nothing
			m_Record = Nothing
			m_CallBackPreviewA = Nothing
			m_CallBackPreviewP = Nothing
			m_SnapShotA = Nothing
			m_SnapShotP = Nothing
			m_Close = Nothing
			m_Capture = Nothing
			m_TriggerA = Nothing
			m_TriggerP = Nothing
			m_SaveImage = Nothing

			m_SetPreviewWindow = Nothing
			m_SetCaptureWindow = Nothing
			m_SetCaptureWindowEx = Nothing
			m_GetCaptureWindowEx = Nothing

			m_SetColorMode = Nothing
			m_GetColorMode = Nothing

			m_SetCrossbar = Nothing
			m_SetDeviceNumber = Nothing
			m_EnumDevice = Nothing
			m_GetDeviceName = Nothing

			m_StartPreview = Nothing
			m_StopPreview = Nothing
			m_GetImageA = Nothing
			m_GetImageP = Nothing

			m_Width = Nothing
			m_Height = Nothing
			m_Fps = Nothing

			m_SetCameraDlg = Nothing
			m_SetImageDlg = Nothing
			m_SetAnalogDlg = Nothing

			m_SetIOPort = Nothing
			m_GetIOPort = Nothing
			m_SetFilterValue = Nothing
			m_GetFilterValue = Nothing

			m_SetSubSample = Nothing
			m_GetSubSample = Nothing
			m_SetWaitTime = Nothing
			m_GetWaitTime = Nothing

			m_SetMirrorV = Nothing
			m_GetMirrorV = Nothing
			m_SetMirrorH = Nothing
			m_GetMirrorH = Nothing

			m_SetBrightness = Nothing
			m_GetBrightness = Nothing
			m_SetContrast = Nothing
			m_GetContrast = Nothing
			m_SetHue = Nothing
			m_GetHue = Nothing
			m_SetSaturation = Nothing
			m_GetSaturation = Nothing
			m_SetSharpness = Nothing
			m_GetSharpness = Nothing
			m_SetBayerGainRGB = Nothing
			m_GetBayerGainRGB = Nothing
			m_SetBayerGainRed = Nothing
			m_GetBayerGainRed = Nothing
			m_SetBayerGainGreen = Nothing
			m_GetBayerGainGreen = Nothing
			m_SetBayerGainBlue = Nothing
			m_GetBayerGainBlue = Nothing
			m_SetBayerGainAuto = Nothing
			m_GetBayerGainAuto = Nothing
			m_SetGamma = Nothing
			m_GetGamma = Nothing
			m_SetBayerMode = Nothing
			m_GetBayerMode = Nothing

			m_SetGlobalGain = Nothing
			m_GetGlobalGain = Nothing
			m_SetColorGainRed = Nothing
			m_GetColorGainRed = Nothing
			m_SetColorGainGreen1 = Nothing
			m_GetColorGainGreen1 = Nothing
			m_SetColorGainGreen2 = Nothing
			m_GetColorGainGreen2 = Nothing
			m_SetColorGainBlue = Nothing
			m_GetColorGainBlue = Nothing
			m_SetExposureTime = Nothing
			m_GetExposureTime = Nothing

			m_SetHalfClock = Nothing
			m_GetHalfClock = Nothing
			m_SetAutoIris = Nothing
			m_GetAutoIris = Nothing

			m_SetSamplingRate = Nothing
			m_GetSamplingRate = Nothing
			m_GetVideoFormat = Nothing

			m_WriteSromID = Nothing
			m_ReadSromID = Nothing

			m_GetCameraInfo = Nothing
			m_GetStatus = Nothing

			m_WriteRegister = Nothing
			m_ReadRegister = Nothing

			m_WriteRegisterEx = Nothing
			m_ReadRegisterEx = Nothing

			m_SetGrayMode = Nothing
			m_GetGrayMode = Nothing
			m_SetGrayGainR = Nothing
			m_GetGrayGainR = Nothing
			m_SetGrayGainG1 = Nothing
			m_GetGrayGainG1 = Nothing
			m_SetGrayGainG2 = Nothing
			m_GetGrayGainG2 = Nothing
			m_SetGrayGainB = Nothing
			m_GetGrayGainB = Nothing

			m_SetGrayOffsetR = Nothing
			m_GetGrayOffsetR = Nothing
			m_SetGrayOffsetG1 = Nothing
			m_GetGrayOffsetG1 = Nothing
			m_SetGrayOffsetG2 = Nothing
			m_GetGrayOffsetG2 = Nothing
			m_SetGrayOffsetB = Nothing
			m_GetGrayOffsetB = Nothing

			m_SetCameraType = Nothing
			m_GetCameraType = Nothing

			m_SetSyncV = Nothing
			m_GetSyncV = Nothing
			m_SetSyncH = Nothing
			m_GetSyncH = Nothing

			m_Fpga_WriteRegister = Nothing
			m_Fpga_ReadRegister = Nothing

			m_Monitor_SetPreviewMode = Nothing
			m_Monitor_GetPreviewMode = Nothing
			m_Monitor_SetPreviewSize = Nothing
			m_Monitor_GetPreviewSize = Nothing
			m_Monitor_SetColorMode = Nothing
			m_Monitor_GetColorMode = Nothing
			m_Monitor_SetCameraClock = Nothing
			m_Monitor_GetCameraClock = Nothing
			m_Monitor_SetBayerGainAuto = Nothing
			m_Monitor_GetBayerGainAuto = Nothing
			m_Monitor_SetBayerGainLock = Nothing
			m_Monitor_GetBayerGainLock = Nothing
			m_Monitor_SetBayerGainRed = Nothing
			m_Monitor_GetBayerGainRed = Nothing
			m_Monitor_SetBayerGainGreen = Nothing
			m_Monitor_GetBayerGainGreen = Nothing
			m_Monitor_SetBayerGainBlue = Nothing
			m_Monitor_GetBayerGainBlue = Nothing

			m_Monitor_SaveCurrentSettings = Nothing
			m_Monitor_InitRegisterSettings = Nothing
			m_Monitor_SetCrossCursorMode = Nothing
			m_Monitor_GetCrossCursorMode = Nothing
			m_Monitor_SetCrossCursorColorR = Nothing
			m_Monitor_GetCrossCursorColorR = Nothing
			m_Monitor_SetCrossCursorColorG = Nothing
			m_Monitor_GetCrossCursorColorG = Nothing
			m_Monitor_SetCrossCursorColorB = Nothing
			m_Monitor_GetCrossCursorColorB = Nothing
			m_Monitor_SetCrossCursorColorRGB = Nothing
			m_Monitor_GetCrossCursorColorRGB = Nothing
			m_Monitor_SetCrossCursorPos = Nothing
			m_Monitor_GetCrossCursorPos = Nothing
			m_Monitor_SetCrossCursorSize = Nothing
			m_Monitor_GetCrossCursorSize = Nothing

			m_Monitor_SetAutoIrisMode = Nothing
			m_Monitor_GetAutoIrisMode = Nothing
			m_Monitor_SetAutoIrisRange = Nothing
			m_Monitor_GetAutoIrisRange = Nothing
			m_Monitor_LoadFirmware = Nothing

			m_GetRealExposureTime = Nothing
			m_SetRealExposureTime = Nothing
			
			m_SaveMaskFile		= Nothing
			m_LoadMaskFile		= Nothing
			m_UpdateMaskData	= Nothing
			m_SetPeltier		= Nothing		
			m_GetPeltier		= Nothing
			m_GetTemperature	= Nothing
			m_SetDotFilter		= Nothing
			m_GetDotFilter		= Nothing
			m_SetMaskFilter		= Nothing
			m_GetMaskFilter		= Nothing

			m_SetInternalCorrection = Nothing
			m_GetInternalCorrection = Nothing
			
			m_LoadConfigFile	= Nothing
			m_SetConfigFilter	= Nothing
			m_GetConfigFilter	= Nothing

			m_GetTemperatureEx	= Nothing
			m_SetExposureTimeEx	= Nothing
			m_GetExposureTimeEx	= Nothing

		End Function


		Protected Function GetDelegate(ByVal szProcName As String, ByVal DelegateType As Type) As [Delegate]

			If m_hArtCamSdk.Equals(IntPtr.Zero) Then
				Return Nothing
			End If

			Dim p As IntPtr = Win32GetProcAddress(m_hArtCamSdk, szProcName)
			If p = IntPtr.Zero Then
				Return Nothing
			End If
			Return Marshal.GetDelegateForFunctionPointer(p, DelegateType)

		End Function

		Public Function LoadLibrary(ByVal szDllName As String) As Boolean
			If IsValid(m_hArtCamSdk) Then
				Return True
			End If
			m_hArtCamSdk = Win32LoadLibrary(szDllName)
			Dim Err As Integer = Win32GetLastError()

			If False = IsValid(m_hArtCamSdk) Then
				Return False
			End If

			' DLL version check
			m_GetDllVersion = GetDelegate("ArtCam_GetDllVersion", GetType(DELEGATE_GETDLLVERSION))
			If m_GetDllVersion Is Nothing Then
				FreeLibrary()
				Return False
			End If

			' Obtain version
			Dim Version As Long = GetDllVersion() And &HFFFF
			Dim DllType As Long = GetDllVersion() >> 16

			' Standard function
			If (1000 <= Version) Then
				m_GetLastError = GetDelegate("ArtCam_GetLastError", GetType(DELEGATE_GETLASTERROR))
				m_Initialize = GetDelegate("ArtCam_Initialize", GetType(DELEGATE_INITIALIZE))
				m_Release = GetDelegate("ArtCam_Release", GetType(DELEGATE_RELEASE))
				m_Preview = GetDelegate("ArtCam_Preview", GetType(DELEGATE_PREVIEW))
				m_Record = GetDelegate("ArtCam_Record", GetType(DELEGATE_RECORD))
				m_CallBackPreviewA = GetDelegate("ArtCam_CallBackPreview", GetType(DELEGATE_CALLBACKPREVIEWA))
				m_CallBackPreviewP = GetDelegate("ArtCam_CallBackPreview", GetType(DELEGATE_CALLBACKPREVIEWP))
				m_Close = GetDelegate("ArtCam_Close", GetType(DELEGATE_CLOSE))
				m_SetPreviewWindow = GetDelegate("ArtCam_SetPreviewWindow", GetType(DELEGATE_SETPREVIEWWINDOW))
				m_SetCaptureWindow = GetDelegate("ArtCam_SetCaptureWindow", GetType(DELEGATE_SETCAPTUREWINDOW))
				m_SetCaptureWindowEx = GetDelegate("ArtCam_SetCaptureWindowEx", GetType(DELEGATE_SETCAPTUREWINDOWEX))
				m_GetCaptureWindowEx = GetDelegate("ArtCam_GetCaptureWindowEx", GetType(DELEGATE_GETCAPTUREWINDOWEX))
				m_SetColorMode = GetDelegate("ArtCam_SetColorMode", GetType(DELEGATE_SETCOLORMODE))
				m_GetColorMode = GetDelegate("ArtCam_GetColorMode", GetType(DELEGATE_GETCOLORMODE))
				m_SetCrossbar = GetDelegate("ArtCam_SetCrossbar", GetType(DELEGATE_SETCROSSBAR))
				m_SetDeviceNumber = GetDelegate("ArtCam_SetDeviceNumber", GetType(DELEGATE_SETDEVICENUMBER))
				m_EnumDevice = GetDelegate("ArtCam_EnumDevice", GetType(DELEGATE_ENUMDEVICE))
				m_GetDeviceName = GetDelegate("ArtCam_GetDeviceName", GetType(DELEGATE_GETDEVICENAME))
				m_StartPreview = GetDelegate("ArtCam_StartPreview", GetType(DELEGATE_STARTPREVIEW))
				m_StopPreview = GetDelegate("ArtCam_StopPreview", GetType(DELEGATE_STOPPREVIEW))
				m_GetImageA = GetDelegate("ArtCam_GetImage", GetType(DELEGATE_GETIMAGEA))
				m_GetImageP = GetDelegate("ArtCam_GetImage", GetType(DELEGATE_GETIMAGEP))
				m_Width = GetDelegate("ArtCam_Width", GetType(DELEGATE_WIDTH))
				m_Height = GetDelegate("ArtCam_Height", GetType(DELEGATE_HEIGHT))
				m_Fps = GetDelegate("ArtCam_Fps", GetType(DELEGATE_FPS))
				m_SetCameraDlg = GetDelegate("ArtCam_SetCameraDlg", GetType(DELEGATE_SETCAMERADLG))
				m_SetImageDlg = GetDelegate("ArtCam_SetImageDlg", GetType(DELEGATE_SETIMAGEDLG))
				m_SetAnalogDlg = GetDelegate("ArtCam_SetAnalogDlg", GetType(DELEGATE_SETANALOGDLG))


				If (IsNothing(m_GetLastError) Or IsNothing(m_Initialize) Or IsNothing(m_Release) Or IsNothing(m_Preview) Or IsNothing(m_Record) Or IsNothing(m_CallBackPreviewA) Or IsNothing(m_CallBackPreviewP) Or IsNothing(m_Close) Or _
					IsNothing(m_SetPreviewWindow) Or IsNothing(m_SetCaptureWindow) Or IsNothing(m_SetCaptureWindowEx) Or IsNothing(m_GetCaptureWindowEx) Or IsNothing(m_SetColorMode) Or IsNothing(m_GetColorMode)Or _
					IsNothing(m_SetCrossbar) Or IsNothing(m_SetDeviceNumber) Or IsNothing(m_EnumDevice) Or IsNothing(m_GetDeviceName) Or IsNothing(m_StartPreview) Or IsNothing(m_StopPreview) Or IsNothing(m_GetImageA) Or IsNothing(m_GetImageP) Or _
					IsNothing(m_Width) Or IsNothing(m_Height) Or IsNothing(m_Fps) Or IsNothing(m_SetCameraDlg) Or IsNothing(m_SetImageDlg) Or IsNothing(m_SetAnalogDlg)) Then
					FreeLibrary()
					Return False
				End If
			End If


			' Functions available with V1.23 or later
			If (1230 <= Version) Then
				m_SetIOPort = GetDelegate("ArtCam_SetIOPort", GetType(DELEGATE_SETIOPORT))
				m_GetIOPort = GetDelegate("ArtCam_GetIOPort", GetType(DELEGATE_GETIOPORT))
				m_SetFilterValue = GetDelegate("ArtCam_SetFilterValue", GetType(DELEGATE_SETFILTERVALUE))
				m_GetFilterValue = GetDelegate("ArtCam_GetFilterValue", GetType(DELEGATE_GETFILTERVALUE))
				m_SnapShotA = GetDelegate("ArtCam_SnapShot", GetType(DELEGATE_SNAPSHOTA))
				m_SnapShotP = GetDelegate("ArtCam_SnapShot", GetType(DELEGATE_SNAPSHOTP))
				m_SetSubSample = GetDelegate("ArtCam_SetSubSample", GetType(DELEGATE_SETSUBSAMPLE))
				m_GetSubSample = GetDelegate("ArtCam_GetSubSample", GetType(DELEGATE_GETSUBSAMPLE))
				m_SetWaitTime = GetDelegate("ArtCam_SetWaitTime", GetType(DELEGATE_SETWAITTIME))
				m_GetWaitTime = GetDelegate("ArtCam_GetWaitTime", GetType(DELEGATE_GETWAITTIME))

				If (IsNothing(m_SetIOPort) Or IsNothing(m_GetIOPort) Or IsNothing(m_SetFilterValue) Or IsNothing(m_GetFilterValue) Or IsNothing(m_SnapShotA) Or IsNothing(m_SnapShotP) Or _
					IsNothing(m_SetSubSample) Or IsNothing(m_GetSubSample) Or IsNothing(m_SetWaitTime) Or IsNothing(m_GetWaitTime)) Then
					FreeLibrary()
					Return False
				End If
			End If


			' Functions available with V1.24 or later
			If (1240 <= Version) Then
				m_SetMirrorV = GetDelegate("ArtCam_SetMirrorV", GetType(DELEGATE_SETMIRRORV))
				m_GetMirrorV = GetDelegate("ArtCam_GetMirrorV", GetType(DELEGATE_GETMIRRORV))
				m_SetMirrorH = GetDelegate("ArtCam_SetMirrorH", GetType(DELEGATE_SETMIRRORH))
				m_GetMirrorH = GetDelegate("ArtCam_GetMirrorH", GetType(DELEGATE_GETMIRRORH))
				m_SetBrightness = GetDelegate("ArtCam_SetBrightness", GetType(DELEGATE_SETBRIGHTNESS))
				m_GetBrightness = GetDelegate("ArtCam_GetBrightness", GetType(DELEGATE_GETBRIGHTNESS))
				m_SetContrast = GetDelegate("ArtCam_SetContrast", GetType(DELEGATE_SETCONTRAST))
				m_GetContrast = GetDelegate("ArtCam_GetContrast", GetType(DELEGATE_GETCONTRAST))
				m_SetHue = GetDelegate("ArtCam_SetHue", GetType(DELEGATE_SETHUE))
				m_GetHue = GetDelegate("ArtCam_GetHue", GetType(DELEGATE_GETHUE))
				m_SetSaturation = GetDelegate("ArtCam_SetSaturation", GetType(DELEGATE_SETSATURATION))
				m_GetSaturation = GetDelegate("ArtCam_GetSaturation", GetType(DELEGATE_GETSATURATION))
				m_SetSharpness = GetDelegate("ArtCam_SetSharpness", GetType(DELEGATE_SETSHARPNESS))
				m_GetSharpness = GetDelegate("ArtCam_GetSharpness", GetType(DELEGATE_GETSHARPNESS))
				m_SetBayerGainRGB = GetDelegate("ArtCam_SetBayerGainRGB", GetType(DELEGATE_SETBAYERGAINRGB))
				m_GetBayerGainRGB = GetDelegate("ArtCam_GetBayerGainRGB", GetType(DELEGATE_GETBAYERGAINRGB))
				m_SetBayerGainRed = GetDelegate("ArtCam_SetBayerGainRed", GetType(DELEGATE_SETBAYERGAINRED))
				m_GetBayerGainRed = GetDelegate("ArtCam_GetBayerGainRed", GetType(DELEGATE_GETBAYERGAINRED))
				m_SetBayerGainGreen = GetDelegate("ArtCam_SetBayerGainGreen", GetType(DELEGATE_SETBAYERGAINGREEN))
				m_GetBayerGainGreen = GetDelegate("ArtCam_GetBayerGainGreen", GetType(DELEGATE_GETBAYERGAINGREEN))
				m_SetBayerGainBlue = GetDelegate("ArtCam_SetBayerGainBlue", GetType(DELEGATE_SETBAYERGAINBLUE))
				m_GetBayerGainBlue = GetDelegate("ArtCam_GetBayerGainBlue", GetType(DELEGATE_GETBAYERGAINBLUE))
				m_SetBayerGainAuto = GetDelegate("ArtCam_SetBayerGainAuto", GetType(DELEGATE_SETBAYERGAINAUTO))
				m_GetBayerGainAuto = GetDelegate("ArtCam_GetBayerGainAuto", GetType(DELEGATE_GETBAYERGAINAUTO))
				m_SetGamma = GetDelegate("ArtCam_SetGamma", GetType(DELEGATE_SETGAMMA))
				m_GetGamma = GetDelegate("ArtCam_GetGamma", GetType(DELEGATE_GETGAMMA))
				m_SetBayerMode = GetDelegate("ArtCam_SetBayerMode", GetType(DELEGATE_SETBAYERMODE))
				m_GetBayerMode = GetDelegate("ArtCam_GetBayerMode", GetType(DELEGATE_GETBAYERMODE))
				m_SetGlobalGain = GetDelegate("ArtCam_SetGlobalGain", GetType(DELEGATE_SETGLOBALGAIN))
				m_GetGlobalGain = GetDelegate("ArtCam_GetGlobalGain", GetType(DELEGATE_GETGLOBALGAIN))
				m_SetColorGainRed = GetDelegate("ArtCam_SetColorGainRed", GetType(DELEGATE_SETCOLORGAINRED))
				m_GetColorGainRed = GetDelegate("ArtCam_GetColorGainRed", GetType(DELEGATE_GETCOLORGAINRED))
				m_SetColorGainGreen1 = GetDelegate("ArtCam_SetColorGainGreen1", GetType(DELEGATE_SETCOLORGAINGREEN1))
				m_GetColorGainGreen1 = GetDelegate("ArtCam_GetColorGainGreen1", GetType(DELEGATE_GETCOLORGAINGREEN1))
				m_SetColorGainGreen2 = GetDelegate("ArtCam_SetColorGainGreen2", GetType(DELEGATE_SETCOLORGAINGREEN2))
				m_GetColorGainGreen2 = GetDelegate("ArtCam_GetColorGainGreen2", GetType(DELEGATE_GETCOLORGAINGREEN2))
				m_SetColorGainBlue = GetDelegate("ArtCam_SetColorGainBlue", GetType(DELEGATE_SETCOLORGAINBLUE))
				m_GetColorGainBlue = GetDelegate("ArtCam_GetColorGainBlue", GetType(DELEGATE_GETCOLORGAINBLUE))
				m_SetExposureTime = GetDelegate("ArtCam_SetExposureTime", GetType(DELEGATE_SETEXPOSURETIME))
				m_GetExposureTime = GetDelegate("ArtCam_GetExposureTime", GetType(DELEGATE_GETEXPOSURETIME))

				If (IsNothing(m_SetMirrorV) Or IsNothing(m_GetMirrorV) Or IsNothing(m_SetMirrorH) Or IsNothing(m_GetMirrorH) Or _
					IsNothing(m_SetBrightness) Or IsNothing(m_GetBrightness) Or IsNothing(m_SetContrast) Or IsNothing(m_GetContrast) Or _
					IsNothing(m_SetHue) Or IsNothing(m_GetHue) Or IsNothing(m_SetSaturation) Or IsNothing(m_GetSaturation) Or _
					IsNothing(m_SetSharpness) Or IsNothing(m_GetSharpness) Or IsNothing(m_SetBayerGainRGB) Or IsNothing(m_GetBayerGainRGB) Or _
					IsNothing(m_SetBayerGainRed) Or IsNothing(m_GetBayerGainRed) Or IsNothing(m_SetBayerGainGreen) Or IsNothing(m_GetBayerGainGreen) Or _
					IsNothing(m_SetBayerGainBlue) Or IsNothing(m_GetBayerGainBlue) Or IsNothing(m_SetBayerGainAuto) Or IsNothing(m_GetBayerGainAuto) Or _
					IsNothing(m_SetGamma) Or IsNothing(m_GetGamma) Or IsNothing(m_SetBayerMode) Or IsNothing(m_GetBayerMode) Or _
					IsNothing(m_SetGlobalGain) Or IsNothing(m_GetGlobalGain) Or IsNothing(m_SetColorGainRed) Or IsNothing(m_GetColorGainRed) Or _
					IsNothing(m_SetColorGainGreen1) Or IsNothing(m_GetColorGainGreen1) Or IsNothing(m_SetColorGainGreen2) Or IsNothing(m_GetColorGainGreen2) Or _
					IsNothing(m_SetColorGainBlue) Or IsNothing(m_GetColorGainBlue) Or IsNothing(m_SetExposureTime) Or IsNothing(m_GetExposureTime)) Then

					FreeLibrary()
					Return False
				End If
			End If


			' Functions available with V1.25 or later
			If (1250 <= Version) Then
				m_Capture = GetDelegate("ArtCam_Capture", GetType(DELEGATE_CAPTURE))
				If IsNothing(m_Capture) Then
					FreeLibrary()
					Return False
				End If
			End If



			' Functions available with V1.26 or later
			If (1260 <= Version) Then
				m_TriggerA = GetDelegate("ArtCam_Trigger", GetType(DELEGATE_TRIGGERA))
				m_TriggerP = GetDelegate("ArtCam_Trigger", GetType(DELEGATE_TRIGGERP))
				m_SaveImage = GetDelegate("ArtCam_SaveImage", GetType(DELEGATE_SAVEIMAGE))
				m_SetHalfClock = GetDelegate("ArtCam_SetHalfClock", GetType(DELEGATE_SETHALFCLOCK))
				m_GetHalfClock = GetDelegate("ArtCam_GetHalfClock", GetType(DELEGATE_GETHALFCLOCK))
				m_SetAutoIris = GetDelegate("ArtCam_SetAutoIris", GetType(DELEGATE_SETAUTOIRIS))
				m_GetAutoIris = GetDelegate("ArtCam_GetAutoIris", GetType(DELEGATE_GETAUTOIRIS))

				If (IsNothing(m_TriggerA) Or IsNothing(m_TriggerP) Or IsNothing(m_SaveImage) Or IsNothing(m_SetHalfClock) Or IsNothing(m_GetHalfClock) Or IsNothing(m_SetAutoIris) Or IsNothing(m_GetAutoIris)) Then
					FreeLibrary()
					Return False
				End If
			End If


			' Functions available with V1.275 or later
			If (1275 <= Version) Then
				m_SetSamplingRate = GetDelegate("ArtCam_SetSamplingRate", GetType(DELEGATE_SETSAMPLINGRATE))
				m_GetSamplingRate = GetDelegate("ArtCam_GetSamplingRate", GetType(DELEGATE_GETSAMPLINGRATE))
				m_GetVideoFormat = GetDelegate("ArtCam_GetVideoFormat", GetType(DELEGATE_GETVIDEOFORMAT))

				If (IsNothing(m_SetSamplingRate) Or IsNothing(m_GetSamplingRate) Or IsNothing(m_GetVideoFormat)) Then
					FreeLibrary()
					Return False
				End If
			End If


			' Functions available with V1.276 or later
			If (1276 <= Version) Then
				m_WriteSromID = GetDelegate("ArtCam_WriteSromID", GetType(DELEGATE_WRITESROMID))
				m_ReadSromID = GetDelegate("ArtCam_ReadSromID", GetType(DELEGATE_READSROMID))

				If (IsNothing(m_WriteSromID) Or IsNothing(m_ReadSromID)) Then
					FreeLibrary()
					Return False
				End If
			End If


			' Functions available with V1.280 or later
			If (1280 <= Version) Then
				m_GetCameraInfo = GetDelegate("ArtCam_GetCameraInfo", GetType(DELEGATE_GETCAMERAINFO))
				m_GetStatus = GetDelegate("ArtCam_GetStatus", GetType(DELEGATE_GETSTATUS))

				m_WriteRegister = GetDelegate("ArtCam_WriteRegister", GetType(DELEGATE_WRITEREGISTER))
				m_ReadRegister = GetDelegate("ArtCam_ReadRegister", GetType(DELEGATE_READREGISTER))

				m_SetGrayMode = GetDelegate("ArtCam_SetGrayMode", GetType(DELEGATE_SETGRAYMODE))
				m_GetGrayMode = GetDelegate("ArtCam_GetGrayMode", GetType(DELEGATE_GETGRAYMODE))
				m_SetGrayGainR = GetDelegate("ArtCam_SetGrayGainR", GetType(DELEGATE_SETGRAYGAINR))
				m_GetGrayGainR = GetDelegate("ArtCam_GetGrayGainR", GetType(DELEGATE_GETGRAYGAINR))
				m_SetGrayGainG1 = GetDelegate("ArtCam_SetGrayGainG1", GetType(DELEGATE_SETGRAYGAING1))
				m_GetGrayGainG1 = GetDelegate("ArtCam_GetGrayGainG1", GetType(DELEGATE_GETGRAYGAING1))
				m_SetGrayGainG2 = GetDelegate("ArtCam_SetGrayGainG2", GetType(DELEGATE_SETGRAYGAING2))
				m_GetGrayGainG2 = GetDelegate("ArtCam_GetGrayGainG2", GetType(DELEGATE_GETGRAYGAING2))
				m_SetGrayGainB = GetDelegate("ArtCam_SetGrayGainB", GetType(DELEGATE_SETGRAYGAINB))
				m_GetGrayGainB = GetDelegate("ArtCam_GetGrayGainB", GetType(DELEGATE_GETGRAYGAINB))
				m_SetGrayOffsetR = GetDelegate("ArtCam_SetGrayOffsetR", GetType(DELEGATE_SETGRAYOFFSETR))
				m_GetGrayOffsetR = GetDelegate("ArtCam_GetGrayOffsetR", GetType(DELEGATE_GETGRAYOFFSETR))
				m_SetGrayOffsetG1 = GetDelegate("ArtCam_SetGrayOffsetG1", GetType(DELEGATE_SETGRAYOFFSETG1))
				m_GetGrayOffsetG1 = GetDelegate("ArtCam_GetGrayOffsetG1", GetType(DELEGATE_GETGRAYOFFSETG1))
				m_SetGrayOffsetG2 = GetDelegate("ArtCam_SetGrayOffsetG2", GetType(DELEGATE_SETGRAYOFFSETG2))
				m_GetGrayOffsetG2 = GetDelegate("ArtCam_GetGrayOffsetG2", GetType(DELEGATE_GETGRAYOFFSETG2))
				m_SetGrayOffsetB = GetDelegate("ArtCam_SetGrayOffsetB", GetType(DELEGATE_SETGRAYOFFSETB))
				m_GetGrayOffsetB = GetDelegate("ArtCam_GetGrayOffsetB", GetType(DELEGATE_GETGRAYOFFSETB))

				If (IsNothing(m_GetCameraInfo) Or IsNothing(m_GetStatus) Or IsNothing(m_WriteRegister) Or IsNothing(m_ReadRegister) Or IsNothing(m_SetGrayMode) Or IsNothing(m_GetGrayMode) Or _
					IsNothing(m_SetGrayGainR) Or IsNothing(m_GetGrayGainR) Or IsNothing(m_SetGrayGainG1) Or IsNothing(m_GetGrayGainG1) Or _
					IsNothing(m_SetGrayGainG2) Or IsNothing(m_GetGrayGainG2) Or IsNothing(m_SetGrayGainB) Or IsNothing(m_GetGrayGainB) Or _
					IsNothing(m_SetGrayOffsetR) Or IsNothing(m_GetGrayOffsetR) Or IsNothing(m_SetGrayOffsetG1) Or IsNothing(m_GetGrayOffsetG1) Or _
					IsNothing(m_SetGrayOffsetG2) Or IsNothing(m_GetGrayOffsetG2) Or IsNothing(m_SetGrayOffsetB) Or IsNothing(m_GetGrayOffsetB)) Then
					FreeLibrary()
					Return False
				End If


				If (ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_900MI = DllType Or ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_1000MI = DllType) Then
					m_WriteRegisterEx = GetDelegate("ArtCam_WriteRegisterEx", GetType(DELEGATE_WRITEREGISTEREX))
					m_ReadRegisterEx = GetDelegate("ArtCam_ReadRegisterEx", GetType(DELEGATE_READREGISTEREX))

					If (IsNothing(m_WriteRegisterEx) Or IsNothing(m_ReadRegisterEx)) Then
						FreeLibrary()
						Return False
					End If
				End If

				' SATA
				If (ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_SATA = DllType) Then
					m_SetCameraType = GetDelegate("ArtCam_SetCameraType", GetType(DELEGATE_SETCAMERATYPE))
					m_GetCameraType = GetDelegate("ArtCam_GetCameraType", GetType(DELEGATE_GETCAMERATYPE))

					If (IsNothing(m_SetCameraType) Or IsNothing(m_GetCameraType)) Then
						FreeLibrary()
						Return False
					End If
				End If

				' MOUT
				If (ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_130MI_MOUT = DllType Or ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P3_MOUT = DllType Or _
					ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_1000MI_HD2 = DllType) Then
					m_Fpga_WriteRegister = GetDelegate("ArtCam_Fpga_WriteRegister", GetType(DELEGATE_FPGA_WRITEREGISTER))
					m_Fpga_ReadRegister = GetDelegate("ArtCam_Fpga_ReadRegister", GetType(DELEGATE_FPGA_READREGISTER))

					m_Monitor_SetPreviewMode = GetDelegate("ArtCam_Monitor_SetPreviewMode", GetType(DELEGATE_MONITOR_SETPREVIEWMODE))
					m_Monitor_GetPreviewMode = GetDelegate("ArtCam_Monitor_GetPreviewMode", GetType(DELEGATE_MONITOR_GETPREVIEWMODE))
					m_Monitor_SetPreviewSize = GetDelegate("ArtCam_Monitor_SetPreviewSize", GetType(DELEGATE_MONITOR_SETPREVIEWSIZE))
					m_Monitor_GetPreviewSize = GetDelegate("ArtCam_Monitor_GetPreviewSize", GetType(DELEGATE_MONITOR_GETPREVIEWSIZE))
					m_Monitor_SetColorMode = GetDelegate("ArtCam_Monitor_SetColorMode", GetType(DELEGATE_MONITOR_SETCOLORMODE))
					m_Monitor_GetColorMode = GetDelegate("ArtCam_Monitor_GetColorMode", GetType(DELEGATE_MONITOR_GETCOLORMODE))
					m_Monitor_SetCameraClock = GetDelegate("ArtCam_Monitor_SetCameraClock", GetType(DELEGATE_MONITOR_SETCAMERACLOCK))
					m_Monitor_GetCameraClock = GetDelegate("ArtCam_Monitor_GetCameraClock", GetType(DELEGATE_MONITOR_GETCAMERACLOCK))
					m_Monitor_SetBayerGainAuto = GetDelegate("ArtCam_Monitor_SetBayerGainAuto", GetType(DELEGATE_MONITOR_SETBAYERGAINAUTO))
					m_Monitor_GetBayerGainAuto = GetDelegate("ArtCam_Monitor_GetBayerGainAuto", GetType(DELEGATE_MONITOR_GETBAYERGAINAUTO))
					m_Monitor_SetBayerGainLock = GetDelegate("ArtCam_Monitor_SetBayerGainLock", GetType(DELEGATE_MONITOR_SETBAYERGAINLOCK))
					m_Monitor_GetBayerGainLock = GetDelegate("ArtCam_Monitor_GetBayerGainLock", GetType(DELEGATE_MONITOR_GETBAYERGAINLOCK))
					m_Monitor_SetBayerGainRed = GetDelegate("ArtCam_Monitor_SetBayerGainRed", GetType(DELEGATE_MONITOR_SETBAYERGAINRED))
					m_Monitor_GetBayerGainRed = GetDelegate("ArtCam_Monitor_GetBayerGainRed", GetType(DELEGATE_MONITOR_GETBAYERGAINRED))
					m_Monitor_SetBayerGainGreen = GetDelegate("ArtCam_Monitor_SetBayerGainGreen", GetType(DELEGATE_MONITOR_SETBAYERGAINGREEN))
					m_Monitor_GetBayerGainGreen = GetDelegate("ArtCam_Monitor_GetBayerGainGreen", GetType(DELEGATE_MONITOR_GETBAYERGAINGREEN))
					m_Monitor_SetBayerGainBlue = GetDelegate("ArtCam_Monitor_SetBayerGainBlue", GetType(DELEGATE_MONITOR_SETBAYERGAINBLUE))
					m_Monitor_GetBayerGainBlue = GetDelegate("ArtCam_Monitor_GetBayerGainBlue", GetType(DELEGATE_MONITOR_GETBAYERGAINBLUE))


					If (IsNothing(m_Fpga_WriteRegister) Or IsNothing(m_Fpga_ReadRegister) Or _
						IsNothing(m_Monitor_SetPreviewMode) Or IsNothing(m_Monitor_GetPreviewMode) Or IsNothing(m_Monitor_SetPreviewSize) Or IsNothing(m_Monitor_GetPreviewSize) Or _
						IsNothing(m_Monitor_SetColorMode) Or IsNothing(m_Monitor_GetColorMode) Or IsNothing(m_Monitor_SetCameraClock) Or IsNothing(m_Monitor_GetCameraClock) Or _
						IsNothing(m_Monitor_SetBayerGainAuto) Or IsNothing(m_Monitor_GetBayerGainAuto) Or IsNothing(m_Monitor_SetBayerGainRed) Or IsNothing(m_Monitor_GetBayerGainRed) Or _
						IsNothing(m_Monitor_SetBayerGainGreen) Or IsNothing(m_Monitor_GetBayerGainGreen) Or IsNothing(m_Monitor_SetBayerGainBlue) Or IsNothing(m_Monitor_GetBayerGainBlue)) Then
						FreeLibrary()
						Return False
					End If
				End If

			End If

			If (1282 <= Version) Then
				' SATA
				If (ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_SATA = DllType) Then
					m_SetSyncV = GetDelegate("ArtCam_SetSyncV", GetType(DELEGATE_SETSYNCV))
					m_GetSyncV = GetDelegate("ArtCam_GetSyncV", GetType(DELEGATE_GETSYNCV))
					m_SetSyncH = GetDelegate("ArtCam_SetSyncH", GetType(DELEGATE_SETSYNCH))
					m_GetSyncH = GetDelegate("ArtCam_GetSyncH", GetType(DELEGATE_GETSYNCH))

					If (IsNothing(m_SetSyncV) Or IsNothing(m_GetSyncV) Or IsNothing(m_SetSyncH) Or IsNothing(m_GetSyncH)) Then
						FreeLibrary()
						Return False
					End If
				End If
				' MOUT
				If (ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_130MI_MOUT = DllType Or ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P3_MOUT = DllType Or _
					ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_1000MI_HD2 = DllType) Then
					m_Monitor_SaveCurrentSettings = GetDelegate("ArtCam_Monitor_SaveCurrentSettings", GetType(DELEGATE_MONITOR_SAVECURRENTSETTINGS))
					m_Monitor_InitRegisterSettings = GetDelegate("ArtCam_Monitor_InitRegisterSettings", GetType(DELEGATE_MONITOR_INITREGISTERSETTINGS))
					m_Monitor_SetCrossCursorMode = GetDelegate("ArtCam_Monitor_SetCrossCursorMode", GetType(DELEGATE_MONITOR_SETCROSSCURSORMODE))
					m_Monitor_GetCrossCursorMode = GetDelegate("ArtCam_Monitor_GetCrossCursorMode", GetType(DELEGATE_MONITOR_GETCROSSCURSORMODE))
					m_Monitor_SetCrossCursorColorR = GetDelegate("ArtCam_Monitor_SetCrossCursorColorR", GetType(DELEGATE_MONITOR_SETCROSSCURSORCOLORR))
					m_Monitor_GetCrossCursorColorR = GetDelegate("ArtCam_Monitor_GetCrossCursorColorR", GetType(DELEGATE_MONITOR_GETCROSSCURSORCOLORR))
					m_Monitor_SetCrossCursorColorG = GetDelegate("ArtCam_Monitor_SetCrossCursorColorG", GetType(DELEGATE_MONITOR_SETCROSSCURSORCOLORG))
					m_Monitor_GetCrossCursorColorG = GetDelegate("ArtCam_Monitor_GetCrossCursorColorG", GetType(DELEGATE_MONITOR_GETCROSSCURSORCOLORG))
					m_Monitor_SetCrossCursorColorB = GetDelegate("ArtCam_Monitor_SetCrossCursorColorB", GetType(DELEGATE_MONITOR_SETCROSSCURSORCOLORB))
					m_Monitor_GetCrossCursorColorB = GetDelegate("ArtCam_Monitor_GetCrossCursorColorB", GetType(DELEGATE_MONITOR_GETCROSSCURSORCOLORB))
					m_Monitor_SetCrossCursorColorRGB = GetDelegate("ArtCam_Monitor_SetCrossCursorColorRGB", GetType(DELEGATE_MONITOR_SETCROSSCURSORCOLORRGB))
					m_Monitor_GetCrossCursorColorRGB = GetDelegate("ArtCam_Monitor_GetCrossCursorColorRGB", GetType(DELEGATE_MONITOR_GETCROSSCURSORCOLORRGB))
					m_Monitor_SetCrossCursorPos = GetDelegate("ArtCam_Monitor_SetCrossCursorPos", GetType(DELEGATE_MONITOR_SETCROSSCURSORPOS))
					m_Monitor_GetCrossCursorPos = GetDelegate("ArtCam_Monitor_GetCrossCursorPos", GetType(DELEGATE_MONITOR_GETCROSSCURSORPOS))
					m_Monitor_SetCrossCursorSize = GetDelegate("ArtCam_Monitor_SetCrossCursorSize", GetType(DELEGATE_MONITOR_SETCROSSCURSORSIZE))
					m_Monitor_GetCrossCursorSize = GetDelegate("ArtCam_Monitor_GetCrossCursorSize", GetType(DELEGATE_MONITOR_GETCROSSCURSORSIZE))
					m_Monitor_SetAutoIrisMode = GetDelegate("ArtCam_Monitor_SetAutoIrisMode", GetType(DELEGATE_MONITOR_SETAUTOIRISMODE))
					m_Monitor_GetAutoIrisMode = GetDelegate("ArtCam_Monitor_GetAutoIrisMode", GetType(DELEGATE_MONITOR_GETAUTOIRISMODE))
					m_Monitor_SetAutoIrisRange = GetDelegate("ArtCam_Monitor_SetAutoIrisRange", GetType(DELEGATE_MONITOR_SETAUTOIRISRANGE))
					m_Monitor_GetAutoIrisRange = GetDelegate("ArtCam_Monitor_GetAutoIrisRange", GetType(DELEGATE_MONITOR_GETAUTOIRISRANGE))
					m_Monitor_LoadFirmware = GetDelegate("ArtCam_Monitor_LoadFirmware", GetType(DELEGATE_MONITOR_LOADFIRMWARE))


					If (IsNothing(m_Monitor_SaveCurrentSettings) Or IsNothing(m_Monitor_InitRegisterSettings) Or IsNothing(m_Monitor_SetCrossCursorMode) Or IsNothing(m_Monitor_GetCrossCursorMode) Or _
						IsNothing(m_Monitor_SetCrossCursorColorR) Or IsNothing(m_Monitor_GetCrossCursorColorR) Or IsNothing(m_Monitor_SetCrossCursorColorG) Or _
						IsNothing(m_Monitor_GetCrossCursorColorG) Or IsNothing(m_Monitor_SetCrossCursorColorB) Or IsNothing(m_Monitor_GetCrossCursorColorB) Or _
						IsNothing(m_Monitor_SetCrossCursorColorRGB) Or IsNothing(m_Monitor_GetCrossCursorColorRGB) Or IsNothing(m_Monitor_SetCrossCursorPos) Or _
						IsNothing(m_Monitor_GetCrossCursorPos) Or IsNothing(m_Monitor_SetCrossCursorSize) Or IsNothing(m_Monitor_GetCrossCursorSize) Or _
						IsNothing(m_Monitor_SetAutoIrisMode) Or IsNothing(m_Monitor_GetAutoIrisMode) Or _
						IsNothing(m_Monitor_SetAutoIrisRange) Or IsNothing(m_Monitor_GetAutoIrisRange)) Then
						FreeLibrary()
						Return False
					End If
				End If
			End If

			' Functions available with V1.300 or later
			If (1300 <= Version) Then
				If (ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV <> DllType) Then
					m_GetRealExposureTime = GetDelegate("ArtCam_GetRealExposureTime", GetType(DELEGATE_GETREALEXPOSURETIME))
					m_SetRealExposureTime = GetDelegate("ArtCam_SetRealExposureTime", GetType(DELEGATE_SETREALEXPOSURETIME))
					If IsNothing(m_GetRealExposureTime) Then
						FreeLibrary()
						Return False
					End If
				End If
				
				' TNIR
				If (ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_031TNIR = DllType Or ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_008TNIR = DllType Or ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_0016TNIR = DllType) Then
					m_SaveMaskFile			= GetDelegate("ArtCam_SaveMaskFile",	GetType(DELEGATE_SAVEMASKFILE))
					m_LoadMaskFile			= GetDelegate("ArtCam_LoadMaskFile",	GetType(DELEGATE_LOADMASKFILE))
					m_UpdateMaskData		= GetDelegate("ArtCam_UpdateMaskData",	GetType(DELEGATE_UPDATEMASKDATA))
                                                                                            
					m_SetPeltier			= GetDelegate("ArtCam_SetPeltier",		GetType(DELEGATE_SETPELTIER))
					m_GetPeltier			= GetDelegate("ArtCam_GetPeltier",		GetType(DELEGATE_GETPELTIER))
					m_GetTemperature		= GetDelegate("ArtCam_GetTemperature",	GetType(DELEGATE_GETTEMPERATURE))
					m_SetDotFilter			= GetDelegate("ArtCam_SetDotFilter",	GetType(DELEGATE_SETDOTFILTER))
					m_GetDotFilter			= GetDelegate("ArtCam_GetDotFilter",	GetType(DELEGATE_GETDOTFILTER))
					m_SetMaskFilter			= GetDelegate("ArtCam_SetMaskFilter",	GetType(DELEGATE_SETMASKFILTER))
					m_GetMaskFilter			= GetDelegate("ArtCam_GetMaskFilter",	GetType(DELEGATE_GETMASKFILTER))


					If (IsNothing(m_SaveMaskFile) Or IsNothing(m_LoadMaskFile) Or IsNothing(m_UpdateMaskData) Or IsNothing(m_SetPeltier) Or _
						IsNothing(m_GetPeltier) Or IsNothing(m_GetTemperature) Or IsNothing(m_SetDotFilter) Or IsNothing(m_GetDotFilter) Or _
						IsNothing(m_SetMaskFilter) Or IsNothing(m_GetMaskFilter)) Then
						FreeLibrary()
						Return False
					End If
				End If

                If (ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_032TNIR_USB3_T2 = DllType Or ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_009TNIR_USB3_T2 = DllType Or _
                    ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_131TNIR_USB3_T2 = DllType Or ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_130SWIR_USB3_T2 = DllType) Then
                    m_SaveMaskFile = GetDelegate("ArtCam_SaveMaskFile", GetType(DELEGATE_SAVEMASKFILE))
                    m_LoadMaskFile = GetDelegate("ArtCam_LoadMaskFile", GetType(DELEGATE_LOADMASKFILE))
                    m_UpdateMaskData = GetDelegate("ArtCam_UpdateMaskData", GetType(DELEGATE_UPDATEMASKDATA))

					m_SetPeltier			= GetDelegate("ArtCam_SetPeltier",		GetType(DELEGATE_SETPELTIER))
					m_GetPeltier			= GetDelegate("ArtCam_GetPeltier",		GetType(DELEGATE_GETPELTIER))
					m_GetTemperature		= GetDelegate("ArtCam_GetTemperature",	GetType(DELEGATE_GETTEMPERATURE))
					m_SetDotFilter			= GetDelegate("ArtCam_SetDotFilter",	GetType(DELEGATE_SETDOTFILTER))
					m_GetDotFilter			= GetDelegate("ArtCam_GetDotFilter",	GetType(DELEGATE_GETDOTFILTER))
					m_SetMaskFilter			= GetDelegate("ArtCam_SetMaskFilter",	GetType(DELEGATE_SETMASKFILTER))
					m_GetMaskFilter			= GetDelegate("ArtCam_GetMaskFilter",	GetType(DELEGATE_GETMASKFILTER))

                    m_SetInternalCorrection = GetDelegate("ArtCam_SetInternalCorrection", GetType(DELEGATE_SETINTERNALCORRECTION))
                    m_GetInternalCorrection = GetDelegate("ArtCam_GetInternalCorrection", GetType(DELEGATE_GETINTERNALCORRECTION))

                    If (IsNothing(m_SetInternalCorrection) Or IsNothing(m_GetInternalCorrection)) Then
                        FreeLibrary()
                        Return False
                    End If
                End If
            End If


            If (1311 <= Version) Then
                If (ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_130XQE_WOM = DllType) Then
                    m_LoadConfigFile = GetDelegate("ArtCam_LoadConfigFileA", GetType(DELEGATE_LOADCONFIGFILE))
                    m_SetConfigFilter = GetDelegate("ArtCam_SetConfigFilter", GetType(DELEGATE_SETCONFIGFILTER))
                    m_GetConfigFilter = GetDelegate("ArtCam_GetConfigFilter", GetType(DELEGATE_GETCONFIGFILTER))

                    If (IsNothing(m_LoadConfigFile) Or IsNothing(m_SetConfigFilter) Or IsNothing(m_GetConfigFilter)) Then
                        FreeLibrary()
                        Return False
                    End If
                End If
            End If

            If (1312 <= Version) Then
                m_GetTemperatureEx = GetDelegate("ArtCam_GetTemperatureEx", GetType(DELEGATE_GETTEMPERATUREEX))
                m_SetExposureTimeEx = GetDelegate("ArtCam_SetExposureTimeEx", GetType(DELEGATE_SETEXPOSURETIMEEX))
                m_GetExposureTimeEx = GetDelegate("ArtCam_GetExposureTimeEx", GetType(DELEGATE_GETEXPOSURETIMEEX))

            End If

            Return True
		End Function

		Public Function FreeLibrary() As Integer
			If (0 <> m_hACam)Then
				If Not IsNothing(m_Release) Then
					m_Release(m_hACam)
				End If
			End If

			If (IsValid(m_hArtCamSdk)) Then
				Win32FreeLibrary(m_hArtCamSdk)
			End If
			NothingSet()
		End Function

		Public Function GetDllVersion() As Integer
			If Not IsNothing(m_GetDllVersion) Then
				Return m_GetDllVersion()
			End If
			Return 0
		End Function

        Public Function GetDllType() As Integer
            Return GetDllVersion() / &H10000
        End Function

        Public Function GetLastError() As Integer
			If Not IsNothing(m_GetLastError) Then
	            Return m_GetLastError(m_hACam)
			End If
			Return 0
        End Function

        Public Function Initialize(ByVal hWnd As IntPtr) As Integer
			If 0 <> m_hACam Then
				Return True
			End If

			If Not IsNothing(m_Initialize) Then
				m_hACam = m_Initialize(hWnd)
					If m_hACam = 0 Then
						Return False
					End If
				Return True
			End If
			Return 0
        End Function

        Public Function Release() As Integer
			If m_hACam = 0 Then
				Return 1
			End If

			If Not IsNothing(m_Initialize) Then
				Dim ret As Integer = m_Release(m_hACam)
				m_hACam = 0
				return ret
			End If
			Return 0
		End Function

        Public Function Preview() As Integer
			If Not IsNothing(m_Preview) Then
	            Return m_Preview(m_hACam)
			End If
			Return 0
		End Function

        Public Function Record(ByVal lpAviName As String, ByVal RecTime As Integer, ByVal fShow As Integer) As Integer
            If Not IsNothing(m_Record) Then
				Return m_Record(m_hACam, lpAviName, RecTime, fShow)
			End If
			Return 0
		End Function

		Public Function CallBackPreview(ByVal hWnd As IntPtr, ByVal lpImage As Byte(), ByVal Size As Integer, ByVal TopDown As Integer) As Integer
			If Not IsNothing(m_CallBackPreviewA) Then
				Return m_CallBackPreviewA(m_hACam, hWnd, lpImage, Size, TopDown)
			End If
			Return 0
		End Function

		Public Function CallBackPreview(ByVal hWnd As IntPtr, ByVal lpImage As  IntPtr, ByVal Size As Integer, ByVal TopDown As Integer) As Integer
			If Not IsNothing(m_CallBackPreviewP) Then
				Return m_CallBackPreviewP(m_hACam, hWnd, lpImage, Size, TopDown)
			End If
			Return 0
		End Function

		Public Function SnapShot(ByVal lpImage As Byte(), ByVal Size As Integer, ByVal TopDown As Integer) As Integer
			If Not IsNothing(m_SnapShotA) Then
				Return m_SnapShotA(m_hACam, lpImage, Size, TopDown)
			End If
			Return 0
		End Function

		Public Function SnapShot(ByVal lpImage As IntPtr, ByVal Size As Integer, ByVal TopDown As Integer) As Integer
			If Not IsNothing(m_SnapShotP) Then
				Return m_SnapShotP(m_hACam, lpImage, Size, TopDown)
			End If
			Return 0
		End Function

		Public Function Close() As Integer
			If Not IsNothing(m_Close) Then
				Return m_Close(m_hACam)
			End If
			Return 0
		End Function

		' 1250
		Public Function Capture() As Integer
			If Not IsNothing(m_Capture) Then
				Return m_Capture(m_hACam)
			End If
			Return 0
		End Function

		' 1260
		Public Function Trigger(ByVal hWnd As IntPtr, ByVal lpImage As Byte(), ByVal Size As Integer, ByVal TopDown As Integer) As Integer
			If Not IsNothing(m_TriggerA) Then
				Return m_TriggerA(m_hACam, hWnd, lpImage, Size, TopDown)
			End If
			Return 0
		End Function

		Public Function Trigger(ByVal hWnd As IntPtr, ByVal lpImage As IntPtr, ByVal Size As Integer, ByVal TopDown As Integer) As Integer
			If Not IsNothing(m_TriggerP) Then
				Return m_TriggerP(m_hACam, hWnd, lpImage, Size, TopDown)
			End If
			Return 0
		End Function

		Public Function SaveImage(ByVal lpSaveName As String, ByVal FileType As FILETYPE) As Integer
			If Not IsNothing(m_SaveImage) Then
				Return m_SaveImage(m_hACam, lpSaveName, FileType)
			End If
			Return 0
		End Function

		Public Function SetPreviewWindow(ByVal hWnd As IntPtr, ByVal Left As Integer, ByVal Top As Integer, ByVal Right As Integer, ByVal Bottom As Integer) As Integer
			If Not IsNothing(m_SetPreviewWindow) Then
				Return m_SetPreviewWindow(m_hACam, hWnd, Left, Top, Right, Bottom)
			End If
			Return 0
		End Function

		Public Function SetCaptureWindow(ByVal Width As Integer, ByVal Height As Integer, ByVal Frame As Integer) As Integer
			If Not IsNothing(m_SetCaptureWindow) Then
				Return m_SetCaptureWindow(m_hACam, Width, Height, Frame)
			End If
			Return 0
		End Function

		Public Function SetCaptureWindowEx(ByVal HTotal As Integer, ByVal HStart As Integer, ByVal HEffective As Integer, ByVal VTotal As Integer, ByVal VStart As Integer, ByVal VEffective As Integer) As Integer
			If Not IsNothing(m_SetCaptureWindowEx) Then
				Return m_SetCaptureWindowEx(m_hACam, HTotal, HStart, HEffective, VTotal, VStart, VEffective)
			End If
			Return 0
		End Function

		Public Function GetCaptureWindowEx(ByRef HTotal As Integer, ByRef HStart As Integer, ByRef HEffective As Integer, ByRef VTotal As Integer, ByRef VStart As Integer, ByRef VEffective As Integer) As Integer
			If Not IsNothing(m_GetCaptureWindowEx) Then
				Return m_GetCaptureWindowEx(m_hACam, HTotal, HStart, HEffective, VTotal, VStart, VEffective)
			End If
			Return 0
		End Function

		Public Function SetColorMode(ByVal ColorMode As Integer) As Integer
			If Not IsNothing(m_SetColorMode) Then
				Return m_SetColorMode(m_hACam, ColorMode)
			End If
			Return 0
		End Function

		Public Function GetColorMode() As Integer
			If Not IsNothing(m_GetColorMode) Then
				Return m_GetColorMode(m_hACam)
			End If
			Return 0
		End Function

		Public Function SetCrossbar(ByVal Output As Integer, ByVal Input As Integer) As Integer
			If Not IsNothing(m_SetCrossbar) Then
				Return m_SetCrossbar(m_hACam, Output, Input)
			End If
			Return 0
		End Function

		Public Function SetDeviceNumber(ByVal Number As Integer) As Integer
			If Not IsNothing(m_SetDeviceNumber) Then
				Return m_SetDeviceNumber(m_hACam, Number)
			End If
			Return 0
		End Function

		Public Function GetDeviceName(ByVal index As Integer, ByVal szDeviceName As System.Text.StringBuilder, ByVal Size As Integer) As Integer
			If Not IsNothing(m_GetDeviceName) Then
				Return m_GetDeviceName(m_hACam, index, szDeviceName, Size)
			End If
			Return 0
		End Function

		Public Function StartPreview() As Integer
			If Not IsNothing(m_StartPreview) Then
				Return m_StartPreview(m_hACam)
			End If
			Return 0
		End Function

		Public Function StopPreview() As Integer
			If Not IsNothing(m_StopPreview) Then
				Return m_StopPreview(m_hACam)
			End If
			Return 0
		End Function

		Public Function GetImage(ByVal lpImage As Byte(), ByVal Size As Integer, ByVal TopDown As Integer) As Integer
			If Not IsNothing(m_GetImageA) Then
				Return m_GetImageA(m_hACam, lpImage, Size, TopDown)
			End If
			Return 0
		End Function

		Public Function GetImage(ByVal lpImage As IntPtr, ByVal Size As Integer, ByVal TopDown As Integer) As Integer
			If Not IsNothing(m_GetImageP) Then
				Return m_GetImageP(m_hACam, lpImage, Size, TopDown)
			End If
			Return 0
		End Function

		Public Function Width() As Integer
			If Not IsNothing(m_Width) Then
				Return m_Width(m_hACam)
			End If
			Return 0
		End Function

		Public Function Height() As Integer
			If Not IsNothing(m_Height) Then
				Return m_Height(m_hACam)
			End If
			Return 0
		End Function

		Public Function Fps() As Integer
			If Not IsNothing(m_Fps) Then
				Return m_Fps(m_hACam)
			End If
			Return 0
		End Function

		Public Function SetCameraDlg(ByVal hWnd As IntPtr) As Integer
			If Not IsNothing(m_SetCameraDlg) Then
				Return m_SetCameraDlg(m_hACam, hWnd)
			End If
			Return 0
		End Function

		Public Function SetImageDlg(ByVal hWnd As IntPtr) As Integer
			If Not IsNothing(m_SetImageDlg) Then
				Return m_SetImageDlg(m_hACam, hWnd)
			End If
			Return 0
		End Function

		Public Function SetAnalogDlg(ByVal hWnd As IntPtr) As Integer
			If Not IsNothing(m_SetAnalogDlg) Then
				Return m_SetAnalogDlg(m_hACam, hWnd)
			End If
			Return 0
		End Function

		' 1230
		Public Function SetIOPort(ByVal byteData As Integer, ByVal longData As Integer, ByVal Reserve As Integer) As Integer
			If Not IsNothing(m_SetIOPort) Then
				Return m_SetIOPort(m_hACam, byteData, longData, Reserve)
			End If
			Return 0
		End Function

		Public Function GetIOPort(ByRef byteData As Byte, ByRef longData As Integer, ByVal Reserve As Integer) As Integer
			If Not IsNothing(m_GetIOPort) Then
				Return m_GetIOPort(m_hACam, byteData, longData, Reserve)
			End If
			Return 0
		End Function

		Public Function SetFilterValue(ByVal FilterType As Integer, ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetFilterValue) Then
				Return m_SetFilterValue(m_hACam, FilterType, Value)
			End If
			Return 0
		End Function

		Public Function GetFilterValue(ByVal FilterType As Integer) As Integer
			If Not IsNothing(m_GetFilterValue) Then
				Return m_GetFilterValue(m_hACam, FilterType, m_Error)
			End If
			Return 0
		End Function

		Public Function SetSubSample(ByVal SubSampleMode As Integer) As Integer
			If Not IsNothing(m_SetSubSample) Then
				Return m_SetSubSample(m_hACam, SubSampleMode)
			End If
			Return 0
		End Function

		Public Function GetSubSample() As Integer
			If Not IsNothing(m_GetSubSample) Then
				Return m_GetSubSample(m_hACam)
			End If
			Return 0
		End Function

		Public Function SetWaitTime(ByVal WaitTime As Integer) As Integer
			If Not IsNothing(m_SetWaitTime) Then
				Return m_SetWaitTime(m_hACam, WaitTime)
			End If
			Return 0
		End Function

		Public Function GetWaitTime() As Integer
			If Not IsNothing(m_GetWaitTime) Then
				Return m_GetWaitTime(m_hACam)
			End If
			Return 0
		End Function

		' 1240
		Public Function SetMirrorV(ByVal Flg As Integer) As Integer
			If Not IsNothing(m_SetMirrorV) Then
				Return m_SetMirrorV(m_hACam, Flg)
			End If
			Return 0
		End Function

		Public Function GetMirrorV() As Integer
			If Not IsNothing(m_GetMirrorV) Then
				Return m_GetMirrorV(m_hACam)
			End If
			Return 0
		End Function

		Public Function SetMirrorH(ByVal Flg As Integer) As Integer
			If Not IsNothing(m_SetMirrorH) Then
				Return m_SetMirrorH(m_hACam, Flg)
			End If
			Return 0
		End Function

		Public Function GetMirrorH() As Integer
			If Not IsNothing(m_GetMirrorH) Then
				Return m_GetMirrorH(m_hACam)
			End If
			Return 0
		End Function

		Public Function SetBrightness(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetBrightness) Then
				Return m_SetBrightness(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetBrightness() As Integer
			If Not IsNothing(m_GetBrightness) Then
				Return m_GetBrightness(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetContrast(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetContrast) Then
				Return m_SetContrast(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetContrast() As Integer
			If Not IsNothing(m_GetContrast) Then
				Return m_GetContrast(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetHue(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetHue) Then
				Return m_SetHue(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetHue() As Integer
			If Not IsNothing(m_GetHue) Then
				Return m_GetHue(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetSaturation(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetSaturation) Then
				Return m_SetSaturation(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetSaturation() As Integer
			If Not IsNothing(m_GetSaturation) Then
				Return m_GetSaturation(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetSharpness(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetSharpness) Then
				Return m_SetSharpness(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetSharpness() As Integer
			If Not IsNothing(m_GetSharpness) Then
				Return m_GetSharpness(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetBayerGainRGB(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetBayerGainRGB) Then
				Return m_SetBayerGainRGB(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetBayerGainRGB() As Integer
			If Not IsNothing(m_GetBayerGainRGB) Then
				Return m_GetBayerGainRGB(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetBayerGainRed(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetBayerGainRed) Then
				Return m_SetBayerGainRed(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetBayerGainRed() As Integer
			If Not IsNothing(m_GetBayerGainRed) Then
				Return m_GetBayerGainRed(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetBayerGainGreen(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetBayerGainGreen) Then
				Return m_SetBayerGainGreen(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetBayerGainGreen() As Integer
			If Not IsNothing(m_GetBayerGainGreen) Then
				Return m_GetBayerGainGreen(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetBayerGainBlue(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetBayerGainBlue) Then
				Return m_SetBayerGainBlue(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetBayerGainBlue() As Integer
			If Not IsNothing(m_GetBayerGainBlue) Then
				Return m_GetBayerGainBlue(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetBayerGainAuto(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetBayerGainAuto) Then
				Return m_SetBayerGainAuto(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetBayerGainAuto() As Integer
			If Not IsNothing(m_GetBayerGainAuto) Then
				Return m_GetBayerGainAuto(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetGamma(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetGamma) Then
				Return m_SetGamma(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetGamma() As Integer
			If Not IsNothing(m_GetGamma) Then
				Return m_GetGamma(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetBayerMode(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetBayerMode) Then
				Return m_SetBayerMode(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetBayerMode() As Integer
			If Not IsNothing(m_GetBayerMode) Then
				Return m_GetBayerMode(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetGlobalGain(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetGlobalGain) Then
				Return m_SetGlobalGain(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetGlobalGain() As Integer
			If Not IsNothing(m_GetGlobalGain) Then
				Return m_GetGlobalGain(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetColorGainRed(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetColorGainRed) Then
				Return m_SetColorGainRed(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetColorGainRed() As Integer
			If Not IsNothing(m_GetColorGainRed) Then
				Return m_GetColorGainRed(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetColorGainGreen1(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetColorGainGreen1) Then
				Return m_SetColorGainGreen1(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetColorGainGreen1() As Integer
			If Not IsNothing(m_GetColorGainGreen1) Then
				Return m_GetColorGainGreen1(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetColorGainGreen2(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetColorGainGreen2) Then
				Return m_SetColorGainGreen2(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetColorGainGreen2() As Integer
			If Not IsNothing(m_GetColorGainGreen2) Then
				Return m_GetColorGainGreen2(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetColorGainBlue(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetColorGainBlue) Then
				Return m_SetColorGainBlue(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetColorGainBlue() As Integer
			If Not IsNothing(m_GetColorGainBlue) Then
				Return m_GetColorGainBlue(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetExposureTime(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetExposureTime) Then
				Return m_SetExposureTime(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetExposureTime() As Integer
			If Not IsNothing(m_GetExposureTime) Then
				Return m_GetExposureTime(m_hACam, m_Error)
			End If
			Return 0
		End Function

		' 1260
		Public Function SetHalfClock(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetHalfClock) Then
				Return m_SetHalfClock(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetHalfClock() As Integer
			If Not IsNothing(m_GetHalfClock) Then
				Return m_GetHalfClock(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetAutoIris(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetAutoIris) Then
				Return m_SetAutoIris(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetAutoIris() As Integer
			If Not IsNothing(m_GetAutoIris) Then
				Return m_GetAutoIris(m_hACam, m_Error)
			End If
			Return 0
		End Function

		' 1275
		Public Function SetSamplingRate(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetSamplingRate) Then
				Return m_SetSamplingRate(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetSamplingRate() As Integer
			If Not IsNothing(m_GetSamplingRate) Then
				Return m_GetSamplingRate(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function GetVideoFormat() As Integer
			If Not IsNothing(m_GetVideoFormat) Then
				Return m_GetVideoFormat(m_hACam, m_Error)
			End If
			Return 0
		End Function

		' 1276
		Public Function WriteSromID(ByVal Address As Integer, ByVal Value As Integer) As Integer
			If Not IsNothing(m_WriteSromID) Then
				Return m_WriteSromID(m_hACam, Address, Value)
			End If
			Return 0
		End Function

		Public Function ReadSromID(ByVal Address As Integer) As Integer
			If Not IsNothing(m_ReadSromID) Then
				Return m_ReadSromID(m_hACam, Address, m_Error)
			End If
			Return 0
		End Function

		' 1280
		Public Function GetCameraInfo(ByRef pInfo As CAMERAINFO) As Integer
			If Not IsNothing(m_GetCameraInfo) Then
				Return m_GetCameraInfo(m_hACam, pInfo)
			End If
			Return 0
		End Function
		Public Function GetStatus(ByRef pError As Integer) As Integer
			If Not IsNothing(m_GetStatus) Then
				Return m_GetStatus(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function WriteRegister(ByVal Address As Byte, ByVal Value As Integer) As Integer
			If Not IsNothing(m_WriteRegister) Then
				Return m_WriteRegister(m_hACam, Address, Value)
			End If
			Return 0
		End Function

		Public Function ReadRegister(ByVal Address As Byte, ByRef pError As Integer) As Integer
			If Not IsNothing(m_ReadRegister) Then
				Return m_ReadRegister(m_hACam, Address, m_Error)
			End If
			Return 0
		End Function

		Public Function SetGrayMode(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetGrayMode) Then
				Return m_SetGrayMode(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetGrayMode(ByRef pError As Integer) As Integer
			If Not IsNothing(m_GetGrayMode) Then
				Return m_GetGrayMode(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetGrayGainR(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetGrayGainR) Then
				Return m_SetGrayGainR(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetGrayGainR(ByRef pError As Integer) As Integer
			If Not IsNothing(m_GetGrayGainR) Then
				Return m_GetGrayGainR(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetGrayGainG1(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetGrayGainG1) Then
				Return m_SetGrayGainG1(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetGrayGainG1(ByRef pError As Integer) As Integer
			If Not IsNothing(m_GetGrayGainG1) Then
				Return m_GetGrayGainG1(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetGrayGainG2(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetGrayGainG2) Then
				Return m_SetGrayGainG2(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetGrayGainG2(ByRef pError As Integer) As Integer
			If Not IsNothing(m_GetGrayGainG2) Then
				Return m_GetGrayGainG2(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetGrayGainB(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetGrayGainB) Then
				Return m_SetGrayGainB(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetGrayGainB(ByRef pError As Integer) As Integer
			If Not IsNothing(m_GetGrayGainB) Then
				Return m_GetGrayGainB(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetGrayOffsetR(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetGrayOffsetR) Then
				Return m_SetGrayOffsetR(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetGrayOffsetR(ByRef pError As Integer) As Integer
			If Not IsNothing(m_GetGrayOffsetR) Then
				Return m_GetGrayOffsetR(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetGrayOffsetG1(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetGrayOffsetG1) Then
				Return m_SetGrayOffsetG1(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetGrayOffsetG1(ByRef pError As Integer) As Integer
			If Not IsNothing(m_GetGrayOffsetG1) Then
				Return m_GetGrayOffsetG1(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetGrayOffsetG2(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetGrayOffsetG2) Then
				Return m_SetGrayOffsetG2(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetGrayOffsetG2(ByRef pError As Integer) As Integer
			If Not IsNothing(m_GetGrayOffsetG2) Then
				Return m_GetGrayOffsetG2(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetGrayOffsetB(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetGrayOffsetB) Then
				Return m_SetGrayOffsetB(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetGrayOffsetB(ByRef pError As Integer) As Integer
			If Not IsNothing(m_GetGrayOffsetB) Then
				Return m_GetGrayOffsetB(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetCameraType(ByVal Flg As Integer) As Integer
			If Not IsNothing(m_SetCameraType) Then
				Return m_SetCameraType(m_hACam, Flg)
			End If
			Return 0
		End Function

		Public Function GetCameraType(ByRef pError As Integer) As Integer
			If Not IsNothing(m_GetCameraType) Then
				Return m_GetCameraType(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function Fpga_WriteRegister(ByVal Address As Byte, ByVal Value As Integer) As Integer
			If Not IsNothing(m_Fpga_WriteRegister) Then
				Return m_Fpga_WriteRegister(m_hACam, Address, Value)
			End If
			Return 0
		End Function

		Public Function Fpga_ReadRegister(ByVal Address As Byte, ByRef pError As Integer) As Integer
			If Not IsNothing(m_Fpga_ReadRegister) Then
				Return m_Fpga_ReadRegister(m_hACam, Address, m_Error)
			End If
			Return 0
		End Function

		Public Function Monitor_SetPreviewMode(ByVal Preview As Boolean) As Integer
			If Not IsNothing(m_Monitor_SetPreviewMode) Then
				Return m_Monitor_SetPreviewMode(m_hACam, Preview)
			End If
			Return 0
		End Function

		Public Function Monitor_GetPreviewMode(ByRef pError As Integer) As Integer
			If Not IsNothing(m_Monitor_GetPreviewMode) Then
				Return m_Monitor_GetPreviewMode(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function Monitor_SetPreviewSize(ByVal Width As Integer, ByVal Height As Integer) As Integer
			If Not IsNothing(m_Monitor_SetPreviewSize) Then
				Return m_Monitor_SetPreviewSize(m_hACam, Width, Height)
			End If
			Return 0
		End Function

		Public Function Monitor_GetPreviewSize(ByRef Width As Integer, ByRef Height As Integer) As Integer
			If Not IsNothing(m_Monitor_GetPreviewSize) Then
				Return m_Monitor_GetPreviewSize(m_hACam, Width, Height)
			End If
			Return 0
		End Function

		Public Function Monitor_SetColorMode(ByVal ColorMode As Boolean) As Integer
			If Not IsNothing(m_Monitor_SetColorMode) Then
				Return m_Monitor_SetColorMode(m_hACam, ColorMode)
			End If
			Return 0
		End Function

		Public Function Monitor_GetColorMode(ByRef pError As Integer) As Integer
			If Not IsNothing(m_Monitor_GetColorMode) Then
				Return m_Monitor_GetColorMode(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function Monitor_SetCameraClock(ByVal Value As Integer) As Integer
			If Not IsNothing(m_Monitor_SetCameraClock) Then
				Return m_Monitor_SetCameraClock(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function Monitor_GetCameraClock(ByRef pError As Integer) As Integer
			If Not IsNothing(m_Monitor_GetCameraClock) Then
				Return m_Monitor_GetCameraClock(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function Monitor_SetBayerGainAuto(ByVal Value As Integer) As Integer
			If Not IsNothing(m_Monitor_SetBayerGainAuto) Then
				Return m_Monitor_SetBayerGainAuto(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function Monitor_GetBayerGainAuto(ByRef pError As Integer) As Integer
			If Not IsNothing(m_Monitor_GetBayerGainAuto) Then
				Return m_Monitor_GetBayerGainAuto(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function Monitor_SetBayerGainLock(ByVal Value As Integer) As Integer
			If Not IsNothing(m_Monitor_SetBayerGainLock) Then
				Return m_Monitor_SetBayerGainLock(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function Monitor_GetBayerGainLock(ByRef pError As Integer) As Integer
			If Not IsNothing(m_Monitor_GetBayerGainLock) Then
				Return m_Monitor_GetBayerGainLock(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function Monitor_SetBayerGainRed(ByVal Value As Integer) As Integer
			If Not IsNothing(m_Monitor_SetBayerGainRed) Then
				Return m_Monitor_SetBayerGainRed(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function Monitor_GetBayerGainRed(ByRef pError As Integer) As Integer
			If Not IsNothing(m_Monitor_GetBayerGainRed) Then
				Return m_Monitor_GetBayerGainRed(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function Monitor_SetBayerGainGreen(ByVal Value As Integer) As Integer
			If Not IsNothing(m_Monitor_SetBayerGainGreen) Then
				Return m_Monitor_SetBayerGainGreen(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function Monitor_GetBayerGainGreen(ByRef pError As Integer) As Integer
			If Not IsNothing(m_Monitor_GetBayerGainGreen) Then
				Return m_Monitor_GetBayerGainGreen(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function Monitor_SetBayerGainBlue(ByVal Value As Integer) As Integer
			If Not IsNothing(m_Monitor_SetBayerGainBlue) Then
				Return m_Monitor_SetBayerGainBlue(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function Monitor_GetBayerGainBlue(ByRef pError As Integer) As Integer
			If Not IsNothing(m_Monitor_GetBayerGainBlue) Then
				Return m_Monitor_GetBayerGainBlue(m_hACam, m_Error)
			End If
			Return 0
		End Function


		Public Function SetSyncV(ByVal Flg As Integer) As Integer
			If Not IsNothing(m_SetSyncV) Then
				Return m_SetSyncV(m_hACam, Flg)
			End If
			Return 0
		End Function

		Public Function GetSyncV(ByRef pError As Integer) As Integer
			If Not IsNothing(m_GetSyncV) Then
				Return m_GetSyncV(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetSyncH(ByVal Flg As Integer) As Integer
			If Not IsNothing(m_SetSyncH) Then
				Return m_SetSyncH(m_hACam, Flg)
			End If
			Return 0
		End Function

		Public Function GetSyncH(ByRef pError As Integer) As Integer
			If Not IsNothing(m_GetSyncH) Then
				Return m_GetSyncH(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function WriteRegisterEx(ByVal Address As Integer, ByVal Value As Integer) As Integer
			If Not IsNothing(m_WriteRegisterEx) Then
				Return m_WriteRegisterEx(m_hACam, Address, Value)
			End If
			Return 0
		End Function

		Public Function ReadRegisterEx(ByVal Address As Integer, ByRef pError As Integer) As Integer
			If Not IsNothing(m_ReadRegisterEx) Then
				Return m_ReadRegisterEx(m_hACam, Address, m_Error)
			End If
			Return 0
		End Function

		Public Function Monitor_SaveCurrentSettings() As Integer
			If Not IsNothing(m_Monitor_SaveCurrentSettings) Then
				Return m_Monitor_SaveCurrentSettings(m_hACam)
			End If
			Return 0
		End Function

		Public Function Monitor_InitRegisterSettings(ByVal Flg As Integer) As Integer
			If Not IsNothing(m_Monitor_InitRegisterSettings) Then
				Return m_Monitor_InitRegisterSettings(m_hACam, Flg)
			End If
			Return 0
		End Function

		Public Function Monitor_LoadFirmware(ByVal szFileName As System.Text.StringBuilder) As Integer
			If Not IsNothing(m_Monitor_LoadFirmware) Then
				Return m_Monitor_LoadFirmware(m_hACam, szFileName)
			End If
			Return 0
		End Function

		Public Function Monitor_SetCrossCursorMode(ByVal CursorNum As Integer, ByVal Value As Integer) As Integer
			If Not IsNothing(m_Monitor_SetCrossCursorMode) Then
				Return m_Monitor_SetCrossCursorMode(m_hACam, CursorNum, Value)
			End If
			Return 0
		End Function
		Public Function Monitor_GetCrossCursorMode(ByVal CursorNum As Integer, ByRef pError As Integer) As Integer
			If Not IsNothing(m_Monitor_GetCrossCursorMode) Then
				Return m_Monitor_GetCrossCursorMode(m_hACam, CursorNum, m_Error)
			End If
			Return 0
		End Function
		Public Function Monitor_SetCrossCursorColorR(ByVal CursorNum As Integer, ByVal Value As Integer) As Integer
			If Not IsNothing(m_Monitor_SetCrossCursorColorR) Then
				Return m_Monitor_SetCrossCursorColorR(m_hACam, CursorNum, Value)
			End If
			Return 0
		End Function
		Public Function Monitor_GetCrossCursorColorR(ByVal CursorNum As Integer, ByRef pError As Integer) As Integer
			If Not IsNothing(m_Monitor_GetCrossCursorColorR) Then
				Return m_Monitor_GetCrossCursorColorR(m_hACam, CursorNum, m_Error)
			End If
			Return 0
		End Function

		Public Function Monitor_SetCrossCursorColorG(ByVal CursorNum As Integer, ByVal Value As Integer) As Integer
			If Not IsNothing(m_Monitor_SetCrossCursorColorG) Then
				Return m_Monitor_SetCrossCursorColorG(m_hACam, CursorNum, Value)
			End If
			Return 0
		End Function

		Public Function Monitor_GetCrossCursorColorG(ByVal CursorNum As Integer, ByRef pError As Integer) As Integer
			If Not IsNothing(m_Monitor_GetCrossCursorColorG) Then
				Return m_Monitor_GetCrossCursorColorG(m_hACam, CursorNum, m_Error)
			End If
			Return 0
		End Function

		Public Function Monitor_SetCrossCursorColorB(ByVal CursorNum As Integer, ByVal Value As Integer) As Integer
			If Not IsNothing(m_Monitor_SetCrossCursorColorB) Then
				Return m_Monitor_SetCrossCursorColorB(m_hACam, CursorNum, Value)
			End If
			Return 0
		End Function

		Public Function Monitor_GetCrossCursorColorB(ByVal CursorNum As Integer, ByRef pError As Integer) As Integer
			If Not IsNothing(m_Monitor_GetCrossCursorColorB) Then
				Return m_Monitor_GetCrossCursorColorB(m_hACam, CursorNum, m_Error)
			End If
			Return 0
		End Function

		Public Function Monitor_SetCrossCursorColorRGB(ByVal CursorNum As Integer, ByVal Value As Integer) As Integer
			If Not IsNothing(m_Monitor_SetCrossCursorColorRGB) Then
				Return m_Monitor_SetCrossCursorColorRGB(m_hACam, CursorNum, Value)
			End If
			Return 0
		End Function

		Public Function Monitor_GetCrossCursorColorRGB(ByVal CursorNum As Integer, ByRef pError As Integer) As Integer
			If Not IsNothing(m_Monitor_GetCrossCursorColorRGB) Then
				Return m_Monitor_GetCrossCursorColorRGB(m_hACam, CursorNum, m_Error)
			End If
			Return 0
		End Function

		Public Function Monitor_SetCrossCursorPos(ByVal CursorNum As Integer, ByVal ValueX As Integer, ByVal ValueY As Integer) As Integer
			If Not IsNothing(m_Monitor_SetCrossCursorPos) Then
				Return m_Monitor_SetCrossCursorPos(m_hACam, CursorNum, ValueX, ValueY)
			End If
			Return 0
		End Function

		Public Function Monitor_GetCrossCursorPos(ByVal CursorNum As Integer, ByRef ValueX As Integer, ByRef ValueY As Integer) As Integer
			If Not IsNothing(m_Monitor_GetCrossCursorPos) Then
				Return m_Monitor_GetCrossCursorPos(m_hACam, CursorNum, ValueX, ValueY)
			End If
			Return 0
		End Function

		Public Function Monitor_SetCrossCursorSize(ByVal CursorNum As Integer, ByVal ValueX As Integer, ByVal ValueY As Integer) As Integer
			If Not IsNothing(m_Monitor_SetCrossCursorSize) Then
				Return m_Monitor_SetCrossCursorSize(m_hACam, CursorNum, ValueX, ValueY)
			End If
			Return 0
		End Function

		Public Function Monitor_GetCrossCursorSize(ByVal CursorNum As Integer, ByRef ValueX As Integer, ByRef ValueY As Integer) As Integer
			If Not IsNothing(m_Monitor_GetCrossCursorSize) Then
				Return m_Monitor_GetCrossCursorSize(m_hACam, CursorNum, ValueX, ValueY)
			End If
			Return 0
		End Function

		Public Function Monitor_SetAutoIrisMode(ByVal Value As Integer) As Integer
			If Not IsNothing(m_Monitor_SetAutoIrisMode) Then
				Return m_Monitor_SetAutoIrisMode(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function Monitor_GetAutoIrisMode(ByRef pError As Integer) As Integer
			If Not IsNothing(m_Monitor_GetAutoIrisMode) Then
				Return m_Monitor_GetAutoIrisMode(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function Monitor_SetAutoIrisRange(ByVal Min As Integer, ByVal Max As Integer) As Integer
			If Not IsNothing(m_Monitor_SetAutoIrisRange) Then
				Return m_Monitor_SetAutoIrisRange(m_hACam, Min, Max)
			End If
			Return 0
		End Function

		Public Function Monitor_GetAutoIrisRange(ByRef Min As Integer, ByRef Max As Integer) As Integer
			If Not IsNothing(m_Monitor_GetAutoIrisRange) Then
				Return m_Monitor_GetAutoIrisRange(m_hACam, Min, Max)
			End If
			Return 0
		End Function

		' 1300
		Public Function GetRealExposureTime(ByRef pError As Integer) As Integer
			If Not IsNothing(m_GetRealExposureTime) Then
				Return m_GetRealExposureTime(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetRealExposureTime(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetRealExposureTime) Then
				Return m_SetRealExposureTime(m_hACam, Value)
			End If
			Return 0
		End Function

		' TNIR
		Public Function SaveMaskFile(ByVal szFileName As StringBuilder)	As Integer
			If Not IsNothing(m_SaveMaskFile) Then
				Return m_SaveMaskFile(m_hACam, szFileName)
			End If
			Return 0
		End Function

		Public Function LoadMaskFile(ByVal szFileName As StringBuilder)	As Integer
			If Not IsNothing(m_LoadMaskFile) Then
				Return m_LoadMaskFile(m_hACam, szFileName)
			End If
			Return 0
		End Function

		Public Function UpdateMaskData(ByVal Flg As MASKTYPE) As Integer
			If Not IsNothing(m_UpdateMaskData) Then
				Return m_UpdateMaskData(m_hACam, Flg)
			End If
			Return 0
		End Function

		Public Function SetPeltier(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetPeltier) Then
				Return m_SetPeltier(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetPeltier() As Integer
			If Not IsNothing(m_GetPeltier) Then
				Return m_GetPeltier(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function GetTemperature() As Integer
			If Not IsNothing(m_GetTemperature) Then
				Return m_GetTemperature(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetDotFilter(ByVal Value As Integer) As Integer
            If Not IsNothing(m_SetDotFilter) Then
                Return m_SetDotFilter(m_hACam, Value)
            End If
			Return 0
		End Function

		Public Function GetDotFilter() As Integer
			If Not IsNothing(m_GetDotFilter) Then
				Return m_GetDotFilter(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetMaskFilter(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetMaskFilter) Then
				Return m_SetMaskFilter(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetMaskFilter() As Integer
			If Not IsNothing(m_GetMaskFilter) Then
				Return m_GetMaskFilter(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function SetInternalCorrection(ByVal Enable As Integer) As Integer
			If Not IsNothing(m_SetInternalCorrection) Then
				Return m_SetInternalCorrection(m_hACam, Enable)
			End If
			Return 0
		End Function

		Public Function GetInternalCorrection() As Integer
			If Not IsNothing(m_GetInternalCorrection) Then
				Return m_GetInternalCorrection(m_hACam, m_Error)
			End If
			Return 0
		End Function

		Public Function LoadConfigFile(ByVal szFileName As StringBuilder) As Integer
			If Not IsNothing(m_LoadConfigFile) Then
				Return m_LoadConfigFile(m_hACam, szFileName)
			End If
			Return 0
		End Function
		Public Function SetConfigFilter(ByVal Value As Integer) As Integer
			If Not IsNothing(m_SetConfigFilter) Then
				Return m_SetConfigFilter(m_hACam, Value)
			End If
			Return 0
		End Function
		Public Function GetConfigFilter() As Integer
			If Not IsNothing(m_GetConfigFilter) Then
				Return m_GetConfigFilter(m_hACam)
			End If
			Return 0
		End Function

		Public Function GetTemperatureEx() As Double
			If Not IsNothing(m_GetTemperatureEx) Then
				Return m_GetTemperatureEx(m_hACam, m_Error)
			End If
			Return 0.0
		End Function

		Public Function SetExposureTimeEx(ByVal Value As Double) As Integer
			If Not IsNothing(m_SetExposureTimeEx) Then
				Return m_SetExposureTimeEx(m_hACam, Value)
			End If
			Return 0
		End Function

		Public Function GetExposureTimeEx() As Double
			If Not IsNothing(m_GetExposureTimeEx) Then
                Return m_GetExposureTimeEx(m_hACam, m_Error)
			End If
			Return -1.0
		End Function

	End Class
End Namespace

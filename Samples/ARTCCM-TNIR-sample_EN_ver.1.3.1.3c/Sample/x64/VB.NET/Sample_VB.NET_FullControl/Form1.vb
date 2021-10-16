Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Text
Imports System.IO
Imports System.Runtime.InteropServices.Marshal
Imports Sample_VB.ArtCamSdk

Public Class Form1
    Inherits System.Windows.Forms.Form

	Dim m_DllType As Integer = -1
	Dim m_DllCount As Integer = 0
	Dim m_DllSata As Integer = -1
	Dim m_SataType As Integer = -1
 Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
 Friend WithEvents MenuUserCorrection As System.Windows.Forms.MenuItem
	Dim m_CurrentCameraType As Integer = 0


#Region "Code made by Windows form designer "

    Public Sub New()
        MyBase.New()

        ' This call required for Windows firm designer Required for Windows firm designer
        InitializeComponent()

        ' InitializeComponent() Add initialization after call

    End Sub

    ' "Form" overwrites "disclose and delete component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Required for Windows firm designer
    Private components As System.ComponentModel.IContainer

    ' Memo: following procedure are required for Windows firm designer
    ' Use Windows firm designer to modify.  
    ' Do not use code editor
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuFile As System.Windows.Forms.MenuItem
    Friend WithEvents MenuSave As System.Windows.Forms.MenuItem
    Friend WithEvents MenuExit As System.Windows.Forms.MenuItem
    Friend WithEvents MenuView As System.Windows.Forms.MenuItem
    Friend WithEvents MenuPreview As System.Windows.Forms.MenuItem
    Friend WithEvents MenuCallback As System.Windows.Forms.MenuItem
    Friend WithEvents MenuSnapshot As System.Windows.Forms.MenuItem
    Friend WithEvents MenuCapture As System.Windows.Forms.MenuItem
    Friend WithEvents MenuTrigger As System.Windows.Forms.MenuItem
    Friend WithEvents MenuSet As System.Windows.Forms.MenuItem
    Friend WithEvents MenuCamera As System.Windows.Forms.MenuItem
    Friend WithEvents MenuFilter As System.Windows.Forms.MenuItem
    Friend WithEvents MenuAnalog As System.Windows.Forms.MenuItem
    Friend WithEvents MenuDevice As System.Windows.Forms.MenuItem
    Friend WithEvents MenuDevice0 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuDevice1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuDevice2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuDevice3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuDevice4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuDevice5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuDevice6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuDevice7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuDevice8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuDevice9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuRec As System.Windows.Forms.MenuItem
    Friend WithEvents MenuStop As System.Windows.Forms.MenuItem
    Friend WithEvents MenuUserSize As System.Windows.Forms.MenuItem
    Friend WithEvents MenuUserFilter As System.Windows.Forms.MenuItem
    Friend WithEvents TimerRec As System.Windows.Forms.Timer
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MenuUserIO As System.Windows.Forms.MenuItem
    Friend WithEvents MenuUserMonitor As System.Windows.Forms.MenuItem
    Friend WithEvents MenuDll As System.Windows.Forms.MenuItem
	Friend WithEvents menuDllReload As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container
		Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
		Me.MenuFile = New System.Windows.Forms.MenuItem
		Me.MenuSave = New System.Windows.Forms.MenuItem
		Me.MenuRec = New System.Windows.Forms.MenuItem
		Me.MenuExit = New System.Windows.Forms.MenuItem
		Me.MenuView = New System.Windows.Forms.MenuItem
		Me.MenuPreview = New System.Windows.Forms.MenuItem
		Me.MenuCallback = New System.Windows.Forms.MenuItem
		Me.MenuSnapshot = New System.Windows.Forms.MenuItem
		Me.MenuCapture = New System.Windows.Forms.MenuItem
		Me.MenuTrigger = New System.Windows.Forms.MenuItem
		Me.MenuItem3 = New System.Windows.Forms.MenuItem
		Me.MenuStop = New System.Windows.Forms.MenuItem
		Me.MenuSet = New System.Windows.Forms.MenuItem
		Me.MenuCamera = New System.Windows.Forms.MenuItem
		Me.MenuFilter = New System.Windows.Forms.MenuItem
		Me.MenuAnalog = New System.Windows.Forms.MenuItem
		Me.MenuItem4 = New System.Windows.Forms.MenuItem
		Me.MenuUserSize = New System.Windows.Forms.MenuItem
		Me.MenuUserFilter = New System.Windows.Forms.MenuItem
		Me.MenuUserIO = New System.Windows.Forms.MenuItem
		Me.MenuUserMonitor = New System.Windows.Forms.MenuItem
		Me.MenuDll = New System.Windows.Forms.MenuItem
		Me.menuDllReload = New System.Windows.Forms.MenuItem
		Me.MenuDevice = New System.Windows.Forms.MenuItem
		Me.MenuDevice0 = New System.Windows.Forms.MenuItem
		Me.MenuDevice1 = New System.Windows.Forms.MenuItem
		Me.MenuDevice2 = New System.Windows.Forms.MenuItem
		Me.MenuDevice3 = New System.Windows.Forms.MenuItem
		Me.MenuDevice4 = New System.Windows.Forms.MenuItem
		Me.MenuDevice5 = New System.Windows.Forms.MenuItem
		Me.MenuDevice6 = New System.Windows.Forms.MenuItem
		Me.MenuDevice7 = New System.Windows.Forms.MenuItem
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.TimerRec = New System.Windows.Forms.Timer(Me.components)
		Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
		Me.MenuItem1 = New System.Windows.Forms.MenuItem
		Me.MenuUserCorrection = New System.Windows.Forms.MenuItem
		Me.SuspendLayout()
		'
		'MainMenu1
		'
		Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuFile, Me.MenuView, Me.MenuSet, Me.MenuDll, Me.MenuDevice})
		'
		'MenuFile
		'
		Me.MenuFile.Index = 0
		Me.MenuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuSave, Me.MenuRec, Me.MenuExit})
		Me.MenuFile.Text = "File(&F)"
		'
		'MenuSave
		'
		Me.MenuSave.Index = 0
		Me.MenuSave.Text = "Save(&S)"
		'
		'MenuRec
		'
		Me.MenuRec.Index = 1
		Me.MenuRec.Text = "Recording(&R)"
		'
		'MenuExit
		'
		Me.MenuExit.Index = 2
		Me.MenuExit.Text = "End(&X)"
		'
		'MenuView
		'
		Me.MenuView.Index = 1
		Me.MenuView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuPreview, Me.MenuCallback, Me.MenuSnapshot, Me.MenuCapture, Me.MenuTrigger, Me.MenuItem3, Me.MenuStop})
		Me.MenuView.Text = "Display(&V)"
		'
		'MenuPreview
		'
		Me.MenuPreview.Index = 0
		Me.MenuPreview.Text = "Preview(&P)"
		'
		'MenuCallback
		'
		Me.MenuCallback.Index = 1
		Me.MenuCallback.Text = "Callback(&B)"
		'
		'MenuSnapshot
		'
		Me.MenuSnapshot.Index = 2
		Me.MenuSnapshot.Text = "Snapshot(&S)"
		'
		'MenuCapture
		'
		Me.MenuCapture.Index = 3
		Me.MenuCapture.Text = "Capture(&C)"
		'
		'MenuTrigger
		'
		Me.MenuTrigger.Index = 4
		Me.MenuTrigger.Text = "Trigger(&T)"
		'
		'MenuItem3
		'
		Me.MenuItem3.Index = 5
		Me.MenuItem3.Text = "-"
		'
		'MenuStop
		'
		Me.MenuStop.Index = 6
		Me.MenuStop.Text = "Pause"
		'
		'MenuSet
		'
		Me.MenuSet.Index = 2
		Me.MenuSet.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuCamera, Me.MenuFilter, Me.MenuAnalog, Me.MenuItem4, Me.MenuUserSize, Me.MenuUserFilter, Me.MenuUserIO, Me.MenuUserMonitor, Me.MenuItem1, Me.MenuUserCorrection})
		Me.MenuSet.Text = "Settings(&S)"
		'
		'MenuCamera
		'
		Me.MenuCamera.Index = 0
		Me.MenuCamera.Text = "Camera settings(&C)"
		'
		'MenuFilter
		'
		Me.MenuFilter.Index = 1
		Me.MenuFilter.Text = "Filter settings(&F)"
		'
		'MenuAnalog
		'
		Me.MenuAnalog.Index = 2
		Me.MenuAnalog.Text = "Analog settings(&A)"
		'
		'MenuItem4
		'
		Me.MenuItem4.Index = 3
		Me.MenuItem4.Text = "-"
		'
		'MenuUserSize
		'
		Me.MenuUserSize.Index = 4
		Me.MenuUserSize.Text = "User size settings"
		'
		'MenuUserFilter
		'
		Me.MenuUserFilter.Index = 5
		Me.MenuUserFilter.Text = "User filter settings"
		'
		'MenuUserIO
		'
		Me.MenuUserIO.Index = 6
		Me.MenuUserIO.Text = "User IO settings"
		'
		'MenuUserMonitor
		'
		Me.MenuUserMonitor.Index = 7
		Me.MenuUserMonitor.Text = "User Monitor settings"
		'
		'MenuDll
		'
		Me.MenuDll.Index = 3
		Me.MenuDll.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuDllReload})
		Me.MenuDll.Text = "DLL(&L)"
		'
		'menuDllReload
		'
		Me.menuDllReload.Index = 0
		Me.menuDllReload.Text = "Reload"
		'
		'MenuDevice
		'
		Me.MenuDevice.Index = 4
		Me.MenuDevice.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuDevice0, Me.MenuDevice1, Me.MenuDevice2, Me.MenuDevice3, Me.MenuDevice4, Me.MenuDevice5, Me.MenuDevice6, Me.MenuDevice7})
		Me.MenuDevice.Text = "Device(&D)"
		'
		'MenuDevice0
		'
		Me.MenuDevice0.Index = 0
		Me.MenuDevice0.Text = "0"
		'
		'MenuDevice1
		'
		Me.MenuDevice1.Index = 1
		Me.MenuDevice1.Text = "1"
		'
		'MenuDevice2
		'
		Me.MenuDevice2.Index = 2
		Me.MenuDevice2.Text = "2"
		'
		'MenuDevice3
		'
		Me.MenuDevice3.Index = 3
		Me.MenuDevice3.Text = "3"
		'
		'MenuDevice4
		'
		Me.MenuDevice4.Index = 4
		Me.MenuDevice4.Text = "4"
		'
		'MenuDevice5
		'
		Me.MenuDevice5.Index = 5
		Me.MenuDevice5.Text = "5"
		'
		'MenuDevice6
		'
		Me.MenuDevice6.Index = 6
		Me.MenuDevice6.Text = "6"
		'
		'MenuDevice7
		'
		Me.MenuDevice7.Index = 7
		Me.MenuDevice7.Text = "7"
		'
		'Timer1
		'
		Me.Timer1.Enabled = True
		'
		'TimerRec
		'
		'
		'SaveFileDialog1
		'
		Me.SaveFileDialog1.FileName = "doc1"
		'
		'MenuItem1
		'
		Me.MenuItem1.Index = 8
		Me.MenuItem1.Text = "-"
		'
		'MenuUserCorrection
		'
		Me.MenuUserCorrection.Index = 9
		Me.MenuUserCorrection.Text = "Correction setting"
		'
		'Form1
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
		Me.ClientSize = New System.Drawing.Size(640, 481)
		Me.Menu = Me.MainMenu1
		Me.Name = "Form1"
		Me.Text = "VB Sample"
		Me.ResumeLayout(False)

	End Sub

#End Region

    Dim m_pCapture() As Byte
	Dim m_pTempData() As Byte
	Dim m_Bitmap As Bitmap = Nothing
    Dim m_PreviewMode As Integer = -1
    Dim m_SelectDevice As Integer = -1
	Dim m_ArtCam As CArtCam = New CArtCam
	Dim m_RecName As String
    Dim m_SaveFlg As Boolean = False
    Dim m_StopFlg As Boolean = False


    ' Start form
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Drawing by double buffer(not to flicker)
        SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)

		If File.Exists("Sample.xml") Then
			Dim ser As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetType(Integer()))
			Dim fs As System.IO.FileStream = New System.IO.FileStream("Sample.xml", System.IO.FileMode.Open)
			Dim DllType As Integer() = {0, 0}
			DllType = CType(ser.Deserialize(fs), Integer())
			fs.Close()
			m_DllType = CType(DllType(0), ARTCAM_CAMERATYPE)
			m_SataType = CType(DllType(1), ARTCAM_CAMERATYPE_SATA)
            End If
		OnDllReload()
		OnDllChange(CType(0, Object), System.EventArgs.Empty, m_DllType, m_SataType)
    End Sub


    ' End form
    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		Dim DllType() As Integer = {CType(m_DllType, Integer), CType(m_SataType, Integer)}
			Dim ser As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetType(Integer()))
			Dim fs As System.IO.FileStream = New System.IO.FileStream("Sample.xml", System.IO.FileMode.Create)
			ser.Serialize(fs, DllType)
			fs.Close()
        Release()
    End Sub

    ' Release camera
    Private Sub Release()
		If Not m_ArtCam Is Nothing Then
        m_ArtCam.Release()
        m_PreviewMode = -1
			TimerRec.Enabled = False
        m_SaveFlg = False
        m_StopFlg = False
		End If
    End Sub

    ' Save
    Private Sub MenuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSave.Click
        SaveFileDialog1.Filter = "BITMAPFile(*.bmp)|*.bmp|JPEGFile(*.jpg)|*.jpg*.jpeg|TIFFFile(*.tif)|*.tif*.tiff|PNGFile(*.png)|*.png|RAWFile(*.raw)|*.raw||"

        If DialogResult.OK = SaveFileDialog1.ShowDialog() Then
            ' Set extension yourself
            Dim fileInfo As FileInfo = New FileInfo(SaveFileDialog1.FileName)

            Dim str As String
            str = fileInfo.FullName.Remove(fileInfo.FullName.Length - fileInfo.Extension.Length, fileInfo.Extension.Length)

            Select Case SaveFileDialog1.FilterIndex
                Case 1
                    str += ".bmp"
                    m_ArtCam.SaveImage(str, FILETYPE.FILETYPE_BITMAP)
                Case 2
                    str += ".jpg"
                    m_ArtCam.SaveImage(str, FILETYPE.FILETYPE_JPEG_HIGH)
                Case 3
                    str += ".tif"
                    m_ArtCam.SaveImage(str, FILETYPE.FILETYPE_TIFF)
                Case 4
                    str += ".png"
                    m_ArtCam.SaveImage(str, FILETYPE.FILETYPE_PNG)
                Case 5
                    str += ".raw"
                    m_ArtCam.SaveImage(str, FILETYPE.FILETYPE_RAW)
            End Select
        End If
    End Sub

    ' Recording
    Private Sub MenuRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuRec.Click
        SaveFileDialog1.Filter = "AVIFile(*.avi)|*.avi||"
        SaveFileDialog1.DefaultExt = "avi"

        If DialogResult.OK = SaveFileDialog1.ShowDialog() Then
            m_RecName = SaveFileDialog1.FileName

            ' Pause
            m_ArtCam.Close()

            ' Display on different window while recording
            ' When "hWnd" is NULL, window is created from SDK side and therefore the size is not important.
            m_ArtCam.SetPreviewWindow(IntPtr.Zero, 0, 0, 0, 0)

            ' 5 seconds recording
            m_ArtCam.Record(m_RecName, 5000, 1)


            ' Timing for record ending is not sent from SDK and therefore it needs to be stopped by software.
            ' Just in case, run the timer for 1 sencond longer.
            TimerRec.Interval = 6000
            TimerRec.Enabled = True
        End If
    End Sub

    ' Recording timer
    Private Sub TimerRec_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRec.Tick
        TimerRec.Enabled = False
        m_ArtCam.Close()

        If DialogResult.Yes = MessageBox.Show("Recording completePlay /n file?", "Complete", MessageBoxButtons.YesNo) Then
            System.Diagnostics.Process.Start(m_RecName)
        End If
    End Sub

    ' End
    Private Sub MenuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuExit.Click
        Close()
    End Sub


    ' Preview Draw automatically
    Private Sub MenuPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPreview.Click
        If Not m_ArtCam.IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        ' Release device
        m_ArtCam.Close()

        ' Set window to be displayed
        ' When setting NULL to hWnd,it is possible to create new window and show it.
        m_ArtCam.SetPreviewWindow(Me.Handle(), 0, 0, Me.Width, Me.Height)

        m_ArtCam.Preview()

        ' Check menu
        MenuPreview.Checked = True
        MenuCallback.Checked = False
        MenuCapture.Checked = False
        MenuTrigger.Checked = False

        m_PreviewMode = 0
        m_SaveFlg = True
        m_StopFlg = False
        MenuStop.Text = "Pause"

        Invalidate()
    End Sub


    ' Callback: Obtain image pointer of image and draw its own.
    Private Sub MenuCallback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCallback.Click
        If Not m_ArtCam.IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        ' Release device
        m_ArtCam.Close()

        ' If drawing by yourself, set all window size to 0.
        ' An automatic display can be performed, if window size is set up even when using CallBackPreview
        m_ArtCam.SetPreviewWindow(Handle, 0, 0, 0, 0)

        ' Creat area for capturing
        CreateBitmap()

        ' Capture image
		m_ArtCam.CallBackPreview(Handle, m_pCapture, getSize(), 1)

        ' Check menu
        MenuPreview.Checked = False
        MenuCallback.Checked = True
        MenuCapture.Checked = False
        MenuTrigger.Checked = False

        m_PreviewMode = 1
        m_StopFlg = False
        MenuStop.Text = "Pause"

        Invalidate()
    End Sub


    ' Snapshot
    Private Sub MenuSnapshot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSnapshot.Click
        If Not m_ArtCam.IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        ' Release device
        m_ArtCam.Close()

        ' Creat area for capturing
        CreateBitmap()

        ' Capture image
        m_ArtCam.SnapShot(m_pCapture, getSize(), 1)

        ' Check menu
        MenuPreview.Checked = False
        MenuCallback.Checked = False
        MenuCapture.Checked = False
        MenuTrigger.Checked = False

        m_PreviewMode = -1
        m_SaveFlg = True
        m_StopFlg = False
        MenuStop.Text = "Pause"

        Invalidate()
    End Sub


    ' Capture mode
    Private Sub MenuCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCapture.Click
        If Not m_ArtCam.IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        ' Release device
        m_ArtCam.Close()


        ' Creat area for capturing
        CreateBitmap()

        ' Display image
        m_ArtCam.Capture()

        ' Check menu
        MenuPreview.Checked = False
        MenuCallback.Checked = False
        MenuCapture.Checked = True
        MenuTrigger.Checked = False

        m_PreviewMode = 3
        m_StopFlg = False
        MenuStop.Text = "Pause"

        Invalidate()
    End Sub


    ' Trigger mode
    Private Sub MenuTrigger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuTrigger.Click
        If Not m_ArtCam.IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        ' Release device
        m_ArtCam.Close()

        ' If drawing by yourself, set all window size to 0.
        ' An automatic display can be performed, if window size is set up even when using CallBackPreview
        m_ArtCam.SetPreviewWindow(Me.Handle, 0, 0, 0, 0)

        ' Creat area for capturing
        CreateBitmap()

        ' Capture image
        m_ArtCam.Trigger(Me.Handle, m_pCapture, getSize(), 1)

        ' Check menu
        MenuPreview.Checked = False
        MenuCallback.Checked = False
        MenuCapture.Checked = False
        MenuTrigger.Checked = True

        m_PreviewMode = 4
        m_StopFlg = False
        MenuStop.Text = "Pause"

        Invalidate()
    End Sub


    ' Pause/Resume
    Private Sub MenuStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuStop.Click
        ' Stop only for animated picture
        If (0 = m_PreviewMode) Or (1 = m_PreviewMode) Then
            If m_StopFlg Then
                m_ArtCam.StartPreview()
                m_StopFlg = False

                MenuStop.Text = "Pause"
            Else
                m_ArtCam.StopPreview()
                m_StopFlg = True

                MenuStop.Text = "Resume"
            End If
        End If
    End Sub


    ' In VB, use of callback message may cause an error. Therefore use timer for timing of drawing.
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If 1 = m_PreviewMode Or 4 = m_PreviewMode Then
            Invalidate()

        ElseIf 3 = m_PreviewMode Then
            m_ArtCam.SnapShot(m_pCapture, getSize(), 1)
            Invalidate()
        End If
    End Sub


    ' Create bit-map
    Private Sub CreateBitmap()
        ' In case bitmap is already created, release.
        If Not IsNothing(m_Bitmap) Then
            m_Bitmap.Dispose()
        End If

        ' Create object
		Select Case getColorMode()
            Case 8, 16
                m_Bitmap = New Bitmap(getWidth, getHeight, PixelFormat.Format8bppIndexed)

                ' Pallet modification
                Dim pal As ColorPalette = m_Bitmap.Palette
                Dim cpe As Color() = m_Bitmap.Palette.Entries

                Dim i As Integer = 0
                For i = 0 To 255
                    cpe.SetValue(Color.FromArgb(i, i, i), i)
                    pal.Entries(i) = cpe(i)
                Next
                m_Bitmap.Palette = pal

            Case 24
                m_Bitmap = New Bitmap(getWidth, getHeight, PixelFormat.Format24bppRgb)
            Case 32
                m_Bitmap = New Bitmap(getWidth, getHeight, PixelFormat.Format32bppRgb)
            Case 48
				m_Bitmap = New Bitmap(getWidth, getHeight, PixelFormat.Format24bppRgb)
            Case 64
				m_Bitmap = New Bitmap(getWidth, getHeight, PixelFormat.Format24bppRgb)
        End Select

        ' Arrangement for capture
        ReDim m_pCapture(getSize())
		ReDim m_pTempData(getSize())
    End Sub


    ' Camera settings
    Private Sub MenuCamera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCamera.Click
        If Not m_ArtCam.IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        If m_ArtCam.SetCameraDlg(Me.Handle()) Then
            Select Case m_PreviewMode
                Case 0
                    MenuPreview_Click(sender, e)
                Case 1
                    MenuCallback_Click(sender, e)
                Case 3
                    MenuCapture_Click(sender, e)
                Case 4
                    MenuTrigger_Click(sender, e)
            End Select
        End If
    End Sub


    ' Image settings
    Private Sub MenuFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFilter.Click
        If Not m_ArtCam.IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        m_ArtCam.SetImageDlg(Me.Handle())
    End Sub


    ' Analog settings
    Private Sub MenuAnalog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAnalog.Click
        If Not m_ArtCam.IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        m_ArtCam.SetAnalogDlg(Me.Handle())
    End Sub


    ' Change device
    Private Sub DeviceChange(ByVal sender As Object, ByVal e As System.EventArgs, ByVal Number As Integer)
        If Not Not m_ArtCam.IsInit Then
            m_ArtCam.Close()
        End If


        ' To confirm whether the device is connected, use "GetDeviceName"
        ' It can be found out easily with "GetDeviceName".
        ' When area for obtain name is not secured, it results in error. Prepare alignment length of at least 32.
        Dim Temp As StringBuilder = New StringBuilder(256)
'		If 0 = m_ArtCam.GetDeviceName(Number, Temp, 256) Then
'			m_PreviewMode = -1
'			m_SelectDevice = -1
'			m_StopFlg = False
'			MenuStop.Text = "Pause"
'			Exit Sub
'		End If


        ' A device will be changed, if a camera is displayed after changing the number of a device now
        ' Notes: A device is not changed in this function simple substance
        '   After calling this function, a device is changed by initializing a device
        m_SelectDevice = Number
        m_ArtCam.SetDeviceNumber(Number)

        Dim i As Integer
		For i = 0 To 7
            MenuDevice.MenuItems(i).Checked = False
        Next i
        MenuDevice.MenuItems(Number).Checked = True

        Select Case m_PreviewMode
            Case 0
                MenuPreview_Click(sender, e)
            Case 1
                MenuCallback_Click(sender, e)
            Case 3
                MenuCapture_Click(sender, e)
            Case 4
                MenuTrigger_Click(sender, e)
        End Select
    End Sub

    Private Sub MenuDevice0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice0.Click
        DeviceChange(sender, e, 0)
    End Sub

    Private Sub MenuDevice1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice1.Click
        DeviceChange(sender, e, 1)
    End Sub

    Private Sub MenuDevice2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice2.Click
        DeviceChange(sender, e, 2)
    End Sub

    Private Sub MenuDevice3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice3.Click
        DeviceChange(sender, e, 3)
    End Sub

    Private Sub MenuDevice4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice4.Click
        DeviceChange(sender, e, 4)
    End Sub

    Private Sub MenuDevice5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice5.Click
        DeviceChange(sender, e, 5)
    End Sub

    Private Sub MenuDevice6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice6.Click
        DeviceChange(sender, e, 6)
    End Sub

    Private Sub MenuDevice7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice7.Click
        DeviceChange(sender, e, 7)
    End Sub

    Private Sub MenuDevice8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice8.Click
        DeviceChange(sender, e, 8)
    End Sub

    Private Sub MenuDevice9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice9.Click
        DeviceChange(sender, e, 9)
    End Sub


    Private Function getSize() As Integer
		Return ((getWidth() * (getColorMode() / 8) + 3) And Not (3)) * getHeight()
    End Function

    Private Function getWidth() As Integer
		Return m_ArtCam.Width() / getSubSample()
    End Function

    Private Function getHeight() As Integer
		Return m_ArtCam.Height() / getSubSample()
	End Function

	Private Function getSubSample() As Integer
        Dim Size() As Integer = {1, 2, 4, 8}
		Return Size(m_ArtCam.GetSubSample() And 3)
    End Function


	Private Function getColorMode() As Integer
		Return (m_ArtCam.GetColorMode() + 7) And Not (7)
	End Function


    Private Function LockBitmap() As BitmapData
		Select Case getColorMode()
            Case 8, 16
                Return m_Bitmap.LockBits(New Rectangle(0, 0, getWidth, getHeight), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed)
			Case 32
				Return m_Bitmap.LockBits(New Rectangle(0, 0, getWidth, getHeight), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)
			Case 24, 48, 64
                Return m_Bitmap.LockBits(New Rectangle(0, 0, getWidth, getHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
        End Select

        Return Nothing
    End Function


    Private Sub DrawImage(ByVal g As Graphics)
        If Nothing Is m_Bitmap Then
            Return
        End If

        Dim pBitmapData As BitmapData = LockBitmap()
        If Nothing Is pBitmapData Then
            Return
        End If


        ' Convert data to pixel
        Dim pDest As IntPtr = pBitmapData.Scan0()

        Dim i As Integer = 0
		Dim BitMode As Integer = m_ArtCam.GetColorMode()
		Select Case getColorMode()
			Case 16
            Dim Size As Integer = getSize() / 2
            For i = 0 To Size - 1
                Dim Data1 As Byte = m_pCapture(i * 2)
                Dim Data2 As Byte = m_pCapture(i * 2 + 1)
					Dim dData As Integer
					Select Case BitMode
						Case 10
							dData = (Data1 / 4) + (Data2 * 64)
							'dData = (Data1 >> 2) + (Data2 << 6)
						Case 12
							dData = (Data1 / 16) + (Data2 * 16)
							'dData = (Data1 >> 4) + (Data2 << 4)
						Case 14
							dData = (Data1 / 64) + (Data2 * 4)
							'dData = (Data1 >> 6) + (Data2 << 2)
						Case Else
							dData = (Data2)
					End Select
                If 255 < dData Then
                    dData = 255
                End If
					m_pTempData(i) = dData
				Next
				Copy(m_pTempData, 0, pDest, Size)
			Case 48
				Dim Size As Integer = getSize() / 6
				For i = 0 To Size - 1
					Dim Data1 As Integer = m_pCapture(i * 6 + 0)
					Dim Data2 As Integer = m_pCapture(i * 6 + 1)
					Dim Data3 As Integer = m_pCapture(i * 6 + 2)
					Dim Data4 As Integer = m_pCapture(i * 6 + 3)
					Dim Data5 As Integer = m_pCapture(i * 6 + 4)
					Dim Data6 As Integer = m_pCapture(i * 6 + 5)
					Dim dDataB As Integer
					Dim dDataG As Integer
					Dim dDataR As Integer
					Select Case BitMode
						Case 42
							dDataB = (Data1 / 4) + (Data2 * 64)
							dDataG = (Data3 / 4) + (Data4 * 64)
							dDataR = (Data5 / 4) + (Data6 * 64)
							'dDataB = (Data1 >> 2) + (Data2 << 6)
							'dDataG = (Data3 >> 2) + (Data4 << 6)
							'dDataR = (Data5 >> 2) + (Data6 << 6)
						Case 44
							dDataB = (Data1 / 16) + (Data2 * 16)
							dDataG = (Data3 / 16) + (Data4 * 16)
							dDataR = (Data5 / 16) + (Data6 * 16)
							'dDataB = (Data1 >> 4) + (Data2 << 4)
							'dDataG = (Data3 >> 4) + (Data4 << 4)
							'dDataR = (Data5 >> 4) + (Data6 << 4)
						Case 46
							dDataB = (Data1 / 64) + (Data2 * 4)
							dDataG = (Data3 / 64) + (Data4 * 4)
							dDataR = (Data5 / 64) + (Data6 * 4)
							'dDataB = (Data1 >> 6) + (Data2 << 2)
							'dDataG = (Data3 >> 6) + (Data4 << 2)
							'dDataR = (Data5 >> 6) + (Data6 << 2)
						Case Else
							dDataB = (Data2)
							dDataG = (Data4)
							dDataR = (Data6)
					End Select
					If 255 < dDataB Then
						dDataB = 255
					End If
					If 255 < dDataG Then
						dDataG = 255
					End If
					If 255 < dDataR Then
						dDataR = 255
					End If

					m_pTempData(i * 3 + 0) = dDataB
					m_pTempData(i * 3 + 1) = dDataG
					m_pTempData(i * 3 + 2) = dDataR
            Next
				Copy(m_pTempData, 0, pDest, Size * 3)
			Case 64
				Dim Size As Integer = getSize() / 8
				For i = 0 To Size - 1
					Dim Data1 As Integer = m_pCapture(i * 8 + 0)
					Dim Data2 As Integer = m_pCapture(i * 8 + 1)
					Dim Data3 As Integer = m_pCapture(i * 8 + 2)
					Dim Data4 As Integer = m_pCapture(i * 8 + 3)
					Dim Data5 As Integer = m_pCapture(i * 8 + 4)
					Dim Data6 As Integer = m_pCapture(i * 8 + 5)
					Dim dDataB As Integer
					Dim dDataG As Integer
					Dim dDataR As Integer
					Select Case BitMode
						Case 58
							dDataB = (Data1 / 4) + (Data2 * 64)
							dDataG = (Data3 / 4) + (Data4 * 64)
							dDataR = (Data5 / 4) + (Data6 * 64)
							'dDataB = (Data1 >> 2) + (Data2 << 6) 
							'dDataG = (Data3 >> 2) + (Data4 << 6) 
							'dDataR = (Data5 >> 2) + (Data6 << 6) 
						Case 60
							dDataB = (Data1 / 16) + (Data2 * 16)
							dDataG = (Data3 / 16) + (Data4 * 16)
							dDataR = (Data5 / 16) + (Data6 * 16)
							'dDataB = (Data1 >> 4) + (Data2 << 4) 
							'dDataG = (Data3 >> 4) + (Data4 << 4) 
							'dDataR = (Data5 >> 4) + (Data6 << 4) 
						Case 62
							dDataB = (Data1 / 64) + (Data2 * 4)
							dDataG = (Data3 / 64) + (Data4 * 4)
							dDataR = (Data5 / 64) + (Data6 * 4)
							'dDataB = (Data1 >> 6) + (Data2 << 2) 
							'dDataG = (Data3 >> 6) + (Data4 << 2) 
							'dDataR = (Data5 >> 6) + (Data6 << 2) 
						Case Else
							dDataB = (Data2)
							dDataG = (Data4)
							dDataR = (Data6)
					End Select
					If 255 < dDataB Then
						dDataB = 255
					End If
					If 255 < dDataG Then
						dDataG = 255
					End If
					If 255 < dDataR Then
						dDataR = 255
					End If

					m_pTempData(i * 3 + 0) = dDataB
					m_pTempData(i * 3 + 1) = dDataG
					m_pTempData(i * 3 + 2) = dDataR
				Next
				Copy(m_pTempData, 0, pDest, Size * 3)
			Case Else
            Dim Size As Integer = getSize()
				Copy(m_pCapture, 0, pDest, Size)
		End Select


        m_Bitmap.UnlockBits(pBitmapData)

        ' Image display
        g.DrawImage(m_Bitmap, New Rectangle(0, 0, getWidth, getHeight))

        ' Line drawing
        Dim Pos As Point = PointToClient(Cursor.Position)
        Dim RedPen As Pen = New Pen(Color.Red, 1)
        g.DrawLine(RedPen, Pos.X, 0, Pos.X, getHeight())
        g.DrawLine(RedPen, 0, Pos.Y, getWidth(), Pos.Y)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        ' Draw using double-buffer (to avoid flickering)
        ' Drawing within OnPaint is written into off-screen buffer.
        ' Once process in OnPaint is complete, image is drawn on the screen.
        DrawImage(e.Graphics)
    End Sub

    Private Sub MenuUserSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUserSize.Click
        m_ArtCam.Close()

        Dim modalDialog As Form = New Form2(m_ArtCam)
        modalDialog.ShowDialog()

        Select Case m_PreviewMode
            Case 0
                MenuPreview_Click(sender, e)
            Case 1
                MenuCallback_Click(sender, e)
            Case 3
                MenuCapture_Click(sender, e)
            Case 4
                MenuTrigger_Click(sender, e)
        End Select
    End Sub

    Private Sub MenuUserFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUserFilter.Click
        Dim modalDialog As Form = New Form3(m_ArtCam, m_PreviewMode)
        modalDialog.ShowDialog()
    End Sub

    Private Sub MenuUserIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUserIO.Click
        Dim modalDialog As Form = New Form4(m_ArtCam)
        modalDialog.ShowDialog()
    End Sub

    Private Sub MenuUserMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUserMonitor.Click
		Dim modalDialog As Form
		Select Case(m_CurrentCameraType)
		Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_130MI_MOUT
		Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P3_MOUT
			modalDialog = New Form5(m_ArtCam)
			modalDialog.ShowDialog()
		Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_1000MI_HD2
			modalDialog = new Form7(m_ArtCam)
        modalDialog.ShowDialog()
		Case Else
		End Select
    End Sub

    Private Sub MenuFile_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFile.Popup
        ' Check if saving is available (if an image has been captured at least once, it is possible).
        If m_SaveFlg Then
            MenuSave.Enabled = True
        Else
            MenuSave.Enabled = False

            ' Check is the camera is Directshow compatible
            ' Only Directshow camera has recording function
			If ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS = (m_ArtCam.GetDllVersion() >> 16) Or (1300 <= (m_ArtCam.GetDllVersion() And &HFFFF)) Then
                MenuRec.Enabled = True
            Else
                MenuRec.Enabled = False
            End If
        End If
    End Sub

    Private Sub MenuView_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuView.Popup
        ' Disable playback if device is not connected
        If -1 = m_SelectDevice Then
            MenuPreview.Enabled = False
            MenuCallback.Enabled = False
            MenuSnapshot.Enabled = False
            MenuCapture.Enabled = False
            MenuTrigger.Enabled = False
            MenuStop.Enabled = False
        Else
            MenuPreview.Enabled = True
            MenuCallback.Enabled = True
            MenuSnapshot.Enabled = True
            MenuCapture.Enabled = True
			MenuStop.Enabled = True

            ' Remark: Trigger mode is not available in every model.
			Select Case (m_ArtCam.GetDllVersion() >> 16)
                Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_USTC, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_200SH, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_098, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_500P
                    MenuTrigger.Enabled = False
                Case Else
                    MenuTrigger.Enabled = True
            End Select
        End If
    End Sub

    Private Sub MenuSet_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSet.Popup
        ' Directshow is not available in every model.
        ' Note that "SetAnalogDlg" is not available in many models.
        MenuCamera.Enabled = True
        MenuFilter.Enabled = True
		MenuAnalog.Enabled = True
		MenuUserMonitor.Enabled = False
		MenuUserCorrection.Enabled = False

		If(m_CurrentCameraType = ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_USTC Or _
			m_CurrentCameraType = ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV) Then
                MenuAnalog.Enabled = False
		End If
		If(m_CurrentCameraType = ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_130MI_MOUT Or _
				m_CurrentCameraType = ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P3_MOUT Or _
				m_CurrentCameraType = ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_1000MI_HD2) Then
				MenuUserMonitor.Enabled = True
		End If
		If(m_CurrentCameraType = ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_008TNIR Or _
				m_CurrentCameraType = ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_0016TNIR Or _
				m_CurrentCameraType = ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_031TNIR) Then
				MenuUserCorrection.Enabled = True
		End If
    End Sub

	Protected Overrides Sub WndProc(ByRef m As Message)
		If m.Msg = DLL_MESSAGE.WM_ERROR Then
			Select Case m_ArtCam.GetLastError()
				Case ARTCAMSDK_ERROR.ARTCAMSDK_NOERROR
					Me.Text = "Ready"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_NOT_INITIALIZE
					Me.Text = "Error Not Initialize"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_DISABLEDDEVICE
					Me.Text = "Error Disable Device"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_CREATETHREAD
					Me.Text = "Error Create Thread"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_CREATEWINDOW
					Me.Text = "Error Create Window"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_OUTOFMEMORY
					Me.Text = "Error Out Of Memory"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_CAMERASET
					Me.Text = "Error Camera Set"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_CAMERASIZE
					Me.Text = "Error Camera Size"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_CAPTURE
					Me.Text = "Capture Error"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_PARAM
					Me.Text = "Error Param"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_DIRECTSHOW
					Me.Text = "Error DirectShow"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_UNSUPPORTED
					Me.Text = "Error Unsupported Function"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_UNKNOWN
					Me.Text = "Error Unknown"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_CAPTURELOST
					Me.Text = "Capture Lost"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_FILENOTFOUND
					Me.Text = "Error File Not Found"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_FPGASET
					Me.Text = "Error Fpga Setting"
				Case ARTCAMSDK_ERROR.ARTCAMSDK_TRANSIMAGEFAILED
					Me.Text = "Error Trans Image Failed"
				Case Else
			End Select
		End If

		MyBase.WndProc(m)
	End Sub
	Private Sub OnDllLoad(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal Type As ARTCAM_CAMERATYPE, ByVal SataType As Integer)

		Release()
		m_ArtCam = New CArtCam

		m_ArtCam.Initialize(Me.Handle())

		Dim i As Integer
		For i = 0 To 7
			Dim Temp As StringBuilder = New StringBuilder(256)
			m_ArtCam.GetDeviceName(i, Temp, 256)

			If Not 0 = m_ArtCam.GetDeviceName(i, Temp, 256) Then
				MenuDevice.MenuItems(i).Text = Temp.ToString()
				MenuDevice.MenuItems(i).Enabled = True
			Else
				MenuDevice.MenuItems(i).Enabled = False
			End If
		Next i

		DeviceChange(sender, e, 0)
	End Sub

	Private Sub OnDllReload()
		' Delete DLL list
		If 1 < MenuDll.MenuItems.Count Then
			Dim i As Integer
			For i = 0 To m_DllCount-1
				MenuDll.MenuItems.RemoveAt(1)
			Next
		End If
		m_DllCount = 0
		m_DllSata  = -1

		' Search for DLL
		Dim szDirPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
		Dim files As String() = Directory.GetFiles(szDirPath, "Art*.dll")
		For Each szFileName As String In files
			Dim ArtCam As CArtCam = New CArtCam()
			If (ArtCam.LoadLibrary(szFileName)) Then

				' Obtain version and show it
				Dim ver As Long = ArtCam.GetDllVersion() And &HFFFF
				Dim szMenu As String = String.Format("{0}{1}Version {2:D4}", Path.GetFileNameWithoutExtension(szFileName), ControlChars.Tab, ver)

				' Add to menu
				m_DllCount += 1
				If (ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_SATA = ArtCam.GetDllVersion() >> 16) Then
					Dim menuSata As MenuItem = New MenuItem()
					menuSata.Text = szMenu
					Dim CameraName() As String = new String() { _
										"LVDS", _
										"300MI", _
										"500MI", _
										"MV413", _
										"800MI", _
										"036MI", _
										"150P3", _
										"267KY", _
										"274KY", _
										"625KY", _
										"130MI", _
										"200MI" _
									}
					Dim i As Integer
					For i=0 To CameraName.Length -1
						Dim mi As MenuItem = New MenuItem()
						mi.Text = CameraName(i)
						AddHandler mi.Click, AddressOf OnMenuDLLSelect
						menuSata.MenuItems.Add(i, mi)
					Next i
					menuDLL.MenuItems.Add(m_DllCount, menuSata)
					m_DllSata = m_DllCount-1
				Else
					Dim mi As MenuItem = New MenuItem()
					mi.Text = szMenu
					AddHandler mi.Click, AddressOf OnMenuDLLSelect
					MenuDll.MenuItems.Add(m_DllCount, mi)
				End If
			End If
		Next

	End Sub
	' Menu handler for DLL selector
	Private Sub OnMenuDLLSelect(ByVal sender As System.Object, ByVal e As System.EventArgs)
		Dim id As Integer =  menuDLL.MenuItems.IndexOf(CType(sender, MenuItem))
		If (id > -1) Then
			OnDllChange(sender, e, id-1, -1)
		Else
			Dim type As Integer = CType(sender, MenuItem).Index
			If (ARTCAM_CAMERATYPE_SATA.ARTCAM_CAMERATYPE_SATA_LVDS <= type And type <= ARTCAM_CAMERATYPE_SATA.ARTCAM_CAMERATYPE_SATA_200MI) Then
				OnDllChange(sender, e, m_DllSata, type)
			End If
		End If
	End Sub
Private Sub menuDllReload_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles menuDllReload.Click
		OnDllReload()
	End Sub

	Private Sub OnDllChange(ByVal sender As System.Object, ByVal e As System.EventArgs, DllType as Integer, SataType As Integer)
		Release()
		m_ArtCam.FreeLibrary()

		m_CurrentCameraType = 0

		If 0 = m_DllCount Then
			Return
		End If

		If 0 > DllType Then
			Return
		End If

		Dim stMenu As String = MenuDll.MenuItems(DllType + 1).Text
		Dim stArray As String() = stMenu.Split(ControlChars.Tab)
		Dim szDllName As String = String.Format("{0}.dll", stArray(0))
		Dim res As Boolean = m_ArtCam.LoadLibrary(szDllName)
		If (False = res) Then
			MessageBox.Show("DLL is not found.\nIt may have been relocated after executing.")
			Return
		Else
			m_CurrentCameraType = (m_ArtCam.GetDllVersion() >> 16)
		End If
		' Initialize is to be called first
		' By setting Window Handle here, WMLERROR can be obtained
		If (False = m_ArtCam.Initialize(Me.Handle)) Then
			MessageBox.Show("Failed to initialize SDK")
			Return
		End If
		m_DllType = DllType
		m_SataType = SataType

		' Check menu
		Dim i As Integer
		For i = 0 To m_DllCount - 1
			MenuDll.MenuItems(i + 1).Checked = False
		Next
		' Select SATA camera type when use Sata.dll
		If (-1 <> SataType And ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_SATA = m_CurrentCameraType) Then
			m_ArtCam.SetCameraType(SataType)
			m_ArtCam.SetDeviceNumber(0)
		Else
			menuDLL.MenuItems(DllType+1).Checked = true
		End If

		MenuSet_Popup(sender, e)

		' Check enable device
		For i = 0 To 7
			Dim Temp As StringBuilder = New StringBuilder(256)
			If (0 <> m_ArtCam.GetDeviceName(i, Temp, 256)) Then

				MenuDevice.MenuItems(i).Text = Temp.ToString()
				MenuDevice.MenuItems(i).Enabled = True
			Else
				MenuDevice.MenuItems(i).Enabled = False
			End If
		Next
		DeviceChange(sender, e, 0)
End Sub

	Protected Overrides Sub Finalize()
		MyBase.Finalize()
		Release()
		m_ArtCam.FreeLibrary()
	End Sub

Private Sub MenuUserCorrection_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles MenuUserCorrection.Click
		Dim modalDialog As Form = New Form6(m_ArtCam)
		modalDialog.ShowDialog()
End Sub
End Class


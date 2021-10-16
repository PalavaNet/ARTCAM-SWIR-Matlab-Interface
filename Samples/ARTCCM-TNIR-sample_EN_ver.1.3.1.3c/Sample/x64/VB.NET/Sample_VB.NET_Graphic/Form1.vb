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

#Region " Code made by Windows form designer "

    Public Sub New()
        MyBase.New()

        ' This call required for Windows firm designer
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
	Friend WithEvents MenuDLL As System.Windows.Forms.MenuItem
	Friend WithEvents MenuDllReload As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container
		Me.MainMenu1 = New System.Windows.Forms.MainMenu
		Me.MenuFile = New System.Windows.Forms.MenuItem
		Me.MenuSave = New System.Windows.Forms.MenuItem
		Me.MenuExit = New System.Windows.Forms.MenuItem
		Me.MenuView = New System.Windows.Forms.MenuItem
		Me.MenuPreview = New System.Windows.Forms.MenuItem
		Me.MenuCallback = New System.Windows.Forms.MenuItem
		Me.MenuSnapshot = New System.Windows.Forms.MenuItem
		Me.MenuCapture = New System.Windows.Forms.MenuItem
		Me.MenuTrigger = New System.Windows.Forms.MenuItem
		Me.MenuSet = New System.Windows.Forms.MenuItem
		Me.MenuCamera = New System.Windows.Forms.MenuItem
		Me.MenuFilter = New System.Windows.Forms.MenuItem
		Me.MenuAnalog = New System.Windows.Forms.MenuItem
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
		Me.MenuDLL = New System.Windows.Forms.MenuItem
		Me.MenuDllReload = New System.Windows.Forms.MenuItem
        '
        'MainMenu1
        '
		Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuFile, Me.MenuView, Me.MenuSet, Me.MenuDLL, Me.MenuDevice})
        '
        'MenuFile
        '
        Me.MenuFile.Index = 0
        Me.MenuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuSave, Me.MenuExit})
        Me.MenuFile.Text = "File(&F)"
        '
        'MenuSave
        '
        Me.MenuSave.Index = 0
        Me.MenuSave.Text = "Save(&S)"
        '
        'MenuExit
        '
        Me.MenuExit.Index = 1
        Me.MenuExit.Text = "End(&X)"
        '
        'MenuView
        '
        Me.MenuView.Index = 1
        Me.MenuView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuPreview, Me.MenuCallback, Me.MenuSnapshot, Me.MenuCapture, Me.MenuTrigger})
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
        'MenuSet
        '
        Me.MenuSet.Index = 2
        Me.MenuSet.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuCamera, Me.MenuFilter, Me.MenuAnalog})
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
        'MenuDevice8
        '
		Me.Timer1.Enabled = True
        '
        'MenuDevice9
        '
		Me.MenuDLL.Index = 3
		Me.MenuDLL.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuDllReload})
		Me.MenuDLL.Text = "DLL(&L)"
        '
		'MenuDllReload
        '
		Me.MenuDllReload.Index = 0
		Me.MenuDllReload.Text = "Reload"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(640, 481)
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "VB Sample"

    End Sub

#End Region

    Dim m_pCapture() As Byte
    Dim m_Bitmap As Bitmap
    Dim m_PreviewMode As Integer = 0
    Dim m_ArtCam As CArtCam = New CArtCam()
    
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Drawing by double buffer(not to flicker)
        SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)

		OnDllReload()
    End Sub


    ' End form
    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Release()
        m_PreviewMode = 0
    End Sub

    ' Release camera
    Private Sub Release()
        m_ArtCam.Release()
        m_PreviewMode = 0
    End Sub

    ' Save
    Private Sub MenuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSave.Click
        If Not m_ArtCam.IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        m_ArtCam.SaveImage("image.jpg", FILETYPE.FILETYPE_JPEG_NOMAL)
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

        ' Stop drawing image ( Call is no problem in case of not drawing image ) 
        m_ArtCam.Close()

        m_ArtCam.SetPreviewWindow(Me.Handle(), 0, 0, getWidth, getHeight)
        m_ArtCam.Preview()

        m_PreviewMode = 1
    End Sub


    ' Callback: Obtain image pointer of image and draw its own.
    Private Sub MenuCallback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCallback.Click
        If Not m_ArtCam.IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        ' Stop drawing image ( Call is no problem in case of not drawing image )
        m_ArtCam.Close()

        ' Create bit-map
        CreateBitmap()

        ' If drawing by yourself, set all window size to 0.
        ' An automatic display can be performed, if window size is set up even when using CallBackPreview
        m_ArtCam.SetPreviewWindow(Me.Handle(), 0, 0, 0, 0)
        m_ArtCam.CallBackPreview(Me.Handle(), m_pCapture, getSize(), 1)

        m_PreviewMode = 2
    End Sub


    ' Snapshot
    Private Sub MenuSnapshot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSnapshot.Click
        If Not m_ArtCam.IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        ' Stop drawing image ( Call is no problem in case of not drawing image )
        m_ArtCam.Close()

        ' Create bit-map
        CreateBitmap()
        m_ArtCam.SnapShot(m_pCapture, getSize(), 1)
        Invalidate()

        m_PreviewMode = 0
    End Sub


    ' Capture mode
    Private Sub MenuCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCapture.Click
        If Not m_ArtCam.IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        ' Release device
        m_ArtCam.Close()

        ' Create bit-map
        CreateBitmap()
        m_ArtCam.Capture()

        m_PreviewMode = 3
    End Sub


    ' Trigger mode
    Private Sub MenuTrigger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuTrigger.Click
        If Not m_ArtCam.IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        ' Release device
        m_ArtCam.Close()

        ' Create bit-map
        CreateBitmap()

        ' If drawing by yourself, set all window size to 0.
        ' An automatic display can be performed, if window size is set up even when using CallBackPreview
        m_ArtCam.SetPreviewWindow(Me.Handle, 0, 0, 0, 0)
        m_ArtCam.Trigger(Me.Handle, m_pCapture, getSize(), 1)

        m_PreviewMode = 4
    End Sub


    ' In VB, use of callback message may cause an error. Therefore use timer for timing of drawing. 
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If 2 = m_PreviewMode Or 4 = m_PreviewMode Then
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
        Select Case m_ArtCam.GetColorMode()
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

            Case 24 : m_Bitmap = New Bitmap(getWidth, getHeight, PixelFormat.Format24bppRgb)
            Case 32 : m_Bitmap = New Bitmap(getWidth, getHeight, PixelFormat.Format32bppRgb)
            Case 48 : m_Bitmap = New Bitmap(getWidth, getHeight, PixelFormat.Format48bppRgb)
            Case 64 : m_Bitmap = New Bitmap(getWidth, getHeight, PixelFormat.Format64bppArgb)
        End Select

        ' Arrangement for capture
        ReDim m_pCapture(getSize())
    End Sub


    ' Camera settings
    Private Sub MenuCamera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCamera.Click
        If Not m_ArtCam.IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        If m_ArtCam.SetCameraDlg(Me.Handle()) Then
            Select Case m_PreviewMode
                Case 1
                    MenuPreview_Click(sender, e)
                Case 2
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
    Private Sub DeviceChange(ByVal Number As Integer)
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
        m_ArtCam.SetDeviceNumber(Number)

		Dim i As Integer
		For i = 0 To 7
			MenuDevice.MenuItems(i).Checked = False
		Next i
		MenuDevice.MenuItems(Number).Checked = True
    End Sub

    Private Sub MenuDevice0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice0.Click
        DeviceChange(0)
    End Sub

    Private Sub MenuDevice1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice1.Click
        DeviceChange(1)
    End Sub

    Private Sub MenuDevice2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice2.Click
        DeviceChange(2)
    End Sub

    Private Sub MenuDevice3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice3.Click
        DeviceChange(3)
    End Sub

    Private Sub MenuDevice4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice4.Click
        DeviceChange(4)
    End Sub

    Private Sub MenuDevice5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice5.Click
        DeviceChange(5)
    End Sub

    Private Sub MenuDevice6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice6.Click
        DeviceChange(6)
    End Sub

    Private Sub MenuDevice7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDevice7.Click
        DeviceChange(7)
    End Sub

    Private Function getSize() As Integer
        Return ((getWidth() * (m_ArtCam.GetColorMode() / 8) + 3) And Not (3)) * getHeight()
    End Function

    Private Function getWidth() As Integer
        Dim Size() As Integer = {1, 2, 4, 8}
        Return m_ArtCam.Width() / Size(m_ArtCam.GetSubSample())
    End Function

    Private Function getHeight() As Integer
        Dim Size() As Integer = {1, 2, 4, 8}
        Return m_ArtCam.Height() / Size(m_ArtCam.GetSubSample())
    End Function

    Private Function LockBitmap() As BitmapData
        Select Case m_ArtCam.GetColorMode()
            Case 8, 16
                Return m_Bitmap.LockBits(New Rectangle(0, 0, getWidth, getHeight), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed)

            Case 24, 32, 48, 64
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
        If 16 = m_ArtCam.GetColorMode() Then
            Dim Size As Integer = getSize() / 2
            For i = 0 To Size - 1
                Dim Data1 As Byte = m_pCapture(i * 2)
                Dim Data2 As Byte = m_pCapture(i * 2 + 1)

                Dim dData As Object = (Data1 / 4) + (Data2 * 64)
                If 255 < dData Then
                    dData = 255
                End If

                WriteByte(pDest, i, CType(dData, Byte))
            Next

        Else
            Dim Size As Integer = getSize()
            For i = 0 To Size - 1
                WriteByte(pDest, i, m_pCapture(i))
            Next
        End If


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
	Private Sub menuDllReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuDllReload.Click
		OnDllReload()
	End Sub

	Private Sub OnDllChange(ByVal sender As System.Object, ByVal e As System.EventArgs, DllType as Integer, SataType As Integer)
		Release()
		m_ArtCam.FreeLibrary()

		If 0 = m_DllCount Then
			Return
		End If
		Dim stMenu As String = MenuDll.MenuItems(DllType + 1).Text
		Dim stArray As String() = stMenu.Split(ControlChars.Tab)
		Dim szDllName As String = String.Format("{0}.dll", stArray(0))
		Dim res As Boolean = m_ArtCam.LoadLibrary(szDllName)
		If (False = res) Then
			MessageBox.Show("DLL is not found.\nIt may have been relocated after executing.")
			Return
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
		If (-1 <> SataType And ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_SATA = m_ArtCam.GetDllType()) Then
			m_ArtCam.SetCameraType(SataType)
			m_ArtCam.SetDeviceNumber(0)
		Else
			menuDLL.MenuItems(DllType+1).Checked = true
		End If

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
		DeviceChange(0)
	End Sub
End Class





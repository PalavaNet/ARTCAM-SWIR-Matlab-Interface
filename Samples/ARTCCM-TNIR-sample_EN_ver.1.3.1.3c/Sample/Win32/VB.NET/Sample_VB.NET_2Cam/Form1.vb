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
    Friend WithEvents MenuCamera1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuAnalog1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuCamera2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuFilter1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuFilter2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuAnalog2 As System.Windows.Forms.MenuItem
	Friend WithEvents MenuDLL As System.Windows.Forms.MenuItem
	Friend WithEvents menuDllReload As System.Windows.Forms.MenuItem
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
		Me.MenuCamera1 = New System.Windows.Forms.MenuItem
		Me.MenuCamera2 = New System.Windows.Forms.MenuItem
		Me.MenuFilter1 = New System.Windows.Forms.MenuItem
		Me.MenuFilter2 = New System.Windows.Forms.MenuItem
		Me.MenuAnalog1 = New System.Windows.Forms.MenuItem
		Me.MenuAnalog2 = New System.Windows.Forms.MenuItem
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.MenuDLL = New System.Windows.Forms.MenuItem
		Me.menuDllReload = New System.Windows.Forms.MenuItem
        '
        'MainMenu1
        '
		Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuFile, Me.MenuView, Me.MenuSet, Me.MenuDLL})
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
        Me.MenuSet.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuCamera1, Me.MenuCamera2, Me.MenuFilter1, Me.MenuFilter2, Me.MenuAnalog1, Me.MenuAnalog2})
        Me.MenuSet.Text = "Settings(&S)"
        '
        'MenuCamera1
        '
        Me.MenuCamera1.Index = 0
        Me.MenuCamera1.Text = "Camera settings1(&C)"
        Me.MenuAnalog1.Text = "Analog settings1(&A)"
        '
        'MenuCamera2
        '
        Me.MenuCamera2.Index = 1
        Me.MenuCamera2.Text = "Camera settings2(&C)"
        '
        'MenuFilter1
        '
        Me.MenuFilter1.Index = 2
        Me.MenuFilter1.Text = "Filter settings1(&F)"
        '
        'MenuFilter2
        '
        Me.MenuFilter2.Index = 3
        Me.MenuFilter2.Text = "Filter settings2(&F)"
        '
        'MenuAnalog2
        '
        Me.MenuAnalog2.Index = 5
        Me.MenuAnalog2.Text = "Analog settings2(&A)"
		'
		'Timer1
		'
		Me.Timer1.Enabled = True
		'
		'MenuDLL
		'
		Me.MenuDLL.Index = 3
		Me.MenuDLL.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuDllReload})
		Me.MenuDLL.Text = "DLL(&L)"
		'
		'menuDllReload
		'
		Me.menuDllReload.Index = 0
		Me.menuDllReload.Text = "Reload"
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


    Dim m_ArtCam() As CArtCam = {New CArtCam(), New CArtCam()}
    Dim m_Bitmap() As Bitmap = {Nothing, Nothing}
    Dim m_BitmapData() As BitmapData = {Nothing, Nothing}
    Dim m_LockFlg() As Boolean = {False, False}
    Dim PreviewMode As Integer = 0


    ' Start form
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		OnDllReload()
    End Sub


    ' End form
    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Release()
    End Sub


    ' Save
    Private Sub MenuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSave.Click
        If Not m_ArtCam(0).IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        m_ArtCam(0).SaveImage("Image1.jpg", FILETYPE.FILETYPE_JPEG_NOMAL)
        m_ArtCam(1).SaveImage("Image2.jpg", FILETYPE.FILETYPE_JPEG_NOMAL)
    End Sub


    ' End
    Private Sub MenuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuExit.Click
        Close()
    End Sub


    ' Preview Draw automatically
    Private Sub MenuPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPreview.Click
        If Not m_ArtCam(0).IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        ' Stop drawing image ( Call is no problem in case of not drawing image )
        m_ArtCam(0).Close()
        m_ArtCam(1).Close()

        m_ArtCam(0).SetPreviewWindow(Me.Handle(), 0, 0, getWidth(0), getHeight(0))
        m_ArtCam(1).SetPreviewWindow(Me.Handle(), 0, 0, getWidth(1), getHeight(1))
        m_ArtCam(0).Preview()
        m_ArtCam(1).Preview()

        PreviewMode = 1
    End Sub


    ' Callback: Obtain image pointer of image and draw its own.
    Private Sub MenuCallback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCallback.Click
        If Not m_ArtCam(0).IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        ' Stop drawing image ( Call is no problem in case of not drawing image )
        m_ArtCam(0).Close()
        m_ArtCam(1).Close()

        ' Create bit-map
        CreateBitmap(0)
        CreateBitmap(1)

        ' If drawing by yourself, set all window size to 0.
        ' An automatic display can be performed, if window size is set up even when using CallBackPreview
        m_ArtCam(0).SetPreviewWindow(Me.Handle(), 0, 0, 0, 0)
        m_ArtCam(1).SetPreviewWindow(Me.Handle(), 0, 0, 0, 0)
        m_ArtCam(0).CallBackPreview(Me.Handle(), m_BitmapData(0).Scan0, getSize(0), 1)
        m_ArtCam(1).CallBackPreview(Me.Handle(), m_BitmapData(1).Scan0, getSize(1), 1)

        PreviewMode = 2
    End Sub


    ' Snapshot
    Private Sub MenuSnapshot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSnapshot.Click
        If Not m_ArtCam(0).IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        ' Stop drawing image ( Call is no problem in case of not drawing image )
        m_ArtCam(0).Close()
        m_ArtCam(1).Close()

        ' Create bit-map
        CreateBitmap(0)
        CreateBitmap(1)
        m_ArtCam(0).SnapShot(m_BitmapData(0).Scan0, getSize(0), 1)
        m_ArtCam(1).SnapShot(m_BitmapData(1).Scan0, getSize(1), 1)
        UnLockBitmap(0)
        UnLockBitmap(1)

        ' Image display
        ' Correspond to 10bit display only for snapshot
        ' In this way,process speed of bit operation is too slow,
        ' Cause memory access violation while working because processing is too slow
        If 16 = m_ArtCam(0).GetColorMode() Then
            DrawImage16Bit(0)
            DrawImage16Bit(1)
        Else
            DrawImage(0)
            DrawImage(1)
        End If

        PreviewMode = 0
    End Sub


    ' Capture mode
    Private Sub MenuCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCapture.Click
        If Not m_ArtCam(0).IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        ' Release device
        m_ArtCam(0).Close()
        m_ArtCam(1).Close()

        ' Create bit-map
        CreateBitmap(0)
        CreateBitmap(1)
        m_ArtCam(0).Capture()
        m_ArtCam(1).Capture()

        PreviewMode = 3
    End Sub


    ' Trigger mode
    Private Sub MenuTrigger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuTrigger.Click
        If Not m_ArtCam(0).IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        ' Release device
        m_ArtCam(0).Close()
        m_ArtCam(1).Close()

        ' Create bit-map
        CreateBitmap(0)
        CreateBitmap(1)

        ' If drawing by yourself, set all window size to 0.
        ' An automatic display can be performed, if window size is set up even when using CallBackPreview
        m_ArtCam(0).SetPreviewWindow(Me.Handle, 0, 0, 0, 0)
        m_ArtCam(1).SetPreviewWindow(Me.Handle, 0, 0, 0, 0)
        m_ArtCam(0).Trigger(Me.Handle, m_BitmapData(0).Scan0, getSize(0), 1)
        m_ArtCam(1).Trigger(Me.Handle, m_BitmapData(1).Scan0, getSize(1), 1)

        PreviewMode = 4
    End Sub


    ' In VB, use of callback message may cause an error. Therefore use timer for timing of drawing.
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If 2 = PreviewMode Or 4 = PreviewMode Then
            UnLockBitmap(0)
            UnLockBitmap(1)

            ' Image display
            DrawImage(0)
            DrawImage(1)

        ElseIf 3 = PreviewMode Then
            LockBitmap(0)
            m_ArtCam(0).SnapShot(m_BitmapData(0).Scan0, getSize(0), 1)
            UnLockBitmap(0)

            LockBitmap(1)
            m_ArtCam(1).SnapShot(m_BitmapData(1).Scan0, getSize(1), 1)
            UnLockBitmap(1)

            ' Image display
            DrawImage(0)
            DrawImage(1)
        End If
    End Sub


    ' Create bit-map
    Private Sub CreateBitmap(ByVal n As Integer)
        ' Release when locked
        UnLockBitmap(n)

        ' In case bitmap is already created, release.
        If Not IsNothing(m_Bitmap(n)) Then
            m_Bitmap(n).Dispose()
        End If

        ' Create object
        Select Case m_ArtCam(n).GetColorMode()
            Case 8 : m_Bitmap(n) = New Bitmap(getWidth(n), getHeight(n), PixelFormat.Format8bppIndexed)

                ' Pallet modification
                Dim pal As ColorPalette = m_Bitmap(n).Palette
                Dim cpe As Color() = m_Bitmap(n).Palette.Entries

                Dim i As Integer = 0
                For i = 0 To 255
                    cpe.SetValue(Color.FromArgb(i, i, i), i)
                    pal.Entries(i) = cpe(i)
                Next
                m_Bitmap(n).Palette = pal

            Case 16 : m_Bitmap(n) = New Bitmap(getWidth(n), getHeight(n), PixelFormat.Format16bppGrayScale)
            Case 24 : m_Bitmap(n) = New Bitmap(getWidth(n), getHeight(n), PixelFormat.Format24bppRgb)
            Case 32 : m_Bitmap(n) = New Bitmap(getWidth(n), getHeight(n), PixelFormat.Format32bppRgb)
            Case 48 : m_Bitmap(n) = New Bitmap(getWidth(n), getHeight(n), PixelFormat.Format48bppRgb)
            Case 64 : m_Bitmap(n) = New Bitmap(getWidth(n), getHeight(n), PixelFormat.Format64bppArgb)
        End Select

        LockBitmap(n)
    End Sub

    Private Function getSize(ByVal n As Integer) As Integer
        Return ((getWidth(n) * (m_ArtCam(n).GetColorMode() / 8) + 3) And Not (3)) * getHeight(n)
    End Function

    Private Function getWidth(ByVal n As Integer) As Integer
        Dim Size() As Integer = {1, 2, 4, 8}
        Return m_ArtCam(n).Width() / Size(m_ArtCam(n).GetSubSample())
    End Function

    Private Function getHeight(ByVal n As Integer) As Integer
        Dim Size() As Integer = {1, 2, 4, 8}
        Return m_ArtCam(n).Height() / Size(m_ArtCam(n).GetSubSample())
    End Function

    Private Sub LockBitmap(ByVal n As Integer)
        If m_LockFlg(n) Then
            Exit Sub
        End If

        Select Case m_ArtCam(0).GetColorMode()
            Case 8 : m_BitmapData(n) = m_Bitmap(n).LockBits(New Rectangle(0, 0, getWidth(n), getHeight(n)), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed)
            Case 16 : m_BitmapData(n) = m_Bitmap(n).LockBits(New Rectangle(0, 0, getWidth(n), getHeight(n)), ImageLockMode.ReadWrite, PixelFormat.Format16bppGrayScale)
            Case 24 : m_BitmapData(n) = m_Bitmap(n).LockBits(New Rectangle(0, 0, getWidth(n), getHeight(n)), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
            Case 32 : m_BitmapData(n) = m_Bitmap(n).LockBits(New Rectangle(0, 0, getWidth(n), getHeight(n)), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb)
            Case 48 : m_BitmapData(n) = m_Bitmap(n).LockBits(New Rectangle(0, 0, getWidth(n), getHeight(n)), ImageLockMode.ReadWrite, PixelFormat.Format48bppRgb)
            Case 64 : m_BitmapData(n) = m_Bitmap(n).LockBits(New Rectangle(0, 0, getWidth(n), getHeight(n)), ImageLockMode.ReadWrite, PixelFormat.Format64bppArgb)
        End Select

        m_LockFlg(n) = True
    End Sub

    Private Sub UnLockBitmap(ByVal n As Integer)
        If m_LockFlg(n) Then
            m_Bitmap(n).UnlockBits(m_BitmapData(n))
            m_LockFlg(n) = False
        End If

    End Sub

    Private Sub DrawImage(ByVal n As Integer)
        Dim g As Graphics = MyBase.CreateGraphics()
        g.DrawImage(m_Bitmap(n), New Rectangle(getWidth(n) * n, 0, getWidth(n), getHeight(n)))
        g.Dispose()
    End Sub

    Private Sub DrawImage16Bit(ByVal n As Integer)
        ' 
        Dim DrawBmp As Bitmap = New Bitmap(getWidth(n), getHeight(n), PixelFormat.Format8bppIndexed)

        ' Pallet modification
        Dim pal As ColorPalette = DrawBmp.Palette
        Dim cpe As Color() = DrawBmp.Palette.Entries

        Dim i As Integer = 0
        For i = 0 To 255
            cpe.SetValue(Color.FromArgb(i, i, i), i)
            pal.Entries(i) = cpe(i)
        Next
        DrawBmp.Palette = pal

        Dim DrawBmpData As BitmapData = DrawBmp.LockBits(New Rectangle(0, 0, getWidth(n), getHeight(n)), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed)

        Dim pSrc As IntPtr = m_BitmapData(n).Scan0()
        Dim pDest As IntPtr = DrawBmpData.Scan0()

        ' Color conversion
        Dim Size As Integer = getWidth(n) * getHeight(n) - 1
        For i = 0 To Size
            Dim Data1 As Byte = ReadByte(pSrc, i * 2)
            Dim Data2 As Byte = ReadByte(pSrc, i * 2 + 1)

            ' No shift operation for .NET2002
            ' Code below works for version after .NET2003
            'Dim Data3 As Byte = (Data2 << 6) | (Data1 >> 2)

            Dim dData As Object = (Data1 / 4) + (Data2 * 64)
            If 255 < dData Then
                dData = 255
            End If

            Dim Data3 As Byte = CType(dData, Byte)

            WriteByte(pDest, i, Data3)
        Next

        DrawBmp.UnlockBits(DrawBmpData)
        UnLockBitmap(n)

        ' Image display
        Dim g As Graphics = MyBase.CreateGraphics()
        g.DrawImage(DrawBmp, New Rectangle(getWidth(n) * n, 0, getWidth(n), getHeight(n)))
        g.Dispose()
    End Sub

    ' Release camera
    Private Sub Release()
        m_ArtCam(0).Release()
        m_ArtCam(1).Release()
        UnLockBitmap(0)
        UnLockBitmap(1)
        PreviewMode = 0
    End Sub


    ' Camera settings
    Private Sub MenuCamera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCamera1.Click
        If Not m_ArtCam(0).IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        If m_ArtCam(0).SetCameraDlg(Me.Handle()) Then
            Select Case PreviewMode
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

    Private Sub MenuCamera2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCamera2.Click
        If Not m_ArtCam(1).IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        If m_ArtCam(1).SetCameraDlg(Me.Handle()) Then
            Select Case PreviewMode
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
    Private Sub MenuFilter1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFilter1.Click
        If Not m_ArtCam(0).IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        m_ArtCam(0).SetImageDlg(Me.Handle())
    End Sub

    Private Sub MenuFilter2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFilter2.Click
        If Not m_ArtCam(1).IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        m_ArtCam(1).SetImageDlg(Me.Handle())
    End Sub


    ' Analog settings
    Private Sub MenuAnalog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAnalog1.Click
        If Not m_ArtCam(0).IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        m_ArtCam(0).SetAnalogDlg(Me.Handle())
    End Sub

    Private Sub MenuAnalog2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAnalog2.Click
        If Not m_ArtCam(1).IsInit Then
            MessageBox.Show("Select available device")
            Exit Sub
        End If

        m_ArtCam(1).SetAnalogDlg(Me.Handle())
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
		m_ArtCam(0).FreeLibrary()
		m_ArtCam(1).FreeLibrary()

		If 0 = m_DllCount Then
			Return
		End If
		Dim stMenu As String = MenuDll.MenuItems(DllType + 1).Text
		Dim stArray As String() = stMenu.Split(ControlChars.Tab)
		Dim szDllName As String = String.Format("{0}.dll", stArray(0))
		Dim res As Boolean = m_ArtCam(0).LoadLibrary(szDllName)
		If (False = res) Then
			MessageBox.Show("DLL is not found.\nIt may have been relocated after executing.")
			Return
		Else
			m_ArtCam(1).LoadLibrary(szDllName)
		End If
		' Initialize is to be called first
		' By setting Window Handle here, WMLERROR can be obtained
		If (False = m_ArtCam(0).Initialize(Me.Handle)) Then
			MessageBox.Show("Failed to initialize SDK")
			Return
		Else
			m_ArtCam(1).Initialize(Me.Handle)
		End If
		m_DllType = DllType
		m_SataType = SataType

		' Check menu
		Dim i As Integer
		For i = 0 To m_DllCount - 1
			MenuDll.MenuItems(i + 1).Checked = False
		Next
		' Select SATA camera type when use Sata.dll
		If (-1 <> SataType And ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_SATA = m_ArtCam(0).GetDllVersion()>>16) Then
			m_ArtCam(0).SetCameraType(SataType)
			m_ArtCam(1).SetCameraType(SataType)
		End If

		' To confirm whether the device is connected, use "GetDeviceName"
		' It can be found out easily with "GetDeviceName".
		Dim Temp As StringBuilder = new StringBuilder( 256 )
		If(0 = m_ArtCam(0).GetDeviceName(0, Temp, 256)) Then
			m_ArtCam(0).FreeLibrary()
		End If
		if(0 = m_ArtCam(1).GetDeviceName(1, Temp, 256)) Then
			' No device
			' Please note that there is possibility of duplication access to one device
			' if there is access from two classes when only one device detected.
			' In this case, please release class or do not call function.
              
			' If you release class, it comes to be safe failure even when call function.
			m_ArtCam(1).FreeLibrary()
		End If


		m_ArtCam(0).SetDeviceNumber(0)
		m_ArtCam(1).SetDeviceNumber(1)

		' To operate 2 cameras simultenously, set camera clock to half.
		m_ArtCam(0).SetHalfClock(1)
		m_ArtCam(1).SetHalfClock(1)


		' Check menu
		For i = 0 To m_DllCount-1
			menuDLL.MenuItems(i + 1).Checked = false
		Next
		If Not (ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_SATA = m_ArtCam(0).GetDllVersion()>>16) Then
			menuDLL.MenuItems(DllType+1).Checked = true
		End If



	End Sub
	
End Class





Imports Sample_VB.ArtCamSdk

Public Class Form7
		Dim m_ArtCam As CArtCam = Nothing
		Public Dim m_DllType As ARTCAM_CAMERATYPE = 0
		Dim m_CameraInfo As CAMERAINFO = Nothing
		Dim m_CursorNumber As Integer = 0
		Dim m_Init As Boolean = False
		public Structure _M_CURSOR
			public Enable As Integer
			public SizeX As Integer
			public SizeY As Integer
			public PosX As Integer
			public PosY As Integer
			public Color As Integer
		End Structure
		Dim m_Cursor() As _M_CURSOR = {New _M_CURSOR(), New _M_CURSOR()}

	Public Sub New(ByVal a As CArtCam)
        ' This call required for Windows firm designer Required for Windows firm designer
		InitializeComponent()
		
        ' InitializeComponent() Add initialization after call
        m_ArtCam = a
        m_Init = False
	End Sub

Private Sub Form7_Load( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles MyBase.Load
			m_DllType = m_ArtCam.GetDllVersion() >> 16
			m_CameraInfo.lSize = System.Runtime.InteropServices.Marshal.SizeOf(m_CameraInfo)
			m_ArtCam.GetCameraInfo(m_CameraInfo)
			m_Init = False

			If(1 = m_ArtCam.Monitor_GetColorMode(0)) Then
				checkColor.Checked = true
			Else
				checkAWB.Enabled = false
			End If

			If(1 = m_ArtCam.Monitor_GetBayerGainAuto(0)) Then
				checkAWB.Checked = true

				numericGainR.Enabled = trackGainR.Enabled = false
				numericGainG.Enabled = trackGainG.Enabled = false
				numericGainB.Enabled = trackGainB.Enabled = false
			End If

			' Bayer
			InitControl(numericGainR, trackGainR, 0, 1023, m_ArtCam.Monitor_GetBayerGainRed(0))
			InitControl(numericGainG, trackGainG, 0, 1023, m_ArtCam.Monitor_GetBayerGainGreen(0))
			InitControl(numericGainB, trackGainB, 0, 1023, m_ArtCam.Monitor_GetBayerGainBlue(0))

			' Gain, Exposure, Mirror
			InitControl(numericGainAll, trackGainAll,	m_CameraInfo.lGlobalGainMin, m_CameraInfo.lGlobalGainMax, m_ArtCam.GetGlobalGain())
			InitControl(NumericExposure, trackExposure, m_CameraInfo.lExposureMin,   m_CameraInfo.lExposureMax,   m_ArtCam.GetExposureTime())
			
			checkMirrorV.Checked = m_ArtCam.GetMirrorV()
			checkMirrorH.Checked = m_ArtCam.GetMirrorH()

			Dim i As Integer = 0
			For i = 0 To 1
				' CursorMode
				m_Cursor(i).Enable= m_ArtCam.Monitor_GetCrossCursorMode(i, 0)

				' Position
				m_ArtCam.Monitor_GetCrossCursorPos(i, m_Cursor(i).PosX, m_Cursor(i).PosY)

				' Size
				m_ArtCam.Monitor_GetCrossCursorSize(i, m_Cursor(i).SizeX, m_Cursor(i).SizeY)

				' Color
				m_Cursor(i).Color = m_ArtCam.Monitor_GetCrossCursorColorRGB(i, 0)
			Next
			
			Dim Width As Integer = 1280
			Dim Height As Integer = 1024
			If(ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_1000MI_HD2 = m_DllType) Then
		        Select Case m_ArtCam.Width()
				Case 3664
				Case 1920
					Width = 1920
					Height = 1080
				Case 1280
					Width = 1280
					Height = 720
				End Select
			End If
			
			InitControl(numericXPos, trackXPos, 0, Width,  m_Cursor(m_CursorNumber).PosX)
			InitControl(numericYPos, trackYPos, 0, Height, m_Cursor(m_CursorNumber).PosY)

			InitControl(numericXSize, trackXSize, 0, 7, m_Cursor(m_CursorNumber).SizeX)
			InitControl(numericYSize, trackYSize, 0, 7, m_Cursor(m_CursorNumber).SizeY)

			radioCursor1.Checked = true
			If(1 = m_Cursor(m_CursorNumber).Enable) Then
				checkCursorOn.Checked = true
			Else
				checkCursorOn.Checked = false
			End If
			Invalidate()
			m_Init = True
End Sub

Private Sub InitControl(n As NumericUpDown, t As TrackBar, Minimum As Integer, Maximum As Integer, Now As Integer)
	n.Minimum = Minimum	
	n.Maximum = Maximum
	t.Minimum = Minimum	
	t.Maximum = Maximum

	If(Now < Minimum Or Maximum < Now) Then
		n.Enabled = t.Enabled = false
		return
	End If
	
	t.Value = Now
	n.Value = Now
End Sub

Private Sub ChangeCursor()
	if(1 = m_Cursor(m_CursorNumber).Enable)
		checkCursorOn.Checked = true
	Else
		checkCursorOn.Checked = false
	End If

	Dim Flg As Boolean
	If (1 = m_Cursor(m_CursorNumber).Enable) Then
		Flg = true
	Else
		Flg = false
	End If

	numericXPos.Enabled = trackXPos.Enabled = Flg
	numericYPos.Enabled = trackYPos.Enabled = Flg	
	numericXPos.Value = m_Cursor(m_CursorNumber).PosX
	numericYPos.Value = m_Cursor(m_CursorNumber).PosY
	
	numericXSize.Enabled = trackXSize.Enabled = Flg
	numericYSize.Enabled = trackYSize.Enabled = Flg	
	numericXSize.Value = m_Cursor(m_CursorNumber).SizeX
	numericYSize.Value = m_Cursor(m_CursorNumber).SizeY

	Invalidate()
End Sub

Private Sub RadioCursor1_CheckedChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles RadioCursor1.CheckedChanged
	m_CursorNumber = 0
	ChangeCursor()
End Sub

Private Sub RadioCursor2_CheckedChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles RadioCursor2.CheckedChanged
	m_CursorNumber = 1
	ChangeCursor()
End Sub

Private Sub CheckCursorOn_CheckedChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles CheckCursorOn.CheckedChanged
	Dim Flg As Integer = 0
	If (checkCursorOn.Checked =True)
		Flg = 1
	Else
		Flg = 0
	End If
	m_ArtCam.Monitor_SetCrossCursorMode(m_CursorNumber, Flg)
	m_Cursor(m_CursorNumber).Enable = Flg
	ChangeCursor()
End Sub

Private Sub CheckColor_CheckedChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles CheckColor.CheckedChanged
	CheckAWB_CheckedChanged(sender, e)
End Sub

Private Sub CheckAWB_CheckedChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles CheckAWB.CheckedChanged
	If m_Init = False Then Return
	Dim Color As Boolean = checkColor.Checked
	Dim AWB As Boolean= checkAWB.Checked

	If Color = True
		m_ArtCam.Monitor_SetColorMode(1)
	Else
		m_ArtCam.Monitor_SetColorMode(0)
	End If
	If AWB = True
		m_ArtCam.Monitor_SetBayerGainAuto(1)
	Else
		m_ArtCam.Monitor_SetBayerGainAuto(0)
	End If

	Dim Flg As Boolean = (Color And (Not AWB))
	numericGainR.Enabled = trackGainR.Enabled = Flg
	numericGainG.Enabled = trackGainG.Enabled = Flg
	numericGainB.Enabled = trackGainB.Enabled = Flg

	If Flg Then
		NumericGainR.Value = m_ArtCam.Monitor_GetBayerGainRed(0)
		NumericGainG.Value = m_ArtCam.Monitor_GetBayerGainGreen(0)
		NumericGainB.Value = m_ArtCam.Monitor_GetBayerGainBlue(0)
	End If

	checkAWB.Enabled = Color
End Sub


Private Sub CheckMirrorV_CheckedChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles CheckMirrorV.CheckedChanged
			m_ArtCam.SetMirrorV(checkMirrorV.Checked)
End Sub

Private Sub CheckMirrorH_CheckedChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles CheckMirrorH.CheckedChanged
			m_ArtCam.SetMirrorH(checkMirrorH.Checked)
End Sub

Private Sub ButtonDefault_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles ButtonDefault.Click
	Select Case(m_DllType)
	case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_1000MI_HD2
		' Bayer
		numericGainR.Value = 256
		numericGainG.Value = 256
		numericGainB.Value = 256

		numericGainAll.Value = 64
		numericExposure.Value = 2748

		numericXPos.Value = 360
		numericYPos.Value = 360
		numericXSize.Value = 4
		numericYSize.Value = 4
	End Select
End Sub

Private Sub TrackGainR_Scroll( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles TrackGainR.Scroll
	numericGainR.Value = trackGainR.Value
End Sub

Private Sub TrackGainG_Scroll( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles TrackGainG.Scroll
	numericGainG.Value = trackGainG.Value
End Sub

Private Sub TrackGainB_Scroll( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles TrackGainB.Scroll
	numericGainB.Value = trackGainB.Value
End Sub

Private Sub TrackGainAll_Scroll( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles TrackGainAll.Scroll
	numericGainAll.Value = trackGainAll.Value
End Sub

Private Sub TrackExposure_Scroll( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles TrackExposure.Scroll
	numericExposure.Value = trackExposure.Value
End Sub

Private Sub TrackXPos_Scroll( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles TrackXPos.Scroll
	numericXPos.Value  = trackXPos.Value
End Sub

Private Sub TrackYPos_Scroll( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles TrackYPos.Scroll
	numericYPos.Value  = trackYPos.Value
End Sub

Private Sub TrackXSize_Scroll( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles TrackXSize.Scroll
	numericXSize.Value = trackXSize.Value
End Sub

Private Sub TrackYSize_Scroll( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles TrackYSize.Scroll
	numericYSize.Value = trackYSize.Value
End Sub

Private Sub ButtonInitSettings_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles ButtonInitSettings.Click
	m_ArtCam.Monitor_InitRegisterSettings(0)
End Sub

Private Sub ButtonSaveSettings_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles ButtonSaveSettings.Click
	m_ArtCam.Monitor_SaveCurrentSettings()
End Sub

Private Sub PictureColor_MouseUp( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureColor.MouseUp
	Dim w As Integer = pictureColor.Width / 16
	Dim h As Integer = pictureColor.Height
	Dim p As Point = Cursor.Position

	Dim i As Integer = 0
	For i = 0 To 15
		Dim rc As Rectangle = new Rectangle(w*i, 0, w, h)
		If(rc.Contains(pictureColor.PointToClient(p))) Then
			m_ArtCam.Monitor_SetCrossCursorColorRGB(m_CursorNumber, i)
			Invalidate()
		End If
	Next
End Sub

Private Sub Form7_Paint( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
	Dim canvas As Bitmap  = new Bitmap(pictureColor.Width, pictureColor.Height)
	Dim g As Graphics = Graphics.FromImage(canvas)
	Dim w As Integer = pictureColor.Width / 16
	Dim h As Integer = pictureColor.Height
	Dim c As Color() = { _
		Color.FromArgb(&HFF, &HFF, &HFF), _
		Color.FromArgb(&H00, &H00, &H00), _
		Color.FromArgb(&HFF, &HFF, &H00), _
		Color.FromArgb(&HFF, &H00, &H00), _
		Color.FromArgb(&H00, &H00, &HFF), _
		Color.FromArgb(&H00, &HFF, &H00), _
		Color.FromArgb(&H80, &H40, &H00), _
		Color.FromArgb(&H80, &H80, &H80), _
		Color.FromArgb(&H00, &H80, &HFF), _
		Color.FromArgb(&H80, &H00, &HFF), _
		Color.FromArgb(&HFF, &H80, &HFF), _
		Color.FromArgb(&H80, &H80, &H00), _
		Color.FromArgb(&H80, &H00, &H40), _
		Color.FromArgb(&H80, &HFF, &HFF), _
		Color.FromArgb(&HFF, &H80, &H00), _
		Color.FromArgb(&H40, &H80, &H80) _
	}

	Dim cc As Integer = m_ArtCam.Monitor_GetCrossCursorColorRGB(m_CursorNumber, 0)

	Dim i As Integer = 0
	For i = 0 To 15
		Dim rc As Rectangle = new Rectangle(w*i, 0, w, h)
		Dim b As SolidBrush = new SolidBrush(c(i))
		g.FillRectangle(b, rc)

		If(cc = i) Then
			g.DrawRectangle(Pens.Red, rc.X, rc.Y, rc.Width-1, rc.Height-1)
		End If
	Next

	g.Dispose()
	pictureColor.Image = canvas
	End Sub

Private Sub NumericGainR_ValueChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles NumericGainR.ValueChanged
	If m_Init = False Then Return
	Dim pos As Integer = numericGainR.Value
	trackGainR.Value = pos
	m_ArtCam.Monitor_SetBayerGainRed(pos)	
End Sub

Private Sub NumericGainG_ValueChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles NumericGainG.ValueChanged
	If m_Init = False Then Return
	Dim pos As Integer = numericGainG.Value
	trackGainG.Value = pos
	m_ArtCam.Monitor_SetBayerGainGreen(pos)	
End Sub

Private Sub NumericGainB_ValueChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles NumericGainB.ValueChanged
	If m_Init = False Then Return
	Dim pos As Integer = numericGainB.Value
	trackGainB.Value = pos
	m_ArtCam.Monitor_SetBayerGainBlue(pos)	
End Sub

Private Sub NumericGainAll_ValueChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles NumericGainAll.ValueChanged
	If m_Init = False Then Return
	Dim pos As Integer = numericGainAll.Value
	trackGainAll.Value = pos
	m_ArtCam.SetGlobalGain(pos)
End Sub


Private Sub NumericExposure_ValueChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles NumericExposure.ValueChanged
	If m_Init = False Then Return
	Dim pos As Integer = numericExposure.Value
	trackExposure.Value = pos
	m_ArtCam.SetExposureTime(pos)	

End Sub

Private Sub NumericXPos_ValueChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles NumericXPos.ValueChanged
	If m_Init = False Then Return
	Dim pos As Integer = numericXPos.Value
	trackXPos.Value = pos
	m_Cursor(m_CursorNumber).PosX = pos
	m_ArtCam.Monitor_SetCrossCursorPos(m_CursorNumber, m_Cursor(m_CursorNumber).PosX,  m_Cursor(m_CursorNumber).PosY)
End Sub

Private Sub NumericYPos_ValueChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles NumericYPos.ValueChanged
	If m_Init = False Then Return
	Dim pos As Integer = numericYPos.Value
	trackYPos.Value = pos
	m_Cursor(m_CursorNumber).PosY = pos
	m_ArtCam.Monitor_SetCrossCursorPos(m_CursorNumber, m_Cursor(m_CursorNumber).PosX,  m_Cursor(m_CursorNumber).PosY)
End Sub

Private Sub NumericXSize_ValueChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles NumericXSize.ValueChanged
	If m_Init = False Then Return
	Dim pos As Integer = NumericXSize.Value
	trackXSize.Value = pos
	m_Cursor(m_CursorNumber).SizeX = pos
	m_ArtCam.Monitor_SetCrossCursorSize(m_CursorNumber, m_Cursor(m_CursorNumber).SizeX, m_Cursor(m_CursorNumber).SizeY)
End Sub

Private Sub NumericYSize_ValueChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles NumericYSize.ValueChanged
	If m_Init = False Then Return
	Dim pos As Integer = NumericYSize.Value
	trackYSize.Value = pos
	m_Cursor(m_CursorNumber).SizeY = pos
	m_ArtCam.Monitor_SetCrossCursorSize(m_CursorNumber, m_Cursor(m_CursorNumber).SizeX, m_Cursor(m_CursorNumber).SizeY)
End Sub
End Class
Imports Sample_VB.ArtCamSdk

Public Class Form6
    Dim m_ArtCam As CArtCam = Nothing

Private Sub Form6_Load( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles MyBase.Load
		Dim MaskFilter As Integer = m_ArtCam.GetMaskFilter()
		Dim DotFilter As Integer = m_ArtCam.GetDotFilter()
		
		If (DotFilter <> 0) Then
			checkDotfilterEnable.Checked = true
		End If
		If (MaskFilter <> 0) Then
			checkCorrectionEnable.Checked = true
		End If

End Sub

Private Sub buttonUpdateLow_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles buttonUpdateLow.Click
	m_ArtCam.UpdateMaskData(MASKTYPE.MASKTYPE_LOW)
End Sub

Private Sub buttonUpdateHigh_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles buttonUpdateHigh.Click
	m_ArtCam.UpdateMaskData(MASKTYPE.MASKTYPE_HIGH)
End Sub

Private Sub buttonSaveMask_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles buttonSaveMask.Click
	Dim sfd As New SaveFileDialog()
	sfd.FileName = "Default.msk"
	sfd.Filter = "MSK file(*.msk)|*.msk||"
	If sfd.ShowDialog() = DialogResult.OK Then
		Dim str As new System.Text.StringBuilder()
		str.Append(sfd.FileName)
		m_ArtCam.SaveMaskFile(str)
	End If
End Sub

Private Sub buttonLoadMask_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles buttonLoadMask.Click
	Dim ofd As New OpenFileDialog()
	ofd.FileName = "Default.msk"
	ofd.Filter = "MSK file(*.msk)|*.msk||"
	If ofd.ShowDialog() = DialogResult.OK Then
		Dim str As new System.Text.StringBuilder()
		str.Append(ofd.FileName)
		m_ArtCam.LoadMaskFile(str)
	End If
End Sub

Private Sub checkCorrectionEnable_CheckedChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles checkCorrectionEnable.CheckedChanged
	Dim Enable As Integer = 0
	If checkCorrectionEnable.Checked = true Then
		Enable = 1
	End If
	m_ArtCam.SetMaskFilter(Enable)
End Sub

Private Sub checkDotfilterEnable_CheckedChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles checkDotfilterEnable.CheckedChanged
	Dim Enable As Integer = 0
	If checkDotfilterEnable.Checked = true Then
		Enable = 1
	End If
	m_ArtCam.SetDotFilter(Enable)
End Sub
End Class
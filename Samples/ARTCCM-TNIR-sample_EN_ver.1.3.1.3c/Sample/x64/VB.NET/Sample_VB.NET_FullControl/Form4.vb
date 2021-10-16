Imports Sample_VB.ArtCamSdk

Public Class Form4
    Inherits System.Windows.Forms.Form

#Region " Code made by Windows form designer "

    Public Sub New(ByVal a As CArtCam)
        MyBase.New()

        ' This call 
        InitializeComponent()

        ' InitializeComponent() Add initialization after call 
        m_ArtCam = a
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
    Friend WithEvents button2 As System.Windows.Forms.Button
    Friend WithEvents button3 As System.Windows.Forms.Button
    Friend WithEvents button1 As System.Windows.Forms.Button
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents checkBoxRead7 As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxRead8 As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxRead5 As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxRead6 As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxRead3 As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxRead4 As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxRead2 As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxRead1 As System.Windows.Forms.CheckBox
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents checkBoxWrite1 As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxWrite2 As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxWrite3 As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxWrite4 As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxWrite5 As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxWrite6 As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxWrite7 As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxWrite8 As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button3 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.checkBoxRead7 = New System.Windows.Forms.CheckBox()
        Me.checkBoxRead8 = New System.Windows.Forms.CheckBox()
        Me.checkBoxRead5 = New System.Windows.Forms.CheckBox()
        Me.checkBoxRead6 = New System.Windows.Forms.CheckBox()
        Me.checkBoxRead3 = New System.Windows.Forms.CheckBox()
        Me.checkBoxRead4 = New System.Windows.Forms.CheckBox()
        Me.checkBoxRead2 = New System.Windows.Forms.CheckBox()
        Me.checkBoxRead1 = New System.Windows.Forms.CheckBox()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.checkBoxWrite1 = New System.Windows.Forms.CheckBox()
        Me.checkBoxWrite2 = New System.Windows.Forms.CheckBox()
        Me.checkBoxWrite3 = New System.Windows.Forms.CheckBox()
        Me.checkBoxWrite4 = New System.Windows.Forms.CheckBox()
        Me.checkBoxWrite5 = New System.Windows.Forms.CheckBox()
        Me.checkBoxWrite6 = New System.Windows.Forms.CheckBox()
        Me.checkBoxWrite7 = New System.Windows.Forms.CheckBox()
        Me.checkBoxWrite8 = New System.Windows.Forms.CheckBox()
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'button2
        '
        Me.button2.Enabled = False
        Me.button2.Location = New System.Drawing.Point(240, 104)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(80, 72)
        Me.button2.TabIndex = 8
        Me.button2.Text = "Write"
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(240, 192)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(80, 23)
        Me.button3.TabIndex = 9
        Me.button3.Text = "Close"
        '
        'button1
        '
        Me.button1.Enabled = False
        Me.button1.Location = New System.Drawing.Point(240, 16)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(80, 72)
        Me.button1.TabIndex = 7
        Me.button1.Text = "Read"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.checkBoxRead7, Me.checkBoxRead8, Me.checkBoxRead5, Me.checkBoxRead6, Me.checkBoxRead3, Me.checkBoxRead4, Me.checkBoxRead2, Me.checkBoxRead1})
        Me.groupBox1.Location = New System.Drawing.Point(8, 8)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(216, 80)
        Me.groupBox1.TabIndex = 5
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Register for Reading"
        '
        'checkBoxRead7
        '
        Me.checkBoxRead7.Enabled = False
        Me.checkBoxRead7.Location = New System.Drawing.Point(184, 32)
        Me.checkBoxRead7.Name = "checkBoxRead7"
        Me.checkBoxRead7.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxRead7.TabIndex = 7
        '
        'checkBoxRead8
        '
        Me.checkBoxRead8.Enabled = False
        Me.checkBoxRead8.Location = New System.Drawing.Point(160, 32)
        Me.checkBoxRead8.Name = "checkBoxRead8"
        Me.checkBoxRead8.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxRead8.TabIndex = 6
        '
        'checkBoxRead5
        '
        Me.checkBoxRead5.Enabled = False
        Me.checkBoxRead5.Location = New System.Drawing.Point(136, 32)
        Me.checkBoxRead5.Name = "checkBoxRead5"
        Me.checkBoxRead5.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxRead5.TabIndex = 5
        '
        'checkBoxRead6
        '
        Me.checkBoxRead6.Enabled = False
        Me.checkBoxRead6.Location = New System.Drawing.Point(112, 32)
        Me.checkBoxRead6.Name = "checkBoxRead6"
        Me.checkBoxRead6.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxRead6.TabIndex = 4
        '
        'checkBoxRead3
        '
        Me.checkBoxRead3.Enabled = False
        Me.checkBoxRead3.Location = New System.Drawing.Point(88, 32)
        Me.checkBoxRead3.Name = "checkBoxRead3"
        Me.checkBoxRead3.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxRead3.TabIndex = 3
        '
        'checkBoxRead4
        '
        Me.checkBoxRead4.Enabled = False
        Me.checkBoxRead4.Location = New System.Drawing.Point(64, 32)
        Me.checkBoxRead4.Name = "checkBoxRead4"
        Me.checkBoxRead4.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxRead4.TabIndex = 2
        '
        'checkBoxRead2
        '
        Me.checkBoxRead2.Enabled = False
        Me.checkBoxRead2.Location = New System.Drawing.Point(40, 32)
        Me.checkBoxRead2.Name = "checkBoxRead2"
        Me.checkBoxRead2.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxRead2.TabIndex = 1
        '
        'checkBoxRead1
        '
        Me.checkBoxRead1.Enabled = False
        Me.checkBoxRead1.Location = New System.Drawing.Point(16, 32)
        Me.checkBoxRead1.Name = "checkBoxRead1"
        Me.checkBoxRead1.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxRead1.TabIndex = 0
        '
        'groupBox2
        '
        Me.groupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.checkBoxWrite1, Me.checkBoxWrite2, Me.checkBoxWrite3, Me.checkBoxWrite4, Me.checkBoxWrite5, Me.checkBoxWrite6, Me.checkBoxWrite7, Me.checkBoxWrite8})
        Me.groupBox2.Location = New System.Drawing.Point(8, 104)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(216, 80)
        Me.groupBox2.TabIndex = 6
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Register for Writing"
        '
        'checkBoxWrite1
        '
        Me.checkBoxWrite1.Enabled = False
        Me.checkBoxWrite1.Location = New System.Drawing.Point(184, 32)
        Me.checkBoxWrite1.Name = "checkBoxWrite1"
        Me.checkBoxWrite1.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxWrite1.TabIndex = 15
        '
        'checkBoxWrite2
        '
        Me.checkBoxWrite2.Enabled = False
        Me.checkBoxWrite2.Location = New System.Drawing.Point(160, 32)
        Me.checkBoxWrite2.Name = "checkBoxWrite2"
        Me.checkBoxWrite2.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxWrite2.TabIndex = 14
        '
        'checkBoxWrite3
        '
        Me.checkBoxWrite3.Enabled = False
        Me.checkBoxWrite3.Location = New System.Drawing.Point(136, 32)
        Me.checkBoxWrite3.Name = "checkBoxWrite3"
        Me.checkBoxWrite3.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxWrite3.TabIndex = 13
        '
        'checkBoxWrite4
        '
        Me.checkBoxWrite4.Enabled = False
        Me.checkBoxWrite4.Location = New System.Drawing.Point(112, 32)
        Me.checkBoxWrite4.Name = "checkBoxWrite4"
        Me.checkBoxWrite4.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxWrite4.TabIndex = 12
        '
        'checkBoxWrite5
        '
        Me.checkBoxWrite5.Enabled = False
        Me.checkBoxWrite5.Location = New System.Drawing.Point(88, 32)
        Me.checkBoxWrite5.Name = "checkBoxWrite5"
        Me.checkBoxWrite5.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxWrite5.TabIndex = 11
        '
        'checkBoxWrite6
        '
        Me.checkBoxWrite6.Enabled = False
        Me.checkBoxWrite6.Location = New System.Drawing.Point(64, 32)
        Me.checkBoxWrite6.Name = "checkBoxWrite6"
        Me.checkBoxWrite6.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxWrite6.TabIndex = 10
        '
        'checkBoxWrite7
        '
        Me.checkBoxWrite7.Enabled = False
        Me.checkBoxWrite7.Location = New System.Drawing.Point(40, 32)
        Me.checkBoxWrite7.Name = "checkBoxWrite7"
        Me.checkBoxWrite7.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxWrite7.TabIndex = 9
        '
        'checkBoxWrite8
        '
        Me.checkBoxWrite8.Enabled = False
        Me.checkBoxWrite8.Location = New System.Drawing.Point(16, 32)
        Me.checkBoxWrite8.Name = "checkBoxWrite8"
        Me.checkBoxWrite8.Size = New System.Drawing.Size(16, 24)
        Me.checkBoxWrite8.TabIndex = 8
        '
        'Form4
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(328, 229)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button2, Me.button3, Me.button1, Me.groupBox1, Me.groupBox2})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form4"
        Me.Text = "IO Settings"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim m_ArtCam As CArtCam = Nothing

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Change operation depending on DLL.
        ' Please refer to the manual for function correspondence with each DLL.
		Dim m_DllType As ARTCAM_CAMERATYPE = (m_ArtCam.GetDllVersion() >> 16)

        Select Case m_DllType
            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_130MI, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_200MI, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_300MI
                button1.Enabled = True
                checkBoxRead1.Enabled = True
                checkBoxRead2.Enabled = True
                checkBoxRead3.Enabled = True
                checkBoxRead4.Enabled = True
                checkBoxRead5.Enabled = True
                checkBoxRead6.Enabled = True
                checkBoxRead7.Enabled = True
                checkBoxRead8.Enabled = True

                button2.Enabled = True
                checkBoxWrite1.Enabled = True
                checkBoxWrite2.Enabled = True
                checkBoxWrite3.Enabled = True
                checkBoxWrite4.Enabled = True
                checkBoxWrite5.Enabled = True
                checkBoxWrite6.Enabled = True
                checkBoxWrite7.Enabled = True
                checkBoxWrite8.Enabled = True
        End Select



    End Sub

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        Dim Data As Byte = 0
        Dim longdata As Integer = 0

        If Not m_ArtCam.GetIOPort(Data, longdata, 0) = 0 Then
            If Not (Data And &H1) = 0 Then
                checkBoxRead1.Checked = True
            Else
                checkBoxRead1.Checked = False
            End If

            If Not (Data And &H2) = 0 Then
                checkBoxRead2.Checked = True
            Else
                checkBoxRead2.Checked = False
            End If

            If Not (Data And &H4) = 0 Then
                checkBoxRead3.Checked = True
            Else
                checkBoxRead3.Checked = False
            End If

            If Not (Data And &H8) = 0 Then
                checkBoxRead4.Checked = True
            Else
                checkBoxRead4.Checked = False
            End If

            If Not (Data And &H10) = 0 Then
                checkBoxRead5.Checked = True
            Else
                checkBoxRead5.Checked = False
            End If

            If Not (Data And &H20) = 0 Then
                checkBoxRead6.Checked = True
            Else
                checkBoxRead6.Checked = False
            End If

            If Not (Data And &H40) = 0 Then
                checkBoxRead7.Checked = True
            Else
                checkBoxRead7.Checked = False
            End If

            If Not (Data And &H80) = 0 Then
                checkBoxRead8.Checked = True
            Else
                checkBoxRead8.Checked = False
            End If
        End If
    End Sub

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
        Dim data As Byte = 0
        If checkBoxWrite1.Checked Then data += &H1
        If checkBoxWrite2.Checked Then data += &H2
        If checkBoxWrite3.Checked Then data += &H4
        If checkBoxWrite4.Checked Then data += &H8
        If checkBoxWrite5.Checked Then data += &H10
        If checkBoxWrite6.Checked Then data += &H20
        If checkBoxWrite7.Checked Then data += &H40
        If checkBoxWrite8.Checked Then data += &H80
        m_ArtCam.SetIOPort(data, 0, 0)
    End Sub

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click
        Hide()
    End Sub
End Class

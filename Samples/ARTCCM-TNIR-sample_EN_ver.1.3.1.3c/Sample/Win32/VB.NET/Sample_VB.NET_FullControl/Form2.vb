Imports Sample_VB.ArtCamSdk

Public Class Form2
    Inherits System.Windows.Forms.Form

    Dim pError As Integer
    Dim m_DllType As ARTCAM_CAMERATYPE = 0
    Dim m_CameraType As ARTCAM_CAMERATYPE_SATA = 0
    Dim m_ArtCam As CArtCam = Nothing

#Region "Code made by Windows form designer "

    Public Sub New(ByVal a As CArtCam)
        MyBase.New()

        ' This call required for Windows firm designer
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
    Friend WithEvents button1 As System.Windows.Forms.Button
    Friend WithEvents groupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents textCode8 As System.Windows.Forms.TextBox
    Friend WithEvents textCode7 As System.Windows.Forms.TextBox
    Friend WithEvents textCode6 As System.Windows.Forms.TextBox
    Friend WithEvents textCode5 As System.Windows.Forms.TextBox
    Friend WithEvents textCode4 As System.Windows.Forms.TextBox
    Friend WithEvents textCode3 As System.Windows.Forms.TextBox
    Friend WithEvents textCode2 As System.Windows.Forms.TextBox
    Friend WithEvents textCode1 As System.Windows.Forms.TextBox
    Friend WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents labelVideo As System.Windows.Forms.Label
    Friend WithEvents groupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents radioChannel6 As System.Windows.Forms.RadioButton
    Friend WithEvents radioChannel5 As System.Windows.Forms.RadioButton
    Friend WithEvents radioChannel4 As System.Windows.Forms.RadioButton
    Friend WithEvents radioChannel3 As System.Windows.Forms.RadioButton
    Friend WithEvents radioChannel2 As System.Windows.Forms.RadioButton
    Friend WithEvents radioChannel1 As System.Windows.Forms.RadioButton
    Friend WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents radioNL As System.Windows.Forms.RadioButton
    Friend WithEvents radioNH As System.Windows.Forms.RadioButton
    Friend WithEvents radioWL As System.Windows.Forms.RadioButton
    Friend WithEvents radioWH As System.Windows.Forms.RadioButton
    Friend WithEvents textFps As System.Windows.Forms.TextBox
    Friend WithEvents labelFps As System.Windows.Forms.Label
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents textVT As System.Windows.Forms.TextBox
    Friend WithEvents textVE As System.Windows.Forms.TextBox
    Friend WithEvents textVS As System.Windows.Forms.TextBox
    Friend WithEvents textHS As System.Windows.Forms.TextBox
    Friend WithEvents textHE As System.Windows.Forms.TextBox
    Friend WithEvents textHT As System.Windows.Forms.TextBox
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents radioSubSample8 As System.Windows.Forms.RadioButton
    Friend WithEvents radioSubSample4 As System.Windows.Forms.RadioButton
    Friend WithEvents radioSubSample2 As System.Windows.Forms.RadioButton
    Friend WithEvents radioSubSample1 As System.Windows.Forms.RadioButton
    Friend WithEvents checkCode As System.Windows.Forms.CheckBox
    Friend WithEvents button2 As System.Windows.Forms.Button
    Friend WithEvents groupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents radioColor64 As System.Windows.Forms.RadioButton
    Friend WithEvents radioColor48 As System.Windows.Forms.RadioButton
    Friend WithEvents radioColor32 As System.Windows.Forms.RadioButton
    Friend WithEvents radioColor24 As System.Windows.Forms.RadioButton
    Friend WithEvents radioColor16 As System.Windows.Forms.RadioButton
    Friend WithEvents radioColor08 As System.Windows.Forms.RadioButton
    Friend WithEvents checkBinning As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button
        Me.groupBox7 = New System.Windows.Forms.GroupBox
        Me.textCode8 = New System.Windows.Forms.TextBox
        Me.textCode7 = New System.Windows.Forms.TextBox
        Me.textCode6 = New System.Windows.Forms.TextBox
        Me.textCode5 = New System.Windows.Forms.TextBox
        Me.textCode4 = New System.Windows.Forms.TextBox
        Me.textCode3 = New System.Windows.Forms.TextBox
        Me.textCode2 = New System.Windows.Forms.TextBox
        Me.textCode1 = New System.Windows.Forms.TextBox
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.labelVideo = New System.Windows.Forms.Label
        Me.groupBox5 = New System.Windows.Forms.GroupBox
        Me.radioChannel6 = New System.Windows.Forms.RadioButton
        Me.radioChannel5 = New System.Windows.Forms.RadioButton
        Me.radioChannel4 = New System.Windows.Forms.RadioButton
        Me.radioChannel3 = New System.Windows.Forms.RadioButton
        Me.radioChannel2 = New System.Windows.Forms.RadioButton
        Me.radioChannel1 = New System.Windows.Forms.RadioButton
        Me.groupBox4 = New System.Windows.Forms.GroupBox
        Me.radioNL = New System.Windows.Forms.RadioButton
        Me.radioNH = New System.Windows.Forms.RadioButton
        Me.radioWL = New System.Windows.Forms.RadioButton
        Me.radioWH = New System.Windows.Forms.RadioButton
        Me.textFps = New System.Windows.Forms.TextBox
        Me.labelFps = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.textVT = New System.Windows.Forms.TextBox
        Me.textVE = New System.Windows.Forms.TextBox
        Me.textVS = New System.Windows.Forms.TextBox
        Me.textHS = New System.Windows.Forms.TextBox
        Me.textHE = New System.Windows.Forms.TextBox
        Me.textHT = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.radioSubSample8 = New System.Windows.Forms.RadioButton
        Me.radioSubSample4 = New System.Windows.Forms.RadioButton
        Me.radioSubSample2 = New System.Windows.Forms.RadioButton
        Me.radioSubSample1 = New System.Windows.Forms.RadioButton
        Me.checkCode = New System.Windows.Forms.CheckBox
        Me.button2 = New System.Windows.Forms.Button
        Me.groupBox6 = New System.Windows.Forms.GroupBox
        Me.radioColor64 = New System.Windows.Forms.RadioButton
        Me.radioColor48 = New System.Windows.Forms.RadioButton
        Me.radioColor32 = New System.Windows.Forms.RadioButton
        Me.radioColor24 = New System.Windows.Forms.RadioButton
        Me.radioColor16 = New System.Windows.Forms.RadioButton
        Me.radioColor08 = New System.Windows.Forms.RadioButton
        Me.checkBinning = New System.Windows.Forms.CheckBox
        Me.groupBox7.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.button1.Location = New System.Drawing.Point(288, 408)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 18
        Me.button1.Text = "Apply"
        '
        'groupBox7
        '
        Me.groupBox7.Controls.Add(Me.textCode8)
        Me.groupBox7.Controls.Add(Me.textCode7)
        Me.groupBox7.Controls.Add(Me.textCode6)
        Me.groupBox7.Controls.Add(Me.textCode5)
        Me.groupBox7.Controls.Add(Me.textCode4)
        Me.groupBox7.Controls.Add(Me.textCode3)
        Me.groupBox7.Controls.Add(Me.textCode2)
        Me.groupBox7.Controls.Add(Me.textCode1)
        Me.groupBox7.Location = New System.Drawing.Point(288, 240)
        Me.groupBox7.Name = "groupBox7"
        Me.groupBox7.Size = New System.Drawing.Size(160, 152)
        Me.groupBox7.TabIndex = 16
        Me.groupBox7.TabStop = False
        '
        'textCode8
        '
        Me.textCode8.Location = New System.Drawing.Point(88, 120)
        Me.textCode8.Name = "textCode8"
        Me.textCode8.Size = New System.Drawing.Size(56, 19)
        Me.textCode8.TabIndex = 13
        Me.textCode8.Text = "0"
        '
        'textCode7
        '
        Me.textCode7.Location = New System.Drawing.Point(88, 88)
        Me.textCode7.Name = "textCode7"
        Me.textCode7.Size = New System.Drawing.Size(56, 19)
        Me.textCode7.TabIndex = 12
        Me.textCode7.Text = "0"
        '
        'textCode6
        '
        Me.textCode6.Location = New System.Drawing.Point(88, 56)
        Me.textCode6.Name = "textCode6"
        Me.textCode6.Size = New System.Drawing.Size(56, 19)
        Me.textCode6.TabIndex = 11
        Me.textCode6.Text = "0"
        '
        'textCode5
        '
        Me.textCode5.Location = New System.Drawing.Point(88, 24)
        Me.textCode5.Name = "textCode5"
        Me.textCode5.Size = New System.Drawing.Size(56, 19)
        Me.textCode5.TabIndex = 10
        Me.textCode5.Text = "0"
        '
        'textCode4
        '
        Me.textCode4.Location = New System.Drawing.Point(16, 120)
        Me.textCode4.Name = "textCode4"
        Me.textCode4.Size = New System.Drawing.Size(56, 19)
        Me.textCode4.TabIndex = 9
        Me.textCode4.Text = "0"
        '
        'textCode3
        '
        Me.textCode3.Location = New System.Drawing.Point(16, 88)
        Me.textCode3.Name = "textCode3"
        Me.textCode3.Size = New System.Drawing.Size(56, 19)
        Me.textCode3.TabIndex = 8
        Me.textCode3.Text = "0"
        '
        'textCode2
        '
        Me.textCode2.Location = New System.Drawing.Point(16, 56)
        Me.textCode2.Name = "textCode2"
        Me.textCode2.Size = New System.Drawing.Size(56, 19)
        Me.textCode2.TabIndex = 7
        Me.textCode2.Text = "0"
        '
        'textCode1
        '
        Me.textCode1.Location = New System.Drawing.Point(16, 24)
        Me.textCode1.Name = "textCode1"
        Me.textCode1.Size = New System.Drawing.Size(56, 19)
        Me.textCode1.TabIndex = 6
        Me.textCode1.Text = "0"
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.labelVideo)
        Me.groupBox3.Controls.Add(Me.groupBox5)
        Me.groupBox3.Controls.Add(Me.groupBox4)
        Me.groupBox3.Location = New System.Drawing.Point(8, 240)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(264, 192)
        Me.groupBox3.TabIndex = 12
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Only for CNV"
        '
        'labelVideo
        '
        Me.labelVideo.Location = New System.Drawing.Point(40, 24)
        Me.labelVideo.Name = "labelVideo"
        Me.labelVideo.Size = New System.Drawing.Size(176, 16)
        Me.labelVideo.TabIndex = 2
        Me.labelVideo.Text = "VideoFormat : "
        '
        'groupBox5
        '
        Me.groupBox5.Controls.Add(Me.radioChannel6)
        Me.groupBox5.Controls.Add(Me.radioChannel5)
        Me.groupBox5.Controls.Add(Me.radioChannel4)
        Me.groupBox5.Controls.Add(Me.radioChannel3)
        Me.groupBox5.Controls.Add(Me.radioChannel2)
        Me.groupBox5.Controls.Add(Me.radioChannel1)
        Me.groupBox5.Location = New System.Drawing.Point(160, 48)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(88, 128)
        Me.groupBox5.TabIndex = 1
        Me.groupBox5.TabStop = False
        Me.groupBox5.Text = "Channel"
        '
        'radioChannel6
        '
        Me.radioChannel6.Location = New System.Drawing.Point(48, 88)
        Me.radioChannel6.Name = "radioChannel6"
        Me.radioChannel6.Size = New System.Drawing.Size(24, 16)
        Me.radioChannel6.TabIndex = 5
        Me.radioChannel6.Text = "6"
        '
        'radioChannel5
        '
        Me.radioChannel5.Location = New System.Drawing.Point(48, 56)
        Me.radioChannel5.Name = "radioChannel5"
        Me.radioChannel5.Size = New System.Drawing.Size(24, 16)
        Me.radioChannel5.TabIndex = 4
        Me.radioChannel5.Text = "5"
        '
        'radioChannel4
        '
        Me.radioChannel4.Location = New System.Drawing.Point(48, 24)
        Me.radioChannel4.Name = "radioChannel4"
        Me.radioChannel4.Size = New System.Drawing.Size(24, 16)
        Me.radioChannel4.TabIndex = 3
        Me.radioChannel4.Text = "4"
        '
        'radioChannel3
        '
        Me.radioChannel3.Location = New System.Drawing.Point(16, 88)
        Me.radioChannel3.Name = "radioChannel3"
        Me.radioChannel3.Size = New System.Drawing.Size(24, 16)
        Me.radioChannel3.TabIndex = 2
        Me.radioChannel3.Text = "3"
        '
        'radioChannel2
        '
        Me.radioChannel2.Location = New System.Drawing.Point(16, 56)
        Me.radioChannel2.Name = "radioChannel2"
        Me.radioChannel2.Size = New System.Drawing.Size(24, 16)
        Me.radioChannel2.TabIndex = 1
        Me.radioChannel2.Text = "2"
        '
        'radioChannel1
        '
        Me.radioChannel1.Location = New System.Drawing.Point(16, 24)
        Me.radioChannel1.Name = "radioChannel1"
        Me.radioChannel1.Size = New System.Drawing.Size(24, 16)
        Me.radioChannel1.TabIndex = 0
        Me.radioChannel1.Text = "1"
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.radioNL)
        Me.groupBox4.Controls.Add(Me.radioNH)
        Me.groupBox4.Controls.Add(Me.radioWL)
        Me.groupBox4.Controls.Add(Me.radioWH)
        Me.groupBox4.Location = New System.Drawing.Point(8, 48)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(136, 128)
        Me.groupBox4.TabIndex = 0
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Sampling rate"
        '
        'radioNL
        '
        Me.radioNL.Location = New System.Drawing.Point(8, 96)
        Me.radioNL.Name = "radioNL"
        Me.radioNL.Size = New System.Drawing.Size(120, 16)
        Me.radioNL.TabIndex = 3
        Me.radioNL.Text = "Normal Lowspeed"
        '
        'radioNH
        '
        Me.radioNH.Location = New System.Drawing.Point(8, 72)
        Me.radioNH.Name = "radioNH"
        Me.radioNH.Size = New System.Drawing.Size(104, 16)
        Me.radioNH.TabIndex = 2
        Me.radioNH.Text = "Normal Hispeed"
        '
        'radioWL
        '
        Me.radioWL.Location = New System.Drawing.Point(8, 48)
        Me.radioWL.Name = "radioWL"
        Me.radioWL.Size = New System.Drawing.Size(104, 16)
        Me.radioWL.TabIndex = 1
        Me.radioWL.Text = "Wide Lowspeed"
        '
        'radioWH
        '
        Me.radioWH.Location = New System.Drawing.Point(8, 24)
        Me.radioWH.Name = "radioWH"
        Me.radioWH.Size = New System.Drawing.Size(96, 16)
        Me.radioWH.TabIndex = 0
        Me.radioWH.Text = "Wide Hispeed"
        '
        'textFps
        '
        Me.textFps.Location = New System.Drawing.Point(312, 144)
        Me.textFps.Name = "textFps"
        Me.textFps.Size = New System.Drawing.Size(72, 19)
        Me.textFps.TabIndex = 15
        Me.textFps.Text = "0"
        '
        'labelFps
        '
        Me.labelFps.Location = New System.Drawing.Point(296, 120)
        Me.labelFps.Name = "labelFps"
        Me.labelFps.Size = New System.Drawing.Size(112, 16)
        Me.labelFps.TabIndex = 14
        Me.labelFps.Text = "Waiting time  (ms)"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.textVT)
        Me.groupBox1.Controls.Add(Me.textVE)
        Me.groupBox1.Controls.Add(Me.textVS)
        Me.groupBox1.Controls.Add(Me.textHS)
        Me.groupBox1.Controls.Add(Me.textHE)
        Me.groupBox1.Controls.Add(Me.textHT)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(8, 8)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(264, 144)
        Me.groupBox1.TabIndex = 10
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Size for taking in"
        '
        'textVT
        '
        Me.textVT.Location = New System.Drawing.Point(176, 48)
        Me.textVT.Name = "textVT"
        Me.textVT.Size = New System.Drawing.Size(72, 19)
        Me.textVT.TabIndex = 10
        Me.textVT.Text = "0"
        '
        'textVE
        '
        Me.textVE.Location = New System.Drawing.Point(176, 80)
        Me.textVE.Name = "textVE"
        Me.textVE.Size = New System.Drawing.Size(72, 19)
        Me.textVE.TabIndex = 9
        Me.textVE.Text = "0"
        '
        'textVS
        '
        Me.textVS.Location = New System.Drawing.Point(176, 112)
        Me.textVS.Name = "textVS"
        Me.textVS.Size = New System.Drawing.Size(72, 19)
        Me.textVS.TabIndex = 8
        Me.textVS.Text = "0"
        '
        'textHS
        '
        Me.textHS.Location = New System.Drawing.Point(88, 112)
        Me.textHS.Name = "textHS"
        Me.textHS.Size = New System.Drawing.Size(72, 19)
        Me.textHS.TabIndex = 7
        Me.textHS.Text = "0"
        '
        'textHE
        '
        Me.textHE.Location = New System.Drawing.Point(88, 80)
        Me.textHE.Name = "textHE"
        Me.textHE.Size = New System.Drawing.Size(72, 19)
        Me.textHE.TabIndex = 6
        Me.textHE.Text = "0"
        '
        'textHT
        '
        Me.textHT.Location = New System.Drawing.Point(88, 48)
        Me.textHT.Name = "textHT"
        Me.textHT.Size = New System.Drawing.Size(72, 19)
        Me.textHT.TabIndex = 5
        Me.textHT.Text = "0"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(184, 24)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(48, 16)
        Me.label5.TabIndex = 4
        Me.label5.Text = "Vertical"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(96, 24)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(48, 16)
        Me.label4.TabIndex = 3
        Me.label4.Text = "Horizon"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(8, 112)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(80, 16)
        Me.label3.TabIndex = 2
        Me.label3.Text = "Starting point"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(8, 80)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(64, 16)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Valid pixels"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(8, 48)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(64, 16)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Total pixels"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.radioSubSample8)
        Me.groupBox2.Controls.Add(Me.radioSubSample4)
        Me.groupBox2.Controls.Add(Me.radioSubSample2)
        Me.groupBox2.Controls.Add(Me.radioSubSample1)
        Me.groupBox2.Location = New System.Drawing.Point(8, 160)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(264, 64)
        Me.groupBox2.TabIndex = 11
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Subsampling"
        '
        'radioSubSample8
        '
        Me.radioSubSample8.Location = New System.Drawing.Point(184, 32)
        Me.radioSubSample8.Name = "radioSubSample8"
        Me.radioSubSample8.Size = New System.Drawing.Size(48, 16)
        Me.radioSubSample8.TabIndex = 3
        Me.radioSubSample8.Text = "1/8"
        '
        'radioSubSample4
        '
        Me.radioSubSample4.Location = New System.Drawing.Point(128, 32)
        Me.radioSubSample4.Name = "radioSubSample4"
        Me.radioSubSample4.Size = New System.Drawing.Size(48, 16)
        Me.radioSubSample4.TabIndex = 2
        Me.radioSubSample4.Text = "1/4"
        '
        'radioSubSample2
        '
        Me.radioSubSample2.Location = New System.Drawing.Point(72, 32)
        Me.radioSubSample2.Name = "radioSubSample2"
        Me.radioSubSample2.Size = New System.Drawing.Size(48, 16)
        Me.radioSubSample2.TabIndex = 1
        Me.radioSubSample2.Text = "1/2"
        '
        'radioSubSample1
        '
        Me.radioSubSample1.Location = New System.Drawing.Point(16, 32)
        Me.radioSubSample1.Name = "radioSubSample1"
        Me.radioSubSample1.Size = New System.Drawing.Size(48, 16)
        Me.radioSubSample1.TabIndex = 0
        Me.radioSubSample1.Text = "1/1"
        '
        'checkCode
        '
        Me.checkCode.Location = New System.Drawing.Point(304, 240)
        Me.checkCode.Name = "checkCode"
        Me.checkCode.Size = New System.Drawing.Size(120, 16)
        Me.checkCode.TabIndex = 17
        Me.checkCode.Text = "Write sub-code"
        '
        'button2
        '
        Me.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.button2.Location = New System.Drawing.Point(376, 408)
        Me.button2.Name = "button2"
        Me.button2.TabIndex = 19
        Me.button2.Text = "Cancel"
        '
        'groupBox6
        '
        Me.groupBox6.Controls.Add(Me.radioColor64)
        Me.groupBox6.Controls.Add(Me.radioColor48)
        Me.groupBox6.Controls.Add(Me.radioColor32)
        Me.groupBox6.Controls.Add(Me.radioColor24)
        Me.groupBox6.Controls.Add(Me.radioColor16)
        Me.groupBox6.Controls.Add(Me.radioColor08)
        Me.groupBox6.Location = New System.Drawing.Point(288, 8)
        Me.groupBox6.Name = "groupBox6"
        Me.groupBox6.Size = New System.Drawing.Size(160, 80)
        Me.groupBox6.TabIndex = 13
        Me.groupBox6.TabStop = False
        Me.groupBox6.Text = "Color mode"
        '
        'radioColor64
        '
        Me.radioColor64.Location = New System.Drawing.Point(112, 48)
        Me.radioColor64.Name = "radioColor64"
        Me.radioColor64.Size = New System.Drawing.Size(40, 16)
        Me.radioColor64.TabIndex = 5
        Me.radioColor64.Text = "64"
        '
        'radioColor48
        '
        Me.radioColor48.Location = New System.Drawing.Point(64, 48)
        Me.radioColor48.Name = "radioColor48"
        Me.radioColor48.Size = New System.Drawing.Size(40, 16)
        Me.radioColor48.TabIndex = 4
        Me.radioColor48.Text = "48"
        '
        'radioColor32
        '
        Me.radioColor32.Location = New System.Drawing.Point(112, 24)
        Me.radioColor32.Name = "radioColor32"
        Me.radioColor32.Size = New System.Drawing.Size(40, 16)
        Me.radioColor32.TabIndex = 3
        Me.radioColor32.Text = "32"
        '
        'radioColor24
        '
        Me.radioColor24.Location = New System.Drawing.Point(64, 24)
        Me.radioColor24.Name = "radioColor24"
        Me.radioColor24.Size = New System.Drawing.Size(40, 16)
        Me.radioColor24.TabIndex = 2
        Me.radioColor24.Text = "24"
        '
        'radioColor16
        '
        Me.radioColor16.Location = New System.Drawing.Point(16, 48)
        Me.radioColor16.Name = "radioColor16"
        Me.radioColor16.Size = New System.Drawing.Size(40, 16)
        Me.radioColor16.TabIndex = 1
        Me.radioColor16.Text = "16"
        '
        'radioColor08
        '
        Me.radioColor08.Location = New System.Drawing.Point(16, 24)
        Me.radioColor08.Name = "radioColor08"
        Me.radioColor08.Size = New System.Drawing.Size(24, 16)
        Me.radioColor08.TabIndex = 0
        Me.radioColor08.Text = "8"
        '
        'checkBinning
        '
        Me.checkBinning.Location = New System.Drawing.Point(16, 216)
        Me.checkBinning.Name = "checkBinning"
        Me.checkBinning.Size = New System.Drawing.Size(200, 16)
        Me.checkBinning.TabIndex = 20
        Me.checkBinning.Text = "Binning"
        '
        'Form2
        '
        Me.AcceptButton = Me.button1
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.CancelButton = Me.button2
        Me.ClientSize = New System.Drawing.Size(462, 445)
        Me.Controls.Add(Me.checkBinning)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.groupBox7)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.textFps)
        Me.Controls.Add(Me.labelFps)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.checkCode)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.groupBox6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Size settings"
        Me.groupBox7.ResumeLayout(False)
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Change operation for each DLL
        ' For each DLL function, please refer to manual.
		m_DllType = (m_ArtCam.GetDllVersion() >> 16)
        If (m_DllType = ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_SATA) Then
            m_CameraType = m_ArtCam.GetCameraType(pError)
        End If

        ' Set size for camera
        InitCameraSize()

        ' Set color mode
        InitColorMode()

        ' Set information for sub-sampling.
        InitSubSample()

        ' Initialize CNV.
        InitCNV()

        ' Obtain sub-code
        InitSubCode()


        ' Frame rate for Directshow
        If (ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS = m_DllType) Then
            textFps.Text = Convert.ToString(m_ArtCam.Fps())
            ' For all others, this is the waiting period between frames
        Else
            labelFps.Text = "Waiting time  (ms)"
            textFps.Text = Convert.ToString(m_ArtCam.GetWaitTime())
        End If

    End Sub

    ' Set size for camera
    Private Sub InitCameraSize()
        Dim lHT As Integer
        Dim lHS As Integer
        Dim lHE As Integer
        Dim lVT As Integer
        Dim lVS As Integer
        Dim lVE As Integer

        ' Cameras that do not allow size settings
        Select Case m_DllType
            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS
                textHT.Enabled = False
                textHS.Enabled = False
                textVT.Enabled = False
                textVS.Enabled = False

                textHT.Text = Convert.ToString(m_ArtCam.Width())
                textHE.Text = Convert.ToString(m_ArtCam.Width())
                textHS.Text = "0"
                textVT.Text = Convert.ToString(m_ArtCam.Height())
                textVE.Text = Convert.ToString(m_ArtCam.Height())
                textVS.Text = "0"

            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_098, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_500P, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P2
                textHT.Enabled = False
                textHE.Enabled = False
                textHS.Enabled = False
                textVT.Enabled = False
                textVE.Enabled = False
                textVS.Enabled = False

                textHT.Text = Convert.ToString(m_ArtCam.Width())
                textHE.Text = Convert.ToString(m_ArtCam.Width())
                textHS.Text = "0"
                textVT.Text = Convert.ToString(m_ArtCam.Height())
                textVE.Text = Convert.ToString(m_ArtCam.Height())
                textVS.Text = "0"

            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_130MI, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_200MI, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_300MI, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_320P, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_200SH
                textVT.Enabled = False
                textHT.Enabled = False

                m_ArtCam.GetCaptureWindowEx(lHT, lHS, lHE, lVT, lVS, lVE)

                textHT.Text = Convert.ToString(lHT)
                textHE.Text = Convert.ToString(lHE)
                textHS.Text = Convert.ToString(lHS)
                textVT.Text = Convert.ToString(lVT)
                textVE.Text = Convert.ToString(lVE)
                textVS.Text = Convert.ToString(lVS)

            Case Else
                m_ArtCam.GetCaptureWindowEx(lHT, lHS, lHE, lVT, lVS, lVE)

                textHT.Text = Convert.ToString(lHT)
                textHE.Text = Convert.ToString(lHE)
                textHS.Text = Convert.ToString(lHS)
                textVT.Text = Convert.ToString(lVT)
                textVE.Text = Convert.ToString(lVE)
                textVS.Text = Convert.ToString(lVS)

        End Select

    End Sub

    ' Set color mode
    Private Sub InitColorMode()
        ' Color number
        Select Case m_ArtCam.GetColorMode()
            Case 8
                radioColor08.Checked = True
            Case 16
                radioColor16.Checked = True
            Case 24
                radioColor24.Checked = True
            Case 32
                radioColor32.Checked = True
            Case 48
                radioColor48.Checked = True
            Case 64
                radioColor64.Checked = True
        End Select

        Select Case m_DllType
            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS
                radioColor08.Enabled = False
                radioColor16.Enabled = False
                radioColor32.Enabled = False
                radioColor48.Enabled = False
                radioColor64.Enabled = False

            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV
                radioColor32.Enabled = False
                radioColor48.Enabled = False
                radioColor64.Enabled = False

            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_320P, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_200SH
                radioColor16.Enabled = False
                radioColor32.Enabled = False
                radioColor48.Enabled = False
                radioColor64.Enabled = False
        End Select
    End Sub

    ' Set information for sub-sampling.
    Private Sub InitSubSample()
        ' Sub-sampling
        Dim bBinning As Boolean = ((m_ArtCam.GetSubSample() And &H10) = &H10)
        Dim iSubSample As Integer = m_ArtCam.GetSubSample() And 3
        Select Case CType(iSubSample, SUBSAMPLE)
            Case SUBSAMPLE.SUBSAMPLE_1
                radioSubSample1.Checked = True
            Case SUBSAMPLE.SUBSAMPLE_2
                radioSubSample2.Checked = True
            Case SUBSAMPLE.SUBSAMPLE_4
                radioSubSample4.Checked = True
            Case SUBSAMPLE.SUBSAMPLE_8
                radioSubSample8.Checked = True
        End Select

        checkBinning.Checked = bBinning
    End Sub

    ' Initialize CNV.
    Private Sub InitCNV()
        ' For CNV only
        If (ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV = m_DllType) Then
            Select Case m_ArtCam.GetVideoFormat()
                Case VIDEOFORMAT.VIDEOFORMAT_NTSC
                    labelVideo.Text = "VideoFormat : NTSC"
                Case VIDEOFORMAT.VIDEOFORMAT_PAL
                    labelVideo.Text = "VideoFormat : PAL"
                Case VIDEOFORMAT.VIDEOFORMAT_PALM
                    labelVideo.Text = "VideoFormat : PALM"
                Case VIDEOFORMAT.VIDEOFORMAT_SECAM
                    labelVideo.Text = "VideoFormat : SECAM"
            End Select

            Select Case m_ArtCam.GetSamplingRate()
                Case SAMPLING_RATE.WIDE_HISPEED
                    radioWH.Checked = True
                Case SAMPLING_RATE.WIDE_LOWSPEED
                    radioWL.Checked = True
                Case SAMPLING_RATE.NORMAL_HISPEED
                    radioNH.Checked = True
                Case SAMPLING_RATE.NORMAL_LOWSPEED
                    radioNL.Checked = True
            End Select
        Else
            radioWH.Enabled = False
            radioWL.Enabled = False
            radioNH.Enabled = False
            radioNL.Enabled = False

            radioChannel1.Enabled = False
            radioChannel2.Enabled = False
            radioChannel3.Enabled = False
            radioChannel4.Enabled = False
            radioChannel5.Enabled = False
            radioChannel6.Enabled = False
        End If
    End Sub

    ' Obtain sub-code
    Private Sub InitSubCode()
        textCode1.Text = Convert.ToString(m_ArtCam.ReadSromID(0))

        If 0 = m_ArtCam.m_Error Then
            textCode1.Enabled = False
            textCode2.Enabled = False
            textCode3.Enabled = False
            textCode4.Enabled = False
            textCode5.Enabled = False
            textCode6.Enabled = False
            textCode7.Enabled = False
            textCode8.Enabled = False

            checkCode.Enabled = False
            Return
        End If

        textCode2.Text = Convert.ToString(m_ArtCam.ReadSromID(1))
        textCode3.Text = Convert.ToString(m_ArtCam.ReadSromID(2))
        textCode4.Text = Convert.ToString(m_ArtCam.ReadSromID(3))
        textCode5.Text = Convert.ToString(m_ArtCam.ReadSromID(4))
        textCode6.Text = Convert.ToString(m_ArtCam.ReadSromID(5))
        textCode7.Text = Convert.ToString(m_ArtCam.ReadSromID(6))
        textCode8.Text = Convert.ToString(m_ArtCam.ReadSromID(7))
    End Sub

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        ' Check size before reflecting
        Dim lHT As Integer = Convert.ToInt32(textHT.Text)
        Dim lHE As Integer = Convert.ToInt32(textHE.Text)
        Dim lHS As Integer = Convert.ToInt32(textHS.Text)
        Dim lVT As Integer = Convert.ToInt32(textVT.Text)
        Dim lVE As Integer = Convert.ToInt32(textVE.Text)
        Dim lVS As Integer = Convert.ToInt32(textVS.Text)
        Dim lFps As Integer = Convert.ToInt32(textFps.Text)


        ' Size and FPS
        Select Case m_DllType
            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS
                m_ArtCam.SetCaptureWindow(lHE, lVE, lFps)

            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV
                If radioWH.Checked Then m_ArtCam.SetSamplingRate(SAMPLING_RATE.WIDE_HISPEED)
                If radioWL.Checked Then m_ArtCam.SetSamplingRate(SAMPLING_RATE.WIDE_LOWSPEED)
                If radioNH.Checked Then m_ArtCam.SetSamplingRate(SAMPLING_RATE.NORMAL_HISPEED)
                If radioNL.Checked Then m_ArtCam.SetSamplingRate(SAMPLING_RATE.NORMAL_LOWSPEED)

                If radioChannel1.Checked Then m_ArtCam.SetCrossbar(0, 0)
                If radioChannel2.Checked Then m_ArtCam.SetCrossbar(1, 0)
                If radioChannel3.Checked Then m_ArtCam.SetCrossbar(2, 0)
                If radioChannel4.Checked Then m_ArtCam.SetCrossbar(3, 0)
                If radioChannel5.Checked Then m_ArtCam.SetCrossbar(4, 0)
                If radioChannel6.Checked Then m_ArtCam.SetCrossbar(5, 0)

            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_098
            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_500P
            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P2

            Case Else
                m_ArtCam.SetCaptureWindowEx(lHT, lHS, lHE, lVT, lVS, lVE)
                m_ArtCam.SetWaitTime(lFps)
        End Select

        ' Invalid values cannot be set at dialog
        ' It reflects without modification
        ' There is no problem since inactive camera returns error as well
        If checkBinning.Checked Then
            If radioSubSample1.Checked Then m_ArtCam.SetSubSample(SUBSAMPLE.SUBSAMPLE_1)
            If radioSubSample2.Checked Then m_ArtCam.SetSubSample(SUBSAMPLE.BINNING_2)
            If radioSubSample4.Checked Then m_ArtCam.SetSubSample(SUBSAMPLE.BINNING_4)
            If radioSubSample8.Checked Then m_ArtCam.SetSubSample(SUBSAMPLE.SUBSAMPLE_8)
        Else
        If radioSubSample1.Checked Then m_ArtCam.SetSubSample(SUBSAMPLE.SUBSAMPLE_1)
        If radioSubSample2.Checked Then m_ArtCam.SetSubSample(SUBSAMPLE.SUBSAMPLE_2)
        If radioSubSample4.Checked Then m_ArtCam.SetSubSample(SUBSAMPLE.SUBSAMPLE_4)
        If radioSubSample8.Checked Then m_ArtCam.SetSubSample(SUBSAMPLE.SUBSAMPLE_8)
        End If

        If radioColor08.Checked Then m_ArtCam.SetColorMode(8)
        If radioColor16.Checked Then m_ArtCam.SetColorMode(16)
        If radioColor24.Checked Then m_ArtCam.SetColorMode(24)
        If radioColor32.Checked Then m_ArtCam.SetColorMode(32)
        If radioColor48.Checked Then m_ArtCam.SetColorMode(48)
        If radioColor64.Checked Then m_ArtCam.SetColorMode(64)


        ' Write sub-code
        ' Make sure writing is correct
        If checkCode.Checked Then
            Dim m_Code(8) As Byte
            m_Code(0) = Convert.ToByte(textCode1.Text)
            m_Code(1) = Convert.ToByte(textCode2.Text)
            m_Code(2) = Convert.ToByte(textCode3.Text)
            m_Code(3) = Convert.ToByte(textCode4.Text)
            m_Code(4) = Convert.ToByte(textCode5.Text)
            m_Code(5) = Convert.ToByte(textCode6.Text)
            m_Code(6) = Convert.ToByte(textCode7.Text)
            m_Code(7) = Convert.ToByte(textCode8.Text)

            m_ArtCam.WriteSromID(0, m_Code(0))
            m_ArtCam.WriteSromID(1, m_Code(1))
            m_ArtCam.WriteSromID(2, m_Code(2))
            m_ArtCam.WriteSromID(3, m_Code(3))
            m_ArtCam.WriteSromID(4, m_Code(4))
            m_ArtCam.WriteSromID(5, m_Code(5))
            m_ArtCam.WriteSromID(6, m_Code(6))
            m_ArtCam.WriteSromID(7, m_Code(7))
        End If

    End Sub

End Class

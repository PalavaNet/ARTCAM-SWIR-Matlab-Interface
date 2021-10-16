Imports Sample_VB.ArtCamSdk

Public Class Form3
    Inherits System.Windows.Forms.Form

    Dim pError As Integer   
    Dim m_DllType As ARTCAM_CAMERATYPE = 0
    Dim m_CameraType As ARTCAM_CAMERATYPE_SATA = 0
    Dim m_ArtCam As CArtCam = Nothing
    Dim m_Preview As Integer = -1
	Dim m_CameraInfo As CAMERAINFO

#Region " Code made by Windows form designer "

    Public Sub New(ByVal a As CArtCam, ByVal p As Integer)
        MyBase.New()

        ' This call 
        InitializeComponent()

        ' InitializeComponent() Add initialization after call 
        m_ArtCam = a
        m_Preview = p
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
    Friend WithEvents groupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents radioChannel6 As System.Windows.Forms.RadioButton
    Friend WithEvents radioChannel5 As System.Windows.Forms.RadioButton
    Friend WithEvents radioChannel4 As System.Windows.Forms.RadioButton
    Friend WithEvents radioChannel3 As System.Windows.Forms.RadioButton
    Friend WithEvents radioChannel2 As System.Windows.Forms.RadioButton
    Friend WithEvents radioChannel1 As System.Windows.Forms.RadioButton
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents UpDownGamma As System.Windows.Forms.NumericUpDown
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents UpDownSharpness As System.Windows.Forms.NumericUpDown
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents UpDownSaturation As System.Windows.Forms.NumericUpDown
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents UpDownHue As System.Windows.Forms.NumericUpDown
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents UpDownContrast As System.Windows.Forms.NumericUpDown
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents UpDownBrightness As System.Windows.Forms.NumericUpDown
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents checkHalfClock As System.Windows.Forms.CheckBox
    Friend WithEvents button1 As System.Windows.Forms.Button
    Friend WithEvents groupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents checkMirrorH As System.Windows.Forms.CheckBox
    Friend WithEvents checkMirrorV As System.Windows.Forms.CheckBox
    Friend WithEvents groupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents radioAI3 As System.Windows.Forms.RadioButton
    Friend WithEvents radioAI2 As System.Windows.Forms.RadioButton
    Friend WithEvents radioAI1 As System.Windows.Forms.RadioButton
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents UpDownBayerGainB As System.Windows.Forms.NumericUpDown
    Friend WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents UpDownBayerGainG As System.Windows.Forms.NumericUpDown
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents UpDownBayerGainR As System.Windows.Forms.NumericUpDown
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents radioBayer4 As System.Windows.Forms.RadioButton
    Friend WithEvents radioBayer3 As System.Windows.Forms.RadioButton
    Friend WithEvents radioBayer2 As System.Windows.Forms.RadioButton
    Friend WithEvents radioBayer1 As System.Windows.Forms.RadioButton
    Friend WithEvents checkAWB As System.Windows.Forms.CheckBox
    Friend WithEvents groupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents UpDownExposureTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents UpDownColorGainB As System.Windows.Forms.NumericUpDown
    Friend WithEvents label11 As System.Windows.Forms.Label
    Friend WithEvents UpDownColorGainG2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents label12 As System.Windows.Forms.Label
    Friend WithEvents UpDownColorGainG1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents label13 As System.Windows.Forms.Label
    Friend WithEvents UpDownColorGainR As System.Windows.Forms.NumericUpDown
    Friend WithEvents label14 As System.Windows.Forms.Label
    Friend WithEvents UpDownGlobalGain As System.Windows.Forms.NumericUpDown
    Friend WithEvents label15 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.groupBox8 = New System.Windows.Forms.GroupBox()
        Me.radioChannel6 = New System.Windows.Forms.RadioButton()
        Me.radioChannel5 = New System.Windows.Forms.RadioButton()
        Me.radioChannel4 = New System.Windows.Forms.RadioButton()
        Me.radioChannel3 = New System.Windows.Forms.RadioButton()
        Me.radioChannel2 = New System.Windows.Forms.RadioButton()
        Me.radioChannel1 = New System.Windows.Forms.RadioButton()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.UpDownGamma = New System.Windows.Forms.NumericUpDown()
        Me.label6 = New System.Windows.Forms.Label()
        Me.UpDownSharpness = New System.Windows.Forms.NumericUpDown()
        Me.label5 = New System.Windows.Forms.Label()
        Me.UpDownSaturation = New System.Windows.Forms.NumericUpDown()
        Me.label4 = New System.Windows.Forms.Label()
        Me.UpDownHue = New System.Windows.Forms.NumericUpDown()
        Me.label3 = New System.Windows.Forms.Label()
        Me.UpDownContrast = New System.Windows.Forms.NumericUpDown()
        Me.label2 = New System.Windows.Forms.Label()
        Me.UpDownBrightness = New System.Windows.Forms.NumericUpDown()
        Me.label1 = New System.Windows.Forms.Label()
        Me.checkHalfClock = New System.Windows.Forms.CheckBox()
        Me.button1 = New System.Windows.Forms.Button()
        Me.groupBox7 = New System.Windows.Forms.GroupBox()
        Me.checkMirrorH = New System.Windows.Forms.CheckBox()
        Me.checkMirrorV = New System.Windows.Forms.CheckBox()
        Me.groupBox6 = New System.Windows.Forms.GroupBox()
        Me.radioAI3 = New System.Windows.Forms.RadioButton()
        Me.radioAI2 = New System.Windows.Forms.RadioButton()
        Me.radioAI1 = New System.Windows.Forms.RadioButton()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.groupBox4 = New System.Windows.Forms.GroupBox()
        Me.UpDownBayerGainB = New System.Windows.Forms.NumericUpDown()
        Me.label9 = New System.Windows.Forms.Label()
        Me.UpDownBayerGainG = New System.Windows.Forms.NumericUpDown()
        Me.label8 = New System.Windows.Forms.Label()
        Me.UpDownBayerGainR = New System.Windows.Forms.NumericUpDown()
        Me.label7 = New System.Windows.Forms.Label()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.radioBayer4 = New System.Windows.Forms.RadioButton()
        Me.radioBayer3 = New System.Windows.Forms.RadioButton()
        Me.radioBayer2 = New System.Windows.Forms.RadioButton()
        Me.radioBayer1 = New System.Windows.Forms.RadioButton()
        Me.checkAWB = New System.Windows.Forms.CheckBox()
        Me.groupBox5 = New System.Windows.Forms.GroupBox()
        Me.UpDownExposureTime = New System.Windows.Forms.NumericUpDown()
        Me.label10 = New System.Windows.Forms.Label()
        Me.UpDownColorGainB = New System.Windows.Forms.NumericUpDown()
        Me.label11 = New System.Windows.Forms.Label()
        Me.UpDownColorGainG2 = New System.Windows.Forms.NumericUpDown()
        Me.label12 = New System.Windows.Forms.Label()
        Me.UpDownColorGainG1 = New System.Windows.Forms.NumericUpDown()
        Me.label13 = New System.Windows.Forms.Label()
        Me.UpDownColorGainR = New System.Windows.Forms.NumericUpDown()
        Me.label14 = New System.Windows.Forms.Label()
        Me.UpDownGlobalGain = New System.Windows.Forms.NumericUpDown()
        Me.label15 = New System.Windows.Forms.Label()
        Me.groupBox8.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.UpDownGamma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDownSharpness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDownSaturation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDownHue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDownContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDownBrightness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox7.SuspendLayout()
        Me.groupBox6.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        CType(Me.UpDownBayerGainB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDownBayerGainG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDownBayerGainR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox3.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        CType(Me.UpDownExposureTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDownColorGainB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDownColorGainG2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDownColorGainG1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDownColorGainR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDownGlobalGain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupBox8
        '
        Me.groupBox8.Controls.AddRange(New System.Windows.Forms.Control() {Me.radioChannel6, Me.radioChannel5, Me.radioChannel4, Me.radioChannel3, Me.radioChannel2, Me.radioChannel1})
        Me.groupBox8.Location = New System.Drawing.Point(367, 246)
        Me.groupBox8.Name = "groupBox8"
        Me.groupBox8.Size = New System.Drawing.Size(152, 96)
        Me.groupBox8.TabIndex = 22
        Me.groupBox8.TabStop = False
        Me.groupBox8.Text = "Display channel(CNV)"
        '
        'radioChannel6
        '
        Me.radioChannel6.Location = New System.Drawing.Point(96, 56)
        Me.radioChannel6.Name = "radioChannel6"
        Me.radioChannel6.Size = New System.Drawing.Size(24, 16)
        Me.radioChannel6.TabIndex = 5
        Me.radioChannel6.Text = "6"
        '
        'radioChannel5
        '
        Me.radioChannel5.Location = New System.Drawing.Point(56, 56)
        Me.radioChannel5.Name = "radioChannel5"
        Me.radioChannel5.Size = New System.Drawing.Size(24, 16)
        Me.radioChannel5.TabIndex = 4
        Me.radioChannel5.Text = "5"
        '
        'radioChannel4
        '
        Me.radioChannel4.Location = New System.Drawing.Point(16, 56)
        Me.radioChannel4.Name = "radioChannel4"
        Me.radioChannel4.Size = New System.Drawing.Size(24, 16)
        Me.radioChannel4.TabIndex = 3
        Me.radioChannel4.Text = "4"
        '
        'radioChannel3
        '
        Me.radioChannel3.Location = New System.Drawing.Point(96, 24)
        Me.radioChannel3.Name = "radioChannel3"
        Me.radioChannel3.Size = New System.Drawing.Size(24, 16)
        Me.radioChannel3.TabIndex = 2
        Me.radioChannel3.Text = "3"
        '
        'radioChannel2
        '
        Me.radioChannel2.Location = New System.Drawing.Point(56, 24)
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
        'groupBox1
        '
        Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.UpDownGamma, Me.label6, Me.UpDownSharpness, Me.label5, Me.UpDownSaturation, Me.label4, Me.UpDownHue, Me.label3, Me.UpDownContrast, Me.label2, Me.UpDownBrightness, Me.label1})
        Me.groupBox1.Location = New System.Drawing.Point(7, 6)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(200, 216)
        Me.groupBox1.TabIndex = 16
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Picture filter"
        '
        'UpDownGamma
        '
        Me.UpDownGamma.Location = New System.Drawing.Point(112, 184)
        Me.UpDownGamma.Name = "UpDownGamma"
        Me.UpDownGamma.Size = New System.Drawing.Size(64, 19)
        Me.UpDownGamma.TabIndex = 11
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(24, 184)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(48, 16)
        Me.label6.TabIndex = 10
        Me.label6.Text = "Gumma"
        '
        'UpDownSharpness
        '
        Me.UpDownSharpness.Location = New System.Drawing.Point(112, 152)
        Me.UpDownSharpness.Name = "UpDownSharpness"
        Me.UpDownSharpness.Size = New System.Drawing.Size(64, 19)
        Me.UpDownSharpness.TabIndex = 9
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(24, 152)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(64, 16)
        Me.label5.TabIndex = 8
        Me.label5.Text = "Sharpness"
        '
        'UpDownSaturation
        '
        Me.UpDownSaturation.Location = New System.Drawing.Point(112, 120)
        Me.UpDownSaturation.Name = "UpDownSaturation"
        Me.UpDownSaturation.Size = New System.Drawing.Size(64, 19)
        Me.UpDownSaturation.TabIndex = 7
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(24, 120)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(64, 16)
        Me.label4.TabIndex = 6
        Me.label4.Text = "Saturation"
        '
        'UpDownHue
        '
        Me.UpDownHue.Location = New System.Drawing.Point(112, 88)
        Me.UpDownHue.Name = "UpDownHue"
        Me.UpDownHue.Size = New System.Drawing.Size(64, 19)
        Me.UpDownHue.TabIndex = 5
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(24, 88)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(32, 16)
        Me.label3.TabIndex = 4
        Me.label3.Text = "Hue"
        '
        'UpDownContrast
        '
        Me.UpDownContrast.Location = New System.Drawing.Point(112, 56)
        Me.UpDownContrast.Name = "UpDownContrast"
        Me.UpDownContrast.Size = New System.Drawing.Size(64, 19)
        Me.UpDownContrast.TabIndex = 3
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(24, 56)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(56, 16)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Contrast"
        '
        'UpDownBrightness
        '
        Me.UpDownBrightness.Location = New System.Drawing.Point(112, 24)
        Me.UpDownBrightness.Name = "UpDownBrightness"
        Me.UpDownBrightness.Size = New System.Drawing.Size(64, 19)
        Me.UpDownBrightness.TabIndex = 1
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(24, 24)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(64, 16)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Brightness"
        '
        'checkHalfClock
        '
        Me.checkHalfClock.Location = New System.Drawing.Point(247, 430)
        Me.checkHalfClock.Name = "checkHalfClock"
        Me.checkHalfClock.Size = New System.Drawing.Size(88, 16)
        Me.checkHalfClock.TabIndex = 21
        Me.checkHalfClock.Text = "Half clock"
        '
        'button1
        '
        Me.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.button1.Location = New System.Drawing.Point(447, 486)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 23
        Me.button1.Text = "Close"
        '
        'groupBox7
        '
        Me.groupBox7.Controls.AddRange(New System.Windows.Forms.Control() {Me.checkMirrorH, Me.checkMirrorV})
        Me.groupBox7.Location = New System.Drawing.Point(231, 358)
        Me.groupBox7.Name = "groupBox7"
        Me.groupBox7.Size = New System.Drawing.Size(209, 56)
        Me.groupBox7.TabIndex = 20
        Me.groupBox7.TabStop = False
        Me.groupBox7.Text = "Mirror reversal"
        '
        'checkMirrorH
        '
        Me.checkMirrorH.Location = New System.Drawing.Point(112, 24)
        Me.checkMirrorH.Name = "checkMirrorH"
        Me.checkMirrorH.Size = New System.Drawing.Size(64, 16)
        Me.checkMirrorH.TabIndex = 1
        Me.checkMirrorH.Text = "Horizon"
        '
        'checkMirrorV
        '
        Me.checkMirrorV.Location = New System.Drawing.Point(16, 24)
        Me.checkMirrorV.Name = "checkMirrorV"
        Me.checkMirrorV.Size = New System.Drawing.Size(64, 16)
        Me.checkMirrorV.TabIndex = 0
        Me.checkMirrorV.Text = "Vertical"
        '
        'groupBox6
        '
        Me.groupBox6.Controls.AddRange(New System.Windows.Forms.Control() {Me.radioAI3, Me.radioAI2, Me.radioAI1})
        Me.groupBox6.Location = New System.Drawing.Point(231, 246)
        Me.groupBox6.Name = "groupBox6"
        Me.groupBox6.Size = New System.Drawing.Size(120, 96)
        Me.groupBox6.TabIndex = 19
        Me.groupBox6.TabStop = False
        Me.groupBox6.Text = "Auto iris"
        '
        'radioAI3
        '
        Me.radioAI3.Location = New System.Drawing.Point(16, 72)
        Me.radioAI3.Name = "radioAI3"
        Me.radioAI3.Size = New System.Drawing.Size(56, 16)
        Me.radioAI3.TabIndex = 2
        Me.radioAI3.Text = "Gain"
        '
        'radioAI2
        '
        Me.radioAI2.Location = New System.Drawing.Point(16, 48)
        Me.radioAI2.Name = "radioAI2"
        Me.radioAI2.Size = New System.Drawing.Size(72, 16)
        Me.radioAI2.TabIndex = 1
        Me.radioAI2.Text = "Shutter"
        '
        'radioAI1
        '
        Me.radioAI1.Location = New System.Drawing.Point(16, 24)
        Me.radioAI1.Name = "radioAI1"
        Me.radioAI1.Size = New System.Drawing.Size(56, 16)
        Me.radioAI1.TabIndex = 0
        Me.radioAI1.Text = "Invalid"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.groupBox4, Me.groupBox3, Me.checkAWB})
        Me.groupBox2.Location = New System.Drawing.Point(7, 246)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(200, 264)
        Me.groupBox2.TabIndex = 17
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Color conversion"
        '
        'groupBox4
        '
        Me.groupBox4.Controls.AddRange(New System.Windows.Forms.Control() {Me.UpDownBayerGainB, Me.label9, Me.UpDownBayerGainG, Me.label8, Me.UpDownBayerGainR, Me.label7})
        Me.groupBox4.Location = New System.Drawing.Point(24, 128)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(144, 120)
        Me.groupBox4.TabIndex = 2
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Bayer conversion gain"
        '
        'UpDownBayerGainB
        '
        Me.UpDownBayerGainB.Location = New System.Drawing.Point(64, 88)
        Me.UpDownBayerGainB.Name = "UpDownBayerGainB"
        Me.UpDownBayerGainB.Size = New System.Drawing.Size(64, 19)
        Me.UpDownBayerGainB.TabIndex = 17
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(16, 88)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(32, 16)
        Me.label9.TabIndex = 16
        Me.label9.Text = "Blue"
        '
        'UpDownBayerGainG
        '
        Me.UpDownBayerGainG.Location = New System.Drawing.Point(64, 56)
        Me.UpDownBayerGainG.Name = "UpDownBayerGainG"
        Me.UpDownBayerGainG.Size = New System.Drawing.Size(64, 19)
        Me.UpDownBayerGainG.TabIndex = 15
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(16, 56)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(40, 16)
        Me.label8.TabIndex = 14
        Me.label8.Text = "Green"
        '
        'UpDownBayerGainR
        '
        Me.UpDownBayerGainR.Location = New System.Drawing.Point(64, 24)
        Me.UpDownBayerGainR.Name = "UpDownBayerGainR"
        Me.UpDownBayerGainR.Size = New System.Drawing.Size(64, 19)
        Me.UpDownBayerGainR.TabIndex = 13
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(16, 24)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(32, 16)
        Me.label7.TabIndex = 12
        Me.label7.Text = "Red"
        '
        'groupBox3
        '
        Me.groupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.radioBayer4, Me.radioBayer3, Me.radioBayer2, Me.radioBayer1})
        Me.groupBox3.Location = New System.Drawing.Point(24, 56)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(144, 56)
        Me.groupBox3.TabIndex = 1
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Bayer conversion mode"
        '
        'radioBayer4
        '
        Me.radioBayer4.Location = New System.Drawing.Point(112, 24)
        Me.radioBayer4.Name = "radioBayer4"
        Me.radioBayer4.Size = New System.Drawing.Size(16, 16)
        Me.radioBayer4.TabIndex = 6
        '
        'radioBayer3
        '
        Me.radioBayer3.Location = New System.Drawing.Point(80, 24)
        Me.radioBayer3.Name = "radioBayer3"
        Me.radioBayer3.Size = New System.Drawing.Size(16, 16)
        Me.radioBayer3.TabIndex = 5
        '
        'radioBayer2
        '
        Me.radioBayer2.Location = New System.Drawing.Point(48, 24)
        Me.radioBayer2.Name = "radioBayer2"
        Me.radioBayer2.Size = New System.Drawing.Size(16, 16)
        Me.radioBayer2.TabIndex = 4
        '
        'radioBayer1
        '
        Me.radioBayer1.Location = New System.Drawing.Point(16, 24)
        Me.radioBayer1.Name = "radioBayer1"
        Me.radioBayer1.Size = New System.Drawing.Size(16, 16)
        Me.radioBayer1.TabIndex = 3
        '
        'checkAWB
        '
        Me.checkAWB.Location = New System.Drawing.Point(24, 24)
        Me.checkAWB.Name = "checkAWB"
        Me.checkAWB.Size = New System.Drawing.Size(128, 16)
        Me.checkAWB.TabIndex = 0
        Me.checkAWB.Text = "Auto white balance"
        '
        'groupBox5
        '
        Me.groupBox5.Controls.AddRange(New System.Windows.Forms.Control() {Me.UpDownExposureTime, Me.label10, Me.UpDownColorGainB, Me.label11, Me.UpDownColorGainG2, Me.label12, Me.UpDownColorGainG1, Me.label13, Me.UpDownColorGainR, Me.label14, Me.UpDownGlobalGain, Me.label15})
        Me.groupBox5.Location = New System.Drawing.Point(231, 6)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(288, 216)
        Me.groupBox5.TabIndex = 18
        Me.groupBox5.TabStop = False
        Me.groupBox5.Text = "Camera settings"
        '
        'UpDownExposureTime
        '
        Me.UpDownExposureTime.Location = New System.Drawing.Point(192, 176)
        Me.UpDownExposureTime.Name = "UpDownExposureTime"
        Me.UpDownExposureTime.Size = New System.Drawing.Size(64, 19)
        Me.UpDownExposureTime.TabIndex = 23
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(24, 179)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(160, 16)
        Me.label10.TabIndex = 22
        Me.label10.Text = "Exposure time(Shutter speed)"
        '
        'UpDownColorGainB
        '
        Me.UpDownColorGainB.Location = New System.Drawing.Point(192, 144)
        Me.UpDownColorGainB.Name = "UpDownColorGainB"
        Me.UpDownColorGainB.Size = New System.Drawing.Size(64, 19)
        Me.UpDownColorGainB.TabIndex = 21
        '
        'label11
        '
        Me.label11.Location = New System.Drawing.Point(24, 147)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(104, 16)
        Me.label11.TabIndex = 20
        Me.label11.Text = "Color gain(Blue)"
        '
        'UpDownColorGainG2
        '
        Me.UpDownColorGainG2.Location = New System.Drawing.Point(192, 112)
        Me.UpDownColorGainG2.Name = "UpDownColorGainG2"
        Me.UpDownColorGainG2.Size = New System.Drawing.Size(64, 19)
        Me.UpDownColorGainG2.TabIndex = 19
        '
        'label12
        '
        Me.label12.Location = New System.Drawing.Point(24, 115)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(112, 16)
        Me.label12.TabIndex = 18
        Me.label12.Text = "Color gain(Green 2)"
        '
        'UpDownColorGainG1
        '
        Me.UpDownColorGainG1.Location = New System.Drawing.Point(192, 80)
        Me.UpDownColorGainG1.Name = "UpDownColorGainG1"
        Me.UpDownColorGainG1.Size = New System.Drawing.Size(64, 19)
        Me.UpDownColorGainG1.TabIndex = 17
        '
        'label13
        '
        Me.label13.Location = New System.Drawing.Point(24, 83)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(120, 16)
        Me.label13.TabIndex = 16
        Me.label13.Text = "Color gain(green 1)"
        '
        'UpDownColorGainR
        '
        Me.UpDownColorGainR.Location = New System.Drawing.Point(192, 48)
        Me.UpDownColorGainR.Name = "UpDownColorGainR"
        Me.UpDownColorGainR.Size = New System.Drawing.Size(64, 19)
        Me.UpDownColorGainR.TabIndex = 15
        '
        'label14
        '
        Me.label14.Location = New System.Drawing.Point(24, 51)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(96, 16)
        Me.label14.TabIndex = 14
        Me.label14.Text = "Color gain(Red)"
        '
        'UpDownGlobalGain
        '
        Me.UpDownGlobalGain.Location = New System.Drawing.Point(192, 16)
        Me.UpDownGlobalGain.Name = "UpDownGlobalGain"
        Me.UpDownGlobalGain.Size = New System.Drawing.Size(64, 19)
        Me.UpDownGlobalGain.TabIndex = 13
        '
        'label15
        '
        Me.label15.Location = New System.Drawing.Point(24, 19)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(72, 16)
        Me.label15.TabIndex = 12
        Me.label15.Text = "Global gain"
        '
        'Form3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(528, 517)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.groupBox8, Me.groupBox1, Me.checkHalfClock, Me.button1, Me.groupBox7, Me.groupBox6, Me.groupBox2, Me.groupBox5})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form3"
        Me.Text = "Filter settings"
        Me.groupBox8.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        CType(Me.UpDownGamma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDownSharpness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDownSaturation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDownHue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDownContrast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDownBrightness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox7.ResumeLayout(False)
        Me.groupBox6.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox4.ResumeLayout(False)
        CType(Me.UpDownBayerGainB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDownBayerGainG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDownBayerGainR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox5.ResumeLayout(False)
        CType(Me.UpDownExposureTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDownColorGainB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDownColorGainG2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDownColorGainG1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDownColorGainR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDownGlobalGain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Change operation for each DLL
        ' For each DLL function, please refer to manual.
		m_DllType = (m_ArtCam.GetDllVersion() >> 16)
        If (m_DllType = ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_SATA) Then
            m_CameraType = m_ArtCam.GetCameraType(pError)
        End If

        ' Preset value of each camera
		m_CameraInfo.lSize = System.Runtime.InteropServices.Marshal.SizeOf(m_CameraInfo)
		m_ArtCam.GetCameraInfo(m_CameraInfo)


        ' Range for value is set while determination of availability is done. 
        If ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV = m_DllType Then
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BRIGHTNESS, UpDownBrightness, 0, 255)
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_CONTRAST, UpDownContrast, 0, 255)
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_HUE, UpDownHue, 0, 255)
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_SATURATION, UpDownSaturation, 0, 255)
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_SHARPNESS, UpDownSharpness, 0, 0)
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_GAMMA, UpDownGamma, 0, 0)

            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYER_GAIN_R, UpDownBayerGainR, 0, 0)
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYER_GAIN_G, UpDownBayerGainG, 0, 0)
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYER_GAIN_B, UpDownBayerGainB, 0, 0)
        Else
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BRIGHTNESS, UpDownBrightness, -255, 255)
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_CONTRAST, UpDownContrast, -127, 127)
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_HUE, UpDownHue, -360, 360)
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_SATURATION, UpDownSaturation, -255, 255)
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_SHARPNESS, UpDownSharpness, 0, 30)
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_GAMMA, UpDownGamma, 0, 200)

            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYER_GAIN_R, UpDownBayerGainR, 0, 200)
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYER_GAIN_G, UpDownBayerGainG, 0, 200)
            InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYER_GAIN_B, UpDownBayerGainB, 0, 200)
        End If

		InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_GLOBAL_GAIN,	UpDownGlobalGain,	m_CameraInfo.lGlobalGainMin,m_CameraInfo.lGlobalGainMax	)
		InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_COLOR_GAIN_R,	UpDownColorGainR,	m_CameraInfo.lColorGainMin,	m_CameraInfo.lColorGainMax	)
		InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_COLOR_GAIN_G1,	UpDownColorGainG1,	m_CameraInfo.lColorGainMin,	m_CameraInfo.lColorGainMax	)
		InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_COLOR_GAIN_G2,	UpDownColorGainG2,	m_CameraInfo.lColorGainMin,	m_CameraInfo.lColorGainMax	)
		InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_COLOR_GAIN_B,	UpDownColorGainB,	m_CameraInfo.lColorGainMin,	m_CameraInfo.lColorGainMax	)
		InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_EXPOSURETIME,	UpDownExposureTime,	m_CameraInfo.lExposureMin,	m_CameraInfo.lExposureMax	)



        ' Auto white balance
        Dim Data As Integer = m_ArtCam.GetFilterValue(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYER_GAIN_AUTO)

        If 0 = m_ArtCam.m_Error Then
            checkAWB.Enabled = False
        End If

        If Not 0 = Data Then
            checkAWB.Checked = True
        End If


        ' Bayer conversion mode
        Data = m_ArtCam.GetFilterValue(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYERMODE)
        If 0 = m_ArtCam.m_Error Then
            radioBayer1.Enabled = False
            radioBayer2.Enabled = False
            radioBayer3.Enabled = False
            radioBayer4.Enabled = False
        End If

        Select Case Data
            Case 0
                radioBayer1.Checked = True
            Case 1
                radioBayer2.Checked = True
            Case 2
                radioBayer3.Checked = True
            Case 3
                radioBayer4.Checked = True
        End Select

        ' Mirror reversal
        If m_ArtCam.GetMirrorV() Then checkMirrorV.Checked = True
        If m_ArtCam.GetMirrorH() Then checkMirrorH.Checked = True

        ' Horizotal reversal is only available in 036MI.
        If Not ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_036MI = m_DllType Then
            checkMirrorH.Enabled = False
        End If

        ' Vertical reversal is not available in following models.
        Select Case m_DllType
            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_USTC, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P2, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_098
                checkMirrorV.Enabled = False
        End Select


        ' Auto iris
        Select Case m_ArtCam.GetAutoIris()
            Case AI_TYPE.AI_NONE
                radioAI1.Checked = True
            Case AI_TYPE.AI_EXPOSURE
                radioAI2.Checked = True
            Case AI_TYPE.AI_GAIN
                radioAI3.Checked = True
        End Select

        If 0 = m_ArtCam.m_Error Then
            radioAI1.Enabled = False
            radioAI2.Enabled = False
            radioAI3.Enabled = False
        End If

        ' Camera without shutter function
        Select Case m_DllType
            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_320P, ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_098
                radioAI2.Enabled = False
        End Select

        ' Half clock
        checkHalfClock.Checked = m_ArtCam.GetHalfClock()
        If 0 = m_ArtCam.m_Error Then
            checkHalfClock.Enabled = False
        End If

        ' Channel
        If Not ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV = m_DllType Then
            radioChannel1.Enabled = False
            radioChannel2.Enabled = False
            radioChannel3.Enabled = False
            radioChannel4.Enabled = False
            radioChannel5.Enabled = False
            radioChannel6.Enabled = False
        End If

    End Sub

    ' 
    Private Sub InitControl(ByVal FilterType As ARTCAM_FILTERTYPE, ByVal UpDown As NumericUpDown, ByVal Min As Integer, ByVal Max As Integer)
        Dim Data As Integer = m_ArtCam.GetFilterValue(FilterType)

        UpDown.Minimum = Min
        UpDown.Maximum = Max
        UpDown.Value = Data

        ' Error occurrence(no response)
        If 0 = m_ArtCam.m_Error Then
            UpDown.Enabled = False
            Return
        End If
    End Sub

    Private Sub checkAWB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetBayerGainAuto(checkAWB.Checked)
    End Sub

    Private Sub radioBayer1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetFilterValue(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYERMODE, 0)
    End Sub

    Private Sub radioBayer2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetFilterValue(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYERMODE, 1)
    End Sub

    Private Sub radioBayer3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetFilterValue(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYERMODE, 2)
    End Sub

    Private Sub radioBayer4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetFilterValue(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYERMODE, 3)
    End Sub

    Private Sub radioAI1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetAutoIris(AI_TYPE.AI_NONE)
    End Sub

    Private Sub radioAI2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetAutoIris(AI_TYPE.AI_EXPOSURE)
    End Sub

    Private Sub radioAI3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetAutoIris(AI_TYPE.AI_GAIN)
    End Sub

    Private Sub checkMirrorV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetMirrorV(checkMirrorV.Checked)
    End Sub

    Private Sub checkMirrorH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetMirrorH(checkMirrorH.Checked)
    End Sub

    Private Sub checkHalfClock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not -1 = m_Preview Then
            ' To switch clock, display needs to be stopped.
            Cursor.Current = Cursors.WaitCursor
            m_ArtCam.StopPreview()
        End If

        m_ArtCam.SetHalfClock(checkHalfClock.Checked)

        If Not -1 = m_Preview Then
            ' Resume display
            m_ArtCam.StartPreview()
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub radioChannel1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetCrossbar(0, 0)
    End Sub

    Private Sub radioChannel2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetCrossbar(1, 0)
    End Sub

    Private Sub radioChannel3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetCrossbar(2, 0)
    End Sub

    Private Sub radioChannel4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetCrossbar(3, 0)
    End Sub

    Private Sub radioChannel5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetCrossbar(4, 0)
    End Sub

    Private Sub radioChannel6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_ArtCam.SetCrossbar(5, 0)
    End Sub

    Private Sub UpDownBrightness_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownBrightness.ValueChanged
        m_ArtCam.SetBrightness(UpDownBrightness.Value)
    End Sub

    Private Sub UpDownContrast_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownContrast.ValueChanged
        m_ArtCam.SetContrast(UpDownContrast.Value)
    End Sub

    Private Sub UpDownHue_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownHue.ValueChanged
        m_ArtCam.SetHue(UpDownHue.Value)
    End Sub

    Private Sub UpDownSaturation_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownSaturation.ValueChanged
        m_ArtCam.SetSaturation(UpDownSaturation.Value)
    End Sub

    Private Sub UpDownSharpness_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownSharpness.ValueChanged
        m_ArtCam.SetSharpness(UpDownSharpness.Value)
    End Sub

    Private Sub UpDownGamma_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownGamma.ValueChanged
        m_ArtCam.SetGamma(UpDownGamma.Value)
    End Sub

    Private Sub UpDownBayerGainR_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownBayerGainR.ValueChanged
        m_ArtCam.SetBayerGainRed(UpDownBayerGainR.Value)
    End Sub

    Private Sub UpDownBayerGainG_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownBayerGainG.ValueChanged
        m_ArtCam.SetBayerGainGreen(UpDownBayerGainG.Value)
    End Sub

    Private Sub UpDownBayerGainB_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownBayerGainB.ValueChanged
        m_ArtCam.SetBayerGainBlue(UpDownBayerGainB.Value)
    End Sub

    Private Sub UpDownGlobalGain_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownGlobalGain.ValueChanged
        m_ArtCam.SetGlobalGain(UpDownGlobalGain.Value)
    End Sub

    Private Sub UpDownColorGainR_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownColorGainR.ValueChanged
        m_ArtCam.SetColorGainRed(UpDownColorGainR.Value)
    End Sub

    Private Sub UpDownColorGainG1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownColorGainG1.ValueChanged
        m_ArtCam.SetColorGainGreen1(UpDownColorGainG1.Value)
    End Sub

    Private Sub UpDownColorGainG2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownColorGainG2.ValueChanged
        m_ArtCam.SetColorGainGreen2(UpDownColorGainG2.Value)
    End Sub

    Private Sub UpDownColorGainB_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownColorGainB.ValueChanged
        m_ArtCam.SetColorGainBlue(UpDownColorGainB.Value)
    End Sub

    Private Sub UpDownExposureTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownExposureTime.ValueChanged
        m_ArtCam.SetExposureTime(UpDownExposureTime.Value)
    End Sub
End Class

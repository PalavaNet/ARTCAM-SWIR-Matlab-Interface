Imports Sample_VB.ArtCamSdk


Public Class Form5
    Inherits System.Windows.Forms.Form

#Region "Code made by Windows form designer "

    Public Sub New(ByVal a As CArtCam)
        MyBase.New()

        ' This call required for Windows firm designer Required for Windows firm designer
        InitializeComponent()

        ' InitializeComponent() Add initialization after call
        m_ArtCam = a
    End Sub

    '  "Form" overwrites "disclose and delete component list.
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxColor As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxAutoWB As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxWBFix As System.Windows.Forms.CheckBox
    Friend WithEvents TrackBarBayerR As System.Windows.Forms.TrackBar
    Friend WithEvents NumericBayerR As System.Windows.Forms.NumericUpDown
    Friend WithEvents TrackBarBayerG As System.Windows.Forms.TrackBar
    Friend WithEvents NumericBayerG As System.Windows.Forms.NumericUpDown
    Friend WithEvents TrackBarBayerB As System.Windows.Forms.TrackBar
    Friend WithEvents NumericBayerB As System.Windows.Forms.NumericUpDown
    Friend WithEvents ComboClock As System.Windows.Forms.ComboBox
    Friend WithEvents ComboResolution As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonLive As System.Windows.Forms.Button
    Friend WithEvents ButtonSnapshot As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonDefault As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CameraControll As System.Windows.Forms.GroupBox
    Friend WithEvents SaveValues As System.Windows.Forms.Button
    Friend WithEvents TrackBarShutter As System.Windows.Forms.TrackBar
    Friend WithEvents NumericShutter As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericGain As System.Windows.Forms.NumericUpDown
    Friend WithEvents TrackBarGain As System.Windows.Forms.TrackBar
    Friend WithEvents CheckBoxMirrorV As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TrackBarCurPosX As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarCurPosY As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarCurSizeX As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarCurSizeY As System.Windows.Forms.TrackBar
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents NumericUpDownCurPosX As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownCurPosY As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownCurSizeX As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownCurSizeY As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CheckAutoGain As System.Windows.Forms.CheckBox
    Friend WithEvents CheckAutoExposure As System.Windows.Forms.CheckBox
    Friend WithEvents TextAiMin As System.Windows.Forms.TextBox
    Friend WithEvents TextAiMax As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ComboClock = New System.Windows.Forms.ComboBox
        Me.ComboResolution = New System.Windows.Forms.ComboBox
        Me.ButtonLive = New System.Windows.Forms.Button
        Me.ButtonSnapshot = New System.Windows.Forms.Button
        Me.CheckBoxColor = New System.Windows.Forms.CheckBox
        Me.CheckBoxAutoWB = New System.Windows.Forms.CheckBox
        Me.CheckBoxWBFix = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.NumericBayerR = New System.Windows.Forms.NumericUpDown
        Me.TrackBarBayerR = New System.Windows.Forms.TrackBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.TrackBarBayerG = New System.Windows.Forms.TrackBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.NumericBayerG = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.TrackBarBayerB = New System.Windows.Forms.TrackBar
        Me.NumericBayerB = New System.Windows.Forms.NumericUpDown
        Me.ButtonOK = New System.Windows.Forms.Button
        Me.ButtonDefault = New System.Windows.Forms.Button
        Me.ButtonCancel = New System.Windows.Forms.Button
        Me.TrackBarShutter = New System.Windows.Forms.TrackBar
        Me.NumericShutter = New System.Windows.Forms.NumericUpDown
        Me.NumericGain = New System.Windows.Forms.NumericUpDown
        Me.TrackBarGain = New System.Windows.Forms.TrackBar
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CameraControll = New System.Windows.Forms.GroupBox
        Me.SaveValues = New System.Windows.Forms.Button
        Me.CheckBoxMirrorV = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.Button1 = New System.Windows.Forms.Button
        Me.TrackBarCurPosX = New System.Windows.Forms.TrackBar
        Me.TrackBarCurPosY = New System.Windows.Forms.TrackBar
        Me.TrackBarCurSizeX = New System.Windows.Forms.TrackBar
        Me.TrackBarCurSizeY = New System.Windows.Forms.TrackBar
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.NumericUpDownCurPosX = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDownCurPosY = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDownCurSizeX = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDownCurSizeY = New System.Windows.Forms.NumericUpDown
        Me.Label10 = New System.Windows.Forms.Label
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TextAiMin = New System.Windows.Forms.TextBox
        Me.CheckAutoGain = New System.Windows.Forms.CheckBox
        Me.CheckAutoExposure = New System.Windows.Forms.CheckBox
        Me.TextAiMax = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericBayerR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarBayerR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarBayerG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericBayerG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarBayerB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericBayerB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarShutter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericShutter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericGain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarGain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CameraControll.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TrackBarCurPosX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarCurPosY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarCurSizeX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarCurSizeY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownCurPosX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownCurPosY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownCurSizeX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownCurSizeY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboClock
        '
        Me.ComboClock.AllowDrop = True
        Me.ComboClock.DisplayMember = "1,2,3"
        Me.ComboClock.Items.AddRange(New Object() {"16MHz", "24MHz", "48MHz"})
        Me.ComboClock.Location = New System.Drawing.Point(16, 16)
        Me.ComboClock.Name = "ComboClock"
        Me.ComboClock.Size = New System.Drawing.Size(160, 20)
        Me.ComboClock.TabIndex = 0
        Me.ComboClock.ValueMember = "0,1,2"
        '
        'ComboResolution
        '
        Me.ComboResolution.Items.AddRange(New Object() {"800x600", "1024x768", "1280x720", "1280x1024"})
        Me.ComboResolution.Location = New System.Drawing.Point(16, 48)
        Me.ComboResolution.Name = "ComboResolution"
        Me.ComboResolution.Size = New System.Drawing.Size(160, 20)
        Me.ComboResolution.TabIndex = 1
        '
        'ButtonLive
        '
        Me.ButtonLive.Location = New System.Drawing.Point(192, 16)
        Me.ButtonLive.Name = "ButtonLive"
        Me.ButtonLive.Size = New System.Drawing.Size(88, 24)
        Me.ButtonLive.TabIndex = 2
        Me.ButtonLive.Text = "Live"
        '
        'ButtonSnapshot
        '
        Me.ButtonSnapshot.Location = New System.Drawing.Point(304, 16)
        Me.ButtonSnapshot.Name = "ButtonSnapshot"
        Me.ButtonSnapshot.Size = New System.Drawing.Size(88, 24)
        Me.ButtonSnapshot.TabIndex = 3
        Me.ButtonSnapshot.Text = "Snapshot"
        '
        'CheckBoxColor
        '
        Me.CheckBoxColor.Location = New System.Drawing.Point(16, 88)
        Me.CheckBoxColor.Name = "CheckBoxColor"
        Me.CheckBoxColor.Size = New System.Drawing.Size(72, 24)
        Me.CheckBoxColor.TabIndex = 4
        Me.CheckBoxColor.Text = "Color"
        '
        'CheckBoxAutoWB
        '
        Me.CheckBoxAutoWB.Location = New System.Drawing.Point(120, 88)
        Me.CheckBoxAutoWB.Name = "CheckBoxAutoWB"
        Me.CheckBoxAutoWB.Size = New System.Drawing.Size(128, 24)
        Me.CheckBoxAutoWB.TabIndex = 5
        Me.CheckBoxAutoWB.Text = "Auto white balance"
        '
        'CheckBoxWBFix
        '
        Me.CheckBoxWBFix.Location = New System.Drawing.Point(272, 88)
        Me.CheckBoxWBFix.Name = "CheckBoxWBFix"
        Me.CheckBoxWBFix.Size = New System.Drawing.Size(136, 24)
        Me.CheckBoxWBFix.TabIndex = 6
        Me.CheckBoxWBFix.Text = "White balance locked"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NumericBayerR)
        Me.GroupBox1.Controls.Add(Me.TrackBarBayerR)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TrackBarBayerG)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.NumericBayerG)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TrackBarBayerB)
        Me.GroupBox1.Controls.Add(Me.NumericBayerB)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 120)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 168)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Bayer"
        '
        'NumericBayerR
        '
        Me.NumericBayerR.Location = New System.Drawing.Point(336, 24)
        Me.NumericBayerR.Maximum = New Decimal(New Integer() {1023, 0, 0, 0})
        Me.NumericBayerR.Name = "NumericBayerR"
        Me.NumericBayerR.Size = New System.Drawing.Size(48, 19)
        Me.NumericBayerR.TabIndex = 2

        '
        'TrackBarBayerR
        '
        Me.TrackBarBayerR.AutoSize = False
        Me.TrackBarBayerR.Location = New System.Drawing.Point(72, 24)
        Me.TrackBarBayerR.Maximum = 1023
        Me.TrackBarBayerR.Name = "TrackBarBayerR"
        Me.TrackBarBayerR.Size = New System.Drawing.Size(256, 42)
        Me.TrackBarBayerR.TabIndex = 1
        Me.TrackBarBayerR.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "R Gain"
        '
        'TrackBarBayerG
        '
        Me.TrackBarBayerG.AutoSize = False
        Me.TrackBarBayerG.Location = New System.Drawing.Point(72, 72)
        Me.TrackBarBayerG.Maximum = 1023
        Me.TrackBarBayerG.Name = "TrackBarBayerG"
        Me.TrackBarBayerG.Size = New System.Drawing.Size(256, 42)
        Me.TrackBarBayerG.TabIndex = 1
        Me.TrackBarBayerG.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "G Gain"
        '
        'NumericBayerG
        '
        Me.NumericBayerG.Location = New System.Drawing.Point(336, 72)
        Me.NumericBayerG.Maximum = New Decimal(New Integer() {1023, 0, 0, 0})
        Me.NumericBayerG.Name = "NumericBayerG"
        Me.NumericBayerG.Size = New System.Drawing.Size(48, 19)
        Me.NumericBayerG.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "B Gain"
        '
        'TrackBarBayerB
        '
        Me.TrackBarBayerB.AutoSize = False
        Me.TrackBarBayerB.Location = New System.Drawing.Point(72, 120)
        Me.TrackBarBayerB.Maximum = 1023
        Me.TrackBarBayerB.Name = "TrackBarBayerB"
        Me.TrackBarBayerB.Size = New System.Drawing.Size(256, 42)
        Me.TrackBarBayerB.TabIndex = 1
        Me.TrackBarBayerB.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'NumericBayerB
        '
        Me.NumericBayerB.Location = New System.Drawing.Point(336, 120)
        Me.NumericBayerB.Maximum = New Decimal(New Integer() {1023, 0, 0, 0})
        Me.NumericBayerB.Name = "NumericBayerB"
        Me.NumericBayerB.Size = New System.Drawing.Size(48, 19)
        Me.NumericBayerB.TabIndex = 2
        '
        'ButtonOK
        '
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOK.Location = New System.Drawing.Point(32, 416)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(80, 24)
        Me.ButtonOK.TabIndex = 8
        Me.ButtonOK.Text = "OK"
        '
        'ButtonDefault
        '
        Me.ButtonDefault.Location = New System.Drawing.Point(136, 416)
        Me.ButtonDefault.Name = "ButtonDefault"
        Me.ButtonDefault.Size = New System.Drawing.Size(80, 24)
        Me.ButtonDefault.TabIndex = 8
        Me.ButtonDefault.Text = "Default"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(336, 416)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(80, 24)
        Me.ButtonCancel.TabIndex = 8
        Me.ButtonCancel.Text = "Cancel"
        '
        'TrackBarShutter
        '
        Me.TrackBarShutter.AutoSize = False
        Me.TrackBarShutter.Location = New System.Drawing.Point(120, 352)
        Me.TrackBarShutter.Maximum = 16383
        Me.TrackBarShutter.Minimum = 1
        Me.TrackBarShutter.Name = "TrackBarShutter"
        Me.TrackBarShutter.Size = New System.Drawing.Size(216, 42)
        Me.TrackBarShutter.TabIndex = 10
        Me.TrackBarShutter.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBarShutter.Value = 1
        '
        'NumericShutter
        '
        Me.NumericShutter.Location = New System.Drawing.Point(344, 352)

        Me.NumericShutter.Name = "NumericShutter"
        Me.NumericShutter.Size = New System.Drawing.Size(56, 19)
        Me.NumericShutter.TabIndex = 10
        '
        'NumericGain
        '
        Me.NumericGain.Location = New System.Drawing.Point(328, 16)
        Me.NumericGain.Maximum = New Decimal(New Integer() {63, 0, 0, 0})
        Me.NumericGain.Name = "NumericGain"
        Me.NumericGain.Size = New System.Drawing.Size(56, 19)
        Me.NumericGain.TabIndex = 10

        '
        'TrackBarGain
        '
        Me.TrackBarGain.AutoSize = False
        Me.TrackBarGain.Location = New System.Drawing.Point(120, 312)
        Me.TrackBarGain.Maximum = 63
        Me.TrackBarGain.Name = "TrackBarGain"
        Me.TrackBarGain.Size = New System.Drawing.Size(216, 42)
        Me.TrackBarGain.TabIndex = 9
        Me.TrackBarGain.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBarGain.Value = 14
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 360)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Exposure Time"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(64, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Global Gain"
        '
        'CameraControll
        '
        Me.CameraControll.Controls.Add(Me.Label5)
        Me.CameraControll.Controls.Add(Me.NumericGain)
        Me.CameraControll.Location = New System.Drawing.Point(16, 296)
        Me.CameraControll.Name = "CameraControll"
        Me.CameraControll.Size = New System.Drawing.Size(400, 104)
        Me.CameraControll.TabIndex = 11
        Me.CameraControll.TabStop = False
        Me.CameraControll.Text = "Camera Controll"
        '
        'SaveValues
        '
        Me.SaveValues.Location = New System.Drawing.Point(240, 416)
        Me.SaveValues.Name = "SaveValues"
        Me.SaveValues.Size = New System.Drawing.Size(80, 24)
        Me.SaveValues.TabIndex = 12
        Me.SaveValues.Text = "Save settings"
        '
        'CheckBoxMirrorV
        '
        Me.CheckBoxMirrorV.Location = New System.Drawing.Point(272, 64)
        Me.CheckBoxMirrorV.Name = "CheckBoxMirrorV"
        Me.CheckBoxMirrorV.Size = New System.Drawing.Size(136, 16)
        Me.CheckBoxMirrorV.TabIndex = 13
        Me.CheckBoxMirrorV.Text = "Vertical Mirror"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.TrackBarCurPosX)
        Me.GroupBox2.Controls.Add(Me.TrackBarCurPosY)
        Me.GroupBox2.Controls.Add(Me.TrackBarCurSizeX)
        Me.GroupBox2.Controls.Add(Me.TrackBarCurSizeY)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.NumericUpDownCurPosX)
        Me.GroupBox2.Controls.Add(Me.NumericUpDownCurPosY)
        Me.GroupBox2.Controls.Add(Me.NumericUpDownCurSizeX)
        Me.GroupBox2.Controls.Add(Me.NumericUpDownCurSizeY)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(432, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(360, 264)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cross cursor settings"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Location = New System.Drawing.Point(8, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(336, 32)
        Me.Panel1.TabIndex = 5
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(8, 8)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(112, 16)
        Me.RadioButton1.TabIndex = 3
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Cursor1"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(136, 8)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(112, 16)
        Me.RadioButton2.TabIndex = 3
        Me.RadioButton2.Text = "Cursor2"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 216)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(48, 32)
        Me.Button1.TabIndex = 4
        '
        'TrackBarCurPosX
        '
        Me.TrackBarCurPosX.AutoSize = False
        Me.TrackBarCurPosX.Location = New System.Drawing.Point(64, 48)
        Me.TrackBarCurPosX.Maximum = 2047
        Me.TrackBarCurPosX.Name = "TrackBarCurPosX"
        Me.TrackBarCurPosX.Size = New System.Drawing.Size(224, 24)
        Me.TrackBarCurPosX.TabIndex = 1
        Me.TrackBarCurPosX.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'TrackBarCurPosY
        '
        Me.TrackBarCurPosY.AutoSize = False
        Me.TrackBarCurPosY.Location = New System.Drawing.Point(64, 88)
        Me.TrackBarCurPosY.Maximum = 2047
        Me.TrackBarCurPosY.Name = "TrackBarCurPosY"
        Me.TrackBarCurPosY.Size = New System.Drawing.Size(224, 24)
        Me.TrackBarCurPosY.TabIndex = 1
        Me.TrackBarCurPosY.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'TrackBarCurSizeX
        '
        Me.TrackBarCurSizeX.AutoSize = False
        Me.TrackBarCurSizeX.Location = New System.Drawing.Point(64, 128)
        Me.TrackBarCurSizeX.Maximum = 2047
        Me.TrackBarCurSizeX.Name = "TrackBarCurSizeX"
        Me.TrackBarCurSizeX.Size = New System.Drawing.Size(224, 24)
        Me.TrackBarCurSizeX.TabIndex = 1
        Me.TrackBarCurSizeX.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'TrackBarCurSizeY
        '
        Me.TrackBarCurSizeY.AutoSize = False
        Me.TrackBarCurSizeY.Location = New System.Drawing.Point(64, 168)
        Me.TrackBarCurSizeY.Maximum = 2047
        Me.TrackBarCurSizeY.Name = "TrackBarCurSizeY"
        Me.TrackBarCurSizeY.Size = New System.Drawing.Size(224, 24)
        Me.TrackBarCurSizeY.TabIndex = 1
        Me.TrackBarCurSizeY.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "X Pos"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Y Pos"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "X Size"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 176)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Y Size"
        '
        'NumericUpDownCurPosX
        '
        Me.NumericUpDownCurPosX.Location = New System.Drawing.Point(296, 48)
        Me.NumericUpDownCurPosX.Maximum = New Decimal(New Integer() {2047, 0, 0, 0})
        Me.NumericUpDownCurPosX.Name = "NumericUpDownCurPosX"
        Me.NumericUpDownCurPosX.Size = New System.Drawing.Size(48, 19)
        Me.NumericUpDownCurPosX.TabIndex = 2
        '
        'NumericUpDownCurPosY
        '
        Me.NumericUpDownCurPosY.Location = New System.Drawing.Point(296, 88)
        Me.NumericUpDownCurPosY.Maximum = New Decimal(New Integer() {2047, 0, 0, 0})
        Me.NumericUpDownCurPosY.Name = "NumericUpDownCurPosY"
        Me.NumericUpDownCurPosY.Size = New System.Drawing.Size(48, 19)
        Me.NumericUpDownCurPosY.TabIndex = 2
        '
        'NumericUpDownCurSizeX
        '
        Me.NumericUpDownCurSizeX.Location = New System.Drawing.Point(296, 128)
        Me.NumericUpDownCurSizeX.Maximum = New Decimal(New Integer() {2047, 0, 0, 0})
        Me.NumericUpDownCurSizeX.Name = "NumericUpDownCurSizeX"
        Me.NumericUpDownCurSizeX.Size = New System.Drawing.Size(48, 19)
        Me.NumericUpDownCurSizeX.TabIndex = 2
        '
        'NumericUpDownCurSizeY
        '
        Me.NumericUpDownCurSizeY.Location = New System.Drawing.Point(296, 168)
        Me.NumericUpDownCurSizeY.Maximum = New Decimal(New Integer() {2047, 0, 0, 0})
        Me.NumericUpDownCurSizeY.Name = "NumericUpDownCurSizeY"
        Me.NumericUpDownCurSizeY.Size = New System.Drawing.Size(48, 19)
        Me.NumericUpDownCurSizeY.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(80, 224)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Color"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextAiMin)
        Me.GroupBox3.Controls.Add(Me.CheckAutoGain)
        Me.GroupBox3.Controls.Add(Me.CheckAutoExposure)
        Me.GroupBox3.Controls.Add(Me.TextAiMax)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Location = New System.Drawing.Point(432, 304)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(360, 96)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Auto iris settings"
        '
        'TextAiMin
        '
        Me.TextAiMin.Location = New System.Drawing.Point(280, 24)
        Me.TextAiMin.MaxLength = 3
        Me.TextAiMin.Name = "TextAiMin"
        Me.TextAiMin.Size = New System.Drawing.Size(56, 19)
        Me.TextAiMin.TabIndex = 1
        Me.TextAiMin.Text = ""
        '
        'CheckAutoGain
        '
        Me.CheckAutoGain.Location = New System.Drawing.Point(24, 24)
        Me.CheckAutoGain.Name = "CheckAutoGain"
        Me.CheckAutoGain.Size = New System.Drawing.Size(96, 24)
        Me.CheckAutoGain.TabIndex = 0
        Me.CheckAutoGain.Text = "Gain"
        '
        'CheckAutoExposure
        '
        Me.CheckAutoExposure.Location = New System.Drawing.Point(24, 56)
        Me.CheckAutoExposure.Name = "CheckAutoExposure"
        Me.CheckAutoExposure.Size = New System.Drawing.Size(128, 24)
        Me.CheckAutoExposure.TabIndex = 0
        Me.CheckAutoExposure.Text = "Exposure"
        '
        'TextAiMax
        '
        Me.TextAiMax.Location = New System.Drawing.Point(280, 64)
        Me.TextAiMax.MaxLength = 3
        Me.TextAiMax.Name = "TextAiMax"
        Me.TextAiMax.Size = New System.Drawing.Size(56, 19)
        Me.TextAiMax.TabIndex = 1
        Me.TextAiMax.Text = ""
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(176, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Min(0-255)"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(176, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 16)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Max(0-255)"
        '
        'Form5
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(818, 447)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.CheckBoxMirrorV)
        Me.Controls.Add(Me.SaveValues)
        Me.Controls.Add(Me.NumericShutter)
        Me.Controls.Add(Me.TrackBarShutter)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CheckBoxWBFix)
        Me.Controls.Add(Me.CheckBoxAutoWB)
        Me.Controls.Add(Me.CheckBoxColor)
        Me.Controls.Add(Me.ButtonSnapshot)
        Me.Controls.Add(Me.ButtonLive)
        Me.Controls.Add(Me.ComboResolution)
        Me.Controls.Add(Me.ComboClock)
        Me.Controls.Add(Me.ButtonDefault)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.TrackBarGain)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CameraControll)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form5"
        Me.Text = "Monitor settings"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.NumericBayerR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarBayerR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarBayerG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericBayerG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarBayerB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericBayerB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarShutter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericShutter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericGain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarGain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CameraControll.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.TrackBarCurPosX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarCurPosY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarCurSizeX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarCurSizeY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownCurPosX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownCurPosY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownCurSizeX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownCurSizeY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim m_ArtCam As CArtCam = Nothing
    Dim m_ColorMode, m_AWB, m_Fix, m_PrevSize, m_CameraClock As Integer
    Dim m_Width, m_Height As Integer
    Dim m_Error As Integer
    Dim iBayerR, iBayerG, iBayerB, iGain, iShutter, iMirrorV As Integer
    Dim m_PreviewMode As Integer
    Dim m_CursorColor(2) As System.Drawing.Color
    Dim m_CursorPosX(2), m_CursorPosY(2), m_CursorSizeX(2), m_CursorSizeY(2), m_CurNum As Integer


    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Change operation depending on DLL.
        ' Please refer to the manual for function correspondence with each DLL.
		Dim m_DllType As ARTCAM_CAMERATYPE = (m_ArtCam.GetDllVersion() >> 16)
        Select Case m_DllType
            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_130MI_MOUT

                'Color Mode
                m_ColorMode = m_ArtCam.Monitor_GetColorMode(m_Error)
                If m_ColorMode = 1 Then
                    CheckBoxColor.Checked() = True
                End If

                'Auto white balance
                m_AWB = m_ArtCam.Monitor_GetBayerGainAuto(m_Error)
                If m_AWB = 1 Then CheckBoxAutoWB.Checked = True

                'Fix the bayer pattern for auto white balance
                m_Fix = m_ArtCam.Monitor_GetBayerGainLock(m_Error)
                If m_Fix = 1 Then CheckBoxWBFix.Checked = True

                'Camera clock
                m_CameraClock = m_ArtCam.Monitor_GetCameraClock(m_Error)
                Select Case m_CameraClock
                    Case 2 : ComboClock.SelectedIndex = 1
                    Case 5 : ComboClock.SelectedIndex = 2
                    Case Else : ComboClock.SelectedIndex = 0
                End Select

                'Preview size
				m_PrevSize = m_ArtCam.Monitor_GetPreviewSize(m_Width, m_Height)
				If m_Width = 800 And m_Height = 600 Then
                    ComboResolution.SelectedIndex = 0
				ElseIf m_Width = 1024 And m_Height = 768 Then
                    ComboResolution.SelectedIndex = 1
				ElseIf m_Width = 1280 And m_Height = 720 Then
                    ComboResolution.SelectedIndex = 2
				ElseIf m_Width = 1280 And m_Height = 1024 Then
					ComboResolution.SelectedIndex = 3
                End If

                'Bayer gain
                iBayerR = m_ArtCam.Monitor_GetBayerGainRed(m_Error)
                iBayerG = m_ArtCam.Monitor_GetBayerGainGreen(m_Error)
                iBayerB = m_ArtCam.Monitor_GetBayerGainBlue(m_Error)

                TrackBarBayerR.Value() = iBayerR
                TrackBarBayerG.Value() = iBayerG
                TrackBarBayerB.Value() = iBayerB

                NumericBayerR.Value = iBayerR
                NumericBayerG.Value = iBayerG
                NumericBayerB.Value = iBayerB

                'Camera controll
                NumericShutter.Maximum = 16383
                NumericShutter.Minimum = 1

                iGain = m_ArtCam.GetGlobalGain()
                iShutter = m_ArtCam.GetExposureTime()
                iMirrorV = m_ArtCam.GetMirrorV()
                TrackBarGain.Value = iGain
                TrackBarShutter.Value = iShutter

                NumericGain.Value = iGain
                NumericShutter.Value = iShutter

                CheckBoxMirrorV.Checked = iMirrorV

				' Color
				m_CurNum = 0

				Dim i As Integer = 0
				For i = 0 To 1
					m_CursorColor(i) = System.Drawing.ColorTranslator.FromOle(RGB( _
					m_ArtCam.Monitor_GetCrossCursorColorR(i, 0), _
					m_ArtCam.Monitor_GetCrossCursorColorG(i, 0), _
					m_ArtCam.Monitor_GetCrossCursorColorB(i, 0)))
				Next i
				Button1.BackColor = m_CursorColor(0)

				'Position, Size
				For i = 0 To 1
					m_ArtCam.Monitor_GetCrossCursorPos(i, m_CursorPosX(i), m_CursorPosY(i))
					m_ArtCam.Monitor_GetCrossCursorSize(i, m_CursorSizeX(i), m_CursorSizeY(i))
				Next i

				CurrentCursorChanged()

        End Select
    End Sub

    Private Sub CheckBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboClock.SelectedIndexChanged
        Select Case ComboClock.SelectedIndex
            Case 0 : m_ArtCam.Monitor_SetCameraClock(0)
            Case 1 : m_ArtCam.Monitor_SetCameraClock(1)
            Case 2 : m_ArtCam.Monitor_SetCameraClock(2)
        End Select
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarBayerR.Scroll
        m_ArtCam.Monitor_SetBayerGainRed(TrackBarBayerR.Value)
        NumericBayerR.Value = TrackBarBayerR.Value
        iBayerR = TrackBarBayerR.Value

    End Sub

    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarBayerG.Scroll
        Dim t As Integer = m_ArtCam.Monitor_SetBayerGainGreen(TrackBarBayerG.Value)
        NumericBayerG.Value = TrackBarBayerG.Value
        iBayerG = TrackBarBayerG.Value
    End Sub

    Private Sub TrackBar3_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarBayerB.Scroll
        Dim t As Integer = m_ArtCam.Monitor_SetBayerGainBlue(TrackBarBayerB.Value)
        NumericBayerB.Value = TrackBarBayerB.Value
        iBayerB = TrackBarBayerB.Value
    End Sub

	Private Sub TrackBarCurPosX_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarCurPosX.Scroll
		Dim t As Integer = m_ArtCam.Monitor_SetCrossCursorPos(m_CurNum, TrackBarCurPosX.Value, m_CursorPosY(m_CurNum))
		NumericUpDownCurPosX.Value = TrackBarCurPosX.Value
		m_CursorPosX(m_CurNum) = TrackBarCurPosX.Value
	End Sub
	Private Sub TrackBarCurPosY_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarCurPosY.Scroll
		Dim t As Integer = m_ArtCam.Monitor_SetCrossCursorPos(m_CurNum, m_CursorPosX(m_CurNum), TrackBarCurPosY.Value)
		NumericUpDownCurPosY.Value = TrackBarCurPosY.Value
		m_CursorPosY(m_CurNum) = TrackBarCurPosY.Value
	End Sub

	Private Sub TrackBarCurSizeX_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarCurSizeX.Scroll
		Dim t As Integer = m_ArtCam.Monitor_SetCrossCursorSize(m_CurNum, TrackBarCurSizeX.Value, m_CursorSizeY(m_CurNum))
		NumericUpDownCurSizeX.Value = TrackBarCurSizeX.Value
		m_CursorSizeX(m_CurNum) = TrackBarCurSizeX.Value
	End Sub

	Private Sub TrackBarCurSizeY_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarCurSizeY.Scroll
		Dim t As Integer = m_ArtCam.Monitor_SetCrossCursorSize(m_CurNum, m_CursorSizeX(m_CurNum), TrackBarCurSizeY.Value)
		NumericUpDownCurSizeY.Value = TrackBarCurSizeY.Value
		m_CursorSizeY(m_CurNum) = TrackBarCurSizeY.Value
	End Sub



    Private Sub CheckBoxColor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxColor.CheckedChanged
        m_ArtCam.Monitor_SetColorMode(CheckBoxColor.Checked)
        If CheckBoxColor.Checked = False Then
            CheckBoxAutoWB.Enabled = False
            CheckBoxWBFix.Enabled = False
        Else
            CheckBoxAutoWB.Enabled = True
            CheckBoxWBFix.Enabled = True
        End If
    End Sub

    Private Sub CheckBoxAutoWB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxAutoWB.CheckedChanged
        m_ArtCam.Monitor_SetBayerGainAuto(CheckBoxAutoWB.Checked)
        Dim r, g, b As Integer
        If CheckBoxAutoWB.Checked = False Then
            CheckBoxWBFix.Enabled = False
            TrackBarBayerR.Enabled = True
            TrackBarBayerG.Enabled = True
            TrackBarBayerB.Enabled = True
            NumericBayerR.Enabled = True
            NumericBayerG.Enabled = True
            NumericBayerB.Enabled = True

        Else
            CheckBoxWBFix.Enabled = True

            r = m_ArtCam.Monitor_GetBayerGainRed(m_Error)
            g = m_ArtCam.Monitor_GetBayerGainGreen(m_Error)
            b = m_ArtCam.Monitor_GetBayerGainBlue(m_Error)
            TrackBarBayerR.Value = r
            NumericBayerR.Value = r
            TrackBarBayerG.Value = g
            NumericBayerG.Value = g
            TrackBarBayerB.Value = b
            NumericBayerB.Value = b

            TrackBarBayerR.Enabled = False
            TrackBarBayerG.Enabled = False
            TrackBarBayerB.Enabled = False
            NumericBayerR.Enabled = False
            NumericBayerG.Enabled = False
            NumericBayerB.Enabled = False
        End If
    End Sub


    Private Sub CheckBoxWBFix_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxWBFix.CheckedChanged
        Dim t As Integer = m_ArtCam.Monitor_SetBayerGainLock(CheckBoxWBFix.Checked)
    End Sub

    Private Sub ComboResolution_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboResolution.SelectedIndexChanged
        Select Case ComboResolution.SelectedIndex
            Case 0 : m_ArtCam.Monitor_SetPreviewSize(800, 600)
            Case 1 : m_ArtCam.Monitor_SetPreviewSize(1024, 768)
			Case 2 : m_ArtCam.Monitor_SetPreviewSize(1280, 720)
            Case Else : m_ArtCam.Monitor_SetPreviewSize(1280, 1024)
        End Select
    End Sub


    Private Sub TrackBarGain_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarGain.Scroll
        Dim t As Integer = m_ArtCam.SetGlobalGain(TrackBarGain.Value)
        NumericGain.Value = TrackBarGain.Value
        iGain = TrackBarGain.Value
    End Sub

    Private Sub TrackBarShutter_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarShutter.Scroll
        Dim t As Integer = m_ArtCam.SetExposureTime(TrackBarShutter.Value)
        NumericShutter.Value = TrackBarShutter.Value
        iShutter = TrackBarShutter.Value
    End Sub

    Private Sub NumericGain_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericGain.ValueChanged
        TrackBarGain.Value = NumericGain.Value
        m_ArtCam.SetGlobalGain(NumericGain.Value)

    End Sub

    Private Sub NumericShutter_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericShutter.ValueChanged
        TrackBarShutter.Value = NumericShutter.Value
        m_ArtCam.SetExposureTime(NumericShutter.Value)
    End Sub

    Private Sub NumericBayerR_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericBayerR.ValueChanged
        TrackBarBayerR.Value = NumericBayerR.Value
        m_ArtCam.Monitor_SetBayerGainRed(NumericBayerR.Value)
    End Sub

    Private Sub NumericBayerG_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericBayerG.ValueChanged
        TrackBarBayerG.Value = NumericBayerG.Value
        m_ArtCam.Monitor_SetBayerGainGreen(NumericBayerG.Value)
    End Sub

    Private Sub NumericBayerB_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericBayerB.ValueChanged
        TrackBarBayerB.Value = NumericBayerB.Value
        m_ArtCam.Monitor_SetBayerGainBlue(NumericBayerB.Value)
    End Sub


    Private Sub SaveValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveValues.Click

		If (MsgBox("After the camera power is turned off, these settings are enabled.\r\nAre you sure to save now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then

        iGain = TrackBarGain.Value
        iShutter = TrackBarShutter.Value

        ' Counter of setting register
        m_ArtCam.Fpga_WriteRegister(&HB6, &H3)

        ' Register for Exposure Time
        m_ArtCam.Fpga_WriteRegister(&HC0, &H9)
        m_ArtCam.Fpga_WriteRegister(&HC1, (iShutter And &HFF00) / 256)
        m_ArtCam.Fpga_WriteRegister(&HC2, iShutter)

        ' Register for Global Gain
        m_ArtCam.Fpga_WriteRegister(&HC3, &H35)
        m_ArtCam.Fpga_WriteRegister(&HC4, (iGain And &HFF00) / 256)
        m_ArtCam.Fpga_WriteRegister(&HC5, iGain)

        ' Register for vertical Mirror

			m_ArtCam.Monitor_SetPreviewMode(True)


			If (m_ArtCam.GetDllVersion() >> 16) = ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_130MI_MOUT Then
				Dim regMirrorV As Integer
				regMirrorV = m_ArtCam.ReadRegister(&H20, m_Error)

				' Vertical mirror
		        m_ArtCam.Fpga_WriteRegister(&HC6, &H20)
		        m_ArtCam.Fpga_WriteRegister(&HC7, (regMirrorV And &HFF00) / 256)
		        m_ArtCam.Fpga_WriteRegister(&HC8, regMirrorV)
			End If

			m_ArtCam.Monitor_SaveCurrentSettings()

		End If
    End Sub

    Private Sub ButtonSnapshot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSnapshot.Click
		m_ArtCam.Monitor_SetPreviewMode(False)
    End Sub

    Private Sub ButtonLive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLive.Click
        m_ArtCam.Monitor_SetPreviewMode(True)
    End Sub

    Private Sub ButtonDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDefault.Click
		Dim m_DllType As ARTCAM_CAMERATYPE = (m_ArtCam.GetDllVersion() >> 16)
        iBayerR = 256
        iBayerG = 256
        iBayerB = 256

        Select Case m_DllType
            Case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_130MI_MOUT

                'Preview mode
                m_ArtCam.Monitor_SetPreviewMode(True)

                ' Bayer gain
                TrackBarBayerR.Value() = iBayerR
                TrackBarBayerG.Value() = iBayerG
                TrackBarBayerB.Value() = iBayerB

                NumericBayerR.Value = iBayerR
                NumericBayerG.Value = iBayerG
                NumericBayerB.Value = iBayerB

                m_ArtCam.Monitor_SetBayerGainRed(iBayerR)
                m_ArtCam.Monitor_SetBayerGainGreen(iBayerG)
                m_ArtCam.Monitor_SetBayerGainBlue(iBayerB)

                ' Camera controll
                iGain = 14
                iShutter = 1024

                TrackBarGain.Value = iGain
                TrackBarShutter.Value = iShutter

                NumericGain.Value = iGain
                NumericShutter.Value = iShutter

                m_ArtCam.SetGlobalGain(iGain)
                m_ArtCam.SetExposureTime(iShutter)

        End Select
    End Sub

    Private Sub CheckBoxMirrorV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMirrorV.CheckedChanged
        If CheckBoxMirrorV.Checked = True Then
            m_ArtCam.SetMirrorV(1)
            iMirrorV = 1
        Else
            m_ArtCam.SetMirrorV(0)
            iMirrorV = 0
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            m_CursorColor(m_CurNum) = ColorDialog1.Color()
            Button1.BackColor = m_CursorColor(m_CurNum)
            m_ArtCam.Monitor_SetCrossCursorColorR(m_CurNum, m_CursorColor(m_CurNum).R())
            m_ArtCam.Monitor_SetCrossCursorColorG(m_CurNum, m_CursorColor(m_CurNum).G())
            m_ArtCam.Monitor_SetCrossCursorColorB(m_CurNum, m_CursorColor(m_CurNum).B())
        End If
    End Sub


    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            m_CurNum = 0
        Else
            m_CurNum = 1
        End If
        CurrentCursorChanged()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            m_CurNum = 1
        Else
            m_CurNum = 0
        End If
        CurrentCursorChanged()
    End Sub

    Private Sub CurrentCursorChanged()
        TrackBarCurPosX.Value = m_CursorPosX(m_CurNum)
        TrackBarCurPosY.Value = m_CursorPosY(m_CurNum)
        TrackBarCurSizeX.Value = m_CursorSizeX(m_CurNum)
        TrackBarCurSizeY.Value = m_CursorSizeY(m_CurNum)

        NumericUpDownCurPosX.Value = m_CursorPosX(m_CurNum)
        NumericUpDownCurPosY.Value = m_CursorPosY(m_CurNum)
        NumericUpDownCurSizeX.Value = m_CursorSizeX(m_CurNum)
        NumericUpDownCurSizeY.Value = m_CursorSizeY(m_CurNum)

        Button1.BackColor = m_CursorColor(m_CurNum)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAutoGain.CheckedChanged
        CheckAutoIrisMode()
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAutoExposure.CheckedChanged
        CheckAutoIrisMode()
    End Sub
    Private Sub CheckAutoIrisMode()
        If (CheckAutoGain.Checked = True) Then
            If (CheckAutoExposure.Checked = True) Then
                m_ArtCam.Monitor_SetAutoIrisMode(AI_TYPE.AI_BOTH)
            Else
                m_ArtCam.Monitor_SetAutoIrisMode(AI_TYPE.AI_GAIN)
            End If
        Else
            If (CheckAutoExposure.Checked = True) Then
                m_ArtCam.Monitor_SetAutoIrisMode(AI_TYPE.AI_EXPOSURE)
            Else
                m_ArtCam.Monitor_SetAutoIrisMode(AI_TYPE.AI_NONE)
            End If
        End If
    End Sub

    Private Sub TextAiMin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextAiMin.TextChanged
        m_ArtCam.Monitor_SetAutoIrisRange(Integer.Parse(TextAiMin.Text), Integer.Parse(TextAiMax.Text))
    End Sub

    Private Sub TextAiMax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextAiMax.TextChanged
        m_ArtCam.Monitor_SetAutoIrisRange(Integer.Parse(TextAiMin.Text), Integer.Parse(TextAiMax.Text))
    End Sub
End Class

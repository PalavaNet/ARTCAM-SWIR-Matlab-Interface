<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
    Inherits System.Windows.Forms.Form

    ' Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

	' NOTE: The following procedure is required by the Windows Form Designer
	' It can be modified using the Windows Form Designer.
	' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox
		Me.CheckAWB = New System.Windows.Forms.CheckBox
		Me.CheckColor = New System.Windows.Forms.CheckBox
		Me.GroupBox2 = New System.Windows.Forms.GroupBox
		Me.NumericGainB = New System.Windows.Forms.NumericUpDown
		Me.TrackGainB = New System.Windows.Forms.TrackBar
		Me.NumericGainG = New System.Windows.Forms.NumericUpDown
		Me.Label3 = New System.Windows.Forms.Label
		Me.NumericGainR = New System.Windows.Forms.NumericUpDown
		Me.TrackGainG = New System.Windows.Forms.TrackBar
		Me.Label2 = New System.Windows.Forms.Label
		Me.TrackGainR = New System.Windows.Forms.TrackBar
		Me.Label1 = New System.Windows.Forms.Label
		Me.GroupBox3 = New System.Windows.Forms.GroupBox
		Me.NumericExposure = New System.Windows.Forms.NumericUpDown
		Me.CheckMirrorH = New System.Windows.Forms.CheckBox
		Me.NumericGainAll = New System.Windows.Forms.NumericUpDown
		Me.CheckMirrorV = New System.Windows.Forms.CheckBox
		Me.TrackExposure = New System.Windows.Forms.TrackBar
		Me.Label5 = New System.Windows.Forms.Label
		Me.TrackGainAll = New System.Windows.Forms.TrackBar
		Me.Label4 = New System.Windows.Forms.Label
		Me.GroupBox4 = New System.Windows.Forms.GroupBox
		Me.NumericYSize = New System.Windows.Forms.NumericUpDown
		Me.PictureColor = New System.Windows.Forms.PictureBox
		Me.NumericXSize = New System.Windows.Forms.NumericUpDown
		Me.TrackYSize = New System.Windows.Forms.TrackBar
		Me.NumericYPos = New System.Windows.Forms.NumericUpDown
		Me.Label9 = New System.Windows.Forms.Label
		Me.NumericXPos = New System.Windows.Forms.NumericUpDown
		Me.TrackXSize = New System.Windows.Forms.TrackBar
		Me.Label8 = New System.Windows.Forms.Label
		Me.TrackYPos = New System.Windows.Forms.TrackBar
		Me.Label7 = New System.Windows.Forms.Label
		Me.TrackXPos = New System.Windows.Forms.TrackBar
		Me.Label6 = New System.Windows.Forms.Label
		Me.CheckCursorOn = New System.Windows.Forms.CheckBox
		Me.RadioCursor2 = New System.Windows.Forms.RadioButton
		Me.RadioCursor1 = New System.Windows.Forms.RadioButton
		Me.ButtonInitSettings = New System.Windows.Forms.Button
		Me.ButtonSaveSettings = New System.Windows.Forms.Button
		Me.ButtonOK = New System.Windows.Forms.Button
		Me.ButtonDefault = New System.Windows.Forms.Button
		Me.ButtonCancel = New System.Windows.Forms.Button
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.NumericGainB, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TrackGainB, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.NumericGainG, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.NumericGainR, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TrackGainG, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TrackGainR, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox3.SuspendLayout()
		CType(Me.NumericExposure, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.NumericGainAll, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TrackExposure, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TrackGainAll, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox4.SuspendLayout()
		CType(Me.NumericYSize, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureColor, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.NumericXSize, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TrackYSize, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.NumericYPos, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.NumericXPos, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TrackXSize, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TrackYPos, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TrackXPos, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.CheckAWB)
		Me.GroupBox1.Controls.Add(Me.CheckColor)
		Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(270, 64)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Working mode settings"
		'
		'CheckAWB
		'
		Me.CheckAWB.AutoSize = True
		Me.CheckAWB.Location = New System.Drawing.Point(105, 28)
		Me.CheckAWB.Name = "CheckAWB"
		Me.CheckAWB.Size = New System.Drawing.Size(122, 16)
		Me.CheckAWB.TabIndex = 1
		Me.CheckAWB.Text = "Auto white balance"
		Me.CheckAWB.UseVisualStyleBackColor = True
		'
		'CheckColor
		'
		Me.CheckColor.AutoSize = True
		Me.CheckColor.Location = New System.Drawing.Point(19, 28)
		Me.CheckColor.Name = "CheckColor"
		Me.CheckColor.Size = New System.Drawing.Size(51, 16)
		Me.CheckColor.TabIndex = 0
		Me.CheckColor.Text = "Color"
		Me.CheckColor.UseVisualStyleBackColor = True
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.NumericGainB)
		Me.GroupBox2.Controls.Add(Me.TrackGainB)
		Me.GroupBox2.Controls.Add(Me.NumericGainG)
		Me.GroupBox2.Controls.Add(Me.Label3)
		Me.GroupBox2.Controls.Add(Me.NumericGainR)
		Me.GroupBox2.Controls.Add(Me.TrackGainG)
		Me.GroupBox2.Controls.Add(Me.Label2)
		Me.GroupBox2.Controls.Add(Me.TrackGainR)
		Me.GroupBox2.Controls.Add(Me.Label1)
		Me.GroupBox2.Location = New System.Drawing.Point(12, 83)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(270, 109)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Bayer conversion"
		'
		'NumericGainB
		'
		Me.NumericGainB.Location = New System.Drawing.Point(215, 75)
		Me.NumericGainB.Name = "NumericGainB"
		Me.NumericGainB.Size = New System.Drawing.Size(49, 19)
		Me.NumericGainB.TabIndex = 11
		'
		'TrackGainB
		'
		Me.TrackGainB.AutoSize = False
		Me.TrackGainB.Location = New System.Drawing.Point(53, 75)
		Me.TrackGainB.Name = "TrackGainB"
		Me.TrackGainB.Size = New System.Drawing.Size(156, 19)
		Me.TrackGainB.TabIndex = 7
		Me.TrackGainB.TickFrequency = 0
		Me.TrackGainB.TickStyle = System.Windows.Forms.TickStyle.None
		'
		'NumericGainG
		'
		Me.NumericGainG.Location = New System.Drawing.Point(215, 48)
		Me.NumericGainG.Name = "NumericGainG"
		Me.NumericGainG.Size = New System.Drawing.Size(49, 19)
		Me.NumericGainG.TabIndex = 10
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(6, 75)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(40, 12)
		Me.Label3.TabIndex = 6
		Me.Label3.Text = "B Gain"
		'
		'NumericGainR
		'
		Me.NumericGainR.Location = New System.Drawing.Point(215, 18)
		Me.NumericGainR.Name = "NumericGainR"
		Me.NumericGainR.Size = New System.Drawing.Size(49, 19)
		Me.NumericGainR.TabIndex = 9
		'
		'TrackGainG
		'
		Me.TrackGainG.AutoSize = False
		Me.TrackGainG.Location = New System.Drawing.Point(53, 50)
		Me.TrackGainG.Name = "TrackGainG"
		Me.TrackGainG.Size = New System.Drawing.Size(156, 19)
		Me.TrackGainG.TabIndex = 4
		Me.TrackGainG.TickFrequency = 0
		Me.TrackGainG.TickStyle = System.Windows.Forms.TickStyle.None
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(6, 50)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(40, 12)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "G Gain"
		'
		'TrackGainR
		'
		Me.TrackGainR.AutoSize = False
		Me.TrackGainR.Location = New System.Drawing.Point(53, 25)
		Me.TrackGainR.Name = "TrackGainR"
		Me.TrackGainR.Size = New System.Drawing.Size(156, 19)
		Me.TrackGainR.TabIndex = 1
		Me.TrackGainR.TickFrequency = 0
		Me.TrackGainR.TickStyle = System.Windows.Forms.TickStyle.None
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(6, 25)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(40, 12)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "R Gain"
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.NumericExposure)
		Me.GroupBox3.Controls.Add(Me.CheckMirrorH)
		Me.GroupBox3.Controls.Add(Me.NumericGainAll)
		Me.GroupBox3.Controls.Add(Me.CheckMirrorV)
		Me.GroupBox3.Controls.Add(Me.TrackExposure)
		Me.GroupBox3.Controls.Add(Me.Label5)
		Me.GroupBox3.Controls.Add(Me.TrackGainAll)
		Me.GroupBox3.Controls.Add(Me.Label4)
		Me.GroupBox3.Location = New System.Drawing.Point(13, 199)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(269, 111)
		Me.GroupBox3.TabIndex = 2
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "Camera controll"
		'
		'NumericExposure
		'
		Me.NumericExposure.Location = New System.Drawing.Point(214, 43)
		Me.NumericExposure.Name = "NumericExposure"
		Me.NumericExposure.Size = New System.Drawing.Size(49, 19)
		Me.NumericExposure.TabIndex = 10
		'
		'CheckMirrorH
		'
		Me.CheckMirrorH.AutoSize = True
		Me.CheckMirrorH.Location = New System.Drawing.Point(141, 79)
		Me.CheckMirrorH.Name = "CheckMirrorH"
		Me.CheckMirrorH.Size = New System.Drawing.Size(109, 16)
		Me.CheckMirrorH.TabIndex = 16
		Me.CheckMirrorH.Text = "Horizontal mirror"
		Me.CheckMirrorH.UseVisualStyleBackColor = True
		'
		'NumericGainAll
		'
		Me.NumericGainAll.Location = New System.Drawing.Point(214, 18)
		Me.NumericGainAll.Name = "NumericGainAll"
		Me.NumericGainAll.Size = New System.Drawing.Size(49, 19)
		Me.NumericGainAll.TabIndex = 9
		'
		'CheckMirrorV
		'
		Me.CheckMirrorV.AutoSize = True
		Me.CheckMirrorV.Location = New System.Drawing.Point(18, 79)
		Me.CheckMirrorV.Name = "CheckMirrorV"
		Me.CheckMirrorV.Size = New System.Drawing.Size(98, 16)
		Me.CheckMirrorV.TabIndex = 15
		Me.CheckMirrorV.Text = "Vertical mirror"
		Me.CheckMirrorV.UseVisualStyleBackColor = True
		'
		'TrackExposure
		'
		Me.TrackExposure.AutoSize = False
		Me.TrackExposure.Location = New System.Drawing.Point(52, 45)
		Me.TrackExposure.Name = "TrackExposure"
		Me.TrackExposure.Size = New System.Drawing.Size(156, 19)
		Me.TrackExposure.TabIndex = 13
		Me.TrackExposure.TickFrequency = 0
		Me.TrackExposure.TickStyle = System.Windows.Forms.TickStyle.None
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(5, 45)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(42, 12)
		Me.Label5.TabIndex = 12
		Me.Label5.Text = "Shutter"
		'
		'TrackGainAll
		'
		Me.TrackGainAll.AutoSize = False
		Me.TrackGainAll.Location = New System.Drawing.Point(52, 20)
		Me.TrackGainAll.Name = "TrackGainAll"
		Me.TrackGainAll.Size = New System.Drawing.Size(156, 19)
		Me.TrackGainAll.TabIndex = 10
		Me.TrackGainAll.TickFrequency = 0
		Me.TrackGainAll.TickStyle = System.Windows.Forms.TickStyle.None
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(5, 20)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(28, 12)
		Me.Label4.TabIndex = 9
		Me.Label4.Text = "Gain"
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.NumericYSize)
		Me.GroupBox4.Controls.Add(Me.PictureColor)
		Me.GroupBox4.Controls.Add(Me.NumericXSize)
		Me.GroupBox4.Controls.Add(Me.TrackYSize)
		Me.GroupBox4.Controls.Add(Me.NumericYPos)
		Me.GroupBox4.Controls.Add(Me.Label9)
		Me.GroupBox4.Controls.Add(Me.NumericXPos)
		Me.GroupBox4.Controls.Add(Me.TrackXSize)
		Me.GroupBox4.Controls.Add(Me.Label8)
		Me.GroupBox4.Controls.Add(Me.TrackYPos)
		Me.GroupBox4.Controls.Add(Me.Label7)
		Me.GroupBox4.Controls.Add(Me.TrackXPos)
		Me.GroupBox4.Controls.Add(Me.Label6)
		Me.GroupBox4.Controls.Add(Me.CheckCursorOn)
		Me.GroupBox4.Controls.Add(Me.RadioCursor2)
		Me.GroupBox4.Controls.Add(Me.RadioCursor1)
		Me.GroupBox4.Location = New System.Drawing.Point(315, 12)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(295, 251)
		Me.GroupBox4.TabIndex = 3
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "Cross cursor settings"
		'
		'NumericYSize
		'
		Me.NumericYSize.Location = New System.Drawing.Point(228, 164)
		Me.NumericYSize.Name = "NumericYSize"
		Me.NumericYSize.Size = New System.Drawing.Size(49, 19)
		Me.NumericYSize.TabIndex = 12
		'
		'PictureColor
		'
		Me.PictureColor.Location = New System.Drawing.Point(19, 199)
		Me.PictureColor.Name = "PictureColor"
		Me.PictureColor.Size = New System.Drawing.Size(258, 35)
		Me.PictureColor.TabIndex = 15
		Me.PictureColor.TabStop = False
		'
		'NumericXSize
		'
		Me.NumericXSize.Location = New System.Drawing.Point(228, 139)
		Me.NumericXSize.Name = "NumericXSize"
		Me.NumericXSize.Size = New System.Drawing.Size(49, 19)
		Me.NumericXSize.TabIndex = 11
		'
		'TrackYSize
		'
		Me.TrackYSize.AutoSize = False
		Me.TrackYSize.Location = New System.Drawing.Point(67, 166)
		Me.TrackYSize.Name = "TrackYSize"
		Me.TrackYSize.Size = New System.Drawing.Size(156, 19)
		Me.TrackYSize.TabIndex = 13
		Me.TrackYSize.TickFrequency = 0
		Me.TrackYSize.TickStyle = System.Windows.Forms.TickStyle.None
		'
		'NumericYPos
		'
		Me.NumericYPos.Location = New System.Drawing.Point(228, 114)
		Me.NumericYPos.Name = "NumericYPos"
		Me.NumericYPos.Size = New System.Drawing.Size(49, 19)
		Me.NumericYPos.TabIndex = 10
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(20, 166)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(37, 12)
		Me.Label9.TabIndex = 12
		Me.Label9.Text = "Y Size"
		'
		'NumericXPos
		'
		Me.NumericXPos.Location = New System.Drawing.Point(228, 89)
		Me.NumericXPos.Name = "NumericXPos"
		Me.NumericXPos.Size = New System.Drawing.Size(49, 19)
		Me.NumericXPos.TabIndex = 9
		'
		'TrackXSize
		'
		Me.TrackXSize.AutoSize = False
		Me.TrackXSize.Location = New System.Drawing.Point(67, 141)
		Me.TrackXSize.Name = "TrackXSize"
		Me.TrackXSize.Size = New System.Drawing.Size(156, 19)
		Me.TrackXSize.TabIndex = 10
		Me.TrackXSize.TickFrequency = 0
		Me.TrackXSize.TickStyle = System.Windows.Forms.TickStyle.None
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(20, 141)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(37, 12)
		Me.Label8.TabIndex = 9
		Me.Label8.Text = "X Size"
		'
		'TrackYPos
		'
		Me.TrackYPos.AutoSize = False
		Me.TrackYPos.Location = New System.Drawing.Point(67, 116)
		Me.TrackYPos.Name = "TrackYPos"
		Me.TrackYPos.Size = New System.Drawing.Size(156, 19)
		Me.TrackYPos.TabIndex = 7
		Me.TrackYPos.TickFrequency = 0
		Me.TrackYPos.TickStyle = System.Windows.Forms.TickStyle.None
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(20, 116)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(35, 12)
		Me.Label7.TabIndex = 6
		Me.Label7.Text = "Y Pos"
		'
		'TrackXPos
		'
		Me.TrackXPos.AutoSize = False
		Me.TrackXPos.Location = New System.Drawing.Point(67, 91)
		Me.TrackXPos.Name = "TrackXPos"
		Me.TrackXPos.Size = New System.Drawing.Size(156, 19)
		Me.TrackXPos.TabIndex = 4
		Me.TrackXPos.TickFrequency = 0
		Me.TrackXPos.TickStyle = System.Windows.Forms.TickStyle.None
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(20, 91)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(35, 12)
		Me.Label6.TabIndex = 3
		Me.Label6.Text = "X Pos"
		'
		'CheckCursorOn
		'
		Me.CheckCursorOn.AutoSize = True
		Me.CheckCursorOn.Location = New System.Drawing.Point(19, 59)
		Me.CheckCursorOn.Name = "CheckCursorOn"
		Me.CheckCursorOn.Size = New System.Drawing.Size(106, 16)
		Me.CheckCursorOn.TabIndex = 2
		Me.CheckCursorOn.Text = "Cross cursor on"
		Me.CheckCursorOn.UseVisualStyleBackColor = True
		'
		'RadioCursor2
		'
		Me.RadioCursor2.AutoSize = True
		Me.RadioCursor2.Location = New System.Drawing.Point(143, 28)
		Me.RadioCursor2.Name = "RadioCursor2"
		Me.RadioCursor2.Size = New System.Drawing.Size(63, 16)
		Me.RadioCursor2.TabIndex = 1
		Me.RadioCursor2.TabStop = True
		Me.RadioCursor2.Text = "Cursor2"
		Me.RadioCursor2.UseVisualStyleBackColor = True
		'
		'RadioCursor1
		'
		Me.RadioCursor1.AutoSize = True
		Me.RadioCursor1.Location = New System.Drawing.Point(19, 27)
		Me.RadioCursor1.Name = "RadioCursor1"
		Me.RadioCursor1.Size = New System.Drawing.Size(63, 16)
		Me.RadioCursor1.TabIndex = 0
		Me.RadioCursor1.TabStop = True
		Me.RadioCursor1.Text = "Cursor1"
		Me.RadioCursor1.UseVisualStyleBackColor = True
		'
		'ButtonInitSettings
		'
		Me.ButtonInitSettings.Location = New System.Drawing.Point(13, 331)
		Me.ButtonInitSettings.Name = "ButtonInitSettings"
		Me.ButtonInitSettings.Size = New System.Drawing.Size(118, 37)
		Me.ButtonInitSettings.TabIndex = 4
		Me.ButtonInitSettings.Text = "Initialize Settings"
		Me.ButtonInitSettings.UseVisualStyleBackColor = True
		'
		'ButtonSaveSettings
		'
		Me.ButtonSaveSettings.Location = New System.Drawing.Point(158, 331)
		Me.ButtonSaveSettings.Name = "ButtonSaveSettings"
		Me.ButtonSaveSettings.Size = New System.Drawing.Size(118, 37)
		Me.ButtonSaveSettings.TabIndex = 5
		Me.ButtonSaveSettings.Text = "Write"
		Me.ButtonSaveSettings.UseVisualStyleBackColor = True
		'
		'ButtonOK
		'
		Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.ButtonOK.Location = New System.Drawing.Point(334, 345)
		Me.ButtonOK.Name = "ButtonOK"
		Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
		Me.ButtonOK.TabIndex = 6
		Me.ButtonOK.Text = "OK"
		Me.ButtonOK.UseVisualStyleBackColor = True
		'
		'ButtonDefault
		'
		Me.ButtonDefault.Location = New System.Drawing.Point(424, 344)
		Me.ButtonDefault.Name = "ButtonDefault"
		Me.ButtonDefault.Size = New System.Drawing.Size(75, 23)
		Me.ButtonDefault.TabIndex = 7
		Me.ButtonDefault.Text = "Default"
		Me.ButtonDefault.UseVisualStyleBackColor = True
		'
		'ButtonCancel
		'
		Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.ButtonCancel.Location = New System.Drawing.Point(518, 344)
		Me.ButtonCancel.Name = "ButtonCancel"
		Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
		Me.ButtonCancel.TabIndex = 8
		Me.ButtonCancel.Text = "Cancel"
		Me.ButtonCancel.UseVisualStyleBackColor = True
		'
		'Form7
		'
		Me.AcceptButton = Me.ButtonOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.ButtonCancel
		Me.ClientSize = New System.Drawing.Size(624, 385)
		Me.Controls.Add(Me.ButtonCancel)
		Me.Controls.Add(Me.ButtonDefault)
		Me.Controls.Add(Me.ButtonOK)
		Me.Controls.Add(Me.ButtonSaveSettings)
		Me.Controls.Add(Me.ButtonInitSettings)
		Me.Controls.Add(Me.GroupBox4)
		Me.Controls.Add(Me.GroupBox3)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Name = "Form7"
		Me.Text = "Monitor Settings"
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		CType(Me.NumericGainB, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TrackGainB, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.NumericGainG, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.NumericGainR, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TrackGainG, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TrackGainR, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox3.ResumeLayout(False)
		Me.GroupBox3.PerformLayout()
		CType(Me.NumericExposure, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.NumericGainAll, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TrackExposure, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TrackGainAll, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox4.ResumeLayout(False)
		Me.GroupBox4.PerformLayout()
		CType(Me.NumericYSize, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureColor, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.NumericXSize, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TrackYSize, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.NumericYPos, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.NumericXPos, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TrackXSize, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TrackYPos, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TrackXPos, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckAWB As System.Windows.Forms.CheckBox
    Friend WithEvents CheckColor As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TrackGainR As System.Windows.Forms.TrackBar
    Friend WithEvents TrackGainB As System.Windows.Forms.TrackBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TrackGainG As System.Windows.Forms.TrackBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TrackExposure As System.Windows.Forms.TrackBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TrackGainAll As System.Windows.Forms.TrackBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CheckMirrorV As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMirrorH As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioCursor2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioCursor1 As System.Windows.Forms.RadioButton
    Friend WithEvents TrackYSize As System.Windows.Forms.TrackBar
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TrackXSize As System.Windows.Forms.TrackBar
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TrackYPos As System.Windows.Forms.TrackBar
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TrackXPos As System.Windows.Forms.TrackBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckCursorOn As System.Windows.Forms.CheckBox
    Friend WithEvents PictureColor As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonInitSettings As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveSettings As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonDefault As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents NumericGainR As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericGainG As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericGainB As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericGainAll As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericExposure As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericXPos As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericYPos As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericXSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericYSize As System.Windows.Forms.NumericUpDown
End Class

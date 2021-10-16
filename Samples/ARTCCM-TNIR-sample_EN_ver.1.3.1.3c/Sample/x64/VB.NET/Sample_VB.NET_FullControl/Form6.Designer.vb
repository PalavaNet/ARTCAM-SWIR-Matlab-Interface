Imports Sample_VB.ArtCamSdk
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
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
		Me.checkCorrectionEnable = New System.Windows.Forms.CheckBox
		Me.checkDotfilterEnable = New System.Windows.Forms.CheckBox
		Me.buttonUpdateLow = New System.Windows.Forms.Button
		Me.buttonUpdateHigh = New System.Windows.Forms.Button
		Me.buttonSaveMask = New System.Windows.Forms.Button
		Me.buttonLoadMask = New System.Windows.Forms.Button
		Me.GroupBox1 = New System.Windows.Forms.GroupBox
		Me.buttonOK = New System.Windows.Forms.Button
		Me.GroupBox1.SuspendLayout()
		Me.SuspendLayout()
		'
		'checkCorrectionEnable
		'
		Me.checkCorrectionEnable.AutoSize = True
		Me.checkCorrectionEnable.Location = New System.Drawing.Point(33, 44)
		Me.checkCorrectionEnable.Name = "checkCorrectionEnable"
		Me.checkCorrectionEnable.Size = New System.Drawing.Size(156, 16)
		Me.checkCorrectionEnable.TabIndex = 0
		Me.checkCorrectionEnable.Text = "Effective mask correction"
		Me.checkCorrectionEnable.UseVisualStyleBackColor = True
		'
		'checkDotfilterEnable
		'
		Me.checkDotfilterEnable.AutoSize = True
		Me.checkDotfilterEnable.Location = New System.Drawing.Point(20, 46)
		Me.checkDotfilterEnable.Name = "checkDotfilterEnable"
		Me.checkDotfilterEnable.Size = New System.Drawing.Size(153, 16)
		Me.checkDotfilterEnable.TabIndex = 1
		Me.checkDotfilterEnable.Text = "Effective pixel correction"
		Me.checkDotfilterEnable.UseVisualStyleBackColor = True
		'
		'buttonUpdateLow
		'
		Me.buttonUpdateLow.Location = New System.Drawing.Point(20, 77)
		Me.buttonUpdateLow.Name = "buttonUpdateLow"
		Me.buttonUpdateLow.Size = New System.Drawing.Size(98, 33)
		Me.buttonUpdateLow.TabIndex = 2
		Me.buttonUpdateLow.Text = "Register(dark)"
		Me.buttonUpdateLow.UseVisualStyleBackColor = True
		'
		'buttonUpdateHigh
		'
		Me.buttonUpdateHigh.Location = New System.Drawing.Point(124, 77)
		Me.buttonUpdateHigh.Name = "buttonUpdateHigh"
		Me.buttonUpdateHigh.Size = New System.Drawing.Size(98, 33)
		Me.buttonUpdateHigh.TabIndex = 3
		Me.buttonUpdateHigh.Text = "Register(bright)"
		Me.buttonUpdateHigh.UseVisualStyleBackColor = True
		'
		'buttonSaveMask
		'
		Me.buttonSaveMask.Location = New System.Drawing.Point(20, 131)
		Me.buttonSaveMask.Name = "buttonSaveMask"
		Me.buttonSaveMask.Size = New System.Drawing.Size(98, 33)
		Me.buttonSaveMask.TabIndex = 4
		Me.buttonSaveMask.Text = "Save"
		Me.buttonSaveMask.UseVisualStyleBackColor = True
		'
		'buttonLoadMask
		'
		Me.buttonLoadMask.Location = New System.Drawing.Point(124, 131)
		Me.buttonLoadMask.Name = "buttonLoadMask"
		Me.buttonLoadMask.Size = New System.Drawing.Size(98, 33)
		Me.buttonLoadMask.TabIndex = 5
		Me.buttonLoadMask.Text = "Load"
		Me.buttonLoadMask.UseVisualStyleBackColor = True
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.checkDotfilterEnable)
		Me.GroupBox1.Controls.Add(Me.buttonLoadMask)
		Me.GroupBox1.Controls.Add(Me.buttonUpdateLow)
		Me.GroupBox1.Controls.Add(Me.buttonUpdateHigh)
		Me.GroupBox1.Controls.Add(Me.buttonSaveMask)
		Me.GroupBox1.Location = New System.Drawing.Point(13, 20)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(269, 184)
		Me.GroupBox1.TabIndex = 6
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Correction"
		'
		'buttonOK
		'
		Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.buttonOK.Location = New System.Drawing.Point(207, 214)
		Me.buttonOK.Name = "buttonOK"
		Me.buttonOK.Size = New System.Drawing.Size(75, 23)
		Me.buttonOK.TabIndex = 7
		Me.buttonOK.Text = "OK"
		Me.buttonOK.UseVisualStyleBackColor = True
		'
		'Form6
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(296, 249)
		Me.Controls.Add(Me.buttonOK)
		Me.Controls.Add(Me.checkCorrectionEnable)
		Me.Controls.Add(Me.GroupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Name = "Form6"
		Me.Text = "Correction setting"
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents checkCorrectionEnable As System.Windows.Forms.CheckBox
    Friend WithEvents checkDotfilterEnable As System.Windows.Forms.CheckBox
    Friend WithEvents buttonUpdateLow As System.Windows.Forms.Button
    Friend WithEvents buttonUpdateHigh As System.Windows.Forms.Button
    Friend WithEvents buttonSaveMask As System.Windows.Forms.Button
    Friend WithEvents buttonLoadMask As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents buttonOK As System.Windows.Forms.Button

	Public Sub New(ByVal a As CArtCam)
		
		' his call is required by the Windows Form Designer.
		InitializeComponent()
		
		' Add any initialization after the InitializeComponent() call.
        m_ArtCam = a
		
	End Sub
End Class

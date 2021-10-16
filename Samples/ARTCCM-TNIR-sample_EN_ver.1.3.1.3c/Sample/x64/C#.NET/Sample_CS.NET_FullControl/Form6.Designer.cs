namespace Sample_CS
{
	partial class Form6
	{
		/// <summary>
		/// Necessary designer variable 
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Execute after-treatment to resource used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// This method is required for designer support.
		/// Do not change the content of this method by code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.checkCorrectionEnable = new System.Windows.Forms.CheckBox();
			this.checkDotfilterEnable = new System.Windows.Forms.CheckBox();
			this.buttonUpdateLow = new System.Windows.Forms.Button();
			this.buttonUpdateHigh = new System.Windows.Forms.Button();
			this.buttonSaveMask = new System.Windows.Forms.Button();
			this.buttonLoadMask = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// checkCorrectionEnable
			// 
			this.checkCorrectionEnable.AutoSize = true;
			this.checkCorrectionEnable.Location = new System.Drawing.Point(26, 37);
			this.checkCorrectionEnable.Name = "checkCorrectionEnable";
			this.checkCorrectionEnable.Size = new System.Drawing.Size(156, 16);
			this.checkCorrectionEnable.TabIndex = 0;
			this.checkCorrectionEnable.Text = "Effective mask correction";
			this.checkCorrectionEnable.UseVisualStyleBackColor = true;
			this.checkCorrectionEnable.CheckedChanged += new System.EventHandler(this.checkCorrectionEnable_CheckedChanged);
			// 
			// checkDotfilterEnable
			// 
			this.checkDotfilterEnable.AutoSize = true;
			this.checkDotfilterEnable.Location = new System.Drawing.Point(13, 46);
			this.checkDotfilterEnable.Name = "checkDotfilterEnable";
			this.checkDotfilterEnable.Size = new System.Drawing.Size(153, 16);
			this.checkDotfilterEnable.TabIndex = 1;
			this.checkDotfilterEnable.Text = "Effective pixel correction";
			this.checkDotfilterEnable.UseVisualStyleBackColor = true;
			this.checkDotfilterEnable.CheckedChanged += new System.EventHandler(this.checkDotfilterEnable_CheckedChanged);
			// 
			// buttonUpdateLow
			// 
			this.buttonUpdateLow.Location = new System.Drawing.Point(13, 81);
			this.buttonUpdateLow.Name = "buttonUpdateLow";
			this.buttonUpdateLow.Size = new System.Drawing.Size(100, 34);
			this.buttonUpdateLow.TabIndex = 2;
			this.buttonUpdateLow.Text = "Register(dark)";
			this.buttonUpdateLow.UseVisualStyleBackColor = true;
			this.buttonUpdateLow.Click += new System.EventHandler(this.buttonUpdateLow_Click);
			// 
			// buttonUpdateHigh
			// 
			this.buttonUpdateHigh.Location = new System.Drawing.Point(119, 81);
			this.buttonUpdateHigh.Name = "buttonUpdateHigh";
			this.buttonUpdateHigh.Size = new System.Drawing.Size(99, 34);
			this.buttonUpdateHigh.TabIndex = 3;
			this.buttonUpdateHigh.Text = "Register(bright)";
			this.buttonUpdateHigh.UseVisualStyleBackColor = true;
			this.buttonUpdateHigh.Click += new System.EventHandler(this.buttonUpdateHigh_Click);
			// 
			// buttonSaveMask
			// 
			this.buttonSaveMask.Location = new System.Drawing.Point(13, 132);
			this.buttonSaveMask.Name = "buttonSaveMask";
			this.buttonSaveMask.Size = new System.Drawing.Size(100, 34);
			this.buttonSaveMask.TabIndex = 4;
			this.buttonSaveMask.Text = "Save";
			this.buttonSaveMask.UseVisualStyleBackColor = true;
			this.buttonSaveMask.Click += new System.EventHandler(this.buttonSaveMask_Click);
			// 
			// buttonLoadMask
			// 
			this.buttonLoadMask.Location = new System.Drawing.Point(119, 132);
			this.buttonLoadMask.Name = "buttonLoadMask";
			this.buttonLoadMask.Size = new System.Drawing.Size(99, 34);
			this.buttonLoadMask.TabIndex = 5;
			this.buttonLoadMask.Text = "Load";
			this.buttonLoadMask.UseVisualStyleBackColor = true;
			this.buttonLoadMask.Click += new System.EventHandler(this.buttonLoadMask_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(172, 199);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 6;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonSaveMask);
			this.groupBox1.Controls.Add(this.checkDotfilterEnable);
			this.groupBox1.Controls.Add(this.buttonUpdateHigh);
			this.groupBox1.Controls.Add(this.buttonLoadMask);
			this.groupBox1.Controls.Add(this.buttonUpdateLow);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(234, 180);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Correction";
			// 
			// Form6
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(274, 234);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.checkCorrectionEnable);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form6";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Correction setting";
			this.Load += new System.EventHandler(this.Form6_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkCorrectionEnable;
		private System.Windows.Forms.CheckBox checkDotfilterEnable;
		private System.Windows.Forms.Button buttonUpdateLow;
		private System.Windows.Forms.Button buttonUpdateHigh;
		private System.Windows.Forms.Button buttonSaveMask;
		private System.Windows.Forms.Button buttonLoadMask;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
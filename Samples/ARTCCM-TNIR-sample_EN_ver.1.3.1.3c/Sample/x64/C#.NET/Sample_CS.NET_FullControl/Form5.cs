using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ArtCamSdk;

namespace Sample_CS
{
	/// <summary>
	/// Outline of Form5
	/// </summary>
	public class Form5 : System.Windows.Forms.Form
	{
		private CArtCam m_CArtCam = null;

		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.TrackBar trackBar2;
		private System.Windows.Forms.TrackBar trackBar3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TrackBar trackBar4;
		private System.Windows.Forms.TrackBar trackBar5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.NumericUpDown numericUpDown3;
		private System.Windows.Forms.NumericUpDown numericUpDown4;
		private System.Windows.Forms.NumericUpDown numericUpDown5;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.CheckBox checkBox4;
		/// <summary>
		/// Necessary designer variable 
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form5(CArtCam a)
		{
			//
			// This is needed for Windows form designer support.
			//
			InitializeComponent();

			//
			// TODO: Add constructor code after calling InitializeComponent.
			//
			m_CArtCam = a;
		}

		/// <summary>
		/// Execute after-treatment to resource used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// This method is required for designer support.
		/// Do not change the content of this method by code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.trackBar3 = new System.Windows.Forms.TrackBar();
			this.trackBar2 = new System.Windows.Forms.TrackBar();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.trackBar5 = new System.Windows.Forms.TrackBar();
			this.trackBar4 = new System.Windows.Forms.TrackBar();
			this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
			this.button5 = new System.Windows.Forms.Button();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
			this.SuspendLayout();
			// 
			// ComboClock
			// 
			this.comboBox1.Items.AddRange(new object[] {
														   "16MHz",
														   "24MHz",
														   "48MHz"});
			this.comboBox1.Location = new System.Drawing.Point(16, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(128, 20);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.Text = "comboBox1";
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// ComboResolution
			// 
			this.comboBox2.Items.AddRange(new object[] {
																 "800 * 600",
														   "1024 * 768",
																 "1280 * 1024"});
			this.comboBox2.Location = new System.Drawing.Point(16, 48);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(128, 20);
			this.comboBox2.TabIndex = 1;
			this.comboBox2.Text = "comboBox2";
			this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(152, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 24);
			this.button1.TabIndex = 2;
			this.button1.Text = "Live";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(152, 48);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(64, 24);
			this.button2.TabIndex = 3;
			this.button2.Text = "Still";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(224, 8);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(80, 16);
			this.checkBox1.TabIndex = 4;
			this.checkBox1.Text = "Color";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(224, 32);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(80, 16);
			this.checkBox2.TabIndex = 6;
			this.checkBox2.Text = "AWB";
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(224, 56);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(88, 16);
			this.checkBox3.TabIndex = 8;
			this.checkBox3.Text = "Lock";
			this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.numericUpDown1,
																					this.label6,
																					this.label5,
																					this.label4,
																					this.trackBar3,
																					this.trackBar2,
																					this.trackBar1,
																					this.numericUpDown2,
																					this.numericUpDown3});
			this.groupBox1.Location = new System.Drawing.Point(16, 88);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(376, 168);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Bayer";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(312, 24);
			this.numericUpDown1.Maximum = new System.Decimal(new int[] {
																		   1023,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(56, 19);
			this.numericUpDown1.TabIndex = 9;
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 128);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 16);
			this.label6.TabIndex = 5;
			this.label6.Text = "B Gain";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "G Gain";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "R Gain";
			// 
			// trackBar3
			// 
			this.trackBar3.AutoSize = false;
			this.trackBar3.Location = new System.Drawing.Point(64, 120);
			this.trackBar3.Maximum = 1023;
			this.trackBar3.Name = "trackBar3";
			this.trackBar3.Size = new System.Drawing.Size(248, 42);
			this.trackBar3.TabIndex = 2;
			this.trackBar3.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
			// 
			// trackBar2
			// 
			this.trackBar2.AutoSize = false;
			this.trackBar2.Location = new System.Drawing.Point(64, 72);
			this.trackBar2.Maximum = 1023;
			this.trackBar2.Name = "trackBar2";
			this.trackBar2.Size = new System.Drawing.Size(248, 42);
			this.trackBar2.TabIndex = 1;
			this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
			// 
			// trackBar1
			// 
			this.trackBar1.AutoSize = false;
			this.trackBar1.Location = new System.Drawing.Point(64, 24);
			this.trackBar1.Maximum = 1023;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(248, 42);
			this.trackBar1.TabIndex = 0;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(312, 72);
			this.numericUpDown2.Maximum = new System.Decimal(new int[] {
																		   1023,
																		   0,
																		   0,
																		   0});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(56, 19);
			this.numericUpDown2.TabIndex = 9;
			this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
			// 
			// numericUpDown3
			// 
			this.numericUpDown3.Location = new System.Drawing.Point(312, 120);
			this.numericUpDown3.Maximum = new System.Decimal(new int[] {
																		   1023,
																		   0,
																		   0,
																		   0});
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(56, 19);
			this.numericUpDown3.TabIndex = 9;
			this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(584, 384);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 32);
			this.button3.TabIndex = 11;
			this.button3.Text = "Write";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.label8,
																					this.label7,
																					this.trackBar5,
																					this.trackBar4,
																					this.numericUpDown4,
																					this.numericUpDown5});
			this.groupBox2.Location = new System.Drawing.Point(16, 264);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(376, 112);
			this.groupBox2.TabIndex = 14;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Sensor";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 72);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 16);
			this.label8.TabIndex = 3;
			this.label8.Text = "Shutter";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 16);
			this.label7.TabIndex = 2;
			this.label7.Text = "Gain";
			// 
			// trackBar5
			// 
			this.trackBar5.AutoSize = false;
			this.trackBar5.Location = new System.Drawing.Point(64, 64);
			this.trackBar5.Maximum = 16383;
			this.trackBar5.Minimum = 1;
			this.trackBar5.Name = "trackBar5";
			this.trackBar5.Size = new System.Drawing.Size(248, 42);
			this.trackBar5.TabIndex = 1;
			this.trackBar5.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBar5.Value = 1;
			this.trackBar5.Scroll += new System.EventHandler(this.trackBar5_Scroll);
			// 
			// trackBar4
			// 
			this.trackBar4.AutoSize = false;
			this.trackBar4.Location = new System.Drawing.Point(64, 16);
			this.trackBar4.Maximum = 63;
			this.trackBar4.Name = "trackBar4";
			this.trackBar4.Size = new System.Drawing.Size(248, 42);
			this.trackBar4.TabIndex = 0;
			this.trackBar4.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
			// 
			// numericUpDown4
			// 
			this.numericUpDown4.Location = new System.Drawing.Point(312, 16);
			this.numericUpDown4.Maximum = new System.Decimal(new int[] {
																		   63,
																		   0,
																		   0,
																		   0});
			this.numericUpDown4.Name = "numericUpDown4";
			this.numericUpDown4.Size = new System.Drawing.Size(56, 19);
			this.numericUpDown4.TabIndex = 9;
			this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
			// 
			// numericUpDown5
			// 
			this.numericUpDown5.Location = new System.Drawing.Point(312, 64);
			this.numericUpDown5.Maximum = new System.Decimal(new int[] {
																		   16383,
																		   0,
																		   0,
																		   0});
			this.numericUpDown5.Minimum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.numericUpDown5.Name = "numericUpDown5";
			this.numericUpDown5.Size = new System.Drawing.Size(56, 19);
			this.numericUpDown5.TabIndex = 9;
			this.numericUpDown5.Value = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			this.numericUpDown5.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
			// 
			// button5
			// 
			this.button5.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button5.Location = new System.Drawing.Point(696, 384);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(96, 32);
			this.button5.TabIndex = 13;
			this.button5.Text = "Close";
			// 
			// checkBox4
			// 
			this.checkBox4.Location = new System.Drawing.Point(320, 56);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(64, 16);
			this.checkBox4.TabIndex = 10;
			this.checkBox4.Text = "Vflip";
			this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
			// 
			// Form5
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(402, 415);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox2,
																		  this.button5,
																		  this.groupBox1,
																		  this.checkBox3,
																		  this.checkBox2,
																		  this.checkBox1,
																		  this.button2,
																		  this.button1,
																		  this.comboBox2,
																		  this.comboBox1,
																		  this.button3,
																		  this.checkBox4});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form5";
			this.Text = "Form5";
			this.Load += new System.EventHandler(this.Form5_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Form5_Load(object sender, System.EventArgs e)
		{

			int MonitorColorMode = m_CArtCam.Monitor_GetColorMode();
			if(1 == MonitorColorMode) this.checkBox1.Checked = true;
			else
			{
				this.checkBox2.Enabled = false;
				this.checkBox3.Enabled = false;
			}

			int MonitorBayerGainAuto = m_CArtCam.Monitor_GetBayerGainAuto();
			if(1 == MonitorBayerGainAuto) this.checkBox2.Checked = true;
			else this.checkBox3.Enabled = false;

			int MonitorBayerGainLock = m_CArtCam.Monitor_GetBayerGainLock();
			if(1 == MonitorBayerGainLock) this.checkBox3.Checked = true;


			int MonitorBayerGainRed = m_CArtCam.Monitor_GetBayerGainRed();
			this.numericUpDown1.Value = this.trackBar1.Value = MonitorBayerGainRed;

			int MonitorBayerGainGreen = m_CArtCam.Monitor_GetBayerGainGreen();
			this.numericUpDown2.Value = this.trackBar2.Value = MonitorBayerGainGreen;
			

			int MonitorBayerGainBlue = m_CArtCam.Monitor_GetBayerGainBlue();
			this.numericUpDown3.Value = this.trackBar3.Value =  MonitorBayerGainBlue;

			int GlobalGain = m_CArtCam.GetGlobalGain();
			this.numericUpDown4.Value = this.trackBar4.Value = GlobalGain;
			int ExposureTime = m_CArtCam.GetExposureTime();
			this.numericUpDown5.Value = this.trackBar5.Value = ExposureTime;

			int MonitorCameraClock = m_CArtCam.Monitor_GetCameraClock();
			switch(MonitorCameraClock)
			{
				case 2 : this.comboBox1.SelectedIndex = 1; break;
				case 5 : this.comboBox1.SelectedIndex = 2; break;
				default: this.comboBox1.SelectedIndex = 0; break;
			}

			int MonWidth, MonHeight;
			m_CArtCam.Monitor_GetPreviewSize(out MonWidth , out MonHeight);
			
			if(800 == MonWidth || 600 == MonHeight)
				this.comboBox2.SelectedIndex = 0;
			else if(1024 == MonWidth || 768 == MonHeight)
				this.comboBox2.SelectedIndex = 1;
			else
				this.comboBox2.SelectedIndex = 2;

			bool Vflip = m_CArtCam.GetMirrorV();
				this.checkBox4.Checked = Vflip;


			}



		private void trackBar1_Scroll(object sender, System.EventArgs e)
		{
			this.numericUpDown1.Value = this.trackBar1.Value;
			m_CArtCam.Monitor_SetBayerGainRed(this.trackBar1.Value);

		}

		private void trackBar2_Scroll(object sender, System.EventArgs e)
		{
			this.numericUpDown2.Value = this.trackBar2.Value;
			m_CArtCam.Monitor_SetBayerGainGreen(this.trackBar2.Value);
		}
		
		private void trackBar3_Scroll(object sender, System.EventArgs e)
		{
			this.numericUpDown3.Value = this.trackBar3.Value;
			m_CArtCam.Monitor_SetBayerGainBlue(this.trackBar3.Value);
			}

		private void trackBar4_Scroll(object sender, System.EventArgs e)
		{
			this.numericUpDown4.Value = this.trackBar4.Value;
			m_CArtCam.SetGlobalGain(this.trackBar4.Value);
		}

		private void trackBar5_Scroll(object sender, System.EventArgs e)
		{
			this.numericUpDown5.Value = this.trackBar5.Value;
			m_CArtCam.SetExposureTime(this.trackBar5.Value);
		}
		private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
		{
			this.trackBar1.Value = (int)this.numericUpDown1.Value;
			m_CArtCam.Monitor_SetBayerGainRed((int)this.numericUpDown1.Value);
		}

		private void numericUpDown2_ValueChanged(object sender, System.EventArgs e)
		{
			this.trackBar2.Value = (int)this.numericUpDown2.Value;
			m_CArtCam.Monitor_SetBayerGainGreen((int)this.numericUpDown2.Value);
		}

		private void numericUpDown3_ValueChanged(object sender, System.EventArgs e)
		{
			this.trackBar3.Value = (int)this.numericUpDown3.Value;
			m_CArtCam.Monitor_SetBayerGainBlue((int)this.numericUpDown3.Value);
		}

		private void numericUpDown4_ValueChanged(object sender, System.EventArgs e)
		{
			this.trackBar4.Value = (int)this.numericUpDown4.Value;
			m_CArtCam.SetGlobalGain((int)this.numericUpDown4.Value);
		}


		private void numericUpDown5_ValueChanged(object sender, System.EventArgs e)
		{
			this.trackBar5.Value = (int)this.numericUpDown5.Value;
			m_CArtCam.SetExposureTime((int)this.numericUpDown5.Value);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			m_CArtCam.Monitor_SetPreviewMode(1);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			m_CArtCam.Monitor_SetPreviewMode(0);
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if		(this.comboBox1.SelectedIndex == 0)
				m_CArtCam.Monitor_SetCameraClock(0);
			else if	(this.comboBox1.SelectedIndex == 1)
				m_CArtCam.Monitor_SetCameraClock(1);
			else
				m_CArtCam.Monitor_SetCameraClock(2);
		}

		private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if		(this.comboBox2.SelectedIndex == 0)
				m_CArtCam.Monitor_SetPreviewSize(800,600);
			else if(this.comboBox2.SelectedIndex == 1)
				m_CArtCam.Monitor_SetPreviewSize(1024,768);
			else
				m_CArtCam.Monitor_SetPreviewSize(1280,1024);
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			int Flg = (true == this.checkBox1.Checked) ? 1 : 0 ;
			m_CArtCam.Monitor_SetColorMode(Flg);
				this.checkBox2.Enabled = this.checkBox1.Checked;
				this.checkBox3.Enabled = this.checkBox1.Checked;
		}

		private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			int Flg = (true == this.checkBox2.Checked) ? 1: 0;
				m_CArtCam.Monitor_SetBayerGainAuto(Flg);
			this.checkBox3.Enabled = this.checkBox2.Checked;

			int MonitorBayerGainRed = m_CArtCam.Monitor_GetBayerGainRed();
			this.numericUpDown1.Value = this.trackBar1.Value = MonitorBayerGainRed;

			int MonitorBayerGainGreen = m_CArtCam.Monitor_GetBayerGainGreen();
			this.numericUpDown2.Value = this.trackBar2.Value = MonitorBayerGainGreen;
			

			int MonitorBayerGainBlue = m_CArtCam.Monitor_GetBayerGainBlue();
			this.numericUpDown3.Value = this.trackBar3.Value =  MonitorBayerGainBlue;

			this.numericUpDown1.Enabled = !this.checkBox2.Checked;
			this.numericUpDown2.Enabled = !this.checkBox2.Checked;
			this.numericUpDown3.Enabled = !this.checkBox2.Checked;
			this.trackBar1.Enabled = !this.checkBox2.Checked;
			this.trackBar2.Enabled = !this.checkBox2.Checked;
			this.trackBar3.Enabled = !this.checkBox2.Checked;

		}

		private void checkBox3_CheckedChanged(object sender, System.EventArgs e)
		{
			int Flg = (true == this.checkBox3.Checked) ? 1: 0;
			m_CArtCam.Monitor_SetBayerGainLock(Flg);
		}

		private void checkBox4_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetMirrorV(checkBox4.Checked);
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			int ExposureTime = m_CArtCam.GetExposureTime();
			int GlobalGain	 = m_CArtCam.GetGlobalGain();
			int MirrorV		 = m_CArtCam.ReadRegister(0x20);
			
			m_CArtCam.Fpga_WriteRegister(0xB6, 0x03);

			m_CArtCam.Fpga_WriteRegister(0xC0, 0x09);
			m_CArtCam.Fpga_WriteRegister(0xC1, (int)(ExposureTime >> 8));
			m_CArtCam.Fpga_WriteRegister(0xC2, (int)ExposureTime);

			m_CArtCam.Fpga_WriteRegister(0xC3, 0x35);
			m_CArtCam.Fpga_WriteRegister(0xC4, (int)(GlobalGain >> 8));
			m_CArtCam.Fpga_WriteRegister(0xC5, (int)GlobalGain);

				m_CArtCam.Fpga_WriteRegister(0xC6, 0x20);
				m_CArtCam.Fpga_WriteRegister(0xC7, (int)MirrorV >> 8);
				m_CArtCam.Fpga_WriteRegister(0xC8, (int)MirrorV);
			

            int wReg0xE4 = m_CArtCam.Fpga_ReadRegister(0xE4);
			wReg0xE4 |= 0x0001;
			m_CArtCam.Fpga_WriteRegister(0xE4, wReg0xE4);
			wReg0xE4 &= 0xFFFE;
			m_CArtCam.Fpga_WriteRegister(0xE4, wReg0xE4);

		}
	
	}
}

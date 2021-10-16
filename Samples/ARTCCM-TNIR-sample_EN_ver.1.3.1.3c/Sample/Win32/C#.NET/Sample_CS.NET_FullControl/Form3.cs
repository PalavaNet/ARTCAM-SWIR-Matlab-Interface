using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ArtCamSdk;


namespace Sample_CS
{
	/// <summary>
	/// Outline of Form3
	/// </summary>
	public class Form3 : System.Windows.Forms.Form
	{
		private ARTCAM_CAMERATYPE m_DllType = 0;
		private CArtCam m_CArtCam = null;
		private int m_Preview = -1;
		private CAMERAINFO m_CameraInfo;
		internal System.Windows.Forms.GroupBox groupBox8;
		internal System.Windows.Forms.RadioButton radioChannel6;
		internal System.Windows.Forms.RadioButton radioChannel5;
		internal System.Windows.Forms.RadioButton radioChannel4;
		internal System.Windows.Forms.RadioButton radioChannel3;
		internal System.Windows.Forms.RadioButton radioChannel2;
		internal System.Windows.Forms.RadioButton radioChannel1;
		internal System.Windows.Forms.GroupBox groupBox2;
		internal System.Windows.Forms.GroupBox groupBox4;
		internal System.Windows.Forms.NumericUpDown UpDownBayerGainB;
		internal System.Windows.Forms.Label label9;
		internal System.Windows.Forms.NumericUpDown UpDownBayerGainG;
		internal System.Windows.Forms.Label label8;
		internal System.Windows.Forms.NumericUpDown UpDownBayerGainR;
		internal System.Windows.Forms.Label label7;
		internal System.Windows.Forms.GroupBox groupBox3;
		internal System.Windows.Forms.RadioButton radioBayer4;
		internal System.Windows.Forms.RadioButton radioBayer3;
		internal System.Windows.Forms.RadioButton radioBayer2;
		internal System.Windows.Forms.RadioButton radioBayer1;
		internal System.Windows.Forms.CheckBox checkAWB;
		internal System.Windows.Forms.GroupBox groupBox7;
		internal System.Windows.Forms.CheckBox checkMirrorH;
		internal System.Windows.Forms.CheckBox checkMirrorV;
		internal System.Windows.Forms.GroupBox groupBox1;
		internal System.Windows.Forms.NumericUpDown UpDownGamma;
		internal System.Windows.Forms.Label label6;
		internal System.Windows.Forms.NumericUpDown UpDownSharpness;
		internal System.Windows.Forms.Label label5;
		internal System.Windows.Forms.NumericUpDown UpDownSaturation;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.NumericUpDown UpDownHue;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.NumericUpDown UpDownContrast;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.NumericUpDown UpDownBrightness;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.GroupBox groupBox6;
		internal System.Windows.Forms.RadioButton radioAI3;
		internal System.Windows.Forms.RadioButton radioAI2;
		internal System.Windows.Forms.RadioButton radioAI1;
		internal System.Windows.Forms.CheckBox checkHalfClock;
		internal System.Windows.Forms.GroupBox groupBox5;
		internal System.Windows.Forms.NumericUpDown UpDownExposureTime;
		internal System.Windows.Forms.Label label10;
		internal System.Windows.Forms.NumericUpDown UpDownColorGainB;
		internal System.Windows.Forms.Label label11;
		internal System.Windows.Forms.NumericUpDown UpDownColorGainG2;
		internal System.Windows.Forms.Label label12;
		internal System.Windows.Forms.NumericUpDown UpDownColorGainG1;
		internal System.Windows.Forms.Label label13;
		internal System.Windows.Forms.NumericUpDown UpDownColorGainR;
		internal System.Windows.Forms.Label label14;
		internal System.Windows.Forms.NumericUpDown UpDownGlobalGain;
		internal System.Windows.Forms.Label label15;
		internal System.Windows.Forms.Button button1;
		/// <summary>
		/// Necessary designer variable 
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form3(CArtCam a, int p)
		{
			//
			// This is needed for Windows form designer support.
			//
			InitializeComponent();

			//
			// TODO: Add constructor code after calling InitializeComponent.
			//
			m_CArtCam = a;
			m_Preview = p;
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
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.radioChannel6 = new System.Windows.Forms.RadioButton();
			this.radioChannel5 = new System.Windows.Forms.RadioButton();
			this.radioChannel4 = new System.Windows.Forms.RadioButton();
			this.radioChannel3 = new System.Windows.Forms.RadioButton();
			this.radioChannel2 = new System.Windows.Forms.RadioButton();
			this.radioChannel1 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.UpDownBayerGainB = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.UpDownBayerGainG = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.UpDownBayerGainR = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.radioBayer4 = new System.Windows.Forms.RadioButton();
			this.radioBayer3 = new System.Windows.Forms.RadioButton();
			this.radioBayer2 = new System.Windows.Forms.RadioButton();
			this.radioBayer1 = new System.Windows.Forms.RadioButton();
			this.checkAWB = new System.Windows.Forms.CheckBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.checkMirrorH = new System.Windows.Forms.CheckBox();
			this.checkMirrorV = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.UpDownGamma = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.UpDownSharpness = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.UpDownSaturation = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.UpDownHue = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.UpDownContrast = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.UpDownBrightness = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.radioAI3 = new System.Windows.Forms.RadioButton();
			this.radioAI2 = new System.Windows.Forms.RadioButton();
			this.radioAI1 = new System.Windows.Forms.RadioButton();
			this.checkHalfClock = new System.Windows.Forms.CheckBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.UpDownExposureTime = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.UpDownColorGainB = new System.Windows.Forms.NumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.UpDownColorGainG2 = new System.Windows.Forms.NumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.UpDownColorGainG1 = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.UpDownColorGainR = new System.Windows.Forms.NumericUpDown();
			this.label14 = new System.Windows.Forms.Label();
			this.UpDownGlobalGain = new System.Windows.Forms.NumericUpDown();
			this.label15 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox8.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.UpDownBayerGainB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownBayerGainG)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownBayerGainR)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.UpDownGamma)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownSharpness)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownSaturation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownHue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownContrast)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownBrightness)).BeginInit();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.UpDownExposureTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownColorGainB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownColorGainG2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownColorGainG1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownColorGainR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownGlobalGain)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.radioChannel6);
			this.groupBox8.Controls.Add(this.radioChannel5);
			this.groupBox8.Controls.Add(this.radioChannel4);
			this.groupBox8.Controls.Add(this.radioChannel3);
			this.groupBox8.Controls.Add(this.radioChannel2);
			this.groupBox8.Controls.Add(this.radioChannel1);
			this.groupBox8.Location = new System.Drawing.Point(368, 247);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(152, 96);
			this.groupBox8.TabIndex = 30;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Display channel(CNV)";
			// 
			// radioChannel6
			// 
			this.radioChannel6.Location = new System.Drawing.Point(96, 56);
			this.radioChannel6.Name = "radioChannel6";
			this.radioChannel6.Size = new System.Drawing.Size(24, 16);
			this.radioChannel6.TabIndex = 5;
			this.radioChannel6.Text = "6";
			this.radioChannel6.CheckedChanged += new System.EventHandler(this.radioChannel6_CheckedChanged);
			// 
			// radioChannel5
			// 
			this.radioChannel5.Location = new System.Drawing.Point(56, 56);
			this.radioChannel5.Name = "radioChannel5";
			this.radioChannel5.Size = new System.Drawing.Size(24, 16);
			this.radioChannel5.TabIndex = 4;
			this.radioChannel5.Text = "5";
			this.radioChannel5.CheckedChanged += new System.EventHandler(this.radioChannel5_CheckedChanged);
			// 
			// radioChannel4
			// 
			this.radioChannel4.Location = new System.Drawing.Point(16, 56);
			this.radioChannel4.Name = "radioChannel4";
			this.radioChannel4.Size = new System.Drawing.Size(24, 16);
			this.radioChannel4.TabIndex = 3;
			this.radioChannel4.Text = "4";
			this.radioChannel4.CheckedChanged += new System.EventHandler(this.radioChannel4_CheckedChanged);
			// 
			// radioChannel3
			// 
			this.radioChannel3.Location = new System.Drawing.Point(96, 24);
			this.radioChannel3.Name = "radioChannel3";
			this.radioChannel3.Size = new System.Drawing.Size(24, 16);
			this.radioChannel3.TabIndex = 2;
			this.radioChannel3.Text = "3";
			this.radioChannel3.CheckedChanged += new System.EventHandler(this.radioChannel3_CheckedChanged);
			// 
			// radioChannel2
			// 
			this.radioChannel2.Location = new System.Drawing.Point(56, 24);
			this.radioChannel2.Name = "radioChannel2";
			this.radioChannel2.Size = new System.Drawing.Size(24, 16);
			this.radioChannel2.TabIndex = 1;
			this.radioChannel2.Text = "2";
			this.radioChannel2.CheckedChanged += new System.EventHandler(this.radioChannel2_CheckedChanged);
			// 
			// radioChannel1
			// 
			this.radioChannel1.Location = new System.Drawing.Point(16, 24);
			this.radioChannel1.Name = "radioChannel1";
			this.radioChannel1.Size = new System.Drawing.Size(24, 16);
			this.radioChannel1.TabIndex = 0;
			this.radioChannel1.Text = "1";
			this.radioChannel1.CheckedChanged += new System.EventHandler(this.radioChannel1_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.groupBox4);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Controls.Add(this.checkAWB);
			this.groupBox2.Location = new System.Drawing.Point(8, 247);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 264);
			this.groupBox2.TabIndex = 25;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Color conversion";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.UpDownBayerGainB);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.UpDownBayerGainG);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.UpDownBayerGainR);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Location = new System.Drawing.Point(24, 128);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(144, 120);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Bayer conversion gain";
			// 
			// UpDownBayerGainB
			// 
			this.UpDownBayerGainB.Location = new System.Drawing.Point(56, 88);
			this.UpDownBayerGainB.Name = "UpDownBayerGainB";
			this.UpDownBayerGainB.Size = new System.Drawing.Size(64, 19);
			this.UpDownBayerGainB.TabIndex = 17;
			this.UpDownBayerGainB.ValueChanged += new System.EventHandler(this.UpDownBayerGainB_ValueChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(9, 88);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 16);
			this.label9.TabIndex = 16;
			this.label9.Text = "Blue";
			// 
			// UpDownBayerGainG
			// 
			this.UpDownBayerGainG.Location = new System.Drawing.Point(56, 56);
			this.UpDownBayerGainG.Name = "UpDownBayerGainG";
			this.UpDownBayerGainG.Size = new System.Drawing.Size(64, 19);
			this.UpDownBayerGainG.TabIndex = 15;
			this.UpDownBayerGainG.ValueChanged += new System.EventHandler(this.UpDownBayerGainG_ValueChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(9, 56);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 16);
			this.label8.TabIndex = 14;
			this.label8.Text = "Green";
			// 
			// UpDownBayerGainR
			// 
			this.UpDownBayerGainR.Location = new System.Drawing.Point(56, 24);
			this.UpDownBayerGainR.Name = "UpDownBayerGainR";
			this.UpDownBayerGainR.Size = new System.Drawing.Size(64, 19);
			this.UpDownBayerGainR.TabIndex = 13;
			this.UpDownBayerGainR.ValueChanged += new System.EventHandler(this.UpDownBayerGainR_ValueChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(9, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 19);
			this.label7.TabIndex = 12;
			this.label7.Text = "Red";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.radioBayer4);
			this.groupBox3.Controls.Add(this.radioBayer3);
			this.groupBox3.Controls.Add(this.radioBayer2);
			this.groupBox3.Controls.Add(this.radioBayer1);
			this.groupBox3.Location = new System.Drawing.Point(24, 56);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(144, 56);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Bayer conversion mode";
			// 
			// radioBayer4
			// 
			this.radioBayer4.Location = new System.Drawing.Point(112, 24);
			this.radioBayer4.Name = "radioBayer4";
			this.radioBayer4.Size = new System.Drawing.Size(16, 16);
			this.radioBayer4.TabIndex = 6;
			this.radioBayer4.CheckedChanged += new System.EventHandler(this.radioBayer4_CheckedChanged);
			// 
			// radioBayer3
			// 
			this.radioBayer3.Location = new System.Drawing.Point(80, 24);
			this.radioBayer3.Name = "radioBayer3";
			this.radioBayer3.Size = new System.Drawing.Size(16, 16);
			this.radioBayer3.TabIndex = 5;
			this.radioBayer3.CheckedChanged += new System.EventHandler(this.radioBayer3_CheckedChanged);
			// 
			// radioBayer2
			// 
			this.radioBayer2.Location = new System.Drawing.Point(48, 24);
			this.radioBayer2.Name = "radioBayer2";
			this.radioBayer2.Size = new System.Drawing.Size(16, 16);
			this.radioBayer2.TabIndex = 4;
			this.radioBayer2.CheckedChanged += new System.EventHandler(this.radioBayer2_CheckedChanged);
			// 
			// radioBayer1
			// 
			this.radioBayer1.Location = new System.Drawing.Point(16, 24);
			this.radioBayer1.Name = "radioBayer1";
			this.radioBayer1.Size = new System.Drawing.Size(16, 16);
			this.radioBayer1.TabIndex = 3;
			this.radioBayer1.CheckedChanged += new System.EventHandler(this.radioBayer1_CheckedChanged);
			// 
			// checkAWB
			// 
			this.checkAWB.Location = new System.Drawing.Point(24, 24);
			this.checkAWB.Name = "checkAWB";
			this.checkAWB.Size = new System.Drawing.Size(128, 16);
			this.checkAWB.TabIndex = 0;
			this.checkAWB.Text = "Auto white balance";
			this.checkAWB.CheckedChanged += new System.EventHandler(this.checkAWB_CheckedChanged);
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.checkMirrorH);
			this.groupBox7.Controls.Add(this.checkMirrorV);
			this.groupBox7.Location = new System.Drawing.Point(232, 359);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(120, 56);
			this.groupBox7.TabIndex = 28;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Mirror reversal";
			// 
			// checkMirrorH
			// 
			this.checkMirrorH.Location = new System.Drawing.Point(64, 24);
			this.checkMirrorH.Name = "checkMirrorH";
			this.checkMirrorH.Size = new System.Drawing.Size(32, 16);
			this.checkMirrorH.TabIndex = 1;
			this.checkMirrorH.Text = "Horizon";
			this.checkMirrorH.CheckedChanged += new System.EventHandler(this.checkMirrorH_CheckedChanged);
			// 
			// checkMirrorV
			// 
			this.checkMirrorV.Location = new System.Drawing.Point(16, 24);
			this.checkMirrorV.Name = "checkMirrorV";
			this.checkMirrorV.Size = new System.Drawing.Size(32, 16);
			this.checkMirrorV.TabIndex = 0;
			this.checkMirrorV.Text = "Vertical";
			this.checkMirrorV.CheckedChanged += new System.EventHandler(this.checkMirrorV_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.UpDownGamma);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.UpDownSharpness);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.UpDownSaturation);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.UpDownHue);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.UpDownContrast);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.UpDownBrightness);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 216);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Picture filter";
			// 
			// UpDownGamma
			// 
			this.UpDownGamma.Location = new System.Drawing.Point(96, 184);
			this.UpDownGamma.Name = "UpDownGamma";
			this.UpDownGamma.Size = new System.Drawing.Size(64, 19);
			this.UpDownGamma.TabIndex = 11;
			this.UpDownGamma.ValueChanged += new System.EventHandler(this.UpDownGamma_ValueChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(24, 184);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Gamma";
			// 
			// UpDownSharpness
			// 
			this.UpDownSharpness.Location = new System.Drawing.Point(96, 152);
			this.UpDownSharpness.Name = "UpDownSharpness";
			this.UpDownSharpness.Size = new System.Drawing.Size(64, 19);
			this.UpDownSharpness.TabIndex = 9;
			this.UpDownSharpness.ValueChanged += new System.EventHandler(this.UpDownSharpness_ValueChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 11);
			this.label5.TabIndex = 8;
			this.label5.Text = "Sharpness";
			// 
			// UpDownSaturation
			// 
			this.UpDownSaturation.Location = new System.Drawing.Point(96, 120);
			this.UpDownSaturation.Name = "UpDownSaturation";
			this.UpDownSaturation.Size = new System.Drawing.Size(64, 19);
			this.UpDownSaturation.TabIndex = 7;
			this.UpDownSaturation.ValueChanged += new System.EventHandler(this.UpDownSaturation_ValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 19);
			this.label4.TabIndex = 6;
			this.label4.Text = "Saturation";
			// 
			// UpDownHue
			// 
			this.UpDownHue.Location = new System.Drawing.Point(96, 88);
			this.UpDownHue.Name = "UpDownHue";
			this.UpDownHue.Size = new System.Drawing.Size(64, 19);
			this.UpDownHue.TabIndex = 5;
			this.UpDownHue.ValueChanged += new System.EventHandler(this.UpDownHue_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Hue";
			// 
			// UpDownContrast
			// 
			this.UpDownContrast.Location = new System.Drawing.Point(96, 56);
			this.UpDownContrast.Name = "UpDownContrast";
			this.UpDownContrast.Size = new System.Drawing.Size(64, 19);
			this.UpDownContrast.TabIndex = 3;
			this.UpDownContrast.ValueChanged += new System.EventHandler(this.UpDownContrast_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Contrast";
			// 
			// UpDownBrightness
			// 
			this.UpDownBrightness.Location = new System.Drawing.Point(96, 24);
			this.UpDownBrightness.Name = "UpDownBrightness";
			this.UpDownBrightness.Size = new System.Drawing.Size(64, 19);
			this.UpDownBrightness.TabIndex = 1;
			this.UpDownBrightness.ValueChanged += new System.EventHandler(this.UpDownBrightness_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Brightness";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.radioAI3);
			this.groupBox6.Controls.Add(this.radioAI2);
			this.groupBox6.Controls.Add(this.radioAI1);
			this.groupBox6.Location = new System.Drawing.Point(232, 247);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(120, 96);
			this.groupBox6.TabIndex = 27;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Auto iris";
			// 
			// radioAI3
			// 
			this.radioAI3.Location = new System.Drawing.Point(16, 72);
			this.radioAI3.Name = "radioAI3";
			this.radioAI3.Size = new System.Drawing.Size(56, 16);
			this.radioAI3.TabIndex = 2;
			this.radioAI3.Text = "Gain";
			this.radioAI3.CheckedChanged += new System.EventHandler(this.radioAI3_CheckedChanged);
			// 
			// radioAI2
			// 
			this.radioAI2.Location = new System.Drawing.Point(16, 48);
			this.radioAI2.Name = "radioAI2";
			this.radioAI2.Size = new System.Drawing.Size(72, 16);
			this.radioAI2.TabIndex = 1;
			this.radioAI2.Text = "Shutter";
			this.radioAI2.CheckedChanged += new System.EventHandler(this.radioAI2_CheckedChanged);
			// 
			// radioAI1
			// 
			this.radioAI1.Location = new System.Drawing.Point(16, 24);
			this.radioAI1.Name = "radioAI1";
			this.radioAI1.Size = new System.Drawing.Size(56, 16);
			this.radioAI1.TabIndex = 0;
			this.radioAI1.Text = "Invalid";
			this.radioAI1.CheckedChanged += new System.EventHandler(this.radioAI1_CheckedChanged);
			// 
			// checkHalfClock
			// 
			this.checkHalfClock.Location = new System.Drawing.Point(248, 431);
			this.checkHalfClock.Name = "checkHalfClock";
			this.checkHalfClock.Size = new System.Drawing.Size(88, 16);
			this.checkHalfClock.TabIndex = 29;
			this.checkHalfClock.Text = "Half clock";
			this.checkHalfClock.CheckedChanged += new System.EventHandler(this.checkHalfClock_CheckedChanged);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.UpDownExposureTime);
			this.groupBox5.Controls.Add(this.label10);
			this.groupBox5.Controls.Add(this.UpDownColorGainB);
			this.groupBox5.Controls.Add(this.label11);
			this.groupBox5.Controls.Add(this.UpDownColorGainG2);
			this.groupBox5.Controls.Add(this.label12);
			this.groupBox5.Controls.Add(this.UpDownColorGainG1);
			this.groupBox5.Controls.Add(this.label13);
			this.groupBox5.Controls.Add(this.UpDownColorGainR);
			this.groupBox5.Controls.Add(this.label14);
			this.groupBox5.Controls.Add(this.UpDownGlobalGain);
			this.groupBox5.Controls.Add(this.label15);
			this.groupBox5.Location = new System.Drawing.Point(232, 7);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(288, 216);
			this.groupBox5.TabIndex = 26;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Camera settings";
			// 
			// UpDownExposureTime
			// 
			this.UpDownExposureTime.Location = new System.Drawing.Point(192, 176);
			this.UpDownExposureTime.Name = "UpDownExposureTime";
			this.UpDownExposureTime.Size = new System.Drawing.Size(64, 19);
			this.UpDownExposureTime.TabIndex = 23;
			this.UpDownExposureTime.ValueChanged += new System.EventHandler(this.UpDownExposureTime_ValueChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(24, 179);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(162, 16);
			this.label10.TabIndex = 22;
			this.label10.Text = "Exposure time(Shutter speed)";
			// 
			// UpDownColorGainB
			// 
			this.UpDownColorGainB.Location = new System.Drawing.Point(192, 144);
			this.UpDownColorGainB.Name = "UpDownColorGainB";
			this.UpDownColorGainB.Size = new System.Drawing.Size(64, 19);
			this.UpDownColorGainB.TabIndex = 21;
			this.UpDownColorGainB.ValueChanged += new System.EventHandler(this.UpDownColorGainB_ValueChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(24, 147);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(136, 24);
			this.label11.TabIndex = 20;
			this.label11.Text = "Color gain(Blue)";
			// 
			// UpDownColorGainG2
			// 
			this.UpDownColorGainG2.Location = new System.Drawing.Point(192, 112);
			this.UpDownColorGainG2.Name = "UpDownColorGainG2";
			this.UpDownColorGainG2.Size = new System.Drawing.Size(64, 19);
			this.UpDownColorGainG2.TabIndex = 19;
			this.UpDownColorGainG2.ValueChanged += new System.EventHandler(this.UpDownColorGainG2_ValueChanged);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(24, 115);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(124, 16);
			this.label12.TabIndex = 18;
			this.label12.Text = "Color gain(Green 2)";
			// 
			// UpDownColorGainG1
			// 
			this.UpDownColorGainG1.Location = new System.Drawing.Point(192, 80);
			this.UpDownColorGainG1.Name = "UpDownColorGainG1";
			this.UpDownColorGainG1.Size = new System.Drawing.Size(64, 19);
			this.UpDownColorGainG1.TabIndex = 17;
			this.UpDownColorGainG1.ValueChanged += new System.EventHandler(this.UpDownColorGainG1_ValueChanged);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(24, 83);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(124, 24);
			this.label13.TabIndex = 16;
			this.label13.Text = "Color gain(green 1)";
			// 
			// UpDownColorGainR
			// 
			this.UpDownColorGainR.Location = new System.Drawing.Point(192, 48);
			this.UpDownColorGainR.Name = "UpDownColorGainR";
			this.UpDownColorGainR.Size = new System.Drawing.Size(64, 19);
			this.UpDownColorGainR.TabIndex = 15;
			this.UpDownColorGainR.ValueChanged += new System.EventHandler(this.UpDownColorGainR_ValueChanged);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(24, 51);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(124, 16);
			this.label14.TabIndex = 14;
			this.label14.Text = "Color gain(Red)";
			// 
			// UpDownGlobalGain
			// 
			this.UpDownGlobalGain.Location = new System.Drawing.Point(192, 16);
			this.UpDownGlobalGain.Name = "UpDownGlobalGain";
			this.UpDownGlobalGain.Size = new System.Drawing.Size(64, 19);
			this.UpDownGlobalGain.TabIndex = 13;
			this.UpDownGlobalGain.ValueChanged += new System.EventHandler(this.UpDownGlobalGain_ValueChanged);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(24, 19);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(88, 16);
			this.label15.TabIndex = 12;
			this.label15.Text = "Global gain";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(448, 488);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 31;
			this.button1.Text = "Close";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form3
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(530, 519);
			this.Controls.Add(this.groupBox8);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox7);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.checkHalfClock);
			this.Controls.Add(this.groupBox5);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form3";
			this.Text = "Filter settings";
			this.Load += new System.EventHandler(this.Form3_Load);
			this.groupBox8.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.UpDownBayerGainB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownBayerGainG)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownBayerGainR)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.UpDownGamma)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownSharpness)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownSaturation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownHue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownContrast)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownBrightness)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.UpDownExposureTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownColorGainB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownColorGainG2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownColorGainG1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownColorGainR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpDownGlobalGain)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Form3_Load(object sender, System.EventArgs e)
		{
			// Change operation for each DLL
			// For each DLL function, please refer to manual.
			m_DllType = (ARTCAM_CAMERATYPE)(m_CArtCam.GetDllVersion() >> 16);
			m_CameraInfo.lSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(CAMERAINFO));
			m_CArtCam.GetCameraInfo(ref m_CameraInfo);

			// Range for value is set while determination of availability is done. 
			if(ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV == m_DllType)
			{
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BRIGHTNESS,		UpDownBrightness,	0,	255);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_CONTRAST,		UpDownContrast,		0,	255);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_HUE,			UpDownHue,			0,	255);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_SATURATION,		UpDownSaturation,	0,	255);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_SHARPNESS,		UpDownSharpness,	0,	  0);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_GAMMA,			UpDownGamma,		0,	  0);

				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYER_GAIN_R,	UpDownBayerGainR,	0,	  0);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYER_GAIN_G,	UpDownBayerGainG,	0,	  0);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYER_GAIN_B,	UpDownBayerGainB,	0,	  0);
			} 
			else 
			{
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BRIGHTNESS,		UpDownBrightness,	-255,	255);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_CONTRAST,		UpDownContrast,		-127,	127);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_HUE,			UpDownHue,			-360,	360);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_SATURATION,		UpDownSaturation,	-255,	255);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_SHARPNESS,		UpDownSharpness,	   0,	 30);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_GAMMA,			UpDownGamma,		   0,	200);

				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYER_GAIN_R,	UpDownBayerGainR,	   0,	200);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYER_GAIN_G,	UpDownBayerGainG,	   0,	200);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYER_GAIN_B,	UpDownBayerGainB,	   0,	200);
			}

			if(ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_SATA != m_DllType)
			{
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_GLOBAL_GAIN, UpDownGlobalGain,		m_CameraInfo.lGlobalGainMin,m_CameraInfo.lGlobalGainMax);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_COLOR_GAIN_R, UpDownColorGainR,		m_CameraInfo.lColorGainMin,	m_CameraInfo.lColorGainMax);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_COLOR_GAIN_G1, UpDownColorGainG1,	m_CameraInfo.lColorGainMin,	m_CameraInfo.lColorGainMax);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_COLOR_GAIN_G2, UpDownColorGainG2,	m_CameraInfo.lColorGainMin,	m_CameraInfo.lColorGainMax);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_COLOR_GAIN_B, UpDownColorGainB,		m_CameraInfo.lColorGainMin,	m_CameraInfo.lColorGainMax);
				InitControl(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_EXPOSURETIME, UpDownExposureTime,	m_CameraInfo.lExposureMin,	m_CameraInfo.lExposureMax);
			}

			// Auto white balance
			int Data = m_CArtCam.GetFilterValue(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYER_GAIN_AUTO);
			if(0 == m_CArtCam.m_Error)
			{
				checkAWB.Enabled = false;
			}
			if(0 != Data)
			{
				checkAWB.Checked = true;
			}


			// Bayer conversion mode
			Data = m_CArtCam.GetFilterValue(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYERMODE);
			if(0 == m_CArtCam.m_Error)
			{
				radioBayer1.Enabled = false;
				radioBayer2.Enabled = false;
				radioBayer3.Enabled = false;
				radioBayer4.Enabled = false;
			}

			switch(Data)
			{
				case 0:	radioBayer1.Checked = true; break;
				case 1:	radioBayer2.Checked = true; break; 
				case 2:	radioBayer3.Checked = true; break;
				case 3:	radioBayer4.Checked = true; break;
			}


			// Mirror reversal
			if(m_CArtCam.GetMirrorV())	checkMirrorV.Checked = true;
			if(m_CArtCam.GetMirrorH())	checkMirrorH.Checked = true;


			// Vertical reversal is not available in following models.
			switch(m_DllType)
			{
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_USTC:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P2:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_098:
					checkMirrorV.Enabled = false;
					break;
			}


			// Auto iris
			switch(m_CArtCam.GetAutoIris())
			{
				case AI_TYPE.AI_NONE:		radioAI1.Checked = true;	break;
				case AI_TYPE.AI_EXPOSURE:	radioAI2.Checked = true;	break;
				case AI_TYPE.AI_GAIN:		radioAI3.Checked = true;	break;
			}

			if(0 == m_CArtCam.m_Error)
			{
				radioAI1.Enabled = false;
				radioAI2.Enabled = false;
				radioAI3.Enabled = false;
			}

			// Camera without shutter function
			switch(m_DllType)
			{
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_320P:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_098:
					radioAI2.Enabled = false;
					break;
			}


			// Half clock
			checkHalfClock.Checked = (0 == m_CArtCam.GetHalfClock()) ? false : true;
			if(0 == m_CArtCam.m_Error)
			{
				checkHalfClock.Enabled = false;
			}


			// Channel
			if(ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV != m_DllType)
			{
				radioChannel1.Enabled = false;
				radioChannel2.Enabled = false;
				radioChannel3.Enabled = false;
				radioChannel4.Enabled = false;
				radioChannel5.Enabled = false;
				radioChannel6.Enabled = false;
			}
		}

		// 
		private void InitControl(ARTCAM_FILTERTYPE FilterType, NumericUpDown UpDown, int Min, int Max)
		{
			int Data = m_CArtCam.GetFilterValue(FilterType);


			UpDown.Minimum = Min;
			UpDown.Maximum = Max;
			if (Min <= Data && Data <= Max)
			{
			UpDown.Value = Data;
			}


			// Error occurrence(no response)
			if(0 == m_CArtCam.m_Error)
			{
				UpDown.Enabled = false;
				return;
			}

			return;
		}

		private void checkAWB_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetBayerGainAuto(checkAWB.Checked);
		}

		private void radioBayer1_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetFilterValue(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYERMODE, 0);
		}

		private void radioBayer2_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetFilterValue(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYERMODE, 1);
		}

		private void radioBayer3_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetFilterValue(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYERMODE, 2);
		}

		private void radioBayer4_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetFilterValue(ARTCAM_FILTERTYPE.ARTCAM_FILTERTYPE_BAYERMODE, 3);
		}

		private void radioAI1_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetAutoIris(AI_TYPE.AI_NONE);
		}

		private void radioAI2_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetAutoIris(AI_TYPE.AI_EXPOSURE);
		}

		private void radioAI3_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetAutoIris(AI_TYPE.AI_GAIN);
		}

		private void checkMirrorV_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetMirrorV(checkMirrorV.Checked);
		}

		private void checkMirrorH_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetMirrorH(checkMirrorH.Checked);
		}

		private void checkHalfClock_CheckedChanged(object sender, System.EventArgs e)
		{
			if(-1 != m_Preview)
			{
				// To switch clock, display needs to be stopped.
				Cursor.Current = Cursors.WaitCursor;
				m_CArtCam.StopPreview();
			}

			m_CArtCam.SetHalfClock(checkHalfClock.Checked ? 1 : 0);

			if(-1 != m_Preview)
			{
				// Resume display
				m_CArtCam.StartPreview();
				Cursor.Current = Cursors.Default;
			}
		}

		private void radioChannel1_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetCrossbar(0, 0);
		}

		private void radioChannel2_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetCrossbar(1, 0);
		}

		private void radioChannel3_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetCrossbar(2, 0);
		}

		private void radioChannel4_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetCrossbar(3, 0);
		}

		private void radioChannel5_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetCrossbar(4, 0);
		}

		private void radioChannel6_CheckedChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetCrossbar(5, 0);
		}

		private void UpDownBrightness_ValueChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetBrightness((int)UpDownBrightness.Value);
		}

		private void UpDownContrast_ValueChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetContrast((int)UpDownContrast.Value);
		}

		private void UpDownHue_ValueChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetHue((int)UpDownHue.Value);
		}

		private void UpDownSaturation_ValueChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetSaturation((int)UpDownSaturation.Value);
		}

		private void UpDownSharpness_ValueChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetSharpness((int)UpDownSharpness.Value);
		}

		private void UpDownGamma_ValueChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetGamma((int)UpDownGamma.Value);
		}

		private void UpDownBayerGainR_ValueChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetBayerGainRed((int)UpDownBayerGainR.Value);
		}

		private void UpDownBayerGainG_ValueChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetBayerGainGreen((int)UpDownBayerGainG.Value);
		}

		private void UpDownBayerGainB_ValueChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetBayerGainBlue((int)UpDownBayerGainB.Value);
		}

		private void UpDownGlobalGain_ValueChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetGlobalGain((int)UpDownGlobalGain.Value);
		}

		private void UpDownColorGainR_ValueChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetColorGainRed((int)UpDownColorGainR.Value);
		}

		private void UpDownColorGainG1_ValueChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetColorGainGreen1((int)UpDownColorGainG1.Value);
		}

		private void UpDownColorGainG2_ValueChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetColorGainGreen2((int)UpDownColorGainG2.Value);
		}

		private void UpDownColorGainB_ValueChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetColorGainBlue((int)UpDownColorGainB.Value);
		}

		private void UpDownExposureTime_ValueChanged(object sender, System.EventArgs e)
		{
			m_CArtCam.SetExposureTime((int)UpDownExposureTime.Value);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
	}
}

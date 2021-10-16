using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ArtCamSdk;

namespace Sample_CS
{
	/// <summary>
	/// Outline of Form2
	/// </summary>
	public class Form2 : System.Windows.Forms.Form
	{
		private ARTCAM_CAMERATYPE m_DllType = 0;
		private CArtCam m_CArtCam = null;
		private CAMERAINFO m_CameraInfo;

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textVT;
		private System.Windows.Forms.TextBox textVE;
		private System.Windows.Forms.TextBox textVS;
		private System.Windows.Forms.TextBox textHS;
		private System.Windows.Forms.TextBox textHE;
		private System.Windows.Forms.RadioButton radioSubSample8;
		private System.Windows.Forms.RadioButton radioSubSample4;
		private System.Windows.Forms.RadioButton radioSubSample2;
		private System.Windows.Forms.RadioButton radioSubSample1;
		private System.Windows.Forms.Label labelVideo;
		private System.Windows.Forms.RadioButton radioNL;
		private System.Windows.Forms.RadioButton radioNH;
		private System.Windows.Forms.RadioButton radioWL;
		private System.Windows.Forms.RadioButton radioWH;
		private System.Windows.Forms.RadioButton radioChannel6;
		private System.Windows.Forms.RadioButton radioChannel5;
		private System.Windows.Forms.RadioButton radioChannel4;
		private System.Windows.Forms.RadioButton radioChannel3;
		private System.Windows.Forms.RadioButton radioChannel2;
		private System.Windows.Forms.RadioButton radioChannel1;
		private System.Windows.Forms.RadioButton radioColor64;
		private System.Windows.Forms.RadioButton radioColor48;
		private System.Windows.Forms.RadioButton radioColor32;
		private System.Windows.Forms.RadioButton radioColor24;
		private System.Windows.Forms.RadioButton radioColor16;
		private System.Windows.Forms.RadioButton radioColor08;
		private System.Windows.Forms.Label labelFps;
		private System.Windows.Forms.TextBox textFps;
		private System.Windows.Forms.TextBox textCode8;
		private System.Windows.Forms.TextBox textCode7;
		private System.Windows.Forms.TextBox textCode6;
		private System.Windows.Forms.TextBox textCode5;
		private System.Windows.Forms.TextBox textCode4;
		private System.Windows.Forms.TextBox textCode3;
		private System.Windows.Forms.TextBox textCode2;
		private System.Windows.Forms.TextBox textCode1;
		private System.Windows.Forms.CheckBox checkCode;
		private System.Windows.Forms.TextBox textHT;
		private System.Windows.Forms.CheckBox checkBinning;
		/// <summary>
		/// Necessary designer variable 
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form2(CArtCam a)
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textVT = new System.Windows.Forms.TextBox();
			this.textVE = new System.Windows.Forms.TextBox();
			this.textVS = new System.Windows.Forms.TextBox();
			this.textHS = new System.Windows.Forms.TextBox();
			this.textHE = new System.Windows.Forms.TextBox();
			this.textHT = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioSubSample8 = new System.Windows.Forms.RadioButton();
			this.radioSubSample4 = new System.Windows.Forms.RadioButton();
			this.radioSubSample2 = new System.Windows.Forms.RadioButton();
			this.radioSubSample1 = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.labelVideo = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.radioChannel6 = new System.Windows.Forms.RadioButton();
			this.radioChannel5 = new System.Windows.Forms.RadioButton();
			this.radioChannel4 = new System.Windows.Forms.RadioButton();
			this.radioChannel3 = new System.Windows.Forms.RadioButton();
			this.radioChannel2 = new System.Windows.Forms.RadioButton();
			this.radioChannel1 = new System.Windows.Forms.RadioButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.radioNL = new System.Windows.Forms.RadioButton();
			this.radioNH = new System.Windows.Forms.RadioButton();
			this.radioWL = new System.Windows.Forms.RadioButton();
			this.radioWH = new System.Windows.Forms.RadioButton();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.radioColor64 = new System.Windows.Forms.RadioButton();
			this.radioColor48 = new System.Windows.Forms.RadioButton();
			this.radioColor32 = new System.Windows.Forms.RadioButton();
			this.radioColor24 = new System.Windows.Forms.RadioButton();
			this.radioColor16 = new System.Windows.Forms.RadioButton();
			this.radioColor08 = new System.Windows.Forms.RadioButton();
			this.labelFps = new System.Windows.Forms.Label();
			this.textFps = new System.Windows.Forms.TextBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.textCode8 = new System.Windows.Forms.TextBox();
			this.textCode7 = new System.Windows.Forms.TextBox();
			this.textCode6 = new System.Windows.Forms.TextBox();
			this.textCode5 = new System.Windows.Forms.TextBox();
			this.textCode4 = new System.Windows.Forms.TextBox();
			this.textCode3 = new System.Windows.Forms.TextBox();
			this.textCode2 = new System.Windows.Forms.TextBox();
			this.textCode1 = new System.Windows.Forms.TextBox();
			this.checkCode = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.checkBinning = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textVT);
			this.groupBox1.Controls.Add(this.textVE);
			this.groupBox1.Controls.Add(this.textVS);
			this.groupBox1.Controls.Add(this.textHS);
			this.groupBox1.Controls.Add(this.textHE);
			this.groupBox1.Controls.Add(this.textHT);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(264, 144);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Size for taking in";
			// 
			// textVT
			// 
			this.textVT.Location = new System.Drawing.Point(168, 48);
			this.textVT.Name = "textVT";
			this.textVT.Size = new System.Drawing.Size(72, 19);
			this.textVT.TabIndex = 10;
			this.textVT.Text = "0";
			// 
			// textVE
			// 
			this.textVE.Location = new System.Drawing.Point(168, 80);
			this.textVE.Name = "textVE";
			this.textVE.Size = new System.Drawing.Size(72, 19);
			this.textVE.TabIndex = 9;
			this.textVE.Text = "0";
			// 
			// textVS
			// 
			this.textVS.Location = new System.Drawing.Point(168, 112);
			this.textVS.Name = "textVS";
			this.textVS.Size = new System.Drawing.Size(72, 19);
			this.textVS.TabIndex = 8;
			this.textVS.Text = "0";
			// 
			// textHS
			// 
			this.textHS.Location = new System.Drawing.Point(80, 112);
			this.textHS.Name = "textHS";
			this.textHS.Size = new System.Drawing.Size(72, 19);
			this.textHS.TabIndex = 7;
			this.textHS.Text = "0";
			// 
			// textHE
			// 
			this.textHE.Location = new System.Drawing.Point(80, 80);
			this.textHE.Name = "textHE";
			this.textHE.Size = new System.Drawing.Size(72, 19);
			this.textHE.TabIndex = 6;
			this.textHE.Text = "0";
			// 
			// textHT
			// 
			this.textHT.Location = new System.Drawing.Point(80, 48);
			this.textHT.Name = "textHT";
			this.textHT.Size = new System.Drawing.Size(72, 19);
			this.textHT.TabIndex = 5;
			this.textHT.Text = "0";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(184, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "Vertical";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(94, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Horizon";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Starting point";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Valid pixels";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Total pixels";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioSubSample8);
			this.groupBox2.Controls.Add(this.radioSubSample4);
			this.groupBox2.Controls.Add(this.radioSubSample2);
			this.groupBox2.Controls.Add(this.radioSubSample1);
			this.groupBox2.Location = new System.Drawing.Point(8, 160);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(264, 85);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Subsampling";
			// 
			// radioSubSample8
			// 
			this.radioSubSample8.Location = new System.Drawing.Point(184, 32);
			this.radioSubSample8.Name = "radioSubSample8";
			this.radioSubSample8.Size = new System.Drawing.Size(48, 16);
			this.radioSubSample8.TabIndex = 3;
			this.radioSubSample8.Text = "1/8";
			// 
			// radioSubSample4
			// 
			this.radioSubSample4.Location = new System.Drawing.Point(128, 32);
			this.radioSubSample4.Name = "radioSubSample4";
			this.radioSubSample4.Size = new System.Drawing.Size(48, 16);
			this.radioSubSample4.TabIndex = 2;
			this.radioSubSample4.Text = "1/4";
			// 
			// radioSubSample2
			// 
			this.radioSubSample2.Location = new System.Drawing.Point(72, 32);
			this.radioSubSample2.Name = "radioSubSample2";
			this.radioSubSample2.Size = new System.Drawing.Size(48, 16);
			this.radioSubSample2.TabIndex = 1;
			this.radioSubSample2.Text = "1/2";
			// 
			// radioSubSample1
			// 
			this.radioSubSample1.Location = new System.Drawing.Point(16, 32);
			this.radioSubSample1.Name = "radioSubSample1";
			this.radioSubSample1.Size = new System.Drawing.Size(48, 16);
			this.radioSubSample1.TabIndex = 0;
			this.radioSubSample1.Text = "1/1";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.labelVideo);
			this.groupBox3.Controls.Add(this.groupBox5);
			this.groupBox3.Controls.Add(this.groupBox4);
			this.groupBox3.Location = new System.Drawing.Point(8, 268);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(264, 192);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Only for CNV";
			// 
			// labelVideo
			// 
			this.labelVideo.Location = new System.Drawing.Point(40, 24);
			this.labelVideo.Name = "labelVideo";
			this.labelVideo.Size = new System.Drawing.Size(176, 16);
			this.labelVideo.TabIndex = 2;
			this.labelVideo.Text = "VideoFormat : ";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.radioChannel6);
			this.groupBox5.Controls.Add(this.radioChannel5);
			this.groupBox5.Controls.Add(this.radioChannel4);
			this.groupBox5.Controls.Add(this.radioChannel3);
			this.groupBox5.Controls.Add(this.radioChannel2);
			this.groupBox5.Controls.Add(this.radioChannel1);
			this.groupBox5.Location = new System.Drawing.Point(160, 48);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(88, 128);
			this.groupBox5.TabIndex = 1;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Channel";
			// 
			// radioChannel6
			// 
			this.radioChannel6.Location = new System.Drawing.Point(48, 88);
			this.radioChannel6.Name = "radioChannel6";
			this.radioChannel6.Size = new System.Drawing.Size(24, 16);
			this.radioChannel6.TabIndex = 5;
			this.radioChannel6.Text = "6";
			// 
			// radioChannel5
			// 
			this.radioChannel5.Location = new System.Drawing.Point(48, 56);
			this.radioChannel5.Name = "radioChannel5";
			this.radioChannel5.Size = new System.Drawing.Size(24, 16);
			this.radioChannel5.TabIndex = 4;
			this.radioChannel5.Text = "5";
			// 
			// radioChannel4
			// 
			this.radioChannel4.Location = new System.Drawing.Point(48, 24);
			this.radioChannel4.Name = "radioChannel4";
			this.radioChannel4.Size = new System.Drawing.Size(24, 16);
			this.radioChannel4.TabIndex = 3;
			this.radioChannel4.Text = "4";
			// 
			// radioChannel3
			// 
			this.radioChannel3.Location = new System.Drawing.Point(16, 88);
			this.radioChannel3.Name = "radioChannel3";
			this.radioChannel3.Size = new System.Drawing.Size(24, 16);
			this.radioChannel3.TabIndex = 2;
			this.radioChannel3.Text = "3";
			// 
			// radioChannel2
			// 
			this.radioChannel2.Location = new System.Drawing.Point(16, 56);
			this.radioChannel2.Name = "radioChannel2";
			this.radioChannel2.Size = new System.Drawing.Size(24, 16);
			this.radioChannel2.TabIndex = 1;
			this.radioChannel2.Text = "2";
			// 
			// radioChannel1
			// 
			this.radioChannel1.Location = new System.Drawing.Point(16, 24);
			this.radioChannel1.Name = "radioChannel1";
			this.radioChannel1.Size = new System.Drawing.Size(24, 16);
			this.radioChannel1.TabIndex = 0;
			this.radioChannel1.Text = "1";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.radioNL);
			this.groupBox4.Controls.Add(this.radioNH);
			this.groupBox4.Controls.Add(this.radioWL);
			this.groupBox4.Controls.Add(this.radioWH);
			this.groupBox4.Location = new System.Drawing.Point(8, 48);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(136, 128);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Sampling rate";
			// 
			// radioNL
			// 
			this.radioNL.Location = new System.Drawing.Point(8, 96);
			this.radioNL.Name = "radioNL";
			this.radioNL.Size = new System.Drawing.Size(120, 16);
			this.radioNL.TabIndex = 3;
			this.radioNL.Text = "Normal Lowspeed";
			// 
			// radioNH
			// 
			this.radioNH.Location = new System.Drawing.Point(8, 72);
			this.radioNH.Name = "radioNH";
			this.radioNH.Size = new System.Drawing.Size(104, 16);
			this.radioNH.TabIndex = 2;
			this.radioNH.Text = "Normal Hispeed";
			// 
			// radioWL
			// 
			this.radioWL.Location = new System.Drawing.Point(8, 48);
			this.radioWL.Name = "radioWL";
			this.radioWL.Size = new System.Drawing.Size(104, 16);
			this.radioWL.TabIndex = 1;
			this.radioWL.Text = "Wide Lowspeed";
			// 
			// radioWH
			// 
			this.radioWH.Location = new System.Drawing.Point(8, 24);
			this.radioWH.Name = "radioWH";
			this.radioWH.Size = new System.Drawing.Size(96, 16);
			this.radioWH.TabIndex = 0;
			this.radioWH.Text = "Wide Hispeed";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.radioColor64);
			this.groupBox6.Controls.Add(this.radioColor48);
			this.groupBox6.Controls.Add(this.radioColor32);
			this.groupBox6.Controls.Add(this.radioColor24);
			this.groupBox6.Controls.Add(this.radioColor16);
			this.groupBox6.Controls.Add(this.radioColor08);
			this.groupBox6.Location = new System.Drawing.Point(288, 8);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(160, 80);
			this.groupBox6.TabIndex = 3;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Color mode";
			// 
			// radioColor64
			// 
			this.radioColor64.Location = new System.Drawing.Point(112, 48);
			this.radioColor64.Name = "radioColor64";
			this.radioColor64.Size = new System.Drawing.Size(40, 16);
			this.radioColor64.TabIndex = 5;
			this.radioColor64.Text = "64";
			// 
			// radioColor48
			// 
			this.radioColor48.Location = new System.Drawing.Point(64, 48);
			this.radioColor48.Name = "radioColor48";
			this.radioColor48.Size = new System.Drawing.Size(40, 16);
			this.radioColor48.TabIndex = 4;
			this.radioColor48.Text = "48";
			// 
			// radioColor32
			// 
			this.radioColor32.Location = new System.Drawing.Point(112, 24);
			this.radioColor32.Name = "radioColor32";
			this.radioColor32.Size = new System.Drawing.Size(40, 16);
			this.radioColor32.TabIndex = 3;
			this.radioColor32.Text = "32";
			// 
			// radioColor24
			// 
			this.radioColor24.Location = new System.Drawing.Point(64, 24);
			this.radioColor24.Name = "radioColor24";
			this.radioColor24.Size = new System.Drawing.Size(40, 16);
			this.radioColor24.TabIndex = 2;
			this.radioColor24.Text = "24";
			// 
			// radioColor16
			// 
			this.radioColor16.Location = new System.Drawing.Point(16, 48);
			this.radioColor16.Name = "radioColor16";
			this.radioColor16.Size = new System.Drawing.Size(40, 16);
			this.radioColor16.TabIndex = 1;
			this.radioColor16.Text = "16";
			// 
			// radioColor08
			// 
			this.radioColor08.Location = new System.Drawing.Point(16, 24);
			this.radioColor08.Name = "radioColor08";
			this.radioColor08.Size = new System.Drawing.Size(24, 16);
			this.radioColor08.TabIndex = 0;
			this.radioColor08.Text = "8";
			// 
			// labelFps
			// 
			this.labelFps.Location = new System.Drawing.Point(296, 120);
			this.labelFps.Name = "labelFps";
			this.labelFps.Size = new System.Drawing.Size(112, 16);
			this.labelFps.TabIndex = 4;
			this.labelFps.Text = "Waiting time  (ms)";
			// 
			// textFps
			// 
			this.textFps.Location = new System.Drawing.Point(312, 144);
			this.textFps.Name = "textFps";
			this.textFps.Size = new System.Drawing.Size(72, 19);
			this.textFps.TabIndex = 5;
			this.textFps.Text = "0";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.textCode8);
			this.groupBox7.Controls.Add(this.textCode7);
			this.groupBox7.Controls.Add(this.textCode6);
			this.groupBox7.Controls.Add(this.textCode5);
			this.groupBox7.Controls.Add(this.textCode4);
			this.groupBox7.Controls.Add(this.textCode3);
			this.groupBox7.Controls.Add(this.textCode2);
			this.groupBox7.Controls.Add(this.textCode1);
			this.groupBox7.Location = new System.Drawing.Point(288, 269);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(160, 152);
			this.groupBox7.TabIndex = 6;
			this.groupBox7.TabStop = false;
			// 
			// textCode8
			// 
			this.textCode8.Location = new System.Drawing.Point(88, 120);
			this.textCode8.Name = "textCode8";
			this.textCode8.Size = new System.Drawing.Size(56, 19);
			this.textCode8.TabIndex = 13;
			this.textCode8.Text = "0";
			// 
			// textCode7
			// 
			this.textCode7.Location = new System.Drawing.Point(88, 88);
			this.textCode7.Name = "textCode7";
			this.textCode7.Size = new System.Drawing.Size(56, 19);
			this.textCode7.TabIndex = 12;
			this.textCode7.Text = "0";
			// 
			// textCode6
			// 
			this.textCode6.Location = new System.Drawing.Point(88, 56);
			this.textCode6.Name = "textCode6";
			this.textCode6.Size = new System.Drawing.Size(56, 19);
			this.textCode6.TabIndex = 11;
			this.textCode6.Text = "0";
			// 
			// textCode5
			// 
			this.textCode5.Location = new System.Drawing.Point(88, 24);
			this.textCode5.Name = "textCode5";
			this.textCode5.Size = new System.Drawing.Size(56, 19);
			this.textCode5.TabIndex = 10;
			this.textCode5.Text = "0";
			// 
			// textCode4
			// 
			this.textCode4.Location = new System.Drawing.Point(16, 120);
			this.textCode4.Name = "textCode4";
			this.textCode4.Size = new System.Drawing.Size(56, 19);
			this.textCode4.TabIndex = 9;
			this.textCode4.Text = "0";
			// 
			// textCode3
			// 
			this.textCode3.Location = new System.Drawing.Point(16, 88);
			this.textCode3.Name = "textCode3";
			this.textCode3.Size = new System.Drawing.Size(56, 19);
			this.textCode3.TabIndex = 8;
			this.textCode3.Text = "0";
			// 
			// textCode2
			// 
			this.textCode2.Location = new System.Drawing.Point(16, 56);
			this.textCode2.Name = "textCode2";
			this.textCode2.Size = new System.Drawing.Size(56, 19);
			this.textCode2.TabIndex = 7;
			this.textCode2.Text = "0";
			// 
			// textCode1
			// 
			this.textCode1.Location = new System.Drawing.Point(16, 24);
			this.textCode1.Name = "textCode1";
			this.textCode1.Size = new System.Drawing.Size(56, 19);
			this.textCode1.TabIndex = 6;
			this.textCode1.Text = "0";
			// 
			// checkCode
			// 
			this.checkCode.Location = new System.Drawing.Point(304, 269);
			this.checkCode.Name = "checkCode";
			this.checkCode.Size = new System.Drawing.Size(120, 16);
			this.checkCode.TabIndex = 7;
			this.checkCode.Text = "Write sub-code";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(288, 437);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "Apply";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(376, 437);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "Cancel";
			// 
			// checkBinning
			// 
			this.checkBinning.Location = new System.Drawing.Point(24, 208);
			this.checkBinning.Name = "checkBinning";
			this.checkBinning.Size = new System.Drawing.Size(192, 24);
			this.checkBinning.TabIndex = 10;
			this.checkBinning.Text = "Binning";
			// 
			// Form2
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(464, 489);
			this.Controls.Add(this.checkBinning);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.checkCode);
			this.Controls.Add(this.groupBox7);
			this.Controls.Add(this.textFps);
			this.Controls.Add(this.labelFps);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form2";
			this.Text = "Size settings";
			this.Load += new System.EventHandler(this.Form2_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void Form2_Load(object sender, System.EventArgs e)
		{
			// Change operation for each DLL
			// For each DLL function, please refer to manual.
			m_DllType = (ARTCAM_CAMERATYPE)(m_CArtCam.GetDllVersion() >> 16);
			m_CameraInfo.lSize = System.Runtime.InteropServices.Marshal.SizeOf(m_CameraInfo);
			m_CArtCam.GetCameraInfo(ref m_CameraInfo);

			// Set size for camera
			InitCameraSize();

			// Set color mode
			InitColorMode();

			// Set information for sub-sampling.
			InitSubSample();

			// Initialize CNV.
			InitCNV();

			// Obtain sub-code
			InitSubCode();


			// Frame rate for Directshow
			if(ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS == m_DllType)
			{
				textFps.Text = Convert.ToString(m_CArtCam.Fps());
			}
				// For all others, this is the waiting period between frames
			else 
			{
				labelFps.Text = "Waiting time  (ms)";
				textFps.Text = Convert.ToString(m_CArtCam.GetWaitTime());
			}


		}

		// Set size for camera
		private void InitCameraSize()
		{
			int lHT, lHS, lHE, lVT, lVS, lVE;

			// Cameras that do not allow size settings
			switch(m_DllType)
			{
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS:
					textHT.Enabled = false;
					textHS.Enabled = false;
					textVT.Enabled = false;
					textVS.Enabled = false;

					textHT.Text	= Convert.ToString(m_CArtCam.Width());
					textHE.Text	= Convert.ToString(m_CArtCam.Width());
					textHS.Text	= "0";
					textVT.Text	= Convert.ToString(m_CArtCam.Height());
					textVE.Text	= Convert.ToString(m_CArtCam.Height());
					textVS.Text	= "0";
					break;

				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_098:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_500P:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P2:
					textHT.Enabled = false;
					textHE.Enabled = false;
					textHS.Enabled = false;
					textVT.Enabled = false;
					textVE.Enabled = false;
					textVS.Enabled = false;

					textHT.Text	= Convert.ToString(m_CArtCam.Width());
					textHE.Text	= Convert.ToString(m_CArtCam.Width());
					textHS.Text	= "0";
					textVT.Text	= Convert.ToString(m_CArtCam.Height());
					textVE.Text	= Convert.ToString(m_CArtCam.Height());
					textVS.Text	= "0";
					break;

				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_130MI:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_200MI:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_300MI:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_320P:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_200SH:
					textVT.Enabled = false;
					textHT.Enabled = false;

					m_CArtCam.GetCaptureWindowEx(out lHT, out lHS, out lHE, out lVT, out lVS, out lVE);

					textHT.Text	= Convert.ToString(lHT);
					textHE.Text	= Convert.ToString(lHE);
					textHS.Text	= Convert.ToString(lHS);
					textVT.Text	= Convert.ToString(lVT);
					textVE.Text	= Convert.ToString(lVE);
					textVS.Text	= Convert.ToString(lVS);
					break;

				default:
					m_CArtCam.GetCaptureWindowEx(out lHT, out lHS, out lHE, out lVT, out lVS, out lVE);

					textHT.Text	= Convert.ToString(lHT);
					textHE.Text	= Convert.ToString(lHE);
					textHS.Text	= Convert.ToString(lHS);
					textVT.Text	= Convert.ToString(lVT);
					textVE.Text	= Convert.ToString(lVE);
					textVS.Text	= Convert.ToString(lVS);
					break;
			}

		}

		private int getColorMode()
		{
			return ((m_CArtCam.GetColorMode() + 7) & ~7);
		}

		// Set color mode
		private void InitColorMode()
		{
			// Color number
			switch(getColorMode())
			{
				case 8: 	radioColor08.Checked = true;	break;
				case 16:	radioColor16.Checked = true;	break;
				case 24:	radioColor24.Checked = true;	break;
				case 32:	radioColor32.Checked = true;	break;
				case 48:	radioColor48.Checked = true;	break;
				case 64:	radioColor64.Checked = true;	break;
			}

			switch(m_DllType)
			{
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS:
					radioColor08.Enabled = false;
					radioColor16.Enabled = false;
					radioColor32.Enabled = false;
					radioColor48.Enabled = false;
					radioColor64.Enabled = false;
					break;

				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV:
					radioColor32.Enabled = false;
					radioColor48.Enabled = false;
					radioColor64.Enabled = false;
					break;

				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_320P:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_200SH:
					radioColor16.Enabled = false;
					radioColor32.Enabled = false;
					radioColor48.Enabled = false;
					radioColor64.Enabled = false;
					break;
			}
		}

		// Set information for sub-sampling.
		private void InitSubSample()
		{
			// Sub-sampling
			switch((SUBSAMPLE)((int)m_CArtCam.GetSubSample() & 0x03))
			{
				case SUBSAMPLE.SUBSAMPLE_1:	radioSubSample1.Checked = true;	break;
				case SUBSAMPLE.SUBSAMPLE_2:	radioSubSample2.Checked = true;	break;
				case SUBSAMPLE.SUBSAMPLE_4:	radioSubSample4.Checked = true;	break;
				case SUBSAMPLE.SUBSAMPLE_8:	radioSubSample8.Checked = true;	break;
			}

			if(((int)m_CArtCam.GetSubSample() & 0x10) == 0x10)
			{
				checkBinning.Checked = true;
			}
			else
			{
				checkBinning.Checked = false;
			}
		}

		// Initialize CNV.
		private void InitCNV()
		{
			// For CNV only
			if(ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV == m_DllType)
			{
				switch(m_CArtCam.GetVideoFormat())
				{
					case VIDEOFORMAT.VIDEOFORMAT_NTSC:	labelVideo.Text = "VideoFormat : NTSC";		break;
					case VIDEOFORMAT.VIDEOFORMAT_PAL:	labelVideo.Text = "VideoFormat : PAL";		break;
					case VIDEOFORMAT.VIDEOFORMAT_PALM:	labelVideo.Text = "VideoFormat : PALM";		break;
					case VIDEOFORMAT.VIDEOFORMAT_SECAM:	labelVideo.Text = "VideoFormat : SECAM";	break;
				}

				switch(m_CArtCam.GetSamplingRate())
				{
					case SAMPLING_RATE.WIDE_HISPEED:	radioWH.Checked = true;		break;
					case SAMPLING_RATE.WIDE_LOWSPEED:	radioWL.Checked = true;		break;
					case SAMPLING_RATE.NORMAL_HISPEED:	radioNH.Checked = true;		break;
					case SAMPLING_RATE.NORMAL_LOWSPEED:	radioNL.Checked = true;		break;
				}
			}
			else 
			{
				radioWH.Enabled = false;
				radioWL.Enabled = false;
				radioNH.Enabled = false;
				radioNL.Enabled = false;

				radioChannel1.Enabled = false;
				radioChannel2.Enabled = false;
				radioChannel3.Enabled = false;
				radioChannel4.Enabled = false;
				radioChannel5.Enabled = false;
				radioChannel6.Enabled = false;
			}
		}

		// Obtain sub-code
		private void InitSubCode()
		{
			textCode1.Text = Convert.ToString(m_CArtCam.ReadSromID(0));

			if(0 == m_CArtCam.m_Error)
			{
				textCode1.Enabled = false;
				textCode2.Enabled = false;
				textCode3.Enabled = false;
				textCode4.Enabled = false;
				textCode5.Enabled = false;
				textCode6.Enabled = false;
				textCode7.Enabled = false;
				textCode8.Enabled = false;

				checkCode.Enabled = false;
				return;
			}

			textCode2.Text = Convert.ToString(m_CArtCam.ReadSromID(1));
			textCode3.Text = Convert.ToString(m_CArtCam.ReadSromID(2));
			textCode4.Text = Convert.ToString(m_CArtCam.ReadSromID(3));
			textCode5.Text = Convert.ToString(m_CArtCam.ReadSromID(4));
			textCode6.Text = Convert.ToString(m_CArtCam.ReadSromID(5));
			textCode7.Text = Convert.ToString(m_CArtCam.ReadSromID(6));
			textCode8.Text = Convert.ToString(m_CArtCam.ReadSromID(7));
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			int lHT, lHS, lHE, lVT, lVS, lVE, lFps;
			lHT		= Convert.ToInt32(textHT.Text);
			lHE		= Convert.ToInt32(textHE.Text);
			lHS		= Convert.ToInt32(textHS.Text);
			lVT		= Convert.ToInt32(textVT.Text);
			lVE		= Convert.ToInt32(textVE.Text);
			lVS		= Convert.ToInt32(textVS.Text);
			lFps	= Convert.ToInt32(textFps.Text);

			/*
			// Size 0 represents error
			if(0 == lVT || 0 == lVE || 0 == lHT || 0 == lHE)
			{
				MessageBox.Show("Set size is wrong");
				return;
			}

			// Effective resolution larger than maximum resolution results in error.
			if( (lVT < lVE + lVS) || (lHT < lHE + lHS) )
			{
				MessageBox.Show("Set size is wrong");
				return;
			}

			if ((lVT > m_CameraInfo.lHeight) || (lHT > m_CameraInfo.lWidth))
				{
					MessageBox.Show("Set size is wrong");
					return;
				}

			// When waiting period is set 0, there will be excessive load on CPU.
			if(ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS != m_DllType)
			{
				if(0 >= lFps)
				{
					MessageBox.Show("Set at least 1 for waiting period. /n performance will deteriorate.");
					return;
				}
			}
			*/



			// Size & frame rate settings.
			switch(m_DllType)
			{
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_DS:
					m_CArtCam.SetCaptureWindow(lHE, lVE, lFps);
					break;

				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_CNV:
					if(radioWH.Checked) m_CArtCam.SetSamplingRate(SAMPLING_RATE.WIDE_HISPEED);
					if(radioWL.Checked) m_CArtCam.SetSamplingRate(SAMPLING_RATE.WIDE_LOWSPEED);
					if(radioNH.Checked) m_CArtCam.SetSamplingRate(SAMPLING_RATE.NORMAL_HISPEED);
					if(radioNL.Checked) m_CArtCam.SetSamplingRate(SAMPLING_RATE.NORMAL_LOWSPEED);

					if(radioChannel1.Checked) m_CArtCam.SetCrossbar(0, 0);
					if(radioChannel2.Checked) m_CArtCam.SetCrossbar(1, 0);
					if(radioChannel3.Checked) m_CArtCam.SetCrossbar(2, 0);
					if(radioChannel4.Checked) m_CArtCam.SetCrossbar(3, 0);
					if(radioChannel5.Checked) m_CArtCam.SetCrossbar(4, 0);
					if(radioChannel6.Checked) m_CArtCam.SetCrossbar(5, 0);
					break;
/*
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_098:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_500P:
				case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_150P2:
					break;
*/
				default:
					m_CArtCam.SetCaptureWindowEx(lHT, lHS, lHE, lVT, lVS, lVE);
					m_CArtCam.SetWaitTime(lFps);
					break;
			}

			// Invalid values cannot be set at dialog
			// It reflects without modification
			// There is no problem since inactive camera returns error as well
			if(checkBinning.Checked)
			{
				if(radioSubSample1.Checked) m_CArtCam.SetSubSample(SUBSAMPLE.SUBSAMPLE_1);
				if(radioSubSample2.Checked) m_CArtCam.SetSubSample(SUBSAMPLE.BINNING_2);
				if(radioSubSample4.Checked) m_CArtCam.SetSubSample(SUBSAMPLE.BINNING_4);
			}
			else
			{
			if(radioSubSample1.Checked) m_CArtCam.SetSubSample(SUBSAMPLE.SUBSAMPLE_1);
			if(radioSubSample2.Checked) m_CArtCam.SetSubSample(SUBSAMPLE.SUBSAMPLE_2);
			if(radioSubSample4.Checked) m_CArtCam.SetSubSample(SUBSAMPLE.SUBSAMPLE_4);
			if(radioSubSample8.Checked) m_CArtCam.SetSubSample(SUBSAMPLE.SUBSAMPLE_8);
			}
			if(radioColor08.Checked) m_CArtCam.SetColorMode( 8);
			if(radioColor16.Checked) m_CArtCam.SetColorMode(16);
			if(radioColor24.Checked) m_CArtCam.SetColorMode(24);
			if(radioColor32.Checked) m_CArtCam.SetColorMode(32);
			if(radioColor48.Checked) m_CArtCam.SetColorMode(48);
			if(radioColor64.Checked) m_CArtCam.SetColorMode(64);


			// Write sub-code
			// Make sure writing is correct
			if(checkCode.Checked)
			{
				byte[] m_Code = new byte[8];
				m_Code[0]	= Convert.ToByte(textCode1.Text);
				m_Code[1]	= Convert.ToByte(textCode2.Text);
				m_Code[2]	= Convert.ToByte(textCode3.Text);
				m_Code[3]	= Convert.ToByte(textCode4.Text);
				m_Code[4]	= Convert.ToByte(textCode5.Text);
				m_Code[5]	= Convert.ToByte(textCode6.Text);
				m_Code[6]	= Convert.ToByte(textCode7.Text);
				m_Code[7]	= Convert.ToByte(textCode8.Text);

				m_CArtCam.WriteSromID(0, m_Code[0]);
				m_CArtCam.WriteSromID(1, m_Code[1]);
				m_CArtCam.WriteSromID(2, m_Code[2]);
				m_CArtCam.WriteSromID(3, m_Code[3]);
				m_CArtCam.WriteSromID(4, m_Code[4]);
				m_CArtCam.WriteSromID(5, m_Code[5]);
				m_CArtCam.WriteSromID(6, m_Code[6]);
				m_CArtCam.WriteSromID(7, m_Code[7]);
			}
		}

	}
}

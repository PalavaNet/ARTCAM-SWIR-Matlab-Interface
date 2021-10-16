namespace Sample_CS
{
	partial class Form7
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkAWB = new System.Windows.Forms.CheckBox();
			this.checkColor = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.numericGainB = new System.Windows.Forms.NumericUpDown();
			this.trackGainB = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.numericGainG = new System.Windows.Forms.NumericUpDown();
			this.trackGainG = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.numericGainR = new System.Windows.Forms.NumericUpDown();
			this.trackGainR = new System.Windows.Forms.TrackBar();
			this.trackShutter = new System.Windows.Forms.TrackBar();
			this.numericGainAll = new System.Windows.Forms.NumericUpDown();
			this.trackGainAll = new System.Windows.Forms.TrackBar();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.checkMirrorH = new System.Windows.Forms.CheckBox();
			this.checkMirrorV = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.numericShutter = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.buttonInitSettings = new System.Windows.Forms.Button();
			this.buttonWrite = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.pictureColor = new System.Windows.Forms.PictureBox();
			this.label9 = new System.Windows.Forms.Label();
			this.numericYSize = new System.Windows.Forms.NumericUpDown();
			this.trackYSize = new System.Windows.Forms.TrackBar();
			this.label8 = new System.Windows.Forms.Label();
			this.numericXSize = new System.Windows.Forms.NumericUpDown();
			this.trackXSize = new System.Windows.Forms.TrackBar();
			this.label7 = new System.Windows.Forms.Label();
			this.numericYPos = new System.Windows.Forms.NumericUpDown();
			this.trackYPos = new System.Windows.Forms.TrackBar();
			this.label4 = new System.Windows.Forms.Label();
			this.checkCursorOn = new System.Windows.Forms.CheckBox();
			this.numericXPos = new System.Windows.Forms.NumericUpDown();
			this.radioCursor2 = new System.Windows.Forms.RadioButton();
			this.trackXPos = new System.Windows.Forms.TrackBar();
			this.radioCursor1 = new System.Windows.Forms.RadioButton();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonDefault = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericGainB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackGainB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericGainG)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackGainG)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericGainR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackGainR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackShutter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericGainAll)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackGainAll)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericShutter)).BeginInit();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericYSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackYSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericXSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackXSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericYPos)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackYPos)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericXPos)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackXPos)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkAWB);
			this.groupBox1.Controls.Add(this.checkColor);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(268, 64);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Working mode settings";
			// 
			// checkAWB
			// 
			this.checkAWB.AutoSize = true;
			this.checkAWB.Location = new System.Drawing.Point(99, 28);
			this.checkAWB.Name = "checkAWB";
			this.checkAWB.Size = new System.Drawing.Size(122, 16);
			this.checkAWB.TabIndex = 1;
			this.checkAWB.Text = "Auto white balance";
			this.checkAWB.UseVisualStyleBackColor = true;
			this.checkAWB.CheckedChanged += new System.EventHandler(this.checkAWB_CheckedChanged);
			// 
			// checkColor
			// 
			this.checkColor.AutoSize = true;
			this.checkColor.Location = new System.Drawing.Point(16, 28);
			this.checkColor.Name = "checkColor";
			this.checkColor.Size = new System.Drawing.Size(51, 16);
			this.checkColor.TabIndex = 0;
			this.checkColor.Text = "Color";
			this.checkColor.UseVisualStyleBackColor = true;
			this.checkColor.CheckedChanged += new System.EventHandler(this.checkColor_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.numericGainB);
			this.groupBox2.Controls.Add(this.trackGainB);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.numericGainG);
			this.groupBox2.Controls.Add(this.trackGainG);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.numericGainR);
			this.groupBox2.Controls.Add(this.trackGainR);
			this.groupBox2.Location = new System.Drawing.Point(13, 84);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(268, 113);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Bayer conversion";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 79);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 12);
			this.label3.TabIndex = 8;
			this.label3.Text = "B Gain";
			// 
			// numericGainB
			// 
			this.numericGainB.Location = new System.Drawing.Point(207, 75);
			this.numericGainB.Name = "numericGainB";
			this.numericGainB.Size = new System.Drawing.Size(50, 19);
			this.numericGainB.TabIndex = 7;
			this.numericGainB.ValueChanged += new System.EventHandler(this.numericGainB_ValueChanged);
			// 
			// trackGainB
			// 
			this.trackGainB.AutoSize = false;
			this.trackGainB.Location = new System.Drawing.Point(47, 75);
			this.trackGainB.Name = "trackGainB";
			this.trackGainB.Size = new System.Drawing.Size(154, 18);
			this.trackGainB.TabIndex = 6;
			this.trackGainB.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackGainB.Scroll += new System.EventHandler(this.trackGainB_Scroll);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 12);
			this.label2.TabIndex = 5;
			this.label2.Text = "G Gain";
			// 
			// numericGainG
			// 
			this.numericGainG.Location = new System.Drawing.Point(207, 47);
			this.numericGainG.Name = "numericGainG";
			this.numericGainG.Size = new System.Drawing.Size(50, 19);
			this.numericGainG.TabIndex = 4;
			this.numericGainG.ValueChanged += new System.EventHandler(this.numericGainG_ValueChanged);
			// 
			// trackGainG
			// 
			this.trackGainG.AutoSize = false;
			this.trackGainG.Location = new System.Drawing.Point(47, 51);
			this.trackGainG.Name = "trackGainG";
			this.trackGainG.Size = new System.Drawing.Size(154, 18);
			this.trackGainG.TabIndex = 3;
			this.trackGainG.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackGainG.Scroll += new System.EventHandler(this.trackGainG_Scroll);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "R Gain";
			// 
			// numericGainR
			// 
			this.numericGainR.Location = new System.Drawing.Point(207, 19);
			this.numericGainR.Name = "numericGainR";
			this.numericGainR.Size = new System.Drawing.Size(50, 19);
			this.numericGainR.TabIndex = 1;
			this.numericGainR.ValueChanged += new System.EventHandler(this.numericGainR_ValueChanged);
			// 
			// trackGainR
			// 
			this.trackGainR.AutoSize = false;
			this.trackGainR.Location = new System.Drawing.Point(47, 22);
			this.trackGainR.Name = "trackGainR";
			this.trackGainR.Size = new System.Drawing.Size(154, 18);
			this.trackGainR.TabIndex = 0;
			this.trackGainR.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackGainR.Scroll += new System.EventHandler(this.trackGainR_Scroll);
			// 
			// trackShutter
			// 
			this.trackShutter.AutoSize = false;
			this.trackShutter.Location = new System.Drawing.Point(47, 51);
			this.trackShutter.Name = "trackShutter";
			this.trackShutter.Size = new System.Drawing.Size(154, 18);
			this.trackShutter.TabIndex = 3;
			this.trackShutter.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackShutter.Scroll += new System.EventHandler(this.trackShutter_Scroll);
			// 
			// numericGainAll
			// 
			this.numericGainAll.Location = new System.Drawing.Point(207, 20);
			this.numericGainAll.Name = "numericGainAll";
			this.numericGainAll.Size = new System.Drawing.Size(50, 19);
			this.numericGainAll.TabIndex = 1;
			this.numericGainAll.ValueChanged += new System.EventHandler(this.numericGainAll_ValueChanged);
			// 
			// trackGainAll
			// 
			this.trackGainAll.AutoSize = false;
			this.trackGainAll.Location = new System.Drawing.Point(47, 24);
			this.trackGainAll.Name = "trackGainAll";
			this.trackGainAll.Size = new System.Drawing.Size(154, 18);
			this.trackGainAll.TabIndex = 0;
			this.trackGainAll.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackGainAll.Scroll += new System.EventHandler(this.trackGainAll_Scroll);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.checkMirrorH);
			this.groupBox3.Controls.Add(this.checkMirrorV);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.numericShutter);
			this.groupBox3.Controls.Add(this.trackShutter);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.numericGainAll);
			this.groupBox3.Controls.Add(this.trackGainAll);
			this.groupBox3.Location = new System.Drawing.Point(13, 203);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(268, 108);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Camera controll";
			// 
			// checkMirrorH
			// 
			this.checkMirrorH.AutoSize = true;
			this.checkMirrorH.Location = new System.Drawing.Point(125, 81);
			this.checkMirrorH.Name = "checkMirrorH";
			this.checkMirrorH.Size = new System.Drawing.Size(109, 16);
			this.checkMirrorH.TabIndex = 7;
			this.checkMirrorH.Text = "Horizontal mirror";
			this.checkMirrorH.UseVisualStyleBackColor = true;
			this.checkMirrorH.CheckedChanged += new System.EventHandler(this.checkMirrorH_CheckedChanged);
			// 
			// checkMirrorV
			// 
			this.checkMirrorV.AutoSize = true;
			this.checkMirrorV.Location = new System.Drawing.Point(9, 81);
			this.checkMirrorV.Name = "checkMirrorV";
			this.checkMirrorV.Size = new System.Drawing.Size(98, 16);
			this.checkMirrorV.TabIndex = 6;
			this.checkMirrorV.Text = "Vertical mirror";
			this.checkMirrorV.UseVisualStyleBackColor = true;
			this.checkMirrorV.CheckedChanged += new System.EventHandler(this.checkMirrorV_CheckedChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 51);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 12);
			this.label5.TabIndex = 5;
			this.label5.Text = "Shutter";
			// 
			// numericShutter
			// 
			this.numericShutter.Location = new System.Drawing.Point(207, 49);
			this.numericShutter.Name = "numericShutter";
			this.numericShutter.Size = new System.Drawing.Size(50, 19);
			this.numericShutter.TabIndex = 4;
			this.numericShutter.ValueChanged += new System.EventHandler(this.numericShutter_ValueChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(7, 22);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(28, 12);
			this.label6.TabIndex = 2;
			this.label6.Text = "Gain";
			// 
			// buttonInitSettings
			// 
			this.buttonInitSettings.Location = new System.Drawing.Point(12, 323);
			this.buttonInitSettings.Name = "buttonInitSettings";
			this.buttonInitSettings.Size = new System.Drawing.Size(114, 31);
			this.buttonInitSettings.TabIndex = 3;
			this.buttonInitSettings.Text = "Initialize setting";
			this.buttonInitSettings.UseVisualStyleBackColor = true;
			this.buttonInitSettings.Click += new System.EventHandler(this.buttonInitSettings_Click);
			// 
			// buttonWrite
			// 
			this.buttonWrite.Location = new System.Drawing.Point(167, 323);
			this.buttonWrite.Name = "buttonWrite";
			this.buttonWrite.Size = new System.Drawing.Size(114, 31);
			this.buttonWrite.TabIndex = 4;
			this.buttonWrite.Text = "Write";
			this.buttonWrite.UseVisualStyleBackColor = true;
			this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.pictureColor);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.numericYSize);
			this.groupBox4.Controls.Add(this.trackYSize);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.numericXSize);
			this.groupBox4.Controls.Add(this.trackXSize);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.numericYPos);
			this.groupBox4.Controls.Add(this.trackYPos);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.checkCursorOn);
			this.groupBox4.Controls.Add(this.numericXPos);
			this.groupBox4.Controls.Add(this.radioCursor2);
			this.groupBox4.Controls.Add(this.trackXPos);
			this.groupBox4.Controls.Add(this.radioCursor1);
			this.groupBox4.Location = new System.Drawing.Point(308, 13);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(279, 253);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Cross cursor settings";
			// 
			// pictureColor
			// 
			this.pictureColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureColor.Location = new System.Drawing.Point(15, 212);
			this.pictureColor.Name = "pictureColor";
			this.pictureColor.Size = new System.Drawing.Size(240, 31);
			this.pictureColor.TabIndex = 18;
			this.pictureColor.TabStop = false;
			this.pictureColor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureColor_MouseUp);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(13, 181);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(37, 12);
			this.label9.TabIndex = 17;
			this.label9.Text = "Y Size";
			// 
			// numericYSize
			// 
			this.numericYSize.Location = new System.Drawing.Point(213, 181);
			this.numericYSize.Name = "numericYSize";
			this.numericYSize.Size = new System.Drawing.Size(50, 19);
			this.numericYSize.TabIndex = 16;
			this.numericYSize.ValueChanged += new System.EventHandler(this.numericYSize_ValueChanged);
			// 
			// trackYSize
			// 
			this.trackYSize.AutoSize = false;
			this.trackYSize.Location = new System.Drawing.Point(53, 182);
			this.trackYSize.Name = "trackYSize";
			this.trackYSize.Size = new System.Drawing.Size(154, 18);
			this.trackYSize.TabIndex = 15;
			this.trackYSize.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackYSize.Scroll += new System.EventHandler(this.trackYSize_Scroll);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(14, 152);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 12);
			this.label8.TabIndex = 14;
			this.label8.Text = "X Size";
			// 
			// numericXSize
			// 
			this.numericXSize.Location = new System.Drawing.Point(214, 152);
			this.numericXSize.Name = "numericXSize";
			this.numericXSize.Size = new System.Drawing.Size(50, 19);
			this.numericXSize.TabIndex = 13;
			this.numericXSize.ValueChanged += new System.EventHandler(this.numericXSize_ValueChanged);
			// 
			// trackXSize
			// 
			this.trackXSize.AutoSize = false;
			this.trackXSize.Location = new System.Drawing.Point(54, 154);
			this.trackXSize.Name = "trackXSize";
			this.trackXSize.Size = new System.Drawing.Size(154, 18);
			this.trackXSize.TabIndex = 12;
			this.trackXSize.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackXSize.Scroll += new System.EventHandler(this.trackXSize_Scroll);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(14, 124);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 12);
			this.label7.TabIndex = 11;
			this.label7.Text = "Y Pos";
			// 
			// numericYPos
			// 
			this.numericYPos.Location = new System.Drawing.Point(214, 124);
			this.numericYPos.Name = "numericYPos";
			this.numericYPos.Size = new System.Drawing.Size(50, 19);
			this.numericYPos.TabIndex = 10;
			this.numericYPos.ValueChanged += new System.EventHandler(this.numericYPos_ValueChanged);
			// 
			// trackYPos
			// 
			this.trackYPos.AutoSize = false;
			this.trackYPos.Location = new System.Drawing.Point(54, 125);
			this.trackYPos.Name = "trackYPos";
			this.trackYPos.Size = new System.Drawing.Size(154, 18);
			this.trackYPos.TabIndex = 9;
			this.trackYPos.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackYPos.Scroll += new System.EventHandler(this.trackYPos_Scroll);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 12);
			this.label4.TabIndex = 8;
			this.label4.Text = "X Pos";
			// 
			// checkCursorOn
			// 
			this.checkCursorOn.AutoSize = true;
			this.checkCursorOn.Location = new System.Drawing.Point(15, 61);
			this.checkCursorOn.Name = "checkCursorOn";
			this.checkCursorOn.Size = new System.Drawing.Size(106, 16);
			this.checkCursorOn.TabIndex = 2;
			this.checkCursorOn.Text = "Cross cursor on";
			this.checkCursorOn.UseVisualStyleBackColor = true;
			this.checkCursorOn.CheckedChanged += new System.EventHandler(this.checkCursorOn_CheckedChanged);
			// 
			// numericXPos
			// 
			this.numericXPos.Location = new System.Drawing.Point(213, 96);
			this.numericXPos.Name = "numericXPos";
			this.numericXPos.Size = new System.Drawing.Size(50, 19);
			this.numericXPos.TabIndex = 7;
			this.numericXPos.ValueChanged += new System.EventHandler(this.numericXPos_ValueChanged);
			// 
			// radioCursor2
			// 
			this.radioCursor2.AutoSize = true;
			this.radioCursor2.Location = new System.Drawing.Point(126, 28);
			this.radioCursor2.Name = "radioCursor2";
			this.radioCursor2.Size = new System.Drawing.Size(63, 16);
			this.radioCursor2.TabIndex = 1;
			this.radioCursor2.TabStop = true;
			this.radioCursor2.Text = "Cursor2";
			this.radioCursor2.UseVisualStyleBackColor = true;
			this.radioCursor2.CheckedChanged += new System.EventHandler(this.radioCursor2_CheckedChanged);
			// 
			// trackXPos
			// 
			this.trackXPos.AutoSize = false;
			this.trackXPos.Location = new System.Drawing.Point(53, 97);
			this.trackXPos.Name = "trackXPos";
			this.trackXPos.Size = new System.Drawing.Size(154, 18);
			this.trackXPos.TabIndex = 6;
			this.trackXPos.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackXPos.Scroll += new System.EventHandler(this.trackXPos_Scroll);
			// 
			// radioCursor1
			// 
			this.radioCursor1.AutoSize = true;
			this.radioCursor1.Location = new System.Drawing.Point(15, 29);
			this.radioCursor1.Name = "radioCursor1";
			this.radioCursor1.Size = new System.Drawing.Size(63, 16);
			this.radioCursor1.TabIndex = 0;
			this.radioCursor1.TabStop = true;
			this.radioCursor1.Text = "Cursor1";
			this.radioCursor1.UseVisualStyleBackColor = true;
			this.radioCursor1.CheckedChanged += new System.EventHandler(this.radioCursor1_CheckedChanged);
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(308, 331);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 6;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// buttonDefault
			// 
			this.buttonDefault.Location = new System.Drawing.Point(410, 331);
			this.buttonDefault.Name = "buttonDefault";
			this.buttonDefault.Size = new System.Drawing.Size(75, 23);
			this.buttonDefault.TabIndex = 7;
			this.buttonDefault.Text = "Default";
			this.buttonDefault.UseVisualStyleBackColor = true;
			this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(512, 331);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 8;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// Form7
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(599, 366);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonDefault);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.buttonWrite);
			this.Controls.Add(this.buttonInitSettings);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form7";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Form7";
			this.Load += new System.EventHandler(this.Form7_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form7_Paint);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericGainB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackGainB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericGainG)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackGainG)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericGainR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackGainR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackShutter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericGainAll)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackGainAll)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericShutter)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericYSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackYSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericXSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackXSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericYPos)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackYPos)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericXPos)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackXPos)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkAWB;
		private System.Windows.Forms.CheckBox checkColor;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TrackBar trackGainR;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericGainR;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericGainG;
		private System.Windows.Forms.TrackBar trackGainG;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericGainB;
		private System.Windows.Forms.TrackBar trackGainB;
		private System.Windows.Forms.TrackBar trackShutter;
		private System.Windows.Forms.NumericUpDown numericGainAll;
		private System.Windows.Forms.TrackBar trackGainAll;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numericShutter;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox checkMirrorV;
		private System.Windows.Forms.CheckBox checkMirrorH;
		private System.Windows.Forms.Button buttonInitSettings;
		private System.Windows.Forms.Button buttonWrite;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox checkCursorOn;
		private System.Windows.Forms.RadioButton radioCursor2;
		private System.Windows.Forms.RadioButton radioCursor1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown numericYSize;
		private System.Windows.Forms.TrackBar trackYSize;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown numericXSize;
		private System.Windows.Forms.TrackBar trackXSize;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown numericYPos;
		private System.Windows.Forms.TrackBar trackYPos;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numericXPos;
		private System.Windows.Forms.TrackBar trackXPos;
		private System.Windows.Forms.PictureBox pictureColor;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonDefault;
		private System.Windows.Forms.Button buttonCancel;
	}
}
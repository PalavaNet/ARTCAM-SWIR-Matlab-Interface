using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ArtCamSdk;

namespace Sample_CS
{
	/// <summary>
	/// Outline of Form4
	/// </summary>
	public class Form4 : System.Windows.Forms.Form
	{
		private CArtCam m_CArtCam = null;

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox checkBoxRead1;
		private System.Windows.Forms.CheckBox checkBoxRead2;
		private System.Windows.Forms.CheckBox checkBoxRead3;
		private System.Windows.Forms.CheckBox checkBoxRead4;
		private System.Windows.Forms.CheckBox checkBoxRead5;
		private System.Windows.Forms.CheckBox checkBoxRead6;
		private System.Windows.Forms.CheckBox checkBoxRead7;
		private System.Windows.Forms.CheckBox checkBoxRead8;
		private System.Windows.Forms.CheckBox checkBoxWrite1;
		private System.Windows.Forms.CheckBox checkBoxWrite2;
		private System.Windows.Forms.CheckBox checkBoxWrite3;
		private System.Windows.Forms.CheckBox checkBoxWrite4;
		private System.Windows.Forms.CheckBox checkBoxWrite5;
		private System.Windows.Forms.CheckBox checkBoxWrite6;
		private System.Windows.Forms.CheckBox checkBoxWrite7;
		private System.Windows.Forms.CheckBox checkBoxWrite8;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		/// <summary>
		/// Necessary designer variable 
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form4(CArtCam a)
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
			this.checkBoxRead7 = new System.Windows.Forms.CheckBox();
			this.checkBoxRead8 = new System.Windows.Forms.CheckBox();
			this.checkBoxRead5 = new System.Windows.Forms.CheckBox();
			this.checkBoxRead6 = new System.Windows.Forms.CheckBox();
			this.checkBoxRead3 = new System.Windows.Forms.CheckBox();
			this.checkBoxRead4 = new System.Windows.Forms.CheckBox();
			this.checkBoxRead2 = new System.Windows.Forms.CheckBox();
			this.checkBoxRead1 = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBoxWrite1 = new System.Windows.Forms.CheckBox();
			this.checkBoxWrite2 = new System.Windows.Forms.CheckBox();
			this.checkBoxWrite3 = new System.Windows.Forms.CheckBox();
			this.checkBoxWrite4 = new System.Windows.Forms.CheckBox();
			this.checkBoxWrite5 = new System.Windows.Forms.CheckBox();
			this.checkBoxWrite6 = new System.Windows.Forms.CheckBox();
			this.checkBoxWrite7 = new System.Windows.Forms.CheckBox();
			this.checkBoxWrite8 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBoxRead7);
			this.groupBox1.Controls.Add(this.checkBoxRead8);
			this.groupBox1.Controls.Add(this.checkBoxRead5);
			this.groupBox1.Controls.Add(this.checkBoxRead6);
			this.groupBox1.Controls.Add(this.checkBoxRead3);
			this.groupBox1.Controls.Add(this.checkBoxRead4);
			this.groupBox1.Controls.Add(this.checkBoxRead2);
			this.groupBox1.Controls.Add(this.checkBoxRead1);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(216, 80);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Register for reading";
			// 
			// checkBoxRead7
			// 
			this.checkBoxRead7.Enabled = false;
			this.checkBoxRead7.Location = new System.Drawing.Point(184, 32);
			this.checkBoxRead7.Name = "checkBoxRead7";
			this.checkBoxRead7.Size = new System.Drawing.Size(16, 24);
			this.checkBoxRead7.TabIndex = 7;
			// 
			// checkBoxRead8
			// 
			this.checkBoxRead8.Enabled = false;
			this.checkBoxRead8.Location = new System.Drawing.Point(160, 32);
			this.checkBoxRead8.Name = "checkBoxRead8";
			this.checkBoxRead8.Size = new System.Drawing.Size(16, 24);
			this.checkBoxRead8.TabIndex = 6;
			// 
			// checkBoxRead5
			// 
			this.checkBoxRead5.Enabled = false;
			this.checkBoxRead5.Location = new System.Drawing.Point(136, 32);
			this.checkBoxRead5.Name = "checkBoxRead5";
			this.checkBoxRead5.Size = new System.Drawing.Size(16, 24);
			this.checkBoxRead5.TabIndex = 5;
			// 
			// checkBoxRead6
			// 
			this.checkBoxRead6.Enabled = false;
			this.checkBoxRead6.Location = new System.Drawing.Point(112, 32);
			this.checkBoxRead6.Name = "checkBoxRead6";
			this.checkBoxRead6.Size = new System.Drawing.Size(16, 24);
			this.checkBoxRead6.TabIndex = 4;
			// 
			// checkBoxRead3
			// 
			this.checkBoxRead3.Enabled = false;
			this.checkBoxRead3.Location = new System.Drawing.Point(88, 32);
			this.checkBoxRead3.Name = "checkBoxRead3";
			this.checkBoxRead3.Size = new System.Drawing.Size(16, 24);
			this.checkBoxRead3.TabIndex = 3;
			// 
			// checkBoxRead4
			// 
			this.checkBoxRead4.Enabled = false;
			this.checkBoxRead4.Location = new System.Drawing.Point(64, 32);
			this.checkBoxRead4.Name = "checkBoxRead4";
			this.checkBoxRead4.Size = new System.Drawing.Size(16, 24);
			this.checkBoxRead4.TabIndex = 2;
			// 
			// checkBoxRead2
			// 
			this.checkBoxRead2.Enabled = false;
			this.checkBoxRead2.Location = new System.Drawing.Point(40, 32);
			this.checkBoxRead2.Name = "checkBoxRead2";
			this.checkBoxRead2.Size = new System.Drawing.Size(16, 24);
			this.checkBoxRead2.TabIndex = 1;
			// 
			// checkBoxRead1
			// 
			this.checkBoxRead1.Enabled = false;
			this.checkBoxRead1.Location = new System.Drawing.Point(16, 32);
			this.checkBoxRead1.Name = "checkBoxRead1";
			this.checkBoxRead1.Size = new System.Drawing.Size(16, 24);
			this.checkBoxRead1.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.checkBoxWrite1);
			this.groupBox2.Controls.Add(this.checkBoxWrite2);
			this.groupBox2.Controls.Add(this.checkBoxWrite3);
			this.groupBox2.Controls.Add(this.checkBoxWrite4);
			this.groupBox2.Controls.Add(this.checkBoxWrite5);
			this.groupBox2.Controls.Add(this.checkBoxWrite6);
			this.groupBox2.Controls.Add(this.checkBoxWrite7);
			this.groupBox2.Controls.Add(this.checkBoxWrite8);
			this.groupBox2.Location = new System.Drawing.Point(8, 104);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(216, 80);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Register for writing";
			// 
			// checkBoxWrite1
			// 
			this.checkBoxWrite1.Enabled = false;
			this.checkBoxWrite1.Location = new System.Drawing.Point(184, 32);
			this.checkBoxWrite1.Name = "checkBoxWrite1";
			this.checkBoxWrite1.Size = new System.Drawing.Size(16, 24);
			this.checkBoxWrite1.TabIndex = 15;
			// 
			// checkBoxWrite2
			// 
			this.checkBoxWrite2.Enabled = false;
			this.checkBoxWrite2.Location = new System.Drawing.Point(160, 32);
			this.checkBoxWrite2.Name = "checkBoxWrite2";
			this.checkBoxWrite2.Size = new System.Drawing.Size(16, 24);
			this.checkBoxWrite2.TabIndex = 14;
			// 
			// checkBoxWrite3
			// 
			this.checkBoxWrite3.Enabled = false;
			this.checkBoxWrite3.Location = new System.Drawing.Point(136, 32);
			this.checkBoxWrite3.Name = "checkBoxWrite3";
			this.checkBoxWrite3.Size = new System.Drawing.Size(16, 24);
			this.checkBoxWrite3.TabIndex = 13;
			// 
			// checkBoxWrite4
			// 
			this.checkBoxWrite4.Enabled = false;
			this.checkBoxWrite4.Location = new System.Drawing.Point(112, 32);
			this.checkBoxWrite4.Name = "checkBoxWrite4";
			this.checkBoxWrite4.Size = new System.Drawing.Size(16, 24);
			this.checkBoxWrite4.TabIndex = 12;
			// 
			// checkBoxWrite5
			// 
			this.checkBoxWrite5.Enabled = false;
			this.checkBoxWrite5.Location = new System.Drawing.Point(88, 32);
			this.checkBoxWrite5.Name = "checkBoxWrite5";
			this.checkBoxWrite5.Size = new System.Drawing.Size(16, 24);
			this.checkBoxWrite5.TabIndex = 11;
			// 
			// checkBoxWrite6
			// 
			this.checkBoxWrite6.Enabled = false;
			this.checkBoxWrite6.Location = new System.Drawing.Point(64, 32);
			this.checkBoxWrite6.Name = "checkBoxWrite6";
			this.checkBoxWrite6.Size = new System.Drawing.Size(16, 24);
			this.checkBoxWrite6.TabIndex = 10;
			// 
			// checkBoxWrite7
			// 
			this.checkBoxWrite7.Enabled = false;
			this.checkBoxWrite7.Location = new System.Drawing.Point(40, 32);
			this.checkBoxWrite7.Name = "checkBoxWrite7";
			this.checkBoxWrite7.Size = new System.Drawing.Size(16, 24);
			this.checkBoxWrite7.TabIndex = 9;
			// 
			// checkBoxWrite8
			// 
			this.checkBoxWrite8.Enabled = false;
			this.checkBoxWrite8.Location = new System.Drawing.Point(16, 32);
			this.checkBoxWrite8.Name = "checkBoxWrite8";
			this.checkBoxWrite8.Size = new System.Drawing.Size(16, 24);
			this.checkBoxWrite8.TabIndex = 8;
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(240, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 72);
			this.button1.TabIndex = 2;
			this.button1.Text = "Read";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(240, 104);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 72);
			this.button2.TabIndex = 3;
			this.button2.Text = "Write";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(240, 192);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(80, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "Close";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Form4
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(328, 229);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form4";
			this.Text = "IO setting";
			this.Load += new System.EventHandler(this.Form4_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void Form4_Load(object sender, System.EventArgs e)
		{
					button1.Enabled = true;
					checkBoxRead1.Enabled = true;
					checkBoxRead2.Enabled = true;
					checkBoxRead3.Enabled = true;
					checkBoxRead4.Enabled = true;
					checkBoxRead5.Enabled = true;
					checkBoxRead6.Enabled = true;
					checkBoxRead7.Enabled = true;
					checkBoxRead8.Enabled = true;

					button2.Enabled = true;
					checkBoxWrite1.Enabled = true;
					checkBoxWrite2.Enabled = true;
					checkBoxWrite3.Enabled = true;
					checkBoxWrite4.Enabled = true;
					checkBoxWrite5.Enabled = true;
					checkBoxWrite6.Enabled = true;
					checkBoxWrite7.Enabled = true;
					checkBoxWrite8.Enabled = true;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			byte Data = 0x00;
			int longdata = 0;
			if(m_CArtCam.GetIOPort(out Data, out longdata, 0))
			{
				checkBoxRead1.Checked = (0 != (Data & 0x01)) ? true : false;
				checkBoxRead2.Checked = (0 != (Data & 0x02)) ? true : false;
				checkBoxRead3.Checked = (0 != (Data & 0x04)) ? true : false;
				checkBoxRead4.Checked = (0 != (Data & 0x08)) ? true : false;
				checkBoxRead5.Checked = (0 != (Data & 0x10)) ? true : false;
				checkBoxRead6.Checked = (0 != (Data & 0x20)) ? true : false;
				checkBoxRead7.Checked = (0 != (Data & 0x40)) ? true : false;
				checkBoxRead8.Checked = (0 != (Data & 0x80)) ? true : false;
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			byte Data = 0x00;
			if(checkBoxWrite1.Checked) Data |= 0x01;
			if(checkBoxWrite2.Checked) Data |= 0x02;
			if(checkBoxWrite3.Checked) Data |= 0x04;
			if(checkBoxWrite4.Checked) Data |= 0x08;
			if(checkBoxWrite5.Checked) Data |= 0x10;
			if(checkBoxWrite6.Checked) Data |= 0x20;
			if(checkBoxWrite7.Checked) Data |= 0x40;
			if(checkBoxWrite8.Checked) Data |= 0x80;

			m_CArtCam.SetIOPort(Data, 0, 0);

		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			Hide();
		}
	}
}



namespace AcquisitionInc
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DoStuffButton = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.ConsoleBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(12, 12);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(148, 23);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect to Camera";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DoStuffButton
            // 
            this.DoStuffButton.Enabled = false;
            this.DoStuffButton.Location = new System.Drawing.Point(167, 11);
            this.DoStuffButton.Name = "DoStuffButton";
            this.DoStuffButton.Size = new System.Drawing.Size(148, 23);
            this.DoStuffButton.TabIndex = 1;
            this.DoStuffButton.Text = "Do Stuff!";
            this.DoStuffButton.UseVisualStyleBackColor = true;
            this.DoStuffButton.Click += new System.EventHandler(this.DoStuffButton_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(321, 11);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(467, 23);
            this.ProgressBar.TabIndex = 2;
            // 
            // ConsoleBox
            // 
            this.ConsoleBox.Enabled = false;
            this.ConsoleBox.Location = new System.Drawing.Point(12, 41);
            this.ConsoleBox.Multiline = true;
            this.ConsoleBox.Name = "ConsoleBox";
            this.ConsoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConsoleBox.Size = new System.Drawing.Size(775, 397);
            this.ConsoleBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConsoleBox);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.DoStuffButton);
            this.Controls.Add(this.ConnectButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DoStuffButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.TextBox ConsoleBox;
    }
}


using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using ArtCamSdk;


namespace Sample_CS
{
	/// <summary>
	/// This is an explanation for outline of "Form1".
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MainMenu mainMenu1;

		private byte[] m_pCapture;
		private Bitmap m_Bitmap = null;
		private int m_PreviewMode = -1;
		private CArtCam m_CArtCam = new CArtCam();
		private int m_DllType  = -1;
		private int m_DllCount = 0;
		private int m_DllSata  = -1;
		private int m_SataType = -1;

		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuSave;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.MenuItem menuView;
		private System.Windows.Forms.MenuItem menuPreview;
		private System.Windows.Forms.MenuItem menuCallback;
		private System.Windows.Forms.MenuItem menuSnapshot;
		private System.Windows.Forms.MenuItem menuCapture;
		private System.Windows.Forms.MenuItem menuTrigger;
		private System.Windows.Forms.MenuItem menuSet;
		private System.Windows.Forms.MenuItem menuCamera;
		private System.Windows.Forms.MenuItem menuFilter;
		private System.Windows.Forms.MenuItem menuAnalog;
		private System.Windows.Forms.MenuItem menuDevice;
		private System.Windows.Forms.MenuItem menuDevice0;
		private System.Windows.Forms.MenuItem menuDevice1;
		private System.Windows.Forms.MenuItem menuDevice2;
		private System.Windows.Forms.MenuItem menuDevice3;
		private System.Windows.Forms.MenuItem menuDevice4;
		private System.Windows.Forms.MenuItem menuDevice5;
		private System.Windows.Forms.MenuItem menuDevice6;
		private System.Windows.Forms.MenuItem menuDevice7;
		private System.Windows.Forms.MenuItem menuDLL;
		private System.Windows.Forms.MenuItem menuDllReload;
		private System.Windows.Forms.Panel ImagePanel;
		private System.Windows.Forms.PictureBox ImageBox;
		private System.Windows.Forms.Timer timer1;


		[DllImport("user32.dll")]
		public static extern IntPtr GetWindow (IntPtr hWnd, int uCmd);

		[DllImport("user32.dll")]
		public static extern int SetWindowPos (IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);


		public Form1()
		{
			//
			// This is needed for Windows form designer support.
			//
			InitializeComponent();

			//
			// TODO: Add constructor code after calling InitializeComponent.
			//
		}

		/// <summary>
		/// Execute after-treatment to resource used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
			Release();
			m_CArtCam.FreeLibrary();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// This method is required for designer support.
		/// Do not change the content of this method by code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuSave = new System.Windows.Forms.MenuItem();
			this.menuExit = new System.Windows.Forms.MenuItem();
			this.menuView = new System.Windows.Forms.MenuItem();
			this.menuPreview = new System.Windows.Forms.MenuItem();
			this.menuCallback = new System.Windows.Forms.MenuItem();
			this.menuSnapshot = new System.Windows.Forms.MenuItem();
			this.menuCapture = new System.Windows.Forms.MenuItem();
			this.menuTrigger = new System.Windows.Forms.MenuItem();
			this.menuSet = new System.Windows.Forms.MenuItem();
			this.menuCamera = new System.Windows.Forms.MenuItem();
			this.menuFilter = new System.Windows.Forms.MenuItem();
			this.menuAnalog = new System.Windows.Forms.MenuItem();
			this.menuDLL = new System.Windows.Forms.MenuItem();
			this.menuDllReload = new System.Windows.Forms.MenuItem();
			this.menuDevice = new System.Windows.Forms.MenuItem();
			this.menuDevice0 = new System.Windows.Forms.MenuItem();
			this.menuDevice1 = new System.Windows.Forms.MenuItem();
			this.menuDevice2 = new System.Windows.Forms.MenuItem();
			this.menuDevice3 = new System.Windows.Forms.MenuItem();
			this.menuDevice4 = new System.Windows.Forms.MenuItem();
			this.menuDevice5 = new System.Windows.Forms.MenuItem();
			this.menuDevice6 = new System.Windows.Forms.MenuItem();
			this.menuDevice7 = new System.Windows.Forms.MenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.ImagePanel = new System.Windows.Forms.Panel();
			this.ImageBox = new System.Windows.Forms.PictureBox();
			this.ImagePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuFile,
																					  this.menuView,
																					  this.menuSet,
																					  this.menuDLL,
																					  this.menuDevice});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuSave,
																					 this.menuExit});
			this.menuFile.Text = "File(&F)";
			// 
			// menuSave
			// 
			this.menuSave.Index = 0;
			this.menuSave.Text = "Save(&S)";
			this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
			// 
			// menuExit
			// 
			this.menuExit.Index = 1;
			this.menuExit.Text = "End(&X)";
			this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
			// 
			// menuView
			// 
			this.menuView.Index = 1;
			this.menuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuPreview,
																					 this.menuCallback,
																					 this.menuSnapshot,
																					 this.menuCapture,
																					 this.menuTrigger});
			this.menuView.Text = "Display(&V)";
			// 
			// menuPreview
			// 
			this.menuPreview.Index = 0;
			this.menuPreview.Text = "Preview(&P)";
			this.menuPreview.Click += new System.EventHandler(this.menuPreview_Click);
			// 
			// menuCallback
			// 
			this.menuCallback.Index = 1;
			this.menuCallback.Text = "Callback(&B)";
			this.menuCallback.Click += new System.EventHandler(this.menuCallback_Click);
			// 
			// menuSnapshot
			// 
			this.menuSnapshot.Index = 2;
			this.menuSnapshot.Text = "Snapshot(&S)";
			this.menuSnapshot.Click += new System.EventHandler(this.menuSnapshot_Click);
			// 
			// menuCapture
			// 
			this.menuCapture.Index = 3;
			this.menuCapture.Text = "Capture(&C)";
			this.menuCapture.Click += new System.EventHandler(this.menuCapture_Click);
			// 
			// menuTrigger
			// 
			this.menuTrigger.Index = 4;
			this.menuTrigger.Text = "Trigger(&T)";
			this.menuTrigger.Click += new System.EventHandler(this.menuTrigger_Click);
			// 
			// menuSet
			// 
			this.menuSet.Index = 2;
			this.menuSet.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuCamera,
																					this.menuFilter,
																					this.menuAnalog});
			this.menuSet.Text = "Settings(&S)";
			// 
			// menuCamera
			// 
			this.menuCamera.Index = 0;
			this.menuCamera.Text = "Camera settings(&C)";
			this.menuCamera.Click += new System.EventHandler(this.menuCamera_Click);
			// 
			// menuFilter
			// 
			this.menuFilter.Index = 1;
			this.menuFilter.Text = "Filter settings(&F)";
			this.menuFilter.Click += new System.EventHandler(this.menuFilter_Click);
			// 
			// menuAnalog
			// 
			this.menuAnalog.Index = 2;
			this.menuAnalog.Text = "Analog settings(&A)";
			this.menuAnalog.Click += new System.EventHandler(this.menuAnalog_Click);
			// 
			// menuDLL
			// 
			this.menuDLL.Index = 3;
			this.menuDLL.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuDllReload});
			this.menuDLL.Text = "DLL(&L)";
			// 
			// menuDllReload
			// 
			this.menuDllReload.Index = 0;
			this.menuDllReload.Text = "Reload";
			this.menuDllReload.Click += new System.EventHandler(this.menuDllReload_Click);
			// 
			// menuDevice
			// 
			this.menuDevice.Index = 4;
			this.menuDevice.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuDevice0,
																					   this.menuDevice1,
																					   this.menuDevice2,
																					   this.menuDevice3,
																					   this.menuDevice4,
																					   this.menuDevice5,
																					   this.menuDevice6,
																					   this.menuDevice7});
			this.menuDevice.Text = "Device(&D)";
			// 
			// menuDevice0
			// 
			this.menuDevice0.Index = 0;
			this.menuDevice0.Text = "0";
			this.menuDevice0.Click += new System.EventHandler(this.menuDevice0_Click);
			// 
			// menuDevice1
			// 
			this.menuDevice1.Index = 1;
			this.menuDevice1.Text = "1";
			this.menuDevice1.Click += new System.EventHandler(this.menuDevice1_Click);
			// 
			// menuDevice2
			// 
			this.menuDevice2.Index = 2;
			this.menuDevice2.Text = "2";
			this.menuDevice2.Click += new System.EventHandler(this.menuDevice2_Click);
			// 
			// menuDevice3
			// 
			this.menuDevice3.Index = 3;
			this.menuDevice3.Text = "3";
			this.menuDevice3.Click += new System.EventHandler(this.menuDevice3_Click);
			// 
			// menuDevice4
			// 
			this.menuDevice4.Index = 4;
			this.menuDevice4.Text = "4";
			this.menuDevice4.Click += new System.EventHandler(this.menuDevice4_Click);
			// 
			// menuDevice5
			// 
			this.menuDevice5.Index = 5;
			this.menuDevice5.Text = "5";
			this.menuDevice5.Click += new System.EventHandler(this.menuDevice5_Click);
			// 
			// menuDevice6
			// 
			this.menuDevice6.Index = 6;
			this.menuDevice6.Text = "6";
			this.menuDevice6.Click += new System.EventHandler(this.menuDevice6_Click);
			// 
			// menuDevice7
			// 
			this.menuDevice7.Index = 7;
			this.menuDevice7.Text = "7";
			this.menuDevice7.Click += new System.EventHandler(this.menuDevice7_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// ImagePanel
			// 
			this.ImagePanel.AutoScroll = true;
			this.ImagePanel.BackColor = System.Drawing.SystemColors.Control;
			this.ImagePanel.Controls.Add(this.ImageBox);
			this.ImagePanel.Location = new System.Drawing.Point(48, 32);
			this.ImagePanel.Name = "ImagePanel";
			this.ImagePanel.Size = new System.Drawing.Size(552, 400);
			this.ImagePanel.TabIndex = 2;
			// 
			// ImageBox
			// 
			this.ImageBox.Location = new System.Drawing.Point(16, 16);
			this.ImageBox.Name = "ImageBox";
			this.ImageBox.Size = new System.Drawing.Size(40, 40);
			this.ImageBox.TabIndex = 0;
			this.ImageBox.TabStop = false;
			this.ImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageBox_Paint);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.ClientSize = new System.Drawing.Size(640, 481);
			this.Controls.Add(this.ImagePanel);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "C# Sample";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ImagePanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Main entry point for application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		protected override unsafe void WndProc(ref Message m)
		{
			// WM_GRAPHNOTIFY
			if(DLL_MESSAGE.WM_GRAPHNOTIFY == (DLL_MESSAGE)m.Msg)
			{
			}
			// WM_ERROR
			else if(DLL_MESSAGE.WM_ERROR == (DLL_MESSAGE)m.Msg ||
				(DLL_MESSAGE.WM_GRAPHPAINT == (DLL_MESSAGE)m.Msg && null == (GP_INFO*)m.WParam)
				)
			{
			}
			// WM_GRAPHPAINT
			else if(DLL_MESSAGE.WM_GRAPHPAINT == (DLL_MESSAGE)m.Msg)
			{
				GP_INFO* pInfo = (GP_INFO*)m.WParam;
				if(pInfo != null){
					ImageBox.Invalidate();
				}
			}
			else
			{
				base.WndProc(ref m);
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			// Drawing by double buffer(not to flicker)
			this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

			if(File.Exists("Sample.xml"))
			{
				System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(int[]));
				System.IO.FileStream fs = new System.IO.FileStream("Sample.xml", System.IO.FileMode.Open);
				int[] Type = new int[2];
				Type = (int[])ser.Deserialize(fs);
				fs.Close();
				m_DllType = Type[0];
				m_SataType= Type[1];
			}
			OnDllReload();
			if( -1 != m_DllType){
				OnDllChange((object)0, System.EventArgs.Empty, m_DllType, m_SataType);
				}
			}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(m_DllType != -1)
			{
				int[] Type = {(int)m_DllType, (int)m_SataType};
				System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(int[]));
				System.IO.FileStream fs = new System.IO.FileStream("Sample.xml", System.IO.FileMode.Create);
				ser.Serialize(fs, Type);
				fs.Close();
		}

			Release();
		}

		private void Release()
		{
			m_CArtCam.Release();
			if(m_Bitmap != null){
				m_Bitmap.Dispose();
				m_Bitmap = null;
			}

			m_PreviewMode = -1;
			timer1.Enabled = false;
		}


		// Save
		private void menuSave_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			m_CArtCam.SaveImage("image.jpg", FILETYPE.FILETYPE_JPEG_NOMAL);
		}

		// End
		private void menuExit_Click(object sender, System.EventArgs e)
		{
			Close();		
		}

		// Preview Draw automatically
		private void menuPreview_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			ImagePanel.Visible = false;
			timer1.Enabled = false;

			// Release device
			m_CArtCam.Close();

			// Set window to be displayed
			// When setting NULL to hWnd,it is possible to create new window and show it.
			m_CArtCam.SetPreviewWindow(this.Handle, 0, 0, this.Width, this.Height);

			m_CArtCam.Preview();

			// Check menu
			menuPreview.Checked  = true;
			menuCallback.Checked = false;
			menuCapture.Checked  = false;
			menuTrigger.Checked  = false;

			m_PreviewMode = 0;
		}

		// Callback: Obtain image pointer of image and draw its own.
		private void menuCallback_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			ImagePanel.Visible = true;
			timer1.Enabled = false;

			// Release device
			m_CArtCam.Close();

			// If drawing by yourself, set all window size to 0.
			// An automatic display can be performed, if window size is set up even when using CallBackPreview
			m_CArtCam.SetPreviewWindow(this.Handle, 0, 0, 0, 0);

			// Create bit-map
			CreateBitmap();

			ImageBox.SetBounds(0, 0, getWidth(), getHeight());

			// Capture image
			m_CArtCam.CallBackPreview(this.Handle, m_pCapture, getSize(), 1);

			// Check menu
			menuPreview.Checked  = false;
			menuCallback.Checked = true;
			menuCapture.Checked  = false;
			menuTrigger.Checked  = false;

			m_PreviewMode = 1;
			ImageBox.Invalidate();
		}

		// Snapshot
		private void menuSnapshot_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			ImagePanel.Visible = true;
			timer1.Enabled = false;

			// Release device
			m_CArtCam.Close();

			// Create bit-map
			CreateBitmap();

			ImageBox.SetBounds(0, 0, getWidth(), getHeight());

			m_CArtCam.SnapShot(m_pCapture, getSize(), 1);

			// Check menu
			menuPreview.Checked  = false;
			menuCallback.Checked = false;
			menuCapture.Checked  = false;
			menuTrigger.Checked  = false;

			m_PreviewMode = 2;

			timer1.Enabled = true;
			timer1.Interval = 100;

			ImageBox.Invalidate();

		}

		// Capture
		private void menuCapture_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			ImagePanel.Visible = true;
			timer1.Enabled = false;

			// Release device
			m_CArtCam.Close();

			// Create bit-map
			CreateBitmap();

			ImageBox.SetBounds(0, 0, getWidth(), getHeight());

			m_CArtCam.Capture();

			// Check menu
			menuPreview.Checked  = false;
			menuCallback.Checked = false;
			menuCapture.Checked  = true;
			menuTrigger.Checked  = false;

			ImageBox.Invalidate();

			timer1.Interval = 100;
			timer1.Enabled = true;
			m_PreviewMode = 3;
		}

		// Capture timer
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(m_PreviewMode == 3)
			{
				m_CArtCam.SnapShot(m_pCapture, getSize(), 1);
			}
			ImageBox.Invalidate();
		}

		// Trigger
		private void menuTrigger_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			ImagePanel.Visible = true;
			timer1.Enabled = false;

			// Release device
			m_CArtCam.Close();

			// If drawing by yourself, set all window size to 0.
			// An automatic display can be performed, if window size is set up even when using CallBackPreview
			m_CArtCam.SetPreviewWindow(this.Handle, 0, 0, 0, 0);

			// Create bit-map
			CreateBitmap();

			ImageBox.SetBounds(0, 0, getWidth(), getHeight());

			m_CArtCam.Trigger(this.Handle, m_pCapture, getSize(), 1);

			// Check menu
			menuPreview.Checked  = false;
			menuCallback.Checked = false;
			menuCapture.Checked  = false;
			menuTrigger.Checked  = true;

			ImageBox.Invalidate();
			m_PreviewMode = 4;
		}

		// Create bit-map
		private void CreateBitmap()
		{
			// In case bitmap is already created, release.
			if(null != m_Bitmap)
			{
				m_Bitmap.Dispose();
			}

			switch(getColorMode())
			{
				case 8:
				case 16:
					m_Bitmap = new Bitmap(getWidth(), getHeight(), PixelFormat.Format8bppIndexed);

					// Pallet modification
					ColorPalette pal = m_Bitmap.Palette;
					Color[] cpe = m_Bitmap.Palette.Entries;

					for(int i=0; i<256; i++)
					{
						cpe.SetValue(Color.FromArgb(i, i, i), i);
						pal.Entries[i] = cpe[i];
					}
					m_Bitmap.Palette = pal;
				break;

				case 24:	m_Bitmap = new Bitmap(getWidth(), getHeight(), PixelFormat.Format24bppRgb);			break;
				case 32:	m_Bitmap = new Bitmap(getWidth(), getHeight(), PixelFormat.Format24bppRgb);			break;
				case 48:	m_Bitmap = new Bitmap(getWidth(), getHeight(), PixelFormat.Format24bppRgb);			break;
				case 64:	m_Bitmap = new Bitmap(getWidth(), getHeight(), PixelFormat.Format24bppRgb);			break;
			}

			// Arrangement for capture
			m_pCapture = new Byte[getSize()];
		}


		// Camera settings
		private void menuCamera_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			if(0 != m_CArtCam.SetCameraDlg(this.Handle))
			{
				switch(m_PreviewMode)
				{
					case 1: menuPreview_Click(sender, e); break;
					case 2: menuCallback_Click(sender, e); break;
				}
			}
		}

		// Filter settings
		private void menuFilter_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			m_CArtCam.SetImageDlg(this.Handle);
		}

		// Analog settings
		private void menuAnalog_Click(object sender, System.EventArgs e)
		{
			if(!m_CArtCam.IsInit())
			{
				MessageBox.Show("Select available device");
				return;
			}

			m_CArtCam.SetAnalogDlg(this.Handle);
		}

		private void OnDllReload()
		{
			// Delete DLL list
			for (int i=0; i<m_DllCount; i++){
				menuDLL.MenuItems.RemoveAt(1);
			}
			m_DllCount = 0;
			m_DllSata  = -1;

			// Search for DLL
			String szDirPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			String[] files = Directory.GetFiles(szDirPath, "Art*.dll");
			foreach (String szFileName in files)
			{
				CArtCam ArtCam = new CArtCam();
				if (ArtCam.LoadLibrary(szFileName)){

					// Obtain version and show it
					long ver = ArtCam.GetDllVersion() & 0xFFFF;
					String szMenu = String.Format("{0}\tVersion {1:D4}", Path.GetFileNameWithoutExtension(szFileName), ver);

					// Add to menu
					m_DllCount++;
					if(ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_SATA == (ARTCAM_CAMERATYPE)(ArtCam.GetDllVersion() >> 16)){
						
						MenuItem menuSata = new MenuItem();
						menuSata.Text = szMenu;
						String[] CameraName = {
											"LVDS",
											"300MI",
											"500MI",
											"MV413",
											"800MI",
											"036MI",
											"150P3",
											"267KY",
											"274KY",
											"625KY",
											"130MI",
											"200MI",
										};
						for(int i=0; i<CameraName.Length; i++){
							MenuItem mi = new MenuItem();
							mi.Text = CameraName[i];
							mi.Click += new System.EventHandler(OnMenuDLLSelect);
							menuSata.MenuItems.Add(i, mi);
						}
						menuDLL.MenuItems.Add(m_DllCount, menuSata);
						m_DllSata = m_DllCount-1;
					}else{
						MenuItem mi = new MenuItem();
						mi.Text = szMenu;
						mi.Click += new System.EventHandler(OnMenuDLLSelect);
						menuDLL.MenuItems.Add(m_DllCount, mi);
					}
				}
			}
		}

		private void OnMenuDLLSelect(object sender, System.EventArgs e)
		{
			int id = menuDLL.MenuItems.IndexOf((MenuItem)sender);
			if (id > -1){
				OnDllChange(sender, e, id-1, -1);
			}else{
				int type = ((MenuItem)sender).Index;
				if((int)ARTCAM_CAMERATYPE_SATA.ARTCAM_CAMERATYPE_SATA_LVDS <= type && type <= (int)ARTCAM_CAMERATYPE_SATA.ARTCAM_CAMERATYPE_SATA_200MI){
					OnDllChange(sender, e, m_DllSata, type);
				}
			}
		}
		// Change Device
		private void DeviceChange(object sender, System.EventArgs e, int Number)
		{
			if(m_CArtCam.IsInit())
			{
				m_CArtCam.Close();
			}


			// To confirm whether the device is connected, use "GetDeviceName"
			// It can be found out easily with "GetDeviceName".
			// When area for obtain name is not secured, it results in error. Prepare alignment length of at least 32.
			StringBuilder Temp = new StringBuilder( 256 );
			if(0 == m_CArtCam.GetDeviceName(Number, Temp, 256))
			{
				m_PreviewMode = -1;
				return;
			}


			// A device will be changed, if a camera is displayed after changing the number of a device now
			// Notes: A device is not changed in this function simple substance
			//   After calling this function, a device is changed by initializing a device
			m_CArtCam.SetDeviceNumber(Number);


			for(int i=0; i<8; i++)
			{
				menuDevice.MenuItems[i].Checked = false;
			}
			menuDevice.MenuItems[Number].Checked = true;
		}

		private void menuDevice0_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 0); }
		private void menuDevice1_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 1); }
		private void menuDevice2_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 2); }
		private void menuDevice3_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 3); }
		private void menuDevice4_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 4); }
		private void menuDevice5_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 5); }
		private void menuDevice6_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 6); }
		private void menuDevice7_Click(object sender, System.EventArgs e){ DeviceChange(sender, e, 7); }

		private int getSize()
		{
			return ((getWidth() * (getColorMode() / 8) + 3) & ~3) * getHeight();
		}

		private int getWidth()
		{
			int[] Size = { 1, 2, 4, 8 };
			return m_CArtCam.Width() / Size[(int)(getSubSample())];
		}

		private int getHeight()
		{
			int[] Size = { 1, 2, 4, 8 };
			return m_CArtCam.Height() / Size[(int)getSubSample()];
		}

		private int getColorMode()
		{
			return ((m_CArtCam.GetColorMode() + 7) & ~7);
		}

		private int getSubSample()
			{
			return ((int)m_CArtCam.GetSubSample() & 0x03);
		}

		private BitmapData LockBitmap()
		{
			switch(getColorMode())
			{
				case 8:
				case 16:
					return m_Bitmap.LockBits(new Rectangle(0,0,getWidth(),getHeight()), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

				case 24:
				case 32:
				case 48:
				case 64:
					return m_Bitmap.LockBits(new Rectangle(0,0,getWidth(),getHeight()), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			}

			return null;
		}

		private void DrawImage(Graphics g)
		{
			if(null == m_Bitmap)
			{
				return ;
			}

			BitmapData pBitmapData = LockBitmap();
			if(null == pBitmapData)
				{
				return ;
				}


				unsafe
				{
				byte* pdest = (byte*)pBitmapData.Scan0.ToPointer();

				// In case of 16 bit transfer,convert to 8 bit and display
				if(getColorMode() == 16)
				{
					int size = getWidth() * getHeight();
					switch(m_CArtCam.GetColorMode())
					{
						case 10: for(int i=0; i<size; i++) pdest[i] = (byte)((m_pCapture[i*2+1] << 6) | (m_pCapture[i*2] >> 2));	break;
						case 12: for(int i=0; i<size; i++) pdest[i] = (byte)((m_pCapture[i*2+1] << 4) | (m_pCapture[i*2] >> 4));	break;
						case 14: for(int i=0; i<size; i++) pdest[i] = (byte)((m_pCapture[i*2+1] << 2) | (m_pCapture[i*2] >> 6));	break;
						case 16: for(int i=0; i<size; i++) pdest[i] = (byte)((m_pCapture[i*2+1] << 0) | (m_pCapture[i*2] >> 8));	break;
					}
				}
				else if(getColorMode() == 32)
				{
					int size = getWidth() * getHeight();
					for(int i=0; i<size; i++)
					{
						pdest[i*3]   = m_pCapture[i*4];
						pdest[i*3+1] = m_pCapture[i*4+1];
						pdest[i*3+2] = m_pCapture[i*4+2];
					}
				}
				// This is a heavy load. When using 16 (10) bit color, use C language.
				else if(getColorMode() == 48 || getColorMode() == 64)
				{
					int bpp = getColorMode() / 8;
					int size = getWidth() * getHeight();
					switch(m_CArtCam.GetColorMode())
					{
						case 42: case 58:
							for(int i=0; i<size; i++)
							{
								pdest[i*3]   = (byte)((m_pCapture[i*bpp+1] << 6) | (m_pCapture[i*bpp]   >> 2));
								pdest[i*3+1] = (byte)((m_pCapture[i*bpp+3] << 6) | (m_pCapture[i*bpp+2] >> 2));
								pdest[i*3+2] = (byte)((m_pCapture[i*bpp+5] << 6) | (m_pCapture[i*bpp+4] >> 2));
					}
							break;
						case 44: case 60:
							for(int i=0; i<size; i++)
							{
								pdest[i*3]   = (byte)((m_pCapture[i*bpp+1] << 4) | (m_pCapture[i*bpp]   >> 4));
								pdest[i*3+1] = (byte)((m_pCapture[i*bpp+3] << 4) | (m_pCapture[i*bpp+2] >> 4));
								pdest[i*3+2] = (byte)((m_pCapture[i*bpp+5] << 4) | (m_pCapture[i*bpp+4] >> 4));
				}
							break;
						case 46: case 62:
							for(int i=0; i<size; i++)
							{
								pdest[i*3]   = (byte)((m_pCapture[i*bpp+1] << 2) | (m_pCapture[i*bpp]   >> 6));
								pdest[i*3+1] = (byte)((m_pCapture[i*bpp+3] << 2) | (m_pCapture[i*bpp+2] >> 6));
								pdest[i*3+2] = (byte)((m_pCapture[i*bpp+5] << 2) | (m_pCapture[i*bpp+4] >> 6));
			}
							break;
						case 48: case 64:
							for(int i=0; i<size; i++)
			{
								pdest[i*3]   = (byte)((m_pCapture[i*bpp+1] << 0) | (m_pCapture[i*bpp]   >> 8));
								pdest[i*3+1] = (byte)((m_pCapture[i*bpp+3] << 0) | (m_pCapture[i*bpp+2] >> 8));
								pdest[i*3+2] = (byte)((m_pCapture[i*bpp+5] << 0) | (m_pCapture[i*bpp+4] >> 8));
							}
							break;
					}
				}
				else
				{
					int size = getSize();
					for(int i=0; i<size; i++)
					{
						pdest[i] = m_pCapture[i];
					}
					}
				}

			m_Bitmap.UnlockBits(pBitmapData);


			// Image display
			int iWidth = m_Bitmap.Width;
			int iHeight= m_Bitmap.Height;
			g.DrawImage(m_Bitmap, new Rectangle(0, 0, getWidth(), getHeight()));
			}
		private void Form1_Resize(object sender, System.EventArgs e)
			{
			ImagePanel.SetBounds(0,0,this.ClientRectangle.Right,this.ClientRectangle.Bottom);
		}

		private void OnDllChange(object sender, System.EventArgs e, int DllType, int SataType)
		{
			Release();
			m_CArtCam.FreeLibrary();

			if (0 == m_DllCount) return;
			String stMenu = menuDLL.MenuItems[(int)DllType + 1].Text;
			String[] stArray = stMenu.Split('\t');
			String szDllName = String.Format("{0}.dll", stArray[0]);
			bool res = m_CArtCam.LoadLibrary(szDllName);
			if (!res){
				MessageBox.Show("DLL is not found.\nIt may have been relocated after executing.");
				return;
			}

			// Initialize is to be called first
			// By setting Window Handle here, WMLERROR can be obtained
			if (!m_CArtCam.Initialize(this.Handle)){
				MessageBox.Show("Failed to initialize SDK");
				return;
		}
			m_DllType = DllType;
			m_SataType = SataType;

			// Check menu
			for (int i = 0; i < m_DllCount; i++){
				menuDLL.MenuItems[(int)i + 1].Checked = false;
			}
			// Select SATA camera type when use Sata.dll
			if(-1 != SataType && ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_SATA == m_CArtCam.GetDllType()){
				m_CArtCam.SetCameraType(SataType);
				m_CArtCam.SetDeviceNumber(0);
			}else{
				menuDLL.MenuItems[(int)DllType+1].Checked = true;
			}


			for(int i=0; i<8; i++)
			{
				StringBuilder Temp = new StringBuilder( 256 );
				if(0 != m_CArtCam.GetDeviceName(i, Temp, 256))
				{
					menuDevice.MenuItems[i].Text = Temp.ToString();
					menuDevice.MenuItems[i].Enabled = true;
				}
				else
				{
					menuDevice.MenuItems[i].Enabled = false;
				}
			}

			DeviceChange(sender, e, 0);

		}

		private void menuDllReload_Click(object sender, System.EventArgs e)
					{
			OnDllReload();
					}

		private void ImageBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
					{
			DrawImage(e.Graphics);
		}

	}
}




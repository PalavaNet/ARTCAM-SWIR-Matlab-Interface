using ArtCamSdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcquisitionInc
{
    public partial class MainForm : Form
    {
        // Our private variables
        private CArtCam m_CArtCam = new CArtCam();
        private Bitmap m_Bitmap;
        private byte[] m_pCapture;

        // User available properties
        int startExposure = 21;
        int endExposure = 2000;
        int exposureStep = 1000;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

            m_CArtCam.Release();

            //if (m_Bitmap != null)
            //{
            //    m_Bitmap.Dispose();
            //    m_Bitmap = null;
            //}

            //m_PreviewMode = -1;
            //timer1.Enabled = false;
            //timerRec.Enabled = false;
            //m_SaveFlg = false;
            //m_StopFlg = false;
            m_CArtCam.FreeLibrary();

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            m_CArtCam.Release();
            m_CArtCam.FreeLibrary();

            // Find an appropriate DLL and load it. 
            string dirPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string[] files = Directory.GetFiles(dirPath, "Art*.dll");
            bool libraryLoadedSuccessfully = false;
            foreach (string fileName in files)
            {
                if (m_CArtCam.LoadLibrary(fileName))
                {
                    Console.WriteLine("Loaded DLL \'{0}\' from \"{1}\"", Path.GetFileNameWithoutExtension(fileName), fileName);
                    Console.WriteLine("DLL version is {0} .", m_CArtCam.GetDllVersion());
                    libraryLoadedSuccessfully = true;
                }
            }
            if (!libraryLoadedSuccessfully)
            {
                Console.WriteLine("Failed to load DLL.");
            }

            if (!m_CArtCam.Initialize(this.Handle))
            {
                Console.WriteLine("Failed to initialise camera.");
            }

            StringBuilder deviceName = new StringBuilder( 256 );
            if (0 == m_CArtCam.GetDeviceName(0, deviceName, 256))
            {
                Console.WriteLine("Failed to connect to camera.");
            }
            else
            {
                Console.WriteLine("Connected to {0}.", deviceName.ToString());
            }

            ConnectButton.Enabled = false;
            DoStuffButton.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Console.SetOut(new ConsoleWriter(ConsoleBox));
            Console.WriteLine("Now redirecting output to the text box");
        }

        private async void DoStuffButton_Click(object sender, EventArgs e)
        {
            // NB: This function just loads a background thread to do the work and can safely be ignored
            // The function you are actually looking for is DoStuff() :-)
            DoStuffButton.Enabled = false;

            // Get the date/time prefix we use for saving
            string prefix = DateTime.Now.ToString("yyyyMMddHHmmss");

            // Process variables
            int totalSteps = (int) Math.Ceiling(((double) (endExposure - startExposure)) / exposureStep + 1);

            // Setup progress bar
            ProgressBar.Maximum = totalSteps;
            ProgressBar.Step = 1;

            var progress = new Progress<int>(v =>
            {
                // This lambda is executed in context of UI thread,
                // so it can safely update form controls
                ProgressBar.Value = v;
            });

            // Run operation in another thread
            await Task.Run(() => DoStuff(prefix, progress));
            ProgressBar.Value = 0;

            DoStuffButton.Enabled = true;
        }

        public void DoStuff(string prefix, IProgress<int> progress)
        {
            // Set gain defaults (probably not necessary)
            m_CArtCam.SetGlobalGain(0);
            m_CArtCam.SetColorGainRed(0);
            m_CArtCam.SetColorGainGreen1(0);
            m_CArtCam.SetColorGainGreen2(0);
            m_CArtCam.SetColorGainBlue(0);
            m_CArtCam.SetBayerGainRed(0);
            m_CArtCam.SetBayerGainGreen(0);
            m_CArtCam.SetBayerGainBlue(0);

            // Other setup. Note that we get 64 bit colour out, we can then save only one channel
            m_CArtCam.SetColorMode(64);

            // Ok, lets loop over some stuff
            int totalSteps = (int) Math.Ceiling(((double) (endExposure - startExposure)) / exposureStep + 1);
            for (int step = 0; step < totalSteps; step++)
            {
                Console.WriteLine(string.Format("Starting capture step {0} of {1}.", step + 1, totalSteps));
                progress.Report(step + 1);

                // Set loop varying properties
                int currentExposure = startExposure + step*exposureStep;
                m_CArtCam.SetExposureTime(currentExposure);

                // Acquire image
                Console.WriteLine("Acquiring image...");
                m_CArtCam.Close();
                m_Bitmap = new Bitmap(m_CArtCam.Width(), m_CArtCam.Height(), PixelFormat.Format24bppRgb);
                m_pCapture = new Byte[((m_CArtCam.Width() * (16 / 8) + 3) & ~3) * m_CArtCam.Height()];
                if (m_CArtCam.SnapShot(m_pCapture, m_pCapture.Length, 1) <= 0)
                {
                    Console.WriteLine("Failed to read image, returning");
                    return;
                }

                // Save image
                string location = string.Format("{0}/{1}_{2}_{3}.png", Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), prefix, step + 1, 1);
                Console.WriteLine("Saving image to \"{0}\"...", location);
                if (m_CArtCam.SaveImage(location, FILETYPE.FILETYPE_PNG) <= 0)
                {
                    Console.WriteLine("Failed to save image, returning");
                    return;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_CArtCam.Release();
            m_CArtCam.FreeLibrary();
        }
    }
}

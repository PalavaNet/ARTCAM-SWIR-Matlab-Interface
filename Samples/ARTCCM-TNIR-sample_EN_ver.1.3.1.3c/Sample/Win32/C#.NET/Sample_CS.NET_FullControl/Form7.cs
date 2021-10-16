using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ArtCamSdk;

namespace Sample_CS
{
	public partial class Form7 : Form
	{
		private CArtCam				m_CArtCam = null;
		private ARTCAM_CAMERATYPE	m_DllType = 0;
		private CAMERAINFO			m_CameraInfo;
		private int					m_CursorNumber = 0;
		private bool				m_Init = false;

		public struct M_CURSOR{
			public int 		Enable;
			public int		SizeX;
			public int		SizeY;
			public int		PosX;
			public int		PosY;
			public int		Color;
		}
		private M_CURSOR[]	m_Cursor = new M_CURSOR[2];

		public Form7(CArtCam a)
		{
			InitializeComponent();
			m_CArtCam = a;
			m_Init = false;
		}

		private void Form7_Load(object sender, EventArgs e)
		{
			m_DllType = (ARTCAM_CAMERATYPE)(m_CArtCam.GetDllVersion() >> 16);
			m_CameraInfo.lSize = System.Runtime.InteropServices.Marshal.SizeOf(m_CameraInfo);
			m_CArtCam.GetCameraInfo(ref m_CameraInfo);
			m_Init = false;

			if(1 == m_CArtCam.Monitor_GetColorMode()){
				checkColor.Checked = true;
			}else{
				checkAWB.Enabled = false;
			}

			if(1 == m_CArtCam.Monitor_GetBayerGainAuto()){
				checkAWB.Checked = true;

				numericGainR.Enabled = trackGainR.Enabled = false;
				numericGainG.Enabled = trackGainG.Enabled = false;
				numericGainB.Enabled = trackGainB.Enabled = false;
			}

			// Bayer
			InitControl(numericGainR, trackGainR, 0, 1023, m_CArtCam.Monitor_GetBayerGainRed());	
			InitControl(numericGainG, trackGainG, 0, 1023, m_CArtCam.Monitor_GetBayerGainGreen());
			InitControl(numericGainB, trackGainB, 0, 1023, m_CArtCam.Monitor_GetBayerGainBlue());

			// Gain, Shutter, Mirror
			InitControl(numericGainAll, trackGainAll, m_CameraInfo.lGlobalGainMin, m_CameraInfo.lGlobalGainMax, m_CArtCam.GetGlobalGain());
			InitControl(numericShutter, trackShutter, m_CameraInfo.lExposureMin,   m_CameraInfo.lExposureMax,   m_CArtCam.GetExposureTime());
			
			checkMirrorV.Checked = m_CArtCam.GetMirrorV();
			checkMirrorH.Checked = m_CArtCam.GetMirrorH();

			for(int i=0; i<2; i++){
				// CursorMode
				m_Cursor[i].Enable= m_CArtCam.Monitor_GetCrossCursorMode(i);

				// Position
				m_CArtCam.Monitor_GetCrossCursorPos(i, out m_Cursor[i].PosX, out m_Cursor[i].PosY);

				// Size
				m_CArtCam.Monitor_GetCrossCursorSize(i, out m_Cursor[i].SizeX, out m_Cursor[i].SizeY);

				// Color
				m_Cursor[i].Color = m_CArtCam.Monitor_GetCrossCursorColorRGB(i);
			}
			
			int Width  = 1280;
			int Height = 1024;
			if(ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_1000MI_HD2 == m_DllType){
				switch(m_CArtCam.Width()){
				case 3664:
				case 1920:
					Width = 1920;
					Height = 1080;
				break;
				case 1280:
					Width = 1280;
					Height = 720;
				break;
				}
			}
			
			InitControl(numericXPos, trackXPos, 0, Width,  m_Cursor[m_CursorNumber].PosX);
			InitControl(numericYPos, trackYPos, 0, Height, m_Cursor[m_CursorNumber].PosY);

			InitControl(numericXSize, trackXSize, 0, 7, m_Cursor[m_CursorNumber].SizeX);
			InitControl(numericYSize, trackYSize, 0, 7, m_Cursor[m_CursorNumber].SizeY);

			radioCursor1.Checked = true;
			checkCursorOn.Checked = (1 == m_Cursor[m_CursorNumber].Enable) ? true : false;
			Invalidate();
			m_Init = true;
		}

		private void ChangeCursor()
		{
			if(1 == m_Cursor[m_CursorNumber].Enable)	checkCursorOn.Checked = true;
			else										checkCursorOn.Checked = false;

			bool Flg = (1 == m_Cursor[m_CursorNumber].Enable) ? true : false;

			numericXPos.Enabled = trackXPos.Enabled = Flg;		numericXPos.Value = m_Cursor[m_CursorNumber].PosX;
			numericYPos.Enabled = trackYPos.Enabled = Flg;		numericYPos.Value = m_Cursor[m_CursorNumber].PosY;
			
			numericXSize.Enabled = trackXSize.Enabled = Flg;	numericXSize.Value = m_Cursor[m_CursorNumber].SizeX;
			numericYSize.Enabled = trackYSize.Enabled = Flg;	numericYSize.Value = m_Cursor[m_CursorNumber].SizeY;

			Invalidate();
		}

		private void radioCursor1_CheckedChanged(object sender, EventArgs e)
		{
			m_CursorNumber = 0;
			ChangeCursor();
		}

		private void radioCursor2_CheckedChanged(object sender, EventArgs e)
		{
			m_CursorNumber = 1;
			ChangeCursor();
		}

		private void checkCursorOn_CheckedChanged(object sender, EventArgs e)
		{
			int Flg = checkCursorOn.Checked ? 1 : 0;
			m_CArtCam.Monitor_SetCrossCursorMode(m_CursorNumber, Flg);
			m_Cursor[m_CursorNumber].Enable = Flg;
			ChangeCursor();
		}

		private void checkColor_CheckedChanged(object sender, EventArgs e)
		{
			checkAWB_CheckedChanged(sender, e);
		}

		private void checkAWB_CheckedChanged(object sender, EventArgs e)
		{
			bool Color = checkColor.Checked;
			bool AWB   = checkAWB.Checked;
			if(!m_Init) return;

			m_CArtCam.Monitor_SetColorMode(Color ? 1 : 0);
			m_CArtCam.Monitor_SetBayerGainAuto(AWB ? 1 : 0);

			bool Flg = (Color && !AWB);
			numericGainR.Enabled = trackGainR.Enabled = Flg;
			numericGainG.Enabled = trackGainG.Enabled = Flg;
			numericGainB.Enabled = trackGainB.Enabled = Flg;

			if(Flg){
				numericGainR.Value = m_CArtCam.Monitor_GetBayerGainRed();
				numericGainG.Value = m_CArtCam.Monitor_GetBayerGainGreen();
				numericGainB.Value = m_CArtCam.Monitor_GetBayerGainBlue();
			}

			checkAWB.Enabled = Color;
		}

		private void checkMirrorV_CheckedChanged(object sender, EventArgs e)
		{
			m_CArtCam.SetMirrorV(checkMirrorV.Checked);
		}

		private void checkMirrorH_CheckedChanged(object sender, EventArgs e)
		{
			m_CArtCam.SetMirrorH(checkMirrorH.Checked);
		}

		private void buttonDefault_Click(object sender, EventArgs e)
		{
			switch(m_DllType){
			case ARTCAM_CAMERATYPE.ARTCAM_CAMERATYPE_1000MI_HD2:
				// Bayer
				numericGainR.Value = 256;
				numericGainG.Value = 256;
				numericGainB.Value = 256;

				numericGainAll.Value = 64;
				numericShutter.Value = 2748;

				numericXPos.Value = 360;
				numericYPos.Value = 360;
				numericXSize.Value = 4;
				numericYSize.Value = 4;
			break;
			}
		}

		private void InitControl(NumericUpDown n, TrackBar t, int Minimum, int Maximum, int Now)
		{
			n.Minimum = Minimum;	n.Maximum = Maximum;
			t.Minimum = Minimum;	t.Maximum = Maximum;

			if(Now < Minimum || Maximum < Now){
				n.Enabled = t.Enabled = false;
				return;
			}
			t.Value = Now;
			n.Value = Now;
		}

		private void buttonWrite_Click(object sender, EventArgs e)
		{
			m_CArtCam.Monitor_SaveCurrentSettings();
		}

		private void buttonInitSettings_Click(object sender, EventArgs e)
		{
			m_CArtCam.Monitor_InitRegisterSettings(0);
		}

		private void pictureColor_MouseUp(object sender, MouseEventArgs e)
		{
			int w = pictureColor.Width / 16;
			int h = pictureColor.Height;
			Point p = Cursor.Position;

			for(int i=0; i<16; i++){
				Rectangle rc = new Rectangle(w*i, 0, w, h);

				if(rc.Contains(pictureColor.PointToClient(p))){
					m_CArtCam.Monitor_SetCrossCursorColorRGB(m_CursorNumber, i);
					Invalidate();
					break;
				}
			}
		}

		private void Form7_Paint(object sender, PaintEventArgs e)
		{
			Bitmap canvas = new Bitmap(pictureColor.Width, pictureColor.Height);
			Graphics g = Graphics.FromImage(canvas);
			int w = pictureColor.Width / 16;
			int h = pictureColor.Height;
			Color[] c = {
				Color.FromArgb(0xFF, 0xFF, 0xFF),
				Color.FromArgb(0x00, 0x00, 0x00),
				Color.FromArgb(0xFF, 0xFF, 0x00),
				Color.FromArgb(0xFF, 0x00, 0x00),
				Color.FromArgb(0x00, 0x00, 0xFF),
				Color.FromArgb(0x00, 0xFF, 0x00),
				Color.FromArgb(0x80, 0x40, 0x00),
				Color.FromArgb(0x80, 0x80, 0x80),
				Color.FromArgb(0x00, 0x80, 0xFF),
				Color.FromArgb(0x80, 0x00, 0xFF),
				Color.FromArgb(0xFF, 0x80, 0xFF),
				Color.FromArgb(0x80, 0x80, 0x00),
				Color.FromArgb(0x80, 0x00, 0x40),
				Color.FromArgb(0x80, 0xFF, 0xFF),
				Color.FromArgb(0xFF, 0x80, 0x00),
				Color.FromArgb(0x40, 0x80, 0x80),
			};
			
			int cc = m_CArtCam.Monitor_GetCrossCursorColorRGB(m_CursorNumber);

			for(int i=0; i<16; i++){
				Rectangle rc = new Rectangle(w*i, 0, w, h);
				SolidBrush b = new SolidBrush(c[i]);
				g.FillRectangle(b, rc);

				if(cc == i){
					g.DrawRectangle(Pens.Red, rc.X, rc.Y, rc.Width-1, rc.Height-3);
				}
			}
			g.Dispose();
			pictureColor.Image = canvas;
		}

		private void trackGainR_Scroll(object sender, EventArgs e)	{	if(!m_Init) return;	numericGainR.Value = trackGainR.Value;		}
		private void trackGainG_Scroll(object sender, EventArgs e)	{	if(!m_Init) return;	numericGainG.Value = trackGainG.Value;		}
		private void trackGainB_Scroll(object sender, EventArgs e)	{	if(!m_Init) return;	numericGainB.Value = trackGainB.Value;		}
		private void trackGainAll_Scroll(object sender, EventArgs e){	if(!m_Init) return;	numericGainAll.Value = trackGainAll.Value;	}
		private void trackShutter_Scroll(object sender, EventArgs e){	if(!m_Init) return;	numericShutter.Value = trackShutter.Value;	}
		private void trackXPos_Scroll(object sender, EventArgs e)	{	if(!m_Init) return;	numericXPos.Value  = trackXPos.Value;		}
		private void trackYPos_Scroll(object sender, EventArgs e)	{	if(!m_Init) return;	numericYPos.Value  = trackYPos.Value;		}
		private void trackXSize_Scroll(object sender, EventArgs e)	{	if(!m_Init) return;	numericXSize.Value = trackXSize.Value;		}
		private void trackYSize_Scroll(object sender, EventArgs e)	{	if(!m_Init) return;	numericYSize.Value = trackYSize.Value;		}

		private void numericGainR_ValueChanged(object sender, EventArgs e)	
		{
			if(!m_Init) return;	
			int pos = trackGainR.Value = (int)numericGainR.Value;
			m_CArtCam.Monitor_SetBayerGainRed(pos);
		}

		private void numericGainG_ValueChanged(object sender, EventArgs e)	
		{	
			if(!m_Init) return;	
			int pos = trackGainG.Value = (int)numericGainG.Value;	
			m_CArtCam.Monitor_SetBayerGainGreen(pos);	
		}

		private void numericGainB_ValueChanged(object sender, EventArgs e)	
		{
			if(!m_Init) return;	
			int pos = trackGainB.Value = (int)numericGainB.Value;	
			m_CArtCam.Monitor_SetBayerGainBlue(pos);	
		}

		private void numericGainAll_ValueChanged(object sender, EventArgs e)
		{	
			if(!m_Init) return;	
			int pos = trackGainAll.Value = (int)numericGainAll.Value;
			m_CArtCam.SetGlobalGain(pos);	
		}

		private void numericShutter_ValueChanged(object sender, EventArgs e)
		{	
			if(!m_Init) return;	
			int pos = trackShutter.Value = (int)numericShutter.Value;	
			m_CArtCam.SetExposureTime(pos);	
		}

		private void numericXPos_ValueChanged(object sender, EventArgs e)	
		{
			if(!m_Init) return;	
			int pos = trackXPos.Value = (int)numericXPos.Value;
			m_Cursor[m_CursorNumber].PosX = pos;
			m_CArtCam.Monitor_SetCrossCursorPos(m_CursorNumber, m_Cursor[m_CursorNumber].PosX,  m_Cursor[m_CursorNumber].PosY);
		}

		private void numericYPos_ValueChanged(object sender, EventArgs e)	
		{
			if(!m_Init) return;	
			int pos = trackYPos.Value = (int)numericYPos.Value;	
			m_Cursor[m_CursorNumber].PosY = pos;
			m_CArtCam.Monitor_SetCrossCursorPos(m_CursorNumber, m_Cursor[m_CursorNumber].PosX,  m_Cursor[m_CursorNumber].PosY);
		}
		private void numericXSize_ValueChanged(object sender, EventArgs e)	
		{	
			if(!m_Init) return;	
			int pos = trackXSize.Value = (int)numericXSize.Value;
			m_Cursor[m_CursorNumber].SizeX = pos; 
			m_CArtCam.Monitor_SetCrossCursorSize(m_CursorNumber, m_Cursor[m_CursorNumber].SizeX, m_Cursor[m_CursorNumber].SizeY);	
		}
		private void numericYSize_ValueChanged(object sender, EventArgs e)	
		{
			if(!m_Init) return;	
			int pos = trackYSize.Value = (int)numericYSize.Value;
			m_Cursor[m_CursorNumber].SizeY = pos;
			m_CArtCam.Monitor_SetCrossCursorSize(m_CursorNumber, m_Cursor[m_CursorNumber].SizeX, m_Cursor[m_CursorNumber].SizeY);
		}
	}
}			
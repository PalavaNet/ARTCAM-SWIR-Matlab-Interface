//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
#include "Unit5.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm5 *Form5;
//---------------------------------------------------------------------------
__fastcall TForm5::TForm5(TComponent* Owner)
	: TForm(Owner)
{
	m_pCArtCamSdk = NULL;
}

//---------------------------------------------------------------------------


void __fastcall TForm5::FormShow(TObject *Sender)
{
	if(NULL == m_pCArtCamSdk){
		return;
	}

	if(m_pCArtCamSdk->Monitor_GetColorMode()){
		CheckBox1->Checked = TRUE;
	}else{
		CheckBox2->Enabled = FALSE;
		CheckBox3->Enabled = FALSE;
	}

	if(m_pCArtCamSdk->Monitor_GetBayerGainAuto()){
		CheckBox2->Checked = TRUE;


		TrackBar1->Enabled = FALSE;
		TrackBar2->Enabled = FALSE;
		TrackBar3->Enabled = FALSE;

		Edit1->Enabled = FALSE;
		Edit2->Enabled = FALSE;
		Edit3->Enabled = FALSE;

	}else{
		CheckBox3->Enabled = FALSE;
	}

	if(m_pCArtCamSdk->Monitor_GetBayerGainLock()){
		CheckBox3->Checked = TRUE;
	}

	if(m_pCArtCamSdk->GetMirrorV()){
    	CheckBox4->Checked = TRUE;
	}

	LONG lWidth = 0; LONG lHeight = 0;
	m_pCArtCamSdk->Monitor_GetPreviewSize(&lWidth,&lHeight);
	switch(lWidth){
		case  800: ComboBox2->ItemIndex=0; break;
		case 1024: ComboBox2->ItemIndex=1; break;
		case 1280: ComboBox2->ItemIndex=2; break;
	}

	LONG lCameraClock = m_pCArtCamSdk->Monitor_GetCameraClock();
		switch(lCameraClock){
			case 2:   ComboBox1->ItemIndex=1; break;
			case 5:   ComboBox1->ItemIndex=2; break;
			default:  ComboBox1->ItemIndex=0; break;
		}

	// Bayer
	lRed   = m_pCArtCamSdk->Monitor_GetBayerGainRed();
	lGreen = m_pCArtCamSdk->Monitor_GetBayerGainGreen();
	lBlue  = m_pCArtCamSdk->Monitor_GetBayerGainBlue();

	TrackBar1->Position = lRed;
	TrackBar2->Position = lGreen;
	TrackBar3->Position = lBlue;

	lGlobalGain   = m_pCArtCamSdk->GetGlobalGain();
	lShutterWidth = m_pCArtCamSdk->GetExposureTime();

	TrackBar4->Position = lGlobalGain;
	TrackBar5->Position = lShutterWidth;


	return;
  
}







void __fastcall TForm5::ComboBox1Change(TObject *Sender)
{
	m_pCArtCamSdk->Monitor_SetCameraClock(ComboBox1->ItemIndex);
}
//---------------------------------------------------------------------------

void __fastcall TForm5::ComboBox2Change(TObject *Sender)
{
	LONG lWidth = 0; LONG lHeight = 0;
	switch(ComboBox2->ItemIndex){
		case 0: lWidth = 800; lHeight = 600; break;
		case 1: lWidth = 1024; lHeight = 768; break;
		default: lWidth = 1280; lHeight = 1024; break;
	}
	m_pCArtCamSdk->Monitor_SetPreviewSize(lWidth,lHeight);
}
//---------------------------------------------------------------------------

void __fastcall TForm5::Button1Click(TObject *Sender)
{
	m_pCArtCamSdk->Monitor_SetPreviewMode(TRUE);	
}
//---------------------------------------------------------------------------

void __fastcall TForm5::Button2Click(TObject *Sender)
{
	m_pCArtCamSdk->Monitor_SetPreviewMode(FALSE);	
}
//---------------------------------------------------------------------------


void TForm5::ColorCheck()
{
	BOOL Color = CheckBox1->Checked;
	BOOL AWB = CheckBox2->Checked;
	BOOL Lock = CheckBox3->Checked;

	m_pCArtCamSdk->Monitor_SetColorMode(Color);
	m_pCArtCamSdk->Monitor_SetBayerGainAuto(AWB);
	m_pCArtCamSdk->Monitor_SetBayerGainLock(Lock);


	TrackBar1->Enabled = (Color && !AWB);
	TrackBar2->Enabled = (Color && !AWB);
	TrackBar3->Enabled = (Color && !AWB);

	Edit1->Enabled = (Color && !AWB);
	Edit2->Enabled = (Color && !AWB);
	Edit3->Enabled = (Color && !AWB);

	if(!Color){
		CheckBox2->Enabled = FALSE;
		CheckBox3->Enabled = FALSE;
	}else{
		CheckBox2->Enabled = TRUE;;
		if(!AWB){
			CheckBox3->Enabled = FALSE;
		}else{
			CheckBox3->Enabled = TRUE;
		}
	}
}
void __fastcall TForm5::CheckBox1Click(TObject *Sender)
{
	ColorCheck();
}
//---------------------------------------------------------------------------

void __fastcall TForm5::CheckBox2Click(TObject *Sender)
{
	ColorCheck();	
}
//---------------------------------------------------------------------------

void __fastcall TForm5::CheckBox3Click(TObject *Sender)
{
	ColorCheck();	
}
//---------------------------------------------------------------------------

void __fastcall TForm5::CheckBox4Click(TObject *Sender)
{
	if( CheckBox4->Checked == TRUE){
		m_pCArtCamSdk->SetMirrorV(1);
	}else{
		m_pCArtCamSdk->SetMirrorV(0);
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm5::TrackBar1Change(TObject *Sender)
{
	lRed = TrackBar1->Position;
	m_pCArtCamSdk->Monitor_SetBayerGainRed(lRed);
	Edit1->Text = IntToStr(lRed);
}
//---------------------------------------------------------------------------

void __fastcall TForm5::TrackBar2Change(TObject *Sender)
{
	lGreen = TrackBar2->Position;
	m_pCArtCamSdk->Monitor_SetBayerGainGreen(lGreen);
	Edit2->Text = IntToStr(lGreen);
}
//---------------------------------------------------------------------------

void __fastcall TForm5::TrackBar3Change(TObject *Sender)
{
	lBlue = TrackBar3->Position;
	m_pCArtCamSdk->Monitor_SetBayerGainBlue(lBlue);
	Edit3->Text = IntToStr(lBlue);
}
//---------------------------------------------------------------------------

void __fastcall TForm5::TrackBar4Change(TObject *Sender)
{
	lGlobalGain = TrackBar4->Position;
	m_pCArtCamSdk->SetGlobalGain(lGlobalGain);
	Edit4->Text = IntToStr(lGlobalGain);
}
//---------------------------------------------------------------------------

void __fastcall TForm5::TrackBar5Change(TObject *Sender)
{
	lShutterWidth = TrackBar5->Position;
	m_pCArtCamSdk->SetExposureTime(lShutterWidth);
	Edit5->Text = IntToStr(lShutterWidth);
}
//---------------------------------------------------------------------------

void __fastcall TForm5::Edit1Change(TObject *Sender)
{
	if(Edit1->Text != ""){
		lRed = StrToInt(Edit1->Text);
		m_pCArtCamSdk->Monitor_SetBayerGainRed(lRed);
		TrackBar1->Position = lRed;
	}
}
//---------------------------------------------------------------------------


void __fastcall TForm5::KeyValueCheck(TObject *Sender, char &Key)
{
	if ((Key<'0') || ('9'<Key))   Key = 0;
}
//---------------------------------------------------------------------------

void __fastcall TForm5::Edit2Change(TObject *Sender)
{
	if(Edit2->Text != ""){
		lGreen = StrToInt(Edit2->Text);
		m_pCArtCamSdk->Monitor_SetBayerGainGreen(lGreen);
		TrackBar2->Position = lGreen;
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm5::Edit3Change(TObject *Sender)
{
	if(Edit3->Text != ""){
		lBlue = StrToInt(Edit3->Text);
		m_pCArtCamSdk->Monitor_SetBayerGainBlue(lBlue);
		TrackBar3->Position = lBlue;
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm5::Edit4Change(TObject *Sender)
{
	if(Edit4->Text != ""){
		lGlobalGain = StrToInt(Edit4->Text);
		m_pCArtCamSdk->SetGlobalGain(lGlobalGain);
		TrackBar4->Position = lGlobalGain;
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm5::Edit5Change(TObject *Sender)
{
	if(Edit5->Text != ""){
		lShutterWidth = StrToInt(Edit5->Text);
		m_pCArtCamSdk->SetExposureTime(lShutterWidth);
		TrackBar5->Position = lShutterWidth;
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm5::Button5Click(TObject *Sender)
{
	Hide();	
}
//---------------------------------------------------------------------------

void __fastcall TForm5::Button3Click(TObject *Sender)
{

	lShutterWidth	= m_pCArtCamSdk->GetExposureTime();
	lGlobalGain		= m_pCArtCamSdk->GetGlobalGain();
	DWORD dwVFlip	= m_pCArtCamSdk->ReadRegister(0x20);


	m_pCArtCamSdk->Fpga_WriteRegister(0xB6, 0x03);

	// Shutter
	m_pCArtCamSdk->Fpga_WriteRegister(0xC0, 0x09);
	m_pCArtCamSdk->Fpga_WriteRegister(0xC1, BYTE(lShutterWidth >> 8));
	m_pCArtCamSdk->Fpga_WriteRegister(0xC2, BYTE(lShutterWidth));

	// Gain
	m_pCArtCamSdk->Fpga_WriteRegister(0xC3, 0x35);
	m_pCArtCamSdk->Fpga_WriteRegister(0xC4, BYTE(lGlobalGain >> 8));
	m_pCArtCamSdk->Fpga_WriteRegister(0xC5, BYTE(lGlobalGain));

	// Mirror reversal
	m_pCArtCamSdk->Fpga_WriteRegister(0xC6, 0x20);
	m_pCArtCamSdk->Fpga_WriteRegister(0xC7, BYTE(dwVFlip >> 8));
	m_pCArtCamSdk->Fpga_WriteRegister(0xC8, BYTE(dwVFlip));


	DWORD wReg0xE4 = m_pCArtCamSdk->Fpga_ReadRegister(0xE4);

	wReg0xE4 |= 0x0001;
	m_pCArtCamSdk->Fpga_WriteRegister(0xE4, wReg0xE4);
	wReg0xE4 &= 0xFFFE;
	m_pCArtCamSdk->Fpga_WriteRegister(0xE4, wReg0xE4);
}
//---------------------------------------------------------------------------


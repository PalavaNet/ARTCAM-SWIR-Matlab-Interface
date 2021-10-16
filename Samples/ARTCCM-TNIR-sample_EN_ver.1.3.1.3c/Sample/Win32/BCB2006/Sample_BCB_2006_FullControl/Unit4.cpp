//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit4.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm4 *Form4;
//---------------------------------------------------------------------------
__fastcall TForm4::TForm4(TComponent* Owner)
    : TForm(Owner)
{
	m_pCArtCamSdk = NULL;
}
//---------------------------------------------------------------------------
void __fastcall TForm4::FormShow(TObject *Sender)
{
	// Change operation for each DLL
	// For each DLL function, please refer to manual.
	m_DllType = HIWORD(m_pCArtCamSdk->GetDllVersion());


	switch(m_DllType){
	case ARTCAM_CAMERATYPE_130MI:
	case ARTCAM_CAMERATYPE_200MI:
	case ARTCAM_CAMERATYPE_300MI:
		Button1->Enabled = TRUE;
		CheckRead1->Enabled = TRUE;
		CheckRead2->Enabled = TRUE;
		CheckRead3->Enabled = TRUE;
		CheckRead4->Enabled = TRUE;
		CheckRead5->Enabled = TRUE;
		CheckRead6->Enabled = TRUE;
		CheckRead7->Enabled = TRUE;
		CheckRead8->Enabled = TRUE;

		Button2->Enabled = TRUE;
		CheckWrite1->Enabled = TRUE;
		CheckWrite2->Enabled = TRUE;
		CheckWrite3->Enabled = TRUE;
		CheckWrite4->Enabled = TRUE;
		CheckWrite5->Enabled = TRUE;
		CheckWrite6->Enabled = TRUE;
		CheckWrite7->Enabled = TRUE;
		CheckWrite8->Enabled = TRUE;
	break;
	}

}
//---------------------------------------------------------------------------
void __fastcall TForm4::Button1Click(TObject *Sender)
{
	BYTE Data = 0x00;
	if(m_pCArtCamSdk->GetIOPort(&Data, NULL, 0)){
		CheckRead1->Checked = (Data & 0x01) ? TRUE : FALSE;
		CheckRead2->Checked = (Data & 0x02) ? TRUE : FALSE;
		CheckRead3->Checked = (Data & 0x04) ? TRUE : FALSE;
		CheckRead4->Checked = (Data & 0x08) ? TRUE : FALSE;
		CheckRead5->Checked = (Data & 0x10) ? TRUE : FALSE;
		CheckRead6->Checked = (Data & 0x20) ? TRUE : FALSE;
		CheckRead7->Checked = (Data & 0x40) ? TRUE : FALSE;
		CheckRead8->Checked = (Data & 0x80) ? TRUE : FALSE;
	}
}
//---------------------------------------------------------------------------
void __fastcall TForm4::Button2Click(TObject *Sender)
{
	BYTE Data = 0x00;
	if(CheckWrite1->Checked) Data |= 0x01;
	if(CheckWrite2->Checked) Data |= 0x02;
	if(CheckWrite3->Checked) Data |= 0x04;
	if(CheckWrite4->Checked) Data |= 0x08;
	if(CheckWrite5->Checked) Data |= 0x10;
	if(CheckWrite6->Checked) Data |= 0x20;
	if(CheckWrite7->Checked) Data |= 0x40;
	if(CheckWrite8->Checked) Data |= 0x80;

	m_pCArtCamSdk->SetIOPort(Data, 0, 0);

}
//---------------------------------------------------------------------------
void __fastcall TForm4::Button3Click(TObject *Sender)
{
	Hide();
}
//---------------------------------------------------------------------------


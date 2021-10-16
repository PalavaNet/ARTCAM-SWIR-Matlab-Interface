//$$---- Form CPP ----
//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit6.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm6 *Form6;
//---------------------------------------------------------------------------
__fastcall TForm6::TForm6(TComponent* Owner)
	: TForm(Owner)
{
	m_pCArtCamSdk = NULL;
}
//---------------------------------------------------------------------------
void __fastcall TForm6::FormShow(TObject *Sender)
{
	if(NULL == m_pCArtCamSdk){
		return;
	}

	LONG MaskFilter   = m_pCArtCamSdk->GetMaskFilter();
	LONG DotFilter = m_pCArtCamSdk->GetDotFilter();
	if(DotFilter)	checkDotfilterEnable->Checked = true;
	if(MaskFilter)	checkCorrectionEnable->Checked = true;
}
//---------------------------------------------------------------------------
void __fastcall TForm6::buttonUpdateLowClick(TObject *Sender)
{
	if(m_pCArtCamSdk){
		m_pCArtCamSdk->UpdateMaskData(MASKTYPE_LOW);
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm6::buttonUpdateHighClick(TObject *Sender)
{
	if(m_pCArtCamSdk){
		m_pCArtCamSdk->UpdateMaskData(MASKTYPE_HIGH);
	}

}
//---------------------------------------------------------------------------

void __fastcall TForm6::buttonSaveMaskClick(TObject *Sender)
{
	if(m_pCArtCamSdk){
		SaveDialog1->DefaultExt = "msk";
		SaveDialog1->FileName = "Default.msk";
		SaveDialog1->Filter = "MSK file(*.msk)|*.msk||";
		SaveDialog1->Options << ofOverwritePrompt;

		if(SaveDialog1->Execute()){
			// Set extension yourself
			TCHAR szTemp[4][MAX_PATH]={"","","",""};
			_splitpath(SaveDialog1->FileName.c_str(), szTemp[0], szTemp[1], szTemp[2], szTemp[3]);

			AnsiString str;
			str.printf("%s%s%s.msk", szTemp[0], szTemp[1], szTemp[2]);	
			m_pCArtCamSdk->SaveMaskFile(str.c_str());
		}
	}

}
//---------------------------------------------------------------------------

void __fastcall TForm6::buttonLoadMaskClick(TObject *Sender)
{
	if(m_pCArtCamSdk){
		OpenDialog1->DefaultExt = "msk";
		OpenDialog1->FileName = "Default.msk";
		OpenDialog1->Filter = "MSK file(*.msk)|*.msk||";
		OpenDialog1->Options << ofOverwritePrompt;

		if(OpenDialog1->Execute()){
			m_pCArtCamSdk->LoadMaskFile(OpenDialog1->FileName.c_str());
		}
	}

}
//---------------------------------------------------------------------------

void __fastcall TForm6::checkCorrectionEnableClick(TObject *Sender)
{
	if(m_pCArtCamSdk){
		LONG Enable = (checkCorrectionEnable->Checked == true) ? 1 : 0;
		m_pCArtCamSdk->SetMaskFilter(Enable);
	}
	
}
//---------------------------------------------------------------------------

void __fastcall TForm6::checkDotfilterEnableClick(TObject *Sender)
{
	if(m_pCArtCamSdk){
		LONG Enable = (checkDotfilterEnable->Checked == true) ? 1 : 0;
		m_pCArtCamSdk->SetDotFilter(Enable);
	}	

}
//---------------------------------------------------------------------------

void __fastcall TForm6::buttonOKClick(TObject *Sender)
{
	Close();
}
//---------------------------------------------------------------------------


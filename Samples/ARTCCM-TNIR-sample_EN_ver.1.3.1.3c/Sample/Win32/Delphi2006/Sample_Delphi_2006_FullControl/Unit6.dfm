object Form6: TForm6
  Left = 0
  Top = 0
  Caption = 'Correction setting'
  ClientHeight = 231
  ClientWidth = 274
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox1: TGroupBox
    Left = 8
    Top = 16
    Width = 257
    Height = 161
    Caption = 'Correction'
    TabOrder = 7
  end
  object checkCorrectionEnable: TCheckBox
    Left = 24
    Top = 40
    Width = 145
    Height = 17
    Caption = 'Effective mask correction '
    TabOrder = 0
    OnClick = checkCorrectionEnableClick
  end
  object checkDotfilterEnable: TCheckBox
    Left = 24
    Top = 63
    Width = 145
    Height = 17
    Caption = 'Effective pixel correction'
    TabOrder = 1
    OnClick = checkDotfilterEnableClick
  end
  object buttonUpdateLow: TButton
    Left = 24
    Top = 88
    Width = 97
    Height = 25
    Caption = 'Register(dark)'
    TabOrder = 2
    OnClick = buttonUpdateLowClick
  end
  object buttonUpdateHigh: TButton
    Left = 152
    Top = 88
    Width = 97
    Height = 25
    Caption = 'Register(bright)'
    TabOrder = 3
    OnClick = buttonUpdateHighClick
  end
  object buttonSaveMask: TButton
    Left = 24
    Top = 136
    Width = 97
    Height = 25
    Caption = 'Save'
    TabOrder = 4
    OnClick = buttonSaveMaskClick
  end
  object buttonLoadMask: TButton
    Left = 152
    Top = 136
    Width = 97
    Height = 25
    Caption = 'Load'
    TabOrder = 5
    OnClick = buttonLoadMaskClick
  end
  object buttonOK: TButton
    Left = 191
    Top = 191
    Width = 75
    Height = 25
    Caption = 'OK'
    ModalResult = 1
    TabOrder = 6
    OnClick = buttonOKClick
  end
  object SaveDialog1: TSaveDialog
    Left = 8
    Top = 184
  end
  object OpenDialog1: TOpenDialog
    Left = 48
    Top = 184
  end
end

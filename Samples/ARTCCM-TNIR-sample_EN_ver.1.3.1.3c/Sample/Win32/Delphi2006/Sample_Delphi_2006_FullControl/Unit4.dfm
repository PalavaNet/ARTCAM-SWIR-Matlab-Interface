object Form4: TForm4
  Left = 223
  Top = 191
  Caption = 'IO settings'
  ClientHeight = 192
  ClientWidth = 314
  Color = clBtnFace
  Font.Charset = SHIFTJIS_CHARSET
  Font.Color = clWindowText
  Font.Height = -12
  Font.Name = 'MS UI Gothic'
  Font.Style = []
  OldCreateOrder = False
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 12
  object GroupBox1: TGroupBox
    Left = 8
    Top = 8
    Width = 217
    Height = 57
    Caption = 'Register for reading'
    TabOrder = 0
    object CheckRead1: TCheckBox
      Left = 16
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 0
    end
    object CheckRead2: TCheckBox
      Left = 40
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 1
    end
    object CheckRead3: TCheckBox
      Left = 64
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 2
    end
    object CheckRead4: TCheckBox
      Left = 88
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 3
    end
    object CheckRead5: TCheckBox
      Left = 184
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 4
    end
    object CheckRead6: TCheckBox
      Left = 160
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 5
    end
    object CheckRead7: TCheckBox
      Left = 136
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 6
    end
    object CheckRead8: TCheckBox
      Left = 112
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 7
    end
  end
  object GroupBox2: TGroupBox
    Left = 8
    Top = 80
    Width = 217
    Height = 57
    Caption = 'Register for writing'
    TabOrder = 1
    object CheckWrite1: TCheckBox
      Left = 16
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 0
    end
    object CheckWrite2: TCheckBox
      Left = 40
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 1
    end
    object CheckWrite3: TCheckBox
      Left = 64
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 2
    end
    object CheckWrite4: TCheckBox
      Left = 88
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 3
    end
    object CheckWrite5: TCheckBox
      Left = 184
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 4
    end
    object CheckWrite6: TCheckBox
      Left = 160
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 5
    end
    object CheckWrite7: TCheckBox
      Left = 136
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 6
    end
    object CheckWrite8: TCheckBox
      Left = 112
      Top = 24
      Width = 17
      Height = 17
      Enabled = False
      TabOrder = 7
    end
  end
  object Button1: TButton
    Left = 240
    Top = 16
    Width = 65
    Height = 49
    Caption = 'Read'
    Enabled = False
    TabOrder = 2
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 240
    Top = 88
    Width = 65
    Height = 49
    Caption = 'Write'
    Enabled = False
    TabOrder = 3
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 232
    Top = 152
    Width = 75
    Height = 25
    Caption = 'Close'
    TabOrder = 4
    OnClick = Button3Click
  end
end

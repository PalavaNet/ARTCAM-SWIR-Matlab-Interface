object Form5: TForm5
  Left = 0
  Top = 0
  BorderIcons = [biSystemMenu]
  Caption = 'Monitor settings'
  ClientHeight = 374
  ClientWidth = 395
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
  object GroupBox2: TGroupBox
    Left = 8
    Top = 231
    Width = 382
    Height = 107
    Caption = 'Camera Settings'
    TabOrder = 21
    object Label4: TLabel
      Left = 3
      Top = 31
      Width = 21
      Height = 13
      Caption = 'Gain'
    end
    object Label5: TLabel
      Left = 3
      Top = 71
      Width = 45
      Height = 13
      Caption = 'Exposure'
    end
  end
  object GroupBox1: TGroupBox
    Left = 8
    Top = 77
    Width = 382
    Height = 148
    Caption = 'Bayer Gain'
    TabOrder = 20
    object Label1: TLabel
      Left = 3
      Top = 30
      Width = 31
      Height = 13
      Caption = 'Gain R'
    end
    object Label2: TLabel
      Left = 3
      Top = 66
      Width = 31
      Height = 13
      Caption = 'Gain G'
    end
    object Label3: TLabel
      Left = 3
      Top = 106
      Width = 30
      Height = 13
      Caption = 'Gain B'
    end
  end
  object ComboBox1: TComboBox
    Left = 0
    Top = 8
    Width = 113
    Height = 21
    ItemHeight = 13
    TabOrder = 0
    Text = 'ComboBox1'
    OnChange = ComboBox1Change
    Items.Strings = (
      '16MHz'
      '24MHz'
      '48MHz')
  end
  object ComboBox2: TComboBox
    Left = 0
    Top = 48
    Width = 113
    Height = 21
    ItemHeight = 13
    TabOrder = 1
    Text = 'ComboBox2'
    OnChange = ComboBox2Change
    Items.Strings = (
      '800 * 600'
      '1024 * 768'
      '1280 * 1024')
  end
  object CheckBox1: TCheckBox
    Left = 224
    Top = 8
    Width = 73
    Height = 21
    Caption = 'Color'
    TabOrder = 2
    OnClick = CheckBox1Click
  end
  object CheckBox2: TCheckBox
    Left = 224
    Top = 30
    Width = 73
    Height = 19
    Caption = 'AutoWB'
    TabOrder = 3
    OnClick = CheckBox2Click
  end
  object CheckBox3: TCheckBox
    Left = 224
    Top = 50
    Width = 73
    Height = 19
    Caption = 'AWB-Lock'
    TabOrder = 4
    OnClick = CheckBox3Click
  end
  object CheckBox4: TCheckBox
    Left = 312
    Top = 46
    Width = 73
    Height = 25
    Caption = 'Vertical flip'
    TabOrder = 5
    OnClick = CheckBox4Click
  end
  object Button1: TButton
    Left = 136
    Top = 8
    Width = 65
    Height = 21
    Caption = 'Live'
    TabOrder = 6
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 136
    Top = 48
    Width = 65
    Height = 21
    Caption = 'Snapshot'
    TabOrder = 7
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 312
    Top = 19
    Width = 65
    Height = 21
    Caption = 'Write'
    TabOrder = 8
    OnClick = Button3Click
  end
  object TrackBar1: TTrackBar
    Left = 56
    Top = 104
    Width = 273
    Height = 34
    Max = 1023
    ShowSelRange = False
    TabOrder = 9
    TickStyle = tsNone
    OnChange = TrackBar1Change
  end
  object TrackBar2: TTrackBar
    Left = 56
    Top = 144
    Width = 273
    Height = 34
    Max = 1023
    ShowSelRange = False
    TabOrder = 10
    TickStyle = tsNone
    OnChange = TrackBar2Change
  end
  object TrackBar3: TTrackBar
    Left = 56
    Top = 184
    Width = 273
    Height = 33
    Max = 1023
    ShowSelRange = False
    TabOrder = 11
    TickStyle = tsNone
    OnChange = TrackBar3Change
  end
  object TrackBar4: TTrackBar
    Left = 56
    Top = 255
    Width = 273
    Height = 26
    Max = 63
    ShowSelRange = False
    TabOrder = 12
    TickStyle = tsNone
    OnChange = TrackBar4Change
  end
  object TrackBar5: TTrackBar
    Left = 56
    Top = 296
    Width = 273
    Height = 25
    Max = 16383
    Min = 1
    Position = 1
    ShowSelRange = False
    TabOrder = 13
    TickStyle = tsNone
    OnChange = TrackBar5Change
  end
  object Edit1: TEdit
    Left = 344
    Top = 104
    Width = 33
    Height = 21
    MaxLength = 4
    TabOrder = 14
    Text = '0'
    OnChange = Edit1Change
    OnKeyPress = KeyValueCheck
  end
  object Edit2: TEdit
    Left = 344
    Top = 140
    Width = 33
    Height = 21
    MaxLength = 4
    TabOrder = 15
    Text = '0'
    OnChange = Edit2Change
    OnKeyPress = KeyValueCheck
  end
  object Edit3: TEdit
    Left = 344
    Top = 183
    Width = 33
    Height = 21
    MaxLength = 4
    TabOrder = 16
    Text = '0'
    OnChange = Edit3Change
    OnKeyPress = KeyValueCheck
  end
  object Edit4: TEdit
    Left = 344
    Top = 259
    Width = 33
    Height = 21
    MaxLength = 4
    TabOrder = 17
    Text = '0'
    OnChange = Edit4Change
    OnKeyPress = KeyValueCheck
  end
  object Edit5: TEdit
    Left = 344
    Top = 294
    Width = 33
    Height = 21
    MaxLength = 5
    TabOrder = 18
    Text = '0'
    OnChange = Edit5Change
    OnKeyPress = KeyValueCheck
  end
  object Button5: TButton
    Left = 162
    Top = 349
    Width = 65
    Height = 17
    Caption = 'Close'
    TabOrder = 19
    OnClick = Button5Click
  end
end

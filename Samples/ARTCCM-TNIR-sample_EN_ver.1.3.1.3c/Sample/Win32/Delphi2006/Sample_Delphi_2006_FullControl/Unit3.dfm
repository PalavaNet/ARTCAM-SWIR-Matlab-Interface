object Form3: TForm3
  Left = 0
  Top = 0
  Caption = 'Size settings'
  ClientHeight = 419
  ClientWidth = 507
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
  object LabelFps: TLabel
    Left = 319
    Top = 112
    Width = 82
    Height = 12
    Caption = 'Framerate (x10)'
  end
  object GroupBox1: TGroupBox
    Left = 8
    Top = 8
    Width = 289
    Height = 129
    Caption = 'Size for taking in'
    TabOrder = 0
    object Label1: TLabel
      Left = 104
      Top = 16
      Width = 38
      Height = 12
      Caption = 'Horizon'
    end
    object Label2: TLabel
      Left = 208
      Top = 16
      Width = 40
      Height = 12
      Caption = 'Vertical'
    end
    object Label3: TLabel
      Left = 22
      Top = 38
      Width = 60
      Height = 12
      Caption = 'Total pixels'
    end
    object Label4: TLabel
      Left = 22
      Top = 65
      Width = 60
      Height = 12
      Caption = 'Valid pixels'
    end
    object Label5: TLabel
      Left = 13
      Top = 92
      Width = 69
      Height = 12
      Caption = 'Starting point'
    end
    object EditHT: TEdit
      Left = 88
      Top = 35
      Width = 81
      Height = 20
      TabOrder = 0
      Text = '0'
    end
    object EditVT: TEdit
      Left = 192
      Top = 35
      Width = 81
      Height = 20
      TabOrder = 1
      Text = '0'
    end
    object EditHE: TEdit
      Left = 88
      Top = 62
      Width = 81
      Height = 20
      TabOrder = 2
      Text = '0'
    end
    object EditVE: TEdit
      Left = 192
      Top = 62
      Width = 81
      Height = 20
      TabOrder = 3
      Text = '0'
    end
    object EditHS: TEdit
      Left = 88
      Top = 89
      Width = 81
      Height = 20
      TabOrder = 4
      Text = '0'
    end
    object EditVS: TEdit
      Left = 192
      Top = 89
      Width = 81
      Height = 20
      TabOrder = 5
      Text = '0'
    end
  end
  object GroupBox2: TGroupBox
    Left = 8
    Top = 143
    Width = 289
    Height = 58
    Caption = 'Subsampling'
    TabOrder = 1
    object RadioSubSample1: TRadioButton
      Left = 17
      Top = 24
      Width = 38
      Height = 17
      Caption = '1/1'
      TabOrder = 0
      TabStop = True
    end
    object RadioSubSample2: TRadioButton
      Left = 88
      Top = 24
      Width = 38
      Height = 17
      Caption = '1/2'
      TabOrder = 1
      TabStop = True
    end
    object RadioSubSample4: TRadioButton
      Left = 145
      Top = 24
      Width = 38
      Height = 17
      Caption = '1/4'
      TabOrder = 2
      TabStop = True
    end
    object RadioSubSample8: TRadioButton
      Left = 208
      Top = 24
      Width = 41
      Height = 17
      Caption = '1/8'
      TabOrder = 3
      TabStop = True
    end
  end
  object GroupBox3: TGroupBox
    Left = 8
    Top = 207
    Width = 289
    Height = 194
    Caption = 'Only for CNV'
    TabOrder = 2
    object LabelVideo: TLabel
      Left = 17
      Top = 24
      Width = 75
      Height = 12
      Caption = 'VideoFormat : '
    end
    object GroupBox4: TGroupBox
      Left = 17
      Top = 51
      Width = 126
      Height = 126
      Caption = 'Sampling rate'
      TabOrder = 6
    end
    object RadioRateWH: TRadioButton
      Left = 30
      Top = 72
      Width = 96
      Height = 17
      Caption = 'Wide Hispeed'
      TabOrder = 7
      TabStop = True
    end
    object RadioRateWL: TRadioButton
      Left = 30
      Top = 95
      Width = 110
      Height = 17
      Caption = 'Wide Lowspeed'
      TabOrder = 8
      TabStop = True
    end
    object RadioRateNH: TRadioButton
      Left = 30
      Top = 118
      Width = 110
      Height = 17
      Caption = 'Normal Hispeed'
      TabOrder = 9
      TabStop = True
    end
    object RadioRateNL: TRadioButton
      Left = 30
      Top = 141
      Width = 110
      Height = 17
      Caption = 'Normal Lowspeed'
      TabOrder = 10
      TabStop = True
    end
    object GroupBox5: TGroupBox
      Left = 149
      Top = 51
      Width = 124
      Height = 126
      Caption = 'Channel'
      TabOrder = 11
    end
    object RadioChannel1: TRadioButton
      Left = 167
      Top = 82
      Width = 34
      Height = 17
      Caption = '1'
      TabOrder = 0
      TabStop = True
    end
    object RadioChannel2: TRadioButton
      Left = 167
      Top = 112
      Width = 37
      Height = 17
      Caption = '2'
      TabOrder = 1
      TabStop = True
    end
    object RadioChannel3: TRadioButton
      Left = 167
      Top = 142
      Width = 40
      Height = 17
      Caption = '3'
      TabOrder = 2
      TabStop = True
    end
    object RadioChannel4: TRadioButton
      Left = 207
      Top = 82
      Width = 40
      Height = 17
      Caption = '4'
      TabOrder = 3
      TabStop = True
    end
    object RadioChannel5: TRadioButton
      Left = 207
      Top = 112
      Width = 37
      Height = 17
      Caption = '5'
      TabOrder = 4
      TabStop = True
    end
    object RadioChannel6: TRadioButton
      Left = 207
      Top = 142
      Width = 40
      Height = 17
      Caption = '6'
      TabOrder = 5
      TabStop = True
    end
  end
  object GroupBox6: TGroupBox
    Left = 303
    Top = 8
    Width = 186
    Height = 83
    Caption = 'Color mode'
    TabOrder = 3
    object RadioColor08: TRadioButton
      Left = 16
      Top = 24
      Width = 33
      Height = 17
      Caption = '8'
      TabOrder = 0
      TabStop = True
    end
    object RadioColor16: TRadioButton
      Left = 16
      Top = 47
      Width = 33
      Height = 17
      Caption = '16'
      TabOrder = 1
      TabStop = True
    end
    object RadioColor24: TRadioButton
      Left = 71
      Top = 24
      Width = 41
      Height = 17
      Caption = '24'
      TabOrder = 2
      TabStop = True
    end
    object RadioColor32: TRadioButton
      Left = 71
      Top = 49
      Width = 33
      Height = 12
      Caption = '32'
      TabOrder = 3
    end
    object RadioColor48: TRadioButton
      Left = 118
      Top = 24
      Width = 33
      Height = 17
      Caption = '48'
      TabOrder = 4
      TabStop = True
    end
    object RadioColor64: TRadioButton
      Left = 118
      Top = 47
      Width = 35
      Height = 17
      Caption = '64'
      TabOrder = 5
      TabStop = True
    end
  end
  object EditFps: TEdit
    Left = 319
    Top = 131
    Width = 96
    Height = 20
    TabOrder = 4
    Text = '0'
  end
  object GroupBox7: TGroupBox
    Left = 303
    Top = 167
    Width = 185
    Height = 175
    TabOrder = 5
    object CheckCode: TCheckBox
      Left = 16
      Top = 0
      Width = 97
      Height = 17
      Caption = 'Write sub-code'
      TabOrder = 0
    end
    object EditCode1: TEdit
      Left = 16
      Top = 31
      Width = 73
      Height = 20
      TabOrder = 1
      Text = '0'
    end
    object EditCode2: TEdit
      Left = 16
      Top = 66
      Width = 73
      Height = 20
      TabOrder = 2
      Text = '0'
    end
    object EditCode3: TEdit
      Left = 16
      Top = 101
      Width = 73
      Height = 20
      TabOrder = 3
      Text = '0'
    end
    object EditCode4: TEdit
      Left = 16
      Top = 136
      Width = 73
      Height = 20
      TabOrder = 4
      Text = '0'
    end
    object EditCode5: TEdit
      Left = 95
      Top = 31
      Width = 73
      Height = 20
      TabOrder = 5
      Text = '0'
    end
    object EditCode6: TEdit
      Left = 95
      Top = 66
      Width = 73
      Height = 20
      TabOrder = 6
      Text = '0'
    end
    object EditCode7: TEdit
      Left = 95
      Top = 101
      Width = 73
      Height = 20
      TabOrder = 7
      Text = '0'
    end
    object EditCode8: TEdit
      Left = 95
      Top = 136
      Width = 73
      Height = 20
      TabOrder = 8
      Text = '0'
    end
  end
  object Button1: TButton
    Left = 303
    Top = 376
    Width = 75
    Height = 25
    Caption = 'Apply'
    ModalResult = 1
    TabOrder = 6
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 413
    Top = 376
    Width = 75
    Height = 25
    Caption = 'Cancel'
    TabOrder = 7
    OnClick = Button2Click
  end
end

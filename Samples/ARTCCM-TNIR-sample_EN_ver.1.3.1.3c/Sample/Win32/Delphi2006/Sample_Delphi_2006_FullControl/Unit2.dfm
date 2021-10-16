object Form2: TForm2
  Left = 276
  Top = 211
  BorderIcons = [biSystemMenu]
  BorderStyle = bsDialog
  Caption = 'Filter settings'
  ClientHeight = 546
  ClientWidth = 542
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
    Height = 225
    Caption = 'Picture filter'
    Font.Charset = SHIFTJIS_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'MS UI Gothic'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    object Label1: TLabel
      Left = 24
      Top = 32
      Width = 55
      Height = 12
      Caption = 'Brightness'
    end
    object Label2: TLabel
      Left = 24
      Top = 64
      Width = 44
      Height = 12
      Caption = 'Contrast'
    end
    object Label3: TLabel
      Left = 24
      Top = 96
      Width = 20
      Height = 12
      Caption = 'Hue'
    end
    object Label4: TLabel
      Left = 24
      Top = 128
      Width = 52
      Height = 12
      Caption = 'Saturation'
    end
    object Label5: TLabel
      Left = 24
      Top = 160
      Width = 53
      Height = 12
      Caption = 'Sharpness'
    end
    object Label6: TLabel
      Left = 24
      Top = 192
      Width = 38
      Height = 12
      Caption = 'Gumma'
    end
    object EditBrightness: TEdit
      Left = 104
      Top = 24
      Width = 65
      Height = 20
      TabOrder = 0
      Text = '0'
      OnChange = EditBrightnessChange
    end
    object EditContrast: TEdit
      Left = 104
      Top = 56
      Width = 65
      Height = 20
      TabOrder = 1
      Text = '0'
      OnChange = EditContrastChange
    end
    object EditHue: TEdit
      Left = 104
      Top = 88
      Width = 65
      Height = 20
      TabOrder = 2
      Text = '0'
      OnChange = EditHueChange
    end
    object EditSaturation: TEdit
      Left = 104
      Top = 120
      Width = 65
      Height = 20
      TabOrder = 3
      Text = '0'
      OnChange = EditSaturationChange
    end
    object EditSharpness: TEdit
      Left = 104
      Top = 152
      Width = 65
      Height = 20
      TabOrder = 4
      Text = '0'
      OnChange = EditSharpnessChange
    end
    object EditGamma: TEdit
      Left = 104
      Top = 184
      Width = 65
      Height = 20
      TabOrder = 5
      Text = '0'
      OnChange = EditGammaChange
    end
    object UpDownBrightness: TUpDown
      Left = 169
      Top = 24
      Width = 15
      Height = 20
      Associate = EditBrightness
      TabOrder = 6
    end
    object UpDownContrast: TUpDown
      Left = 169
      Top = 56
      Width = 16
      Height = 20
      Associate = EditContrast
      TabOrder = 7
    end
    object UpDownHue: TUpDown
      Left = 169
      Top = 88
      Width = 16
      Height = 20
      Associate = EditHue
      TabOrder = 8
    end
    object UpDownSaturation: TUpDown
      Left = 169
      Top = 120
      Width = 16
      Height = 20
      Associate = EditSaturation
      TabOrder = 9
    end
    object UpDownSharpness: TUpDown
      Left = 169
      Top = 152
      Width = 16
      Height = 20
      Associate = EditSharpness
      TabOrder = 10
    end
    object UpDownGamma: TUpDown
      Left = 169
      Top = 184
      Width = 16
      Height = 20
      Associate = EditGamma
      TabOrder = 11
    end
  end
  object GroupBox2: TGroupBox
    Left = 240
    Top = 8
    Width = 289
    Height = 225
    Caption = 'Camera settings'
    Font.Charset = SHIFTJIS_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'MS UI Gothic'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    object Label7: TLabel
      Left = 24
      Top = 192
      Width = 155
      Height = 12
      Caption = 'Exposure time (shutter speed)'
    end
    object Label8: TLabel
      Left = 24
      Top = 160
      Width = 83
      Height = 12
      Caption = 'Color gain(Blue)'
    end
    object Label9: TLabel
      Left = 24
      Top = 128
      Width = 100
      Height = 12
      Caption = 'Color gain(Green 2)'
    end
    object Label10: TLabel
      Left = 24
      Top = 96
      Width = 100
      Height = 12
      Caption = 'Color gain(Green 1)'
    end
    object Label11: TLabel
      Left = 24
      Top = 64
      Width = 80
      Height = 12
      Caption = 'Color gain(Red)'
    end
    object Label12: TLabel
      Left = 24
      Top = 32
      Width = 57
      Height = 12
      Caption = 'Global gain'
    end
    object EditExposureTime: TEdit
      Left = 200
      Top = 184
      Width = 65
      Height = 20
      TabOrder = 0
      Text = '0'
      OnChange = EditExposureTimeChange
    end
    object EditColorGainB: TEdit
      Left = 200
      Top = 152
      Width = 65
      Height = 20
      TabOrder = 1
      Text = '0'
      OnChange = EditColorGainBChange
    end
    object EditColorGainG2: TEdit
      Left = 200
      Top = 120
      Width = 65
      Height = 20
      TabOrder = 2
      Text = '0'
      OnChange = EditColorGainG2Change
    end
    object EditColorGainG1: TEdit
      Left = 200
      Top = 88
      Width = 65
      Height = 20
      TabOrder = 3
      Text = '0'
      OnChange = EditColorGainG1Change
    end
    object EditColorGainR: TEdit
      Left = 200
      Top = 56
      Width = 65
      Height = 20
      TabOrder = 4
      Text = '0'
      OnChange = EditColorGainRChange
    end
    object EditGlobalGain: TEdit
      Left = 200
      Top = 24
      Width = 65
      Height = 20
      TabOrder = 5
      Text = '0'
      OnChange = EditGlobalGainChange
    end
    object UpDownGlobalGain: TUpDown
      Left = 265
      Top = 24
      Width = 16
      Height = 20
      Associate = EditGlobalGain
      TabOrder = 6
    end
    object UpDownColorGainR: TUpDown
      Left = 265
      Top = 56
      Width = 16
      Height = 20
      Associate = EditColorGainR
      TabOrder = 7
    end
    object UpDownColorGainG1: TUpDown
      Left = 265
      Top = 88
      Width = 16
      Height = 20
      Associate = EditColorGainG1
      TabOrder = 8
    end
    object UpDownColorGainG2: TUpDown
      Left = 265
      Top = 120
      Width = 16
      Height = 20
      Associate = EditColorGainG2
      TabOrder = 9
    end
    object UpDownColorGainB: TUpDown
      Left = 265
      Top = 152
      Width = 16
      Height = 20
      Associate = EditColorGainB
      TabOrder = 10
    end
    object UpDownExposureTime: TUpDown
      Left = 265
      Top = 184
      Width = 16
      Height = 20
      Associate = EditExposureTime
      TabOrder = 11
    end
  end
  object GroupBox3: TGroupBox
    Left = 8
    Top = 248
    Width = 217
    Height = 289
    Caption = 'Color conversion'
    Font.Charset = SHIFTJIS_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'MS UI Gothic'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    object CheckAWB: TCheckBox
      Left = 24
      Top = 24
      Width = 145
      Height = 17
      Caption = 'Auto white balance'
      TabOrder = 0
      OnClick = CheckAWBClick
    end
    object GroupBox4: TGroupBox
      Left = 24
      Top = 56
      Width = 169
      Height = 73
      Caption = 'Bayer conversion mode'
      TabOrder = 1
      object RadioBayer1: TRadioButton
        Left = 24
        Top = 32
        Width = 17
        Height = 17
        TabOrder = 0
        OnClick = RadioBayer1Click
      end
      object RadioBayer2: TRadioButton
        Left = 56
        Top = 32
        Width = 17
        Height = 17
        TabOrder = 1
        OnClick = RadioBayer2Click
      end
      object RadioBayer3: TRadioButton
        Left = 88
        Top = 32
        Width = 17
        Height = 17
        TabOrder = 2
        OnClick = RadioBayer3Click
      end
      object RadioBayer4: TRadioButton
        Left = 120
        Top = 32
        Width = 17
        Height = 17
        TabOrder = 3
        OnClick = RadioBayer4Click
      end
    end
    object GroupBox5: TGroupBox
      Left = 24
      Top = 144
      Width = 169
      Height = 129
      Caption = 'Bayer conversion gain'
      TabOrder = 2
      object Label13: TLabel
        Left = 32
        Top = 96
        Width = 23
        Height = 12
        Caption = 'Blue'
      end
      object Label14: TLabel
        Left = 32
        Top = 64
        Width = 30
        Height = 12
        Caption = 'Green'
      end
      object Label15: TLabel
        Left = 32
        Top = 32
        Width = 20
        Height = 12
        Caption = 'Red'
      end
      object EditBayerGainB: TEdit
        Left = 72
        Top = 88
        Width = 65
        Height = 20
        TabOrder = 0
        Text = '0'
        OnChange = EditBayerGainBChange
      end
      object EditBayerGainG: TEdit
        Left = 72
        Top = 56
        Width = 65
        Height = 20
        TabOrder = 1
        Text = '0'
        OnChange = EditBayerGainGChange
      end
      object EditBayerGainR: TEdit
        Left = 72
        Top = 24
        Width = 65
        Height = 20
        TabOrder = 2
        Text = '0'
        OnChange = EditBayerGainRChange
      end
      object UpDownBayerGainR: TUpDown
        Left = 137
        Top = 24
        Width = 16
        Height = 20
        Associate = EditBayerGainR
        TabOrder = 3
      end
      object UpDownBayerGainG: TUpDown
        Left = 137
        Top = 56
        Width = 16
        Height = 20
        Associate = EditBayerGainG
        TabOrder = 4
      end
      object UpDownBayerGainB: TUpDown
        Left = 137
        Top = 88
        Width = 16
        Height = 20
        Associate = EditBayerGainB
        TabOrder = 5
      end
    end
  end
  object GroupBox6: TGroupBox
    Left = 240
    Top = 248
    Width = 129
    Height = 105
    Caption = 'Auto iris'
    Font.Charset = SHIFTJIS_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'MS UI Gothic'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    object RadioAI1: TRadioButton
      Left = 24
      Top = 24
      Width = 49
      Height = 17
      Caption = 'Invalid'
      TabOrder = 0
      OnClick = RadioAI1Click
    end
    object RadioAI2: TRadioButton
      Left = 24
      Top = 48
      Width = 73
      Height = 17
      Caption = 'Shutter'
      TabOrder = 1
      OnClick = RadioAI2Click
    end
    object RadioAI3: TRadioButton
      Left = 24
      Top = 72
      Width = 57
      Height = 17
      Caption = 'Gain'
      TabOrder = 2
      OnClick = RadioAI3Click
    end
  end
  object GroupBox7: TGroupBox
    Left = 240
    Top = 368
    Width = 129
    Height = 73
    Caption = 'Mirror reversal'
    Font.Charset = SHIFTJIS_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'MS UI Gothic'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    object CheckMirrorV: TCheckBox
      Left = 16
      Top = 16
      Width = 73
      Height = 17
      Caption = 'Vertical'
      TabOrder = 0
      OnClick = CheckMirrorVClick
    end
    object CheckMirrorH: TCheckBox
      Left = 16
      Top = 39
      Width = 73
      Height = 17
      Caption = 'Horizon'
      TabOrder = 1
      OnClick = CheckMirrorHClick
    end
  end
  object CheckHalfClock: TCheckBox
    Left = 264
    Top = 464
    Width = 97
    Height = 17
    Caption = 'Half clock'
    Font.Charset = SHIFTJIS_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'MS UI Gothic'
    Font.Style = []
    ParentFont = False
    TabOrder = 5
    OnClick = CheckHalfClockClick
  end
  object GroupBox8: TGroupBox
    Left = 376
    Top = 248
    Width = 153
    Height = 105
    Caption = 'Display channel (CNV)'
    Font.Charset = SHIFTJIS_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'MS UI Gothic'
    Font.Style = []
    ParentFont = False
    TabOrder = 6
    object RadioChannel1: TRadioButton
      Left = 16
      Top = 24
      Width = 33
      Height = 17
      Caption = '1'
      TabOrder = 0
      OnClick = RadioChannel1Click
    end
    object RadioChannel2: TRadioButton
      Left = 56
      Top = 24
      Width = 33
      Height = 17
      Caption = '2'
      TabOrder = 1
      OnClick = RadioChannel2Click
    end
    object RadioChannel3: TRadioButton
      Left = 96
      Top = 24
      Width = 33
      Height = 17
      Caption = '3'
      TabOrder = 2
      OnClick = RadioChannel3Click
    end
    object RadioChannel4: TRadioButton
      Left = 16
      Top = 56
      Width = 33
      Height = 17
      Caption = '4'
      TabOrder = 3
      OnClick = RadioChannel4Click
    end
    object RadioChannel5: TRadioButton
      Left = 56
      Top = 56
      Width = 33
      Height = 17
      Caption = '5'
      TabOrder = 4
      OnClick = RadioChannel5Click
    end
    object RadioChannel6: TRadioButton
      Left = 96
      Top = 56
      Width = 33
      Height = 17
      Caption = '6'
      TabOrder = 5
      OnClick = RadioChannel6Click
    end
  end
  object Button1: TButton
    Left = 448
    Top = 512
    Width = 75
    Height = 25
    Caption = 'Close'
    Font.Charset = SHIFTJIS_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'MS UI Gothic'
    Font.Style = []
    ParentFont = False
    TabOrder = 7
    OnClick = Button1Click
  end
end

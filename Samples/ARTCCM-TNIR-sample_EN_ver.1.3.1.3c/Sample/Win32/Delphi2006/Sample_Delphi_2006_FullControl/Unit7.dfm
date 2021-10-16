object Form7: TForm7
  Left = 0
  Top = 0
  Caption = 'Form7'
  ClientHeight = 390
  ClientWidth = 574
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnPaint = FormPaint
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox2: TGroupBox
    Left = 8
    Top = 71
    Width = 273
    Height = 122
    Caption = 'Bayer conversion'
    TabOrder = 12
    object Label1: TLabel
      Left = 16
      Top = 25
      Width = 30
      Height = 13
      Caption = 'R gain'
    end
    object Label2: TLabel
      Left = 16
      Top = 56
      Width = 30
      Height = 13
      Caption = 'G gain'
    end
    object Label3: TLabel
      Left = 16
      Top = 88
      Width = 29
      Height = 13
      Caption = 'B gain'
    end
  end
  object GroupBox1: TGroupBox
    Left = 8
    Top = 8
    Width = 273
    Height = 57
    Caption = 'Working mode settings'
    TabOrder = 2
  end
  object CheckColor: TCheckBox
    Left = 24
    Top = 32
    Width = 49
    Height = 17
    Caption = 'Color'
    TabOrder = 0
    OnClick = CheckColorClick
  end
  object CheckAWB: TCheckBox
    Left = 88
    Top = 32
    Width = 129
    Height = 17
    Caption = 'Auto white balance'
    TabOrder = 1
    OnClick = CheckAWBClick
  end
  object TrackGainR: TTrackBar
    Left = 65
    Top = 92
    Width = 128
    Height = 25
    ShowSelRange = False
    TabOrder = 3
    TickStyle = tsNone
    OnChange = TrackGainRChange
  end
  object EditGainR: TEdit
    Left = 199
    Top = 93
    Width = 50
    Height = 21
    TabOrder = 4
    OnChange = EditGainRChange
  end
  object UpDownGainR: TUpDown
    Left = 248
    Top = 93
    Width = 16
    Height = 24
    TabOrder = 5
    Thousands = False
  end
  object UpDownGainG: TUpDown
    Left = 248
    Top = 123
    Width = 16
    Height = 24
    TabOrder = 6
    Thousands = False
  end
  object EditGainG: TEdit
    Left = 199
    Top = 123
    Width = 50
    Height = 21
    TabOrder = 7
    OnChange = EditGainGChange
  end
  object TrackGainG: TTrackBar
    Left = 65
    Top = 122
    Width = 128
    Height = 25
    ShowSelRange = False
    TabOrder = 8
    TickStyle = tsNone
    OnChange = TrackGainGChange
  end
  object UpDownGainB: TUpDown
    Left = 248
    Top = 153
    Width = 16
    Height = 24
    TabOrder = 9
    Thousands = False
  end
  object EditGainB: TEdit
    Left = 199
    Top = 153
    Width = 50
    Height = 21
    TabOrder = 10
    OnChange = EditGainBChange
  end
  object TrackGainB: TTrackBar
    Left = 65
    Top = 153
    Width = 128
    Height = 25
    ShowSelRange = False
    TabOrder = 11
    TickStyle = tsNone
    OnChange = TrackGainBChange
  end
  object GroupBox3: TGroupBox
    Left = 8
    Top = 199
    Width = 273
    Height = 130
    Caption = 'Camera controll'
    TabOrder = 13
    object Label4: TLabel
      Left = 16
      Top = 24
      Width = 21
      Height = 13
      Caption = 'Gain'
    end
    object Label5: TLabel
      Left = 16
      Top = 55
      Width = 36
      Height = 13
      Caption = 'Shutter'
    end
    object TrackGainGlobal: TTrackBar
      Left = 57
      Top = 24
      Width = 128
      Height = 25
      ShowSelRange = False
      TabOrder = 0
      TickStyle = tsNone
      OnChange = TrackGainGlobalChange
    end
    object EditGainGlobal: TEdit
      Left = 191
      Top = 28
      Width = 50
      Height = 21
      TabOrder = 1
      OnChange = EditGainGlobalChange
    end
    object UpDownGainGlobal: TUpDown
      Left = 240
      Top = 25
      Width = 16
      Height = 24
      TabOrder = 2
      Thousands = False
    end
    object TrackExposureTime: TTrackBar
      Left = 57
      Top = 55
      Width = 128
      Height = 25
      ShowSelRange = False
      TabOrder = 3
      TickStyle = tsNone
      OnChange = TrackExposureTimeChange
    end
    object EditExposureTime: TEdit
      Left = 191
      Top = 59
      Width = 50
      Height = 21
      TabOrder = 4
      OnChange = EditExposureTimeChange
    end
    object UpDownExposureTime: TUpDown
      Left = 240
      Top = 56
      Width = 16
      Height = 24
      TabOrder = 5
      Thousands = False
    end
    object CheckMirrorV: TCheckBox
      Left = 16
      Top = 96
      Width = 97
      Height = 17
      Caption = 'Vertical mirror'
      TabOrder = 6
      OnClick = CheckMirrorVClick
    end
    object CheckMirrorH: TCheckBox
      Left = 144
      Top = 96
      Width = 97
      Height = 17
      Caption = 'Horizontal mirror'
      TabOrder = 7
      OnClick = CheckMirrorHClick
    end
  end
  object GroupBox4: TGroupBox
    Left = 296
    Top = 8
    Width = 265
    Height = 271
    Caption = 'Cross cursor settings'
    TabOrder = 14
    object Label6: TLabel
      Left = 12
      Top = 88
      Width = 26
      Height = 13
      Caption = 'X Pos'
    end
    object Label7: TLabel
      Left = 12
      Top = 118
      Width = 26
      Height = 13
      Caption = 'Y Pos'
    end
    object Label8: TLabel
      Left = 12
      Top = 148
      Width = 28
      Height = 13
      Caption = 'X Size'
    end
    object Label9: TLabel
      Left = 12
      Top = 179
      Width = 28
      Height = 13
      Caption = 'Y Size'
    end
    object Image1: TImage
      Left = 12
      Top = 219
      Width = 242
      Height = 33
      OnMouseDown = Image1MouseDown
    end
    object RadioCursor_1: TRadioButton
      Left = 16
      Top = 24
      Width = 73
      Height = 17
      Caption = 'Cursor1'
      TabOrder = 0
      OnClick = RadioCursor_1Click
    end
    object RadioCursor_2: TRadioButton
      Left = 128
      Top = 24
      Width = 73
      Height = 17
      Caption = 'Cursor2'
      TabOrder = 1
      OnClick = RadioCursor_2Click
    end
    object CheckCursorOn: TCheckBox
      Left = 16
      Top = 47
      Width = 129
      Height = 17
      Caption = 'Cross cursor on'
      TabOrder = 2
      OnClick = CheckCursorOnClick
    end
    object TrackPosX: TTrackBar
      Left = 57
      Top = 83
      Width = 128
      Height = 25
      ShowSelRange = False
      TabOrder = 3
      TickStyle = tsNone
      OnChange = TrackPosXChange
    end
    object TrackPosY: TTrackBar
      Left = 57
      Top = 114
      Width = 128
      Height = 25
      ShowSelRange = False
      TabOrder = 4
      TickStyle = tsNone
      OnChange = TrackPosYChange
    end
    object TrackSizeX: TTrackBar
      Left = 57
      Top = 145
      Width = 128
      Height = 25
      ShowSelRange = False
      TabOrder = 5
      TickStyle = tsNone
      OnChange = TrackSizeXChange
    end
    object EditPosX: TEdit
      Left = 191
      Top = 85
      Width = 50
      Height = 21
      TabOrder = 6
      OnChange = EditPosXChange
    end
    object UpDownPosX: TUpDown
      Left = 236
      Top = 85
      Width = 16
      Height = 24
      TabOrder = 7
      Thousands = False
    end
    object EditPosY: TEdit
      Left = 191
      Top = 115
      Width = 50
      Height = 21
      TabOrder = 8
      OnChange = EditPosYChange
    end
    object UpDownPosY: TUpDown
      Left = 236
      Top = 115
      Width = 16
      Height = 24
      TabOrder = 9
      Thousands = False
    end
    object EditSizeX: TEdit
      Left = 191
      Top = 145
      Width = 50
      Height = 21
      TabOrder = 10
      OnChange = EditSizeXChange
    end
    object UpDownSizeX: TUpDown
      Left = 236
      Top = 145
      Width = 16
      Height = 24
      TabOrder = 11
      Thousands = False
    end
    object TrackSizeY: TTrackBar
      Left = 57
      Top = 176
      Width = 128
      Height = 25
      ShowSelRange = False
      TabOrder = 12
      TickStyle = tsNone
      OnChange = TrackSizeYChange
    end
    object EditSizeY: TEdit
      Left = 191
      Top = 176
      Width = 50
      Height = 21
      TabOrder = 13
      OnChange = EditSizeYChange
    end
    object UpDownSizeY: TUpDown
      Left = 236
      Top = 175
      Width = 16
      Height = 24
      TabOrder = 14
      Thousands = False
    end
  end
  object ButtonInitSettings: TButton
    Left = 24
    Top = 344
    Width = 113
    Height = 33
    Caption = 'Initialize setting'
    TabOrder = 15
    OnClick = ButtonInitSettingsClick
  end
  object ButtonSaveSettings: TButton
    Left = 157
    Top = 344
    Width = 107
    Height = 33
    Caption = 'Write'
    TabOrder = 16
    OnClick = ButtonSaveSettingsClick
  end
  object ButtonOK: TButton
    Left = 311
    Top = 348
    Width = 75
    Height = 25
    Caption = 'OK'
    ModalResult = 1
    TabOrder = 17
    OnClick = ButtonOKClick
  end
  object ButtonDefault: TButton
    Left = 392
    Top = 348
    Width = 75
    Height = 25
    Caption = 'Default'
    TabOrder = 18
    OnClick = ButtonDefaultClick
  end
  object ButtonCancel: TButton
    Left = 473
    Top = 348
    Width = 75
    Height = 25
    Caption = 'Cancel'
    ModalResult = 2
    TabOrder = 19
    OnClick = ButtonCancelClick
  end
end

object Form1: TForm1
  Left = 245
  Top = 152
  Caption = 'Sample'
  ClientHeight = 768
  ClientWidth = 940
  Color = clBtnFace
  Font.Charset = SHIFTJIS_CHARSET
  Font.Color = clWindowText
  Font.Height = -12
  Font.Name = 'MS UI Gothic'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  OnResize = FormResize
  PixelsPerInch = 96
  TextHeight = 12
  object MainMenu1: TMainMenu
    object PopupFile: TMenuItem
      Caption = 'File(&F)'
      OnClick = PopupFileClick
      object FileSave: TMenuItem
        Caption = 'Save(&S)'
        OnClick = SaveClick
      end
      object FileRec: TMenuItem
        Caption = 'Recording(&R)'
        OnClick = FileRecClick
      end
      object FileExit: TMenuItem
        Caption = 'End(&X)'
        OnClick = ExitClick
      end
    end
    object PopupShow: TMenuItem
      Caption = 'Display(&V)'
      OnClick = PopupShowClick
      object ShowPreview: TMenuItem
        Caption = 'Preview(&P)'
        OnClick = PreviewClick
      end
      object ShowCallBack: TMenuItem
        Caption = 'Callback(&B)'
        OnClick = CallBackClick
      end
      object ShowSnapShot: TMenuItem
        Caption = 'Snapshot(&S)'
        OnClick = SnapShotClick
      end
      object ShowCapture: TMenuItem
        Caption = 'Capture(&C)'
        OnClick = CaptureClick
      end
      object ShowTrigger: TMenuItem
        Caption = 'Trigger(&T)'
        OnClick = TriggerClick
      end
      object N4: TMenuItem
        Caption = '-'
      end
      object ShowStop: TMenuItem
        Caption = 'Pause'
        OnClick = ShowStopClick
      end
    end
    object PopupSet: TMenuItem
      Caption = 'Settings(&S)'
      OnClick = PopupSetClick
      object SetCamera: TMenuItem
        Caption = 'Camera settings(&C)'
        OnClick = SetCameraClick
      end
      object SetFilter: TMenuItem
        Caption = 'Filter settings(&F)'
        OnClick = SetFilterClick
      end
      object SetAnalog: TMenuItem
        Caption = 'Analog settings(&A)'
        OnClick = SetAnalogClick
      end
      object N5: TMenuItem
        Caption = '-'
      end
      object SetUserSize: TMenuItem
        Caption = 'User size settings'
        OnClick = SetUserSizeClick
      end
      object SetUserFilter: TMenuItem
        Caption = 'User filter settings'
        OnClick = SetUserFilterClick
      end
      object SetUserIO: TMenuItem
        Caption = 'User IO settings'
        OnClick = SetUserIOClick
      end
      object SetUserMonitor: TMenuItem
        Caption = 'User Monitor settings'
        OnClick = SetUserMonitorClick
      end
      object N1: TMenuItem
        Caption = '-'
      end
      object SetCorrection: TMenuItem
        Caption = 'TNIR settings'
        OnClick = SetCorrectionClick
      end
    end
    object PopupDll: TMenuItem
      AutoHotkeys = maManual
      AutoLineReduction = maManual
      Caption = 'DLL(&L)'
      object Reload: TMenuItem
        AutoHotkeys = maManual
        AutoLineReduction = maManual
        Caption = 'Reload'
        OnClick = ReloadClick
      end
    end
    object PopupDevice: TMenuItem
      Caption = 'Device(&D)'
      object DEVICE0: TMenuItem
        Caption = '0'
        OnClick = Device0Click
      end
      object Device1: TMenuItem
        Caption = '1'
        OnClick = Device1Click
      end
      object Device2: TMenuItem
        Caption = '2'
        OnClick = Device2Click
      end
      object Device3: TMenuItem
        Caption = '3'
        OnClick = Device3Click
      end
      object Device4: TMenuItem
        Caption = '4'
        OnClick = Device4Click
      end
      object Device5: TMenuItem
        Caption = '5'
        OnClick = Device5Click
      end
      object Device6: TMenuItem
        Caption = '6'
        OnClick = Device6Click
      end
      object Device7: TMenuItem
        Caption = '7'
        OnClick = Device7Click
      end
    end
  end
  object Timer1: TTimer
    OnTimer = Timer1Timer
    Top = 32
  end
  object SaveDialog1: TSaveDialog
    Top = 64
  end
  object RecTimer: TTimer
    OnTimer = Timer1Timer
    Left = 40
    Top = 32
  end
end

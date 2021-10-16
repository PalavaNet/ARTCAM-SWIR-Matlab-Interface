object Form1: TForm1
  Left = 236
  Top = 149
  Caption = 'Sample'
  ClientHeight = 718
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
      object FileSave: TMenuItem
        Caption = 'Save(&S)'
        OnClick = SaveClick
      end
      object FileExit: TMenuItem
        Caption = 'End(&X)'
        OnClick = ExitClick
      end
    end
    object PopupShow: TMenuItem
      Caption = 'Display(&V)'
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
    end
    object PopupSet: TMenuItem
      Caption = 'Settings(&S)'
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
      object Device8: TMenuItem
        Caption = '8'
      end
      object Device9: TMenuItem
        Caption = '9'
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
  end
  object Timer1: TTimer
    OnTimer = Timer1Timer
    Top = 32
  end
end

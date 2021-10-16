object Form1: TForm1
  Left = 236
  Top = 149
  Caption = 'Sample'
  ClientHeight = 697
  ClientWidth = 930
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
  object Image1: TImage
    Left = 0
    Top = 0
    Width = 449
    Height = 577
  end
  object Image2: TImage
    Left = 464
    Top = 0
    Width = 441
    Height = 577
  end
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
      Caption = 'View(&V)'
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
      object SetCamera1: TMenuItem
        Caption = 'Camera settings1(&C)'
        OnClick = SetCameraClick1
      end
      object SetCamera2: TMenuItem
        Caption = 'Camera settings2(&C)'
        OnClick = SetCameraClick2
      end
      object SetFilter1: TMenuItem
        Caption = 'Filter settings1(&F)'
        OnClick = SetFilterClick1
      end
      object SetFilter2: TMenuItem
        Caption = 'Filter settings2(&F)'
        OnClick = SetFilterClick2
      end
      object SetAnalog1: TMenuItem
        Caption = 'Analog settings1(&A)'
        OnClick = SetAnalogClick1
      end
      object SetAnalog2: TMenuItem
        Caption = 'Analog settings2(&A)'
        OnClick = SetAnalogClick2
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

Public Class frmOptionsRunner

    Private bChanged As Boolean
    Private fontDefault As Font
    Private bLoadedAdvanced As Boolean = False


    Public Property Changed() As Boolean
        Get
            Return bChanged
        End Get
        Set(ByVal Value As Boolean)
            bChanged = Value
            If bChanged Then
                btnApply.Enabled = True
            Else
                btnApply.Enabled = False
            End If
        End Set
    End Property


    Private Sub LoadForm()

        With UserSession
            .iMarginWidth = CInt(GetSetting("ADRIFT", "Runner", "Margin", "10"))
            nudMargin.Value = .iMarginWidth

            chkBlankLine.Checked = CBool(GetSetting("ADRIFT", "Runner", "BlankLine", "0"))
            chkLocationNames.Checked = .bShowShortLocations
            chkGraphics.Checked = .bGraphics
            chkSound.Checked = .bSound
            chkUseMyFont.Checked = CBool(GetSetting("ADRIFT", "Runner", "Myfont", "0"))

            pnlInputColour.BackColor = ColorTranslator.FromOle(CInt(GetSetting("ADRIFT", "Runner", "Text1", ColorTranslator.ToOle(Color.FromArgb(210, 37, 39)).ToString)))
            pnlOutputColour.BackColor = ColorTranslator.FromOle(CInt(GetSetting("ADRIFT", "Runner", "Text2", ColorTranslator.ToOle(Color.FromArgb(25, 165, 138)).ToString)))
            pnlLinkColour.BackColor = ColorTranslator.FromOle(CInt(GetSetting("ADRIFT", "Runner", "LinkColour", ColorTranslator.ToOle(Color.FromArgb(75, 215, 188)).ToString)))
            pnlBackgroundColour.BackColor = ColorTranslator.FromOle(CInt(GetSetting("ADRIFT", "Runner", "Background", ColorTranslator.ToOle(Color.Black).ToString)))

            chkAllowColours.Checked = CBool(GetSetting("ADRIFT", "Runner", "AllowColours", "1"))
            chkAllowFonts.Checked = CBool(GetSetting("ADRIFT", "Runner", "AllowFonts", "1"))
            chkEnableMenu.Checked = CBool(GetSetting("ADRIFT", "Runner", "EnableMenu", "1"))
            chkDisplayLinks.Checked = CBool(GetSetting("ADRIFT", "Runner", "DisplayLinks", "0"))

            If Adventure IsNot Nothing Then
                chkDisplayLinks.Enabled = Adventure.EnableMenu
                chkEnableMenu.Enabled = Adventure.EnableMenu
            End If

            fontDefault = .DefaultFont
            txtFont.Text = fontDefault.Name & ", " & SafeInt(Math.Round(fontDefault.Size, MidpointRounding.AwayFromZero))

            Changed = False
            'Me.Show()
        End With

    End Sub


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ApplyOptions()
        Me.Close()
    End Sub


    Private Sub ApplyOptions()

        With UserSession
            .iMarginWidth = CInt(nudMargin.Value)                   
            fRunner.SetMargins()

            SaveSetting("ADRIFT", "Runner", "Margin", .iMarginWidth.ToString)
            SaveSetting("ADRIFT", "Runner", "BlankLine", CInt(chkBlankLine.Checked).ToString)
            .bShowShortLocations = chkLocationNames.Checked
            SaveSetting("ADRIFT", "Runner", "showshortroom", CInt(.bShowShortLocations).ToString)

            'colInput = pnlInputColour.BackColor
            SaveSetting("ADRIFT", "Runner", "Text1", ColorTranslator.ToOle(pnlInputColour.BackColor).ToString)
            fRunner.SetInputColour()
            'fRunner.txtInput.ForeColor = colInput

            'colOutput = pnlOutputColour.BackColor
            SaveSetting("ADRIFT", "Runner", "Text2", ColorTranslator.ToOle(pnlOutputColour.BackColor).ToString)

            'colLink = pnlLinkColour.BackColor
            SaveSetting("ADRIFT", "Runner", "LinkColour", ColorTranslator.ToOle(pnlLinkColour.BackColor).ToString)
            SaveSetting("ADRIFT", "Runner", "Background", ColorTranslator.ToOle(pnlBackgroundColour.BackColor).ToString)

            SaveSetting("ADRIFT", "Runner", "AllowColours", CInt(chkAllowColours.Checked).ToString)
            AllowDevToSetColours = chkAllowColours.Checked

            fRunner.SetBackgroundColour()
            'fRunner.txtOutput.BackColor = pnlBackgroundColour.BackColor
            'fRunner.pnlTop.BackColor = pnlBackgroundColour.BackColor
            'fRunner.txtInput.BackColor = pnlBackgroundColour.BackColor
            'fRunner.pnlBottom.BackColor = pnlBackgroundColour.BackColor

            .DefaultFont = fontDefault
            fRunner.txtInput.SelectionFont = .DefaultFont

            SaveSetting("ADRIFT", "Runner", "AllowFonts", CInt(chkAllowFonts.Checked).ToString)
            SaveSetting("ADRIFT", "Runner", "EnableMenu", CInt(chkEnableMenu.Checked).ToString)
            SaveSetting("ADRIFT", "Runner", "DisplayLinks", CInt(chkDisplayLinks.Checked).ToString)

            UserSession.bUseDefaultFont = chkUseMyFont.Checked
            SaveSetting("ADRIFT", "Runner", "Myfont", CInt(chkUseMyFont.Checked).ToString)

            SaveSetting("ADRIFT", "Runner", "FontName", .DefaultFont.Name)
            SaveSetting("ADRIFT", "Runner", "Font Size", .DefaultFont.Size.ToString)
            SaveSetting("ADRIFT", "Runner", "FontBold", CInt(.DefaultFont.Bold).ToString)
            SaveSetting("ADRIFT", "Runner", "FontItalic", CInt(.DefaultFont.Italic).ToString)

            .bGraphics = chkGraphics.Checked
            SaveSetting("ADRIFT", "Runner", "Graphics", CInt(.bGraphics).ToString)
            .bSound = chkSound.Checked
            SaveSetting("ADRIFT", "Runner", "Sound", CInt(.bSound).ToString)

            If bLoadedAdvanced Then
                Dim bResetSound As Boolean = False
                If chkSoundWinMM.Checked <> SafeBool(GetSetting("ADRIFT", "Shared", "WinMM", "1")) Then bResetSound = True
                If chkSoundDirectX.Checked <> SafeBool(GetSetting("ADRIFT", "Shared", "DirectX", "1")) Then bResetSound = True
                If chkSoundSoundPlayer.Checked <> SafeBool(GetSetting("ADRIFT", "Shared", "SoundPlayer", "1")) Then bResetSound = True

                SaveSetting("ADRIFT", "Shared", "WinMM", CInt(chkSoundWinMM.Checked).ToString)
                SaveSetting("ADRIFT", "Shared", "DirectX", CInt(chkSoundDirectX.Checked).ToString)
                SaveSetting("ADRIFT", "Shared", "SoundPlayer", CInt(chkSoundSoundPlayer.Checked).ToString)

                If bResetSound Then ResetSounds()

            End If

            If Not .bSound Then
                For iChannel As Integer = 1 To 8
                    StopSound(iChannel)
                Next
            End If
            'Adventure.Changed = True
        End With

    End Sub


    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        ApplyOptions()
        Changed = False
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Changed Then
            Dim result As DialogResult = MessageBox.Show("Would you like to apply your changes?", "ADRIFT Runner", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If result = Windows.Forms.DialogResult.Yes Then ApplyOptions()
            If result = Windows.Forms.DialogResult.Cancel Then
                DialogResult = Nothing
                Exit Sub
            End If
        End If
        Me.Close()
    End Sub



    Private Sub frmOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetFormPosition(Me)
        Me.Icon = Icon.FromHandle(My.Resources.Resources.imgOptions16.GetHicon)
    End Sub


    Private Sub StuffChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkUseMyFont.CheckedChanged, chkAllowColours.CheckedChanged, chkAllowFonts.CheckedChanged, chkBlankLine.CheckedChanged, chkLocationNames.CheckedChanged, chkSound.CheckedChanged, chkGraphics.CheckedChanged, chkEnableMenu.CheckedChanged, chkDisplayLinks.CheckedChanged
        Changed = True
    End Sub


    Private Sub pnlInputColour_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInputColour.Click, pnlOutputColour.Click, pnlBackgroundColour.Click, pnlLinkColour.Click

        Dim dlgColour As New ColorDialog
        dlgColour.Color = CType(sender, Panel).BackColor

        If dlgColour.ShowDialog = Windows.Forms.DialogResult.OK Then
            CType(sender, Panel).BackColor = dlgColour.Color
            Changed = True
        End If

    End Sub


    Private Sub btnResetColours_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetColours.Click

        pnlInputColour.BackColor = Color.FromArgb(DEFAULT_INPUTCOLOUR) ' 210, 37, 39)
        pnlOutputColour.BackColor = Color.FromArgb(DEFAULT_OUTPUTCOLOUR) ' 25, 165, 138)
        pnlLinkColour.BackColor = Color.FromArgb(DEFAULT_LINKCOLOUR) ' 75, 215, 188)
        pnlBackgroundColour.BackColor = Color.FromArgb(DEFAULT_BACKGROUNDCOLOUR) ' Color.Black
        nudMargin.Value = 10
        chkBlankLine.Checked = False
        chkLocationNames.Checked = True
        chkGraphics.Checked = True
        chkSound.Checked = True
        chkAllowFonts.Checked = True
        chkAllowColours.Checked = True
        chkEnableMenu.Checked = True
        chkDisplayLinks.Checked = False

        fontDefault = New Font("Arial", 12, FontStyle.Regular)
        txtFont.Text = "Arial, 12"
        chkUseMyFont.Checked = False

        Changed = True
    End Sub


    Private Sub btnSetFont_Click(sender As System.Object, e As System.EventArgs) Handles btnSetFont.Click

        With fd
            .FontMustExist = False
            .MinSize = 8
            .MaxSize = 36

            'If txtFont.Text <> "" Then
            '    Dim sName As String = ""
            '    Dim emSize As Single = 0

            '    Dim sFont() As String = txtFont.Text.Split(","c)
            '    If sFont(0) <> "" Then sName = sFont(0)

            '    If sFont(1) <> "" Then
            '        If SafeDbl(sFont(1)) > 0 Then emSize = CSng(SafeDbl(sFont(1)))
            '    End If
            '    If sName <> "" AndAlso emSize > 0 Then
            '        Dim f As New Font(sName, emSize)
            '        .Font = f
            '    End If
            'End If
            .Font = fontDefault
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim sFontInfo() As String = .Font.ToString.Split(","c)
                txtFont.Text = sFontInfo(0).Replace("[Font: Name=", "") & ", " & SafeInt(Math.Round(SafeDbl(sFontInfo(1).Replace(" Size=", "")), MidpointRounding.AwayFromZero))
                fontDefault = .Font
                Changed = True
            End If
        End With
    End Sub

    Private Sub chkUseMyFont_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkUseMyFont.CheckedChanged
        txtFont.Enabled = chkUseMyFont.Checked
        btnSetFont.Enabled = chkUseMyFont.Checked
    End Sub

    Private Sub chkEnableMenu_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkEnableMenu.CheckedChanged
        chkDisplayLinks.Enabled = chkEnableMenu.Checked
    End Sub

#If Mono Then
    Private Sub tabsOptions_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabsOptions.SelectedIndexChanged

        If tabsOptions.SelectedTab is tabAdvanced Then
#Else
    Private Sub tabsOptions_SelectedTabChanged(sender As System.Object, e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabsOptions.SelectedTabChanged

        If e.Tab.Text = "Advanced" Then
#End If

            If Not bLoadedAdvanced Then

                Try
#If Mono Then
                    Dim IWinMM As clsSoundInterface = Nothing
#Else
                    Dim IWinMM As New MMSoundInterface(0)
#End If

                    chkSoundWinMM.Enabled = IWinMM IsNot Nothing AndAlso IWinMM.IsInitialised
                    If chkSoundWinMM.Enabled Then
                        chkSoundWinMM.Checked = SafeBool(GetSetting("ADRIFT", "Shared", "WinMM", "1"))
                    Else
                        chkSoundWinMM.Checked = False
                    End If
                Catch ex As Exception
                    chkSoundWinMM.Enabled = False
                    chkSoundWinMM.Checked = False
                End Try

                Try
#If Mono Then
                    Dim IDirectX As clsSoundInterface = Nothing
#Else
                    Dim IDirectX As New DirectXSoundInterface
#End If

                    chkSoundDirectX.Enabled = IDirectX IsNot Nothing AndAlso IDirectX.IsInitialised
                    If chkSoundDirectX.Enabled Then
                        chkSoundDirectX.Checked = SafeBool(GetSetting("ADRIFT", "Shared", "DirectX", "1"))
                    Else
                        chkSoundDirectX.Checked = False
                    End If
                Catch ex As Exception
                    chkSoundDirectX.Enabled = False
                    chkSoundDirectX.Checked = False
                End Try

                Try
                    Dim ISoundPlayer As New SoundPlayerSoundInterface
                    chkSoundSoundPlayer.Enabled = ISoundPlayer IsNot Nothing AndAlso ISoundPlayer.IsInitialised
                    If chkSoundSoundPlayer.Enabled Then
                        chkSoundSoundPlayer.Checked = SafeBool(GetSetting("ADRIFT", "Shared", "SoundPlayer", "1"))
                    Else
                        chkSoundSoundPlayer.Checked = False
                    End If
                Catch ex As Exception
                    chkSoundSoundPlayer.Enabled = False
                    chkSoundSoundPlayer.Checked = False
                End Try

                bLoadedAdvanced = True
            End If
        End If

    End Sub

    Private Sub pnlBackgroundColour_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlBackgroundColour.Paint

    End Sub

    Private Sub pnlInputColour_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlInputColour.Paint

    End Sub
End Class

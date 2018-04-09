Module Mono

    Dim s As New CSettings(False)

    Public Function GetSetting(AppName As String, Section As String, Key As String, Optional [Default] As String = "") As String
        '    Return [Default]
        Return SafeString(s.GetSetting(AppName, Section, Key, [Default]))
    End Function

    Public Sub SaveSetting(AppName As String, Section As String, Key As String, Value As String)
        s.SaveSetting(AppName, Section, Key, Value)
    End Sub

    Public Sub AddPrevious()

        Dim sFilename As String

        For iPrevious As Integer = 1 To 10
            sFilename = GetSetting("ADRIFT", "Runner", "Recent_" & iPrevious, "")
            If sFilename <> "" Then
                Dim tsi As ToolStripItem = fRunner.miRecentAdventures.DropDownItems.Add("&" & iPrevious & "  " & sFilename, Nothing, AddressOf fRunner.miRecentAdventures_Click)
                tsi.Tag = sFilename
            End If
        Next

    End Sub

    Public Class ComboBoxItem
        Public KeyboardShortcut As Keys

        Public Shadows ReadOnly Property ToString As String
            Get
                Return KeyboardShortcut.ToString
            End Get
        End Property

        Public Sub New(ByVal KeyboardShortcut As Keys)
            Me.KeyboardShortcut = KeyboardShortcut
        End Sub
    End Class


    Private MenuBackColor As Color = Color.FromArgb(60, 59, 55)
    Private MenuForeColor As Color = Color.FromArgb(223, 219, 210)

    Public Sub SetWindowStyle(ByVal frmTarget As Form)

        'frmTarget.SuspendLayout()

        ''frmTarget.ForeColor = Color.White
        ''frmTarget.BackColor = Color.SlateGray

        'For Each c As Control In frmTarget.Controls
        '    SetControlStyle(c)
        'Next

        'frmTarget.ResumeLayout()

    End Sub

    Public Sub SetControlStyle(ByVal c As Control)

        Select Case True
            Case TypeOf c Is StatusBar
                With CType(c, StatusBar)

                End With
            Case TypeOf c Is MenuStrip
                With CType(c, MenuStrip)
                    c.BackColor = MenuBackColor
                    c.ForeColor = MenuForeColor                    
                End With
            Case TypeOf c Is TabControl
                With CType(c, TabControl)
                    c.BackColor = MenuBackColor
                    c.ForeColor = MenuForeColor
                End With
            Case TypeOf c Is ToolStrip
                With CType(c, ToolStrip)
                    c.ForeColor = MenuForeColor
                    c.BackColor = MenuBackColor
                End With

            Case TypeOf c Is Label

            Case TypeOf c Is SplitterPanel Or TypeOf c Is RichTextBox Or TypeOf c Is SplitContainer Or TypeOf c Is Panel
                ' Ignore
            Case Else
                'MsgBox(c.ToString)
        End Select

        If Not c.Controls Is Nothing Then
            For Each cChild As Control In c.Controls
                SetControlStyle(cChild)
            Next
        End If

    End Sub

End Module



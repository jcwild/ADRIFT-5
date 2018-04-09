Public NotInheritable Class AboutBox

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        'Me.lblProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision)
        Me.LabelCopyright.Text = My.Application.Info.Copyright        
        Me.lblInfo.Text = My.Application.Info.Description.Split(Chr(10))(0) & vbCrLf & vbCrLf ' Split here because RPX appends to this
#If Mono Then
        lblInfo.Text = lblInfo.Text.Replace("Windows", "Linux")
#End If
#If Generator Then
        Me.lblInfo.Text &= "This product is Donationware, not Freeware.  If you enjoy this product and use it a lot, you are encouraged to make a donation."
        If IsRegistered Then
            Dim sRegisteredTo As String = Dencode(GetSetting("ADRIFT", "Shared", "RegName", ""))
            If sRegisteredTo <> "" Then
                Me.lblRegistered.Text = "Registered to " & sRegisteredTo 'Dencode(sRegisteredTo, 0).ToString
            Else
                Me.lblRegistered.Text = "" 'Registered copy"
            End If
        Else
            Me.lblRegistered.Text = "" 'Unregistered copy"
            'lblRegistered.Appearance.ForeColor = Color.Red
        End If
#Else
        Me.lblRegistered.Text = ""
        Me.lblInfo.Text &= "This product is Freeware."
#If Not Mono Then
        btnDonate.Visible = False
#End If
#End If

        Me.lblInfo.Text &= "  " & ApplicationTitle & " was created using Visual Studio 2005/08/10."
        Me.lblInfo.Text &= vbCrLf & vbCrLf & "Splash image ""Adrift"" © V. Milovic 2010 (http://www.brokentoyland.com) and used with permission."

        ' Randomly swap the OK/Donate buttons around
#If Not Mono Then
        If Random(0, 1) = 1 Then
            Dim iX As Integer = btnDonate.Location.X
            btnDonate.Location = New Point(OKButton.Location.X, btnDonate.Location.Y)
            OKButton.Location = New Point(iX, OKButton.Location.Y)
            'CancelButton = btnDonate
            AcceptButton = btnDonate
            btnDonate.TabIndex = 0
            btnDonate.TabStop = True
        End If
#End If
        'Try
        '    'For Each ff As FontFamily In GetFont.Families
        '    '    If ff.IsStyleAvailable(FontStyle.Regular) Then
        '    '        lblProductName.Font = New Font(ff, lblProductName.Font.Size, FontStyle.Regular)
        '    '    End If
        '    'Next
        '    Dim sFont As String = Application.StartupPath & IO.Path.DirectorySeparatorChar & "LYDIAN.TTF"
        '    If IO.File.Exists(sFont) Then
        '        Dim pfc As New System.Drawing.Text.PrivateFontCollection
        '        pfc.AddFontFile(sFont)
        '        For Each ff As FontFamily In pfc.Families
        '            If ff.IsStyleAvailable(FontStyle.Regular) Then
        '                lblProductName.Font = New Font(ff, lblProductName.Font.Size, FontStyle.Regular)
        '            End If
        '        Next
        '    End If
        'Catch ex As Exception
        'End Try

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub LogoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoPictureBox.Click
        System.Diagnostics.Process.Start("http://www.brokentoyland.com")
    End Sub

    Private Sub UltraGroupBox1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles UltraGroupBox1.Paint

        If pfc Is Nothing Then pfc = GetFontCollection()
        Dim f As Font

        For Each ff As FontFamily In pfc.Families
            If ff.IsStyleAvailable(FontStyle.Regular) Then
                f = New Font(ff, 14, FontStyle.Regular)
                e.Graphics.DrawString(My.Application.Info.ProductName, f, New SolidBrush(Color.Black), New Point(354, 13))
            End If
        Next

    End Sub

#If Not Mono Then
    Private Sub btnDonate_Click(sender As System.Object, e As System.EventArgs) Handles btnDonate.Click
        System.Diagnostics.Process.Start("https://www.paypal.com/uk/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=FTJPYPFLJLCV6")
    End Sub
#End If

End Class

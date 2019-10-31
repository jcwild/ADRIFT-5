Public Class Splash

    Private Sub Splash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'lblVersion5.Text = "v" & sLeft(Application.ProductVersion, Application.ProductVersion.Length - 2)

        Try
            'For Each ff As FontFamily In GetFont.Families
            '    If ff.IsStyleAvailable(FontStyle.Regular) Then
            '        For Each lbl As Label In New Label() {lblADRIFT, lblADRIFTFull, lblCopyright, lblGenerator, lblVersion5}
            '            lbl.Font = New Font(ff, lbl.Font.Size, FontStyle.Regular)
            '        Next
            '    End If
            'Next
            'Dim sFont As String = Application.StartupPath & IO.Path.DirectorySeparatorChar & "LYDIAN.TTF"
            'If IO.File.Exists(sFont) Then
            '    Dim pfc As New System.Drawing.Text.PrivateFontCollection
            '    pfc.AddFontFile(sFont)
            '    For Each ff As FontFamily In pfc.Families
            '        If ff.IsStyleAvailable(FontStyle.Regular) Then
            '            For Each lbl As Label In New Label() {lblADRIFT, lblADRIFTFull, lblCopyright, lblGenerator, lblVersion5}
            '                lbl.Font = New Font(ff, lbl.Font.Size, FontStyle.Regular)
            '            Next
            '        End If
            '    Next
            'End If

            'Dim pfc As New System.Drawing.Text.PrivateFontCollection
            'Dim bytLydian As Byte() = My.Resources.Lydian
            'gch = Runtime.InteropServices.GCHandle.Alloc(bytLydian, Runtime.InteropServices.GCHandleType.Pinned)
            'pfc.AddMemoryFont(gch.AddrOfPinnedObject, bytLydian.Length)


            'Dim pfc As System.Drawing.Text.PrivateFontCollection = GetFontCollection()
            'For Each ff As FontFamily In pfc.Families
            '    If ff.IsStyleAvailable(FontStyle.Regular) Then
            '        For Each lbl As Label In New Label() {lblADRIFT, lblADRIFTFull, lblCopyright, lblGenerator, lblVersion5}
            '            lbl.UseCompatibleTextRendering = True
            '            lbl.Font = New Font(ff, lbl.Font.Size, FontStyle.Regular)
            '        Next
            '    End If
            'Next

        Catch
        End Try

        '#If Generator Then
        '        lblGenerator.Text = "Developer"
        '#Else
        '        lblGenerator.Text = "Runner"
        '#End If

    End Sub


    Private Sub imgAdrift_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgAdrift.Click
        Me.Close()
    End Sub



    Private Sub imgAdrift_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles imgAdrift.Paint

        If pfc Is Nothing Then pfc = GetFontCollection()
        Dim f As Font

        For Each ff As FontFamily In pfc.Families
            If ff.IsStyleAvailable(FontStyle.Regular) Then
                f = New Font(ff, 60, FontStyle.Regular)
#If Mono Then
                e.Graphics.DrawString("ADRIFT", f, New SolidBrush(Color.White), New Point(7, 0))
#Else
                e.Graphics.DrawString("ADRIFT", f, New SolidBrush(Color.White), New Point(-3, 0))
#End If
                f = New Font(ff, 18, FontStyle.Regular)
#If Generator Then
                e.Graphics.DrawString("Developer", f, New SolidBrush(Color.White), New Point(8, 96))
#Else
                e.Graphics.DrawString("Runner", f, New SolidBrush(Color.White), New Point(8, 96))
#End If
                f = New Font(ff, 11.25, FontStyle.Regular)
                e.Graphics.DrawString("© Campbell Wild 1998-2019", f, New SolidBrush(Color.White), New Point(369, 393))
                f = New Font(ff, 9.75, FontStyle.Regular)
                e.Graphics.DrawString("Adventure Development & Runner - Interactive Fiction Toolkit", f, New SolidBrush(Color.White), New Point(10, 81))
#If Mono Then
                e.Graphics.DrawString("v" & Application.ProductVersion, f, New SolidBrush(Color.White), New Point(257, 15))
#Else
                e.Graphics.DrawString("v" & sLeft(Application.ProductVersion, Application.ProductVersion.Length - 2), f, New SolidBrush(Color.White), New Point(257, 15))
#End If

            End If
        Next
    End Sub
End Class
Module WebStuff

    'Public WebPage As _Default
    Public iId As Integer = 0
    'Private _sURL As String
    Public Property sURL As String
        Get
            'Return _sURL
            Return SafeString(HttpContext.Current.Session.Item("sURL"))
        End Get
        Set(value As String)
            '_sURL = value
            HttpContext.Current.Session.Item("sURL") = value
        End Set
    End Property


    Public Property MapHeight As Integer
        Get
            Return SafeInt(HttpContext.Current.Session.Item("MapHeight"))
        End Get
        Set(value As Integer)
            HttpContext.Current.Session.Item("MapHeight") = value
        End Set
    End Property

    Public Property MapWidth As Integer
        Get
            Return SafeInt(HttpContext.Current.Session.Item("MapWidth"))
        End Get
        Set(value As Integer)
            HttpContext.Current.Session.Item("MapWidth") = value
        End Set
    End Property


    Public Class Cursors
        Friend Shared Arrow As Object
        Friend Shared WaitCursor As Object
        Friend Shared Current As Object
        Friend Shared SizeAll As Object
        Friend Shared NoMove2D As Object
        Friend Shared Hand As Object
    End Class
    Public Cursor As Cursors

    Public MousePosition As Point

    Public Class clsApplication
        Friend Shared ExecutablePath As Object
        Friend Shared StartupPath As String
        Friend Shared LocalUserAppDataPath As String
        Friend Shared ProductVersion As String

        Public Sub DoEvents()

        End Sub

    End Class
    Public Application As clsApplication
    Public fRunner As _Default ' New frmRunner


    Public Function MsgBox(Prompt As String, Buttons As Microsoft.VisualBasic.MsgBoxStyle, Title As String) As Microsoft.VisualBasic.MsgBoxResult
        Select Case MessageBox.Show(Prompt, Title)
            Case DialogResult.OK
                Return MsgBoxResult.Ok
            Case DialogResult.Cancel
                Return MsgBoxResult.Cancel
            Case Else
                Return MsgBoxResult.Cancel
        End Select
    End Function
    Public Function MsgBox(Prompt As String, Buttons As Microsoft.VisualBasic.MsgBoxStyle) As Microsoft.VisualBasic.MsgBoxResult
        Select Case MessageBox.Show(Prompt)
            Case DialogResult.OK
                Return MsgBoxResult.Ok
            Case DialogResult.Cancel
                Return MsgBoxResult.Cancel
            Case Else
                Return MsgBoxResult.Cancel
        End Select
    End Function
    Public Function MsgBox(Prompt As String) As Microsoft.VisualBasic.MsgBoxResult
        MessageBox.Show(Prompt)
        Return MsgBoxResult.Ok            
    End Function
    Public Class MessageBox
        Private Shared m_executingPages As New Hashtable()

        Public Shared Function Show(ByVal text As String) As System.Windows.Forms.DialogResult
            Return Show(text, "ADRIFT WebRunner")
        End Function
        Public Shared Function Show(ByVal text As String, ByVal caption As String) As System.Windows.Forms.DialogResult
            Return Show(text, caption, MessageBoxButtons.OK)
        End Function
        Public Shared Function Show(ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons) As System.Windows.Forms.DialogResult            
            Return Show(text, caption, buttons, MessageBoxIcon.None)            
        End Function
        Public Shared Function Show(ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon) As System.Windows.Forms.DialogResult            
            Return Show(text, caption, buttons, icon, MessageBoxDefaultButton.Button1)            
        End Function
        Public Shared Function Show(ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal defaultButton As MessageBoxDefaultButton) As System.Windows.Forms.DialogResult            
            Select Case buttons
                Case MessageBoxButtons.OK
                    HttpContext.Current.Response.Write("<script type=""text/javascript"">alert(""" & text & """);</script>")
                    Return DialogResult.OK
                Case MessageBoxButtons.YesNo
                    HttpContext.Current.Response.Write("<script type=""text/javascript"">alert(""" & text & "\n\n" & "Yes | [[No]]"");</script>")
                    'HttpContext.Current.Response.Write("<script type=""text/javascript"">confirm(""" & text & "\n" & "(Yes / [No])"");</script>")
                    Return DialogResult.No
                Case MessageBoxButtons.YesNoCancel
                    HttpContext.Current.Response.Write("<script type=""text/javascript"">alert(""" & text & "\n\n" & "Yes | No | [[Cancel]]"");</script>")
                    Return DialogResult.Cancel
            End Select                        
            Return DialogResult.Cancel
        End Function

    End Class

   

    Public Function InputBox(Prompt As String, Title As String, DefaultResponse As String) As String        
        HttpContext.Current.Response.Write("<script type=""text/javascript"">alert(""Inputbox for " & Prompt & " not allowed in WebRunner"");</script>")
        Return ""
    End Function

End Module

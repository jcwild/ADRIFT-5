Imports System.Web.UI.WebControls

Public Class _Default
    Inherits System.Web.UI.Page

    Friend WithEvents pbxGraphics As Object ' clsImage
    Friend WithEvents btnMore As New Windows.Forms.Button
    Friend pnlBottom As New System.Windows.Forms.Panel()
    'Friend WithEvents StatusBar As New Windows.Forms.StatusBar
    Friend WithEvents txtInput As New Windows.Forms.RichTextBox
    Friend WithEvents txtOutput As New Windows.Forms.RichTextBox    


    'Friend Property Map As ADRIFT.Map
    '    Get
    '        If UserSession.Map Is Nothing Then
    '            UserSession.Map = New ADRIFT.Map
    '            'Dim f As New Windows.Forms.Form
    '            'f.Controls.Add(UserSession.Map)
    '            UserSession.Map.RecalculateNode(Adventure.Map.FindNode(Adventure.Player.Location.LocationKey))
    '            UserSession.Map.SelectNode(Adventure.Player.Location.LocationKey)
    '        End If
    '        Return UserSession.Map
    '        'Dim m As New ADRIFT.Map
    '        'm.RecalculateNode(Adventure.Map.FindNode(Adventure.Player.Location.LocationKey))
    '        'm.SelectNode(Adventure.Player.Location.LocationKey)
    '        'Return m
    '    End Get
    '    Set(value As ADRIFT.Map)
    '        UserSession.Map = value
    '    End Set
    'End Property

    'Private Property LastLoad() As Date
    '    Get
    '        If HttpContext.Current.Session.Item("LastLoad") Is Nothing Then
    '            Return Date.MinValue
    '        Else
    '            Return CType(HttpContext.Current.Session.Item("LastLoad"), Date)
    '        End If
    '    End Get
    '    Set(value As Date)
    '        HttpContext.Current.Session.Item("LastLoad") = value
    '    End Set
    'End Property

    Private Property KeyPressed As Boolean
        Get
            Return HttpContext.Current.Session.Item("KeyPressed")
        End Get
        Set(value As Boolean)
            HttpContext.Current.Session.Item("KeyPressed") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Now.Subtract(LastLoad).TotalMilliseconds < 200 Then Exit Sub
        ''Debug.WriteLine(Now.Subtract(LastLoad).TotalMilliseconds & " milliseconds")
        'LastLoad = Now
        'Debug.WriteLine("Callback from: " & ScriptManager1.AsyncPostBackSourceElementID)        
        'Debug.WriteLine(Now.TimeOfDay.ToString & " Page_Load, IsPostBack: " & Page.IsPostBack & ", KeyPressed: " & KeyPressed & ", txtInputWeb.Text: " & txtInputWeb.Text)
        'For Each Channel As HtmlGenericControl In New HtmlGenericControl() {Channel1}
        '    Channel.InnerHtml = ""
        'Next

        If Request.Browser.Browser = "Chrome" OrElse Request.Browser.Browser = "Safari" Then ' For some reason Chrome seems to be calling a second Page_Load
            If Page.IsPostBack AndAlso txtInputWeb.Text = "" AndAlso Not KeyPressed AndAlso WaitKeyBuffer <> "" Then
                ' User has pressed Enter whilst in a <waitkey>, but nothing in Inputbox
                KeyPressed = True
            End If
            If Not KeyPressed AndAlso Page.IsPostBack Then Exit Sub
            KeyPressed = False
        End If

        fRunner = Me

        'txtOutputWeb.InnerText = HttpContext.Current.Request.PhysicalApplicationPath
        'Exit Sub

        IO.Directory.SetCurrentDirectory(DataPath) 'IO.Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data"))

        If Page.ToString = "ASP.about_aspx" Then About()
        If Page.ToString <> "ASP.default_aspx" Then Exit Sub

        'If StatusBar.Panels.Count = 0 Then
        '    Dim pnlDescription As New StatusBarPanel
        '    pnlDescription.Name = "Description"
        '    StatusBar.Panels.Add(pnlDescription)
        '    Dim pnlScore As New StatusBarPanel
        '    pnlScore.Name = "Score"
        '    StatusBar.Panels.Add(pnlScore)
        'End If

        If UserSession Is Nothing Then
            UserSession = New RunnerSession
        End If
        If Adventure Is Nothing Then
            GlobalStartup()
            SetColours()
        Else
            If Not Page.IsPostBack Then
                ' Hmm, returning to the page from another
                SetColours()
                ' Clear text and set to last message
                UserSession.UpdateStatusBar()
                txtOutputWeb.InnerHtml = ""
                If Not Locked Then UserSession.Display(Adventure.htblLocations(Adventure.Player.Location.LocationKey).ViewLocation & vbCrLf & vbCrLf, True)
            End If
        End If

        If Locked Then
            ' If there is anything in the waitkey buffer, output it to screen now
            Locked = False
            Dim sBuffer As String = WaitKeyBuffer
            If sBuffer <> "" Then
                WaitKeyBuffer = ""
                AppendHTML(sBuffer)
            End If
            txtInputWeb.Text = ""
        ElseIf txtInputWeb.Text <> "" Then
            Dim sCommand As String = txtInputWeb.Text
            txtInputWeb.Text = ""
            UserSession.Process(sCommand)
        End If

        'If IsPostBack Then      


        If Request("advid") <> "" Then
            ' Load from adrift.co
            If SafeInt(Request("advid")) <> iId Then
                iId = SafeInt(Request("advid"))
                MsgBox("Load from adrift.co by ID")
            End If
        ElseIf Request("game") <> "" Then
            If Request("game") <> sURL Then
                sURL = Request("game")
                If sURL.ToLower.EndsWith(".taf") OrElse sURL.ToLower.EndsWith(".blorb") Then

                    Dim sFile As String = ""
                    If IO.File.Exists(sURL) Then
                        sFile = sURL
                    ElseIf IO.File.Exists(IO.Path.GetFileName(sURL)) Then
                        sFile = IO.Path.GetFileName(sURL)
                    Else
                        Dim sTxt As String = sURL.Replace("/", "_").Replace("\", "_") & ".txt"
                        If IO.File.Exists(sTxt) Then
                            ' This game has been downloaded before
                            ' sTxt contains the IFID

                        Else
                            ' We need to download the file
                            Try
                                Dim wc As New System.Net.WebClient
                                sFile = IO.Path.GetFileName(sURL)
                                wc.DownloadFile(sURL, sFile)
                                wc.Dispose()

                                Threading.Thread.Sleep(10)
                            Catch exHLE As System.Net.HttpListenerException
                                ErrMsg("Error downloading " & sURL, exHLE)
                            Catch ex As Exception
                                ErrMsg("Error downloading " & sURL, ex)
                            End Try
                        End If
                    End If

                    If IO.File.Exists(sFile) Then
                        ' Ok, just load the local file
                        txtOutputWeb.InnerText = ""
                        UserSession.OpenAdventure(sFile)
                        If Adventure.dVersion < 5 OrElse Adventure.BabelTreatyInfo Is Nothing Then
                            UserSession.sGameFolder = IO.Path.Combine(DataPath, IO.Path.GetFileNameWithoutExtension(sFile))
                        Else
                            UserSession.sGameFolder = IO.Path.Combine(DataPath, Adventure.BabelTreatyInfo.Stories(0).Identification.IFID)
                        End If

                        If Not IO.Directory.Exists(UserSession.sGameFolder) Then
                            IO.Directory.CreateDirectory(UserSession.sGameFolder)
                        End If

                        'If sFile = "cursed.taf" OrElse sFile = "how suzy got her powers.taf" Then CType(Page.Master, Site).footer.InnerHtml = "Please be aware that v5 is not yet 100% compatible with v4.  For this reason, please play this game on <a href=""http://www.adrift.co/files/ADRIFT40r.zip"">v4 Runner</a>."
                    Else
                        ErrMsg("File not found")
                    End If

                    'If IO.Path.GetFileName(sURL) = sURL Then
                    '    ' Filename only - look in App_Data folder
                    '    sURL = IO.Path.Combine(IO.Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data"), sURL)
                    'End If

                    SetColours()
                Else
                    ErrMsg("WebRunner can only play taf or blorb files!")
                End If
            End If
            'Response.Redirect("Default.aspx")
        End If
        txtInputWeb.Focus()

    End Sub


    Private Sub About()

        Dim lKeys As New List(Of String)
        For Each sKey As String In txtOutputWebAbout.Style.Keys
            lKeys.Add(sKey)
        Next
        For Each sKey As String In New String() {"font-family", "font-size", "color"}
            If lKeys.Contains(sKey) Then txtOutputWebAbout.Style.Remove(sKey)
        Next
        If Adventure IsNot Nothing Then
            txtOutputWebAbout.Style.Add("font-family", Adventure.DefaultFontName)
            txtOutputWebAbout.Style.Add("font-size", Adventure.DefaultFontSize.ToString & "pt")
        End If
        txtOutputWebAbout.Style.Add("color", "#" & Hex(GetOutputColour.ToArgb).Substring(2))

        UserSession.Display("ADRIFT WebRunner version " & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString & vbCrLf & vbCrLf, True)
        If Adventure IsNot Nothing Then
            If Adventure.BabelTreatyInfo.Stories IsNot Nothing Then
                UserSession.Display(Adventure.Title & vbCrLf & "by " & Adventure.Author & vbCrLf & "Version " & Adventure.BabelTreatyInfo.Stories(0).Releases.Attached.Release.Version & vbCrLf & vbCrLf, True)
                If Adventure.BabelTreatyInfo.Stories(0).Releases.Attached.Release IsNot Nothing Then
                    Dim sBuild As String = "Built "
                    If Adventure.BabelTreatyInfo.Stories(0).Releases.Attached.Release.CompilerVersion <> "" Then
                        sBuild &= "using ADRIFT Developer " & Adventure.BabelTreatyInfo.Stories(0).Releases.Attached.Release.CompilerVersion & " "
                    Else
                        sBuild &= "using ADRIFT "
                        If Adventure.dVersion >= 5 Then sBuild &= "Developer " Else sBuild &= "Generator "
                        sBuild &= Adventure.Version & " "
                    End If
                    If Adventure.BabelTreatyInfo.Stories(0).Releases.Attached.Release.ReleaseDate <> Date.MinValue Then sBuild &= "on " & Adventure.BabelTreatyInfo.Stories(0).Releases.Attached.Release.ReleaseDate.ToShortDateString
                    UserSession.Display(sBuild, True)
                End If
            End If
        End If

        UserSession.Display(vbCrLf & vbCrLf & "ADRIFT WebRunner is still in development, and there may be bugs.  If you find any, please notify <a href=""mailto:campbell@adrift.org.uk"">Campbell</a> or add it to the ADRIFT <a href=""http://www.adrift.org.uk/cgi/new/adrift.cgi?script=bugs5"">bugs list</a>.  At present, there are a few things that WebRunner can't do that the Runner app does.  For the full experience, please <a href=""http://www.adrift.co/download"">download</a> ADRIFT Runner for your operating system.", True)

    End Sub


    Public Sub SetInput(ByVal sText As String)
        txtInputWeb.Text = sText
    End Sub

    Public Sub SubmitCommand()

    End Sub

    Friend Sub SetBackgroundColour(Optional ByVal colBackground As Color = Nothing)
        If colBackground = Nothing Then colBackground = GetBackgroundColour()
        fRunner.txtOutput.BackColor = colBackground
        'fRunner.pnlTop.BackColor = colBackground
        fRunner.txtInput.BackColor = colBackground
        fRunner.pnlBottom.BackColor = colBackground
    End Sub

    Private Sub SetColours()

        Dim lKeys As New List(Of String)
        For Each sKey As String In txtOutputWeb.Style.Keys
            lKeys.Add(sKey)
        Next
        If Adventure IsNot Nothing Then
            For Each sKey As String In New String() {"font-family", "font-size", "color"}
                If lKeys.Contains(sKey) Then txtOutputWeb.Style.Remove(sKey)
            Next
            txtOutputWeb.Style.Add("font-family", Adventure.DefaultFontName)
            txtOutputWeb.Style.Add("font-size", Adventure.DefaultFontSize.ToString & "pt")
        End If
        txtOutputWeb.Style.Add("color", "#" & Hex(GetOutputColour.ToArgb).Substring(2))

        lKeys.Clear()
        For Each sKey As String In InputWeb.Style.Keys
            lKeys.Add(sKey)
        Next
        For Each sKey As String In New String() {"font-family", "font-size", "color"}
            If lKeys.Contains(sKey) Then InputWeb.Style.Remove(sKey)
        Next
        If Adventure IsNot Nothing Then
            InputWeb.Style.Add("font-family", Adventure.DefaultFontName)
            InputWeb.Style.Add("font-size", Adventure.DefaultFontSize.ToString & "pt")
        End If
        InputWeb.Style.Add("color", "#" & Hex(GetInputColour.ToArgb).Substring(2))

        lKeys.Clear()
        For Each sKey As String In txtInputWeb.Style.Keys
            lKeys.Add(sKey)
        Next
        For Each sKey As String In New String() {"font-family", "font-size", "color"}
            If lKeys.Contains(sKey) Then txtInputWeb.Style.Remove(sKey)
        Next
        If Adventure IsNot Nothing Then
            txtInputWeb.Style.Add("font-family", Adventure.DefaultFontName)
            txtInputWeb.Style.Add("font-size", Adventure.DefaultFontSize.ToString & "pt")
        End If
        txtInputWeb.Style.Add("color", "#" & Hex(GetInputColour.ToArgb).Substring(2))
    End Sub


    Private Function LoadFromID(ByVal iId As Integer) As Boolean

    End Function
    Private Function LoadFromURL(ByVal sURL As String) As Boolean

    End Function
    Private Function LoadFromFile(ByVal sFile As String) As Boolean
        Return UserSession.OpenAdventure(sFile)
        'Return OpenAdventure("C:\Users\CampbellWild\Documents\ADRIFT5\Games\jim5.taf")
    End Function

    Protected Sub txtInputWeb_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtInputWeb.TextChanged
        'If Locked Then
        '    Locked = False
        '    Dim sBuffer As String = WaitKeyBuffer
        '    If sBuffer <> "" Then
        '        WaitKeyBuffer = ""
        '        AppendHTML(sBuffer)
        '    End If
        'Else
        '    Process(txtInputWeb.Text)
        'End If
        'txtInputWeb.Text = ""
        KeyPressed = True
        'Debug.WriteLine(Now.TimeOfDay.ToString & " txtInputWeb_TextChanged: " & txtInputWeb.Text)
        'Page_Load(Nothing, Nothing) ' Chrome seems to do a Page_Load after this, but Firefox doesn't :-/
    End Sub

    Private Sub txtInput_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInput.TextChanged
        If txtInput.Text <> txtInputWeb.Text Then
            txtInputWeb.Text = txtInput.Text
        End If
    End Sub



    'Public Sub AppendHTML(ByVal sText As String)
    '    sText = sText.Replace("<c>", "<font color=""#" & Hex(colInput.ToArgb).Substring(2) & """>").Replace("</c>", "</font>")        
    '    txtOutputWeb.Text &= sText
    'End Sub

    Public Sub AppendHTML(ByVal sSource As String)

        If txtOutputWeb IsNot Nothing AndAlso WaitKeyBuffer <> "" Then
            WaitKeyBuffer &= sSource
            Exit Sub
        End If

        If sSource.Contains("<>") Then
            sSource = sSource.Replace("<>", "")
        End If

        If sSource.Contains("<waitkey>") Then
            Dim sBefore As String = sSource.Substring(0, sSource.IndexOf("<waitkey>"))
            If sBefore <> "" Then AppendHTML(sBefore)
            WaitKeyBuffer = sSource.Substring(sSource.IndexOf("<waitkey>") + 9)
            WaitKey()
            Exit Sub
        End If

        If sSource.Contains("<cls>") Then
            Dim sBefore As String = sSource.Substring(0, sSource.IndexOf("<cls>"))
            If sBefore <> "" Then AppendHTML(sBefore)
            txtOutputWeb.InnerHtml = ""
            Dim sAfter As String = sSource.Substring(sSource.IndexOf("<cls>") + 5)
            UserSession.stackFonts.Clear()
            UserSession.stackColours.Clear()
            If sAfter <> "" Then AppendHTML(sAfter)
            Exit Sub
        End If

        ' Corrections to source...
        sSource = sSource.Replace("<font face=""Wingdings"" size=14>Ø</font>", "<font size=14>" & ChrW(&H27A2) & "</font>")
        sSource = sSource.Replace(vbCrLf, "<br>").Replace(vbLf, "<br>").Replace("centre>", "center>")
        While sSource.Contains("  ")
            sSource = sSource.Replace("  ", "&nbsp;&nbsp;")
        End While
        While sSource.Contains("<br> ")
            sSource = sSource.Replace("<br> ", "<br>&nbsp;")
        End While
        sSource = sSource.Replace("<br>", "<br/>")

        Dim Chunks As New List(Of String)
        Dim sCurrentChunk As String = ""
        Dim iLevel As Integer = 0
        For i As Integer = 0 To sSource.Length - 1
            Select Case sSource(i)
                Case "<"c
                    If iLevel = 0 Then
                        If sCurrentChunk <> "" Then Chunks.Add(sCurrentChunk)
                        sCurrentChunk = ""
                    End If
                    iLevel += 1
                    sCurrentChunk &= "<"
                Case ">"c
                    sCurrentChunk &= ">"
                    iLevel -= 1
                    If iLevel = 0 Then
                        Chunks.Add(sCurrentChunk)
                        sCurrentChunk = ""
                    End If
                Case Else
                    sCurrentChunk &= sSource(i)
            End Select
        Next
        If sCurrentChunk <> "" Then Chunks.Add(sCurrentChunk)
        'For Each sChunk As String In sSource.Split("<")
        '    If sChunk <> "" Then
        '        If sChunk.Contains(">") Then
        '            Chunks.Add("<" & sChunk.Split(">")(0) & ">")
        '            If sChunk.Split(">")(1) <> "" Then Chunks.Add(sChunk.Split(">")(1))
        '        Else
        '            Chunks.Add(sChunk)
        '        End If
        '    End If
        'Next

        For iChunk As Integer = 0 To Chunks.Count - 1
            With Chunks(iChunk)
                If .StartsWith("<") AndAlso .EndsWith(">") Then
                    Dim sTag As String = .Substring(1, .Length - 2)

                    If sTag.StartsWith("!--") AndAlso sTag.EndsWith("--") Then
                        Chunks(iChunk) = ""
                        sTag = ""
                    End If

                    Dim sTagName As String = sTag
                    If sTagName.Contains(" ") Then sTagName = sLeft(sTag, sTagName.IndexOf(" "))
                    Select Case sTagName
                        Case "c"
                            Chunks(iChunk) = "<font color=""#" & Hex(GetInputColour.ToArgb).Substring(2) & """>"
                        Case "/c"
                            Chunks(iChunk) = "</font>"
                        Case "del"
                            If iChunk > 0 AndAlso Chunks(iChunk - 1).Length > 0 Then
                                Chunks(iChunk - 1) = Chunks(iChunk - 1).Substring(0, Chunks(iChunk - 1).Length - 1)
                            Else
                                If txtOutputWeb.InnerHtml.EndsWith("<br>") Then txtOutputWeb.InnerHtml = txtOutputWeb.InnerHtml.Substring(0, txtOutputWeb.InnerHtml.Length - 4)
                            End If
                            Chunks(iChunk) = ""
                        Case "font"
                            Dim fontPrevious As Font
                            Dim colourPrevious As String
                            Dim i As Integer

                            If UserSession.stackFonts.Count > 0 Then
                                fontPrevious = UserSession.stackFonts.Peek
                            Else
                                fontPrevious = Adventure.DefaultFont
                            End If
                            If UserSession.stackColours.Count > 0 Then
                                colourPrevious = UserSession.stackColours.Peek
                            Else
                                colourPrevious = System.Drawing.ColorTranslator.ToHtml(GetOutputColour)
                            End If

                            sTag = sTag.Replace("= ", "=").Replace(" =", "=")

                            Dim sFace As String = fontPrevious.FontFamily.Name
                            i = sInstr(sTag, "face=")
                            If i > 0 Then
                                Dim sBuffer As String = sMid(sTag, i + 5, sTag.Length - i - 4)
                                If Left(sBuffer, 1) = Chr(34) Then
                                    sBuffer = sMid(sBuffer, 2, sInstr(2, sBuffer, Chr(34)) - 2)
                                Else
                                    If sInstr(1, sBuffer, " ") > 0 Then sBuffer = Left(sBuffer, sInstr(1, sBuffer, " "))
                                End If

                                sFace = sBuffer
                            End If

                            Dim iSize As Integer = fontPrevious.SizeInPoints
                            i = sInstr(sTag, "size=")
                            If i > 0 Then
                                Dim sBuffer As String = sMid(sTag, i + 5, sTag.Length - i - 4)
                                If Left(sBuffer, 1) = Chr(34) Then
                                    sBuffer = sMid(sBuffer, 2, sInstr(2, sBuffer, Chr(34)) - 2)
                                Else
                                    If sInstr(1, sBuffer, " ") > 0 Then sBuffer = Left(sBuffer, sInstr(1, sBuffer, " "))
                                End If

                                If Not (sBuffer.Contains("-") OrElse sBuffer.Contains("+")) Then
                                    iSize = SafeInt(sBuffer)
                                ElseIf CSng(sBuffer) < 0 Then
                                    Dim iOffset As Integer = SafeInt(sBuffer)
                                    iSize += iOffset
                                ElseIf Left(sBuffer, 1) = "+" Then
                                    Dim iOffset As Integer = SafeInt(sBuffer.Substring(1))
                                    iSize += iOffset
                                End If
                            End If

                            i = sInstr(sTag, "color=")
                            Dim sColour As String = colourPrevious
                            If i > 0 Then
                                Dim sBuffer As String = sMid(sTag, i + 6, sTag.Length - i - 5)
                                If sInstr(sBuffer, " ") > 0 Then sBuffer = Left(sBuffer, sInstr(sBuffer, " ") - 1)
                                If Right(sBuffer, 1) = Chr(34) AndAlso Left(sBuffer, 1) = Chr(34) Then sBuffer = sMid(sBuffer, 2, sBuffer.Length - 2)
                                sBuffer = ColourLookup(sBuffer)

                                If Not sBuffer.StartsWith("#") Then sBuffer = "#" & sBuffer
                                'sNewTag &= " color=""" & sBuffer & """"
                                'NewColour = Color.FromArgb(rr, gg, bb)
                                sColour = sBuffer
                            End If
                            If Not sColour.StartsWith("#") Then sColour = "#" & sColour

                            Dim newfont As New Font(sFace, iSize, GraphicsUnit.Point)

                            Dim bColour As Boolean = sColour <> colourPrevious
                            Dim bFace As Boolean = newfont.FontFamily.Name <> fontPrevious.FontFamily.Name
                            Dim bSize As Boolean = newfont.SizeInPoints <> fontPrevious.SizeInPoints

                            UserSession.stackFonts.Push(newfont)
                            UserSession.stackColours.Push(sColour)

                            Dim sFontColour As String = ""
                            If bColour Then sFontColour = " color=""" & sColour & """"
                            Dim sStyle As String = ""
                            If bFace OrElse bSize Then
                                sStyle = " style="""
                                If bFace Then sStyle &= "font-family:" & newfont.FontFamily.Name & ";"
                                If bSize Then sStyle &= "font-size:" & newfont.SizeInPoints & "pt;"
                                sStyle &= """"
                            End If
                            Chunks(iChunk) = "<font" & sFontColour & sStyle & ">"

                        Case "/font"
                            If UserSession.stackFonts.Count > 0 Then UserSession.stackFonts.Pop()
                            If UserSession.stackColours.Count > 0 Then UserSession.stackColours.Pop()
                            Chunks(iChunk) = "</font>"

                        Case "img", "/img"
                            Chunks(iChunk) = ""

                            Dim i As Integer

                            i = sInstr(sTag, " src=")
                            If i > 0 Then
                                Dim sBuffer As String = sMid(sTag, i + 5, sTag.Length - i - 4)
                                If sBuffer.StartsWith("""") Then sBuffer = sBuffer.Substring(1)
                                If sBuffer.EndsWith("""") Then sBuffer = sBuffer.Substring(0, sBuffer.Length - 1)
                                sBuffer = Trim(sBuffer)

                                Dim bVisible As Boolean = False

                                Try
                                    If UserSession.bGraphics Then
                                        ' First ensure Img directory exists
                                        If Not IO.Directory.Exists(Server.MapPath("/img")) Then
                                            IO.Directory.CreateDirectory(Server.MapPath("/img"))
                                            IO.File.Create(Server.MapPath("/img") & "/index.htm")
                                        End If
                                        ' Then ensure IFID directory exists
                                        If Not IO.Directory.Exists(Server.MapPath("/img/" & Adventure.BabelTreatyInfo.Stories(0).Identification.IFID)) Then
                                            IO.Directory.CreateDirectory(Server.MapPath("/img/" & Adventure.BabelTreatyInfo.Stories(0).Identification.IFID))
                                            IO.File.Create(Server.MapPath("/img/" & Adventure.BabelTreatyInfo.Stories(0).Identification.IFID) & "/index.htm")
                                        End If

                                        Dim sImgPath As String = "/img/" & Adventure.BabelTreatyInfo.Stories(0).Identification.IFID
                                        ' Then check to see if image file exists

                                        If Adventure.BlorbMappings IsNot Nothing AndAlso Adventure.BlorbMappings.Count > 0 Then
                                            Dim iResource As Integer = 0
                                            If Adventure.BlorbMappings.ContainsKey(sBuffer) Then iResource = Adventure.BlorbMappings(sBuffer)
                                            If iResource > 0 Then                                                
                                                Dim sURL As String = ""
                                                Dim sProperties As String = ""
                                                For Each sExtn As String In New String() {"jpg", "png", "gif"}
                                                    If IO.File.Exists(Server.MapPath(sImgPath) & "/Image" & iResource & "." & sExtn) Then
                                                        sURL = sImgPath & "/Image" & iResource & "." & sExtn
                                                        Dim img As System.Drawing.Image = Blorb.GetImage(iResource)
                                                        sProperties = " Height = " & img.Height & " Width = " & img.Width
                                                        Exit For
                                                    End If
                                                Next
                                                If sURL = "" Then
                                                    Dim sExtn As String = ""
                                                    Dim img As System.Drawing.Image = Blorb.GetImage(iResource, , sExtn)
                                                    img.Save(Server.MapPath(sImgPath) & "/Image" & iResource & "." & sExtn)
                                                    sProperties = " Height = " & img.Height & " Width = " & img.Width                                                   
                                                    sURL = sImgPath & "/Image" & iResource & "." & sExtn
                                                End If
                                                Chunks(iChunk) = "<center><img src=""" & sURL & """" & sProperties & " /></center>"
                                            End If
                                        Else
                                            '    fRunner.pbxGraphics.Load(sBuffer)
                                        End If
                                    End If
                                Catch
                                End Try
                            End If                            

                        Case "audio", "/audio"
                            Chunks(iChunk) = ""

                            Try
                                If UserSession.bSound Then
                                    Dim i As Integer
                                    Dim iChannel As Integer = 1
                                    Dim bLooping As Boolean = False
                                    Dim sSrc As String = ""
                                    Dim sBuffer As String

                                    i = sInstr(sTag, "channel=")
                                    If i > 0 Then
                                        sBuffer = sMid(sTag, i + 8, sTag.Length - i - 8)
                                        If Left(sBuffer, 1) = Chr(34) Then
                                            sBuffer = sMid(sBuffer, 2, sInstr(2, sBuffer, Chr(34)) - 2)
                                        Else
                                            If sInstr(1, sBuffer, " ") > 0 Then sBuffer = Left(sBuffer, sInstr(1, sBuffer, " "))
                                        End If
                                        iChannel = SafeInt(sBuffer)
                                    End If

                                    i = sInstr(sTag, " src=")
                                    If i > 0 Then
                                        sBuffer = sMid(sTag, i + 5, sTag.Length - i - 4)
                                        If Left(sBuffer, 1) = Chr(34) Then
                                            sSrc = sMid(sBuffer, 2, sInstr(2, sBuffer, Chr(34)) - 2)
                                        Else
                                            If sInstr(1, sBuffer, " ") > 0 Then sSrc = Left(sBuffer, sInstr(1, sBuffer, " "))
                                        End If
                                    End If

                                    i = sInstr(sTag, " loop=")
                                    If i > 0 Then
                                        sBuffer = sMid(sTag, i + 6, sTag.Length - i - 6)
                                        If Left(sBuffer, 1) = Chr(34) Then sBuffer = sMid(sBuffer, 2, sInstr(2, sBuffer, Chr(34)) - 2)
                                        Select Case sBuffer
                                            Case "Y", "y", "1", "True", "true", "TRUE"
                                                bLooping = True
                                        End Select
                                    End If

                                    ' TODO - We actually need an UpdatePanel per channel...
                                    Dim Channel As HtmlGenericControl = Nothing
                                    Select Case iChannel
                                        Case 1
                                            Channel = Channel1
                                        Case 2
                                            Channel = Channel2
                                        Case 3
                                            Channel = Channel3
                                        Case 4
                                            Channel = Channel4
                                        Case 5
                                            Channel = Channel5
                                        Case 6
                                            Channel = Channel6
                                        Case 7
                                            Channel = Channel7
                                        Case 8
                                            Channel = Channel8
                                    End Select

                                    If Channel IsNot Nothing Then
                                        If sTag.Contains(" pause") Then
                                            Channel.InnerHtml = ""
                                            UpdatePanelAudioChannels.Update()
                                        ElseIf sTag.Contains(" stop") Then
                                            Channel.InnerHtml = ""
                                            UpdatePanelAudioChannels.Update()
                                        Else
                                            ' First ensure Img directory exists
                                            If Not IO.Directory.Exists(Server.MapPath("/img")) Then
                                                IO.Directory.CreateDirectory(Server.MapPath("/img"))
                                                IO.File.Create(Server.MapPath("/img") & "/index.htm")
                                            End If
                                            ' Then ensure IFID directory exists
                                            If Not IO.Directory.Exists(Server.MapPath("/img/" & Adventure.BabelTreatyInfo.Stories(0).Identification.IFID)) Then
                                                IO.Directory.CreateDirectory(Server.MapPath("/img/" & Adventure.BabelTreatyInfo.Stories(0).Identification.IFID))
                                                IO.File.Create(Server.MapPath("/img/" & Adventure.BabelTreatyInfo.Stories(0).Identification.IFID) & "/index.htm")
                                            End If

                                            Dim sImgPath As String = "/img/" & Adventure.BabelTreatyInfo.Stories(0).Identification.IFID

                                            If Adventure.BlorbMappings IsNot Nothing AndAlso Adventure.BlorbMappings.Count > 0 Then
                                                Dim iResource As Integer = 0
                                                If Adventure.BlorbMappings.ContainsKey(sSrc) Then iResource = Adventure.BlorbMappings(sSrc)
                                                If iResource > 0 Then
                                                    Dim sURL As String = ""
                                                    For Each sExtn As String In New String() {"mp3", "wav", "mid"}
                                                        If IO.File.Exists(Server.MapPath(sImgPath) & "/Sound" & iResource & "." & sExtn) Then
                                                            sURL = sImgPath & "/Sound" & iResource & "." & sExtn
                                                            Exit For
                                                        End If
                                                    Next
                                                    If sURL = "" Then
                                                        Dim sExtn As String = ""
                                                        Dim sound As ADRIFT.clsBlorb.SoundFile = Blorb.GetSound(iResource, , sExtn)
                                                        sound.Save(Server.MapPath(sImgPath) & "/Sound" & iResource & "." & sExtn)
                                                        sURL = sImgPath & "/Sound" & iResource & "." & sExtn
                                                    End If                                                    

                                                    'Channel.InnerHtml
                                                    Channel.InnerHtml = "<NOEMBED><BGSOUND SRC=""" & sURL & """ LOOP=" & IIf(bLooping, "1", "0").ToString & "></NOEMBED>" _
                                                   & "<EMBED SRC=""" & sURL & """ AUTOSTART=""True"" HIDDEN=""True"" LOOP=""" & bLooping.ToString.ToLower & """>"
                                                    UpdatePanelAudioChannels.Update()
                                                End If
                                            Else
                                                '    fRunner.pbxGraphics.Load(sBuffer)
                                            End If

                                           
                                            'PlaySound(sSrc, iChannel, bLooping)
                                        End If
                                    End If
                                End If
                            Catch
                            End Try

                    End Select
                End If
            End With
        Next

        sSource = ""
        For Each sChunk As String In Chunks
            sSource &= sChunk
        Next

        If txtOutputWeb IsNot Nothing Then
            txtOutputWeb.InnerHtml &= sSource
        ElseIf txtOutputWebAbout IsNot Nothing Then
            txtOutputWebAbout.InnerHtml &= sSource
        End If

    End Sub



    Private Property WaitKeyBuffer As String
        Get
            Return HttpContext.Current.Session.Item("WaitKeyBuffer")
        End Get
        Set(value As String)
            HttpContext.Current.Session.Item("WaitKeyBuffer") = value
        End Set
    End Property


    Public Property Locked() As Boolean
        Get
            Return SafeBool(HttpContext.Current.Session.Item("Locked"))
        End Get
        Set(ByVal value As Boolean)
            HttpContext.Current.Session.Item("Locked") = value
        End Set
    End Property

    Public Sub WaitKey()
        Locked = True
    End Sub

    Public Sub Close()

    End Sub

    Public Sub SetTitle(ByVal sText As String)
        'CType(Page.Master, Site).txtHeader.InnerHtml = "<h1 style=""margin:0px;font-variant:small-caps;font-size:20px;font-family:Arial,sans-serif;font-weight:200;"">" & sText & "</h1>"
        Page.Header.Title = sText
    End Sub
    'Private Sub StatusBar_TextChanged(sender As Object, e As System.EventArgs) Handles StatusBar.TextChanged

    'End Sub

    Public Sub UpdateStatusBar(sDescription As String, ByVal sScore As String, ByVal sUserStatus As String)
        txtStatusBar.InnerHtml = sDescription
        txtScore.InnerHtml = sScore
        txtUserStatus.InnerHtml = ReplaceALRs(sUserStatus)
        UpdatePanelStatusBar.Update()
    End Sub


    Private Sub WebSplitter1_SplitterPaneSizeChanged(sender As Object, e As Infragistics.Web.UI.LayoutControls.SplitterPaneSizeChangedEventArgs) Handles WebSplitter1.SplitterPaneSizeChanged
        Debug.WriteLine(e.Pane.Size)
        MapWidth = WebSplitter1.Panes(1).Size.Value
    End Sub

    Public Sub RefreshMap()
        ' Required for IE, Firefox or Safari (not Chrome), so it thinks it's a unique image
        MapImage.ImageUrl = "~/MapHandler.ashx?" & New Random().Next

        UpdatePanelMap.Update()
    End Sub

End Class
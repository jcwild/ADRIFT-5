Module SharedModule

#If www Then
    Public Property Adventure As clsAdventure
        Get
            Return HttpContext.Current.Session.Item("Adventure")
        End Get
        Set(value As clsAdventure)
            HttpContext.Current.Session.Item("Adventure") = value
        End Set
    End Property
#Else
    Public Property Adventure As clsAdventure
#End If
   
    Public Blorb As clsBlorb
    Public iLoading As Integer
    'Public bGenerator As Boolean
    Public dVersion As Double = 5.0
    Public Const ANYOBJECT As String = "AnyObject"
    Public Const ANYCHARACTER As String = "AnyCharacter"
    Public Const ANYDIRECTION As String = "AnyDirection"
    Public Const NOOBJECT As String = "NoObject"
    Public Const NOCHARACTER As String = "NoCharacter"
    'Public Const ALLHELDOBJECTS As String = "AllHeldObjects"
    'Public Const ALLWORNOBJECTS As String = "AllWornObjects"
    Public Const ALLROOMS As String = "AllLocations"
    Public Const NOROOMS As String = "NoLocations"
    Public Const THEFLOOR As String = "TheFloor"
    Public Const THEPLAYER As String = "%Player%"
    Public Const CHARACTERPROPERNAME As String = "CharacterProperName"
    Public Const PLAYERLOCATION As String = "PlayerLocation"
    Public Const HIDDEN As String = "Hidden"

    Public Const DEFAULT_BACKGROUNDCOLOUR As Integer = -16777216 ' Color.Black.ToArgb
    Public Const DEFAULT_INPUTCOLOUR As Integer = -3005145 ' = Color.FromArgb(210, 37, 39)
    Public Const DEFAULT_OUTPUTCOLOUR As Integer = -15096438 ' Color = Color.FromArgb(25, 165, 138)
    Public Const DEFAULT_LINKCOLOUR As Integer = -11806788 ' = Color.FromArgb(75, 215, 188)

    ' Mandatory properties
    Public Const SHORTLOCATIONDESCRIPTION As String = "ShortLocationDescription"
    Public Const LONGLOCATIONDESCRIPTION As String = "LongLocationDescription"
    Public Const OBJECTARTICLE As String = "_ObjectArticle"
    Public Const OBJECTPREFIX As String = "_ObjectPrefix"
    Public Const OBJECTNOUN As String = "_ObjectNoun"


    Public Const sLOCATION As String = "Location"
    Public Const sOBJECT As String = "Object"
    Public Const sTASK As String = "Task"
    Public Const sEVENT As String = "Event"
    Public Const sCHARACTER As String = "Character"
    Public Const sGROUP As String = "Group"
    Public Const sVARIABLE As String = "Variable"
    Public Const sPROPERTY As String = "Property"
    Public Const sHINT As String = "Hint"
    Public Const sALR As String = "Text Override"
    Public Const sGENERAL As String = "General"
    Public Const sSELECTED As String = "<Selected>"
    Public Const sUNSELECTED As String = "<Unselected>"

    'Public sLocalDataPath As String
    'Public colInput As Color = Color.FromArgb(210, 37, 39)
    'Public colOutput As Color = Color.FromArgb(25, 165, 138)
    'Public colLink As Color = Color.FromArgb(75, 215, 188)

    Public iImageSizeMode As Integer ' SizeModeEnum =  generator.c SizeModeEnum.ActualSizeCentred

    'Private Declare Auto Function AddFontMemResourceEx Lib "Gdi32.dll" (ByVal pbFont As IntPtr, ByVal cbFont As Integer, ByVal pdv As Integer, ByRef pcFonts As Integer) As IntPtr
    Friend pfc As System.Drawing.Text.PrivateFontCollection = Nothing

    Public Enum PerspectiveEnum
        None = 0
        FirstPerson = 1     ' I/Me/Myself
        SecondPerson = 2    ' You/Yourself
        ThirdPerson = 3     ' He/She/Him/Her
        ' It
        ' We
        ' They
    End Enum


    Public Enum ReferencesType
        [Object]
        Character
        Number
        Text
        Direction
        Location
        Item
    End Enum


    Friend Enum ArticleTypeEnum
        Definite ' The
        Indefinite ' A
        None
    End Enum

#Region "Microsoft.VisualBasic compatability"

    Public Function Asc(ByVal c As Char) As Integer
        Return Convert.ToInt32(c)
    End Function
    Public Function Asc(ByVal s As String) As Integer
        'If System.Text.Encoding.Default.GetBytes(s(0))(0) <> Microsoft.VisualBasic.Asc(s) Then
        '    Return Microsoft.VisualBasic.Asc(s)
        'Else
        Return System.Text.Encoding.Default.GetBytes(s(0))(0) 'Convert.ToInt32(CChar(s))
        'End If
    End Function

#If False Then
    Public Enum MsgBoxStyle
        OkOnly = 0
        OkCancel = 1
        YesNoCancel = 3
        YesNo = 4
        Question = 32
        Exclamation = 48
    End Enum
    Public Enum MsgBoxResult
        Ok = 1
        Cancel = 2
        Abort = 3
        Yes = 6
        No = 7
    End Enum

    Public Function Chr(ByVal i As Integer) As Char
        Return Convert.ToChar(i)
    End Function

    Public Function ChrW(ByVal i As Integer) As Char
        Return Convert.ToChar(i)
    End Function

    Public Function Dir() As String
        TODO()
    End Function

    Public Function FileLen(ByVal PathName As String) As Long
        TODO()
    End Function

    Public Function Format(Expression As Object, Optional Stye As String = "") As String
        TODO()
    End Function

    Public Function GetSetting(AppName As String, Section As String, Key As String, Optional [Default] As String = "") As String
        TODO()
    End Function

    Public Function Hex(Number As Integer) As String
        TODO()
    End Function

    Public Function IIf(ByVal bTest As Boolean, ByVal oTrue As Object, ByVal oFalse As Object) As Object
        If bTest Then
            Return oTrue
        Else
            Return oFalse
        End If
    End Function

    Public Function InputBox(Prompt As String, Optional Title As String = "", Optional DefaultResponse As String = "") As String
        TODO()
    End Function

    Public Enum CompareMethod
        Binary = 0
        Text = 1
    End Enum
    Public Function Instr(ByVal sText As String, ByVal sSearchFor As String, Optional Compare As CompareMethod = CompareMethod.Binary) As Integer
        TODO() 'Return sInstr(sText, sSearchFor)        
    End Function

    Public Function Int(Number As Object) As Integer
        TODO()
    End Function

    Public Function IsDate(Expression As Object) As Boolean
        TODO()
    End Function

    Public Function IsDBNull(Expression As Object) As Boolean
        TODO()
    End Function

    Public Function IsNumeric(Expression As Object) As Boolean
        TODO()
    End Function

    Public Function LCase(ByVal s As String) As String
        Return s.ToLower
    End Function

    Public Function Left(ByVal sString As String, ByVal iLength As Integer) As String
        Return sLeft(sString, iLength)
    End Function

    Public Function Len(ByVal sString As String) As Integer
        If sString Is Nothing Then Return 0
        Return sString.Length
    End Function

    Public Function Mid(ByVal sString As String, ByVal iStart As Integer) As String
        Return sMid(sString, iStart)
    End Function

    Public Function Mid(ByVal sString As String, ByVal iStart As Integer, ByVal iLength As Integer) As String
        Return sMid(sString, iStart, iLength)
    End Function

    Public Function MsgBox(ByVal Prompt As String) As DialogResult
        Return MessageBox.Show(Prompt, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Function
    Public Function MsgBox(ByVal Prompt As String, ByVal Buttons As MsgBoxStyle) As MsgBoxResult
        TODO() ' Return MessageBox.Show(Prompt, Application.ProductName, MessageBoxButtons.OK)
    End Function
    Public Function MsgBox(ByVal Prompt As String, ByVal Buttons As MsgBoxStyle, ByVal Title As String) As MsgBoxResult
        TODO() ' Return MessageBox.Show(Prompt, Title, MessageBoxButtons.OK)
    End Function

    Public Function Now() As Date
        Return Date.Now
    End Function

    Public Sub Randomize(Number As Double)
        TODO()
    End Sub
    Public Function Replace(Expression As String, Find As String, Replacement As String, Optional Start As Integer = 1, Optional Count As Integer = -1) As String
        TODO()
    End Function
    Public Function Right(ByVal sString As String, ByVal iLength As Integer) As String
        Return sRight(sString, iLength)
    End Function

    Public Function Rnd() As Integer
        TODO()
    End Function
    Public Function Rnd(Number As Single) As Single
        TODO()
    End Function

    Public Sub SaveSetting(AppName As String, Section As String, Key As String, Setting As String)
        TODO()
    End Sub

    Public Function Space(Number As Integer) As String
        TODO()
    End Function

    Public Function Split(Expression As String, Optional Delimiter As String = "", Optional Limit As Integer = -1) As String()
        TODO()
    End Function

    Public Function Str(Number As Object) As String
        TODO()
    End Function

    Public Function UCase(ByVal s As String) As String
        Return s.ToUpper
    End Function

    Public Function Val(Expression As Object) As Double

    End Function

    Public ReadOnly Property vbCrLf As String
        Get
            Return Environment.NewLine
        End Get
    End Property

    Public ReadOnly Property vbLf As Char
        Get
            Return Convert.ToChar(10)
        End Get
    End Property

#End If
#End Region

#If Not (Mono Or www) Then
    Public Function DarkInterface() As Boolean

        Select Case eStyle
            Case Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007
                Return eColour2007 = Infragistics.Win.Office2007ColorScheme.Black
            Case Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2010
                Return False ' All light
            Case Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2013
                Return False ' All light
        End Select
        Return False

    End Function
#End If


    Public ReadOnly Property BinPath(Optional ByVal bSeparatorCharacter As Boolean = False) As String
        Get
#If www Then
            Return IO.Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data") & IO.Path.DirectorySeparatorChar
#Else
            Return Application.StartupPath & If(bSeparatorCharacter, IO.Path.DirectorySeparatorChar, "").ToString
            'Dim sPath As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & IO.Path.DirectorySeparatorChar & "ADRIFT"
            'If Not IO.Directory.Exists(sPath) Then IO.Directory.CreateDirectory(sPath)
            'Return sPath ' & IO.Path.DirectorySeparatorChar
#End If
        End Get
    End Property
    Public ReadOnly Property DataPath(Optional ByVal bSeparatorCharacter As Boolean = False) As String
        Get
#If www Then
            Return IO.Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data") & IO.Path.DirectorySeparatorChar
#Else
            'Return Application.StartupPath & IO.Path.DirectorySeparatorChar
            Dim sPath As String
            If Application.LocalUserAppDataPath IsNot Nothing Then
                sPath = Application.LocalUserAppDataPath.Substring(0, Application.LocalUserAppDataPath.IndexOf("\ADRIFT")) & "\ADRIFT" '& IO.Path.DirectorySeparatorChar
            Else
                sPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & IO.Path.DirectorySeparatorChar & "ADRIFT"
            End If

            If Not IO.Directory.Exists(sPath) Then IO.Directory.CreateDirectory(sPath)
            Return sPath & If(bSeparatorCharacter, IO.Path.DirectorySeparatorChar, "").ToString
#End If
        End Get
    End Property


    Public Sub TidyUp()
        TidyUpSounds()
    End Sub


    Public Function GetFontCollection() As Drawing.Text.PrivateFontCollection

        Dim _pfc As Drawing.Text.PrivateFontCollection = Nothing
        'Public Function GetFont() As Drawing.Text.PrivateFontCollection

        'Dim pfc As New System.Drawing.Text.PrivateFontCollection

        Try
            If _pfc Is Nothing Then
                Dim sFont As String = Application.StartupPath & IO.Path.DirectorySeparatorChar & "LYDIAN.TTF"

                _pfc = New Drawing.Text.PrivateFontCollection

                If IO.File.Exists(sFont) AndAlso False Then
                    _pfc.AddFontFile(sFont)
                Else

                    Dim bytLydian As Byte() = My.Resources.Lydian
                    Dim gch As Runtime.InteropServices.GCHandle = Runtime.InteropServices.GCHandle.Alloc(bytLydian, Runtime.InteropServices.GCHandleType.Pinned)
                    _pfc.AddMemoryFont(gch.AddrOfPinnedObject, bytLydian.Length)
                    gch.Free()

                    'Dim FntPtr As IntPtr = Runtime.InteropServices.Marshal.AllocHGlobal(Runtime.InteropServices.Marshal.SizeOf(GetType(Byte)) * bytLydian.Length) ' ByteStrm.Length)
                    'Dim ptrMem As IntPtr = Runtime.InteropServices.Marshal.AllocCoTaskMem(bytLydian.Length)

                    ''Copy the byte array holding the font into the allocated memory.
                    'Runtime.InteropServices.Marshal.Copy(bytLydian, 0, ptrMem, bytLydian.Length)

                    ''Add the font to the PrivateFontCollection            
                    ''FntFC.AddMemoryFont(FntPtr, bytLydian.Length)
                    '_pfc.AddMemoryFont(ptrMem, bytLydian.Length)

                    'Dim pcFonts As Int32
                    'pcFonts = 1
                    'AddFontMemResourceEx(ptrMem, bytLydian.Length, 0, pcFonts)

                    ''Free the memory
                    ''Runtime.InteropServices.Marshal.FreeHGlobal(FntPtr)
                    'Runtime.InteropServices.Marshal.FreeCoTaskMem(ptrMem)
                    'Next
                End If
            End If

        Catch ex As Exception
            ErrMsg("Error extracting font", ex)
        End Try

        Return _pfc

    End Function

    'Public Function GetFont() As Drawing.Text.PrivateFontCollection
    '    'Get the namespace of the application    
    '    'Dim NameSpc As String = Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString()
    '    'Dim FntStrm As IO.Stream
    '    Dim FntFC As New Drawing.Text.PrivateFontCollection()
    '    Try
    '        'Dim i As Integer
    '        'For i = 0 To FontResource.GetUpperBound(0)
    '        'Get the resource stream area where the font is located
    '        'FntStrm = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ADRIFT." + FontResource(i))            
    '        'Load the font off the stream into a byte array
    '        'Dim ByteStrm(CType(FntStrm.Length, Integer)) As Byte
    '        'FntStrm.Read(ByteStrm, 0, Int(CType(FntStrm.Length, Integer)))
    '        'Allocate some memory on the global heap
    '        Dim bytLydian As Byte() = My.Resources.Lydian
    '        Dim FntPtr As IntPtr = Runtime.InteropServices.Marshal.AllocHGlobal(Runtime.InteropServices.Marshal.SizeOf(GetType(Byte)) * bytLydian.Length) ' ByteStrm.Length)
    '        'Copy the byte array holding the font into the allocated memory.
    '        Runtime.InteropServices.Marshal.Copy(bytLydian, 0, FntPtr, bytLydian.Length)
    '        'Add the font to the PrivateFontCollection
    '        FntFC.AddMemoryFont(FntPtr, bytLydian.Length)
    '        Dim pcFonts As Int32
    '        pcFonts = 1
    '        '            AddFontMemResourceEx(FntPtr, bytLydian.Length, 0, pcFonts)
    '        'Free the memory
    '        Runtime.InteropServices.Marshal.FreeHGlobal(FntPtr)
    '        'Next
    '    Catch ex As Exception
    '        ErrMsg("Error extracting font", ex)
    '    End Try
    '    Return FntFC
    'End Function


    'Public Sub Rnd(ByVal a As String)
    '    ' Don't use this...
    'End Sub    
    Private r As Random
    Public Function Random(ByVal iMax As Integer) As Integer
        If r Is Nothing Then r = New Random(GetNextSeed)
        'Dim r As New Random(GetNextSeed)
        Return r.Next(iMax + 1)
    End Function
    Public Function Random(ByVal iMin As Integer, ByVal iMax As Integer) As Integer
        If r Is Nothing Then r = New Random(GetNextSeed)
        'Dim r As New Random(GetNextSeed)
        If iMax < iMin Then
            Dim i As Integer = iMax
            iMax = iMin
            iMin = i
        End If
        Return r.Next(iMin, iMax + 1)
    End Function

    Private Function GetNextSeed() As Integer
        Static iLastSeed As Integer = 0

        Dim iNextSeed As Integer = CInt(Now.Ticks Mod Integer.MaxValue)
        While iNextSeed = iLastSeed
            iNextSeed -= Now.Millisecond
        End While
        iLastSeed = iNextSeed

        Return iNextSeed

    End Function


    Public Enum DirectionsEnum
        North = 0
        East = 1
        South = 2
        West = 3
        Up = 4
        Down = 5
        [In] = 6
        Out = 7
        NorthEast = 8
        SouthEast = 9
        SouthWest = 10
        NorthWest = 11
    End Enum


    Public Enum ItemEnum
        Location
        [Object]
        Task
        [Event]
        Character
        Group
        Variable
        [Property]
        Hint
        ALR
        General
    End Enum


    Public Sub GlobalStartup()
        'If Not Application.LocalUserAppDataPath Is Nothing Then
        '    sLocalDataPath = Application.LocalUserAppDataPath.Substring(0, Application.LocalUserAppDataPath.IndexOf("ADRIFT")) & "ADRIFT" & IO.Path.DirectorySeparatorChar
        'End If

#If www Then
        Dim version As Version = system.Reflection.Assembly.GetCallingAssembly.GetName.Version
#Else
        Dim version As Version = New Version(Application.ProductVersion)
#End If
        dVersion = CDbl(version.Major & System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator & Format(version.Minor, "000") & Format(version.Build, "000") & Format(version.Revision))
    End Sub


    Friend Function IsHex(ByVal sHex As String) As Boolean
        For i As Integer = 0 To sHex.Length - 1
            If "0123456789ABCDEF".IndexOf(sHex(i)) = -1 Then Return False
        Next
        Return True
    End Function


    Public Function ItemToString(ByVal item As ItemEnum, Optional ByVal bPlural As Boolean = False) As String

        ItemToString = ""

        Select Case item
            Case ItemEnum.Location
                ItemToString = sLOCATION
            Case ItemEnum.Object
                ItemToString = sOBJECT
            Case ItemEnum.Task
                ItemToString = sTASK
            Case ItemEnum.Event
                ItemToString = sEVENT
            Case ItemEnum.Character
                ItemToString = sCHARACTER
            Case ItemEnum.Group
                ItemToString = sGROUP
            Case ItemEnum.Variable
                ItemToString = sVARIABLE
            Case ItemEnum.Property
                ItemToString = sPROPERTY
            Case ItemEnum.Hint
                ItemToString = sHINT
            Case ItemEnum.ALR
                ItemToString = sALR
            Case ItemEnum.General
                ItemToString = sGENERAL
        End Select

        If bPlural Then
            Select Case item
                Case ItemEnum.Location, ItemEnum.Object, ItemEnum.Task, ItemEnum.Event, ItemEnum.Character, ItemEnum.Group, ItemEnum.Variable, ItemEnum.Hint, ItemEnum.ALR, ItemEnum.General
                    Return ItemToString & "s"
                Case ItemEnum.Property
                    Return "Properties"
            End Select
        End If

    End Function


    Private WithEvents WebClient As New System.Net.WebClient
    Public Sub CheckForUpdate(Optional ByVal bAtStart As Boolean = True)

        ' Try to download from http://www.adrift.co/cgi/versioncheck.cgi?from=5.0.26.1&atstart=0

        ' <?xml>
        '   <versioncheck>
        '     <currentversion>5.0.26.1</currentversion>
        '     <change type="enhancement" item="1234" title="Blah">Blah blah</change>
        '     <change type="bug" item="2345" title="Oops">La de dah</change>
        '   </versioncheck>        

#If DEBUG Then
        Exit Sub
#End If

        'Dim URI As New System.Uri("http://www.adrift.co/cgi/versioncheck.cgi?from=" & Application.ProductVersion & If(bAtStart, "", "&atstart=0").ToString)
        'Dim URI As New System.Uri("http://www.adrift.co/cgi/versioncheck.cgi?from=5.0.0.0" & If(bAtStart, "", "&atstart=0").ToString)

        WebClient.DownloadStringAsync(New System.Uri("http://www.adrift.co/cgi/versioncheck.cgi?from=" & Application.ProductVersion & If(bAtStart, "", "&atstart=0").ToString))

    End Sub

#If Not www Then
    Private Sub WebClient_DownloadStringCompleted(sender As Object, e As System.Net.DownloadStringCompletedEventArgs) Handles WebClient.DownloadStringCompleted

        Try
            If e.Error IsNot Nothing Then Exit Sub

            Dim xmlVersion As New Xml.XmlDocument
            Dim sXML As String = e.Result.Replace("&eacute;", "E").Replace("&agrave;", "A").Replace("&aelig;", "ae").Replace("&raquo;", "&gt;")
            xmlVersion.LoadXml(sXML)
            Dim sOldVersion As String = Application.ProductVersion
            Dim sNewVersion As String = ""

            With xmlVersion.Item("versioncheck")
                Dim bUpdate As Boolean = False

                If .Item("currentversion") IsNot Nothing Then
                    sNewVersion = .Item("currentversion").InnerText
                    If sOldVersion <> sNewVersion Then
                        Dim OldVersion() As String = sOldVersion.Split("."c)
                        Dim NewVersion() As String = sNewVersion.Split("."c)

                        For i As Integer = 0 To 3
                            Dim iOld As Integer = 0
                            Dim iNew As Integer = 0
                            If OldVersion.Length > i Then iOld = SafeInt(OldVersion(i))
                            If NewVersion.Length > i Then iNew = SafeInt(NewVersion(i))

                            If iOld < iNew Then
                                bUpdate = True
                                Exit For
                            ElseIf iOld > iNew Then
                                Exit Sub ' We are apparently newer than the published version
                            End If
                        Next
                    End If
                End If

                If Not bUpdate Then Exit Sub

#If Generator Then
                Dim ync As New frmYesNoCancel
                ync.Text = "ADRIFT Update"
                ync.lblText.Text = "There is a new version of ADRIFT available.  Would you like to download this now?"
                ync.btnCancel.Text = "Details"
                ync.CancelButton = ync.btnNo
                Dim sDialogResult As String = GetSetting("ADRIFT", "Shared", "DownloadUpdates", "")
                If sDialogResult = "" Then sDialogResult = CInt(ync.ShowDialog()).ToString

                Select Case CType(sDialogResult, DialogResult)
                    Case DialogResult.Yes
                        DownloadUpdate()
                    Case DialogResult.No, DialogResult.Cancel
                        ' Do nothing
                    Case DialogResult.Ignore ' About
                        Dim sEnhancements As String = ""
                        Dim sBugs As String = ""
                        For Each nodChange As Xml.XmlElement In xmlVersion.SelectNodes("/versioncheck/change")
                            Dim iItem As Integer = 0
                            If nodChange.HasAttribute("item") Then iItem = SafeInt(nodChange.GetAttribute("item"))
                            Dim sTitle As String = ""
                            If nodChange.HasAttribute("title") Then sTitle = nodChange.GetAttribute("title")
                            Dim sChange As String = sTitle & " [#" & iItem & "]"
                            If nodChange.HasAttribute("type") Then
                                Select Case nodChange.GetAttribute("type")
                                    Case "enhancement"
                                        sEnhancements &= sChange & vbCrLf
                                    Case "bug"
                                        sBugs &= sChange & vbCrLf
                                End Select
                            End If
                        Next

                        Dim frmWhatsNew As New WhatsNew
                        With frmWhatsNew
                            .txtWhatsNew.SelectionFont = New Font("Arial", 12, FontStyle.Bold)
                            .txtWhatsNew.SelectedText = "Changes between " & sOldVersion & " and " & sNewVersion & vbCrLf & vbCrLf
                            If sEnhancements <> "" Then
                                .txtWhatsNew.SelectionFont = New Font("Arial", 14, FontStyle.Bold)
                                .txtWhatsNew.SelectedText = "Enhancements" & vbCrLf
                                .txtWhatsNew.SelectionBullet = True
                                .txtWhatsNew.SelectionFont = New Font("Arial", 10, FontStyle.Regular)
                                .txtWhatsNew.SelectedText = sEnhancements
                                .txtWhatsNew.SelectionBullet = False
                            End If
                            If sBugs <> "" Then
                                .txtWhatsNew.SelectionFont = New Font("Arial", 14, FontStyle.Bold)
                                .txtWhatsNew.SelectedText = vbCrLf & "Bug Fixes" & vbCrLf
                                .txtWhatsNew.SelectionBullet = True
                                .txtWhatsNew.SelectionFont = New Font("Arial", 10, FontStyle.Regular)
                                .txtWhatsNew.SelectedText = sBugs
                                .txtWhatsNew.SelectionBullet = False
                            End If
                            .txtWhatsNew.SelectionStart = 0

                            If .ShowDialog = DialogResult.OK Then DownloadUpdate()
                        End With

                End Select

                If ync.chkRemember.Checked Then SaveSetting("ADRIFT", "Shared", "DownloadUpdates", sDialogResult)
#End If

            End With
        Catch ex As Exception
            ' Hmm, just ignore
        End Try

    End Sub
#End If

    Private Sub DownloadUpdate()
        Cursor.Current = Cursors.WaitCursor
        Process.Start("http://www.adrift.co/download")
        Cursor.Current = Cursors.Arrow
    End Sub


    Public Sub OpenAdventureDialog(ByVal ofd As System.Windows.Forms.OpenFileDialog)

        Try
            ofd.DefaultExt = "taf"
#If Runner Then
            ofd.Filter = "ADRIFT Text Adventures (*.taf; *.blorb)|*.taf; *.blorb|All Files (*.*)|*.*"
            If ofd.FileName.Length > 3 AndAlso Not ofd.FileName.ToLower.EndsWith("taf") AndAlso Not ofd.FileName.ToLower.EndsWith(".blorb") Then ofd.FileName = ""
#Else
            ofd.Filter = "ADRIFT Text Adventures (*.taf)|*.taf|All Files (*.*)|*.*"
            If ofd.FileName.Length > 3 AndAlso Not ofd.FileName.ToLower.EndsWith("taf") Then ofd.FileName = ""
#End If

            If ofd.ShowDialog() = DialogResult.OK Then
                If ofd.FileName <> "" Then
                    If IO.File.Exists(ofd.FileName) Then
#If Runner Then
                        UserSession.OpenAdventure(ofd.FileName)
#Else
                        OpenAdventure(ofd.FileName)
#End If

                    Else
                        ErrMsg("File not found!")
                    End If
                End If
            End If
        Catch ex As Exception
            ErrMsg("Error displaying Open File Dialog", ex)
        End Try

    End Sub


    Public Function IsRunningOnMono() As Boolean
        Return Type.GetType("Mono.Runtime") IsNot Nothing
    End Function

#If Not www Then
    Public Sub RemoveFileFromList(ByVal sFilename As String)

        If sFilename Is Nothing Then Exit Sub

        Dim lRecents As New List(Of String)
        Dim iRetrieve As Integer
        Dim sProject As String
#If Generator Then
        Dim UTMMain As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager = fGenerator.UTMMain
        sProject = "Generator"
#Else
#If Mono Then
#Else
        Dim UTMMain As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager = fRunner.UTMMain
#End If
        sProject = "Runner"
#End If

        For iPrevious As Integer = 1 To 20
            Dim sPrevious As String = GetSetting("ADRIFT", sProject, "Recent_" & iPrevious, "")
            'If sPrevious = sFilename Then DeleteSetting("ADRIFT", sProject, "Recent_" & iPrevious)            
            If sPrevious <> "" AndAlso sPrevious.ToLower <> sFilename.ToLower Then lRecents.Add(sPrevious)
        Next

        For Each sRecent As String In lRecents
            iRetrieve += 1
            SaveSetting("ADRIFT", sProject, "Recent_" & iRetrieve, sRecent)
        Next
        For iPrevious As Integer = iRetrieve + 1 To 20
            Try
                DeleteSetting("ADRIFT", sProject, "Recent_" & iPrevious)
            Catch
            End Try
        Next

#If Mono Then
        fRunner.miRecentAdventures.DropDownItems.Clear()
        AddPrevious()
#Else
        For m As Integer = UTMMain.Tools.Count - 1 To 0 Step -1
            If CStr(UTMMain.Tools(m).SharedProps.Tag) = "_RECENT_" Then
                UTMMain.Tools.RemoveAt(m)
            End If
        Next

        AddPrevious(UTMMain, sProject)
#End If

    End Sub


    Public Sub AddFileToList(ByVal sFilename As String)

        If sFilename Is Nothing Then Exit Sub

        Dim sRecents(19) As String
        Dim iRetrieve As Integer
        Dim sPrevious As String
        Dim sProject As String
#If Generator Then
        Dim UTMMain As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager = fGenerator.UTMMain
        sProject = "Generator"
#Else
#If Mono Then
#Else
        Dim UTMMain As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager = fRunner.UTMMain
#End If
        sProject = "Runner"
#End If

        For iPrevious As Integer = 1 To 20
            sPrevious = GetSetting("ADRIFT", sProject, "Recent_" & iPrevious, "")
            If sPrevious.ToUpper <> sFilename.ToUpper AndAlso iRetrieve < 19 Then
                iRetrieve += 1
                sRecents(iRetrieve) = sPrevious
            End If
        Next
        sRecents(0) = sFilename

        For iPrevious As Integer = 1 To 20
            SaveSetting("ADRIFT", sProject, "Recent_" & iPrevious, SafeString(sRecents(iPrevious - 1)))
        Next

#If Mono Then
        fRunner.miRecentAdventures.DropDownItems.Clear()
        AddPrevious()
#Else
        For m As Integer = UTMMain.Tools.Count - 1 To 0 Step -1
            If CStr(UTMMain.Tools(m).SharedProps.Tag) = "_RECENT_" Then
                UTMMain.Tools.RemoveAt(m)
            End If
        Next

        AddPrevious(UTMMain, sProject)
#End If

    End Sub
#End If


    Public Sub ErrMsg(ByVal sMessage As String, Optional ByVal ex As System.Exception = Nothing)

        Dim sErrorMsg As String = sMessage
        If Not ex Is Nothing Then sErrorMsg &= ": " & ex.Message

        If Not ex Is Nothing Then
            sErrorMsg &= vbCrLf & ex.StackTrace
            While Not ex.InnerException Is Nothing
                ex = ex.InnerException
                sErrorMsg &= vbCrLf & ex.Message & vbCrLf & ex.StackTrace
            End While
        End If

#If www Then
        Throw New Exception(sMessage, ex)
        Exit Sub
#End If

        ' We've got to remember the current active form, otherwise for some reason focus goes off ADRIFT (never a good thing!)
        Try
            Dim frmActive As Form = Form.ActiveForm
#If Not Mono AndAlso Not www Then
            Dim fError As New frmError(sMessage, ex)
            fError.ShowDialog()
            If Not frmActive Is Nothing Then
                If Not frmActive.InvokeRequired Then
                    If Not frmActive.Focused Then frmActive.Focus()
                End If
            End If
#Else
            MsgBox(sErrorMsg, MsgBoxStyle.Exclamation, "ADRIFT Error")
#End If
        Catch
            ' We've had an Error creating window handle error here, yikes!
            MsgBox(sErrorMsg, MsgBoxStyle.Exclamation, "ADRIFT Error")
        End Try

    End Sub


    Public Function CharacterCount(ByVal sText As String, ByVal cCharacter As Char) As Integer
        CharacterCount = 0
        For i As Integer = 0 To sText.Length - 1
            If sText.Substring(i, 1) = cCharacter Then CharacterCount += 1
        Next
    End Function


    Public Function GetLibraries() As String()

        Dim sLibraries As String = GetSetting("ADRIFT", "Generator", "Libraries")

        If sLibraries = "" Then
            ' Attempt to find the libarary in current directory
            Dim SL As String = "StandardLibrary.amf"

            For Each sDir As String In New String() {IO.Path.GetDirectoryName(Application.ExecutablePath), DataPath}
                If IO.File.Exists(sDir & IO.Path.DirectorySeparatorChar & SL) Then
                    sLibraries = sDir & IO.Path.DirectorySeparatorChar & SL
                    Exit For
                End If
            Next
        End If

        Return sLibraries.Split("|"c)

    End Function



    ' A replacement for VB.Left - Substring returns an error if you try to access part of the string that doesn't exist.
    Public Function sLeft(ByVal sString As String, ByVal iLength As Integer) As String
        If sString Is Nothing OrElse iLength < 0 Then Return ""
        If sString.Length < iLength Then
            If sString <> Left(sString, iLength) Then
                sString = sString
            End If
            Return sString
        Else
            If sString.Substring(0, Math.Max(iLength, 0)) <> Left(sString, iLength) Then
                sString = sString
            End If
            Return sString.Substring(0, Math.Max(iLength, 0))
        End If
    End Function


    ' A replacement for VB.Right
    Public Function sRight(ByVal sString As String, ByVal iLength As Integer) As String
        If sString Is Nothing OrElse iLength < 0 Then Return ""
        If iLength > sString.Length Then
            If sString <> Right(sString, iLength) Then
                sString = sString
            End If
            Return sString
        Else
            If sString.Substring(sString.Length - iLength) <> Right(sString, iLength) Then
                sString = sString
            End If
            Return sString.Substring(sString.Length - iLength)
        End If
    End Function


    ' A replacement for VB.Mid
    Public Function sMid(ByVal sString As String, ByVal iStart As Integer) As String
        If sString Is Nothing Then Return ""
        If iStart < 1 Then iStart = 1
        If iStart > sString.Length Then
            Return ""
        Else
            Return sString.Substring(iStart - 1)
        End If
    End Function

    Public Function sMid(ByVal sString As String, ByVal iStart As Integer, ByVal iLength As Integer) As String
        If sString Is Nothing Then Return ""
        If iLength < 0 Then Return ""
        If iStart < 1 Then iStart = 1
        If iStart > sString.Length Then
            Return ""
        ElseIf iLength > sString.Length OrElse iLength + iStart > sString.Length Then
            'If Mid(sString, iStart, iLength) <> sString.Substring(iStart - 1) Then
            '    sString = sString
            'End If
            Return sString.Substring(iStart - 1)
        Else
            'If Mid(sString, iStart, iLength) <> sString.Substring(iStart - 1, iLength) Then
            '    sString = sString
            'End If
            Return sString.Substring(iStart - 1, iLength)
        End If
    End Function


    Public Function sInstr(ByVal sText As String, ByVal sSearchFor As String) As Integer
        If InStr(sText, sSearchFor) <> sInstr(1, sText, sSearchFor) Then
            sText = sText
        End If
        Return sInstr(1, sText, sSearchFor)
    End Function
    Public Function sInstr(ByVal startIndex As Integer, ByVal sText As String, ByVal sSearchFor As String) As Integer
        If sText Is Nothing OrElse sText = "" Then Return 0 ' -1 
        If sText.IndexOf(sSearchFor, startIndex - 1) + 1 <> InStr(startIndex, sText, sSearchFor) Then
            sText = sText
        End If
        Return sText.IndexOf(sSearchFor, startIndex - 1) + 1
    End Function


    Public Function DoubleToString(ByVal dfDouble As Double, Optional ByVal sFormat As String = "#,##0") As String
        Return dfDouble.ToString(sFormat, System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
    End Function


    Private Function GetDefaultFont() As Font
#If Runner Then
        If UserSession.bUseDefaultFont Then
            Return UserSession.DefaultFont
        Else
#End If
        If Adventure IsNot Nothing Then
            Return Adventure.DefaultFont
        Else
            Return New Font("Arial", 12, GraphicsUnit.Point)
        End If
#If Runner Then
        End If
#End If
    End Function


    Private _AllowDevToSetColours As Boolean?
    Public Property AllowDevToSetColours As Boolean
        Get
            If Not _AllowDevToSetColours.HasValue Then
                _AllowDevToSetColours = CBool(GetSetting("ADRIFT", "Runner", "AllowColours", "1"))
            End If
            Return _AllowDevToSetColours.Value
        End Get
        Set(value As Boolean)
            _AllowDevToSetColours = value
        End Set
    End Property


    Friend Function GetBackgroundColour() As Color

        If Adventure IsNot Nothing Then
#If Runner Then
        If Not AllowDevToSetColours OrElse Adventure.DeveloperDefaultBackgroundColour = Nothing Then
            Return ColorTranslator.FromOle(CInt(GetSetting("ADRIFT", "Runner", "Background", ColorTranslator.ToOle(Color.FromArgb(DEFAULT_BACKGROUNDCOLOUR)).ToString)))
        Else
            Return Adventure.DeveloperDefaultBackgroundColour
        End If
#Else
            Return Adventure.DeveloperDefaultBackgroundColour
#End If
        Else
            Return Color.FromArgb(DEFAULT_BACKGROUNDCOLOUR)
        End If

    End Function

    Friend Function GetInputColour() As Color

        If Adventure IsNot Nothing Then
#If Runner Then
            If Not AllowDevToSetColours OrElse Adventure.DeveloperDefaultInputColour = Nothing Then
                Return ColorTranslator.FromOle(CInt(GetSetting("ADRIFT", "Runner", "Text1", ColorTranslator.ToOle(Color.FromArgb(DEFAULT_INPUTCOLOUR)).ToString)))
            Else
                Return Adventure.DeveloperDefaultInputColour
            End If
#Else
            Return Adventure.DeveloperDefaultInputColour
#End If
        Else
            Return Color.FromArgb(DEFAULT_INPUTCOLOUR)
        End If

    End Function

    Friend Function GetOutputColour() As Color

        If Adventure IsNot Nothing Then
#If Runner Then
            If Not AllowDevToSetColours OrElse Adventure.DeveloperDefaultOutputColour = Nothing Then
                Return ColorTranslator.FromOle(CInt(GetSetting("ADRIFT", "Runner", "Text2", ColorTranslator.ToOle(Color.FromArgb(DEFAULT_OUTPUTCOLOUR)).ToString)))
            Else
                Return Adventure.DeveloperDefaultOutputColour
            End If
#Else
            Return Adventure.DeveloperDefaultOutputColour
#End If
        Else
            Return Color.FromArgb(DEFAULT_OUTPUTCOLOUR)
        End If

    End Function

    Friend Function GetLinkColour() As Color

        If Adventure IsNot Nothing Then
#If Runner Then
            If Not AllowDevToSetColours OrElse Adventure.DeveloperDefaultLinkColour = Nothing Then
                Return ColorTranslator.FromOle(CInt(GetSetting("ADRIFT", "Runner", "LinkColour", ColorTranslator.ToOle(Color.FromArgb(DEFAULT_LINKCOLOUR)).ToString)))
            Else
                Return Adventure.DeveloperDefaultLinkColour
            End If
#Else
            Return Adventure.DeveloperDefaultLinkColour
#End If
        Else
            Return Color.FromArgb(DEFAULT_LINKCOLOUR)
        End If

    End Function

    Friend Enum eJustification
        [Left]
        [Right]
        [Central]
    End Enum
    Public Sub Source2HTML(ByVal sSource As String, ByRef RichText As RichTextBox, ByVal bClearRTB As Boolean, Optional ByVal bDebug As Boolean = False, Optional ByRef sUnprocessedText As String = Nothing)

#If www Then
        fRunner.AppendHTML(sSource)
        Exit Sub
#Else

        Dim arlFonts As New Generic.List(Of Font)
        Dim arlColours As New Generic.List(Of Color)
        Dim arlJust As New Generic.List(Of eJustification)
        Dim iFontLevel As Integer = 0
        Dim iJustLevel As Integer = 0
        Dim sChunk As String
        Dim bItalic As Boolean
        Dim bBold As Boolean
        Dim bUnderline As Boolean
        Dim bColour As Boolean
        Dim Colour As Color

        Try

            If bClearRTB Then RichText.Text = ""

            Dim f As Font = GetDefaultFont()

            arlFonts.Add(f)
            arlColours.Add(GetOutputColour)
            arlJust.Add(eJustification.Left)

            While sSource <> ""

                If sLeft(sSource, 1) = "<" Then

                    Dim sToken As String
                    Dim sBuffer As String


                    If sInstr(1, sSource, ">") > 0 Then
                        ' Handle embedded tags
                        Dim i As Integer = 1
                        Dim iLevel As Integer = 0
                        While i < sSource.Length - 1 AndAlso Not (iLevel = 0 AndAlso sSource(i) = ">")
                            Select Case sSource(i)
                                Case "<"c
                                    iLevel += 1
                                Case ">"c
                                    iLevel -= 1
                            End Select
                            i += 1
                        End While
                        sToken = sSource.Substring(0, i + 1)
                        'sToken = sLeft(sSource, sInstr(1, sSource, ">"))
                    Else
                        sToken = sSource
                    End If

                    Dim sTokenOrig As String = sToken
                    sToken = sToken.ToLower
                    Dim iTokenLen As Integer = sToken.Length
                    sToken = sToken.Replace(" =", "=").Replace("= ", "=").Replace("colour", "color")

                    Select Case sToken
                        Case "<i>" : bItalic = True
                        Case "</i>" : bItalic = False
                        Case "<b>" : bBold = True
                        Case "</b>" : bBold = False
                        Case "<u>" : bUnderline = True
                        Case "</u>" : bUnderline = False
                        Case "<c>" : bColour = True
                        Case "</c>" : bColour = False
                        Case "<br>" : sSource = sToken & vbCrLf & Right(sSource, Len(sSource) - Len(sToken))
                        Case "</font>"
                            If iFontLevel > 0 Then
                                arlFonts.RemoveAt(iFontLevel)
                                arlColours.RemoveAt(iFontLevel)
                                iFontLevel -= 1
                                f = GetDefaultFont() ' Restore it in case we changed the default
                            End If
                        Case "</window>"
                            sUnprocessedText = sSource.Substring(sToken.Length)
                            Exit Sub
                        Case "<center>", "<centre>"
                            iJustLevel += 1
                            arlJust.Add(eJustification.Central)
                        Case "</center>", "</centre>", "</right>", "</left>"
                            If iJustLevel > 0 Then
                                arlJust.RemoveAt(iJustLevel)
                                iJustLevel -= 1
                            End If
                        Case "<right>"
                            iJustLevel += 1
                            arlJust.Add(eJustification.Right)
                        Case "<left>"
                            iJustLevel += 1
                            arlJust.Add(eJustification.Left)
                        Case "<del>"
                            RichText.SelectionStart = RichText.TextLength - 1
                            RichText.SelectionLength = 1
                            RichText.SelectedText = Chr(0)
                        Case "<waitkey>"
#If Runner Then
                            'RichText.SelectionStart = RichText.TextLength
                            'RichText.ScrollToCaret()
                            If Not bDebug Then
                                ScrollToEnd(RichText)
                                fRunner.WaitKey()
                            End If
                            Adventure.Player.WalkTo = "" ' Terminate any walks
#End If
                        Case "<cls>"
                            If Not bDebug Then
#If Runner Then
                                If RichText Is fRunner.txtOutput Then UserSession.iPreviousOffset = 0
#End If
                                RichText.Clear()
                            End If
                    End Select

#If Runner Then
                    If sLeft(sToken, 6) = "<wait " Then
                        Dim sTime As String = sRight(sToken, sToken.Length - 6).Replace(">", "")
                        Dim dfTime As Double = SafeDbl(sTime)
                        If dfTime > 0 AndAlso Not bDebug Then
                            ScrollToEnd(RichText)
                            fRunner.Locked = True
                            Application.DoEvents()
                            Threading.Thread.Sleep(SafeInt(dfTime * 1000))
                            fRunner.Locked = False
                        End If
                    End If

                    If sLeft(sToken, 8) = "<window " Then
                        Dim sWindow As String = sSource.Substring(8, sToken.Length - 8).Replace(">", "") ' Take from sSource rather than sToken so we get the defined case

                        If sWindow <> "" Then
                            Dim txtOutput As RichTextBox = Nothing                                       
#If Not Mono Then
                            Dim pane As Infragistics.Win.UltraWinDock.DockablePaneBase = fRunner.UDMRunner.PaneFromKey("pane_" & sWindow)
                            If pane Is Nothing Then
                                pane = New Infragistics.Win.UltraWinDock.DockableControlPane("pane_" & sWindow)
                                fRunner.UDMRunner.ControlPanes.Add(CType(pane, Infragistics.Win.UltraWinDock.DockableControlPane))
                                fRunner.UDMRunner.DockAreas(0).Panes.Add(pane)
                                txtOutput = New RichTextBox
                                With txtOutput
                                    .Font = fRunner.txtOutput.Font
                                    .ForeColor = fRunner.txtOutput.ForeColor
                                    .BackColor = fRunner.txtOutput.BackColor
                                    .ReadOnly = True
                                    .Name = "window_" & sWindow                                    
                                    AddHandler .MouseDown, AddressOf frmRunner.txtOutput_MouseDown
                                    AddHandler .GotFocus, AddressOf frmRunner.txtOutput_GotFocus
                                End With
                                With CType(pane, Infragistics.Win.UltraWinDock.DockableControlPane)
                                    .Control = txtOutput
                                    .Text = sWindow
                                    .Closed = False
                                End With
                                ' The layout restored on game load won't have included this control, so re-load it - not ideal :( 
                                fRunner.RestoreLayout(CType(pane, Infragistics.Win.UltraWinDock.DockableControlPane))
                            Else
                                txtOutput = CType(CType(pane, Infragistics.Win.UltraWinDock.DockableControlPane).Control, RichTextBox)
                            End If
#End If

                            Dim sUnprocessed As String = ""

                            Source2HTML(sSource.Substring(sToken.Length), txtOutput, bClearRTB, bDebug, sUnprocessed)
                            sSource = sToken & sUnprocessed
                        End If
                    End If

                    If sLeft(sToken, 5) = "<img " Then
                        Dim i As Integer

                        i = sInstr(sToken, " src=")
                        If i > 0 Then
                            sBuffer = sMid(sTokenOrig, i + 5, sTokenOrig.Length - i - 5)
                            If Left(sBuffer, 1) = Chr(34) Then
                                sBuffer = sMid(sBuffer, 2, sInstr(2, sBuffer, Chr(34)) - 2)
                            Else
                                If sInstr(1, sBuffer, " ") > 0 Then sBuffer = Left(sBuffer, sInstr(1, sBuffer, " "))
                            End If

                            Dim bVisible As Boolean = False
#If Not Mono AndAlso Not www Then
                            For Each cp As Infragistics.Win.UltraWinDock.DockableControlPane In fRunner.UDMRunner.ControlPanes
                                If cp.Text = "Graphics" AndAlso cp.IsVisible Then bVisible = True
                            Next
#End If
                            Try
                                If UserSession.bGraphics AndAlso Not bDebug Then
                                    If Adventure.BlorbMappings IsNot Nothing AndAlso Adventure.BlorbMappings.Count > 0 Then
                                        Dim iResource As Integer = 0
                                        If Adventure.BlorbMappings.ContainsKey(sBuffer) Then iResource = Adventure.BlorbMappings(sBuffer)
                                        If iResource > 0 Then
                                            fRunner.pbxGraphics.Image = Blorb.GetImage(iResource, True)
                                        End If
                                    Else
                                        fRunner.pbxGraphics.Load(sBuffer)
                                    End If

                                    If Not bVisible Then
                                        If False Then
                                            ' RTF method
                                            Dim img As Image = fRunner.pbxGraphics.Image
                                            Dim stmMemory As New IO.MemoryStream
                                            'img.Save(stmMemory, System.Drawing.Imaging.ImageFormat.Bmp)
                                            stmMemory = WmfStuff.MakeMetafileStream(img)

                                            'Dim converter As New ImageConverter
                                            'Dim bytImage() As Byte = CType(converter.ConvertTo(img, GetType(Byte())), Byte())
                                            Dim bytImage() As Byte = stmMemory.ToArray
                                            Dim sHex As String = BitConverter.ToString(bytImage).Replace("-", "").ToLower


                                            Dim sRTF As String = "{\pict\wmetafile8\picw" & img.Width & "\pich" & img.Height & "\picwgoal" & img.Width * 15 & "\pichgoal" & img.Height * 15 & " " & sHex & "}"
                                            'Dim sRTF As String = "{\pict\wbitmap8\picw" & img.Width & "\pich" & img.Height & "\picwgoal" & img.Width * 15 & "\pichgoal" & img.Height * 15 & " " & sHex & "}"
                                            RichText.ReadOnly = False
                                            'RichText.Rtf.Insert(RichText.Rtf.Length - 1, sRTF)
                                            RichText.Rtf = RichText.Rtf.Insert(RichText.Rtf.Length - 3, sRTF)
                                            'RichText.SelectedRtf = sRTF
                                            RichText.ReadOnly = True

                                        Else
                                            ' Clipboard method
                                            'Dim oExistingData As IDataObject = Nothing
                                            Dim sExistingText As String = Nothing
                                            Dim imgExistingImage As Image = Nothing
                                            Try
                                                If Clipboard.ContainsText Then sExistingText = Clipboard.GetText
                                                If Clipboard.ContainsImage Then imgExistingImage = Clipboard.GetImage
                                                'oExistingData = Clipboard.GetDataObject
                                            Catch
                                            End Try
                                            Clipboard.SetImage(fRunner.pbxGraphics.Image)
                                            RichText.ReadOnly = False
                                            'Dim align As HorizontalAlignment = RichText.SelectionAlignment
                                            'RichText.SelectionAlignment = HorizontalAlignment.Center

                                            RichText.Paste()
                                            'RichText.SelectedText = vbCrLf
                                            'RichText.SelectionAlignment = align
                                            RichText.ReadOnly = True

                                            'Put whatever was on the clipboard before, back on
                                            'If oExistingData IsNot Nothing Then
                                            'Clipboard.SetDataObject(oExistingData, True, 1, 0)
                                            'End If
                                            If sExistingText IsNot Nothing Then Clipboard.SetText(sExistingText)
                                            If imgExistingImage IsNot Nothing Then Clipboard.SetImage(imgExistingImage)
                                        End If
                                    End If
                                End If
                            Catch
                            End Try
                        End If
                    End If
#End If

                    If sLeft(sToken, 7) = "<audio " Then
                        Dim i As Integer
                        Dim iChannel As Integer = 1
                        Dim bLooping As Boolean = False
                        Dim sSrc As String = ""

                        i = sInstr(sToken, "channel=")
                        If i > 0 Then
                            sBuffer = sMid(sTokenOrig, i + 8, sTokenOrig.Length - i - 8)
                            If Left(sBuffer, 1) = Chr(34) Then
                                sBuffer = sMid(sBuffer, 2, sInstr(2, sBuffer, Chr(34)) - 2)
                            Else
                                If sInstr(1, sBuffer, " ") > 0 Then sBuffer = Left(sBuffer, sInstr(1, sBuffer, " "))
                            End If
                            iChannel = SafeInt(sBuffer)
                        End If

                        i = sInstr(sToken, " src=")
                        If i > 0 Then
                            sBuffer = sMid(sTokenOrig, i + 5, sTokenOrig.Length - i - 5)
                            If Left(sBuffer, 1) = Chr(34) Then
                                sSrc = sMid(sBuffer, 2, sInstr(2, sBuffer, Chr(34)) - 2)
                            Else
                                If sInstr(1, sBuffer, " ") > 0 Then sSrc = Left(sBuffer, sInstr(1, sBuffer, " "))
                            End If
                        End If

                        i = sInstr(sToken, " loop=")
                        If i > 0 Then
                            sBuffer = sMid(sTokenOrig, i + 6, sTokenOrig.Length - i - 6)
                            If Left(sBuffer, 1) = Chr(34) Then sBuffer = sMid(sBuffer, 2, sInstr(2, sBuffer, Chr(34)) - 2)
                            Select Case sBuffer
                                Case "Y", "y", "1", "True", "true", "TRUE"
                                    bLooping = True
                            End Select
                        End If

#If Runner Then
                        If UserSession.bSound AndAlso Not bDebug Then
#End If
                            If sToken.Contains(" pause") Then
                                PauseSound(iChannel)
                            ElseIf sToken.Contains(" stop") Then
                                StopSound(iChannel)
                            Else
                                PlaySound(sSrc, iChannel, bLooping)
                            End If
#If Runner Then
                        End If
#End If

                    End If


                    If (sLeft(sToken, 8) = "<bgcolor" OrElse sLeft(sToken, 9) = "<bgcolour") AndAlso AllowDevToSetColours Then
                        sBuffer = sToken.Substring(9)
                        sBuffer = sBuffer.Substring(0, sBuffer.Length - 1)
                        While sBuffer.StartsWith(" ") OrElse sBuffer.StartsWith("=")
                            sBuffer = sBuffer.Substring(1)
                        End While
                        Dim bgColour As Color
                        If Right(sBuffer, 1) = Chr(34) AndAlso Left(sBuffer, 1) = Chr(34) Then sBuffer = sMid(sBuffer, 2, sBuffer.Length - 2)
                        If sBuffer.ToLower = "default" Then
                            bgColour = GetBackgroundColour()
                        Else
                            sBuffer = ColourLookup(sBuffer)

                            ' Interpret the colour
                            Dim rr As Byte = invhex(Left(sBuffer, 2))
                            Dim gg As Byte = invhex(Mid(sBuffer, 3, 2))
                            Dim bb As Byte = invhex(Right(sBuffer, 2))

                            bgColour = Color.FromArgb(rr, gg, bb)
                        End If
#If Runner Then
                        fRunner.SetBackgroundColour(bgColour)
#End If
                    End If


                    If sLeft(sToken, 6) = "<font " Then

                        iFontLevel += 1
                        Dim NewFont As New Font(f, f.Style)
                        Dim NewColour As New Color
                        NewColour = arlColours(iFontLevel - 1)
                        Dim i As Integer

                        i = sInstr(sToken, "color=")
                        If i > 0 Then
                            sBuffer = sMid(sToken, i + 6, sToken.Length - i - 6)
                            If sInstr(sBuffer, " ") > 0 Then sBuffer = Left(sBuffer, sInstr(sBuffer, " ") - 1)
                            If Right(sBuffer, 1) = Chr(34) AndAlso Left(sBuffer, 1) = Chr(34) Then sBuffer = sMid(sBuffer, 2, sBuffer.Length - 2)
                            If AllowDevToSetColours OrElse (sBuffer.ToUpper = "#" & Hex(GetLinkColour.ToArgb).Substring(2) AndAlso sSource.Contains("</u>")) Then
                                If sBuffer.ToLower = "default" Then
                                    NewColour = GetOutputColour()
                                Else
                                    sBuffer = ColourLookup(sBuffer)

                                    ' Interpret the colour
                                    Dim rr As Byte = invhex(Left(sBuffer, 2))
                                    Dim gg As Byte = invhex(Mid(sBuffer, 3, 2))
                                    Dim bb As Byte = invhex(Right(sBuffer, 2))

                                    NewColour = Color.FromArgb(rr, gg, bb)
                                End If
                            End If
                        End If

                        i = sInstr(sToken, "face=")
                        If i > 0 Then
                            sBuffer = sMid(sToken, i + 5, sToken.Length - i - 5)
                            If Left(sBuffer, 1) = Chr(34) Then
                                sBuffer = sMid(sBuffer, 2, sInstr(2, sBuffer, Chr(34)) - 2)
                            Else
                                If sInstr(1, sBuffer, " ") > 0 Then sBuffer = Left(sBuffer, sInstr(1, sBuffer, " "))
                            End If

                            If CBool(GetSetting("ADRIFT", "Runner", "AllowFonts", "1")) OrElse sSource.StartsWith("<font face=""Wingdings"" size=14>Ø</font>") OrElse sSource.StartsWith("<font face=""Wingdings"" size=18>@</font>") Then
                                NewFont = New Font(sBuffer, f.Size, f.Style, GraphicsUnit.Point)
                                f = NewFont
                            End If
                        End If

                        i = sInstr(sToken, "size=")
                        If i > 0 Then
                            sBuffer = sMid(sToken, i + 5, sToken.Length - i - 5)
                            If Left(sBuffer, 1) = Chr(34) Then
                                sBuffer = sMid(sBuffer, 2, sInstr(2, sBuffer, Chr(34)) - 2)
                            Else
                                If sInstr(1, sBuffer, " ") > 0 Then sBuffer = Left(sBuffer, sInstr(1, sBuffer, " "))
                            End If

                            If CSng(sBuffer) < 0 Then
                                sBuffer = (arlFonts(iFontLevel - 1).Size + CSng(sBuffer)).ToString
                            End If
                            If Left(sBuffer, 1) = "+" Then
                                sBuffer = (arlFonts(iFontLevel - 1).Size + CSng(sBuffer.Substring(1))).ToString
                            End If

                            If CBool(GetSetting("ADRIFT", "Runner", "AllowFonts", "1")) Then
                                NewFont = New Font(f.FontFamily, CSng(sBuffer), f.Style, GraphicsUnit.Point)
                            End If
                        End If

                        arlFonts.Add(NewFont)
                        arlColours.Add(NewColour)

                    End If

                    sSource = sRight(sSource, sSource.Length - iTokenLen)

                End If

                If sInstr(1, sSource, "<") > 0 Then
                    sChunk = sLeft(sSource, sInstr(1, sSource, "<") - 1)
                    sSource = sRight(sSource, sSource.Length - sInstr(1, sSource, "<") + 1)
                Else
                    sChunk = sSource
                    sSource = ""
                End If

                With RichText
                    If .IsDisposed Then Exit Sub

                    .SelectionStart = .TextLength

                    Dim fStyle As New FontStyle
                    fStyle = FontStyle.Regular
                    If bBold Then fStyle = FontStyle.Bold
                    If bItalic Then fStyle = fStyle Or FontStyle.Italic
                    If bUnderline Then fStyle = fStyle Or FontStyle.Underline
                    If bColour Then Colour = GetInputColour() Else Colour = arlColours(iFontLevel)

                    Try
                        Select Case arlJust(iJustLevel)
                            Case eJustification.Left
                                If .SelectionAlignment <> HorizontalAlignment.Left AndAlso sRight(RichText.Text, 1) <> vbLf Then
                                    .AppendText(vbCrLf) ' sChunk = vbCrLf & sChunk
                                    If sChunk.StartsWith(vbLf) Then sChunk = sChunk.Substring(1)
                                End If
                                .SelectionAlignment = HorizontalAlignment.Left
                            Case eJustification.Central
                                If .SelectionAlignment <> HorizontalAlignment.Center AndAlso sRight(RichText.Text, 1) <> vbLf Then
                                    .AppendText(vbCrLf)
                                    If sChunk.StartsWith(vbLf) Then sChunk = sChunk.Substring(1)
                                End If
                                .SelectionAlignment = HorizontalAlignment.Center
                            Case eJustification.Right
                                If .SelectionAlignment <> HorizontalAlignment.Right AndAlso sRight(RichText.Text, 1) <> vbLf Then
                                    .AppendText(vbCrLf) ' sChunk = vbCrLf & sChunk
                                    If sChunk.StartsWith(vbLf) Then sChunk = sChunk.Substring(1)
                                End If
                                .SelectionAlignment = HorizontalAlignment.Right
                        End Select
                    Catch
                    End Try

                    Dim font As Font = New Font(arlFonts(iFontLevel), fStyle)
                    If font IsNot Nothing Then
                        Try
                            .SelectionFont = font
                            'sChunk = font.ToString & sChunk
                        Catch ex As Exception
                            'ErrMsg("Error setting font " & font.Name, ex)
                        End Try
                    End If

                    Try
                        If .SelectionColor <> Colour Then
                            If sChunk.StartsWith(vbCrLf) Then sChunk = " " & sChunk
                            '    .AppendText(" " & vbCrLf) ' A fudge, because for some reason we seem to be applying the new colour to the last char before the CR
                            '    sChunk = sChunk.Substring(2)                                
                            'End If
                            .SelectionColor = Colour
                        End If
                    Catch ex As Exception
                        'ErrMsg("Error setting selection colour", ex)
                    End Try

                    '.SelectedText = sChunk.Replace("&gt;", ">").Replace("&lt;", "<")
                    .AppendText(sChunk.Replace("&gt;", ">").Replace("&lt;", "<").Replace("&perc;", "%").Replace("&quot;", """"))

                    ' A nasty workaround because there seems to be a bug colouring extended Ascii characters.  :-(
                    Dim bRecolour As Boolean = False
                    For Each c As Char In sChunk
                        If Asc(c) > 128 Then
                            bRecolour = True
                            Exit For
                        End If
                    Next
                    If bRecolour Then
                        Dim iChunkLength As Integer = Math.Min(sChunk.Replace(vbCrLf, "@").Length, .TextLength)
                        .SelectionStart = .TextLength - iChunkLength
                        .SelectionLength = iChunkLength
                        .SelectionColor = Colour
                    End If
                    '.ScrollToCaret()

                    '                .SelectedText = sChunk
                    '.SelectionStart = .TextLength

                    'If Not bClearRTB Then
                    '    .Focus()
                    '    .ScrollToCaret()
                    'End If

                End With

            End While

            ScrollToEnd(RichText)

        Catch exOD As ObjectDisposedException
            ' Fail silently - we're shutting down            
        Catch ex As Exception
            ErrMsg("Source2HTML error", ex)
        End Try

#End If

    End Sub


    Private Class WmfStuff

        <Flags> _
        Private Enum EmfToWmfBitsFlags
            EmfToWmfBitsFlagsDefault = &H0
            EmfToWmfBitsFlagsEmbedEmf = &H1
            EmfToWmfBitsFlagsIncludePlaceable = &H2
            EmfToWmfBitsFlagsNoXORClip = &H4
        End Enum

        Private Shared MM_ISOTROPIC As Integer = 7
        Private Shared MM_ANISOTROPIC As Integer = 8

        <System.Runtime.InteropServices.DllImport("gdiplus.dll")> _
        Private Shared Function GdipEmfToWmfBits(_hEmf As IntPtr, _bufferSize As UInteger, _buffer As Byte(), _mappingMode As Integer, _flags As EmfToWmfBitsFlags) As UInteger
        End Function
        <System.Runtime.InteropServices.DllImport("gdi32.dll")> _
        Private Shared Function SetMetaFileBitsEx(_bufferSize As UInteger, _buffer As Byte()) As IntPtr
        End Function
        <System.Runtime.InteropServices.DllImport("gdi32.dll")> _
        Private Shared Function CopyMetaFile(hWmf As IntPtr, filename As String) As IntPtr
        End Function
        <System.Runtime.InteropServices.DllImport("gdi32.dll")> _
        Private Shared Function DeleteMetaFile(hWmf As IntPtr) As Boolean
        End Function
        <System.Runtime.InteropServices.DllImport("gdi32.dll")> _
        Private Shared Function DeleteEnhMetaFile(hEmf As IntPtr) As Boolean
        End Function

        Public Shared Function MakeMetafileStream(image As System.Drawing.Image) As IO.MemoryStream
            Dim metafile As System.Drawing.Imaging.Metafile = Nothing
            Using g As Graphics = Graphics.FromImage(image)
                Dim hDC As IntPtr = g.GetHdc()
                metafile = New System.Drawing.Imaging.Metafile(hDC, System.Drawing.Imaging.EmfType.EmfOnly)
                g.ReleaseHdc(hDC)
            End Using

            Using g As Graphics = Graphics.FromImage(metafile)
                g.DrawImage(image, 0, 0)
            End Using
            Dim _hEmf As IntPtr = metafile.GetHenhmetafile()
            Dim _bufferSize As UInteger = GdipEmfToWmfBits(_hEmf, 0, Nothing, MM_ANISOTROPIC, EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault)
            Dim _buffer As Byte() = New Byte(CInt(_bufferSize) - 1) {}
            GdipEmfToWmfBits(_hEmf, _bufferSize, _buffer, MM_ANISOTROPIC, EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault)
            DeleteEnhMetaFile(_hEmf)

            Dim stream As New IO.MemoryStream()
            stream.Write(_buffer, 0, CInt(_bufferSize))
            stream.Seek(0, 0)

            Return stream
        End Function

    End Class


    ' Scrolls to the end of the text, and adds a <Wait> box if necessary
    Friend Sub ScrollToEnd(ByVal RichText As RichTextBox)

        With RichText
            .SelectionStart = .TextLength + 1
            .ScrollToCaret() ' Scroll to end
#If Runner Then
            If RichText Is fRunner.txtOutput Then
                Dim iCurrentTop As Integer = .GetCharIndexFromPosition(New Point(0, 0))
                If iCurrentTop > UserSession.iPreviousOffset Then
                    .SelectionStart = UserSession.iPreviousOffset
                    .ScrollToCaret() ' Scroll back to start of this text section

                    If .GetCharIndexFromPosition(New Point(.Width, .Height)) < .TextLength - 1 Then
                        fRunner.btnMore.Size = New Size(fRunner.pnlBottom.Size.Width - 1, fRunner.pnlBottom.Size.Height - 1)
                        fRunner.btnMore.Location = New Point(fRunner.pnlBottom.Location.X - 1, fRunner.pnlBottom.Location.Y - 1)
                        fRunner.btnMore.Visible = True
                    End If
                End If
            End If
#End If
        End With

    End Sub


    ' Escape any characters that are special in RE's
    Friend Function MakeTextRESafe(ByVal sText As String) As String

        sText = sText.Replace("+", "\+").Replace("*", "\*")

        Return sText
    End Function


    Friend Function invhex(ByVal hexcode As String) As Byte

        Dim n As Byte

        If Left(hexcode, 1) = "0" Then
            For n = 0 To 15
                If Hex(n) = UCase(Right(hexcode, 1)) Then Return n
            Next n
        End If
        For n = 16 To 254
            If Hex(n) = UCase(hexcode) Then Return n
        Next n
        If Hex(255) = UCase(hexcode) Then Return 255
        Return 0

    End Function


    Friend Function ColourLookup(ByVal sCode As String) As String

        sCode = sCode.Replace("""", "")

        ColourLookup = Nothing

        Select Case LCase(sCode)
            Case "black" : ColourLookup = "000000"
            Case "blue" : ColourLookup = "0000ff"
            Case "cyan", "turquoise", "aqua" : ColourLookup = "00ffff"
            Case "default"
                'ColourLookup = Right(Hex(colour(0)), 2) & sMid(Hex(colour(0)), 3, 2) & Left(Hex(colour(0)), 2)
            Case "gray" : ColourLookup = "808080"
            Case "green" : ColourLookup = "008000"
            Case "lime" : ColourLookup = "00ff00"
            Case "magenta", "fuchsia" : ColourLookup = "ff00ff"
            Case "maroon" : ColourLookup = "800000"
            Case "navy" : ColourLookup = "000080"
            Case "olive" : ColourLookup = "808000"
            Case "orange" : ColourLookup = "ff8000"
            Case "pink" : ColourLookup = "ff8888"
            Case "purple" : ColourLookup = "800080"
            Case "red" : ColourLookup = "ff0000"
            Case "silver" : ColourLookup = "c0c0c0"
            Case "teal" : ColourLookup = "008080"
            Case "white" : ColourLookup = "ffffff"
            Case "yellow" : ColourLookup = "ffff00"

            Case Else
                If Left(sCode, 1) = "#" Then sCode = Right(sCode, Len(sCode) - 1)
                If Len(sCode) > 6 Then sCode = "ffffff"
                While Len(sCode) < 6
                    sCode = sCode & "0"
                End While
                ColourLookup = sCode
        End Select

    End Function

    Public Function DirectionName(ByVal dir As DirectionsEnum) As String

        Dim sName As String = Adventure.sDirectionsRE(dir)
        If sName.Contains("/") Then sName = sName.Substring(0, sName.IndexOf("/"))
        Return sName

        'Select Case dir
        '    Case DirectionsEnum.North
        '        Return "North"
        '    Case DirectionsEnum.NorthEast
        '        Return "North East"
        '    Case DirectionsEnum.East
        '        Return "East"
        '    Case DirectionsEnum.SouthEast
        '        Return "South East"
        '    Case DirectionsEnum.South
        '        Return "South"
        '    Case DirectionsEnum.SouthWest
        '        Return "South West"
        '    Case DirectionsEnum.West
        '        Return "West"
        '    Case DirectionsEnum.NorthWest
        '        Return "North West"
        '    Case DirectionsEnum.Up
        '        Return "Up"
        '    Case DirectionsEnum.Down
        '        Return "Down"
        '    Case DirectionsEnum.In
        '        Return "Inside"
        '    Case DirectionsEnum.Out
        '        Return "Outside"
        'End Select

        'Return Nothing

    End Function



    Public Function DirectionRE(ByVal dir As DirectionsEnum, Optional ByVal bBrackets As Boolean = True, Optional ByVal bRealRE As Boolean = False) As String

        'Dim sRE As String = ""
        'Dim sOr As String = CStr(IIf(bRealRE, "|", "/"))

        '' Allow these to be customised later
        'Select Case dir
        '    Case DirectionsEnum.North
        '        sRE = "north" & sOr & "n"
        '    Case DirectionsEnum.NorthEast
        '        sRE = "north east" & sOr & "northeast" & sOr & "north-east" & sOr & "ne"
        '    Case DirectionsEnum.East
        '        sRE = "east" & sOr & "e"
        '    Case DirectionsEnum.SouthEast
        '        sRE = "south east" & sOr & "southeast" & sOr & "south-east" & sOr & "se"
        '    Case DirectionsEnum.South
        '        sRE = "south" & sOr & "s"
        '    Case DirectionsEnum.SouthWest
        '        sRE = "south west" & sOr & "southwest" & sOr & "south-west" & sOr & "sw"
        '    Case DirectionsEnum.West
        '        sRE = "west" & sOr & "w"
        '    Case DirectionsEnum.NorthWest
        '        sRE = "north west" & sOr & "northwest" & sOr & "north-west" & sOr & "nw"
        '    Case DirectionsEnum.Up
        '        sRE = "up" & sOr & "u"
        '    Case DirectionsEnum.Down
        '        sRE = "down" & sOr & "d"
        '    Case DirectionsEnum.In
        '        sRE = "inside" & sOr & "in"
        '    Case DirectionsEnum.Out
        '        sRE = "outside" & sOr & "out" & sOr & "o"
        'End Select

        Dim sRE As String = Adventure.sDirectionsRE(dir).ToLower
        If bRealRE Then sRE = sRE.Replace("/", "|")

        If bBrackets Then
            If bRealRE Then
                Return "(" & sRE & ")"
            Else
                Return "[" & sRE & "]"
            End If
        Else
            Return sRE
        End If

    End Function

    Public Function KeyExists(ByVal sKey As String) As Boolean

        With Adventure
            If .htblLocations.ContainsKey(sKey) Then Return True
            If .htblObjects.ContainsKey(sKey) Then Return True
            If .htblTasks.ContainsKey(sKey) Then Return True
            If .htblEvents.ContainsKey(sKey) Then Return True
            If .htblCharacters.ContainsKey(sKey) Then Return True
            If .htblGroups.ContainsKey(sKey) Then Return True
            If .htblVariables.ContainsKey(sKey) Then Return True
            If .htblALRs.ContainsKey(sKey) Then Return True
            If .htblHints.ContainsKey(sKey) Then Return True
            If .htblAllProperties.ContainsKey(sKey) Then Return True
        End With

        Return False

    End Function

    Public Function FindProperty(ByVal arlStates As StringArrayList) As String

        Dim bMatch As Boolean

        For Each prop As clsProperty In Adventure.htblAllProperties.Values
            bMatch = True
            If prop.arlStates.Count = arlStates.Count Then
                For Each sState As String In arlStates
                    If Not prop.arlStates.Contains(sState) Then
                        bMatch = False
                        Exit For
                    End If
                Next
                If bMatch Then
                    Return prop.Key
                End If
            End If
        Next

        Return Nothing

    End Function

    Public Function ToProper(ByVal sText As String, Optional ByVal bForceRestLower As Boolean = True) As String
        If bForceRestLower Then
            Return sLeft(sText, 1).ToUpper & sRight(sText, sText.Length - 1).ToLower
        Else
            Return sLeft(sText, 1).ToUpper & sRight(sText, sText.Length - 1)
        End If
    End Function

    Public Function FunctionNames() As StringArrayList
        Dim Names As New StringArrayList
        For Each sName As String In New String() {"AloneWithChar", "CharacterDescriptor", "CharacterName", "CharacterProper", "ConvCharacter", "DisplayCharacter", "DisplayLocation", "DisplayObject", "Held", "LCase", "ListCharactersOn", "ListCharactersIn", "ListCharactersOnAndIn", "ListHeld", "ListExits", "ListObjectsAtLocation", "ListWorn", "ListObjectsOn", "ListObjectsIn", "ListObjectsOnAndIn", "LocationName", "LocationOf", "NumberAsText", "ObjectName", "ObjectsIn", "ParentOf", "PCase", "Player", "PopUpChoice", "PopUpInput", "PrevListObjectsOn", "PrevParentOf", "ProperName", "PropertyValue", "Release", "Replace", "Sum", "TaskCompleted", "TheObject", "TheObjects", "Turns", "UCase", "Version", "Worn"}
            Names.Add(sName)
        Next
        If Adventure IsNot Nothing Then
            For Each UDF As clsUserFunction In Adventure.htblUDFs.Values
                Names.Add(UDF.Name)
            Next
        End If
        Return Names
    End Function

    Public Function ReferenceNames() As String()
        Return New String() {"%object%", "%objects%", "%object1%", "%object2%", "%object3%", "%object4%", "%object5%", "%direction%", "%direction1%", "%direction2%", "%direction3%", "%direction4%", "%direction5%", "%character%", "%character1%", "%character2%", "%character3%", "%character4%", "%character5%", "%text%", "%text1%", "%text2%", "%text3%", "%text4%", "%text5%", "%number%", "%number1%", "%number2%", "%number3%", "%number4%", "%number5%", "%location%", "%location1%", "%location2%", "%location3%", "%location4%", "%location5%", "%item%", "%item1%", "%item2%", "%item3%", "%item4%", "%item5%"}
    End Function

    Public Function InstrCount(ByVal sText As String, ByVal sSubText As String) As Integer

        Dim iOffset As Integer = 1
        Dim iCount As Integer = 0

        While iOffset < sText.Length
            If sInstr(iOffset, sText, sSubText) > 0 Then
                iCount += 1
                iOffset = sInstr(iOffset, sText, sSubText) + 1
            Else
                Return iCount
            End If
        End While

        Return iCount

    End Function


    Public Function EvaluateExpression(ByVal sExpression As String) As String

        If sExpression = "" Then Return ""

        Dim var As New clsVariable
        var.Type = clsVariable.VariableTypeEnum.Text
        var.SetToExpression(sExpression)
        'If var.StringValue <> "" Then ' Err, what if the function returns ""?
        Return var.StringValue
        'Else
        'Return sExpression
        'End If

    End Function
    Public Function EvaluateExpression(ByVal sExpression As String, ByVal bInt As Boolean) As Integer

        Dim var As New clsVariable
        var.Type = clsVariable.VariableTypeEnum.Numeric
        var.SetToExpression(sExpression)
        Return var.IntValue

    End Function


    Public Function ReplaceExpressions(ByVal sText As String) As String

        Dim reExp As New System.Text.RegularExpressions.Regex("<#(?<expression>.*?)#>", System.Text.RegularExpressions.RegexOptions.Singleline)
        For Each m As System.Text.RegularExpressions.Match In reExp.Matches(sText)
            sText = sText.Replace(m.Value, EvaluateExpression(m.Groups("expression").Value))
        Next
        Return sText

    End Function


    Public Function ReplaceALRs(ByVal sText As String, Optional ByVal bAutoCapitalise As Boolean = True) As String

        Try
            If sText = "" Then Return ""

            sText = ReplaceFunctions(sText)
            sText = ReplaceExpressions(sText)

            Dim bChanged As Boolean = False

            '' Auto-capitalise - Do before ALRs as the user sees the final output so wants to replace that
            'If bAutoCapitalise Then
            '    Dim reCap As New System.Text.RegularExpressions.Regex("^(?<cap>[a-z])|\n(?<cap>[a-z])|[a-z][\.\!\?] ( )?(?<cap>[a-z])")
            '    While reCap.IsMatch(sText)
            '        Dim match As System.Text.RegularExpressions.Match = reCap.Match(sText)
            '        Dim sCap As String = match.Groups("cap").Value
            '        Dim iIndex As Integer = match.Groups("cap").Index
            '        sText = sText.Substring(0, iIndex) & sCap.ToUpper & sText.Substring(iIndex + sCap.Length)
            '    End While
            'End If

            ' Replace ALRs
            For Each alr As clsALR In Adventure.htblALRs.Values
                If sText.Contains(alr.OldText) Then
                    Dim sALR As String = alr.NewText.ToString ' Get it in a variable in case we have DisplayOnce
                    If sText = sALR Then Exit For
                    sText = sText.Replace(alr.OldText, ReplaceALRs(sALR, False))
                End If
            Next

            ' Auto-capitalise - needs to happen after ALR replacements, as some replacements may be both intra and start of sentences
            If bAutoCapitalise Then 'AndAlso bChanged Then
                Dim reCap As New System.Text.RegularExpressions.Regex("^(?<cap>[a-z])|\n(?<cap>[a-z])|[a-z][\.\!\?] ( )?(?<cap>[a-z])")
                While reCap.IsMatch(sText)
                    Dim match As System.Text.RegularExpressions.Match = reCap.Match(sText)
                    Dim sCap As String = match.Groups("cap").Value
                    Dim iIndex As Integer = match.Groups("cap").Index
                    sText = sText.Substring(0, iIndex) & sCap.ToUpper & sText.Substring(iIndex + sCap.Length)
                    bChanged = True
                End While
            End If

            ' Do a second round of ALR replacements if we auto-capped anything, as user may want to replace the auto-capped version
            If bChanged Then
                For Each alr As clsALR In Adventure.htblALRs.Values
                    If sText.Contains(alr.OldText) Then
                        Dim sALR As String = alr.NewText.ToString ' Get it in a variable in case we have DisplayOnce
                        If sText = sALR Then Exit For
                        sText = sText.Replace(alr.OldText, ReplaceALRs(sALR, False))
                    End If
                Next
            End If

            Return sText

        Catch ex As Exception
            ErrMsg("ReplaceALRs error", ex)
            Return sText
        End Try

    End Function



    Public Function pSpace(ByRef sText As String) As String

        If sText Is Nothing OrElse sText.Length = 0 Then
            sText = ""
            Return sText
        Else
            If sText.EndsWith(vbLf) Then Return sText ' OrElse sText.ToLower.EndsWith("<br>")
        End If

        sText &= "  "
        Return sText

    End Function


    Public Sub DisplayError(ByVal sText As String)
#If Runner Then
        UserSession.DebugPrint(Nothing, "", DebugDetailLevelEnum.Error, "<i><c>*** " & sText & "***</c></i>")
#Else
        ErrMsg(sText)
#End If
    End Sub


    ' A case ignoring search
    Public Function Contains(ByVal sTextToSearchIn As String, ByVal sTextToFind As String, Optional ByVal bExactWord As Boolean = False, Optional ByVal iStart As Integer = 0) As Boolean
        sTextToFind = sTextToFind.Replace(".", "\.")
        Dim sPattern As String = If(bExactWord, "\b" & sTextToFind & "\b", sTextToFind).ToString
        Dim regex As New System.Text.RegularExpressions.Regex(sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        Return regex.IsMatch(sTextToSearchIn.Substring(iStart))
    End Function
    Public Function ContainsWord(ByVal sTextToSearchIn As String, ByVal sTextToFind As String) As Boolean
        Return Contains(sTextToSearchIn, sTextToFind, True)
    End Function

    Public Function PreviousFunction(ByVal sFunction As String, ByVal sArgs As String) As String

#If Runner Then
        With UserSession
            Dim sNewFunction As String = sFunction.Replace("prev", "")
            Dim PreviousState As clsGameState = CType(.States.Peek, clsGameState) ' Note the previous state
            .States.RecordState() ' Save where we are now
            .States.RestoreState(PreviousState) ' Load up the previous state

            PreviousFunction = ReplaceFunctions("%" & sNewFunction & "[" & sArgs & "]%")

            .States.Pop() ' Get rid of the 'current' state and load it back as present
        End With
#Else
        Return ""
#End If

    End Function


    ' Chops the last character off a string 
    Public Function ChopLast(ByVal sText As String) As String

        If sText.Length > 0 Then
            Return sText.Substring(0, sText.Length - 1)
        Else
            Return ""
        End If

    End Function


    ' If this is in an expression, we need to replace anything with a quoted value
    Public Function ReplaceOO(ByVal sText As String, ByVal bExpression As Boolean) As String

        Dim reIgnore As New System.Text.RegularExpressions.Regex(".*?(?<embeddedexpression><#.*?#>).*?")
        If reIgnore.IsMatch(sText) Then
            Dim sMatch As String = reIgnore.Match(sText).Groups("embeddedexpression").Value
            Dim sGUID As String
            sGUID = ":" & System.Guid.NewGuid.ToString & ":"
            Dim sReturn As String = ReplaceOO(sText.Replace(sMatch, sGUID), bExpression)
            Return sReturn.Replace(sGUID, sMatch)
        Else
            ' Match anything unless it's between <# ... #> symbols
            'Dim re As New System.Text.RegularExpressions.Regex("(?!<#.*?)(?<firstkey>%?[A-Za-z][\w\|_-]*%?)(?<nextkey>\.%?[A-Za-z][\w\|_-]*%?(\(.+?\))?)+(?!.*?#>)")
            Dim re As New System.Text.RegularExpressions.Regex("(?!<#.*?)(?<firstkey>%?[A-Za-z][\w\|_]*%?)(?<nextkey>\.%?[A-Za-z][\w\|_]*%?(\(.+?\))?)+(?!.*?#>)")
            'Dim re As New System.Text.RegularExpressions.Regex("(?!<#.*?)(?<firstkey>%?[A-Za-z]([\w\|_]|-(?!\d))*%?)(?<nextkey>\.%?[A-Za-z]([\w\|_]|-(?!\d))*%?(\(.+?\))?)+(?!.*?#>)")
            Dim sPrevious As String = ""
            Dim iStartAt As Integer = 0

            While iStartAt < sText.Length AndAlso re.IsMatch(sText, iStartAt)  ' AndAlso sText <> sPrevious
                sPrevious = sText

                Dim sMatch As String = re.Match(sText, iStartAt).Value
                Dim bIntValue As Boolean = False
                Dim sReplace As String = ReplaceOOProperty(sMatch, bInt:=bIntValue)
                Dim iPrevStart As Integer = iStartAt
                iStartAt = re.Match(sText, iStartAt).Index + sMatch.Length

#If Generator Then
                ' Replace functions with simple values, so that validation works on them ok (e.g. when typing an expression into an expression box, so we know it's a valid int etc)
                If sReplace = "#*!~#" Then
                    For Each p As clsProperty In Adventure.htblAllProperties.Values
                        If sMatch.EndsWith("." & p.Key) Then
                            Select Case p.Type
                                Case clsProperty.PropertyTypeEnum.Integer
                                    sReplace = "0"
                            End Select
                        End If
                    Next
                End If
#End If

                If sReplace <> "#*!~#" Then
                    If sReplace.Contains(sMatch) Then sReplace = sReplace.Replace(sMatch, "*** RECURSIVE REPLACE ***")
                    If bExpression AndAlso Not bIntValue AndAlso Not Contains(sText, """" & sMatch & """", , iPrevStart + 1) Then sReplace = """" & sReplace & """"
                    sText = sText.Substring(0, iPrevStart) & Replace(sText, sMatch, sReplace, iPrevStart + 1, 1) 'sText = sText.Replace(sMatch, sReplace)
                    iStartAt += sReplace.Length - sMatch.Length
                End If

            End While

            Return ReplaceFunctions(sText, , False)
        End If

    End Function


    Private Function ReplaceOOProperty(ByVal sProperty As String, Optional ByVal ob As clsObject = Nothing, Optional ByVal ch As clsCharacter = Nothing, Optional ByVal loc As clsLocation = Nothing, Optional ByVal lst As List(Of clsItemWithProperties) = Nothing, Optional ByVal lstDirs As List(Of DirectionsEnum) = Nothing, Optional ByVal evt As clsEvent = Nothing, Optional sPropertyKey As String = Nothing, Optional ByRef bInt As Boolean = False) As String

        Dim sFunction As String = sProperty
        Dim sArgs As String = ""
        Dim sRemainder As String = ""

        Dim iIndexOfDot As Integer = sFunction.IndexOf(".")
        Dim iIndexOfOB As Integer = sFunction.IndexOf("(")

        If iIndexOfOB > -1 AndAlso sFunction.Contains(")") Then
            Dim iIndexOfCB As Integer = sFunction.IndexOf(")", iIndexOfOB)
            If iIndexOfDot > -1 Then
                If iIndexOfDot < iIndexOfOB Then
                    sRemainder = sFunction.Substring(iIndexOfDot + 1)
                    sFunction = sFunction.Substring(0, iIndexOfDot)
                Else
                    sArgs = sFunction.Substring(iIndexOfOB + 1, iIndexOfCB - iIndexOfOB - 1) '.ToLower
                    sRemainder = sFunction.Substring(iIndexOfCB + 2)
                    sFunction = sFunction.Substring(0, iIndexOfOB)
                End If
            Else
                sArgs = sFunction.Substring(iIndexOfOB + 1, sFunction.LastIndexOf(")") - iIndexOfOB - 1) '.ToLower
                sRemainder = sFunction.Substring(iIndexOfCB + 1)
                sFunction = sFunction.Substring(0, iIndexOfOB)
            End If
        ElseIf iIndexOfDot > 0 Then
            sRemainder = sFunction.Substring(iIndexOfDot + 1)
            sFunction = sFunction.Substring(0, iIndexOfDot)
        End If

        'If sFunction.Contains(".") Then
        '    sFunction = sFunction.Substring(0, sFunction.IndexOf("."))
        '    sRemainder = sProperty.Substring(sProperty.IndexOf(".") + 1)
        'End If
        'If sFunction.Contains("(") AndAlso sFunction.Contains(")") Then
        '    sArgs = sFunction.Substring(sFunction.IndexOf("(") + 1, sFunction.LastIndexOf(")") - sFunction.IndexOf("(") - 1).ToLower
        '    sFunction = sFunction.Substring(0, sFunction.IndexOf("("))
        'End If


        If lst IsNot Nothing OrElse (lstDirs IsNot Nothing AndAlso (sFunction = "List" OrElse sFunction = "Count" OrElse sFunction = "Name" OrElse sFunction = "")) Then
            Select Case sFunction
                Case ""
                    Dim sResult As String = ""
                    If lst IsNot Nothing Then
                        For i As Integer = 0 To lst.Count - 1
                            sResult &= lst(i).Key
                            If i < lst.Count - 1 Then sResult &= "|"
                        Next
                    Else
                        For i As Integer = 0 To lstDirs.Count - 1
                            sResult &= lstDirs(i).ToString
                            If i < lstDirs.Count - 1 Then sResult &= "|"
                        Next
                    End If

                    Return sResult

                Case "Count"
                    If lst IsNot Nothing Then
                        Return lst.Count.ToString
                    ElseIf lstDirs IsNot Nothing Then
                        Return lstDirs.Count.ToString
                    End If
                    bInt = True
                    Return "0"

                Case "Sum"
                    Dim iSum As Integer = 0
                    If lst IsNot Nothing AndAlso sPropertyKey IsNot Nothing Then
                        For Each oItem As clsItemWithProperties In lst
                            If oItem.HasProperty(sPropertyKey) Then
                                iSum += oItem.htblProperties(sPropertyKey).IntData
                            End If
                        Next
                    End If
                    bInt = True
                    Return iSum.ToString

                Case "Description"
                    Dim sResult As String = ""
                    For Each oItem As clsItem In lst
                        pSpace(sResult)
                        Select Case True
                            Case TypeOf oItem Is clsObject
                                sResult &= CType(oItem, clsObject).Description.ToString
                            Case TypeOf oItem Is clsCharacter
                                sResult &= CType(oItem, clsCharacter).Description.ToString
                            Case TypeOf oItem Is clsLocation
                                If CType(oItem, clsLocation).ViewLocation = "" Then
                                    sResult &= "There is nothing of interest here."
                                Else
                                    sResult &= CType(oItem, clsLocation).ViewLocation
                                End If
                        End Select
                    Next
                    Return sResult

                Case "List", "Name"
                    ' List(and) - And separated list - Default
                    ' List(or) - Or separated list
                    Dim sSeparator As String = " and "
                    Dim sArgsTest As String = sArgs.ToLower

                    If sArgsTest.Contains("or") Then sSeparator = " or "
                    If sArgsTest.Contains("rows") Then sSeparator = vbCrLf

                    ' List(definite/the) - List the objects names - Default
                    ' List(indefinite) - List a/an object
                    Dim Article As ArticleTypeEnum = ArticleTypeEnum.Definite
                    If sArgsTest.Contains("indefinite") Then Article = ArticleTypeEnum.Indefinite
                    If sArgsTest.Contains("none") Then Article = ArticleTypeEnum.None

                    ' List(true) - List anything in/on everything in the list (single level) - Default
                    ' List(false) - Do not list anything in/on
                    Dim bListInOn As Boolean = True ' List any objects in or on anything in this list
                    If sFunction = "Name" OrElse sArgsTest.Contains("false") OrElse sArgsTest.Contains("0") Then
                        bListInOn = False
                    End If

                    Dim bForcePronoun As Boolean = False
#If Runner Then
                    Dim ePronoun As PronounEnum = PronounEnum.Subjective
                    If sArgsTest.Contains("none") Then ePronoun = PronounEnum.None
                    If sArgsTest.Contains("force") Then bForcePronoun = True
                    If sArgsTest.Contains("objective") OrElse sArgsTest.Contains("object") OrElse sArgsTest.Contains("target") Then ePronoun = PronounEnum.Objective
                    If sArgsTest.Contains("possessive") OrElse sArgsTest.Contains("possess") Then ePronoun = PronounEnum.Possessive
                    If sArgsTest.Contains("reflective") OrElse sArgsTest.Contains("reflect") Then ePronoun = PronounEnum.Reflective
#Else
                    Dim ePronoun As Boolean = False
#End If

                    Dim sList As String = ""
                    Dim i As Integer = 0
                    If lst IsNot Nothing Then
                        For Each oItem As clsItem In lst
                            i += 1
                            If sSeparator = vbCrLf Then
                                If i > 1 Then sList &= sSeparator
                            Else
                                If i > 1 AndAlso i < lst.Count Then sList &= ", "
                                If lst.Count > 1 AndAlso i = lst.Count Then sList &= sSeparator
                            End If

                            If TypeOf oItem Is clsObject Then
                                sList &= CType(oItem, clsObject).FullName(Article)
                                If bListInOn AndAlso CType(oItem, clsObject).Children(clsObject.WhereChildrenEnum.InsideOrOnObject).Count > 0 Then sList &= ".  " & ChopLast(CType(oItem, clsObject).DisplayObjectChildren)
                            ElseIf TypeOf oItem Is clsCharacter Then
                                ' List(definite/the) - List the objects names - Default
                                ' List(indefinite) - List a/an object
                                Article = ArticleTypeEnum.Indefinite ' opposite default from objects
                                If sArgsTest.Contains("definite") Then Article = ArticleTypeEnum.Definite
                                sList &= CType(oItem, clsCharacter).Name(ePronoun, , , Article, bForcePronoun)
                            ElseIf TypeOf oItem Is clsLocation Then
                                sList &= CType(oItem, clsLocation).ShortDescription.ToString
                            End If
                        Next
                    ElseIf lstDirs IsNot Nothing Then
                        For Each oDir As DirectionsEnum In lstDirs
                            i += 1
                            If i > 1 AndAlso i < lstDirs.Count Then sList &= ", "
                            If lstDirs.Count > 1 AndAlso i = lstDirs.Count Then sList &= sSeparator
                            sList &= LCase(DirectionName(oDir))
                        Next
                    End If
                    If sList = "" Then sList = "nothing"
                    Return sList

                Case "Parent"
                    Dim lstNew As New List(Of clsItemWithProperties)
                    Dim lstKeys As New List(Of String)

                    For Each oItem As clsItemWithProperties In lst
                        Dim sParent As String = oItem.Parent
                        If sParent <> "" Then
                            If Not lstKeys.Contains(sParent) Then
                                Dim oItemNew As clsItemWithProperties = CType(Adventure.dictAllItems(sParent), clsItemWithProperties)
                                lstKeys.Add(sParent)
                                lstNew.Add(oItemNew)
                            End If
                        End If
                    Next

                    If sRemainder <> "" Then
                        Return ReplaceOOProperty(sRemainder, , , , lstNew, bInt:=bInt)
                    End If

                Case "Children"
                    Dim lstNew As New List(Of clsItemWithProperties)

                    For Each oItem As clsItemWithProperties In lst
                        Select Case True
                            Case TypeOf oItem Is clsObject
                                ob = CType(oItem, clsObject)
                                Select Case sArgs.ToLower.Replace(" ", "")
                                    Case "", "all", "onandin", "all,onandin"
                                        For Each oOb As clsObject In ob.Children(clsObject.WhereChildrenEnum.InsideOrOnObject, True).Values
                                            lstNew.Add(oOb)
                                        Next
                                        For Each oCh As clsCharacter In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideOrOnObject).Values
                                            lstNew.Add(oCh)
                                        Next
                                    Case "characters,in"
                                        For Each oCh As clsCharacter In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).Values
                                            lstNew.Add(oCh)
                                        Next
                                    Case "characters,on"
                                        For Each oCh As clsCharacter In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.OnObject).Values
                                            lstNew.Add(oCh)
                                        Next
                                    Case "characters,onandin", "characters"
                                        For Each oCh As clsCharacter In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideOrOnObject).Values
                                            lstNew.Add(oCh)
                                        Next
                                    Case "in"
                                        For Each oOb As clsObject In ob.Children(clsObject.WhereChildrenEnum.InsideObject, True).Values
                                            lstNew.Add(oOb)
                                        Next
                                        For Each oCh As clsCharacter In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).Values
                                            lstNew.Add(oCh)
                                        Next
                                    Case "objects,in"
                                        For Each oOb As clsObject In ob.Children(clsObject.WhereChildrenEnum.InsideObject, True).Values
                                            lstNew.Add(oOb)
                                        Next
                                    Case "objects,on"
                                        For Each oOb As clsObject In ob.Children(clsObject.WhereChildrenEnum.OnObject, True).Values
                                            lstNew.Add(oOb)
                                        Next
                                    Case "objects,onandin", "objects"
                                        For Each oOb As clsObject In ob.Children(clsObject.WhereChildrenEnum.InsideOrOnObject, True).Values
                                            lstNew.Add(oOb)
                                        Next
                                End Select

                            Case TypeOf oItem Is clsCharacter
                                ' No real reason we couldn't give Children from a Character

                        End Select
                    Next

                    If sRemainder <> "" OrElse lstNew.Count > 0 Then
                        Return ReplaceOOProperty(sRemainder, , , , lstNew, bInt:=bInt)
                    End If

                Case "Contents"
                    Dim lstNew As New List(Of clsItemWithProperties)

                    For Each oItem As clsItemWithProperties In lst
                        Select Case True
                            Case TypeOf oItem Is clsObject
                                ob = CType(oItem, clsObject)
                                Select Case sArgs.ToLower
                                    Case "", "all"
                                        For Each oOb As clsObject In ob.Children(clsObject.WhereChildrenEnum.InsideObject, True).Values
                                            lstNew.Add(oOb)
                                        Next
                                        For Each oCh As clsCharacter In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).Values
                                            lstNew.Add(oCh)
                                        Next
                                    Case "characters"
                                        For Each oCh As clsCharacter In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).Values
                                            lstNew.Add(oCh)
                                        Next
                                    Case "objects"
                                        For Each oOb As clsObject In ob.Children(clsObject.WhereChildrenEnum.InsideObject, True).Values
                                            lstNew.Add(oOb)
                                        Next
                                End Select
                        End Select
                    Next

                    'If sRemainder <> "" OrElse lstNew.Count > 0 Then
                    Return ReplaceOOProperty(sRemainder, , , , lstNew, bInt:=bInt)
                    'End If

                Case "Objects"
                    Dim lstNew As New List(Of clsItemWithProperties)

                    For Each oItem As clsItemWithProperties In lst
                        Select Case True
                            Case TypeOf oItem Is clsLocation
                                loc = CType(oItem, clsLocation)
                                For Each obLoc As clsObject In loc.ObjectsInLocation.Values
                                    lstNew.Add(obLoc)
                                Next
                            Case Else
                                TODO()
                        End Select
                    Next

                    Return ReplaceOOProperty(sRemainder, , , , lstNew, bInt:=bInt)

                Case Else
                    If Adventure.htblAllProperties.ContainsKey(sFunction) Then
                        Dim lstNew As New List(Of clsItemWithProperties)
                        Dim lstKeys As New List(Of String)
                        Dim iTotal As Integer = 0
                        Dim sResult As String = ""
                        Dim bIntResult As Boolean = False
                        Dim bPropertyFound As Boolean = False
                        Dim sNewPropertyKey As String = Nothing

                        For Each oItem As clsItemWithProperties In lst
                            If oItem.HasProperty(sFunction) Then
                                bPropertyFound = True
                                Dim p As clsProperty = oItem.GetProperty(sFunction)

                                Dim bValueOK As Boolean = True
                                If sArgs <> "" Then
                                    bValueOK = False
                                    If sArgs.Contains(".") Then sArgs = ReplaceFunctions(sArgs)
                                    If sArgs.Contains("+") OrElse sArgs.Contains("-") Then
                                        Dim sArgsNew As String = EvaluateExpression(sArgs)
                                        If sArgsNew IsNot Nothing Then sArgs = sArgsNew
                                    End If
                                    Select Case p.Type
                                        Case clsProperty.PropertyTypeEnum.ValueList
                                            Dim iCheckValue As Integer = 0
                                            If IsNumeric(sArgs) Then
                                                iCheckValue = SafeInt(sArgs)
                                            Else
                                                If p.ValueList.ContainsKey(sArgs) Then iCheckValue = p.ValueList(sArgs)
                                            End If
                                            bValueOK = p.IntData = iCheckValue
                                            bInt = True
                                        Case clsProperty.PropertyTypeEnum.Integer
                                            Dim iCheckValue As Integer = 0
                                            If IsNumeric(sArgs) Then iCheckValue = SafeInt(sArgs)
                                            bValueOK = p.IntData = iCheckValue
                                            bInt = True
                                        Case clsProperty.PropertyTypeEnum.StateList
                                            bValueOK = p.Value.ToLower = sArgs.ToLower
                                        Case clsProperty.PropertyTypeEnum.SelectionOnly
                                            Select Case sArgs.ToLower
                                                Case "false", "0"
                                                    bValueOK = False
                                                Case Else
                                                    bValueOK = True ' p.Value = "True" ' True
                                            End Select
                                            bInt = True
                                        Case Else
                                            TODO("Property filter check not yet implemented for " & p.Type.ToString)
                                    End Select
                                End If

                                If bValueOK Then
                                    Select Case p.Type
                                        Case clsProperty.PropertyTypeEnum.CharacterKey
                                            Dim chP As clsCharacter = Adventure.htblCharacters(p.Value)
                                            If Not lstKeys.Contains(chP.Key) Then
                                                lstKeys.Add(chP.Key)
                                                lstNew.Add(chP)
                                            End If
                                        Case clsProperty.PropertyTypeEnum.LocationGroupKey
                                            For Each sItem As String In Adventure.htblGroups(p.Value).arlMembers
                                                If Not lstKeys.Contains(sItem) Then
                                                    Dim oItemNew As clsItemWithProperties = CType(Adventure.dictAllItems(sItem), clsItemWithProperties)
                                                    lstKeys.Add(oItemNew.Key)
                                                    lstNew.Add(oItemNew)
                                                End If
                                            Next
                                        Case clsProperty.PropertyTypeEnum.LocationKey
                                            Dim oItemNew As clsItemWithProperties = Adventure.htblLocations(p.Value)
                                            If Not lstKeys.Contains(oItemNew.Key) Then
                                                lstKeys.Add(oItemNew.Key)
                                                lstNew.Add(oItemNew)
                                            End If
                                        Case clsProperty.PropertyTypeEnum.ObjectKey
                                            Dim oItemNew As clsItemWithProperties = Adventure.htblObjects(p.Value)
                                            If Not lstKeys.Contains(oItemNew.Key) Then
                                                lstKeys.Add(oItemNew.Key)
                                                lstNew.Add(oItemNew)
                                            End If
                                        Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList, clsProperty.PropertyTypeEnum.StateList
                                            lstNew.Add(oItem)
                                            sNewPropertyKey = sFunction
                                            bInt = p.Type = clsProperty.PropertyTypeEnum.Integer OrElse p.Type = clsProperty.PropertyTypeEnum.ValueList
                                            'iTotal += p.IntData
                                            'bIntResult = True
                                        Case clsProperty.PropertyTypeEnum.SelectionOnly
                                            ' Selection Only property to further reduce list
                                            lstNew.Add(oItem)
                                            bInt = True
                                        Case clsProperty.PropertyTypeEnum.Text
                                            If sResult <> "" Then
                                                If oItem Is lst(lst.Count - 1) Then sResult &= " and " Else sResult &= ", "
                                            End If
                                            sResult &= p.Value
                                    End Select
                                End If
                            Else
                                If Adventure.htblAllProperties.ContainsKey(sFunction) Then
                                    Dim p As clsProperty = Adventure.htblAllProperties(sFunction)
                                    Dim bValueOK As Boolean = False ' Because this is equiv of arg = (True)
                                    If sArgs <> "" Then
                                        bValueOK = False
                                        If sArgs.Contains(".") Then sArgs = ReplaceFunctions(sArgs)
                                        If sArgs.Contains("+") OrElse sArgs.Contains("-") Then
                                            Dim sArgsNew As String = EvaluateExpression(sArgs)
                                            If sArgsNew IsNot Nothing Then sArgs = sArgsNew
                                        End If
                                        Select Case p.Type
                                            ' Opposite of above, since this item _doesn't_ contain this property
                                            Case clsProperty.PropertyTypeEnum.SelectionOnly
                                                Select Case sArgs.ToLower
                                                    Case "false", "0"
                                                        bValueOK = True
                                                    Case Else
                                                        bValueOK = False
                                                End Select
                                                bInt = True
                                            Case clsProperty.PropertyTypeEnum.StateList
                                                bValueOK = False ' Since we don't have the property
                                            Case Else
                                                TODO("Property filter check not yet implemented for " & p.Type.ToString)
                                        End Select
                                    End If
                                    If bValueOK Then
                                        Select Case p.Type
                                            Case clsProperty.PropertyTypeEnum.SelectionOnly
                                                ' Selection Only property to further reduce list
                                                lstNew.Add(oItem)
                                        End Select
                                    End If
                                End If
                            End If
                        Next

                        If Not bPropertyFound Then
                            Select Case Adventure.htblAllProperties(sFunction).Type
                                Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList
                                    bIntResult = True
                                    bInt = True
                            End Select
                        End If

                        If sRemainder <> "" OrElse (lstNew.Count > 0 AndAlso Not bIntResult) Then
                            Return ReplaceOOProperty(sRemainder, lst:=lstNew, sPropertyKey:=sNewPropertyKey, bInt:=bInt)
                        ElseIf bIntResult Then
                            Return iTotal.ToString
                        Else
                            Return sResult
                        End If
                    End If
            End Select

        ElseIf ob IsNot Nothing Then
            Select Case sFunction
                Case "Adjective", "Prefix"
                    Return ob.Prefix

                Case "Article"
                    Return ob.Article

                Case "Children"
                    Dim lstNew As New List(Of clsItemWithProperties)
                    Select Case sArgs.ToLower.Replace(" ", "")
                        Case "", "all", "onandin", "all,onandin"
                            For Each oOb As clsObject In ob.Children(clsObject.WhereChildrenEnum.InsideOrOnObject, True).Values
                                lstNew.Add(oOb)
                            Next
                            For Each oCh As clsCharacter In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideOrOnObject).Values
                                lstNew.Add(oCh)
                            Next
                        Case "characters,in"
                            For Each oCh As clsCharacter In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).Values
                                lstNew.Add(oCh)
                            Next
                        Case "characters,on"
                            For Each oCh As clsCharacter In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.OnObject).Values
                                lstNew.Add(oCh)
                            Next
                        Case "characters,onandin", "characters"
                            For Each oCh As clsCharacter In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideOrOnObject).Values
                                lstNew.Add(oCh)
                            Next
                        Case "in"
                            For Each oOb As clsObject In ob.Children(clsObject.WhereChildrenEnum.InsideObject, True).Values
                                lstNew.Add(oOb)
                            Next
                            For Each oCh As clsCharacter In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).Values
                                lstNew.Add(oCh)
                            Next
                        Case "objects,in"
                            For Each oOb As clsObject In ob.Children(clsObject.WhereChildrenEnum.InsideObject, True).Values
                                lstNew.Add(oOb)
                            Next
                        Case "objects,on"
                            For Each oOb As clsObject In ob.Children(clsObject.WhereChildrenEnum.OnObject, True).Values
                                lstNew.Add(oOb)
                            Next
                        Case "objects,onandin", "objects"
                            For Each oOb As clsObject In ob.Children(clsObject.WhereChildrenEnum.InsideOrOnObject, True).Values
                                lstNew.Add(oOb)
                            Next
                    End Select
                    'If sRemainder <> "" OrElse lstNew.Count > 0 Then
                    Return ReplaceOOProperty(sRemainder, , , , lstNew, bInt:=bInt)
                    'End If

                Case "Contents"
                    Dim lstNew As New List(Of clsItemWithProperties)
                    Select Case sArgs.ToLower
                        Case "", "all"
                            For Each oOb As clsObject In ob.Children(clsObject.WhereChildrenEnum.InsideObject, True).Values
                                lstNew.Add(oOb)
                            Next
                            For Each oCh As clsCharacter In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).Values
                                lstNew.Add(oCh)
                            Next
                        Case "characters"
                            For Each oCh As clsCharacter In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).Values
                                lstNew.Add(oCh)
                            Next
                        Case "objects"
                            For Each oOb As clsObject In ob.Children(clsObject.WhereChildrenEnum.InsideObject, True).Values
                                lstNew.Add(oOb)
                            Next
                    End Select
                    'If sRemainder <> "" OrElse lstNew.Count > 0 Then
                    Return ReplaceOOProperty(sRemainder, , , , lstNew, bInt:=bInt)
                    'End If

                Case "Count"
                    bInt = True
                    Return "1"

                Case "Description"
                    Return ob.Description.ToString

                Case "Location"
                    Dim lstNew As New List(Of clsItemWithProperties)
                    For Each sLocKey As String In ob.LocationRoots.Keys
                        Dim oLoc As clsLocation = Adventure.htblLocations(sLocKey)
                        lstNew.Add(oLoc)
                    Next
                    'If sRemainder <> "" Then
                    Return ReplaceOOProperty(sRemainder, , , , lstNew, bInt:=bInt)
                    'End If

                Case "Name", "List"
                    ' Name(definite/the) - List the objects names - Default
                    ' Name(indefinite) - List a/an object
                    Dim Article As ArticleTypeEnum = ArticleTypeEnum.Definite
                    If sArgs.ToLower.Contains("indefinite") Then Article = ArticleTypeEnum.Indefinite
                    If sArgs.ToLower.Contains("none") Then Article = ArticleTypeEnum.None

                    Return ob.FullName(Article)

                Case "Noun"
                    Return ob.arlNames(0)

                Case "Parent"
                    Dim sParent As String = ob.Parent
                    Dim oParentOb As clsObject = Nothing
                    Dim oParentCh As clsCharacter = Nothing
                    Dim oParentLoc As clsLocation = Nothing
                    Adventure.htblObjects.TryGetValue(sParent, oParentOb)
                    Adventure.htblCharacters.TryGetValue(sParent, oParentCh)
                    Adventure.htblLocations.TryGetValue(sParent, oParentLoc)
                    Return ReplaceOOProperty(sRemainder, oParentOb, oParentCh, oParentLoc, bInt:=bInt)

                Case ""
                    Return ob.Key

                Case Else
                    Dim p As clsProperty = Nothing
                    Dim oOb As clsObject = Nothing
                    Dim oCh As clsCharacter = Nothing
                    Dim oLoc As clsLocation = Nothing
                    Dim lstNew As List(Of clsItemWithProperties) = Nothing

                    If ob.htblProperties.TryGetValue(sFunction, p) Then
                        Select Case p.Type
                            Case clsProperty.PropertyTypeEnum.CharacterKey
                                oCh = Adventure.htblCharacters(p.Value)
                            Case clsProperty.PropertyTypeEnum.LocationGroupKey
                                If lstNew Is Nothing Then lstNew = New List(Of clsItemWithProperties)
                                For Each sItem As String In Adventure.htblGroups(p.Value).arlMembers
                                    Dim oItem As clsItemWithProperties = CType(Adventure.dictAllItems(sItem), clsItemWithProperties)
                                    lstNew.Add(oItem)
                                Next
                            Case clsProperty.PropertyTypeEnum.LocationKey
                                oLoc = Adventure.htblLocations(p.Value)
                            Case clsProperty.PropertyTypeEnum.ObjectKey
                                oOb = Adventure.htblObjects(p.Value)
                            Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList
                                Return p.IntData.ToString
                            Case clsProperty.PropertyTypeEnum.SelectionOnly
                                Return "1"
                            Case clsProperty.PropertyTypeEnum.Text, clsProperty.PropertyTypeEnum.StateList
                                Return p.Value
                        End Select
                    Else
                        If Adventure.htblObjectProperties.ContainsKey(sFunction) Then
                            ' Ok, item doesn't have property.  Give it a default
                            Select Case Adventure.htblObjectProperties(sFunction).Type
                                Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList, clsProperty.PropertyTypeEnum.SelectionOnly
                                    bInt = True
                                    Return "0"
                            End Select
                        End If
                    End If
                    If sRemainder <> "" Then
                        Return ReplaceOOProperty(sRemainder, oOb, oCh, oLoc, lstNew, bInt:=bInt)
                    ElseIf oLoc IsNot Nothing Then
                        Return oLoc.Key
                    ElseIf oOb IsNot Nothing Then
                        Return oOb.Key
                    ElseIf oCh IsNot Nothing Then
                        Return oCh.Key
                    ElseIf lstNew IsNot Nothing AndAlso lstNew.Count > 0 Then
                        Return ReplaceOOProperty(sRemainder, oOb, oCh, oLoc, lstNew, bInt:=bInt)
                    End If

            End Select

        ElseIf ch IsNot Nothing Then
            Select Case sFunction
                ' Case "Children"
                '   No real reason we couldn't do this.  If we do, remember to add to List above

                Case "Count"
                    bInt = True
                    Return "1"

                Case "Descriptor"
                    Return ch.Descriptor.ToString

                Case "Description"
                    Return ch.Description.ToString

                Case "Exits"
                    Dim lstNew As New List(Of DirectionsEnum)

                    For d As DirectionsEnum = DirectionsEnum.North To DirectionsEnum.NorthWest ' Adventure.iCompassPoints
#If Runner Then
                        If Adventure.Player.HasRouteInDirection(d, False, Adventure.Player.Location.LocationKey) Then
                            lstNew.Add(d)
                        End If
#End If
                    Next
                    Return ReplaceOOProperty(sRemainder, , ch, , , lstNew, bInt:=bInt)

                Case "Held"
                    Dim lstNew As New List(Of clsItemWithProperties)
#If Runner Then
                    Select Case sArgs.ToLower
                        Case "", "true", "1", "-1"
                            For Each obHeld As clsObject In ch.HeldObjects(True).Values
                                lstNew.Add(obHeld)
                            Next
                        Case "false", "0"
                            For Each obHeld As clsObject In ch.HeldObjects(False).Values
                                lstNew.Add(obHeld)
                            Next
                    End Select
#End If
                    Return ReplaceOOProperty(sRemainder, , ch, , lstNew, bInt:=bInt)

                Case "Location"
                    Dim sLoc As String = ch.Location.LocationKey
                    Dim oLoc As clsLocation = Nothing
                    Adventure.htblLocations.TryGetValue(sLoc, oLoc)
                    Return ReplaceOOProperty(sRemainder, , , oLoc, bInt:=bInt)

                Case "Name"
                    Dim bForcePronoun As Boolean = False

                    Dim bTheNames As Boolean = False ' opposite default from objects
                    Dim Article As ArticleTypeEnum = ArticleTypeEnum.Definite
                    Dim bExplicitArticle As Boolean = False
#If Runner Then
                    Dim ePronoun As PronounEnum = PronounEnum.Subjective
                    Dim sArgsTest As String = sArgs.ToLower

                    If sArgsTest.Contains("none") Then
                        ' Could mean either article or pronoun
                        If sArgsTest.Contains("definite") OrElse sArgsTest.Contains("indefinite") Then
                            ePronoun = PronounEnum.None
                        ElseIf sArgsTest.Contains("force") OrElse sArgsTest.Contains("objective") OrElse sArgsTest.Contains("possessive") OrElse sArgsTest.Contains("reflective") Then
                            Article = ArticleTypeEnum.None
                        Else
                            ' If only None is specified, assume they mean pronouns, as less likely they'll disable articles on character names
                            ePronoun = PronounEnum.None
                        End If
                    End If
                    If sArgsTest.Contains("force") Then bForcePronoun = True
                    If sArgsTest.Contains("objective") OrElse sArgsTest.Contains("object") OrElse sArgsTest.Contains("target") Then ePronoun = PronounEnum.Objective
                    If sArgsTest.Contains("possessive") OrElse sArgsTest.Contains("possess") Then ePronoun = PronounEnum.Possessive
                    If sArgsTest.Contains("reflective") OrElse sArgsTest.Contains("reflect") Then ePronoun = PronounEnum.Reflective
                    'If sArgsTest.Contains("definite") Then Article = ArticleTypeEnum.Definite
                    If ContainsWord(sArgsTest, "definite") Then
                        Article = ArticleTypeEnum.Definite
                        bExplicitArticle = True
                    End If
                    If ContainsWord(sArgsTest, "indefinite") Then
                        Article = ArticleTypeEnum.Indefinite
                        bExplicitArticle = True
                    End If
#Else
                    Dim ePronoun As Boolean = False
#End If
                    ' List(definite/the) - List the objects names - Default
                    ' List(indefinite) - List a/an object

                    Return ch.Name(ePronoun, , , Article, bForcePronoun, bExplicitArticle)

                Case "Parent"
                    Dim sParent As String = ch.Parent
                    Dim oParentOb As clsObject = Nothing
                    Dim oParentCh As clsCharacter = Nothing
                    Dim oParentLoc As clsLocation = Nothing
                    Adventure.htblObjects.TryGetValue(sParent, oParentOb)
                    Adventure.htblCharacters.TryGetValue(sParent, oParentCh)
                    Adventure.htblLocations.TryGetValue(sParent, oParentLoc)
                    Return ReplaceOOProperty(sRemainder, oParentOb, oParentCh, oParentLoc, bInt:=bInt)

                Case "ProperName"
                    Return ch.ProperName

                Case "Worn"
                    Dim lstNew As New List(Of clsItemWithProperties)
#If Runner Then
                    Select Case sArgs.ToLower
                        Case "", "true", "1", "-1"
                            For Each obWorn As clsObject In ch.WornObjects(True).Values
                                lstNew.Add(obWorn)
                            Next
                        Case "false", "0"
                            For Each obWorn As clsObject In ch.WornObjects(False).Values
                                lstNew.Add(obWorn)
                            Next
                    End Select
#End If
                    Return ReplaceOOProperty(sRemainder, , ch, , lstNew, bInt:=bInt)

                Case "WornAndHeld"
                    Dim lstNew As New List(Of clsItemWithProperties)
#If Runner Then
                    Select Case sArgs.ToLower
                        Case "", "true", "1", "-1"
                            For Each obWorn As clsObject In ch.WornObjects(True).Values
                                lstNew.Add(obWorn)
                            Next
                            For Each obHeld As clsObject In ch.HeldObjects(True).Values
                                lstNew.Add(obHeld)
                            Next
                        Case "false", "0"
                            For Each obWorn As clsObject In ch.WornObjects(False).Values
                                lstNew.Add(obWorn)
                            Next
                            For Each obHeld As clsObject In ch.HeldObjects(False).Values
                                lstNew.Add(obHeld)
                            Next
                    End Select
#End If
                    Return ReplaceOOProperty(sRemainder, , ch, , lstNew, bInt:=bInt)

                Case ""
                    Return ch.Key

                Case Else
                    Dim p As clsProperty = Nothing
                    Dim oOb As clsObject = Nothing
                    Dim oCh As clsCharacter = Nothing
                    Dim oLoc As clsLocation = Nothing
                    Dim lstNew As List(Of clsItemWithProperties) = Nothing

                    If ch.htblProperties.TryGetValue(sFunction, p) Then
                        Select Case p.Type
                            Case clsProperty.PropertyTypeEnum.CharacterKey
                                oCh = Adventure.htblCharacters(p.Value)
                            Case clsProperty.PropertyTypeEnum.LocationGroupKey
                                lstNew = New List(Of clsItemWithProperties)
                                For Each sItem As String In Adventure.htblGroups(p.Value).arlMembers
                                    Dim oItem As clsItemWithProperties = CType(Adventure.dictAllItems(sItem), clsItemWithProperties)
                                    lstNew.Add(oItem)
                                Next
                            Case clsProperty.PropertyTypeEnum.LocationKey
                                oLoc = Adventure.htblLocations(p.Value)
                            Case clsProperty.PropertyTypeEnum.ObjectKey
                                oOb = Adventure.htblObjects(p.Value)
                            Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList
                                bInt = True
                                Return p.IntData.ToString
                            Case clsProperty.PropertyTypeEnum.SelectionOnly
                                bInt = True
                                Return "1"
                            Case clsProperty.PropertyTypeEnum.Text, clsProperty.PropertyTypeEnum.StateList
                                Return p.Value
                        End Select
                    Else
                        If Adventure.htblCharacterProperties.ContainsKey(sFunction) Then
                            ' Ok, item doesn't have property.  Give it a default
                            Select Case Adventure.htblCharacterProperties(sFunction).Type
                                Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList, clsProperty.PropertyTypeEnum.SelectionOnly
                                    Return "0"
                            End Select
                        End If
                        '' Ok, item doesn't have property.  Give it a default
                        'If Adventure.htblAllProperties.TryGetValue(sNextKey, p) Then
                        '    Select Case p.Type
                        '        Case clsProperty.PropertyTypeEnum.CharacterKey, clsProperty.PropertyTypeEnum.LocationGroupKey, clsProperty.PropertyTypeEnum.LocationKey, clsProperty.PropertyTypeEnum.ObjectKey
                        '            bList = True
                        '        Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList
                        '            bReturnInt = True
                        '        Case clsProperty.PropertyTypeEnum.SelectionOnly
                        '            bReturnInt = True
                        '        Case clsProperty.PropertyTypeEnum.Text, clsProperty.PropertyTypeEnum.StateList
                        '    End Select
                        '    Else
                        '    ' Duff property
                        'End If
                    End If
                    If sRemainder <> "" Then
                        Return ReplaceOOProperty(sRemainder, oOb, oCh, oLoc, lstNew, bInt:=bInt)
                    ElseIf oLoc IsNot Nothing Then
                        Return oLoc.Key
                    ElseIf oOb IsNot Nothing Then
                        Return oOb.Key
                    ElseIf oCh IsNot Nothing Then
                        Return oCh.Key
                    ElseIf lstNew IsNot Nothing AndAlso lstNew.Count > 0 Then
                        Return ReplaceOOProperty(sRemainder, oOb, oCh, oLoc, lstNew, bInt:=bInt)
                    End If

            End Select

        ElseIf loc IsNot Nothing Then
            Select Case sFunction
                Case "Characters"
                    Dim lstNew As New List(Of clsItemWithProperties)
                    For Each chLoc As clsCharacter In loc.CharactersVisibleAtLocation.Values
                        lstNew.Add(chLoc)
                    Next
                    Return ReplaceOOProperty(sRemainder, , , , lstNew, bInt:=bInt)

                Case "Contents"
                    Dim lstNew As New List(Of clsItemWithProperties)
                    Select Case sArgs.ToLower
                        Case "", "all"
                            For Each oOb As clsObject In loc.ObjectsInLocation.Values
                                lstNew.Add(oOb)
                            Next
                            For Each oCh As clsCharacter In loc.CharactersDirectlyInLocation.Values
                                lstNew.Add(oCh)
                            Next
                        Case "characters"
                            For Each oCh As clsCharacter In loc.CharactersDirectlyInLocation.Values
                                lstNew.Add(oCh)
                            Next
                        Case "objects"
                            For Each oOb As clsObject In loc.ObjectsInLocation.Values
                                lstNew.Add(oOb)
                            Next
                    End Select
                    Return ReplaceOOProperty(sRemainder, , , , lstNew, bInt:=bInt)

                Case "Count"
                    bInt = True
                    Return "1"

                Case "Description", LONGLOCATIONDESCRIPTION
                    Dim sResult As String = loc.ViewLocation
                    If sResult = "" Then sResult = "There is nothing of interest here."
                    Return sResult

                Case "Exits"
                    Dim lstNew As New List(Of DirectionsEnum)

                    For d As DirectionsEnum = DirectionsEnum.North To DirectionsEnum.NorthWest ' Adventure.iCompassPoints
#If Runner Then
                        If loc.arlDirections(d).LocationKey <> "" Then
                            lstNew.Add(d)
                        End If
#End If
                    Next
                    Return ReplaceOOProperty(sRemainder, , ch, , , lstNew, bInt:=bInt)

                Case "LocationTo"
                    Dim lstNew As New List(Of clsItemWithProperties)
                    Dim locTo As clsLocation = Nothing

                    For Each sDir As String In sArgs.ToLower.Split("|"c)
                        For Each d As DirectionsEnum In [Enum].GetValues(GetType(DirectionsEnum))
                            If sDir = d.ToString.ToLower Then
                                Dim sLocTo As String = loc.arlDirections(d).LocationKey
                                If sLocTo IsNot Nothing Then
                                    locTo = Nothing
                                    Adventure.htblLocations.TryGetValue(sLocTo, locTo)
                                    If locTo IsNot Nothing Then                                      
                                        lstNew.Add(locTo)
                                    End If
                                End If
                                Exit For
                            End If
                        Next
                    Next

                    If lstNew.Count = 1 Then
                        locTo = CType(lstNew(0), clsLocation)
                        lstNew = Nothing
                    End If
                    Return ReplaceOOProperty(sRemainder, , , locTo, lstNew, bInt:=bInt)
                    'Dim sLocTo As String = ""

                    'For Each d As DirectionsEnum In [Enum].GetValues(GetType(DirectionsEnum))
                    '    If sArgs.ToLower = d.ToString.ToLower Then
                    '        sLocTo = loc.arlDirections(d).LocationKey
                    '        If sLocTo Is Nothing Then sLocTo = ""
                    '        Exit For
                    '    End If
                    'Next

                    'Dim locTo As clsLocation = Nothing
                    'Adventure.htblLocations.TryGetValue(sLocTo, locTo)
                    'If locTo IsNot Nothing Then
                    '    Return ReplaceOOProperty(sRemainder, , , locTo)
                    'Else
                    '    Return ""
                    'End If

                Case "Name", SHORTLOCATIONDESCRIPTION
                    Return loc.ShortDescription.ToString

                Case "Objects"
                    Dim lstNew As New List(Of clsItemWithProperties)
                    For Each obLoc As clsObject In loc.ObjectsInLocation.Values
                        lstNew.Add(obLoc)
                    Next
                    Return ReplaceOOProperty(sRemainder, , , , lstNew, bInt:=bInt)

                Case ""
                    Return loc.Key

                Case Else
                    Dim p As clsProperty = Nothing
                    Dim oOb As clsObject = Nothing
                    Dim oCh As clsCharacter = Nothing
                    Dim oLoc As clsLocation = Nothing
                    Dim lstNew As List(Of clsItemWithProperties)

                    If loc.htblProperties.TryGetValue(sFunction, p) Then
                        Select Case p.Type
                            Case clsProperty.PropertyTypeEnum.CharacterKey
                                oCh = Adventure.htblCharacters(p.Value)
                            Case clsProperty.PropertyTypeEnum.LocationGroupKey
                                lstNew = New List(Of clsItemWithProperties)
                                For Each sItem As String In Adventure.htblGroups(p.Value).arlMembers
                                    Dim oItem As clsItemWithProperties = CType(Adventure.dictAllItems(sItem), clsItemWithProperties)
                                    lstNew.Add(oItem)
                                Next
                            Case clsProperty.PropertyTypeEnum.LocationKey
                                oLoc = Adventure.htblLocations(p.Value)
                            Case clsProperty.PropertyTypeEnum.ObjectKey
                                oOb = Adventure.htblObjects(p.Value)
                            Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList
                                bInt = True
                                Return p.IntData.ToString
                            Case clsProperty.PropertyTypeEnum.SelectionOnly
                                bInt = True
                                Return "1"
                            Case clsProperty.PropertyTypeEnum.Text, clsProperty.PropertyTypeEnum.StateList
                                Return p.Value
                        End Select
                    Else
                        If Adventure.htblLocationProperties.ContainsKey(sFunction) Then
                            ' Ok, item doesn't have property.  Give it a default
                            Select Case Adventure.htblLocationProperties(sFunction).Type
                                Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList, clsProperty.PropertyTypeEnum.SelectionOnly
                                    Return "0"
                            End Select
                        End If
                    End If
                    If sRemainder <> "" Then
                        Return ReplaceOOProperty(sRemainder, oOb, oCh, oLoc, lstNew, bInt:=bInt)
                    ElseIf oLoc IsNot Nothing Then
                        Return oLoc.Key
                    ElseIf oOb IsNot Nothing Then
                        Return oOb.Key
                    ElseIf oCh IsNot Nothing Then
                        Return oCh.Key
                    ElseIf lstNew.Count > 0 Then
                        Return ReplaceOOProperty(sRemainder, oOb, oCh, oLoc, lstNew, bInt:=bInt)
                    End If

            End Select

        ElseIf evt IsNot Nothing Then
            Select Case sFunction
                Case "Length"
                    Return evt.Length.Value.ToString
#If Runner Then
                Case "Position"
                    Return evt.TimerFromStartOfEvent.ToString
#End If
                Case ""
                    Return evt.Key

            End Select

        Else
            If sFunction.Contains("|") Then
                Dim lstNew As New List(Of clsItemWithProperties)
                For Each sItem As String In sFunction.Split("|"c)
                    Dim oItem As clsItemWithProperties = CType(Adventure.dictAllItems(sItem), clsItemWithProperties)
                    lstNew.Add(oItem)
                Next
                Return ReplaceOOProperty(sRemainder, , , , lstNew, bInt:=bInt)
            Else
                If Adventure.AllKeys.Contains(sFunction) Then
                    Dim lstNew As List(Of clsItemWithProperties) = Nothing
                    If Adventure.htblObjects.ContainsKey(sFunction) Then
                        ob = Adventure.htblObjects(sFunction)
                    ElseIf Adventure.htblCharacters.ContainsKey(sFunction) Then
                        ch = Adventure.htblCharacters(sFunction)
                    ElseIf Adventure.htblLocations.ContainsKey(sFunction) Then
                        loc = Adventure.htblLocations(sFunction)
                    ElseIf Adventure.htblEvents.ContainsKey(sFunction) Then
                        evt = Adventure.htblEvents(sFunction)
                    ElseIf Adventure.htblGroups.ContainsKey(sFunction) Then
                        Dim grp As clsGroup = Adventure.htblGroups(sFunction)
                        lstNew = New List(Of clsItemWithProperties)
                        For Each sMember As String In grp.arlMembers
                            Dim itm As clsItemWithProperties = CType(Adventure.dictAllItems(sMember), clsItemWithProperties)
                            lstNew.Add(itm)
                        Next
                    End If

                    Return ReplaceOOProperty(sRemainder, ob, ch, loc, lstNew, , evt, bInt:=bInt)
                Else
                    For Each d As DirectionsEnum In [Enum].GetValues(GetType(DirectionsEnum))
                        If d.ToString = sFunction Then
                            Dim NewDir As New List(Of DirectionsEnum)
                            NewDir.Add(d)
                            Return ReplaceOOProperty(sRemainder, lstDirs:=NewDir, bInt:=bInt)
                        End If
                    Next
                End If
            End If
        End If

        Return "#*!~#"

    End Function

#If 0 Then
    Private Function ReplaceOOPropertyOld(ByVal lstKeys As StringArrayList, ByVal sProperty As String, ByVal bList As Boolean) As String

        Dim sResults As New System.Text.StringBuilder
        Dim iResult As Integer = 0
        Dim bReturnInt As Boolean = False
        Dim sAppend As New System.Text.StringBuilder
        Dim re As New System.Text.RegularExpressions.Regex("(?<nextkey>[A-Za-z]([\w\|_-])*(\([A-Za-z ,]+?\))?)(?<followingkeys>\.[A-Za-z]([\w\|_-])*(\([A-Za-z ,]+?\))?)*")
        Dim sMatch As String = ""
        Dim sNextKey As String = ""
        Dim lstSubKeys As New StringArrayList

        If re.IsMatch(sProperty) Then
            sMatch = re.Match(sProperty).Value
            sNextKey = re.Match(sProperty).Groups("nextkey").Value
        End If

        For Each sKey As String In lstKeys
            'Dim re As New System.Text.RegularExpressions.Regex("(?<nextkey>[A-Za-z]([\w\|_-])*(\([A-Za-z ,]+?\))?)(?<followingkeys>\.[A-Za-z]([\w\|_-])*(\([A-Za-z ,]+?\))?)*")
            If sMatch <> "" Then ' re.IsMatch(sProperty) Then
                'Dim sMatch As String = re.Match(sProperty).Value
                'Dim sNextKey As String = re.Match(sProperty).Groups("nextkey").Value
                'Dim lstSubKeys As New StringArrayList
                '        Dim bList As Boolean = False

                Dim item As clsItemWithProperties = Nothing
                Dim ob As clsObject = Nothing
                Dim ch As clsCharacter = Nothing
                Dim loc As clsLocation = Nothing

                If Adventure.htblObjects.TryGetValue(sKey, ob) Then
                    item = ob
                Else
                    If Adventure.htblCharacters.TryGetValue(sKey, ch) Then
                        item = ch
                    Else
                        If Adventure.htblLocations.TryGetValue(sKey, loc) Then
                            item = loc
                        End If
                    End If
                End If

                Dim sFunction As String = sNextKey.Replace(" ", "")
                Dim sArgs As String = ""
                If sFunction.Contains("(") AndAlso sFunction.Contains(")") Then
                    If sFunction.LastIndexOf(")") > sFunction.IndexOf("(") Then
                        sArgs = sFunction
                        sArgs = sArgs.Substring(sArgs.IndexOf("(") + 1, sArgs.LastIndexOf(")") - sArgs.IndexOf("(") - 1).ToLower
                    End If
                    sFunction = sFunction.Substring(0, sFunction.Length - sArgs.Length - 2)
                End If

                Select Case sFunction
                    Case "Children"
                        bList = True
                        If ob IsNot Nothing Then
                            Select Case sArgs
                                Case "", "all", "onandin", "all,onandin"
                                    For Each sChild As String In ob.Children(clsObject.WhereChildrenEnum.InsideOrOnObject, True).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                    For Each sChild As String In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideOrOnObject).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                Case "characters,in"
                                    For Each sChild As String In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                Case "characters,on"
                                    For Each sChild As String In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.OnObject).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                Case "characters,onandin"
                                    For Each sChild As String In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideOrOnObject).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                Case "in"
                                    For Each sChild As String In ob.Children(clsObject.WhereChildrenEnum.InsideObject, True).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                    For Each sChild As String In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                Case "objects,in"
                                    For Each sChild As String In ob.Children(clsObject.WhereChildrenEnum.InsideObject, True).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                Case "objects,on"
                                    For Each sChild As String In ob.Children(clsObject.WhereChildrenEnum.OnObject, True).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                Case "objects,onandin", "objects"
                                    For Each sChild As String In ob.Children(clsObject.WhereChildrenEnum.InsideOrOnObject, True).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                            End Select
                        End If

                    Case "Contents"
                        bList = True
                        If ob IsNot Nothing Then
                            Select Case sArgs
                                Case "", "all"
                                    For Each sChild As String In ob.Children(clsObject.WhereChildrenEnum.InsideObject, True).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                    For Each sChild As String In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                Case "characters"
                                    For Each sChild As String In ob.ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                Case "objects"
                                    For Each sChild As String In ob.Children(clsObject.WhereChildrenEnum.InsideObject, True).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                            End Select
                        ElseIf loc IsNot Nothing Then
                            Select Case sArgs
                                Case "", "all"
                                    For Each sChild As String In loc.ObjectsInLocation.Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                    For Each sChild As String In loc.CharactersDirectlyInLocation.Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                Case "characters"
                                    For Each sChild As String In loc.CharactersDirectlyInLocation.Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                Case "objects"
                                    For Each sChild As String In loc.ObjectsInLocation.Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                            End Select
                        End If

                    Case "Count"
                        iResult += 1
                        bReturnInt = True

                    Case "Description", LONGLOCATIONDESCRIPTION
                        If ob IsNot Nothing Then
                            sResults.Append(ob.Description.ToString)
                        ElseIf ch IsNot Nothing Then
                            sResults.Append(ch.Description.ToString)
                        ElseIf loc IsNot Nothing Then
                            Dim sResult As String = loc.ViewLocation
                            If sResult = "" Then sResult = "There is nothing of interest here."
                            sResults.Append(sResult)
                        End If

                    Case "Exits"
#If Runner Then
                        If loc IsNot Nothing Then
                            For d As DirectionsEnum = DirectionsEnum.North To DirectionsEnum.NorthWest ' Adventure.iCompassPoints
                                If Adventure.Player.HasRouteInDirection(d, False, Adventure.Player.Location.LocationKey) Then
                                    lstSubKeys.Add(d.ToString)
                                End If
                            Next
                        End If
#End If
                    Case "Held"
#If Runner Then
                        If ch IsNot Nothing Then
                            Select Case sArgs
                                Case "", "true", "1", "-1"
                                    For Each sChild As String In ch.HeldObjects(True).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                Case "false", "0"
                                    For Each sChild As String In ch.HeldObjects(False).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                            End Select

                        End If
#End If

                    Case "Name", "List" ', "List(Or)", "List(True)", "List(1)", "List(False)", "List(0)"                            
                        ' List(and) - And separated list - Default
                        ' List(or) - Or separated list
                        Dim sSeparator As String = " and "
                        If sArgs.Contains("or") Then sSeparator = " or "

                        ' List(definite/the) - List the objects names - Default
                        ' List(indefinite) - List a/an object
                        Dim bTheNames As Boolean = True
                        If sArgs.Contains("indefinite") Then bTheNames = False

                        ' List(true) - List anything in/on everything in the list (single level) - Default
                        ' List(false) - Do not list anything in/on
                        Dim bListInOn As Boolean = True ' List any objects in or on anything in this list
                        If sFunction = "Name" OrElse sArgs.Contains("false") OrElse sArgs.Contains("0") Then
                            bListInOn = False
                        End If

                        If lstKeys.Count > 1 AndAlso sResults.ToString <> "" Then
                            If sKey = lstKeys(lstKeys.Count - 1) Then sResults.Append(sSeparator) Else sResults.Append(", ")
                        End If
                        If ob IsNot Nothing Then
                            sResults.Append(ob.FullName(bTheNames))
                            If bListInOn AndAlso ob.Children(clsObject.WhereChildrenEnum.InsideOrOnObject).Count > 0 Then sAppend.Append(".  " & ChopLast(ob.DisplayObjectChildren))
                        ElseIf ch IsNot Nothing Then
                            sResults.Append(ch.Name)
                        ElseIf loc IsNot Nothing Then
                            sResults.Append(loc.ShortDescription.ToString)
                        End If

                    Case "Objects"
                        If loc IsNot Nothing Then
                            For Each obLoc As clsObject In loc.ObjectsInLocation.Values
                                lstSubKeys.Add(obLoc.Key)
                            Next
                        End If

                    Case "Parent"
                        If ob IsNot Nothing Then
                            If ob.Parent <> "" Then lstSubKeys.Add(ob.Parent)
                        ElseIf ch IsNot Nothing Then
                            If ch.Parent <> "" Then lstSubKeys.Add(ch.Parent)
                        End If

                    Case "PrevParent"
                        If ob IsNot Nothing Then
                            If ob.Parent <> "" Then lstSubKeys.Add(ob.PrevParent)
                        ElseIf ch IsNot Nothing Then
                            If ch.Parent <> "" Then lstSubKeys.Add(ch.PrevParent)
                        End If

                    Case SHORTLOCATIONDESCRIPTION
                        If loc IsNot Nothing Then sResults.Append(loc.ShortDescription.ToString)

                    Case "Worn" ', "Worn(False)", "Worn(0)", "Worn(True)", "Worn(1)"
#If Runner Then
                        If ch IsNot Nothing Then
                            Select Case sArgs
                                Case "", "true", "1", "-1"
                                    For Each sChild As String In ch.WornObjects(True).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                Case "false", "0"
                                    For Each sChild As String In ch.WornObjects(False).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                            End Select
                            If lstSubKeys.Count = 0 Then
                                sResults.Append("nothing")
                            End If
                        End If
#End If

                    Case "WornAndHeld" ', "Worn(False)", "Worn(0)", "Worn(True)", "Worn(1)"
#If Runner Then
                        If ch IsNot Nothing Then
                            Select Case sArgs
                                Case "", "true", "1", "-1"
                                    For Each sChild As String In ch.WornObjects(True).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                    For Each sChild As String In ch.HeldObjects(True).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                Case "false", "0"
                                    For Each sChild As String In ch.WornObjects(False).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                                    For Each sChild As String In ch.HeldObjects(False).Keys
                                        lstSubKeys.Add(sChild)
                                    Next
                            End Select
                            If lstSubKeys.Count = 0 Then
                                sResults.Append("nothing")
                            End If
                        End If
#End If

                    Case Else
                        If item IsNot Nothing Then
                            Dim p As clsProperty = Nothing
                            If item.htblProperties.TryGetValue(sNextKey, p) Then
                                Select Case p.Type
                                    Case clsProperty.PropertyTypeEnum.CharacterKey, clsProperty.PropertyTypeEnum.LocationGroupKey, clsProperty.PropertyTypeEnum.LocationKey, clsProperty.PropertyTypeEnum.ObjectKey
                                        bList = True
                                        lstSubKeys.Add(p.Value)
                                    Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList
                                        iResult += p.IntData
                                        bReturnInt = True
                                    Case clsProperty.PropertyTypeEnum.SelectionOnly
                                        iResult += 1
                                        bReturnInt = True
                                    Case clsProperty.PropertyTypeEnum.Text, clsProperty.PropertyTypeEnum.StateList
                                        If lstKeys.Count > 1 AndAlso sResults.ToString <> "" Then
                                            If sKey = lstKeys(lstKeys.Count - 1) Then sResults.Append(" and ") Else sResults.Append(", ")
                                        End If
                                        sResults.Append(p.Value)
                                End Select
                            Else
                                ' Ok, item doesn't have property.  Give it a default
                                If Adventure.htblAllProperties.TryGetValue(sNextKey, p) Then
                                    Select Case p.Type
                                        Case clsProperty.PropertyTypeEnum.CharacterKey, clsProperty.PropertyTypeEnum.LocationGroupKey, clsProperty.PropertyTypeEnum.LocationKey, clsProperty.PropertyTypeEnum.ObjectKey
                                            bList = True
                                        Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList
                                            bReturnInt = True
                                        Case clsProperty.PropertyTypeEnum.SelectionOnly
                                            bReturnInt = True
                                        Case clsProperty.PropertyTypeEnum.Text, clsProperty.PropertyTypeEnum.StateList
                                    End Select
                                Else
                                    ' Duff property
                                End If
                            End If
                        ElseIf lstKeys.Count > 0 Then
                            Dim p As clsProperty = Nothing
                            If Adventure.htblAllProperties.TryGetValue(sNextKey, p) Then

                            End If
                        End If
                End Select

#If Debug And Runner Then
                If Not bReturnInt AndAlso sMatch = sNextKey AndAlso sResults.ToString = "" AndAlso lstSubKeys.Count = 0 Then
                    TODO(sNextKey)
                End If
#End If

                'If bList AndAlso sMatch = sNextKey Then sMatch &= ".List"

                If sMatch <> sNextKey Then
                    Dim sSubProperty As String = sMatch.Substring(sNextKey.Length + 1)
                    If sSubProperty.Length > 0 Then
                        If lstSubKeys.Count = 0 AndAlso sResults.ToString <> "" Then
                            Return sResults.ToString
                        Else
                            Return ReplaceOOPropertyOld(lstSubKeys, sSubProperty, bList)
                        End If
                    End If
                Else
                    If lstSubKeys.Count > 0 AndAlso sResults.ToString = "" Then
                        For Each sSubKey As String In lstSubKeys
                            If sResults.Length > 0 Then sResults.Append("|")
                            sResults.Append(sSubKey)
                        Next
                    End If
                End If

            End If
        Next

        If sAppend.ToString <> "" Then sResults.Append(sAppend.ToString)

        If lstKeys.Count = 0 Then
            ' We need to work out the datatype
            Select Case sProperty
                Case "Count"
                    bReturnInt = True
                Case "List"
                    bReturnInt = False
                    Return ""
                Case Else
                    If sNextKey <> "" AndAlso sNextKey <> sMatch Then
                        Dim sSubProperty As String = sMatch.Substring(sNextKey.Length + 1)
                        If sSubProperty.Length > 0 Then
                            Return ReplaceOOPropertyOld(lstKeys, sSubProperty, bList)
                        End If
                    Else
                        Dim p As clsProperty = Nothing
                        If Adventure.htblAllProperties.TryGetValue(sProperty, p) Then
                            Select Case p.Type
                                Case clsProperty.PropertyTypeEnum.CharacterKey, clsProperty.PropertyTypeEnum.LocationGroupKey, clsProperty.PropertyTypeEnum.LocationKey, clsProperty.PropertyTypeEnum.ObjectKey
                                    ' Recurse again...
                                Case clsProperty.PropertyTypeEnum.Integer, clsProperty.PropertyTypeEnum.ValueList
                                    bReturnInt = True
                                Case clsProperty.PropertyTypeEnum.StateList, clsProperty.PropertyTypeEnum.Text
                                    bReturnInt = False
                                    Return "#*!~#" ' We don't want to replace Properties of nothing (e.g. notakey.Property)
                            End Select
                        Else
                            Return "#*!~#"
                        End If
                    End If
            End Select
        End If

        If bReturnInt Then
            Return iResult.ToString
        Else
            Return sResults.ToString
        End If

    End Function
#End If


    Private Function SplitArgs(ByVal sArgs As String) As List(Of String)

        Dim lArgs As New List(Of String)
        Dim iLevel As Integer = 0
        Dim sArg As String = ""

        For i As Integer = 0 To sArgs.Length - 1
            Select Case sArgs(i)
                Case ","c
                    If iLevel = 0 Then
                        If sArg <> "" Then lArgs.Add(sArg)
                        sArg = ""
                    Else
                        sArg &= sArgs(i)
                    End If
                Case "("c, "["c
                    iLevel += 1
                    sArg &= sArgs(i)
                Case ")"c, "]"c
                    iLevel -= 1
                    sArg &= sArgs(i)
                Case Else
                    sArg &= sArgs(i)
            End Select
        Next
        If sArg <> "" Then lArgs.Add(sArg)

        Return lArgs

    End Function


    Private Sub EvaluateUDF(ByVal udf As clsUserFunction, ByRef sText As String)

        ' This will need to be a bit more sophisticated once we have arguments...
        Dim re As New System.Text.RegularExpressions.Regex("%" & udf.Name & "(\[.*?\])?%")

        If re.IsMatch(sText) Then
            ' We can't test udf.Output.ToString until we've replaced the parameters below

            ' Test for recursion
            For Each d As SingleDescription In udf.Output
                If d.Description.Contains("%" & udf.Name & If(udf.Arguments.Count = 0, "%", "[")) Then
                    ErrMsg("Recursive User Defined Function - " & udf.Name)
                    Exit Sub
                End If
            Next

            ' Replace each parameter with it's resolved value
            Dim sMatch As String = re.Match(sText).Value
            Dim dOut As Description = udf.Output.Copy

#If Runner Then
                ' Backup existing Refs
                Dim refsCopy As clsNewReference() = UserSession.NewReferences
                Dim refsUDF As clsNewReference() = {}
                Dim iRefNo As Integer = 0
#End If

            If sMatch.Contains("[") AndAlso sMatch.Contains("]") Then
                Dim sArgs As String = sMatch.Substring(sMatch.IndexOf("["c) + 1, sMatch.LastIndexOf("]"c) - sMatch.IndexOf("["c) - 1)

                'Dim sArg() As String = sArgs.Split(","c)
                Dim sArg As List(Of String) = SplitArgs(sArgs)
                Dim i As Integer = 0
                For Each arg As clsUserFunction.Argument In udf.Arguments
                    Dim sEvaluatedArg As String = ReplaceFunctions(sArg(i))

#If Runner Then
                        If sEvaluatedArg.Contains("|") Then ' Means it evaluated to multiple items                            
                            ' Depending on arg type, create an objects parameter, and set the refs
                            Select Case arg.Type
                                Case clsUserFunction.ArgumentType.Object
                                    Dim refOb As New clsNewReference(ReferencesType.Object)
                                    With refOb
                                        For Each sOb As String In sEvaluatedArg.Split("|"c)
                                            Dim itmOb As New clsSingleItem
                                            itmOb.MatchingPossibilities.Add(sOb)
                                            itmOb.bExplicitlyMentioned = True
                                            .Items.Add(itmOb)
                                        Next
                                    End With
                                    'sEvaluatedArg = "%objects%"
                                    ReDim Preserve refsUDF(iRefNo)
                                    refsUDF(iRefNo) = refOb
                                    iRefNo += 1
                            End Select
                        End If
#End If

                    ' Our function argument could be an expression
                    If New System.Text.RegularExpressions.Regex("\d( )*[+-/*^]( )*\d").IsMatch(sEvaluatedArg) Then
                        Dim sExpr As String = EvaluateExpression(sEvaluatedArg)
                        If sExpr IsNot Nothing Then sEvaluatedArg = sExpr
                    End If

                    For Each d As SingleDescription In dOut
                        d.Description = d.Description.Replace("%" & arg.Name & "%", sEvaluatedArg)
                        For Each r As clsRestriction In d.Restrictions
                            If r.sKey1 = "Parameter-" & arg.Name Then r.sKey1 = If(sEvaluatedArg.Contains("|"), "ReferencedObjects", sEvaluatedArg).ToString
                            If r.sKey2 = "Parameter-" & arg.Name Then r.sKey2 = If(sEvaluatedArg.Contains("|"), "ReferencedObjects", sEvaluatedArg).ToString
                        Next
                    Next
                    i += 1
                Next
            End If

#If Runner Then
            UserSession.NewReferences = refsUDF
#End If
            Dim sFunctionResult As String = dOut.ToString
#If Runner Then
            ' Restore Refs
            UserSession.NewReferences = refsCopy
#End If
            sText = ReplaceFunctions(re.Replace(sText, sFunctionResult, 1))            
        End If

    End Sub


    Public Function ReplaceFunctions(ByVal sText As String, Optional ByVal bExpression As Boolean = False, Optional ByVal bAllowOO As Boolean = True) As String

        Try
            Dim dictGUIDs As New Dictionary(Of String, String)
            While sText.Contains("<#")
                Dim iStart As Integer = sText.IndexOf("<#")
                Dim iEnd As Integer = sText.IndexOf("#>", iStart)
                Dim sGUID As String = ":" & System.Guid.NewGuid.ToString & ":"
                Dim sExpression As String = sText.Substring(iStart, iEnd - iStart + 2)
                dictGUIDs.Add(sGUID, sExpression)
                sText = sText.Replace(sExpression, sGUID)
            End While

            For Each udf As clsUserFunction In Adventure.htblUDFs.Values
                EvaluateUDF(udf, sText)
            Next

            If sInstr(sText, "%") > 0 Then

                Dim sCheck As String

                Do
                    sCheck = sText

                    sText = ReplaceIgnoreCase(sText, "%Player%", Adventure.Player.Key)

                    sText = ReplaceIgnoreCase(sText, "%object%", "%object1%")
                    sText = ReplaceIgnoreCase(sText, "%character%", "%character1%")
                    sText = ReplaceIgnoreCase(sText, "%location%", "%location1%")
                    sText = ReplaceIgnoreCase(sText, "%direction%", "%direction1%")
                    sText = ReplaceIgnoreCase(sText, "%item%", "%item1%")
                    sText = ReplaceIgnoreCase(sText, "%text%", "%text1%")
                    sText = ReplaceIgnoreCase(sText, "%number%", "%number1%")

                    'If bExpression Then
                    '    sText = ReplaceIgnoreCase(sText, "%text%", """" & Adventure.sReferencedText & """")
                    'Else
                    '    sText = ReplaceIgnoreCase(sText, "%text%", Adventure.sReferencedText)
                    'End If
                    sText = ReplaceIgnoreCase(sText, "%ConvCharacter%", Adventure.sConversationCharKey)
                    sText = ReplaceIgnoreCase(sText, "%turns%", Adventure.Turns.ToString)
                    Dim sVersion As String = System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString
                    sText = ReplaceIgnoreCase(sText, "%version%", sVersion.Substring(0, 1) & sVersion.Substring(2, 1) & sVersion.Substring(4)) ' .dVersion.ToString)
                    sText = ReplaceIgnoreCase(sText, "%release%", Adventure.BabelTreatyInfo.Stories(0).Releases.Attached.Release.Version.ToString)
                    'sText = ReplaceIgnoreCase(sText, "%room%", Adventure.htblLocations(Adventure.Player.Location.LocationKey).ShortDescription.ToString)

                    If Contains(sText, "%AloneWithChar%") Then
                        Dim sAloneWithChar As String = Adventure.Player.AloneWithChar
                        If sAloneWithChar Is Nothing Then sAloneWithChar = NOCHARACTER
                        sText = ReplaceIgnoreCase(sText, "%AloneWithChar%", sAloneWithChar)
                    End If
                    If sText.Contains("%CharacterName[") Then
                        For Each sPronoun As String In New String() {"subject", "subjective", "personal", "target", "object", "objective", "possessive"}
                            sText = ReplaceIgnoreCase(sText, "%CharacterName[" & sPronoun & "]%", "%CharacterName[%Player%, " & sPronoun & "]%")
                        Next
                    End If
                    sText = ReplaceIgnoreCase(sText, "%CharacterName%", "%CharacterName[%Player%]%") ' Function without args points to Player

#If Runner Then
                    With UserSession
                        If .NewReferences IsNot Nothing Then
                            For iObRef As Integer = 1 To 5
                                If Contains(sText, "%object" & iObRef & "%") Then ' sInstr(sText, "%object" & iObRef & "%") > 0 Then
                                    ' Get the first object reference       
                                    'Dim iActRef As Integer = 0
                                    Dim bQuote As Boolean = bExpression AndAlso Not Contains(sText, "%object" & iObRef & "%.") AndAlso Not Contains(sText, """%object" & iObRef & "%""")
                                    For Each nr As clsNewReference In .NewReferences
                                        If nr.ReferenceType = ReferencesType.Object Then
                                            'iActRef += 1
                                            'nr.ReferenceMatch = "objects" OrElse 
                                            If nr.ReferenceMatch = "object" & iObRef Then ' iActRef = iObRef Then
                                                Dim sObjects As String = ""
                                                For Each itm As clsSingleItem In nr.Items
                                                    If sObjects <> "" Then sObjects &= "|"
                                                    sObjects &= itm.MatchingPossibilities(0)
                                                Next
                                                If bQuote Then sObjects = """" & sObjects & """"
                                                If sObjects <> "" Then sText = ReplaceIgnoreCase(sText, "%object" & iObRef & "%", sObjects)
                                                Exit For
                                            End If
                                        End If
                                    Next
                                End If
                            Next iObRef

                            If Contains(sText, "%objects%") Then
                                ' Get the first object reference            
                                Dim bQuote As Boolean = bExpression AndAlso Not Contains(sText, "%objects%.") AndAlso Not Contains(sText, """%objects%""")
                                For Each nr As clsNewReference In .NewReferences
                                    If nr.ReferenceType = ReferencesType.Object AndAlso nr.ReferenceMatch = "objects" Then ' AndAlso nr.bMultiple Then
                                        Dim sObjects As String = ""
                                        For Each itm As clsSingleItem In nr.Items
                                            If sObjects <> "" Then sObjects &= "|"
                                            sObjects &= itm.MatchingPossibilities(0)
                                        Next
                                        If bQuote Then sObjects = """" & sObjects & """"
                                        If sObjects <> "" Then sText = ReplaceIgnoreCase(sText, "%objects%", sObjects)
                                        Exit For
                                    End If
                                Next
                            End If

                            For iCharRef As Integer = 1 To 5
                                If Contains(sText, "%character" & iCharRef & "%") Then ' sInstr(sText, "%character" & iCharRef & "%") > 0 Then
                                    ' Get the first character reference       
                                    'Dim iActRef As Integer = 0
                                    Dim bQuote As Boolean = bExpression AndAlso Not Contains(sText, "%character" & iCharRef & "%.") AndAlso Not Contains(sText, """%character" & iCharRef & "%""")
                                    For Each nr As clsNewReference In .NewReferences
                                        If nr.ReferenceType = ReferencesType.Character Then
                                            'iActRef += 1
                                            If nr.ReferenceMatch = "character" & iCharRef Then ' iActRef = iCharRef Then
                                                Dim sCharacters As String = ""
                                                For Each itm As clsSingleItem In nr.Items
                                                    If sCharacters <> "" Then sCharacters &= "|"
                                                    sCharacters &= itm.MatchingPossibilities(0)
                                                Next
                                                If bQuote Then sCharacters = """" & sCharacters & """"
                                                If sCharacters <> "" Then sText = ReplaceIgnoreCase(sText, "%character" & iCharRef & "%", sCharacters)
                                                Exit For
                                            End If
                                        End If
                                    Next
                                End If
                            Next iCharRef

                            If Contains(sText, "%characters%") Then
                                ' Get the first character reference 
                                Dim bQuote As Boolean = bExpression AndAlso Not Contains(sText, "%characters%.") AndAlso Not Contains(sText, """%characters%""")
                                For Each nr As clsNewReference In .NewReferences
                                    If nr.ReferenceType = ReferencesType.Character Then ' AndAlso nr.bMultiple Then
                                        Dim sCharacters As String = ""
                                        For Each itm As clsSingleItem In nr.Items
                                            If sCharacters <> "" Then sCharacters &= "|"
                                            sCharacters &= itm.MatchingPossibilities(0)
                                        Next
                                        If bQuote Then sCharacters = """" & sCharacters & """"
                                        If sCharacters <> "" Then sText = ReplaceIgnoreCase(sText, "%characters%", sCharacters)
                                        Exit For
                                    End If
                                Next
                            End If

                            For iLocRef As Integer = 1 To 5
                                If Contains(sText, "%location" & iLocRef & "%") Then
                                    ' Get the first location reference                                           
                                    Dim bQuote As Boolean = bExpression AndAlso Not Contains(sText, "%location" & iLocRef & "%.") AndAlso Not Contains(sText, """%location" & iLocRef & "%""")
                                    For Each nr As clsNewReference In .NewReferences
                                        If nr.ReferenceType = ReferencesType.Location Then
                                            'iActRef += 1
                                            If nr.ReferenceMatch = "location" & iLocRef Then ' iActRef = iLocRef Then
                                                Dim sLocations As String = ""
                                                For Each itm As clsSingleItem In nr.Items
                                                    If sLocations <> "" Then sLocations &= "|"
                                                    sLocations &= itm.MatchingPossibilities(0)
                                                Next
                                                If bQuote Then sLocations = """" & sLocations & """"
                                                If sLocations <> "" Then sText = ReplaceIgnoreCase(sText, "%location" & iLocRef & "%", sLocations)
                                                Exit For
                                            End If
                                        End If
                                    Next
                                End If
                            Next iLocRef

                            For iItemRef As Integer = 1 To 5
                                If Contains(sText, "%item" & iItemRef & "%") Then
                                    ' Get the first item reference       
                                    Dim bQuote As Boolean = bExpression AndAlso Not Contains(sText, "%item" & iItemRef & "%.") AndAlso Not Contains(sText, """%item" & iItemRef & "%""")
                                    For Each nr As clsNewReference In .NewReferences
                                        If nr.ReferenceType = ReferencesType.Item Then
                                            'iActRef += 1
                                            If nr.ReferenceMatch = "item" & iItemRef Then ' iActRef = iItemRef Then
                                                Dim sItems As String = ""
                                                For Each itm As clsSingleItem In nr.Items
                                                    If sItems <> "" Then sItems &= "|"
                                                    sItems &= itm.MatchingPossibilities(0)
                                                Next
                                                If bQuote Then sItems = """" & sItems & """"
                                                If sItems <> "" Then sText = ReplaceIgnoreCase(sText, "%item" & iItemRef & "%", sItems)
                                                Exit For
                                            End If
                                        End If
                                    Next
                                End If
                            Next iItemRef

                            For iDirRef As Integer = 1 To 5
                                If Contains(sText, "%direction" & iDirRef & "%") Then
                                    ' Get the first direction reference       
                                    Dim bQuote As Boolean = bExpression AndAlso Not Contains(sText, "%direction" & iDirRef & "%.") AndAlso Not Contains(sText, """%direction" & iDirRef & "%""")
                                    For Each nr As clsNewReference In .NewReferences
                                        If nr.ReferenceType = ReferencesType.Direction Then
                                            'iActRef += 1
                                            If nr.ReferenceMatch = "direction" & iDirRef Then ' iActRef = iDirRef Then
                                                Dim sDirections As String = ""
                                                For Each itm As clsSingleItem In nr.Items
                                                    If sDirections <> "" Then sDirections &= "|"
                                                    sDirections &= itm.MatchingPossibilities(0)
                                                Next
                                                If bQuote Then sDirections = """" & sDirections & """"
                                                If sDirections <> "" Then sText = ReplaceIgnoreCase(sText, "%direction" & iDirRef & "%", sDirections)
                                                Exit For
                                            End If
                                        End If
                                    Next
                                End If
                            Next iDirRef


                            For i As Integer = 1 To 5
                                Dim iRef As Integer = i '- 1
                                'If iRef > 0 Then iRef -= 1

                                Dim sNumber As String = "%number" & If(i > 0, i.ToString, "").ToString & "%"
                                If Contains(sText, sNumber) Then
                                    Dim bQuote As Boolean = bExpression AndAlso Not Contains(sText, "%number" & If(i > 0, i.ToString, "").ToString & "%.") AndAlso Not Contains(sText, """%number" & If(i > 0, i.ToString, "").ToString & "%""")
                                    For Each ref As clsNewReference In .NewReferences
                                        If ref.ReferenceType = ReferencesType.Number Then
                                            'iNumRef += 1
                                            If ref.ReferenceMatch = "number" & iRef Then ' iNumRef - 1 = iRef Then
                                                'If ref.Items.Count = 1 AndAlso ref.Items(0).MatchingPossibilities.Count = 1 Then
                                                '    sText = ReplaceIgnoreCase(sText, sNumber, ref.Items(0).MatchingPossibilities(0))
                                                'End If
                                                'Exit For
                                                Dim sNumbers As String = ""
                                                For Each itm As clsSingleItem In ref.Items
                                                    If sNumbers <> "" Then sNumbers &= "|"
                                                    sNumbers &= itm.MatchingPossibilities(0)
                                                Next
                                                If bQuote Then sNumbers = """" & sNumbers & """"
                                                If sNumbers <> "" Then sText = ReplaceIgnoreCase(sText, sNumber, sNumbers)
                                                Exit For
                                            End If
                                        End If
                                    Next

                                    'sText = ReplaceIgnoreCase(sText, sNumber, Adventure.iReferencedNumber(iRef).ToString)                                    
                                End If

                                Dim sRefText As String = "%text" & If(i > 0, i.ToString, "").ToString & "%"
                                If Contains(sText, sRefText) Then
                                    Dim bQuote As Boolean = bExpression AndAlso Not Contains(sText, "%text" & If(i > 0, i.ToString, "").ToString & "%.") AndAlso Not Contains(sText, """%text" & If(i > 0, i.ToString, "").ToString & "%""")
                                    For Each ref As clsNewReference In .NewReferences
                                        If ref.ReferenceType = ReferencesType.Text Then
                                            'iTextRef += 1
                                            If ref.ReferenceMatch = "text" & iRef Then ' iTextRef - 1 = iRef Then
                                                If ref.Items.Count = 1 AndAlso ref.Items(0).MatchingPossibilities.Count = 1 Then
                                                    If bExpression Then
                                                        sText = ReplaceIgnoreCase(sText, sRefText, """" & ref.Items(0).MatchingPossibilities(0) & """")
                                                    Else
                                                        sText = ReplaceIgnoreCase(sText, sRefText, ref.Items(0).MatchingPossibilities(0))
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Next                                    
                                    If bQuote Then
                                        sText = ReplaceIgnoreCase(sText, sRefText, """" & Adventure.sReferencedText(iRef) & """")
                                    Else
                                        sText = ReplaceIgnoreCase(sText, sRefText, Adventure.sReferencedText(iRef))
                                    End If
                                End If
                            Next

                        End If
                    End With
#End If

                    For Each var As clsVariable In Adventure.htblVariables.Values
                        If var.Length = 1 Then
                            While InStr(sText, "%" & var.Name & "%", CompareMethod.Text) > 0
                                If var.Type = clsVariable.VariableTypeEnum.Numeric Then
                                    sText = ReplaceIgnoreCase(sText, "%" & var.Name & "%", var.IntValue.ToString) ' sText.Replace("%" & var.Name & "%", var.IntValue.ToString)
                                Else
                                    If bExpression Then
                                        sText = ReplaceIgnoreCase(sText, "%" & var.Name & "%", """" & var.StringValue & """")
                                    Else
                                        sText = ReplaceIgnoreCase(sText, "%" & var.Name & "%", var.StringValue)
                                    End If
                                End If
                            End While
                        ElseIf var.Length > 1 Then
                            While sInstr(sText, "%" & var.Name & "[") > 0
                                Dim iOffset As Integer = sInstr(sText, "%" & var.Name & "[") + var.Name.Length + 1
                                Dim sIndex As String = sText.Substring(iOffset, sText.IndexOf("]"c, iOffset) - iOffset)
                                If IsNumeric(sIndex) Then
                                    If var.Type = clsVariable.VariableTypeEnum.Numeric Then
                                        sText = sText.Replace("%" & var.Name & "[" & sIndex & "]%", var.IntValue(CInt(sIndex)).ToString)
                                    Else
                                        If bExpression Then
                                            sText = sText.Replace("%" & var.Name & "[" & sIndex & "]%", """" & var.StringValue(CInt(sIndex)).ToString & """")
                                        Else
                                            sText = sText.Replace("%" & var.Name & "[" & sIndex & "]%", var.StringValue(CInt(sIndex)).ToString)
                                        End If
                                    End If
                                Else
                                    Dim iIndex As Integer = 0
                                    If IsNumeric(sIndex) Then
                                        iIndex = SafeInt(sIndex)
                                    Else
                                        Dim varIndex As New clsVariable
                                        varIndex.Type = clsVariable.VariableTypeEnum.Numeric
                                        varIndex.SetToExpression(sIndex)
                                        iIndex = varIndex.IntValue
                                    End If
                                    If var.Type = clsVariable.VariableTypeEnum.Numeric Then
                                        sText = sText.Replace("%" & var.Name & "[" & sIndex & "]%", var.IntValue(iIndex).ToString)
                                    Else
                                        If bExpression Then
                                            sText = sText.Replace("%" & var.Name & "[" & sIndex & "]%", """" & var.StringValue(iIndex).ToString & """")
                                        Else
                                            sText = sText.Replace("%" & var.Name & "[" & sIndex & "]%", var.StringValue(iIndex).ToString)
                                        End If
                                    End If
                                End If
                            End While
                        End If
                    Next

                    ' Need this to evaluate text in order, not replace by function order
                    ' This is in case eg. "%DisplayCharacter% %CharacterName%" where DisplayCharacter contains name, then we must evaluate first 
                    ' name first in case we abbreviate, else we'll abbreviate the first name with 'he' instead of the second.
                    '
                    Dim sFirstFunction As String = ""
                    Dim iFirstLocation As Integer = Integer.MaxValue
                    For Each sFunctionCheck As String In FunctionNames()
                        sFunctionCheck = sFunctionCheck.ToLower
                        Dim iMatchCheck As Integer = sInstr(sText.ToLower, "%" & sFunctionCheck & "[")
                        If iMatchCheck > 0 AndAlso iMatchCheck < iFirstLocation Then
                            sFirstFunction = sFunctionCheck
                            iFirstLocation = iMatchCheck
                        End If
                    Next

                    'For Each sFunction As String In FunctionNames()
                    If sFirstFunction <> "" Then
                        'sFunction = sFunction.ToLower
                        Dim sFunction As String = sFirstFunction
                        Dim iMatchLoc As Integer = sInstr(sText.ToLower, "%" & sFunction & "[")
                        While iMatchLoc > 0
                            Dim sArgs As String = GetFunctionArgs(sText.Substring(InStr(sText.ToLower, "%" & sFunction & "[") + sFunction.Length))
                            Dim iArgsLength As Integer = sArgs.Length
                            Dim bFunctionIsArgument As Boolean = (iMatchLoc > 1 AndAlso sText.Substring(iMatchLoc - 2, 1) = "[" AndAlso sText.Substring(iMatchLoc + sFunction.Length + iArgsLength, 2) = "]%")

                            If iArgsLength > 0 OrElse sFunction.ToLower = "sum" Then

                                Dim sOldArgs As String = sArgs
                                sArgs = ReplaceFunctions(sArgs)
                                sText = sText.Substring(0, iMatchLoc - 1) & Replace(sText, sOldArgs, sArgs, iMatchLoc, 1) ' sText.Replace(sOldArgs, sArgs) ' Only replace 1 because subsequent functions could return different values (e.g. CharacterName)

                                If sInstr(sText.ToLower, "%" & sFunction & "[" & sArgs.ToLower & "]%") > 0 Then

                                    Dim bAllowBlank As Boolean = False
                                    Dim sResult As String = ""
                                    Dim htblObjects As New ObjectHashTable
                                    Dim htblCharacters As New CharacterHashTable
                                    Dim htblLocations As New LocationHashTable

                                    If sArgs.Contains("|") Then
                                        ' We've got a pipe-separated list of parent keys                                    
                                        Dim sKeys() As String = sArgs.Split("|"c)
                                        For Each sKey As String In sKeys
                                            If sKey.Contains(",") Then sKey = sLeft(sKey, sInstr(sKey, ",") - 1) ' trim off any other args
                                            If Not htblObjects.ContainsKey(sKey) AndAlso Adventure.htblObjects.ContainsKey(sKey) Then htblObjects.Add(Adventure.htblObjects(sKey), sKey)
                                            If Not htblCharacters.ContainsKey(sKey) AndAlso Adventure.htblCharacters.ContainsKey(sKey) Then htblCharacters.Add(Adventure.htblCharacters(sKey), sKey)
                                            If Not htblLocations.ContainsKey(sKey) AndAlso Adventure.htblLocations.ContainsKey(sKey) Then htblLocations.Add(Adventure.htblLocations(sKey), sKey)
                                        Next
                                    Else
                                        Dim sKey As String = sArgs
                                        If sKey.Contains(",") Then sKey = sLeft(sKey, sInstr(sKey, ",") - 1)
                                        If Not htblObjects.ContainsKey(sKey) AndAlso Adventure.htblObjects.ContainsKey(sKey) Then htblObjects.Add(Adventure.htblObjects(sKey), sKey)
                                        If Not htblCharacters.ContainsKey(sKey) AndAlso Adventure.htblCharacters.ContainsKey(sKey) Then htblCharacters.Add(Adventure.htblCharacters(sKey), sKey)
                                        If Not htblLocations.ContainsKey(sKey) AndAlso Adventure.htblLocations.ContainsKey(sKey) Then htblLocations.Add(Adventure.htblLocations(sKey), sKey)
                                    End If

                                    Select Case sFunction
                                        Case "CharacterDescriptor".ToLower
                                            If Adventure.htblCharacters.ContainsKey(sArgs) Then
                                                ' This needs to be The, depending whether we have referred to them already... :-/
                                                sResult = htblCharacters(sArgs).Descriptor
                                            Else
                                                DisplayError("Bad Argument to &perc;CharacterDescriptor[]&perc; - Character Key """ & sArgs & """ not found")
                                            End If

                                        Case "CharacterName".ToLower
                                            Dim sKeys() As String = Split(sArgs.Replace(" ", ""), ",")
                                            Dim sKey As String = ""
                                            If sKeys.Length > 0 Then sKey = sKeys(0)
#If Runner Then
                                            Dim ePronoun As PronounEnum = PronounEnum.Subjective
                                            If sKeys.Length = 2 Then
                                                Select Case sKeys(1).ToLower
                                                    Case "subject", "subjective", "personal"
                                                        ePronoun = PronounEnum.Subjective
                                                    Case "target", "object", "objective"
                                                        ePronoun = PronounEnum.Objective
                                                    Case "possess", "possessive"
                                                        ePronoun = PronounEnum.Possessive
                                                    Case "none"
                                                        ePronoun = PronounEnum.None
                                                End Select
                                            End If

                                            If htblCharacters.ContainsKey(sKey) Then
                                                sResult = htblCharacters(sKey).Name(ePronoun)
                                                ' Slight fudge - if the name is the start of a sentence, auto-cap it... (consistent with v4)
                                                If iMatchLoc > 3 Then
                                                    If sText.Substring(iMatchLoc - 3, 2) = vbCrLf OrElse sText.Substring(iMatchLoc - 3, 2) = "  " Then
                                                        sResult = PCase(sResult)
                                                    End If
                                                End If

                                                'sResult = AutoCapitalise(sText, sResult, iMatchLoc)
#If Runner Then
                                                'If bDisplaying Then Perspectives.Add(New PerspectiveOffset(iMatchLoc, htblCharacters(sArgs).Perspective))
                                                If UserSession.bDisplaying Then UserSession.PronounKeys.Add(sKey, ePronoun, htblCharacters(sKey).Gender, UserSession.sOutputText.Length + iMatchLoc)
                                                'Select Case htblCharacters(sKey).Gender
                                                '    Case clsCharacter.GenderEnum.Male
                                                '        Select Case ePronoun
                                                '            Case PronounEnum.Objective
                                                '                UserSession.LastObjectiveMalePronoun = sKey
                                                '            Case PronounEnum.Possessive
                                                '                UserSession.LastPossessiveMalePronoun = sKey
                                                '            Case PronounEnum.Reflective
                                                '                UserSession.LastReflectiveMalePronoun = sKey
                                                '            Case PronounEnum.Subjective
                                                '                UserSession.LastSubjectiveMalePronoun = sKey
                                                '        End Select                                                        
                                                '    Case clsCharacter.GenderEnum.Female
                                                '        Select Case ePronoun
                                                '            Case PronounEnum.Objective
                                                '                UserSession.LastObjectiveFemalePronoun = sKey
                                                '            Case PronounEnum.Possessive
                                                '                UserSession.LastPossessiveFemalePronoun = sKey
                                                '            Case PronounEnum.Reflective
                                                '                UserSession.LastReflectiveFemalePronoun = sKey
                                                '            Case PronounEnum.Subjective
                                                '                UserSession.LastSubjectiveFemalePronoun = sKey
                                                '        End Select
                                                '    Case clsCharacter.GenderEnum.Unknown
                                                '        Select Case ePronoun
                                                '            Case PronounEnum.Objective
                                                '                UserSession.LastObjectiveItPronoun = sKey
                                                '            Case PronounEnum.Possessive
                                                '                UserSession.LastPossessiveItPronoun = sKey
                                                '            Case PronounEnum.Reflective
                                                '                UserSession.LastReflectiveItPronoun = sKey
                                                '            Case PronounEnum.Subjective
                                                '                UserSession.LastSubjectiveItPronoun = sKey
                                                '        End Select
                                                'End Select                                                
#End If
                                            ElseIf sKey = NOCHARACTER Then
                                                sResult = "Nobody"
                                            Else
                                                DisplayError("Bad Argument to &perc;CharacterName[]&perc; - Character Key """ & sArgs & """ not found")
                                            End If
#Else
                                            If Adventure.htblCharacters.ContainsKey(sKey) Then
                                                sResult = htblCharacters(sKey).Name()
                                            End If
#End If

                                        Case "CharacterProper".ToLower, "ProperName".ToLower
                                            If Adventure.htblCharacters.ContainsKey(sArgs) Then
                                                sResult = htblCharacters(sArgs).ProperName
                                                'sResult = AutoCapitalise(sText, sResult, iMatchLoc)
                                                '#If Runner Then
                                                '                                            If bDisplaying Then Perspectives.Add(New PerspectiveOffset(iMatchLoc, htblCharacters(sArgs).Perspective))
                                                '#End If

                                            Else
                                                DisplayError("Bad Argument to &perc;CharacterProper[]&perc; - Character Key """ & sArgs & """ not found")
                                            End If

                                        Case "DisplayCharacter".ToLower
                                            If Adventure.htblCharacters.ContainsKey(sArgs) Then
                                                sResult = htblCharacters(sArgs).Description.ToString
                                                If sResult = "" Then sResult = "%CharacterName% see[//s] nothing interesting about %CharacterName[" & sArgs & ", target]%."
                                            Else
                                                DisplayError("Bad Argument to &perc;DisplayCharacter[]&perc; - Character Key """ & sArgs & """ not found")
                                            End If

                                        Case "DisplayLocation".ToLower
                                            If Adventure.htblLocations.ContainsKey(sArgs) Then
                                                sResult = Adventure.htblLocations(sArgs).ViewLocation
                                                If sResult = "" Then sResult = "There is nothing of interest here."
                                            Else
                                                DisplayError("Bad Argument to &perc;DisplayLocation[]&perc; - Location Key """ & sArgs & """ not found")
                                            End If

                                        Case "DisplayObject".ToLower
                                            If Adventure.htblObjects.ContainsKey(sArgs) Then
                                                sResult = htblObjects(sArgs).Description.ToString
                                                If sResult = "" Then sResult = "%CharacterName% see[//s] nothing interesting about " & htblObjects(sArgs).FullName(ArticleTypeEnum.Definite) & "."
                                            Else
                                                DisplayError("Bad Argument to &perc;DisplayObject[]&perc; - Object Key """ & sArgs & """ not found")
                                            End If

                                        Case "Held".ToLower
#If Runner Then
                                            If Adventure.htblCharacters.ContainsKey(sArgs) Then
                                                For Each ob As clsObject In Adventure.htblCharacters(sArgs).HeldObjects.Values
                                                    If sResult <> "" Then sResult &= "|"
                                                    sResult &= ob.Key
                                                Next
                                            Else
                                                DisplayError("Bad Argument to &perc;Held[]&perc; - Character Key """ & sArgs & """ not found")
                                            End If
                                            bAllowBlank = True
#End If
                                        Case "LCase".ToLower
                                            sResult = sArgs.ToLower

                                        Case "ListCharactersOn".ToLower
                                            If Adventure.htblObjects.ContainsKey(sArgs) Then
                                                sResult = Adventure.htblObjects(sArgs).ChildrenCharacters(clsObject.WhereChildrenEnum.OnObject).List()
                                            Else
                                                DisplayError("Bad Argument to &perc;ListCharactersOn[]&perc; - Object Key """ & sArgs & """ not found")
                                            End If

                                        Case "ListCharactersIn".ToLower
                                            If Adventure.htblObjects.ContainsKey(sArgs) Then
                                                sResult = Adventure.htblObjects(sArgs).ChildrenCharacters(clsObject.WhereChildrenEnum.InsideObject).List()
                                            Else
                                                DisplayError("Bad Argument to &perc;ListCharactersIn[]&perc; - Object Key """ & sArgs & """ not found")
                                            End If

                                        Case "ListCharactersOnAndIn".ToLower
                                            If Adventure.htblObjects.ContainsKey(sArgs) Then
                                                sResult = Adventure.htblObjects(sArgs).DisplayCharacterChildren
                                            Else
                                                DisplayError("Bad Argument to &perc;ListCharactersOnAndIn[]&perc; - Object Key """ & sArgs & """ not found")
                                            End If

                                        Case "ListHeld".ToLower
#If Runner Then
                                            If Adventure.htblCharacters.ContainsKey(sArgs) Then
                                                sResult = Adventure.htblCharacters(sArgs).HeldObjects.List(, True, ArticleTypeEnum.Indefinite)
                                            Else
                                                DisplayError("Bad Argument to &perc;ListHeld[]&perc; - Character Key """ & sArgs & """ not found")
                                            End If
#End If
                                        Case "ListExits".ToLower
#If Runner Then
                                            If Adventure.htblCharacters.ContainsKey(sArgs) Then
                                                sResult = Adventure.htblCharacters(sArgs).ListExits
                                            Else
                                                DisplayError("Bad Argument to &perc;ListExits[]&perc; - Character Key """ & sArgs & """ not found")
                                            End If
#End If
                                        Case "ListObjectsAtLocation".ToLower
                                            If Adventure.htblLocations.ContainsKey(sArgs) Then
                                                sResult = Adventure.htblLocations(sArgs).ObjectsInLocation(clsLocation.WhichObjectsToListEnum.AllObjects, True).List(, , ArticleTypeEnum.Indefinite)
                                            Else
                                                DisplayError("Bad Argument to &perc;ListObjectsAtLocation[]&perc; - Location Key """ & sArgs & """ not found")
                                            End If

                                        Case "ListObjectsOn".ToLower
                                            If Adventure.htblObjects.ContainsKey(sArgs) Then
                                                sResult = Adventure.htblObjects(sArgs).Children(clsObject.WhereChildrenEnum.OnObject).List(, , ArticleTypeEnum.Indefinite)
                                            Else
                                                DisplayError("Bad Argument to &perc;ListObjectsOn[]&perc; - Object Key """ & sArgs & """ not found")
                                            End If

                                        Case "ListObjectsIn".ToLower
                                            If Adventure.htblObjects.ContainsKey(sArgs) Then
                                                sResult = Adventure.htblObjects(sArgs).Children(clsObject.WhereChildrenEnum.InsideObject).List(, , ArticleTypeEnum.Indefinite)
                                            Else
                                                DisplayError("Bad Argument to &perc;ListObjectsIn[]&perc; - Object Key """ & sArgs & """ not found")
                                            End If

                                        Case "ListObjectsOnAndIn".ToLower
                                            If htblObjects.Count > 0 Then
                                                For Each ob As clsObject In htblObjects.Values
                                                    If htblObjects.Count = 1 OrElse ob.Children(clsObject.WhereChildrenEnum.InsideOrOnObject).Count > 0 Then
                                                        If sResult <> "" Then pSpace(sResult)
                                                        sResult &= ob.DisplayObjectChildren
                                                    End If
                                                Next
                                            Else
                                                DisplayError("Bad Argument to &perc;ListObjectsOnAndIn[]&perc; - Object Key """ & sArgs & """ not found")
                                            End If
                                            'If Adventure.htblObjects.ContainsKey(sArgs) Then
                                            '    sResult = Adventure.htblObjects(sArgs).DisplayObjectChildren
                                            'Else
                                            '    DisplayError("Bad Argument to &perc;ListObjectsOnAndIn[]&perc; - Object Key """ & sArgs & """ not found")
                                            'End If

                                        Case "ListWorn".ToLower
#If Runner Then
                                            If Adventure.htblCharacters.ContainsKey(sArgs) Then
                                                sResult = Adventure.htblCharacters(sArgs).WornObjects.List("and", True, ArticleTypeEnum.Indefinite)
                                            Else
                                                DisplayError("Bad Argument to &perc;ListWorn[]&perc; - Character Key """ & sArgs & """ not found")
                                            End If
#End If
                                        Case "LocationName".ToLower
                                            If Adventure.htblLocations.ContainsKey(sArgs) Then
                                                sResult = Adventure.htblLocations(sArgs).ShortDescription.ToString
                                            Else
                                                DisplayError("Bad Argument to &perc;LocationName[]&perc; - Location Key """ & sArgs & """ not found")
                                            End If

                                        Case "LocationOf".ToLower
                                            If Adventure.htblCharacters.ContainsKey(sArgs) Then
                                                sResult = Adventure.htblCharacters(sArgs).Location.LocationKey
                                            ElseIf Adventure.htblObjects.ContainsKey(sArgs) Then
                                                For Each sLocKey As String In Adventure.htblObjects(sArgs).LocationRoots.Keys
                                                    If sResult <> "" Then sResult &= "|"
                                                    sResult &= sLocKey
                                                Next
                                            Else
                                                DisplayError("Bad Argument to &perc;LocationOf[]&perc; - Character Key """ & sArgs & """ not found")
                                            End If

                                        Case "NumberAsText".ToLower
                                            sResult = NumberToString(sArgs)

                                        Case "ObjectName".ToLower
                                            sResult = htblObjects.List(, , ArticleTypeEnum.Indefinite)

                                        Case "ObjectsIn".ToLower
                                            If Adventure.htblObjects.ContainsKey(sArgs) Then
                                                For Each ob As clsObject In Adventure.htblObjects(sArgs).Children(clsObject.WhereChildrenEnum.InsideObject).Values
                                                    If sResult <> "" Then sResult &= "|"
                                                    sResult &= ob.Key
                                                Next
                                            Else
                                                DisplayError("Bad Argument to &perc;ObjectsIn[]&perc; - Object Key """ & sArgs & """ not found")
                                            End If
                                            bAllowBlank = True

                                        Case "ParentOf".ToLower
                                            'Dim htblParents As New ObjectHashTable
                                            'For Each ob As clsObject In htblObjects.Values
                                            '    htblParents.Add(Adventure.htblObjects(ob.Parent), ob.Parent)
                                            'Next
                                            'sResult = htblParents.List
                                            For Each ob As clsObject In htblObjects.Values
                                                If sResult <> "" Then sResult &= "|"
                                                sResult &= ob.Parent
                                            Next
                                            For Each ch As clsCharacter In htblCharacters.Values
                                                If sResult <> "" Then sResult &= "|"
                                                sResult &= ch.Parent
                                            Next
                                            '' Just take the first one.  Not sure about multiple...
                                            ''Dim htblParents As New ObjectHashTable
                                            'For Each ob As clsObject In htblObjects.Values
                                            '    sResult = ob.Parent
                                            '    'If Not htblParents.Contains(ob.Parent) Then
                                            '    'Return ob.Parent
                                            '    'End If
                                            '    'htblParents.Add(Adventure.htblObjects(ob.Parent), ob.Parent)
                                            'Next
                                        Case "PCase".ToLower
                                            sResult = PCase(sArgs, , bExpression)

                                        Case "PopUpChoice".ToLower
                                            Dim sKeys() As String = sArgs.Split(","c) ' TODO - Improve this to read quotes and commas properly
                                            If sKeys.Length = 3 Then
                                                ' For now - needs improving
                                                Dim var As New clsVariable
                                                var.Type = clsVariable.VariableTypeEnum.Text
                                                Select Case MsgBox(sKeys(0) & vbCrLf & vbCrLf & "Yes for " & sKeys(1) & ", No for " & sKeys(2) & " (dialog box to be improved!)", MsgBoxStyle.YesNo)
                                                    Case MsgBoxResult.Yes
                                                        var.SetToExpression(sKeys(1))
                                                    Case MsgBoxResult.No
                                                        var.SetToExpression(sKeys(2))
                                                End Select
                                                sResult = var.StringValue
                                                If bExpression Then sResult = """" & sResult & """"
                                            Else
                                                DisplayError("Bad arguments to PopUpChoice function: PopUpChoice[prompt, choice1, choice2]")
                                            End If

                                        Case "PopUpInput".ToLower
                                            Dim sKeys() As String = sArgs.Split(","c) ' TODO - Improve this to read quotes and commas properly
                                            If sKeys.Length = 1 OrElse sKeys.Length = 2 Then
                                                'Dim var As New clsVariable
                                                'var.Type = clsVariable.VariableTypeEnum.Text
                                                'var.SetToExpression(sKeys(0))
                                                Dim sDefault As String = ""
                                                If sKeys.Length = 2 Then sDefault = EvaluateExpression(sKeys(1))
                                                sResult = """" & InputBox(EvaluateExpression(sKeys(0)), "ADRIFT", sDefault) & """"
                                            Else
                                                DisplayError("Expecting 1 or two arguments to PopUpInput[prompt, default]")
                                            End If

                                        Case "PrevListObjectsOn".ToLower
                                            ' Maintain a 'last turn' state
                                            ' Call ListObjectsOn on this state
                                            sResult = PreviousFunction(sFunction, sArgs)

                                        Case "PrevParentOf".ToLower
                                            ' Get rid of PrevParent, and do the same as above
                                            For Each ob As clsObject In htblObjects.Values
                                                If sResult <> "" Then sResult &= "|"
                                                sResult &= ob.PrevParent
                                            Next
                                            For Each ch As clsCharacter In htblCharacters.Values
                                                If sResult <> "" Then sResult &= "|"
                                                sResult &= ch.PrevParent
                                            Next

                                        Case "PropertyValue".ToLower
                                            bAllowBlank = True
                                            Dim sKeys() As String = Split(sArgs.Replace(" ", ""), ",")
                                            If sKeys.Length = 2 Then
                                                If htblObjects.Count + htblCharacters.Count + htblLocations.Count > 0 Then
                                                    Dim arlOutput As New StringArrayList
                                                    For Each ob As clsObject In htblObjects.Values
                                                        If ob.HasProperty(sKeys(1)) Then
                                                            arlOutput.Add(ob.GetPropertyValue(sKeys(1)))
                                                        Else
                                                            DisplayError("Bad 2nd Argument to &perc;PropertyValue[]&perc; - Property Key """ & sKeys(1) & """ not found")
                                                        End If
                                                    Next
                                                    For Each ch As clsCharacter In htblCharacters.Values
                                                        If ch.HasProperty(sKeys(1)) Then
                                                            arlOutput.Add(ch.GetPropertyValue(sKeys(1)))
                                                        Else
                                                            DisplayError("Bad 2nd Argument to &perc;PropertyValue[]&perc; - Property Key """ & sKeys(1) & """ not found")
                                                        End If
                                                    Next
                                                    For Each l As clsLocation In htblLocations.Values
                                                        If l.HasProperty(sKeys(1)) Then
                                                            arlOutput.Add(l.GetPropertyValue(sKeys(1)))
                                                        Else
                                                            DisplayError("Bad 2nd Argument to &perc;PropertyValue[]&perc; - Property Key """ & sKeys(1) & """ not found")
                                                        End If
                                                    Next
                                                    sResult = arlOutput.List
                                                Else
                                                    ' Only warn about the first arg if it isn't from a function
                                                    Dim sOrig As String = Split(sOldArgs.Replace(" ", ""), ",")(0)
                                                    If sOrig = sKeys(0) Then DisplayError("Bad 1st Argument to &perc;PropertyValue[]&perc; - Object/Character Key """ & sKeys(0) & """ not found")
                                                End If
                                            Else
                                                DisplayError("Bad call to &perc;PropertyValue[]&perc; - Two arguments expected; Object Key, Property Key")
                                            End If

                                            'Case "ProperName".ToLower
                                            '    If Adventure.htblCharacters.ContainsKey(sArgs) Then
                                            '        sResult = htblCharacters(sArgs).ProperName
                                            '    Else
                                            '        DisplayError("Bad Argument to &perc;ProperName[]&perc; - Character Key """ & sArgs & """ not found")
                                            '    End If

                                        Case "Sum".ToLower
                                            ' Sum the numbers from a string
                                            Dim sInput As New System.Text.StringBuilder
                                            For Each c As Char In sArgs.ToCharArray
                                                Select Case c
                                                    Case "0"c To "9"c, "-"c
                                                        sInput.Append(c)
                                                    Case Else
                                                        sInput.Append(" ")
                                                End Select
                                            Next
                                            While sInput.ToString.Contains("  ")
                                                sInput.Replace("  ", " ")
                                            End While
                                            Dim iTotal As Integer = 0
                                            For Each s As String In sInput.ToString.Split(" "c)
                                                iTotal += SafeInt(s)
                                            Next
                                            sResult = iTotal.ToString

                                        Case "TaskCompleted".ToLower
                                            If Adventure.htblTasks.ContainsKey(sArgs) Then
                                                sResult = Adventure.htblTasks(sArgs).Completed.ToString
                                            Else
                                                DisplayError("Bad Argument to &perc;TaskCompleted[]&perc; - Task Key """ & sArgs & """ not found")
                                            End If

                                        Case "TheObject".ToLower, "TheObjects".ToLower
                                            sResult = htblObjects.List

                                        Case "UCase".ToLower
                                            sResult = sArgs.ToUpper

                                        Case "Worn".ToLower
#If Runner Then
                                            If Adventure.htblCharacters.ContainsKey(sArgs) Then
                                                For Each ob As clsObject In Adventure.htblCharacters(sArgs).WornObjects.Values
                                                    If sResult <> "" Then sResult &= "|"
                                                    sResult &= ob.Key
                                                Next
                                            Else
                                                DisplayError("Bad Argument to &perc;Worn[]&perc; - Character Key """ & sArgs & """ not found")
                                            End If
#End If
                                    End Select

                                    If sResult = "" AndAlso Not bAllowBlank Then
                                        DisplayError("Bad Function - Nothing output")
                                    End If

                                    sText = ReplaceIgnoreCase(sText, "%" & sFunction & "[" & sArgs & "]%", sResult)

                                Else
                                    Dim sBadFunction As String = ""
                                    If sText.ToLower.Contains("%" & sFunction) Then sBadFunction = "%" & sFunction
                                    If sText.ToLower.Contains("%" & sFunction & "[") Then sBadFunction = "%" & sFunction & "["
                                    If sText.ToLower.Contains("%" & sFunction & "[" & sArgs.ToLower) Then sBadFunction = "%" & sFunction & "[" & sArgs
                                    If sText.ToLower.Contains("%" & sFunction & "[" & sArgs.ToLower & "]") Then sBadFunction = "%" & sFunction & "[" & sArgs & "]"
                                    sText = ReplaceIgnoreCase(sText, sBadFunction, " <c><u>" & sBadFunction.Replace("%", "&perc;") & "</u></c>")

                                    DisplayError("Bad function " & sFunction)

                                End If
                            Else
                                sText = ReplaceIgnoreCase(sText, "%" & sFunction & "[]%", "")
                                sText = ReplaceIgnoreCase(sText, "%" & sFunction & "[", "")

                                DisplayError("No arguments given to function " & sFunction)

                            End If

                            iMatchLoc = sInstr(sText.ToLower, "%" & sFunction & "[")
                        End While
                        'Next
                    End If

                Loop While sText <> sCheck
            End If


            If bAllowOO Then
                Dim sPrev As String
                Do
                    sPrev = sText
                    sText = ReplaceOO(sText, bExpression)
                Loop While sText <> sPrev
            End If


            Dim rePerspective As New System.Text.RegularExpressions.Regex("\[(?<first>.*?)/(?<second>.*?)/(?<third>.*?)\]")
            While rePerspective.IsMatch(sText)
                'If Adventure.LastPerspective = clsCharacter.PerspectiveEnum.None Then Adventure.LastPerspective = Adventure.Player.Perspective
                Dim match As System.Text.RegularExpressions.Match = rePerspective.Match(sText)
                Dim sFirst As String = match.Groups("first").Value
                If sFirst.Contains("[") Then sFirst = sFirst.Substring(sFirst.LastIndexOf("[") + 1)
                Dim sSecond As String = match.Groups("second").Value
                Dim sThird As String = match.Groups("third").Value
                Dim sValue As String = ""

                If sFirst.Contains("[") OrElse sFirst.Contains("]") OrElse sSecond.Contains("[") OrElse sSecond.Contains("]") OrElse sThird.Contains("[") OrElse sThird.Contains("]") Then Exit While

                Select Case GetPerspective(match.Index) ' Adventure.LastPerspective
                    Case PerspectiveEnum.FirstPerson
                        sValue = sFirst
                    Case PerspectiveEnum.SecondPerson
                        sValue = sSecond
                    Case PerspectiveEnum.ThirdPerson
                        sValue = sThird
                End Select

                sText = sText.Replace("[" & sFirst & "/" & sSecond & "/" & sThird & "]", sValue)
                'For Each p As PerspectiveOffset In Perspectives
                '    If p.Offset > match.Index Then
                '        p.Offset -= ("[" & sFirst & "/" & sSecond & "/" & sThird & "]").Length - sValue.Length
                '    End If
                'Next
            End While

            For Each sGUID As String In dictGUIDs.Keys
                sText = sText.Replace(sGUID, dictGUIDs(sGUID))
            Next

            Return sText

        Catch ex As Exception
            ErrMsg("ReplaceFunctions error", ex)
            Return sText
        End Try

    End Function


    '' E.g. "one. two three", "two", 6 => "one. Two three" 
    'Public Function AutoCapitalise(ByVal sWholeText As String, ByVal sText As String, ByVal iOffset As Integer) As String

    '    Dim bCapitalise As Boolean = False

    '    If iOffset = 1 Then
    '        bCapitalise = True
    '    Else
    '        If iOffset > 1 AndAlso sWholeText(iOffset - 2) = vbLf Then
    '            bCapitalise = True
    '        End If
    '        If sWholeText.Length > iOffset - 1 AndAlso iOffset > 1 AndAlso sWholeText(iOffset - 2) = " " Then
    '            If sWholeText(iOffset - 3) = " " Then
    '                If sWholeText(iOffset - 4) = "." Then
    '                    bCapitalise = True
    '                End If
    '            ElseIf sWholeText(iOffset - 3) = "." Then
    '                bCapitalise = True
    '            End If
    '        End If
    '    End If

    '    If bCapitalise Then
    '        Return PCase(sText)
    '    Else
    '        Return sText
    '    End If

    'End Function


    'Adventure.htblCharacters(PronounKeys(PronounKeys.Count - 1).Key).Perspective ' 
    ' Return the highest perspective that is less the iOffset
    Private Function GetPerspective(ByVal iOffset As Integer) As PerspectiveEnum

        Dim iHighest As Integer = 0
        Dim ePerspective As PerspectiveEnum = PerspectiveEnum.None

#If Runner Then
        For Each p As PronounInfo In UserSession.PronounKeys
            If iOffset >= p.Offset AndAlso p.Offset > iHighest Then
                ePerspective = Adventure.htblCharacters(p.Key).Perspective
                iHighest = p.Offset
            End If
        Next
#End If

        If ePerspective <> PerspectiveEnum.None Then
            Return ePerspective
        Else
            Return Adventure.Player.Perspective
        End If

    End Function


    ' Convert a number between 0 and 999 into words.
    Private Function GroupToWords(ByVal num As Integer) As _
        String
        Static one_to_nineteen() As String = {"zero", "one", _
            "two", "three", "four", "five", "six", "seven", _
            "eight", "nine", "ten", "eleven", "twelve", _
            "thirteen", "fourteen", "fifteen", "sixteen", _
            "seventeen", "eighteen", "nineteen"}
        Static multiples_of_ten() As String = {"twenty", _
            "thirty", "forty", "fifty", "sixty", "seventy", _
            "eighty", "ninety"}

        ' If the number is 0, return an empty string.
        If num = 0 Then Return ""

        ' Handle the hundreds digit.
        Dim digit As Integer
        Dim result As String = ""
        Dim bAnd As Boolean = False
        If num > 99 Then
            digit = num \ 100
            num = num Mod 100
            bAnd = True
            result = one_to_nineteen(digit) & " hundred"
        End If

        ' If num = 0, we have hundreds only.
        If num = 0 Then Return result.Trim()

        If bAnd Then result &= " and"

        ' See if the rest is less than 20.
        If num < 20 Then
            ' Look up the correct name.
            result &= " " & one_to_nineteen(num)
        Else
            ' Handle the tens digit.
            digit = num \ 10
            num = num Mod 10
            result &= " " & multiples_of_ten(digit - 2)

            ' Handle the final digit.
            If num > 0 Then
                result &= " " & one_to_nineteen(num)
            End If
        End If

        Return result.Trim()
    End Function


    ' Return a word representation of the whole number value.
    Private Function NumberToString(ByVal num_str As String, Optional ByVal use_us_group_names As Boolean = True) As String

        Dim result As String = ""
        Dim sIn As String = num_str

        If Not IsNumeric(num_str) Then
            Dim v As New clsVariable
            v.SetToExpression(num_str)
            num_str = v.IntValue.ToString
        End If

        Try

            ' Get the appropiate group names.
            Dim groups() As String
            If use_us_group_names Then
                groups = New String() {"", "thousand", "million", _
                    "billion", "trillion", "quadrillion", _
                    "quintillion", "sextillion", "septillion", _
                    "octillion", "nonillion", "decillion", _
                    "undecillion", "duodecillion", "tredecillion", _
                    "quattuordecillion", "quindecillion", _
                    "sexdecillion", "septendecillion", _
                    "octodecillion", "novemdecillion", _
                    "vigintillion"}
            Else
                groups = New String() {"", "thousand", "million", _
                    "milliard", "billion", "1000 billion", _
                    "trillion", "1000 trillion", "quadrillion", _
                    "1000 quadrillion", "quintillion", "1000 " & _
                    "quintillion", "sextillion", "1000 sextillion", _
                    "septillion", "1000 septillion", "octillion", _
                    "1000 octillion", "nonillion", "1000 " & _
                    "nonillion", "decillion", "1000 decillion"}
            End If

            ' Clean the string a bit.
            ' Remove "$", ",", leading zeros, and
            ' anything after a decimal point.
            Const CURRENCY As String = "$"
            Const SEPARATOR As String = ","
            Const DECIMAL_POINT As String = "."
            num_str = num_str.Replace(CURRENCY, _
                "").Replace(SEPARATOR, "")
            num_str = num_str.TrimStart(New Char() {"0"c})
            Dim pos As Integer = num_str.IndexOf(DECIMAL_POINT)
            If pos = 0 Then
                Return "zero"
            ElseIf pos > 0 Then
                num_str = num_str.Substring(0, pos - 1)
            End If

            ' See how many groups there will be.
            Dim num_groups As Integer = (num_str.Length + 2) \ 3

            ' Pad so length is a multiple of 3.
            num_str = num_str.PadLeft(num_groups * 3, " "c)

            ' Process the groups, largest first.            
            Dim group_num As Integer
            For group_num = num_groups - 1 To 0 Step -1
                ' Get the next three digits.
                Dim group_str As String = num_str.Substring(0, 3)
                num_str = num_str.Substring(3)
                Dim group_value As Integer = CInt(group_str)

                ' Convert the group into words.
                If group_value > 0 Then
                    If group_num >= groups.Length Then
                        result &= GroupToWords(group_value) & _
                            " ?, "
                    Else
                        result &= GroupToWords(group_value) & _
                            " " & groups(group_num) & ", "
                    End If
                End If
            Next group_num

            ' Remove the trailing ", ".
            If result.EndsWith(", ") Then
                result = result.Substring(0, result.Length - 2)
            End If

            result = result.Trim()

        Catch ex As Exception
            ErrMsg("NumberToString error parsing """ & sIn & """", ex)
        End Try

        If result = "" Then result = "zero"
        Return result

    End Function


    Public Function OppositeDirection(ByVal dir As DirectionsEnum) As DirectionsEnum
        Select Case dir
            Case DirectionsEnum.North
                Return DirectionsEnum.South
            Case DirectionsEnum.NorthEast
                Return DirectionsEnum.SouthWest
            Case DirectionsEnum.East
                Return DirectionsEnum.West
            Case DirectionsEnum.SouthEast
                Return DirectionsEnum.NorthWest
            Case DirectionsEnum.South
                Return DirectionsEnum.North
            Case DirectionsEnum.SouthWest
                Return DirectionsEnum.NorthEast
            Case DirectionsEnum.West
                Return DirectionsEnum.East
            Case DirectionsEnum.NorthWest
                Return DirectionsEnum.SouthEast
            Case DirectionsEnum.Up
                Return DirectionsEnum.Down
            Case DirectionsEnum.Down
                Return DirectionsEnum.Up
            Case DirectionsEnum.In
                Return DirectionsEnum.Out
            Case DirectionsEnum.Out
                Return DirectionsEnum.In
            Case Else
                Return dir
        End Select
    End Function



    Public Function ReplaceIgnoreCase(ByVal Expression As String, ByVal Find As String, ByVal Replacement As String) As String
        If Replacement Is Nothing Then Replacement = ""
        Dim regex As New System.Text.RegularExpressions.Regex(Find.Replace("[", "\[").Replace("]", "\]").Replace("(", "\(").Replace(")", "\)").Replace("|", "\|").Replace("*", "\*").Replace("?", "\?").Replace("$", "\$").Replace("^", "\^").Replace("+", "\+"), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        Return regex.Replace(Expression, Replacement.Replace("$", "$$"), 1) ' Prevent Substitutions (http://msdn.microsoft.com/en-us/library/ewy2t5e0.aspx)
    End Function


    Public Function PCase(ByVal sText As String, Optional ByVal bStrictLower As Boolean = False, Optional ByVal bExpression As Boolean = False) As String

        Dim bQuotes As Boolean = False
        If bExpression AndAlso sText.StartsWith("""") AndAlso sText.EndsWith("""") Then
            bQuotes = True
            sText = sText.Substring(1, sText.Length - 2)
        End If
        PCase = ""

        Try
            If sText.Length > 0 Then
                PCase = Left(sText, 1).ToUpper
                If sText.Length > 1 Then
                    If bStrictLower Then
                        PCase &= Right(sText, sText.Length - 1).ToLower
                    Else
                        PCase &= Right(sText, sText.Length - 1)
                    End If
                End If
            Else
                Return ""
            End If
        Finally
            If bQuotes Then PCase = """" & PCase & """"
        End Try

    End Function


    Public Function GetFunctionArgs(ByVal sText As String) As String

        Try
            If sInstr(sText, "[") = 0 OrElse sInstr(sText, "]") = 0 Then Return ""

            ' Work out this bracket chunk, then run ReplaceFunctions on it
            Dim iOffset As Integer = 1
            Dim iLevel As Integer = 1

            While iLevel > 0
                Select Case sText.Substring(iOffset, 1)
                    Case "["
                        iLevel += 1
                    Case "]"
                        iLevel -= 1
                    Case Else
                        ' Ignore
                End Select
                iOffset += 1
            End While

            Return sText.Substring(1, iOffset - 2)
        Catch ex As Exception
            DisplayError("Error obtaining function arguments from """ & sText & """")
            Return ""
        End Try

    End Function


    Public Sub Sleep(ByVal iSeconds As Integer)
        Threading.Thread.Sleep(iSeconds * 1000)
    End Sub


    Public Sub IntroMessage()
        'MessageBox.Show("This is an early alpha release of ADRIFT 5.0 for <Ken Franklin>, dated 19th Nov 2006.  Please do NOT distribute!", "ADRIFT 5.0", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub



    Public Function EnumParsePropertyPropertyOf(ByVal sValue As String) As clsProperty.PropertyOfEnum
        Select Case sValue
            Case "Objects"
                Return clsProperty.PropertyOfEnum.Objects
            Case "Characters"
                Return clsProperty.PropertyOfEnum.Characters
            Case "Locations"
                Return clsProperty.PropertyOfEnum.Locations
            Case "AnyItem"
                Return clsProperty.PropertyOfEnum.AnyItem
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParsePropertyType(ByVal sValue As String) As clsProperty.PropertyTypeEnum
        Select Case sValue
            Case "CharacterKey"
                Return clsProperty.PropertyTypeEnum.CharacterKey
            Case "Integer"
                Return clsProperty.PropertyTypeEnum.Integer
            Case "LocationGroupKey"
                Return clsProperty.PropertyTypeEnum.LocationGroupKey
            Case "LocationKey"
                Return clsProperty.PropertyTypeEnum.LocationKey
            Case "ObjectKey"
                Return clsProperty.PropertyTypeEnum.ObjectKey
            Case "SelectionOnly"
                Return clsProperty.PropertyTypeEnum.SelectionOnly
            Case "StateList"
                Return clsProperty.PropertyTypeEnum.StateList
            Case "ValueList"
                Return clsProperty.PropertyTypeEnum.ValueList
            Case "Text"
                Return clsProperty.PropertyTypeEnum.Text
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseMoveCharacter(ByVal sValue As String) As clsAction.MoveCharacterToEnum
        Select Case sValue
            Case "InDirection"
                Return clsAction.MoveCharacterToEnum.InDirection
            Case "ToLocation"
                Return clsAction.MoveCharacterToEnum.ToLocation
            Case "ToLocationGroup"
                Return clsAction.MoveCharacterToEnum.ToLocationGroup
            Case "ToLyingOn"
                Return clsAction.MoveCharacterToEnum.ToLyingOn
            Case "ToSameLocationAs"
                Return clsAction.MoveCharacterToEnum.ToSameLocationAs
            Case "ToSittingOn"
                Return clsAction.MoveCharacterToEnum.ToSittingOn
            Case "ToStandingOn"
                Return clsAction.MoveCharacterToEnum.ToStandingOn
            Case "ToSwitchWith"
                Return clsAction.MoveCharacterToEnum.ToSwitchWith
            Case "InsideObject"
                Return clsAction.MoveCharacterToEnum.InsideObject
            Case "OntoCharacter"
                Return clsAction.MoveCharacterToEnum.OntoCharacter
            Case "ToParentLocation"
                Return clsAction.MoveCharacterToEnum.ToParentLocation
            Case "ToGroup"
                Return clsAction.MoveCharacterToEnum.ToGroup
            Case "FromGroup"
                Return clsAction.MoveCharacterToEnum.FromGroup
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseMoveLocation(ByVal sValue As String) As clsAction.MoveLocationToEnum
        Select Case sValue
            Case "ToGroup"
                Return clsAction.MoveLocationToEnum.ToGroup
            Case "FromGroup"
                Return clsAction.MoveLocationToEnum.FromGroup
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseSetTask(ByVal sValue As String) As clsAction.SetTasksEnum
        Select Case sValue
            Case "Execute"
                Return clsAction.SetTasksEnum.Execute
            Case "Unset"
                Return clsAction.SetTasksEnum.Unset
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseEndGame(ByVal sValue As String) As clsAction.EndGameEnum
        Select Case sValue
            Case "Win"
                Return clsAction.EndGameEnum.Win
            Case "Lose"
                Return clsAction.EndGameEnum.Lose
            Case "Neutral"
                Return clsAction.EndGameEnum.Neutral
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseMoveObject(ByVal sValue As String) As clsAction.MoveObjectToEnum
        Select Case sValue
            Case "InsideObject"
                Return clsAction.MoveObjectToEnum.InsideObject
            Case "OntoObject"
                Return clsAction.MoveObjectToEnum.OntoObject
            Case "ToCarriedBy"
                Return clsAction.MoveObjectToEnum.ToCarriedBy
            Case "ToLocation"
                Return clsAction.MoveObjectToEnum.ToLocation
            Case "ToLocationGroup"
                Return clsAction.MoveObjectToEnum.ToLocationGroup
            Case "ToPartOfCharacter"
                Return clsAction.MoveObjectToEnum.ToPartOfCharacter
            Case "ToPartOfObject"
                Return clsAction.MoveObjectToEnum.ToPartOfObject
            Case "ToSameLocationAs"
                Return clsAction.MoveObjectToEnum.ToSameLocationAs
            Case "ToWornBy"
                Return clsAction.MoveObjectToEnum.ToWornBy
            Case "ToGroup"
                Return clsAction.MoveObjectToEnum.ToGroup
            Case "FromGroup"
                Return clsAction.MoveObjectToEnum.FromGroup
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseMust(ByVal sValue As String) As clsRestriction.MustEnum
        Select Case sValue
            Case "Must"
                Return clsRestriction.MustEnum.Must
            Case "MustNot"
                Return clsRestriction.MustEnum.MustNot
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseLocation(ByVal sValue As String) As clsRestriction.LocationEnum
        If Adventure.dVersion < 5.000015 Then
            If sValue = "SeenByCharacter" Then sValue = "HaveBeenSeenByCharacter"
        End If
        Select Case sValue
            Case "BeInGroup"
                Return clsRestriction.LocationEnum.BeInGroup
            Case "HaveBeenSeenByCharacter"
                Return clsRestriction.LocationEnum.HaveBeenSeenByCharacter
            Case "HaveProperty"
                Return clsRestriction.LocationEnum.HaveProperty
            Case "BeLocation"
                Return clsRestriction.LocationEnum.BeLocation
            Case "Exist"
                Return clsRestriction.LocationEnum.Exist
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseDirections(ByVal sValue As String) As DirectionsEnum
        Select Case sValue
            Case "Down"
                Return DirectionsEnum.Down
            Case "East"
                Return DirectionsEnum.East
            Case "In"
                Return DirectionsEnum.In
            Case "North"
                Return DirectionsEnum.North
            Case "NorthEast"
                Return DirectionsEnum.NorthEast
            Case "NorthWest"
                Return DirectionsEnum.NorthWest
            Case "Out"
                Return DirectionsEnum.Out
            Case "South"
                Return DirectionsEnum.South
            Case "SouthEast"
                Return DirectionsEnum.SouthEast
            Case "SouthWest"
                Return DirectionsEnum.SouthWest
            Case "Up"
                Return DirectionsEnum.Up
            Case "West"
                Return DirectionsEnum.West
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseBeforeAfter(ByVal sValue As String) As clsTask.BeforeAfterEnum
        Select Case sValue
            Case "After"
                Return clsTask.BeforeAfterEnum.After
            Case "Before"
                Return clsTask.BeforeAfterEnum.Before
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseVariable(ByVal sValue As String) As clsRestriction.VariableEnum
        Select Case sValue
            Case "EqualTo"
                Return clsRestriction.VariableEnum.EqualTo
            Case "GreaterThan"
                Return clsRestriction.VariableEnum.GreaterThan
            Case "GreaterThanOrEqualTo"
                Return clsRestriction.VariableEnum.GreaterThanOrEqualTo
            Case "LessThan"
                Return clsRestriction.VariableEnum.LessThan
            Case "LessThanOrEqualTo"
                Return clsRestriction.VariableEnum.LessThanOrEqualTo
            Case "Contain"
                Return clsRestriction.VariableEnum.Contain
            Case Else
                Return Nothing
        End Select
    End Function


    Public Function EnumParseItem(ByVal sValue As String) As clsRestriction.ItemEnum
        Select Case sValue
            Case "BeAtLocation"
                Return clsRestriction.ItemEnum.BeAtLocation
            Case "BeCharacter"
                Return clsRestriction.ItemEnum.BeCharacter
            Case "BeInGroup"
                Return clsRestriction.ItemEnum.BeInGroup
            Case "BeInSameLocationAsCharacter"
                Return clsRestriction.ItemEnum.BeInSameLocationAsCharacter
            Case "BeInSameLocationAsObject"
                Return clsRestriction.ItemEnum.BeInSameLocationAsObject
            Case "BeInsideObject"
                Return clsRestriction.ItemEnum.BeInsideObject
            Case "BeLocation"
                Return clsRestriction.ItemEnum.BeLocation
            Case "BeObject"
                Return clsRestriction.ItemEnum.BeObject
            Case "BeOnCharacter"
                Return clsRestriction.ItemEnum.BeOnCharacter
            Case "BeOnObject"
                Return clsRestriction.ItemEnum.BeOnObject
            Case "BeType"
                Return clsRestriction.ItemEnum.BeType
            Case "Exist"
                Return clsRestriction.ItemEnum.Exist
            Case "HaveProperty"
                Return clsRestriction.ItemEnum.HaveProperty
            Case Else
                TODO()
        End Select
    End Function


    Public Function EnumParseCharacter(ByVal sValue As String) As clsRestriction.CharacterEnum
        Select Case sValue
            Case "BeAlone"
                Return clsRestriction.CharacterEnum.BeAlone
            Case "BeAloneWith"
                Return clsRestriction.CharacterEnum.BeAloneWith
            Case "BeAtLocation"
                Return clsRestriction.CharacterEnum.BeAtLocation
            Case "BeCharacter"
                Return clsRestriction.CharacterEnum.BeCharacter
            Case "BeInConversationWith"
                Return clsRestriction.CharacterEnum.BeInConversationWith
            Case "Exist"
                Return clsRestriction.CharacterEnum.Exist
            Case "HaveRouteInDirection"
                Return clsRestriction.CharacterEnum.HaveRouteInDirection
            Case "HaveSeenCharacter"
                Return clsRestriction.CharacterEnum.HaveSeenCharacter
            Case "HaveSeenLocation"
                Return clsRestriction.CharacterEnum.HaveSeenLocation
            Case "HaveSeenObject"
                Return clsRestriction.CharacterEnum.HaveSeenObject
            Case "BeHoldingObject"
                Return clsRestriction.CharacterEnum.BeHoldingObject
            Case "BeInSameLocationAsCharacter"
                Return clsRestriction.CharacterEnum.BeInSameLocationAsCharacter
            Case "BeInSameLocationAsObject"
                Return clsRestriction.CharacterEnum.BeInSameLocationAsObject
            Case "BeLyingOnObject"
                Return clsRestriction.CharacterEnum.BeLyingOnObject
            Case "BeMemberOfGroup", "BeInGroup"
                Return clsRestriction.CharacterEnum.BeInGroup
            Case "BeOfGender"
                Return clsRestriction.CharacterEnum.BeOfGender
            Case "BeSittingOnObject"
                Return clsRestriction.CharacterEnum.BeSittingOnObject
            Case "BeStandingOnObject"
                Return clsRestriction.CharacterEnum.BeStandingOnObject
            Case "BeWearingObject"
                Return clsRestriction.CharacterEnum.BeWearingObject
            Case "BeWithinLocationGroup"
                Return clsRestriction.CharacterEnum.BeWithinLocationGroup
            Case "HaveProperty"
                Return clsRestriction.CharacterEnum.HaveProperty
            Case "BeInPosition"
                Return clsRestriction.CharacterEnum.BeInPosition
            Case "BeInsideObject"
                Return clsRestriction.CharacterEnum.BeInsideObject
            Case "BeOnObject"
                Return clsRestriction.CharacterEnum.BeOnObject
            Case "BeOnCharacter"
                Return clsRestriction.CharacterEnum.BeOnCharacter
            Case "BeVisibleToCharacter"
                Return clsRestriction.CharacterEnum.BeVisibleToCharacter
            Case Else
                'Throw New Exception("Value """ & sValue & """ not parsed!")
                Return Nothing
        End Select

    End Function


    Public Function EnumParseObject(ByVal sValue As String) As clsRestriction.ObjectEnum
        Select Case sValue
            Case "BeExactText"
                Return clsRestriction.ObjectEnum.BeExactText
            Case "BeAtLocation"
                Return clsRestriction.ObjectEnum.BeAtLocation
            Case "BeHeldByCharacter"
                Return clsRestriction.ObjectEnum.BeHeldByCharacter
            Case "BeHidden"
                Return clsRestriction.ObjectEnum.BeHidden
            Case "BeInGroup"
                Return clsRestriction.ObjectEnum.BeInGroup
            Case "BeInsideObject"
                Return clsRestriction.ObjectEnum.BeInsideObject
            Case "BeInState"
                Return clsRestriction.ObjectEnum.BeInState
            Case "BeOnObject"
                Return clsRestriction.ObjectEnum.BeOnObject
            Case "BePartOfCharacter"
                Return clsRestriction.ObjectEnum.BePartOfCharacter
            Case "BePartOfObject"
                Return clsRestriction.ObjectEnum.BePartOfObject
            Case "BeVisibleToCharacter"
                Return clsRestriction.ObjectEnum.BeVisibleToCharacter
            Case "BeWornByCharacter"
                Return clsRestriction.ObjectEnum.BeWornByCharacter
            Case "Exist"
                Return clsRestriction.ObjectEnum.Exist
            Case "HaveBeenSeenByCharacter"
                Return clsRestriction.ObjectEnum.HaveBeenSeenByCharacter
            Case "HaveProperty"
                Return clsRestriction.ObjectEnum.HaveProperty
            Case "BeObject"
                Return clsRestriction.ObjectEnum.BeObject
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseSubEventMeasure(ByVal sValue As String) As clsEvent.SubEvent.MeasureEnum
        Select Case sValue
            Case "Turns"
                Return clsEvent.SubEvent.MeasureEnum.Turns
            Case "Seconds"
                Return clsEvent.SubEvent.MeasureEnum.Seconds
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function

    Public Function EnumParseSubEventWhat(ByVal sValue As String) As clsEvent.SubEvent.WhatEnum
        Select Case sValue
            Case "DisplayMessage"
                Return clsEvent.SubEvent.WhatEnum.DisplayMessage
            Case "ExecuteTask"
                Return clsEvent.SubEvent.WhatEnum.ExecuteTask
            Case "SetLook"
                Return clsEvent.SubEvent.WhatEnum.SetLook
            Case "UnsetTask"
                Return clsEvent.SubEvent.WhatEnum.UnsetTask
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseTaskType(ByVal sValue As String) As clsTask.TaskTypeEnum
        Select Case sValue
            Case "General"
                Return clsTask.TaskTypeEnum.General
            Case "Specific"
                Return clsTask.TaskTypeEnum.Specific
            Case "System"
                Return clsTask.TaskTypeEnum.System
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseSpecificType(ByVal sValue As String) As ReferencesType
        Select Case sValue
            Case "Character"
                Return ReferencesType.Character
            Case "Direction"
                Return ReferencesType.Direction
            Case "Number"
                Return ReferencesType.Number
            Case "Object"
                Return ReferencesType.Object
            Case "Text"
                Return ReferencesType.Text
            Case "Location"
                Return ReferencesType.Location
            Case "Item"
                Return ReferencesType.Item
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseCharacterType(ByVal sValue As String) As clsCharacter.CharacterTypeEnum
        Select Case sValue
            Case "NonPlayer"
                Return clsCharacter.CharacterTypeEnum.NonPlayer
            Case "Player"
                Return clsCharacter.CharacterTypeEnum.Player
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseVariableType(ByVal sValue As String) As clsVariable.VariableTypeEnum
        Select Case sValue
            Case "Numeric"
                Return clsVariable.VariableTypeEnum.Numeric
            Case "Text"
                Return clsVariable.VariableTypeEnum.Text
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function


    Public Function EnumParseGroupType(ByVal sValue As String) As clsGroup.GroupTypeEnum
        Select Case sValue
            Case "Characters"
                Return clsGroup.GroupTypeEnum.Characters
            Case "Locations"
                Return clsGroup.GroupTypeEnum.Locations
            Case "Objects"
                Return clsGroup.GroupTypeEnum.Objects
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function



    Public Function WriteEnum(ByVal e As clsAction.EndGameEnum) As String
        Select Case e
            Case clsAction.EndGameEnum.Win
                Return "Win"
            Case clsAction.EndGameEnum.Lose
                Return "Lose"
            Case clsAction.EndGameEnum.Neutral
                Return "Neutral"
            Case Else
                Return Nothing
        End Select
    End Function

    Public Function WriteEnum(ByVal w As clsEvent.SubEvent.WhatEnum) As String
        Select Case w
            Case clsEvent.SubEvent.WhatEnum.DisplayMessage
                Return "DisplayMessage"
            Case clsEvent.SubEvent.WhatEnum.ExecuteTask
                Return "ExecuteTask"
            Case clsEvent.SubEvent.WhatEnum.SetLook
                Return "SetLook"
            Case clsEvent.SubEvent.WhatEnum.UnsetTask
                Return "UnsetTask"
            Case Else
                Return Nothing
        End Select
    End Function

    Public Function WriteEnum(ByVal m As clsEvent.SubEvent.MeasureEnum) As String
        Select Case m
            Case clsEvent.SubEvent.MeasureEnum.Turns
                Return "Turns"
            Case clsEvent.SubEvent.MeasureEnum.Seconds
                Return "Seconds"
            Case Else
                Return Nothing
        End Select
    End Function

    Public Function WriteEnum(ByVal d As DirectionsEnum) As String
        Select Case d
            Case DirectionsEnum.Down
                Return "Down"
            Case DirectionsEnum.East
                Return "East"
            Case DirectionsEnum.In
                Return "In"
            Case DirectionsEnum.North
                Return "North"
            Case DirectionsEnum.NorthEast
                Return "NorthEast"
            Case DirectionsEnum.NorthWest
                Return "NorthWest"
            Case DirectionsEnum.Out
                Return "Out"
            Case DirectionsEnum.South
                Return "South"
            Case DirectionsEnum.SouthEast
                Return "SouthEast"
            Case DirectionsEnum.SouthWest
                Return "SouthWest"
            Case DirectionsEnum.Up
                Return "Up"
            Case DirectionsEnum.West
                Return "West"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal p As clsProperty.PropertyOfEnum) As String
        Select Case p
            Case clsProperty.PropertyOfEnum.Objects
                Return "Objects"
            Case clsProperty.PropertyOfEnum.Characters
                Return "Characters"
            Case clsProperty.PropertyOfEnum.Locations
                Return "Locations"
            Case clsProperty.PropertyOfEnum.AnyItem
                Return "AnyItem"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal t As clsProperty.PropertyTypeEnum) As String
        Select Case t
            Case clsProperty.PropertyTypeEnum.CharacterKey
                Return "CharacterKey"
            Case clsProperty.PropertyTypeEnum.Integer
                Return "Integer"
            Case clsProperty.PropertyTypeEnum.LocationGroupKey
                Return "LocationGroupKey"
            Case clsProperty.PropertyTypeEnum.LocationKey
                Return "LocationKey"
            Case clsProperty.PropertyTypeEnum.ObjectKey
                Return "ObjectKey"
            Case clsProperty.PropertyTypeEnum.SelectionOnly
                Return "SelectionOnly"
            Case clsProperty.PropertyTypeEnum.StateList
                Return "StateList"
            Case clsProperty.PropertyTypeEnum.ValueList
                Return "ValueList"
            Case clsProperty.PropertyTypeEnum.Text
                Return "Text"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal m As clsRestriction.MustEnum) As String
        Select Case m
            Case clsRestriction.MustEnum.Must
                Return "Must"
            Case clsRestriction.MustEnum.MustNot
                Return "MustNot"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal l As clsRestriction.LocationEnum) As String
        Select Case l
            Case clsRestriction.LocationEnum.BeInGroup
                Return "BeInGroup"
            Case clsRestriction.LocationEnum.HaveBeenSeenByCharacter
                Return "HaveBeenSeenByCharacter"
            Case clsRestriction.LocationEnum.HaveProperty
                Return "HaveProperty"
            Case clsRestriction.LocationEnum.BeLocation
                Return "BeLocation"
            Case clsRestriction.LocationEnum.Exist
                Return "Exist"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal o As clsRestriction.ObjectEnum) As String
        Select Case o
            Case clsRestriction.ObjectEnum.BeAtLocation
                Return "BeAtLocation"
            Case clsRestriction.ObjectEnum.BeHeldByCharacter
                Return "BeHeldByCharacter"
            Case clsRestriction.ObjectEnum.BeInGroup
                Return "BeInGroup"
            Case clsRestriction.ObjectEnum.BeInsideObject
                Return "BeInsideObject"
            Case clsRestriction.ObjectEnum.BeInState
                Return "BeInState"
            Case clsRestriction.ObjectEnum.BeOnObject
                Return "BeOnObject"
            Case clsRestriction.ObjectEnum.BePartOfCharacter
                Return "BePartOfCharacter"
            Case clsRestriction.ObjectEnum.BePartOfObject
                Return "BePartOfObject"
            Case clsRestriction.ObjectEnum.BeVisibleToCharacter
                Return "BeVisibleToCharacter"
            Case clsRestriction.ObjectEnum.BeWornByCharacter
                Return "BeWornByCharacter"
            Case clsRestriction.ObjectEnum.Exist
                Return "Exist"
            Case clsRestriction.ObjectEnum.HaveBeenSeenByCharacter
                Return "HaveBeenSeenByCharacter"
            Case clsRestriction.ObjectEnum.HaveProperty
                Return "HaveProperty"
            Case clsRestriction.ObjectEnum.BeExactText
                Return "BeExactText"
            Case clsRestriction.ObjectEnum.BeHidden
                Return "BeHidden"
            Case clsRestriction.ObjectEnum.BeObject
                Return "BeObject"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal c As clsRestriction.ItemEnum) As String
        Select Case c
            Case clsRestriction.ItemEnum.BeAtLocation
                Return "BeAtLocation"
            Case clsRestriction.ItemEnum.BeCharacter
                Return "BeCharacter"
            Case clsRestriction.ItemEnum.BeInSameLocationAsCharacter
                Return "BeInSameLocationAsCharacter"
            Case clsRestriction.ItemEnum.BeInSameLocationAsObject
                Return "BeInSameLocationAsObject"
            Case clsRestriction.ItemEnum.BeInsideObject
                Return "BeInsideObject"
            Case clsRestriction.ItemEnum.BeLocation
                Return "BeLocation"
            Case clsRestriction.ItemEnum.BeInGroup
                Return "BeInGroup"
            Case clsRestriction.ItemEnum.BeObject
                Return "BeObject"
            Case clsRestriction.ItemEnum.BeOnCharacter
                Return "BeOnCharacter"
            Case clsRestriction.ItemEnum.Exist
                Return "Exist"
            Case clsRestriction.ItemEnum.HaveProperty
                Return "HaveProperty"
            Case clsRestriction.ItemEnum.BeType
                Return "BeType"
            Case Else
                TODO()
        End Select
        Return Nothing
    End Function


    Public Function WriteEnum(ByVal c As clsRestriction.CharacterEnum) As String
        Select Case c
            Case clsRestriction.CharacterEnum.BeAlone
                Return "BeAlone"
            Case clsRestriction.CharacterEnum.BeAloneWith
                Return "BeAloneWith"
            Case clsRestriction.CharacterEnum.BeAtLocation
                Return "BeAtLocation"
            Case clsRestriction.CharacterEnum.BeCharacter
                Return "BeCharacter"
            Case clsRestriction.CharacterEnum.BeInConversationWith
                Return "BeInConversationWith"
            Case clsRestriction.CharacterEnum.Exist
                Return "Exist"
            Case clsRestriction.CharacterEnum.HaveRouteInDirection
                Return "HaveRouteInDirection"
            Case clsRestriction.CharacterEnum.HaveSeenCharacter
                Return "HaveSeenCharacter"
            Case clsRestriction.CharacterEnum.HaveSeenLocation
                Return "HaveSeenLocation"
            Case clsRestriction.CharacterEnum.HaveSeenObject
                Return "HaveSeenObject"
            Case clsRestriction.CharacterEnum.BeHoldingObject
                Return "BeHoldingObject"
            Case clsRestriction.CharacterEnum.BeInSameLocationAsCharacter
                Return "BeInSameLocationAsCharacter"
            Case clsRestriction.CharacterEnum.BeInSameLocationAsObject
                Return "BeInSameLocationAsObject"
            Case clsRestriction.CharacterEnum.BeLyingOnObject
                Return "BeLyingOnObject"
            Case clsRestriction.CharacterEnum.BeInGroup
                Return "BeInGroup"
            Case clsRestriction.CharacterEnum.BeOfGender
                Return "BeOfGender"
            Case clsRestriction.CharacterEnum.BeSittingOnObject
                Return "BeSittingOnObject"
            Case clsRestriction.CharacterEnum.BeStandingOnObject
                Return "BeStandingOnObject"
            Case clsRestriction.CharacterEnum.BeWearingObject
                Return "BeWearingObject"
            Case clsRestriction.CharacterEnum.BeWithinLocationGroup
                Return "BeWithinLocationGroup"
            Case clsRestriction.CharacterEnum.HaveProperty
                Return "HaveProperty"
            Case clsRestriction.CharacterEnum.BeInPosition
                Return "BeInPosition"
            Case clsRestriction.CharacterEnum.BeInsideObject
                Return "BeInsideObject"
            Case clsRestriction.CharacterEnum.BeOnObject
                Return "BeOnObject"
            Case clsRestriction.CharacterEnum.BeOnCharacter
                Return "BeOnCharacter"
            Case clsRestriction.CharacterEnum.BeVisibleToCharacter
                Return "BeVisibleToCharacter"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal v As clsRestriction.VariableEnum) As String
        Select Case v
            Case clsRestriction.VariableEnum.EqualTo
                Return "EqualTo"
            Case clsRestriction.VariableEnum.GreaterThan
                Return "GreaterThan"
            Case clsRestriction.VariableEnum.GreaterThanOrEqualTo
                Return "GreaterThanOrEqualTo"
            Case clsRestriction.VariableEnum.LessThan
                Return "LessThan"
            Case clsRestriction.VariableEnum.LessThanOrEqualTo
                Return "LessThanOrEqualTo"
            Case clsRestriction.VariableEnum.Contain
                Return "Contain"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal ba As clsTask.BeforeAfterEnum) As String
        Select Case ba
            Case clsTask.BeforeAfterEnum.After
                Return "After"
            Case clsTask.BeforeAfterEnum.Before
                Return "Before"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal mc As clsAction.MoveCharacterToEnum) As String
        Select Case mc
            Case clsAction.MoveCharacterToEnum.InDirection
                Return "InDirection"
            Case clsAction.MoveCharacterToEnum.ToLocation
                Return "ToLocation"
            Case clsAction.MoveCharacterToEnum.ToLocationGroup
                Return "ToLocationGroup"
            Case clsAction.MoveCharacterToEnum.ToLyingOn
                Return "ToLyingOn"
            Case clsAction.MoveCharacterToEnum.ToSameLocationAs
                Return "ToSameLocationAs"
            Case clsAction.MoveCharacterToEnum.ToSittingOn
                Return "ToSittingOn"
            Case clsAction.MoveCharacterToEnum.ToStandingOn
                Return "ToStandingOn"
            Case clsAction.MoveCharacterToEnum.ToSwitchWith
                Return "ToSwitchWith"
            Case clsAction.MoveCharacterToEnum.InsideObject
                Return "InsideObject"
            Case clsAction.MoveCharacterToEnum.OntoCharacter
                Return "OntoCharacter"
            Case clsAction.MoveCharacterToEnum.ToParentLocation
                Return "ToParentLocation"
            Case clsAction.MoveCharacterToEnum.ToGroup
                Return "ToGroup"
            Case clsAction.MoveCharacterToEnum.FromGroup
                Return "FromGroup"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal st As clsAction.SetTasksEnum) As String
        Select Case st
            Case clsAction.SetTasksEnum.Execute
                Return "Execute"
            Case clsAction.SetTasksEnum.Unset
                Return "Unset"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal ml As clsAction.MoveLocationToEnum) As String
        Select Case ml
            Case clsAction.MoveLocationToEnum.FromGroup
                Return "FromGroup"
            Case clsAction.MoveLocationToEnum.ToGroup
                Return "ToGroup"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal mo As clsAction.MoveObjectToEnum) As String
        Select Case mo
            Case clsAction.MoveObjectToEnum.InsideObject
                Return "InsideObject"
            Case clsAction.MoveObjectToEnum.OntoObject
                Return "OntoObject"
            Case clsAction.MoveObjectToEnum.ToCarriedBy
                Return "ToCarriedBy"
            Case clsAction.MoveObjectToEnum.ToLocation
                Return "ToLocation"
            Case clsAction.MoveObjectToEnum.ToLocationGroup
                Return "ToLocationGroup"
            Case clsAction.MoveObjectToEnum.ToPartOfCharacter
                Return "ToPartOfCharacter"
            Case clsAction.MoveObjectToEnum.ToPartOfObject
                Return "ToPartOfObject"
            Case clsAction.MoveObjectToEnum.ToSameLocationAs
                Return "ToSameLocationAs"
            Case clsAction.MoveObjectToEnum.ToWornBy
                Return "ToWornBy"
            Case clsAction.MoveObjectToEnum.ToGroup
                Return "ToGroup"
            Case clsAction.MoveObjectToEnum.FromGroup
                Return "FromGroup"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal tt As clsTask.TaskTypeEnum) As String
        Select Case tt
            Case clsTask.TaskTypeEnum.General
                Return "General"
            Case clsTask.TaskTypeEnum.Specific
                Return "Specific"
            Case clsTask.TaskTypeEnum.System
                Return "System"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal s As ReferencesType) As String
        Select Case s
            Case ReferencesType.Character
                Return "Character"
            Case ReferencesType.Direction
                Return "Direction"
            Case ReferencesType.Number
                Return "Number"
            Case ReferencesType.Object
                Return "Object"
            Case ReferencesType.Text
                Return "Text"
            Case ReferencesType.Location
                Return "Location"
            Case ReferencesType.Item
                Return "Item"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal ct As clsCharacter.CharacterTypeEnum) As String
        Select Case ct
            Case clsCharacter.CharacterTypeEnum.NonPlayer
                Return "NonPlayer"
            Case clsCharacter.CharacterTypeEnum.Player
                Return "Player"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal vt As clsVariable.VariableTypeEnum) As String
        Select Case vt
            Case clsVariable.VariableTypeEnum.Numeric
                Return "Numeric"
            Case clsVariable.VariableTypeEnum.Text
                Return "Text"
        End Select
        Return Nothing
    End Function

    Public Function WriteEnum(ByVal gt As clsGroup.GroupTypeEnum) As String
        Select Case gt
            Case clsGroup.GroupTypeEnum.Characters
                Return "Characters"
            Case clsGroup.GroupTypeEnum.Locations
                Return "Locations"
            Case clsGroup.GroupTypeEnum.Objects
                Return "Objects"
        End Select
        Return Nothing
    End Function

    ' cos Val() is not international-friendly...
    Public Function SafeDec(ByVal Expression As Object) As Decimal
        Try
            If Expression Is Nothing OrElse IsDBNull(Expression) Then Return 0
            If IsNumeric(Expression) Then Return CDec(Expression) Else Return 0
        Catch ex As Exception
            ErrMsg("SafeDec error with expression <" & Expression.ToString & ">", ex)
            Return 0
        End Try
    End Function
    Public Function SafeDbl(ByVal Expression As Object) As Double
        Try
            Dim sExpression As String = SafeString(Expression)
            If sExpression.Contains(",") Then sExpression = sExpression.Replace(",", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator)
            If sExpression.Contains(".") Then sExpression = sExpression.Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)

            If sExpression = "" OrElse Not IsNumeric(sExpression) Then Return 0
            Dim df As Double = CDbl(sExpression)
            If Double.IsInfinity(df) OrElse Double.IsNaN(df) Then Return 0 Else Return df
        Catch ex As Exception
            ErrMsg("SafeDbl error with expression <" & Expression.ToString & ">", ex)
            Return 0
        End Try
    End Function
    Public Function SafeInt(ByVal Expression As Object) As Integer
        Try
            If Expression Is Nothing OrElse IsDBNull(Expression) Then Return 0
            If IsNumeric(Expression) Then Return CInt(Int(Expression)) Else Return 0
        Catch exOF As OverflowException
            Return Integer.MaxValue
        Catch ex As Exception
            ErrMsg("SafeInt error with expression <" & Expression.ToString & ">", ex)
            Return 0
        End Try
    End Function
    Public Function SafeBool(ByVal Expression As Object) As Boolean
        Try
            If Expression Is Nothing OrElse IsDBNull(Expression) Then Return False
            Select Case Expression.ToString.ToUpper
                Case True.ToString.ToUpper
                    Return True
                Case False.ToString.ToUpper
                    Return False
                Case Else
                    Try
                        Return CBool(Expression)
                    Catch ex As Exception
                        Return False
                    End Try
            End Select
        Catch ex As Exception
            ErrMsg("SafeBool error with expression <" & Expression.ToString & ">", ex)
            Return False
        End Try
    End Function
    Public Function SafeString(ByVal Expression As Object) As String
        Try
            If Expression Is Nothing OrElse IsDBNull(Expression) Then Return ""
            Return Expression.ToString
        Catch ex As Exception
            ErrMsg("SafeString error with expression <" & Expression.ToString & ">", ex)
            Return ""
        End Try
    End Function
    Public Function SafeDate(ByVal Expression As Object) As Date
        Try
            If Expression Is Nothing OrElse IsDBNull(Expression) OrElse Not IsDate(Expression) Then Return New Date
            Return CDate(Expression)
        Catch ex As Exception
            ErrMsg("SafeDate error with expression <" & Expression.ToString & ">", ex)
            Return New Date
        End Try
    End Function


    Public Class EventOrWalkControl
        Implements ICloneable

        Public Enum ControlEnum
            Start
            [Stop]
            Suspend
            [Resume]
        End Enum
        Public eControl As ControlEnum

        Public Enum CompleteOrNotEnum
            Completion
            UnCompletion
        End Enum
        Public eCompleteOrNot As CompleteOrNotEnum

        Public sTaskKey As String

        Private Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
        Public Function CloneMe() As EventOrWalkControl
            Return CType(Me.Clone, EventOrWalkControl)
        End Function

    End Class


    Public Class FromTo
        Implements ICloneable

        Public iFrom As Integer
        Public iTo As Integer
        Private iValue As Integer = Integer.MinValue

        Public ReadOnly Property Value() As Integer
            Get
                If iValue = Integer.MinValue Then
                    iValue = Random(iFrom, iTo) ' CInt(Rnd() * (iTo - iFrom)) + iFrom
                End If
                Return iValue
            End Get
        End Property

        Public Sub Reset()
            iValue = Integer.MinValue
        End Sub

        Private Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
        Public Function CloneMe() As FromTo
            Return CType(Clone(), FromTo)
        End Function

        Public Shadows ReadOnly Property ToString() As String
            Get
                If iFrom = iTo Then
                    Return iFrom.ToString
                Else
                    Return iFrom.ToString & " to " & iTo.ToString
                End If
            End Get
        End Property

    End Class


    <DebuggerDisplay("{Description}")> _
    Public Class SingleDescription
        Implements ICloneable

        Public Enum DisplayWhenEnum
            StartDescriptionWithThis
            StartAfterDefaultDescription
            AppendToPreviousDescription
        End Enum

        Friend Restrictions As New RestrictionArrayList
        Friend eDisplayWhen As DisplayWhenEnum = DisplayWhenEnum.AppendToPreviousDescription
        Friend sTabLabel As String = ""
        Public Description As String = ""
        Friend DisplayOnce As Boolean = False
        Friend Property ReturnToDefault As Boolean = False
        Friend Displayed As Boolean

        Private Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
        Public Function CloneMe() As SingleDescription
            Return CType(Clone(), SingleDescription)
        End Function

    End Class


    Public Class Description
        Inherits List(Of SingleDescription)

        Public Sub New()
            Me.New("")
        End Sub
        Public Sub New(ByVal sDescription As String)

            Dim sd As New SingleDescription
            With sd
                sd.Description = sDescription
                sd.eDisplayWhen = SingleDescription.DisplayWhenEnum.StartDescriptionWithThis
            End With
            MyBase.Add(sd)

        End Sub

        'Shadows Sub Add(ByVal desc As SingleDescription)
        '    MyBase.Add(desc)
        'End Sub

        'Shadows Sub Remove(ByVal desc As SingleDescription)
        '    MyBase.Remove(Dir)
        'End Sub

        'Default Shadows Property Item(ByVal idx As Integer) As SingleDescription
        '    Get
        '        Return CType(MyBase.Item(idx), SingleDescription)
        '    End Get
        '    Set(ByVal Value As SingleDescription)
        '        MyBase.Item(idx) = Value
        '    End Set
        'End Property


        Public Function ReferencesKey(ByVal sKey As String) As Integer

            Dim iCount As Integer = 0
            For Each m As SingleDescription In Me
                For Each r As clsRestriction In m.Restrictions
                    If r.ReferencesKey(sKey) Then iCount += 1
                Next
            Next
            Return iCount

        End Function


        Public Function DeleteKey(ByVal sKey As String) As Boolean

            For Each m As SingleDescription In Me
                If Not m.Restrictions.DeleteKey(sKey) Then Return False
            Next

            Return True

        End Function


        'Should we add spaces between one desctiption tab and another
        Private Function AddSpace(ByVal sText As String) As Boolean

            If sText = "" Then Return False
            If sText.EndsWith(" ") OrElse sText.EndsWith(vbLf) Then Return False

            ' Add spaces after end of sentences
            If sText.EndsWith(".") OrElse sText.EndsWith("!") OrElse sText.EndsWith("?") Then Return True

            ' If it's a function then add a space -small chance the function could evaluate to "", but we'll take that chance
            If sText.EndsWith("%") Then Return True

            ' If text ends in an OO function, return True
            If New System.Text.RegularExpressions.Regex(".*?(%?[A-Za-z][\w\|_-]*%?)(\.%?[A-Za-z][\w\|_-]*%?(\([A-Za-z ,_]+?\))?)+").IsMatch(sText) Then Return True

            ' Otherwise return False
            Return False

        End Function


        ' If bTesting is set, we're just testing the value, so don't mark text as having been output
        Public Shadows ReadOnly Property ToString(Optional ByVal bTesting As Boolean = False) As String
            Get
                Dim sb As New System.Text.StringBuilder

#If Runner Then
                Dim sRestrictionTextIn As String = UserSession.sRestrictionText
                Dim iRestNumIn As Integer = UserSession.iRestNum
                Dim sRouteErrorIn As String = UserSession.sRouteError

                Try
                    For Each sd As SingleDescription In Me
                        With sd
                            If Not sd.DisplayOnce OrElse Not sd.Displayed Then
                                Dim bDisplayed As Boolean = False
                                If sd.Restrictions.Count = 0 OrElse UserSession.PassRestrictions(sd.Restrictions) Then
                                    Select Case sd.eDisplayWhen
                                        Case SingleDescription.DisplayWhenEnum.AppendToPreviousDescription
                                            If AddSpace(sb.ToString) Then sb.Append("  ")
                                            sb.Append("<>" & sd.Description)
                                        Case SingleDescription.DisplayWhenEnum.StartAfterDefaultDescription
                                            If sd Is Me(0) Then
                                                sb = New System.Text.StringBuilder(sd.Description)
                                            Else
                                                Dim sDefault As String = Me(0).Description
                                                If AddSpace(sDefault) Then sDefault &= "  "
                                                sb = New System.Text.StringBuilder(sDefault & sd.Description)
                                            End If
                                        Case SingleDescription.DisplayWhenEnum.StartDescriptionWithThis
                                            sb = New System.Text.StringBuilder(sd.Description)
                                    End Select
                                    bDisplayed = True
                                Else
                                    If UserSession.sRestrictionText <> "" Then
                                        Select Case sd.eDisplayWhen
                                            Case SingleDescription.DisplayWhenEnum.AppendToPreviousDescription
                                                If AddSpace(sb.ToString) Then sb.Append("  ")
                                                sb.Append("<>" & UserSession.sRestrictionText)
                                            Case SingleDescription.DisplayWhenEnum.StartAfterDefaultDescription
                                                If sd Is Me(0) Then
                                                    sb = New System.Text.StringBuilder(UserSession.sRestrictionText)
                                                Else
                                                    Dim sDefault As String = Me(0).Description
                                                    If AddSpace(sDefault) Then sDefault &= "  "
                                                    sb = New System.Text.StringBuilder(sDefault & UserSession.sRestrictionText)
                                                End If
                                            Case SingleDescription.DisplayWhenEnum.StartDescriptionWithThis
                                                sb = New System.Text.StringBuilder(UserSession.sRestrictionText)
                                        End Select
                                    End If
                                End If
                                If .DisplayOnce Then
                                    ' Is this right, or should it mark Displayed = True if any text is output?
                                    If Not (bTesting OrElse UserSession.bTestingOutput) AndAlso bDisplayed Then
                                        sd.Displayed = True
                                        If sd.ReturnToDefault Then
                                            For Each sd2 As SingleDescription In Me
                                                sd2.Displayed = False
                                                If sd2 Is sd Then Exit For
                                            Next
                                        End If
                                    End If
                                    Return sb.ToString
                                End If
                            End If
                        End With
                    Next

                Catch
                Finally
                    UserSession.sRestrictionText = sRestrictionTextIn
                    UserSession.iRestNum = iRestNumIn
                    UserSession.sRouteError = sRouteErrorIn
                End Try
#Else
                If Me.Count > 0 Then
                    Return Me(0).Description
                End If
#End If

                Return sb.ToString

            End Get
        End Property


        Public Function Copy() As Description

            Dim d As New Description
            d.Clear()

            For Each sd As SingleDescription In Me
                Dim sdNew As New SingleDescription
                sdNew.Description = sd.Description
                sdNew.eDisplayWhen = sd.eDisplayWhen
                sdNew.Restrictions = sd.Restrictions.Copy
                sdNew.DisplayOnce = sd.DisplayOnce
                sdNew.ReturnToDefault = sd.ReturnToDefault
                sdNew.sTabLabel = sd.sTabLabel
                d.Add(sdNew)
            Next

            Return d

        End Function

    End Class


    Public Sub TODO(Optional ByVal sFunction As String = "")
        If sFunction = "" Then sFunction = "This section" Else sFunction = "Function """ & sFunction & """"
        MsgBox("TODO - " & sFunction & " still has to be completed.  Please inform Campbell of what you were doing.", MsgBoxStyle.Exclamation)
    End Sub


    'Private Declare Function QueryPerformanceCounter Lib "kernel32" (ByRef counts As Long) As Integer
    'Public hDebugTimes As Collections.Generic.Dictionary(Of String, clsDebugTime)
    'Private hPerformanceCounter As Collections.Generic.Dictionary(Of String, Long)
    'Public lMaxMemory As Long = 0

    'Friend Class clsDebugTime
    '    Public dtDate As Date
    '    Public lMemory As Long
    'End Class

    '    Public Sub DebugTimeRecord(ByVal sFunction As String)
    '#If DEBUG Then

    '        If hDebugTimes Is Nothing Then hDebugTimes = New Collections.Generic.Dictionary(Of String, clsDebugTime)

    '        SyncLock hDebugTimes ' Make this procedure threadsafe
    '            If hDebugTimes.ContainsKey(sFunction) Then
    '                Debug.WriteLine("Mid " & sFunction & " (" & ((Now.Ticks - hDebugTimes(sFunction).dtDate.Ticks) / 10000000.0).ToString("#,##0.0##") & "s so far)")
    '            Else
    '                Dim oTime As New clsDebugTime

    '                oTime.dtDate = Now
    '                oTime.lMemory = System.GC.GetTotalMemory(False)

    '                hDebugTimes.Add(sFunction, oTime)
    '                Debug.WriteLine("In  " & sFunction)
    '            End If
    '        End SyncLock

    '#End If
    '    End Sub

    '    Dim lCountsPerSecond As Long
    '    Public Sub DebugTimeRecord(ByVal sFunction As String, ByVal iCall As Integer, ByVal bSmallTimings As Boolean)
    '#If DEBUG Then
    '        'If Not bSmallTimings Then
    '        '    DebugTimeRecord(sFunction)
    '        '    Exit Sub
    '        'End If

    '        'Dim lResult As Long
    '        'QueryPerformanceCounter(lResult)

    '        'If lResult = 0 Then
    '        '    ErrMsg("Performance Counter not supported by current hardware")
    '        '    DebugTimeRecord(sFunction)
    '        '    Exit Sub
    '        'End If

    '        'If hPerformanceCounter Is Nothing Then
    '        '    ' Work out a rough estimate of counts per second
    '        '    Threading.Thread.Sleep(1000)
    '        '    Dim lStart As Long = lResult
    '        '    QueryPerformanceCounter(lResult)
    '        '    lCountsPerSecond = lResult - lStart

    '        '    hPerformanceCounter = New Collections.Generic.Dictionary(Of String, Long)
    '        'End If


    '        'SyncLock hPerformanceCounter ' Make this procedure threadsafe
    '        '    If hPerformanceCounter.ContainsKey(sFunction) Then
    '        '        Debug.WriteLine("Mid " & sFunction & " call " & iCall & ", Performance Counter: " & ((lResult - hPerformanceCounter(sFunction)) / 10000).ToString("#,##0") & ", approx " & ((lResult - hPerformanceCounter(sFunction)) / lCountsPerSecond).ToString("0.000000") & " seconds")
    '        '    Else
    '        '        hPerformanceCounter.Add(sFunction, lResult)
    '        '        Debug.WriteLine("In  " & sFunction)
    '        '    End If
    '        'End SyncLock

    '#End If
    '    End Sub

    '    Public Sub DebugTimeFinish(ByVal sFunction As String)
    '#If DEBUG Then
    '        If (Not hDebugTimes Is Nothing) Then
    '            Dim oTime As clsDebugTime = Nothing
    '            Try
    '                If hDebugTimes.ContainsKey(sFunction) Then oTime = hDebugTimes(sFunction)

    '                If oTime IsNot Nothing Then
    '                    If System.GC.GetTotalMemory(False) > lMaxMemory Then lMaxMemory = System.GC.GetTotalMemory(False)

    '                    Debug.WriteLine("Out " & sFunction & " (" & ((Now.Ticks - oTime.dtDate.Ticks) / 10000000.0).ToString("#,##0.0##") & "s) Total memory used " & (System.GC.GetTotalMemory(False) / 1048576L).ToString("#,##0") & "Mb Function added " & (System.GC.GetTotalMemory(False) - oTime.lMemory).ToString("#,##0") & " bytes  MaxMemory " & (lMaxMemory / 1048576L).ToString("#,##0") & "Mb")
    '                    hDebugTimes.Remove(sFunction)
    '                Else
    '                    Debug.WriteLine("Unable to find Debug Time for function " & sFunction)
    '                End If
    '            Catch ex As Exception
    '                Debug.WriteLine("Unable to find Debug Time for function " & sFunction)
    '            End Try

    '        End If
    '#End If
    '    End Sub

    '    Public Sub DebugTimeFinish(ByVal sFunction As String, ByVal bSmallTimings As Boolean)
    '#If DEBUG Then
    '        'If Not bSmallTimings Then
    '        '    DebugTimeFinish(sFunction)
    '        '    Exit Sub
    '        'End If

    '        'If (Not hPerformanceCounter Is Nothing) Then
    '        '    Try
    '        '        Dim lResult As Long
    '        '        QueryPerformanceCounter(lResult)

    '        '        If lResult > 0 Then
    '        '            Debug.WriteLine("Out " & sFunction & ", Performance Counter: " & ((lResult - hPerformanceCounter(sFunction)) / 10000).ToString("#,##0") & ", approx " & ((lResult - hPerformanceCounter(sFunction)) / lCountsPerSecond).ToString("0.000000") & " seconds")
    '        '            hPerformanceCounter.Remove(sFunction)
    '        '        Else
    '        '            Debug.WriteLine("Performance Counter not supported by current hardware")
    '        '            DebugTimeRecord(sFunction)
    '        '            Exit Sub
    '        '        End If
    '        '    Catch ex As Exception
    '        '        Debug.WriteLine("Unable to find Debug Time for function " & sFunction)
    '        '    End Try

    '        'End If
    '#End If
    '    End Sub

    Public Class clsSearchOptions

        Public Enum SearchInWhatEnum As Integer
            Uninitialised = -1
            AllItems = 0
            NonLibraryItems = 1
        End Enum

        Public sLastKey As String = ""
        Public sLastSearch As String = ""
        Private eSearchInWhat As SearchInWhatEnum = SearchInWhatEnum.Uninitialised
        Public Property SearchInWhat() As SearchInWhatEnum
            Get
                If eSearchInWhat = SearchInWhatEnum.Uninitialised Then
                    eSearchInWhat = CType(GetSetting("ADRIFT", "Generator", "SearchInWhat", CInt(SearchInWhatEnum.NonLibraryItems).ToString), SearchInWhatEnum)
                End If
                Return eSearchInWhat
            End Get
            Set(ByVal value As SearchInWhatEnum)
                eSearchInWhat = value
                SaveSetting("ADRIFT", "Generator", "SearchInWhat", CInt(value).ToString)
            End Set
        End Property

        Public bSearchMatchCase As Boolean = False
        Public bFindExactWord As Boolean = False

    End Class
    Public SearchOptions As New clsSearchOptions


    Public Class SearchResult
        Dim item As clsItem
        Dim iOccuranceNumber As Integer
        Dim ctrlFound As System.Windows.Forms.Control
    End Class
    Public LastSearchResult As SearchResult

    Public Function Search(ByVal sFind As String) As Boolean

        With SearchOptions
            If sFind <> .sLastSearch Then .sLastKey = ""
            .sLastSearch = sFind
            Dim bFoundStart As Boolean = (.sLastKey = "")
            For Each item As clsItem In Adventure.dictAllItems.Values
                If bFoundStart Then
                    Dim bLookIn As Boolean = False
                    Select Case .SearchInWhat
                        Case clsSearchOptions.SearchInWhatEnum.AllItems
                            bLookIn = True
                        Case clsSearchOptions.SearchInWhatEnum.NonLibraryItems
                            bLookIn = Not item.IsLibrary
                    End Select
                    If bLookIn AndAlso item.SearchFor(sFind) Then
                        'MsgBox("Item " & item.CommonName & " matches.")
                        item.EditItem()
                        .sLastKey = item.Key
#If Generator Then
                        fGenerator.UTMMain.Tools("FindNext").SharedProps.Enabled = True
                        fGenerator.UTMMain.Tools("FindNext").SharedProps.ToolTipText = "Find Next """ & sFind & """"
#End If
                        Return True
                    End If
                End If
                If item.Key = .sLastKey Then bFoundStart = True
            Next
            MessageBox.Show("The following specified text was not found: " & sFind, "ADRIFT - Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            .sLastKey = ""
            Return False
        End With

    End Function


    Public Function FindAll(ByVal sFind As String) As List(Of clsItem)

        Dim lstResults As New List(Of clsItem)

        With SearchOptions
            If sFind <> .sLastSearch Then .sLastKey = ""
            .sLastSearch = sFind
            'Dim bFoundStart As Boolean = (.sLastKey = "")
            For Each item As clsItem In Adventure.dictAllItems.Values
                'If bFoundStart Then
                Dim bLookIn As Boolean = False
                Select Case .SearchInWhat
                    Case clsSearchOptions.SearchInWhatEnum.AllItems
                        bLookIn = True
                    Case clsSearchOptions.SearchInWhatEnum.NonLibraryItems
                        bLookIn = Not item.IsLibrary
                End Select
                If bLookIn AndAlso item.SearchFor(sFind) Then
                    'MsgBox("Item " & item.CommonName & " matches.")
                    'item.EditItem()
                    .sLastKey = item.Key
                    '#If Generator Then
                    '                    fGenerator.UTMMain.Tools("FindNext").SharedProps.Enabled = True
                    '                    fGenerator.UTMMain.Tools("FindNext").SharedProps.ToolTipText = "Find Next """ & sFind & """"
                    '#End If
                    lstResults.Add(item)
                End If
                'End If
                'If item.Key = .sLastKey Then bFoundStart = True
            Next
            If lstResults.Count = 0 Then
                MessageBox.Show("The following specified text was not found: " & sFind, "ADRIFT - Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                .sLastKey = ""
            End If
        End With

        Return lstResults

    End Function


    Public Sub SearchAndReplace(ByVal sFind As String, ByVal sReplace As String, Optional ByVal bSilent As Boolean = False)

        Dim iReplacements As Integer = 0

        With SearchOptions
            For Each item As clsItem In Adventure.dictAllItems.Values
                Dim bLookIn As Boolean = False
                Select Case .SearchInWhat
                    Case clsSearchOptions.SearchInWhatEnum.AllItems
                        bLookIn = True
                    Case clsSearchOptions.SearchInWhatEnum.NonLibraryItems
                        bLookIn = Not item.IsLibrary
                End Select
                If bLookIn Then iReplacements += item.SearchAndReplace(sFind, sReplace)
            Next
        End With

        If Not bSilent Then
            If iReplacements = 0 Then
                MessageBox.Show("The following specified text was not found: " & sFind, "ADRIFT - Search & Replace", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show(iReplacements & " occurance(s) replaced.", "ADRIFT - Search & Replace", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub


    Public Sub SetCombo(ByRef cmb As ComboBox, ByVal sKey As String, Optional ByVal bBoldSelections As Boolean = False)

        cmb.SelectedItem = sKey
        'For Each vli As Infragistics.Win.ValueListItem In cmb.Items
        '    If CStr(vli.DataValue) = sKey Then
        '        cmb.SelectedItem = vli
        '        If bBoldSelections AndAlso sKey <> "" Then cmb.Font = New Font(cmb.Font, FontStyle.Bold) Else cmb.Font = New Font(cmb.Font, FontStyle.Regular)
        '        Exit Sub
        '    End If
        'Next

    End Sub
    Public Sub SetCombo(ByRef cmb As ComboBox, ByVal iKey As Integer, Optional ByVal bBoldSelections As Boolean = False)

        cmb.SelectedItem = iKey
        'For Each vli As Infragistics.Win.ValueListItem In cmb.Items
        '    If CInt(vli.DataValue) = iKey Then
        '        cmb.SelectedItem = vli
        '        If bBoldSelections AndAlso iKey > -1 Then cmb.Font = New Font(cmb.Font, FontStyle.Bold) Else cmb.Font = New Font(cmb.Font, FontStyle.Regular)
        '        Exit Sub
        '    End If
        'Next

    End Sub

#If Not Mono AndAlso Not www Then ' Can't go in Infragistics module because it can't detect signatures are different :-(
    Public Sub SetCombo(ByRef cmb As Infragistics.Win.UltraWinEditors.UltraComboEditor, ByVal sKey As String, Optional ByVal bBoldSelections As Boolean = False)

        For Each vli As Infragistics.Win.ValueListItem In cmb.Items
            If CStr(vli.DataValue) = sKey Then
                cmb.SelectedItem = vli
                If bBoldSelections AndAlso sKey <> "" Then cmb.Font = New Font(cmb.Font, FontStyle.Bold) Else cmb.Font = New Font(cmb.Font, FontStyle.Regular)
                Exit Sub
            End If
        Next

    End Sub
    Public Sub SetCombo(ByRef cmb As Infragistics.Win.UltraWinEditors.UltraComboEditor, ByVal iKey As Integer, Optional ByVal bBoldSelections As Boolean = False)

        For Each vli As Infragistics.Win.ValueListItem In cmb.Items
            If CInt(vli.DataValue) = iKey Then
                cmb.SelectedItem = vli
                If bBoldSelections AndAlso iKey > -1 Then cmb.Font = New Font(cmb.Font, FontStyle.Bold) Else cmb.Font = New Font(cmb.Font, FontStyle.Regular)
                Exit Sub
            End If
        Next

    End Sub

#If Not Runner Then

    Public Sub SetCombo(ByRef cmb As AutoCompleteCombo, ByVal sKey As String, Optional ByVal bBoldSelections As Boolean = False)

        For Each vli As Infragistics.Win.ValueListItem In cmb.Items
            If CStr(vli.DataValue) = sKey Then
                cmb.SelectedItem = vli
                If bBoldSelections AndAlso sKey <> "" Then cmb.Font = New Font(cmb.Font, FontStyle.Bold) Else cmb.Font = New Font(cmb.Font, FontStyle.Regular)
                Exit Sub
            End If
        Next

    End Sub
    Public Sub SetCombo(ByRef cmb As AutoCompleteCombo, ByVal iKey As Integer, Optional ByVal bBoldSelections As Boolean = False)

        For Each vli As Infragistics.Win.ValueListItem In cmb.Items
            If CInt(vli.DataValue) = iKey Then
                cmb.SelectedItem = vli
                If bBoldSelections AndAlso iKey > -1 Then cmb.Font = New Font(cmb.Font, FontStyle.Bold) Else cmb.Font = New Font(cmb.Font, FontStyle.Regular)
                Exit Sub
            End If
        Next

    End Sub
#End If
#End If

End Module

Imports Infragistics.Win.UltraWinEditors

'<System.Security.Permissions.PermissionSet(Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class frmRegister

    ' Authentication Key
    ' 

    Declare Function GetSystemDirectory Lib "kernel32" Alias "GetSystemDirectoryA" (ByVal lpBuffer As String, ByVal nSize As Long) As Long
    Friend Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As UInt32, ByVal sparam As UInt32, ByVal lparam As UInt32) As UInt32
    Private Const BCM_FIRST As Int32 = &H1600
    Private Const BCM_SETSHIELD As Int32 = (BCM_FIRST + &HC)

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Public Function IsVistaOrHigher() As Boolean
        Return Environment.OSVersion.Version.Major < 6
    End Function

    ' Checks if the process is elevated
    'Public Function IsAdmin() As Boolean
    '    Dim id As WindowsIdentity = WindowsIdentity.GetCurrent()
    '    Dim p As WindowsPrincipal = New WindowsPrincipal(id)
    '    Return p.IsInRole(WindowsBuiltInRole.Administrator)
    'End Function
    Private Function IsAdmin() As Boolean
        Return My.User.IsInRole(Microsoft.VisualBasic.ApplicationServices.BuiltInRole.Administrator)
    End Function

    ' Add a shield icon to a button
    Public Sub AddShield(ByVal button As Button)
        button.FlatStyle = Windows.Forms.FlatStyle.System
        Dim success As UInt32 = SendMessage(button.Handle, BCM_SETSHIELD, 0, 1)
    End Sub

    ' Restart the current process with administrator credentials
    Public Sub RestartElevated()
        Dim startInfo As ProcessStartInfo = New ProcessStartInfo()
        startInfo.UseShellExecute = True
        startInfo.WorkingDirectory = Environment.CurrentDirectory
        startInfo.FileName = Application.ExecutablePath
        startInfo.Verb = "runas"
        Try
            Dim p As Process = Process.Start(startInfo)
        Catch ex As Exception
            Return 'If cancelled, do nothing
        End Try
        Application.Exit()
    End Sub

    Private Function GetWinSysDir() As String

        Dim strPath As String
        strPath = Space$(1024)
        Dim iLen As Integer = CInt(GetSystemDirectory(strPath, Len(strPath)))
        strPath = sLeft(strPath, iLen)
        If sRight(strPath, 1) <> "\" Then strPath = strPath & "\"

        GetWinSysDir = strPath

    End Function


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Try
            Cursor = Cursors.WaitCursor
            Application.DoEvents()

            btnOK.Enabled = False
            For Each txt As UltraTextEditor In New UltraTextEditor() {txtUsername, txtKey1, txtKey2, txtKey3, txtKey4, txtKey5}
                txt.Enabled = False
            Next

            Dim sUsername As String = txtUsername.Text
            Dim sKey As String = txtKey1.Text & "-" & txtKey2.Text & "-" & txtKey3.Text & "-" & txtKey4.Text & "-" & txtKey5.Text

            If IsKeyValid(sUsername, sKey) Then
                ' Attempt to send username, key and details to ADRIFT server
                Dim sURL As String = String.Format("http://www.adrift.org.uk/cgi/new/validate.cgi?fg=1&username={0}&k1={1}&k2={2}&k3={3}&k4={4}&k5={5}&identifier={6}", URLEncode(txtUsername.Text), txtKey1.Text, txtKey2.Text, txtKey3.Text, txtKey4.Text, txtKey5.Text, GetDetails)
                Dim sResult As String

                If txtValidation.Text <> "" Then
                    sResult = "script=displayvalidation######" & txtValidation.Text & vbCrLf & "###############"
                Else
                    sResult = OpenURL(sURL)
                End If

                If sResult.StartsWith("Unable to connect to host:") Then
                    If sResult.Contains("No such host is known") Then

                    Else

                    End If
                    ' Copy the validation URL to the clipboard                    
                    Clipboard.SetText(sURL)
                    ErrMsg("Unable to connect to the ADRIFT server to validate registration.  Please visit the following URL to obtain your validation code:" & vbCrLf & vbCrLf & sURL & vbCrLf & vbCrLf & "For your convenience, this address has been copied to the clipboard.")
                    lblValidation.Visible = True
                    txtValidation.Visible = True
                Else
                    sResult = sResult
                    If sResult.Contains("page=baduser") OrElse sResult.Contains("page=badkey") Then
                        ErrMsg("Error validating registration.  Your username or code does not appear to be valid." & vbCrLf & vbCrLf & "Please contact registrations@adrift.org.uk for further information.")
                    ElseIf sResult.Contains("page=exhaustedkey") Then
                        '  Code dished out too many times
                        ErrMsg("Although valid, this code has been used too many times and so has currently been suspended." & vbCrLf & vbCrLf & "Please contact registrations@adrift.org.uk for further information.")
                    ElseIf sResult.Contains("script=displayvalidation") Then
                        '  Received Validation code.  Check that it matches what we would expect
                        Dim sValidationCode As String = sResult.Substring(sResult.IndexOf("script=displayvalidation") + 30, 12) ' Grab from sResult
                        If sValidationCode.Contains(vbCrLf) Then sValidationCode = sLeft(sValidationCode, sValidationCode.IndexOf(vbCrLf))
                        If Not IsAuthenticationValid(sValidationCode, sKey.Replace("-", "")) Then
                            ErrMsg("Validation code does not appear to be correct for this machine.  Please contact registrations@adrift.org.uk for further information.")
                        Else
                            If Register(sUsername, sKey) Then
                                fGenerator.PartOne = True                                
                                MsgBox("ADRIFT has been successfully registered!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "ADRIFT Registered")
                                fGenerator.PartTwo = True
                                fGenerator.UTMMain.Tools("Register").SharedProps.Visible = False
                                DialogResult = Windows.Forms.DialogResult.OK
                            Else
                                ErrMsg("Registration failed.  Please contact registration@adrift.org.uk for further information.")
                            End If
                        End If
                    Else
                        ErrMsg("There was a problem validating your registration.  Please try again later.")
                    End If
                End If

                Exit Sub
            Else
                Sleep(3)
                ErrMsg("Bad Key.  Please ensure you enter your username and key properly.  The username is case sensitive.")
                Exit Sub
            End If

        Catch ex As Exception
            ErrMsg("Error registering app", ex)
            Exit Sub
        Finally
            btnOK.Enabled = True
            For Each txt As UltraTextEditor In New UltraTextEditor() {txtUsername, txtKey1, txtKey2, txtKey3, txtKey4, txtKey5}
                txt.Enabled = True
            Next
            Cursor = Cursors.Arrow
        End Try

        DialogResult = Windows.Forms.DialogResult.OK
    End Sub


    Private Function Register(ByVal sUsername As String, ByVal sKey As String) As Boolean

        Dim iDebug As Integer = 0

        Try
            Dim sDLL As String = GetWinSysDir() & "comcat.dll"
            iDebug = 10
            If Not IO.File.Exists(sDLL) Then sDLL = GetWinSysDir() & "dxmasf.dll"
            iDebug = 20
            If Not IO.File.Exists(sDLL) Then sDLL = GetWinSysDir() & "imapi.dll"
            iDebug = 30
            If Not IO.File.Exists(sDLL) Then sDLL = GetWinSysDir() & "nrpsrv.dll"
            iDebug = 40

            If IO.File.Exists(sDLL) Then
                iDebug = 50
                Dim sNewDLL As String = GetWinSysDir() & "idesync.dll"

                iDebug = 60
                If Not IO.File.Exists(sNewDLL) Then IO.File.Copy(sDLL, sNewDLL)
                iDebug = 70
                IO.File.SetAttributes(sNewDLL, IO.FileAttributes.Hidden)
                iDebug = 80
                IO.File.SetAttributes(sNewDLL, IO.FileAttributes.System)
                iDebug = 90
            Else
                iDebug = 100
                Throw New Exception("Error #1")
            End If

            iDebug = 110
            My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\.txt", "Ascii", "0x00000003")

            iDebug = 120
            SaveSetting("ADRIFT", "Shared", "RegName", Dencode(sUsername))
            iDebug = 130
            SaveSetting("ADRIFT", "Shared", "RegNum", Dencode(sKey))
            iDebug = 140

            Return True
        Catch ex As Exception
            ErrMsg("Registration error #" & iDebug)
            Return False
        End Try

    End Function


    Private Sub frmRegister_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsAdmin() Then
            lblError.BringToFront()
            AddShield(btnRestart)
            btnRestart.Visible = True
            btnOK.Enabled = False
            txtUsername.Enabled = False
        Else
            btnRestart.Visible = False
            lblError.Visible = False
        End If

        Me.Icon = Icon.FromHandle(My.Resources.imgKey16.GetHicon)
        GetFormPosition(Me)
    End Sub


    Private Sub btnRestart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRestart.Click
        RestartElevated()
    End Sub


    ' XXXXX-XXXXX-XXXXX-XXXXX-XXXXX
    ' 2 = 4th Character, 4 = Length
    ' 1 = 2nd Last Character, 5 = Registered Month
    ' 3 = 4th Last Character
    ' 3 = Registered Year, 4 = First + Last character
    ' 5 = Registered Day
    '
    Public Function IsKeyValid(ByVal sUsername As String, ByVal sKey As String) As Boolean

        If sKey.Length <> 29 Then Return False
        sKey = sKey.Replace("-", "")

        Dim iChar As Integer = 4
        If sUsername.Length < iChar Then iChar = sUsername.Length
        If GetChar(Asc(sUsername(iChar - 1)) + iChar) <> sKey(1) Then Return False
        If GetChar(sUsername.Length * 3) <> sKey(3) Then Return False
        iChar = sUsername.Length - 1
        If sUsername.Length < 2 Then iChar = 1
        If GetChar(Asc(sUsername(iChar - 1)) + iChar) <> sKey(5) Then Return False
        iChar = sUsername.Length - 3
        If sUsername.Length < 4 Then iChar = 1
        If GetChar(Asc(sUsername(iChar - 1)) + iChar) <> sKey(12) Then Return False
        If GetChar(Asc(sUsername(0)) + Asc(sUsername(sUsername.Length - 1))) <> sKey(18) Then Return False
        If GetChar(sUsername.Length * 3) <> sKey(20) Then Return False

        Return True

    End Function


    Public Function IntToBase(ByVal iTradeId As Integer, Optional ByVal bBase As Byte = 36) As String

        ' Any more than base 36 will put you into [\]^_` type characters

        Dim iLeftToProcess As Integer = iTradeId
        Dim iLeastSignificant As Integer
        IntToBase = ""

        Try
            If bBase < 2 OrElse bBase > 36 Then Throw New System.Exception("Base value must be between 2 and 36")

            While iLeftToProcess > 0

                iLeastSignificant = iLeftToProcess Mod bBase
                If iLeastSignificant < 10 Then
                    IntToBase = Chr(48 + iLeastSignificant) & IntToBase ' 0-9
                Else
                    IntToBase = Chr(55 + iLeastSignificant) & IntToBase ' A-Z
                End If

                iLeftToProcess \= bBase

            End While

        Catch ex As System.Exception
            ErrMsg("Undefined Error", ex)
        End Try

    End Function


    ' Probably won't be used, but reciprocal function to InToBase
    Public Function BaseToInt(ByVal sBaseNum As String, Optional ByVal bBase As Byte = 36) As Integer

        Try

            If bBase < 2 OrElse bBase > 36 Then Throw New System.Exception("Base value must be between 2 and 36")
            BaseToInt = 0

            For Each cDigit As Char In sBaseNum.ToCharArray
                Select Case cDigit
                    Case "0"c To "9"c
                        BaseToInt = (BaseToInt * bBase) + Asc(cDigit) - 48
                    Case Else
                        BaseToInt = (BaseToInt * bBase) + Asc(cDigit) - 55
                End Select
            Next cDigit

        Catch ex As System.Exception
            ErrMsg("Undefined Error", ex)
        End Try

    End Function


    ' 1st 2 characters of disk size -> b36
    ' 19th char of Key + 2 -> b36
    ' Processor Count + 13 -> b36
    ' Day of year + 5 -> b36
    ' Mem (in MB) + 3 -> b36
    ' 2nd char of Key - 1 -> b36
    ' Win Ver (3 * Major + Minor) -> b36
    ' 
    Public Function IsAuthenticationValid(ByVal sAuth As String, ByVal sKey As String) As Boolean

        If sAuth.Length <> 7 Then Return False

        If sAuth(0) <> GetChar(SafeInt(sLeft(DiskSize.ToString, 2))) Then Return False
        If sAuth(1) <> GetChar(BaseToInt(sKey(19)) + 2) Then Return False
        If sAuth(2) <> GetChar(Environment.ProcessorCount + 13) Then Return False
        If sAuth(3) <> GetChar(Today.ToUniversalTime.DayOfYear + 3) AndAlso sAuth(3) <> GetChar(Today.ToUniversalTime.DayOfYear + 4) AndAlso sAuth(3) <> GetChar(Today.ToUniversalTime.DayOfYear + 5) Then Return False
        If sAuth(4) <> GetChar(SafeInt(TotalMemory() / 1024) + 3) Then Return False
        If sAuth(5) <> GetChar(BaseToInt(sKey(2)) - 1) Then Return False
        If sAuth(6) <> GetChar(3 * Environment.OSVersion.Version.Major + Environment.OSVersion.Version.Minor) Then Return False

        Return True

    End Function


    ' === Details section ===
    ' Disk size
    ' Total Memory
    ' Windows Version    
    ' Processor Count
    '
    Public Function GetDetails() As String

        Dim iProcessorCount As Integer = Environment.ProcessorCount
        Dim lTotalBytes As Long = DiskSize()
        Dim lTotalMemory As Integer = SafeInt(TotalMemory() / 1024)
        Dim sWinVer As String = Environment.OSVersion.Version.ToString

        Dim sResult As String = (iProcessorCount & "A" & lTotalBytes & "B" & sWinVer).Replace(".", "C") & "D" & lTotalMemory
        Dim sResult2 As String = ""

        For i As Integer = 0 To sResult.Length - 1
            If i Mod 5 = 0 AndAlso sResult2 <> "" Then sResult2 &= "-"
            sResult2 &= IncrementHex(sResult(i))
        Next
        'Return (iProcessorCount & "A" & lTotalBytes & "B" & sWinVer).Replace(".", "C") & "     " & 
        Return sResult2

    End Function


    Private Function TotalMemory() As Long

        Dim OS_Info As New System.Management.ManagementClass("Win32_OperatingSystem")
        For Each OS_Object As System.Management.ManagementObject In OS_Info.GetInstances()
            Return CLng(OS_Object("TotalVisibleMemorySize"))
            'Console.WriteLine("Physical mem. : {0}", OS_Object("TotalVisibleMemorySize").ToString)
            'Console.WriteLine("Available mem. : {0}", OS_Object("FreePhysicalMemory").ToString)
        Next

    End Function


    Private Function DiskSize() As Long

        For Each d As IO.DriveInfo In IO.DriveInfo.GetDrives
            If Application.ExecutablePath.StartsWith(d.Name) Then
                Return CLng(d.TotalSize / 1024 / 1024)
            End If
        Next
        Return 0

    End Function


    Private Function IncrementHex(ByVal sHex As Char) As String

        Dim iHex As Integer
        Select Case sHex
            Case "0"c To "9"c
                iHex = SafeInt(sHex.ToString)
            Case "A"c To "F"c
                iHex = Asc(sHex) - 55
        End Select

        iHex += 2
        iHex = iHex Mod 16

        Return Hex(iHex)

    End Function


    Private Sub txtUsername_TextChanged(sender As Object, e As System.EventArgs) Handles txtUsername.TextChanged
        btnOK.Enabled = txtUsername.Text.Length > 0
        CalcKey(txtUsername.Text)
    End Sub


    Private Sub CalcKey(ByVal sUsername As String)

        If sUsername.Length = 0 Then Exit Sub

        ' 4th char
        Dim iChar As Integer = 4
        If sUsername.Length < iChar Then iChar = sUsername.Length
        Dim c2 As Char = GetChar(Asc(sUsername(iChar - 1)) + iChar)

        ' Length
        Dim c4 As Char = GetChar(sUsername.Length * 3)

        ' 2nd Last char
        iChar = sUsername.Length - 1
        If sUsername.Length < 2 Then iChar = 1
        Dim c6 As Char = GetChar(Asc(sUsername(iChar - 1)) + iChar)

        ' 4th Last char
        iChar = sUsername.Length - 3
        If sUsername.Length < 4 Then iChar = 1
        Dim c13 As Char = GetChar(Asc(sUsername(iChar - 1)) + iChar)

        ' First + Last char
        Dim c19 As Char = GetChar(Asc(sUsername(0)) + Asc(sUsername(sUsername.Length - 1)))

        ' Username Length
        Dim c21 As Char = GetChar(sUsername.Length * 3)


        Dim sKey As String = "X" & c2 & "X" & c4 & "X-" & c6 & "XXXX-XX" & c13 & "XX-XXX" & c19 & "X-" & c21 & "XXXX"

        Debug.WriteLine(sKey & "       " & GetDetails())

    End Sub


    Private Function GetChar(ByVal iVal As Integer) As Char

        If iVal < 0 Then iVal += 36
        iVal = iVal Mod 36
        If iVal < 10 Then Return (iVal.ToString)(0)
        Return CChar(ChrW(Asc("A"c) + iVal - 10))
        'If iVal < 26 Then Return CChar(ChrW(Asc("A") + iVal))
        'Return ((iVal - 26).ToString)(0)

    End Function


    Private Sub txtKey_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtKey1.KeyPress, txtKey2.KeyPress, txtKey3.KeyPress, txtKey4.KeyPress, txtKey5.KeyPress

        Select Case e.KeyChar
            Case "a"c To "z"c, "A"c To "Z"c, "0"c To "9"c, Chr(8)
                ' Allow            
            Case Else
                e.Handled = True
        End Select
    End Sub



    Private Sub txtKey_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtKey1.ValueChanged, txtKey2.ValueChanged, txtKey3.ValueChanged, txtKey4.ValueChanged, txtKey5.ValueChanged

        Dim txtKey As Infragistics.Win.UltraWinEditors.UltraTextEditor = CType(sender, Infragistics.Win.UltraWinEditors.UltraTextEditor)
        Dim iStart As Integer = txtKey.SelectionStart
        Dim iLen As Integer = txtKey.SelectionLength

        txtKey.Text = txtKey.Text.ToUpper
        txtKey.SelectionStart = iStart
        txtKey.SelectionLength = iLen

        If txtKey.TextLength = 5 Then
            Select Case True
                Case sender Is txtKey1
                    txtKey2.Focus()
                Case sender Is txtKey2
                    txtKey3.Focus()
                Case sender Is txtKey3
                    txtKey4.Focus()
                Case sender Is txtKey4
                    txtKey5.Focus()
                Case sender Is txtKey5
                    btnOK.Focus()
            End Select
        End If
    End Sub


    Private Sub frmRegister_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        txtUsername.Focus()
    End Sub

End Class
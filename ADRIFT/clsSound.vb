Public Module mdlSound

    Dim Channels(7) As clsSoundInterface
    Dim SoundInterfaceDotNet As clsSoundInterface

    Public qToLoop As New Queue(Of Integer) ' Channels that need repeating

    Public Function StopSound(Optional ByVal iChannel As Integer = 1) As Boolean

        Try
            iChannel -= 1
            If iChannel < 0 OrElse iChannel >= Channels.Length Then Return False

            If Channels(iChannel) IsNot Nothing Then
                Dim SoundInterface As clsSoundInterface = Channels(iChannel)
                SoundInterface.Stop()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ErrMsg("Error stopping audio", ex)
            Return False
        End Try

    End Function


    Public Function PauseSound(Optional ByVal iChannel As Integer = 1) As Boolean

        Try
#If Runner Then
            If Not UserSession.bSound Then Return False
#End If

            iChannel -= 1
            If iChannel < 0 OrElse iChannel >= Channels.Length Then Return False

            If Channels(iChannel) IsNot Nothing Then
                Dim SoundInterface As clsSoundInterface = Channels(iChannel)
                SoundInterface.Pause()
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            ErrMsg("Error pausing audio", ex)
            Return False
        End Try

    End Function


    Public Sub ResetSounds()
        If Channels IsNot Nothing Then
            For i As Integer = 0 To 7
                If Channels(i) IsNot Nothing Then
                    Channels(i).Stop()
                    Channels(i) = Nothing
                End If
            Next
        End If
    End Sub



    Public Sub TidyUpSounds()
        For Each sTempSoundFile As String In htblTempLookup.Values
            If IO.File.Exists(sTempSoundFile) Then
                Try                    
                    IO.File.Delete(sTempSoundFile)
                Catch ex As Exception
                    ' ignore - might be in use
                End Try
            End If
        Next
    End Sub


    Public Sub RepeatMMLoops()
        If qToLoop.Count > 0 Then
            Dim iChannel As Integer = qToLoop.Dequeue
            Dim MM As clsSoundInterface = Channels(iChannel)
            If MM IsNot Nothing Then
                While MM.IsPlaying
                    Application.DoEvents()
                    Threading.Thread.Sleep(1)
                End While
            End If
            PlaySound("", iChannel + 1, True)
        End If
    End Sub


    Friend htblTempLookup As New Dictionary(Of String, String)
    Public Function PlaySound(ByVal sSoundFile As String, Optional ByVal iChannel As Integer = 1, Optional ByVal bLooping As Boolean = False) As Boolean

        Try
#If Runner Then
            If Not UserSession.bSound Then Return False
#End If

            iChannel -= 1
            Dim SoundInterface As clsSoundInterface = Nothing            

            ' Try to use any existing interface
            If Channels(iChannel) IsNot Nothing Then
                SoundInterface = Channels(iChannel)
                If sSoundFile = "" Then sSoundFile = SoundInterface.SoundFile
                If Not SoundInterface.CanPlayFile(sSoundFile) Then
                    SoundInterface.Stop()
                    SoundInterface = Nothing
                End If
            End If

            Dim iInterface As Integer = 0
            While SoundInterface Is Nothing
                ' TODO - Allow disabling of each interface in Settings
                Select Case iInterface
#If Not (www Or Mono) Then
                    Case 0
                        If SafeBool(GetSetting("ADRIFT", "Shared", "WinMM", "1")) Then SoundInterface = New MMSoundInterface(iChannel)
                    Case 1
                        If SafeBool(GetSetting("ADRIFT", "Shared", "DirectX", "1")) Then SoundInterface = New DirectXSoundInterface
#End If
                    Case 2
                        If SafeBool(GetSetting("ADRIFT", "Shared", "SoundPlayer", "1")) Then SoundInterface = New SoundPlayerSoundInterface
                    Case 3
                        ' No more interfaces.  I guess we have to settle for no sound. :-(
                        Exit While
                End Select

                If SoundInterface IsNot Nothing Then
                    SoundInterface.SoundFile = sSoundFile

                    If SoundInterface.IsInitialised AndAlso SoundInterface.CanPlayFile(sSoundFile) Then
                        ' Yay, we have an interface
                    Else
                        SoundInterface = Nothing
                    End If
                End If                

                iInterface += 1
            End While

            Channels(iChannel) = SoundInterface

            If SoundInterface IsNot Nothing Then
                Dim sLoadFile As String = sSoundFile
                Dim sExtn As String = ""

                If IO.File.Exists(sLoadFile) Then
                    sLoadFile = sSoundFile
                Else
                    If htblTempLookup.ContainsKey(sSoundFile) Then
                        sLoadFile = htblTempLookup(sSoundFile)
                        sExtn = IO.Path.GetExtension(sSoundFile).ToUpper.Substring(1)
                    Else
                        If Adventure.BlorbMappings IsNot Nothing AndAlso Adventure.BlorbMappings.Count > 0 Then
                            Dim iResource As Integer = 0
                            If Adventure.BlorbMappings.ContainsKey(sSoundFile) Then iResource = Adventure.BlorbMappings(sSoundFile)
                            If iResource > 0 Then
                                Dim sf As clsBlorb.SoundFile = Blorb.GetSound(iResource, True)
                                Dim tmpFile As String = IO.Path.GetTempFileName
                                Dim stmOutput As New IO.FileStream(tmpFile, IO.FileMode.Create)
                                stmOutput.Write(sf.bytSound, 0, sf.bytSound.Length - 1)
                                stmOutput.Close()
                                htblTempLookup.Add(sSoundFile, tmpFile)
                                sLoadFile = tmpFile
                                sExtn = IO.Path.GetExtension(sSoundFile).ToUpper.Substring(1)
                            End If
                        ElseIf Adventure.dVersion >= 4 AndAlso Adventure.dVersion < 5 AndAlso Adventure.dictv4Media.Count > 0 Then
                            Dim tmpFile As String = IO.Path.GetTempFileName
                            If Getv4Audio(sSoundFile, tmpFile) Then
                                htblTempLookup.Add(sSoundFile, tmpFile)
                                sLoadFile = tmpFile
                                sExtn = IO.Path.GetExtension(sSoundFile).ToUpper.Substring(1)
                            End If
                        End If
                    End If

                End If

                If IO.File.Exists(sLoadFile) Then
                    Try
                        With SoundInterface
                            Dim bChanged As Boolean = True
                            Try
                                If .SoundFile <> sLoadFile Then
                                    .SoundFile = sLoadFile
                                    If sExtn <> "" Then SoundInterface._sExtension = sExtn
                                Else
                                    bChanged = False
                                End If
                            Catch ex As Exception
                                DisplayError("Error loading audio: " & ex.Message & " - " & ex.InnerException.Message)
                            End Try
                            If .Looping <> bLooping Then .Looping = bLooping
                            Try
                                ' If user tries to play a sound that is already playing, just leave as is
#If Runner Then
                                UserSession.DebugPrint(ItemEnum.General, "", DebugDetailLevelEnum.High, "Playing sound type " & .Extension & " on interface " & .Name)
#End If
                                If bChanged OrElse Not .IsPlaying Then .Play()
                            Catch ex As Exception
                                DisplayError("Error playing audio: " & ex.Message & " - " & ex.InnerException.Message)
                            End Try
                        End With
                    Catch exA As Exception
                        'ErrMsg("Error initialising audio", exA)
                        DisplayError("Unable to play audio.  DLL missing?")
                    End Try
                Else
                    DisplayError("Audio file """ & sLoadFile & """ not found.")
                End If
            Else
                'ErrMsg("No interface found capable of playing audio file " & sSoundFile)
#If Runner Then
                UserSession.DebugPrint(ItemEnum.General, "", DebugDetailLevelEnum.Medium, "No interface found capable of playing audio file " & sSoundFile)
#End If
            End If

        Catch ex As Exception
            ErrMsg("Error playing audio", ex)
        End Try

    End Function

End Module



Public MustInherit Class clsSoundInterface

    Public MustOverride ReadOnly Property IsInitialised As Boolean
    Public Property Looping As Boolean
    'Public MustOverride Property SoundFile As String
    Public MustOverride Sub Play()
    Public MustOverride ReadOnly Property IsPlaying() As Boolean
    Public MustOverride Sub [Stop]()
    Public MustOverride Sub Pause()
    Public MustOverride Function CanPlayFile(ByVal sFilename As String) As Boolean
    Public MustOverride ReadOnly Property Name As String
    Public Paused As Boolean = False

    Private _SoundFile As String
    Friend Overridable Property SoundFile As String
        Get
            Return _SoundFile
        End Get
        Set(value As String)
            If value <> _SoundFile Then
                _SoundFile = value
                _sExtension = ""
            End If
        End Set
    End Property


    Friend _sExtension As String
    Friend Function Extension() As String

        Try
            If _sExtension = "" Then
                Select Case Right(_SoundFile, 3).ToUpper
                    Case "WAV", "MP3", "MID", "IDI"
                        _sExtension = Right(_SoundFile, 3).ToUpper
                    Case Else                        
                        ' Ok, have to look at the file signature to work it out
                        'Dim data() As Byte = IO.File.ReadAllBytes(_SoundFile)
                        Dim reader As New IO.BinaryReader(New IO.StreamReader(_SoundFile).BaseStream)
                        Dim data() As Byte = reader.ReadBytes(4)
                        reader.Close()

                        If data.Length > 2 AndAlso data(0) = CByte(Asc("I")) AndAlso data(1) = CByte(Asc("D")) AndAlso data(2) = CByte(Asc("3")) Then
                            _sExtension = "MP3"
                        ElseIf data.Length > 1 AndAlso data(0) = 255 AndAlso data(1) >= 224 Then ' FF Ex / FF Fx
                            _sExtension = "MP3"
                        ElseIf data.Length > 3 AndAlso data(0) = 0 AndAlso data(1) = 0 AndAlso data(2) = 0 AndAlso data(3) = 0 Then ' Unsure about this...
                            _sExtension = "MP3"
                        ElseIf data.Length > 3 AndAlso ((data(0) = 82 AndAlso data(1) = 73 AndAlso data(2) = 70 AndAlso data(3) = 70) OrElse _
                            (data(0) = 48 AndAlso data(1) = 38 AndAlso data(2) = 178 AndAlso data(3) = 117)) Then
                            _sExtension = "WAV"
                        ElseIf data.Length > 3 AndAlso data(0) = 77 AndAlso data(1) = 84 AndAlso data(2) = 104 AndAlso data(3) = 100 Then
                            _sExtension = "MID"
                        ElseIf data.Length > 3 AndAlso data(0) = 79 AndAlso data(1) = 103 AndAlso data(2) = 103 AndAlso data(3) = 83 Then
                            _sExtension = "OGG"
                        Else
                            ErrMsg("Unable to identify file format")
                        End If
                End Select
            End If
        Catch ex As Exception
            ErrMsg("Error identifying sound file", ex)
        End Try
        
        Return _sExtension

    End Function

End Class


Public Class SoundPlayerSoundInterface
    Inherits clsSoundInterface

    Private WithEvents Player As System.Media.SoundPlayer

    Public Sub New()
        Player = New System.Media.SoundPlayer
    End Sub

    Public Overrides ReadOnly Property IsInitialised As Boolean
        Get
            Return Player IsNot Nothing
        End Get
    End Property

    'Public Overrides Property SoundFile As String
    '    Get
    '        Return Player.SoundLocation
    '    End Get
    '    Set(value As String)
    '        Player.SoundLocation = value
    '    End Set
    'End Property

    Public Overrides Sub Play()
        Try
            If Player.SoundLocation = "" Then Player.SoundLocation = MyBase.SoundFile

            If Looping Then
                Player.PlayLooping()
            Else
                Player.Play()
            End If
            Paused = False
        Catch ex As Exception
            Throw New Exception("SoundPlayer audio error", ex)
        End Try
    End Sub

    Public Overrides Sub [Stop]()
        Player.Stop()
    End Sub

    'Public Overrides Function CanPlayExtension(ByVal sExtn As String) As Boolean
    '    Return sExtn.ToUpper = ".WAV"
    'End Function

    Public Overrides Sub Pause()
        Player.Stop()
        Paused = True
    End Sub

    Public Overrides ReadOnly Property IsPlaying As Boolean
        Get
            Return False ' for now... Player.
        End Get
    End Property

    Public Overrides Function CanPlayFile(sFilename As String) As Boolean
        Return MyBase.Extension = "WAV"
    End Function

    Public Overrides ReadOnly Property Name As String
        Get
            Return "SoundPlayer"
        End Get
    End Property

End Class

#If Not www Then
Public Class MMSoundInterface
    Inherits clsSoundInterface

    Private Declare Auto Function mciSendString Lib "winmm.dll" Alias "mciSendString" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As UInt32, ByVal hwndCallback As IntPtr) As Int32
    Private Declare Unicode Function mciGetErrorString Lib "winmm.dll" Alias "mciGetErrorStringW" (ByVal errorCode As Int32, ByVal errorText As String, ByVal errorTextSize As Int32) As Int32
    Private iChannel As Integer = 0

    Public Sub New(ByVal iChannel As Integer)
        Me.iChannel = iChannel
    End Sub


    Private _isPaused As Boolean = False
    Public ReadOnly Property IsPaused() As Boolean
        Get
            Try
                Dim sBuffer As String = Space(128)
                Command("status audiofile" & iChannel & " mode", sBuffer, True)
                Return sBuffer = "paused"
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property


    Private Function Command(ByVal sCommand As String, Optional ByRef sResult As String = Nothing, Optional ByVal bIgnoreErrors As Boolean = False) As Integer

        Try
            Dim sBuffer As String = Space(255)
#If Runner Then
            Dim iResult As Integer = mciSendString(sCommand, sBuffer, 255, fRunner.Handle) ' Has hung on this line... :-(
#Else
            Dim iResult As Integer = mciSendString(sCommand, sBuffer, 255, IntPtr.Zero) ' Has hung on this line... :-(
#End If

            sBuffer = sBuffer.Replace(Chr(0), "").Trim
            sResult = sBuffer
            Dim iErrorCode As Integer = iResult

            If iErrorCode > 0 Then
                sBuffer = Space(128)
                iResult = mciGetErrorString(iErrorCode, sBuffer, 128)
                sBuffer = sBuffer.Replace(Chr(0), "").Trim
                If Not bIgnoreErrors Then ErrMsg("Error " & iErrorCode & " carrying out command """ & sCommand & """: " & sBuffer)
            End If

            Return iErrorCode

        Catch ex As Exception
            Return -1
        End Try

    End Function


    Public Overrides ReadOnly Property IsInitialised As Boolean
        Get
            Return Command("status", , True) = 292 ' Complains, but at least we know that's it working
        End Get
    End Property

    Public Overrides ReadOnly Property IsPlaying As Boolean
        Get
            Try
                Dim sBuffer As String = Space(128)
                Command("status audiofile" & iChannel & " mode", sBuffer, True)
                Return sBuffer = "playing"
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property

    Public Overrides Sub Pause()
        Command("pause audiofile" & iChannel, , True)
    End Sub

    


    Public Overrides Sub Play()

        If IsPaused Then
            If Extension() = "MID" Then
                Command("play audiofile" & iChannel & " from " & Position)
            Else
                Command("resume audiofile" & iChannel)
            End If
        Else
            [Stop]()
            If Looping Then qToLoop.Enqueue(iChannel)
            Select Case Extension()
                Case "WAV"
                    Command("open """ & SoundFile & """ type waveaudio alias audiofile" & iChannel)
                    'Command("play audiofile" & iChannel & " from 0" & If(_wait, " wait", "").ToString & If(Looping, " notify repeat", "").ToString)
                    Command("play audiofile" & iChannel & " from 0" & If(_wait, " wait", "").ToString & If(Looping, " notify", "").ToString)
                Case "MP3"
                    Command("open """ & SoundFile & """ type mpegvideo alias audiofile" & iChannel)
                    Command("play audiofile" & iChannel & " from 0" & If(_wait, " wait", "").ToString & If(Looping, " repeat", "").ToString)
                Case "MID", "IDI"
                    Command("open sequencer!" & SoundFile & " alias audiofile" & iChannel)
                    Command("play audiofile" & iChannel & " from 0" & If(_wait, " wait", "").ToString & If(Looping, " repeat", "").ToString)
                Case Else
                    Throw New Exception("Sound file type " & Extension() & " not supported.")
                    Close()
            End Select
        End If

    End Sub

    ''' <summary>
    ''' Sets the audio file's time format via the mciSendString API.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Milliseconds() As Integer
        Get
            Dim buf As String = Space(255)
            mciSendString("set audiofile" & iChannel & " time format milliseconds", Nothing, 0, IntPtr.Zero)
            mciSendString("status audiofile" & iChannel & " length", buf, 255, IntPtr.Zero)

            buf = Replace(buf, Chr(0), "") ' Get rid of the nulls, they muck things up

            If buf = "" Then
                Return 0
            Else
                Return CInt(buf)
            End If
        End Get
    End Property

    ''' <summary>
    ''' Gets the channels of the file via the mciSendString API.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Channels() As Integer
        Get
            Dim buf As String = Space(255)
            mciSendString("status audiofile" & iChannel & " channels", buf, 255, IntPtr.Zero)

            If IsNumeric(buf) = True Then
                Return CInt(buf)
            Else
                Return -1
            End If
        End Get
    End Property

    Private _wait As Boolean = False
    ''' <summary>
    ''' Halt the program until the .wav file is done playing.  Be careful, this will lock the entire program up until the
    ''' file is done playing.  It behaves as if the Windows Sleep API is called while the file is playing (and maybe it is, I don't
    ''' actually know, I'm just theorizing).  :P
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Wait() As Boolean
        Get
            Return _wait
        End Get
        Set(ByVal value As Boolean)
            _wait = value
        End Set
    End Property

    ''' <summary>
    ''' Used for debugging purposes.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Debug() As String
        Get
            Dim buf As String = Space(255)
            mciSendString("status audiofile" & iChannel & " channels", buf, 255, IntPtr.Zero)

            Return Str(buf)
        End Get
    End Property

    ReadOnly Property Position As Long
        Get
            Dim sBuffer As String = Space(255)
            Command("status audiofile" & iChannel & " position", sBuffer)
            Return CLng(sBuffer)
        End Get
    End Property

    'Private _SoundFile As String
    Friend Overrides Property SoundFile As String
        Get
            Return MyBase.SoundFile ' _SoundFile
        End Get
        Set(value As String)
            If value <> MyBase.SoundFile Then
                [Stop]()
                MyBase.SoundFile = value
            End If
        End Set
    End Property

    Public Overrides Sub [Stop]()
        Command("stop audiofile" & iChannel, , True)
        If qToLoop.Count > 0 AndAlso qToLoop.Peek = iChannel Then qToLoop.Dequeue()
        Close()
    End Sub

    Private Sub Close()
        Command("close audiofile" & iChannel, , True)
    End Sub

    Public Overrides Function CanPlayFile(sFilename As String) As Boolean
        Select Case Extension()
            Case "OGG"
                Return False
            Case "WAV", "MP3", "MID"
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Overrides ReadOnly Property Name As String
        Get
            Return "WinMM"
        End Get
    End Property
End Class


Public Class DirectXSoundInterface
    Inherits clsSoundInterface

    'Private _dev As Microsoft.DirectX.DirectSound.Device
    'Private _buffer As Microsoft.DirectX.DirectSound.SecondaryBuffer
    Private audio As Microsoft.DirectX.AudioVideoPlayback.Audio

    Public Sub New()
        '_dev = New Microsoft.DirectX.DirectSound.Device
        '_dev.SetCooperativeLevel(fRunner.Handle, Microsoft.DirectX.DirectSound.CooperativeLevel.Priority)        
    End Sub

    'Public Overrides Function CanPlayExtension(sExtn As String) As Boolean
    '    Select Case sExtn.ToUpper
    '        Case ".OGG"
    '            Return False
    '        Case ".WAV", ".MP3", ".MID"
    '            Return True
    '        Case Else
    '            Return True ' At least until I know what it supports
    '    End Select
    'End Function

    Public Overrides ReadOnly Property IsInitialised As Boolean
        Get
            'Return _dev IsNot Nothing
            Return True ' audio IsNot Nothing ' True
        End Get
    End Property

    Public Overrides Sub Play()
        Try
            If audio IsNot Nothing AndAlso Not audio.Paused Then [Stop]()
            If audio Is Nothing AndAlso SoundFile <> "" Then
                Try
                    audio = New Microsoft.DirectX.AudioVideoPlayback.Audio(SoundFile, False)
                Catch ex As Exception
                    Throw New Exception("DirectX audio error", ex)
                End Try
            End If
            If audio IsNot Nothing Then
                If Looping Then AddHandler audio.Ending, AddressOf MusicEnds
                audio.Play()
                Paused = False
            End If
        Catch ex As Exception
            Throw New Exception("DirectX audio error (play)", ex)
        End Try
    End Sub

    Private Sub MusicEnds(ByVal sender As Object, ByVal e As System.EventArgs)
        audio.CurrentPosition = 0
    End Sub

    'Private _sSoundFile As String = Nothing
    'Public Overrides Property SoundFile As String
    '    Get
    '        Return _sSoundFile
    '    End Get
    '    Set(value As String)
    '        _sSoundFile = value
    '    End Set
    'End Property

    Public Overrides Sub [Stop]()
        Try
            If audio IsNot Nothing Then
                audio.Stop()
                If Looping Then RemoveHandler audio.Ending, AddressOf MusicEnds
                audio.Dispose()
            End If
            audio = Nothing
        Catch ex As Exception
            Throw New Exception("DirectX audio error (stop)", ex)
        End Try
    End Sub

    Public Overrides Sub Pause()
        Try
            If audio.Paused Then
                audio.Play()
                Paused = False
            Else
                audio.Pause()
                Paused = True
            End If
        Catch ex As Exception
            Throw New Exception("DirectX audio error (pause)", ex)
        End Try
    End Sub

    Public Overrides ReadOnly Property IsPlaying As Boolean
        Get
            Return audio IsNot Nothing AndAlso audio.Playing AndAlso audio.CurrentPosition < audio.Duration
        End Get
    End Property

    Public Overrides Function CanPlayFile(sFilename As String) As Boolean
        Select Case Extension()
            Case "OGG"
                Return False
            Case "WAV", "MP3", "MID"
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Overrides ReadOnly Property Name As String
        Get
            Return "DirectX"
        End Get
    End Property

End Class
#End If

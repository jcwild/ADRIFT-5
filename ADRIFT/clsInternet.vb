Imports System.Net
Imports System.Net.Sockets
Imports System.Text


Module Internet

    Public Function OpenURL(ByVal sInURL As String) As String

        Dim iP As Integer
        Dim sURL As String
        Dim sURLHost As String
        Dim sURLPath As String

        Dim abyteReceive(1024) As Byte

        'The path parsing should be more robust ...
        iP = sInstr(UCase$(sInURL), "HTTP://")
        If iP > 0 Then
            sURL = Mid$(sInURL, iP + 7)
        Else
            sURL = sInURL
        End If

        iP = sInstr(sURL, "/")
        If iP > 0 Then
            sURLHost = sMid(sURL, 1, iP - 1)
            sURLPath = sMid(sURL, iP)
        Else
            sURLHost = sURL
            sURLPath = "/"
        End If

        'should be supporting HTTP 1.1
        Dim s As String = ""
        Dim sGet As String = "GET " & sURLPath & " HTTP/1.0" & vbCrLf & " Host: " & sURLHost & vbCrLf & "Connection: Close" & vbCrLf & vbCrLf
        Dim asciiGet As Encoding = Encoding.ASCII
        Dim abyteGet() As Byte = asciiGet.GetBytes(sGet)

        Try
            Dim hostentry As IPHostEntry = Dns.GetHostEntry(sURLHost) ' Dns.GetHostByName(sURLHost)
            Dim hostadd As IPAddress = hostentry.AddressList(0)


            Dim EPhost As IPEndPoint = New IPEndPoint(hostadd, 80)
            Dim sockHTTP As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

            sockHTTP.Connect(EPhost)

            If Not sockHTTP.Connected Then Return "Unable to connect to host: " & sURLHost

            sockHTTP.Send(abyteGet, abyteGet.Length, 0)

            Dim iBytes As Integer = sockHTTP.Receive(abyteReceive, abyteReceive.Length, 0)
            s = ("HTML from " & sURL & "(" & hostadd.ToString & "):").Replace("|", ":") & vbCrLf
            s &= asciiGet.GetString(abyteReceive, 0, iBytes)

            Do While iBytes > 0
                iBytes = sockHTTP.Receive(abyteReceive, abyteReceive.Length, 0)
                s &= asciiGet.GetString(abyteReceive, 0, iBytes)
            Loop

            sockHTTP.Close()
            sockHTTP = Nothing

        Catch ex As Exception
            Return "Unable to connect to host: " & sURLHost & ", " & ex.Message
        End Try

        Return s

    End Function


    Public Function URLEncode(ByVal sURLCode As String) As String
        URLEncode = sURLCode.Replace(vbCrLf, "<br>").Replace("%", "%25").Replace(" ", "%20").Replace("""", "%22").Replace("#", "%23").Replace("$", "%24").Replace("&", "%26").Replace("+", "%2B").Replace(",", "%2C").Replace("/", "%2F").Replace(":", "%3A").Replace(";", "%3B").Replace("<", "%3C").Replace("=", "%3D").Replace(">", "%3E").Replace(">", "%3E").Replace("?", "%3F").Replace("@", "%40").Replace("\", "%5C%5C")
    End Function

End Module

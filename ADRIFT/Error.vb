Option Strict On


Public Class frmError

    'Private bSend As Boolean = False
    Private iBugId As Integer = 0
    Private Enum BugStatusEnum As Integer
        Failed = 0
        Added = 1
        AlreadyExists = 2
        ExistsAndCompleted=3
    End Enum

    Public Sub New(ByVal sErrorMessage As String, Optional ByVal ex As Exception = Nothing)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.   
        Dim sStackTrace As String = Nothing
        If Not ex Is Nothing Then
            sErrorMessage &= ": " & ex.Message
            sStackTrace = New System.Diagnostics.StackTrace(True).ToString
            'sStackTrace = ex.StackTrace()
            'While Not ex.InnerException Is Nothing
            '    ex = ex.InnerException
            '    sStackTrace &= vbCrLf & ex.Message & vbCrLf & ex.StackTrace
            'End While
        End If

        LoadForm(sErrorMessage, sStackTrace)

    End Sub



    Private Sub LoadForm(ByVal sErrorMessage As String, ByVal sStackTrace As String)

        Me.lblErrorMessage.Text = sErrorMessage
        SetOptimumSize()
        'lblFeedback.Appearance.BackColor = Color.FromArgb(rSession.cSystemColour.A, Math.Max(rSession.cSystemColour.R - 25, 0), Math.Max(rSession.cSystemColour.G - 25, 0), Math.Max(rSession.cSystemColour.B - 25, 0))
        If sStackTrace IsNot Nothing Then
            'bSend = True
            imgCross.Visible = True
            imgExclamation.Visible = False
            Me.txtStackTrace.Text = sStackTrace
            'If rSession.bShowStackTrace Then
            OpenST()
            'Else
            'CloseST()
            'End If
            System.Media.SystemSounds.Hand.Play()
            LogError(sErrorMessage, sStackTrace)
        Else
            'bSend = False
            imgCross.Visible = False
            imgExclamation.Visible = True
            CloseST()
            btnUp.Visible = False
            btnDown.Visible = False
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            System.Media.SystemSounds.Exclamation.Play()
            tabsError.Visible = False
        End If

    End Sub



    Private Sub LogError(ByVal sErrorMessage As String, ByVal sStackTrace As String)
        ' Send the error to ADRIFT and await acknowlegement
        ' 0 - fail, 1 - added success, 2 - already exists, 3 - exists and completed
        ' if added or already exists, get bug id
        ' if completed, get date and version 

        Dim sParam As String = "sShortDesc=" & URLEncode(sErrorMessage)
        If sStackTrace IsNot Nothing Then sParam &= "&sException=" & URLEncode(sStackTrace)
        sParam &= "&Validation=203987"
        sParam &= "&sReleaseVer=0"
        sParam &= "&bEnhancement=0"
        sParam &= "&sFoundVer=" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build

        Dim sResult As String = OpenURL("www.adrift.org.uk/cgi/new/submitbug.cgi?" & sParam)

        If sResult.StartsWith("Unable to connect to host:") Then
            Me.tabsError.Tabs("Feedback").Visible = False
            Me.lblInfo.Text = "Unable to log error with ADRIFT.  Please check your firewall settings - the more of these errors that are logged, the more stable ADRIFT will become."
        Else

            Dim sResults() As String = sResult.Split("|"c)
            If sResults.Length > 1 AndAlso sResults(1) <> "" Then
                Select Case CType(sResults(1), BugStatusEnum)
                    Case BugStatusEnum.Failed
                        Me.tabsError.Tabs("Info").Visible = False
                        Me.tabsError.Tabs("Feedback").Visible = False
                    Case BugStatusEnum.Added
                        Me.tabsError.Tabs("Info").Visible = False
                        iBugId = SafeInt(sResults(2))
                    Case BugStatusEnum.AlreadyExists
                        Me.tabsError.Tabs("Info").Visible = False
                        iBugId = CInt(sResults(2))
                    Case BugStatusEnum.ExistsAndCompleted
                        Me.tabsError.Tabs("Feedback").Visible = False
                        Dim dtCompleted As Date = CDate(sResults(3))
                        Dim sReleaseVer As String = sResults(4).ToString
                        lblInfo.Text = "This bug was completed on " & dtCompleted.ToLongDateString & ".  You need to upgrade to version " & sReleaseVer & " to prevent this error from reoccurring."
                End Select
            Else
                Me.tabsError.Tabs("Info").Visible = False
                Me.tabsError.Tabs("Feedback").Visible = False
            End If
            'Me.txtFeedback.Text = sResult
        End If

    End Sub


    Private Sub SendFeedback()

        If iBugId > 0 AndAlso txtFeedback.Text <> "" Then
            ' Send additional info
            Dim sParam As String = "sDescription=" & URLEncode(txtFeedback.Text)
            sParam &= "&Validation=203987"
            sParam &= "&iBugId=" & iBugId
            sParam &= "&User=" & URLEncode(Environment.UserName)            

            Dim sResult As String = OpenURL("www.adrift.org.uk/cgi/new/submitfeedback.cgi?" & sParam)

        End If

    End Sub


    Private Sub OpenST()
        btnUp.Visible = True
        btnDown.Visible = False
        Me.Size = New Size(Me.Width, Me.Height + 150)
        'pnlDropdown.Height = Me.Height - pnlDropdown.Top - 45
    End Sub


    Private Sub CloseST()
        btnUp.Visible = False
        btnDown.Visible = True
        Me.Size = New Size(Me.Width, btnOK.Top + btnOK.Height + 40)
    End Sub


    Private Function MeasureString(ByVal str As String, ByVal maxWidth As Integer, ByVal font As Font) As Size

        Try
            Dim g As Graphics = CreateGraphics()
            Dim strRectSizeF As SizeF = g.MeasureString(str, font, maxWidth)
            g.Dispose()

            Return New Size(CInt(Math.Ceiling(strRectSizeF.Width)), CInt(Math.Ceiling(strRectSizeF.Height)))
        Catch
            ' This has returned an Error creating window handle before, arrrgh!
            Return New Size(CInt(Screen.PrimaryScreen.Bounds.Width / 2), CInt(Screen.PrimaryScreen.Bounds.Height / 3))
        End Try

    End Function



    Private Sub SetOptimumSize()

        Dim szText As Size = MeasureString(lblErrorMessage.Text, CInt(SystemInformation.WorkingArea.Width * 0.6), txtStackTrace.Font)
        Me.Size = New Size(szText.Width + 240, szText.Height + 110)
        Me.MinimumSize = Me.Size
        imgCross.Top = CInt((Me.Size.Height - imgCross.Height) / 2) - 20
        imgExclamation.Top = imgCross.Top
        lblErrorMessage.Height = Me.Size.Height - 80
        btnOK.Top = Me.Size.Height - 67        
        btnUp.Top = btnOK.Top
        btnDown.Top = btnOK.Top           

    End Sub


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.txtFeedback.Text <> "" Then ' bSend Then
            '#If DEBUG Then
            '            If MsgBox("Debug mode - do you want email sent out?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then SendMail()
            '#Else
            '            SendMail()
            '#End If
            SendFeedback()
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub


    Private Sub btnExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click, btnDown.Click
        If btnUp.Visible Then CloseST() Else OpenST()
    End Sub



    Private Sub frmError_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If btnUp.Visible Then rSession.bShowStackTrace = True
        Me.Hide()
    End Sub


    Private Sub frmError_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SetWindowStyle(Me)
    End Sub

End Class
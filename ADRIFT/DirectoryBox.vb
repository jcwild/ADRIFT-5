Imports System.ComponentModel


Public Class DirectoryBox
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.BackColor = Color.Transparent

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Public WithEvents txtDir As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Private WithEvents btnSearch As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sfd As System.Windows.Forms.SaveFileDialog
    Friend WithEvents fbd As System.Windows.Forms.FolderBrowserDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtDir = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnSearch = New Infragistics.Win.Misc.UltraButton
        Me.fbd = New System.Windows.Forms.FolderBrowserDialog
        Me.ofd = New System.Windows.Forms.OpenFileDialog
        Me.sfd = New System.Windows.Forms.SaveFileDialog
        CType(Me.txtDir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDir
        '
        Me.txtDir.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDir.AutoSize = False
        Me.txtDir.Location = New System.Drawing.Point(0, 0)
        Me.txtDir.Name = "txtDir"
        Me.txtDir.Size = New System.Drawing.Size(248, 22)
        Me.txtDir.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.BackColorInternal = System.Drawing.Color.Transparent
        Me.btnSearch.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSearch.Location = New System.Drawing.Point(248, 0)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(32, 22)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "···"
        '
        'ofd
        '
        Me.ofd.FileName = "OpenFileDialog1"
        Me.sfd.FileName = "SaveFileDialog1"
        '
        'DirectoryBox
        '
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtDir)
        Me.Name = "DirectoryBox"
        Me.Size = New System.Drawing.Size(280, 22)
        CType(Me.txtDir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Shadows Event TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Private sFileFilter As String
    Private sPath As String


    Public Enum OpenOrSaveEnum
        Open
        Save
    End Enum

    Private eOpenOrSave As OpenOrSaveEnum = OpenOrSaveEnum.Open
    Public Property OpenOrSave As OpenOrSaveEnum
        Set(value As OpenOrSaveEnum)
            eOpenOrSave = value
        End Set
        Get
            Return eOpenOrSave
        End Get
    End Property


    Public Property FileFilter() As String
        Get
            If sFileFilter = "" Then sFileFilter = "All Files (*.*)|*.*"
            Return sFileFilter
        End Get
        Set(ByVal value As String)
            sFileFilter = value
        End Set
    End Property

    Public Property Directory() As String
        Get
            If BoxType = BoxTypeEnum.Directory Then
                Return txtDir.Text
            Else
                Return "*** Incorrect BoxType ***"
            End If
        End Get
        Set(ByVal Value As String)
            If BoxType = BoxTypeEnum.Directory Then
                txtDir.Text = Value
            End If
        End Set
    End Property

    Public Property Filename() As String
        Get
            If BoxType = BoxTypeEnum.File Then
                Return sPath
            Else
                Return "*** Incorrect BoxType ***"
            End If
        End Get
        Set(ByVal Value As String)
            If BoxType = BoxTypeEnum.File Then
                If Value IsNot Nothing AndAlso Value.Contains("...") Then
                    While Value.StartsWith("...")
                        Value = sRight(Value, Value.Length - 3)
                    End While
                    Value = Value
                Else
                    sPath = Value
                    txtDir.Text = Abbreviate(sPath)
                End If
            End If
        End Set
    End Property


    Private Function MeasureString(ByVal str As String, ByVal maxWidth As Integer, ByVal font As Font) As Size

        Dim g As Graphics = CreateGraphics()
        Dim strRectSizeF As SizeF = g.MeasureString(str, font, maxWidth)
        g.Dispose()

        Return New Size(CInt(Math.Ceiling(strRectSizeF.Width)), CInt(Math.Ceiling(strRectSizeF.Height)))

    End Function


    Private Function Abbreviate(ByVal sPath As String) As String

        Dim sAbb As String = sPath
        Dim sDirs As String() = Split(sPath, "\")

        If txtDir.Width > 0 Then
            While txtDir.Width < MeasureString(sAbb, 0, txtDir.Font).Width + 10  ' sAbb.Length * 5
                Dim sOldAbb As String = sAbb
                For i As Integer = sDirs.Length - 2 To 0 Step -1
                    If sDirs(i) <> "..." Then
                        sDirs(i) = "..."
                        sAbb = ""
                        For Each sDir As String In sDirs
                            sAbb &= sDir & "\"
                        Next
                        sAbb = sLeft(sAbb, sAbb.Length - 1)
                        While sAbb.Contains("...\...")
                            sAbb = sAbb.Replace("...\...", "...")
                        End While
                        Exit For
                    End If
                Next
                If sAbb = sOldAbb Then Return sAbb
            End While
        End If

        Return sAbb

    End Function


    Public Enum BoxTypeEnum
        File
        Directory
    End Enum
    Private eBoxType As BoxTypeEnum
    Public Property BoxType() As BoxTypeEnum
        Get
            Return eBoxType
        End Get
        Set(ByVal value As BoxTypeEnum)
            eBoxType = value
        End Set
    End Property


    Private Sub txtDir_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDir.TextChanged

        If BoxType = BoxTypeEnum.Directory Then
            Directory = txtDir.Text
        Else
            Filename = txtDir.Text
        End If

        If (BoxType = BoxTypeEnum.Directory AndAlso IO.Directory.Exists(Directory)) OrElse (BoxType = BoxTypeEnum.File AndAlso IO.File.Exists(Filename)) Then
            txtDir.ForeColor = SystemColors.ControlText
        Else
            txtDir.ForeColor = Color.DarkRed
        End If

        RaiseEvent TextChanged(sender, e)

    End Sub

    Public Sub OpenFileDialog()
        btnSearch_Click(Nothing, Nothing)
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Try
            If BoxType = BoxTypeEnum.Directory Then
                With fbd
                    .SelectedPath = Directory
                    If .ShowDialog = DialogResult.OK Then
                        Directory = .SelectedPath
                    End If
                End With
            Else
                If eOpenOrSave = OpenOrSaveEnum.Open Then
                    With ofd
                        If IO.Directory.Exists(Filename) Then .InitialDirectory = Filename
                        Try
                            .FileName = Filename
                        Catch
                        End Try
                        .Filter = FileFilter

                        If .ShowDialog = DialogResult.OK Then
                            Filename = .FileName
                        End If
                    End With
                Else
                    With sfd
                        If IO.Directory.Exists(Filename) Then .InitialDirectory = Filename
                        Try
                            .FileName = Filename
                        Catch
                        End Try
                        .Filter = FileFilter

                        If .ShowDialog = DialogResult.OK Then
                            Filename = .FileName
                        End If
                    End With
                End If
            End If
        Catch ex As Exception
            ErrMsg("btnSearch error", ex)
        End Try

    End Sub

    ' Hide the Text property
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), Obsolete("Text Property not in use", True)> _
    Public Overrides Property Text() As String
        Get
            Return Nothing
        End Get
        Set(ByVal Value As String)
            Value = Nothing
        End Set
    End Property

    Private Sub DirectoryBox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        txtDir.Text = Abbreviate(sPath)
    End Sub

End Class

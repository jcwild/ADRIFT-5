Imports Infragistics.Win.UltraWinToolbars


Public Class frmRunner
    Inherits System.Windows.Forms.Form

    Private iCommand As Integer    
    Friend WithEvents DockableWindow1 As Infragistics.Win.UltraWinDock.DockableWindow
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents WindowDockingArea3 As Infragistics.Win.UltraWinDock.WindowDockingArea
    Friend WithEvents btnMore As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSubmit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ctxMenu As New ContextMenuStrip
    Friend WithEvents DockableWindow3 As Infragistics.Win.UltraWinDock.DockableWindow
    Friend WithEvents WindowDockingArea1 As Infragistics.Win.UltraWinDock.WindowDockingArea
    Friend WithEvents WindowDockingArea5 As Infragistics.Win.UltraWinDock.WindowDockingArea
    'Friend dictMacros As New Generic.Dictionary(Of String, clsMacro)
    Private fSplash As Splash
    'Private bEXE As Boolean = False

    ' MouseWheel scrolling
    Public Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Public Const EM_GETLINECOUNT As Integer = &HBA
    Public Const EM_LINESCROLL As Integer = &HB6

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        UserSession = New RunnerSession        
        GlobalStartup()

        If Environment.GetCommandLineArgs.Length = 1 Then

            ' Work out whether we have a TAF appended on the end.  If so, run that in Executable mode
            ' Grab out the last 8 bytes, and see if it converts to a size
            Dim bData(5) As Byte
            Dim sFilename As String = Application.ExecutablePath
            Dim fStream As New IO.FileStream(sFilename, IO.FileMode.Open, IO.FileAccess.Read)
            fStream.Seek(fStream.Length - 6, IO.SeekOrigin.Begin)
            fStream.Read(bData, 0, 6)
            'fStream.Close()

            Dim sFileSize As String = (New System.Text.ASCIIEncoding).GetString(bData).ToUpper            
            If IsHex(sFileSize) Then
                Dim lFileSize As Long = CLng("&H" & sFileSize)                
                If lFileSize > 0 Then
                    Blorb = New clsBlorb
                    fStream.Seek(lFileSize, IO.SeekOrigin.Begin)
                    clsBlorb.bEXE = True
                    If Blorb.LoadBlorb(fStream, sFilename, lFileSize) Then UserSession.bEXE = True
                    '' Ok, check the offset to see that the appended data is really a TAF...
                    'fStream = New IO.FileStream(Application.ExecutablePath, IO.FileMode.Open, IO.FileAccess.Read)
                    'fStream.Seek(lFileSize, IO.SeekOrigin.Begin)
                    'ReDim bData(11)
                    'fStream.Read(bData, 0, 12)
                    'fStream.Close()
                    'Dim sVersion As String = System.Text.Encoding.Default.GetString(Dencode(System.Text.Encoding.Default.GetString(bData), 1))
                    'If sVersion = "Version 5.00" Then bEXE = True                    
                End If
            End If
            fStream.Close()
        End If

        If Not UserSession.bEXE Then
            fSplash = New Splash
            fSplash.Show(Me)
            Application.DoEvents()
        Else
            UserSession.ShowUserSplash()
        End If

        'This call is required by the Windows Form Designer.
        InitializeComponent()        
        Me.DockableWindow1.Controls.Clear()        
        Me.DockableWindow1.Controls.Add(UserSession.Map)
        CType(UDMRunner.PaneFromKey("Map"), Infragistics.Win.UltraWinDock.DockableControlPane).Control = UserSession.Map
        MapHolder.Parent = Nothing
        MapHolder.Dispose()
        'Debug.WriteLine(UDMRunner.DockAreas(0).DockAreaPane.Panes("Map").DockedState)

        'Add any initialization after the InitializeComponent() call
        If UserSession.bEXE Then
            UTMMain.Tools("mnuOpenAdv").SharedProps.Visible = False
            'UTMMain.Tools("OpenGame").SharedProps.Visible = False
            UTMMain.Tools("mnuRecentAdventures").SharedProps.Visible = False
            UTMMain.Tools("About").SharedProps.Visible = False
            UTMMain.Tools("Debugger").SharedProps.Visible = False
        End If

        If UserSession.bRequiresRestoreLayout Then
            RestoreLayout()
            Application.DoEvents()
            UserSession.bRequiresRestoreLayout = False
        End If

    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents _frmRunnerUnpinnedTabAreaLeft As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents _frmRunnerUnpinnedTabAreaRight As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents _frmRunnerUnpinnedTabAreaTop As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents _frmRunnerUnpinnedTabAreaBottom As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents _frmRunner_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmRunner_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmRunner_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmRunner_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmRunnerAutoHideControl As Infragistics.Win.UltraWinDock.AutoHideControl
    Friend WithEvents UTMMain As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents UDMRunner As Infragistics.Win.UltraWinDock.UltraDockManager
    Friend WithEvents StatusBar As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents WindowDockingArea2 As Infragistics.Win.UltraWinDock.WindowDockingArea
    Friend WithEvents pbxGraphics As clsImage
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtInput As System.Windows.Forms.RichTextBox
    Friend WithEvents txtOutput As System.Windows.Forms.RichTextBox
    Friend MapHolder As Control
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DockAreaPane1 As Infragistics.Win.UltraWinDock.DockAreaPane = New Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedRight, New System.Guid("8028f595-16e1-4599-8f8e-41450dcae519"))
        Dim DockableControlPane1 As Infragistics.Win.UltraWinDock.DockableControlPane = New Infragistics.Win.UltraWinDock.DockableControlPane(New System.Guid("c3dc8aaa-2fb3-48cf-bcb9-a92e299b503c"), New System.Guid("a048d2fa-390f-49be-ac40-0d4facdead52"), 0, New System.Guid("8028f595-16e1-4599-8f8e-41450dcae519"), 0)
        Dim DockAreaPane2 As Infragistics.Win.UltraWinDock.DockAreaPane = New Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedRight, New System.Guid("810d89e0-1a82-4b9b-9221-07fe4dc6f671"))
        Dim DockableControlPane2 As Infragistics.Win.UltraWinDock.DockableControlPane = New Infragistics.Win.UltraWinDock.DockableControlPane(New System.Guid("4e0755a5-595b-49d9-a388-0b8017a1efd7"), New System.Guid("7300ca1b-647a-4abc-8580-a3435aee91f1"), -1, New System.Guid("810d89e0-1a82-4b9b-9221-07fe4dc6f671"), 0)
        Dim DockAreaPane3 As Infragistics.Win.UltraWinDock.DockAreaPane = New Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, New System.Guid("7300ca1b-647a-4abc-8580-a3435aee91f1"))
        Dim DockAreaPane4 As Infragistics.Win.UltraWinDock.DockAreaPane = New Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, New System.Guid("a048d2fa-390f-49be-ac40-0d4facdead52"))
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("mnuRunner")
        Dim PopupMenuTool1 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuFile")
        Dim PopupMenuTool2 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuEdit")
        Dim PopupMenuTool3 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuView")
        Dim PopupMenuTool13 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("Macros")
        Dim PopupMenuTool4 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuWindow")
        Dim PopupMenuTool5 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuHelp")
        Dim UltraToolbar2 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("ToolBar")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuOpenAdv")
        Dim ButtonTool14 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("OpenGame")
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("SaveGame")
        Dim ButtonTool28 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapZoomIn")
        Dim ButtonTool29 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapZoomOut")
        Dim StateButtonTool10 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("CentreMapLock", "")
        Dim StateButtonTool8 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("MapPlayerLock", "")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuOpenAdv")
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim PopupMenuTool6 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuFile")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuOpenAdv")
        Dim ButtonTool20 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("OpenGame")
        Dim ButtonTool24 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("RestartGame")
        Dim ButtonTool18 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("SaveGame")
        Dim ButtonTool19 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("SaveGameAs")
        Dim ButtonTool16 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("miStartTranscript")
        Dim PopupMenuTool7 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuRecentAdventures")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Exit")
        Dim PopupMenuTool8 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuEdit")
        Dim StateButtonTool6 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("AutoComplete", "")
        Dim PopupMenuTool9 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuView")
        Dim StateButtonTool1 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("mnuFullScreen", "")
        Dim StateButtonTool2 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("Debugger", "")
        Dim ButtonTool22 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Options")
        Dim PopupMenuTool10 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuHelp")
        Dim ButtonTool12 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("About")
        Dim ButtonTool32 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("AboutAdventure")
        Dim StateButtonTool3 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("mnuFullScreen", "")
        Dim StateButtonTool4 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("mnuHideMenu", "")
        Dim PopupMenuTool11 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuWindow")
        Dim ButtonTool10 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ShowMap")
        Dim ButtonTool11 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ShowGraphics")
        Dim MdiWindowListTool1 As Infragistics.Win.UltraWinToolbars.MdiWindowListTool = New Infragistics.Win.UltraWinToolbars.MdiWindowListTool("MDIWindowListTool1")
        Dim PopupMenuTool12 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuRecentAdventures")
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Exit")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim StateButtonTool5 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("Debugger", "")
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ShowMap")
        Dim ButtonTool9 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ShowGraphics")
        Dim ButtonTool13 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("About")
        Dim StateButtonTool7 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("AutoComplete", "")
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("SaveGame")
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool15 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("OpenGame")
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool17 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("SaveGameAs")
        Dim ButtonTool21 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("miStartTranscript")
        Dim ButtonTool23 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Options")
        Dim PopupMenuTool14 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("Macros")
        Dim ButtonTool26 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Edit Macros")
        Dim ButtonTool27 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Edit Macros")
        Dim ButtonTool25 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("RestartGame")
        Dim ButtonTool30 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapZoomIn")
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool31 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapZoomOut")
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim StateButtonTool9 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("MapPlayerLock", "")
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim StateButtonTool11 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("CentreMapLock", "")
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool33 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("AboutAdventure")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim UltraStatusPanel2 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraStatusPanel3 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRunner))
        Me.pbxGraphics = New ADRIFT.clsImage()
        Me.MapHolder = New System.Windows.Forms.Control()
        Me.UDMRunner = New Infragistics.Win.UltraWinDock.UltraDockManager(Me.components)
        Me._frmRunnerUnpinnedTabAreaLeft = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me._frmRunnerUnpinnedTabAreaRight = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me._frmRunnerUnpinnedTabAreaTop = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me._frmRunnerUnpinnedTabAreaBottom = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me._frmRunner_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UTMMain = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._frmRunner_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._frmRunner_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._frmRunner_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._frmRunnerAutoHideControl = New Infragistics.Win.UltraWinDock.AutoHideControl()
        Me.StatusBar = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.WindowDockingArea2 = New Infragistics.Win.UltraWinDock.WindowDockingArea()
        Me.DockableWindow1 = New Infragistics.Win.UltraWinDock.DockableWindow()
        Me.DockableWindow3 = New Infragistics.Win.UltraWinDock.DockableWindow()
        Me.txtInput = New System.Windows.Forms.RichTextBox()
        Me.txtOutput = New System.Windows.Forms.RichTextBox()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnSubmit = New Infragistics.Win.Misc.UltraButton()
        Me.btnMore = New Infragistics.Win.Misc.UltraButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.WindowDockingArea3 = New Infragistics.Win.UltraWinDock.WindowDockingArea()
        Me.WindowDockingArea5 = New Infragistics.Win.UltraWinDock.WindowDockingArea()
        Me.WindowDockingArea1 = New Infragistics.Win.UltraWinDock.WindowDockingArea()
        CType(Me.UDMRunner, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UTMMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WindowDockingArea2.SuspendLayout()
        Me.DockableWindow1.SuspendLayout()
        Me.DockableWindow3.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.WindowDockingArea3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbxGraphics
        '
        Me.pbxGraphics.BackColor = System.Drawing.Color.Transparent
        Me.pbxGraphics.BackColour = System.Drawing.Color.Transparent
        Me.pbxGraphics.Image = Nothing
        Me.pbxGraphics.Location = New System.Drawing.Point(0, 20)
        Me.pbxGraphics.Name = "pbxGraphics"
        Me.pbxGraphics.Size = New System.Drawing.Size(183, 377)
        Me.pbxGraphics.SizeMode = ADRIFT.clsImage.SizeModeEnum.ActualSizeCentred
        Me.pbxGraphics.TabIndex = 0
        Me.pbxGraphics.TabStop = False
        '
        'MapHolder
        '
        Me.MapHolder.BackColor = System.Drawing.Color.Blue
        Me.MapHolder.Location = New System.Drawing.Point(0, 20)
        Me.MapHolder.Name = "MapHolder"
        Me.MapHolder.Size = New System.Drawing.Size(183, 169)
        Me.MapHolder.TabIndex = 0
        '
        'UDMRunner
        '
        DockAreaPane1.DockedBefore = New System.Guid("810d89e0-1a82-4b9b-9221-07fe4dc6f671")
        DockAreaPane1.FloatingLocation = New System.Drawing.Point(565, 357)
        DockableControlPane1.Control = Me.pbxGraphics
        DockableControlPane1.Key = "Graphics"
        DockableControlPane1.OriginalControlBounds = New System.Drawing.Rectangle(80, 136, 152, 104)
        DockableControlPane1.Size = New System.Drawing.Size(180, 153)
        DockableControlPane1.Text = "Graphics"
        DockAreaPane1.Panes.AddRange(New Infragistics.Win.UltraWinDock.DockablePaneBase() {DockableControlPane1})
        DockAreaPane1.Size = New System.Drawing.Size(183, 397)
        DockAreaPane2.DockedBefore = New System.Guid("7300ca1b-647a-4abc-8580-a3435aee91f1")
        DockableControlPane2.Closed = True
        DockableControlPane2.Control = Me.MapHolder
        DockableControlPane2.Key = "Map"
        DockableControlPane2.OriginalControlBounds = New System.Drawing.Rectangle(232, 136, 153, 132)
        DockableControlPane2.Size = New System.Drawing.Size(100, 141)
        DockableControlPane2.Text = "Map"
        DockAreaPane2.Panes.AddRange(New Infragistics.Win.UltraWinDock.DockablePaneBase() {DockableControlPane2})
        DockAreaPane2.Size = New System.Drawing.Size(183, 397)
        DockAreaPane3.DockedBefore = New System.Guid("a048d2fa-390f-49be-ac40-0d4facdead52")
        DockAreaPane3.FloatingLocation = New System.Drawing.Point(563, 339)
        DockAreaPane3.Size = New System.Drawing.Size(95, 395)
        DockAreaPane4.FloatingLocation = New System.Drawing.Point(565, 357)
        DockAreaPane4.Size = New System.Drawing.Size(183, 397)
        Me.UDMRunner.DockAreas.AddRange(New Infragistics.Win.UltraWinDock.DockAreaPane() {DockAreaPane1, DockAreaPane2, DockAreaPane3, DockAreaPane4})
        Me.UDMRunner.DragWindowStyle = Infragistics.Win.UltraWinDock.DragWindowStyle.LayeredWindowWithIndicators
        Me.UDMRunner.HostControl = Me
        Me.UDMRunner.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.VisualStudio2005
        '
        '_frmRunnerUnpinnedTabAreaLeft
        '
        Me._frmRunnerUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me._frmRunnerUnpinnedTabAreaLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frmRunnerUnpinnedTabAreaLeft.Location = New System.Drawing.Point(0, 48)
        Me._frmRunnerUnpinnedTabAreaLeft.Name = "_frmRunnerUnpinnedTabAreaLeft"
        Me._frmRunnerUnpinnedTabAreaLeft.Owner = Me.UDMRunner
        Me._frmRunnerUnpinnedTabAreaLeft.Size = New System.Drawing.Size(0, 397)
        Me._frmRunnerUnpinnedTabAreaLeft.TabIndex = 5
        Me._frmRunnerUnpinnedTabAreaLeft.TabStop = False
        '
        '_frmRunnerUnpinnedTabAreaRight
        '
        Me._frmRunnerUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right
        Me._frmRunnerUnpinnedTabAreaRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frmRunnerUnpinnedTabAreaRight.Location = New System.Drawing.Point(627, 48)
        Me._frmRunnerUnpinnedTabAreaRight.Name = "_frmRunnerUnpinnedTabAreaRight"
        Me._frmRunnerUnpinnedTabAreaRight.Owner = Me.UDMRunner
        Me._frmRunnerUnpinnedTabAreaRight.Size = New System.Drawing.Size(0, 397)
        Me._frmRunnerUnpinnedTabAreaRight.TabIndex = 6
        Me._frmRunnerUnpinnedTabAreaRight.TabStop = False
        '
        '_frmRunnerUnpinnedTabAreaTop
        '
        Me._frmRunnerUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top
        Me._frmRunnerUnpinnedTabAreaTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frmRunnerUnpinnedTabAreaTop.Location = New System.Drawing.Point(0, 48)
        Me._frmRunnerUnpinnedTabAreaTop.Name = "_frmRunnerUnpinnedTabAreaTop"
        Me._frmRunnerUnpinnedTabAreaTop.Owner = Me.UDMRunner
        Me._frmRunnerUnpinnedTabAreaTop.Size = New System.Drawing.Size(627, 0)
        Me._frmRunnerUnpinnedTabAreaTop.TabIndex = 3
        Me._frmRunnerUnpinnedTabAreaTop.TabStop = False
        '
        '_frmRunnerUnpinnedTabAreaBottom
        '
        Me._frmRunnerUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me._frmRunnerUnpinnedTabAreaBottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frmRunnerUnpinnedTabAreaBottom.Location = New System.Drawing.Point(0, 445)
        Me._frmRunnerUnpinnedTabAreaBottom.Name = "_frmRunnerUnpinnedTabAreaBottom"
        Me._frmRunnerUnpinnedTabAreaBottom.Owner = Me.UDMRunner
        Me._frmRunnerUnpinnedTabAreaBottom.Size = New System.Drawing.Size(627, 0)
        Me._frmRunnerUnpinnedTabAreaBottom.TabIndex = 4
        Me._frmRunnerUnpinnedTabAreaBottom.TabStop = False
        '
        '_frmRunner_Toolbars_Dock_Area_Left
        '
        Me._frmRunner_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmRunner_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control
        Me._frmRunner_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._frmRunner_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmRunner_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 48)
        Me._frmRunner_Toolbars_Dock_Area_Left.Name = "_frmRunner_Toolbars_Dock_Area_Left"
        Me._frmRunner_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 397)
        Me._frmRunner_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UTMMain
        '
        'UTMMain
        '
        Me.UTMMain.DesignerFlags = 1
        Me.UTMMain.DockWithinContainer = Me
        Me.UTMMain.DockWithinContainerBaseType = GetType(System.Windows.Forms.Form)
        Me.UTMMain.ShowFullMenusDelay = 500
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.FloatingSize = New System.Drawing.Size(232, 44)
        UltraToolbar1.IsMainMenuBar = True
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {PopupMenuTool1, PopupMenuTool2, PopupMenuTool3, PopupMenuTool13, PopupMenuTool4, PopupMenuTool5})
        UltraToolbar1.Text = "mnuRunner"
        UltraToolbar2.DockedColumn = 0
        UltraToolbar2.DockedRow = 1
        UltraToolbar2.FloatingSize = New System.Drawing.Size(107, 50)
        ButtonTool28.InstanceProps.IsFirstInGroup = True
        UltraToolbar2.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, ButtonTool14, ButtonTool6, ButtonTool28, ButtonTool29, StateButtonTool10, StateButtonTool8})
        UltraToolbar2.Text = "ToolBar"
        Me.UTMMain.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1, UltraToolbar2})
        Appearance32.Image = Global.ADRIFT.My.Resources.imgOpen
        ButtonTool2.SharedPropsInternal.AppearancesSmall.Appearance = Appearance32
        ButtonTool2.SharedPropsInternal.Caption = "Open Adventure..."
        ButtonTool2.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        PopupMenuTool6.SharedPropsInternal.Caption = "&File"
        PopupMenuTool6.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        ButtonTool20.InstanceProps.IsFirstInGroup = True
        ButtonTool18.InstanceProps.IsFirstInGroup = True
        PopupMenuTool7.InstanceProps.IsFirstInGroup = True
        ButtonTool4.InstanceProps.IsFirstInGroup = True
        PopupMenuTool6.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool3, ButtonTool20, ButtonTool24, ButtonTool18, ButtonTool19, ButtonTool16, PopupMenuTool7, ButtonTool4})
        PopupMenuTool8.SharedPropsInternal.Caption = "&Edit"
        StateButtonTool6.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        PopupMenuTool8.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {StateButtonTool6})
        PopupMenuTool9.SharedPropsInternal.Caption = "&View"
        StateButtonTool1.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool2.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        PopupMenuTool9.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {StateButtonTool1, StateButtonTool2, ButtonTool22})
        PopupMenuTool10.SharedPropsInternal.Caption = "&Help"
        PopupMenuTool10.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType
        PopupMenuTool10.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool12, ButtonTool32})
        StateButtonTool3.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool3.SharedPropsInternal.Caption = "Full Screen"
        StateButtonTool4.SharedPropsInternal.Caption = "Hide Menu"
        PopupMenuTool11.SharedPropsInternal.Caption = "&Window"
        PopupMenuTool11.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool10, ButtonTool11})
        MdiWindowListTool1.SharedPropsInternal.Caption = "MDIWindowListTool1"
        PopupMenuTool12.SharedPropsInternal.Caption = "Recent Adventures"
        Appearance12.Image = Global.ADRIFT.My.Resources.imgCancel16
        ButtonTool5.SharedPropsInternal.AppearancesSmall.Appearance = Appearance12
        ButtonTool5.SharedPropsInternal.Caption = "E&xit"
        StateButtonTool5.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool5.SharedPropsInternal.Caption = "Debugger"
        ButtonTool8.SharedPropsInternal.Caption = "Show Map"
        ButtonTool8.SharedPropsInternal.Enabled = False
        ButtonTool8.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlM
        ButtonTool9.SharedPropsInternal.Caption = "Show Graphics"
        ButtonTool9.SharedPropsInternal.Enabled = False
        ButtonTool9.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        ButtonTool13.SharedPropsInternal.Caption = "About ADRIFT"
        StateButtonTool7.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool7.SharedPropsInternal.Caption = "Auto Complete"
        Appearance33.Image = Global.ADRIFT.My.Resources.imgSave16
        ButtonTool7.SharedPropsInternal.AppearancesSmall.Appearance = Appearance33
        ButtonTool7.SharedPropsInternal.Caption = "Save Game"
        ButtonTool7.SharedPropsInternal.Enabled = False
        ButtonTool7.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Appearance34.Image = Global.ADRIFT.My.Resources.imgFolderBlue16
        ButtonTool15.SharedPropsInternal.AppearancesSmall.Appearance = Appearance34
        ButtonTool15.SharedPropsInternal.Caption = "Open Game..."
        ButtonTool15.SharedPropsInternal.Enabled = False
        ButtonTool15.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        ButtonTool17.SharedPropsInternal.Caption = "Save Game As..."
        ButtonTool17.SharedPropsInternal.Enabled = False
        ButtonTool21.SharedPropsInternal.Caption = "Start Transcript..."
        ButtonTool23.SharedPropsInternal.Caption = "Options"
        PopupMenuTool14.SharedPropsInternal.Caption = "&Macros"
        PopupMenuTool14.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType
        PopupMenuTool14.SharedPropsInternal.Enabled = False
        ButtonTool26.InstanceProps.IsFirstInGroup = True
        PopupMenuTool14.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool26})
        ButtonTool27.SharedPropsInternal.Caption = "Edit Macros"
        ButtonTool25.SharedPropsInternal.Caption = "Restart Game"
        ButtonTool25.SharedPropsInternal.Enabled = False
        ButtonTool25.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlR
        Appearance35.Image = Global.ADRIFT.My.Resources.imgZoomIn16
        ButtonTool30.SharedPropsInternal.AppearancesSmall.Appearance = Appearance35
        ButtonTool30.SharedPropsInternal.Caption = "Zoom In"
        Appearance36.Image = Global.ADRIFT.My.Resources.imgZoomOut16
        ButtonTool31.SharedPropsInternal.AppearancesSmall.Appearance = Appearance36
        ButtonTool31.SharedPropsInternal.Caption = "Zoom Out"
        Appearance37.Image = Global.ADRIFT.My.Resources.imgCentre16
        StateButtonTool9.SharedPropsInternal.AppearancesSmall.Appearance = Appearance37
        StateButtonTool9.SharedPropsInternal.Caption = "Player Location lock"
        Appearance38.Image = Global.ADRIFT.My.Resources.imgCentre16
        StateButtonTool11.SharedPropsInternal.AppearancesSmall.Appearance = Appearance38
        StateButtonTool11.SharedPropsInternal.Caption = "Centre Map lock"
        ButtonTool33.SharedPropsInternal.Caption = "About Adventure"
        Me.UTMMain.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool2, PopupMenuTool6, PopupMenuTool8, PopupMenuTool9, PopupMenuTool10, StateButtonTool3, StateButtonTool4, PopupMenuTool11, MdiWindowListTool1, PopupMenuTool12, ButtonTool5, StateButtonTool5, ButtonTool8, ButtonTool9, ButtonTool13, StateButtonTool7, ButtonTool7, ButtonTool15, ButtonTool17, ButtonTool21, ButtonTool23, PopupMenuTool14, ButtonTool27, ButtonTool25, ButtonTool30, ButtonTool31, StateButtonTool9, StateButtonTool11, ButtonTool33})
        '
        '_frmRunner_Toolbars_Dock_Area_Right
        '
        Me._frmRunner_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmRunner_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control
        Me._frmRunner_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._frmRunner_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmRunner_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(627, 48)
        Me._frmRunner_Toolbars_Dock_Area_Right.Name = "_frmRunner_Toolbars_Dock_Area_Right"
        Me._frmRunner_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 397)
        Me._frmRunner_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UTMMain
        '
        '_frmRunner_Toolbars_Dock_Area_Top
        '
        Me._frmRunner_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmRunner_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control
        Me._frmRunner_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._frmRunner_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmRunner_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._frmRunner_Toolbars_Dock_Area_Top.Name = "_frmRunner_Toolbars_Dock_Area_Top"
        Me._frmRunner_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(627, 48)
        Me._frmRunner_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UTMMain
        '
        '_frmRunner_Toolbars_Dock_Area_Bottom
        '
        Me._frmRunner_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmRunner_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmRunner_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmRunner_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmRunner_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 445)
        Me._frmRunner_Toolbars_Dock_Area_Bottom.Name = "_frmRunner_Toolbars_Dock_Area_Bottom"
        Me._frmRunner_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(627, 0)
        Me._frmRunner_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UTMMain
        '
        '_frmRunnerAutoHideControl
        '
        Me._frmRunnerAutoHideControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frmRunnerAutoHideControl.Location = New System.Drawing.Point(0, 0)
        Me._frmRunnerAutoHideControl.Name = "_frmRunnerAutoHideControl"
        Me._frmRunnerAutoHideControl.Owner = Me.UDMRunner
        Me._frmRunnerAutoHideControl.Size = New System.Drawing.Size(0, 0)
        Me._frmRunnerAutoHideControl.TabIndex = 0
        Me._frmRunnerAutoHideControl.TabStop = False
        '
        'StatusBar
        '
        Appearance1.FontData.SizeInPoints = 11.0!
        Me.StatusBar.Appearance = Appearance1
        Me.StatusBar.Location = New System.Drawing.Point(0, 445)
        Me.StatusBar.Name = "StatusBar"
        UltraStatusPanel1.Key = "Description"
        UltraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        UltraStatusPanel1.Text = "Please open an adventure file"
        Appearance2.TextHAlignAsString = "Center"
        UltraStatusPanel2.Appearance = Appearance2
        UltraStatusPanel2.Key = "UserStatus"
        UltraStatusPanel2.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring
        UltraStatusPanel3.Key = "Score"
        UltraStatusPanel3.Text = "Score: 0"
        UltraStatusPanel3.Visible = False
        Me.StatusBar.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel1, UltraStatusPanel2, UltraStatusPanel3})
        Me.StatusBar.Size = New System.Drawing.Size(627, 23)
        Me.StatusBar.TabIndex = 11
        Me.StatusBar.Tag = ""
        '
        'WindowDockingArea2
        '
        Me.WindowDockingArea2.Controls.Add(Me.DockableWindow1)
        Me.WindowDockingArea2.Dock = System.Windows.Forms.DockStyle.Right
        Me.WindowDockingArea2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WindowDockingArea2.Location = New System.Drawing.Point(439, 48)
        Me.WindowDockingArea2.Name = "WindowDockingArea2"
        Me.WindowDockingArea2.Owner = Me.UDMRunner
        Me.WindowDockingArea2.Size = New System.Drawing.Size(188, 397)
        Me.WindowDockingArea2.TabIndex = 2
        Me.WindowDockingArea2.TabStop = False
        '
        'DockableWindow1
        '
        Me.DockableWindow1.Controls.Add(Me.pbxGraphics)
        Me.DockableWindow1.Location = New System.Drawing.Point(5, 0)
        Me.DockableWindow1.Name = "DockableWindow1"
        Me.DockableWindow1.Owner = Me.UDMRunner
        Me.DockableWindow1.Size = New System.Drawing.Size(183, 397)
        Me.DockableWindow1.TabIndex = 12
        Me.DockableWindow1.TabStop = False
        '
        'DockableWindow3
        '
        Me.DockableWindow3.Controls.Add(Me.MapHolder)
        Me.DockableWindow3.Location = New System.Drawing.Point(5, 0)
        Me.DockableWindow3.Name = "DockableWindow3"
        Me.DockableWindow3.Owner = Me.UDMRunner
        Me.DockableWindow3.Size = New System.Drawing.Size(183, 397)
        Me.DockableWindow3.TabIndex = 13
        '
        'txtInput
        '
        Me.txtInput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInput.BackColor = System.Drawing.Color.Black
        Me.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInput.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtInput.Location = New System.Drawing.Point(48, 0)
        Me.txtInput.Multiline = False
        Me.txtInput.Name = "txtInput"
        Me.txtInput.ReadOnly = True
        Me.txtInput.Size = New System.Drawing.Size(387, 20)
        Me.txtInput.TabIndex = 1
        Me.txtInput.Text = ""
        '
        'txtOutput
        '
        Me.txtOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOutput.BackColor = System.Drawing.Color.Black
        Me.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOutput.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtOutput.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtOutput.Location = New System.Drawing.Point(48, 0)
        Me.txtOutput.Margin = New System.Windows.Forms.Padding(0)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtOutput.Size = New System.Drawing.Size(388, 367)
        Me.txtOutput.TabIndex = 0
        Me.txtOutput.TabStop = False
        Me.txtOutput.Text = ""
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.Black
        Me.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlTop.Controls.Add(Me.txtOutput)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(439, 371)
        Me.pnlTop.TabIndex = 0
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.Black
        Me.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBottom.Controls.Add(Me.btnSubmit)
        Me.pnlBottom.Controls.Add(Me.btnMore)
        Me.pnlBottom.Controls.Add(Me.txtInput)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBottom.Location = New System.Drawing.Point(0, 0)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(439, 25)
        Me.pnlBottom.TabIndex = 0
        '
        'btnSubmit
        '
        Me.btnSubmit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSubmit.Location = New System.Drawing.Point(386, 0)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(49, 21)
        Me.btnSubmit.TabIndex = 13
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.Visible = False
        '
        'btnMore
        '
        Me.btnMore.Location = New System.Drawing.Point(131, -2)
        Me.btnMore.Name = "btnMore"
        Me.btnMore.Size = New System.Drawing.Size(307, 24)
        Me.btnMore.TabIndex = 12
        Me.btnMore.Text = "Press any key to continue"
        Me.btnMore.Visible = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 48)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlTop)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlBottom)
        Me.SplitContainer1.Size = New System.Drawing.Size(439, 397)
        Me.SplitContainer1.SplitterDistance = 371
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 1
        Me.SplitContainer1.TabStop = False
        '
        'WindowDockingArea3
        '
        Me.WindowDockingArea3.Controls.Add(Me.DockableWindow3)
        Me.WindowDockingArea3.Dock = System.Windows.Forms.DockStyle.Right
        Me.WindowDockingArea3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WindowDockingArea3.Location = New System.Drawing.Point(4, 4)
        Me.WindowDockingArea3.Name = "WindowDockingArea3"
        Me.WindowDockingArea3.Owner = Me.UDMRunner
        Me.WindowDockingArea3.Size = New System.Drawing.Size(188, 397)
        Me.WindowDockingArea3.TabIndex = 0
        Me.WindowDockingArea3.TabStop = False
        '
        'WindowDockingArea5
        '
        Me.WindowDockingArea5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WindowDockingArea5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WindowDockingArea5.Location = New System.Drawing.Point(8, 8)
        Me.WindowDockingArea5.Name = "WindowDockingArea5"
        Me.WindowDockingArea5.Owner = Me.UDMRunner
        Me.WindowDockingArea5.Size = New System.Drawing.Size(95, 395)
        Me.WindowDockingArea5.TabIndex = 0
        '
        'WindowDockingArea1
        '
        Me.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WindowDockingArea1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WindowDockingArea1.Location = New System.Drawing.Point(439, 48)
        Me.WindowDockingArea1.Name = "WindowDockingArea1"
        Me.WindowDockingArea1.Owner = Me.UDMRunner
        Me.WindowDockingArea1.Size = New System.Drawing.Size(183, 397)
        Me.WindowDockingArea1.TabIndex = 13
        '
        'frmRunner
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(627, 468)
        Me.Controls.Add(Me._frmRunnerAutoHideControl)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.WindowDockingArea3)
        Me.Controls.Add(Me.WindowDockingArea2)
        Me.Controls.Add(Me._frmRunnerUnpinnedTabAreaBottom)
        Me.Controls.Add(Me._frmRunnerUnpinnedTabAreaTop)
        Me.Controls.Add(Me._frmRunnerUnpinnedTabAreaRight)
        Me.Controls.Add(Me._frmRunnerUnpinnedTabAreaLeft)
        Me.Controls.Add(Me._frmRunner_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._frmRunner_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._frmRunner_Toolbars_Dock_Area_Top)
        Me.Controls.Add(Me._frmRunner_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me.StatusBar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRunner"
        Me.Text = "ADRIFT Runner"
        CType(Me.UDMRunner, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UTMMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WindowDockingArea2.ResumeLayout(False)
        Me.DockableWindow1.ResumeLayout(False)
        Me.DockableWindow3.ResumeLayout(False)
        Me.pnlTop.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.WindowDockingArea3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FullScreen(ByVal bActivate As Boolean)
        If bActivate Then
            'Hide()
            txtOutput.Visible = False
            pnlTop.BorderStyle = BorderStyle.None
            pnlBottom.BorderStyle = BorderStyle.None
            'Application.DoEvents()

            Me.Text = ""
            Me.ControlBox = False
            WindowState = FormWindowState.Maximized
            txtOutput.Visible = True
            'Me.txtOutput.BorderStyle = BorderStyle.None
            'Me.txtInput.BorderStyle = BorderStyle.None
            'Show()
        Else
            WindowState = FormWindowState.Normal
            Me.ControlBox = True
            Me.Text = "ADRIFT Runner"
            'Hide()

            pnlTop.BorderStyle = BorderStyle.Fixed3D
            pnlBottom.BorderStyle = BorderStyle.Fixed3D
            'Show()
            'Me.txtOutput.BorderStyle = BorderStyle.Fixed3D
            'Me.txtInput.BorderStyle = BorderStyle.Fixed3D
        End If
        CType(UTMMain.Tools("mnuFullScreen"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = bActivate
        SaveSetting("ADRIFT", "Runner", "FullScreen", CInt(bActivate).ToString)
        'Application.DoEvents()
    End Sub


    Public Sub UpdateStatusBar(sDescription As String, ByVal sScore As String, ByVal sUserStatus As String)
        Try
            If Not StatusBar.IsDisposed Then
                With StatusBar
                    .Panels("Description").Text = sDescription
                    If sScore <> "" Then
                        .Panels("Score").Text = sScore
                        .Panels("Score").Visible = True
                    Else
                        .Panels("Score").Visible = False
                    End If
                    If sUserStatus <> "" Then
                        .Panels("UserStatus").Text = ReplaceALRs(sUserStatus)
                        .Panels("UserStatus").Visible = True
                        .Panels("Description").SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
                    Else
                        .Panels("UserStatus").Visible = False
                        .Panels("Description").SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring
                    End If
                End With
            End If
        Catch
        End Try
    End Sub


    Private Sub UTMMain_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UTMMain.ToolClick
        DoToolClick(e.Tool.Key, e.Tool.SharedProps.Caption, CStr(e.Tool.SharedProps.Tag))
    End Sub

    Private Sub DoToolClick(ByVal sKey As String, ByVal sCaption As String, ByVal sTag As String)

        Try
            If sTag = "_RECENT_" Then
                UserSession.OpenAdventure(sKey)
            End If

            Select Case sKey
                Case "About"
                    Dim fAbout As New AboutBox
                    Try
                        fAbout.ShowDialog()
                    Catch
                    End Try
                    'MessageBox.Show("ADRIFT Runner" & vbCrLf & "Version " & Application.ProductVersion & vbCrLf & "© Campbell Wild 2010" & vbCrLf & vbCrLf & "Alpha Release.  Registered users only." & vbCrLf & "Splash image ""Adrift"" © V. Milovic 2010 (www.brokentoyland.com)", "About ADRIFT Runner", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case "AboutAdventure"
                    Dim sVersion As String = ""
                    If Adventure IsNot Nothing Then
                        If Adventure.BabelTreatyInfo IsNot Nothing Then
                            If Adventure.BabelTreatyInfo.Stories.Length = 1 AndAlso Adventure.BabelTreatyInfo.Stories(0).Releases IsNot Nothing Then
                                With Adventure.BabelTreatyInfo.Stories(0).Releases.Attached.Release
                                    sVersion = vbCrLf & "Version: " & .Version
                                    If .ReleaseDate > Date.MinValue Then sVersion &= vbCrLf & "Released: " & .ReleaseDate.ToLongDateString
                                End With
                            End If
                        End If
                        MessageBox.Show(Adventure.Title & vbCrLf & "By " & Adventure.Author & sVersion, "About Adventure", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Case "AutoComplete"
                    'CType(UTMMain.Tools("AutoComplete"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = Not CType(UTMMain.Tools("AutoComplete"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked                
                    UserSession.bAutoComplete = CType(UTMMain.Tools("AutoComplete"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked
                    SaveSetting("ADRIFT", "Generator", "Auto Complete", CInt(UserSession.bAutoComplete).ToString)
                Case "Debugger"
                    If UserSession.Debugger Is Nothing OrElse UserSession.Debugger.IsDisposed Then UserSession.Debugger = New frmDebugger
                    UserSession.Debugger.Visible = CType(UTMMain.Tools("Debugger"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked
                Case "Exit"
                    UserSession.Quit()
                Case "mnuFullScreen"
                    FullScreen(CType(UTMMain.Tools("mnuFullScreen"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked)
                Case "mnuOpenAdv"
                    OpenAdventureDialog(fRunner.ofd)
                Case "RestartGame"
                    UserSession.Restart()
                Case "OpenGame"
                    UserSession.Restore()
                    UserSession.Display(vbCrLf & vbCrLf, True)
                Case "SaveGame", "SaveGameAs"
                    UserSession.SaveGame(sKey = "SaveGameAs")
                    UserSession.Display(vbCrLf & vbCrLf, True)
                Case "ShowGraphics"
                    For Each cp As Infragistics.Win.UltraWinDock.DockableControlPane In UDMRunner.ControlPanes
                        If cp.Text = "Graphics" AndAlso Not cp.IsVisible Then
                            cp.Show()
                            UTMMain.Tools("ShowGraphics").SharedProps.Enabled = False
                            SetMargins()
                        End If
                    Next
                Case "ShowMap"
                    For Each cp As Infragistics.Win.UltraWinDock.DockableControlPane In UDMRunner.ControlPanes
                        If cp.Text = "Map" AndAlso Not cp.IsVisible Then
                            cp.Show()
                            UTMMain.Tools("ShowMap").SharedProps.Enabled = False
                            SetMargins()
                        End If
                    Next
                    'If Not UDMRunner.ControlPanes.Exists("") Then Exit Sub
                    'UDM.ControlPanes(sPane).Closed = False ' We're getting an Infragistics Stack overflow bug whenever we try to reopen a pane that was restored as closed...
                    'UDM.ControlPanes(sPane).Activate()
                    'CType(sender, ToolStripMenuItem).Visible = False
                    'If Not arlOpenPanes.Contains(sPane) Then arlOpenPanes.Add(sPane)
                Case "miStartTranscript"
                    If UTMMain.Tools("miStartTranscript").SharedProps.Caption = "Start Transcript..." Then
                        StartTranscript()
                    Else
                        StopTranscript()
                    End If

                Case "Options"
                    Dim frmOptions As New frmOptionsRunner
                    frmOptions.ShowDialog()

                Case "Edit Macros"
                    Dim frmMacros As New frmMacros
                    'frmMacros.dictMacros = CType(dictMacros.Clon, StringHashTable)
                    frmMacros.ldictMacros = New Generic.Dictionary(Of String, clsMacro)
                    For Each macro As clsMacro In UserSession.dictMacros.Values
                        frmMacros.ldictMacros.Add(macro.Key, CType(macro.Clone, clsMacro))
                    Next
                    frmMacros.Text = "Edit Macros - " & Adventure.Title
                    frmMacros.Show()

                Case "MapPlan"
                    UserSession.Map.PlanView()

                Case "MapCentre"
                    UserSession.Map.CentreMap()

                Case "MapZoomIn"
                    UserSession.Map.Zoom(True)

                Case "MapZoomOut"
                    UserSession.Map.Zoom(False)

                Case "CentreMapLock"
                    UserSession.Map.LockMapCentre = CType(UTMMain.Tools(sKey), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked

                Case "MapPlayerLock"
                    UserSession.Map.LockPlayerCentre = CType(UTMMain.Tools(sKey), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked

                Case Else
                    'ErrMsg("Tool " & sKey & " not yet programmed!")

            End Select

            If sLeft(sKey, 6) = "Macro-" Then
                RunMacro(sKey.Replace("Macro-", ""))
            End If

        Catch ex As Exception
            ErrMsg("Tool Click error", ex)
        End Try

    End Sub


    Private bStopMacro As Boolean = False
    Private Sub RunMacro(ByVal sKey As String)

        bStopMacro = False

        If UserSession.dictMacros.ContainsKey(sKey) Then
            If UserSession.dictMacros(sKey).Commands IsNot Nothing Then
                Dim bAutoComplete As Boolean = UserSession.bAutoComplete
                UserSession.bAutoComplete = False
                For Each sCommand As String In UserSession.dictMacros(sKey).Commands.Split(Chr(10))
                    sCommand = ReplaceFunctions(sCommand)
                    If sCommand.Trim <> "" Then
                        If sLeft(sCommand, 1) = "#" AndAlso sCommand.Length > 1 Then
                            txtInput_KeyDown(Nothing, New KeyEventArgs(Keys.OemQuotes))
                            txtInput.Text = "@ " & sCommand.Substring(1).Trim
                        Else
                            txtInput.Text = "xx" & sCommand.Trim
                        End If

                        txtInput_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                        Application.DoEvents()
                        If bStopMacro Then Exit Sub
                    End If
                Next
                UserSession.bAutoComplete = bAutoComplete
            End If
        End If

    End Sub


    '' Load Macros from file
    'Public Sub LoadMacros()

    '    Try
    '        Dim sMacrosFile As String = sLocalDataPath & "ADRIFTMacros.xml"
    '        dictMacros.Clear()

    '        If IO.File.Exists(sMacrosFile) Then
    '            Dim xmlDoc As New System.Xml.XmlDocument
    '            xmlDoc.Load(sMacrosFile)
    '            Dim bFirst As Boolean = True

    '            For Each nod As System.Xml.XmlNode In xmlDoc.SelectNodes("/Macros/Macro")

    '                Dim sTitle As String = nod.SelectSingleNode("Title").InnerText
    '                Dim sCommands As String = nod.SelectSingleNode("Commands").InnerText
    '                Dim sKey As String = nod.SelectSingleNode("Key").InnerText

    '                If sKey <> "" AndAlso sTitle <> "" AndAlso sCommands <> "" Then
    '                    Dim macro As New clsMacro(sKey)
    '                    macro.Title = sTitle
    '                    macro.Commands = sCommands

    '                    If nod.SelectSingleNode("Shared") IsNot Nothing Then macro.Shared = SafeBool(nod.SelectSingleNode("Shared").InnerText)
    '                    If nod.SelectSingleNode("IFID") IsNot Nothing Then macro.IFID = SafeString(nod.SelectSingleNode("IFID").InnerText)
    '                    If nod.SelectSingleNode("Shortcut") IsNot Nothing Then macro.Shortcut = CType([Enum].Parse(GetType(Shortcut), nod.SelectSingleNode("Shortcut").InnerText), Shortcut)

    '                    dictMacros.Add(macro.Key, macro)
    '                End If
    '            Next
    '        End If

    '        ReloadMacros()

    '    Catch ex As Exception
    '        ErrMsg("Error loading macros", ex)
    '    End Try

    'End Sub


    'Public Sub SaveMacros()

    '    Try
    '        Dim sMacrosFile As String = sLocalDataPath & "ADRIFTMacros.xml"

    '        Dim xmlWriter As New System.Xml.XmlTextWriter(sMacrosFile, System.Text.Encoding.UTF8)
    '        With xmlWriter
    '            .Indentation = 4
    '            .IndentChar = " "c
    '            .Formatting = Xml.Formatting.Indented

    '            .WriteStartDocument()
    '            .WriteComment("File created by ADRIFT v" & Application.ProductVersion)

    '            .WriteStartElement("Macros")

    '            For Each sTitle As String In dictMacros.Keys
    '                .WriteStartElement("Macro")

    '                Dim m As clsMacro = dictMacros(sTitle)

    '                .WriteElementString("Key", m.Key)
    '                .WriteElementString("Title", m.Title)
    '                .WriteElementString("Shared", m.Shared.ToString)
    '                .WriteElementString("IFID", m.IFID)
    '                If m.Shortcut <> Keys.None Then .WriteElementString("Shortcut", m.Shortcut.ToString)
    '                .WriteElementString("Commands", m.Commands)

    '                .WriteEndElement() ' Macro
    '            Next

    '            .WriteEndElement() ' Macros

    '            .WriteEndDocument()

    '            .Flush()
    '            .Close()

    '        End With
    '    Catch ex As Exception
    '        ErrMsg("Error saving macros", ex)
    '    End Try

    'End Sub


    ' Reload the macros on the form
    Public Sub ReloadMacros()

        Dim mnuMacros As PopupMenuTool = CType(UTMMain.Tools("Macros"), PopupMenuTool)

        For iTool As Integer = mnuMacros.Tools.Count - 1 To 0 Step -1
            If mnuMacros.Tools(iTool).Key <> "Edit Macros" Then mnuMacros.Tools.RemoveAt(iTool)
        Next

        'Dim arlKeys As New StringArrayList
        'For Each sTitle As String In dictMacros.Keys
        '    arlKeys.Add(sTitle)
        'Next
        'arlKeys.Sort()

        Dim i As Integer
        For Each macro As clsMacro In UserSession.dictMacros.Values
            i += 1
            With macro
                If Adventure IsNot Nothing AndAlso .IFID = Adventure.BabelTreatyInfo.Stories(0).Identification.IFID OrElse .Shared Then
                    Dim sToolKey As String = "Macro-" & .Key
                    If Not UTMMain.Tools.Exists(sToolKey) Then
                        Dim newTool As New ButtonTool(sToolKey)
                        newTool.SharedProps.Caption = .Title
                        UTMMain.Tools.Add(newTool)
                    End If

                    Dim newinstance As ButtonTool = CType(mnuMacros.Tools.InsertTool(mnuMacros.Tools.Count - 1, sToolKey), ButtonTool)
                    If .Shortcut <> Keys.None Then
                        UTMMain.Tools(sToolKey).SharedProps.Shortcut = .Shortcut
                    End If
                End If
            End With
        Next

    End Sub



    Private bLocked As Boolean = False
    Public Property Locked() As Boolean
        Get
            Return bLocked
        End Get
        Set(ByVal value As Boolean)
            bLocked = value
            'txtInput.Enabled = Not bLocked
            UTMMain.Enabled = Not bLocked
        End Set
    End Property


    Private bWaitKey As Boolean = False
    Public Sub WaitKey()
        bWaitKey = True
        Locked = True
        While bWaitKey AndAlso Visible
            Application.DoEvents()
            Threading.Thread.Sleep(5)
        End While
        Locked = False
        If fRunner.txtOutput IsNot Nothing AndAlso Not fRunner.txtOutput.IsDisposed Then UserSession.iPreviousOffset = fRunner.txtOutput.TextLength
    End Sub


    Private bLoadedMargins As Boolean = False
    Public Sub SetMargins()

        With UserSession
            If Not bLoadedMargins Then
                .iMarginWidth = CInt(GetSetting("ADRIFT", "Runner", "Margin", "10"))
                bLoadedMargins = True
            End If
            txtOutput.Width = pnlTop.ClientSize.Width - .iMarginWidth '+ 10
            txtOutput.Left = .iMarginWidth
            txtOutput.RightMargin = Math.Max(txtOutput.ClientSize.Width - .iMarginWidth, 0)
            txtInput.Width = pnlBottom.ClientSize.Width - .iMarginWidth ' + 10
            txtInput.Left = .iMarginWidth
            'txtInput.Top = -2
        End With

    End Sub


    Private Sub StartTranscript()

        With UserSession
            Dim sfd As New Windows.Forms.SaveFileDialog
            sfd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            If .sTranscriptFile = "" Then .sTranscriptFile = "ADRIFT_1.txt"
            Dim i As Integer = 1
            While IO.File.Exists(.sTranscriptFile)
                .sTranscriptFile = "ADRIFT_" & i & ".txt"
            End While
            sfd.FileName = .sTranscriptFile
            sfd.DefaultExt = "txt"
            sfd.OverwritePrompt = False
            If sfd.FileName.Length > 3 AndAlso Not sfd.FileName.ToLower.EndsWith("txt") Then sfd.FileName = ""
            If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                UTMMain.Tools("miStartTranscript").SharedProps.Caption = "Stop Transcript"
                .sTranscriptFile = sfd.FileName
            End If
        End With

    End Sub


    Private Sub StopTranscript()
        MessageBox.Show("Saving Transcript stopped." & vbCrLf & vbCrLf & "The file was saved as """ & UserSession.sTranscriptFile & """.", "ADRIFT Runner", MessageBoxButtons.OK, MessageBoxIcon.Information)
        UTMMain.Tools("miStartTranscript").SharedProps.Caption = "Start Transcript..."
    End Sub


    Private Sub txtInput_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInput.KeyDown

        Try
            With UserSession
                bIgnore = False

                If Locked Then
                    e.Handled = True
                    Exit Sub
                End If

                If .UserSplash IsNot Nothing AndAlso .UserSplash.Visible Then
                    e.Handled = True
                    .UserSplash.Hide()
                    Exit Sub
                End If

                If iCommand > .salCommands.Count - 1 Then iCommand = .salCommands.Count - 1

                Select Case e.KeyCode
                    Case Keys.Enter
                        e.Handled = True
                        e.SuppressKeyPress = True
                        bIgnore = True
                        'If txtInput.Text.Length > 2 AndAlso .salCommands.Count > 0 Then
                        '    .salCommands.Add("")
                        '    iCommand = .salCommands.Count - 1
                        '    .salCommands(iCommand - 1) = txtInput.Text.Substring(2)
                        '    .ClearAutoCompletes()
                        '    Adventure.Turns += 1
                        '    .Process(txtInput.Text.Substring(2).Trim)
                        'End If
                        SubmitCommand()
                    Case Keys.Up
                        If iCommand > 0 Then
                            iCommand -= 1
                            '.InitialiseInputBox()
                            'txtInput.SelectedText = .salCommands(iCommand)
                            'txtInput.SelectionStart = txtInput.Text.Length
                            SetInput(.salCommands(iCommand))
                        End If
                        e.Handled = True
                    Case Keys.Down
                        If iCommand < .salCommands.Count - 1 Then
                            iCommand += 1
                            '.InitialiseInputBox()
                            'txtInput.SelectedText = .salCommands(iCommand)
                            'txtInput.SelectionStart = txtInput.Text.Length
                            SetInput(.salCommands(iCommand))
                        End If
                        e.Handled = True
                    Case Keys.Left
                        If txtInput.SelectionStart <= 2 Then e.Handled = True
                    Case Keys.Back
                        If txtInput.SelectionStart <= 2 Then e.Handled = True
                        ' Otherwise, let it flow...
                    Case Keys.OemQuotes
                        If txtInput.SelectionStart = 2 Then
                            .InitialiseInputBox("@")
                            e.SuppressKeyPress = True
                            e.Handled = True
                        End If
                    Case Else
                        Application.DoEvents()
                        If iCommand > -1 AndAlso .salCommands.Count > iCommand Then ' .salCommands.Count > 0 AndAlso iCommand > -1 Then                            
                            .salCommands(iCommand) = txtInput.Text.Substring(2)
                        End If

                        If Not .bAutoComplete OrElse (Adventure IsNot Nothing AndAlso Adventure.eGameState <> clsAction.EndGameEnum.Running) OrElse (txtInput.Tag IsNot Nothing AndAlso txtInput.Tag.ToString = "Comment") Then Exit Sub
                        If txtInput.Text.Length < 3 Then Exit Sub

                        .DoAutoComplete()
                End Select
            End With

        Catch ex As Exception
            ErrMsg("KeyDown error", ex)
        End Try

    End Sub


    Public Sub SetInput(ByVal sText As String)
        UserSession.InitialiseInputBox()
        txtInput.SelectedText = sText
        txtInput.SelectionStart = txtInput.Text.Length
    End Sub


    Public Sub SubmitCommand()

        With UserSession
            If txtInput.Text.Length > 2 AndAlso .salCommands.Count > 0 Then
                btnSubmit.Enabled = False
                .salCommands.Add("")
                iCommand = .salCommands.Count - 1
                .salCommands(iCommand - 1) = txtInput.Text.Substring(2)
                .ClearAutoCompletes()
                Adventure.Turns += 1
                Dim sInput As String = txtInput.Text.Substring(2).Trim
                sInput = StripCarats(sInput)
                .Process(sInput)
                btnSubmit.Visible = False
                btnSubmit.Enabled = True
            End If
        End With

    End Sub


    Private Sub AddPrevious()

        Dim sFilename As String

        For iPrevious As Integer = 1 To 10
            sFilename = GetSetting("ADRIFT", "Runner", "Recent_" & iPrevious, "")
            If sFilename <> "" Then
                AddTool(UTMMain, "mnuRecentAdventures", sFilename, "&" & iPrevious & "  " & sFilename, "_RECENT_")
            End If
        Next

    End Sub

    Public Sub AddTool(ByRef UTMTarget As UltraToolbarsManager, ByVal sTargetTool As String, ByVal sKey As String, ByVal sCaption As String, Optional ByVal sTag As String = "", Optional ByVal bFirstInGroup As Boolean = False)

        Try
            Dim newTool As New ButtonTool(sKey)
            If Not UTMTarget.Tools.Exists(sKey) Then
                newTool.SharedProps.Caption = sCaption
                newTool.SharedProps.Tag = sTag
                UTMTarget.Tools.Add(newTool)

                Dim newinstance As ButtonTool = CType(CType(UTMTarget.Tools(sTargetTool), PopupMenuTool).Tools.AddTool(sKey), ButtonTool)
                newinstance.InstanceProps.IsFirstInGroup = bFirstInGroup
            End If
        Catch ex As Exception
            ' Probably a duplicate key
            ErrMsg("AddTool error", ex)
        End Try

    End Sub


    Private Sub frmRunner_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, txtInput.KeyDown, txtOutput.KeyDown
        If e.KeyData = Keys.Escape Then
            bStopMacro = True
        ElseIf e.KeyData = (Keys.Control Or Keys.M) Then
            For Each cp As Infragistics.Win.UltraWinDock.DockableControlPane In UDMRunner.ControlPanes
                If cp.Text = "Map" AndAlso cp.IsVisible Then
                    cp.Close()
                    UTMMain.Tools("ShowMap").SharedProps.Enabled = True
                    SetMargins()
                End If
            Next
        End If
    End Sub


    Friend Sub SetBackgroundColour(Optional ByVal colBackground As Color = Nothing)
        If colBackground = Nothing Then colBackground = GetBackgroundColour()
        fRunner.txtOutput.BackColor = colBackground
        fRunner.pnlTop.BackColor = colBackground
        fRunner.txtInput.BackColor = colBackground
        fRunner.pnlBottom.BackColor = colBackground
    End Sub

    Friend Sub SetInputColour(Optional ByVal colInput As Color = Nothing)
        If colInput = Nothing Then colInput = GetInputColour()
        fRunner.txtInput.ForeColor = colInput
    End Sub



    Private Sub frmRunner_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fRunner = Me
        fRunner.Visible = False
        SetBackgroundColour()
        SetInputColour()
        '        colInput = ColorTranslator.FromOle(CInt(GetSetting("ADRIFT", "Runner", "Text1", ColorTranslator.ToOle(Color.FromArgb(210, 37, 39)).ToString)))
        '       colOutput = ColorTranslator.FromOle(CInt(GetSetting("ADRIFT", "Runner", "Text2", ColorTranslator.ToOle(Color.FromArgb(25, 165, 138)).ToString)))
        '      colLink = ColorTranslator.FromOle(CInt(GetSetting("ADRIFT", "Runner", "LinkColour", ColorTranslator.ToOle(Color.FromArgb(75, 215, 188)).ToString)))

        eStyle = EnumParseViewStyle(GetSetting("ADRIFT", "Generator", "ViewStyle", "Office2007"))
        Select Case eStyle
            Case Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2013
                eColour2013 = EnumParseColourScheme2013(GetSetting("ADRIFT", "Generator", "ColourScheme", "LightGray"))
                Infragistics.Win.Office2013ColorTable.ColorScheme = eColour2013
            Case Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2010
                eColour2010 = EnumParseColourScheme2010(GetSetting("ADRIFT", "Generator", "ColourScheme", "Blue"))
                Infragistics.Win.Office2010ColorTable.ColorScheme = eColour2010
            Case Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007
                eColour2007 = EnumParseColourScheme2007(GetSetting("ADRIFT", "Generator", "ColourScheme", "Blue"))
                Infragistics.Win.Office2007ColorTable.ColorScheme = eColour2007
        End Select

        CType(UTMMain.Tools("AutoComplete"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = SafeBool(GetSetting("ADRIFT", "Generator", "Auto Complete", "-1"))
        RestoreLayout()
        UserSession.Map.LockMapCentre = SafeBool(GetSetting("ADRIFT", "Runner", "CentreMapLock", "0"))
        UserSession.Map.LockPlayerCentre = SafeBool(GetSetting("ADRIFT", "Runner", "MapPlayerLock", "0"))
        AddPrevious()
        UserSession.LoadMacros()
        FullScreen(CBool(GetSetting("ADRIFT", "Runner", "FullScreen", "0")))
        GetFormPosition(Me, UTMMain, UDMRunner)
        fRunner.Visible = True
        UserSession.RunnerStartup()
    End Sub

    Private Sub frmRunner_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        With UserSession
            .bQuitting = True
            If .Quit() Then
                SaveFormPosition(Me)
                SaveLayout()
                TidyUp()
            Else
                e.Cancel = True
                .bQuitting = False
            End If
        End With
    End Sub

    Friend Sub txtOutput_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutput.GotFocus
        txtInput.Focus()
    End Sub

    Private bIgnore As Boolean = False
    Private Sub txtInput_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInput.KeyPress

        If bIgnore Then
            bIgnore = False
            Exit Sub ' Avoid an oddity where KeyPress is firing as well as KeyDown.Enter
        End If

        If bWaitKey AndAlso Not btnMore.Visible Then
            Adventure.sReferencedText(0) = e.KeyChar
            e.Handled = True
            bWaitKey = False
            Exit Sub
        End If

        If btnMore.Visible Then
            btnMore_Click(Nothing, Nothing)
            e.Handled = True
            Exit Sub
        End If

        Select Case e.KeyChar
            Case " "c, "'"c ' keys when pressed skip the auto-complete highlighted word
                If txtInput.SelectionLength > 0 Then txtInput.SelectionStart = txtInput.Text.Length
        End Select

    End Sub


    Private Sub txtInput_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInput.SelectionChanged
        If txtInput.SelectionStart < 2 Then txtInput.SelectionStart = 2
    End Sub


    Private Sub txtInput_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInput.TextChanged
        UserSession.BuildAutos()
    End Sub






    'Private Function ExpandBlockOld(ByVal sBlock As String) As StringArrayList

    '    Dim sal As New StringArrayList

    '    sal.Add("")

    '    For i As Integer = 0 To sBlock.Length - 1

    '        Dim cNextChar As Char = sBlock.Substring(i, 1).ToCharArray()(0)

    '        Select Case cNextChar
    '            Case "["c, "{"c

    '                ' Get the whole block
    '                Dim cBracket As Char = sBlock.Substring(i).ToCharArray()(0)
    '                Dim iLevel As Integer = 1
    '                Dim sNewBlock As String = ""
    '                'Dim n As Integer = i + 1
    '                Dim bLastOptional As Boolean
    '                While iLevel > 0
    '                    i += 1
    '                    Dim cNewChar As Char = sBlock.Substring(i, 1).ToCharArray()(0)
    '                    bLastOptional = False
    '                    Select Case cNewChar
    '                        Case "["c, "{"c
    '                            iLevel += 1
    '                        Case "]"c, "}"c
    '                            iLevel -= 1
    '                            bLastOptional = (cNewChar = "}"c)
    '                        Case Else
    '                    End Select
    '                    If iLevel > 0 Then sNewBlock &= cNewChar
    '                    'n += 1
    '                End While
    '                'i += n - 1

    '                Dim sal2 As New StringArrayList
    '                'If InStr(sNewBlock, "[") > 0 OrElse InStr(sNewBlock, "{") > 0 Then                        
    '                '    For Each s As String In sal
    '                '        If bLastOptional Then sal2.Add(s)
    '                '        For Each sNew As String In ExpandBlock(sNewBlock)
    '                '            sal2.Add(s & sNew)
    '                '        Next
    '                '    Next
    '                'Else
    '                '    For Each s As String In sal
    '                '        For Each sNew As String In sNewBlock.Split("/"c)
    '                '            If bLastOptional Then sal2.Add(s)
    '                '            sal2.Add(s & sNew)
    '                '        Next
    '                '    Next
    '                'End If

    '                For Each s As String In sal
    '                    For Each sNew As String In sNewBlock.Split("/"c)
    '                        If bLastOptional Then sal2.Add(s)
    '                        If InStr(sNew, "[") > 0 OrElse InStr(sNew, "{") > 0 Then
    '                            For Each sNew2 As String In ExpandBlock(sNew)
    '                                sal2.Add(s & sNew2)
    '                            Next
    '                        Else
    '                            sal2.Add(s & sNew)
    '                        End If
    '                    Next
    '                Next

    '                sal = sal2

    '            Case Else
    '                For ix As Integer = 0 To sal.Count - 1
    '                    sal(ix) = sal(ix) & cNextChar
    '                Next
    '        End Select
    '    Next

    '    Return sal

    'End Function

    Friend Function CurrentIFID() As String

        If Adventure IsNot Nothing AndAlso Adventure.BabelTreatyInfo IsNot Nothing AndAlso Adventure.BabelTreatyInfo.Stories.Length = 1 Then
            Return "-" & Adventure.BabelTreatyInfo.Stories(0).Identification.IFID
        End If
        Return ""

    End Function

    Friend Sub SaveLayout()
        Try
            'If Not IO.Directory.Exists(sLocalDataPath) Then IO.Directory.CreateDirectory(sLocalDataPath)

            UDMRunner.SaveAsXML(DataPath(True) & "RunnerLayout" & CurrentIFID() & ".xml")
        Catch
        End Try
    End Sub

    Friend Sub RestoreLayout(Optional ByVal cpNew As Infragistics.Win.UltraWinDock.DockableControlPane = Nothing)

        Dim sXMLFile As String = DataPath(True) & "RunnerLayout" & CurrentIFID() & ".xml"

        Try

            If Not IO.File.Exists(sXMLFile) Then sXMLFile = DataPath(True) & "RunnerLayout.xml"
            If IO.File.Exists(sXMLFile) Then UDMRunner.LoadFromXML(sXMLFile)

            ' Restore the sizemode from our secret embedding in the layout
            RestoreDataFromLayoutXML()
            'If pbxGraphics.Parent IsNot Nothing AndAlso CType(pbxGraphics.Parent, Infragistics.Win.UltraWinDock.DockableWindow).Pane.OriginalControlBounds.Location.X = 1 Then
            '    pbxGraphics.SizeMode = CType(CType(pbxGraphics.Parent, Infragistics.Win.UltraWinDock.DockableWindow).Pane.OriginalControlBounds.Location.Y, clsImage.SizeModeEnum)
            'End If

            Dim bFoundNew As Boolean = False
            For Each cp As Infragistics.Win.UltraWinDock.DockableControlPane In UDMRunner.ControlPanes
                If cp.Closed Then
                    If cp.Text = "Map" AndAlso Not cp.IsVisible Then
                        UTMMain.Tools("ShowMap").SharedProps.Enabled = True
                    End If
                    If cp.Text = "Graphics" AndAlso Not cp.IsVisible Then
                        UTMMain.Tools("ShowGraphics").SharedProps.Enabled = True
                    End If
                End If
                If cpNew IsNot Nothing AndAlso cp.Key = cpNew.Key Then bFoundNew = True
            Next

            ' If the new control isn't in a stored layout, re-add it to the restored layout
            Try
                If Not bFoundNew AndAlso cpNew IsNot Nothing Then
                    fRunner.UDMRunner.ControlPanes.Add(cpNew)
                    cpNew.Parent.Panes.RemoveAt(cpNew.Index)
                    fRunner.UDMRunner.DockAreas(0).Panes.Add(cpNew)
                End If
            Catch
            End Try

            SetMargins()
        Catch ex As Exception
            If MessageBox.Show("There was an error restoring the window layout.  Would you like me to delete the layout file?  This will mean the next time you start up Runner it should display the default layout.  Runner will end after the file is deleted.", "Error restoring layout", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                Try
                    If IO.File.Exists(sXMLFile) Then IO.File.Delete(sXMLFile)
                    End
                Catch ex2 As Exception
                    ErrMsg("Could not delete file", ex2)
                End Try
            End If
            'ErrMsg("Error restoring layout", ex)
        End Try
    End Sub


    Private Sub UDMRunner_AfterDockChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.PaneEventArgs) Handles UDMRunner.AfterDockChange, UDMRunner.AfterToggleDockState
        If UserSession.Map.ParentForm.Name = Me.Name Then
            SetMapButtons(True)
            UserSession.Map.ToolStrip1.Visible = False
        Else
            SetMapButtons(False)
            UserSession.Map.ToolStrip1.Visible = True
        End If
    End Sub

    Private Sub SetMapButtons(ByVal bVisible As Boolean)

        UTMMain.Tools("MapZoomIn").SharedProps.Visible = bVisible
        UTMMain.Tools("MapZoomOut").SharedProps.Visible = bVisible

    End Sub

    Private Sub UDMRunner_AfterPaneButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.PaneButtonEventArgs) Handles UDMRunner.AfterPaneButtonClick
        If e.Button = Infragistics.Win.UltraWinDock.PaneButton.Close Then
            If Not UserSession.Map.Visible Then SetMapButtons(False)
        End If
    End Sub


    Private Sub UDMRunner_AfterSplitterDrag(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.PanesEventArgs) Handles UDMRunner.AfterSplitterDrag
        SetMargins()
    End Sub


    Private Sub UDMRunner_PaneHidden(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.PaneHiddenEventArgs) Handles UDMRunner.PaneHidden

        If e.Pane.Closed Then
            If e.Pane.Text = "Graphics" Then
                UTMMain.Tools("ShowGraphics").SharedProps.Enabled = True
            ElseIf e.Pane.Text = "Map" Then
                UTMMain.Tools("ShowMap").SharedProps.Enabled = True
                SetMapButtons(False)
            End If
        End If
        SetMargins()

    End Sub


    Dim bSettingSize As Boolean = False
    Private Sub frmRunner_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        SetMargins()

        If Not bSettingSize Then SaveDataInLayoutXML(RunnerWindowSize:=Me.Size, RunnerWindowState:=Me.WindowState)
    End Sub



    Private Sub SaveDataInLayoutXML(Optional ByVal RunnerWindowSize As Size = Nothing,
                                    Optional ByVal RunnerWindowState As FormWindowState = CType(-1, FormWindowState),
                                    Optional ByVal PictureSizeMode As clsImage.SizeModeEnum = CType(-1, clsImage.SizeModeEnum))

        Try
            If pbxGraphics IsNot Nothing AndAlso pbxGraphics.Parent IsNot Nothing AndAlso CType(pbxGraphics.Parent, Infragistics.Win.UltraWinDock.DockableWindow).Pane IsNot Nothing Then

                Dim r As Rectangle = CType(pbxGraphics.Parent, Infragistics.Win.UltraWinDock.DockableWindow).Pane.OriginalControlBounds

                Dim iNewSizeMode As Integer = r.Y
                If PictureSizeMode > -1 Then iNewSizeMode = CInt(PictureSizeMode)

                Dim iNewWindowState As Integer = r.Height - r.Height Mod 10000
                If RunnerWindowState > -1 Then iNewWindowState = CInt(RunnerWindowState + 1) * 10000

                Dim iNewWindowHeight As Integer = r.Height Mod 10000
                If RunnerWindowSize.Height > 0 Then iNewWindowHeight = RunnerWindowSize.Height

                Dim iNewWindowWidth As Integer = r.Width Mod 10000
                If RunnerWindowSize.Width > 0 Then iNewWindowWidth = RunnerWindowSize.Width

                ' X is always 1, to denote our encoding
                CType(pbxGraphics.Parent, Infragistics.Win.UltraWinDock.DockableWindow).Pane.OriginalControlBounds = New Rectangle(1, iNewSizeMode, iNewWindowWidth, iNewWindowState + iNewWindowHeight)
            End If

        Catch ex As Exception
            ErrMsg("Error saving layout", ex)
        End Try

    End Sub


    Private Sub RestoreDataFromLayoutXML()

        If pbxGraphics IsNot Nothing AndAlso pbxGraphics.Parent IsNot Nothing Then
            Dim r As Rectangle = CType(pbxGraphics.Parent, Infragistics.Win.UltraWinDock.DockableWindow).Pane.OriginalControlBounds

            If r.Location.X = 1 Then

                Dim iNewSizeMode As Integer = r.Y
                If iNewSizeMode > -1 AndAlso iNewSizeMode < 3 Then pbxGraphics.SizeMode = CType(iNewSizeMode, clsImage.SizeModeEnum)

                bSettingSize = True

                Dim iNewWindowState As Integer = r.Height - r.Height Mod 10000
                If iNewWindowState > 9999 Then Me.WindowState = CType(CInt(iNewWindowState / 10000 - 1), FormWindowState)

                Dim iNewWindowHeight As Integer = r.Height Mod 10000
                If iNewWindowHeight > 0 Then Me.Height = iNewWindowHeight

                Dim iNewWindowWidth As Integer = r.Width Mod 10000
                If iNewWindowWidth > 0 Then Me.Width = iNewWindowWidth

                bSettingSize = False
            End If
        End If

    End Sub


    Private WithEvents tmrSplash As New Timer

    Private Sub frmRunner_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        tmrSplash.Interval = 3000
        tmrSplash.Start()

        Try
            If Environment.GetCommandLineArgs.Length > 1 Then
                Dim sExecutable As String = ""
                For i As Integer = 1 To Environment.GetCommandLineArgs.Length - 1
                    If sExecutable <> "" Then sExecutable &= " "
                    sExecutable &= Environment.GetCommandLineArgs(i)
                Next
                If IO.File.Exists(sExecutable) Then
                    If UserSession.OpenAdventure(sExecutable) Then Exit Sub
                End If
            Else
                '' Work out whether we have a TAF appended on the end.  If so, run that in Executable mode
                '' Grab out the last 8 bytes, and see if it converts to a size
                'Dim bData(5) As Byte
                'Dim fStream As New IO.FileStream(Application.ExecutablePath, IO.FileMode.Open, IO.FileAccess.Read)
                'fStream.Seek(fStream.Length - 6, IO.SeekOrigin.Begin)
                'fStream.Read(bData, 0, 6)
                'fStream.Close()

                'Dim sFileSize As String = (New System.Text.ASCIIEncoding).GetString(bData).ToUpper
                'If IsHex(sFileSize) Then
                If UserSession.bEXE AndAlso UserSession.OpenAdventure(Application.ExecutablePath, True) Then Exit Sub
                'End If
            End If

            UserSession.Display("ADRIFT Runner Version 5.0<br><>© Campbell Wild 1998-2019<br>Last build: 6th June 2016 (Release " & CInt(Double.Parse(Application.ProductVersion.Replace("5.0.", ""), Globalization.CultureInfo.InvariantCulture.NumberFormat)).ToString("0") & ")", True) '©

        Catch ex As Exception
            ErrMsg("Startup Error", ex)
        End Try

    End Sub


    Private Sub tmrSplash_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrSplash.Tick
        tmrSplash.Stop()
        If fSplash IsNot Nothing Then fSplash.Close()
    End Sub


    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = 953 Then RepeatMMLoops() ' Notification that sound finished
        MyBase.WndProc(m)
    End Sub

    Private Sub UDMRunner_PaneDisplayed(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.PaneDisplayedEventArgs) Handles UDMRunner.PaneDisplayed
        Select Case True
            Case e.Pane.Control Is UserSession.Map
                SetMapButtons(True)
        End Select
    End Sub


    Friend Sub txtOutput_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtOutput.MouseDown
        OutputClicked(txtInput, CType(sender, RichTextBox), ctxMenu, MousePosition, btnSubmit, e)
    End Sub



    Private Sub txtOutput_VScroll(sender As Object, e As System.EventArgs) Handles txtOutput.VScroll
        '    ' Work out whether our previous offset is now off screen
        '    If txtOutput.GetCharIndexFromPosition(New Point(0, 0)) > iPreviousOffset Then
        '        ' Ok, we need to change the scroll position            
        '        txtOutput.SelectionStart = iPreviousOffset
        '        txtOutput.ScrollToCaret()
        '    End If
        ' If we have scrolled the screen right to the bottom, get rid of the button
        If btnMore.Visible Then
            If txtOutput.GetCharIndexFromPosition(New Point(txtOutput.Width, txtOutput.Height)) >= txtOutput.TextLength - 1 Then
                btnMore.Visible = False
            End If
        End If

    End Sub

    Private Sub btnMore_Click(sender As Object, e As System.EventArgs) Handles btnMore.Click
        With txtOutput
            btnMore.Visible = False
            UserSession.iPreviousOffset = .GetCharIndexFromPosition(New Point(.Width, .Height))
            ScrollToEnd(txtOutput)
        End With
    End Sub


    Private Sub pnlBottom_Resize(sender As Object, e As System.EventArgs) Handles pnlBottom.Resize
        If btnMore.Visible Then
            btnMore.Size = New Size(pnlBottom.Size.Width - 1, pnlBottom.Size.Height - 1)
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        btnSubmit.Enabled = False
        SubmitCommand()
        btnSubmit.Visible = False
        btnSubmit.Enabled = True
    End Sub


    Private Sub ctxMenu_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ctxMenu.ItemClicked
        If e.ClickedItem.Text.StartsWith("Type """) Then
            txtInput.SelectedText = e.ClickedItem.Text.Substring(6, e.ClickedItem.Text.Length - 7) & " "
            btnSubmit.Visible = True
        Else
            txtInput.Text = "XX" & e.ClickedItem.Text
            SubmitCommand()
        End If
    End Sub


    Private Sub txtInput_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtInput.MouseWheel
        If e.Delta <> 0 Then SendMessage(txtOutput.Handle, EM_LINESCROLL, 0, -CInt(e.Delta / 40))
    End Sub


    Private Sub txtOutput_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtOutput.MouseMove

        txtOutput.SuspendLayout()

        Dim iCharPos As Integer = txtOutput.GetCharIndexFromPosition(New Point(e.X, e.Y))

        If iCharPos > -1 Then 'AndAlso e.X < txtOutput.GetPositionFromCharIndex(txtOutput.Text.Length).X Then
            txtOutput.Cursor = Cursors.Arrow
            txtOutput.SelectionStart = iCharPos
            If txtOutput.SelectionFont.Underline AndAlso txtOutput.SelectionColor = GetLinkColour() Then
                txtOutput.Cursor = Cursors.Hand
                'Else
                '   txtOutput.Cursor = Cursors.Arrow
            End If
        Else
            txtOutput.Cursor = Cursors.Arrow
        End If

        txtOutput.ResumeLayout()

    End Sub




    Private Sub pbxGraphics_SizeModeChanged(o As clsImage, e As clsImage.ImageEventArgs) Handles pbxGraphics.SizeModeChanged
        ' Store the SizeMode in the OriginalControlBounds, so it gets stored in the Infragistics XML
        'CType(pbxGraphics.Parent, Infragistics.Win.UltraWinDock.DockableWindow).Pane.OriginalControlBounds = New Rectangle(1, CInt(e.SizeMode), 1, 1)
        'CType(pbxGraphics.Parent, Infragistics.Win.UltraWinDock.DockableWindow).Pane.Key=
        SaveDataInLayoutXML(PictureSizeMode:=e.SizeMode)
    End Sub

End Class


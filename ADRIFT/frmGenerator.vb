Public Class frmGenerator
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        fSplash = New Splash
        fSplash.Show(Me)
        Application.DoEvents()

        Dim sIde As String = "ide"

        Dim sDLL As String = GetWinSysDir() & sIde & "sync" & "." & Chr(&H64) & "ll"
        If IO.File.Exists(sDLL) OrElse IO.File.Exists(sDLL.ToLower.Replace("system32", "syswow64")) Then PartOne = True

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents _frmGenerator_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmGenerator_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmGenerator_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmGenerator_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents StatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents UTMMain As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    'Friend WithEvents UltraTabbedMdiManager1 As Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager
    Friend WithEvents FolderList1 As ADRIFT.FolderList
    Friend WithEvents _frmGeneratorAutoHideControl As Infragistics.Win.UltraWinDock.AutoHideControl
    Friend WithEvents UDMGenerator As Infragistics.Win.UltraWinDock.UltraDockManager
    Friend WithEvents WindowDockingArea1 As Infragistics.Win.UltraWinDock.WindowDockingArea
    Friend WithEvents DockableWindow1 As Infragistics.Win.UltraWinDock.DockableWindow
    Friend WithEvents _frmGeneratorUnpinnedTabAreaBottom As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents _frmGeneratorUnpinnedTabAreaTop As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents _frmGeneratorUnpinnedTabAreaRight As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents _frmGeneratorUnpinnedTabAreaLeft As Infragistics.Win.UltraWinDock.UnpinnedTabArea
    Friend WithEvents Map1 As ADRIFT.Map
    Friend WithEvents DockableWindow2 As Infragistics.Win.UltraWinDock.DockableWindow
    Friend WithEvents WindowDockingArea3 As Infragistics.Win.UltraWinDock.WindowDockingArea
    Friend WithEvents WindowDockingArea4 As Infragistics.Win.UltraWinDock.WindowDockingArea
    Friend WithEvents fbd As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents cmsMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miAddFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sfd As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim UltraStatusPanel2 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim UltraStatusPanel3 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim UltraStatusPanel4 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim UltraStatusPanel5 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim ButtonTool59 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Exit")
        Dim ButtonTool36 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuNew")
        Dim ButtonTool37 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuOpen")
        Dim ButtonTool38 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuSave")
        Dim ButtonTool39 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuSaveAs")
        Dim PopupMenuTool1 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("Import")
        Dim PopupMenuTool2 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("Export")
        Dim ButtonTool50 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ProtectAdventure")
        Dim ButtonTool157 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("IntroductionWinning")
        Dim ButtonTool40 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Settings")
        Dim ButtonTool155 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Properties")
        Dim LabelTool1 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("Recent Documents")
        Dim ContextualTabGroup1 As Infragistics.Win.UltraWinToolbars.ContextualTabGroup = New Infragistics.Win.UltraWinToolbars.ContextualTabGroup("ctgMapTools")
        Dim RibbonTab1 As Infragistics.Win.UltraWinToolbars.RibbonTab = New Infragistics.Win.UltraWinToolbars.RibbonTab("Home")
        Dim RibbonGroup1 As Infragistics.Win.UltraWinToolbars.RibbonGroup = New Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup2")
        Dim ButtonTool42 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Cut")
        Dim ButtonTool43 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Copy")
        Dim ButtonTool44 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Paste")
        Dim ButtonTool45 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Delete")
        Dim RibbonGroup2 As Infragistics.Win.UltraWinToolbars.RibbonGroup = New Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup1")
        Dim ButtonTool25 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Location")
        Dim ButtonTool27 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Object")
        Dim ButtonTool28 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Task")
        Dim ButtonTool30 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Character")
        Dim ButtonTool29 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Event")
        Dim ButtonTool31 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Variable")
        Dim ButtonTool34 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Group")
        Dim ButtonTool33 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Property")
        Dim ButtonTool32 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Text Override")
        Dim ButtonTool35 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Hint")
        Dim ButtonTool172 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Synonym")
        Dim ButtonTool170 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("UserFunction")
        Dim RibbonGroup3 As Infragistics.Win.UltraWinToolbars.RibbonGroup = New Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup3")
        Dim ButtonTool46 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Find")
        Dim ButtonTool47 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("FindNext")
        Dim ButtonTool48 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Replace")
        Dim RibbonGroup4 As Infragistics.Win.UltraWinToolbars.RibbonGroup = New Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup4")
        Dim ButtonTool49 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Options")
        Dim ButtonTool58 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("RunAdventure")
        Dim RibbonTab2 As Infragistics.Win.UltraWinToolbars.RibbonTab = New Infragistics.Win.UltraWinToolbars.RibbonTab("View")
        Dim RibbonGroup5 As Infragistics.Win.UltraWinToolbars.RibbonGroup = New Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup1")
        Dim ButtonTool61 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("FolderList")
        Dim ButtonTool65 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Map")
        Dim ButtonTool52 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Cascade")
        Dim ButtonTool53 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("TileHorizontally")
        Dim ButtonTool54 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("TileVertically")
        Dim ButtonTool147 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Tile")
        Dim ButtonTool55 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("CloseAllWindows")
        Dim RibbonTab3 As Infragistics.Win.UltraWinToolbars.RibbonTab = New Infragistics.Win.UltraWinToolbars.RibbonTab("Map")
        Dim RibbonGroup6 As Infragistics.Win.UltraWinToolbars.RibbonGroup = New Infragistics.Win.UltraWinToolbars.RibbonGroup("MapTools")
        Dim ButtonTool64 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("NewPage")
        Dim ButtonTool67 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapLocation")
        Dim ButtonTool68 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapPlan")
        Dim ButtonTool69 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapCentre")
        Dim ButtonTool70 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapZoomIn")
        Dim ButtonTool71 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapZoomOut")
        Dim StateButtonTool3 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("ShowGridLines", "")
        Dim StateButtonTool1 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("Show Axes", "")
        Dim ButtonTool165 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Print")
        Dim ButtonTool57 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuSave")
        Dim ButtonTool158 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("RunAdventure")
        Dim ButtonTool149 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapWarning")
        Dim ButtonTool56 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Register")
        Dim ButtonTool51 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("AboutGenerator")
        Dim ButtonTool167 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Help")
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("Tools")
        Dim ButtonTool73 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuNew")
        Dim ButtonTool74 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuOpen")
        Dim ButtonTool75 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuSave")
        Dim ButtonTool76 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Cut")
        Dim ButtonTool77 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Copy")
        Dim ButtonTool78 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Paste")
        Dim ButtonTool79 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Location")
        Dim ButtonTool80 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Object")
        Dim ButtonTool81 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Task")
        Dim ButtonTool82 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Event")
        Dim ButtonTool83 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Character")
        Dim ButtonTool84 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Variable")
        Dim ButtonTool85 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Group")
        Dim ButtonTool86 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Text Override")
        Dim ButtonTool87 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Hint")
        Dim ButtonTool88 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Property")
        Dim ButtonTool89 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("RunAdventure")
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Find")
        Dim UltraToolbar2 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenuBar")
        Dim PopupMenuTool21 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuFile")
        Dim PopupMenuTool22 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuEdit")
        Dim PopupMenuTool23 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuView")
        Dim PopupMenuTool24 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuAdventure")
        Dim PopupMenuTool25 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuWindow")
        Dim PopupMenuTool26 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuHelp")
        Dim PopupMenuTool27 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuFile")
        Dim ButtonTool90 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuNew")
        Dim ButtonTool91 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuOpen")
        Dim ButtonTool92 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuSave")
        Dim ButtonTool93 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuSaveAs")
        Dim PopupMenuTool28 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("Import")
        Dim PopupMenuTool29 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("Export")
        Dim PopupMenuTool30 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuRecentAdventures")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Settings")
        Dim ButtonTool94 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Exit")
        Dim ButtonTool95 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuNew")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool96 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuOpen")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim PopupMenuTool31 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuEdit")
        Dim ButtonTool97 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Cut")
        Dim ButtonTool98 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Copy")
        Dim ButtonTool99 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Paste")
        Dim ButtonTool100 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Delete")
        Dim ButtonTool21 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Find")
        Dim ButtonTool22 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("FindNext")
        Dim ButtonTool20 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Replace")
        Dim PopupMenuTool32 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuView")
        Dim ButtonTool102 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuCreateNewList")
        Dim ButtonTool103 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuDeleteList")
        Dim ButtonTool104 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuRenameList")
        Dim ButtonTool105 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuCreateNewList")
        Dim ButtonTool106 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuRenameList")
        Dim ButtonTool107 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuDeleteList")
        Dim PopupMenuTool33 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuAdventure")
        Dim PopupMenuTool34 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("Add New")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("IntroductionWinning")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Options")
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("RunAdventure")
        Dim PopupMenuTool35 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuWindow")
        Dim ButtonTool10 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Cascade")
        Dim ButtonTool11 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("CloseAllWindows")
        Dim ButtonTool12 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("TileHorizontally")
        Dim ButtonTool13 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("TileVertically")
        Dim MdiWindowListTool3 As Infragistics.Win.UltraWinToolbars.MdiWindowListTool = New Infragistics.Win.UltraWinToolbars.MdiWindowListTool("MDIWindowListTool1")
        Dim PopupMenuTool36 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuHelp")
        Dim ButtonTool109 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("AboutGenerator")
        Dim MdiWindowListTool4 As Infragistics.Win.UltraWinToolbars.MdiWindowListTool = New Infragistics.Win.UltraWinToolbars.MdiWindowListTool("MDIWindowListTool1")
        Dim ButtonTool110 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuSave")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool111 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Cut")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool112 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Copy")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool113 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Paste")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool114 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Delete")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool115 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Find")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool116 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Location")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool117 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Object")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool118 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Task")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool119 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Event")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool120 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Character")
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool121 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Variable")
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim PopupMenuTool37 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("Add New")
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool122 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Location")
        Dim ButtonTool123 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Object")
        Dim ButtonTool124 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Task")
        Dim ButtonTool125 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Event")
        Dim ButtonTool126 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Character")
        Dim ButtonTool127 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Variable")
        Dim ButtonTool128 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Group")
        Dim ButtonTool129 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Text Override")
        Dim ButtonTool130 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Hint")
        Dim ButtonTool131 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Property")
        Dim ButtonTool132 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("mnuSaveAs")
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim PopupMenuTool38 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuRecentAdventures")
        Dim StateButtonTool4 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("Tab Windows", "")
        Dim ButtonTool133 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Group")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool134 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Text Override")
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool135 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Hint")
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool136 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ImportModule")
        Dim ButtonTool137 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ExportModule")
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim PopupMenuTool39 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("Import")
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool138 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ImportModule")
        Dim ButtonTool153 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ImportBlorb")
        Dim ButtonTool162 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ImportTrizbort")
        Dim ButtonTool159 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("LanguageResource")
        Dim PopupMenuTool40 As Infragistics.Win.UltraWinToolbars.PopupMenuTool = New Infragistics.Win.UltraWinToolbars.PopupMenuTool("Export")
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool139 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ExportModule")
        Dim ButtonTool9 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("iFictionRecord")
        Dim ButtonTool26 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("CreateExecutable")
        Dim ButtonTool151 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ExportBlorb")
        Dim ButtonTool168 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ExportLanguageResource")
        Dim ButtonTool140 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Settings")
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool141 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Property")
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool142 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("AboutGenerator")
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool143 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("RunAdventure")
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool144 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Exit")
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("IntroductionWinning")
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Options")
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("iFictionRecord")
        Dim ButtonTool14 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ArrangeIcons")
        Dim ButtonTool15 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Cascade")
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool16 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("CloseAllWindows")
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool17 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("TileHorizontally")
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool18 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("TileVertically")
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool19 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Replace")
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool23 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("FindNext")
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool24 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("CreateExecutable")
        Dim LabelTool2 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("Recent Documents")
        Dim ButtonTool60 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ProtectAdventure")
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool62 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("FolderList")
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool63 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Register")
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool66 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Map")
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool72 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapLocation")
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool101 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapPlan")
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool108 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapCentre")
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool145 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapZoomIn")
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool146 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapZoomOut")
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool148 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("MapWarning")
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim StateButtonTool2 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("Show Axes", "")
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim StateButtonTool5 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("ShowGridLines", "")
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool150 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Tile")
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool152 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ExportBlorb")
        Dim ButtonTool154 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ImportBlorb")
        Dim ButtonTool156 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Properties")
        Dim ButtonTool41 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("NewPage")
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool160 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ImportTrizbort")
        Dim ButtonTool161 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("LanguageResource")
        Dim ButtonTool163 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Print")
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool164 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("PrintPreview")
        Dim ButtonTool166 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ExportLanguageResource")
        Dim ButtonTool169 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Help")
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool171 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("UserFunction")
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool173 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Synonym")
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DockAreaPane1 As Infragistics.Win.UltraWinDock.DockAreaPane = New Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, New System.Guid("c3e7f400-f214-486a-bfea-b1991baa81b0"))
        Dim DockableControlPane1 As Infragistics.Win.UltraWinDock.DockableControlPane = New Infragistics.Win.UltraWinDock.DockableControlPane(New System.Guid("3a96af15-ca01-4fb2-b71d-e418e2057ad0"), New System.Guid("00000000-0000-0000-0000-000000000000"), -1, New System.Guid("c3e7f400-f214-486a-bfea-b1991baa81b0"), -1)
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DockAreaPane2 As Infragistics.Win.UltraWinDock.DockAreaPane = New Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, New System.Guid("02625fb5-30ea-419f-a5ee-f435e59086b2"))
        Dim DockAreaPane3 As Infragistics.Win.UltraWinDock.DockAreaPane = New Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, New System.Guid("da8e20b7-4eff-497d-ac07-a6389585feb4"))
        Dim DockableControlPane2 As Infragistics.Win.UltraWinDock.DockableControlPane = New Infragistics.Win.UltraWinDock.DockableControlPane(New System.Guid("b6db8285-030c-4edd-89ef-aaaf5b21d655"), New System.Guid("02625fb5-30ea-419f-a5ee-f435e59086b2"), 0, New System.Guid("da8e20b7-4eff-497d-ac07-a6389585feb4"), 0)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenerator))
        Me.FolderList1 = New ADRIFT.FolderList()
        Me.Map1 = New ADRIFT.Map()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.StatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.sfd = New System.Windows.Forms.SaveFileDialog()
        Me._frmGenerator_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UTMMain = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._frmGenerator_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._frmGenerator_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._frmGenerator_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UDMGenerator = New Infragistics.Win.UltraWinDock.UltraDockManager(Me.components)
        Me._frmGeneratorUnpinnedTabAreaLeft = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me._frmGeneratorUnpinnedTabAreaRight = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me._frmGeneratorUnpinnedTabAreaTop = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me._frmGeneratorUnpinnedTabAreaBottom = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me._frmGeneratorAutoHideControl = New Infragistics.Win.UltraWinDock.AutoHideControl()
        Me.WindowDockingArea1 = New Infragistics.Win.UltraWinDock.WindowDockingArea()
        Me.DockableWindow1 = New Infragistics.Win.UltraWinDock.DockableWindow()
        Me.DockableWindow2 = New Infragistics.Win.UltraWinDock.DockableWindow()
        Me.WindowDockingArea3 = New Infragistics.Win.UltraWinDock.WindowDockingArea()
        Me.WindowDockingArea4 = New Infragistics.Win.UltraWinDock.WindowDockingArea()
        Me.fbd = New System.Windows.Forms.FolderBrowserDialog()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.cmsMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAddFolder = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UTMMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDMGenerator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WindowDockingArea1.SuspendLayout()
        Me.DockableWindow1.SuspendLayout()
        Me.DockableWindow2.SuspendLayout()
        Me.WindowDockingArea4.SuspendLayout()
        Me.cmsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'FolderList1
        '
        Me.FolderList1.Location = New System.Drawing.Point(0, 20)
        Me.FolderList1.Name = "FolderList1"
        Me.FolderList1.Size = New System.Drawing.Size(194, 460)
        Me.StatusBar1.SetStatusBarText(Me.FolderList1, "Double-click a folder to open a new window, or single click to load in the active" & _
        " window")
        Me.FolderList1.TabIndex = 12
        '
        'Map1
        '
        Me.Map1.Location = New System.Drawing.Point(0, 20)
        Me.Map1.Map = Nothing
        Me.Map1.Name = "Map1"
        Me.Map1.ShowAxes = True
        Me.Map1.ShowGrid = True
        Me.Map1.Size = New System.Drawing.Size(714, 217)
        Me.Map1.TabIndex = 35
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 644)
        Me.StatusBar1.Name = "StatusBar1"
        UltraStatusPanel1.MinWidth = 150
        UltraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        UltraStatusPanel1.Text = "File version:"
        UltraStatusPanel2.MinWidth = 150
        UltraStatusPanel2.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        UltraStatusPanel2.Text = "File size:"
        UltraStatusPanel3.MinWidth = 150
        UltraStatusPanel3.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        UltraStatusPanel3.Text = "Maximum score:"
        UltraStatusPanel4.MinWidth = 150
        UltraStatusPanel4.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        UltraStatusPanel4.Text = "Simple Mode On"
        UltraStatusPanel5.KeyStateInfo.Key = Infragistics.Win.UltraWinStatusBar.KeyState.CapsLock
        UltraStatusPanel5.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.KeyState
        Me.StatusBar1.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel1, UltraStatusPanel2, UltraStatusPanel3, UltraStatusPanel4, UltraStatusPanel5})
        Me.StatusBar1.Size = New System.Drawing.Size(929, 24)
        Me.StatusBar1.TabIndex = 5
        Me.StatusBar1.Text = "UltraStatusBar1"
        '
        '_frmGenerator_Toolbars_Dock_Area_Left
        '
        Me._frmGenerator_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmGenerator_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._frmGenerator_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._frmGenerator_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmGenerator_Toolbars_Dock_Area_Left.InitialResizeAreaExtent = 8
        Me._frmGenerator_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 164)
        Me._frmGenerator_Toolbars_Dock_Area_Left.Name = "_frmGenerator_Toolbars_Dock_Area_Left"
        Me._frmGenerator_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(8, 480)
        Me._frmGenerator_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UTMMain
        '
        'UTMMain
        '
        Me.UTMMain.DesignerFlags = 1
        Me.UTMMain.DockWithinContainer = Me
        Me.UTMMain.DockWithinContainerBaseType = GetType(System.Windows.Forms.Form)
        Me.UTMMain.Ribbon.ApplicationMenu.FooterToolbar.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool59})
        PopupMenuTool1.InstanceProps.IsFirstInGroup = True
        ButtonTool50.InstanceProps.IsFirstInGroup = True
        ButtonTool157.InstanceProps.IsFirstInGroup = True
        ButtonTool157.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        Me.UTMMain.Ribbon.ApplicationMenu.ToolAreaLeft.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool36, ButtonTool37, ButtonTool38, ButtonTool39, PopupMenuTool1, PopupMenuTool2, ButtonTool50, ButtonTool157, ButtonTool40, ButtonTool155})
        Me.UTMMain.Ribbon.ApplicationMenu.ToolAreaRight.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {LabelTool1})
        Me.UTMMain.Ribbon.ApplicationMenu.ToolAreaRight.Settings.LabelDisplayStyle = Infragistics.Win.UltraWinToolbars.LabelMenuDisplayStyle.Header
        Me.UTMMain.Ribbon.ApplicationMenu.ToolAreaRight.Settings.UseLargeImages = Infragistics.Win.DefaultableBoolean.[False]
        Me.UTMMain.Ribbon.ApplicationMenuButtonImage = Global.ADRIFT.My.Resources.imgDeveloper24
        ContextualTabGroup1.Caption = "Map Tools"
        ContextualTabGroup1.Key = "ctgMapTools"
        ContextualTabGroup1.Visible = False
        Me.UTMMain.Ribbon.NonInheritedContextualTabGroups.AddRange(New Infragistics.Win.UltraWinToolbars.ContextualTabGroup() {ContextualTabGroup1})
        RibbonTab1.Caption = "Home"
        RibbonGroup1.Caption = "Clipboard"
        ButtonTool45.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        RibbonGroup1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool42, ButtonTool43, ButtonTool44, ButtonTool45})
        RibbonGroup2.Caption = "Add Items"
        ButtonTool25.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool27.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool28.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool30.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool29.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool31.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool34.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool33.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool32.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool35.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool172.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool170.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        RibbonGroup2.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool25, ButtonTool27, ButtonTool28, ButtonTool30, ButtonTool29, ButtonTool31, ButtonTool34, ButtonTool33, ButtonTool32, ButtonTool35, ButtonTool172, ButtonTool170})
        RibbonGroup3.Caption = "Search"
        RibbonGroup3.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool46, ButtonTool47, ButtonTool48})
        RibbonGroup4.Caption = "General"
        ButtonTool49.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool58.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        RibbonGroup4.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool49, ButtonTool58})
        RibbonTab1.Groups.AddRange(New Infragistics.Win.UltraWinToolbars.RibbonGroup() {RibbonGroup1, RibbonGroup2, RibbonGroup3, RibbonGroup4})
        RibbonTab2.Caption = "View"
        RibbonGroup5.Caption = "Window"
        ButtonTool61.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool65.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool52.InstanceProps.IsFirstInGroup = True
        RibbonGroup5.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool61, ButtonTool65, ButtonTool52, ButtonTool53, ButtonTool54, ButtonTool147, ButtonTool55})
        RibbonTab2.Groups.AddRange(New Infragistics.Win.UltraWinToolbars.RibbonGroup() {RibbonGroup5})
        RibbonTab3.Caption = "Map"
        RibbonTab3.ContextualTabGroupKey = "ctgMapTools"
        RibbonGroup6.Caption = "Map Tools"
        ButtonTool64.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool67.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool68.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool69.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool70.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool71.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        StateButtonTool3.InstanceProps.IsFirstInGroup = True
        StateButtonTool3.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        StateButtonTool1.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool165.InstanceProps.IsFirstInGroup = True
        ButtonTool165.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        RibbonGroup6.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool64, ButtonTool67, ButtonTool68, ButtonTool69, ButtonTool70, ButtonTool71, StateButtonTool3, StateButtonTool1, ButtonTool165})
        RibbonTab3.Groups.AddRange(New Infragistics.Win.UltraWinToolbars.RibbonGroup() {RibbonGroup6})
        Me.UTMMain.Ribbon.NonInheritedRibbonTabs.AddRange(New Infragistics.Win.UltraWinToolbars.RibbonTab() {RibbonTab1, RibbonTab2, RibbonTab3})
        Me.UTMMain.Ribbon.QuickAccessToolbar.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool57, ButtonTool158})
        Me.UTMMain.Ribbon.TabItemToolbar.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool149, ButtonTool56, ButtonTool51, ButtonTool167})
        Me.UTMMain.Ribbon.Visible = True
        Me.UTMMain.ShowFullMenusDelay = 500
        Me.UTMMain.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 1
        ButtonTool76.InstanceProps.IsFirstInGroup = True
        ButtonTool79.InstanceProps.IsFirstInGroup = True
        ButtonTool89.InstanceProps.IsFirstInGroup = True
        ButtonTool7.InstanceProps.IsFirstInGroup = True
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool73, ButtonTool74, ButtonTool75, ButtonTool76, ButtonTool77, ButtonTool78, ButtonTool79, ButtonTool80, ButtonTool81, ButtonTool82, ButtonTool83, ButtonTool84, ButtonTool85, ButtonTool86, ButtonTool87, ButtonTool88, ButtonTool89, ButtonTool7})
        UltraToolbar1.Text = "Default"
        UltraToolbar2.DockedColumn = 0
        UltraToolbar2.DockedRow = 0
        UltraToolbar2.FloatingLocation = New System.Drawing.Point(480, 362)
        UltraToolbar2.FloatingSize = New System.Drawing.Size(342, 22)
        UltraToolbar2.IsMainMenuBar = True
        UltraToolbar2.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {PopupMenuTool21, PopupMenuTool22, PopupMenuTool23, PopupMenuTool24, PopupMenuTool25, PopupMenuTool26})
        UltraToolbar2.Text = "MainMenuBar"
        Me.UTMMain.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1, UltraToolbar2})
        PopupMenuTool27.SharedPropsInternal.Caption = "&File"
        PopupMenuTool27.SharedPropsInternal.Category = "Imported"
        PopupMenuTool28.InstanceProps.IsFirstInGroup = True
        PopupMenuTool30.InstanceProps.IsFirstInGroup = True
        ButtonTool3.InstanceProps.IsFirstInGroup = True
        ButtonTool94.InstanceProps.IsFirstInGroup = True
        PopupMenuTool27.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool90, ButtonTool91, ButtonTool92, ButtonTool93, PopupMenuTool28, PopupMenuTool29, PopupMenuTool30, ButtonTool3, ButtonTool94})
        Appearance3.Image = Global.ADRIFT.My.Resources.imgNew32
        ButtonTool95.SharedPropsInternal.AppearancesLarge.Appearance = Appearance3
        Appearance4.Image = Global.ADRIFT.My.Resources.imgNew16
        ButtonTool95.SharedPropsInternal.AppearancesSmall.Appearance = Appearance4
        ButtonTool95.SharedPropsInternal.Caption = "&New"
        ButtonTool95.SharedPropsInternal.Category = "Imported"
        ButtonTool95.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        ButtonTool96.SharedPropsInternal.AppearancesLarge.Appearance = Appearance5
        Appearance6.Image = CType(resources.GetObject("Appearance6.Image"), Object)
        ButtonTool96.SharedPropsInternal.AppearancesSmall.Appearance = Appearance6
        ButtonTool96.SharedPropsInternal.Caption = "&Open"
        ButtonTool96.SharedPropsInternal.Category = "Imported"
        PopupMenuTool31.SharedPropsInternal.Caption = "&Edit"
        PopupMenuTool31.SharedPropsInternal.Category = "Imported"
        ButtonTool21.InstanceProps.IsFirstInGroup = True
        PopupMenuTool31.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool97, ButtonTool98, ButtonTool99, ButtonTool100, ButtonTool21, ButtonTool22, ButtonTool20})
        PopupMenuTool32.SharedPropsInternal.Caption = "&View"
        PopupMenuTool32.SharedPropsInternal.Category = "Imported"
        PopupMenuTool32.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool102, ButtonTool103, ButtonTool104})
        ButtonTool105.SharedPropsInternal.Caption = "Create &New List"
        ButtonTool105.SharedPropsInternal.Category = "Imported"
        ButtonTool106.SharedPropsInternal.Caption = "&Rename List"
        ButtonTool106.SharedPropsInternal.Category = "Imported"
        ButtonTool106.SharedPropsInternal.Spring = True
        ButtonTool107.SharedPropsInternal.Caption = "&Delete List"
        ButtonTool107.SharedPropsInternal.Category = "Imported"
        ButtonTool107.SharedPropsInternal.Spring = True
        PopupMenuTool33.SharedPropsInternal.Caption = "&Adventure"
        PopupMenuTool33.SharedPropsInternal.Category = "Imported"
        PopupMenuTool33.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {PopupMenuTool34, ButtonTool1, ButtonTool4, ButtonTool6})
        PopupMenuTool35.SharedPropsInternal.Caption = "&Window"
        PopupMenuTool35.SharedPropsInternal.Category = "Imported"
        MdiWindowListTool3.InstanceProps.IsFirstInGroup = False
        PopupMenuTool35.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool10, ButtonTool11, ButtonTool12, ButtonTool13, MdiWindowListTool3})
        PopupMenuTool36.SharedPropsInternal.Caption = "&Help"
        PopupMenuTool36.SharedPropsInternal.Category = "Imported"
        PopupMenuTool36.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool109})
        MdiWindowListTool4.DisplayArrangeIconsCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide
        MdiWindowListTool4.DisplayCascadeCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide
        MdiWindowListTool4.DisplayCloseWindowsCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide
        MdiWindowListTool4.DisplayTileHorizontalCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide
        MdiWindowListTool4.DisplayTileVerticalCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide
        MdiWindowListTool4.SharedPropsInternal.Caption = "MDIWindowListTool1"
        Appearance7.Image = CType(resources.GetObject("Appearance7.Image"), Object)
        ButtonTool110.SharedPropsInternal.AppearancesLarge.Appearance = Appearance7
        Appearance8.Image = Global.ADRIFT.My.Resources.imgSave16
        ButtonTool110.SharedPropsInternal.AppearancesSmall.Appearance = Appearance8
        ButtonTool110.SharedPropsInternal.Caption = "&Save"
        ButtonTool110.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Appearance9.Image = Global.ADRIFT.My.Resources.imgCut
        ButtonTool111.SharedPropsInternal.AppearancesSmall.Appearance = Appearance9
        ButtonTool111.SharedPropsInternal.Caption = "&Cut"
        ButtonTool111.SharedPropsInternal.Enabled = False
        ButtonTool111.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlX
        Appearance10.Image = Global.ADRIFT.My.Resources.imgCopy
        ButtonTool112.SharedPropsInternal.AppearancesSmall.Appearance = Appearance10
        ButtonTool112.SharedPropsInternal.Caption = "&Copy"
        ButtonTool112.SharedPropsInternal.Enabled = False
        ButtonTool112.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Appearance11.Image = Global.ADRIFT.My.Resources.imgPaste
        ButtonTool113.SharedPropsInternal.AppearancesSmall.Appearance = Appearance11
        ButtonTool113.SharedPropsInternal.Caption = "&Paste"
        ButtonTool113.SharedPropsInternal.Enabled = False
        ButtonTool113.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlV
        Appearance12.Image = CType(resources.GetObject("Appearance12.Image"), Object)
        ButtonTool114.SharedPropsInternal.AppearancesLarge.Appearance = Appearance12
        Appearance13.Image = Global.ADRIFT.My.Resources.imgDelete
        ButtonTool114.SharedPropsInternal.AppearancesSmall.Appearance = Appearance13
        ButtonTool114.SharedPropsInternal.Caption = "&Delete"
        ButtonTool114.SharedPropsInternal.Enabled = False
        Appearance14.Image = Global.ADRIFT.My.Resources.imgFind
        ButtonTool115.SharedPropsInternal.AppearancesSmall.Appearance = Appearance14
        ButtonTool115.SharedPropsInternal.Caption = "Find"
        ButtonTool115.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Appearance15.Image = Global.ADRIFT.My.Resources.imgLocation32
        ButtonTool116.SharedPropsInternal.AppearancesLarge.Appearance = Appearance15
        Appearance16.Image = Global.ADRIFT.My.Resources.imgLocation16
        ButtonTool116.SharedPropsInternal.AppearancesSmall.Appearance = Appearance16
        ButtonTool116.SharedPropsInternal.Caption = "Location"
        ButtonTool116.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlL
        ButtonTool116.SharedPropsInternal.ToolTipText = "Locations are the places characters can visit"
        ButtonTool116.SharedPropsInternal.ToolTipTitle = "Add Location"
        Appearance17.Image = Global.ADRIFT.My.Resources.imgObjectDynamic32
        ButtonTool117.SharedPropsInternal.AppearancesLarge.Appearance = Appearance17
        Appearance18.Image = CType(resources.GetObject("Appearance18.Image"), Object)
        ButtonTool117.SharedPropsInternal.AppearancesSmall.Appearance = Appearance18
        ButtonTool117.SharedPropsInternal.Caption = "Object"
        ButtonTool117.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        ButtonTool117.SharedPropsInternal.ToolTipText = "Objects are anything within a location that can be looked at or manipulated"
        ButtonTool117.SharedPropsInternal.ToolTipTitle = "Add Object"
        Appearance19.Image = Global.ADRIFT.My.Resources.imgTaskGeneral32
        ButtonTool118.SharedPropsInternal.AppearancesLarge.Appearance = Appearance19
        Appearance20.Image = CType(resources.GetObject("Appearance20.Image"), Object)
        ButtonTool118.SharedPropsInternal.AppearancesSmall.Appearance = Appearance20
        ButtonTool118.SharedPropsInternal.Caption = " Task "
        ButtonTool118.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlT
        ButtonTool118.SharedPropsInternal.ToolTipText = "Tasks allow you to create custom actions in your game"
        ButtonTool118.SharedPropsInternal.ToolTipTitle = "Add Task"
        Appearance21.Image = Global.ADRIFT.My.Resources.imgEvent32
        ButtonTool119.SharedPropsInternal.AppearancesLarge.Appearance = Appearance21
        Appearance22.Image = CType(resources.GetObject("Appearance22.Image"), Object)
        ButtonTool119.SharedPropsInternal.AppearancesSmall.Appearance = Appearance22
        ButtonTool119.SharedPropsInternal.Caption = "Event"
        ButtonTool119.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlE
        ButtonTool119.SharedPropsInternal.ToolTipText = "Events allow you to make things happen at particular times in your game"
        ButtonTool119.SharedPropsInternal.ToolTipTitle = "Add Event"
        Appearance23.Image = Global.ADRIFT.My.Resources.imgCharacter32
        ButtonTool120.SharedPropsInternal.AppearancesLarge.Appearance = Appearance23
        Appearance24.Image = Global.ADRIFT.My.Resources.imgCharacter16
        ButtonTool120.SharedPropsInternal.AppearancesSmall.Appearance = Appearance24
        ButtonTool120.SharedPropsInternal.Caption = "Character"
        ButtonTool120.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        ButtonTool120.SharedPropsInternal.ToolTipText = "Characters are people or animals you may encounter in your game"
        ButtonTool120.SharedPropsInternal.ToolTipTitle = "Add Character"
        Appearance25.Image = Global.ADRIFT.My.Resources.imgVariable32
        ButtonTool121.SharedPropsInternal.AppearancesLarge.Appearance = Appearance25
        Appearance26.Image = Global.ADRIFT.My.Resources.imgVariable16
        ButtonTool121.SharedPropsInternal.AppearancesSmall.Appearance = Appearance26
        ButtonTool121.SharedPropsInternal.Caption = "Variable"
        ButtonTool121.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftV
        ButtonTool121.SharedPropsInternal.ToolTipText = "Variables allow you to keep track of numbers or text in your game"
        ButtonTool121.SharedPropsInternal.ToolTipTitle = "Add Variable"
        Appearance27.Image = Global.ADRIFT.My.Resources.imgAdd16
        PopupMenuTool37.SharedPropsInternal.AppearancesSmall.Appearance = Appearance27
        PopupMenuTool37.SharedPropsInternal.Caption = "Add New"
        PopupMenuTool37.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool122, ButtonTool123, ButtonTool124, ButtonTool125, ButtonTool126, ButtonTool127, ButtonTool128, ButtonTool129, ButtonTool130, ButtonTool131})
        Appearance28.Image = CType(resources.GetObject("Appearance28.Image"), Object)
        ButtonTool132.SharedPropsInternal.AppearancesLarge.Appearance = Appearance28
        ButtonTool132.SharedPropsInternal.Caption = "Save &As"
        ButtonTool132.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        PopupMenuTool38.SharedPropsInternal.Caption = "Recent Adventures"
        StateButtonTool4.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool4.SharedPropsInternal.Caption = "Tab Windows"
        Appearance29.Image = Global.ADRIFT.My.Resources.imgGroup32
        ButtonTool133.SharedPropsInternal.AppearancesLarge.Appearance = Appearance29
        Appearance30.Image = Global.ADRIFT.My.Resources.imgGroup16
        ButtonTool133.SharedPropsInternal.AppearancesSmall.Appearance = Appearance30
        ButtonTool133.SharedPropsInternal.Caption = "Group"
        ButtonTool133.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        ButtonTool133.SharedPropsInternal.ToolTipText = "Locations, Objects and Characters can all be added to groups to all be treated th" & _
    "e same"
        ButtonTool133.SharedPropsInternal.ToolTipTitle = "Add Group"
        Appearance31.Image = Global.ADRIFT.My.Resources.imgALR32
        ButtonTool134.SharedPropsInternal.AppearancesLarge.Appearance = Appearance31
        Appearance32.Image = Global.ADRIFT.My.Resources.imgALR16
        ButtonTool134.SharedPropsInternal.AppearancesSmall.Appearance = Appearance32
        ButtonTool134.SharedPropsInternal.Caption = "Text Override"
        ButtonTool134.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlX
        ButtonTool134.SharedPropsInternal.ToolTipText = "Text Overrides allow you to change any final output text in Runner"
        ButtonTool134.SharedPropsInternal.ToolTipTitle = "Add Text Override"
        Appearance33.Image = Global.ADRIFT.My.Resources.imgHint32
        ButtonTool135.SharedPropsInternal.AppearancesLarge.Appearance = Appearance33
        Appearance34.Image = CType(resources.GetObject("Appearance34.Image"), Object)
        ButtonTool135.SharedPropsInternal.AppearancesSmall.Appearance = Appearance34
        ButtonTool135.SharedPropsInternal.Caption = "Hint"
        ButtonTool135.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlH
        ButtonTool135.SharedPropsInternal.ToolTipText = "You can add hints to give players a little help whilst playing your game"
        ButtonTool135.SharedPropsInternal.ToolTipTitle = "Add Hint"
        ButtonTool136.SharedPropsInternal.Caption = "Module"
        ButtonTool136.SharedPropsInternal.DescriptionOnMenu = "Insert everything from a module into this adventure"
        Appearance35.Image = Global.ADRIFT.My.Resources.imgGroup32
        ButtonTool137.SharedPropsInternal.AppearancesLarge.Appearance = Appearance35
        ButtonTool137.SharedPropsInternal.Caption = "Module"
        ButtonTool137.SharedPropsInternal.DescriptionOnMenu = "Export a module for distribution, or for use as a library"
        Appearance36.Image = Global.ADRIFT.My.Resources.imgImport32
        PopupMenuTool39.SharedPropsInternal.AppearancesLarge.Appearance = Appearance36
        Appearance37.Image = Global.ADRIFT.My.Resources.imgImport16
        PopupMenuTool39.SharedPropsInternal.AppearancesSmall.Appearance = Appearance37
        PopupMenuTool39.SharedPropsInternal.Caption = "&Import"
        PopupMenuTool39.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType
        PopupMenuTool39.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool138, ButtonTool153, ButtonTool162, ButtonTool159})
        Appearance38.Image = Global.ADRIFT.My.Resources.imgExport32
        PopupMenuTool40.SharedPropsInternal.AppearancesLarge.Appearance = Appearance38
        Appearance39.Image = Global.ADRIFT.My.Resources.imgExport16
        PopupMenuTool40.SharedPropsInternal.AppearancesSmall.Appearance = Appearance39
        PopupMenuTool40.SharedPropsInternal.Caption = "&Export"
        PopupMenuTool40.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool139, ButtonTool9, ButtonTool26, ButtonTool151, ButtonTool168})
        Appearance40.Image = Global.ADRIFT.My.Resources.imgSettings32
        ButtonTool140.SharedPropsInternal.AppearancesLarge.Appearance = Appearance40
        Appearance41.Image = Global.ADRIFT.My.Resources.imgSettings16
        ButtonTool140.SharedPropsInternal.AppearancesSmall.Appearance = Appearance41
        ButtonTool140.SharedPropsInternal.Caption = "Settings..."
        Appearance42.Image = Global.ADRIFT.My.Resources.imgProperty32
        ButtonTool141.SharedPropsInternal.AppearancesLarge.Appearance = Appearance42
        Appearance43.Image = Global.ADRIFT.My.Resources.imgProperty16
        ButtonTool141.SharedPropsInternal.AppearancesSmall.Appearance = Appearance43
        ButtonTool141.SharedPropsInternal.Caption = "Property"
        ButtonTool141.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlP
        ButtonTool141.SharedPropsInternal.ToolTipText = "Locations, Objects and Characters can all be given particular attributes"
        ButtonTool141.SharedPropsInternal.ToolTipTitle = "Add Property"
        Appearance44.Image = Global.ADRIFT.My.Resources.imgInfo16
        ButtonTool142.SharedPropsInternal.AppearancesSmall.Appearance = Appearance44
        ButtonTool142.SharedPropsInternal.Caption = "About ADRIFT Developer"
        Appearance45.Image = Global.ADRIFT.My.Resources.imgRun32
        ButtonTool143.SharedPropsInternal.AppearancesLarge.Appearance = Appearance45
        Appearance46.Image = Global.ADRIFT.My.Resources.imgRun16
        ButtonTool143.SharedPropsInternal.AppearancesSmall.Appearance = Appearance46
        ButtonTool143.SharedPropsInternal.Caption = "Run Adventure"
        ButtonTool143.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.F5
        Appearance47.Image = Global.ADRIFT.My.Resources.imgCancel16
        ButtonTool144.SharedPropsInternal.AppearancesSmall.Appearance = Appearance47
        ButtonTool144.SharedPropsInternal.Caption = "E&xit Developer"
        ButtonTool144.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance48.Image = Global.ADRIFT.My.Resources.imgSynonym32
        ButtonTool2.SharedPropsInternal.AppearancesLarge.Appearance = Appearance48
        ButtonTool2.SharedPropsInternal.Caption = "Introduction && End of Game"
        Appearance49.Image = Global.ADRIFT.My.Resources.imgOptions32
        ButtonTool5.SharedPropsInternal.AppearancesLarge.Appearance = Appearance49
        Appearance50.Image = Global.ADRIFT.My.Resources.imgOptions16
        ButtonTool5.SharedPropsInternal.AppearancesSmall.Appearance = Appearance50
        ButtonTool5.SharedPropsInternal.Caption = "Options"
        ButtonTool8.SharedPropsInternal.Caption = "iFiction Record"
        ButtonTool8.SharedPropsInternal.DescriptionOnMenu = "Export the bibliographic record for this text adventure"
        ButtonTool14.SharedPropsInternal.Caption = "Arrange Icons"
        Appearance51.Image = Global.ADRIFT.My.Resources.imgCascade16
        ButtonTool15.SharedPropsInternal.AppearancesSmall.Appearance = Appearance51
        ButtonTool15.SharedPropsInternal.Caption = "Cascade"
        Appearance52.Image = Global.ADRIFT.My.Resources.imgDelete
        ButtonTool16.SharedPropsInternal.AppearancesSmall.Appearance = Appearance52
        ButtonTool16.SharedPropsInternal.Caption = "Close All Windows"
        Appearance53.Image = Global.ADRIFT.My.Resources.imgArrangeHorz16
        ButtonTool17.SharedPropsInternal.AppearancesSmall.Appearance = Appearance53
        ButtonTool17.SharedPropsInternal.Caption = "Tile Horizontally"
        Appearance54.Image = CType(resources.GetObject("Appearance54.Image"), Object)
        ButtonTool18.SharedPropsInternal.AppearancesSmall.Appearance = Appearance54
        ButtonTool18.SharedPropsInternal.Caption = "Tile Vertically"
        Appearance55.Image = CType(resources.GetObject("Appearance55.Image"), Object)
        ButtonTool19.SharedPropsInternal.AppearancesSmall.Appearance = Appearance55
        ButtonTool19.SharedPropsInternal.Caption = "Replace"
        ButtonTool19.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlR
        Appearance56.Image = Global.ADRIFT.My.Resources.imgFindNext
        ButtonTool23.SharedPropsInternal.AppearancesLarge.Appearance = Appearance56
        Appearance57.Image = Global.ADRIFT.My.Resources.imgFindNext
        ButtonTool23.SharedPropsInternal.AppearancesSmall.Appearance = Appearance57
        Appearance58.Image = Global.ADRIFT.My.Resources.imgFindNext
        ButtonTool23.SharedPropsInternal.AppearancesSmall.AppearanceOnMenu = Appearance58
        ButtonTool23.SharedPropsInternal.Caption = "Find Next"
        ButtonTool23.SharedPropsInternal.Enabled = False
        ButtonTool23.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        ButtonTool24.SharedPropsInternal.Caption = "Windows Executable"
        ButtonTool24.SharedPropsInternal.DescriptionOnMenu = "Create a file that can be distributed as a standalone executable"
        LabelTool2.SharedPropsInternal.Caption = "Recent Documents"
        Appearance59.Image = Global.ADRIFT.My.Resources.imgUnlock32
        ButtonTool60.SharedPropsInternal.AppearancesLarge.Appearance = Appearance59
        ButtonTool60.SharedPropsInternal.Caption = "Protect Adventure"
        Appearance60.Image = Global.ADRIFT.My.Resources.imgFolderList32
        ButtonTool62.SharedPropsInternal.AppearancesLarge.Appearance = Appearance60
        ButtonTool62.SharedPropsInternal.Caption = "Folder List"
        ButtonTool62.SharedPropsInternal.Enabled = False
        Appearance61.Image = Global.ADRIFT.My.Resources.imgKey16
        ButtonTool63.SharedPropsInternal.AppearancesSmall.Appearance = Appearance61
        ButtonTool63.SharedPropsInternal.Caption = "Unlock ADRIFT"
        Appearance62.Image = CType(resources.GetObject("Appearance62.Image"), Object)
        ButtonTool66.SharedPropsInternal.AppearancesLarge.Appearance = Appearance62
        Appearance63.Image = CType(resources.GetObject("Appearance63.Image"), Object)
        ButtonTool66.SharedPropsInternal.AppearancesSmall.Appearance = Appearance63
        ButtonTool66.SharedPropsInternal.Caption = "Map"
        ButtonTool66.SharedPropsInternal.Enabled = False
        Appearance64.Image = Global.ADRIFT.My.Resources.imgLocation32
        ButtonTool72.SharedPropsInternal.AppearancesLarge.Appearance = Appearance64
        ButtonTool72.SharedPropsInternal.Caption = "Add Location"
        Appearance65.Image = Global.ADRIFT.My.Resources.imgPlanView32
        ButtonTool101.SharedPropsInternal.AppearancesLarge.Appearance = Appearance65
        ButtonTool101.SharedPropsInternal.Caption = "Plan View"
        ButtonTool101.SharedPropsInternal.ToolTipText = "Reset map to plan view"
        Appearance66.Image = Global.ADRIFT.My.Resources.imgCentre32
        ButtonTool108.SharedPropsInternal.AppearancesLarge.Appearance = Appearance66
        ButtonTool108.SharedPropsInternal.Caption = "Centralise Map"
        Appearance67.Image = Global.ADRIFT.My.Resources.imgZoomIn32
        ButtonTool145.SharedPropsInternal.AppearancesLarge.Appearance = Appearance67
        ButtonTool145.SharedPropsInternal.Caption = "Zoom In"
        Appearance68.Image = Global.ADRIFT.My.Resources.imgZoomOut32
        ButtonTool146.SharedPropsInternal.AppearancesLarge.Appearance = Appearance68
        ButtonTool146.SharedPropsInternal.Caption = "Zoom Out"
        Appearance69.Image = Global.ADRIFT.My.Resources.imgWarn16
        ButtonTool148.SharedPropsInternal.AppearancesSmall.Appearance = Appearance69
        ButtonTool148.SharedPropsInternal.Caption = "Map Layout Warning"
        ButtonTool148.SharedPropsInternal.Visible = False
        Appearance70.Image = Global.ADRIFT.My.Resources.imgAxes32
        StateButtonTool2.SharedPropsInternal.AppearancesLarge.Appearance = Appearance70
        StateButtonTool2.SharedPropsInternal.Caption = "Show Axes"
        Appearance71.Image = Global.ADRIFT.My.Resources.imgGrid16
        StateButtonTool5.SharedPropsInternal.AppearancesLarge.Appearance = Appearance71
        Appearance72.Image = Global.ADRIFT.My.Resources.imgGrid16
        StateButtonTool5.SharedPropsInternal.AppearancesSmall.Appearance = Appearance72
        StateButtonTool5.SharedPropsInternal.Caption = "Show Grid Lines"
        Appearance73.Image = Global.ADRIFT.My.Resources.imgTile16
        ButtonTool150.SharedPropsInternal.AppearancesSmall.Appearance = Appearance73
        ButtonTool150.SharedPropsInternal.Caption = "Tile"
        ButtonTool152.SharedPropsInternal.Caption = "Blorb"
        ButtonTool152.SharedPropsInternal.DescriptionOnMenu = "Package your adventure into a single file containing all media used"
        ButtonTool154.SharedPropsInternal.Caption = "Blorb"
        ButtonTool154.SharedPropsInternal.DescriptionOnMenu = "Extract all the media from a Blorb file"
        ButtonTool156.SharedPropsInternal.Caption = "Properties"
        Appearance74.Image = Global.ADRIFT.My.Resources.imgNew32
        ButtonTool41.SharedPropsInternal.AppearancesLarge.Appearance = Appearance74
        Appearance75.Image = Global.ADRIFT.My.Resources.imgNew16
        ButtonTool41.SharedPropsInternal.AppearancesSmall.Appearance = Appearance75
        ButtonTool41.SharedPropsInternal.Caption = "Add Page"
        ButtonTool160.SharedPropsInternal.Caption = "Trizbort"
        ButtonTool160.SharedPropsInternal.DescriptionOnMenu = "Import map layout"
        ButtonTool161.SharedPropsInternal.Caption = "Language Resource"
        ButtonTool161.SharedPropsInternal.DescriptionOnMenu = "Import Text Overrides from a text file"
        Appearance76.Image = Global.ADRIFT.My.Resources.imgPrint32
        ButtonTool163.SharedPropsInternal.AppearancesLarge.Appearance = Appearance76
        Appearance77.Image = Global.ADRIFT.My.Resources.imgPrint16
        ButtonTool163.SharedPropsInternal.AppearancesSmall.Appearance = Appearance77
        ButtonTool163.SharedPropsInternal.Caption = "Print"
        ButtonTool164.SharedPropsInternal.Caption = "Print Preview..."
        ButtonTool166.SharedPropsInternal.Caption = "Language Resource"
        ButtonTool166.SharedPropsInternal.DescriptionOnMenu = "Export Text Overrides into a text file"
        Appearance78.Image = Global.ADRIFT.My.Resources.imgHelp16
        ButtonTool169.SharedPropsInternal.AppearancesSmall.Appearance = Appearance78
        ButtonTool169.SharedPropsInternal.Caption = "Help"
        Appearance79.Image = Global.ADRIFT.My.Resources.imgFunction32
        ButtonTool171.SharedPropsInternal.AppearancesLarge.Appearance = Appearance79
        Appearance80.Image = Global.ADRIFT.My.Resources.imgFunction16
        ButtonTool171.SharedPropsInternal.AppearancesSmall.Appearance = Appearance80
        ButtonTool171.SharedPropsInternal.Caption = "User Function"
        Appearance81.Image = Global.ADRIFT.My.Resources.imgSynonym32
        ButtonTool173.SharedPropsInternal.AppearancesLarge.Appearance = Appearance81
        Appearance82.Image = Global.ADRIFT.My.Resources.imgSynonym16
        ButtonTool173.SharedPropsInternal.AppearancesSmall.Appearance = Appearance82
        ButtonTool173.SharedPropsInternal.Caption = "Synonym"
        Me.UTMMain.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {PopupMenuTool27, ButtonTool95, ButtonTool96, PopupMenuTool31, PopupMenuTool32, ButtonTool105, ButtonTool106, ButtonTool107, PopupMenuTool33, PopupMenuTool35, PopupMenuTool36, MdiWindowListTool4, ButtonTool110, ButtonTool111, ButtonTool112, ButtonTool113, ButtonTool114, ButtonTool115, ButtonTool116, ButtonTool117, ButtonTool118, ButtonTool119, ButtonTool120, ButtonTool121, PopupMenuTool37, ButtonTool132, PopupMenuTool38, StateButtonTool4, ButtonTool133, ButtonTool134, ButtonTool135, ButtonTool136, ButtonTool137, PopupMenuTool39, PopupMenuTool40, ButtonTool140, ButtonTool141, ButtonTool142, ButtonTool143, ButtonTool144, ButtonTool2, ButtonTool5, ButtonTool8, ButtonTool14, ButtonTool15, ButtonTool16, ButtonTool17, ButtonTool18, ButtonTool19, ButtonTool23, ButtonTool24, LabelTool2, ButtonTool60, ButtonTool62, ButtonTool63, ButtonTool66, ButtonTool72, ButtonTool101, ButtonTool108, ButtonTool145, ButtonTool146, ButtonTool148, StateButtonTool2, StateButtonTool5, ButtonTool150, ButtonTool152, ButtonTool154, ButtonTool156, ButtonTool41, ButtonTool160, ButtonTool161, ButtonTool163, ButtonTool164, ButtonTool166, ButtonTool169, ButtonTool171, ButtonTool173})
        '
        '_frmGenerator_Toolbars_Dock_Area_Right
        '
        Me._frmGenerator_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmGenerator_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._frmGenerator_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._frmGenerator_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmGenerator_Toolbars_Dock_Area_Right.InitialResizeAreaExtent = 8
        Me._frmGenerator_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(921, 164)
        Me._frmGenerator_Toolbars_Dock_Area_Right.Name = "_frmGenerator_Toolbars_Dock_Area_Right"
        Me._frmGenerator_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(8, 480)
        Me._frmGenerator_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UTMMain
        '
        '_frmGenerator_Toolbars_Dock_Area_Top
        '
        Me._frmGenerator_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmGenerator_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._frmGenerator_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._frmGenerator_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmGenerator_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._frmGenerator_Toolbars_Dock_Area_Top.Name = "_frmGenerator_Toolbars_Dock_Area_Top"
        Me._frmGenerator_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(929, 164)
        Me._frmGenerator_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UTMMain
        '
        '_frmGenerator_Toolbars_Dock_Area_Bottom
        '
        Me._frmGenerator_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmGenerator_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._frmGenerator_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmGenerator_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmGenerator_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 644)
        Me._frmGenerator_Toolbars_Dock_Area_Bottom.Name = "_frmGenerator_Toolbars_Dock_Area_Bottom"
        Me._frmGenerator_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(929, 0)
        Me._frmGenerator_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UTMMain
        '
        'UDMGenerator
        '
        Me.UDMGenerator.CompressUnpinnedTabs = False
        DockAreaPane1.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit
        DockAreaPane1.DockedBefore = New System.Guid("02625fb5-30ea-419f-a5ee-f435e59086b2")
        DockableControlPane1.Control = Me.FolderList1
        DockableControlPane1.FlyoutSize = New System.Drawing.Size(194, -1)
        DockableControlPane1.OriginalControlBounds = New System.Drawing.Rectangle(12, 54, 192, 429)
        Appearance1.Image = Global.ADRIFT.My.Resources.imgFolder16
        DockableControlPane1.Settings.TabAppearance = Appearance1
        DockableControlPane1.Size = New System.Drawing.Size(100, 100)
        DockableControlPane1.Text = "Folders"
        DockAreaPane1.Panes.AddRange(New Infragistics.Win.UltraWinDock.DockablePaneBase() {DockableControlPane1})
        DockAreaPane1.Size = New System.Drawing.Size(194, 480)
        DockAreaPane2.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit
        DockAreaPane2.DockedBefore = New System.Guid("da8e20b7-4eff-497d-ac07-a6389585feb4")
        DockAreaPane2.FloatingLocation = New System.Drawing.Point(567, 408)
        DockAreaPane2.Size = New System.Drawing.Size(186, 326)
        DockAreaPane3.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit
        DockAreaPane3.FloatingLocation = New System.Drawing.Point(567, 408)
        DockableControlPane2.Control = Me.Map1
        DockableControlPane2.FlyoutSize = New System.Drawing.Size(-1, 237)
        DockableControlPane2.OriginalControlBounds = New System.Drawing.Rectangle(593, 296, 266, 254)
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        DockableControlPane2.Settings.TabAppearance = Appearance2
        DockableControlPane2.Size = New System.Drawing.Size(100, 100)
        DockableControlPane2.Text = "Map"
        DockAreaPane3.Panes.AddRange(New Infragistics.Win.UltraWinDock.DockablePaneBase() {DockableControlPane2})
        DockAreaPane3.Size = New System.Drawing.Size(714, 237)
        Me.UDMGenerator.DockAreas.AddRange(New Infragistics.Win.UltraWinDock.DockAreaPane() {DockAreaPane1, DockAreaPane2, DockAreaPane3})
        Me.UDMGenerator.DragWindowStyle = Infragistics.Win.UltraWinDock.DragWindowStyle.LayeredWindowWithIndicators
        Me.UDMGenerator.HostControl = Me
        Me.UDMGenerator.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.VisualStudio2008
        '
        '_frmGeneratorUnpinnedTabAreaLeft
        '
        Me._frmGeneratorUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me._frmGeneratorUnpinnedTabAreaLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frmGeneratorUnpinnedTabAreaLeft.Location = New System.Drawing.Point(8, 164)
        Me._frmGeneratorUnpinnedTabAreaLeft.Name = "_frmGeneratorUnpinnedTabAreaLeft"
        Me._frmGeneratorUnpinnedTabAreaLeft.Owner = Me.UDMGenerator
        Me._frmGeneratorUnpinnedTabAreaLeft.Size = New System.Drawing.Size(0, 480)
        Me._frmGeneratorUnpinnedTabAreaLeft.TabIndex = 24
        '
        '_frmGeneratorUnpinnedTabAreaRight
        '
        Me._frmGeneratorUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right
        Me._frmGeneratorUnpinnedTabAreaRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frmGeneratorUnpinnedTabAreaRight.Location = New System.Drawing.Point(921, 164)
        Me._frmGeneratorUnpinnedTabAreaRight.Name = "_frmGeneratorUnpinnedTabAreaRight"
        Me._frmGeneratorUnpinnedTabAreaRight.Owner = Me.UDMGenerator
        Me._frmGeneratorUnpinnedTabAreaRight.Size = New System.Drawing.Size(0, 480)
        Me._frmGeneratorUnpinnedTabAreaRight.TabIndex = 25
        '
        '_frmGeneratorUnpinnedTabAreaTop
        '
        Me._frmGeneratorUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top
        Me._frmGeneratorUnpinnedTabAreaTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frmGeneratorUnpinnedTabAreaTop.Location = New System.Drawing.Point(8, 164)
        Me._frmGeneratorUnpinnedTabAreaTop.Name = "_frmGeneratorUnpinnedTabAreaTop"
        Me._frmGeneratorUnpinnedTabAreaTop.Owner = Me.UDMGenerator
        Me._frmGeneratorUnpinnedTabAreaTop.Size = New System.Drawing.Size(913, 0)
        Me._frmGeneratorUnpinnedTabAreaTop.TabIndex = 26
        '
        '_frmGeneratorUnpinnedTabAreaBottom
        '
        Me._frmGeneratorUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me._frmGeneratorUnpinnedTabAreaBottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frmGeneratorUnpinnedTabAreaBottom.Location = New System.Drawing.Point(8, 644)
        Me._frmGeneratorUnpinnedTabAreaBottom.Name = "_frmGeneratorUnpinnedTabAreaBottom"
        Me._frmGeneratorUnpinnedTabAreaBottom.Owner = Me.UDMGenerator
        Me._frmGeneratorUnpinnedTabAreaBottom.Size = New System.Drawing.Size(913, 0)
        Me._frmGeneratorUnpinnedTabAreaBottom.TabIndex = 27
        '
        '_frmGeneratorAutoHideControl
        '
        Me._frmGeneratorAutoHideControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frmGeneratorAutoHideControl.Location = New System.Drawing.Point(30, 160)
        Me._frmGeneratorAutoHideControl.Name = "_frmGeneratorAutoHideControl"
        Me._frmGeneratorAutoHideControl.Owner = Me.UDMGenerator
        Me._frmGeneratorAutoHideControl.Size = New System.Drawing.Size(199, 484)
        Me._frmGeneratorAutoHideControl.TabIndex = 28
        '
        'WindowDockingArea1
        '
        Me.WindowDockingArea1.Controls.Add(Me.DockableWindow1)
        Me.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left
        Me.WindowDockingArea1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WindowDockingArea1.Location = New System.Drawing.Point(8, 164)
        Me.WindowDockingArea1.Name = "WindowDockingArea1"
        Me.WindowDockingArea1.Owner = Me.UDMGenerator
        Me.WindowDockingArea1.Size = New System.Drawing.Size(199, 480)
        Me.WindowDockingArea1.TabIndex = 29
        '
        'DockableWindow1
        '
        Me.DockableWindow1.Controls.Add(Me.FolderList1)
        Me.DockableWindow1.Location = New System.Drawing.Point(0, 0)
        Me.DockableWindow1.Name = "DockableWindow1"
        Me.DockableWindow1.Owner = Me.UDMGenerator
        Me.DockableWindow1.Size = New System.Drawing.Size(194, 480)
        Me.DockableWindow1.TabIndex = 48
        '
        'DockableWindow2
        '
        Me.DockableWindow2.Controls.Add(Me.Map1)
        Me.DockableWindow2.Location = New System.Drawing.Point(0, 0)
        Me.DockableWindow2.Name = "DockableWindow2"
        Me.DockableWindow2.Owner = Me.UDMGenerator
        Me.DockableWindow2.Size = New System.Drawing.Size(714, 237)
        Me.DockableWindow2.TabIndex = 49
        '
        'WindowDockingArea3
        '
        Me.WindowDockingArea3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WindowDockingArea3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WindowDockingArea3.Location = New System.Drawing.Point(8, 8)
        Me.WindowDockingArea3.Name = "WindowDockingArea3"
        Me.WindowDockingArea3.Owner = Me.UDMGenerator
        Me.WindowDockingArea3.Size = New System.Drawing.Size(186, 326)
        Me.WindowDockingArea3.TabIndex = 0
        '
        'WindowDockingArea4
        '
        Me.WindowDockingArea4.Controls.Add(Me.DockableWindow2)
        Me.WindowDockingArea4.Dock = System.Windows.Forms.DockStyle.Top
        Me.WindowDockingArea4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WindowDockingArea4.Location = New System.Drawing.Point(207, 164)
        Me.WindowDockingArea4.Name = "WindowDockingArea4"
        Me.WindowDockingArea4.Owner = Me.UDMGenerator
        Me.WindowDockingArea4.Size = New System.Drawing.Size(714, 242)
        Me.WindowDockingArea4.TabIndex = 42
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "ADRIFT 5 Help.chm"
        '
        'cmsMain
        '
        Me.cmsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAddFolder})
        Me.cmsMain.Name = "cmsMain"
        Me.cmsMain.Size = New System.Drawing.Size(133, 26)
        '
        'miAddFolder
        '
        Me.miAddFolder.Image = Global.ADRIFT.My.Resources.imgFolder16
        Me.miAddFolder.Name = "miAddFolder"
        Me.miAddFolder.Size = New System.Drawing.Size(132, 22)
        Me.miAddFolder.Text = "Add Folder"
        '
        'frmGenerator
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(929, 668)
        Me.ContextMenuStrip = Me.cmsMain
        Me.Controls.Add(Me._frmGeneratorAutoHideControl)
        Me.Controls.Add(Me.WindowDockingArea4)
        Me.Controls.Add(Me.WindowDockingArea1)
        Me.Controls.Add(Me._frmGeneratorUnpinnedTabAreaBottom)
        Me.Controls.Add(Me._frmGeneratorUnpinnedTabAreaTop)
        Me.Controls.Add(Me._frmGeneratorUnpinnedTabAreaRight)
        Me.Controls.Add(Me._frmGeneratorUnpinnedTabAreaLeft)
        Me.Controls.Add(Me._frmGenerator_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._frmGenerator_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._frmGenerator_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me._frmGenerator_Toolbars_Dock_Area_Top)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmGenerator"
        Me.Text = "ADRIFT Developer"
        CType(Me.StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UTMMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDMGenerator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WindowDockingArea1.ResumeLayout(False)
        Me.DockableWindow1.ResumeLayout(False)
        Me.DockableWindow2.ResumeLayout(False)
        Me.WindowDockingArea4.ResumeLayout(False)
        Me.cmsMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Private Declare Function GetActiveWindow Lib "user32" () As Int32
    Private Declare Function GetCurrentThreadId Lib "kernel32" () As Integer
    Private Declare Function GetForegroundWindow Lib "user32" () As IntPtr
    Private Declare Function GetWindowThreadProcessId Lib "user32" (ByVal hWnd As IntPtr, lpdwProcessId As Integer) As Integer


    'Declare Function GetSystemDirectory Lib "kernel32" Alias "GetSystemDirectoryA" (ByVal lpBuffer As String, ByVal nSize As Long) As Long
    Private WithEvents tmrElapsed As New Timer
    Public fSettings As frmSettings
    Public fOptions As frmOptions
    Private _sDestinationList As String
    Public Property sDestinationList As String
        Get
            Return _sDestinationList
        End Get
        Set(value As String)
            _sDestinationList = value
        End Set
    End Property
    Private fSplash As Splash
    Public ActiveFolder As Folder
    Public PartOne As Boolean = False
    Private bPartTwo As Boolean = False
    Public Property PartTwo As Boolean
        Get
            Return bPartTwo
        End Get
        Set(value As Boolean)
            bPartTwo = value
            iRegistered = 0
        End Set
    End Property


    Private sKeyPrefix As String = "" 'UNDEFINED"
    Public Property KeyPrefix As String
        Get
            'If sKeyPrefix = "UNDEFINED" Then
            'sKeyPrefix = GetSetting("ADRIFT", "Generator", "KeyPrefix", "")
            'End If
            Return sKeyPrefix
        End Get
        Set(value As String)
            sKeyPrefix = value
            'SaveSetting("ADRIFT", "Generator", "KeyPrefix", value)
        End Set
    End Property


    Private bSimpleMode As Boolean = False
    Private bLoadedSimpleMode As Boolean = False
    Public Property SimpleMode As Boolean
        Get
            If Not bLoadedSimpleMode Then
                bSimpleMode = SafeBool(GetSetting("ADRIFT", "Generator", "SimpleMode", CInt(True).ToString))
                bLoadedSimpleMode = True
                SetSimple(bSimpleMode)
            End If
            Return bSimpleMode
        End Get
        Set(value As Boolean)
            If value <> bSimpleMode Then
                bSimpleMode = value
                SaveSetting("ADRIFT", "Generator", "SimpleMode", CInt(bSimpleMode).ToString)
                SetSimple(bSimpleMode)
            End If
        End Set
    End Property



    Private _AutoComplete As Boolean = False
    Private _LoadedAutoComplete As Boolean = False
    Public Property AutoComplete As Boolean
        Get
            If Not _LoadedAutoComplete Then
                _AutoComplete = SafeBool(GetSetting("ADRIFT", "Generator", "AutoComplete", CInt(True).ToString))
                _LoadedAutoComplete = True
            End If
            Return _AutoComplete
        End Get
        Set(value As Boolean)
            If value <> _AutoComplete Then
                _AutoComplete = value
                SaveSetting("ADRIFT", "Generator", "AutoComplete", CInt(_AutoComplete).ToString)
            End If
        End Set
    End Property


    Private Sub SetSimple(ByVal bSimple As Boolean)
        SetToolVisible(fGenerator.UTMMain.Tools("Variable"), Not bSimple)
        SetToolVisible(fGenerator.UTMMain.Tools("Group"), Not bSimple)
        SetToolVisible(fGenerator.UTMMain.Tools("Property"), Not bSimple)
        SetToolVisible(fGenerator.UTMMain.Tools("Text Override"), Not bSimple)
        SetToolVisible(fGenerator.UTMMain.Tools("Hint"), Not bSimple)
        SetToolVisible(fGenerator.UTMMain.Tools("Synonym"), Not bSimple)
        SetToolVisible(fGenerator.UTMMain.Tools("UserFunction"), Not bSimple)
        If bSimple Then
            StatusBar1.Panels(3).Text = "Simple Mode: On"
        Else
            StatusBar1.Panels(3).Text = ""
        End If
        'UpdateMainTitle()
    End Sub


    Private Sub SetToolVisible(ByVal tool As Infragistics.Win.UltraWinToolbars.ToolBase, ByVal bVisible As Boolean, Optional ByVal grp As Infragistics.Win.UltraWinToolbars.RibbonGroup = Nothing)

        If Not fGenerator.UTMMain.Ribbon.Tabs("Home").Groups.Exists("Hidden") Then
            fGenerator.UTMMain.Ribbon.Tabs("Home").Groups.Add("Hidden")
            fGenerator.UTMMain.Ribbon.Tabs("Home").Groups("Hidden").Visible = False
        End If

        If grp Is Nothing Then grp = fGenerator.UTMMain.Ribbon.Tabs("Home").Groups("ribbonGroup1")

        Dim grpSource As Infragistics.Win.UltraWinToolbars.RibbonGroup
        Dim grpDest As Infragistics.Win.UltraWinToolbars.RibbonGroup

        If bVisible Then
            grpSource = fGenerator.UTMMain.Ribbon.Tabs("Home").Groups("Hidden")
            grpDest = grp
        Else
            grpSource = grp
            grpDest = fGenerator.UTMMain.Ribbon.Tabs("Home").Groups("Hidden")
        End If

        If Not grpDest.Tools.Exists(tool.Key) Then
            grpSource.Tools.Remove(tool)
            grpDest.Tools.AddTool(tool.Key)
            With grpDest.Tools(tool.Key)
                .InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
            End With
        End If

    End Sub


    Private Sub frmGenerator_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not CheckForSave() Then e.Cancel = True
        UDMGenerator.SaveAsXML(DataPath(True) & "DeveloperLayout.xml")
    End Sub


    ' Returns True if nothing needs saving, or saves OK, or user doesn't want to save
    ' Returns False if user cancels
    Private Function CheckForSave() As Boolean

        If Adventure IsNot Nothing AndAlso Adventure.Changed Then
            Select Case MessageBox.Show("Would you like to save your changes to this adventure?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    Return mnuSave()
                Case Windows.Forms.DialogResult.No
                    Return True
                Case Windows.Forms.DialogResult.Cancel
                    Return False
            End Select
        Else
            Return True
        End If

    End Function


    Private Function GetWinSysDir() As String

        'Dim strPath As String
        'strPath = Space$(1024)
        'Dim iLen As Integer = CInt(GetSystemDirectory(strPath, Len(strPath)))
        'strPath = sLeft(strPath, iLen)
        'If sRight(strPath, 1) <> "\" Then strPath = strPath & "\"

        'GetWinSysDir = strPath
        Return Environment.SystemDirectory & IO.Path.DirectorySeparatorChar
    End Function



    Private Sub frmGenerator_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            fGenerator = Me

            'If Not IsRegistered() Then
            '    MessageBox.Show("ADRIFT Developer v5.0 Alpha is only available to registered users.  Sorry.", "Not Registered", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    End
            'End If

            GlobalStartup()
            IntroMessage()
            GetSettings()

            Dim bSetSimple As Boolean = SimpleMode

            UTMMain.Tools("Register").SharedProps.Visible = Not IsRegistered

            'If Not IO.Directory.Exists(sLocalDataPath) Then IO.Directory.CreateDirectory(sLocalDataPath)

            If IO.File.Exists(DataPath(True) & "DeveloperLayout.xml") Then
                Try
                    UDMGenerator.LoadFromXML(DataPath(True) & "DeveloperLayout.xml")
                Catch
                    ' It's not the end of the world if this fails
                End Try
            End If

            If Not ControlInForm(Map1) Then
                UTMMain.Tools("Map").SharedProps.Enabled = True
                UTMMain.Ribbon.ContextualTabGroups("ctgMapTools").Visible = False
            End If
            If Not ControlInForm(FolderList1) Then UTMMain.Tools("FolderList").SharedProps.Enabled = True

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

            eOverwriteLibraries = CType(SafeInt(GetSetting("ADRIFT", "Generator", "OverwriteLibraries", "0")), OverwriteLibrariesEnum)
            bEnableGraphics = CBool(SafeInt(GetSetting("ADRIFT", "Generator", "EnableGraphics", "-1")))
            bEnableAudio = CBool(SafeInt(GetSetting("ADRIFT", "Generator", "EnableAudio", "-1")))
            bEnablePreview = CBool(SafeInt(GetSetting("ADRIFT", "Generator", "EnablePreview", "-1")))

            GetFormPosition(Me, UTMMain, UDMGenerator)
            NewAdventure()
            AddPrevious(fGenerator.UTMMain, "Generator")

            If Environment.GetCommandLineArgs.Length > 1 Then
                If IO.File.Exists(Environment.GetCommandLineArgs(1)) Then
                    OpenAdventure(Environment.GetCommandLineArgs(1))
                End If
            End If

            tmrElapsed.Interval = 1000
            tmrElapsed.Start()

        Catch ex As Exception
            ErrMsg("Error starting up Developer", ex)
        End Try

    End Sub


    Private Function mnuSave() As Boolean

        If Adventure.Filename <> "" AndAlso Adventure.Filename <> "untitled.taf" Then
            If Adventure.dVersion < 5 Then
                If MessageBox.Show("This adventure is version " & Adventure.dVersion.ToString("0.0") & ".  Are you sure you wish to overwrite with version 5.0 format?", "Save Adventure", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Exit Function
            End If
            Try
                Dim sBackup As String = Adventure.FullPath
                If sBackup.EndsWith(".taf") Then sBackup = sBackup.Replace(".taf", ".bak") Else sBackup &= ".bak"
                IO.File.Copy(Adventure.FullPath, sBackup, True)
            Catch ex As Exception

            End Try
            If SaveFile(Adventure.FullPath, True) Then
                Adventure.Changed = False
                mnuSave = True
                AddFileToList(Adventure.FullPath)
            End If
        Else
            Return mnuSaveAs()
        End If

    End Function


    Private Function mnuSaveAs() As Boolean

        sfd.Filter = "ADRIFT Text Adventures (*.taf)|*.taf|All Files (*.*)|*.*"
        sfd.DefaultExt = "taf"
        If sfd.FileName.Length > 3 AndAlso Not sfd.FileName.ToLower.EndsWith("taf") Then sfd.FileName = ""
        sfd.Title = "Save ADRIFT Adventure"
        sfd.ShowDialog()

        If sfd.FileName <> "" Then
            If SaveFile(sfd.FileName, True) Then
                Adventure.Changed = False
                mnuSaveAs = True
                AddFileToList(Adventure.FullPath)
            End If
        End If

    End Function


    Private Sub ExportLanguageResource()

        sfd.Filter = "Language Resource Files (*.alr)|*.alr|All Files (*.*)|*.*"
        sfd.DefaultExt = "alr"
        If sfd.FileName.Length > 3 AndAlso Not sfd.FileName.ToLower.EndsWith("alr") Then sfd.FileName = ""
        sfd.ShowDialog()

        If sfd.FileName <> "" Then ExportALR(sfd.FileName)

    End Sub


    Private Sub ExportBlorb()

        sfd.Filter = "ADRIFT Blorb File (*.blorb)|*.blorb|All Files (*.*)|*.*"
        sfd.DefaultExt = "blorb"
        If sfd.FileName.Length > 5 AndAlso Not sfd.FileName.ToLower.EndsWith("blorb") Then sfd.FileName = ""
        sfd.Title = "Export ADRIFT Blorb"
        If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If sfd.FileName <> "" Then
                If SaveBlorb(sfd.FileName) Then Adventure.Changed = True
            End If
        End If
    End Sub


    Private Function OutputBlorb(ByVal blorb As clsBlorb) As Boolean

        If clsBlorb.ExecType <> "" AndAlso clsBlorb.ExecType <> "ADRI" Then
            Select Case MessageBox.Show("This Blorb contains an executable that is not in ADRIFT format.  Are you sure you wish to expand the Blorb?", "Output Blorb", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                Case Windows.Forms.DialogResult.Yes
                    ' Continue
                Case Windows.Forms.DialogResult.No
                    Return False
            End Select
        End If

        fbd.Description = "Select folder to output Blorb contents to"
        fbd.ShowDialog()
        If fbd.SelectedPath <> "" Then
            If blorb.OutputToFolder(fbd.SelectedPath) Then MessageBox.Show("Blorb extracted successfully.", "Output Blorb", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return True

    End Function



    Private Sub AddFolder(ByVal sFolder As String)
        ExportList.Add(sFolder)

        For Each sMember As String In Adventure.dictFolders(sFolder).Members
            If Adventure.dictFolders.ContainsKey(sMember) Then
                AddFolder(sMember)
            Else
                ExportList.Add(sMember)
            End If
        Next

    End Sub


    Friend Sub ExportModule(Optional ByVal sFolder As String = "")

        sfd.Filter = "ADRIFT Module File (*.amf)|*.amf|All Files (*.*)|*.*"
        sfd.DefaultExt = "amf"
        If sfd.FileName.Length > 3 AndAlso Not sfd.FileName.ToLower.EndsWith("amf") Then sfd.FileName = ""
        If sFolder = "" Then
            sfd.Title = "Export Module"
        Else
            sfd.Title = "Export folder """ & Adventure.dictFolders(sFolder).Name & """ as a Module"
        End If

        sfd.ShowDialog()

        If sfd.FileName <> "" Then
            ' Check to see if user only wants to save selected items            
            Dim iSelected As Integer = 0

            If sFolder = "" Then
                For Each folder As frmFolder In fGenerator.MDIFolders
                    iSelected += folder.Folder.lstContents.SelectedItems.Count
                    If iSelected > 3 Then Exit For
                Next
            End If

            If iSelected > 3 AndAlso sFolder = "" Then
                Select Case MessageBox.Show("Would you like to export the selected items only?", "Export Module", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    Case Windows.Forms.DialogResult.Yes
                        iSelected = -1
                    Case Windows.Forms.DialogResult.No
                        iSelected = 0
                    Case Windows.Forms.DialogResult.Cancel
                        Exit Sub
                End Select
            End If

            If sFolder <> "" Then
                ExportList = New List(Of String)
                AddFolder(sFolder)
                iSelected = -1
            Else
                ExportList = Nothing
            End If

            SaveFile(sfd.FileName, False, bSelectedOnly:=CBool(iSelected))
        End If

    End Sub


    Private Sub ExportiFictionRecord()

        sfd.Filter = "iFiction Records (*.iFiction)|*.iFiction|All Files (*.*)|*.*"
        sfd.DefaultExt = "iFiction"
        If sfd.FileName.Length > 8 AndAlso Not sfd.FileName.ToLower.EndsWith("iFiction") Then sfd.FileName = ""
        sfd.Title = "Export iFiction Record"
        sfd.ShowDialog()

        If sfd.FileName <> "" Then SaveiFictionRecord(sfd.FileName)

    End Sub


    Private Sub mnuOpen()
        OpenAdventureDialog(ofd)
    End Sub



    'Private Sub ListClick(ByVal sList As String)

    '    Try
    '        ' First, check to see if the list is already open
    '        For Each lst As frmList In Me.MdiChildren
    '            If lst.Text = sList Then
    '                lst.Show()
    '                lst.Focus()
    '                Exit Sub
    '            End If
    '        Next

    '        Dim ListInfo As ListInfo = CType(colLists(sList), ListInfo)
    '        ShowList(ListInfo)

    '    Catch ex As Exception
    '        MessageBox.Show("Error defining List: " & ex.Message, "ADRIFT Developer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    End Try

    'End Sub



    Private Sub NewAdventure()
        If CheckForSave() Then
            'SaveListsToXML()
            'ClearMenuLists()
            Adventure = New clsAdventure
            'LoadDefaults()        
            LoadLibraries(LoadWhatEnum.All)
            'CreateMandatoryProperties()

            Dim bNoLibrary As Boolean = Adventure.dictAllItems.Keys.Count = 0
            fGenerator.FolderList1.InitialiseTree()
            'If UDMGenerator.ControlPanes.Count > 1 Then
            '    ActiveFolder = CType(UDMGenerator.ControlPanes(1).Control, Folder)
            'End If
            'LoadLists(True)
            'Me.Text = "Untitled - ADRIFT Developer - [" & Adventure.Filename & "]"
            UpdateMainTitle()
            fGenerator.StatusBar1.Panels(0).Text = "File version: " & Adventure.Version
            fGenerator.StatusBar1.Panels(1).Text = "File size: 0 bytes"
            fGenerator.StatusBar1.Panels(2).Text = "Maximum score: 0"
            fGenerator.UTMMain.Tools("ProtectAdventure").SharedProps.Caption = "Protect Adventure"
            fGenerator.UTMMain.Tools("ProtectAdventure").SharedProps.AppearancesLarge.Appearance.Image = My.Resources.imgUnlock32

            If bNoLibrary Then
                If MessageBox.Show("You do not appear to have any libraries loaded.  Would you like to set these now?", "New Adventure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Me.Show()
                    DoToolClick("Settings", "", "Libraries")
                    If fSettings IsNot Nothing AndAlso fSettings.Visible Then
                        fSettings.TopMost = True
                        fSettings.BringToFront()
                    End If
                End If
            End If

        End If
    End Sub



    Private Sub frmGenerator_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'SaveListsToXML()
        SaveFormPosition(Me)
        'If Me.WindowState = FormWindowState.Normal Then
        '    SaveSetting("ADRIFT", "Generator", "Window Height", (Me.Height * 15).ToString)
        '    SaveSetting("ADRIFT", "Generator", "Window Width", (Me.Width * 15).ToString)
        'End If
    End Sub


    Private Sub UTMMain_BeforeToolActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.CancelableToolEventArgs) Handles UTMMain.BeforeToolActivate
        Debug.WriteLine(e.Tool.Key)
    End Sub

    Private Sub UTMMain_PropertyChanged(ByVal sender As Object, ByVal e As Infragistics.Win.PropertyChangedEventArgs) Handles UTMMain.PropertyChanged
        'call FindPropId on the ChangeInfo of the event args and pass in Infragistics.Win.UltraWinToolbars.PropertyIds.IsMinimized. 
        'If the PropChangeInfo returned is not null and its Source property is the Ribbon, its minimization has changed.
        Debug.WriteLine(e.ChangeInfo.PropId.ToString)
        Dim prop As Infragistics.Shared.PropChangeInfo = e.ChangeInfo.FindPropId(Infragistics.Win.UltraWinToolbars.PropertyIds.IsMinimized)
        If prop IsNot Nothing AndAlso prop.Source Is UTMMain.Ribbon Then
            SaveSetting("ADRIFT", "Generator", "RibbonMinimized", CInt(UTMMain.Ribbon.IsMinimized).ToString)
        End If
    End Sub



    Private Sub UTMMain_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UTMMain.ToolClick
        DoToolClick(e.Tool.Key, e.Tool.SharedProps.Caption, CStr(e.Tool.SharedProps.Tag))
    End Sub



    Private Sub DoToolClick(ByVal sKey As String, ByVal sCaption As String, ByVal sTag As String)

        'If sTag = "_LIST_" Then
        '    ListClick(sCaption)
        '    Exit Sub
        'End If

        If sTag = "_RECENT_" Then
            If CheckForSave() Then OpenAdventure(sKey)
            Exit Sub
        End If

        Select Case sKey
            Case "Location", "Object", "Task", "Event", "Character", "Variable", "Property", "Group", "Text Override", "Hint"
                sDestinationList = sKey.Replace("Property", "Propertie") & "s"
        End Select

        Select Case sKey
            Case "AboutGenerator"
                Dim fAbout As New AboutBox
                Try
                    fAbout.ShowDialog()
                Catch
                End Try

                'Case "mnuCreateNewList"
                '    CreateNewList()
                'Case "mnuDeleteList"
                '    DeleteList()
            Case "Properties"
                Properties()
            Case "Location"
                Dim fLocation As New frmLocation(New clsLocation, True)
            Case "Object"
                Dim fObject As New frmObject(New clsObject, True)
            Case "Task"
                Dim fTask As New frmTask(New clsTask, True)
            Case "Event"
                Dim fEvent As New frmEvent(New clsEvent, True)
            Case "Character"
                Dim fCharacter As New frmCharacter(New clsCharacter, True)
            Case "Variable"
                Dim fVariable As New frmVariable(New clsVariable, True)
            Case "Property"
                Dim fProperty As New frmProperty(New clsProperty, True)
            Case "Group"
                Dim fGroup As New frmGroup(New clsGroup, True)
            Case "Hint"
                Dim fHint As New frmHint(New clsHint, True)
            Case "Text Override"
                Dim fALR As New frmTextOverride(New clsALR)
            Case "UserFunction"
                Dim fUDF As New frmUserFunction(New clsUserFunction)
            Case "Synonym"
                Dim fSynonym As New frmSynonym(New clsSynonym)
            Case "mnuNew"
                NewAdventure()
            Case "mnuOpen"
                mnuOpen()
            Case "mnuSave"
                mnuSave()
            Case "mnuSaveAs"
                Adventure.BabelTreatyInfo.Stories(0).Identification.GenerateNewIFID()
                mnuSaveAs()
                'Case "mnuRenameList"
                '    CType(Me.ActiveMdiChild, frmList).Rename()
            Case "RunAdventure"
                If IO.File.Exists(BinPath(True) & "run500.exe") Then
                    If CheckForSave() Then System.Diagnostics.Process.Start(BinPath(True) & "run500.exe", Adventure.FullPath)
                Else
                    ErrMsg("Runner executable not found.")
                End If
                'Case "Tab Windows"
                '    TabWindows()
            Case "ImportModule"
                OpenModuleDialog(ofd)
            Case "ImportTrizbort"
                OpenTrizbortDialog(ofd)
            Case "LanguageResource"
                OpenALRDialog(ofd)
            Case "ExportLanguageResource"
                ExportLanguageResource()
            Case "ExportModule"
                ExportModule()
            Case "ExportBlorb"
                ExportBlorb()
            Case "ImportBlorb"
                Dim blorbImported As clsBlorb = OpenBlorbDialog(ofd)
                If blorbImported IsNot Nothing Then OutputBlorb(blorbImported)
                'blorbImported.Dispose()
            Case "Options"
                If fOptions Is Nothing Then
                    fOptions = New frmOptions
                Else
                    fOptions.Focus()
                End If
            Case "Settings"
                If fSettings Is Nothing Then
                    fSettings = New frmSettings
                Else
                    fSettings.Focus()
                End If
                If sTag = "Libraries" Then fSettings.tabsOptions.SelectedTab = fSettings.tabsOptions.Tabs(1)
            Case "Cut"
                'CutItem(CType(ActiveMdiChild, frmList).ItemList.lvwList.SelectedItems(0).SubItems(2).Text)
                If Form.ActiveForm Is fGenerator AndAlso ActiveFolder IsNot Nothing Then CutItems(ActiveFolder.SelectedKeys)
            Case "Copy"
                'CopyItem(CType(ActiveMdiChild, frmList).ItemList.lvwList.SelectedItems(0).SubItems(2).Text)
                If Form.ActiveForm Is fGenerator AndAlso ActiveFolder IsNot Nothing Then CopyItems(ActiveFolder.SelectedKeys)
            Case "Delete"
                If Form.ActiveForm Is fGenerator AndAlso ActiveFolder IsNot Nothing Then DeleteItems(ActiveFolder.SelectedKeys)
            Case "Paste"
                'PasteItem()
                If Form.ActiveForm Is fGenerator AndAlso ActiveFolder IsNot Nothing Then PasteItems()
            Case "Exit"
                Me.Close()
            Case "IntroductionWinning"
                Dim fIntro As New frmIntroWinning
            Case "iFictionRecord"
                ExportiFictionRecord()
            Case "ArrangeIcons"
                Me.LayoutMdi(MdiLayout.ArrangeIcons)
            Case "Cascade"
                'Me.LayoutMdi(MdiLayout.Cascade)
                Dim sizeMDI As Size
                For Each ctl As Control In Me.Controls
                    If TypeOf ctl Is MdiClient Then
                        sizeMDI = New Size(ctl.Size.Width - 4, ctl.Size.Height - 4)
                        Exit For
                    End If
                Next
                Dim iCount As Integer = Me.MdiChildren.Length - 1
                For i As Integer = 0 To iCount
                    Me.MdiChildren(i).Location = New Point(i * CInt(sizeMDI.Width / (iCount + 2)), i * 32)
                    Me.MdiChildren(i).Size = New Size(CInt(2 * sizeMDI.Width / (iCount + 2)), sizeMDI.Height - (32 * iCount + 1))
                    Me.MdiChildren(i).BringToFront()
                Next
            Case "CloseAllWindows"
                For i As Integer = Me.MdiChildren.Length - 1 To 0 Step -1
                    Me.MdiChildren(i).Close()
                Next
            Case "Tile"
                Dim sizeMDI As Size
                For Each ctl As Control In Me.Controls
                    If TypeOf ctl Is MdiClient Then
                        sizeMDI = New Size(ctl.Size.Width - 4, ctl.Size.Height - 4)
                        Exit For
                    End If
                Next
                If Me.MdiChildren.Length > 0 Then
                    Dim iCols As Integer = CInt(Math.Ceiling(Math.Sqrt(Me.MdiChildren.Length)))
                    Dim iRows As Integer = CInt(Math.Ceiling((Me.MdiChildren.Length) / iCols))
                    For iRow As Integer = 0 To iRows - 1
                        For iCol As Integer = 0 To iCols - 1
                            Dim i As Integer = iRow * iCols + iCol
                            If i < MdiChildren.Length Then
                                With MdiChildren(i)
                                    .Width = CInt(sizeMDI.Width / iCols)
                                    .Height = CInt(sizeMDI.Height / iRows)
                                    .Location = New Point(.Width * iCol, .Height * iRow)
                                    While .Location.X + .Width > sizeMDI.Width
                                        Dim iWidth As Integer = .Width
                                        .Width -= 1
                                        If iWidth = .Width Then Exit While ' Bug 8595
                                    End While
                                    While .Location.Y + .Height > sizeMDI.Height
                                        Dim iHeight As Integer = .Height
                                        .Height -= 1
                                        If iHeight = .Height Then Exit While
                                    End While
                                End With
                            End If
                        Next
                    Next
                End If
            Case "TileHorizontally", "TileVertically"
                Dim mc As MdiClient = Nothing
                For i As Integer = 0 To Me.Controls.Count - 1
                    If (Me.Controls(i).GetType().Equals(GetType(MdiClient))) Then
                        mc = CType(Me.Controls(i), MdiClient)
                    End If
                Next

                Dim iVisCount As Integer = 0
                For Each child As Form In MdiChildren
                    If child.Visible Then iVisCount += 1
                Next

                Dim iCount As Integer = 0
                Dim iSum As Integer = 0
                For Each frmChild As Form In MdiChildren
                    If frmChild.Visible Then
                        frmChild.WindowState = FormWindowState.Normal
                        If sKey = "TileHorizontally" Then
                            Dim iHeight As Integer = CInt(Math.Floor((mc.Height - 4) / iVisCount))
                            iSum += iHeight
                            frmChild.Size = New Size(mc.Width - 4, iHeight)
                            frmChild.Location = New Point(0, iCount * iHeight)
                            If iCount = iVisCount - 1 Then
                                frmChild.Height = frmChild.Height + mc.Height - iSum - 4
                            End If
                        Else
                            Dim iWidth As Integer = CInt(Math.Floor((mc.Width - 4) / iVisCount))
                            iSum += iWidth
                            frmChild.Size = New Size(iWidth, mc.Height - 4)
                            frmChild.Location = New Point(iCount * iWidth, 0)
                            If iCount = iVisCount - 1 Then
                                frmChild.Width = frmChild.Width + mc.Width - iSum - 4
                            End If
                        End If
                        iCount += 1
                    End If
                Next

            Case "Find"
                Dim frmFind As New SearchReplace
                If fSearch IsNot Nothing AndAlso Not fSearch.IsDisposed Then frmFind = fSearch Else frmFind = New SearchReplace
                frmFind.SetFind()
                frmFind.Owner = Me
                frmFind.Show()
                'Dim sFind As String = InputBox("Enter search string:", "Find text")
                'If sFind <> "" Then Search(sFind)

            Case "FindNext"
                If SearchOptions.sLastSearch <> "" Then Search(SearchOptions.sLastSearch)

            Case "Replace"
                Dim frmReplace As SearchReplace
                If fSearch IsNot Nothing AndAlso Not fSearch.IsDisposed Then frmReplace = fSearch Else frmReplace = New SearchReplace
                frmReplace.SetReplace()
                frmReplace.Owner = Me
                frmReplace.Show()
                'Dim sFind As String = InputBox("Enter search string:", "Replace text")
                'If sFind <> "" Then
                '    Dim sReplace As String = InputBox("Enter replace string:", "Replace text")
                '    If sReplace <> "" Then SearchAndReplace(sFind, sReplace)
                'End If

            Case "CreateExecutable"
                CreateExecutable()

            Case "ProtectAdventure"
                Dim fPassword As New Password
                With fPassword
                    .txtPassword.Text = ""
                    If sCaption = "Protect Adventure" Then
                        .Text = "Protect Adventure"
                        .lblText.Text = "Enter password to protect adventure with:"
                        If fPassword.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Dim sPass1 As String = .txtPassword.Text
                            If sPass1 <> "" Then
                                .lblText.Text = "Please confirm password:"
                                .txtPassword.Text = ""
                                If fPassword.ShowDialog = Windows.Forms.DialogResult.OK Then
                                    If sPass1 = .txtPassword.Text Then
                                        Adventure.Password = sPass1
                                        MessageBox.Show("Adventure is now password protected.", "Protect Adventure", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        fGenerator.UTMMain.Tools("ProtectAdventure").SharedProps.Caption = "Unprotect Adventure"
                                        fGenerator.UTMMain.Tools("ProtectAdventure").SharedProps.AppearancesLarge.Appearance.Image = My.Resources.imgLock32
                                    Else
                                        ErrMsg("Passwords do not match.  Adventure is not protected.")
                                    End If
                                End If
                            Else
                                ErrMsg("You cannot protect an adventure with a blank password!")
                            End If
                        End If
                    Else
                        .Text = "Unprotect Adventure"
                        .lblText.Text = "Enter existing password to remove it from the adventure:"
                        If fPassword.ShowDialog = Windows.Forms.DialogResult.OK Then
                            If .txtPassword.Text = Adventure.Password Then
                                Adventure.Password = ""
                                MessageBox.Show("Password has now been removed from adventure.", "Unprotect Adventure", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                fGenerator.UTMMain.Tools("ProtectAdventure").SharedProps.Caption = "Protect Adventure"
                                fGenerator.UTMMain.Tools("ProtectAdventure").SharedProps.AppearancesLarge.Appearance.Image = My.Resources.imgUnlock32
                            Else
                                ErrMsg("Incorrect password.  Adventure is still protected.")
                            End If
                        End If
                    End If
                End With

            Case "FolderList"
                For Each cp As Infragistics.Win.UltraWinDock.DockableControlPane In UDMGenerator.ControlPanes
                    If cp.Control Is FolderList1 Then
                        cp.Closed = False
                        UTMMain.Tools("FolderList").SharedProps.Enabled = False
                    End If
                Next

            Case "Map"
                For Each cp As Infragistics.Win.UltraWinDock.DockableControlPane In UDMGenerator.ControlPanes
                    If cp.Control Is Map1 Then
                        cp.Closed = False
                        UTMMain.Tools("Map").SharedProps.Enabled = False
                    End If
                Next

            Case "Register"
                Dim fRegister As New frmRegister
                fRegister.ShowDialog()

            Case "MapLocation"
                Map1.AddLocation()

            Case "MapPlan"
                Map1.PlanView()

            Case "MapCentre"
                Map1.CentreMap()

            Case "MapZoomIn"
                Map1.Zoom(True)

            Case "MapZoomOut"
                Map1.Zoom(False)

            Case "MapWarning"
                Map1.tabsMap.Tabs(UTMMain.Tools("MapWarning").Tag.ToString).Selected = True

            Case "Show Axes"
                Map1.ShowAxes = CType(UTMMain.Tools(sKey), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked

            Case "ShowGridLines"
                Map1.ShowGrid = CType(UTMMain.Tools(sKey), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked

            Case "NewPage"
                Map1.AddPage()

            Case "Print"
                Map1.Print()

            Case "Help"
                ShowHelp(Me)

            Case Else
                TODO("Tool Click : " & sKey)

        End Select

    End Sub


    Private Sub Properties()
        If Adventure Is Nothing Then Exit Sub

        Dim tElapsed As TimeSpan = New TimeSpan(0, 0, Adventure.iElapsed)
        Dim sElapsed As String
        If tElapsed.TotalDays > 24 Then
            sElapsed = Math.Floor(tElapsed.TotalDays) & " Day" & IIf(Math.Floor(tElapsed.TotalDays) > 1, "s ", " ").ToString & Math.Floor(tElapsed.Hours) & " Hour" & IIf(Math.Floor(tElapsed.Hours) > 1, "s", "").ToString
        ElseIf tElapsed.TotalHours > 1 Then
            sElapsed = Math.Floor(tElapsed.TotalHours) & " Hour" & IIf(Math.Floor(tElapsed.TotalHours) > 1, "s ", " ").ToString & Math.Floor(tElapsed.Minutes) & " Minute" & IIf(Math.Floor(tElapsed.Minutes) > 1, "s", "").ToString
        Else
            sElapsed = Math.Floor(tElapsed.TotalMinutes) & " Minute" & IIf(Math.Floor(tElapsed.TotalMinutes) > 1, "s", "").ToString
        End If

        Dim iTotal As Integer = 0
        Dim iTotalIncLibrary As Integer = 0

        Dim iCount As Integer = 0
        Dim sLocations As String = ""
        For Each l As clsLocation In Adventure.htblLocations.Values
            If Not l.IsLibrary Then iCount += 1
        Next
        If iCount = Adventure.htblLocations.Count Then
            sLocations = iCount.ToString
        Else
            sLocations = iCount & " (" & Adventure.htblLocations.Count & " including libraries)"
        End If
        iTotal += iCount
        iTotalIncLibrary += Adventure.htblLocations.Count

        iCount = 0
        Dim sObjects As String = ""
        For Each o As clsObject In Adventure.htblObjects.Values
            If Not o.IsLibrary Then iCount += 1
        Next
        If iCount = Adventure.htblObjects.Count Then
            sObjects = iCount.ToString
        Else
            sObjects = iCount & " (" & Adventure.htblObjects.Count & " including libraries)"
        End If
        iTotal += iCount
        iTotalIncLibrary += Adventure.htblObjects.Count

        iCount = 0
        Dim sTasks As String = ""
        For Each t As clsTask In Adventure.htblTasks.Values
            If Not t.IsLibrary Then iCount += 1
        Next
        If iCount = Adventure.htblTasks.Count Then
            sTasks = iCount.ToString
        Else
            sTasks = iCount & " (" & Adventure.htblTasks.Count & " including libraries)"
        End If
        iTotal += iCount
        iTotalIncLibrary += Adventure.htblTasks.Count

        iCount = 0
        Dim sCharacters As String = ""
        For Each c As clsCharacter In Adventure.htblCharacters.Values
            If Not c.IsLibrary Then iCount += 1
        Next
        If iCount = Adventure.htblCharacters.Count Then
            sCharacters = iCount.ToString
        Else
            sCharacters = iCount & " (" & Adventure.htblCharacters.Count & " including libraries)"
        End If
        iTotal += iCount
        iTotalIncLibrary += Adventure.htblCharacters.Count

        iCount = 0
        Dim sEvents As String = ""
        For Each e As clsEvent In Adventure.htblEvents.Values
            If Not e.IsLibrary Then iCount += 1
        Next
        If iCount = Adventure.htblEvents.Count Then
            sEvents = iCount.ToString
        Else
            sEvents = iCount & " (" & Adventure.htblEvents.Count & " including libraries)"
        End If
        iTotal += iCount
        iTotalIncLibrary += Adventure.htblEvents.Count

        iCount = 0
        Dim sVariables As String = ""
        For Each v As clsVariable In Adventure.htblVariables.Values
            If Not v.IsLibrary Then iCount += 1
        Next
        If iCount = Adventure.htblVariables.Count Then
            sVariables = iCount.ToString
        Else
            sVariables = iCount & " (" & Adventure.htblVariables.Count & " including libraries)"
        End If
        iTotal += iCount
        iTotalIncLibrary += Adventure.htblVariables.Count

        Dim sSize As String = GetFileSize(Adventure.FullPath)
        If sSize = "" Then sSize = "Not saved yet"

        MessageBox.Show("Size: " & sSize & vbCrLf & vbCrLf _
            & "Locations: " & sLocations & vbCrLf _
            & "Objects: " & sObjects & vbCrLf _
            & "Tasks: " & sTasks & vbCrLf _
            & "Characters: " & sCharacters & vbCrLf _
            & "Events: " & sEvents & vbCrLf _
            & "Variables: " & sVariables & vbCrLf & vbCrLf _
            & "Total Items: " & iTotal & " (" & iTotalIncLibrary & " including libraries)" & vbCrLf & vbCrLf _
            & "Total Editing Time: " & sElapsed & vbCrLf _
                , Adventure.Title & " Properties", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Public ReadOnly Property MDIFolders() As Generic.List(Of frmFolder)
        Get
            Dim folders As New Generic.List(Of frmFolder)
            For Each child As Form In MdiChildren
                If TypeOf child Is frmFolder Then folders.Add(CType(child, frmFolder))
            Next
            Return folders
        End Get
    End Property


    Private Sub CreateExecutable()

        Try
            If Not IsRegistered Then
                NotAvailable()
                Exit Sub
            End If

            If IO.File.Exists(BinPath & IO.Path.DirectorySeparatorChar & "run500.exe") Then
                If CheckForSave() Then
                    'System.Diagnostics.Process.Start(Application.StartupPath & "\run500.exe", Adventure.FullPath)
                    sfd.Filter = "Executables (*.exe)|*.exe|All Files (*.*)|*.*"
                    sfd.DefaultExt = "exe"
                    If sfd.FileName.Length > 3 AndAlso Not sfd.FileName.ToLower.EndsWith("exe") Then sfd.FileName = ""
                    sfd.ShowDialog()

                    If sfd.FileName <> "" Then
                        IO.File.Copy(BinPath & IO.Path.DirectorySeparatorChar & "run500.exe", sfd.FileName, True)
                        'SaveFile(sfd.FileName, True, New IO.FileInfo(Application.StartupPath & "\run500.exe").Length)
                        SaveBlorb(sfd.FileName, IO.FileMode.Append)

                        ' Write the size of Runner to the end of the file for reference later
                        Dim stmEXE As New IO.FileStream(sfd.FileName, IO.FileMode.Append)
                        Dim lLength As Long = New IO.FileInfo(BinPath & IO.Path.DirectorySeparatorChar & "run500.exe").Length
                        stmEXE.Write((New System.Text.UTF8Encoding).GetBytes(String.Format("{0:X6}", lLength)), 0, 6)
                        stmEXE.Close()
                    End If

                End If
            Else
                ErrMsg("Runner executable not found for packaging.")
            End If
        Catch ex As Exception
            ErrMsg("Unable to create executable", ex)
        End Try

    End Sub


    'Private Sub TabWindows()
    '    Me.UltraTabbedMdiManager1.Enabled = CType(Me.UTMMain.Tools("Tab Windows"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked
    'End Sub


    'Private Sub DeleteList()

    '    Dim frmSource As frmList = CType(Me.ActiveMdiChild, frmList)
    '    If frmSource Is Nothing Then Exit Sub

    '    If MessageBox.Show("Are you sure you wish to delete list '" & frmSource.Text & "'?", "Delete List", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
    '        ' Move all list items from this list to another one

    '        Dim SourceList As ListInfo = frmSource.ListInfo
    '        Dim DestList As ListInfo = Nothing

    '        For Each li As ListInfo In colLists
    '            If li.sName <> Me.ActiveMdiChild.Text Then
    '                DestList = li
    '                Exit For
    '            End If
    '        Next

    '        If Not DestList Is Nothing Then
    '            Dim frmDest As frmList = DestList.GetForm
    '            If Not frmDest Is Nothing Then
    '                For Each lvi As ListViewItem In frmSource.ItemList.lvwList.Items
    '                    frmSource.ItemList.lvwList.Items.Remove(lvi)
    '                    frmDest.ItemList.lvwList.Items.Add(lvi)
    '                Next
    '            End If
    '            ' Copy colKeys too
    '            For Each sKey As String In SourceList.arlKeys
    '                DestList.arlKeys.Add(sKey)
    '            Next

    '            frmSource.Visible = False
    '            frmSource.Dispose()

    '            colLists.Remove(SourceList.sName)
    '            UTMMain.Tools.Remove(UTMMain.Tools("_LIST_" & SourceList.sName))
    '            SourceList = Nothing

    '        Else
    '            ErrMsg("Sorry, you must have at least one defined list.")
    '        End If
    '    End If

    'End Sub

    'Private Sub CreateNewList()

    '    Dim sName As String = InputBox("Please enter name for new list", "New List", "")

    '    If sName <> "" Then

    '        If Not DoesListExist(sName) Then
    '            Dim NewList As New ListInfo(sName)
    '            With NewList
    '                '.sName = sName
    '                .bVisible = True
    '                .s = New Size(200, 500)
    '                .p = New Point(100, 20)
    '            End With
    '            colLists.Add(NewList, NewList.sName)

    '            Dim frmList As New frmList(NewList)
    '        Else
    '            ErrMsg("List already exists.")
    '        End If

    '    End If

    'End Sub

    'Private Function DoesListExist(ByVal sKey As String) As Boolean

    '    For Each li As ListInfo In colLists
    '        If li.sName = sKey Then Return True
    '    Next

    '    Return False

    'End Function

    Private WithEvents tmrSplash As New Timer
    Private Sub frmGenerator_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        tmrSplash.Interval = 3000
        tmrSplash.Start()
        If CBool(CInt(GetSetting("ADRIFT", "Shared", "AutoCheck", "1"))) Then CheckForUpdate()
    End Sub


    Private Sub tmrSplash_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrSplash.Tick
        fSplash.Close()
        tmrSplash.Enabled = False
    End Sub

    Private Sub UDMGenerator_AfterDockChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.PaneEventArgs) Handles UDMGenerator.AfterDockChange, UDMGenerator.AfterToggleDockState
        If Map1.ParentForm.Name = Me.Name Then
            UTMMain.Ribbon.ContextualTabGroups("ctgMapTools").Visible = True
            Map1.ToolStrip1.Visible = False
        Else
            UTMMain.Ribbon.ContextualTabGroups("ctgMapTools").Visible = False
            Map1.ToolStrip1.Visible = True
        End If
    End Sub

    Private Sub UDMGenerator_AfterPaneButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.PaneButtonEventArgs) Handles UDMGenerator.AfterPaneButtonClick
        If e.Button = Infragistics.Win.UltraWinDock.PaneButton.Close Then
            If Not Map1.Visible Then UTMMain.Ribbon.ContextualTabGroups("ctgMapTools").Visible = False
        End If
    End Sub

    Private Sub UDMGenerator_PaneActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.ControlPaneEventArgs) Handles UDMGenerator.PaneActivate
        'If e.Pane.Control Is Map1 AndAlso Not e.Pane.DockedState = Infragistics.Win.UltraWinDock.DockedState.Floating Then UTMMain.Ribbon.ContextualTabGroups("ctgMapTools").Visible = True
        If e.Pane.Control Is Map1 AndAlso UTMMain.Ribbon.SelectedTab.Key = "Home" Then
            ' Only do this if we click on the map - so we don't auto select the Map tab when the app gets focus for example            
            If Map1.PointToClient(MousePosition).X > 0 AndAlso Map1.PointToClient(MousePosition).Y > 0 AndAlso Map1.PointToClient(MousePosition).X < Map1.Width AndAlso Map1.PointToClient(MousePosition).Y < Map1.Height Then
                UTMMain.Ribbon.SelectedTab = UTMMain.Ribbon.Tabs("Map")
            End If
        End If
    End Sub

    Private Sub UDMGenerator_PaneDeactivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.ControlPaneEventArgs) Handles UDMGenerator.PaneDeactivate
        'If e.Pane.Control Is Map1 Then UTMMain.Ribbon.ContextualTabGroups("ctgMapTools").Visible = False
        If e.Pane.Control Is Map1 AndAlso UTMMain.Ribbon.SelectedTab.Key = "Map" Then UTMMain.Ribbon.SelectedTab = UTMMain.Ribbon.Tabs("Home")
    End Sub

    Private Sub UDMGenerator_PaneDisplayed(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.PaneDisplayedEventArgs) Handles UDMGenerator.PaneDisplayed
        Select Case True
            Case e.Pane.Control Is Map1
                UTMMain.Ribbon.ContextualTabGroups("ctgMapTools").Visible = True
        End Select
    End Sub

    Private Sub UDMGenerator_PaneHidden(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.PaneHiddenEventArgs) Handles UDMGenerator.PaneHidden
        Select Case True
            Case e.Pane.Control Is FolderList1
                If e.Pane.Closed Then UTMMain.Tools("FolderList").SharedProps.Enabled = True
            Case e.Pane.Control Is Map1
                If e.Pane.Closed Then UTMMain.Tools("Map").SharedProps.Enabled = True
                UTMMain.Ribbon.ContextualTabGroups("ctgMapTools").Visible = False
        End Select
    End Sub


    Private Function ControlInForm(ByVal ctrl As Control) As Boolean

        For Each cp As Infragistics.Win.UltraWinDock.DockableControlPane In UDMGenerator.ControlPanes
            If cp.Control Is ctrl Then Return Not cp.Closed
        Next
        'If ctrl Is Me Then
        '    Return True
        'ElseIf TypeOf ctrl Is Infragistics.Win.UltraWinDock.DockableControlPane Then ' MdiClient Then
        '    Return CType(ctrl, MdiClient).Visible
        'ElseIf ctrl.Parent Is Nothing Then
        '    Return False
        'Else
        '    Return ControlInForm(ctrl.Parent)
        'End If

    End Function


    Private Sub tmrElapsed_Tick(sender As System.Object, e As System.EventArgs) Handles tmrElapsed.Tick
        Dim iWhere As Integer = 0
        Try
            If Adventure IsNot Nothing Then
                Dim hWnd As IntPtr
                Dim ProcessID As Integer
                Dim CurrentThreadID As Integer
                Dim ActiveThreadID As Integer

                iWhere = 1
                hWnd = GetForegroundWindow
                iWhere = 2
                ActiveThreadID = GetWindowThreadProcessId(hWnd, ProcessID)
                iWhere = 3
                CurrentThreadID = GetCurrentThreadId
                iWhere = 4
                If CurrentThreadID = ActiveThreadID Then
                    Adventure.iElapsed += 1
                End If

            End If
        Catch ex As Exception
            ErrMsg("Error obtaining active thread ," & iWhere, ex)
        End Try
    End Sub


    Private Sub StatusBar1_PanelDoubleClick(sender As Object, e As Infragistics.Win.UltraWinStatusBar.PanelClickEventArgs) Handles StatusBar1.PanelDoubleClick

        If e.Panel Is StatusBar1.Panels(2) Then
            If Adventure.htblVariables.ContainsKey("MaxScore") Then
                Dim var As clsVariable = Adventure.htblVariables("MaxScore")
                var.EditItem()
            End If
        ElseIf e.Panel Is StatusBar1.Panels(3) Then
            SimpleMode = Not SimpleMode
        End If

    End Sub


    Private Sub miAddFolder_Click(sender As Object, e As EventArgs) Handles miAddFolder.Click

        Dim newFolder As New clsFolder

        If Adventure IsNot Nothing Then
            Adventure.dictFolders.Add(newFolder.Key, newFolder)
            Adventure.dictFolders("ROOT").Members.Add(newFolder.Key)
        End If        

        'Dim subitems() As Infragistics.Win.UltraWinListView.UltraListViewSubItem = {New Infragistics.Win.UltraWinListView.UltraListViewSubItem, New Infragistics.Win.UltraWinListView.UltraListViewSubItem, New Infragistics.Win.UltraWinListView.UltraListViewSubItem, New Infragistics.Win.UltraWinListView.UltraListViewSubItem}
        'subitems(0).Value = newFolder.Created
        'subitems(1).Value = newFolder.LastUpdated
        'subitems(2).Value = "Folder"
        'subitems(3).Value = newFolder.Key

        'Dim itmFolder As New Infragistics.Win.UltraWinListView.UltraListViewItem(newFolder.Name, subitems)
        'itmFolder.Key = newFolder.Key
        'itmFolder.Appearance.Image = My.Resources.imgFolderClosed16
        
        'Dim nodFolder As Infragistics.Win.UltraWinTree.UltraTreeNode = fGenerator.FolderList1.AddFolder(newFolder, fGenerator.FolderList1.treeFolders.GetNodeByKey("Desktop"))
        'nodFolder.Selected = True
        'fGenerator.FolderList1.OpenNewFolder(nodFolder.Key)
        'fGenerator.FolderList1.RenameFolder(nodFolder)

        Dim nodFolder As Infragistics.Win.UltraWinTree.UltraTreeNode = fGenerator.FolderList1.AddFolder(newFolder)
        nodFolder.Selected = True
        fGenerator.FolderList1.OpenNewFolder(nodFolder.Key)
        fGenerator.FolderList1.RenameFolder(nodFolder)

        For Each folderGUI As frmFolder In fGenerator.MDIFolders
            If folderGUI.Folder.folder.Members.Contains(newFolder.Key) Then
                folderGUI.Folder.AddSingleItem(newFolder.Key)
            End If
        Next

    End Sub

End Class

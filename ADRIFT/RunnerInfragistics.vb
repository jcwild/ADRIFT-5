Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolbars


Module RunnerInfragistics

    Public eStyle As Infragistics.Win.UltraWinToolbars.ToolbarStyle
    Public eColour2007 As Infragistics.Win.Office2007ColorScheme
    Public eColour2010 As Infragistics.Win.Office2010ColorScheme
    Public eColour2013 As Infragistics.Win.Office2013ColorScheme


    Public Sub SetWindowStyle(ByVal frmTarget As Form, Optional ByVal utm As UltraWinToolbars.UltraToolbarsManager = Nothing, Optional ByVal udm As UltraWinDock.UltraDockManager = Nothing)

        frmTarget.SuspendLayout()


        Select Case eStyle
            Case ToolbarStyle.Default
                If Not utm Is Nothing Then utm.Style = UltraWinToolbars.ToolbarStyle.Office2000
                If Not udm Is Nothing Then udm.WindowStyle = UltraWinDock.WindowStyle.Windows
            Case ToolbarStyle.Office2003
                If Not utm Is Nothing Then utm.Style = UltraWinToolbars.ToolbarStyle.Office2003
                If Not udm Is Nothing Then udm.WindowStyle = UltraWinDock.WindowStyle.Office2003
            Case ToolbarStyle.Office2007
                If Not utm Is Nothing Then utm.Style = UltraWinToolbars.ToolbarStyle.Office2007
                If Not udm Is Nothing Then udm.WindowStyle = UltraWinDock.WindowStyle.Office2007
            Case ToolbarStyle.Office2010
                If Not utm Is Nothing Then utm.Style = UltraWinToolbars.ToolbarStyle.Office2010
                If Not udm Is Nothing Then udm.WindowStyle = UltraWinDock.WindowStyle.Office2007
            Case ToolbarStyle.Office2013
                If Not utm Is Nothing Then utm.Style = UltraWinToolbars.ToolbarStyle.Office2013
                If Not udm Is Nothing Then udm.WindowStyle = UltraWinDock.WindowStyle.Office2007
            Case ToolbarStyle.VisualStudio2005
                If Not utm Is Nothing Then utm.Style = UltraWinToolbars.ToolbarStyle.VisualStudio2005
                If Not udm Is Nothing Then udm.WindowStyle = UltraWinDock.WindowStyle.VisualStudio2005
            Case Else
        End Select

        For Each c As Control In frmTarget.Controls
            SetControlStyle(c)
        Next

        frmTarget.ResumeLayout()

    End Sub


    Public Sub SetControlStyle(ByVal c As Control)

        'If TypeOf c Is UltraControlBase Then
        '    CType(c, UltraControlBase).StyleSetName = "c:\program files\Infragistics\NetAdvantage 2006 Volume 3 CLR 2.0\AppStylist\Styles\Office2007Blue.isl"
        'End If

        Dim dsElement As EmbeddableElementDisplayStyle = EmbeddableElementDisplayStyle.Default
        Dim vsStatusBar As UltraWinStatusBar.ViewStyle = UltraWinStatusBar.ViewStyle.Default
        Dim vsGroupBox As Misc.GroupBoxViewStyle = Misc.GroupBoxViewStyle.Default
        Dim vsTabControl As UltraWinTabControl.ViewStyle = UltraWinTabControl.ViewStyle.Default
        Dim gsCheck As GlyphStyle = GlyphStyle.Default


        Select Case eStyle
            Case ToolbarStyle.Default
                dsElement = EmbeddableElementDisplayStyle.Standard
                vsStatusBar = UltraWinStatusBar.ViewStyle.Standard
                vsGroupBox = Misc.GroupBoxViewStyle.Office2000
                vsTabControl = UltraWinTabControl.ViewStyle.Default
                gsCheck = GlyphStyle.Default
            Case ToolbarStyle.Office2003
                dsElement = EmbeddableElementDisplayStyle.Office2003
                vsStatusBar = UltraWinStatusBar.ViewStyle.Office2003
                vsGroupBox = Misc.GroupBoxViewStyle.Office2003
                vsTabControl = UltraWinTabControl.ViewStyle.Office2003
            Case ToolbarStyle.Office2007
                dsElement = EmbeddableElementDisplayStyle.Office2007
                vsStatusBar = UltraWinStatusBar.ViewStyle.Office2007
                vsGroupBox = Misc.GroupBoxViewStyle.Office2007
                gsCheck = GlyphStyle.Office2007
                vsTabControl = UltraWinTabControl.ViewStyle.Office2007
            Case ToolbarStyle.Office2010
                dsElement = EmbeddableElementDisplayStyle.Office2010
                vsStatusBar = UltraWinStatusBar.ViewStyle.Office2007
                vsGroupBox = Misc.GroupBoxViewStyle.Office2007
                gsCheck = GlyphStyle.Office2010
                vsTabControl = UltraWinTabControl.ViewStyle.Office2007
            Case ToolbarStyle.Office2013
                dsElement = EmbeddableElementDisplayStyle.Office2013
                vsStatusBar = UltraWinStatusBar.ViewStyle.Office2007
                vsGroupBox = Misc.GroupBoxViewStyle.Office2007
                gsCheck = GlyphStyle.Office2013
                vsTabControl = UltraWinTabControl.ViewStyle.Office2007
            Case ToolbarStyle.VisualStudio2005
                dsElement = EmbeddableElementDisplayStyle.VisualStudio2005
                vsStatusBar = UltraWinStatusBar.ViewStyle.VisualStudio2005
                vsGroupBox = Misc.GroupBoxViewStyle.VisualStudio2005
                vsTabControl = UltraWinTabControl.ViewStyle.VisualStudio2005
        End Select


        If TypeOf c Is UltraWinStatusBar.UltraStatusBar Then
            CType(c, UltraWinStatusBar.UltraStatusBar).ViewStyle = vsStatusBar
            'ElseIf TypeOf c Is Misc.UltraButton Then
            'CType(c, Misc.UltraButton).HotTracking = rSession.bHotTracking
        ElseIf TypeOf c Is Misc.UltraGroupBox Then
            CType(c, Misc.UltraGroupBox).ViewStyle = vsGroupBox
        ElseIf TypeOf c Is UltraWinProgressBar.UltraProgressBar Then
            CType(c, UltraWinProgressBar.UltraProgressBar).Style = UltraWinProgressBar.ProgressBarStyle.Default
        ElseIf TypeOf c Is UltraWinTabControl.UltraTabControl Then
            CType(c, UltraWinTabControl.UltraTabControl).ViewStyle = vsTabControl
        Else
            Debug.WriteLine(c.GetType.ToString)
        End If

        If Not c.Controls Is Nothing Then
            For Each cChild As Control In c.Controls
                SetControlStyle(cChild)
            Next
        End If

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

End Module

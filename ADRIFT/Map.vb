Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Map

    Private Shared iScale As Integer = 10
    Private Shared iOffsetX As Integer = 200
    Private Shared iOffsetY As Integer = 40 '25
    Private Shared iBoundX As Integer = 0
    Private Shared iBoundY As Integer = 0
    Private mPage As MapPage
    Private Property Page() As MapPage
        Get
            Return mPage
        End Get
        Set(ByVal value As MapPage)
            mPage = value
        End Set
    End Property
    Private mHotTrackedNode As MapNode = Nothing
    Private mHotTrackedLink As MapLink = Nothing
    Private mActiveNode As MapNode = Nothing
    Private mHotTrackedAnchor As Anchor = Nothing
    Private mNewLink As MapLink = Nothing
    Private mSelectedLink As MapLink = Nothing
    'Private bAllowMoveSelected As Boolean = False
    'Private bRenaming As Boolean = False
    'Private sPreviousName As String = ""
    Private bDragged As Boolean = False
    Private Planes As New MapPlanes
    Private sizeImage As Size ' Size of the image - for some reason www gets it wrong

    Private MAPBACKGROUND As Color = Color.FromArgb(230, 255, 255)
    Private NODEBACKGROUND As Color = Color.FromArgb(150, 200, 255)
    Private NODESELECTED As Color = Color.FromArgb(255, 255, 0)
    Private NODEBORDER As Color = Color.FromArgb(100, 150, 200)
    Private NODETEXT As Color = Color.FromArgb(0, 0, 0)
    Private LINKCOLOUR As Color = Color.FromArgb(70, 0, 0)
    Private LINKSELECTED As Color = Color.FromArgb(200, 150, 0)


    Private bLockMapCentre As Boolean
    Friend Property LockMapCentre() As Boolean
        Get
            Return bLockMapCentre
        End Get
        Set(ByVal value As Boolean)
            If value <> bLockMapCentre Then
                bLockMapCentre = value
                If bLockMapCentre Then LockPlayerCentre = False
#If Runner Then
#If Mono Or www Then

#Else
                CType(fRunner.UTMMain.Tools("CentreMapLock"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = bLockMapCentre
#End If

                SaveSetting("ADRIFT", "Runner", "CentreMapLock", CInt(value).ToString)
#End If
            End If
        End Set
    End Property


    Private bLockPlayerCentre As Boolean
    Friend Property LockPlayerCentre() As Boolean
        Get
            Return bLockPlayerCentre
        End Get
        Set(ByVal value As Boolean)
            If value <> bLockPlayerCentre Then
                bLockPlayerCentre = value
                If bLockPlayerCentre Then LockMapCentre = False
#If Runner Then
#If Mono Or www Then
#Else
                CType(fRunner.UTMMain.Tools("MapPlayerLock"), Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = bLockPlayerCentre
#End If
                SaveSetting("ADRIFT", "Runner", "MapPlayerLock", CInt(value).ToString)
#End If
            End If
        End Set
    End Property


    Private Class MapPlanes
        Inherits Generic.Dictionary(Of Integer, MapPlane)

        Private Sub CheckExists(ByVal Z As Integer)
            If Not ContainsKey(Z) Then
                Dim planeNew As New MapPlane(Z)
                Add(Z, planeNew)
            End If
        End Sub


        Public Function GetPoint2D(ByVal point As Point3D) As Point
            CheckExists(point.Z)
            Return Item(point.Z).GetPointOnPlane(point.X, point.Y)
        End Function
        Public Function GetPoint2D(ByVal X As Double, ByVal Y As Double, ByVal Z As Integer) As Point
            CheckExists(Z)
            Return Item(Z).GetPointOnPlane(X, Y)
        End Function


        Public Function GetMatrix(ByVal Z As Integer) As Matrix
            CheckExists(Z)
            Return Item(Z).matrix
        End Function

    End Class


    Private Class MapPlane

        Public Z As Integer
        Private pt0, pt1, pt2, pt3, pt4 As Point
        Private Const SIZE As Integer = 1000
        Friend matrix As Matrix

        Public Sub New(ByVal Z As Integer)

            ' We only need to calculate 3 of the points, because we are a parallellogram, so the 4th is trivial
            ' From these, we can interpolate any point on the plane

            pt1 = TranslateToScreen(New Point3D(0 - (0 * Z), 0, Z))
            pt2 = TranslateToScreen(New Point3D(SIZE - (0 * Z), 0, Z))
            pt3 = TranslateToScreen(New Point3D(SIZE - (0 * Z), SIZE - (0 * Z), Z))

            ' Create a matrix for any graphics transformations on our plane
            matrix = New Matrix()
            Dim dfRotationAngle As Double = Math.Atan((pt2.Y - pt1.Y) / (pt2.X - pt1.X)) ' in Radians            

            matrix.Translate(CSng(pt1.X), CSng(pt1.Y))

            Dim s1 As Integer = pt3.Y - pt2.Y
            Dim s2 As Integer = pt2.X - pt3.X
            Dim dfRotationPlusSquewAngle As Double = Math.Atan(s2 / s1)
            Dim dfSquewAngle As Double = dfRotationPlusSquewAngle - dfRotationAngle
            Dim dfYY As Double = Math.Sqrt(s1 ^ 2 + s2 ^ 2) ' Length of line of what was height
            Dim dfXX As Double = Math.Sqrt((pt2.X - pt1.X) ^ 2 + (pt2.Y - pt1.Y) ^ 2) ' Length of line of what was width
            Dim dfSquewLength As Double = Math.Sin(dfSquewAngle) * dfYY
            Dim dfPreSquewHeight As Double = Math.Cos(dfSquewAngle) * dfYY
            Dim dfXShear As Single = CSng(-dfSquewLength / dfPreSquewHeight)

            matrix.Rotate(CSng(dfRotationAngle * (180 / Math.PI)))

            If Not Double.IsInfinity(dfXShear) AndAlso Not Double.IsNaN(dfXShear) Then matrix.Shear(dfXShear, 0)

            Dim dfXScale As Single = CSng(dfXX / SIZE / iScale)
            Dim dfYScale As Single = CSng(dfPreSquewHeight / SIZE / iScale)
            If dfXScale <> 0 OrElse dfYScale <> 0 Then matrix.Scale(dfXScale, dfYScale)
            'Debug.WriteLine(String.Format("Translation: {0}, {1}, Rotation: {2}, Scale: {3}, {4}", pt1.X, pt2.X, dfRotationAngle, dfXScale, dfYScale))

        End Sub


        Public Function GetPointOnPlane(ByVal X As Integer, ByVal Y As Integer) As Point

            Dim iX1 As Integer = (pt2.X - pt1.X) * X '- (Z * 50000)
            Dim iY1 As Integer = (pt2.Y - pt1.Y) * X ' - (Z * 50000)
            Dim iX2 As Integer = (pt3.X - pt2.X) * Y '+ (Z * 50000) ' + (Z * 50000)
            Dim iY2 As Integer = (pt3.Y - pt2.Y) * Y '+ (Z * 50000) ' + (Z * 50000)

            Return New Point(pt1.X + CInt((iX1 + iX2) / SIZE), pt1.Y + CInt((iY1 + iY2) / SIZE))

        End Function
        Public Function GetPointOnPlane(ByVal X As Double, ByVal Y As Double) As Point

            Dim dfX1 As Double = (pt2.X - pt1.X) * X '- (Z * 50000)
            Dim dfY1 As Double = (pt2.Y - pt1.Y) * X '- (Z * 50000)
            Dim dfX2 As Double = (pt3.X - pt2.X) * Y '+ (Z * 50000) '+ (Z * 50000)
            Dim dfY2 As Double = (pt3.Y - pt2.Y) * Y '+ (Z * 50000) '+ (Z * 50000)

            Return New Point(pt1.X + CInt((dfX1 + dfX2) / SIZE), pt1.Y + CInt((dfY1 + dfY2) / SIZE))

        End Function

    End Class


    Private Class clsSelectedNodes
        Inherits Generic.List(Of MapNode)

        ' Returns True if new item added
        Shadows Function Add(ByVal item As MapNode, Optional ByVal bRefresh As Boolean = True) As Boolean
            If Not MyBase.Contains(item) Then
                MyBase.Add(item)
                RefreshMap(bRefresh)
                Return True
            Else
                Return False
            End If
        End Function

        Shadows Sub Remove(ByVal item As MapNode, Optional ByVal bRefresh As Boolean = True)
            If MyBase.Contains(item) Then
                MyBase.Remove(item)
                RefreshMap(bRefresh)
            End If
        End Sub

        Shadows Sub RemoveAt(ByVal index As Integer, Optional ByVal bRefresh As Boolean = True)
            If index < MyBase.Count Then
                MyBase.RemoveAt(index)
                RefreshMap(bRefresh)
            End If
        End Sub

        Private Sub RefreshMap(ByVal bRefresh As Boolean)
#If Generator Then
            If bRefresh Then fGenerator.Map1.imgMap.Refresh()
#End If
        End Sub

    End Class


    Private SelectedNodes As New clsSelectedNodes

    Private bShowAxes As Boolean = True
    Public Property ShowAxes() As Boolean
        Get
#If Runner Then
            Return False
#Else
            Return bShowAxes
#End If
        End Get
        Set(ByVal value As Boolean)
            If value <> bShowAxes Then
                bShowAxes = value
                imgMap.Refresh()
                SaveSetting("ADRIFT", "Generator", "ShowAxes", CInt(bShowAxes).ToString)
            End If
        End Set
    End Property

    Private bShowGrid As Boolean = True
    Public Property ShowGrid() As Boolean
        Get
#If Runner Then
            Return False
#Else
            Return bShowGrid
#End If
        End Get
        Set(ByVal value As Boolean)
            If value <> bShowGrid Then
                bShowGrid = value
                imgMap.Refresh()
                SaveSetting("ADRIFT", "Generator", "ShowGrid", CInt(bShowGrid).ToString)
            End If
        End Set
    End Property

    Private Property HotTrackedNode() As MapNode
        Get
            Return mHotTrackedNode
        End Get
        Set(ByVal value As MapNode)
            If value IsNot mHotTrackedNode Then
                mHotTrackedNode = value
                imgMap.Refresh()
            End If
        End Set
    End Property


    Private Property HotTrackedLink() As MapLink
        Get
            Return mHotTrackedLink
        End Get
        Set(ByVal value As MapLink)
            If value IsNot mHotTrackedLink Then
                mHotTrackedLink = value
                imgMap.Refresh()
            End If
        End Set
    End Property


    Private Property NewLink() As MapLink
        Get
            Return mNewLink
        End Get
        Set(ByVal value As MapLink)
            If value IsNot mNewLink Then
                If mNewLink IsNot Nothing Then
                    ' Hide the anchors
                    Dim nodeSource As MapNode = Page.GetNode(mNewLink.sSource)
                    If nodeSource IsNot ActiveNode Then nodeSource.Anchors(mNewLink.eSourceLinkPoint).Visible = False
                    Dim nodeDest As MapNode = Page.GetNode(mNewLink.sDestination)
                    If nodeDest IsNot Nothing AndAlso nodeDest IsNot ActiveNode Then nodeDest.Anchors(mNewLink.eDestinationLinkPoint).Visible = False
                End If
                mNewLink = value
                If SelectedLink Is value Then SelectedLink = Nothing
                imgMap.Refresh()
            End If
        End Set
    End Property


    Private Property SelectedLink() As MapLink
        Get
            Return mSelectedLink
        End Get
        Set(ByVal value As MapLink)
            If value IsNot mSelectedLink Then
                If mSelectedLink IsNot Nothing Then
                    ' Hide the anchors
                    Dim nodeSource As MapNode = Page.GetNode(mSelectedLink.sSource)
                    If nodeSource IsNot Nothing AndAlso nodeSource IsNot ActiveNode Then nodeSource.Anchors(mSelectedLink.eSourceLinkPoint).Visible = False
                    Dim nodeDest As MapNode = Page.GetNode(mSelectedLink.sDestination)
                    If nodeDest IsNot Nothing AndAlso nodeDest IsNot ActiveNode AndAlso nodeDest.Anchors.ContainsKey(mSelectedLink.eDestinationLinkPoint) Then nodeDest.Anchors(mSelectedLink.eDestinationLinkPoint).Visible = False
                End If
                mSelectedLink = value
                If value IsNot Nothing Then ActiveNode = Nothing
                imgMap.Refresh()
            End If
        End Set
    End Property


    Private Property HotTrackedAnchor() As Anchor
        Get
            Return mHotTrackedAnchor
        End Get
        Set(ByVal value As Anchor)
            If value IsNot mHotTrackedAnchor Then
                mHotTrackedAnchor = value
                imgMap.Refresh()
            End If
        End Set
    End Property


    Private Property ActiveNode() As MapNode
        Get
            Return mActiveNode
        End Get
        Set(ByVal value As MapNode)
            If value IsNot mActiveNode Then
                mActiveNode = value
                If value IsNot Nothing Then RecalculateNode(value)
                For Each node As MapNode In Page.Nodes
                    If node IsNot ActiveNode AndAlso node.Anchors.Count > 0 Then
                        'node.Anchors.Clear()
                        For Each a As Anchor In node.Anchors.Values
                            a.Visible = False
                        Next
                        'RecalculateNode(node)
                    End If
                Next
                If value IsNot Nothing Then SelectedLink = Nothing
                'bAllowMoveSelected = False
                'bRenaming = False
                txtRename.Visible = False
            End If
            If value IsNot Nothing AndAlso Not SelectedNodes.Add(value) Then imgMap.Refresh()
        End Set
    End Property



    Private oMap As clsMap
    Public Property Map() As clsMap
        Get
            Return oMap
        End Get
        Set(ByVal value As clsMap)
            oMap = value
            LoadMap()
        End Set
    End Property


    Private bLoading As Boolean = False
    Private Sub LoadMap()

        Try
            bLoading = True
#If Mono Then
        tabsMap.TabPages.Clear()
#ElseIf Not www Then
            Try
                tabsMap.Tabs.Clear()
            Catch
            End Try
#End If

            SelectedLink = Nothing
            ActiveNode = Nothing
            NewLink = Nothing
            Page = Nothing

            If Map Is Nothing Then Exit Sub
            For Each iPage As Integer In Map.Pages.Keys
#If Mono Then
            tabsMap.TabPages.Add(iPage.ToString, Map.Pages(iPage).Label) ' User can rename the pages
            tabsMap.TabPages.RemoveByKey(iPage.ToString) ' .Visible = False
#ElseIf Not www Then
                tabsMap.Tabs.Add(iPage.ToString, Map.Pages(iPage).Label) ' User can rename the pages
#If Runner Then
            tabsMap.Tabs(iPage.ToString).Visible = False
#End If
#End If
                If Page Is Nothing Then Page = Map.Pages(iPage)
            Next
            If Page IsNot Nothing Then
                CentreMap()
                'RecalculateNodes()
            End If
            bLoading = False
#If Mono OrElse www Then
        If Map.SelectedPage <> "" AndAlso tabsMap.TabPages.ContainsKey(Map.SelectedPage) Then tabsMap.SelectedTab = tabsMap.TabPages(Map.SelectedPage)
        If tabsMap.SelectedTab IsNot Nothing Then
            'tabsMap.SelectedTab.Controls.Add(Me.imgMap)
            imgMap.Parent = tabsMap.SelectedTab
        ElseIf tabsMap.TabPages.Count > 0 Then
            imgMap.Parent = tabsMap.TabPages(0)
        Else
            imgMap.Parent = tabsMap.Parent
        End If
#Else
            If Map.SelectedPage <> "" AndAlso tabsMap.Tabs.Exists(Map.SelectedPage) Then tabsMap.SelectedTab = tabsMap.Tabs(Map.SelectedPage)
#End If
        Catch ex As Exception
            ErrMsg("Error loading map", ex)
        End Try

    End Sub


    Private Sub imgMap_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles imgMap.MouseClick

        imgMap.Focus()

#If Generator Then
        If Not bDragged Then ' e.Button = Windows.Forms.MouseButtons.Left AndAlso
            If HotTrackedAnchor IsNot Nothing Then
                If TypeOf HotTrackedAnchor.Parent Is MapNode Then
                    Dim parNode As MapNode = CType(HotTrackedAnchor.Parent, MapNode)
                    If NewLink IsNot Nothing Then
                        ' We are selecting an end-point
                        If Not (NewLink.sSource Is Nothing OrElse parNode.Key = NewLink.sSource AndAlso HotTrackedAnchor.Direction = NewLink.eSourceLinkPoint) Then ' HotTrackedAnchor.Parent.Key IsNot NewLink.sDestination AndAlso HotTrackedAnchor.Direction <> NewLink.eSourceLinkPoint Then
                            ' Different point
                            NewLink.sDestination = parNode.Key
                            NewLink.eDestinationLinkPoint = HotTrackedAnchor.Direction
                            ReDim NewLink.OrigMidPoints(-1)
                            parNode.Anchors(HotTrackedAnchor.Direction).HasLink = True
                            Page.GetNode(NewLink.sSource).Anchors(NewLink.eSourceLinkPoint).HasLink = True
                            HotTrackedAnchor.Visible = False
                            ' Add the link in the locations
                            ' If the destination link point has an outgoing route, then don't make it duplex
                            Adventure.htblLocations(NewLink.sSource).arlDirections(NewLink.eSourceLinkPoint).LocationKey = NewLink.sDestination
                            If Adventure.htblLocations(NewLink.sDestination).arlDirections(NewLink.eDestinationLinkPoint).LocationKey = "" Then
                                Adventure.htblLocations(NewLink.sDestination).arlDirections(NewLink.eDestinationLinkPoint).LocationKey = NewLink.sSource
                                NewLink.Duplex = True
                            Else
                                NewLink.Duplex = False
                            End If
                            Adventure.Changed = True

                            NewLink = Nothing
                        Else
                            ' Same point - just remove the link
                            RemoveLink(NewLink)
                        End If
                        ActiveNode = Nothing
                    Else
                        ' Select any link attached to this anchor
                        Dim link As MapLink = Nothing
                        If parNode.Links.ContainsKey(HotTrackedAnchor.Direction) Then
                            link = parNode.Links(HotTrackedAnchor.Direction)
                        Else
                            ' Look for a link terminating here
                            For Each node As MapNode In Page.Nodes
                                For Each linkOther As MapLink In node.Links.Values
                                    If linkOther.sDestination = parNode.Key AndAlso linkOther.eDestinationLinkPoint = HotTrackedAnchor.Direction Then
                                        link = linkOther
                                        Exit For
                                    End If
                                Next
                            Next
                        End If
                        SelectedLink = link
                        If e.Button = Windows.Forms.MouseButtons.Right AndAlso SelectedLink IsNot Nothing Then cmsLink.Show(imgMap, imgMap.PointToClient(MousePosition))
                        imgMap.Refresh()
                    End If
                Else
                    ' Link anchor

                End If
            End If

            If e.Button = Windows.Forms.MouseButtons.Left Then
                If HotTrackedNode Is Nothing Then
                    SelectedNodes.Clear()
                    ActiveNode = Nothing
                End If
                If HotTrackedAnchor Is Nothing Then SelectedLink = Nothing
                imgMap.Refresh()
            End If

        End If

#End If

    End Sub


    Private Sub imgMap_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles imgMap.MouseDoubleClick
#If Generator Then
        fGenerator.sDestinationList = ""
#End If        
        If HotTrackedAnchor IsNot Nothing Then
            If TypeOf HotTrackedAnchor.Parent Is MapNode Then
                Dim nodParent As MapNode = CType(HotTrackedAnchor.Parent, MapNode)

                If nodParent.Links.ContainsKey(HotTrackedAnchor.Direction) Then
                    RemoveLink(nodParent.Links(HotTrackedAnchor.Direction))
                Else
                    ' Check to see if a link exists from another location - if so, edit that link
                    For Each node As MapNode In Map.Pages(nodParent.Page).Nodes
                        For Each link As MapLink In node.Links.Values
                            If link.sDestination = nodParent.Key AndAlso link.eDestinationLinkPoint = HotTrackedAnchor.Direction Then
                                nodParent = node
                                HotTrackedAnchor = node.Anchors(link.eSourceLinkPoint)
                                RemoveLink(node.Links(link.eSourceLinkPoint))
                                Exit For
                            End If
                        Next
                    Next
                End If

                NewLink = New MapLink
                NewLink.sSource = nodParent.Key
                NewLink.eSourceLinkPoint = HotTrackedAnchor.Direction
                NewLink.Duplex = True
                If nodParent.Links.ContainsKey(NewLink.eSourceLinkPoint) Then
                    NewLink = nodParent.Links(NewLink.eSourceLinkPoint)
                    NewLink.Anchors.Clear()
                    ReDim NewLink.OrigMidPoints(-1)
                Else
                    nodParent.Links.Add(NewLink.eSourceLinkPoint, NewLink)
                End If
                For d As DirectionsEnum = DirectionsEnum.NorthWest To DirectionsEnum.North Step CType(-1, DirectionsEnum)
                    If d <> HotTrackedAnchor.Direction AndAlso nodParent.Anchors.ContainsKey(d) Then nodParent.Anchors(d).Visible = False
                Next
                RecalculateLinks(nodParent)
            End If
        ElseIf HotTrackedNode IsNot Nothing Then
            EditLocation()
        Else
            AddNode()
        End If
    End Sub


    Private Sub AddNode(Optional ByVal bCentre As Boolean = False)

        Dim loc As New clsLocation
        loc.Key = loc.GetNewKey
        loc.ShortDescription = New Description("New Location")
        Adventure.htblLocations.Add(loc, loc.Key)

        Dim node As New MapNode
        Dim Z As Integer = 0
        If ActiveNode IsNot Nothing Then Z = ActiveNode.Location.Z
        Dim pt As Point3D
        If Not bCentre Then
            pt = MouseTo3DCoords(Z)
        Else
            Dim ptCentre As New Point(imgMap.Location.X + CInt(sizeImage.Width / 2), imgMap.Location.Y + CInt(sizeImage.Height / 2))
            Dim iX As Integer = ptCentre.X + iBoundX
            Dim iY As Integer = ptCentre.Y + iBoundY
            Dim pt2 As Point = ConvertScreento3D(New Point(iX, iY), Z * iScale)

            pt = New Point3D(CInt(pt2.X / iScale), CInt(pt2.Y / iScale), Z)
        End If

        node.Location.X = CInt(pt.X - node.Width / 2)
        node.Location.Y = CInt(pt.Y - node.Height / 2)
        node.Location.Z = Z
        'End If
        node.Key = loc.Key
        node.Text = loc.ShortDescriptionSafe ' StripCarats(ReplaceALRs(loc.ShortDescription.ToString))
        node.Page = Page.iKey

        Page.AddNode(node)
        ActiveNode = node

        RecalculateNode(node)
        imgMap.Refresh()

        UpdateLocDescription(loc.Key, loc.ShortDescription.ToString)

        RenameNode()
#If Generator Then
        Adventure.Changed = True
#End If

    End Sub


    Private Sub UpdateLocDescription(ByVal sKey As String, ByVal sShortDesc As String)
#If Generator Then
        UpdateListItem(sKey, sShortDesc)
#End If
    End Sub
    Private Sub EditLocation()
        If SelectedNodes IsNot Nothing AndAlso SelectedNodes.Count = 1 Then
            Dim loc As clsLocation
            loc = Adventure.htblLocations(SelectedNodes(0).Key)
            If loc Is Nothing Then Exit Sub
            loc.EditItem()
        End If
    End Sub

    Private Sub imgMap_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgMap.MouseEnter
        'imgMap.Focus()
    End Sub


    Friend Sub PaintMe(ByVal size As Size) ' Called from www

        LockPlayerCentre = True

        If size <> sizeImage Then
            'If imgMap.Image.Size <> size OrElse imgMap.Size <> size Then
            imgMap.Image = New Bitmap(size.Width, size.Height)
            imgMap.Size = size
            sizeImage = size
            CentreMap()
        End If
        'If Me.Size <> size Then Me.Size = size
        'If imgMap.Size <> size Then imgMap.Size = size

        Dim g As Graphics = Graphics.FromImage(imgMap.Image)
        g.Clear(MAPBACKGROUND)
        RecalculateNodes()

        'CentreMap()
        'iBoundY = -(size.Height / 2)
        'iBoundX = -(size.Width / 2)
        'RecalculateNodes()
        imgMap_Paint(Nothing, New PaintEventArgs(g, New Rectangle(0, 0, size.Width, size.Height)))
    End Sub
    Private Sub imgMap_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles imgMap.Paint

        If Page Is Nothing Then Exit Sub

        PaintGraphics(e.Graphics)
    End Sub
    Private Sub PaintGraphics(ByVal gfx As Graphics)

#If Not www Then
        If MouseButtons = Windows.Forms.MouseButtons.Left AndAlso (Control.ModifierKeys And Keys.Shift) > 0 Then
            Dim penLasso As New Pen(Color.Black, 1)
            penLasso.DashStyle = DashStyle.DashDot
            Dim x1 As Integer = Math.Min(ptStartLasso.X, ptEndLasso.X)
            Dim y1 As Integer = Math.Min(ptStartLasso.Y, ptEndLasso.Y)
            Dim x2 As Integer = Math.Max(ptStartLasso.X, ptEndLasso.X)
            Dim y2 As Integer = Math.Max(ptStartLasso.Y, ptEndLasso.Y)
            gfx.DrawRectangle(penLasso, x1, y1, Math.Abs(x1 - x2), Math.Abs(y1 - y2))
        End If
#End If

        With Page
            gfx.SmoothingMode = SmoothingMode.HighQuality ' SmoothingMode.HighQuality            
            If ShowGrid Then DrawGrid(gfx)
            If ShowAxes Then DrawAxes(gfx)
            For Each node As MapNode In .Nodes
                DrawNode(gfx, node)
            Next
        End With

    End Sub


    Private Sub RecalculateNodes(Optional ByVal iPage As Integer = -1)
        If Map IsNot Nothing AndAlso Map.Pages.Count > 0 AndAlso tabsMap.SelectedTab IsNot Nothing Then
            If iPage = -1 Then
#If Mono Then 'Or www Then
                iPage = SafeInt(tabsMap.SelectedTab.Name)
#ElseIf Not www Then
                iPage = SafeInt(tabsMap.SelectedTab.Key)
#Else
                Dim node As MapNode = Map.FindNode(Adventure.Player.Location.LocationKey)
                If node Is Nothing Then Exit Sub

                iPage = node.Page
                If Page Is Nothing OrElse Page.iKey <> iPage Then
                    Page = Map.Pages(iPage)
                    CentreMap()
                End If
#End If
            End If
            If Map.Pages.ContainsKey(iPage) Then
                With Map.Pages(iPage)
                    Planes.Clear()
                    For Each node As MapNode In .Nodes
                        RecalculateNode(node, False)
                    Next
                    For Each node As MapNode In .Nodes
                        RecalculateLinks(node)
                    Next
                    ' Need to call RecalculateLinks on any nodes on a different page that link to us
                    For Each node As MapNode In .Nodes
                        If node.bHasIn OrElse node.bHasOut Then
                            For Each p As MapPage In Map.Pages.Values
                                If p.iKey <> iPage Then
                                    For Each nodeOther As MapNode In p.Nodes
                                        For Each l As MapLink In nodeOther.Links.Values
                                            If l.sDestination = node.Key Then
                                                RecalculateLinks(nodeOther)
                                            End If
                                        Next
                                    Next
                                End If
                            Next
                        End If
                    Next
                End With
            End If
        End If
    End Sub


    Private Shared Function TranslateToScreen(ByVal pt3D As Point3D) As Point

        Dim X As Integer = pt3D.X * iScale
        Dim Y As Integer = pt3D.Y * iScale
        Dim Z As Integer = pt3D.Z * iScale

        Dim pt2D As Point = Convert3DtoScreen(X, Y, Z)
        pt2D.X -= iBoundX
        pt2D.Y -= iBoundY

        Return pt2D

    End Function


    Private Function GetLinkPoint(ByVal node As MapNode, ByVal d As DirectionsEnum, Optional ByVal nodDest As MapNode = Nothing) As Point

        Dim pt As Point

        Select Case d
            Case DirectionsEnum.North
                'pt = New Point(node.Points(0).X + CInt((node.Points(1).X - node.Points(0).X) / 2), node.Points(0).Y)
                pt = Planes.GetPoint2D(node.Location.X + node.Width / 2, node.Location.Y, node.Location.Z)
            Case DirectionsEnum.NorthEast
                pt = node.Points(1)
            Case DirectionsEnum.East
                'pt = New Point(node.Points(1).X + CInt((node.Points(2).X - node.Points(1).X) / 2), node.Points(1).Y + CInt((node.Points(2).Y - node.Points(1).Y) / 2))
                pt = Planes.GetPoint2D(node.Location.X + node.Width, node.Location.Y + node.Height / 2, node.Location.Z)
            Case DirectionsEnum.SouthEast
                pt = node.Points(2)
            Case DirectionsEnum.South
                'pt = New Point(node.Points(3).X + CInt((node.Points(2).X - node.Points(3).X) / 2), node.Points(2).Y)
                pt = Planes.GetPoint2D(node.Location.X + node.Width / 2, node.Location.Y + node.Height, node.Location.Z)
            Case DirectionsEnum.SouthWest
                pt = node.Points(3)
            Case DirectionsEnum.West
                'pt = New Point(node.Points(0).X + CInt((node.Points(3).X - node.Points(0).X) / 2), node.Points(0).Y + CInt((node.Points(3).Y - node.Points(0).Y) / 2))
                pt = Planes.GetPoint2D(node.Location.X, node.Location.Y + node.Height / 2, node.Location.Z)
            Case DirectionsEnum.NorthWest
                pt = node.Points(0)
            Case DirectionsEnum.Up, DirectionsEnum.Down
                'pt = New Point(node.Points(0).X + CInt((node.Points(2).X - node.Points(0).X) / 2), node.Points(0).Y + CInt((node.Points(2).Y - node.Points(0).Y) / 2))
                pt = Planes.GetPoint2D(node.Location.X + node.Width / 2, node.Location.Y + node.Height / 2, node.Location.Z)
            Case DirectionsEnum.In
                ' This will depend where the destination is
                If nodDest IsNot Nothing AndAlso nodDest.Page = node.Page Then
                    If nodDest.Location.X > node.Location.X + node.Width Then
                        pt = Planes.GetPoint2D(node.Location.X + node.Width, node.Location.Y + node.Height / 4, node.Location.Z)
                        node.eInEdge = DirectionsEnum.East
                    ElseIf nodDest.Location.X + nodDest.Width < node.Location.X Then
                        pt = Planes.GetPoint2D(node.Location.X, node.Location.Y + (3 * node.Height / 4), node.Location.Z)
                        node.eInEdge = DirectionsEnum.West
                    ElseIf nodDest.Location.Y > node.Location.Y Then
                        pt = Planes.GetPoint2D(node.Location.X + (3 * node.Width / 4), node.Location.Y + node.Height, node.Location.Z)
                        node.eInEdge = DirectionsEnum.South
                    Else
                        pt = Planes.GetPoint2D(node.Location.X + node.Width / 4, node.Location.Y, node.Location.Z)
                        node.eInEdge = DirectionsEnum.North
                    End If
                Else
                    'pt = Planes.GetPoint2D(node.Location.X + node.Width, node.Location.Y + node.Height / 4, node.Location.Z)
                End If
            Case DirectionsEnum.Out
                '' This will depend where the destination is
                'If nodDest IsNot Nothing AndAlso nodDest.Page = node.Page Then
                'Else
                '    pt = Planes.GetPoint2D(node.Location.X + node.Width, node.Location.Y + (3 * node.Height / 4), node.Location.Z)
                'End If
                If nodDest IsNot Nothing AndAlso nodDest.Page = node.Page Then
                    If nodDest.Location.X > node.Location.X + node.Width Then
                        pt = Planes.GetPoint2D(node.Location.X + node.Width, node.Location.Y + (3 * node.Height / 4), node.Location.Z)
                        node.eOutEdge = DirectionsEnum.East
                    ElseIf nodDest.Location.X + nodDest.Width < node.Location.X Then
                        pt = Planes.GetPoint2D(node.Location.X, node.Location.Y + node.Height / 4, node.Location.Z)
                        node.eOutEdge = DirectionsEnum.West
                    ElseIf nodDest.Location.Y > node.Location.Y Then
                        pt = Planes.GetPoint2D(node.Location.X + node.Width / 4, node.Location.Y + node.Height, node.Location.Z)
                        node.eOutEdge = DirectionsEnum.South
                    Else
                        pt = Planes.GetPoint2D(node.Location.X + (3 * node.Width / 4), node.Location.Y, node.Location.Z)
                        node.eOutEdge = DirectionsEnum.North
                    End If
                Else
                    'pt = Planes.GetPoint2D(node.Location.X + node.Width, node.Location.Y + node.Height / 4, node.Location.Z)
                End If
        End Select

        Return pt

    End Function


    Private Sub RecalculateLinks(ByVal node As MapNode)

        If Map Is Nothing Then Exit Sub

        For Each link As MapLink In node.Links.Values
            With link
                If Page Is Nothing Then Page = Map.Pages(node.Page)
                Dim nodDest As MapNode = Page.GetNode(.sDestination)
                Dim ptStart As Point = GetLinkPoint(node, .eSourceLinkPoint, nodDest)
                Dim ptEnd As Point
                Dim iDist As Integer


                If nodDest IsNot Nothing Then
                    ptEnd = GetLinkPoint(nodDest, .eDestinationLinkPoint, node)
                    iDist = CInt(Math.Sqrt(Math.Max(Math.Abs(ptStart.X - ptEnd.X) ^ 2 + Math.Abs(ptStart.Y - ptEnd.Y) ^ 2, 1)))
                    'Debug.WriteLine(iDist)
                    If .eDestinationLinkPoint = DirectionsEnum.In AndAlso nodDest.CompareTo(node) > 0 Then nodDest.bDrawIn = True
                    If .eDestinationLinkPoint = DirectionsEnum.Out AndAlso nodDest.CompareTo(node) > 0 Then nodDest.bDrawOut = True
                Else
                    ' Create a set distance for the assister if we don't have 2 nodes to compare
                    iDist = (node.Points(1).X - node.Points(0).X) * 3
                End If

                ' If we have user defined points, don't add the assisters...
                Dim iMidStart As Integer = 2
                If nodDest Is Nothing Then
                    ReDim .Points(2) ' 2 points for start, one for end
                Else
                    If .OrigMidPoints.Length = 0 OrElse link Is NewLink Then
                        ReDim .Points(3) ' 2 points for each end
                    Else
                        ReDim .Points(.OrigMidPoints.Length + 1) ' 1 point for each end, plus any mid-points
                        iMidStart = 1
                    End If
                End If

                'ReDim .Points(1 + CInt(IIf(link IsNot NewLink OrElse .sDestination = "", .OrigMidPoints.Length, 0)) + CInt(IIf(.sDestination <> "", 2, 0)))
                .Points(0) = ptStart
                If .OrigMidPoints.Length = 0 OrElse link Is NewLink Then .Points(1) = GetBezierAssister(node, .eSourceLinkPoint, iDist)

                If link IsNot NewLink OrElse .sDestination = "" Then
                    For i As Integer = 0 To .OrigMidPoints.Length - 1
                        Dim ptMid As Point = TranslateToScreen(.OrigMidPoints(i))
                        .Points(iMidStart + i) = ptMid
                        If link IsNot NewLink Then
                            With link.Anchors(i)
                                Dim n As New MapNode(False)
                                n.Location = link.OrigMidPoints(i) ' change to get rid of node calc
                                RecalculateNode(n)
                                .Points = GetAnchorPoints(n, 0, 0)
                            End With
                        End If
                    Next
                End If

                ' 2 points for the end
                If nodDest IsNot Nothing Then
                    'Dim nodDest As MapNode = Page.GetNode(.sDestination)
                    'Dim ptEnd As Point = GetLinkPoint(nodDest, .eDestinationLinkPoint)
                    If .Points.Length = 4 AndAlso (.OrigMidPoints.Length = 0 OrElse link Is NewLink) Then .Points(.Points.Length - 2) = GetBezierAssister(nodDest, .eDestinationLinkPoint, iDist)
                    .Points(.Points.Length - 1) = ptEnd
                End If

                If link.eSourceLinkPoint = DirectionsEnum.In AndAlso link.sDestination <> "" Then
                    If nodDest Is Nothing Then nodDest = Map.FindNode(link.sDestination)
                    If nodDest IsNot Nothing AndAlso link.Duplex Then nodDest.bDrawOut = True
                End If
                If link.eSourceLinkPoint = DirectionsEnum.Out AndAlso link.sDestination <> "" Then
                    If nodDest Is Nothing Then nodDest = Map.FindNode(link.sDestination)
                    If nodDest IsNot Nothing AndAlso link.Duplex Then nodDest.bDrawIn = True
                End If
                'Debug.WriteLine(String.Format("Points count: {0}, OrigPoints len: {1}, sDest: {2}", .Points.Length, .OrigMidPoints.Length, .sDestination))
            End With
        Next

        'node.bDrawIn = False
        'node.bDrawOut = False
        If node.bHasOut Then
            'Dim iCircleWidth As Integer = CInt(iScale * 6 / node.Width)
            Select Case node.eOutEdge
                Case DirectionsEnum.North
                    node.ptOut = New Point(CInt(3 * node.Width * iScale / 4), 0)
                Case DirectionsEnum.East
                    node.ptOut = New Point(node.Width * iScale, CInt(3 * node.Height * iScale / 4))
                Case DirectionsEnum.South
                    node.ptOut = New Point(CInt(node.Width * iScale / 4), node.Height * iScale)
                Case DirectionsEnum.West
                    node.ptOut = New Point(0, CInt(node.Height * iScale / 4))
            End Select
            'Dim rectInOut As New Rectangle(X2 - X - CInt(iCircleWidth / 2), CInt((Y2 - Y) / 4 - (iCircleWidth / 2)), iCircleWidth, iCircleWidth)
        End If
        If node.bHasIn Then
            'Dim iCircleWidth As Integer = CInt(iScale * 6 / node.Width)
            Select Case node.eInEdge
                Case DirectionsEnum.North
                    node.ptIn = New Point(CInt(node.Width * iScale / 4), 0)
                Case DirectionsEnum.East
                    node.ptIn = New Point(node.Width * iScale, CInt(node.Height * iScale / 4))
                Case DirectionsEnum.South
                    node.ptIn = New Point(CInt(3 * node.Width * iScale / 4), node.Height * iScale)
                Case DirectionsEnum.West
                    node.ptIn = New Point(0, CInt(3 * node.Height * iScale / 4))
            End Select
            'Dim rectInOut As New Rectangle(X2 - X - CInt(iCircleWidth / 2), CInt((Y2 - Y) / 4 - (iCircleWidth / 2)), iCircleWidth, iCircleWidth)
        End If

    End Sub



    ' Recalculate the node points
    Public Sub RecalculateNode(ByVal node As MapNode, Optional ByVal bRecalculateLinks As Boolean = True)

        If node Is Nothing OrElse node.Key Is Nothing Then Exit Sub
#If Runner Then
        node.Seen = Adventure.Player.HasSeenLocation(node.Key)
#End If

        Dim points(3) As Point

        points(0) = Planes.GetPoint2D(node.Location)
        points(1) = Planes.GetPoint2D(New Point3D(node.Location.X + node.Width, node.Location.Y, node.Location.Z))
        points(2) = Planes.GetPoint2D(New Point3D(node.Location.X + node.Width, node.Location.Y + node.Height, node.Location.Z))
        points(3) = Planes.GetPoint2D(New Point3D(node.Location.X, node.Location.Y + node.Height, node.Location.Z))

        node.Points = New Point() {points(0), points(1), points(2), points(3)}

        node.ptUp = Planes.GetPoint2D(node.Location.X + node.Width / 2, node.Location.Y + node.Height / 2, node.Location.Z - 6)
        node.ptDown = Planes.GetPoint2D(node.Location.X + node.Width / 2, node.Location.Y + node.Height / 2, node.Location.Z + 6)

        'node.bDrawIn = False
        'node.bDrawOut = False


        If node.Anchors.Count > 0 Then ' because otherwise we are just being used to calc link anchor location

            If bRecalculateLinks Then
                RecalculateLinks(node)
                ' Recalculate all links that link to us
                If Page IsNot Nothing Then
                    For Each nodeOther As MapNode In Page.Nodes
                        For Each link As MapLink In nodeOther.Links.Values
                            If link.sDestination = node.Key Then RecalculateLinks(nodeOther)
                        Next
                    Next
                End If
                For Each d As DirectionsEnum In New DirectionsEnum() {DirectionsEnum.In, DirectionsEnum.Out}
                    If node.Links.ContainsKey(d) Then
                        Dim nodDest As MapNode = Page.GetNode(node.Links(d).sDestination)
                        If nodDest IsNot Nothing Then RecalculateLinks(nodDest)
                    End If
                Next
            End If

            node.Anchors(DirectionsEnum.NorthWest).Points = GetAnchorPoints(node, 0, 0)
            node.Anchors(DirectionsEnum.North).Points = GetAnchorPoints(node, 50, 0)
            node.Anchors(DirectionsEnum.NorthEast).Points = GetAnchorPoints(node, 100, 0)
            node.Anchors(DirectionsEnum.East).Points = GetAnchorPoints(node, 100, 50)
            node.Anchors(DirectionsEnum.SouthEast).Points = GetAnchorPoints(node, 100, 100)
            node.Anchors(DirectionsEnum.South).Points = GetAnchorPoints(node, 50, 100)
            node.Anchors(DirectionsEnum.SouthWest).Points = GetAnchorPoints(node, 0, 100)
            node.Anchors(DirectionsEnum.West).Points = GetAnchorPoints(node, 0, 50)

            If node Is ActiveNode Then
                For Each a As Anchor In node.Anchors.Values
                    a.Visible = True
                Next
            End If
        End If

    End Sub



    ' http://answers.google.com/answers/threadview/id/496030.html
    Private Shared Function Convert3DtoScreen(ByVal x As Integer, ByVal y As Integer, ByVal z As Integer) As Point

        Dim Rx As Double = (iOffsetY - 40) / 150 ' rotation about x axis
        Dim Ry As Double = (iOffsetX - 200) / 200 ' rotation about y axis
        Dim Rz As Double = Ry / 5 ' 0 ' rotation about z axis

        ' First, apply the x-axis rotation to transform coordinates (x, y, z) into coordinates (x0, y0, z0).
        Dim x0 As Double = x
        Dim y0 As Double = y * Math.Cos(Rx) + z * Math.Sin(Rx)
        Dim z0 As Double = z * Math.Cos(Rx) - y * Math.Sin(Rx)

        ' Then apply the y-axis rotation to (x0, y0, z0) to obtain (x1, y1, z1).
        Dim x1 As Double = x0 * Math.Cos(Ry) - z0 * Math.Sin(Ry)
        Dim y1 As Double = y0
        Dim z1 As Double = z0 * Math.Cos(Ry) + x0 * Math.Sin(Ry)

        ' Finally, apply the z-axis rotation to obtain the point (x2, y2).
        Dim x2 As Double = x1 * Math.Cos(Rz) + y1 * Math.Sin(Rz)
        Dim y2 As Double = y1 * Math.Cos(Rz) - x1 * Math.Sin(Rz)

        'Debug.WriteLine(String.Format("(X: {0}, Y: {1}, Z: {2}) -> (X: {3}, Y: {4})", x, y, z, x2, y2))
        'If bDisplay Then
        '    Debug.WriteLine(String.Format("(X: {0}, Y: {1}, Z: {2}) -> (X: {3}, Y: {4}, Z: {5})", x, y, z, x2, y2, z1))
        'End If

        Return New Point(CInt(x2), CInt(y2)) ' + 200)

    End Function


    Private Function ConvertScreento3D(ByVal ptScreen As Point, ByVal zTest As Integer) As Point

        ' Calculate a series of coordinates on the 3D given by the screen coordinate, and return the first
        ' point in 3D space where we cross the plane given by z

        ' Could probably vastly improve this function if needed, using a bisection algorithm...
        ' http://en.wikipedia.org/wiki/Bisection_method

        Dim x As Double, y As Double, z As Double
        Dim zUnknown As Double = -2500

        Do
            zUnknown += 1
            Get3DCoord(ptScreen.X, ptScreen.Y, zUnknown, x, y, z)
        Loop While z < zTest

        Return New Point(CInt(x), CInt(y))

    End Function


    ' Get the original X and Y coords, assuming we are given the 3D point, plus Z
    Private Sub Get3DCoord(ByVal x2 As Double, ByVal y2 As Double, ByVal z2 As Double, ByRef x As Double, ByRef y As Double, ByRef z As Double)

        Dim Rx As Double = (iOffsetY - 40) / 150 ' rotation about x axis
        Dim Ry As Double = (iOffsetX - 200) / 200 ' rotation about y axis
        Dim Rz As Double = Ry / 5 ' 0 ' rotation about z axis

        ' Using http://www.numberempire.com/equationsolver.php

        'Dim x2 As Double = pt.X
        'Dim y2 As Double = pt.Y - 200
        'Dim z2 As Double = z '?!!

        ' x2 = x1 * Cos(Rz) + y1 * Sin(Rz)  -A
        ' y2 = y1 * Cos(Rz) - x1 * Sin(Rz)  -B
        ' =>
        ' x1 = -(sin(Rz)*y1-x2)/cos(Rz) -fromA -A
        ' y1 = (x2-cos(Rz)*x1)/sin(Rz)  -fromA -B
        ' x1 = -(y2-cos(Rz)*y1)/sin(Rz) -fromB -C
        ' y1 = (y2+sin(Rz)*x1)/cos(Rz)  -fromB -D
        ' =>
        ' y1 = (cos(Rz)*y2+sin(Rz)*x2)/(sin(Rz)^2+cos(Rz)^2)    -fromA,C
        ' x1 = -(sin(Rz)*y2-cos(Rz)*x2)/(sin(Rz)^2+cos(Rz)^2)   -fromB,D
        ' z1 = z2

        Dim x1 As Double = -(Math.Sin(Rz) * y2 - Math.Cos(Rz) * x2) / (Math.Sin(Rz) ^ 2 + Math.Cos(Rz) ^ 2)
        Dim y1 As Double = (Math.Cos(Rz) * y2 + Math.Sin(Rz) * x2) / (Math.Sin(Rz) ^ 2 + Math.Cos(Rz) ^ 2)
        Dim z1 As Double = z2

        '---

        ' x1 = x0 * Cos(Ry) - z0 * Sin(Ry)  -A        
        ' z1 = z0 * Cos(Ry) + x0 * Sin(Ry)  -B
        ' =>
        ' x0 = (sin(Ry)*z0+x1)/cos(Ry)  -fromA -A
        ' z0 = -(x1-cos(Ry)*x0)/sin(Ry) -fromA -B
        ' x0 = (z1-cos(Ry)*z0)/sin(Ry)  -fromB -C
        ' z0 = (z1-sin(Ry)*x0)/cos(Ry)  -fromB -D
        ' =>
        ' z0 = (cos(Ry)*z1-sin(Ry)*x1)/(sin(Ry)^2+cos(Ry)^2)    -fromA,C
        ' x0 = (sin(Ry)*z1+cos(Ry)*x1)/(sin(Ry)^2+cos(Ry)^2)    -fromB,D
        ' y0 = y1

        Dim x0 As Double = (Math.Sin(Ry) * z1 + Math.Cos(Ry) * x1) / (Math.Sin(Ry) ^ 2 + Math.Cos(Ry) ^ 2)
        Dim y0 As Double = y1
        Dim z0 As Double = (Math.Cos(Ry) * z1 - Math.Sin(Ry) * x1) / (Math.Sin(Ry) ^ 2 + Math.Cos(Ry) ^ 2)

        '---

        ' y0 = y * Cos(Rx) + z * Sin(Rx)    -A
        ' z0 = z * Cos(Rx) - y * Sin(Rx)    -B
        ' =>
        ' y = -(sin(Rx)*z-y0)/cos(Rx)   -fromA -A
        ' z = (y0-cos(Rx)*y)/sin(Rx)    -fromA -B
        ' y = -(z0-cos(Rx)*z)/sin(Rx)   -fromB -C
        ' z = (z0+sin(Rx)*y)/cos(Rx)    -fromB -D
        ' =>
        ' z = (cos(Rx)*z0+sin(Rx)*y0)/(sin(Rx)^2+cos(Rx)^2)     -fromA,C
        ' y = -(sin(Rx)*z0-cos(Rx)*y0)/(sin(Rx)^2+cos(Rx)^2)    -fromB,D
        ' x = x0

        x = x0
        y = -(Math.Sin(Rx) * z0 - Math.Cos(Rx) * y0) / (Math.Sin(Rx) ^ 2 + Math.Cos(Rx) ^ 2)
        z = (Math.Cos(Rx) * z0 + Math.Sin(Rx) * y0) / (Math.Sin(Rx) ^ 2 + Math.Cos(Rx) ^ 2)

        'Debug.WriteLine(String.Format("(X: {0}, Y: {1}) -> (X: {2}, Y: {3}, Z: {4})", x2, y2, x, y, z))

    End Sub


    Private Function HotTrackColour(ByVal colour As Color, Optional ByVal bAlpha As Byte = 0) As Color
        If bAlpha = 0 Then bAlpha = colour.A
        Return Color.FromArgb(bAlpha, Math.Max(colour.R - 30, 0), Math.Max(colour.G - 30, 0), Math.Max(colour.B - 30, 0))
    End Function


    Private Sub DrawAxes(ByVal g As Graphics)
        'For i As Integer = -5 To 5
        '    g.DrawPolygon(New Pen(Color.Cyan), New Point() {Planes.GetPoint2D(New Point3D(0, 0, i)), Planes.GetPoint2D(New Point3D(5, 0, i)), Planes.GetPoint2D(New Point3D(5, 5, i)), Planes.GetPoint2D(New Point3D(0, 5, i))})
        'Next
        g.DrawLine(New Pen(Color.FromArgb(70, 255, 0, 0), 1), Planes.GetPoint2D(New Point3D(-1000, 0, 0)), Planes.GetPoint2D(New Point3D(1000, 0, 0)))
        g.DrawLine(New Pen(Color.FromArgb(70, 0, 255, 0), 1), Planes.GetPoint2D(New Point3D(0, -1000, 0)), Planes.GetPoint2D(New Point3D(0, 1000, 0)))
        g.DrawLine(New Pen(Color.FromArgb(70, 0, 0, 255), 1), Planes.GetPoint2D(New Point3D(0, 0, -1000)), Planes.GetPoint2D(New Point3D(0, 0, 1000)))
    End Sub
    Private Sub DrawGrid(ByVal g As Graphics)

        If ActiveNode IsNot Nothing Then
            Dim iRange As Integer = 200
            For x As Integer = -iRange To iRange Step 2
                g.DrawLine(New Pen(Color.FromArgb(30, 0, 0, 0)), Planes.GetPoint2D(New Point3D(x, -iRange, ActiveNode.Location.Z)), Planes.GetPoint2D(New Point3D(x, iRange, ActiveNode.Location.Z)))
                g.DrawLine(New Pen(Color.FromArgb(30, 0, 0, 0)), Planes.GetPoint2D(New Point3D(-iRange, x, ActiveNode.Location.Z)), Planes.GetPoint2D(New Point3D(iRange, x, ActiveNode.Location.Z)))
            Next
        End If

    End Sub


    Private Sub DrawNode(ByVal g As Graphics, ByVal node As MapNode)

        Try
            'Dim penBlack As New Pen(Color.DarkCyan, 1)
            'Dim penJoin As New Pen(Color.DarkBlue, 3)
            'Dim points(3) As Point       
#If Runner Then
            If Not node.Seen Then Exit Sub
            If Adventure.htblLocations(node.Key).HideOnMap Then Exit Sub
#End If

            Dim X As Integer = node.Location.X * iScale '- iBoundX  ' Left
            Dim Y As Integer = node.Location.Y * iScale '- iBoundY  ' Top        
            Dim X2 As Integer = (X + node.Width * iScale)   ' Right
            Dim Y2 As Integer = (Y + node.Height * iScale)  ' Bottom        
            'Dim Z As Integer = node.Z * iScale              ' Level


            Dim brushNodeText As Brush
            Dim brushNodeBackground As Brush
            Dim penBorder As Pen
            Dim Alpha As Byte = 255

            If SelectedNodes.Contains(node) Then
                brushNodeBackground = New System.Drawing.SolidBrush(Color.FromArgb(200, NODESELECTED))
                brushNodeText = New System.Drawing.SolidBrush(NODETEXT)
                penBorder = New Pen(NODEBORDER, 1)
                If node Is HotTrackedNode Then
                    brushNodeBackground = New System.Drawing.SolidBrush(HotTrackColour(NODESELECTED))
                End If
            ElseIf node Is HotTrackedNode Then
                brushNodeBackground = New System.Drawing.SolidBrush(HotTrackColour(NODEBACKGROUND, 200)) ' Color.FromArgb(200, Math.Max(NODEBACKGROUND.R - 30, 0), Math.Max(NODEBACKGROUND.G - 30, 0), Math.Max(NODEBACKGROUND.B - 30, 0)))
                brushNodeText = New System.Drawing.SolidBrush(NODETEXT)
                penBorder = New Pen(NODEBORDER, 1)
            Else
                If ActiveNode Is Nothing OrElse node.Location.Z = ActiveNode.Location.Z Then
                    ' Nodes on same level as hot-tracked node
                    brushNodeBackground = New System.Drawing.SolidBrush(Color.FromArgb(200, NODEBACKGROUND))
                    brushNodeText = New System.Drawing.SolidBrush(NODETEXT)
                    penBorder = New Pen(NODEBORDER, 1)
                Else
                    ' Nodes on a different level to hot-tracked node
                    brushNodeBackground = New System.Drawing.SolidBrush(Color.FromArgb(50, NODEBACKGROUND))
                    brushNodeText = New System.Drawing.SolidBrush(Color.FromArgb(50, NODETEXT))
                    penBorder = New Pen(Color.FromArgb(50, NODEBORDER))
                    Alpha = 50
                End If
            End If

            If node.Overlapping Then penBorder = Pens.Red
#If Generator Then
            If Adventure.htblLocations(node.Key).HideOnMap Then
                penBorder = New Pen(penBorder.Color)
                penBorder.DashStyle = DashStyle.DashDot
            End If
#End If
            'Dim loc As clsLocation = Adventure.htblLocations(node.Key)
            'If loc.arlDirections(DirectionsEnum.Down).LocationKey <> "" Then
            '    Dim node2 As MapNode = Page.GetNode(loc.arlDirections(DirectionsEnum.Down).LocationKey)
            '    If node2 IsNot Nothing Then
            '        'g.DrawLine(penBlack, CSng(node.Points(0).X + (node.Points(1).X - node.Points(0).X) / 2), node.Points(0).Y, CSng(node2.Points(0).X + (node2.Points(1).X - node2.Points(0).X) / 2), node2.Points(0).Y)
            '        g.DrawLine(penJoin, CSng(node.Points(0).X + (node.Points(2).X - node.Points(0).X) / 2), CSng(node.Points(0).Y + (node.Points(2).Y - node.Points(0).Y) / 2), CSng(node2.Points(0).X + (node2.Points(2).X - node2.Points(0).X) / 2), CSng(node2.Points(0).Y + (node2.Points(2).Y - node2.Points(0).Y) / 2))
            '    End If
            'End If            

            'g.SmoothingMode = SmoothingMode.HighQuality

            '            DrawLinks(g, node, DirectionsEnum.Down)
            For eDir As DirectionsEnum = DirectionsEnum.North To DirectionsEnum.NorthWest
                Dim nodDest As MapNode = Nothing
                If node.Links.ContainsKey(eDir) Then
                    nodDest = Map.FindNode(node.Links(eDir).sDestination)
                    If nodDest IsNot Nothing Then
                        Dim iComp As Integer = nodDest.CompareTo(node)
                        'If nodDest IsNot Nothing AndAlso (nodDest.Location.Z > node.Location.Z OrElse (nodDest.Location.Z = node.Location.Z AndAlso nodDest.Location.Y < node.Location.Y) OrElse (nodDest Is node AndAlso eDir = DirectionsEnum.Down)) Then
                        If nodDest IsNot Nothing AndAlso (iComp < 0 OrElse (eDir = DirectionsEnum.Down AndAlso iComp = 0)) Then
                            'If eDir <> DirectionsEnum.Down Then
                            DrawLinks(g, node, eDir)
                        End If
                    End If
                End If
            Next
#If Runner Then
            If Adventure.Player IsNot Nothing AndAlso Adventure.Player.HasRouteInDirection(DirectionsEnum.Down, False, node.Key) AndAlso Not Adventure.Player.HasSeenLocation(Adventure.htblLocations(node.Key).arlDirections(DirectionsEnum.Down).LocationKey) Then
                DrawOutArrow(g, node, DirectionsEnum.Down)
            End If
#End If
            'brushNodeBackground = New System.Drawing.SolidBrush(Color.FromArgb(200, Color.FromArgb(Math.Min(150 - (node.Location.Z * 2), 255), Math.Min(200 - (node.Location.Z * 2), 255), Math.Min(255 - (node.Location.Z * 2), 255))))

            g.FillPolygon(brushNodeBackground, node.Points)
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

            ' Create a transformation on the graphics, so we can squish the text correctly into the box
            Dim transformNone As System.Drawing.Drawing2D.Matrix = g.Transform
            'Dim myMatrix As New Matrix()
            'Dim dfXShear As Single = -CSng((node.Points(0).X - node.Points(3).X) / (node.Points(3).Y - node.Points(0).Y)) '(Y2 - Y)) ' 
            'Dim dfXScale As Single = -CSng(node.Points(0).X - node.Points(1).X) / (X2 - X)
            'Dim dfYScale As Single = CSng((node.Points(2).Y - node.Points(1).Y) / (Y2 - Y))
            ''myMatrix.Scale(dfXScale, dfYScale)
            'myMatrix.Translate(CSng(node.Points(0).X), CSng(node.Points(0).Y))
            ''myMatrix.Rotate(CInt((-iOffsetX + 200) / 20))
            'If Not Double.IsInfinity(dfXShear) AndAlso Not Double.IsNaN(dfXShear) Then myMatrix.Shear(dfXShear, 0)
            'If dfXScale <> 0 AndAlso dfYScale <> 0 Then myMatrix.Scale(dfXScale, dfYScale)
            'g.MultiplyTransform(myMatrix)
            Dim sf As New StringFormat
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center
            Dim rect As Rectangle = New Rectangle(node.Points(0).X, node.Points(0).Y, X2 - X, Y2 - Y)
            Dim rectInner As New Rectangle(2, 2, rect.Width - 4, Math.Max(rect.Height - 4, 2))
            'Dim rectInner As New Rectangle(2, 2, rect.Width - 4, rect.Height - 4)

            Dim sText As String = node.Text ' Adventure.htblLocations(node.Key).ShortDescription
            'If txtRename.Visible AndAlso node Is ActiveNode Then sText &= "_" '"|"
            Dim fntText As Font = GetFont(g, rectInner, sText)
            If txtRename.Visible AndAlso node Is ActiveNode Then
                If txtRename.SelectionLength > 0 Then
                    sText = sLeft(sText, txtRename.SelectionStart) & "[" & sMid(sText, txtRename.SelectionStart + 1, txtRename.SelectionLength) & "]" & sRight(sText, sText.Length - txtRename.SelectionStart - txtRename.SelectionLength)
                Else
                    sText = sLeft(sText, txtRename.SelectionStart) & "|" & sRight(sText, sText.Length - txtRename.SelectionStart)
                End If
            End If
            'g.DrawString(sText, fntText, brushNodeText, rectInner, sf)
            'If txtRename.Visible AndAlso txtRename.SelectedText <> "" Then
            '    g.DrawString(txtRename.SelectedText, fntText, Brushes.Chocolate, rectInner, sf)
            'End If

            'g.Transform = transformNone ' Restore transformation back to normal

            'If node.Key = "Location1" OrElse node.Key = "Location2" Then
            'g.DrawEllipse(New Pen(Color.Red, 4), New Rectangle(Planes(node.Location.Z).GetPointOnPlane(0, 0), New Size(5, 5)))
            'g.DrawEllipse(New Pen(Color.Red, 4), New Rectangle(Planes(node.Location.Z).GetPointOnPlane(1000, 0), New Size(5, 5)))
            'g.DrawEllipse(New Pen(Color.Red, 4), New Rectangle(Planes(node.Location.Z).GetPointOnPlane(1000, 1000), New Size(5, 5)))
            'g.DrawString(sText, fntText, Brushes.Red, rectInner, sf)

            If Not Planes.ContainsKey(node.Location.Z) Then Exit Sub ' For now...

            Dim myMatrix As Matrix = CType(Planes(node.Location.Z).matrix.Clone, Matrix)
            myMatrix.Translate(node.Location.X * iScale, node.Location.Y * iScale)
            g.MultiplyTransform(myMatrix)
            'g.DrawString(sText, fntText, Brushes.Green, rectInner, sf)
            'myMatrix.Reset()
            'g.MultiplyTransform(myMatrix)
            g.DrawString(sText, fntText, brushNodeText, rectInner, sf)
            'g.Transform.Reset()
            'g.DrawImage(My.Resources.Resources.imgOut32, New Rectangle(X2 - X, Y, 100, 100))   

            Dim transformNode As System.Drawing.Drawing2D.Matrix = g.Transform

            g.Transform = transformNone ' Restore transformation back to normal
            'End If

            ' Draw the outer box
            g.DrawPolygon(penBorder, node.Points)

            For eDir As DirectionsEnum = DirectionsEnum.North To DirectionsEnum.NorthWest
                Dim nodDest As MapNode = Nothing
                If node.Links.ContainsKey(eDir) Then
                    If node.Links(eDir).sDestination <> "" Then nodDest = Map.FindNode(node.Links(eDir).sDestination)
                    If Not (node Is nodDest AndAlso eDir = DirectionsEnum.Down) Then
                        If node.Links(eDir).sDestination = "" OrElse (nodDest IsNot Nothing AndAlso nodDest.CompareTo(node) >= 0) Then
                            DrawLinks(g, node, eDir)
                        End If
                    End If
                End If
#If Runner Then
                If eDir <> DirectionsEnum.Down Then
                    If Adventure.Player IsNot Nothing AndAlso Adventure.Player.HasRouteInDirection(eDir, False, node.Key) AndAlso Not Adventure.Player.HasSeenLocation(Adventure.htblLocations(node.Key).arlDirections(eDir).LocationKey) Then
                        If eDir = DirectionsEnum.In OrElse eDir = DirectionsEnum.Out Then
                            DrawInOutIcon(eDir, g, node, , Alpha)
                        Else
                            DrawOutArrow(g, node, eDir)
                        End If
                    End If
                End If
#End If
            Next


            If (node.bDrawOut AndAlso node.bHasOut) OrElse node.Links.ContainsKey(DirectionsEnum.Out) Then
#If Runner Then
                If Adventure.Player.HasRouteInDirection(DirectionsEnum.Out, False, node.Key) Then
#End If
                DrawInOutIcon(DirectionsEnum.Out, g, node, , Alpha)
#If Runner Then
                End If
#End If
            End If
            If (node.bDrawIn AndAlso node.bHasIn) OrElse node.Links.ContainsKey(DirectionsEnum.In) Then
#If Runner Then
                If Adventure.Player.HasRouteInDirection(DirectionsEnum.In, False, node.Key) Then
#End If
                DrawInOutIcon(DirectionsEnum.In, g, node, , Alpha)
#If Runner Then
                End If
#End If
            End If


#If Generator Then
            ' Draw any anchors
            If node.Anchors IsNot Nothing AndAlso node.Anchors.Count > 0 Then
                For Each a As Anchor In node.Anchors.Values
                    If a.Visible Then DrawAnchor(g, a)
                Next
            End If
#End If


            'For eDir As DirectionsEnum = DirectionsEnum.North To DirectionsEnum.NorthWest
            '    If node.Links.ContainsKey(eDir) Then
            '        Dim nodDest As MapNode = Map.FindNode(node.Links(eDir).sDestination)
            '        If nodDest IsNot Nothing Then
            '            If nodDest.Location.Z < node.Location.Z OrElse (nodDest.Location.Z = node.Location.Z AndAlso nodDest.Location.Y >= node.Location.Y) Then
            '                'If eDir <> DirectionsEnum.Down Then
            '                DrawLinks(g, node, eDir)
            '            End If
            '        End If
            '    End If
            'Next

        Catch ex As Exception
            'ErrMsg("Error drawing node", ex)
        End Try

    End Sub


    Private Sub DrawAnchor(ByVal g As Graphics, ByVal a As Anchor)
        Dim brushAnchor As Brush
        If a Is HotTrackedAnchor Then
            brushAnchor = New SolidBrush(Color.FromArgb(125, 210, 120, 30))
        Else
            brushAnchor = New SolidBrush(Color.FromArgb(100, 255, 150, 50))
        End If
        g.FillPolygon(brushAnchor, a.Points)
        g.DrawPolygon(Pens.DarkOrange, a.Points)
    End Sub


    'Private Function GetAnchor(ByVal node As MapNode, ByVal d As DirectionsEnum) As Anchor

    '    If node.Anchors Is Nothing OrElse Not node.Anchors.ContainsKey(d) Then
    '        CreateAnchor(node, d)            
    '    End If
    '    Return node.Anchors(d)

    'End Function


    Private Sub DrawOutArrow(ByVal g As Graphics, ByVal node As MapNode, ByVal eDir As DirectionsEnum, Optional ByVal pen As Pen = Nothing)

        Dim penLink As Pen
        If pen Is Nothing Then
            penLink = New Pen(Color.FromArgb(30, LINKCOLOUR), CInt(iScale / 5))
            If ActiveNode Is Nothing OrElse node.Location.Z = ActiveNode.Location.Z Then
                penLink = New Pen(Color.FromArgb(100, LINKCOLOUR), CInt(iScale / 5))
            End If
            penLink.DashStyle = DashStyle.Solid
            penLink.StartCap = LineCap.Round
        Else
            penLink = pen
        End If
        Dim bigarrow As New AdjustableArrowCap(4, 4, True)
        Dim cap As CustomLineCap = bigarrow
        penLink.EndCap = LineCap.Custom
        penLink.CustomEndCap = cap

        Dim ptStart As Point = GetLinkPoint(node, eDir)
        Dim ptEnd As Point = GetBezierAssister(node, eDir, 10 * iScale)

        g.DrawLine(penLink, ptStart, ptEnd)

    End Sub


    Private Sub DrawLinks(ByVal g As Graphics, ByVal node As MapNode, ByVal eDir As DirectionsEnum)

        If node.Links.ContainsKey(eDir) Then
            Dim link As MapLink = node.Links(eDir)
            With link                
#If Runner Then
                If .Style = DashStyle.Dot AndAlso Not Adventure.Player.HasRouteInDirection(eDir, False, node.Key) Then Exit Sub
                If .sDestination Is Nothing OrElse Not Adventure.htblLocations(.sDestination).SeenBy(Adventure.Player.Key) Then Exit Sub
#End If

                Dim penLink As New Pen(Color.FromArgb(30, LINKCOLOUR), CInt(iScale / 5))
                Dim nodDest As MapNode = Page.GetNode(link.sDestination)

                If ActiveNode Is Nothing OrElse node.Location.Z = ActiveNode.Location.Z OrElse (nodDest IsNot Nothing AndAlso nodDest.Location.Z = ActiveNode.Location.Z AndAlso nodDest.Seen) Then
                    ' Nodes on same level as selected node
                    penLink = New Pen(Color.FromArgb(100, LINKCOLOUR), CInt(iScale / 5))
                End If

                penLink.DashStyle = .Style
                penLink.StartCap = LineCap.Flat ' LineCap.Round

                ' Don't show dotted lines if we haven't been restricted in that direction yet
                If .Style = DashStyle.Dot Then
                    Dim src As clsLocation = Adventure.htblLocations(.sSource)
                    If src.arlDirections(eDir).Restrictions.Count > 0 AndAlso Not src.arlDirections(eDir).bEverBeenBlocked Then penLink.DashStyle = DashStyle.Solid
                End If

                If Not .Duplex Then
                    ' Draw as an arrow
                    'penLink.EndCap = LineCap.ArrowAnchor
                    Dim bigarrow As New AdjustableArrowCap(4, 4, True)
                    Dim cap As CustomLineCap = bigarrow
                    penLink.EndCap = LineCap.Custom
                    penLink.CustomEndCap = cap
                Else
                    penLink.EndCap = LineCap.Round ' LineCap.Round
                End If

                If link Is NewLink Then
                    If node.Anchors.ContainsKey(eDir) Then node.Anchors(eDir).Visible = True
                    penLink.Color = Color.FromArgb(100, 255, 0, 0)
                ElseIf link Is SelectedLink Then
                    If node.Anchors.ContainsKey(link.eSourceLinkPoint) Then node.Anchors(link.eSourceLinkPoint).Visible = True
                    If nodDest IsNot Nothing AndAlso nodDest.Anchors.ContainsKey(link.eDestinationLinkPoint) Then nodDest.Anchors(link.eDestinationLinkPoint).Visible = True
                    penLink.Color = Color.FromArgb(100, LINKSELECTED)
                ElseIf link Is HotTrackedLink Then
                    If node.Anchors.ContainsKey(eDir) Then node.Anchors(eDir).Visible = True
                    If nodDest IsNot Nothing AndAlso nodDest.Anchors.ContainsKey(link.eDestinationLinkPoint) Then nodDest.Anchors(link.eDestinationLinkPoint).Visible = True
                    penLink.Color = Color.FromArgb(150, HotTrackColour(LINKCOLOUR))
                End If

                If .sDestination = node.Key AndAlso eDir <> DirectionsEnum.In AndAlso eDir <> DirectionsEnum.Out Then 'AndAlso .eDestinationLinkPoint = OppositeDirection(eDir) Then
                    DrawOutArrow(g, node, eDir, penLink)
                    Exit Sub
                End If

                '#If Runner Then
                '        If Not Adventure.htblLocations(.sDestination).SeenBy(Adventure.Player.Key) Then
                '            DrawOutArrow(g, node, eDir, penLink)
                '            Exit Sub
                '        End If
                '#End If

                'Debug.WriteLine(.Points(0).ToString & .Points(1).ToString & .Points(2).ToString)
                If .Points IsNot Nothing AndAlso Not (.Points.Length = 3 AndAlso .Points(2).X = 0 AndAlso .Points(2).Y = 0) Then
                    If .Points.Length = 3 AndAlso .sDestination = "" Then
                        g.DrawBezier(penLink, .Points(0), .Points(1), .Points(2), .Points(2))
                    ElseIf .Points.Length = 4 AndAlso (.OrigMidPoints.Length = 0 OrElse link Is NewLink) Then
                        g.DrawBezier(penLink, .Points(0), .Points(1), .Points(2), .Points(3))
                    Else
                        g.DrawCurve(penLink, .Points) ', 0.5F)                                    
                    End If
                End If

                If link Is SelectedLink OrElse link Is NewLink OrElse link Is HotTrackedLink Then
                    If link.Anchors.Count > 0 Then
#If False Then
                            Dim p As Point = .Points(1)
                            g.DrawEllipse(Pens.Red, New Rectangle(p.X - 2, p.Y - 2, 5, 5))
                            p = .Points(.Points.Length - 2)
                            g.DrawEllipse(Pens.Red, New Rectangle(p.X - 2, p.Y - 2, 5, 5))
#End If
                        For Each a As Anchor In link.Anchors
                            DrawAnchor(g, a)
                        Next
                        'Else                        
                        'For i As Integer = 1 To .Points.Length - 2
                        '    Dim p As Point = .Points(i)
                        '    g.DrawEllipse(Pens.Red, New Rectangle(p.X - 2, p.Y - 2, 5, 5))
                        'Next
                    End If
                End If

                ' Draw the destination In/Out icon if the destination node is less significant than us                
                If nodDest IsNot Nothing AndAlso (eDir = DirectionsEnum.Out OrElse eDir = DirectionsEnum.In) Then
                    Dim Alpha As Byte = 255
                    If Not SelectedNodes.Contains(node) AndAlso Not (ActiveNode Is Nothing OrElse node.Location.Z = ActiveNode.Location.Z) Then Alpha = 50
                    DrawInOutIcon(OppositeDirection(eDir), g, nodDest, , Alpha)
                End If

            End With

        End If

    End Sub


    Private Sub DrawInOutIcon(ByVal eDir As DirectionsEnum, ByVal g As Graphics, ByVal node As MapNode, Optional ByVal nodDest As MapNode = Nothing, Optional ByVal Alpha As Byte = 255)

        Try

            'If Not node.Links.ContainsKey(eDir) Then Exit Sub
            If (eDir = DirectionsEnum.In AndAlso Not node.bHasIn) OrElse (eDir = DirectionsEnum.Out AndAlso Not node.bHasOut) Then Exit Sub

            Dim transformNone As System.Drawing.Drawing2D.Matrix = g.Transform
            Dim iCircleWidth As Integer = CInt(iScale / 2)
            Dim ptInOut As Point

            For Each n As MapNode In New MapNode() {node, nodDest}
                If n IsNot Nothing Then
                    Dim eInOut As DirectionsEnum = eDir
                    If n IsNot node Then eInOut = OppositeDirection(eInOut)

                    If n Is node OrElse node.CompareTo(nodDest) > 0 Then
                        If (n.bHasOut AndAlso eInOut = DirectionsEnum.Out) OrElse (n.bHasIn AndAlso eInOut = DirectionsEnum.In) Then
                            ptInOut = CType(IIf(eInOut = DirectionsEnum.In, n.ptIn, n.ptOut), Point)

                            Dim rectInOut As New Rectangle(ptInOut.X - iCircleWidth, ptInOut.Y - iCircleWidth, iCircleWidth * 2, iCircleWidth * 2)
                            Dim sInOut As String

                            If Not Planes.ContainsKey(n.Location.Z) Then Exit Sub

                            Dim myMatrix As Matrix = CType(Planes(n.Location.Z).matrix.Clone, Matrix)
                            myMatrix.Translate(n.Location.X * iScale, n.Location.Y * iScale)
                            g.MultiplyTransform(myMatrix)

                            Dim brushBackground As Brush
                            Dim penBorder As Pen

                            If eInOut = DirectionsEnum.In Then
                                sInOut = "IN"
                                brushBackground = New System.Drawing.SolidBrush(HotTrackColour(Color.LightGreen, Alpha))
                                penBorder = New Pen(HotTrackColour(Color.DarkGreen, Alpha))
                            Else
                                sInOut = "OUT"
                                brushBackground = New System.Drawing.SolidBrush(HotTrackColour(Color.Pink, Alpha))
                                penBorder = New Pen(HotTrackColour(Color.DarkRed, Alpha))
                            End If
                            g.FillEllipse(brushBackground, rectInOut)
                            g.DrawEllipse(penBorder, rectInOut)
                            Dim fntText2 As Font = GetFont(g, rectInOut, sInOut)
                            Dim sf As New StringFormat
                            sf.Alignment = StringAlignment.Center
                            sf.LineAlignment = StringAlignment.Center
                            g.DrawString(sInOut, fntText2, New System.Drawing.SolidBrush(HotTrackColour(Color.Black, Alpha)), New Rectangle(rectInOut.X, rectInOut.Y, rectInOut.Width, CInt(rectInOut.Height * 1.08)), sf)

                            g.Transform = transformNone
                        End If
                    End If
                End If
            Next

        Catch ex As Exception

        End Try

    End Sub


    Private Function GetBezierAssister(ByVal node As MapNode, ByVal d As DirectionsEnum, ByVal iDist As Integer) As Point

        ' Make this a function of the distance between the two node points

        Dim pt As Point

        If iDist = 0 Then iDist = 1
        Dim iOffsetX As Integer = 0
        Dim iOffsetY As Integer = 0


        If node IsNot Nothing Then
            iOffsetX = CInt(iDist * 40 / iScale / node.Width)
            iOffsetY = CInt(iDist * 40 / iScale / node.Height)
        End If

        Select Case d
            Case DirectionsEnum.North
                pt = GetRelativePoint(node, 50, -iOffsetY) ' 50,-50
            Case DirectionsEnum.NorthEast
                pt = GetRelativePoint(node, 100 + CInt(3 * iOffsetX / 4), -CInt(iOffsetY / 2)) ' 150,-50
            Case DirectionsEnum.East
                pt = GetRelativePoint(node, 100 + iOffsetX, 50) ' 150,50
            Case DirectionsEnum.SouthEast
                pt = GetRelativePoint(node, 100 + CInt(3 * iOffsetX / 4), 100 + CInt(iOffsetY / 2)) '150,150
            Case DirectionsEnum.South
                pt = GetRelativePoint(node, 50, 100 + iOffsetY) ' 50,150
            Case DirectionsEnum.SouthWest
                pt = GetRelativePoint(node, -CInt(3 * iOffsetX / 4), 100 + CInt(iOffsetY / 2)) ' -50,150
            Case DirectionsEnum.West
                pt = GetRelativePoint(node, -iOffsetX, 50) ' -50,50
            Case DirectionsEnum.NorthWest
                pt = GetRelativePoint(node, -CInt(3 * iOffsetX / 4), -CInt(iOffsetY / 2)) ' -50,-50
            Case DirectionsEnum.Up
                pt = node.ptUp ' GetRelativePoint(node, 50, 50) ' 50,50
            Case DirectionsEnum.Down
                pt = node.ptDown ' GetRelativePoint(node, 50, 50) ' 50,50
            Case DirectionsEnum.In
                Select Case node.eInEdge
                    Case DirectionsEnum.North
                        pt = GetRelativePoint(node, 25, -iOffsetY)
                    Case DirectionsEnum.South
                        pt = GetRelativePoint(node, 75, 100 + iOffsetY)
                    Case DirectionsEnum.East
                        pt = GetRelativePoint(node, 100 + iOffsetX, 25)
                    Case DirectionsEnum.West
                        pt = GetRelativePoint(node, -iOffsetX, 75)
                End Select
            Case DirectionsEnum.Out
                Select Case node.eOutEdge
                    Case DirectionsEnum.North
                        pt = GetRelativePoint(node, 75, -iOffsetY)
                    Case DirectionsEnum.South
                        pt = GetRelativePoint(node, 25, 100 + iOffsetY)
                    Case DirectionsEnum.East
                        pt = GetRelativePoint(node, 100 + iOffsetX, 75)
                    Case DirectionsEnum.West
                        pt = GetRelativePoint(node, -iOffsetX, 25)
                End Select
        End Select

        Return pt

    End Function


    ' x and y are percentages of the node, so -10, -10 is above and to left of points(0), 100, 100 is points(2)
    Private Function GetRelativePoint(ByVal node As MapNode, ByVal xP As Double, ByVal yP As Double) As Point

        'Dim iWidth As Integer = node.Points(1).X - node.Points(0).X
        'Dim iHeight As Integer = node.Points(3).Y - node.Points(0).Y
        'Dim iSkew As Integer = node.Points(0).X - node.Points(3).X

        'Dim iX As Integer = CInt(iWidth * xP / 100)
        'Dim iY As Integer = CInt(iHeight * yP / 100)

        ''Return New Point(CInt(x + (iSkew / 12)), CInt(y))
        'Return New Point(CInt(node.Points(0).X + iX - (iSkew * yP / 100)), CInt(node.Points(0).Y + iY))

        Return Planes.GetPoint2D(node.Location.X + (node.Width * xP / 100), node.Location.Y + (node.Height * yP / 100), node.Location.Z)

    End Function



    Private Function GetAnchorPoints(ByVal node As MapNode, ByVal xP As Integer, ByVal yP As Integer) As Point()

        Dim pointsAnchor(3) As Point

        pointsAnchor(0) = GetRelativePoint(node, xP - (36 / node.Width), yP - (36 / node.Height))
        pointsAnchor(1) = GetRelativePoint(node, xP + (36 / node.Width), yP - (36 / node.Height))
        pointsAnchor(2) = GetRelativePoint(node, xP + (36 / node.Width), yP + (36 / node.Height))
        pointsAnchor(3) = GetRelativePoint(node, xP - (36 / node.Width), yP + (36 / node.Height))

        Return pointsAnchor

    End Function



    Private Function GetFont(ByVal g As Graphics, ByVal rectF As RectangleF, ByVal sText As String) As Font

        Dim emSize As Single = Math.Min(CSng(rectF.Height / 3), 36)
        Dim fnt As Font
        Dim sf As New StringFormat
        Dim sWords As String() = sText.Split(" "c)
        Dim iWordCount As Integer = sWords.Length

        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        If emSize < 1 Then emSize = 1
        Do
            fnt = New Font("Arial", emSize, FontStyle.Regular, GraphicsUnit.Pixel) ', FontStyle.Regular, GraphicsUnit.Point) ' GraphicsUnit.Pixel)

            'Dim size As SizeF = g.MeasureString(sText, fnt, CInt(rectF.Width), sf)            
            Dim cf As Integer = 0
            Dim lf As Integer = 0
            Dim bOk As Boolean = False

            ' Check the whole text fits in our rectangle
            Dim size As SizeF = g.MeasureString(sText, fnt, New SizeF(rectF.Width, Integer.MaxValue), sf, cf, lf)

            If size.Height <= rectF.Height Then
                ' If it does, check each word individually fits in ok
                bOk = True
                For Each sWord As String In sWords
                    g.MeasureString(sWord, fnt, New SizeF(rectF.Width, Integer.MaxValue), sf, cf, lf)
                    If lf > 1 Then
                        bOk = False
                        Exit For
                    End If
                Next
            End If

            ' emSize <= 1 OrElse (size.Height <= rectF.Height AndAlso Not (Not sText.Contains(" ") AndAlso size.Height > emSize * 2)) AndAlso lf <= iWordCount AndAlso cf >= iMaxWord Then Return fnt
            If bOk OrElse emSize <= 1 Then Return fnt
            emSize -= 1

        Loop

    End Function


    Private Sub tabsMap_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tabsMap.MouseDown

#If Generator Then
        If e.Button = Windows.Forms.MouseButtons.Right then 'AndAlso tabsMap.SelectedTab IsNot Nothing AndAlso tabsMap.SelectedTab Is tabsMap.HotTrackedTab Then
            cmsTabs.Show(imgMap, imgMap.PointToClient(MousePosition))
        End If
#End If

    End Sub



    '#If Not www Then
#If Mono OrElse www Then
    Private Sub tabsMap_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabsMap.SelectedIndexChanged
        imgMap.Parent = tabsMap.SelectedTab
#Else
    Private Sub tabsMap_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabsMap.SelectedTabChanged
#End If
        If bLoading Then Exit Sub
        If Page IsNot Nothing Then
            'For Each node As MapNode In Page.Nodes
            '    If node.Anchors.Count > 0 Then
            '        For Each a As Anchor In node.Anchors
            '            a.Visible = False
            '        Next
            '    End If
            'Next
            If tabsMap.SelectedTab IsNot Nothing Then
#If Mono OrElse www Then
                If Map.Pages.ContainsKey(SafeInt(tabsMap.SelectedTab.Name)) Then
                    Page = Map.Pages(SafeInt(tabsMap.SelectedTab.Name))
#Else
                If Map.Pages.ContainsKey(SafeInt(tabsMap.SelectedTab.Key)) Then
                    Page = Map.Pages(SafeInt(tabsMap.SelectedTab.Key))
#End If
                    RecalculateNodes()
                    CentreMap()
                    RecalculateNodes()
                    ActiveNode = Nothing
                    If Not bLoading AndAlso tabsMap.SelectedTab IsNot Nothing Then
#If Mono OrElse www Then
                        Map.SelectedPage = tabsMap.SelectedTab.Name
#Else
                        Map.SelectedPage = tabsMap.SelectedTab.Key
#End If
                    End If
                End If
            End If
        End If
    End Sub
    '#End If

    Private Sub btnPlanView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlanView.Click
        PlanView()
    End Sub


    Public Sub PlanView()
        iOffsetX = 200
        iOffsetY = 40
        RecalculateNodes()
        imgMap.Refresh()
    End Sub


    Dim ptStart As Point
    Dim ptStartLasso As Point
    Dim ptEndLasso As Point
    Dim iOffsetStartX As Integer = 0
    Dim iOffsetStartY As Integer = 0
    Dim iBoundStartX As Integer = 0
    Dim iBoundStartY As Integer = 0
    Private Sub imgMap_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles imgMap.MouseDown
        ptStart = e.Location
        iOffsetStartX = iOffsetX
        iOffsetStartY = iOffsetY
        iBoundStartX = iBoundX
        iBoundStartY = iBoundY

        If (System.Windows.Forms.Control.ModifierKeys And Keys.Shift) > 0 Then
            ptStartLasso = e.Location
            ActiveNode = Nothing
            SelectedNodes.Clear()
        End If

        bDragged = False

        imgMap_MouseMove(sender, e) ' So any hot-tracks are updated

        If HotTrackedAnchor IsNot Nothing AndAlso SelectedLink IsNot Nothing Then
            'If e.Button = Windows.Forms.MouseButtons.Right Then cmsLink.Show(imgMap, imgMap.PointToClient(MousePosition))
        ElseIf HotTrackedNode IsNot Nothing Then
            Dim bSelectedContainsNew As Boolean = SelectedNodes.Contains(HotTrackedNode)
#If Generator Then
            If (Control.ModifierKeys And Keys.Control) > 0 Then
                If bSelectedContainsNew Then
                    SelectedNodes.Remove(HotTrackedNode)
                Else
                    If ActiveNode Is Nothing Then ActiveNode = HotTrackedNode
                    SelectedNodes.Add(HotTrackedNode)
                End If
            Else
                ActiveNode = HotTrackedNode
                If Not bSelectedContainsNew Then
                    SelectedNodes.Clear()
                    SelectedNodes.Add(HotTrackedNode)
                End If
            End If

            If e.Button = Windows.Forms.MouseButtons.Right Then cmsNode.Show(imgMap, imgMap.PointToClient(MousePosition))
#Else
            Adventure.Player.WalkTo = HotTrackedNode.Key
            Adventure.Player.DoWalk()
#End If

        ElseIf HotTrackedAnchor Is Nothing Then
            If e.Button = Windows.Forms.MouseButtons.Left AndAlso (System.Windows.Forms.Control.ModifierKeys And Keys.Shift) = 0 Then imgMap.Cursor = CType(Cursors.NoMove2D, Cursor)
            If e.Button = Windows.Forms.MouseButtons.Right Then imgMap.Cursor = CType(Cursors.SizeAll, Cursor)
        End If

    End Sub


    Public Sub SelectNode(ByVal sKey As String, Optional ByVal bClearSelectionFirst As Boolean = True)

        If Map Is Nothing Then Exit Sub

        Dim bFoundNode As Boolean = False
        If bClearSelectionFirst Then SelectedNodes.Clear()
        For Each p As MapPage In Map.Pages.Values
            If p.GetNode(sKey) IsNot Nothing Then
#If Mono OrElse www Then
                If tabsMap.TabPages.ContainsKey(p.iKey.ToString) Then
                    Dim iCurrent As Integer = Page.iKey
                    tabsMap.SelectedTab = tabsMap.TabPages(p.iKey.ToString)
#If www Then
                    If p.iKey <> iCurrent Then tabsMap_TabIndexChanged(Nothing, Nothing)
#End If
                Else
                    tabsMap.TabPages.Add(p.iKey.ToString, p.Label)
                    imgMap.Parent = tabsMap.TabPages(p.iKey.ToString)
                    tabsMap.SelectedTab = tabsMap.TabPages(p.iKey.ToString)
                End If
                fRunner.txtInput.Focus()
#Else
                tabsMap.SelectedTab = tabsMap.Tabs(p.iKey.ToString)
#End If
                'Application.DoEvents() ' This causes delay between activating and selecting which looks naff
                ActiveNode = Page.GetNode(sKey)
                bFoundNode = True
            End If
        Next
        If bClearSelectionFirst AndAlso Not bFoundNode Then ActiveNode = Nothing

#If Runner Then
        If LockMapCentre Then
            CentreMap()
            CentreAxis()
        ElseIf LockPlayerCentre AndAlso SelectedNodes.Count > 0 Then
            CentreOnNode(SelectedNodes(0))
            'RecalculateNodes()
            CentreAxis()
        End If
#End If

        imgMap.Refresh()
    End Sub


    Private Function MouseTo3DCoords(ByVal Z As Integer) As Point3D

        Dim ptMouse As Point = imgMap.PointToClient(MousePosition)
        Dim iX As Integer = ptMouse.X + iBoundX
        Dim iY As Integer = ptMouse.Y + iBoundY
        Dim pt As Point = ConvertScreento3D(New Point(iX, iY), Z * iScale)

        Return New Point3D(CInt(pt.X / iScale), CInt(pt.Y / iScale), Z)

    End Function


    Private Sub imgMap_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles imgMap.MouseMove

        Dim bMoved As Boolean = Math.Abs(e.X - ptStart.X) > 3 OrElse Math.Abs(e.Y - ptStart.Y) > 3

#If Generator Then
        If (e.Button = Windows.Forms.MouseButtons.Left AndAlso (Control.ModifierKeys And Keys.Shift) > 0) OrElse e.Button = Windows.Forms.MouseButtons.Middle OrElse (e.Button = Windows.Forms.MouseButtons.Left AndAlso e.Button = Windows.Forms.MouseButtons.Right) Then
            ptEndLasso = e.Location
            imgMap.Cursor = Cursors.Arrow
            Dim x1 As Integer = Math.Min(ptStartLasso.X, ptEndLasso.X)
            Dim y1 As Integer = Math.Min(ptStartLasso.Y, ptEndLasso.Y)
            Dim x2 As Integer = Math.Max(ptStartLasso.X, ptEndLasso.X)
            Dim y2 As Integer = Math.Max(ptStartLasso.Y, ptEndLasso.Y)

            Dim nodes As New Generic.List(Of MapNode)
            For Each node As MapNode In Page.Nodes
                For Each pt As Point In node.Points
                    If pt.X >= x1 AndAlso pt.X <= x2 AndAlso pt.Y >= y1 AndAlso pt.Y <= y2 Then
                        nodes.Add(node)
                        Exit For
                    End If
                Next
            Next

            Dim bRequiresRefresh As Boolean = False
            For i As Integer = SelectedNodes.Count - 1 To 0 Step -1
                If Not nodes.Contains(SelectedNodes(i)) Then
                    SelectedNodes.RemoveAt(i)
                    bRequiresRefresh = True
                End If
            Next
            For Each node As MapNode In nodes
                If Not SelectedNodes.Contains(node) Then
                    SelectedNodes.Add(node, False)
                    bRequiresRefresh = True
                End If
            Next

            If bRequiresRefresh = True Then imgMap.Refresh()
        End If
#End If

        If e.Button = Windows.Forms.MouseButtons.Left AndAlso bMoved Then
#If Generator Then

            bDragged = True

            If HotTrackedAnchor IsNot Nothing Then
                If e.X <> ptStart.X OrElse e.Y <> ptStart.Y Then

                    If TypeOf HotTrackedAnchor.Parent Is MapLink Then
                        ' Move link anchors
                        Dim link As MapLink = CType(HotTrackedAnchor.Parent, MapLink)
                        For i As Integer = 0 To link.Anchors.Count - 1
                            If link.Anchors(i) Is HotTrackedAnchor Then
                                Dim pt As Point3D = MouseTo3DCoords(link.OrigMidPoints(i).Z)
                                link.OrigMidPoints(i) = pt
                                Debug.WriteLine("Dragging link anchor " & i)
                            End If
                        Next
                        RecalculateLinks(Page.GetNode(link.sSource))
                        imgMap.Refresh()

                    ElseIf TypeOf HotTrackedAnchor.Parent Is MapNode Then
                        ' Resize the node
                        If ActiveNode IsNot Nothing Then
                            Dim iXOffset As Integer, iYOffset As Integer, iWidthOffset As Integer, iHeightOffset As Integer

                            Dim pt As Point3D = MouseTo3DCoords(ActiveNode.Location.Z)
                            Dim node As MapNode = CType(HotTrackedAnchor.Parent, MapNode)
                            Select Case True
                                Case HotTrackedAnchor Is node.Anchors(DirectionsEnum.NorthWest)
                                    'If node.Height + node.Location.Y - pt.Y > 0 Then
                                    '    ActiveNode.Height = node.Height + node.Location.Y - pt.Y
                                    '    ActiveNode.Location.Y = pt.Y
                                    'End If
                                    'If node.Width + node.Location.X - pt.X > 0 Then
                                    '    ActiveNode.Width = node.Width + node.Location.X - pt.X
                                    '    ActiveNode.Location.X = pt.X
                                    'End If
                                    iHeightOffset = node.Height + node.Location.Y - pt.Y - ActiveNode.Height
                                    iYOffset = pt.Y - ActiveNode.Location.Y
                                    iWidthOffset = node.Width + node.Location.X - pt.X - ActiveNode.Width
                                    iXOffset = pt.X - ActiveNode.Location.X
                                Case HotTrackedAnchor Is node.Anchors(DirectionsEnum.North)
                                    If node.Height + node.Location.Y - pt.Y > 0 Then
                                        'ActiveNode.Height = node.Height + node.Location.Y - pt.Y
                                        'ActiveNode.Location.Y = pt.Y
                                        iHeightOffset = node.Height + node.Location.Y - pt.Y - ActiveNode.Height
                                        iYOffset = pt.Y - ActiveNode.Location.Y
                                    End If
                                Case HotTrackedAnchor Is node.Anchors(DirectionsEnum.NorthEast)
                                    'If node.Height + node.Location.Y - pt.Y > 0 Then
                                    '    ActiveNode.Height = node.Height + node.Location.Y - pt.Y
                                    '    ActiveNode.Location.Y = pt.Y
                                    'End If
                                    'ActiveNode.Width = Math.Max(pt.X - node.Location.X, 1)
                                    iHeightOffset = node.Height + node.Location.Y - pt.Y - ActiveNode.Height
                                    iYOffset = pt.Y - ActiveNode.Location.Y
                                    iWidthOffset = Math.Max(pt.X - node.Location.X, 1) - ActiveNode.Width
                                Case HotTrackedAnchor Is node.Anchors(DirectionsEnum.East)
                                    'ActiveNode.Width = Math.Max(pt.X - node.Location.X, 1)
                                    iWidthOffset = Math.Max(pt.X - node.Location.X, 1) - ActiveNode.Width
                                Case HotTrackedAnchor Is node.Anchors(DirectionsEnum.SouthEast)
                                    'ActiveNode.Width = Math.Max(pt.X - node.Location.X, 1)
                                    'ActiveNode.Height = Math.Max(pt.Y - node.Location.Y, 1)
                                    iWidthOffset = Math.Max(pt.X - node.Location.X, 1) - ActiveNode.Width
                                    iHeightOffset = Math.Max(pt.Y - node.Location.Y, 1) - ActiveNode.Height
                                Case HotTrackedAnchor Is node.Anchors(DirectionsEnum.South)
                                    'ActiveNode.Height = Math.Max(pt.Y - node.Location.Y, 1)
                                    iHeightOffset = Math.Max(pt.Y - node.Location.Y, 1) - ActiveNode.Height
                                Case HotTrackedAnchor Is node.Anchors(DirectionsEnum.SouthWest)
                                    'If node.Width + node.Location.X - pt.X > 0 Then
                                    '    ActiveNode.Width = node.Width + node.Location.X - pt.X
                                    '    ActiveNode.Location.X = pt.X
                                    'End If
                                    'ActiveNode.Height = Math.Max(pt.Y - node.Location.Y, 1)
                                    iHeightOffset = Math.Max(pt.Y - node.Location.Y, 1) - ActiveNode.Height
                                    iWidthOffset = node.Width + node.Location.X - pt.X - ActiveNode.Width
                                    iXOffset = pt.X - ActiveNode.Location.X
                                Case HotTrackedAnchor Is node.Anchors(DirectionsEnum.West)
                                    If node.Width + node.Location.X - pt.X > 0 Then
                                        'ActiveNode.Width = node.Width + node.Location.X - pt.X
                                        'ActiveNode.Location.X = pt.X
                                        iWidthOffset = node.Width + node.Location.X - pt.X - ActiveNode.Width
                                        iXOffset = pt.X - ActiveNode.Location.X
                                    End If
                            End Select

                            For Each nodeSel As MapNode In SelectedNodes
                                If nodeSel.Height + iHeightOffset > 0 AndAlso nodeSel.Width + iWidthOffset > 0 Then
                                    nodeSel.Height = nodeSel.Height + iHeightOffset
                                    nodeSel.Width = nodeSel.Width + iWidthOffset
                                    nodeSel.Location.X += iXOffset
                                    nodeSel.Location.Y += iYOffset
                                End If
                            Next

                            For Each nodeSel As MapNode In SelectedNodes
                                RecalculateNode(nodeSel)
                            Next

                            Page.CheckForOverlaps()
                            imgMap.Refresh()
                        End If
                    End If
                End If
            ElseIf bMoved AndAlso HotTrackedNode IsNot Nothing AndAlso HotTrackedNode Is ActiveNode Then
                ' Move the selected node                                          
                Dim pt As Point3D = MouseTo3DCoords(ActiveNode.Location.Z)
                Dim iXOffset As Integer = pt.X - CInt(ActiveNode.Width / 2) - ActiveNode.Location.X
                Dim iYOffset As Integer = pt.Y - CInt(ActiveNode.Height / 2) - ActiveNode.Location.Y

                For Each node As MapNode In SelectedNodes
                    node.Location.X += iXOffset
                    node.Location.Y += iYOffset
                Next

                Page.Nodes.Sort()
                For Each node As MapNode In SelectedNodes
                    RecalculateNode(node)
                Next

                Page.CheckForOverlaps()
                imgMap.Refresh()
            ElseIf (Control.ModifierKeys And Keys.Shift) = 0 Then
#End If

            ' Rotate the display
            imgMap.Cursor = CType(Cursors.NoMove2D, Cursor)

            iOffsetX = Math.Max(Math.Min(iOffsetStartX + e.Location.X - ptStart.X, 400), 0)
                iOffsetY = Math.Max(Math.Min(iOffsetStartY - e.Location.Y + ptStart.Y, 250), 0)
                RecalculateNodes()
#If Generator Then
            End If
#End If

            imgMap.Refresh()
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            ' Move the whole map
            imgMap.Cursor = CType(Cursors.SizeAll, Cursor)
            iBoundX = iBoundStartX - e.Location.X + ptStart.X
            iBoundY = iBoundStartY - e.Location.Y + ptStart.Y
            RecalculateNodes()
            imgMap.Refresh()
            'CentreAxis()
        Else
            Dim bRequiresRefresh As Boolean = False

            ' Work out what is under the mouse
            If e.Button = Windows.Forms.MouseButtons.None Then
                Dim nodeHotTrack As MapNode = Nothing
                Dim anchMouse As Anchor = Nothing
                Dim ptMouse As Point = imgMap.PointToClient(MousePosition)

#If Generator Then
                If Page IsNot Nothing Then
                    For Each node As MapNode In Page.Nodes
                        For Each a As Anchor In node.Anchors.Values
                            If PolygonContainsPoint(a.Points, ptMouse) Then
                                anchMouse = a
                                ' Display any anchor the mouse is over
                                a.Visible = True
                            Else
                                If Not node Is ActiveNode Then
                                    ' Unless the anchor is on the selected or new link, then hide it
                                    Dim bHideAnchor As Boolean = True
                                    For Each linkTest As MapLink In New MapLink() {NewLink, SelectedLink, HotTrackedLink}
                                        If linkTest IsNot Nothing Then
                                            Dim nodParent As MapNode = CType(a.Parent, MapNode)
                                            If (linkTest.sSource = nodParent.Key AndAlso linkTest.eSourceLinkPoint = a.Direction) _
                                            OrElse (linkTest.sDestination = nodParent.Key AndAlso linkTest.eDestinationLinkPoint = a.Direction) Then
                                                bHideAnchor = False
                                            End If
                                        End If
                                    Next
                                    If a.Visible = bHideAnchor Then
                                        a.Visible = Not bHideAnchor
                                        bRequiresRefresh = True
                                    End If
                                End If
                            End If
                        Next
                    Next
                End If
                If SelectedLink IsNot Nothing Then
                    For Each a As Anchor In SelectedLink.Anchors
                        If PolygonContainsPoint(a.Points, ptMouse) Then
                            anchMouse = a
                            Exit For
                        End If
                    Next
                End If

                If HotTrackedAnchor IsNot anchMouse Then bRequiresRefresh = True
                If anchMouse IsNot Nothing AndAlso anchMouse.Visible Then
                    HotTrackedAnchor = anchMouse
                Else
                    HotTrackedAnchor = Nothing
                End If

                Dim theHotTrackLink As MapLink = Nothing
                If HotTrackedAnchor IsNot Nothing Then

                    If TypeOf HotTrackedAnchor.Parent Is MapNode Then
                        Dim parNode As MapNode = CType(HotTrackedAnchor.Parent, MapNode)
                        ' Select any link attached to this anchor                        
                        If parNode.Links.ContainsKey(HotTrackedAnchor.Direction) Then
                            theHotTrackLink = parNode.Links(HotTrackedAnchor.Direction)
                        Else
                            ' Look for a link terminating here
                            For Each node As MapNode In Page.Nodes
                                For Each linkOther As MapLink In node.Links.Values
                                    If linkOther.sDestination = parNode.Key AndAlso linkOther.eDestinationLinkPoint = HotTrackedAnchor.Direction Then
                                        theHotTrackLink = linkOther
                                        Exit For
                                    End If
                                Next
                            Next
                        End If
                    End If
                End If
                HotTrackedLink = theHotTrackLink

                ' Only allow node hot tracking if we aren't tracked over an anchor
                If anchMouse Is Nothing AndAlso Page IsNot Nothing Then
                    For iNode As Integer = Page.Nodes.Count - 1 To 0 Step -1
                        If PolygonContainsPoint(Page.Nodes(iNode).Points, ptMouse) Then
                            nodeHotTrack = Page.Nodes(iNode)
                            Exit For
                        End If
                    Next
                End If
                HotTrackedNode = nodeHotTrack

                If HotTrackedNode IsNot Nothing Then
                    If HotTrackedNode Is ActiveNode Then
                        imgMap.Cursor = Cursors.SizeAll
                    Else
                        imgMap.Cursor = Cursors.Hand
                    End If
                Else
                    imgMap.Cursor = Cursors.Arrow
                End If

                If HotTrackedAnchor IsNot Nothing Then
                    If TypeOf HotTrackedAnchor.Parent Is MapLink Then
                        imgMap.Cursor = Cursors.SizeAll
                    End If
                    If NewLink Is Nothing AndAlso HotTrackedAnchor.Parent Is ActiveNode Then
                        Select Case HotTrackedAnchor.Direction
                            Case DirectionsEnum.North, DirectionsEnum.South
                                imgMap.Cursor = Cursors.SizeNS
                            Case DirectionsEnum.East, DirectionsEnum.West
                                imgMap.Cursor = Cursors.SizeWE
                            Case DirectionsEnum.NorthEast, DirectionsEnum.SouthWest
                                imgMap.Cursor = Cursors.SizeNESW
                            Case DirectionsEnum.NorthWest, DirectionsEnum.SouthEast
                                imgMap.Cursor = Cursors.SizeNWSE
                        End Select
                    End If
                End If

                If NewLink IsNot Nothing AndAlso Page IsNot Nothing Then
                    Dim nodStart As MapNode = Page.GetNode(NewLink.sSource)
                    If nodStart IsNot Nothing Then
                        Dim ptEnd As Point3D = MouseTo3DCoords(nodStart.Location.Z)
                        ReDim NewLink.OrigMidPoints(0)
                        NewLink.OrigMidPoints(0) = ptEnd
                        NewLink.Duplex = True
                        Dim bFoundAnchor As Boolean = False
                        For Each nodDest As MapNode In Page.Nodes
                            For Each a As Anchor In nodDest.Anchors.Values
                                If PolygonContainsPoint(a.Points, ptMouse) Then
                                    a.Visible = True
                                    NewLink.sDestination = CType(a.Parent, MapNode).Key
                                    NewLink.eDestinationLinkPoint = a.Direction
                                    If Adventure.htblLocations(NewLink.sDestination).arlDirections(a.Direction).LocationKey <> "" Then
                                        NewLink.Duplex = False
                                    End If
                                    bFoundAnchor = True
                                    Exit For
                                Else
                                    ' Allow start anchor
                                    If Not (nodStart Is nodDest AndAlso NewLink.eSourceLinkPoint = a.Direction) Then a.Visible = False
                                End If
                            Next
                            If bFoundAnchor Then Exit For
                        Next
                        If Not bFoundAnchor Then
                            NewLink.sDestination = ""
                        End If
                        RecalculateLinks(nodStart)

                        bRequiresRefresh = True
                    End If
                End If
#Else
                ' Only allow node hot tracking if we aren't tracked over an anchor
                If anchMouse Is Nothing AndAlso Page IsNot Nothing Then
                    For iNode As Integer = Page.Nodes.Count - 1 To 0 Step -1
                        If PolygonContainsPoint(Page.Nodes(iNode).Points, ptMouse) Then
                            If Page.Nodes(iNode).Seen Then
                                nodeHotTrack = Page.Nodes(iNode)
                                Exit For
                            End If
                        End If
                    Next
                End If
                HotTrackedNode = nodeHotTrack

                If HotTrackedNode IsNot Nothing Then
                    imgMap.Cursor = CType(Cursors.Hand, Cursor)
                Else
                    imgMap.Cursor = CType(Cursors.Arrow, Cursor)
                End If
#End If

                If bRequiresRefresh Then
                    imgMap.Refresh()
                    bRequiresRefresh = False
                End If

            End If
        End If

    End Sub


    Private Sub CentreOnPoint(ByVal point As Point3D, Optional ByVal bCentreOnMouse As Boolean = False)

        Dim pt As Point = TranslateToScreen(point)
        Dim ptTarget As Point

        If bCentreOnMouse Then
            ptTarget = imgMap.PointToClient(MousePosition)
        Else
            ptTarget = New Point(CInt(sizeImage.Width / 2), CInt(sizeImage.Height / 2))
        End If

        iBoundX -= ptTarget.X - pt.X
        iBoundY -= ptTarget.Y - pt.Y

    End Sub


    Public Sub CentreOnNode(ByVal node As MapNode, Optional ByVal bCentreOnMouse As Boolean = False)
        CentreOnPoint(New Point3D(CInt(node.Location.X + (node.Width / 2)), CInt(node.Location.Y + (node.Height / 2)), node.Location.Z), bCentreOnMouse)
    End Sub


    Public Sub CentreAxis()

        ' Work out the current grid ref in the centre of the map on the current axis plane
        Dim pt As Point = ConvertScreento3D(New Point(CInt(Me.Width / 2) + iBoundX, CInt(Me.Height / 2) + iBoundY), 0)
        Dim ptCentre As Point3D = New Point3D(CInt(pt.X / iScale), CInt(pt.Y / iScale), 0)

        'Debug.WriteLine(ptCentre.ToString)

        MoveAxis(ptCentre.X, ptCentre.Y)

    End Sub


    Private Sub MoveAxis(ByVal iX As Integer, ByVal iY As Integer)

        iX = CInt(iX / 2) * 2
        iY = CInt(iY / 2) * 2

        If iX = 0 AndAlso iY = 0 Then Exit Sub

        'Dim pt As Point = ConvertScreento3D(New Point(CInt(Me.Width / 2) + iBoundX, CInt(Me.Height / 2) + iBoundY), 0)
        'Dim ptCentre As Point3D = New Point3D(CInt(pt.X / iScale), CInt(pt.Y / iScale), 0)

        'Debug.WriteLine(ptCentre.ToString)

        ' Change the x and y offset by 1 grid's worth
        Dim pt1 As Point = Planes.GetPoint2D(New Point3D(0, 0, 0))
        Dim pt2 As Point = Planes.GetPoint2D(New Point3D(iX, iY, 0))

        Dim iMoveX As Integer = pt2.X - pt1.X
        Dim iMoveY As Integer = pt2.Y - pt1.Y

        'Debug.WriteLine("X:" & iX & ", Y:" & iY)

        For Each node As MapNode In Page.Nodes
            node.Location.X -= iX
            node.Location.Y -= iY
            For Each link As MapLink In node.Links.Values
                For Each p As Point3D In link.OrigMidPoints
                    p.X -= iX
                    p.Y -= iY
                Next
            Next
        Next

        iBoundX -= iMoveX
        iBoundY -= iMoveY
        RecalculateNodes()
        imgMap.Refresh()

    End Sub


    Public Sub Zoom(Optional ByVal bIn As Boolean = True)

        Dim iLastScale As Integer = iScale
        If bIn Then
            iScale = Math.Min(CInt(iScale * 1.15), 100)
            If iScale < 10 AndAlso iScale = iLastScale Then iScale += 1
        Else
            iScale = Math.Max(CInt(iScale / 1.15), 0)
            If iScale > 1 AndAlso iScale = iLastScale Then iScale -= 1
        End If
        If iScale <> iLastScale Then

            ' See what % the mouse is at within the node range, then re-set that once we've resized
            Dim ptMouse As Point = imgMap.PointToClient(MousePosition)
            Dim rectRange As Rectangle = MapRange()
            Dim pX As Integer = CInt(100 * (ptMouse.X - rectRange.X) / Math.Max(rectRange.Width, 1))
            Dim pY As Integer = CInt(100 * (ptMouse.Y - rectRange.Y) / Math.Max(rectRange.Height, 1))

            ' The location to focus the map back to 
            Dim iFocusX As Integer = ptMouse.X
            Dim iFocusY As Integer = ptMouse.Y

            If ptMouse.Y < 0 OrElse pX < -50 OrElse pX > 150 Then
                pX = 50
                iFocusX = CInt(sizeImage.Width / 2)
            End If
            If ptMouse.Y < 0 OrElse pY < -50 OrElse pY > 150 Then
                pY = 50
                iFocusY = CInt(sizeImage.Height / 2)
            End If

            'Debug.WriteLine(String.Format("Mouse position: {0},{1}", ptMouse.X, ptMouse.Y))
            'Debug.WriteLine(String.Format("Currently {0}% and {1}% in nodes", pX, pY))

            RecalculateNodes()

            rectRange = MapRange()

            iBoundX -= iFocusX - (CInt(pX * rectRange.Width / 100) + rectRange.X)
            iBoundY -= iFocusY - (CInt(pY * rectRange.Height / 100) + rectRange.Y)

            RecalculateNodes()
            imgMap.Refresh()
        End If

    End Sub

    Private Sub imgMap_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles imgMap.MouseWheel
        If e.Delta <> 0 Then Zoom(e.Delta > 1)
    End Sub



    Public Function PolygonContainsPoint(ByVal points() As Point, ByVal pt As PointF) As Boolean

        ' Check basic rectangle first
        If pt.X < Math.Min(points(0).X, points(3).X) OrElse pt.X > Math.Max(points(1).X, points(2).X) _
            OrElse pt.Y < Math.Min(points(0).Y, points(1).Y) OrElse pt.Y > Math.Max(points(2).Y, points(3).Y) Then Return False

        ' If inside the rectangle, do a more specific check
        Dim isIn As Boolean = False
        Dim i As Integer = 0, j As Integer = 3

        Do While i < 4
            If ((((points(i).Y <= pt.Y) AndAlso (pt.Y < points(j).Y)) OrElse ((points(j).Y <= pt.Y) AndAlso (pt.Y < points(i).Y))) _
                AndAlso (pt.X < (points(j).X - points(i).X) * (pt.Y - points(i).Y) / (points(j).Y - points(i).Y) + points(i).X)) Then
                isIn = Not isIn
            End If

            j = i
            i += 1
        Loop

        Return isIn

    End Function



    Private Sub Map_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        imgMap.BackColor = MAPBACKGROUND
        RecalculateNodes()
        ToolStrip1.Visible = False
#If Runner Then
        btnAddNode.Visible = False
#End If
    End Sub


    Private Sub btnCentralise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCentralise.Click
        CentreMap()
    End Sub


    Private Function MapRange() As Rectangle

        If Page.Nodes.Count = 0 Then Return New Rectangle(0, 0, 0, 0)

        Dim iMinX As Integer = Integer.MaxValue
        Dim iMinY As Integer = Integer.MaxValue
        Dim iMaxX As Integer = Integer.MinValue
        Dim iMaxY As Integer = Integer.MinValue
        Dim bFound As Boolean = False

        For Each node As MapNode In Page.Nodes
            With node
                If node.Seen Then
                    If Math.Max(.Points(1).X, .Points(2).X) > iMaxX Then iMaxX = Math.Max(.Points(1).X, .Points(2).X)
                    If Math.Min(.Points(0).X, .Points(3).X) < iMinX Then iMinX = Math.Min(.Points(0).X, .Points(3).X)
                    If Math.Max(.Points(2).Y, .Points(3).Y) > iMaxY Then iMaxY = Math.Max(.Points(2).Y, .Points(3).Y)
                    If Math.Min(.Points(0).Y, .Points(1).Y) < iMinY Then iMinY = Math.Min(.Points(0).Y, .Points(1).Y)
                    bFound = True
                End If
            End With
        Next

        If Not bFound Then Return New Rectangle(0, 0, 0, 0)
        Return New Rectangle(iMinX, iMinY, iMaxX - iMinX, iMaxY - iMinY)

    End Function


    Public Sub CentreMap(Optional ByVal iPage As Integer = -1)

        If Page Is Nothing Then Exit Sub

        '#If www Then
        '        If imgMap.Height = 100 AndAlso imgMap.Width = 200 Then Exit Sub ' Dunno why it's forcing to this size
        '        'RecalculateNodes() - fixes issue going Up/Down at start Jac Jim
        '#End If

        If Page.Nodes.Count = 0 Then
            CentreOnPoint(New Point3D(0, 0, 0))
            Exit Sub
        End If
        'Debug.WriteLine(String.Format("Map width:{0}, MinX:{1}, Nodes width:{2}, Need to offset X by {3}", imgMap.Width, iMinX, iMaxX - iMinX, CInt(iMinX + ((iMaxX - iMinX) / 2) - (imgMap.Width / 2))))

        Dim rectRange As Rectangle = MapRange()
        If rectRange.Width = 0 AndAlso rectRange.Height = 0 Then
            RecalculateNodes(iPage)
            rectRange = MapRange()
        End If

        ' Ok, change our offsets                
        iBoundX += CInt(rectRange.X + (rectRange.Width / 2) - (sizeImage.Width / 2))
        iBoundY += CInt(rectRange.Y + (rectRange.Height / 2) - (sizeImage.Height / 2))
        'iBoundX += CInt(iMinX + ((iMaxX - iMinX) / 2) - (imgMap.Width / 2))
        'iBoundY += CInt(iMinY + ((iMaxY - iMinY) / 2) - (imgMap.Height / 2))
        If iPage = -1 Then
            RecalculateNodes(iPage)
            imgMap.Refresh()
        End If

    End Sub


    Private Sub miEditLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEditLocation.Click
        EditLocation()
    End Sub

    Private Sub miMoveUpDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMoveUp.Click, miMoveDown.Click
        MoveUpDown(sender Is miMoveUp)
    End Sub


    Private Sub MoveUpDown(ByVal bUp As Boolean)
        For Each node As MapNode In SelectedNodes
            node.Location.Z += CInt(IIf(bUp, -1, 1))
            RecalculateNode(node)
        Next
        imgMap.Refresh()
        'If HotTrackedNode IsNot Nothing Then
        '    HotTrackedNode.Location.Z += CInt(IIf(bUp, -1, 1))
        '    RecalculateNode(HotTrackedNode)
        '    imgMap.Refresh()
        'End If
    End Sub

    Private Sub imgMap_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgMap.Resize
#If Not www Then
        sizeImage = imgMap.Size
        CentreMap()
#End If
    End Sub

    Private Sub btnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomIn.Click, btnZoomOut.Click
        Zoom(sender Is btnZoomIn)
    End Sub

    Private Sub imgMap_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles imgMap.PreviewKeyDown
        Debug.WriteLine(e.KeyData)

        'If bRenaming Then
        '    Select Case e.KeyData
        '        Case Keys.Escape
        '            bRenaming = False
        '            Adventure.htblLocations(ActiveNode.Key).ShortDescription = sPreviousName
        '            imgMap.Refresh()
        '        Case Keys.Enter
        '            bRenaming = False
        '            imgMap.Refresh()
        '        Case Keys.Back
        '            Adventure.htblLocations(ActiveNode.Key).ShortDescription = sLeft(Adventure.htblLocations(ActiveNode.Key).ShortDescription, Adventure.htblLocations(ActiveNode.Key).ShortDescription.Length - 1)
        '            imgMap.Refresh()
        '        Case Else
        '            Dim ch As Char = ChrW(e.KeyCode)
        '            If Char.IsLetterOrDigit(ch) OrElse Char.IsPunctuation(ch) Then
        '                Adventure.htblLocations(ActiveNode.Key).ShortDescription &= IIf(e.Shift, UCase(ch), LCase(ch)).ToString
        '            End If
        '            'Select Case ch
        '            '    Case " "c, "a"c To "z"c, "A"c To "Z"c
        '            '        Adventure.htblLocations(ActiveNode.Key).ShortDescription &= IIf(e.Shift, UCase(ch), LCase(ch)).ToString
        '            'End Select
        '            imgMap.Refresh()
        '            'End If                    
        '    End Select
        '    Exit Sub
        'End If

#If Generator Then
        Select Case e.KeyData
            Case Keys.Control Or Keys.Shift Or Keys.P
                Print()
            Case Keys.T
                'MoveAxis(1, 1)
                'CentreAxis()
            Case Keys.Escape
                If NewLink IsNot Nothing Then RemoveLink(NewLink)
                ActiveNode = Nothing
            Case Keys.Control Or Keys.U, Keys.Control Or Keys.D
                MoveUpDown(e.KeyData = (Keys.Control Or Keys.U))
            Case Keys.Delete, Keys.Back
                Dim sKeys As New Generic.List(Of String)
                For Each node As MapNode In SelectedNodes
                    sKeys.Add(node.Key)
                Next
                DeleteItems(sKeys)
                'Case Keys.Space
                '    If SelectedLink IsNot Nothing Then
                '        SelectedLink.Duplex = Not SelectedLink.Duplex
                '    End If
                'Case Keys.T
                '    If SelectedLink IsNot Nothing Then
                '        If SelectedLink.Style = DashStyle.Solid Then
                '            SelectedLink.Style = DashStyle.Dot
                '        Else
                '            SelectedLink.Style = DashStyle.Solid
                '        End If
                '    End If
            Case Keys.Control Or Keys.Shift Or Keys.R
                ResetMap()
        End Select
#Else
        fRunner.txtInput.Focus()
        'fRunner.txtInput.
        SendKeys.Send(LCase(ChrW(e.KeyCode))) ' not perfect, but will have to do
#End If

    End Sub



    Private Sub ResetMap()
        If MessageBox.Show("Are you sure you wish to reset the map?", "Reset Map", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            With Adventure
                .Map = New clsMap
                .Map.RecalculateLayout()
                imgMap.Refresh()
            End With
        End If
    End Sub

    Private Sub RemoveLink(ByVal link As MapLink)

        If SelectedLink Is link Then SelectedLink = Nothing

        Dim nodSource As MapNode = Page.GetNode(link.sSource)
        If nodSource Is Nothing Then Exit Sub
        Dim nodDest As MapNode = Page.GetNode(link.sDestination)
        nodSource.Links.Remove(link.eSourceLinkPoint)
        If nodSource IsNot Nothing AndAlso nodSource IsNot ActiveNode Then nodSource.Anchors(link.eSourceLinkPoint).Visible = False
        If nodDest IsNot Nothing AndAlso nodDest IsNot ActiveNode Then nodDest.Anchors(link.eDestinationLinkPoint).Visible = False
        If NewLink Is link Then NewLink = Nothing
        imgMap.Refresh()

        Dim locSource As clsLocation = Adventure.htblLocations(link.sSource)
        locSource.arlDirections(link.eSourceLinkPoint).Restrictions.Clear()
        locSource.arlDirections(link.eSourceLinkPoint).LocationKey = ""

        If link.sDestination <> "" Then
            Dim locDest As clsLocation = Adventure.htblLocations(link.sDestination)
            locDest.arlDirections(link.eDestinationLinkPoint).Restrictions.Clear()
            locDest.arlDirections(link.eDestinationLinkPoint).LocationKey = ""
        End If

    End Sub


    Private Sub miDeleteLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDeleteLink.Click
        If SelectedLink IsNot Nothing Then RemoveLink(SelectedLink)
    End Sub


    'Private Sub DeleteLink(ByVal link As MapLink)
    '    Page.GetNode(link.sSource).Links.Remove(link.eSourceLinkPoint)
    'End Sub


    Private Sub imgMap_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles imgMap.MouseUp
        'bAllowMoveSelected = True
        CentreAxis()
        'imgMap.Refresh()
    End Sub


    Private Sub btnAddNode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNode.Click
        AddLocation()
    End Sub


    Public Sub AddLocation()
        AddNode(True)
    End Sub

    Private Sub miAddAnchor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miAddAnchor.Click

        Try

            If SelectedLink IsNot Nothing Then
                Dim ptStart As Point3D, ptEnd As Point3D

                If HotTrackedAnchor Is Nothing OrElse HotTrackedAnchor.Direction = SelectedLink.eSourceLinkPoint Then
                    ' Add anchor between start anchor and first/end anchor
                    ptStart = Page.GetNode(SelectedLink.sSource).Anchors(SelectedLink.eSourceLinkPoint).GetApproxPoint3D
                    If SelectedLink.OrigMidPoints.Length > 0 Then
                        ptEnd = SelectedLink.OrigMidPoints(0)
                    Else
                        ptEnd = Page.GetNode(SelectedLink.sDestination).Anchors(SelectedLink.eDestinationLinkPoint).GetApproxPoint3D
                    End If
                Else
                    ' Add anchor between start/second last anchor and last anchor
                    If SelectedLink.OrigMidPoints.Length > 0 Then
                        ptStart = SelectedLink.OrigMidPoints(SelectedLink.OrigMidPoints.Length - 1)
                    Else
                        ptStart = Page.GetNode(SelectedLink.sSource).Anchors(SelectedLink.eSourceLinkPoint).GetApproxPoint3D
                    End If
                    ptEnd = Page.GetNode(SelectedLink.sDestination).Anchors(SelectedLink.eDestinationLinkPoint).GetApproxPoint3D
                End If

                ' Find the location half way between the source point and either the first point or the destination point            
                Dim ptMid As New Point3D(CInt((ptStart.X + ptEnd.X) / 2), CInt((ptStart.Y + ptEnd.Y) / 2), CInt((ptStart.Z + ptEnd.Z) / 2))
                ReDim Preserve SelectedLink.OrigMidPoints(SelectedLink.OrigMidPoints.Length)

                ' Create the point mid-way between the other two points
                If HotTrackedAnchor Is Nothing OrElse HotTrackedAnchor.Direction = SelectedLink.eSourceLinkPoint Then
                    For i As Integer = SelectedLink.OrigMidPoints.Length - 1 To 1 Step -1
                        SelectedLink.OrigMidPoints(i) = SelectedLink.OrigMidPoints(i - 1)
                    Next
                    SelectedLink.OrigMidPoints(0) = ptMid
                Else
                    SelectedLink.OrigMidPoints(SelectedLink.OrigMidPoints.Length - 1) = ptMid
                End If

                Dim a As New Anchor
                a.Visible = True
                a.Parent = SelectedLink
                SelectedLink.Anchors.Add(a)

                RecalculateLinks(Page.GetNode(SelectedLink.sSource))
                imgMap.Refresh()
            End If

        Catch ex As Exception
            ErrMsg("Error adding anchor", ex)
        End Try

    End Sub


    Private Sub miRenameLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miRenameLocation.Click
        RenameNode()
    End Sub


    Private Sub RenameNode()
        'bRenaming = True
        'sPreviousName = Adventure.htblLocations(ActiveNode.Key).ShortDescription
        txtRename.Text = Adventure.htblLocations(ActiveNode.Key).ShortDescription.ToString
        txtRename.Tag = txtRename.Text
        txtRename.Visible = True
        txtRename.Focus()
        imgMap.Refresh()
    End Sub



    Private Sub txtRename_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRename.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Adventure.htblLocations(ActiveNode.Key).ShortDescription.Item(0).Description = txtRename.Tag.ToString
                UpdateLocDescription(ActiveNode.Key, txtRename.Tag.ToString)
                ActiveNode.Text = txtRename.Tag.ToString
                txtRename.Visible = False
                e.SuppressKeyPress = True
                e.Handled = True
            Case Keys.Enter
                txtRename.Visible = False
                e.SuppressKeyPress = True
                e.Handled = True
        End Select
        imgMap.Refresh()
    End Sub


    Private Sub txtRename_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRename.KeyUp
        imgMap.Refresh()
    End Sub


    Private Sub txtRename_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRename.LostFocus
        txtRename.Visible = False
    End Sub



    Private Sub txtRename_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRename.TextChanged
        Adventure.htblLocations(ActiveNode.Key).ShortDescription.Item(0).Description = txtRename.Text
        ActiveNode.Text = txtRename.Text
        UpdateLocDescription(ActiveNode.Key, txtRename.Text)
        imgMap.Refresh()
    End Sub


    Private Sub miOneWayLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miOneWayLink.Click

        If Not SelectedLink.Duplex Then
            ' Attempt to make the link duplex.  It may not be possible if the other end already has a link            
            If Adventure.htblLocations(SelectedLink.sDestination).arlDirections(SelectedLink.eDestinationLinkPoint).LocationKey = "" Then
                Adventure.htblLocations(SelectedLink.sDestination).arlDirections(SelectedLink.eDestinationLinkPoint).LocationKey = SelectedLink.sSource
                SelectedLink.Duplex = True
            Else
                ErrMsg("Unable to make the link 2-way as the other end already has an outgoing route.")
            End If
        Else
            ' TODO - warn if there are restrictions
            Adventure.htblLocations(SelectedLink.sDestination).arlDirections(SelectedLink.eDestinationLinkPoint).LocationKey = ""
            SelectedLink.Duplex = False
        End If

    End Sub


    Private Sub cmsLink_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsLink.Opening
        If SelectedLink IsNot Nothing Then miOneWayLink.Checked = Not SelectedLink.Duplex
    End Sub


    Private Sub cmsNode_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsNode.Opening

        miMoveToPage.DropDownItems.Clear()
        For Each iPage As Integer In Map.Pages.Keys
            If iPage <> Page.iKey Then
                Dim tsi As ToolStripItem = miMoveToPage.DropDownItems.Add(Map.Pages(iPage).Label, Nothing, AddressOf MoveToPage)
                tsi.Tag = iPage
            End If
        Next
        'For Each tab As Infragistics.Win.UltraWinTabControl.UltraTab In tabsMap.Tabs
        '    If SafeInt(tab.Key) <> Page.iKey Then
        '        Dim tsi As ToolStripItem = miMoveToPage.DropDownItems.Add(Map.Pages(SafeInt(tab.Key)).Label, Nothing, AddressOf MoveToPage)
        '        tsi.Tag = SafeInt(tab.Key)
        '    End If
        'Next
        miMoveToPage.Visible = (miMoveToPage.DropDownItems.Count > 0)

    End Sub


    Private Sub MoveToPage(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim tsi As ToolStripItem = CType(sender, ToolStripItem)
        Dim iPage As Integer = SafeInt(tsi.Tag)
        Dim iPageFrom As Integer = ActiveNode.Page

        For Each n As MapNode In SelectedNodes
            Map.MoveNodeToPage(n, iPage)
        Next

#If Mono OrElse www Then
        If Not Map.Pages.ContainsKey(iPageFrom) Then tabsMap.TabPages.Remove(tabsMap.TabPages(iPageFrom.ToString))
        tabsMap.SelectedTab = tabsMap.TabPages(iPage.ToString)
#Else
        If Not Map.Pages.ContainsKey(iPageFrom) Then tabsMap.Tabs.Remove(tabsMap.Tabs(iPageFrom.ToString))
        tabsMap.SelectedTab = tabsMap.Tabs(iPage.ToString)
#End If

        imgMap.Refresh()

    End Sub


    Private Sub miRenamePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miRenamePage.Click
        Dim sTabLabel As String = InputBox("Enter page label:", "Rename page", Page.Label)
        If sTabLabel <> "" Then

#If Mono OrElse www Then
            Dim tab As TabPage = tabsMap.SelectedTab
            Map.Pages(SafeInt(tab.Name)).Label = sTabLabel
#Else
            Dim tab As Infragistics.Win.UltraWinTabControl.UltraTab = tabsMap.SelectedTab
            Map.Pages(SafeInt(tab.Key)).Label = sTabLabel
#End If
            tab.Text = sTabLabel

        End If
    End Sub

#If Not Mono AndAlso Not www Then
    Public Sub AddPage()
        With Map
            Dim iNewPage As Integer = .GetNewPage(True)
            .Pages.Add(iNewPage, New MapPage(iNewPage))
            tabsMap.Tabs.Clear()
            For Each iPage As Integer In .Pages.Keys
                tabsMap.Tabs.Add(iPage.ToString, .Pages(iPage).Label)
            Next
            tabsMap.SelectedTab = tabsMap.Tabs(iNewPage)
        End With
    End Sub

    Private Sub miAddPage_Click(sender As System.Object, e As System.EventArgs) Handles miAddPage.Click
        AddPage()
    End Sub
#End If


#If Not Mono AndAlso Not www Then
    Private Sub tabsMap_TabMoved(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTabControl.TabMovedEventArgs) Handles tabsMap.TabMoved
        Dim NewPages As New Generic.Dictionary(Of Integer, MapPage)
        For iPosition As Integer = 0 To Map.Pages.Count - 1
            For Each tab As Infragistics.Win.UltraWinTabControl.UltraTab In tabsMap.Tabs
                If tab.VisibleIndex = iPosition Then
                    Dim page As MapPage = Map.Pages(SafeInt(tab.Key))
                    NewPages.Add(page.iKey, page)
                    Exit For
                End If
            Next
        Next
        Map.Pages = NewPages
    End Sub
#End If

    Private Sub imgMap_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgMap.MouseLeave
        HotTrackedAnchor = Nothing
        HotTrackedLink = Nothing
        HotTrackedNode = Nothing
    End Sub


    Private Sub miDeleteNode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miDeleteNode.Click
#If Generator Then
        Dim sKeys As New Generic.List(Of String)
        For Each n As MapNode In SelectedNodes
            sKeys.Add(n.Key)
        Next
        DeleteItems(sKeys)
#End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.     
        '#If www Then
        '        imgMap.Image = New Bitmap(400, 300) ' Me.ClientSize.Width, Me.ClientSize.Height)                
        '#End If
    End Sub


#Region "Trizbort"

#If Generator Then
    Public Function ImportTrizbort(ByVal trizbort As trizbort) As Boolean

        If Adventure.htblLocations.Count > 0 Then AddPage()
        Page = Map.Pages(Map.Pages.Count - 1)
        Dim dictIDs As New Dictionary(Of Integer, String)

        With trizbort
            With .info
                If Adventure.Title = "Untitled" AndAlso .title <> "" Then Adventure.Title = .title
                If Adventure.Author = "Anonymous" AndAlso .author <> "" Then Adventure.Author = .author
                If .title <> "" Then
                    Page.Label = .title
                    fGenerator.Map1.tabsMap.SelectedTab.Text = .title
                End If
            End With

            For Each oElement As Object In trizbort.map
                If TypeOf oElement Is trizbortRoom Then
                    Dim room As trizbortRoom = CType(oElement, trizbortRoom)

                    Dim loc As New clsLocation
                    loc.Key = loc.GetNewKey
                    loc.ShortDescription = New Description(room.name)
                    Adventure.htblLocations.Add(loc, loc.Key)
                    UpdateLocDescription(loc.Key, loc.ShortDescription.ToString)
                    If room.description <> "" Then loc.LongDescription = New Description(room.description)


                    Dim node As New MapNode
                    dictIDs.Add(room.id, loc.Key)
                    node.Key = loc.Key
                    node.Page = Page.iKey
                    node.Location = New Point3D(CInt(room.x / 16), CInt(room.y / 16), 0)
                    node.Width = CInt(room.w / 16)
                    node.Height = CInt(room.h / 16)
                    node.Text = loc.ShortDescriptionSafe
                    Page.AddNode(node)
                End If
            Next

            ' First pass, map the directions that are exact N, E, SE etc
            ' Second pass, map the ENE etc directions onto the best fit
            '
            For iPass As Integer = 0 To 1
                For Each oElement As Object In trizbort.map
                    If TypeOf oElement Is trizbortLine Then
                        Dim line As trizbortLine = CType(oElement, trizbortLine)
                        Dim link As New MapLink
                        Dim bOKToAdd As Boolean = True
                        Dim locSource As clsLocation = Nothing
                        Dim locDest As clsLocation = Nothing

                        If line.flow = "oneWay" Then
                            link.Duplex = False
                        Else
                            link.Duplex = True
                        End If

                        If line.dock IsNot Nothing Then
                            If line.dock.Length > 0 Then
                                With line.dock(0)
                                    link.sSource = dictIDs(.id)
                                    locSource = Adventure.htblLocations(link.sSource)
                                    link.eSourceLinkPoint = CType(-1, DirectionsEnum)

                                    If iPass = 0 Then
                                        Select Case line.startText
                                            Case "up"
                                                If locSource.arlDirections(DirectionsEnum.Up).LocationKey = "" Then link.eSourceLinkPoint = DirectionsEnum.Up
                                            Case "down"
                                                If locSource.arlDirections(DirectionsEnum.Down).LocationKey = "" Then link.eSourceLinkPoint = DirectionsEnum.Down
                                            Case "out"
                                                If locSource.arlDirections(DirectionsEnum.In).LocationKey = "" Then
                                                    link.eSourceLinkPoint = DirectionsEnum.In
                                                    Page.GetNode(link.sSource).bHasIn = True
                                                End If
                                            Case "in"
                                                If locSource.arlDirections(DirectionsEnum.Out).LocationKey = "" Then
                                                    link.eSourceLinkPoint = DirectionsEnum.Out
                                                    Page.GetNode(link.sSource).bHasOut = True
                                                End If
                                        End Select
                                    Else
                                        Select Case line.startText
                                            Case "up", "down", "in", "out"
                                                bOKToAdd = False
                                        End Select
                                    End If

                                    If link.eSourceLinkPoint = CType(-1, DirectionsEnum) Then
                                        Select Case .port
                                            Case "n"
                                                If iPass = 0 Then link.eSourceLinkPoint = DirectionsEnum.North Else bOKToAdd = False
                                            Case "e"
                                                If iPass = 0 Then link.eSourceLinkPoint = DirectionsEnum.East Else bOKToAdd = False
                                            Case "s"
                                                If iPass = 0 Then link.eSourceLinkPoint = DirectionsEnum.South Else bOKToAdd = False
                                            Case "w"
                                                If iPass = 0 Then link.eSourceLinkPoint = DirectionsEnum.West Else bOKToAdd = False
                                            Case "ne"
                                                If iPass = 0 Then link.eSourceLinkPoint = DirectionsEnum.NorthEast Else bOKToAdd = False
                                            Case "se"
                                                If iPass = 0 Then link.eSourceLinkPoint = DirectionsEnum.SouthEast Else bOKToAdd = False
                                            Case "sw"
                                                If iPass = 0 Then link.eSourceLinkPoint = DirectionsEnum.SouthWest Else bOKToAdd = False
                                            Case "nw"
                                                If iPass = 0 Then link.eSourceLinkPoint = DirectionsEnum.NorthWest Else bOKToAdd = False
                                            Case "nne", "ene", "ese", "sse", "ssw", "wsw", "wnw", "nnw"
                                                If iPass = 1 Then
                                                    link.eSourceLinkPoint = FindSpareLink(locSource, .port, False)
                                                    If link.eSourceLinkPoint = CType(-1, DirectionsEnum) Then bOKToAdd = False
                                                Else
                                                    bOKToAdd = False
                                                End If
                                        End Select
                                    End If
                                End With
                            End If

                            If bOKToAdd AndAlso line.dock.Length > 1 Then
                                With line.dock(1)
                                    link.sDestination = dictIDs(.id)
                                    locDest = Adventure.htblLocations(link.sDestination)

                                    Select Case line.endText
                                        Case "up"
                                            link.eDestinationLinkPoint = DirectionsEnum.Up
                                        Case "down"
                                            link.eDestinationLinkPoint = DirectionsEnum.Down
                                        Case "out"
                                            link.eDestinationLinkPoint = DirectionsEnum.In
                                            Page.GetNode(link.sDestination).bHasIn = True
                                        Case "in"
                                            link.eDestinationLinkPoint = DirectionsEnum.Out
                                            Page.GetNode(link.sDestination).bHasOut = True
                                        Case Else
                                            Select Case .port
                                                Case "n"
                                                    link.eDestinationLinkPoint = DirectionsEnum.North
                                                Case "e"
                                                    link.eDestinationLinkPoint = DirectionsEnum.East
                                                Case "s"
                                                    link.eDestinationLinkPoint = DirectionsEnum.South
                                                Case "w"
                                                    link.eDestinationLinkPoint = DirectionsEnum.West
                                                Case "ne"
                                                    link.eDestinationLinkPoint = DirectionsEnum.NorthEast
                                                Case "se"
                                                    link.eDestinationLinkPoint = DirectionsEnum.SouthEast
                                                Case "sw"
                                                    link.eDestinationLinkPoint = DirectionsEnum.SouthWest
                                                Case "nw"
                                                    link.eDestinationLinkPoint = DirectionsEnum.NorthWest
                                                Case "nne", "ene", "ese", "sse", "ssw", "wsw", "wnw", "nnw"
                                                    link.eDestinationLinkPoint = FindSpareLink(locDest, .port, Not link.Duplex)
                                            End Select
                                    End Select


                                End With
                            Else
                                link.sDestination = link.sSource
                                link.eDestinationLinkPoint = OppositeDirection(link.eSourceLinkPoint)
                            End If
                        Else
                            bOKToAdd = False
                        End If

                        If bOKToAdd Then
                            Page.GetNode(link.sSource).Links.Add(link.eSourceLinkPoint, link)
                            If link.sSource <> "" Then
                                With Adventure.htblLocations(link.sSource)
                                    Dim dir As New clsDirection
                                    dir.LocationKey = link.sDestination
                                    .arlDirections(link.eSourceLinkPoint) = dir
                                End With
                            End If
                            If link.sDestination <> "" AndAlso link.Duplex Then
                                With Adventure.htblLocations(link.sDestination)
                                    Dim dir As New clsDirection
                                    dir.LocationKey = link.sSource
                                    .arlDirections(link.eDestinationLinkPoint) = dir
                                End With
                            End If
                        End If
                    End If
                Next
            Next

            fGenerator.Map1.tabsMap.SelectedTab = fGenerator.Map1.tabsMap.Tabs(Page.iKey)
            RecalculateNodes()
            imgMap.Refresh()
            UpdateMainTitle()

        End With

    End Function
#End If

    Private Function FindSpareLink(ByVal loc As clsLocation, ByVal sDirection As String, ByVal bAllowExist As Boolean) As DirectionsEnum

        Select Case sDirection
            Case "nne"
                For Each d As DirectionsEnum In New DirectionsEnum() {DirectionsEnum.North, DirectionsEnum.NorthEast, DirectionsEnum.NorthWest, DirectionsEnum.East, DirectionsEnum.West, DirectionsEnum.SouthEast, DirectionsEnum.SouthWest, DirectionsEnum.South}
                    If bAllowExist OrElse loc.arlDirections(d).LocationKey = "" Then Return d
                Next
            Case "ene"
                For Each d As DirectionsEnum In New DirectionsEnum() {DirectionsEnum.East, DirectionsEnum.NorthEast, DirectionsEnum.SouthEast, DirectionsEnum.North, DirectionsEnum.South, DirectionsEnum.NorthWest, DirectionsEnum.SouthWest, DirectionsEnum.West}
                    If bAllowExist OrElse loc.arlDirections(d).LocationKey = "" Then Return d
                Next
            Case "ese"
                For Each d As DirectionsEnum In New DirectionsEnum() {DirectionsEnum.East, DirectionsEnum.SouthEast, DirectionsEnum.NorthEast, DirectionsEnum.South, DirectionsEnum.North, DirectionsEnum.SouthWest, DirectionsEnum.NorthWest, DirectionsEnum.West}
                    If bAllowExist OrElse loc.arlDirections(d).LocationKey = "" Then Return d
                Next
            Case "sse"
                For Each d As DirectionsEnum In New DirectionsEnum() {DirectionsEnum.South, DirectionsEnum.SouthEast, DirectionsEnum.SouthWest, DirectionsEnum.East, DirectionsEnum.West, DirectionsEnum.NorthEast, DirectionsEnum.NorthWest, DirectionsEnum.North}
                    If bAllowExist OrElse loc.arlDirections(d).LocationKey = "" Then Return d
                Next
            Case "ssw"
                For Each d As DirectionsEnum In New DirectionsEnum() {DirectionsEnum.South, DirectionsEnum.SouthWest, DirectionsEnum.SouthEast, DirectionsEnum.West, DirectionsEnum.East, DirectionsEnum.NorthWest, DirectionsEnum.NorthEast, DirectionsEnum.North}
                    If bAllowExist OrElse loc.arlDirections(d).LocationKey = "" Then Return d
                Next
            Case "wsw"
                For Each d As DirectionsEnum In New DirectionsEnum() {DirectionsEnum.West, DirectionsEnum.SouthWest, DirectionsEnum.NorthWest, DirectionsEnum.South, DirectionsEnum.North, DirectionsEnum.SouthEast, DirectionsEnum.NorthEast, DirectionsEnum.East}
                    If bAllowExist OrElse loc.arlDirections(d).LocationKey = "" Then Return d
                Next
            Case "wnw"
                For Each d As DirectionsEnum In New DirectionsEnum() {DirectionsEnum.West, DirectionsEnum.NorthWest, DirectionsEnum.SouthWest, DirectionsEnum.North, DirectionsEnum.South, DirectionsEnum.NorthEast, DirectionsEnum.SouthEast, DirectionsEnum.East}
                    If bAllowExist OrElse loc.arlDirections(d).LocationKey = "" Then Return d
                Next
            Case "nnw"
                For Each d As DirectionsEnum In New DirectionsEnum() {DirectionsEnum.North, DirectionsEnum.NorthWest, DirectionsEnum.NorthEast, DirectionsEnum.West, DirectionsEnum.East, DirectionsEnum.SouthWest, DirectionsEnum.SouthEast, DirectionsEnum.South}
                    If bAllowExist OrElse loc.arlDirections(d).LocationKey = "" Then Return d
                Next
        End Select

        Return CType(-1, DirectionsEnum)

    End Function


#End Region



#Region "Printing"

    Private WithEvents printDoc As Printing.PrintDocument

    Public Sub Print()

        Try
            If printDoc Is Nothing Then printDoc = New Printing.PrintDocument

            'Dim dlgPrintPreview As New PrintPreviewDialog
            'With dlgPrintPreview
            '    .Document = printDoc            
            '    .ShowDialog()
            'End With
            Dim dlgPrint As New PrintDialog
            With dlgPrint
                .Document = printDoc
                .AllowSomePages = True
                .AllowCurrentPage = True
                .AllowSelection = True
                .PrinterSettings.FromPage = 1
#If Mono Then
                .PrinterSettings.ToPage = tabsMap.TabCount
#ElseIf www Then
                .PrinterSettings.ToPage = Map.Pages.Count
#Else
                .PrinterSettings.ToPage = tabsMap.Tabs.Count
#End If

                If .ShowDialog() = DialogResult.OK Then
                    printDoc.Print()
                End If
            End With

        Catch ex As Exception
            ErrMsg("Error printing out map", ex)
        End Try
        
    End Sub


    Private Sub printDoc_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles printDoc.BeginPrint
        iPrintPage = 0
        oStartPage = Page
        iBoundXStore = iBoundX
        iBoundYStore = iBoundY
        iScaleStore = iScale
    End Sub


    Private iPrintPage As Integer = 0
    Private oStartPage As MapPage
    Private iBoundXStore As Integer = 0
    Private iBoundYStore As Integer = 0
    Private iScaleStore As Integer = 0

    Private Sub printDoc_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles printDoc.PrintPage

        'Retry:
        '        Dim bPrintThisPage As Boolean = False

        '        Select Case e.PageSettings.PrinterSettings.PrintRange
        '            Case Printing.PrintRange.AllPages
        '                bPrintThisPage = True
        '            Case Printing.PrintRange.CurrentPage
        '                bPrintThisPage = (tabsMap.SelectedTab.Index = iPrintPage)
        '            Case Printing.PrintRange.SomePages
        '                bPrintThisPage = iPrintPage >= e.PageSettings.PrinterSettings.FromPage - 1 AndAlso iPrintPage <= e.PageSettings.PrinterSettings.ToPage - 1
        '            Case Printing.PrintRange.Selection
        '        End Select

        '        If Not bPrintThisPage Then
        '            iPrintPage += 1
        '            If iPrintPage = Map.Pages.Count Then Exit Sub            
        '            GoTo Retry
        '        End If


        Dim iKey As Integer = KeyFromPage(iPrintPage)
        If Not Map.Pages.ContainsKey(iKey) Then Exit Sub

        'Me.sizeImage = New Size(e.MarginBounds.Width, e.MarginBounds.Height)
        Me.sizeImage = New Size(e.PageBounds.Width, e.PageBounds.Height)
        iScale = iScaleStore

        Page = Map.Pages(iKey)

        CentreMap(iKey)
        RecalculateNodes(iKey)
        PaintGraphics(e.Graphics)
        
        iPrintPage += 1

        Dim iLastPage As Integer = Map.Pages.Count
           Select e.PageSettings.PrinterSettings.PrintRange
            Case Printing.PrintRange.AllPages
                ' Leave as last page
            Case Printing.PrintRange.CurrentPage, Printing.PrintRange.Selection
#If Mono Then
                iLastPage = tabsMap.SelectedIndex + 1
#ElseIf Not www Then
                iLastPage = tabsMap.SelectedTab.Index + 1
#End If
            Case Printing.PrintRange.SomePages
                iLastPage = e.PageSettings.PrinterSettings.ToPage '- 1            
        End Select

        e.HasMorePages = iPrintPage < iLastPage

    End Sub


    Private Sub printDoc_EndPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles printDoc.EndPrint
        Page = oStartPage
        Me.sizeImage = imgMap.Size
        iBoundX = iBoundXStore
        iBoundY = iBoundYStore
        iScale = iScaleStore
        RecalculateNodes()
    End Sub


    Private Sub printDoc_QueryPageSettings(sender As Object, e As System.Drawing.Printing.QueryPageSettingsEventArgs) Handles printDoc.QueryPageSettings

Retry:
        Dim bPrintThisPage As Boolean = False

        Select Case e.PageSettings.PrinterSettings.PrintRange
            Case Printing.PrintRange.AllPages
                bPrintThisPage = True
            Case Printing.PrintRange.CurrentPage, Printing.PrintRange.Selection
#If Mono Then                
                bPrintThisPage = (tabsMap.SelectedIndex = iPrintPage)
#ElseIf Not www Then
                bPrintThisPage = (tabsMap.SelectedTab.Index = iPrintPage)
#End If                
            Case Printing.PrintRange.SomePages
                bPrintThisPage = iPrintPage >= e.PageSettings.PrinterSettings.FromPage - 1 AndAlso iPrintPage <= e.PageSettings.PrinterSettings.ToPage - 1            
        End Select

        If Not bPrintThisPage Then
            iPrintPage += 1
            If iPrintPage = Map.Pages.Count Then
                'e.Cancel = True
                Exit Sub
            End If
            GoTo Retry
        End If

        Dim iKey As Integer = KeyFromPage(iPrintPage)
        Page = Map.Pages(iKey)
        RecalculateNodes(iKey)
        Dim range As Rectangle = MapRange()

        If range.Width > range.Height Then
            e.PageSettings.Landscape = True
        Else
            e.PageSettings.Landscape = False
        End If
        'e.PageSettings.PrinterSettings.ToPage = tabsMap.Tabs.Count
        If range.Width > sizeImage.Width Then
            iScale = CInt(iScale * (sizeImage.Width / range.Width))
            RecalculateNodes(iKey)
        End If

    End Sub


    Private Function KeyFromPage(ByVal iPage As Integer) As Integer
        Dim iCount As Integer = 0
        For Each Page As Integer In Map.Pages.Keys
            If iPage = iCount Then Return Page
            iCount += 1
        Next
        Return -1
    End Function

#End Region

End Class
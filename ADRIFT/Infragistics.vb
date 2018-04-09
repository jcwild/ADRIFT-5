Imports Infragistics
Imports Infragistics.Win

Module InfragisticsStuff

#If Generator Then
    Public Function EnumParseViewStyle(ByVal sValue As String) As Infragistics.Win.UltraWinToolbars.ToolbarStyle
        Select Case sValue
            Case "Default", "Standard"
                Return UltraWinToolbars.ToolbarStyle.Default
            Case "Office2003"
                Return UltraWinToolbars.ToolbarStyle.Office2003
            Case "Office2007"
                Return UltraWinToolbars.ToolbarStyle.Office2007
            Case "VisualStudio2005"
                Return UltraWinToolbars.ToolbarStyle.VisualStudio2005
            Case "Office2010"
                Return UltraWinToolbars.ToolbarStyle.Office2010
            Case "Office2013"
                Return UltraWinToolbars.ToolbarStyle.Office2013
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function
#Else
    Public Function EnumParseViewStyle(ByVal sValue As String) As Infragistics.Win.UltraWinToolbars.ToolbarStyle
        Select Case sValue
            Case "Default", "Standard"
                Return UltraWinToolbars.ToolbarStyle.Default
            Case "Office2003"
                Return UltraWinToolbars.ToolbarStyle.Office2003
            Case "Office2007"
                Return UltraWinToolbars.ToolbarStyle.Office2007
            Case "Office2010"
                Return UltraWinToolbars.ToolbarStyle.Office2010
            Case "Office2013"
                Return UltraWinToolbars.ToolbarStyle.Office2013
            Case "VisualStudio2005"
                Return UltraWinToolbars.ToolbarStyle.VisualStudio2005
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function

#End If


    Public Sub AddPrevious(ByVal UTMMain As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager, ByVal sProject As String)

        Dim sFilename As String

        For iPrevious As Integer = 1 To 20
            sFilename = GetSetting("ADRIFT", sProject, "Recent_" & iPrevious, "")
            If sFilename <> "" Then
#If Generator Then
                Dim sJustFile As String = sFilename
                If sJustFile.Contains("\") Then sJustFile = sRight(sJustFile, sJustFile.Length - sJustFile.LastIndexOf("\") - 1)
                If iPrevious < 10 Then sJustFile = "&" & iPrevious & "   " & sJustFile Else sJustFile = "     " & sJustFile
                AddTool(UTMMain, "mnuRecentAdventures", sFilename, sJustFile, "_RECENT_", , sFilename)

                UTMMain.Ribbon.ApplicationMenu.ToolAreaRight.Tools.AddTool(sFilename)
#Else
                fRunner.AddTool(UTMMain, "mnuRecentAdventures", sFilename, "&" & iPrevious & "  " & sFilename, "_RECENT_")
#End If

            End If
        Next

    End Sub


    Public Sub SetOptSet(ByVal opt As Infragistics.Win.UltraWinEditors.UltraOptionSet, ByVal iKey As Integer)

        For Each vli As Infragistics.Win.ValueListItem In opt.Items
            If CInt(vli.DataValue) = iKey Then
                opt.CheckedItem = vli
                Exit Sub
            End If
        Next

    End Sub



    Public Function EnumParseColourScheme2007(ByVal sValue As String) As Infragistics.Win.Office2007ColorScheme
        Select Case sValue
            Case "Blue"
                Return Infragistics.Win.Office2007ColorScheme.Blue
            Case "Silver"
                Return Infragistics.Win.Office2007ColorScheme.Silver
            Case "Black"
                Return Infragistics.Win.Office2007ColorScheme.Black
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function
    Public Function EnumParseColourScheme2010(ByVal sValue As String) As Infragistics.Win.Office2010ColorScheme
        Select Case sValue
            Case "Blue"
                Return Infragistics.Win.Office2010ColorScheme.Blue
            Case "Silver"
                Return Infragistics.Win.Office2010ColorScheme.Silver
            Case "Black"
                Return Infragistics.Win.Office2010ColorScheme.Black
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function
    Public Function EnumParseColourScheme2013(ByVal sValue As String) As Infragistics.Win.Office2013ColorScheme
        Select Case sValue
            Case "Blue", "LightGray"
                Return Infragistics.Win.Office2013ColorScheme.LightGray
            Case "Silver", "White"
                Return Infragistics.Win.Office2013ColorScheme.White
            Case "Black", "DarkGray"
                Return Infragistics.Win.Office2013ColorScheme.DarkGray
            Case Else
                Throw New Exception("Value " & sValue & " not parsed!")
                Return Nothing
        End Select
    End Function

End Module

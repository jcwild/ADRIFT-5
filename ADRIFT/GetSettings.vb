' Purpose: Replacement Class for VB GetSetting and
' ''' SaveSetting.  Designed to replace the
' saving of application Settings in the registry
' with saving in an xml file in the installation directory.
' Allows user to set an alternate path in case of install
' directory lockdown.  Allows user to have their own Settings
' xml file or use one shared by all users on the same machine.
' Allows user to have multiple "AppNames" creating multiple
' xml files and multiple Settings (e.g., Settings, Registration, etc.)
' Completely simulates VB GetSetting and SaveSetting by simply
' instantiating this class and prefacing Get/SaveSetting calls with
' the instance object name, e.g., r.GetSetting(....).
' Author:  Les Smith
' Date Created: 01/24/2004 at 11:00:35
' CopyRight:  KnowDotNet
' '''***************************************
'


Option Strict On
Imports System.Data

Public Class CSettings

#Region " Class Variables "
    Private ds As DataSet
    Private xmlFile As String = String.Empty
    Dim _AllUsers As Boolean
    Const XML As String = ".xml"
    Private _AlternatePath As String = String.Empty
#End Region

#Region " Public SaveSetting Overloaded Methods "
    Public Overloads Sub SaveSetting(ByVal AppTitle As String, _
       ByVal Settings As String, _
       ByVal Key As String, _
       ByVal Value As Boolean)
        SaveSetting(AppTitle, Settings, Key, CStr(Value))
    End Sub
    Public Overloads Sub SaveSetting(ByVal AppTitle As String, _
       ByVal Settings As String, _
       ByVal Key As String, _
       ByVal Value As Integer)
        SaveSetting(AppTitle, Settings, Key, CStr(Value))
    End Sub
    Public Overloads Sub SaveSetting(ByVal AppTitle As String, _
       ByVal Settings As String, _
       ByVal Key As String, _
       ByVal Value As String)

        ' this method sets or adds the value row for the passed key

        Try
            If xmlFile.Length = 0 Then SetupXMLFileName(AppTitle)

            If ds Is Nothing Then                
                Dim dt As DataTable = GetXml(Settings)
                If dt Is Nothing Then
                    ds = New DataSet
                    ds.DataSetName = "ADRIFTSettings"
                    dt = CreateDT(Settings, Key, Value)
                    ds.Tables.Add(dt)
                End If
            Else
                Dim dt As DataTable = ds.Tables(Settings)
                If dt Is Nothing Then
                    ' create new datatable named Settings
                    dt = CreateDT(Settings, Key, Value)
                    ds.Tables.Add(dt)
                Else
                    Dim i As Integer
                    Dim b As Boolean
                    For i = 0 To dt.Rows.Count - 1
                        If CStr(dt.Rows(i).Item("key")) = Key Then
                            dt.Rows(i).Item("value") = Value
                            b = True
                            Exit For
                        End If
                    Next
                    If Not b Then
                        AddRow(dt, Key, Value)
                    End If
                End If
            End If
            ds.WriteXml(xmlFile)
        Catch ex As System.Exception
#If Not Debug Then ' cos it gets really annoying...
            ErrMsg("SaveSetting error", ex)
#End If
        End Try
    End Sub
#End Region

#Region " Public Overloaded GetSetting Methods "
    Public Overloads Function GetSetting(ByVal AppTitle As String, _
       ByVal Settings As String, _
       ByVal key As String, _
       ByVal keyvalue As Integer) _
       As Integer
        Dim o As Object = GetSetting(AppTitle, Settings, key, CStr(keyvalue))
        If o Is Nothing Then
            Return keyvalue
        Else
            Return CType(o, Integer)
        End If
    End Function
    Public Overloads Function GetSetting(ByVal AppTitle As String, _
          ByVal Settings As String, _
          ByVal key As String, _
          ByVal keyvalue As Boolean) _
          As Boolean
        Dim o As Object = GetSetting(AppTitle, Settings, key, CStr(keyvalue))
        If o Is Nothing Then
            Return keyvalue
        Else
            Return CType(o, Boolean)
        End If
    End Function


    Public Overloads Function GetSetting(ByVal AppTitle As String, _
        ByVal Settings As String, _
        ByVal key As String, _
        ByVal keyvalue As String) _
        As Object

        Dim i As Integer
        Dim dr As DataRow
        Dim dt As DataTable


        Try
            If xmlFile.Length = 0 Then SetupXMLFileName(AppTitle)

            ' this method returns the value specified by the key
            If ds Is Nothing Then
                dt = GetXml(Settings)
                If dt Is Nothing Then Return keyvalue
            Else
                dt = ds.Tables(Settings)
            End If
            If dt IsNot Nothing Then
                For i = 0 To dt.Rows.Count - 1
                    dr = dt.Rows(i)
                    If CStr(dr("Key")) = key Then
                        Return dr("Value")
                    End If
                Next
            End If            
        Catch ex As System.Exception
            ErrMsg("GetSetting error", ex)
        End Try
        Return keyvalue

    End Function
#End Region

#Region " Private Methods "
    Private Function CreateDT(ByVal Settings As String, ByVal key As String, _
       ByVal value As Object) As DataTable
        Dim dt As DataTable
        dt = New DataTable(Settings)
        dt.Columns.Add("Key", Type.GetType("System.String"))
        dt.Columns.Add("Value", Type.GetType("System.String"))
        AddRow(dt, key, value)
        Return dt
    End Function
    Private Sub AddRow(ByRef dt As DataTable, ByVal key As String, _
       ByVal value As Object)
        Dim newRow As DataRow = dt.NewRow
        newRow(0) = key
        newRow(1) = value
        dt.Rows.Add(newRow)
    End Sub
    Private Function GetXml(ByVal tablename As String) As DataTable
        If Not IO.File.Exists(xmlFile) Then
            Return Nothing
        End If
        ds = New DataSet
        ds.DataSetName = "ADRIFTSettings"

        ds.ReadXml(xmlFile)
        Dim dt As DataTable = ds.Tables(tablename)
        Return dt

    End Function
    Private Sub SetupXMLFileName(ByVal fn As String)
        ' Returns filename for xmlfile, generated by using
        ' AppTitle supplied to the two public methods and then
        ' boolean supplied to the constructor.
        ' install directory may be locked so check to see if
        ' caller supplied an alternate directory.
        Dim s As String
        If _AlternatePath.Length = 0 Then
            s = IO.Path.GetDirectoryName( _
               Reflection.Assembly.GetExecutingAssembly.Location())
        Else
            s = IO.Path.GetDirectoryName(_AlternatePath)
        End If
        If _AllUsers Then
            xmlFile = s & IO.Path.DirectorySeparatorChar & fn & XML
        Else
            xmlFile = s & IO.Path.DirectorySeparatorChar & fn & "_" & System.Security.Principal.WindowsIdentity.GetCurrent.Name.Replace(IO.Path.DirectorySeparatorChar, "_") & XML ' Environ("UserName") & XML
        End If
    End Sub
#End Region

#Region " Constructor "
    Public Sub New(ByVal AllUsers As Boolean)
        Me._AllUsers = AllUsers
    End Sub
#End Region

#Region " Property Methods "
    Public Property AlternatePath() As String
        Get
            Return _AlternatePath
        End Get
        Set(ByVal Value As String)
            _AlternatePath = Value
        End Set
    End Property
#End Region
End Class
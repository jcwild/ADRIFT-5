Imports System.Xml.Serialization


<System.SerializableAttribute(), _
    System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://babel.ifarchive.org/protocol/iFiction/"), _
    System.Xml.Serialization.XmlRootAttribute("ifindex", [Namespace]:="http://babel.ifarchive.org/protocol/iFiction/", _
    IsNullable:=False)> _
Public Class clsBabelTreatyInfo

    Public Sub New()
        sVersion = "1.0"
        ReDim oStories(0)
        oStories(0) = New clsStory        
    End Sub


    Public Function FromString(ByVal sXML As String) As Boolean

        Try
            Dim serializer As New XmlSerializer(GetType(clsBabelTreatyInfo))
            Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(sXML)
            Dim ms As New System.IO.MemoryStream(bytes)
            Adventure.BabelTreatyInfo = CType(serializer.Deserialize(ms), clsBabelTreatyInfo)
            ms.Close()
            Return True
        Catch ex As Exception
            ErrMsg("FromString error parsing ifindex", ex)
            Return False
        End Try

    End Function


    Public Shadows Function ToString(Optional ByVal bIncludeXMLTag As Boolean = True) As String

        Try
            Dim serializer As New XmlSerializer(GetType(clsBabelTreatyInfo))
            Dim ms As New System.IO.MemoryStream
            Dim xmlTextWriter As New System.Xml.XmlTextWriter(ms, System.Text.Encoding.UTF8)

            serializer.Serialize(xmlTextWriter, Me)

            ms = CType(xmlTextWriter.BaseStream, System.IO.MemoryStream)
            Dim sXML As String = (New System.Text.UTF8Encoding).GetString(ms.ToArray)
            Dim iOffset As Integer = 0
            While iOffset < sXML.Length AndAlso sXML(iOffset) <> "<"c
                iOffset += 1
            End While

            If bIncludeXMLTag Then
                Return sXML.Substring(iOffset)
            Else
                Return sXML.Substring(iOffset).Replace("<?xml version=""1.0"" encoding=""utf-8""?>", "")
            End If
        Catch ex As Exception
            ErrMsg("ToString error parsing ifindex", ex)
            Return ""
        End Try

    End Function


    Private oStories() As clsStory
    <System.Xml.Serialization.XmlElementAttribute("story", GetType(clsStory))> _
    Public Property Stories() As clsStory()
        Get
            Return oStories
        End Get
        Set(ByVal Value As clsStory())
            oStories = Value
        End Set
    End Property


    Private sVersion As String
    <System.Xml.Serialization.XmlAttributeAttribute("version")> _
    Public Property Version() As String
        Get
            Return sVersion
        End Get
        Set(ByVal value As String)
            sVersion = value
        End Set
    End Property


    Public Class clsStory

        Public Sub New()
            Identification.GenerateNewIFID()
            Releases = New clsBabelTreatyInfo.clsStory.clsReleases
        End Sub


        ' The <identification> section is mandatory. The content here identifies
        ' to which story file the metadata belongs. (This is necessary because
        ' the metadata may be held on some remote server, quite separate from
        ' the story file.)
        Public Class clsIdentification

            Public Sub GenerateNewIFID()
                With System.Reflection.Assembly.GetExecutingAssembly.GetName.Version
                    sIFID = "ADRIFT-" & .Major & .Minor.ToString("00") & "-" & sRight(Guid.NewGuid.ToString, 32).ToUpper
                End With
            End Sub

            Private sIFID As String
            <System.Xml.Serialization.XmlElement("ifid")> _
            Public Property IFID() As String
                Get
                    Return sIFID
                End Get
                Set(ByVal value As String)
                    sIFID = value
                End Set
            End Property

            <System.Xml.Serialization.XmlElement("format")> _
            Public Property Format() As String
                Get
                    Return "adrift"
                End Get
                Set(ByVal value As String)
                    ' Ignore
                End Set
            End Property

            Private iBAFN As Integer
            <System.Xml.Serialization.XmlElement("bafn")> _
            Public Property BAFN() As Integer
                Get
                    Return iBAFN
                End Get
                Set(ByVal value As Integer)
                    iBAFN = value
                    If iBAFN <> 0 Then bBAFNSpecified = True
                End Set
            End Property

            Private bBAFNSpecified As Boolean
            <System.Xml.Serialization.XmlIgnoreAttribute()> _
            Public Property BAFNSpecified() As Boolean
                Get
                    Return bBAFNSpecified
                End Get
                Set(ByVal Value As Boolean)
                    bBAFNSpecified = Value
                End Set
            End Property

        End Class
        <System.Xml.Serialization.XmlElement("identification")> _
        Public Identification As New clsIdentification

        ' The <bibliographic> section is mandatory.
        Public Class clsBibliographic

            <System.Xml.Serialization.XmlElement("title")> _
            Public Property Title() As String
                Get
                    Return Adventure.Title
                End Get
                Set(ByVal value As String)
                    ' Ignore
                End Set
            End Property

            <System.Xml.Serialization.XmlElement("author")> _
            Public Property Author() As String
                Get
                    Return Adventure.Author
                End Get
                Set(ByVal value As String)
                    ' Ignore
                End Set
            End Property

            ' Always reads this from the current culture, so can change if modified on a different machine
            Private sLanguage As String
            <System.Xml.Serialization.XmlElement("language")> _
            Public Property Language() As String
                Get
                    Return Threading.Thread.CurrentThread.CurrentCulture.ToString()
                End Get
                Set(ByVal value As String)
                    ' Ignore
                End Set
            End Property

            Private sHeadline As String
            <System.Xml.Serialization.XmlElement("headline")> _
            Public Property Headline() As String
                Get
                    Return sHeadline
                End Get
                Set(ByVal value As String)
                    sHeadline = value
                End Set
            End Property

            Private dtFirstPublished As DateTime
            <System.Xml.Serialization.XmlElement("firstpublished")> _
            Public Property FirstPublished() As DateTime
                Get
                    Return dtFirstPublished
                End Get
                Set(ByVal value As DateTime)
                    dtFirstPublished = value
                    If value <> Date.MinValue Then bFirstPublishedSpecified = True
                End Set
            End Property

            Private bFirstPublishedSpecified As Boolean
            <System.Xml.Serialization.XmlIgnoreAttribute()> _
            Public Property FirstPublishedSpecified() As Boolean
                Get
                    Return bFirstPublishedSpecified
                End Get
                Set(ByVal Value As Boolean)
                    bFirstPublishedSpecified = Value
                End Set
            End Property

            Private sGenre As String
            <System.Xml.Serialization.XmlElement("genre")> _
            Public Property Genre() As String
                Get
                    Return sGenre
                End Get
                Set(ByVal value As String)
                    sGenre = value
                End Set
            End Property

            Private sGroup As String
            Public Property Group() As String
                Get
                    Return sGroup
                End Get
                Set(ByVal value As String)
                    sGroup = value
                End Set
            End Property

            Private sDescription As String
            <System.Xml.Serialization.XmlElement("description")> _
            Public Property Description() As String
                Get
                    Return sDescription
                End Get
                Set(ByVal value As String)
                    sDescription = value
                End Set
            End Property

            Private sSeries As String
            Public Property Series() As String
                Get
                    Return sSeries
                End Get
                Set(ByVal value As String)
                    sSeries = value
                End Set
            End Property

            Private iSeriesNumber As Integer
            Public Property SeriesNumber() As Integer
                Get
                    Return iSeriesNumber
                End Get
                Set(ByVal value As Integer)
                    iSeriesNumber = value
                    If iSeriesNumber > 0 Then bSeriesNumberSpecified = True
                End Set
            End Property

            Private bSeriesNumberSpecified As Boolean
            <System.Xml.Serialization.XmlIgnoreAttribute()> _
            Public Property SeriesNumberSpecified() As Boolean
                Get
                    Return bSeriesNumberSpecified
                End Get
                Set(ByVal Value As Boolean)
                    bSeriesNumberSpecified = Value
                End Set
            End Property

            Public Enum ForgivenessEnum
                Merciful
                Polite
                Tough
                Nasty
                Cruel
            End Enum
            Private eForgiveness As ForgivenessEnum
            <System.Xml.Serialization.XmlElement("forgiveness")> _
            Public Property Forgiveness() As ForgivenessEnum
                Get
                    Return eForgiveness
                End Get
                Set(ByVal value As ForgivenessEnum)
                    eForgiveness = value
                    bForgivenessSpecified = True
                End Set
            End Property

            Private bForgivenessSpecified As Boolean
            <System.Xml.Serialization.XmlIgnoreAttribute()> _
            Public Property ForgivenessSpecified() As Boolean
                Get
                    Return bForgivenessSpecified
                End Get
                Set(ByVal Value As Boolean)
                    bForgivenessSpecified = Value
                End Set
            End Property

        End Class
        <System.Xml.Serialization.XmlElement("bibliographic")> _
        Public Bibliographic As New clsBibliographic

        ' The <resources> tag is optional. This section, if present, details
        ' the other files (if any) which are intended to accompany the story
        ' file, and to be available to any player. By "other" is meant files
        ' which are not embedded in the story file. (So, for instance, pictures
        ' in a blorbed Z-machine story file do not count as "other".)
        <System.SerializableAttribute(), _
            System.Xml.Serialization.XmlTypeAttribute([TypeName]:="resources", [Namespace]:="http://babel.ifarchive.org/protocol/iFiction/")> _
        Public Class clsResources

            Public Class clsAuxiliary

                Private sLeafName As String
                Public Property LeafName() As String
                    Get
                        Return sLeafName
                    End Get
                    Set(ByVal value As String)
                        sLeafName = value
                    End Set
                End Property

                Private sDescription As String
                Public Property Description() As String
                    Get
                        Return sDescription
                    End Get
                    Set(ByVal value As String)
                        sDescription = value
                    End Set
                End Property

            End Class
            Public Auxiliary As New clsAuxiliary

        End Class
        Public Resources As clsResources

        ' The <contacts> tag is optional.
        <System.SerializableAttribute(), _
            System.Xml.Serialization.XmlTypeAttribute([TypeName]:="contacts", [Namespace]:="http://babel.ifarchive.org/protocol/iFiction/")> _
        Public Class clsContacts

            Private sURL As String
            Public Property URL() As String
                Get
                    Return sURL
                End Get
                Set(ByVal value As String)
                    sURL = value
                End Set
            End Property

            Private sAuthorEmail As String
            Public Property AuthorEmail() As String
                Get
                    Return sAuthorEmail
                End Get
                Set(ByVal value As String)
                    sAuthorEmail = value
                End Set
            End Property

        End Class
        Public Contacts As clsContacts

        ' The <cover> tag is optional, except that it is mandatory for an
        ' iFiction record embedded in a story file which contains a cover
        ' image; and the information must, of course, be correct.

        Public Class clsCover

            Friend imgCoverArt As System.Drawing.Image


            'Private sFilename As String
            '<System.Xml.Serialization.XmlIgnoreAttribute()> _
            'Public Property Filename() As String
            '    Get
            '        Return sFilename
            '    End Get
            '    Set(ByVal value As String)
            '        If sFormat = "" Then sFormat = sRight(value, 3)
            '        sFilename = value
            '    End Set
            'End Property

            ' This is required to be either "jpg" or "png". No other casings,
            ' spellings or image formats are permitted.
            Private sFormat As String
            <System.Xml.Serialization.XmlElement("format")> _
            Public Property Format() As String
                Get
                    If imgCoverArt IsNot Nothing Then Return sFormat Else Return Nothing
                End Get
                Set(ByVal value As String)
                    If value = "" OrElse value = "jpg" OrElse value = "png" Then
                        sFormat = value
                    Else
                        Throw New Exception("Only jpg or png allowed!")
                    End If
                End Set
            End Property

            <System.Xml.Serialization.XmlElement("height")> _
            Public Property Height() As Integer
                Get
                    If imgCoverArt IsNot Nothing Then Return imgCoverArt.Height Else Return 0
                End Get
                Set(ByVal value As Integer)
                    ' Provided for serialization only
                End Set
            End Property

            Private bHeightSpecified As Boolean
            <System.Xml.Serialization.XmlIgnoreAttribute()> _
            Public Property HeightSpecified() As Boolean
                Get
                    Return imgCoverArt IsNot Nothing
                End Get
                Set(ByVal Value As Boolean)
                    ' Ignore
                End Set
            End Property

            <System.Xml.Serialization.XmlElement("width")> _
            Public Property Width() As Integer
                Get
                    If imgCoverArt IsNot Nothing Then Return imgCoverArt.Width Else Return 0
                End Get
                Set(ByVal value As Integer)
                    ' Provided for serialization only
                End Set
            End Property

            Private bWidthSpecified As Boolean
            <System.Xml.Serialization.XmlIgnoreAttribute()> _
            Public Property WidthSpecified() As Boolean
                Get
                    Return imgCoverArt IsNot Nothing
                End Get
                Set(ByVal Value As Boolean)
                    ' Ignore
                End Set
            End Property

        End Class
        <System.Xml.Serialization.XmlElement("cover")> _
        Public Cover As clsCover

        Public Class clsADRIFT

            Public ReadOnly Property Version() As String
                Get
                    Return Application.ProductVersion
                End Get
            End Property

        End Class
        Public ADRIFT As clsADRIFT

        ' 5.11 - Releases
        '   Attached
        '   History
        <System.SerializableAttribute(), _
           System.Xml.Serialization.XmlTypeAttribute([TypeName]:="releases", [Namespace]:="http://babel.ifarchive.org/protocol/iFiction/")> _
        Public Class clsReleases

            Public Sub New()
                Attached = New clsBabelTreatyInfo.clsStory.clsReleases.clsAttached
            End Sub


            Public Class clsAttached

                Public Sub New()
                    Release = New clsBabelTreatyInfo.clsStory.clsReleases.clsAttached.clsRelease
                End Sub


                Public Class clsRelease

                    Private iVersion As Integer = 1
                    <System.Xml.Serialization.XmlElement("version")> _
                    Public Property Version() As Integer
                        Get
                            Return iVersion
                        End Get
                        Set(ByVal value As Integer)
                            iVersion = value
                            If iVersion > 0 Then bVersionSpecified = True
                        End Set
                    End Property

                    Private bVersionSpecified As Boolean
                    <System.Xml.Serialization.XmlIgnoreAttribute()> _
                    Public Property VersionSpecified() As Boolean
                        Get
                            Return bVersionSpecified
                        End Get
                        Set(ByVal Value As Boolean)
                            bVersionSpecified = Value
                        End Set
                    End Property

                    Private dtReleaseDate As DateTime                    
                    <System.Xml.Serialization.XmlElement("releasedate")> _
                    Public Property ReleaseDateXML() As String
                        Get
                            Return ReleaseDate.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
                        End Get
                        Set(ByVal value As String)
                            ReleaseDate = DateTime.Parse(value)
                        End Set
                    End Property

                    <System.Xml.Serialization.XmlIgnore()> _
                    Public Property ReleaseDate() As DateTime
                        Get
#If Generator Then
                            Return Date.Today
#Else
                            Return dtReleaseDate
#End If
                        End Get
                        Set(ByVal value As DateTime)
                            dtReleaseDate = value                            
                        End Set
                    End Property

                    Private sCompiler As String
                    <System.Xml.Serialization.XmlElement("compiler")> _
                    Public Property Compiler() As String
                        Get
                            Return "ADRIFT 5"
                        End Get
                        Set(ByVal value As String)
                        End Set
                    End Property

                    Private sCompilerVersion As String
                    <System.Xml.Serialization.XmlElement("compilerversion")> _
                    Public Property CompilerVersion() As String
                        Get
                            Return Application.ProductVersion
                        End Get
                        Set(ByVal value As String)
                        End Set
                    End Property

                End Class
                <System.Xml.Serialization.XmlElement("release")> _
                Public Release As New clsRelease

            End Class
            <System.Xml.Serialization.XmlElement("attached")> _
            Public Attached As New clsAttached

        End Class

        <System.Xml.Serialization.XmlElement("releases")> _
        Public Releases As clsReleases


        ' 5.12 - Colophon

        ' 5.13 - Annotation

        ' 5.14 - Examples    

    End Class

End Class

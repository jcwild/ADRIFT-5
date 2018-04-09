Imports System.Web
Imports System.Web.Services

Public Class MapHandler
    Implements System.Web.IHttpHandler
    Implements IRequiresSessionState

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        'context.Response.ContentType = "text/plain"
        'context.Response.Write("Hello World!")

        ' Write your handler implementation here.
        'Using image As System.Drawing.Image = GetImage(context.Request.QueryString("ID"))
        '    context.Response.ContentType = "image/jpeg"
        '    image.Save(context.Response.OutputStream, ImageFormat.Jpeg)
        'End Using
        'If UserSession Is Nothing Then Exit Sub
        '  CType(Page.Master, Site).footer.InnerHtml = "Please be aware that v5 is not yet 100% compatible with v4.  For this reason, please play this game on <a href=""http://www.adrift.co/files/ADRIFT40r.zip"">v4 Runner</a>."
        If UserSession Is Nothing Then Exit Sub

        Dim iHeight As Integer = MapHeight
        Dim iWidth As Integer = MapWidth

        If iHeight = 0 Then iHeight = 500
        If iWidth = 0 Then iWidth = 400

        Dim sId As String = context.Request.QueryString("ID")
        UserSession.Map.PaintMe(New Size(iWidth, iHeight))
        Dim img As System.Drawing.Image = UserSession.Map.imgMap.Image 'Drawing.Image.FromFile("C:\Users\CampbellWild\Pictures\main.jpg")
        img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg)

        'Dim ms As New IO.MemoryStream
        'img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

        'Dim buffer As Byte() = ms.GetBuffer
        'ms.Close()

        'context.Response.ContentType = "image/jpeg"
        'context.Response.BinaryWrite(buffer)
        'context.Response.End()

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class
Public Class MapControl
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load        

        UserSession.Map.PaintMe(New Size(500, 300))
        Dim img As System.Drawing.Image = UserSession.Map.imgMap.Image 'Drawing.Image.FromFile("C:\Users\CampbellWild\Pictures\main.jpg")
        Dim ms As New IO.MemoryStream
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim buffer As Byte() = ms.GetBuffer
        ms.Close()

        Response.ContentType = "image/jpeg"
        Response.BinaryWrite(buffer)
        Response.End()

    End Sub

   

End Class
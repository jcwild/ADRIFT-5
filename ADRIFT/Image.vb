Public Class clsImage

    Public Class ImageEventArgs
        Inherits EventArgs

        Public SizeMode As SizeModeEnum
    End Class


    Public Event SizeModeChanged(ByVal o As clsImage, ByVal e As ImageEventArgs)

    Public Enum SizeModeEnum
        ActualSizeCentred = 0
        StretchedKeepAspect = 1
        StretchToFill = 2
    End Enum
    Private eSizeMode As SizeModeEnum

    Private bmpAnimation As Bitmap = Nothing
    Private bAnimating As Boolean = False


    Public Property SizeMode() As SizeModeEnum
        Get
            Return eSizeMode
        End Get
        Set(ByVal value As SizeModeEnum)

            Dim imgSize As Image = Nothing
            If bmpAnimation IsNot Nothing Then
                imgSize = bmpAnimation
            Else
                imgSize = imgGraphics.Image
            End If
            If imgSize Is Nothing Then
                eSizeMode = value
                Exit Property
            End If

            Dim sMode As String = ""
            Select Case value
                Case SizeModeEnum.ActualSizeCentred
                    imgGraphics.Visible = False
                    imgGraphics.Dock = DockStyle.Fill
                    imgGraphics.SizeMode = PictureBoxSizeMode.CenterImage
                    imgGraphics.Visible = True
                    sMode = "Actual Size, Centred"

                Case SizeModeEnum.StretchedKeepAspect
                    imgGraphics.Visible = False
                    imgGraphics.Dock = DockStyle.None
                    imgGraphics.SizeMode = PictureBoxSizeMode.StretchImage
                    If imgSize.Height / imgSize.Width > Me.Height / Me.Width Then
                        imgGraphics.Top = 0
                        imgGraphics.Height = Me.Height
                        imgGraphics.Width = CInt(imgSize.Width * Me.Height / imgSize.Height)
                        imgGraphics.Left = CInt((Me.Width - imgGraphics.Width) / 2)
                    Else
                        imgGraphics.Left = 0
                        imgGraphics.Width = Me.Width
                        imgGraphics.Height = CInt(imgSize.Height * Me.Width / imgSize.Width)
                        imgGraphics.Top = CInt((Me.Height - imgGraphics.Height) / 2)
                    End If
                    imgGraphics.Visible = True
                    sMode = "Fit Window, Keep Aspect"

                Case SizeModeEnum.StretchToFill
                    imgGraphics.Visible = False
                    imgGraphics.Dock = DockStyle.Fill
                    imgGraphics.SizeMode = PictureBoxSizeMode.StretchImage
                    imgGraphics.Visible = True
                    sMode = "Stretch to Window"

            End Select

            lblMode.AutoSize = False
            lblMode.Width = imgGraphics.Width
            lblMode.Location = New Point(0, 5) 'imgGraphics.Height - 20)

            If value <> eSizeMode Then
                lblMode.Text = "Mode: " & sMode
                lblMode.Parent = imgGraphics
                lblMode.Visible = True
                tmrLabel.Stop()
                tmrLabel.Interval = 1000
                tmrLabel.Enabled = True
                tmrLabel.Start()
                eSizeMode = value
                SharedModule.iImageSizeMode = CInt(eSizeMode)

                Dim ea As New ImageEventArgs
                ea.SizeMode = value

                RaiseEvent SizeModeChanged(Me, ea)
            End If

        End Set
    End Property


    Dim pbxURL As PictureBox
    Public Shadows Sub Load(ByVal url As String)

        StopAnimating()
        If Adventure.dVersion >= 4 AndAlso Adventure.dVersion < 5 AndAlso Adventure.dictv4Media.Count > 0 Then
            ' Grab the image directly from the TAF
            imgGraphics.Image = Getv4Image(url)
        Else
            Dim imgTemp As Bitmap
            If url.Contains("://") Then
                If pbxURL Is Nothing Then pbxURL = New PictureBox
                pbxURL.Load(url)
                imgTemp = New Bitmap(pbxURL.Image)
            Else
                Try
                    imgTemp = New Bitmap(url)
                Catch ex As Exception
                    Dim img As Image = Image.FromFile(url, False)
                    imgTemp = New Bitmap(img)
                End Try
            End If

            Dim dimension As New Imaging.FrameDimension(imgTemp.FrameDimensionsList(0))
            If imgTemp.GetFrameCount(dimension) > 1 Then
                imgGraphics.Image = Nothing
                bmpAnimation = imgTemp
                AnimateImage()
            Else
                imgGraphics.Image = imgTemp
            End If
        End If
        SizeMode = SizeMode ' Just in case it was set before the image was loaded

    End Sub


    Public Property Image() As System.Drawing.Image
        Get
            Return imgGraphics.Image
        End Get
        Set(ByVal value As System.Drawing.Image)
            imgGraphics.Image = value
            SizeMode = SizeMode  ' Just in case it was set before the image was loaded
        End Set
    End Property


    Private Sub StopAnimating()
        If bAnimating Then
            'RemoveHandler addressof OnFrameChanged
            ImageAnimator.StopAnimate(bmpAnimation, New eventhandler(AddressOf OnFrameChanged))
            bAnimating = False
            bmpAnimation = Nothing
        End If
    End Sub


    Private Sub AnimateImage()

        If Not bAnimating Then
            ImageAnimator.Animate(bmpAnimation, New EventHandler(AddressOf OnFrameChanged))
            bAnimating = True
        End If

    End Sub


    Private Sub OnFrameChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        imgGraphics.Invalidate()
    End Sub


    Private Sub imgGraphics_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles imgGraphics.Paint

        ' Begin the animation
        'AnimateImage()

        If bAnimating Then
            ' Get the next frame ready for rendering
            ImageAnimator.UpdateFrames()

            Dim rect As Rectangle

            Select Case SizeMode
                Case SizeModeEnum.ActualSizeCentred
                    rect = New Rectangle(CInt((imgGraphics.Width - bmpAnimation.Width) / 2), CInt((imgGraphics.Height - bmpAnimation.Height) / 2), bmpAnimation.Width, bmpAnimation.Height)
                Case SizeModeEnum.StretchToFill, SizeModeEnum.StretchedKeepAspect
                    rect = New Rectangle(0, 0, imgGraphics.Width, imgGraphics.Height)
            End Select

            ' Draw the next frame in the animation
            e.Graphics.DrawImage(bmpAnimation, rect)

        End If

    End Sub

    'Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
    '    MyBase.OnPaint(e)
    'End Sub


    Private Sub imgGraphics_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgGraphics.Click, Me.Click

        Select Case SizeMode
            Case SizeModeEnum.ActualSizeCentred
                SizeMode = SizeModeEnum.StretchedKeepAspect
            Case SizeModeEnum.StretchedKeepAspect
                SizeMode = SizeModeEnum.StretchToFill
            Case SizeModeEnum.StretchToFill
                SizeMode = SizeModeEnum.ActualSizeCentred
        End Select

    End Sub


    Private Sub Image_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If SizeMode = SizeModeEnum.StretchedKeepAspect Then SizeMode = SizeModeEnum.StretchedKeepAspect ' to redraw        
    End Sub



    Private Sub tmrLabel_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrLabel.Tick
        tmrLabel.Enabled = False
        lblMode.Visible = False
    End Sub


    Public Property BackColour() As Color
        Get
            Return imgGraphics.BackColor
        End Get
        Set(ByVal value As Color)
            imgGraphics.BackColor = value
            Me.BackColor = value
        End Set
    End Property

End Class

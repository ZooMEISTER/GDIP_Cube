Public Class Form1
    Structure Point3D
        Dim x As Double
        Dim y As Double
        Dim z As Double
    End Structure

    Const Pi As Double = 3.1415926535897931
    Dim P1, P2, P3, P4, P5, P6, P7, P8 As Point3D

    Dim P1T, P2T, P3T, P4T, P5T, P6T, P7T, P8T, T As New Point

    Dim remote As Double = 200
    Dim angle, angle2 As Double
    Dim sight As Double = 400
    Dim sremote = Math.Sqrt(1 / 2) * remote

    Private Sub VScrollBar2_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar2.Scroll
        Call DrawCube()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call DrawCube()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Call DrawCube()
    End Sub

    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Call DrawCube()
    End Sub

    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll
        Call DrawCube()
    End Sub

    Sub DrawCube()
        Dim Bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim g = Graphics.FromImage(Bmp)

        Dim SightHeight As Double = 100 - Me.VScrollBar2.Value

        Dim H As Graphics = Me.PictureBox1.CreateGraphics

        Dim MyPen As New Pen(Color.Black)
        Dim MyPenB As New SolidBrush(Color.FromArgb(TrackBar1.Value, Color.Blue))
        Dim MyPenR As New SolidBrush(Color.FromArgb(TrackBar1.Value, Color.Red))
        Dim MyPenP As New SolidBrush(Color.FromArgb(TrackBar1.Value, Color.Pink))
        Dim MyPenG As New SolidBrush(Color.FromArgb(TrackBar1.Value, Color.Green))
        Dim MyPenY As New SolidBrush(Color.FromArgb(TrackBar1.Value, Color.Yellow))
        Dim MyPenO As New SolidBrush(Color.FromArgb(TrackBar1.Value, Color.Orange))

        Me.Label2.Text = TrackBar1.Value

        angle = -Me.HScrollBar1.Value / 180 * Pi
        angle2 = Me.VScrollBar1.Value / 180 * Pi

        g.Clear(Color.White)

        '中心点
        T.X = 300
        T.Y = 300

        '八个顶点的空间坐标
        P1.x = sremote * Math.Cos(angle) + （sremote * Math.Cos(Pi / 4 - angle2) - sremote / Math.Sqrt(2)) * Math.Cos(Pi / 4 - angle)
        P1.y = remote / 2 - (sremote / Math.Sqrt(2) - sremote * Math.Sin(Pi / 4 - angle2))
        P1.z = -sremote * Math.Sin(angle) + （sremote * Math.Cos(Pi / 4 - angle2) - sremote / Math.Sqrt(2)) * Math.Sin(Pi / 4 - angle)

        P2.x = sremote * Math.Sin(angle) + （sremote * Math.Cos(Pi / 4 - angle2) - sremote / Math.Sqrt(2)) * Math.Cos(Pi / 4 - angle)
        P2.y = remote / 2 - (sremote / Math.Sqrt(2) - sremote * Math.Sin(Pi / 4 - angle2))
        P2.z = sremote * Math.Cos(angle) + （sremote * Math.Cos(Pi / 4 - angle2) - sremote / Math.Sqrt(2)) * Math.Sin(Pi / 4 - angle)

        P3.x = -sremote * Math.Cos(angle) + (sremote / Math.Sqrt(2) - sremote * Math.Sin(Pi / 4 - angle2)) * Math.Cos(Pi / 4 - angle)
        P3.y = remote / 2 + (sremote * Math.Sin(angle2 + Pi / 4) - sremote / Math.Sqrt(2))
        P3.z = sremote * Math.Sin(angle) + (sremote / Math.Sqrt(2) - sremote * Math.Sin(Pi / 4 - angle2)) * Math.Sin(Pi / 4 - angle)

        P4.x = -sremote * Math.Sin(angle) + (sremote / Math.Sqrt(2) - sremote * Math.Sin(Pi / 4 - angle2)) * Math.Cos(Pi / 4 - angle)
        P4.y = remote / 2 + (sremote * Math.Sin(angle2 + Pi / 4) - sremote / Math.Sqrt(2))
        P4.z = -sremote * Math.Cos(angle) + (sremote / Math.Sqrt(2) - sremote * Math.Sin(Pi / 4 - angle2)) * Math.Sin(Pi / 4 - angle)


        P5.x = sremote * Math.Cos(angle) - (sremote / Math.Sqrt(2) - sremote * Math.Sin(Pi / 4 - angle2)) * Math.Cos(Pi / 4 - angle)
        P5.y = -remote / 2 - (sremote * Math.Sin(angle2 + Pi / 4) - sremote / Math.Sqrt(2))
        P5.z = -sremote * Math.Sin(angle) - (sremote / Math.Sqrt(2) - sremote * Math.Sin(Pi / 4 - angle2)) * Math.Sin(Pi / 4 - angle)

        P6.x = sremote * Math.Sin(angle) - (sremote / Math.Sqrt(2) - sremote * Math.Sin(Pi / 4 - angle2)) * Math.Cos(Pi / 4 - angle)
        P6.y = -remote / 2 - (sremote * Math.Sin(angle2 + Pi / 4) - sremote / Math.Sqrt(2))
        P6.z = sremote * Math.Cos(angle) - (sremote / Math.Sqrt(2) - sremote * Math.Sin(Pi / 4 - angle2)) * Math.Sin(Pi / 4 - angle)

        P7.x = -sremote * Math.Cos(angle) - （sremote * Math.Cos(Pi / 4 - angle2) - sremote / Math.Sqrt(2)) * Math.Cos(Pi / 4 - angle)
        P7.y = -remote / 2 + (sremote / Math.Sqrt(2) - sremote * Math.Sin(Pi / 4 - angle2))
        P7.z = sremote * Math.Sin(angle) - （sremote * Math.Cos(Pi / 4 - angle2) - sremote / Math.Sqrt(2)) * Math.Sin(Pi / 4 - angle)

        P8.x = -sremote * Math.Sin(angle) - （sremote * Math.Cos(Pi / 4 - angle2) - sremote / Math.Sqrt(2)) * Math.Cos(Pi / 4 - angle)
        P8.y = -remote / 2 + (sremote / Math.Sqrt(2) - sremote * Math.Sin(Pi / 4 - angle2))
        P8.z = -sremote * Math.Cos(angle) - （sremote * Math.Cos(Pi / 4 - angle2) - sremote / Math.Sqrt(2)) * Math.Sin(Pi / 4 - angle)

        '八个顶点的投影坐标
        P1T.X = (P1.x) * sight / (sight + P1.z)
        P1T.Y = (P1.y - SightHeight) * sight / (sight + P1.z)

        P2T.X = (P2.x) * sight / (sight + P2.z)
        P2T.Y = (P2.y - SightHeight) * sight / (sight + P2.z)

        P3T.X = (P3.x) * sight / (sight + P3.z)
        P3T.Y = (P3.y - SightHeight) * sight / (sight + P3.z)

        P4T.X = (P4.x) * sight / (sight + P4.z)
        P4T.Y = (P4.y - SightHeight) * sight / (sight + P4.z)

        P5T.X = (P5.x) * sight / (sight + P5.z)
        P5T.Y = (P5.y - SightHeight) * sight / (sight + P5.z)

        P6T.X = (P6.x) * sight / (sight + P6.z)
        P6T.Y = (P6.y - SightHeight) * sight / (sight + P6.z)

        P7T.X = (P7.x) * sight / (sight + P7.z)
        P7T.Y = (P7.y - SightHeight) * sight / (sight + P7.z)

        P8T.X = (P8.x) * sight / (sight + P8.z)
        P8T.Y = (P8.y - SightHeight) * sight / (sight + P8.z)


        g.DrawLine(MyPen, T.X + P1T.X, T.Y + P1T.Y, T.X + P2T.X, T.Y + P2T.Y)
        g.DrawLine(MyPen, T.X + P2T.X, T.Y + P2T.Y, T.X + P3T.X, T.Y + P3T.Y)
        g.DrawLine(MyPen, T.X + P3T.X, T.Y + P3T.Y, T.X + P4T.X, T.Y + P4T.Y)
        g.DrawLine(MyPen, T.X + P4T.X, T.Y + P4T.Y, T.X + P1T.X, T.Y + P1T.Y)

        g.DrawLine(MyPen, T.X + P5T.X, T.Y + P5T.Y, T.X + P6T.X, T.Y + P6T.Y)
        g.DrawLine(MyPen, T.X + P6T.X, T.Y + P6T.Y, T.X + P7T.X, T.Y + P7T.Y)
        g.DrawLine(MyPen, T.X + P7T.X, T.Y + P7T.Y, T.X + P8T.X, T.Y + P8T.Y)
        g.DrawLine(MyPen, T.X + P8T.X, T.Y + P8T.Y, T.X + P5T.X, T.Y + P5T.Y)

        g.DrawLine(MyPen, T.X + P1T.X, T.Y + P1T.Y, T.X + P5T.X, T.Y + P5T.Y)
        g.DrawLine(MyPen, T.X + P2T.X, T.Y + P2T.Y, T.X + P6T.X, T.Y + P6T.Y)
        g.DrawLine(MyPen, T.X + P3T.X, T.Y + P3T.Y, T.X + P7T.X, T.Y + P7T.Y)
        g.DrawLine(MyPen, T.X + P4T.X, T.Y + P4T.Y, T.X + P8T.X, T.Y + P8T.Y)

        '上色
        '正面(3,8)
        Dim Pz(0 To 5) As Double
        Dim MyPointsFront As PointF() = {New PointF(T.X + P3T.X, T.Y + P3T.Y), New PointF(T.X + P4T.X, T.Y + P4T.Y), New PointF(T.X + P8T.X, T.Y + P8T.Y), New PointF(T.X + P7T.X, T.Y + P7T.Y)}
        Pz(0) = P3.z + P8.z
        '后面(1,6)
        Dim MyPointsBack As PointF() = {New PointF(T.X + P1T.X, T.Y + P1T.Y), New PointF(T.X + P2T.X, T.Y + P2T.Y), New PointF(T.X + P6T.X, T.Y + P6T.Y), New PointF(T.X + P5T.X, T.Y + P5T.Y)}
        Pz(1) = P1.z + P6.z + 0.000001
        '左面(2,7)
        Dim MyPointsLeft As PointF() = {New PointF(T.X + P2T.X, T.Y + P2T.Y), New PointF(T.X + P3T.X, T.Y + P3T.Y), New PointF(T.X + P7T.X, T.Y + P7T.Y), New PointF(T.X + P6T.X, T.Y + P6T.Y)}
        Pz(2) = P2.z + P7.z + 0.0000012
        '右面(1,8)
        Dim MyPointsRight As PointF() = {New PointF(T.X + P1T.X, T.Y + P1T.Y), New PointF(T.X + P4T.X, T.Y + P4T.Y), New PointF(T.X + P8T.X, T.Y + P8T.Y), New PointF(T.X + P5T.X, T.Y + P5T.Y)}
        Pz(3) = P1.z + P8.z + 0.0000013
        '上面(5,7)
        Dim MyPointsAbove As PointF() = {New PointF(T.X + P5T.X, T.Y + P5T.Y), New PointF(T.X + P6T.X, T.Y + P6T.Y), New PointF(T.X + P7T.X, T.Y + P7T.Y), New PointF(T.X + P8T.X, T.Y + P8T.Y)}
        Pz(4) = P5.z + P7.z + 0.0000014
        '下面(1,3)
        Dim MyPointsUnder As PointF() = {New PointF(T.X + P1T.X, T.Y + P1T.Y), New PointF(T.X + P2T.X, T.Y + P2T.Y), New PointF(T.X + P3T.X, T.Y + P3T.Y), New PointF(T.X + P4T.X, T.Y + P4T.Y)}
        Pz(5) = P1.z + P3.z + 0.0000015

        Dim Num(0 To 6) As Integer      '由大到小
        Dim i, j, k As Integer
        For i = 0 To 5
            k = 0
            For j = 0 To 5
                If j <> i Then
                    If Pz(i) < Pz(j) Then
                        k = k + 1
                    End If
                End If
            Next
            Num(k + 1) = i
        Next

        For k = 1 To 6
            If Num(k) = 0 Then
                g.FillPolygon(MyPenY, MyPointsFront)
            ElseIf Num(k) = 1 Then
                g.FillPolygon(MyPenP, MyPointsBack)
            ElseIf Num(k) = 2 Then
                g.FillPolygon(MyPenB, MyPointsLeft)
            ElseIf Num(k) = 3 Then
                g.FillPolygon(MyPenG, MyPointsRight)
            ElseIf Num(k) = 4 Then
                g.FillPolygon(MyPenR, MyPointsAbove)
            ElseIf Num(k) = 5 Then
                g.FillPolygon(MyPenO, MyPointsUnder)
            End If
        Next


        H.DrawImage(Bmp, 0, 0)

        '防止溢出
        Bmp.Dispose()
        g.Dispose()
        H.Dispose()
    End Sub
End Class

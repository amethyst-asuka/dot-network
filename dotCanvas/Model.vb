Imports Microsoft.VisualBasic.ComponentModel.Ranges
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Imaging

Public Class Model

    Public ReadOnly Property Dots As Dot()

    ''' <summary>
    ''' Dot size
    ''' </summary>
    ''' <returns></returns>
    Public Property Size As Single = 10

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="n">The number of the dots on the canvas</param>
    Sub New(n As Integer, rect As Size, Optional speeds As DoubleRange = Nothing)
        If speeds Is Nothing Then
            speeds = New DoubleRange(3, 10)
        End If

        Dim dlst As New List(Of Dot)
        Dim rnd As New Random
        Dim d As New DoubleRange(0, 2 * Math.PI)
        Dim s As New Value(Of Double)

        For i As Integer = 0 To n
            dlst += New Dot With {
                .Location = New PointF(rnd.Next(rect.Width), rnd.Next(rect.Height)),
                .Speed = (s = speeds.GetRandomValue),
                .Direction = GetAngleVector(d.GetRandomValue, r:=s)
            }
        Next

        Dots = dlst
    End Sub

    Public Sub Calculate(rect As Rectangle)
        For Each x As Dot In Dots
            Dim l = x.Location
            Dim d = x.Direction

            x.Location = New PointF(l.X + d.X, l.Y + d.Y)
            l = x.Location

            If Not l.InRegion(rect) Then
                Dim ra As Double = Math.PI - x.Alpha
                x.Direction = GetAngleVector(ra, r:=x.Speed)

                If l.Y < 0 OrElse l.Y > rect.Bottom Then
                    x.Direction = New PointF(-x.Direction.X, -x.Direction.Y)
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' Update graphics
    ''' </summary>
    ''' <param name="g"></param>
    Public Sub Update(g As Graphics)
        Dim b As New SolidBrush(Color.Black)

        For Each x In Dots
            g.FillPie(b, New Rectangle(New Point(x.Location.X, x.Location.Y), New Size(Size, Size)), 0, 360)
        Next
    End Sub
End Class

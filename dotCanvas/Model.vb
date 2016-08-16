Imports Microsoft.VisualBasic.ComponentModel.Ranges
Imports Microsoft.VisualBasic
Imports System.Drawing

Public Class Model

    Public ReadOnly Property Dots As Dot()

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

        For i As Integer = 0 To n
            dlst += New Dot With {
                .Location = New Point(rnd.Next(rect.Width), rnd.Next(rect.Height)),
                .Speed = speeds.GetRandomValue,
                .Direction = GetAngleVector(d.GetRandomValue)
            }
        Next

        Dots = dlst
    End Sub
End Class

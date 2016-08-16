Imports System.Drawing
Imports Microsoft.VisualBasic.Serialization.JSON

Public Class Dot

    Public Property Location As PointF
    Public Property Direction As PointF
    Public Property Speed As Single

    Public ReadOnly Property Alpha As Double
        Get
            Return Direction.Angle
        End Get
    End Property

    Public Property Nearby As New Dictionary(Of Dot, Double)

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function

End Class

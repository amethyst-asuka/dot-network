Imports System.Drawing
Imports Microsoft.VisualBasic.Serialization.JSON

Public Class Dot

    Public Property Location As Point
    Public Property Direction As PointF
    Public Property Speed As Single

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function

End Class

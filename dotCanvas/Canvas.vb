Imports System.Windows.Forms
Imports Microsoft.VisualBasic.Parallel.Tasks

Public Class Canvas

    ReadOnly __driver As New UpdateThread(30, AddressOf __update)

    Private Sub __update()
        Me.Invalidate()
    End Sub

    Private Sub Canvas_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

    End Sub
End Class

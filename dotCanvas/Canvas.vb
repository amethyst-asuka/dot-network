Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.Parallel.Tasks

Public Class Canvas

    ReadOnly __driver As New UpdateThread(30, AddressOf __update)

    Dim model As Model

    Private Sub __update()
        Me.Invalidate()
    End Sub

    Private Sub Canvas_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        __driver.Dispose()
    End Sub

    Private Sub Canvas_Load(sender As Object, e As EventArgs) Handles Me.Load
        model = New Model(0, Size)
        __driver.Start()
    End Sub

    Private Sub Canvas_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Call model.Calculate(New Rectangle(New Point, Size))
        Call model.Update(e.Graphics)
    End Sub
End Class

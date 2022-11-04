Public Class wdAcesso

    Private Sub SairBtn_Click(sender As Object, e As RoutedEventArgs) Handles SairBtn.Click
        Me.Close()
    End Sub


    Private Sub wdAcesso_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Key = Key.Escape Then
            Me.Close()
        End If
    End Sub
End Class

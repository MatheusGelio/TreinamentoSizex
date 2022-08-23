Public Class wdCadCliente

    Private Sub SairBtn_Click(sender As Object, e As RoutedEventArgs) Handles SairBtn.Click
        Me.Close()
    End Sub

    Private Sub Window_Loaded_1(sender As Object, e As RoutedEventArgs)
        FotoCt.Content = New ucCadFoto
    End Sub
End Class
Public Class wdCadProduto

    Private Sub SairBtn_Click(sender As Object, e As RoutedEventArgs) Handles SairBtn.Click
        Me.Close()
    End Sub

    Private Sub Window_Loaded_1(sender As Object, e As RoutedEventArgs)
        Me.Show()
    End Sub


    Private Sub wdCadProduto_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim lista As New List(Of String)
        lista.Add("ACABADO")
        lista.Add("EMBALAGEM")
        lista.Add("INSUMO")
        lista.Add("MATERIA PRIMA")

        TipoTxt.ItemsSource = lista.ToList
    End Sub
End Class

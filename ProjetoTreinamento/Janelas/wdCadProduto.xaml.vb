Public Class wdCadProduto
    Dim passou As Boolean = False

    Private Sub SairBtn_Click(sender As Object, e As RoutedEventArgs) Handles SairBtn.Click
        Me.Close()
    End Sub

    Private Sub wdCadProduto_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If passou = False Then
            Me.Show()
            Dim lista As New List(Of String)
            lista.Add("ACABADO")
            lista.Add("EMBALAGEM")
            lista.Add("INSUMO")
            lista.Add("MATERIA PRIMA")

            TipoTxt.ItemsSource = lista.ToList

            passou = True
        End If
    End Sub
End Class

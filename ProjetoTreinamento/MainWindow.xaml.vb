Class MainWindow

    Private Sub ProductMnu_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles ProductMnu.MouseLeftButtonDown
        Dim wd As New wdCadProduto
        wd.ShowDialog()
    End Sub

    Private Sub ClienteMnu_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles ClienteMnu.MouseLeftButtonDown
        Dim wd As New wdCadCliente
        wd.ShowDialog()
    End Sub

    Private Sub VeiculoMnu_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles VeiculoMnu.MouseLeftButtonDown
        Dim uc As New ucCadVeiculo
        Dim tb As New TabItem
        tb.Content = uc
        tb.Header = "Veículos"
        MenuTb.Items.Add(tb)
    End Sub
End Class
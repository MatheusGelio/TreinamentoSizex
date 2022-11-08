Class MainWindow

    Private Sub ProductMnu_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles ProductMnu.MouseLeftButtonDown
        Dim uc As New ucCadProduto
        Dim tb As New TabItem
        tb.Content = uc
        tb.Header = "Produtos"
        MenuTb.Items.Add(tb)
    End Sub

    Private Sub ClienteMnu_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles ClienteMnu.MouseLeftButtonDown
        Dim uc As New ucCadCliente("C")
        Dim tb As New TabItem
        tb.Content = uc
        tb.Header = "Clientes"
        MenuTb.Items.Add(tb)
    End Sub

    Private Sub FornecedorMnu_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles FornecedorMnu.MouseLeftButtonDown
        Dim uc As New ucCadCliente("F")
        Dim tb As New TabItem
        tb.Content = uc
        tb.Header = "Fornecedores"
        MenuTb.Items.Add(tb)
    End Sub

    Private Sub VeiculoMnu_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles VeiculoMnu.MouseLeftButtonDown
        Dim uc As New ucCadVeiculo
        Dim tb As New TabItem
        tb.Content = uc
        tb.Header = "Veículos"
        MenuTb.Items.Add(tb)
    End Sub
End Class
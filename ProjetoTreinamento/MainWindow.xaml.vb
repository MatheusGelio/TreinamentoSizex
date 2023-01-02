Class MainWindow

    Private Sub ProductMnu_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles ProductMnu.MouseLeftButtonDown
        Cfg.CarregarTela(MenuTb, New ucCadProduto)
    End Sub

    Private Sub ClienteMnu_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles ClienteMnu.MouseLeftButtonDown
        Cfg.CarregarTela(MenuTb, New ucCadCliente("C"))
    End Sub

    Private Sub FornecedorMnu_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles FornecedorMnu.MouseLeftButtonDown
        Cfg.CarregarTela(MenuTb, New ucCadCliente("F"))
    End Sub

    Private Sub VeiculoMnu_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles VeiculoMnu.MouseLeftButtonDown
        Cfg.CarregarTela(MenuTb, New ucCadVeiculo)
    End Sub

    Private Sub TituloMnu_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles TituloMnu.MouseLeftButtonDown
        Cfg.CarregarTela(MenuTb, new ucCadTitulo)
    End Sub

    Private Sub VendaMnu_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles VendaMnu.MouseLeftButtonDown
        Cfg.CarregarTela(MenuTb, New ucCadVenda)
    End Sub
End Class
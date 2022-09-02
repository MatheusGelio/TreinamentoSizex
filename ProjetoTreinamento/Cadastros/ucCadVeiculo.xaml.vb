Public Class ucCadVeiculo

    Private Sub ucCadVeiculo_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim lista As New List(Of String)
        lista.Add("DIESEL")
        lista.Add("ETANOL")
        lista.Add("FLEX")
        lista.Add("GASOLINA")

        CombustivelTxt.ItemsSource = lista.ToList
    End Sub

    Private Sub AdicionarBtn_Click(sender As Object, e As RoutedEventArgs) Handles AdicionarBtn.Click
        Dim objVeiculo As New Veiculo
        objVeiculo.Placa = PlacaTxt.Text
        objVeiculo.DescricaoVeiculo = DescricaoTxt.Text
        objVeiculo.Combustivel = CombustivelTxt.Text
        objVeiculo.UltimoKm = KmTxt.Text
        objVeiculo.ValorCompra = ValorTxt.Text
        objVeiculo.DataAquisicao = DataTxt.Text

        Dim objVeiculoRegistros As New VeiculoRegistros
        objVeiculoRegistros.DataAbast = DataAbastTxt.Text
        objVeiculoRegistros.KmAbast = KmAbastTxt.Text
        objVeiculoRegistros.Litros = LitrosTxt.Text
        objVeiculoRegistros.ValorTotal = ValorTxt.Text

        objVeiculo.Registros = New List(Of VeiculoRegistros)
        objVeiculo.Registros.Add(objVeiculoRegistros)
    End Sub
End Class

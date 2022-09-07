Public Class ucCadVeiculo
    Dim objVeiculo As Veiculo
    Dim passou As Boolean = False

    Private Sub ucCadVeiculo_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If passou = False Then
            Dim lista As New List(Of String)
            lista.Add("DIESEL")
            lista.Add("ETANOL")
            lista.Add("FLEX")
            lista.Add("GASOLINA")

            CombustivelTxt.ItemsSource = lista.ToList

            passou = True
        End If
    End Sub

    Private Sub AdicionarBtn_Click(sender As Object, e As RoutedEventArgs) Handles AdicionarBtn.Click
        If objVeiculo Is Nothing Then
            MsgBox("Para incluir um registro, o veículo precisa estar salvo, verifique!", MsgBoxStyle.Exclamation, "Validação")
            Exit Sub
        End If

        If Not IsDate(DataAbastTxt.Text) Then
            MsgBox("Para incluir um registro, é necessário preencher o campo de DATA, verifique!", MsgBoxStyle.Exclamation, "Validação")
            DataTxt.Focus()
            Exit Sub
        ElseIf KmAbastTxt.Text = Nothing Then
            MsgBox("Para incluir um registro, é necessário preencher o campo de KM, verifique!", MsgBoxStyle.Exclamation, "Validação")
            KmAbastTxt.Focus()
            Exit Sub
        ElseIf LitrosTxt.Text = Nothing Then
            MsgBox("Para incluir um registro, é necessário preencher o campo de LITROS, verifique!", MsgBoxStyle.Exclamation, "Validação")
            LitrosTxt.Focus()
            Exit Sub
        ElseIf TotalTxt.Text = Nothing Then
            MsgBox("Para incluir um registro, é necessário preencher o campo de VALOR TOTAL, verifique!", MsgBoxStyle.Exclamation, "Validação")
            TotalTxt.Focus()
            Exit Sub
        End If

        Dim objVeiculoRegistros As New VeiculoRegistros
        objVeiculoRegistros.DataAbast = DataAbastTxt.Text
        objVeiculoRegistros.KmAbast = KmAbastTxt.Text
        objVeiculoRegistros.Litros = LitrosTxt.Text
        objVeiculoRegistros.ValorTotal = TotalTxt.Text

        If objVeiculo.Registros Is Nothing Then
            objVeiculo.Registros = New List(Of VeiculoRegistros)
        End If
        objVeiculo.Registros.Add(objVeiculoRegistros)

        Dim mensagem As String = "Veículo salvo com sucesso!" & vbNewLine & "Total de Registros: " & objVeiculo.Registros.Count

        MsgBox(mensagem, MsgBoxStyle.Information, "Parabéns!")
        DataAbastTxt.Text = Nothing
        KmAbastTxt.Clear()
        LitrosTxt.Clear()
        TotalTxt.Clear()
    End Sub

    Private Sub SalvarBtn_Click(sender As Object, e As RoutedEventArgs) Handles SalvarBtn.Click
        If PlacaTxt.Text = Nothing Then
            MsgBox("Para salvar um veículo, é necessário preencher o campo de PLACA, verifique!", MsgBoxStyle.Exclamation, "Validação")
            PlacaTxt.Focus()
            Exit Sub
        ElseIf CombustivelTxt.Text = Nothing Then
            MsgBox("Para salvar um veículo, é necessário preencher o campo de COMBUSTÍVEL, verifique!", MsgBoxStyle.Exclamation, "Validação")
            CombustivelTxt.Focus()
            Exit Sub
        ElseIf KmTxt.Text = Nothing Then
            MsgBox("Para salvar um veículo, é necessário preencher o campo de ÚLTIMO KM, verifique!", MsgBoxStyle.Exclamation, "Validação")
            KmTxt.Focus()
            Exit Sub
        ElseIf ValorTxt.Text = Nothing Then
            MsgBox("Para salvar um veículo, é necessário preencher o campo de VALOR DE COMPRA, verifique!", MsgBoxStyle.Exclamation, "Validação")
            ValorTxt.Focus()
            Exit Sub
        ElseIf Not IsDate(DataTxt.Text) Then
            MsgBox("Para salvar um veículo, é necessário preencher o campo de DATA DE AQUISIÇÃO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            DataTxt.Focus()
            Exit Sub
        End If

        objVeiculo = New Veiculo

        objVeiculo.Placa = PlacaTxt.Text
        objVeiculo.DescricaoVeiculo = DescricaoTxt.Text
        objVeiculo.Combustivel = CombustivelTxt.Text
        objVeiculo.UltimoKm = KmTxt.Text
        objVeiculo.ValorCompra = ValorTxt.Text
        objVeiculo.DataAquisicao = DataTxt.Text

        MsgBox("Veículo salvo com sucesso!", MsgBoxStyle.Information, "Parabéns!")
        PlacaTxt.Clear()
        DescricaoTxt.Clear()
        CombustivelTxt.Text = Nothing
        KmTxt.Clear()
        ValorTxt.Clear()
        DataTxt.Text = Nothing

        PlacaTxt.Focus()
    End Sub
End Class

Public Class wdCadCliente

    Private Sub SairBtn_Click(sender As Object, e As RoutedEventArgs) Handles SairBtn.Click
        Me.Close()
    End Sub

    Private Sub Window_Loaded_1(sender As Object, e As RoutedEventArgs)
        FotoCt.Content = New ucCadFoto
    End Sub

    Private Sub wdCadCliente_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim lista As New List(Of String)
        lista.Add("ACRE (AC)")
        lista.Add("ALAGOAS (AL)")
        lista.Add("AMAPÁ (AP)")
        lista.Add("AMAZONAS (AM)")
        lista.Add("BAHIA (BA)")
        lista.Add("CEARÁ (CE)")
        lista.Add("DISTRITO FEDERAL (DF)")
        lista.Add("ESPÍRITO SANTO (ES)")
        lista.Add("GOIÁS (GO)")
        lista.Add("MARANHÃO (MA)")
        lista.Add("MATO GROSSO (MT)")
        lista.Add("MATO GROSSO DO SUL (MS)")
        lista.Add("MINAS GERAIS (MG)")
        lista.Add("PARÁ (PA)")
        lista.Add("PARAÍBA (PB)")
        lista.Add("PARANÁ (PR)")
        lista.Add("PERNAMBUCO (PE)")
        lista.Add("PIAUÍ (PI)")
        lista.Add("RIO DE JANEIRO (RJ)")
        lista.Add("RIO GRANDE DO NORTE (RN)")
        lista.Add("RIO GRANDE DO SUL (RS)")
        lista.Add("RONDÔNIA (RO)")
        lista.Add("RORAIMA (RR)")
        lista.Add("SANTA CATARINA (SC)")
        lista.Add("SÃO PAULO (SP)")
        lista.Add("SERGIPE (SE)")
        lista.Add("TOCANTINS (TO)")

        EstadoTxt.ItemsSource = lista.ToList
    End Sub

    Private Sub AdicionarBtn_Click(sender As Object, e As RoutedEventArgs) Handles AdicionarBtn.Click
        Dim objCliente As New Cliente
        objCliente.Cpf = CpfTxt.Text
        objCliente.Rg = RgTxt.Text
        objCliente.DataCadastro = DataTxt.Text
        objCliente.Inativo = InativoChk.IsChecked
        objCliente.Nome = NomeTxt.Text
        objCliente.Endereco = EnderecoTxt.Text
        objCliente.Numero = NumeroTxt.Text
        objCliente.Complemento = ComplementoTxt.Text
        objCliente.Bairro = BairroTxt.Text
        objCliente.Cidade = CidadeTxt.Text
        objCliente.Estado = EstadoTxt.Text

        Dim objClienteContatos As New ClienteContatos
        objClienteContatos.TipoContato = TipoTxt.Text
        objClienteContatos.DadosContato = ContatoTxt.Text
        objClienteContatos.Obs = ObsTxt.Text

        objCliente.Contatos = New List(Of ClienteContatos)
        objCliente.Contatos.Add(objClienteContatos)
    End Sub
End Class
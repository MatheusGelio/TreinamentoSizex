Public Class wdCadCliente
    Dim objCliente As Cliente
    Dim passou As Boolean = False

    Private Sub SairBtn_Click(sender As Object, e As RoutedEventArgs) Handles SairBtn.Click
        Me.Close()
    End Sub

    Private Sub wdCadCliente_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If passou = False Then
            FotoCt.Content = New ucCadFoto
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

            passou = True
        End If
    End Sub

    Private Sub AdicionarBtn_Click(sender As Object, e As RoutedEventArgs) Handles AdicionarBtn.Click
        If objCliente Is Nothing Then
            MsgBox("Para incluir um contato, o cliente precisa estar salvo, verifique!", MsgBoxStyle.Exclamation, "Validação")
            Exit Sub
        End If

        If TipoTxt.Text = Nothing Then
            MsgBox("Para incluir um contato, é necessário preencher o campo de TIPO DE CONTATO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            TipoTxt.Focus()
            Exit Sub
        ElseIf ContatoTxt.Text = Nothing Then
            MsgBox("Para incluir um contato, é necessário preencher o campo de DADOS DO CONTATO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            ContatoTxt.Focus()
            Exit Sub
        ElseIf ObsTxt.Text = Nothing Then
            MsgBox("Para incluir um contato, é necessário preencher o campo de OBSERVAÇÕES, verifique!", MsgBoxStyle.Exclamation, "Validação")
            ObsTxt.Focus()
            Exit Sub
        End If

        Dim objClienteContatos As New ClienteContatos
        objClienteContatos.TipoContato = TipoTxt.Text
        objClienteContatos.DadosContato = ContatoTxt.Text
        objClienteContatos.Obs = ObsTxt.Text

        If objCliente.Contatos Is Nothing Then
            objCliente.Contatos = New List(Of ClienteContatos)
        End If
        objCliente.Contatos.Add(objClienteContatos)

        Dim mensagem As String = "Contato salvo com sucesso!" & vbNewLine & "Total de Registros: " & objCliente.Contatos.Count

        MsgBox(mensagem, MsgBoxStyle.Information, "Parabéns!")
        TipoTxt.Clear()
        ContatoTxt.Clear()
        ObsTxt.Clear()
    End Sub

    Private Sub SalvarBtn_Click(sender As Object, e As RoutedEventArgs) Handles SalvarBtn.Click
        If CpfTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de CPF, verifique!", MsgBoxStyle.Exclamation, "Validação")
            CpfTxt.Focus()
            Exit Sub
        ElseIf RgTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de RG, verifique!", MsgBoxStyle.Exclamation, "Validação")
            RgTxt.Focus()
            Exit Sub
        ElseIf Not IsDate(DataTxt.Text) Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de DATA, verifique!", MsgBoxStyle.Exclamation, "Validação")
            DataTxt.Focus()
            Exit Sub
        ElseIf NomeTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de NOME, verifique!", MsgBoxStyle.Exclamation, "Validação")
            NomeTxt.Focus()
            Exit Sub
        ElseIf EnderecoTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de ENDEREÇO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            EnderecoTxt.Focus()
            Exit Sub
        ElseIf NumeroTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de NÚMERO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            NumeroTxt.Focus()
            Exit Sub
        ElseIf BairroTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de BAIRRO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            BairroTxt.Focus()
            Exit Sub
        ElseIf CidadeTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de CIDADE, verifique!", MsgBoxStyle.Exclamation, "Validação")
            CidadeTxt.Focus()
            Exit Sub
        ElseIf EstadoTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de ESTADO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            EstadoTxt.Focus()
            Exit Sub
        End If

        objCliente = New Cliente

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

        MsgBox("Registro salvo com sucesso!", MsgBoxStyle.Information, "Parabéns!")
        CpfTxt.Clear()
        RgTxt.Clear()
        DataTxt.Text = Nothing
        InativoChk.IsChecked = False
        NomeTxt.Clear()
        EnderecoTxt.Clear()
        NumeroTxt.Clear()
        ComplementoTxt.Clear()
        BairroTxt.Clear()
        CidadeTxt.Clear()
        EstadoTxt.Text = Nothing

        CpfTxt.Focus()
    End Sub
End Class
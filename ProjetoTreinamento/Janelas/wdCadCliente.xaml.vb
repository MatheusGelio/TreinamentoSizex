Public Class wdCadCliente
    Dim objCliente As Cliente
    Dim passou As Boolean = False
    Dim srcContatos As CollectionViewSource

#Region "Métodos"
    Private Sub LimpaCampos(tipo As String)
        If tipo = "C" Or tipo = "T" Then
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
            objCliente = Nothing

            srcContatos.Source = Nothing
        End If
        
        If tipo = "CT" Or tipo = "T" Then
            TipoTxt.Clear()
            ContatoTxt.Clear()
            ObsTxt.Clear()
        End If
    End Sub

    Private Function GravaCliente() As Boolean
        If CpfTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de CPF, verifique!", MsgBoxStyle.Exclamation, "Validação")
            CpfTxt.Focus()
            Return False
            Exit Function
        ElseIf RgTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de RG, verifique!", MsgBoxStyle.Exclamation, "Validação")
            RgTxt.Focus()
            Return False
            Exit Function
        ElseIf Not IsDate(DataTxt.Text) Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de DATA, verifique!", MsgBoxStyle.Exclamation, "Validação")
            DataTxt.Focus()
            Return False
            Exit Function
        ElseIf NomeTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de NOME, verifique!", MsgBoxStyle.Exclamation, "Validação")
            NomeTxt.Focus()
            Return False
            Exit Function
        ElseIf EnderecoTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de ENDEREÇO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            EnderecoTxt.Focus()
            Return False
            Exit Function
        ElseIf NumeroTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de NÚMERO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            NumeroTxt.Focus()
            Return False
            Exit Function
        ElseIf BairroTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de BAIRRO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            BairroTxt.Focus()
            Return False
            Exit Function
        ElseIf CidadeTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de CIDADE, verifique!", MsgBoxStyle.Exclamation, "Validação")
            CidadeTxt.Focus()
            Return False
            Exit Function
        ElseIf EstadoTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de ESTADO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            EstadoTxt.Focus()
            Return False
            Exit Function
        End If

        If objCliente Is Nothing Then
            objCliente = New Cliente
            objCliente.Contatos = New List(Of ClienteContatos)
        End If

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

        Return True
    End Function
#End Region

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

            srcContatos = CType(Me.FindResource("ClienteContatosViewSource"), CollectionViewSource)

            passou = True
        End If
    End Sub

    Private Sub AdicionarBtn_Click(sender As Object, e As RoutedEventArgs) Handles AdicionarBtn.Click
        If GravaCliente() = False Then
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

        objCliente.Contatos.Add(objClienteContatos)

        Dim mensagem As String = "Contato salvo com sucesso!" & vbNewLine & "Total de Registros: " & objCliente.Contatos.Count

        MsgBox(mensagem, MsgBoxStyle.Information, "Parabéns!")

        srcContatos.Source = objCliente.Contatos.ToList

        LimpaCampos("CT")
    End Sub

    Private Sub SalvarBtn_Click(sender As Object, e As RoutedEventArgs) Handles SalvarBtn.Click
        If GravaCliente() = False Then
            Exit Sub
        End If

        MsgBox("Registro salvo com sucesso!", MsgBoxStyle.Information, "Parabéns!")
        LimpaCampos("T")
        CpfTxt.Focus()
    End Sub

    Private Sub NovoBtn_Click(sender As Object, e As RoutedEventArgs) Handles NovoBtn.Click
        LimpaCampos("T")
    End Sub

    Private Sub ExcluirBtn_Click(sender As Object, e As RoutedEventArgs) Handles ExcluirBtn.Click
        LimpaCampos("C")
    End Sub
End Class
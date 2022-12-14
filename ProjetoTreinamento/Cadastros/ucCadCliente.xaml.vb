Public Class ucCadCliente
    Dim objCliente As Cliente
    Dim objClienteContatos As ClienteContatos
    Dim passou As Boolean = False
    Dim srcCliente As CollectionViewSource
    Dim srcClienteContatos As CollectionViewSource
    Dim lstCliente As List(Of Cliente)
    Dim tipoPesquisa As String
    Dim ctx As SizexConnectionEntities

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(tipo As String)
        InitializeComponent()

        If tipo = "C" Then
            TituloLbl.Content = "Cadastro de Clientes"
        Else
            TituloLbl.Content = "Cadastro de Fornecedores"
            Tag = "Fornecedores"
            FotoCt.Visibility = Windows.Visibility.Collapsed
        End If
    End Sub

#Region "Métodos"
    Private Sub LimparCampos(tipo As String)
        Try
            If tipo = "C" Or tipo = "T" Then
                CpfTxt.Text = ""
                RgTxt.Text = ""
                DataTxt.Text = Date.Today
                InativoChk.IsChecked = False
                NomeTxt.Text = ""
                EnderecoTxt.Text = ""
                NumeroTxt.Text = ""
                ComplementoTxt.Text = ""
                BairroTxt.Text = ""
                CidadeTxt.Text = ""
                EstadoTxt.SelectedItem = ""
                objCliente = Nothing

                srcClienteContatos.Source = Nothing
            End If

            If tipo = "CT" Or tipo = "T" Then
                TipoTxt.Text = ""
                ContatoTxt.Text = ""
                ObsTxt.Text = ""
                objClienteContatos = Nothing
            End If

            CidadeTxt.ItemsSource = ctx.Cliente.Select(Function(p) p.Cidade).Distinct.ToList
            EstadoTxt.ItemsSource = ctx.Cliente.Select(Function(p) p.Estado).Distinct.ToList
        Catch ex As Exception
            MsgBox("Ocorreu um errro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Limpar Campos")
        End Try
    End Sub

    Private Sub PreencherCamposCliente()
        Try
            If objCliente IsNot Nothing Then
                CpfTxt.Text = objCliente.Cpf
                RgTxt.Text = objCliente.Rg
                If objCliente.DataCadastro Is Nothing Then
                    DataTxt.Text = ""
                Else
                    DataTxt.Text = objCliente.DataCadastro
                End If
                InativoChk.IsChecked = objCliente.Inativo
                NomeTxt.Text = objCliente.Nome
                EnderecoTxt.Text = objCliente.Endereco
                NumeroTxt.Text = objCliente.Numero
                ComplementoTxt.Text = objCliente.Complemento
                BairroTxt.Text = objCliente.Bairro
                CidadeTxt.Text = objCliente.Cidade
                EstadoTxt.Text = objCliente.Estado
            End If
            srcClienteContatos.Source = ctx.ClienteContatos.Where(Function(p) p.ClienteId = objCliente.Id).ToList
        Catch ex As Exception
            MsgBox("Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Preencher Campos")
        End Try
    End Sub

    Private Sub PreencherCamposClienteContatos()
        Try
            If objClienteContatos IsNot Nothing Then
                TipoTxt.Text = objClienteContatos.Tipo
                ContatoTxt.Text = objClienteContatos.Dados
                ObsTxt.Text = objClienteContatos.Obs
            End If
        Catch ex As Exception
            MsgBox("Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Preencher Campos")
        End Try
    End Sub

    Private Function GravaCliente(Optional ByRef retorno As String = "") As Boolean
        retorno = "1 - Validando Campos."
        If CpfTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de CPF, verifique!", MsgBoxStyle.Exclamation, "Validação")
            CpfTxt.Focus()
            Return False
        ElseIf RgTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de RG, verifique!", MsgBoxStyle.Exclamation, "Validação")
            RgTxt.Focus()
            Return False
        ElseIf Not IsDate(DataTxt.Text) Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de DATA, verifique!", MsgBoxStyle.Exclamation, "Validação")
            DataTxt.Focus()
            Return False
        ElseIf NomeTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de NOME, verifique!", MsgBoxStyle.Exclamation, "Validação")
            NomeTxt.Focus()
            Return False
        ElseIf EnderecoTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de ENDEREÇO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            EnderecoTxt.Focus()
            Return False
        ElseIf NumeroTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de NÚMERO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            NumeroTxt.Focus()
            Return False
        ElseIf BairroTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de BAIRRO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            BairroTxt.Focus()
            Return False
        ElseIf CidadeTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de CIDADE, verifique!", MsgBoxStyle.Exclamation, "Validação")
            CidadeTxt.Focus()
            Return False
        ElseIf EstadoTxt.Text = Nothing Then
            MsgBox("Para salvar um cliente, é necessário preencher o campo de ESTADO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            EstadoTxt.Focus()
            Return False
        End If

        retorno = "2 - Inserindo Objeto."
        If objCliente Is Nothing Then
            objCliente = New Cliente
            ctx.Cliente.Add(objCliente)
        End If

        retorno = "3 - Gravando Campos do Cliente."
        objCliente.Cpf = CpfTxt.Text
        objCliente.Rg = RgTxt.Text
        objCliente.DataCadastro = DataTxt.Text
        objCliente.Inativo = InativoChk.IsChecked
        objCliente.Nome = UCase(NomeTxt.Text)
        objCliente.Endereco = UCase(EnderecoTxt.Text)
        objCliente.Numero = CInt(NumeroTxt.Text)
        objCliente.Complemento = UCase(ComplementoTxt.Text)
        objCliente.Bairro = UCase(BairroTxt.Text)
        objCliente.Cidade = UCase(CidadeTxt.Text)
        objCliente.Estado = UCase(EstadoTxt.Text)

        objCliente.Usuario = InputBox("Informe o seu nome para gravar um cliente", "Auditoria", "")
        objCliente.Data = Date.Now

        ctx.SaveChanges()

        retorno = "4 - Gravação Concluída."
        Return True
    End Function
#End Region

    Private Sub ucCadCliente_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles Me.PreviewKeyDown
        Select Case e.Key
            Case Key.F2
                NovoBtn_Click(Nothing, Nothing)
            Case Key.F3
                SalvarBtn_Click(Nothing, Nothing)
            Case Key.F4
                ExcluirBtn_Click(Nothing, Nothing)
            Case Key.Escape
                SairBtn_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub wdCadCliente_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If passou = False Then
            ctx = New SizexConnectionEntities
            FotoCt.Content = New ucCadFoto
            lstCliente = New List(Of Cliente)
            srcCliente = CType(Me.FindResource("ClienteViewSource"), CollectionViewSource)
            srcClienteContatos = CType(Me.FindResource("ClienteContatosViewSource"), CollectionViewSource)
            LimparCampos("T")
            tipoPesquisa = "N"
            passou = True
        End If
    End Sub

    Private Sub AdicionarBtn_Click(sender As Object, e As RoutedEventArgs) Handles AdicionarBtn.Click
        Dim retorno As String = ""
        Try
            If GravaCliente(retorno) = False Then
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
            End If

            If objClienteContatos Is Nothing Then
                objClienteContatos = New ClienteContatos
                objClienteContatos.Cliente = objCliente
                ctx.ClienteContatos.Add(objClienteContatos)
            End If

            objClienteContatos.Tipo = UCase(TipoTxt.Text)
            objClienteContatos.Dados = UCase(ContatoTxt.Text)
            objClienteContatos.Obs = UCase(ObsTxt.Text)

            ctx.SaveChanges()

            Dim mensagem As String = "Contato salvo com sucesso!" & vbNewLine & "Total de Registros: " & objCliente.ClienteContatos.Count
            MsgBox(mensagem, MsgBoxStyle.Information, "Parabéns!")

            'srcClienteContatos.Source = ctx.ClienteContatos.Where(Function(p) p.ClienteId = objCliente.Id).ToList'

            LimparCampos("CT")
            PreencherCamposCliente()
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Adicionar Contato")
        End Try
    End Sub

    Private Sub DeletarBtn_Click(sender As Object, e As RoutedEventArgs) Handles DeletarBtn.Click
        Dim retorno As String = ""
        Try
            If objCliente Is Nothing Then
                MsgBox("Para deletar um contato, é necessário selecioná-lo antes, verifique!", MsgBoxStyle.Exclamation, "Deletar Contato")
                Exit Sub
            End If

            If objClienteContatos Is Nothing Then
                MsgBox("Para deletar um contato, é necessário selecioná-lo antes, verifique!", MsgBoxStyle.Exclamation, "Deletar Contato")
                Exit Sub
            End If

            ctx.ClienteContatos.Remove(objClienteContatos)
            ctx.SaveChanges()

            'srcClienteContatos.Source = ctx.ClienteContatos.Where(Function(p) p.ClienteId = objCliente.Id).ToList'

            MsgBox("Contato deletado com sucesso!", MsgBoxStyle.Information, "Parabéns!")

            LimparCampos("CT")
            PreencherCamposCliente()
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Deletar Contato")
        End Try
    End Sub

    Private Sub SalvarBtn_Click(sender As Object, e As RoutedEventArgs) Handles SalvarBtn.Click
        Dim retorno As String = ""
        Try
            If GravaCliente(retorno) = False Then
                Exit Sub
            End If

            'srcCliente.Source = ctx.Cliente.OrderBy(Function(p) p.Nome).ToList'
            srcCliente.Source = ctx.Cliente.ToList

            MsgBox("Registro salvo com sucesso!", MsgBoxStyle.Information, "Parabéns!")
            LimparCampos("T")
            CpfTxt.Focus()
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Salvar Cliente")
        End Try
    End Sub

    Private Sub NovoBtn_Click(sender As Object, e As RoutedEventArgs) Handles NovoBtn.Click
        LimparCampos("T")
    End Sub

    Private Sub ExcluirBtn_Click(sender As Object, e As RoutedEventArgs) Handles ExcluirBtn.Click
        Dim retorno As String = ""
        Try
            If objCliente Is Nothing Then
                MsgBox("Para excluir um cliente, é necessário selecioná-lo antes, verifique!", MsgBoxStyle.Exclamation, "Excluir Cliente")
                Exit Sub
            End If

            ctx.Cliente.Remove(objCliente)
            ctx.SaveChanges()
            srcCliente.Source = ctx.Cliente.ToList

            MsgBox("Cliente excluído com sucesso!", MsgBoxStyle.Information, "Parabéns!")

            LimparCampos("C")
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Excluir Cliente")
        End Try
    End Sub

    Private Sub SairBtn_Click(sender As Object, e As RoutedEventArgs) Handles SairBtn.Click
        Cfg.DestruirTela(Me)
    End Sub

    Private Sub ClienteContatosDataGrid_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles ClienteContatosDataGrid.MouseDoubleClick
        If sender.selectedItem IsNot Nothing Then
            objClienteContatos = CType(sender.selectedItem, ClienteContatos)
            PreencherCamposClienteContatos()
        End If
    End Sub

    Private Sub ClienteDataGrid_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles ClienteDataGrid.MouseDoubleClick
        If sender.selectedItem IsNot Nothing Then
            objCliente = CType(sender.selectedItem, Cliente)
            PreencherCamposCliente()
            PrincipalTb.SelectedItem = CadTb
            e.Handled = True
        End If
    End Sub

    Private Sub CpfTxt_LostFocus(sender As Object, e As RoutedEventArgs) Handles CpfTxt.LostFocus
        CpfTxt.Text = Cfg.FormatarCpf(CpfTxt.Text)
    End Sub

    Private Sub RgTxt_LostFocus(sender As Object, e As RoutedEventArgs) Handles RgTxt.LostFocus
        RgTxt.Text = Cfg.FormatarRg(RgTxt.Text)
    End Sub

    Private Sub DataTxt_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles DataTxt.PreviewKeyDown
        If e.Key = Key.Return Or e.Key = Key.Tab Then
            NomeTxt.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub BairroTxt_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles BairroTxt.PreviewKeyDown
        If e.Key = Key.Return Or e.Key = Key.Tab Then
            CidadeTxt.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub CidadeTxt_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles CidadeTxt.PreviewKeyDown
        If e.Key = Key.Return Or e.Key = Key.Tab Then
            EstadoTxt.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub PesquisarTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles PesquisarTxt.KeyDown
        If e.Key = Key.F6 Then
            If tipoPesquisa = "N" Then
                PesquisarLbl.Content = "[F6] Pesquisar por: CPF"
                tipoPesquisa = "C"
            ElseIf tipoPesquisa = "C" Then
                PesquisarLbl.Content = "[F6] Pesquisar por: Endereço"
                tipoPesquisa = "E"
            ElseIf tipoPesquisa = "E" Then
                PesquisarLbl.Content = "[F6] Pesquisar por: Nome do Cliente"
                tipoPesquisa = "N"
            End If
        End If
    End Sub

    Private Sub PesquisarTxt_TextChanged(sender As Object, e As TextChangedEventArgs) Handles PesquisarTxt.TextChanged
        If ctx.Cliente.ToList.Count > 0 Then
            If tipoPesquisa = "N" Then
                srcCliente.Source = ctx.Cliente.Where(Function(p) p.Nome.Contains(CStr(PesquisarTxt.Text))).ToList
            ElseIf tipoPesquisa = "C" Then
                srcCliente.Source = ctx.Cliente.Where(Function(p) p.Cpf.Contains(CStr(PesquisarTxt.Text))).ToList
            ElseIf tipoPesquisa = "E" Then
                srcCliente.Source = ctx.Cliente.Where(Function(p) p.Endereco.Contains(CStr(PesquisarTxt.Text))).ToList
            End If
        End If
    End Sub
End Class
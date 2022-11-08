Public Class ucCadProduto
    Dim objProduto As Produto
    Dim srcProduto As CollectionViewSource
    Dim lstProduto As List(Of Produto)
    Dim passou As Boolean = False

#Region "Métodos"
    Private Sub LimparCampos()
        If lstProduto.Count > 0 Then
            CodigoTxt.Text = lstProduto.Select(Function(p) p.Codigo).Max + 1
        Else
            CodigoTxt.Text = 1
        End If
        DescricaoTxt.Text = ""
        DataTxt.Text = Date.Today
        SimRdb.IsChecked = True
        GrupoTxt.Text = ""
        TipoCmb.SelectedIndex = -1
        CustoTxt.Text = "0,00"
        MargemTxt.Text = "0,00"
        PrecoTxt.Text = "0,00"
        InativoChk.IsChecked = False
        objProduto = Nothing
    End Sub

    Private Sub PreencherCampos(sender As Object)
        objProduto = CType(sender.selectedItem, Produto)
        CodigoTxt.Text = objProduto.Codigo
        DescricaoTxt.Text = objProduto.Descricao
        DataTxt.Text = objProduto.DataCadastro
        If objProduto.Estoque = True Then
            SimRdb.IsChecked = True
        Else
            NaoRdb.IsChecked = True
        End If
        GrupoTxt.Text = objProduto.Grupo
        TipoCmb.Text = objProduto.TipoProduto
        CustoTxt.Text = objProduto.Custo
        MargemTxt.Text = objProduto.Margem
        PrecoTxt.Text = objProduto.Preco
        InativoChk.IsChecked = objProduto.Inativo

        srcProduto.Source = lstProduto.ToList
    End Sub

    Private Sub CalcularValores(tipo As String)
        Dim valor As Double = 0
        If tipo = "C" Or tipo = "M" Then
            If Cfg.RetornarValorPadrao(CustoTxt.Text) > 0 And Cfg.RetornarValorPadrao(MargemTxt.Text) > 0 Then
                valor = CDbl(CustoTxt.Text) + (CDbl(CustoTxt.Text) * (CDbl(MargemTxt.Text) / 100))
                valor = Math.Round(valor, 2)
                PrecoTxt.Text = valor.ToString("##0.00")
            End If
        ElseIf tipo = "P" Then
            If Cfg.RetornarValorPadrao(CustoTxt.Text) > 0 And Cfg.RetornarValorPadrao(PrecoTxt.Text) > 0 Then
                valor = ((CDbl(PrecoTxt.Text) * 100) / CDbl(CustoTxt.Text)) - 100
                valor = Math.Round(valor, 2)
                MargemTxt.Text = valor.ToString("##0.00")
            End If
        End If
    End Sub

    Private Function SalvarProduto(Optional ByRef retorno As String = "") As Boolean
        retorno = "1 - Validando Campos."
        If Cfg.RetornarValorPadrao(CodigoTxt.Text) = 0 Then
            MsgBox("Para salvar um produto, é necessário preencher o campo de CÓDIGO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            CodigoTxt.Focus()
            Return False
        ElseIf DescricaoTxt.Text = Nothing Then
            MsgBox("Para salvar um produto, é necessário preencher o campo de DESCRIÇÃO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            DescricaoTxt.Focus()
            Return False
        ElseIf Not IsDate(DataTxt.Text) Then
            MsgBox("Para salvar um produto, é necessário preencher o campo de DATA DE CADASTRO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            DataTxt.Focus()
            Return False
        ElseIf TipoCmb.SelectedIndex < 0 Then
            MsgBox("Para salvar um produto, é necessário preencher o campo de TIPO DE PRODUTO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            TipoCmb.Focus()
            Return False
        ElseIf Cfg.RetornarValorPadrao(PrecoTxt.Text) = False Then
            MsgBox("Para salvar um produto, é necessário preencher o campo de PREÇO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            PrecoTxt.Focus()
            Return False
        End If

        retorno = "2 - Inserindo Objeto."
        If objProduto Is Nothing Then
            objProduto = New Produto
            lstProduto.Add(objProduto)
        End If

        retorno = "3 - Salvando Campos do Produto."
        objProduto.Codigo = CInt(CodigoTxt.Text)
        objProduto.Descricao = UCase(DescricaoTxt.Text)
        objProduto.DataCadastro = DataTxt.Text
        objProduto.Estoque = SimRdb.IsChecked
        objProduto.Grupo = UCase(GrupoTxt.Text)
        objProduto.TipoProduto = TipoCmb.Text
        objProduto.Custo = Cfg.RetornarValorPadrao(CustoTxt.Text)
        objProduto.Margem = Cfg.RetornarValorPadrao(MargemTxt.Text)
        objProduto.Preco = CDbl(PrecoTxt.Text)
        objProduto.Inativo = InativoChk.IsChecked

        objProduto.Usuario = InputBox("Informe o seu nome para salvar um produto", "Auditoria", "")
        objProduto.DataSalvamento = Date.Now

        retorno = "4 - Salvamento Concluído."
        Return True
    End Function
#End Region

    Private Sub NovoBtn_Click(sender As Object, e As RoutedEventArgs) Handles NovoBtn.Click
        LimparCampos()
    End Sub

    Private Sub SalvarBtn_Click(sender As Object, e As RoutedEventArgs) Handles SalvarBtn.Click
        Dim retorno As String = ""
        Try
            If SalvarProduto(retorno) = False Then
                Exit Sub
            End If

            srcProduto.Source = lstProduto.ToList

            MsgBox("Produto salvo com sucesso!", MsgBoxStyle.Information, "Parabéns!")
            LimparCampos()
            CodigoTxt.Focus()
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um errro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Salvar Produto")
        End Try
    End Sub

    Private Sub ExcluirBtn_Click(sender As Object, e As RoutedEventArgs) Handles ExcluirBtn.Click
        Dim retorno As String = ""
        Try
            If objProduto Is Nothing Then
                MsgBox("Para excluir um produto, é necessário selecioná-lo antes, verifique!", MsgBoxStyle.Exclamation, "Excluir Produto")
                Exit Sub
            End If

            lstProduto.Remove(objProduto)
            srcProduto.Source = lstProduto.ToList

            MsgBox("Produto excluído com sucesso!", MsgBoxStyle.Information, "Parabéns!")

            LimparCampos()
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um errro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Excluir Produto")
        End Try
    End Sub

    Private Sub SairBtn_Click(sender As Object, e As RoutedEventArgs) Handles SairBtn.Click

    End Sub

    Private Sub ucCadProduto_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub wdCadProduto_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If passou = False Then

            lstProduto = New List(Of Produto)
            srcProduto = CType(Me.FindResource("ProdutoViewSource"), CollectionViewSource)
            LimparCampos()
            CodigoTxt.Focus()

            passou = True
        End If
    End Sub

    Private Sub ProdutoDataGrid_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles ProdutoDataGrid.MouseDoubleClick
        If sender.selectedItem IsNot Nothing Then
            PreencherCampos(sender)
        End If
    End Sub

    Private Sub CustoTxt_LostFocus(sender As Object, e As RoutedEventArgs) Handles CustoTxt.LostFocus
        CalcularValores("C")
    End Sub


    Private Sub MargemTxt_LostFocus(sender As Object, e As RoutedEventArgs) Handles MargemTxt.LostFocus
        CalcularValores("M")
    End Sub


    Private Sub PrecoTxt_LostFocus(sender As Object, e As RoutedEventArgs) Handles PrecoTxt.LostFocus
        CalcularValores("P")
    End Sub

    Private Sub DataTxt_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles DataTxt.PreviewKeyDown
        If e.Key = Key.Return Or e.Key = Key.Tab Then
            GrupoTxt.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub PrecoTxt_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles PrecoTxt.PreviewKeyDown
        If e.Key = Key.Return Or e.Key = Key.Tab Then
            PesquisarTxt.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub PesquisarTxt_TextChanged(sender As Object, e As TextChangedEventArgs) Handles PesquisarTxt.TextChanged
        If lstProduto.Count > 0 Then
            srcProduto.Source = lstProduto.Where(Function(p) p.Descricao.Contains(PesquisarTxt.Text)).ToList
        End If
    End Sub
End Class

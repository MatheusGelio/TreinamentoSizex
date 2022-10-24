Public Class wdCadProduto
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

    Private Function SalvarProduto(Optional ByRef retorno As String = "") As Boolean
        retorno = "1 - Validando Campos."
        If IsNumeric(CodigoTxt.Text) = False Then
            MsgBox("Para salvar um produto, é necessário preencher o campo de CÓDIGO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            CodigoTxt.Focus()
            Return False
        ElseIf CInt(CodigoTxt.Text) = 0 Then
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
        ElseIf IsNumeric(PrecoTxt.Text) = False Then
            MsgBox("Para salvar um produto, é necessário preencher o campo de PREÇO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            PrecoTxt.Focus()
            Return False
        ElseIf CDbl(PrecoTxt.Text) = 0 Then
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
        objProduto.Custo = CDbl(CustoTxt.Text)
        objProduto.Margem = CDbl(MargemTxt.Text)
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
        Me.Close()
    End Sub

    Private Sub wdCadProduto_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles Me.PreviewKeyDown
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

    Private Sub DataTxt_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles DataTxt.PreviewKeyDown
        If e.Key = Key.Return Or e.Key = Key.Tab Then
            GrupoTxt.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub wdCadProduto_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If passou = False Then
            Me.Show()

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
End Class

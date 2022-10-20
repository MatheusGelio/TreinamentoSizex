Public Class wdCadProduto
    Dim objProduto As Produto
    Dim srcProduto As CollectionViewSource
    Dim lstProduto As List(Of Produto)
    Dim passou As Boolean = False

#Region "Métodos"
    Private Sub LimparCampos()
        CodigoTxt.Clear()
        DescricaoTxt.Clear()
        DataTxt.Text = Nothing
        SimRdb.IsChecked = True
        GrupoTxt.Clear()
        TipoTxt.Text = Nothing
        CustoTxt.Clear()
        MargemTxt.Clear()
        PrecoTxt.Clear()
        InativoChk.IsChecked = False
        objProduto = Nothing
    End Sub

    Private Function SalvarProduto(Optional ByRef retorno As String = "") As Boolean
        retorno = "1 - Validando Campos."
        If CodigoTxt.Text = Nothing Then
            MsgBox("Para salvar um produto, é necessário preencher o campo de CÓDIGO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            CodigoTxt.Focus()
            Return False
            Exit Function
        ElseIf DescricaoTxt.Text = Nothing Then
            MsgBox("Para salvar um produto, é necessário preencher o campo de DESCRIÇÃO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            DescricaoTxt.Focus()
            Return False
            Exit Function
        ElseIf Not IsDate(DataTxt.Text) Then
            MsgBox("Para salvar um produto, é necessário preencher o campo de DATA DE CADASTRO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            DataTxt.Focus()
            Return False
            Exit Function
        ElseIf TipoTxt.Text = Nothing Then
            MsgBox("Para salvar um produto, é necessário preencher o campo de TIPO DE PRODUTO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            TipoTxt.Focus()
            Return False
            Exit Function
        ElseIf PrecoTxt.Text = Nothing Then
            MsgBox("Para salvar um produto, é necessário preencher o campo de PREÇO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            PrecoTxt.Focus()
            Return False
            Exit Function
        End If

        retorno = "2 - Inserindo Objeto."
        If objProduto Is Nothing Then
            objProduto = New Produto
            lstProduto.Add(objProduto)
        End If

        retorno = "3 - Salvando Campos do Produto."
        objProduto.Codigo = CodigoTxt.Text
        objProduto.Descricao = DescricaoTxt.Text
        objProduto.DataCadastro = DataTxt.Text
        If SimRdb.IsChecked Then
            objProduto.Estoque = True
        Else
            objProduto.Estoque = False
        End If
        objProduto.Grupo = GrupoTxt.Text
        objProduto.TipoProduto = TipoTxt.Text
        objProduto.Custo = CustoTxt.Text
        objProduto.Margem = MargemTxt.Text
        objProduto.Preco = PrecoTxt.Text
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
        If objProduto Is Nothing Then
            MsgBox("Para excluir um produto, é necessário selecioná-lo antes, verifique!", MsgBoxStyle.Exclamation, "Excluir Produto")
            Exit Sub
        End If

        lstProduto.Remove(objProduto)
        srcProduto.Source = lstProduto.ToList

        MsgBox("Produto excluído com sucesso!", MsgBoxStyle.Information, "Parabéns!")

        LimparCampos()
    End Sub

    Private Sub SairBtn_Click(sender As Object, e As RoutedEventArgs) Handles SairBtn.Click
        Me.Close()
    End Sub

    Private Sub wdCadProduto_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            Me.Show()
            Dim lista As New List(Of String)
            lista.Add("ACABADO")
            lista.Add("EMBALAGEM")
            lista.Add("INSUMO")
            lista.Add("MATERIA PRIMA")

            TipoTxt.ItemsSource = lista.ToList

            lstProduto = New List(Of Produto)

            srcProduto = CType(Me.FindResource("ProdutoViewSource"), CollectionViewSource)

            DataTxt.Text = Date.Today

            passou = True
        End If
    End Sub

    Private Sub ProdutoDataGrid_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles ProdutoDataGrid.MouseDoubleClick
        If sender.selectedItem IsNot Nothing Then
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
            TipoTxt.Text = objProduto.TipoProduto
            CustoTxt.Text = objProduto.Custo
            MargemTxt.Text = objProduto.Margem
            PrecoTxt.Text = objProduto.Preco
            InativoChk.IsChecked = objProduto.Inativo

            srcProduto.Source = lstProduto.ToList
        End If
    End Sub
End Class

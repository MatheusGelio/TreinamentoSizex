Public Class ucCadVenda
    Dim objVenda As Venda
    Dim objVendaRegistros As VendaRegistros
    Dim srcVenda As CollectionViewSource
    Dim srcVendaRegistros As CollectionViewSource
    Dim lstVenda As List(Of Venda)
    Dim passou As Boolean = False
    Dim totalProdutos As Double = 0
    Dim tipoPesquisa As String

#Region "Métodos"
    Private Sub LimparCampos(tipo As String)
        If tipo = "V" Or tipo = "T" Then
            TipoCmb.SelectedIndex = -1
            DataTxt.Text = Date.Today
            ClienteTxt.Text = ""
            VendedorTxt.Text = ""
            CenarioFiscalCmb.SelectedIndex = -1
            TotalItensTxt.Text = 0
            TotalProdutosTxt.Text = "0,00"
            DescontoTxt.Text = "0,00"
            FreteTxt.Text = "0,00"
            OutrasDesTxt.Text = "0,00"
            ImpostosTxt.Text = "0,00"
            TotalVendaTxt.Text = "0,00"
            objVenda = Nothing

            srcVendaRegistros.Source = Nothing
        End If

        If tipo = "R" Or tipo = "T" Then
            ProdutoTxt.Text = ""
            QuantidadeTxt.Text = 0
            ValorUniTxt.Text = "0,00"
            ValorTotalTxt.Text = "0,00"
            objVendaRegistros = Nothing
        End If
    End Sub

    Private Sub PreencherCamposVenda(sender As Object, e As MouseButtonEventArgs)
        objVenda = CType(sender.selectedItem, Venda)
        TipoCmb.Text = objVenda.Tipo
        DataTxt.Text = objVenda.Data
        'ClienteTxt.Text = objVenda.Cliente'
        VendedorTxt.Text = objVenda.Vendedor
        TotalItensTxt.Text = objVenda.TotalItens
        TotalProdutosTxt.Text = objVenda.TotalProdutos
        DescontoTxt.Text = objVenda.Desconto
        FreteTxt.Text = objVenda.Frete
        OutrasDesTxt.Text = objVenda.OutrasDes
        ImpostosTxt.Text = objVenda.Impostos
        TotalVendaTxt.Text = objVenda.TotalVenda

        srcVendaRegistros.Source = objVenda.VendaRegistros.ToList

        BottomTb.SelectedItem = VendaTb
        e.Handled = True
    End Sub

    Private Sub PreencherCamposVendaRegistros(sender As Object, e As MouseButtonEventArgs)
        objVendaRegistros = CType(sender.selectedItem, VendaRegistros)
        ProdutoTxt.Text = objVendaRegistros.ProdutoId
        QuantidadeTxt.Text = objVendaRegistros.Quantidade
        ValorUniTxt.Text = objVendaRegistros.ValorUni
    End Sub

    Private Sub CalcularValores(tipo As String)
        Dim valor As Double = 0
        If tipo = "Q" Or tipo = "U" Then
            If Cfg.RetornarValorPadrao(QuantidadeTxt.Text) > 0 And Cfg.RetornarValorPadrao(ValorUniTxt.Text) > 0 Then
                valor = CInt(QuantidadeTxt.Text) * CDbl(ValorUniTxt.Text)
                valor = Math.Round(valor, 2)
                ValorTotalTxt.Text = valor.ToString("##0.00")
            End If
        ElseIf tipo = "T" Then
            If Cfg.RetornarValorPadrao(QuantidadeTxt.Text) > 0 And Cfg.RetornarValorPadrao(ValorTotalTxt.Text) > 0 Then
                valor = CDbl(ValorTotalTxt.Text) / CInt(QuantidadeTxt.Text)
                valor = Math.Round(valor, 2)
                ValorUniTxt.Text = valor.ToString("##0.00")
            End If
        ElseIf tipo = "TV" Then
            valor = CDbl(TotalProdutosTxt.Text) - CDbl(DescontoTxt.Text) + CDbl(FreteTxt.Text) + CDbl(OutrasDesTxt.Text) + CDbl(ImpostosTxt.Text)
            valor = Math.Round(valor, 2)
            TotalVendaTxt.Text = valor.ToString("##0.00")
        End If
    End Sub

    Private Function SalvarVenda(Optional ByRef retorno As String = "") As Boolean
        retorno = "1 - Validando Campos."
        If TipoCmb.SelectedIndex < 0 Then
            MsgBox("Para salvar uma venda, é necessário preencher o campo de TIPO DE VENDA, verifique!", MsgBoxStyle.Exclamation, "Validação")
            TipoCmb.Focus()
            Return False
        ElseIf Not IsDate(DataTxt.Text) Then
            MsgBox("Para salvar uma venda, é necessário preencher o campo de DATA, verifique!", MsgBoxStyle.Exclamation, "Validação")
            DataTxt.Focus()
            Return False
        ElseIf ClienteTxt.Text = Nothing Then
            MsgBox("Para salvar uma venda, é necessário preencher o campo de CLIENTE, verifique!", MsgBoxStyle.Exclamation, "Validação")
            ClienteTxt.Focus()
            Return False
        ElseIf VendedorTxt.Text = Nothing Then
            MsgBox("Para salvar uma venda, é necessário preencher o campo de VENDEDOR, verifique!", MsgBoxStyle.Exclamation, "Validação")
            VendedorTxt.Focus()
            Return False
        ElseIf TotalVendaTxt.Text = Nothing Then
            MsgBox("Para salvar uma venda, é necessário preencher o campo de TOTAL DA VENDA, verifique!", MsgBoxStyle.Exclamation, "Validação")
            TotalVendaTxt.Focus()
            Return False
        End If

        retorno = "2 - Inserindo Objeto."
        If objVenda Is Nothing Then
            objVenda = New Venda
            lstVenda.Add(objVenda)
            objVenda.VendaRegistros = New List(Of VendaRegistros)
        End If

        retorno = "3 - Salvando Campos da Venda."
        objVenda.Tipo = TipoCmb.Text
        objVenda.Data = DataTxt.Text
        'objVenda.Cliente.Nome = UCase(ClienteTxt.Text)'
        objVenda.Vendedor = UCase(VendedorTxt.Text)
        objVenda.TotalItens = CInt(TotalItensTxt.Text)
        objVenda.TotalProdutos = CDbl(TotalProdutosTxt.Text)
        objVenda.Desconto = CDbl(DescontoTxt.Text)
        objVenda.Frete = CDbl(FreteTxt.Text)
        objVenda.OutrasDes = CDbl(OutrasDesTxt.Text)
        objVenda.Impostos = CDbl(ImpostosTxt.Text)
        objVenda.TotalVenda = CDbl(TotalVendaTxt.Text)

        retorno = "4 - Salvamento Concluído."
        Return True
    End Function
#End Region

    Private Sub ucCadVenda_LostFocus(sender As Object, e As RoutedEventArgs) Handles Me.LostFocus
        CalcularValores("TV")
    End Sub

    Private Sub ucCadVenda_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles Me.PreviewKeyDown
        Select Case e.Key
            Case Key.F2
                NovoBtn_Click(Nothing, Nothing)
            Case Key.F3
                SalvarBtn_Click(Nothing, Nothing)
            Case Key.F4
                CancelarBtn_Click(Nothing, Nothing)
            Case Key.Escape
                SairBtn_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub ucCadVenda_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If passou = False Then
            lstVenda = New List(Of Venda)
            srcVenda = CType(Me.FindResource("VendaViewSource"), CollectionViewSource)
            srcVendaRegistros = CType(Me.FindResource("VendaRegistrosViewSource"), CollectionViewSource)
            tipoPesquisa = "C"
            LimparCampos("T")
            passou = True
        End If
    End Sub

    Private Sub NovoBtn_Click(sender As Object, e As RoutedEventArgs) Handles NovoBtn.Click
        LimparCampos("T")
    End Sub

    Private Sub SalvarBtn_Click(sender As Object, e As RoutedEventArgs) Handles SalvarBtn.Click
        Dim retorno As String = ""
        Try
            If SalvarVenda(retorno) = False Then
                Exit Sub
            End If

            srcVenda.Source = lstVenda.ToList

            MsgBox("Venda salva com sucesso!", MsgBoxStyle.Information, "Parabéns!")
            LimparCampos("T")
            TipoCmb.Focus()
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Salvar Venda")
        End Try
    End Sub

    Private Sub CancelarBtn_Click(sender As Object, e As RoutedEventArgs) Handles CancelarBtn.Click
        Dim retorno As String = ""
        Try
            If objVenda Is Nothing Then
                MsgBox("Para cancelar uma venda, é necessário selecioná-la antes, verifique!", MsgBoxStyle.Exclamation, "Cancelar Venda")
                Exit Sub
            End If

            lstVenda.Remove(objVenda)
            srcVenda.Source = lstVenda.ToList

            MsgBox("Venda cancelada com sucesso!", MsgBoxStyle.Information, "Parabéns!")

            LimparCampos("V")
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Cancelar Venda")
        End Try
    End Sub

    Private Sub SairBtn_Click(sender As Object, e As RoutedEventArgs) Handles SairBtn.Click
        Cfg.DestruirTela(Me)
    End Sub

    Private Sub AdicionarBtn_Click(sender As Object, e As RoutedEventArgs) Handles AdicionarBtn.Click
        Dim retorno As String = ""
        Try
            If SalvarVenda(retorno) = False Then
                Exit Sub
            End If

            If ProdutoTxt.Text = Nothing Then
                MsgBox("Para adicionar um registro, é necessário preencher o campo de PRODUTO, verifique!", MsgBoxStyle.Exclamation, "Validação")
                ProdutoTxt.Focus()
                Exit Sub
            ElseIf QuantidadeTxt.Text = Nothing Then
                MsgBox("Para adicionar um registro, é necessário preencher o campo de QUANTIDADE, verifique!", MsgBoxStyle.Exclamation, "Validação")
                QuantidadeTxt.Focus()
                Exit Sub
            ElseIf ValorUniTxt.Text = Nothing Then
                MsgBox("Para adicionar um registro, é necessário preencher o campo de VALOR UNITÁRIO, verifique!", MsgBoxStyle.Exclamation, "Validação")
                ValorUniTxt.Focus()
                Exit Sub
            ElseIf ValorTotalTxt.Text = Nothing Then
                MsgBox("Para adicionar um registro, é necessário preencher o campo de VALOR TOTAL, verifique!", MsgBoxStyle.Exclamation, "Validação")
                ValorTotalTxt.Focus()
                Exit Sub
            End If

            If objVendaRegistros Is Nothing Then
                objVendaRegistros = New VendaRegistros
                objVenda.VendaRegistros.Add(objVendaRegistros)
            End If

            objVendaRegistros.ProdutoId = UCase(ProdutoTxt.Text)
            objVendaRegistros.Quantidade = CInt(QuantidadeTxt.Text)
            objVendaRegistros.ValorUni = CDbl(ValorUniTxt.Text)

            srcVendaRegistros.Source = objVenda.VendaRegistros.ToList

            Dim mensagem As String = "Venda salva com sucesso!" & vbNewLine & "Total de Registros: " & objVenda.VendaRegistros.Count

            TotalItensTxt.Text = objVenda.VendaRegistros.Count
            totalProdutos = totalProdutos + ValorTotalTxt.Text
            TotalProdutosTxt.Text = totalProdutos

            MsgBox(mensagem, MsgBoxStyle.Information, "Parabéns!")

            LimparCampos("R")
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Adicionar Registro")
        End Try
    End Sub

    Private Sub DeletarBtn_Click(sender As Object, e As RoutedEventArgs) Handles DeletarBtn.Click
        Dim retorno As String = ""
        Try
            If objVenda Is Nothing Then
                MsgBox("Para deletar um registro, é necessário selecioná-lo antes, verifique!", MsgBoxStyle.Exclamation, "Deletar Registro")
                Exit Sub
            End If

            If objVendaRegistros Is Nothing Then
                MsgBox("Para deletar um registro, é necessário selecioná-lo antes, verifique!", MsgBoxStyle.Exclamation, "Deletar Registro")
                Exit Sub
            End If

            totalProdutos = totalProdutos - ValorTotalTxt.Text

            objVenda.VendaRegistros.Remove(objVendaRegistros)
            srcVendaRegistros.Source = objVenda.VendaRegistros.ToList

            TotalItensTxt.Text = objVenda.VendaRegistros.Count
            TotalProdutosTxt.Text = totalProdutos

            MsgBox("Registro deletado com sucesso!", MsgBoxStyle.Information, "Parabéns!")

            LimparCampos("R")
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Deletar Registro")
        End Try
    End Sub

    Private Sub VendedorTxt_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles VendedorTxt.PreviewKeyDown
        If e.Key = Key.Return Or e.Key = Key.Tab Then
            CenarioFiscalCmb.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub VendaDataGrid_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles VendaDataGrid.MouseDoubleClick
        If sender.selectedItem IsNot Nothing Then
            PreencherCamposVenda(sender, e)
        End If
    End Sub

    Private Sub VendaRegistrosDataGrid_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles VendaRegistrosDataGrid.MouseDoubleClick
        If sender.selectedItem IsNot Nothing Then
            PreencherCamposVendaRegistros(sender, e)
        End If
    End Sub

    Private Sub QuantidadeTxt_LostFocus(sender As Object, e As RoutedEventArgs) Handles QuantidadeTxt.LostFocus
        CalcularValores("Q")
    End Sub

    Private Sub ValorUniTxt_LostFocus(sender As Object, e As RoutedEventArgs) Handles ValorUniTxt.LostFocus
        CalcularValores("U")
    End Sub

    Private Sub ValorTotalTxt_LostFocus(sender As Object, e As RoutedEventArgs) Handles ValorTotalTxt.LostFocus
        CalcularValores("T")
    End Sub
    
    Private Sub PesquisarProdutoTxt_TextChanged(sender As Object, e As TextChangedEventArgs) Handles PesquisarProdutoTxt.TextChanged
        srcVendaRegistros.Source = objVenda.VendaRegistros.Where(Function(p) p.Produto.Descricao.Contains(PesquisarProdutoTxt.Text)).ToList
    End Sub

    Private Sub PesquisarVendaTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles PesquisarVendaTxt.KeyDown
        If e.Key = Key.F6 Then
            If tipoPesquisa = "C" Then
                PesquisarVendaLbl.Content = "[F6] Pesquisar por: Vendedor"
                tipoPesquisa = "V"
            ElseIf tipoPesquisa = "V" Then
                PesquisarVendaLbl.Content = "[F6] Pesquisar por: Cliente"
                tipoPesquisa = "C"
            End If
        End If
    End Sub

    Private Sub PesquisarVendaTxt_TextChanged(sender As Object, e As TextChangedEventArgs) Handles PesquisarVendaTxt.TextChanged
        If lstVenda.Count > 0 Then
            If tipoPesquisa = "C" Then
                'srcVenda.Source = lstVenda.Where(Function(p) p.Cliente.Nome.Contains(PesquisarVendaTxt.Text)).ToList'
            ElseIf tipoPesquisa = "V" Then
                srcVenda.Source = lstVenda.Where(Function(p) p.Vendedor.Contains(PesquisarVendaTxt.Text)).ToList
            End If
        End If
    End Sub
End Class

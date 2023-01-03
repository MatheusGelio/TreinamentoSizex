Public Class ucCadVenda
    Dim objVenda As Venda
    Dim objVendaRegistros As VendaRegistros
    Dim srcVenda As CollectionViewSource
    Dim srcVendaRegistros As CollectionViewSource
    Dim lstVenda As List(Of Venda)
    Dim passou As Boolean = False

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
        End If

        If tipo = "R" Or tipo = "T" Then
            ProdutoTxt.Text = ""
            QuantidadeTxt.Text = 0
            ValorUniTxt.Text = "0,00"
            ValorTotalTxt.Text = "0,00"
        End If
    End Sub

    Private Sub PreencherCamposVenda(sender As Object, e As MouseButtonEventArgs)
        objVenda = CType(sender.selectedItem, Venda)
        TipoCmb.Text = objVenda.TipoVenda
        DataTxt.Text = objVenda.Data
        ClienteTxt.Text = objVenda.Cliente
        VendedorTxt.Text = objVenda.Vendedor
        CenarioFiscalCmb.Text = objVenda.CenarioFiscal
        TotalItensTxt.Text = objVenda.TotalItens
        TotalProdutosTxt.Text = objVenda.TotalProdutos
        DescontoTxt.Text = objVenda.Desconto
        FreteTxt.Text = objVenda.Frete
        OutrasDesTxt.Text = objVenda.OutrasDes
        ImpostosTxt.Text = objVenda.Impostos
        TotalVendaTxt.Text = objVenda.TotalVenda

        'srcVendaRegistros.Source = objVenda.Registros.ToList'

        BottomTb.SelectedItem = VendaTb
        e.Handled = True
    End Sub

    Private Sub PreencherCamposVendaRegistros(sender As Object, e As MouseButtonEventArgs)
        objVendaRegistros = CType(sender.selectedItem, VendaRegistros)
        ProdutoTxt.Text = objVendaRegistros.Produto
        QuantidadeTxt.Text = objVendaRegistros.Quantidade
        ValorUniTxt.Text = objVendaRegistros.ValorUni
        ValorTotalTxt.Text = objVendaRegistros.ValorTotal
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
        End If

        retorno = "3 - Salvando Campos da Venda."
        objVenda.TipoVenda = TipoCmb.Text
        objVenda.Data = DataTxt.Text
        objVenda.Cliente = UCase(ClienteTxt.Text)
        objVenda.Vendedor = UCase(VendedorTxt.Text)
        objVenda.CenarioFiscal = CenarioFiscalCmb.Text
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
                objVenda.Registros.Add(objVendaRegistros)
            End If

            objVendaRegistros.Produto = UCase(ProdutoTxt.Text)
            objVendaRegistros.Quantidade = CInt(QuantidadeTxt.Text)
            objVendaRegistros.ValorUni = CDbl(ValorUniTxt.Text)
            objVendaRegistros.ValorTotal = CDbl(ValorTotalTxt.Text)

            srcVendaRegistros.Source = objVenda.Registros.ToList

            Dim mensagem As String = "Venda salva com sucesso!" & vbNewLine & "Total de Registros: " & objVenda.Registros.Count

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

            objVenda.Registros.Remove(objVendaRegistros)
            srcVendaRegistros.Source = objVenda.Registros.ToList

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

    Private Sub NomeClienteTxt_TextChanged(sender As Object, e As TextChangedEventArgs) Handles NomeClienteTxt.TextChanged
        srcVenda.Source = lstVenda.Where(Function(p) p.Cliente.Contains(NomeClienteTxt.Text)).ToList
    End Sub

    Private Sub NomeVendedorTxt_TextChanged(sender As Object, e As TextChangedEventArgs) Handles NomeVendedorTxt.TextChanged
        srcVenda.Source = lstVenda.Where(Function(p) p.Vendedor.Contains(NomeVendedorTxt.Text)).ToList
    End Sub
End Class

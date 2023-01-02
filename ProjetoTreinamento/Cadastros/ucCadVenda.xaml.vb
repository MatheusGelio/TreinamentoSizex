Public Class ucCadVenda
    Dim objVenda As Venda
    Dim srcVenda As CollectionViewSource
    Dim lstVenda As List(Of Venda)
    Dim passou As Boolean = False

#Region "Métodos"
    Private Sub LimparCampos()
        TipoCmb.SelectedIndex = -1
        DataTxt.Text = Date.Today
        ClienteTxt.Text = ""
        VendedorTxt.Text = ""
        CenarioFiscalCmb.SelectedIndex = -1
        QuantidadeTxt.Text = 0
        ValorUniTxt.Text = "0,00"
        ValorTotalTxt.Text = "0,00"
        TotalItensTxt.Text = 0
        TotalProdutosTxt.Text = "0,00"
        DescontoTxt.Text = "0,00"
        FreteTxt.Text = "0,00"
        OutrasDesTxt.Text = "0,00"
        ImpostosTxt.Text = "0,00"
        TotalVendaTxt.Text = "0,00"
        objVenda = Nothing
    End Sub

    Private Function SalvarVenda(Optional ByRef retorno As String = "") As Boolean
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
            LimparCampos()
            passou = True
        End If
    End Sub

    Private Sub NovoBtn_Click(sender As Object, e As RoutedEventArgs) Handles NovoBtn.Click
        LimparCampos()
    End Sub

    Private Sub SalvarBtn_Click(sender As Object, e As RoutedEventArgs) Handles SalvarBtn.Click

    End Sub

    Private Sub CancelarBtn_Click(sender As Object, e As RoutedEventArgs) Handles CancelarBtn.Click

    End Sub

    Private Sub SairBtn_Click(sender As Object, e As RoutedEventArgs) Handles SairBtn.Click
        Cfg.DestruirTela(Me)
    End Sub

    Private Sub VendedorTxt_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles VendedorTxt.PreviewKeyDown
        If e.Key = Key.Return Or e.Key = Key.Tab Then
            CenarioFiscalCmb.Focus()
            e.Handled = True
        End If
    End Sub
End Class

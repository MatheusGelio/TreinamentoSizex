Public Class ucCadTitulo
    Dim objTitulo As Titulo
    Dim srcTitulo As CollectionViewSource
    Dim lstTitulo As List(Of Titulo)
    Dim passou = False
    Dim ctx As SizexConnectionEntities

#Region "Métodos"
    Private Sub LimparCampos()
        Try
            TipoCmb.SelectedIndex = -1
            PessoaTxt.Text = ""
            ResultadoTxt.Text = ""
            VencimentoParcTxt.Text = Date.Today
            ParcelasTxt.Text = "1"
            DiaProxParcTxt.Text = "1"
            ValorTxt.Text = "0,00"
            DescontoTxt.Text = "0,00"
            JurosTxt.Text = "0,00"
            MultaTxt.Text = "0,00"
            DocumentoTxt.Text = ""
            FormaPgmtCmb.SelectedIndex = -1
            ObsTxt.Text = ""
            FormaDePgmtCmb.SelectedIndex = -1
            VencimentoTxt.Text = ""
            ValorParcTxt.Text = ""
            objTitulo = Nothing
        Catch ex As Exception
            MsgBox("Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Limpar Campos")
        End Try
    End Sub

    Private Sub PreencherCampos()
        Try
            If objTitulo IsNot Nothing Then
                TipoCmb.Text = objTitulo.Tipo.ToString
                PessoaTxt.Text = objTitulo.Pessoa
                ResultadoTxt.Text = objTitulo.Resultado
                VencimentoParcTxt.Text = objTitulo.VencimentoParc
                ParcelasTxt.Text = objTitulo.Parcelas
                DiaProxParcTxt.Text = objTitulo.DiaProxParc
                ValorTxt.Text = objTitulo.Valor
                DescontoTxt.Text = objTitulo.Desconto
                JurosTxt.Text = objTitulo.Juros
                MultaTxt.Text = objTitulo.Multa
                DocumentoTxt.Text = objTitulo.Documento
                FormaPgmtCmb.Text = objTitulo.FormaPgmt
                ObsTxt.Text = objTitulo.Obs
                FormaDePgmtCmb.Text = objTitulo.FormaPgmt
                VencimentoTxt.Text = objTitulo.VencimentoParc
                ValorParcTxt.Text = objTitulo.Valor
            End If
            PessoaTxt.ItemsSource = ctx.Titulo.Select(Function(p) p.Pessoa).Distinct.ToList
            ResultadoTxt.ItemsSource = ctx.Titulo.Select(Function(r) r.Resultado).Distinct.ToList
            srcTitulo.Source = ctx.Titulo.ToList
        Catch ex As Exception
            MsgBox("Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Preencher Campos")
        End Try
    End Sub

    Private Function SalvarTitulo(Optional ByRef retorno As String = "", Optional ByRef tipo As String = "") As Boolean
        retorno = "1 - Validando Campos."
        If TipoCmb.SelectedItem Is Nothing Then
            MsgBox("Para salvar um título, é necessário preencher o campo de TIPO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            TipoCmb.Focus()
            Return False
        ElseIf PessoaTxt.Text = Nothing Then
            MsgBox("Para salvar um título, é necessário preencher o campo de PESSOA (RESPONSÁVEL OU FORNECEDOR), verifique!", MsgBoxStyle.Exclamation, "Validação")
            PessoaTxt.Focus()
            Return False
        ElseIf Not IsDate(VencimentoParcTxt.Text) Then
            MsgBox("Para salvar um título, é necessário preencher o campo de VENCIMENTO 1º PARC., verifique!", MsgBoxStyle.Exclamation, "Validação")
            VencimentoParcTxt.Focus()
            Return False
        ElseIf ValorTxt.Text = Nothing Then
            MsgBox("Para salvar um título, é necessário preencher o campo de VALOR, verifique!", MsgBoxStyle.Exclamation, "Validação")
            ValorTxt.Focus()
            Return False
        ElseIf DocumentoTxt.Text = Nothing Then
            MsgBox("Para salvar um título, é necessário preencher o campo de DOCUMENTO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            DocumentoTxt.Focus()
            Return False
        ElseIf FormaPgmtCmb.SelectedItem Is Nothing Then
            MsgBox("Para salvar um título, é necessário preencher o campo de FORMA DE PAGAMENTO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            FormaPgmtCmb.Focus()
            Return False
        End If

        retorno = "2 - Inserindo Objeto."
        If objTitulo Is Nothing Or tipo = "C" Then
            objTitulo = New Titulo
            ctx.Titulo.Add(objTitulo)
        End If

        retorno = "3 - Salvando Campos do Produto."
        objTitulo.Tipo = CStr(TipoCmb.Text)
        objTitulo.Pessoa = UCase(PessoaTxt.Text)
        objTitulo.Resultado = UCase(ResultadoTxt.Text)
        objTitulo.VencimentoParc = VencimentoParcTxt.Text
        objTitulo.Parcelas = CInt(ParcelasTxt.Text)
        objTitulo.DiaProxParc = CInt(DiaProxParcTxt.Text)
        objTitulo.Valor = CDbl(ValorTxt.Text)
        objTitulo.Desconto = CDbl(DescontoTxt.Text)
        objTitulo.Juros = CDbl(JurosTxt.Text)
        objTitulo.Multa = CDbl(MultaTxt.Text)
        objTitulo.Documento = UCase(DocumentoTxt.Text)
        objTitulo.FormaPgmt = FormaPgmtCmb.Text
        objTitulo.Obs = UCase(ObsTxt.Text)

        ctx.SaveChanges()

        retorno = "4 - Salvamento Concluído."
        Return True
    End Function
#End Region

    Private Sub CalcularBtn_Click(sender As Object, e As RoutedEventArgs) Handles CalcularBtn.Click
        Dim retorno As String = ""
        Try
            For i As Integer = 1 To ParcelasTxt.Text
                If SalvarTitulo(retorno, "C") = False Then
                    Exit Sub
                End If
                objTitulo.Parcelas = i
                objTitulo.VencimentoParc = Date.Parse(objTitulo.VencimentoParc).AddMonths(i - 1)
            Next

            CalcularBtn.Visibility = Windows.Visibility.Hidden
            GerarBtn.Visibility = Windows.Visibility.Visible

            MsgBox("Título salvo com sucesso!", MsgBoxStyle.Information, "Parabéns!")
            LimparCampos()
            PreencherCampos()
            TipoCmb.Focus()
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Calcular Título")
        End Try
    End Sub

    Private Sub GerarBtn_Click(sender As Object, e As RoutedEventArgs) Handles GerarBtn.Click
        Dim retorno As String = ""
        Try
            If ctx.Titulo.ToList.Count < 1 Then
                Exit Sub
            End If

            If MsgBox("Você deseja excluir o título selecionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Excluir Título") = MsgBoxResult.Yes Then
                ctx.Titulo.Remove(objTitulo)
                ctx.SaveChanges()

                MsgBox("Título gerado com sucesso!", MsgBoxStyle.Information, "Parabéns!")

                CalcularBtn.Visibility = Windows.Visibility.Visible
                GerarBtn.Visibility = Windows.Visibility.Hidden

                LimparCampos()
                PreencherCampos()
            End If
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Gerar Título")
        End Try
    End Sub

    Private Sub DesfazerBtn_Click(sender As Object, e As RoutedEventArgs) Handles DesfazerBtn.Click
        LimparCampos()
    End Sub

    Private Sub SairBtn_Click(sender As Object, e As RoutedEventArgs) Handles SairBtn.Click
        Cfg.DestruirTela(Me)
    End Sub

    Private Sub ucCadTitulo_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles Me.PreviewKeyDown
        Select Case e.Key
            Case Key.Escape
                SairBtn_Click(Nothing, Nothing)
            Case Key.F5
                CalcularBtn_Click(Nothing, Nothing)
            Case Key.F6
                GerarBtn_Click(Nothing, Nothing)
            Case Key.F7
                DesfazerBtn_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub ucCadTitulo_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If passou = False Then
            ctx = New SizexConnectionEntities
            lstTitulo = New List(Of Titulo)
            srcTitulo = CType(Me.FindResource("TituloViewSource"), CollectionViewSource)
            LimparCampos()
            PreencherCampos()
            TipoCmb.Focus()
            GerarBtn.Visibility = Windows.Visibility.Hidden
            passou = True
        End If
    End Sub

    Private Sub TituloDataGrid_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles TituloDataGrid.MouseDoubleClick
        If sender.selectedItem IsNot Nothing Then
            objTitulo = CType(sender.selectedItem, Titulo)
            PreencherCampos()
        End If
    End Sub

    Private Sub ResultadoTxt_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles ResultadoTxt.PreviewKeyDown
        If e.Key = Key.Return Or e.Key = Key.Tab Then
            VencimentoParcTxt.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub VencimentoParcTxt_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles VencimentoParcTxt.PreviewKeyDown
        If e.Key = Key.Return Or e.Key = Key.Tab Then
            ParcelasTxt.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub FormaPgmtCmb_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles FormaPgmtCmb.PreviewKeyDown
        If e.Key = Key.Return Or e.Key = Key.Tab Then
            ObsTxt.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub VencimentoTxt_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles VencimentoTxt.PreviewKeyDown
        If e.Key = Key.Return Or e.Key = Key.Tab Then
            ValorParcTxt.Focus()
            e.Handled = True
        End If
    End Sub
End Class

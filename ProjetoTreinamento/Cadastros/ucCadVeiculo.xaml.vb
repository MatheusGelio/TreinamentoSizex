Public Class ucCadVeiculo
    Dim objVeiculo As Veiculo
    Dim objVeiculoRegistros As VeiculoRegistros
    Dim passou As Boolean = False
    Dim srcVeiculo As CollectionViewSource
    Dim srcVeiculoRegistros As CollectionViewSource
    Dim lstVeiculo As List(Of Veiculo)
    Dim tipoPesquisa As String

#Region "Métodos"
    Private Sub LimparCampos(tipo As String)
        If tipo = "V" Or tipo = "T" Then
            PlacaTxt.Text = ""
            DescricaoTxt.Text = ""
            CombustivelTxt.SelectedItem = ""
            KmTxt.Text = "0"
            ValorTxt.Text = "0,00"
            DataTxt.Text = Date.Today
            objVeiculo = Nothing

            srcVeiculoRegistros.Source = Nothing
        End If

        If tipo = "RT" Or tipo = "T" Then
            DataAbastTxt.Text = Nothing
            KmAbastTxt.Text = "0"
            LitrosTxt.Text = "0,00"
            TotalTxt.Text = "0,00"
            objVeiculoRegistros = Nothing
        End If
    End Sub

    Private Sub PreencherCamposVeiculo(sender As Object, e As MouseButtonEventArgs)
        objVeiculo = CType(sender.selectedItem, Veiculo)
        PlacaTxt.Text = objVeiculo.Placa
        DescricaoTxt.Text = objVeiculo.DescricaoVeiculo
        CombustivelTxt.Text = objVeiculo.Combustivel
        KmTxt.Text = objVeiculo.UltimoKm
        ValorTxt.Text = objVeiculo.ValorCompra
        DataTxt.Text = objVeiculo.DataAquisicao

        srcVeiculoRegistros.Source = objVeiculo.Registros.ToList

        PrincipalTb.SelectedItem = CadTb
        e.Handled = True
    End Sub

    Private Sub PreencherCamposVeiculoRegistros(sender As Object, e As MouseButtonEventArgs)
        objVeiculoRegistros = CType(sender.selectedItem, VeiculoRegistros)
        DataAbastTxt.Text = objVeiculoRegistros.DataAbast
        KmAbastTxt.Text = objVeiculoRegistros.KmAbast
        LitrosTxt.Text = objVeiculoRegistros.Litros
        TotalTxt.Text = objVeiculoRegistros.ValorTotal
    End Sub

    Private Function SalvarVeiculo(Optional ByRef retorno As String = "") As Boolean
        retorno = "1 - Validando Campos."
        If PlacaTxt.Text = Nothing Then
            MsgBox("Para salvar um veículo, é necessário preencher o campo de PLACA, verifique!", MsgBoxStyle.Exclamation, "Validação")
            PlacaTxt.Focus()
            Return False
        ElseIf DescricaoTxt.Text = Nothing Then
            MsgBox("Para salvar um veículo, é necessário preencher o campo de DESCRIÇÃO, verifique!", MsgBoxStyle.Exclamation, "Validação")
            DescricaoTxt.Focus()
            Return False
        ElseIf CombustivelTxt.Text = Nothing Then
            MsgBox("Para salvar um veículo, é necessário preencher o campo de COMBUSTÍVEL, verifique!", MsgBoxStyle.Exclamation, "Validação")
            CombustivelTxt.Focus()
            Return False
        ElseIf KmTxt.Text = Nothing Then
            MsgBox("Para salvar um veículo, é necessário preencher o campo de ÚLTIMO KM, verifique!", MsgBoxStyle.Exclamation, "Validação")
            KmTxt.Focus()
            Return False
        End If

        retorno = "2 - Inserindo Objeto."
        If objVeiculo Is Nothing Then
            objVeiculo = New Veiculo
            lstVeiculo.Add(objVeiculo)
            objVeiculo.Registros = New List(Of VeiculoRegistros)
        End If

        retorno = "3 - Salvando Campos do Veículo."
        objVeiculo.Placa = UCase(PlacaTxt.Text)
        objVeiculo.DescricaoVeiculo = UCase(DescricaoTxt.Text)
        objVeiculo.Combustivel = UCase(CombustivelTxt.Text)
        objVeiculo.UltimoKm = CInt(KmTxt.Text)
        objVeiculo.ValorCompra = CDbl(ValorTxt.Text)
        objVeiculo.DataAquisicao = DataTxt.Text

        objVeiculo.Usuario = InputBox("Informe o seu nome para gravar um veículo", "Auditoria", "")
        objVeiculo.DataGravacao = Date.Now

        retorno = "4 - Salvamento Concluído."

        CombustivelTxt.ItemsSource = lstVeiculo.Select(Function(p) p.Combustivel).Distinct.ToList
        Return True
    End Function
#End Region

    Private Sub ucCadVeiculo_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles Me.PreviewKeyDown
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

    Private Sub ucCadVeiculo_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If passou = False Then
            lstVeiculo = New List(Of Veiculo)
            srcVeiculo = CType(Me.FindResource("VeiculoViewSource"), CollectionViewSource)
            srcVeiculoRegistros = CType(Me.FindResource("VeiculoRegistrosViewSource"), CollectionViewSource)
            LimparCampos("T")
            tipoPesquisa = "D"
            passou = True
        End If
    End Sub

    Private Sub AdicionarBtn_Click(sender As Object, e As RoutedEventArgs) Handles AdicionarBtn.Click
        Dim retorno As String = ""
        Try
            If SalvarVeiculo(retorno) = False Then
                Exit Sub
            End If

            If Not IsDate(DataAbastTxt.Text) Then
                MsgBox("Para incluir um registro, é necessário preencher o campo de DATA, verifique!", MsgBoxStyle.Exclamation, "Validação")
                DataTxt.Focus()
                Exit Sub
            ElseIf KmAbastTxt.Text = Nothing Then
                MsgBox("Para incluir um registro, é necessário preencher o campo de KM, verifique!", MsgBoxStyle.Exclamation, "Validação")
                KmAbastTxt.Focus()
                Exit Sub
            ElseIf LitrosTxt.Text = Nothing Then
                MsgBox("Para incluir um registro, é necessário preencher o campo de LITROS, verifique!", MsgBoxStyle.Exclamation, "Validação")
                LitrosTxt.Focus()
                Exit Sub
            ElseIf TotalTxt.Text = Nothing Then
                MsgBox("Para incluir um registro, é necessário preencher o campo de VALOR TOTAL, verifique!", MsgBoxStyle.Exclamation, "Validação")
                TotalTxt.Focus()
                Exit Sub
            End If

            If objVeiculoRegistros Is Nothing Then
                objVeiculoRegistros = New VeiculoRegistros
                objVeiculo.Registros.Add(objVeiculoRegistros)
            End If

            objVeiculoRegistros.DataAbast = DataAbastTxt.Text
            objVeiculoRegistros.KmAbast = KmAbastTxt.Text
            objVeiculoRegistros.Litros = LitrosTxt.Text
            objVeiculoRegistros.ValorTotal = TotalTxt.Text

            srcVeiculoRegistros.Source = objVeiculo.Registros.ToList

            Dim mensagem As String = "Veículo salvo com sucesso!" & vbNewLine & "Total de Registros: " & objVeiculo.Registros.Count

            MsgBox(mensagem, MsgBoxStyle.Information, "Parabéns!")

            LimparCampos("RT")
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Adicionar Registro")
        End Try
    End Sub

    Private Sub DeletarBtn_Click(sender As Object, e As RoutedEventArgs) Handles DeletarBtn.Click
        Dim retorno As String = ""
        Try
            If objVeiculo Is Nothing Then
                MsgBox("Para deletar um registro, é necessário selecioná-lo antes, verifique!", MsgBoxStyle.Exclamation, "Deletar Registro")
                Exit Sub
            End If

            If objVeiculoRegistros Is Nothing Then
                MsgBox("Para deletar um registro, é necessário selecioná-lo antes, verifique!", MsgBoxStyle.Exclamation, "Deletar Registro")
                Exit Sub
            End If

            objVeiculo.Registros.Remove(objVeiculoRegistros)
            srcVeiculoRegistros.Source = objVeiculo.Registros.ToList

            MsgBox("Registro deletado com sucesso!", MsgBoxStyle.Information, "Parabéns!")

            LimparCampos("RT")
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Deletar Registro")
        End Try
    End Sub

    Private Sub SalvarBtn_Click(sender As Object, e As RoutedEventArgs) Handles SalvarBtn.Click
        Dim retorno As String = ""
        Try
            If SalvarVeiculo(retorno) = False Then
                Exit Sub
            End If

            srcVeiculo.Source = lstVeiculo.ToList

            MsgBox("Veículo salvo com sucesso!", MsgBoxStyle.Information, "Parabéns!")
            LimparCampos("T")
            PlacaTxt.Focus()
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Salvar Veículo")
        End Try
    End Sub

    Private Sub NovoBtn_Click(sender As Object, e As RoutedEventArgs) Handles NovoBtn.Click
        LimparCampos("T")
    End Sub

    Private Sub ExcluirBtn_Click(sender As Object, e As RoutedEventArgs) Handles ExcluirBtn.Click
        Dim retorno As String = ""
        Try
            If objVeiculo Is Nothing Then
                MsgBox("Para excluir um veículo, é necessário selecioná-lo antes, verifique!", MsgBoxStyle.Exclamation, "Excluir Veículo")
                Exit Sub
            End If

            lstVeiculo.Remove(objVeiculo)
            srcVeiculo.Source = lstVeiculo.ToList

            MsgBox("Veículo excluído com sucesso!", MsgBoxStyle.Information, "Parabéns!")

            LimparCampos("V")
        Catch ex As Exception
            MsgBox(retorno & vbNewLine & "Ocorreu um erro no sistema, entre em contato com a SIZEX!" & vbNewLine & "(" & ex.Message & ")", MsgBoxStyle.Critical, "Excluir Veículo")
        End Try
    End Sub

    Private Sub SairBtn_Click(sender As Object, e As RoutedEventArgs) Handles SairBtn.Click

    End Sub

    Private Sub VeiculoDataGrid_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles VeiculoDataGrid.MouseDoubleClick
        If sender.selectedItem IsNot Nothing Then
            PreencherCamposVeiculo(sender, e)
        End If
    End Sub

    Private Sub VeiculoRegistrosDataGrid_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles VeiculoRegistrosDataGrid.MouseDoubleClick
        If sender.selectedItem IsNot Nothing Then
            PreencherCamposVeiculoRegistros(sender, e)
        End If
    End Sub

    Private Sub DescricaoTxt_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles DescricaoTxt.PreviewKeyDown
        If e.Key = Key.Return Or e.Key = Key.Tab Then
            CombustivelTxt.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub DataTxt_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles DataTxt.PreviewKeyDown
        If e.Key = Key.Return Or e.Key = Key.Tab Then
            DataAbastTxt.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub DataAbastTxt_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles DataAbastTxt.PreviewKeyDown
        If e.Key = Key.Return Or e.Key = Key.Tab Then
            KmAbastTxt.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub PesquisarTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles PesquisarTxt.KeyDown
        If e.Key = Key.F6 Then
            If tipoPesquisa = "D" Then
                PesquisarLbl.Content = "[F6] Pesquisar por: Placa"
                tipoPesquisa = "P"
            ElseIf tipoPesquisa = "P" Then
                PesquisarLbl.Content = "[F6] Pesquisar por: Combustível"
                tipoPesquisa = "C"
            ElseIf tipoPesquisa = "C" Then
                PesquisarLbl.Content = "[F6] Pesquisar por: Descrição do Veículo"
                tipoPesquisa = "D"
            End If
        End If
    End Sub

    Private Sub PesquisarTxt_TextChanged(sender As Object, e As TextChangedEventArgs) Handles PesquisarTxt.TextChanged
        If lstVeiculo.Count > 0 Then
            If tipoPesquisa = "D" Then
                srcVeiculo.Source = lstVeiculo.Where(Function(p) p.DescricaoVeiculo.Contains(PesquisarTxt.Text)).ToList
            ElseIf tipoPesquisa = "P" Then
                srcVeiculo.Source = lstVeiculo.Where(Function(p) p.Placa.Contains(PesquisarTxt.Text)).ToList
            ElseIf tipoPesquisa = "C" Then
                srcVeiculo.Source = lstVeiculo.Where(Function(p) p.Combustivel.Contains(PesquisarTxt.Text)).ToList
            End If
        End If
    End Sub
End Class

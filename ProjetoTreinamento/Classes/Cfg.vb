Public Class Cfg
    Public Shared Function RetornarValorPadrao(valor As String) As Double
        If IsNumeric(valor) Then
            If CDbl(valor) > 0 Then
                Return CDbl(valor)
            End If
        End If
        Return 0
    End Function

    Public Shared Function FormatarCpf(valor As String) As String
        Dim valorAux As String = valor
        valorAux = Replace(Replace(valorAux, ".", ""), "-", "")
        If IsNumeric(valorAux) = True Then
            If Len(valorAux) = 11 Then
                Return Left(valorAux, 3) & "." & Mid(valorAux, 4, 3) & "." & Mid(valorAux, 7, 3) & "-" & Right(valorAux, 2)
            End If
        End If
        Return "CPF INVÁLIDO!"
    End Function

    Public Shared Function FormatarRg(valor As String) As String
        Dim valorAux As String = valor
        valorAux = Replace(Replace(valorAux, ".", ""), "-", "")
        If IsNumeric(valorAux) = True Then
            If Len(valorAux) = 9 Then
                Return Left(valorAux, 2) & "." & Mid(valorAux, 3, 3) & "." & Mid(valorAux, 6, 3) & "-" & Right(valorAux, 1)
            End If
        End If
        Return "RG INVÁLIDO!"
    End Function

    Public Shared Sub CarregarTela(menu As TabControl, uc As UserControl)
        'Dim tbItem As TabItem
        'For i As Integer = 0 To menu.Items.Count - 1
        '   tbItem = menu.Items(i)
        '   If tbItem.Header = uc.Tag Then
        '       menu.SelectedItem = tbItem
        '       Exit Sub
        '   End If
        'Next

        For Each tbItem As TabItem In menu.Items
            If tbItem.Header = uc.Tag Then
                menu.SelectedItem = tbItem
                Exit Sub
            End If
        Next

        Dim tb As New TabItem
        tb.Content = uc
        tb.Header = uc.Tag
        menu.Items.Add(tb)
        menu.SelectedItem = tb
    End Sub

    Public Shared Sub DestruirTela(uc As UserControl)
        Dim tbItem As TabItem = uc.Parent
        Dim menu As TabControl = tbItem.Parent
        menu.Items.Remove(tbItem)
    End Sub
End Class

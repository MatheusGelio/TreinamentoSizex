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
End Class

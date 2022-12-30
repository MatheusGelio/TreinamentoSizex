Public Class wdAcesso

    Private Sub SairBtn_Click(sender As Object, e As RoutedEventArgs) Handles SairBtn.Click
        Me.Close()
    End Sub

    Private Sub wdAcesso_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Key = Key.Escape Then
            Me.Close()
        ElseIf e.Key = Key.Enter Then
            EntrarBtn_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub EntrarBtn_Click(sender As Object, e As RoutedEventArgs) Handles EntrarBtn.Click
        If UsuarioTxt.Text = "" Then
            MsgBox("Usuário não informado, verifique!", MsgBoxStyle.Information, "Validação")
            UsuarioTxt.Focus()
            Exit Sub
        ElseIf SenhaTxt.Password = "" Then
            MsgBox("Senha não informada, verifique!", MsgBoxStyle.Information, "Validação")
            SenhaTxt.Focus()
            Exit Sub
        End If

        Dim senha As String = GetSetting("Treinamento", "Acesso", UCase(UsuarioTxt.Text), "")
        If senha = "" Then
            If MsgBox("Deseja cadastrar esse usuário?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Usuário") = MsgBoxResult.Yes Then
                senha = InputBox("Confirme sua senha digitando aqui.", "Senha", "")
                If senha = "" Then
                    MsgBox("Senha não cadastrada, verifique!", MsgBoxStyle.Information, "Atenção")
                    Exit Sub
                End If
                SaveSetting("Treinamento", "Acesso", UCase(UsuarioTxt.Text), senha)
                MsgBox("Usuário (" & UCase(UsuarioTxt.Text) & ") cadastrado com sucesso!", MsgBoxStyle.Information, "Parabéns!")
                UsuarioTxt.Text = UCase(UsuarioTxt.Text)
                SenhaTxt.Password = ""
                SenhaTxt.Focus()
            End If
        ElseIf senha = SenhaTxt.Password Then
            Dim wd As New MainWindow
            wd.Show()
            Me.Close()
        Else
            MsgBox("A senha digitada é inválida, verifique!", MsgBoxStyle.Exclamation, "Atenção")
        End If
    End Sub

    Private Sub wdAcesso_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        UsuarioTxt.Focus()
    End Sub
End Class

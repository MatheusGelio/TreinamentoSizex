﻿Public Class Cliente
    Public Property Cpf As String
    Public Property Rg As String
    Public Property DataCadastro As String
    Public Property Inativo As Boolean
    Public Property Nome As String
    Public Property Endereco As String
    Public Property Numero As String
    Public Property Complemento As String
    Public Property Bairro As String
    Public Property Cidade As String
    Public Property Estado As String
    Public Property Contatos As List(Of ClienteContatos)
End Class

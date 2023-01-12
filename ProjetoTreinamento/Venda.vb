'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Venda
    Public Property Id As Integer
    Public Property ClienteId As Nullable(Of Integer)
    Public Property Tipo As String
    Public Property Data As Nullable(Of Date)
    Public Property Vendedor As String
    Public Property TotalItens As Nullable(Of Integer)
    Public Property TotalProdutos As Nullable(Of Decimal)
    Public Property Desconto As Nullable(Of Decimal)
    Public Property Frete As Nullable(Of Decimal)
    Public Property OutrasDes As Nullable(Of Decimal)
    Public Property Impostos As Nullable(Of Decimal)
    Public Property TotalVenda As Nullable(Of Decimal)

    Public Overridable Property Titulo As ICollection(Of Titulo) = New HashSet(Of Titulo)
    Public Overridable Property VendaRegistros As ICollection(Of VendaRegistros) = New HashSet(Of VendaRegistros)

End Class
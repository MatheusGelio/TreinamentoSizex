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

Partial Public Class Veiculo
    Public Property Id As Integer
    Public Property Placa As String
    Public Property DescricaoVeiculo As String
    Public Property Combustivel As String
    Public Property UltimoKm As Nullable(Of Integer)
    Public Property ValorCompra As Nullable(Of Decimal)
    Public Property DataAquisicao As Nullable(Of Date)
    Public Property Usuario As String
    Public Property DataGravacao As Nullable(Of Date)

    Public Overridable Property VeiculoRegistros As ICollection(Of VeiculoRegistros) = New HashSet(Of VeiculoRegistros)

End Class

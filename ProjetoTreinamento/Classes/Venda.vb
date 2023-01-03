Public Class Venda
    Public Property TipoVenda As String
    Public Property Data As Date
    Public Property Cliente As String
    Public Property Vendedor As String
    Public Property CenarioFiscal As String
    Public Property TotalItens As Integer
    Public Property TotalProdutos As Double
    Public Property Desconto As Double
    Public Property Frete As Double
    Public Property OutrasDes As Double
    Public Property Impostos As String
    Public Property TotalVenda As Double
    Public Property Registros As List(Of VendaRegistros)
End Class

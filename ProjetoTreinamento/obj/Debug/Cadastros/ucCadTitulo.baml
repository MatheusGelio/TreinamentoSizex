   M S B A M L   `   `   `  ????D  @ctTextBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ctTextBox;assembly=ctTextBox	ctTextBox  5       ProjetoTreinamento$   ProjetoTreinamento.ucCadTitulo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @	ctTextBox*clr-namespace:ctTextBox;assembly=ctTextBox     5      
  ? Tag$  Títulos??5   7    ? 	Resources 5	         TituloViewSource ?? Source??%1   &	        ?? 5
   
    68   ?? *Titulo+5      .??5      ?   
background#???  6    ? RowDefinitions 5   
   ?? 5      $??40 ?6   ?? 5      $??* ?6   ?? 5      $??40 ?6   .+?5   
   ? $??0??6     title-primary#???  6   .+?5      ?? -   5         ??Name$ 	TituloLbl??5      $??Cadastro de Títulos??6'   $??Stretch=?6E   $??0,0,0,0q?6c   $
??Bold"?6t   $??22(?6?   $??Calibri)?6?   
???????6?   5      ? 5   
   $??1??6    5      ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    ?? 5      $??* ?6    .+?5      ? $??0??6    ? ColumnDefinitions 5      ?? 5       $	??150 ?6'   ?? 5!      $??* ?6'   ?? 5"      $??* ?6'   .+?5$      ? $??0??6   .+?5%      ?? -   5        $ TipoLbl??5%      $??Tipo:??6-    	 Label#??[ 6=      ctTextBox.ctComboBox  5&      -   5          Name$ TipoCmb??5&   +   $??5,23,0,0q?6<   $??0??6N   .@?5'      ?? $??PAGAR??6'   ?? 5(      $??RECEBER??6'   5)      5*      ? 5+      $??1??6   .+?5,      ?? -   5        $ 	PessoaLbl??5,      $*??$Pessoa (Responsável ou Fornecedor):??6/   #??[ 6]      ctTextBox.ctAutoComplete  5-      -   5          Name$ 	PessoaTxt??5-   /     AutoBox#??[ 6B   $??1??6c      ExibirBorda .  6p   5.      ? 5/      $??2??6   .+?50      ?? -   5        $ ResultadoLbl??50      $??Centro de Resultados:??62   #??[ 6R     51      -   5        $ ResultadoTxt??51   /   #??[ 6E   $??5,23,5,0q?6f   $??2??6x    .  6?   52      53      ? 54      $??1??6    55      ?? 56      $??* ?6'   ?? 57      $??* ?6'   ?? 58      $??* ?6'   ?? 59      $??* ?6'   ?? 5:      $??* ?6'   ?? 5;      $??* ?6'   ?? 5<      $??* ?6'   .+?5>      ? $??0??6   .+?5?      ?? -   5        $ VencimentoParcLbl??5?      $??Venc. 1º Parc.:??67   #??[ 6Q   (  "System.Windows.Controls.DatePicker  5@      -	   5        	  Name$	 VencimentoParcTxt??5@   !   $??Stretch=?6<   $??5,23,0,0q?6Z   $??4??6l   ???	#FF4B4B4B
???   ?6?   5A      ? 5B      $??1??6   .+?5C      ?? -
   5        $ ParcelasLbl??5C      $??	Parcelas:??61   #??[ 6E      ctTextBox.ctTextInt  5D      -   5        $??ParcelasTxt??5D   *    
 IntBox#??[ 6=   
 ?? SelectionBrush#
 ?  6]   $??5??6?      ExibirBorda .  6?   5E      ? 5F      $??2??6   .+?5G      ?? -   5        $ DiaProxParcLbl??5G      $??Dia Próx. Parc.:??64   #??[ 6O     5H      -   5        $??DiaProxParcTxt??5H   *   #??[ 6@   #
 ?  6`   $??6??6?    .  6?   5I      ? 5J      $??3??6   .+?5K      ?? -   5        $ ValorLbl??5K      $??Valor:??6.   #??[ 6?      ctTextBox.ctDecimalBox  5L      -   5        $??ValorTxt??5L   -     
DecimalBox#??[ 6=   #
 ?  6a   $??7??6?      
NrDecimais$ 2??6?      ExibirBorda .  6?   5M      ? 5N      $??4??6   .+?5O      ?? -   5        $ DescontoLbl??5O      $??	Desconto:??61   #??[ 6E     5P      -   5        $??DescontoTxt??5P   -   #??[ 6@   #
 ?  6d   $??8??6?   $ 2??6?    .  6?   5Q      ? 5R      $??5??6   .+?5S      ?? -   5        $ JurosLbl??5S      $??Juros:??6.   #??[ 6?     5T      -   5        $??JurosTxt??5T   -   #??[ 6=   #
 ?  6a   $??9??6?   $ 2??6?    .  6?   5U      ? 5V      $??6??6   .+?5W      ?? -   5        $ MultaLbl??5W      $??Multa:??6.   #??[ 6?     5X      -   5        $??MultaTxt??5X   -   #??[ 6=   #
 ?  6a   $??5,23,5,0q?6?   $??10??6?   $ 2??6?    .  6?   5Y      5Z      ? 5[      $??2??6    5\      ?? 5]      $??34.328 ?6'   ?? 5^      $??165.672 ?6'   ?? 5_      $	??150 ?6'   ?? 5`      $??* ?6'   .+?5b      ? $??0??6   $??2??6'   .+?5c      ?? -   5        $ DocumentoLbl??5c      $??
Documento:??62   #??[ 6G      ctTextBox.ctTextBox  5d      -   5        $??DocumentoTxt??5d   *     TextBox#??[ 6>   #
 ?  6_   $??11??6?      ExibirBorda .  6?   5e      ? 5f      $??2??6   .+?5g      ?? -   5        $ FormaPgmtLbl??5g      $??Forma de Pagamento:??62   #??[ 6P     5h      -   5        $ FormaPgmtCmb??5h   +   $??5,23,0,0q?6A   $??12??6S   .@?5i      ?? $??BOLETO??6'   ?? 5j      $??CARTÃO DE CRÉDITO??6'   ?? 5k      $??CARTÃO DE DÉBITO??6'   ?? 5l      $??CHEQUE??6'   ?? 5m      $??	DEPÓSITO??6'   ?? 5n      $??DINHEIRO??6'   ?? 5o      $??TRANSFERÊNCIA??6'   5p      5q      ? 5r      $??3??6   .+?5s      ?? -   5        $ ObsLbl??5s      $??Observações:??6,   #??[ 6C     5t      -   5        $??ObsTxt??5t   *   #??[ 68   #
 ?  6Y   $??5,23,5,0q?6?   $??13??6?    .  6?   5u      5v      ? 5w      $??3??6    5x      ?? 5y      $??* ?6'   ?? 5z      $??* ?6'   ?? 5{      $??* ?6'   .+?5}      ? $??0??6   .+?5~      ?? -   5         ??Name$ CalcularBtn??5~      $??Calcular [F5]??62   $??5,5,0,0q?6J    
 Button#??[ 6[   5      ? 5?      $??1??6   .+?5?      ?? -   5        $ GerarBtn??5?      $??
Gerar [F6]??6/   $??5,5,0,0q?6D   #??[ 6U   5?      ? 5?      $??2??6   .+?5?      ?? -   5        $ DesfazerBtn??5?      $??Desfazer [F7]??62   $??5,5,0,0q?6J   #??[ 6[   5?      5?      ? 5?      $??4??6    5?      ?? 5?      $
??250* ?6'   ?? 5?      $
??200* ?6'   ?? 5?      $
??200* ?6'   .+?5?      ? $??0??6   .+?5?      ?? -   5        $ FormaDePgmtLbl??5?      $??Forma de Pagamento:??64   #??[ 6R     5?      -    5        $ FormaDePgmtCmb??5?   +   $??5,23,0,0q?6C   $??14??6U   .@?5?      ?? $??BOLETO??6'   ?? 5?      $??CARTÃO DE CRÉDITO??6'   ?? 5?      $??CARTÃO DE DÉBITO??6'   ?? 5?      $??CHEQUE??6'   ?? 5?      $??	DEPÓSITO??6'   ?? 5?      $??DINHEIRO??6'   ?? 5?      $??TRANSFERÊNCIA??6'   5?      5?      ? 5?      $??1??6   .+?5?      ?? -!   5        $ VencimentoLbl??5?      $??Vencimento:??63   #??[ 6I     5?      -"   5        $	 VencimentoTxt??5?   !   $??Stretch=?68   $??5,23,0,0q?6V   $??15??6h   ???	#FF4B4B4B
???   ?6?   5?      ? 5?      $??2??6   .+?5?      ?? -#   5        $ ValorParcLbl??5?      $??Valor da Parcela:??62   #??[ 6N     5?      -$   5        $??ValorParcTxt??5?   -   #??[ 6A   #
 ?  6e   $??5,23,5,0q?6?   $??16??6?   $ 2??6?    .  6?   5?      5?      ? 5?      $??5??6   .+?5?      &   System.Windows.Controls.DataGrid  -%   5          Name$ TituloDataGrid??5?      $??Stretch=?63   $??5,5,5,5q?6Q      AutoGenerateColumns .     
IsReadOnly .    CanUserAddRows .     CanUserDeleteRows .  ??6b   ??  ?? Source# [     Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5?      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Parcela??6-    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	 90*
 6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   ?? *
Parcelas+  5?      $ Forma de Pagamento??6-   $
 180*
 6I    6V   ?? *	FormaPgmt+  5?      $ 
Vencimento??6-   $
 120*
 6A    6N   ?? *VencimentoParc+ ?? StringFormat$ {0:dd/MM/yyyy}??  5?      $ Valor da Parcela??6-   $
 150*
 6G    6T   ?? *Valor+5?      5?      5?      ? 5?   
   $??2??6   $??Stretch=?6    	 title-secondary#??? 	 6:   .+?5?      ? $??0??6   $??Right=?6     5?      ?? 5?      $??90 ?6'   .+?5?      ? $??0??6   .+?5?      ?? -&   5        $ SairBtn??5?      $??
Sair [ESC]??6.   #??[ 6C   5?      5?      5?      5?      5?      
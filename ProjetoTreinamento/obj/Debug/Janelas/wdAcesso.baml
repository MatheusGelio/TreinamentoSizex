   M S B A M L   `   `   `  ????D  @ctTextBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ctTextBox;assembly=ctTextBox	ctTextBox  5       ProjetoTreinamento!   ProjetoTreinamento.wdAcesso   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @	ctTextBox*clr-namespace:ctTextBox;assembly=ctTextBox     5        ? Title$  Acesso??5       ? WindowStartupLocation$ CenterScreen=?6    
  Window#??[  69   .??5      ? .+?5   
   ?? -   5         ??Name$ 	AcessoRtg??5      ???	#FF1D3F6F6'   ?? 5   
   -   5         ??Name$ 	AcessoImg??5      $6??0/ProjetoTreinamento;component/Imagens/Acesso.png??6$   ? 5	   
   $??0??6    ? RowDefinitions 5
      ?? 5      $	??220 ?6    ?? 5      $??50 ?6    ?? 5      $??50 ?6    ?? 5      $??* ?6    .+?5      ? $??1??6   $??Bottom=?6    .+?5      ?? -   5         ??Name$ 
UsuarioLbl??5      $??	Usuário:??6,   $??Stretch=?6?   $??
245,0,0,25q?6]   $
??Bold"?6q   $??16(?6?   $??Calibri)?6?   ???	#FF1D3F6F6?      ctTextBox.ctTextBox  5      -   5          Name$ 
UsuarioTxt??5   &    ?? CharacterCasing$ Upper=?6:    ?? 
CaretBrush ?	#FF1D3F6F	 ?? SelectionBrush	 ?	#FF1D3F6F
 ?? TextAlignment$

 Left=?6?   $??Stretch=?6?   $??250,25,250,0q?6?   $
??Bold"?6?   $??14(?6?   $??Calibri)?6?   ???	#FF4B4B4B???	#FF1D3F6F$??0??61     ExibirBorda .  6>  5      ? 5      $??2??6   $	??Top=?6    .+?5      ?? -   5        $ SenhaLbl??5      $??Senha:??6*   $??Stretch=?6;   $??
245,0,0,25q?6Y   $
??Bold"?6m   $??16(?6   $??Calibri)?6?   ???	#FF1D3F6F6?   G? 5      -   5         G?Name$ SenhaTxt??5       G? 
CaretBrush ?	#FF1D3F6F G? SelectionBrush ?	#FF1D3F6F$??Stretch=?6b   $??250,25,250,0q?6?   ???	#FF4B4B4B???	#FF1D3F6F$??1??6?   5      ? 5      $??3??6   $	??Top=?6    .+?5      ?? -   5         ??Name$ 	EntrarBtn??5      $??Entrar [ENTER]??6,   $	??140??6E   $??25??6Q   $
??Left=?6]   $??
250,10,0,0q?6x   $??	ExtraBold"?6?   $??14(?6?     title-primary#???  6?   
???????6?   ?? 5      -   5        $ SairBtn??5      $??
Sair [ESC]??6*   $	??140??6?   $??25??6K   $??Right=?6W   $??
0,10,250,0q?6s   $??	ExtraBold"?6?   $??14(?6?     title-secondary#???  6?   
???????6?   5      5      5      5      
   M S B A M L   `   `   `  ����B  >Jukebox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Jukebox.ViewJukebox.View  5      (    "Jukebox.View.CreditTransactionView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Jukebox.View     5      .��5	      � $��15q�6     � RowDefinitions  5
   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Add Credits��6   $��18(�5      �� 5   
   $��1��69   $
��0, 5q�6F   ��6   �� *CurrentCreditsHeader+6F   �� 5   
   $��Amount of Credits to Add��6   $��2��63   $
��0, 5q�6@   	� 5   
   $��	5 Credits��6    	� 	GroupName$ 	CreditAmt��6*   $��3��6b    d� 	IsChecked 6@   �� *FiveCredits+6b   	� 5   
   $��
10 Credits��6   $ 	CreditAmt��6+   $��4��6b    6A   �� *
TenCredits+6b   	� 5   
   $��
15 Credits��6   $ 	CreditAmt��6+   $��5��6f    6A   �� *FifteenCredits+6f   �� 5   
   $��Payment Method��6   $��6��6)   $
��0, 5q�66   �� 5   
   $��7��6`   ��6   �� *PaymentOptions+ �� SelectedItem 69   �� *PaymentMethod+6`   �� 5   
   $��Add Credits��6   $��8��6R   $��0, 10, 0, 10q�6_   ��6'   �� *TransactCreditsCommand+6_   �� 5    
   $��Cancel��6   $��9��6X   ��6"   �� *#!CloseCreditTransactionViewCommand+6X   5"      5#      
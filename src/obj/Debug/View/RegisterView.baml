   M S B A M L   `   `   `  ����B  >Jukebox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Jukebox.ViewJukebox.View  5      1clr-namespace:Jukebox.HelpersJukebox.Helpers  5      G(clr-namespace:Jukebox.Helpers.ValidationJukebox.Helpers.Validation  5          Jukebox.View.RegisterView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Jukebox.View     5      -conclr-namespace:Jukebox.Helpers     5      8val(clr-namespace:Jukebox.Helpers.Validation     5        � 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �� Triggers P� Property	 P� Value
 �� 
TargetName �� Self �� RelativeSource �� Path'   !Jukebox.Helpers.RegisterConverter   MultiValueConverter  validationTemplate  textBoxInError �� Triggers��%1  '��       '�� O     'G� �    &	  �    &	 �    &	     �� 5   
   " ��6   .�5      ��  � �� �#6665      5      �� 5   
   " ��6   .�5      ��  � ��$ 0,0,0,1q�5      �� 5       � �� �#aaa5      �� 5       � ��
 ���� 5      �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��_Border��6!   #��z��5   !   #��z��5   !   #��z��5   !   ._�5      �� $ PART_ContentHost��6+   # z 5   +   5        5!      P� 5"       �@J�	IsFocused	 . . �5$   "   �� $
 _Border��6)    � ��
 ��d�5&   )   �� 5'   "   $
 _Border��6)    � ��$ 0,0,0,2q�5)   )   5*      P� 5+       �@J�IsMouseOver	 . . �5-   "   ��  �@�Cursor$ IBeam��5.   )   5/      P� 50       �@=�HasError	 . . �52   "   ��  53   )   �� # Z $) #(Validation.Errors)[0].ErrorContent� �@�ToolTip�� 55   "   $
 _Border��6)    � �� �	#FFFB757557   )   58      5:      5<      5=      �� 5>   
   " G�6   .�5?      ��  � �� �#aaa5@      �� 5A       � ��$ 0,0,0,1q�5B      �� 5C       � ��
 ���� 5D      �� 5E       � �� 5F      �� 5G      " G�6&   .R�5H      �� $��_Border��6!   #��z��5I   !   #��z��5J   !   #��z��5K   !   ._�5L      �� $ PART_ContentHost��6+   # z 5M   +   5N       5O      P� 5P       �@J�	IsFocused	 . . �5R   "   �� $
 _Border��6)    � ��
 ��d�5T   )   �� 5U   "   $
 _Border��6)    � ��$ 0,0,0,2q�5W   )   5X      P� 5Y       �@J�IsMouseOver	 . . �5[   "   ��  �@�Cursor$ IBeam��5\   )   5]      5_      5a      5b        5c   
   6    �� 5e   
   .R�5f      ]� .+�5g      �� 
���  ��$��20(�6-   !6>   �� 5h      5i      5j      �� 5k   
   " ��6'    5l      P� 5m       �@=�HasError	 . . �5n      ��  �@�ToolTip 60   �� # Z $) #(Validation.Errors)[0].ErrorContent��� 5p       � �� �	#FFFFDCDC63   5q      5s      5t      .��5u      � $��15q�6    � RowDefinitions 5v   
   �� 5w      $
��Auto �6   6,   �� 5x      $
��Auto �6   6,   �� 5y      $
��Auto �6   6,   �� 5z      $
��Auto �6   6,   �� 5{      $
��Auto �6   6,   �� 5|      $
��Auto �6   6,   .+�5~   
   ��  =� ErrorTemplate# [ 6   $��1��6Q   $��18��6^   $��Bottom=�6j   .��6�   ��5      �� 5�      $ Username�6    �� UpdateSourceTrigger$ PropertyChanged=�6*    �� ValidationRules 5�      -   'Jukebox.Helpers.Validation.UsernameRule  5�      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ UpdatedValue=�6+   5�      .��5�      5�      G� 5�   
   -   5        $��password��5�      $��2��6&   $��18��63   $��Bottom=�6?    � ToolTip$2 ,Password Must Contain at Least 6 Characters.��5�      G� 5�   
   -   5        $��confirmPassword��5�      $��3��6-   $��18��6:   $��Bottom=�6F   �� 5�   
   $��Sign Up��6   $��4��6N   $��0, 10, 0, 0q�6[    �� 	IsDefault . ��6#   �� *RegisterNewUserCommand+��5�      `� 5�       `� 	Converter# [  6   .1�5�      ��  �� ElementName$ password��6   �� 5�      $ confirmPassword��6   5�      5�      �� 5�   
   $��Cancel��6   $��5��6O   $��0, 10, 0, 0q�6\   ��6"   �� *CloseRegisterViewCommand+6\   �� 5�   
   -   5         ��Name$ label��5�      $��Username��6   $
��Left=�62   $��
0, 5, 5, 5q�6M   $��63��6b   $��26��6m   $��1��6y   $��Bottom=�6�   $��0,0,0,18q�6�   �� 5�   
   -   5        $ label1��5�      $��Password��6    $��
0, 5, 5, 5q�63   $��0,0,0,18q�6H   $��2��6Z   $��Bottom=�6g   $��26��6�   �� 5�   
   -   5        $ label2��5�      $��Confirm Password��6    $
��Left=�6;   $��
0, 5, 5, 5q�6V   $��0,0,0,18q�6k   $��3��6}   $��Bottom=�6�   $��26��6�   $	��110��6�   �� 5�   
   $��Sign Up��6    �� Padding$ 
0, 0, 5, 5q�6#   $��18(�5�      5�      5�      
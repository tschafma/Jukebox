   M S B A M L   `   `   `  ����B  >Jukebox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Jukebox.ViewJukebox.View  5      G(clr-namespace:Jukebox.Helpers.ValidationJukebox.Helpers.Validation  5          Jukebox.View.EditSongView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Jukebox.View     5      8val(clr-namespace:Jukebox.Helpers.Validation     5      $	��200��5
        � 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �� Triggers P� Property	 P� Value
 �� 
TargetName �� Self �� RelativeSource �� Path   ArtTemplate  validationTemplate  textBoxInError �� Triggers��%�  '��       '�� O     &	  �    &	 G    &	 �    �� 5   
   " ��6   .�5      ��  � �� �#6665      5      �� 5   
   " ��6   .�5      ��  � ��$ 0,0,0,1q�5      �� 5       � �� �#aaa5      �� 5       � ��
 ���� 5      �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��_Border��6!   #��z��5   !   #��z��5   !   #��z��5   !   ._�5      �� $ PART_ContentHost��6+   # z 5   +   5        5!      P� 5"       �@J�	IsFocused	 . . �5$   "   �� $
 _Border��6)    � ��
 ��d�5&   )   �� 5'   "   $
 _Border��6)    � ��$ 0,0,0,2q�5)   )   5*      P� 5+       �@J�IsMouseOver	 . . �5-   "   ��  �@�Cursor$ IBeam��5.   )   5/      P� 50       �@=�HasError	 . . �52   "   ��  53   )   �� # Z $) #(Validation.Errors)[0].ErrorContent� �@�ToolTip�� 55   "   $
 _Border��6)    � �� �	#FFFB757557   )   58      5:      5<      5=      �� 5>   
   .R�5?      � .+�5@      �� $��50��6+   $��50��66   ��6   �� 66   5A      5B      �� 5C   
   .R�5D      ]� .+�5E      �� 
���  ��$��20(�6-   !6>   �� 5F      5G      5H      �� 5I   
   " ��6'    5J      P� 5K       �@=�HasError	 . . �5L      ��  �@�ToolTip 60   �� # Z $) #(Validation.Errors)[0].ErrorContent��� 5N       � �� �	#FFFFDCDC63   5O      5Q      5R      .��5S      � $��15q�6    � RowDefinitions 5T   
   �� 5U      $
��Auto �6   6,   �� 5V      $
��Auto �6   6,   �� 5W      $
��Auto �6   6,   �� 5X      $
��Auto �6   6,   �� 5Y      $
��Auto �6   6,   �� 5Z      $
��Auto �6   6,   �� 5[      $
��Auto �6   .+�5]   
   �� $��18(�5^       �� Padding$
 0, 5q�5_      ��5]      �� *Header+5_      �� 5`   
    =� ErrorTemplate# [ 6   $��1��6Q   $��21��6^   $��Bottom=�6m   .��6�   ��5a      �� 5b      $ Title�6    �� UpdateSourceTrigger$ PropertyChanged=�6'    �� ValidationRules 5c      *   $Jukebox.Helpers.Validation.TitleRule  5d      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ UpdatedValue=�6(   5f      .��5g      5h      �� 5i   
   # [ 6   $��2��6Q   $��21��6^   $��Bottom=�6m   .��6�   ��5j      �� 5k      $ Artist�6   $ PropertyChanged=�6(    5l        5m      $ UpdatedValue=�6(   5o      .��5p      5q      �� 5r   
   # [ 6   $��3��6Q   $��21��6^   $��Bottom=�6m   .��6�   ��5s      �� 5t      $ Duration�6   $ PropertyChanged=�6*    5u      -   'Jukebox.Helpers.Validation.DurationRule  5v      $ UpdatedValue=�6+   5x      .��5y      5z      �� 5{   
   $��0, 28, 0, 0q�67   #��[  6q   $��4��6�   $��21��6�   $	��120��6�   $��Bottom=�6�   ��6   �� *ArtSelection+ �� SelectedItem 6L   �� *SelectedArt+6�   �� 5|   
   $��Save Changes��6   $��0, 10, 0, 0q�6(   $��5��6j   ��6=   �� *SaveChangesToSongCommand+6j   �� 5}   
   $��Cancel��6   $��0, 10, 0, 0q�6"   $��6��6d   ��67   �� *CloseEditSongViewCommand+6d   �� 5   
   $��Title��6   $��1��6    $��21��6-   $
��0, 5q�6<   $��0,0,0,21q�6K   $	��Top=�6]   �� 5�   
   $��Artist��6   $��2��6!   $��21��6.   $
��0, 5q�6=   $��0,0,0,21q�6L   $	��Top=�6^   �� 5�   
   $��Duration��6   $��3��6#   $��21��60   $
��0, 5q�6?   $��0,0,0,21q�6N   $	��Top=�6`   �� 5�   
   $��	Album Art��6   $��4��6$   $��21��61   $
��0, 5q�6@   $��0,0,0,21q�6O   $	��Top=�6a   5�      5�      
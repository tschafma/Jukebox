   M S B A M L   `   `   `  ����B  >Jukebox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Jukebox.ViewJukebox.View  5      G(clr-namespace:Jukebox.Helpers.ValidationJukebox.Helpers.Validation  5          Jukebox.View.AddSongView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Jukebox.View     5      8val(clr-namespace:Jukebox.Helpers.Validation     5      $	��230��5
      $	��250��5        � 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �� Triggers P� Property	 P� Value
 �� 
TargetName �� Self �� RelativeSource �� Path   ArtItemTemplate  validationTemplate  textBoxInError �� Triggers��%�  '��       '�� O     &	  �    &	 Y    &	 �    �� 5   
   " ��6   .�5      ��  � �� �#6665      5      �� 5   
   " ��6   .�5      ��  � ��$ 0,0,0,1q�5      �� 5       � �� �#aaa5      �� 5       � ��
 ���� 5      �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��_Border��6!   #��z��5   !   #��z��5   !   #��z��5   !   ._�5      �� $ PART_ContentHost��6+   # z 5    +   5!       5"      P� 5#       �@J�	IsFocused	 . . �5%   "   �� $
 _Border��6)    � ��
 ��d�5'   )   �� 5(   "   $
 _Border��6)    � ��$ 0,0,0,2q�5*   )   5+      P� 5,       �@J�IsMouseOver	 . . �5.   "   ��  �@�Cursor$ IBeam��5/   )   50      P� 51       �@=�HasError	 . . �53   "   ��  54   )   �� # Z $) #(Validation.Errors)[0].ErrorContent� �@�ToolTip�� 56   "   $
 _Border��6)    � �� �	#FFFB757558   )   59      5;      5=      5>      �� 5?   
   .R�5@      � .+�5A      �� $��64��6+   $��64��66   $��Center=�6B   ��6   �� 6B   5B      5C      �� 5D   
   .R�5E      ]� .+�5F      �� 
���  ��$��20(�6-   !6>   �� 5G      5H      5I      �� 5J   
   " ��6'    5K      P� 5L       �@=�HasError	 . . �5M      ��  �@�ToolTip 60   �� # Z $) #(Validation.Errors)[0].ErrorContent��� 5O       � �� �	#FFFFDCDC63   5P      5R      5S      .��5T      � $��10q�6    � RowDefinitions 5U   
   �� 5V      $
��Auto �6   6,   �� 5W      $
��Auto �6   6,   �� 5X      $
��Auto �6   6,   �� 5Y      $
��Auto �6   6,   �� 5Z      $
��Auto �6   6,   �� 5[      $
��Auto �6   6,   �� 5\      $
��Auto �6   6,   �� 5]      $
��Auto �6    � ColumnDefinitions 5_   
   �� 5`      6!   �� 5a      6!   .+�5c   
   �� $��Add Song��6    �� Padding$
 0, 5q�6$   $��2��63   $��18(�5d      �� 5e   
   -   5        $��txtPath��5e   Q    =� ErrorTemplate# [ 6   $��	0,0,-40,1q�6`   $��Bottom=�6s   $��1��6�   $��0��6�   .��6�   ��5f      �� 5g      $ SongPath�6    �� UpdateSourceTrigger$ PropertyChanged=�6*    �� ValidationRules 5h      -   'Jukebox.Helpers.Validation.RequiredRule  5i      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ UpdatedValue=�6+   5k      .��5l      5m      �� 5n   
   $��Browse . . .��6   $��45,0,0,0q�6(   $��Bottom=�6:   $��1��6U   $��1��6b   ��6r   �� *BrowseSongCommand+�� 5o   
   -   5        $��txtTitle��5o   Q   # [ 6   $��2��6a   $��2��6n   $��0,0,0,1q�6�   $��21��6�   $��Bottom=�6�   .��6�   ��5p      �� 5q      $ Title�6   $ PropertyChanged=�6'    5r      *   $Jukebox.Helpers.Validation.TitleRule  5s      $ UpdatedValue=�6(   5u      .��5v      5w      �� 5x   
   -   5        $��	txtArtist��5x   Q   # [ 6   $��3��6b   $��2��6o   $��21��6�   $��Bottom=�6�   .��6�   ��5y      �� 5z      $ Artist�6   $ PropertyChanged=�6(    5{        5|      $ UpdatedValue=�6(   5~      .��5      5�      �� 5�   
   -   5        $��txtDuration��5�   Q   # [ 6   $��4��6d   $��2��6q   $��0,0,0,1q�6�   $��21��6�   $��Bottom=�6�   .��6�   ��5�      �� 5�      $ Duration�6   $ PropertyChanged=�6*    5�      -   'Jukebox.Helpers.Validation.DurationRule  5�      $ UpdatedValue=�6+   5�      .��5�      5�      �� 5�   
   -   5        $��listArt��5�      $��0,28,0,0q�6!   #��[  6�   $��5��6�   $��2��6�   $��21��6�   $	��120��6�   $
��Auto=�6�   $��Disabled=�6!  ��. $��Bottom=�6|   �� SelectedItem 63   �� *SelectedImage+��6Z   �� *ArtCollection+6|  �� 5�   
   -   5        $��
btnConfirm��5�      $��0, 10, 0, 0q�6#   $��Add Song��68   $��6��6K   $��2��6X   ��6l   �� *AddNewSongCommand+�� 5�   
   -   5        $��	btnCancel��5�      $��0, 10, 0, 0q�6"   $��Cancel��67   $��7��6H   $��2��6U   ��6i   �� *CloseAddNewSongViewCommand+�� 5�   
   $��Pick a Song��6   $��0, 0, 0, 21q�6&   $
��0, 5q�6;   $��1��6J   $��28��6W   $	��Top=�6c   $
��Left=�6|   �� 5�   
   $��Title��6   $��0, 0, 0, 21q�6    $
��0, 5q�65   $��2��6D   $��28��6Q   $	��Top=�6]   $
��Left=�6v   �� 5�   
   $��Artist��6   $��0, 0, 0, 21q�6!   $
��0, 5q�66   $��3��6E   $��28��6R   $	��Top=�6^   $
��Left=�6v   �� 5�   
   $��Duration��6   $��0, 0, 0, 21q�6#   $
��0, 5q�68   $��4��6G   $��28��6T   $	��Top=�6`   $
��Left=�6x   �� 5�   
   $	��Art��6   $��0, 0, 0, 21q�6   $
��0, 5q�63   $��5��6B   $��28��6O   $	��Top=�6[   $
��Left=�6s   5�      5�      
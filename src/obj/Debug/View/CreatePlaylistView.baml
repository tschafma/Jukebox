   M S B A M L   `   `   `  ����B  >Jukebox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Jukebox.ViewJukebox.View  5      G(clr-namespace:Jukebox.Helpers.ValidationJukebox.Helpers.Validation  5      %    Jukebox.View.CreatePlaylistView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Jukebox.View     5      8val(clr-namespace:Jukebox.Helpers.Validation     5      $	��200��5
        � 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �� Triggers P� Property	 P� Value
 �� 
TargetName �� Self �� RelativeSource �� Path   VisibilityConverter  AllSongsItemTemplate � RowDefinitions  ArtItemTemplate  validationTemplate  textBoxInError �� Triggers��%�  '��       '�� O     &	  �    &	 �    &	 �    &	 P    &	 �    �� 5   
   " ��6   .�5      ��  � �� �#6665      5      �� 5   
   " ��6   .�5      ��  � ��$ 0,0,0,1q�5      �� 5       � �� �#aaa5      �� 5       � ��
 ���� 5      �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��_Border��6!   #��z��5   !   #��z��5   !   #��z��5   !   ._�5      �� $ PART_ContentHost��6+   # z 5   +   5        5!      P� 5"       �@J�	IsFocused	 . . �5$   "   �� $
 _Border��6)    � ��
 ��d�5&   )   �� 5'   "   $
 _Border��6)    � ��$ 0,0,0,2q�5)   )   5*      P� 5+       �@J�IsMouseOver	 . . �5-   "   ��  �@�Cursor$ IBeam��5.   )   5/      P� 50       �@=�HasError	 . . �52   "   ��  53   )   �� # Z $) #(Validation.Errors)[0].ErrorContent� �@�ToolTip�� 55   "   $
 _Border��6)    � �� �	#FFFB757557   )   58      5:      5<      5=      �� 5>   
   6'   �� 5?   
   .R�5@      �  5A      �� 5B      6&   �� 5C      6&   .+�5E      �� $��0��63   ��6   �� *Title+63   �� 5F      $��1��64   ���#999��6   �� *Artist+6A   5G      5H      �� 5I   
   .R�5J      � .+�5K      �� $��32��6+   $��32��66   $��Center=�6B   ��6   �� 6B   5L      5M      �� 5N   
   .R�5O      ]� .+�5P      �� 
���  ��$��20(�6-   !6>   �� 5Q      5R      5S      �� 5T   
   " ��6'    5U      P� 5V       �@=�HasError	 . . �5W      ��  �@�ToolTip 60   �� # Z $) #(Validation.Errors)[0].ErrorContent��� 5Y       � �� �	#FFFFDCDC63   5Z      5\      5]      .��5^      � $��15q�6    5_   
   �� 5`      $
��Auto �6   6,   �� 5a      $
��Auto �6   6,   �� 5b      $
��Auto �6   6,   �� 5c      $
��Auto �6   6,   �� 5d      $
��Auto �6   6,   �� 5e      $
��Auto �6   6,   �� 5f      $
��Auto �6   .+�5h   
   �� $��Create Playlist��6    �� Padding$ 
0, 0, 5, 5q�6+   $��18(�5i      �� 5j   
   -   5        $��txtNewPlaylistName��5j   Q    =� ErrorTemplate# [ 6   $��1��6k   $��21��6x   $��Bottom=�6�   .��6�   ��5k      �� 5l      $
 Name�6    �� UpdateSourceTrigger$ PropertyChanged=�6&    �� ValidationRules 5m      *   $Jukebox.Helpers.Validation.TitleRule  5n      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ UpdatedValue=�6(   5p      .��5q      5r      �� 5s   
   -   5        $��listArtSelection��5s      #��[ 6m   $��2��6�   $	��100��6�   $��21��6�   $	��Top=�6�   $��0,26,0,0q�6�   ��6*   �� *Art+ �� SelectedItem 6F   �� *SelectedImage+6�   �� 5t   
   -   5        $��listMusicSelection��5t      $��3��6,   #��[ 6W    �� SelectionMode$ Multiple=�6�   $	��150��6�   $��21��6�   $	��Top=�6�   $��0,26,0,0q�6�   ��69   �� *Songs+��5u      �� 5v      " ��6   .�5w      ��  �@��
IsSelected 63   �� *
IsSelected+5x      5z      �� 5{   
   -   5        $��radioAllPlaylists��5{      $��
0, 5, 0, 0q�6�   $��For All Users��6�   $��4��6�    d� 	IsChecked 6,   �� *PlaylistForAll+y�6Q   �� *	IsAdmin+ �� 	Converter# [   �� FallbackValue$ 	Collapsed��6�   �� 5|   
   -   5        $��btnCreatePlaylist��5|      $��
0, 5, 0, 0q�6*   $��Create Playlist��6>   $��5��6X   ��6e   �� *CreateNewPlaylistCommand+�� 5}   
   -   5        $��btnClosePlaylist��5}      $��
0, 5, 0, 0q�6)   $��Cancel��6=   $��6��6N   ��6[   �� * CloseCreatePlaylistViewCommand+�� 5~   
   -   5         ��Name$ label��5~      $��
0, 5, 5, 5q�6   $��Playlist Name��64   $
��Left=�6L   $��Bottom=�6g   $��1��6�   $��1��6�   $��0,0,0,21q�6�   �� 5   
   -   5        $ label1��5      $��
0, 5, 5, 0q�6    $��Choose an Image��65   $
��Left=�6O   $��2��6j   $	��Top=�6w   �� 5�   
   -	   5        $ label2��5�      $��
0, 5, 5, 0q�6    $��Pick Your Songs��65   $
��Left=�6O   $��3��6j   $	��Top=�6w   5�      5�      
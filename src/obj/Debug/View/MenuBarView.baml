   M S B A M L   `   `   `  ����B  >Jukebox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Jukebox.ViewJukebox.View  5          Jukebox.View.MenuBarView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Jukebox.View     5      ���#f2f2f2  � 	Resources  5
         VisibilityConverter �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� Triggers P� Property P� Value��%�  &	        '��      �� 5   
   6'   �� 5   
   " ��6   .�5      ��  � ��
 ���� 6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ 
0, 0, 0, 0q�6'   �� 5       � ��$ 15, 15, 50, 15q�6(   �� 5       � ��$ 0,0,0,0q�60   �� 5       � ��
 �����6,   �� 5       � �� �#6262625      �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   # z��5   !   #��z��5   !   #��z��5   !   ._�5      �� $
��Left=�6/   $��Center=�6J   5      5      5        5!      P� 5"       �@J�IsMouseOver . . �5$      ��  � ��
 ��d�63   �� 5%       � �� �#f9f9f95&      �� 5'       �@�Cursor$
 Hand��5(      5)      P� 5*       � �� . . �5+      ��  � ��
 �����63   �� 5,       � ��
 �   �63   5-      5/      50      .��5I      �� .+�5J   
   �� $��Log in��6   $��0��5L      y�5K      �� *IsLoggedOut+	 �� 	Converter#	 [  
 �� FallbackValue$
 Visible����5M      �� *CreateLoginViewCommand+�� 5N   
   $��Log out��6   $��0��5P      y�5O      �� *
IsLoggedIn+#	 [  $
 	Collapsed����5Q      �� *LogoutUserCommand+�� 5R   
   $��Create Playlist��6   $��1��5T      y�5S      �� *
IsLoggedIn+#	 [  $
 	Collapsed����5U      �� *CreatePlaylistViewCommand+�� 5V   
   $��Sign Up��6   $��1��5X      y�5W      �� *IsLoggedOut+#	 [  $
 Visible����5Y      �� *CreateRegisterViewCommand+�� 5Z   
   $��Add Song��6   $��2��5\      y�5[      �� *	IsAdmin+#	 [  $
 	Collapsed����5]      �� *CreateAddNewSongViewCommand+�� 5^   
   $��Purchase Credits��6   $��3��5_      ��5`      �� *$"CreateCreditTransactionViewCommand+�� 5a   
   $��Edit Playlist��6   $��4��5c      y�5b      �� *IsPlaylistSelected+#	 [  $
 	Collapsed����5d      �� *CreateEditPlaylistViewCommand+�� 5e   
   $��	Edit Song��6   $��5��5g      y�5f      �� *IsSongSelected+#	 [  $
 	Collapsed����5h      �� *CreateEditSongViewCommand+�� 5i   
   $��Delete Playlist��6   $��6��5k      y�5j      �� *IsPlaylistSelected+#	 [  $
 	Collapsed����5l      �� *DeletePlaylistCommand+�� 5m   
   $��Delete Song��6   $��7��5o      y�5n      �� *IsSongSelected+#	 [  $
 	Collapsed����5p      �� *DeleteSongCommand+�� 5q   
   $��8��5r      $��15, 15q�5s      ���#f2f2f2���#666��5q      �� *
UserInfo+5u      5v      5w      
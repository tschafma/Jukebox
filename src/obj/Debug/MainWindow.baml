   M S B A M L   `   `   `  ����B  >Jukebox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:JukeboxJukebox  5   	   +clr-namespace:Jukebox.ViewJukebox.View  5   	   5clr-namespace:Jukebox.ViewModelJukebox.ViewModel  5   	       Jukebox.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Jukebox     5   	   (vclr-namespace:Jukebox.View     5   	   .vmclr-namespace:Jukebox.ViewModel     5   	     � Title$  JukeBox��5
   	    � 	Resources 5      %   Jukebox.ViewModel.MainViewModel   MainViewModel �� DataType#   Jukebox.PlaylistListViewModel#   Jukebox.View.PlaylistListView   Jukebox.SongListViewModel   Jukebox.View.SongListView   Jukebox.SongViewModel   Jukebox.View.SongView%   Jukebox.ViewModel.MenuViewModel	   Jukebox.View.MenuBarView/
   )Jukebox.ViewModel.CreatePlaylistViewModel%   Jukebox.View.CreatePlaylistView*   $Jukebox.ViewModel.LoginUserViewModel    Jukebox.View.LoginUserView)   #Jukebox.ViewModel.RegisterViewModel   Jukebox.View.RegisterView   Jukebox.AddSongViewModel   Jukebox.View.AddSongView-   'Jukebox.ViewModel.EditPlaylistViewModel#   Jukebox.View.EditPlaylistView)   #Jukebox.ViewModel.EditSongViewModel   Jukebox.View.EditSongView2   ,Jukebox.ViewModel.CreditTransactionViewModel(   "Jukebox.View.CreditTransactionView��%V  &	        (��      5      *, +)(�� E     5      *, +)(�� w     5      *, +)(�� �     5      *, +)(�� �     5      *,
 +)(��     5      *, +)(�� ?    5      *, +)(�� q    5"      *, +)(�� �    5%      *, +)(�� �    5(      *, +)(��     5+      *, +)  5   
   6   �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5      	  5      �� 5   
   " 
 6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5         5!      �� 5"   
   "  6   .R�5#        5$      �� 5%   
   "  6   .R�5&        5'      �� 5(   
   "  6   .R�5)        5*      �� 5+   
   "  6   .R�5,        5-      5.      .��5/      �  � DataContext# [  6    � RowDefinitions 50   
   �� 51      $
��auto �6   6,   �� 52      $��* �6   6)    � ColumnDefinitions 54   
   �� 55      $
��Auto �6   6.   �� 56      $
��Auto �6   6.   �� 57      $
��173* �6   6.   �� 58      $
��Auto �6   6.   .+�5:   
   �� -   5        $��MenuBar��5:      $��0��6    $��0��6-   ���#ddd._�5;      �� ��6   �� *MenuViewModel+5<      �� 5=   
   -   5        $��VariableColumn��5=      $��1��6'   $��0��64   ���#f2f2f2
�������$��0,2,0,0q�6m   ._�5>      �� $
��Auto=�6   .��5?      �� ��6!   �� *VariableViewModel+5@      5A      �� 5B   
   $��1��6   $��2��6!   $��0,0,0,1q�62   ._�5C      �� ��6   �� *PlaylistListViewModel+5D      �� 5E   
   $��2��6   $��2��6!   $	��0,1q�62   ._�5F      �� ��6   �� *SongListViewModel+5G      �� 5H   
   $��3��6   $��2��6!   $��0q�62   ._�5I      �� ��6   �� *SongViewModel+5J      5K      5L      
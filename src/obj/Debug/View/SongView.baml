   M S B A M L   `   `   `  ����B  >Jukebox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Jukebox.ViewJukebox.View  5          Jukebox.View.SongView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Jukebox.View     5      ���#f2f2f2  � 	Resources  5
       �� 
TargetType �� Property �� Value��%c   '��       �� 5   
   " ��6   .�5      ��  �@��Padding$ 0, 10, 0, 5q�6(   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      .+�5   
   �� $	��400��6)   $��
0, 0, 0, 0q�65   $��0��6I   ��6   �� *Image+6I   �� 5   
   $��2��6+   ���#f2f2f2���#505050 �� TextAlignment$ Center=�6b   $��16(�6y   ��6   �� *Title+6y   �� 5   
   $��3��6,   ���#f2f2f2���#727272$ Center=�6c   $��13.333(�6z   ��6   �� *Artist+6z   �� 5   
   $��4��6.   ���#f2f2f2���#727272$ Center=�6e   ��6   �� *
Duration+6e   �� 5   
   -   5        $��DurationSlider��5      {�.  $��5��6:   $��10q�6G   r� 5   
   -   5        $��MediaPlayer��5       r� LoadedBehavior$ Manual=�6*   $��6��6e    r� Source 6B   �� *MediaSourcePath+6�   5$      5%      
   M S B A M L   `   `   `  ����D  @Zadatak_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Zadatak_1.ViewsZadatak_1.Views  5   	       Zadatak_1.Views.UserView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Zadatak_1.Views     5   	     � Title$
  User��5   	   $	��450��6   $	��500��6#   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6   .+�5   
   �� -   5        $��
btnAddSong��5   .   $��1��6   $��1��6!   $��Add new Song��6@   $��20��6W   $	��100��6c   $
��Left=�6o   $��0,10,0,0q�5   R   ��6   �� *	AddSong+ �� UpdateSourceTrigger$ PropertyChanged=�6R   � 5   
   $��1��6   $��2��6   $
��auto��6,   $
��auto��6:   .+�5       &   System.Windows.Controls.DataGrid  -   5          Name$ AllSongs��5          AutoGenerateColumns .     
IsReadOnly .    HeadersVisibility$ Column=�5!   )   $��0,10,0,0q�6D   ��5    )   �� *Songs+$ PropertyChanged=� �� SelectedItem 5!   V   �� *Song+$ PropertyChanged=�	   Columns	 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn
   Header$
 	Song Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Name+  5$      $
 Song Author��6)    6>   �� *Author+  5%      $
 Length in Seconds��6)    6D   �� *SecondsLength+5'      5(      5)      5*      
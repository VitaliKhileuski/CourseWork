   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      H DWPFCourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFCourseWork.ViewWPFCourseWork.View 5      "   WPFCourseWork.View.TimeTable   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      2local clr-namespace:WPFCourseWork.View     5      .��5      �   � RowDefinitions  5   
   �� 5      $	��37* �6   6+   �� 5      $��8* �6   6*    � ColumnDefinitions 5   
   �� 5      $	��19* �6   6-   �� 5      $
��auto �6   6.   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid��5   �      
IsReadOnly .   �� TextAlignment$ Center=�6&      SelectionMode$ Single=�6�   
�������   SelectionUnit$
 Cell=�6�      MinRowHeight$ 80Q�6�      AutoGenerateColumns .  "	   VerticalScrollBarVisibility$	 Disabled=�6`  
   CanUserAddRows
 .     CanUserSortColumns .     CanUserResizeColumns .     CanUserDeleteRows .     CurrentCell 6I   �� *Temp+ �� SelectedIndex 6f   �� *Temp+ �� Mode$ TwoWay=���6�   �� *StudentDays+ �� UpdateSourceTrigger$ PropertyChanged=� � 	Resources 5       �� 
TargetType   WrapText �� Property �� Value��%T   &	        �� 5      " ��6   .�5      ��  � ��$
 Wrap=�65   5      5      .   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5         	EventName$ PreparingCellForEdit��6!   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      6   0System.Windows.Interactivity.InvokeCommandAction     Command 5      �� *SetDisciplineCommand+5        5      $ GotFocus��6!   . 5          5!      �� *SelectedCommand+5#      5$         Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6&      
IsReadOnly .    
FontWeight$
 Bold"�6c      Header$ день недели��6u   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6E   �� *	DayOfWeek+5)        5*      $ 0.25* 6&    . $
 Bold"�6}   $ дата��6�    6G   �� *Date+  �� StringFormat$  	{0:dd.MM}��5+        5,      ! 	  ElementStyle#! [  6h   $ * 6�    6%   �� *
Lessons[0]+$ PropertyChanged=� 5-      �� 5.      $
��Bold"�6$   $��Первая пара��66   $��30 0 0 0q�6I   6]   50        51      $ * 6%   #! [  6r    6/   �� *
Lessons[1]+$ PropertyChanged=� 52      �� 53      $
��Bold"�6$   $��Вторая пара��66   $��30 0 0 0q�6I   6]   55        56      $ * 6%   #! [  6r    6/   �� *
Lessons[2]+$ PropertyChanged=� 57      �� 58      $
��Bold"�6$   $
��Wrap=�66   $��Третья пара��6J   $��30 0 0 0q�6]   6q   5:        5;      $ * 6%   #! [  6r    6/   �� *
Lessons[3]+$ PropertyChanged=� 5<      �� 5=      $
��Bold"�6$   $!��Четвертая пара��66   $��30 0 0 0q�6L   6`   5?        5@      $ * 6%   #! [  6r    6/   �� *
Lessons[4]+$ PropertyChanged=� 5A      �� 5B      $
��Bold"�6$   $��Пятая пара��66   $��30 0 0 0q�6H   6\   5D      5G      �� 5H   
   $��1��6   " �� Orientation$" 
Horizontal=�6"   .+�5I      �� $��
Назад��6   $��
30 0 200 0q�6%   $��50��6:   $	��100��6I   
���   �$	��1.4q�6�   $��19(�6�   ��6X   �� *BackCommand+6�   �� 5J      $��1��6   $��0��6#   $:��4выставление/показ пропусков��63   $	��1.4q�6�   
���   �$��70��6�   $	��340��6�   $	��350��6�   $��19(�6  ��6Z   �� *FillSkipsCommand+��6   �� *NewSelectedItem+6  5K      �� 5M   
   $��18(�6@   $��1��6N   $��2��6�   # �� SelectedItem# 6   �� *SelectedDiscipline+��6_   �� *Disciplines+6�   5N      5P      
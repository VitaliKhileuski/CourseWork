   M S B A M L   `   `   `  ����H  DWPFCourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFCourseWork.ViewWPFCourseWork.View  5   	       WPFCourseWork.View.skips   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPFCourseWork.View     5   	     � Title$  skips��5   	   $	��750��6   $
��1300��6$    � WindowStartupLocation$ CenterScreen=�61   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��564* �6   6,   �� 5      $
��157* �6   6,   .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns .  $��0��6/      CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .  ��6<   �� *Skips+ �� UpdateSourceTrigger$ PropertyChanged=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   CanUserSort
 .     Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.4* 6z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	Student+$ PropertyChanged=�   Header 5      �� 5      $��Студенты��6$   $
��Bold"�64   $��
140 0 60 0q�6F   5      5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ 0.118* 6*    69   �� *
IsAbsent+$ PropertyChanged=� 5      �� 5      $��Отсутсвует��6$   $
��Bold"�66   $��15 0 0 0q�6H   6\   5        5      $ * 6E    6%   �� *Description+ 5      �� 5      $2��,Статус пропуска,причина��6$   $��
300 0 0  0q�6D   $
��Bold"�6Y   6m   5!      5#      �� 5$   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5%      �� $ Vertical=�6   $��
 0 0 100 0q�60   .+�5&      �� $��	20 20 0 0q�6   $��16(�6/   $
��Bold"�6=   ��6O   ��  �� StringFormat$ Дисциплина: {0}�� �� Path$ 
Discipline�6�   �� 5'      $��
20 20 0 20q�6   $��16(�60   $
��Bold"�6>   ��6P   �� $% Преподаватель: {0}��$ Teacher�6�   5(      �� 5)      $��1��6   $��0 0 0 50q�6"   $��Сохранить��64   $��70��6n   $	��1.4q�6}   
���   �$	��340��6�   $	��350��6�   $��19(�6�   ��6I   �� *SaveSkipsCommand+6�   5*      5,      5-      
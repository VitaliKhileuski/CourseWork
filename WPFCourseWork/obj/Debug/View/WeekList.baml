   M S B A M L   `   `   `  ����H  DWPFCourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFCourseWork.ViewWPFCourseWork.View  5      !    WPFCourseWork.View.WeekList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:WPFCourseWork.View     5      .��5
      �   � ColumnDefinitions  5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��0��6   $��
Назад��6!   $��	20 20 0 0q�61   $��0��6d   $	��Top=�6q   $
��Left=�6�   $	��1.4q�6�   
���   �$��35��6�   $��70��6�   ��6D   �� *BackCommand+6�   �� 5   
   $��0��6   $��0��6$   $��0 70 0 0q�61   $��2��6C   $��Выбор недели��6W   $��30(�6k   $
��Bold"�6y   $��Center=�6�   6�   �� 5   
   $��25(�6   $��0��6J   $��1��6y   $��2��6�   $	��Top=�6�   $��	55 0 55 0q�6�    �� SelectedItem 6$   �� *SelectedWeek+��6Z   �� *Weeks+6�   �� 5   
   $��1��69   $��1��6I   $	��top=�6V   $��ВЫБРАТЬ��6n   $��0 0 0 30q�6�   $	��1.4q�6�   
���   �$��90��6�   $	��250��6�   $��19(�6�   ��6   �� *ChoosewWeekCommand+6�   �� 5   
   $��1��6   $��2��6"   $	��Top=�6/   $*��$Получить docx таблицу��6m   $	��1.4q�6�   
���   �$��90��6�   $	��250��6�   $��19(�6�   ��6G   �� *CreateDocxCommand+6�   5      5      
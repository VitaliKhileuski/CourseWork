   M S B A M L   `   `   `  ����H  DWPFCourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFCourseWork.ViewWPFCourseWork.View  5      #    WPFCourseWork.View.LoginGroup   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:WPFCourseWork.View     5      .��5
      �   � RowDefinitions  5   
   �� 5      $	��34* �6   6+   �� 5      $
��144* �6   6,   �� 5      $	��47* �6   6+   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   .+�5      �� $��
Назад��6   $��20 0 0 0q�6%   $	��1.4q�6W   
���   �$��35��6�   $��70��6�   ��67   �� *BackCommand+6�   �� 5      $��Center=�6:   $��
380 40 0 0q�6W   $_��YГруппа отсутствует, пожалуйста, Создайте группу.��6k   $��25(�6�   $
��Bold"�6�   y�6   �� *
Visibility+6�   5      �� 5   
   $	��500��6    �� SelectionMode$ Extended=�6$   $��	20 0 20 0q�6=   $��1��6Q   $��30(�6�   $��Center=�6�   ��6^   �� *StudentGroups+ �� SelectedItem 6�   �� *SelectedStudentGroup+5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $��2��6L   .+�5      �� $��Удалить��6   $	��1.4q�6�   
���   �$��0 0 30 0q�6�   $��60��6�   $	��200��6�   ��6'   �� *DeleteGroupCommand+��6N   �� *SelectedStudentGroup+6�   �� 5      $��
Войти��6   $	��1.4q�6�   
���   �$��30 0 0 0q�6�   $��60��6�   $	��200��6�   ��6'   �� *LoginGroupCommand+��6N   �� *SelectedStudentGroup+6�   5      5      5      
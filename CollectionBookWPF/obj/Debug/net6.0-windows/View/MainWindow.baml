   M S B A M L   `   `   `  ����L  HCollectionBookWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CollectionBookWPF.ViewCollectionBookWPF.View  5   	   '    !CollectionBookWPF.View.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:CollectionBookWPF.View     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��850��6)   
�������.��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� -   5         ��Name$ ViewAllBooks��5   !   $��0��6      ListViewStyle#���   5      $��Disabled=�5      ��5      �� *	All_Books+ �� SelectedItem 5      �� *Selected_Book+ � ContextMenu 5      �� 5      .@�5      m� $ ��Редактировать��6    m� Command 66   �� *Open_Edit_Book_Wnd+m� 5      $��Удалить��6    60   �� *Delete_Item+5      ��5      �� 5      .R�5      � $	��800��6    5      �� 5      $��* �6,   69   .+�5       �� $��0��6?   $��Center=�6L    �� TextAlignment$ Center=�6g   $	��200��6~   $
��Left=�5!   ,   $��0 5 5 5q�6G   $��20(�6X   $
��Bold"�6f   ��5    (   �� *Name+5!   f   �� 5"      $��0��6@   $��	200 5 5 5q�6M   $
��Left=�6`   $��20(�6{   $	��200��5#   (   $
��Bold"�64   $��Center=�6G   $ Center=�6b   ��5"   (   �� *Author+5#   b   �� 5$      $��0��6E   $��20(�6R   $
��Left=�6`   $��	400 5 5 5q�6{   $	��200��5%   )   $
��Bold"�65   $��Center=�6G   $ Center=�6b     TextBlockStyle#���  6y   ��5$   (   �� *Title_Genre+5%   y   �� 5&      $��0��6L   $��20(�6Y   $
��Left=�6g   $��	600 5 5 5q�6�   $	��200��5'   )   $
��Bold"�65   $��Center=�6G   $ Center=�6b   ��5&   (   �� *Year_Of_Publishing+5'   b   �� 5(      $��0��6!   $��0��6.   
���   �$��2q�6S    �� CornerRadius$ 10��6g   5)      5*      5,      �� 5F   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5G      ��   ButtonStyle#���  6   $��Добавить��6;   ��5H      �� *Open_Add_New_Book_Wnd+�� 5I      #���  6   $ ��Редактировать��6;   ��5J      �� *Open_Edit_Book_Wnd+�� 5K      #���  6   $��Удалить��6;   ��5L      �� *Delete_Item+�� 5N      #���  6   $��Сорт. по году��6;   ��5O      �� *	Sort_Year+5P      �� 5Q   
   $��1��6   $ 
Horizontal=�6"   $
��Left=�6;   .+�5R      �� $#��Поиск по автору:��6   $��5q�60   $��20��6;   $��Center=�6G   �� 5S      -   5        $	��Com��5S      $	��200��6#   $��23��6/   ��6;   �� *Find_Author_Combobox+5T      5U      5V      
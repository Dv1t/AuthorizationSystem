   M S B A M L   `   `   `  ����B  >UserApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UserAppUserApp  5   	       UserApp.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:UserApp     5   	     � Title$  LoginWindow��5   	   $	��450��6   $	��800��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   6)   �� 5      $
��0.5* �6   6,   �� 5      $
��0.5* �6   6,   �� 5      $
��0.5* �6   6,   �� 5      $
��1.5* �6   6,    � ColumnDefinitions 5   
   �� 5      6!   �� 5      $��3* �6   6,   �� 5      6!   .+�5   
   �� $��3��6   $��0��6(   $��50(�65    �� TextAlignment$ Center=�6C   $��Center=�6Z   
���iii�Awesome user database6�   �� 5   
   -   5        $��LoginBox��5      $��1��6"   $��1��6/   $��10q�6?   $��0q�6K    �� 	MaxLength$ 20��6W   $��22(�6f   .��6�   Login6�   G� 5   
   -   5        $��PasswordBox��5      $��2��6)   $��1��66   $��10q�6F   $��0q�6R    G� 	MaxLength$ 20��6^   $��22(�6m    G� Password$ ******��6{   6�   �� 5   
   $��3��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $��Stretch=�6h   .+�5      �� -   5        $	��100��5      $��10q�6!   $��22(�6-   .��6N   LOGIN6U   �� 5      $��Center=�6   $��22(�63   OR6E   �� 5      -   5        $	��120��5      $��10q�6!   $��22(�6-   .��6Q   
REGISTER6[   5      5      5       
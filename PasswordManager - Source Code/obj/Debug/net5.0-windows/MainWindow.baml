   M S B A M L   `   `   `  ����J  FPasswordManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PasswordManagerPasswordManager  5   	        PasswordManager.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:PasswordManager     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   ]� $��False��6   .+�5      �� $	��200��6   .+�5      �� $��40��6   
�������$	��182��67   �� 5      -   5         ��Name$ Createbutton��5      $��Create New Profile��6/   $��30��6L   $	��180��6X   6d   �� 5      $	��100��6   
�������$	��182��68   �� 5      -   5        $ Deletebutton��5      $��
DeleteFile��6/   $��30��6D   $	��180��6P   6\   �� 5      $	��100��6   
�������$	��182��68   �� 5      -   5        $ Exportbutton��5      $��Export/Import Passwords��6/   $��30��6Q   $	��180��6]   6i   5      �� 5      $	��600��6   .+�5      �� -   5         ��Name$ comboBox��5      $��29��6-   $	��386��69   6E   �� 5      $��30��6   
�������$	��568��67   �� 5      -   5         ��Name$ ProfileNameLabel��5      $��25��66   $
��Bold"�6B   $��20(�6T   $
��Wrap=�6b   $��Profile Name��6v   $	��150��6�    �� TextAlignment$ Center=�6�   �� 5      -   5        $ ProfileName��5      $��20(�61   $��30��6?   $
��Wrap=�6K   $��Nothing inputed yet��6_   $	��458��6z   $ Center=�6�   �� 5      $��30��6   
�������$	��568��67   �� 5      -   5        $ UserNameLabel��5      $��25��63   $
��Bold"�6?   $��20(�6Q   $
��Wrap=�6_   $��Username��6s   $	��150��6�   $ Center=�6�   �� 5      -   5        $ UserName��5      $��20(�6.   $��30��6<   $
��Wrap=�6H   $��Nothing inputed yet��6\   $	��458��6w   $ Center=�6�   �� 5      -	   5        $ usernameCopyButton��5      $��Copy to Clipboard��65   $��25��6Q   $	��130��6]   $
��Bold"�6i   6{   �� 5      $��30��6   
�������$	��568��67   �� 5      -
   5        $ PasswordLabel��5      $��25��63   $
��Bold"�6?   $��20(�6Q   $
��Wrap=�6_   $��Password��6s   $	��150��6�   $ Center=�6�   �� 5      -   5        $ Password��5      $��20(�6.   $��30��6<   $
��Wrap=�6H   $��Nothing inputed yet��6\   $	��458��6w   $ Center=�6�   �� 5      -   5        $ passwordCopyButton��5      $��Copy to Clipboard��65   $��25��6Q   $	��130��6]   $
��Bold"�6i   6{   �� 5       $��30��6   
�������$	��568��67   �� 5!      -   5        $ deleteButton��5!      $��Delete Profile��6/   $
��Bold"�6H   $��36��6Z   $	��121��6f   6r   5"      5#      5%      5&      
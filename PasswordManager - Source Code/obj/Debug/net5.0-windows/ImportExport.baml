   M S B A M L   `   `   `  ����J  FPasswordManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PasswordManagerPasswordManager  5   	   "    PasswordManager.ImportExport   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:PasswordManager     5   	     � Title$  ImportExport��5   	   $	��400��6   $	��700��6+   .��5	      � .+�5
   
   �� -   5         ��Name$ ExportLabel��5
      $��Export Path:��6%   $
��Bold"�6<   $��20(�6N   $
��Left=�6\   $��42��6w   $��	30,23,0,0q�6�   $	��Top=�6�   $	��159��6�   �� 5   
   -   5         ��Name$ exportTextBox��5      $��18(�6)   $
��Left=�67   $��53��6R   $��	30,57,0,0q�6^    �� TextWrapping$
 Wrap=�6q   $8��2File Path to save an un-encrypted password file at��6�   $	��Top=�6�   $	��637��6�   �� 5   
   -   5         ��Name$ ExportButton��5      $��Export��6'   $
��Bold"�68   $��20(�6J   $��Center=�6X   $��42��6u   $��	0,115,0,0q�6�   $	��Top=�6�   $	��212��6�   6�   �� 5   
   -   5        $ ImportLabel��5      $��Import Path:��6%   $
��Bold"�6<   $��20(�6N   $
��Left=�6\   $��37��6w   $��
30,206,0,0q�6�   $	��Top=�6�   $	��159��6�   �� 5   
   -   5        $ importTextBox��5      $��18(�6)   $
��Left=�67   $��53��6R   $��
30,243,0,0q�6^   $
 Wrap=�6r   $:��4File Path to an un-encrypted password file to import��6�   $	��Top=�6�   $	��614��6�   �� 5   
   -   5        $ ImportButton��5      $��Import��6'   $
��Bold"�68   $��20(�6J   $��Center=�6X   $��42��6u   $��	0,301,0,0q�6�   $	��Top=�6�   $	��212��6�   6�   5      5      
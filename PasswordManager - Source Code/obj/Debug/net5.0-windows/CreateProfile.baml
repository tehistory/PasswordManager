   M S B A M L   `   `   `  ����J  FPasswordManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PasswordManagerPasswordManager  5   	   #    PasswordManager.CreateProfile   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:PasswordManager     5   	     � Title$  CreateProfile��5   	   $	��270��6   $	��500��6,   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��Create New Profile��6   $��Center=�6<   $��42��6Y   $��0,0,0,0q�6e   $	��Top=�6v   $	��438��6�   $��Center=�6�   $
��Bold"�6�   $��24(�6�   �� 5   
   -   5        $ ProfileLabel��5      $��Profile Name:��6&   $
��Left=�6>   $��25��6Y   $��0,50,0,0q�6e   $	��Top=�6w   $	��107��6�   �� 5   
   -   5         ��Name$ 
ProfileBox��5      $��Center=�6&   $��25��6C   $��0,50,0,0q�6O    �� TextWrapping$
 Wrap=�6a   $��Profile Name��6u   $	��Top=�6�   $	��315��6�   �� 5   
   -   5        $ UsernameLabel��5      $��Profile Name:��6'   $
��Left=�6?   $��25��6Z   $��0,90,0,0q�6f   $	��Top=�6x   $	��107��6�   �� 5   
   -   5        $ UsernameBox��5      $��Center=�6'   $��25��6D   $��0,90,0,0q�6P   $
 Wrap=�6b   $��Username��6v   $	��Top=�6�   $	��315��6�   �� 5   
   -   5        $ PasswordLabel��5      $��	Password:��6'   $
��Left=�6;   $��25��6V   $��	0,130,0,0q�6b   $	��Top=�6u   $	��107��6�   �� 5   
   -   5        $ PasswordBox��5      $��Center=�6'   $��25��6D   $��	0,130,0,0q�6P   $
 Wrap=�6c   $��Password��6w   $	��Top=�6�   $	��315��6�   �� 5   
   -   5         ��Name$ 	Genbutton��5      $��Generate Password��6$   $��Center=�6@   $��20��6]   $��	0,160,0,0q�6i   $	��Top=�6|   $	��120��6�   6�   �� 5   
   -	   5        $ Createbutton��5      $��Create��6'   $��Center=�68   $��20��6U   $��	0,200,0,0q�6a   $	��Top=�6t   $��85��6�   6�   5      5      
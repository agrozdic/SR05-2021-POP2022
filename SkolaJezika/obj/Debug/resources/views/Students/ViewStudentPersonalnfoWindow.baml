   M S B A M L   `   `   `  ����L  HSR38-2021-POP2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:SkolaJezika.resources.views.Students$SkolaJezika.resources.views.Students  5   	   G    ASkolaJezika.resources.views.Students.ViewStudentPersonalnfoWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:SkolaJezika.resources.views.Students     5   	     � Title$  Licni podaci��5   	   $	��500��6   $	��450��6+   .��5	      � $��25 25 25 25q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $	��Ime��6   $
��Left=�6   $��	-2,-2,0,0q�69   $	��Top=�6L   $��26��6d   $��67��6p   $��1��6{   �� 5   
   -   5        $��txtFirstName��5      $��Center=�6&   $��20��6C    �� TextWrapping$
 Wrap=�6O   $�� ��6c   $	��Top=�6k   $	��380��6�   $��1��6�   $��0,24,0,0q�6�   �� 5   
   $��Prezime��6   $
��Left=�6"   $��	-1,44,0,0q�6=   $	��Top=�6P   $��1��6h   $��26��6u   $��66��6�   �� 5   
   -   5        $��txtLastName��5      $��Center=�6%   $��20��6B   $
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��380��6�   $��1��6�   $��0,70,0,0q�6�   �� 5   
   $��Pol                ��6   $
��Left=�5      $��9,90,0,0q�6-   $	��Top=�6?   $��1��6W   $��26��6d   $��66��6p   �� 5   
   -   5        $��comboGender��5      $
��Left=�6&   $��
13,121,0,0q�6A   $	��Top=�6U   $��81��6m   $��1��6x    �� SelectedItem 6�   �� *Gender+�� 5   
   $��E-mail��6   $
��Left=�6!   $��
10,148,0,0q�6<   $	��Top=�6P   $��1��6h   $��26��6u   $	��189��6�   �� 5   
   -   5        $��txtEmail��5      $��Center=�6"   $��20��6?   $
 Wrap=�6K   $�� ��6_   $	��Top=�6g   $	��380��6   $��1��6�   $��	0,174,0,0q�6�   �� 5   
   $��Adresa��6   $
��Left=�6!   $��	9,252,0,0q�6<   $��1��6O   $	��Top=�6\   �� 5   
   -   5        $��txtStreetAddress��5      $
��Left=�6+   $��20��6F   $
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��178��6�   $��1��6�   $��
13,283,0,0q�6�   �� 5   
   $
��Broj��6   $
��Left=�6   $��201,252,0,0q�6:   $��1��6O   $	��Top=�6\   �� 5   
   -   5        $��txtStreetNumber��5      $
��Left=�6)   $��20��6D   $
 Wrap=�6P   $�� ��6d   $	��Top=�6l   $	��178��6�   $��1��6�   $��201,283,0,0q�6�   �� 5   
   $
��Grad��6   $
��Left=�6   $��	9,308,0,0q�6:   $��1��6M   $	��Top=�6Z   �� 5   
   -   5        $��txtCity��5      $
��Left=�6!   $��20��6<   $
 Wrap=�6H   $�� ��6\   $	��Top=�6d   $	��178��6|   $��1��6�   $��
10,339,0,0q�6�   �� 5   
   $��Drzava��6   $
��Left=�6!   $��201,313,0,0q�6<   $��1��6Q   $	��Top=�6^   �� 5   
   -   5        $��
txtCountry��5      $
��Left=�6$   $��20��6?   $
 Wrap=�6K   $�� ��6_   $	��Top=�6g   $	��178��6   $��1��6�   $��200,339,0,0q�6�   �� 5   
   -	   5        $��	btnCancel��5      $��Odustani��6"   $
��Left=�65   $��23��6P   $��
12,387,0,0q�6\   $��2��6p   $	��Top=�6�   $	��180��6�   6�   �� 5    
   -
   5        $��	btnSubmit��5    #   $��Sacuvaj��6   $
��Left=�64   $��23��6O   $��201,387,0,0q�6[   $��2��6p   $	��Top=�6�   $	��189��6�   6�   �� 5!   
   $��Lozinka��6   $
��Left=�6"   $��
13,199,0,0q�6=   $��1��6Q   $	��Top=�6^   G� 5"   
   -   5        $��txtPassword��5"      $
��Left=�6)   $��22��6D   $��
13,225,0,0q�6P   $��2��6d   $	��Top=�6u   $	��377��6�   5#      5$      
   M S B A M L   `   `   `  ����  SR38-2021-POP20223    -SkolaJezika.resources.views.Admin.AdminWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Admin��5   	   $	��500��6   $
��1000��6$   .��5      � $��125 25 25 25q�6   .+�5	   
   &   System.Windows.Controls.DataGrid  -   5        $��dataStudents��5	   N   $
��Left=�63   $	��180��6b   $��	10,54,0,0q�6o   $	��Top=�6�   $	��349��6�      AutoGenerateColumns .     CanUserAddRows .  ��6   �� *	Student+   Columns 5
      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *PersonalIdentityNumber+  5      $ 
First Name��6%    69   �� *	FirstName+  5      $ 	Last Name��6%    68   �� *
LastName+  5      $ Email��6%    64   �� *Email+  5      $ Gender��6%    65   �� *Gender+5        5   
   -   5        $��dataTeachers��5   ;   $
��Left=�6   $	��180��6.   $��
391,54,0,0q�6O   $	��Top=�6c   $	��336��6{    .   .  ��6�   �� *	Teacher+ 5        5      $ ID��6%    61   �� *PersonalIdentityNumber+  5      $ 
First Name��6%    69   �� *	FirstName+  5      $ 	Last Name��6%    68   �� *
LastName+  5      $ Email��6%    64   �� *Email+  5      $ Gender��6%    65   �� *Gender+  5      $ Working School��6%    6=   �� *WorkingSchool.Name+5      �� 5   
   $��Center=�6   $��-100, 17,0,0q�61   $
��Wrap=�6G   $��Admin��6[   $	��Top=�6h   $
��16px(�6�   �� 5   
   -   5        $��
btnAddress��5   "   $��Adrese��6   $
��Left=�64   $��35��6O   $��215,328,0,0q�6[   $	��Top=�6p   $��90��6�   6�   �� 5   
   -   5        $��
btnSchools��5   !   $��Skole��6   $
��Left=�63   $��35��6N   $��324,328,0,0q�6Z   $	��Top=�6o   $��90��6�   6�   �� 5   
   -   5        $��btnSessions��5   "   $��Casovi��6   $
��Left=�65   $��35��6P   $��439,328,0,0q�6\   $	��Top=�6q   $��90��6�   6�   �� 5    
   -   5        $��btnLanguages��5    "   $��Jezici��6   $
��Left=�66   $��35��6Q   $��554,328,0,0q�6]   $	��Top=�6r   $��90��6�   6�   �� 5!   
   -   5        $��btnCreateTeacher��5!   .   $��Kreiraj nastavnika��6   $
��Left=�6F   $��391,254,0,0q�6a   $	��Top=�6v   $��27��6�   $	��100��6�   6�   �� 5"   
   -   5        $��btnUpdateTeacher��5"   /   $��Azuriraj nastavnika��6   $
��Left=�6G   $��27��6b   $��516,254,0,0q�6n   $	��Top=�6�   $��96��6�   6�   �� 5#   
   -	   5        $��btnDeleteTeacher��5#   .   $��Izbrisi nastavnika��6   $
��Left=�6F   $��27��6a   $��633,254,0,0q�6m   $	��Top=�6�   $��94��6�   6�   �� 5$   
   -
   5        $��btnCreateStudent��5$   ,   $��Kreiraj studenta��6   $
��Left=�6D   $��27��6_   $��
10,254,0,0q�6k   $	��Top=�6   $��99��6�   6�   �� 5%   
   -   5        $��btnUpdateStudent��5%   -   $��Azuriraj studenta��6   $
��Left=�6E   $��27��6`   $��130,254,0,0q�6l   $	��Top=�6�   $	��101��6�   6�   �� 5&   
   -   5        $��btnDeleteStudent��5&   ,   $��Izbrisi studenta��6   $
��Left=�6D   $��27��6_   $��250,254,0,0q�6k   $	��Top=�6�   $	��109��6�   6�   �� 5'   
   -   5        $��btnSearchUsers��5'   .   $��Pretrazi korisnike��6   $
��Left=�6D   $��
96,328,0,0q�6_   $	��Top=�6s   $��35��6�   $��99��6�   6�   �� 5(   
   -   5        $��	btnLogout��5(   "   $��Odjava��6   $
��Left=�63   $��36��6N   $��324,380,0,0q�6Z   $	��Top=�6o   $��90��6�   6�   5)      5*      
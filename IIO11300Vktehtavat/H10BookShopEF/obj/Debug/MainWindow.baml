   M S B A M L   `   `   `  ����H  DBookShopH3247, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:H10BookShopEFH10BookShopEF  5   	       H10BookShopEF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:H10BookShopEF     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��725��6)   .��5	      � .+�5   
   ]� $��Stretch=�6   $��Stretch=�60   ��. .+�5      �� $	��Top=�6    �� Orientation$ 
Horizontal=�6.   .+�5      �� -   5        $��spMenu��5      .+�5      �� -   5        $��btnHaeAsiakkaat��5   8   $��Hae asiakkaat EF ��5      $��28��69   $
��Left=�5      $	��167��6P   $��5,5,5,0q�5      6.   �� 5      -   5        $��btnHaeKirjat��5   \   $��Hae kirjat EF��6   $��28��65   $
��Left=�6A   $	��167��5      $��5,5,5,0q�6*   6;   �� 5      -   5         ��Name$ cbCountries��5      $��26��6L   $��5,5,5,0q�6Y   $y�Hidden=�6j   ��64   �� 6~   5      �� 5      -   5        $��spBook��5      
�������$	��200��6B   $ 
Horizontal=�6Q   .+�5      �� .+�5      �� Tuote6+   �� 5      Nimi6*   �� 5      
Kirjailija60   �� 5      Maa6)   �� 5      Vuosi6+   5      �� 5      $	��200��6!   $
��Left=�60   .+�5      �� -   5        $��txtKirja��5   $   $$��Tw Cen MT Condensed Extra Bold)�6c   $��1q�6�   
���������64   ��  �� Path$ DisplayName� �� Mode$ Oneway=�6�   �� 5       -   5        $��txtNimi��5    "   $$��Tw Cen MT Condensed Extra Bold)�6q   $��1q�6�   ��61   �� $
 name� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5!      -   5        $��txtKirjailija��5!   "   $$��Tw Cen MT Condensed Extra Bold)�6y   $��1q�6�   ��67   �� $ author�$ PropertyChanged=�6�   �� 5"      -	   5        $��txtMaa��5"   "   $$��Tw Cen MT Condensed Extra Bold)�6N   $��1q�6z   ��60   �� $ country�6�   �� 5#      -
   5        $��txtVuosi��5#   "   $$��Tw Cen MT Condensed Extra Bold)�6M   $��40��6y   $��40��6�   $
��Left=�6�   $��1q�6�   ��62   �� $
 year�6�   �� 5$      -   5         ��Name$ btnTallenna��5$   !   $��Tallenna��66   6I   �� 5%      -   5        $ btnUusi��5%   !   $
��Uusi��62   6A   �� 5&      -   5        $ 	btnPoista��5&   !   $��Poista��64   6E   5'      5(      �� 5*      -   5        $��
spCustomer��5*      
����� �$	��200��6A   $ 
Horizontal=�6P   .+�5+      �� .+�5,      �� 	asiakas6-   �� 5-      	etunimi6-   �� 5.      
sukunimi6.   �� 5/      	tilauksia6/   50      �� 51      $	��200��6!   $
��Left=�60   .+�53      �� $$��Tw Cen MT Condensed Extra Bold)�6S   $��1q�6   
���������6$   �� $ DisplayName�$ Oneway=�6�   �� 54      $$��Tw Cen MT Condensed Extra Bold)�6g   $��1q�6�   ��6"   �� $ 	firstname�$ PropertyChanged=�6�   �� 55      $$��Tw Cen MT Condensed Extra Bold)�6f   $��1q�6�   ��6"   �� $ lastname�$ PropertyChanged=�6�   �� 56      $$��Tw Cen MT Condensed Extra Bold)�6u   $��1q�6�   $��20��6�   $
��Left=�6�   ��6"   �� $ 
OrderCount�$ OneWay=�$ PropertyChanged=�6�   �� 57      -   5        $ btnHaeTilaukset��57   !   $��Hae asiakkaan tilaukset��6:   6\   58      59      5:      �� 5;      $��Bottom=�6   .@�5<      �� -   5        $��	tbMessage��5<      $��Tähän ilmoitukset��6-   $��32��6F   5=      &   System.Windows.Controls.DataGrid  5>      -   5        $��dgBooks��5?   (      AutoGenerateColumns . $
��Auto��5>   2   $
��Left=�6@   $��5,5,5,5q�5?      $	��Top=�67   $
��Auto��6O   ��5@      �� 6/   5A      5C      5D      
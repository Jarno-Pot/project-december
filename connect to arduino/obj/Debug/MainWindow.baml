   M S B A M L   `   `   `  ����M  Iconnect to arduino, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:connect_to_arduinoconnect_to_arduino  5   	   #    connect_to_arduino.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:connect_to_arduino     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��500��6)    � 
ResizeMode$ NoResize=�65   .��5	      �� .+�5
   
   �� $��Seriele connectie��6   $��20(�6.   $��10q�6<   .��5      �� .+�5      �� -   5        $��combox��5      $	��120��6)   $��30��65   $
��Left=�6A   $��10q�6\   $��16(�6h   6x   �� 5      -   5         ��Name$
 bcom��5      $	��150��6'   $��30��63   $
��Left=�6?   $��10q�6Z   $��connect/disconnect��6f   $��16(�5      6<   5      5      �� 5   
   $��lcd console��6   $��10q�6(   $��20(�64   .��5      �� .+�5      �� -   5         ��Name$
 box1��5      $��10q�6(   $��30��64   $��16(�6@   6P   �� 5      -   5        $ bwrite��5      $��tekst naar lcd��6)   $��16(�6B   $��30��6P   $	��120��6\   $
��Left=�6h   $��10q�5      6<   �� 5      -   5        $ bcalc��5      $��bereken��6(   $��16(�6:   $��30��6H   $	��120��6T   $
��Left=�6`   $��10q�5      6;   5      5      5      5      
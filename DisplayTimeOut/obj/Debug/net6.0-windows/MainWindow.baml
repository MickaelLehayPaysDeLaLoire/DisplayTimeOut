   M S B A M L   `   `   `  ����I  EDisplayTimeOut, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DisplayTimeoutDisplayTimeout  5   	       DisplayTimeout.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:DisplayTimeout     5   	     � Title$  Arret��5   	   $	��400��6   $	��600��6$    � 
ResizeMode$ NoResize=�60    � Topmost$
 True��6F    � WindowStartupLocation$ CenterScreen=�6U   .��5	      � $��	4,0,10,11q�6    � ColumnDefinitions 5
   
   �� 5      $	��22* �6   �� 5      $
��271* �6    � RowDefinitions 5   
   �� 5      $��0* �6   �� 5      .+�5   
   �� $
��Left=�6   $	��346��6+   $��Center=�68   $	��562��6S   $)��#/istockphoto-1311617386-612x612.jpg��6_   $��1��6�    J� Opacity$	 0.5Q�6�   $
��Fill=�6�   $��2��6�   $��12,0,0,0q�6�   �� 5   
   -   5         ��Name$ Bouton_Annuler��5      $&�� Annuler l'arrêt de l'ordinateur��6)   $
��Left=�6S   $	��Top=�6n   $	��540��6�   $��
23,234,0,0q�6�   $��87��6�   $��1��6�   $��22(�6�   $
��Bold"�6�   $	 0.6Q�6�   $��2��6  �� 5   
   -   5         ��Name$ CountDownLabel��5      $!��arrêt de l'ordinateur dans��6(   $
��Left=�6M   $��
34,162,0,0q�6h   $	��Top=�6|   $	��518��6�   $��22(�6�   $��1��6�   $��72��6�   $��Center=�6�   
���  ��$
��Bold"�6�   $��2��6  �� 5   
   -   5        $ Message1��5      $
��Left=�6"   $��
34,103,0,0q�6=   $��2��6Q   $@��:Cet ordinateur n'est plus utilisé depuis un certain temps��6b   $	��Top=�6�   $	��518��6�   $��70��6�   $��20(�6�   $��Center=�6�   $��2��6  �� 5   
   -   5        	 ��Name$
	 Logo��5      $
��Left=�6   $	��107��69   $��	10,11,0,0q�6F   $��2��6Y   $	��Top=�6j   $	��184��6�   $��2��6�   �� 5   
   -   5        $ Credits��5      $(��"Programme créé par Mickael LEHAY��6!   $
��Left=�6L   $��296,321,0,0q�6g   $��2��6|   $	��Top=�6�   $
��Bold"�6�   $��1��6�   5      5      
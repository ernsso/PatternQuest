   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   > :RPG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null&clr-namespace:RPG;assembly=RPGRPG 5   	   > :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI 5   	      GUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   .rpgclr-namespace:RPG;assembly=RPG     5   	   !guiclr-namespace:GUI     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   -   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6j     � Title$  
MainWindow��6	    � SizeToContent$ WidthAndHeight=�6�    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius	 �� Triggers
 P� Property P� Value �� 
TargetName��%�  '��       �� 5	   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $	 bdr��6!   $ 22��6.   $��3q�6@   $��1q�6K   
���   �
�������._�5      �� $��Center=�6/   $��Center=�6J   $��Content��6g   $��20(�6   5      	 5      P� 5      
 �@J�IsMouseOver . . �5   "   �� $	 bdr��6)    � ��
 �����6P   5      5      5      5      5      .��5      ��  �� Orientation$ 
Horizontal=�6   $	��698��6*   .+�5   
   �� -   5        $��SimpleSimulation_Button��5      $��10q�60   $��Simulation déplacement��6<   $	��240��6�   �� 5    
   -   5        $ ��LabyrinthSimulation_Button��5       $��10q�63   $��Simulation labyrinthe��6?   $	��212��6�   �� 5!   
   -   5        $��QuestSimulation_Button��5!      $��10q�6/   $��Simulation spéciale��6;   $	��186��6~   5"      5#      
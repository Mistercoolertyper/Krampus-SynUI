   M S B A M L   `   `   `  ����I  ESynapse UI WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Synapse_UI_WPFSynapse_UI_WPF  5   	       Synapse_UI_WPF.LoadWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Synapse_UI_WPF     5   	   -   5          � Title$  Synapse X - Loader��5   	    � 
ResizeMode$ NoResize=�6$   $��116.685��6:   $��418.203��6K    � Topmost .  � WindowStyle$
 None=�6j   ���	#FF333333.��5	      � $	��116��6   $��0,-3,0,0q�6   $	��Top=�6*   $
��Left=�6B   $	��421��6]    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � -   5        $��TopBox��5      $
��Left=�6   $��37��68   ���	#FF3C3C3C$��Center=�6[   $	��426��6v   $��2��6�   $��
0,0,-0.4,0q�6�   .+�5      �� -   5        $��TitleBox��5      $��Synapse X - Loader��6$   $��Center=�6A   $��0,6,0,0q�6^   $	��Top=�6o   
�������6�   �� 5      -   5        $��IconBox��5      $#��sxlogosmallwhite_OJJ_icon.ico��6#   $
��Left=�6J   $��8,4,0,0q�6e   $	��Top=�6v   5      �� 5   
   -   5        $��	StatusBox��5      $��Initializing...��6!   $��Center=�6;   $��
0,10.2,0,0q�6X   $��1��6l   $	��Top=�6y   
�������$��14(�6�   � 5   
   -   5        $��ProgressBox��5      $
��Left=�6)   $��21��6D   $��19,44.2,0,0q�6P   $��1��6e   $	��Top=�6r   $	��387��6�   5      5      
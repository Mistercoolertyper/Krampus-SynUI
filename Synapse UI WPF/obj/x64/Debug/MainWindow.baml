   M S B A M L   `   `   `  ����I  ESynapse UI WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Synapse_UI_WPFSynapse_UI_WPF  5   	   V RCefSharp.Wpf, Version=73.1.130.0, Culture=neutral, PublicKeyToken=40c4b6fc221f4138A0clr-namespace:CefSharp.Wpf;assembly=CefSharp.WpfCefSharp.Wpf 5   	   A%clr-namespace:Synapse_UI_WPF.ControlsSynapse_UI_WPF.Controls  5   	       Synapse_UI_WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Synapse_UI_WPF     5   	   @Wpf0clr-namespace:CefSharp.Wpf;assembly=CefSharp.Wpf     5   	   :controls%clr-namespace:Synapse_UI_WPF.Controls     5   	   -   5          � Title$  	Synapse X��5   	    � 
ResizeMode$ NoResize=�6    � SizeToContent$ WidthAndHeight=�61    � UseLayoutRounding . $	��355��6i   $	��801��6v    � Topmost .  � WindowStyle$
 None=�6�   ���	#FF333333���	#FF333333.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6    � LayoutTransform 5   
   �� 5      -   5        ScaleTransform��	 �� ScaleX$		 1.0Q�5   5   
 �� ScaleY$	
 1.0Q�6B    �� CenterX$	 1.0Q�6O    �� CenterY$	 1.0Q�6]   .+�5   
   � -   5        $��TopBox��5      $
��Left=�6   $��30��68   $��0,0,0,0q�6D   $	��Top=�6U   $	��801��6m   ���	#FF3C3C3C.+�5      �� -   5        $��TitleBox��5      $��Synapse X - v1.0.0��6$   $��Center=�6A   $��0,0,0,0q�6^   $��Center=�6o   
�������6�   �� 5      -   5        $��CloseButton��5      $��X��6(   #��[" �64   $��Right=�6o   $	��Top=�6�   $��22��6�   
�������6�   �� 5      -   5        $��
MiniButton��5      $��_��6'   #��[" �63   $��Right=�6n   $	��Top=�6�   $��22��6�   
�������$��0,0,22,0q�6�   6�   �� 5      -   5         ��Name$ IconBox��5      $#��sxlogosmallwhite_OJJ_icon.ico��6%   $
��Left=�6L   $��6,1,0,0q�6g   $	��Top=�6x   6�   5      $   Synapse_UI_WPF.Controls.Monaco  5    
   -   5          Name$ Browser��5       $   Synapse_UI_WPF.Controls.Monaco   MonacoReady$ Browser_MonacoReady��6�    �� BitmapScalingMode$ HighQuality=�6+   $
��Left=�6Y   $	��252��6t   $��	10,25,0,0q�6�   $��1��6�   $	��Top=�6�   $	��658��6�   6�   �� 5"   
   -	   5        $��	ScriptBox��5"      $��0q�6#   $
��Left=�67   $	��272��6R   $��673,4.6,0,0q�6_   $��1��6t   $	��Top=�6�   $	��122��6�   ���	#FF3C3C3C
������� � ContextMenu 5#      �� 5$      .@�5%      m� -
   5        $��ExecuteItem��5%      $��Execute��62   6C   m� 5&      -   5        $��LoadItem��5&      $��Load to Editor��6/   6G   m� 5'      -   5        $��RefreshItem��5'      $��Refresh��62   6C   5(      5*      �� 5,   
   -   5        $��ExecuteButton��5,      #��[" �6&   $��Execute��6a   $
��Left=�6s   $��10,281.6,0,0q�6�   $��1��6�   $��Center=�6�   $	��Top=�6�   $��91��6�   $��33��6�   ���	#FF3C3C3C
�������$��14(�6,  6:  �� 5-   
   -   5        $��ClearButton��5-      #��[" �6$   $��Clear��6_   $
��Left=�6o   $��106,281.6,0,0q�6�   $��1��6�   $��Center=�6�   $	��Top=�6�   $��91��6�   $��33��6�   ���	#FF3C3C3C
�������$��14(�6)  67  �� 5.   
   -   5        $��OpenFileButton��5.      #��[" �6'   $��	Open File��6b   $
��Left=�6v   $��202,281.6,0,0q�6�   $��1��6�   $��Center=�6�   $	��Top=�6�   $��91��6�   $��33��6�   ���	#FF3C3C3C
�������$��14(�60  6>  �� 5/   
   -   5        $��ExecuteFileButton��5/      #��[" �6*   $��Execute File��6e   $
��Left=�6|   $��298,281.6,0,0q�6�   $��1��6�   $��Center=�6�   $	��Top=�6�   $��91��6�   $��33��6   ���	#FF3C3C3C
�������$��14(�66  6D  �� 50   
   -   5        $��SaveFileButton��50      #��[" �6'   $��	Save File��6b   $
��Left=�6v   $��394,281.6,0,0q�6�   $��1��6�   $��Center=�6�   $	��Top=�6�   $��91��6�   $��33��6�   ���	#FF3C3C3C
�������$��14(�60  6>  �� 51   
   -   5        $��OptionsButton��51      #��[" �6&   $��Options��6a   $
��Left=�6s   $��490,281.6,0,0q�6�   $��1��6�   $��Center=�6�   $	��Top=�6�   $��91��6�   $��33��6�   ���	#FF3C3C3C
�������$��14(�6-  6;  �� 53   
   -   5        $��AttachButton��53      #��[" �6%   $��Attach��6`   $
��Left=�6q   $��608,281.6,0,0q�6�   $��1��6�   $��Center=�6�   $	��Top=�6�   $��91��6�   $��33��6�   ���	#FF3C3C3C
�������$��14(�6+  69  �� 54   
   -   5        $��ScriptHubButton��54      #��[" �6(   $��
Script Hub��6c   $
��Left=�6x   $��704,281.6,0,0q�6�   $��1��6�   $��Center=�6�   $	��Top=�6�   $��91��6�   $��33��6�   ���	#FF3C3C3C
�������$��14(�62  6@  �� 57   
   -   5        $��BottomControl��57      $y�Hidden=�6%   $	��AAA��69   $
��Left=�6G   $��10,312.6,0,2.2q�6b   $��1��6z   $��1(�6�   �� 58   
   -   5         ��Name$ 	TabSystem��58   {   $��1��6   $��10,0,133,299q�6e   $	��658��6�   $��25��6�   ��6"   Z� ��68   Z� ��6O   Z� .@�59      �� -   5         ��Name$ AddTabButton��59   !   $��+��6   ���#696969���#FFFFFF���#5454545:      5;      5<      5=      
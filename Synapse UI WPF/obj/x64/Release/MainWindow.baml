   M S B A M L   `   `   `  ���� I  ESynapse UI WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Synapse_UI_WPFSynapse_UI_WPF  V RCefSharp.Wpf, Version=73.1.130.0, Culture=neutral, PublicKeyToken=40c4b6fc221f4138A0clr-namespace:CefSharp.Wpf;assembly=CefSharp.WpfCefSharp.Wpf A%clr-namespace:Synapse_UI_WPF.ControlsSynapse_UI_WPF.Controls      Synapse_UI_WPF.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:Synapse_UI_WPF     @Wpf0clr-namespace:CefSharp.Wpf;assembly=CefSharp.Wpf     :controls%clr-namespace:Synapse_UI_WPF.Controls     -     � Title$  	Synapse X�� � 
ResizeMode$ NoResize=� � SizeToContent$ WidthAndHeight=� � UseLayoutRounding . $	��355��$	��801�� � Topmost .  � WindowStyle$
 None=����	#FF333333���	#FF333333.���  � RowDefinitions �� $
��Auto ��� $��* � � ColumnDefinitions �� $��* ��� $
��Auto � � LayoutTransform �� -   ScaleTransform��	 �� ScaleX$		 1.0Q�
 �� ScaleY$	
 1.0Q� �� CenterX$	 1.0Q� �� CenterY$	 1.0Q�.+�� -   $��TopBox��$
��Left=�$��30��$��0,0,0,0q�$	��Top=�$	��801�����	#FF3C3C3C.+��� -   $��TitleBox��$��Synapse X - v1.0.0��$��Center=�$��0,0,0,0q�$��Center=�
��������� -   $��CloseButton��$��X��#��[" �$��Right=�$	��Top=�$��22��
��������� -   $��
MiniButton��$��_��#��[" �$��Right=�$	��Top=�$��22��
�������$��0,0,22,0q��� -    ��Name$ IconBox��$#��sxlogosmallwhite_OJJ_icon.ico��$
��Left=�$��6,1,0,0q�$	��Top=�$   Synapse_UI_WPF.Controls.Monaco  -     Name$ Browser��$   Synapse_UI_WPF.Controls.Monaco   MonacoReady$ Browser_MonacoReady�� �� BitmapScalingMode$ HighQuality=�$
��Left=�$	��252��$��	10,25,0,0q�$��1��$	��Top=�$	��658���� -	   $��	ScriptBox��$��0q�$
��Left=�$	��272��$��673,4.6,0,0q�$��1��$	��Top=�$	��122�����	#FF3C3C3C
������� � ContextMenu �� .@�m� -
   $��ExecuteItem��$��Execute��m� -   $��LoadItem��$��Load to Editor��m� -   $��RefreshItem��$��Refresh���� -   $��ExecuteButton��#��[" �$��Execute��$
��Left=�$��10,281.6,0,0q�$��1��$��Center=�$	��Top=�$��91��$��33�����	#FF3C3C3C
�������$��14(��� -   $��ClearButton��#��[" �$��Clear��$
��Left=�$��106,281.6,0,0q�$��1��$��Center=�$	��Top=�$��91��$��33�����	#FF3C3C3C
�������$��14(��� -   $��OpenFileButton��#��[" �$��	Open File��$
��Left=�$��202,281.6,0,0q�$��1��$��Center=�$	��Top=�$��91��$��33�����	#FF3C3C3C
�������$��14(��� -   $��ExecuteFileButton��#��[" �$��Execute File��$
��Left=�$��298,281.6,0,0q�$��1��$��Center=�$	��Top=�$��91��$��33�����	#FF3C3C3C
�������$��14(��� -   $��SaveFileButton��#��[" �$��	Save File��$
��Left=�$��394,281.6,0,0q�$��1��$��Center=�$	��Top=�$��91��$��33�����	#FF3C3C3C
�������$��14(��� -   $��OptionsButton��#��[" �$��Options��$
��Left=�$��490,281.6,0,0q�$��1��$��Center=�$	��Top=�$��91��$��33�����	#FF3C3C3C
�������$��14(��� -   $��AttachButton��#��[" �$��Attach��$
��Left=�$��608,281.6,0,0q�$��1��$��Center=�$	��Top=�$��91��$��33�����	#FF3C3C3C
�������$��14(��� -   $��ScriptHubButton��#��[" �$��
Script Hub��$
��Left=�$��704,281.6,0,0q�$��1��$��Center=�$	��Top=�$��91��$��33�����	#FF3C3C3C
�������$��14(��� -   $��BottomControl��$y�Hidden=�$	��AAA��$
��Left=�$��10,312.6,0,2.2q�$��1��$��1(��� -    ��Name$ 	TabSystem��$��1��$��10,0,133,299q�$	��658��$��25����Z� ��Z� ��Z� .@��� -    ��Name$ AddTabButton��$��+�����#696969���#FFFFFF���#545454
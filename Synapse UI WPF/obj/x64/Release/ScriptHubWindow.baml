   M S B A M L   `   `   `  ���� I  ESynapse UI WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Synapse_UI_WPFSynapse_UI_WPF  $    Synapse_UI_WPF.ScriptHubWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:Synapse_UI_WPF     -     � Title$  Synapse X - Script Hub�� � 
ResizeMode$ NoResize=� � Topmost .  � WindowStyle$
 None=�$	��336��$	��439�����	#FF333333.���  � RowDefinitions �� $
��Auto ��� $��* � � ColumnDefinitions �� $��* ��� $
��Auto �.+�� -   $��TopBox��$
��Left=�$��30��$��0,0,0,0q�$	��Top=�$	��439�����	#FF3C3C3C.+��� -   $��TitleBox��$��Synapse X - Script Hub��$��Center=�$��0,0,0,0q�$��Center=�
��������� -    ��Name$ IconBox��$#��sxlogosmallwhite_OJJ_icon.ico��$
��Left=�$��2,0,0,0q�$	��Top=��� -   $��
MiniButton��$��_��#��[" �$��Right=�$	��Top=�$��22��
��������� -   $��	ScriptBox��$��0q�$
��Left=�$	��286��$��
10,9.6,0,0q�$��1��$	��Top=�$	��115�����	#FF3C3C3C
��������� -   $��ScriptPictureBox��$
��Left=�$	��170��$��130,9.6,0,0q�$��1��$	��Top=�$	��299���� -   $��DescriptionBox�� �� 
IsReadOnly . $��0q�$
��Left=�$��80��$��130,184.6,0,0q�$��1�� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��299�����	#FF1E1E1E
��������� -	   $��ExecuteButton��$��Execute��#��[" ����	#FF3C3C3C$
��Left=�$��130,269.6,0,0q�$��1��$	��Top=�$	��149��
�������$��26���� -
   $��CloseButton��$��Close��#��[" ����	#FF3C3C3C$
��Left=�$��284,269.6,0,0q�$��1��$	��Top=�$	��145��
�������$��26��
   M S B A M L   `   `   `  ����B  >MainApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MainAppMainApp  5          MainApp.Signal   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:MainApp     5        � 	Resources  5	      %   MainApp.SignalFontSizeConventer   SignalFontSizeConventer��%   &	          5
   
   6(   5      .��5      �� 
���   �$��1q�6!    �� CornerRadius$ 10,10,10,10��65   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF70B473��6    � Offset$ 0.854Q�61   � 5      $ 	Gainsboro��6   $ 0.673Q�61   � 5      $ White��6   $
 0.58Q�6-   � 5      $ 	#FF19651D��6   $ 0.981Q�61   5      ._�5   
   �  � RowDefinitions 5      �� 5      $��3* �6    �� 5      .+�5      �� -   5         ��Name$	 Img��5      �� 5      -   5         ��Name$ 	TypeLabel��5      $��1��5      $	��Top=�5      $
��Bold"�5      $��Center=�6&   $��Microsoft Sans Serif)�5      
���������5!      �� 	 �� ElementName$	 	TypeLabel��
 �� Path$
 ActualHeight� �� 	Converter# [  5"      5#      5$      
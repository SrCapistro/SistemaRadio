   M S B A M L   `   `   `  ����I  ESistemaDeRadio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SistemaDeRadioSistemaDeRadio  5   	       SistemaDeRadio.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SistemaDeRadio     5   	     � Title$  
MainWindow��5   	   $	��450��6   $��700         ��6)   .��5
      � .+�5   
   �� $
��Left=�6   $	��420��6+   $	��Top=�68   $	��280��6P   $2��,/SistemaDeRadio;component/Recursos/login.jpg��6\   �� 5   
   $
��Left=�6   $	��110��60   $��	280,0,0,0q�6=   $	��Top=�6P   $	��414��6h   ���	#FF14213D6t   �� 5   
   $��Inicio de sesión��6   $
��Left=�6+   $��
331,29,0,0q�6F   $	��Top=�6Z   $��52��6r   $	��325��6~   $��Arial Black)�6�   $
��Bold"�6�   $��36(�6�   
�������6�   �� 5   
   $
��Left=�6   $��53��6+   $��307,144,0,0q�67   $	��Top=�6L   $��55��6d   $0��*/SistemaDeRadio;component/Recursos/usr.png��6o    J� RenderTransformOrigin$ 0.308,0.558&�6�   �� 5   
   $
��Left=�6   $��56��6+   $��307,223,0,0q�67   $	��Top=�6L   $��55��6d   $1��+/SistemaDeRadio;component/Recursos/pass.png��6o   $ 0.848,0.577&�6�   �� 5   
   -   5         ��Name$ txt_usuario��5      $
��Left=�6'   $��39��6B   $��20(�6N   $��388,149,0,0q�6\    �� TextWrapping$
 Wrap=�6q   $	��Top=�6�   $	��268��6�   .��6�   ��5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   -   �� 6   6sys&clr-namespace:System;assembly=mscorlib     6-    �� 
TargetType" ��6    �� 	Resources 5         CueBannerBrush j� 
AlignmentX j� 
AlignmentY j� Stretch	 !� Visual��%�   &	        !� 5      $
 Left=�6=   $ Center=�6O   $
 None=�6c   	 5      �� 5   "   $��Usuario��6(   $��20(�6:   
�������6H   5      5      
 �� Triggers
 5      P� 5       P� Property � �� �� Empty P� Value# Z 62   . �5      ��  �� Property � �� �� Value# [  6;   5      P� 5       � �� 62   Z� . �5       ��  � ��# [  6;   5!      P� 5"       �@J�IsKeyboardFocused . . �5#      ��  � ��
 �����6;   5$      5&      .��5'      5(      G� 5*   
   -   5         G�Name$ txt_contraseña��5*      $
��Left=�6.   $��388,231,0,0q�6I   $	��Top=�6^   $	��268��6v   $��39��6�   �� 5,   
   -   5         ��Name$ btn_iniciarSesion��5,      $��Iniciar sesión��6,   $
��Left=�6E   $��433,299,0,0q�6`   $	��Top=�6u   $	��149��6�   ���	#FF14213D
�������$��47��6�   $��Arial)�6�   $��20(�6�   $
��Bold"�6�   6  �� 5-   
   -   5         ��Name$ lb_mensajes��5-      $��¡DATOS FALTANTES!��6%   $
��Left=�6A   $��443,371,0,0q�6\   $	��Top=�6q   $��Arial)�6�   $	��139��6�   $ 0.424,0.553&�6�   
�������
���  ��$
��Bold"�6�   $y�Hidden=�6  5.      5/      
   M S B A M L   `   `   `  ����I  ESistemaDeRadio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SistemaDeRadio.VentanasSistemaDeRadio.Ventanas  5   	   )    #SistemaDeRadio.Ventanas.PatronCusom   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:SistemaDeRadio.Ventanas     5   	     � Title$  PatronCusom��5   	   $	��450��6   $	��800��6*   .��5	      � .+�5
   
   �� ���	#FF14213D$��	0,0,0,341q�6,   .+�5      �� -   5         ��Name$ lbTituloVentana��5      $��Registrar patrón��6-   
�������$��50(�6[   $��Center=�6i   $��5q�6�   $��	ExtraBold"�6�   $��83��6�   5      �� 5   
   -   5         ��Name$ tbNombrePatron��5      $
��Left=�6*   $��20(�6E   $��
10,100,0,0q�6T    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��190��6�   $��32��6�   .��6�   ��5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   -   �� 6   6sys&clr-namespace:System;assembly=mscorlib     6-    �� 
TargetType" ��6    �� 	Resources 5         CueBannerBrush j� 
AlignmentX j� 
AlignmentY j� Stretch	 !� Visual��%�   &	        !� 5      $
 Left=�6=   $ Center=�6O   $
 None=�6c   	 5      �� 5   "   $��Nombre del patrón��6(   $��20(�6D   
�������6R   5      5      
 �� Triggers
 5      P� 5       P� Property � �� �� Empty P� Value# Z 62   . �5      ��  �� Property � �� �� Value# [  6;   5      P� 5       � �� 62   Z� . �5      ��  � ��# [  6;   5      P� 5       �@J�IsKeyboardFocused . . �5       ��  � ��
 �����6;   5!      5#      .��5$      5%      &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ tablaLineas��5'      $��18(�6(   $��0,150,0,125q�66      FrozenColumnCount$ 3��6K      
IsReadOnly . 6a   �� 5(   
   $ ��Añade lineas del patrón:��6   $��18(�63   $
��Left=�6A   $��
214,99,0,0q�6\   $	��Top=�6p   $��32��6�   $	��237��6�   �� 5*   
   -   5         ��Name$ cbCategorias��5*      $��18(�6)   $
��Left=�67   $��430,100,0,0q�6R   $	��Top=�6g   $	��128��6   $��32��6�   6�   �� 5,   
   -   5        $ 	cbGeneros��5,      $��18(�6&   $
��Left=�65   $��577,100,0,0q�6P   $	��Top=�6e   $	��127��6}   $��32��6�   6�   �� 5.   
   -   5         ��Name$ btnAñadirLinea��5.      $
��Left=�6)   $��713,101,0,0q�6D   $	��Top=�6Y   $��30��6q   $��39��6}    � 	Resources 5/      ��%_   '��       �� 50      " ��6   .�51      ��  �@��CornerRadius$ 10��65   52      53      .��54      �� .+�55      �� $
��Fill=�6   $��/Ventanas/crear.png��6(   $��20��6E   $��28��6Q   56      57      �� 59   
   ���	#FF14213D$��	0,364,0,0q�6,   .+�5:      �� -   5        $ btnCancelar��5:      $��Cancelar��6*   ���	#FF8C0000$��18(�6T   $��10q�6b   $
��Bold"�6n   
�������$	��150��6�   $��35��6�    5;      ��%_   '��       �� 5<      " ��6   .�5=      ��  �@��CornerRadius$ 10��69   5>      5?      5@      5A      �� 5C   
   -   5        $ btnGuardarPatron��5C      $
��Left=�6+   $��694,314,0,0q�6F   $	��Top=�6[   $��45��6s   $��58��6    5D      ��%_   '��       �� 5E      " ��6   .�5F      ��  �@��CornerRadius$ 10��65   5G      5H      .��5I      �� .+�5J      �� $
��Fill=�6   $��/Recursos/guardar.png��6(   $��38��6G   $��48��6S   5K      5L      �� 5N   
   -	   5        $ btnEliminarLinea��5N      $
��Left=�6+   $��
10,316,0,0q�6F   $	��Top=�6Z    5O      ��%_   '��       �� 5P      " ��6   .�5Q      ��  �@��CornerRadius$ 10��65   5R      5S      .��5T      �� .+�5U      �� $
��Fill=�6   $��/Recursos/eliminar.png��6(   $��38��6H   $��48��6T   5V      5W      �� 5X   
   -
   5         ��Name$ chbNuevasCanciones��5X      $��Generar nuevas canciones��6/   $
��Left=�6R   $��522,329,0,0q�6m   $	��Top=�6�   5Z      5[      
   M S B A M L   `   `   `  ����I  ESistemaDeRadio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SistemaDeRadio.VentanasSistemaDeRadio.Ventanas  5   	   2    ,SistemaDeRadio.Ventanas.VisualizarCronograma   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:SistemaDeRadio.Ventanas     5   	     � Title$  VisualizarCronograma��5   	   $	��554��6&   $	��891��63   .��5	      � .+�5
   
   �� $
��Left=�6   $��81��60   $	��Top=�6<   $	��886��6T   ���	#FF14213D$��
0,0,-0.4,0q�6w   .+�5      �� $��Cronograma del Dia��6   $��50(�61   $
��Bold"�6?   
�������$��Center=�6d   5      �� 5   
   -   5         ��Name$ btnRegresar��5      $��Regresar��6&   $
��Left=�69   $��
50,468,0,0q�6T   $	��Top=�6h   $	��125��6�   ���	#FF8C0000
�������$��Arial)�6�   $��18(�6�   $
��Bold"�6�   $��30��6�    � 	Resources 5       �� 
TargetType �� Property �� Value��%^   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 7��65   5      5      5      �� 5   
   $��Elementos por programa��6   $
��Left=�61   $��329,101,0,0q�6L   $	��Top=�6a   $��18(�6y   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgSegunPrograma��5      $
��Left=�6,   $	��249��6G   $��329,159,0,0q�6T   $	��Top=�6i   $	��514��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Elemento��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 67   �� *NombreElemento+  5      $ Comentarios��6%   	 6:   �� *Comentarios+  5      $ Patrón��6%   	 65   �� *NombrePatron+5      �� 5   
   -   5        
 ��Name$
 lbFecha��5      $�� ��6!   $
��Left=�6,   $��
10,101,0,0q�6G   $	��Top=�6[   $��18(�6s   $	��225��6�     5   
   -   5        $ dgProgramas��5      $
��Left=�6(   $	��249��6C   $��
25,159,0,0q�6P   $	��Top=�6d   $	��264��6|    5        5      $ Programas del Dia��6%   	 6@   �� *NombrePrograma+  5       $ Inicio��6%   	 65   �� *
HoraInicio+  5!      $	 Fin��6%   	 62   �� *	HoraFin+5#      �� 5$   
   -   5        $ btnGenerarPdf��5$      $��Generar Reporte��6(   $
��Left=�6B   $��660,468,0,0q�6]   $	��Top=�6r   $	��183��6�   
��� � �
�������$��Arial)�6�   $��18(�6�   $
��Bold"�6�   $��30��6�    5%      ��%^   '��       �� 5&      " ��6   .�5'      ��  �@��CornerRadius$ 7��65   5(      5)      5*      5+      5,      
   M S B A M L   `   `   `  ����I  ESistemaDeRadio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SistemaDeRadio.VentanasSistemaDeRadio.Ventanas  5   	   :    4SistemaDeRadio.Ventanas.VisualizarInfoProgramaActivo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:SistemaDeRadio.Ventanas     5   	     � Title$"  VisualizarInfoProgramaActivo��5   	   $	��600��6.   $	��700��6;   .��5	      � .+�5
   
   �� $
��Left=�6   $��81��60   $	��Top=�6<   $	��692��6T   ���	#FF14213D.+�5      �� $��Detalles Programa Activo��6   $��40(�67   $
��Bold"�6E   
�������$��Center=�6j   $��
109,0,46,0q�6�   $	��537��6�   5      �� 5   
   -   5         ��Name$ btnRegresar��5      $��Regresar��6&   $
��Left=�69   $��277,529,0,0q�6T   $	��Top=�6i   $	��125��6�   ���	#FF8C0000
�������$��Arial)�6�   $��18(�6�   $
��Bold"�6�   $��30��6�    � 	Resources 5       �� 
TargetType �� Property �� Value��%^   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 7��65   5      5      5      �� 5   
   $��Nombre del Programa: ��6   $
��Left=�60   $��	89,96,0,0q�6K   $	��Top=�6^   $��18(�6v   $
��Bold"�6�   �� 5   
   $��Hora de inicio: ��6   $
��Left=�6+   $��160,135,0,0q�6F   $	��Top=�6[   $��18(�6s   $
��Bold"�6�   �� 5   
   $��Hora de Fin: ��6   $
��Left=�6(   $��180,174,0,0q�6C   $	��Top=�6X   $��18(�6p   $
��Bold"�6~   �� 5   
   $��Dia Programado: ��6   $
��Left=�6+   $��140,213,0,0q�6F   $	��Top=�6[   $��18(�6s   $
��Bold"�6�   �� 5   
   $��Estación Actual: ��6   $
��Left=�6,   $��152,252,0,0q�6G   $	��Top=�6\   $��18(�6t   $
��Bold"�6�   $	��159��6�   �� 5   
   -   5         ��Name$ lbNombrePrograma��5      $.��(No existe un programa activo actualmente��6*   $
��Left=�6]   $��
322,96,0,0q�6x   $	��Top=�6�   $��18(�6�   �� 5   
   -   5        $ lbHoraInicio��5      $�� ��6&   $
��Left=�61   $��322,135,0,0q�6L   $	��Top=�6a   $��18(�6y   $	��246��6�   �� 5   
   -   5        $ 	lbHoraFin��5      $�� ��6#   $
��Left=�6.   $��322,174,0,0q�6I   $	��Top=�6^   $��18(�6v   $	��208��6�   �� 5   
   -   5        $ lbDiaProgramado��5      $�� ��6)   $
��Left=�64   $��323,213,0,0q�6O   $	��Top=�6d   $��18(�6|   $	��100��6�   �� 5   
   -   5        $ 
lbEstacion��5      $�� ��6$   $
��Left=�6/   $��322,252,0,0q�6J   $	��Top=�6_   $��18(�6w   $	��246��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgElementos��5      $
��Left=�6(   $	��200��6C   $��
26,308,0,0q�6P   $	��Top=�6d   $	��643��6|      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn	   Header$	 Elemento��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 67   �� *NombreElemento+  5!      $	 Comentarios��6%   
 6:   �� *Comentarios+  5"      $	 Patrón��6%   
 65   �� *NombrePatron+5$      5%      5&      
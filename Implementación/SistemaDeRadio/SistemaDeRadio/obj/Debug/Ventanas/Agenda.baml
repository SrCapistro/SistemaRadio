   M S B A M L   `   `   `  ����I  ESistemaDeRadio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SistemaDeRadio.VentanasSistemaDeRadio.Ventanas  5   	   $    SistemaDeRadio.Ventanas.Agenda   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:SistemaDeRadio.Ventanas     5   	     � Title$  Agenda��5   	   $��577.83��6   $��724.052��6(   .��5	      � $��
0,0,-0.4,1q�6   .+�5
   
   �� $
��Left=�6   $	��102��60   $	��Top=�6=   $	��718��6U   ���	#FF14213D.+�5      �� $��Agenda��6   $��Center=�6%   $��Center=�6B   $��50(�6]   $
��Bold"�6k   
�������6}   5      �� 5   
   $��Agenda del día: ��6   $
��Left=�6+   $��
29,165,0,0q�6F   $	��Top=�6Z   $��Arial)�6r   $��18(�6�   �� 5   
   -   5         ��Name$ lbDiaSeleccionado��5      $#��Aquí va el día seleccionado��6+   $
��Left=�6Q   $��170,165,0,0q�6l   $	��Top=�6�    J� RenderTransformOrigin$ -0.002,0.552&�6�   $��Arial)�6�   $��18(�6�   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgProgramasAgendados��5      $
��Left=�61   $	��255��6L   $��
29,208,0,0q�6Y   $	��Top=�6m   $	��660��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre del programa��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 360 6f   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *NombrePrograma+6f     5      $ Hora de inicio��6%   $	 150 6]    6=   �� *
HoraInicio+6]     5      $ Hora de fin��6%   $	 150 6W    6:   �� *	HoraFin+6W   5      �� 5   
   -   5         ��Name$ btnRegresar��5      $��Regresar��6&   $
��Left=�69   $��
29,507,0,0q�6T   $	��Top=�6h   $	��125��6�   ���	#FF8C0000
�������$��Arial)�6�   $��18(�6�   $
��Bold"�6�   $��30��6�   	 � 	Resources	 5      
 �� 
TargetType �� Property �� Value��%^   '��       �� 5      "
 ��6   .�5      ��  �@��CornerRadius$ 7��65   5      5      5      �� 5   
   -   5        $ btnGestionarPrograma��5      $��Gestionar programa��6/   $
��Left=�6L   $��278,507,0,0q�6g   $	��Top=�6|   $	��186��6�   $��30��6�   ���	#FF14213D
�������$��Arial)�6�   $
��Bold"�6�   $��18(�6�   	 5      ��%^   '��       �� 5      "
 ��6   .�5       ��  �@��CornerRadius$ 7��65   5!      5"      5#      �� 5$   
   -   5        $ btnAgendarPrograma��5$      $��Agendar programa��6-   $
��Left=�6H   $��500,507,0,0q�6c   $	��Top=�6x   $	��188��6�   $��30��6�   ���	#FF14213D
�������$��Arial)�6�   $
��Bold"�6�   $��18(�6�   	 5%      ��%^   '��       �� 5&      "
 ��6   .�5'      ��  �@��CornerRadius$ 7��65   5(      5)      5*      �� 5+   
   $��Días de la semana:��6   $
��Left=�6-   $��
29,124,0,0q�6H   $	��Top=�6\   �� 5,   
   -   5         ��Name$ cbDiaSemana��5,      $
��Left=�6(   $��143,127,0,0q�6C   $	��Top=�6X   $	��197��6p   6|   5.      5/      
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SistemaDeRadio.Ventanas
{
    /// <summary>
    /// Lógica de interacción para MenuCanciones.xaml
    /// </summary>
    public partial class MenuCanciones : Window
    {
        public MenuCanciones()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
            pantallaPrincipal.Show();
            this.Close();
        }

        private void btnBuscarCancion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnModificarCancion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegistrarCancion_Click(object sender, RoutedEventArgs e)
        {
            RegistrarCancion registrarCancion = new RegistrarCancion();
            registrarCancion.Show();
            this.Close();
        }

        private void btnGenerarReporteCanciones_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGenerarReporteCancionesSinUso_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

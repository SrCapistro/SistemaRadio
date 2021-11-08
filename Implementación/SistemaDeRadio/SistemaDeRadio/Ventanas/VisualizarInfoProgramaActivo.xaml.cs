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
    /// Lógica de interacción para VisualizarInfoProgramaActivo.xaml
    /// </summary>
    public partial class VisualizarInfoProgramaActivo : Window
    {
        public VisualizarInfoProgramaActivo()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal regresarPrincipal = new PantallaPrincipal();
            regresarPrincipal.Show();
            this.Close();
        }
    }
}

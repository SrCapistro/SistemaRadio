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
    /// Lógica de interacción para RegistrarCancion.xaml
    /// </summary>
    public partial class RegistrarCancion : Window
    {
        public RegistrarCancion()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MenuCanciones menuCanciones = new MenuCanciones();
            menuCanciones.Show();
            this.Close();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

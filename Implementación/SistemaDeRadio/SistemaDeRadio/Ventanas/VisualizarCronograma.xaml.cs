using System;
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
    /// Lógica de interacción para VisualizarCronograma.xaml
    /// </summary>
    public partial class VisualizarCronograma : Window
    {
        public VisualizarCronograma()
        {
            InitializeComponent();
            llamarFecha();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal regresarPrincipal = new PantallaPrincipal();
            regresarPrincipal.Show();
            this.Close();
        }
            
        private void llamarFecha()
        {
            String fechaActual = DateTime.Now.ToString("dd-MM-yyyy");
            lbFecha.Content = "Cronograma - " + fechaActual;
        }

    }
}

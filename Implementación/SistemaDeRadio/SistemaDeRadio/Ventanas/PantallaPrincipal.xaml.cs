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
    /// Lógica de interacción para PantallaPrincipal.xaml
    /// </summary>
    public partial class PantallaPrincipal : Window
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void btnPatrones_Click(object sender, RoutedEventArgs e)
        {
            PatronesRegistrados pantallaPatrones = new PatronesRegistrados();
            pantallaPatrones.Show();
            this.Close();
        }

        private void btnCronograma_Click(object sender, RoutedEventArgs e)
        {
            VisualizarCronograma pantallaCronograma = new VisualizarCronograma();
            pantallaCronograma.Show();
            this.Close();
        }

        private void btnDetalles_Click(object sender, RoutedEventArgs e)
        {
            VisualizarInfoProgramaActivo pantallaDetalles = new VisualizarInfoProgramaActivo();
            pantallaDetalles.Show();
            this.Close();
        }
    }
}

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
    /// Lógica de interacción para VisualizarInfoProgramaActivo.xaml
    /// </summary>
    public partial class VisualizarInfoProgramaActivo : Window
    {
        public VisualizarInfoProgramaActivo()
        {
            InitializeComponent();
            /*
            String horaActual = DateTime.Now.ToShortTimeString();
            Console.WriteLine("La hora actual es: " + horaActual);
            */
            obtenerSoloHora();
        }

        private void obtenerSoloHora()
        {
            String horaActual = DateTime.Now.ToShortTimeString();
            //Console.WriteLine("La hora actual es: " + horaActual);

            char primerDijito = horaActual[0];
            char segundoDijito = horaActual[1];

            String soloHora = primerDijito.ToString() + segundoDijito.ToString();

            Console.WriteLine("Las horas son: " + soloHora);

        }

        private void cargarInformacionProgramaActual(String hora)
        {

        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal regresarPrincipal = new PantallaPrincipal();
            regresarPrincipal.Show();
            this.Close();
        }
    }
}

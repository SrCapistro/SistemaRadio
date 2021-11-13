using SistemaDeRadio.DAO;
using SistemaDeRadio.POCO;
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

        public static String estacion = "";
        List<Programa> programas;
        String fechaActual = DateTime.Now.ToString("dddd");

        public PantallaPrincipal()
        {
            InitializeComponent();
            programas = new List<Programa>();
            cargarEstacion();
            obtenerHoraActual();
        }

        void cargarEstacion()
        {
             estacion = MainWindow.estacion;
        }
        

        private void btnPatrones_Click(object sender, RoutedEventArgs e)
        {
            PatronesRegistrados pantallaPatrones = new PatronesRegistrados();
            pantallaPatrones.Show();
            
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

        private void btnAgenda_Click(object sender, RoutedEventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            Agenda agenda = new Agenda(fecha);
            agenda.Show();
        }

        private void obtenerHoraActual()
        {
            String horaActual = DateTime.Now.ToString("HH:mm:ss");
            char primerDijito = horaActual[0];
            char segundoDijito = horaActual[1];

            String soloHora = primerDijito.ToString() + segundoDijito.ToString();

            String soloHoraAux = soloHora + "%";
            cargarNombreProgramaActual(soloHoraAux, fechaActual);
        }

        private void cargarNombreProgramaActual(String hora, String fecha)
        {
            try
            {
                programas = ProgramaDAO.obtenerProgramaActual(hora, fecha, PantallaPrincipal.estacion);

                Programa programaActual = new Programa();
                programaActual = programas[0];

                txtInfoPrograma.Text = "Programa Actual: " + programaActual.NombrePrograma;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

    }
}

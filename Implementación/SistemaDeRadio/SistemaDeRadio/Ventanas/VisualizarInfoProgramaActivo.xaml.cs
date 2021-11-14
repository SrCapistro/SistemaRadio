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
    /// Lógica de interacción para VisualizarInfoProgramaActivo.xaml
    /// </summary>
    public partial class VisualizarInfoProgramaActivo : Window
    {

        List<Programa> programas;
        List<Formato> formatos;
        String fechaActual = DateTime.Now.ToString("dddd");

        public VisualizarInfoProgramaActivo()
        {
            InitializeComponent();
            programas = new List<Programa>();
            formatos = new List<Formato>();
            obtenerSoloHora();
        }

        private void obtenerSoloHora()
        {
            String horaActual = DateTime.Now.ToString("HH:mm:ss");

            char primerDijito = horaActual[0];
            char segundoDijito = horaActual[1];

            String soloHora = primerDijito.ToString() + segundoDijito.ToString();

            String soloHoraAux = soloHora + "%";

            Console.WriteLine("Las horas son: " + soloHoraAux);
            Console.WriteLine("La fecha actual es: " + fechaActual);

            cargarInformacionProgramaActual(soloHoraAux, fechaActual);

        }

        private void cargarInformacionProgramaActual(String hora, String fecha)
        {
            try
            {
                programas = ProgramaDAO.obtenerProgramaActual(hora, fecha, PantallaPrincipal.estacion);

                Programa programaActual = new Programa();
                programaActual = programas[0];

                lbNombrePrograma.Content = programaActual.NombrePrograma;
                lbHoraInicio.Content = programaActual.HoraInicio;
                lbHoraFin.Content = programaActual.HoraFin;
                lbDiaProgramado.Content = programaActual.FechaProgramada;
                lbEstacion.Content = programaActual.Estacion;

                int idHorarioAux = programaActual.IdHorario;
                
                llenarTabla(idHorarioAux);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private void llenarTabla(int horario)
        {

            formatos = FormatoDAO.obtenerElementosDelPrograma(horario);

            dgElementos.AutoGenerateColumns = false;
            dgElementos.ItemsSource = formatos;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal regresarPrincipal = new PantallaPrincipal();
            regresarPrincipal.Show();
            this.Close();
        }
    }
}

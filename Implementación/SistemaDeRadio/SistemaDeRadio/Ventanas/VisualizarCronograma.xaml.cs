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
    /// Lógica de interacción para VisualizarCronograma.xaml
    /// </summary>
    public partial class VisualizarCronograma : Window
    {

        List<Programa> programas;
        String fechaHoy = DateTime.Now.ToString("yyyy-MM-dd");

        public VisualizarCronograma()
        {
            InitializeComponent();
            programas = new List<Programa>();
            cargarProgramasDelDia(fechaHoy);
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal regresarPrincipal = new PantallaPrincipal();
            regresarPrincipal.Show();
            this.Close();
        } 

        void cargarProgramasDelDia(String fecha)
        {

            try
            {
                lbFecha.Content = "Cronograma - " + fecha;

                programas = ProgramaDAO.obtenerProgramasProgramados(fecha, PantallaPrincipal.estacion);
                dgProgramas.AutoGenerateColumns = false;

                dgProgramas.ItemsSource = programas;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }
                        
        private void seleccionPrograma_Click(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("Clic en el programaaaa");
            Programa programaSeleccionado = new Programa();
            programaSeleccionado = programas[dgProgramas.SelectedIndex];

            String nombreProgramaAux = programaSeleccionado.NombrePrograma;
            String horaInicioAux = programaSeleccionado.HoraInicio;
            String horaFinAux = programaSeleccionado.HoraFin;
            Console.WriteLine("Elementos del programa: " + nombreProgramaAux + " Horas: " + horaInicioAux + " a " + horaFinAux);
            //AQUI LLAMO AL DAO PARA MANDAR A LA OTRA TABLA
        }
    }
}

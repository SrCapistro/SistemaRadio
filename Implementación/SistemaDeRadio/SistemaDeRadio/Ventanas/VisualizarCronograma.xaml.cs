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
        List<Formato> formatos;
        String fechaHoy = DateTime.Now.ToString("dddd");

        public VisualizarCronograma()
        {
            InitializeComponent();
            programas = new List<Programa>();
            formatos = new List<Formato>();
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
                dgProgramas.CanUserAddRows = false;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }
                        
        private void seleccionPrograma_Click(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Programa programaSeleccionado = new Programa();
                programaSeleccionado = programas[dgProgramas.SelectedIndex];

                int idHorarioAux = programaSeleccionado.IdHorario;
                formatos = FormatoDAO.obtenerElementosDelPrograma(idHorarioAux);

                dgSegunPrograma.AutoGenerateColumns = false;
                dgSegunPrograma.ItemsSource = formatos;
                dgSegunPrograma.CanUserAddRows = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

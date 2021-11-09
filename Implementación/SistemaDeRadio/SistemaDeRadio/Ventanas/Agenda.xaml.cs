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
    /// Lógica de interacción para Agenda.xaml
    /// </summary>
    public partial class Agenda : Window
    {

        List<Programa> programas;
        String fechaHoy = DateTime.Now.ToString("yyyy-MM-dd");

        public Agenda()
        {
            InitializeComponent();
            programas = new List<Programa>();
            cargarProgramas(fechaHoy);
        }

        void cargarProgramas(String fecha)
        {
            
            try
            {
                programas = ProgramaDAO.obtenerProgramasProgramados(fecha, PantallaPrincipal.estacion);
                dgProgramasAgendados.AutoGenerateColumns = false;
                dgProgramasAgendados.ItemsSource = programas;
                fecha = Convert.ToDateTime(fecha).ToString("D");
                lbDiaSeleccionado.Content = fecha;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }

        }


        private void seleccionFecha(object sender, SelectionChangedEventArgs e)
        {
            String fechaSeleccionada = dpFechas.Text;
            fechaSeleccionada = Convert.ToDateTime(fechaSeleccionada).ToString("yyyy-MM-dd");
            cargarProgramas(fechaSeleccionada);
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGestionarPrograma_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}

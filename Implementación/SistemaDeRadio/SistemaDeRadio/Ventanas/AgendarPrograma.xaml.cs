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
    /// Lógica de interacción para AgendarPrograma.xaml
    /// </summary>
    public partial class AgendarPrograma : Window
    {

        List<string> horas;
        List<string> elementos;
        List<Programa> programas;
        List<Patron> patrones;
        public AgendarPrograma()
        {
            InitializeComponent();
            horas = new List<string>();
            elementos = new List<string>();
            programas = new List<Programa>();
            patrones = new List<Patron>();
            cargarCombos();
        }

        void cargarCombos()
        {
            try
            {
                horas = ProgramaDAO.obtenerHoras();
                elementos = ProgramaDAO.obtenerElementos();
                programas = ProgramaDAO.obtenerTodosLosProgramas(PantallaPrincipal.estacion);
                patrones = PatronDAO.obtenerPatrones();

                cbHoraInicio.ItemsSource = horas;
                cbHoraFin.ItemsSource = horas;
                cbElementos.ItemsSource = elementos;
                cbProgramas.ItemsSource = programas;
                cbPatrones.ItemsSource = patrones;
            }catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                MessageBox.Show("Error en base de datos", "ATENCIÓN");
            }
            
        }

        private void seleccionarPatron(object sender, SelectionChangedEventArgs e)
        {
            int indiceSeleccion = cbPatrones.SelectedIndex;
            if(indiceSeleccion >= 0)
            {
                string patronSeleccionado = patrones[indiceSeleccion].NombrePatron;
                cargarCanciones(patronSeleccionado);
            }
        }

        void cargarCanciones(string patron)
        {
            try
            {
                List<ListaCanciones> canciones = ListaCancionesDAO.obtenerCancionesDeUnPatron(patron);
                dgListaCanciones.ItemsSource = canciones;
                
            }catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                MessageBox.Show("Error en la Base de datos", "ATENCIÓN");
            }
            

        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgendar_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}

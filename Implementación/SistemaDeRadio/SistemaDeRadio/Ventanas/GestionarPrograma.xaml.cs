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
    
    public partial class GestionarPrograma : Window
    {
        
        List<string> horas;
        List<string> elementos;
        List<Programa> programas;
        List<Patron> patrones;

        string programaSeleccion;
        string horaInicioSeleccion;
        string horaFinSeleccion;
        string diaSeleccionado;
        int idHorarioSeleccionado;

        public GestionarPrograma(string programaSeleccion, string horaInicioSeleccion, string horaFinSeleccion, string diaSeleccionado, int idHorarioSeleccionado)
        {
            InitializeComponent();

            this.programaSeleccion = programaSeleccion;
            this.horaInicioSeleccion = horaInicioSeleccion;
            this.horaFinSeleccion = horaFinSeleccion;
            this.diaSeleccionado = diaSeleccionado;
            this.idHorarioSeleccionado = idHorarioSeleccionado;

            horas = new List<string>();
            elementos = new List<string>();
            programas = new List<Programa>();
            patrones = new List<Patron>();
            cargarCombosSeleccionados();
        }

        void cargarCombosSeleccionados()
        {
           
            try
            {
                horas = ProgramaDAO.obtenerHoras();
                elementos = ProgramaDAO.obtenerElementos();
                programas = ProgramaDAO.obtenerTodosLosProgramas(PantallaPrincipal.estacion);
                patrones = PatronDAO.obtenerPatrones();

                cbHoraInicio.ItemsSource = horas;
                cbHoraInicio.Text = horaInicioSeleccion;

                cbHoraFin.ItemsSource = horas;
                cbHoraFin.Text = horaFinSeleccion;

                cbElementos.ItemsSource = elementos;

                cbProgramas.ItemsSource = programas;
                cbProgramas.Text = programaSeleccion;

                dpDiaProgramado.Text = Convert.ToDateTime(diaSeleccionado).ToString("d");

                cbPatrones.ItemsSource = patrones;
                string patronSeleccionado = FormatoDAO.obtenerPatronDeUnFormato(idHorarioSeleccionado);
                cbPatrones.Text = patronSeleccionado;
                Console.WriteLine("Campos: " + horaInicioSeleccion + idHorarioSeleccionado);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                MessageBox.Show("Error en base de datos", "ATENCIÓN");
            }

        }

        private void seleccionarPatron(object sender, SelectionChangedEventArgs e)
        {
            int indiceSeleccion = cbPatrones.SelectedIndex;
            if (indiceSeleccion >= 0)
            {
                
            }
        }

       

        private void btnInhabilitar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDesagendar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgregarPrograma_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgregarElemento_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgregarComentario_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

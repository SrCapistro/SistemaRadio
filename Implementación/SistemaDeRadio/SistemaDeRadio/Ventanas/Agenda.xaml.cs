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
        List<string> diasSemana;

        public static string nombreProgramaSeleccionado;
        public static string horaInicioProgramaSeleccionado;
        public static string horaFinProgramaSeleccionado;
        public static string diaProgramadoProgramaSeleccionado;
        public static int idHorarioSeleccion;
        public Agenda(string diaSemana)
        {
            InitializeComponent();
            programas = new List<Programa>();
            cargarProgramas(diaSemana);
            cargarComboDias();
        }

        void cargarComboDias()
        {
            diasSemana = new List<string>();
            diasSemana.Add("lunes");
            diasSemana.Add("martes");
            diasSemana.Add("miércoles");
            diasSemana.Add("jueves");
            diasSemana.Add("viernes");
            diasSemana.Add("sábado");
            diasSemana.Add("domingo");
            cbDiaSemana.ItemsSource = diasSemana;
        }

        void cargarProgramas(String diaSemana)
        {
            
            try
            {
                programas = ProgramaDAO.obtenerProgramasProgramados(diaSemana, PantallaPrincipal.estacion);
                dgProgramasAgendados.AutoGenerateColumns = false;
                dgProgramasAgendados.IsReadOnly = true;
                dgProgramasAgendados.CanUserAddRows = false;
                dgProgramasAgendados.ItemsSource = programas;
                lbDiaSeleccionado.Content = diaSemana;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                MessageBox.Show("Ocurrió un error en la Base de datos", "ATENCIÓN");
            }

        }

        private void seleccionDia(object sender, SelectionChangedEventArgs e)
        {
            int seleccionCombo = cbDiaSemana.SelectedIndex;
            cargarProgramas(diasSemana[seleccionCombo]);
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGestionarPrograma_Click(object sender, RoutedEventArgs e)
        {
            int seleccionIndex = dgProgramasAgendados.SelectedIndex;
            if(seleccionIndex >= 0)
            {
                nombreProgramaSeleccionado = programas[seleccionIndex].NombrePrograma;
                horaInicioProgramaSeleccionado = programas[seleccionIndex].HoraInicio;
                horaFinProgramaSeleccionado = programas[seleccionIndex].HoraFin;
                diaProgramadoProgramaSeleccionado = programas[seleccionIndex].FechaProgramada;
                idHorarioSeleccion = programas[seleccionIndex].IdHorario;
                GestionarPrograma gestion = new GestionarPrograma(nombreProgramaSeleccionado, horaInicioProgramaSeleccionado, horaFinProgramaSeleccionado, diaProgramadoProgramaSeleccionado, idHorarioSeleccion);
                gestion.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Primero seleccione un programa");
            }
        }

        private void btnAgendarPrograma_Click(object sender, RoutedEventArgs e)
        {
            AgendarPrograma agendar = new AgendarPrograma();
            agendar.Show();
            this.Close();
        }

        
    }
}

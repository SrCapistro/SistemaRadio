using SistemaDeRadio.DAO;
using SistemaDeRadio.POCO;
using System;
using System.Collections.Generic;
using System.Data;
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
        List<ListaCanciones> canciones;
        List<ListaCanciones> auxiliar;
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
            } catch (Exception e)
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
                string patronSeleccionado = patrones[indiceSeleccion].NombrePatron;
                cargarCanciones(patronSeleccionado);
            }
        }

        void cargarCanciones(string patron)
        {
            try
            {
                canciones = ListaCancionesDAO.obtenerCancionesDeUnPatron(patron);
                dgListaCanciones.AutoGenerateColumns = false;
                dgListaCanciones.CanUserAddRows = false;
                dgListaCanciones.ItemsSource = canciones;

            } catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                MessageBox.Show("Error en la Base de datos", "ATENCIÓN");
            }


        }

        void agendarPrograma()
        {
            string nombrePrograma = cbProgramas.Text;
            string diaProgramado = dpDiaProgramado.Text;
            string horaInicio = cbHoraInicio.Text;
            string horaFin = cbHoraFin.Text;
            string patron = cbPatrones.Text;
            Boolean esCorrecto = true;
            List<Formato> formatos = new List<Formato>();
            
            if(nombrePrograma == "")
            {
                MessageBox.Show("Es necesario seleccionar un programa", "ATENCIÓN");
                esCorrecto = false;
            }
            if(diaProgramado == "")
            {
                MessageBox.Show("Es necesario seleccionar una fecha", "ATENCIÓN");
                esCorrecto = false;
            }
            if(horaInicio == "")
            {
                MessageBox.Show("Es necesario seleccionar una hora de inicio", "ATENCIÓN");
                esCorrecto = false;
            }
            if (horaFin == "")
            {
                MessageBox.Show("Es necesario seleccionar una hora de final", "ATENCIÓN");
                esCorrecto = false;
            }
            if(patron == "")
            {
                MessageBox.Show("Es necesario seleccionar un patron", "ATENCIÓN");
                esCorrecto = false;
            }

            if (esCorrecto)
            {
                diaProgramado = Convert.ToDateTime(diaProgramado).ToString("yyyy-MM-dd");
                try
                {
                    int resultado = ProgramaDAO.agendarPrograma(horaInicio, horaFin, diaProgramado, nombrePrograma);
                    if (resultado > 0)
                    {
                        int programaAgendado = ProgramaDAO.obtenerUltimoProgramaAgendado();
                        if (programaAgendado > 0)
                        {
                            int tamañoLista = canciones.Count();
                            int contador = 0;
                            while (contador < tamañoLista)
                            {
                                Formato formato = new Formato();
                                formato.IdHorarioPrograma = programaAgendado;
                                formato.NombrePatron = patron;
                                formato.NombreElemento = canciones[contador].NombreCancion;
                                formato.Comentarios = canciones[contador].Comentarios;
                                formato.OrdenElementos = contador;
                                formatos.Add(formato);
                                contador++;
                            }
                            int resultadoFinal = FormatoDAO.registrarFormato(formatos);
                            if(resultadoFinal == contador)
                            {
                                MessageBox.Show("Registro exitoso", "INFORMACIÓN");
                            }
                            else
                            {
                                MessageBox.Show("No fue posible completar el registro, intente más tarde", "ATENCIÓN");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Algo salió mal, intente más tarde", "ATENCIÓN");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Algo salió mal, intente más tarde", "ATENCIÓN");
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("Error en la base de datos", "ATENCIÓN");
                    Console.WriteLine("Error: " + e.Message);
                }
                    
                
            }

        }

        private void btnAgregarPrograma_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAgregarElemento_Click(object sender, RoutedEventArgs e)
        {
            auxiliar = new List<ListaCanciones>();
            int seleccionTabla = dgListaCanciones.SelectedIndex;
            
            string elementoSeleccionado = cbElementos.Text;
            if (elementoSeleccionado != "")
            {
                
                if (seleccionTabla == 0)
                {
                    ListaCanciones cancionesAux = new ListaCanciones();
                    cancionesAux.NombreCancion = elementoSeleccionado;
                    auxiliar.Add(cancionesAux);
                    int contador = 0;
                    while (contador < canciones.Count)
                    {
                        ListaCanciones cancionesAux2 = new ListaCanciones();
                        cancionesAux2.NombreCancion = canciones[contador].NombreCancion;
                        cancionesAux2.Comentarios = canciones[contador].Comentarios;
                        auxiliar.Add(cancionesAux2);
                        contador++;
                    }
                    dgListaCanciones.ItemsSource = auxiliar;
                    
                } else if (seleccionTabla > 0)
                {
                    
                    int contador = 0;
                    
                    while (contador < seleccionTabla)
                    {
                        ListaCanciones cancionesAux3 = new ListaCanciones();
                        cancionesAux3.NombreCancion = canciones[contador].NombreCancion;
                        cancionesAux3.Comentarios = canciones[contador].Comentarios;
                        auxiliar.Add(cancionesAux3);
                        contador++;
                    }
                    
                    ListaCanciones cancionesAux4 = new ListaCanciones();
                    cancionesAux4.NombreCancion = elementoSeleccionado;
                    auxiliar.Add(cancionesAux4);
                   
                    while(contador < canciones.Count)
                    {
                        ListaCanciones cancionesAux5 = new ListaCanciones();
                        cancionesAux5.NombreCancion = canciones[contador].NombreCancion;
                        cancionesAux5.Comentarios = canciones[contador].Comentarios;
                        auxiliar.Add(cancionesAux5);
                        contador++;
                    }
                    dgListaCanciones.ItemsSource = auxiliar;
                   

                }
                else
                {
                MessageBox.Show("Para editar una celda primero seleccionela", "ATENCIÓN");
                }
            }
            else
            {
                MessageBox.Show("Primero seleccione un elemento", "ATENCIÓN");
            }
        }

        private void btnAgregarComentario_Click(object sender, RoutedEventArgs e)
        {
            int seleccionTabla = dgListaCanciones.SelectedIndex;
            string comentario = txtComentario.Text;
            if(seleccionTabla >= 0)
            {
                if (!txtComentario.Equals(""))
                {
                    canciones[seleccionTabla].Comentarios = comentario;
                    dgListaCanciones.ItemsSource = canciones;
                    txtComentario.Text = "";
                }
                else
                {
                    MessageBox.Show("Para agregar un comentario primero escribalo", "ATENCIÓN");
                }
            }
            else
            {
                MessageBox.Show("Para editar una celda primero seleccionela", "ATENCIÓN");
            }
                
        }


        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgendar_Click(object sender, RoutedEventArgs e)
        {
            agendarPrograma();
        }

        
    }
}

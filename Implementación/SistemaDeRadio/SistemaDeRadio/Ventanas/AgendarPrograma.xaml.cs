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

        List<string> horasInicio;
        List<string> horasFin;
        List<string> elementos;
        List<Programa> programas;
        List<Patron> patrones;
        List<ListaCanciones> canciones;
        List<ListaCanciones> auxiliar;
        List<string> diasSemana;
        public AgendarPrograma()
        {
            InitializeComponent();
            horasInicio = new List<string>();
            horasFin = new List<string>();
            elementos = new List<string>();
            programas = new List<Programa>();
            patrones = new List<Patron>();
            diasSemana = new List<string>();
            cargarCombos();
        }

        void cargarCombos()
        {
            try
            {
                horasInicio = ProgramaDAO.obtenerHorasInicio();
                cbHoraInicio.ItemsSource = horasInicio;
            
                elementos = ProgramaDAO.obtenerElementos();
                cbElementos.ItemsSource = elementos;

                programas = ProgramaDAO.obtenerTodosLosProgramas(PantallaPrincipal.estacion);
                cbProgramas.ItemsSource = programas;

                patrones = PatronDAO.obtenerPatrones();
                cbPatrones.ItemsSource = patrones;

                horasFin = ProgramaDAO.obtenerHorasFin();
                cbHoraFin.ItemsSource = horasFin;
                
                
                
                cargarDiasDeLaSemana();
            } catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                MessageBox.Show("Error en base de datos", "ATENCIÓN");
            }

        }

        void cargarDiasDeLaSemana()
        {
            diasSemana.Add("lunes");
            diasSemana.Add("martes");
            diasSemana.Add("miércoles");
            diasSemana.Add("jueves");
            diasSemana.Add("viernes");
            diasSemana.Add("sábado");
            diasSemana.Add("domingo");
            cbDiaSemana.ItemsSource = diasSemana;
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
                dgListaCanciones.IsReadOnly = true;
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
            string diaProgramado = cbDiaSemana.Text;
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

            DateTime horaInicioConvertida = Convert.ToDateTime(horaInicio);
            DateTime horaFinConvertida = Convert.ToDateTime(horaFin);
            Boolean esHorarioCorrecto = true;
            if(horaInicioConvertida > horaFinConvertida)
            {
                esHorarioCorrecto = false;
            }

            Boolean hayTraslape = validarTraslapes(horaInicioConvertida, horaFinConvertida, diaProgramado);


            if (esCorrecto)
            {
                if (esHorarioCorrecto)
                {
                    if (!hayTraslape)
                    {
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
                                    int resultado2 = FormatoDAO.registrarFormato(formatos);
                                    if (resultado2 == contador)
                                    {
                                        int resultadoFinal = PatronDAO.aumentarUsoDePatron(patron);
                                        if (resultadoFinal > 0)
                                        {
                                            MessageBox.Show("Registro exitoso", "INFORMACIÓN");
                                            abrirAgenda(diaProgramado);
                                        }
                                        else
                                        {
                                            MessageBox.Show("No fue posible completar el registro, intente más tarde", "ATENCIÓN");
                                        }

                                    }

                                }
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Error en la base de datos", "ATENCIÓN");
                            Console.WriteLine("Error: " + e.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Traslape de horario, el lapso de horario que desea registrar ya está ocupado", "ATENCIÓN");
                    }
                }
                else
                {
                    MessageBox.Show("La hora de inicio debe ser menor a la hora de final", "ATENCIÓN");
                }

            }

        }

        Boolean validarTraslapes(DateTime horaInicio, DateTime horaFin, string diaProgramado)
        {
            Boolean hayTraslape = false;
            List<string> horasInicio = new List<string>();
            List<string> horasFin = new List<string>();
            try
            {
                horasInicio = ProgramaDAO.obtenerHorasInicioProgramadas(diaProgramado, PantallaPrincipal.estacion);
                horasFin = ProgramaDAO.obtenerHorasFinProgramadas(diaProgramado);
                for(int i = 0; i < horasInicio.Count; i++)
                {
                    DateTime horaInicioObtenida = Convert.ToDateTime(horasInicio[i]);
                    DateTime horaFinObtenida = Convert.ToDateTime(horasFin[i]);
                    if (horaInicio == horaInicioObtenida)
                    {
                        hayTraslape = true;
                        break;
                    }
                    if (((horaInicio >= horaInicioObtenida) && (horaInicio < horaFinObtenida)) || ((horaFin >= horaInicioObtenida) && (horaInicio < horaFinObtenida)))
                    {
                        hayTraslape = true;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                hayTraslape = true;
                MessageBox.Show("Validacion de traslape", "ATENCIÓN");
                MessageBox.Show("Error en la base de datos", "ATENCIÓN");
            }
            return hayTraslape;
        }

        void abrirAgenda(string fecha)
        {
            Agenda agenda = new Agenda(fecha);
            agenda.Show();
            this.Close();
        }

        private void btnAgregarPrograma_Click(object sender, RoutedEventArgs e)
        {
            string programaNuevo = txtNombreProgramaNuevo.Text;
            try
            {
                if (!programaNuevo.Equals(""))
                {
                    Boolean hayRegistro = ProgramaDAO.verificarProgramaRegistrado(programaNuevo);
                    if (!hayRegistro)
                    {
                        int resultado = ProgramaDAO.registrarPrograma(programaNuevo, PantallaPrincipal.estacion);
                        if(resultado > 0)
                        {
                            MessageBox.Show("Registro exitoso, ahora puede seleccionar el nuevo programa", "INFORMACIÓN");
                            txtNombreProgramaNuevo.Text = "";
                            programas = ProgramaDAO.obtenerTodosLosProgramas(PantallaPrincipal.estacion);
                            cbProgramas.ItemsSource = programas;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Programa ya fue registrado, intente con otro nombre", "ATENCIÓN");
                    }
                }
                else
                {
                    MessageBox.Show("Debe proporcionar un nombre para el programa", "ATENCIÓN");
                }
                    
            }catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("Ocurrió un error en la Base de datos", "ATENCIÓN");
            }
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

                    int contador2 = 0;
                    canciones.Clear();
                    while(contador2 < auxiliar.Count)
                    {
                        ListaCanciones llenarLista = new ListaCanciones();
                        llenarLista.NombreCancion = auxiliar[contador2].NombreCancion;
                        llenarLista.Comentarios = auxiliar[contador2].Comentarios;
                        canciones.Add(llenarLista);
                        contador2++;
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

                    canciones.Clear();
                    int contador2 = 0;
                    while (contador2 < auxiliar.Count)
                    {
                        ListaCanciones llenarLista = new ListaCanciones();
                        llenarLista.NombreCancion = auxiliar[contador2].NombreCancion;
                        llenarLista.Comentarios = auxiliar[contador2].Comentarios;
                        canciones.Add(llenarLista);
                        contador2++;
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

        private void btnAgregarComentario_Click_1(object sender, RoutedEventArgs e)
        {
            auxiliar = new List<ListaCanciones>();
            int seleccionTabla = dgListaCanciones.SelectedIndex;
            string comentario = txtComentario.Text;
            if (seleccionTabla >= 0)
            {
                if (!txtComentario.Equals(""))
                {
                    int contador = 0;
                    while (contador < canciones.Count)
                    {
                        ListaCanciones cancionesAuxiliar = new ListaCanciones();
                        cancionesAuxiliar.NombreCancion = canciones[contador].NombreCancion;
                        cancionesAuxiliar.Comentarios = canciones[contador].Comentarios;
                        auxiliar.Add(cancionesAuxiliar);
                        contador++;
                    }

                    auxiliar[seleccionTabla].Comentarios = comentario;
                    dgListaCanciones.ItemsSource = auxiliar;
                
                    int contador2 = 0;
                    canciones.Clear();
                    while (contador2 < auxiliar.Count)
                    {
                        ListaCanciones cancionesAuxiliar = new ListaCanciones();
                        cancionesAuxiliar.NombreCancion = auxiliar[contador2].NombreCancion;
                        cancionesAuxiliar.Comentarios = auxiliar[contador2].Comentarios;
                        canciones.Add(cancionesAuxiliar);
                        contador2++;
                    }
                    
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
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            abrirAgenda(fecha);
        }

        private void btnAgendar_Click(object sender, RoutedEventArgs e)
        {
            agendarPrograma();
        }

    }
}

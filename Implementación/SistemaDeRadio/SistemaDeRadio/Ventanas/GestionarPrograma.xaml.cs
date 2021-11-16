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
        
        List<string> horasInicio;
        List<string> horasFin;
        List<string> elementos;
        List<Programa> programas;
        List<string> diasSemana;
        List<Formato> elementosFormato;
        List<Formato> elementosFormatoAuxiliar;

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

            horasInicio = new List<string>();
            horasFin = new List<string>();
            elementos = new List<string>();
            programas = new List<Programa>();
            diasSemana = new List<string>();
            cargarCombosSeleccionados();
        }

        void cargarCombosSeleccionados()
        {

            try
            {
                horasInicio = ProgramaDAO.obtenerHorasInicio();
                cbHoraInicio.ItemsSource = horasInicio;
                cbHoraInicio.Text = horaInicioSeleccion;
            
                elementos = ProgramaDAO.obtenerElementos();
                cbElementos.ItemsSource = elementos;

                programas = ProgramaDAO.obtenerTodosLosProgramas(PantallaPrincipal.estacion);
                cbProgramas.ItemsSource = programas;
                cbProgramas.Text = programaSeleccion;

                string patronSeleccionado = FormatoDAO.obtenerPatronDeUnFormato(idHorarioSeleccionado);
                txtPatron.Text = patronSeleccionado;
                txtPatron.IsReadOnly = true;
                cargarFormato(idHorarioSeleccionado, patronSeleccionado);

                horasFin = ProgramaDAO.obtenerHorasFin();
                cbHoraFin.ItemsSource = horasFin;
                cbHoraFin.Text = horaFinSeleccion;
                cargarDiasDeLaSemana();
            }
            catch (Exception e)
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
            cbDiaSemana.Text = diaSeleccionado;
        }

        void cargarFormato(int idHorarioPrograma, string patron)
        {
            try
            {
                elementosFormato = FormatoDAO.obtenerFormatoDeProgramaEnOrden(idHorarioPrograma, patron);
                dgFormatoPrograma.AutoGenerateColumns = false;
                dgFormatoPrograma.CanUserAddRows = false;
                dgFormatoPrograma.IsReadOnly = true;
                dgFormatoPrograma.ItemsSource = elementosFormato;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                MessageBox.Show("Error en la Base de datos", "ATENCIÓN");
            }
        }

        void actualizarAgenda()
        {
            string nombrePrograma = cbProgramas.Text;
            string diaProgramado = cbDiaSemana.Text;
            string horaInicio = cbHoraInicio.Text;
            string horaFin = cbHoraFin.Text;

            DateTime horaInicioConvertida = Convert.ToDateTime(horaInicio);
            DateTime horaFinConvertida = Convert.ToDateTime(horaFin);
            Boolean esHorarioCorrecto = true;
            if (horaInicioConvertida > horaFinConvertida)
            {
                esHorarioCorrecto = false;
            }

            DateTime horaInicioSeleccionConvertida = Convert.ToDateTime(horaInicioSeleccion);
            DateTime horaFinSeleccionConvertida = Convert.ToDateTime(horaFinSeleccion);
            Boolean hayTraslape;
            if ((horaInicioConvertida >= horaInicioSeleccionConvertida) && (horaInicioConvertida < horaFinSeleccionConvertida))
            {
                hayTraslape = false;
            }
            else
            {
                hayTraslape = validarTraslapes(horaInicioConvertida, horaFinConvertida, diaProgramado);
            }

            if (esHorarioCorrecto)
            {
                if (!hayTraslape)
                {
                    try
                    {
                        int resultado = ProgramaDAO.actualizarPrograma(horaInicio, horaFin, diaProgramado, nombrePrograma, idHorarioSeleccionado);
                        if (resultado > 0)
                        {
                            int tamañoLista = elementosFormato.Count();
                            int contador = 0;
                            List<Formato> elemetosActualizar = new List<Formato>();
                            while (contador < tamañoLista)
                            {
                                Formato formato = new Formato();
                                formato.NombreElemento = elementosFormato[contador].NombreElemento;
                                formato.Comentarios = elementosFormato[contador].Comentarios;
                                formato.OrdenElementos = contador;
                                elemetosActualizar.Add(formato);
                                contador++;
                            }
                            int resultado2 = FormatoDAO.actualizarFormato(elemetosActualizar, idHorarioSeleccionado);
                            if (resultado2 == contador)
                            {
                                MessageBox.Show("Actualización exitosa", "INFORMACIÓN");
                                abrirAgenda(diaProgramado);
                            }
                            else
                            {
                                MessageBox.Show("No fue posible completar el registro, intente más tarde", "ATENCIÓN");
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

        void abrirAgenda(string dia)
        {
            Agenda agenda = new Agenda(dia);
            agenda.Show();
            this.Close();
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
                for (int i = 0; i < horasInicio.Count; i++)
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


        private void btnInhabilitar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int resultado = ProgramaDAO.inHabilitarPrograma(programaSeleccion);
                if(resultado > 0)
                {
                    MessageBox.Show("El programa fue Inhabilitado", "INFORMACIÓN");
                    abrirAgenda(diaSeleccionado);
                }
                else
                {
                    MessageBox.Show("No fue posible inhabilitar el programa, intente más tarde", "ATENCIÓN");
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Error : "+ex.Message);
                MessageBox.Show("Error de base de datos", "ATENCIÓN");
            }
        }

        private void btnDesagendar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int resultado = FormatoDAO.desagendarFormato(idHorarioSeleccionado);
                if(resultado > 0)
                {
                    int resultado2 = ProgramaDAO.desagendarPrograma(idHorarioSeleccionado);
                    if(resultado2 > 0)
                    {
                        MessageBox.Show("El programa fue desagendado", "INFORMACIÓN");
                        abrirAgenda(diaSeleccionado);
                    }
                    else
                    {
                        MessageBox.Show("No fue posible desagendar el programa, intente más tarde", "ATENCIÓN");
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("Error de base de datos", "ATENCIÓN");
            }
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
                        if (resultado > 0)
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

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("Ocurrió un error en la Base de datos", "ATENCIÓN");
            }
        }

        private void btnAgregarElemento_Click(object sender, RoutedEventArgs e)
        {
            elementosFormatoAuxiliar = new List<Formato>();
            int seleccionTabla = dgFormatoPrograma.SelectedIndex;
            string elementoSeleccionado = cbElementos.Text;
            if(elementoSeleccionado != "")
            {
                if(seleccionTabla > 0)
                {
                    int contador = 0;
                    while(contador < elementosFormato.Count)
                    {
                        Formato formato = new Formato();
                        formato.NombreElemento = elementosFormato[contador].NombreElemento;
                        formato.Comentarios = elementosFormato[contador].Comentarios;
                        elementosFormatoAuxiliar.Add(formato);
                        contador++;
                    }
                    elementosFormatoAuxiliar[seleccionTabla].NombreElemento = elementoSeleccionado;
                    dgFormatoPrograma.ItemsSource = elementosFormatoAuxiliar;
                   
                    elementosFormato.Clear();
                    int contador2 = 0;
                    while(contador2 < elementosFormatoAuxiliar.Count)
                    {
                        Formato formato2 = new Formato();
                        formato2.NombreElemento = elementosFormatoAuxiliar[contador2].NombreElemento;
                        formato2.Comentarios = elementosFormatoAuxiliar[contador2].Comentarios;
                        elementosFormato.Add(formato2);
                        contador2++;
                    }
                    txtComentario.Text = "";
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
            elementosFormatoAuxiliar = new List<Formato>();
            int seleccionTabla = dgFormatoPrograma.SelectedIndex;
            string comentario = txtComentario.Text;
            if (comentario != "")
            {
                if (seleccionTabla > 0)
                {
                    int contador = 0;
                    while (contador < elementosFormato.Count)
                    {
                        Formato formato = new Formato();
                        formato.NombreElemento = elementosFormato[contador].NombreElemento;
                        formato.Comentarios = elementosFormato[contador].Comentarios;
                        elementosFormatoAuxiliar.Add(formato);
                        contador++;
                    }
                    elementosFormatoAuxiliar[seleccionTabla].Comentarios = comentario;
                    dgFormatoPrograma.ItemsSource = elementosFormatoAuxiliar;

                    elementosFormato.Clear();
                    int contador2 = 0;
                    while (contador2 < elementosFormatoAuxiliar.Count)
                    {
                        Formato formato2 = new Formato();
                        formato2.NombreElemento = elementosFormatoAuxiliar[contador2].NombreElemento;
                        formato2.Comentarios = elementosFormatoAuxiliar[contador2].Comentarios;
                        elementosFormato.Add(formato2);
                        contador2++;
                    }
                }
                else
                {
                    MessageBox.Show("Para editar una celda primero seleccionela", "ATENCIÓN");
                }
            }
            else
            {
                MessageBox.Show("Primero escriba su comentario", "ATENCIÓN");
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            actualizarAgenda();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            abrirAgenda(diaSeleccionado);
        }
    }
}

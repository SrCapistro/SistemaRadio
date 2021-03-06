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
    /// Lógica de interacción para PatronCusom.xaml
    /// </summary>
    public partial class PatronCusom : Window
    {
        private List<Categoria> listaCategorias = null;
        private List<Genero> listaGeneros = null;
        private List<Cancion> listaCancionesPatron = new List<Cancion> { };
        List<LineaPatron> listaLineasAñadidas = new List<LineaPatron> { };
        List<LineaPatron> listaLineasNuevas = new List<LineaPatron> { };
        private long generoAñadirID = 0;
        private long categoriaAñadirID = 0;
        private int indexCategoria = 0;
        private int indexGenero = 0;
        private String nombrePatronSeleccionado = "";
        private bool esNuevo = false;

        public PatronCusom()
        {
            InitializeComponent();
            cargarGenerosCombo();
            cargarCategoriasCombo();
            chbNuevasCanciones.IsChecked = true;
            chbNuevasCanciones.Visibility = Visibility.Hidden;

        }

        public PatronCusom(String nombrePatron)
        {
            nombrePatronSeleccionado = nombrePatron;
            InitializeComponent();
            esNuevo = true;
            cargarDatosPatronSeleccionado(nombrePatron);
            cargarCategoriasCombo();
            cargarGenerosCombo();
            chbNuevasCanciones.Visibility = Visibility.Visible;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            PatronesRegistrados patronesRegistrados = new PatronesRegistrados();
            patronesRegistrados.Show();
            this.Close();
        }

        private void btnGuardarPatron_Click(object sender, RoutedEventArgs e)
        {
            if(tbNombrePatron.Text.Length == 0){
                MessageBox.Show("Debe de llenar los campos y \nregistrar al menos una linea de patron", "Campos faltantes");
            }
            else
            {
                if (esNuevo)
                {
                    if(chbNuevasCanciones.IsChecked == true)
                    {
                        if (CancionDAO.eliminarListaLineasActualizaras(nombrePatronSeleccionado) > 0 || listaCancionesPatron.Count == 0)
                        {
                            guardarPatronConNuevasCanciones();
                        }
                    }
                    else
                    {
                        guardarPatronConMismasCanciones();
                    }
                }
                else
                {
                    guardarNuevoPatron();
                }
            }
        }

        private void guardarNuevoPatron()
        {
            Patron patronGuardar = new Patron();
            patronGuardar.NombrePatron = tbNombrePatron.Text;
            if (!PatronDAO.comprobarExistenciaPatron(patronGuardar.NombrePatron))
            {
                try
                {
                    generarCancionesPorLinea(listaLineasAñadidas);
                    PatronDAO.registrarPatronNuevo(patronGuardar);
                    PatronDAO.registrarListaDePatron(listaCancionesPatron, patronGuardar.NombrePatron);
                    MessageBox.Show("Se ha registrado el patrón correctamente", "Registro éxitoso");
                    PatronesRegistrados patronesRegistrados = new PatronesRegistrados();
                    patronesRegistrados.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("El patron con el nombre " + patronGuardar.NombrePatron + " ya esta registrado", "Registro duplicado");
            }
        }

        private void guardarPatronConNuevasCanciones()
        {
            Patron patronGuardar = new Patron();
            patronGuardar.NombrePatron = tbNombrePatron.Text;
            try
            {
                if (!patronGuardar.NombrePatron.Equals(nombrePatronSeleccionado))
                {
                    if (!PatronDAO.comprobarExistenciaPatron(patronGuardar.NombrePatron))
                    {
                        PatronDAO.actualizarPatron(patronGuardar.NombrePatron, nombrePatronSeleccionado);
                    }
                    else
                    {
                        MessageBox.Show("El nombre del patron " + patronGuardar.NombrePatron + " ya existe.", "Registro duplicado");
                    }
                }
                generarCancionesPorLinea(listaLineasAñadidas);
                PatronDAO.registrarListaDePatron(listaCancionesPatron, patronGuardar.NombrePatron);
                MessageBox.Show("Se ha registrado el patrón correctamente", "Registro éxitoso");
                PatronesRegistrados patronesRegistrados = new PatronesRegistrados();
                patronesRegistrados.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guardarPatronConMismasCanciones()
        {
            Patron patronGuardar = new Patron();
            patronGuardar.NombrePatron = tbNombrePatron.Text;
            try
            {
                if (!patronGuardar.NombrePatron.Equals(nombrePatronSeleccionado))
                {
                    if (!PatronDAO.comprobarExistenciaPatron(patronGuardar.NombrePatron))
                    {
                        PatronDAO.actualizarPatron(patronGuardar.NombrePatron, nombrePatronSeleccionado);
                    }
                    else
                    {
                        MessageBox.Show("El nombre del patron " + patronGuardar.NombrePatron + " ya existe.", "Registro duplicado");
                    }
                }
                generarCancionesPorLinea(listaLineasNuevas);
                PatronDAO.registrarListaDePatron(listaCancionesPatron, patronGuardar.NombrePatron);
                MessageBox.Show("Se ha registrado el patrón correctamente", "Registro éxitoso");
                PatronesRegistrados patronesRegistrados = new PatronesRegistrados();
                patronesRegistrados.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El nombre de patrón no se puede modificar si esta siendo ocupado en un programa "+ex.Message);
            }
        }
        
        private void cargarGenerosCombo()
        {
            try
            {
                listaGeneros = GeneroDAO.obtenerGeneros();
                foreach (Genero genero in listaGeneros)
                {
                    cbGeneros.Items.Add(genero.GeneroNombre);
                }
            }catch (NullReferenceException ex)
            {
                MessageBox.Show("Ocurrio un error de conexión, intentélo de nuevo más tarde", "Error al cargar los datos");
            }
        }

        public void cargarCategoriasCombo()
        {
            try
            {
                listaCategorias = CategoriaDAO.obtenerCategorias();
                foreach (Categoria categoria in listaCategorias)
                {
                    cbCategorias.Items.Add(categoria.CategoriaNombre);
                }
            }catch(NullReferenceException ex)
            {
                MessageBox.Show("Ocurrio un error de conexión, inténtelo de nuevo más tarde", "Error al cargar los datos");
            }
        }

        private void cbCategoriasSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            indexCategoria = cbCategorias.SelectedIndex;
            try
            {
                listaGeneros.Clear();
                listaGeneros = GeneroDAO.obtenerGeneroPorCategoria(listaCategorias[indexCategoria].CategoriaID);
                cbGeneros.Items.Clear();
                foreach (Genero genero in listaGeneros)
                {
                    cbGeneros.Items.Add(genero.GeneroNombre);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbGenerosSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            indexGenero = cbGeneros.SelectedIndex;
        }

        private void btnAñadirLinea_Click(object sender, RoutedEventArgs e)
        {
            if (indexGenero == 0 || indexCategoria == 0)
            {
                MessageBox.Show("Debe de seleccionar una categoria y un género valido", "Selección faltante");
            }
            else
            {
                categoriaAñadirID = listaCategorias[indexCategoria].CategoriaID;
                generoAñadirID = listaGeneros[indexGenero].GeneroID;
                LineaPatron lineaNueva = new LineaPatron();
                lineaNueva.CategoriaLinea = listaCategorias[indexCategoria].CategoriaNombre;
                lineaNueva.GeneroLinea = listaGeneros[indexGenero].GeneroNombre;
                lineaNueva.GenerolineaID = listaGeneros[indexGenero].GeneroID;
                lineaNueva.CategoriaLineaID = listaCategorias[indexCategoria].CategoriaID;
                try
                {
                    lineaNueva.NumeroCanciones = CancionDAO.contarCancionesLinea(categoriaAñadirID, generoAñadirID);
                }catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión", "Inténtelo de nuevo");
                }
                if (lineaNueva.NumeroCanciones > 0)
                {
                    if(lineaNueva.NumeroCanciones > contarRepeticionLinea(lineaNueva, listaLineasAñadidas))
                    {
                        listaLineasAñadidas.Add(lineaNueva);
                        if (esNuevo)
                        {
                            listaLineasNuevas.Add(lineaNueva);
                        }
                        cargarDataGridLineas();
                    }
                    else
                    {
                        MessageBox.Show("Se ha sobrepasado la cantidad de canciones disponibles para la linea seleccionada" +
                            " , selecciona una linea diferente", "Canciones no disponibles");
                    }
                   
                }
                else
                {
                    MessageBox.Show("No se ha encontrado canción con los parametros seleccionados, inténtelo con" +
                        " otros parametros", "Linea sin canciones");
                }
            }            
        }
        public void cargarDataGridLineas()
        {
            tablaLineas.ItemsSource = null;
            tablaLineas.FrozenColumnCount = 3;
            tablaLineas.AutoGenerateColumns = true;
            tablaLineas.ItemsSource = listaLineasAñadidas;
        }

        private void generarCancionesPorLinea(List<LineaPatron> lineaPatrones)
        {
            for(int i=0; i <lineaPatrones.Count; i++)
            {
                if (listaCancionesPatron.Count() == 0)
                {
                    int idUltimaCancionLinea = CancionDAO.obtenerUltimaCancionLinea(lineaPatrones[i].CategoriaLineaID, lineaPatrones[i].GenerolineaID);
                    Cancion cancionLinea = CancionDAO.obtenerCancionesPatron(lineaPatrones[i].CategoriaLineaID, lineaPatrones[i].GenerolineaID, idUltimaCancionLinea);
                    listaCancionesPatron.Add(cancionLinea);
                }
                else
                {
                    if (lineaPatrones[i].CategoriaLineaID == lineaPatrones[i - 1].CategoriaLineaID && lineaPatrones[i].GenerolineaID == lineaPatrones[i - 1].GenerolineaID)
                    {
                        try
                        {
                            Cancion cancionLinea = CancionDAO.obtenerCancionesPatron(lineaPatrones[i].CategoriaLineaID, lineaPatrones[i].GenerolineaID, listaCancionesPatron[i - 1].CancionID);
                            listaCancionesPatron.Add(cancionLinea);
                        }
                        catch (NullReferenceException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else
                    {
                        Cancion ultimaCancionLinea = obtenerUltimaCancionLinea(lineaPatrones);
                        Cancion cancionLinea = CancionDAO.obtenerCancionesPatron(lineaPatrones[i].CategoriaLineaID, lineaPatrones[i].GenerolineaID, ultimaCancionLinea.CancionID);
                        listaCancionesPatron.Add(cancionLinea);
                    }
                }
            }
        }

        private Cancion obtenerUltimaCancionLinea(List<LineaPatron> lineaPatrones)
        {
            Cancion cancionEncontrada = null;
            try
            {
                foreach (LineaPatron linea in lineaPatrones)
                {
                    foreach (Cancion cancion in listaCancionesPatron)
                    {
                        if (linea.CategoriaLineaID == cancion.CancionCategoria && linea.GenerolineaID == cancion.CancionGenero)
                        {
                            cancionEncontrada = cancion;
                        }
                    }
                }
                Console.WriteLine(cancionEncontrada.CancionTitulo);
            }catch (Exception ex)
            {
                MessageBox.Show("Occurrio un error de conexión con la base de datos, inténtelo de nuevo más tarde", "Error de conexión");
            }

            return cancionEncontrada;
        }

        private int contarRepeticionLinea(LineaPatron linea, List<LineaPatron> lineas)
        {
            int contadorLinea = 0;
            foreach(LineaPatron lineaContar in lineas)
            {
                if (lineaContar.CategoriaLineaID == linea.CategoriaLineaID && lineaContar.GenerolineaID == linea.GenerolineaID)
                {
                    contadorLinea++;
                }
            }
            return contadorLinea;
        }

       

        private void cargarDatosPatronSeleccionado(String nombrePatron)
        {
            tbNombrePatron.Text = nombrePatron;
            listaLineasAñadidas = PatronDAO.obtenerLineasPatron(nombrePatron);
            tablaLineas.ItemsSource = listaLineasAñadidas;
        }

        private void btnEliminarLinea_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = tablaLineas.SelectedIndex;
            if(selectedIndex >= 0)
            {
                listaLineasAñadidas.RemoveAt(selectedIndex);
                tablaLineas.ItemsSource = listaLineasAñadidas;
                cargarDataGridLineas();
                
            }
            else
            {
                MessageBox.Show("Para eliminar una linea debe de seleccionarla", "Selección necesaria");
            }
        }
    }

    
}

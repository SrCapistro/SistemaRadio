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
        private long generoAñadirID = 0;
        private long categoriaAñadirID = 0;
        private int indexCategoria = 0;
        private int indexGenero = 0;

        public PatronCusom()
        {
            InitializeComponent();
            cargarGenerosCombo();
            cargarCategoriasCombo();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            PatronesRegistrados patronesRegistrados = new PatronesRegistrados();
            patronesRegistrados.Show();
            this.Close();
        }

        private void btnGuardarPatron_Click(object sender, RoutedEventArgs e)
        {
            if(tbNombrePatron.Text.Equals("Nombre del patrón")){
                MessageBox.Show("Debe de llenar los campos", "Campos faltantes");
            }
            else
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
                        Console.Write(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("El patron con el nombre " + patronGuardar.NombrePatron + " ya esta registrado", "Registro duplicado");
                }
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
                lineaNueva.NumeroCanciones = CancionDAO.contarCancionesLinea(categoriaAñadirID, generoAñadirID);
                if (lineaNueva.NumeroCanciones > 0)
                {
                    if(lineaNueva.NumeroCanciones > contarRepeticionLinea(lineaNueva, listaLineasAñadidas))
                    {
                        listaLineasAñadidas.Add(lineaNueva);
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
            int indexLinea = 0;
            foreach(LineaPatron linea in lineaPatrones)
            {
                if(listaCancionesPatron.Count() == 0)
                {
                    Cancion cancionLinea = CancionDAO.obtenerCancionesPatron(linea.CategoriaLineaID, linea.GenerolineaID, 0);
                    listaCancionesPatron.Add(cancionLinea);
                }
                else
                {
                    if (linea.CategoriaLineaID == lineaPatrones[indexLinea - 1].CategoriaLineaID && linea.GenerolineaID == lineaPatrones[indexLinea - 1].GenerolineaID)
                    {
                        Cancion cancionLinea = CancionDAO.obtenerCancionesPatron(linea.CategoriaLineaID, linea.GenerolineaID, listaCancionesPatron[indexLinea - 1].CancionID);
                        listaCancionesPatron.Add(cancionLinea);
                    }
                    else
                    {
                        Cancion ultimaCancionLinea = obtenerUltimaCancionLinea(lineaPatrones);
                        Cancion cancionLinea = CancionDAO.obtenerCancionesPatron(linea.CategoriaLineaID, linea.GenerolineaID, ultimaCancionLinea.CancionID);
                        listaCancionesPatron.Add(cancionLinea);
                    }
                }
                indexLinea++;
            }
            indexLinea = 0;
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

        private bool comprobarExistenciaEnLinea(List<Cancion> listaCancionLinea, Cancion cancion)
        {
            bool existe = false;
            foreach(Cancion cancionBuscar in listaCancionLinea)
            {
                if(cancionBuscar.CancionID == cancion.CancionID)
                {
                    return true;
                }
            }
            return existe;
        }
    }

    
}

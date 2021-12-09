using System;
using System.Collections.Generic;
using SistemaDeRadio.DAO;
using SistemaDeRadio.POCO;
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
    /// Lógica de interacción para RegistrarCancion.xaml
    /// </summary>
    public partial class RegistrarCancion : Window
    {
        private List<Categoria> listaCategorias = null;
        private List<Genero> listaGeneros = null;
        private List<Artista> listaArtistas = null;
        private int indexCategoria = 0;
        private int indexGenero = 0;
        private int indexArtista = 0;
        public RegistrarCancion()
        {
            InitializeComponent();
            cargarCategoriasCombo();
            cargarGenerosCombo();
            cargarArtistasCombo();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MenuCanciones menuCanciones = new MenuCanciones();
            menuCanciones.Show();
            this.Close();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (tbNombre.Text.Length == 0)
            {
                MessageBox.Show("Escriba el nombre de una canción");
            } else
            {
                registrarCancion();
                MessageBox.Show("Cancion registrada correctamente");    
            }
        }

        private void cargarGenerosCombo()
        {
            try
            {
                listaGeneros = GeneroDAO.obtenerGeneros();
                foreach (Genero genero in listaGeneros)
                {
                    cbGenero.Items.Add(genero.GeneroNombre);
                }
            }
            catch (NullReferenceException ex)
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
                    cbCategoria.Items.Add(categoria.CategoriaNombre);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Ocurrio un error de conexión, inténtelo de nuevo más tarde", "Error al cargar los datos");
            }
        }
        private void cargarArtistasCombo()
        {
            try
            {
                listaArtistas = ArtistaDAO.obtenerArtistas(); 
                foreach (Artista artista in listaArtistas)
                {
                    cbArtista.Items.Add(artista.ArtistaNombre);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Ocurrio un error de conexión, inténtelo de nuevo más tarde", "Error al cargar los datos");
            }
        }

        private void cbGeneroSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            indexGenero = cbGenero.SelectedIndex;
        }

        private void cbCategoriaSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            indexCategoria = cbCategoria.SelectedIndex;
        }

        private void cbArtistaSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            indexArtista = cbArtista.SelectedIndex;
        }

        private void registrarCancion()
        {
            string nombreCancion = tbNombre.Text.ToString();
            int genero = indexGenero;
            int categoria = indexCategoria;
            int artista = indexArtista;
            string clave = "00104";
            string dias = "1234567";
            CancionDAO.agregarCancion(nombreCancion, categoria, genero, clave, dias, artista);
        }

    }
}

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
    /// Lógica de interacción para PatronesRegistrados.xaml
    /// </summary>
    public partial class PatronesRegistrados : Window
    {
        List<Patron> listaPatrones = new List<Patron>();
        public PatronesRegistrados()
        {
            InitializeComponent();
            cargarPatronesEnGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
            pantallaPrincipal.Show();
            this.Close();
        }

        private void btnCrearPatron_Click(object sender, RoutedEventArgs e)
        {
            PatronCusom patronCusom = new PatronCusom();
            patronCusom.Show();
            this.Close();
        }

        private void cargarPatronesEnGrid()
        {
            try
            {
                listaPatrones = PatronDAO.obtenerListaPatronesCompleta();
                tablaPatrones.AutoGenerateColumns = true;
                tablaPatrones.ItemsSource = listaPatrones;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificarPatron_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = tablaPatrones.SelectedIndex;
            if(selectedIndex >= 0)
            {
                Patron patronEditar = listaPatrones[selectedIndex];
                PatronCusom editarPatron = new PatronCusom(patronEditar.NombrePatron);
                editarPatron.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Patrón no seleccionado");
            }
        }

        private void btnEliminarPatron_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = tablaPatrones.SelectedIndex;
            if(selectedIndex >= 0)
            {
                String patronEliminar = listaPatrones[selectedIndex].NombrePatron;
                MessageBoxResult messageResult = MessageBox.Show("¿Seguro que desea dar de baja el patron " + patronEliminar + "?","Confirmación de baja", MessageBoxButton.YesNo);
                if(messageResult == MessageBoxResult.Yes)
                {
                    if (PatronDAO.darBajaPatron(patronEliminar) > 0)
                    {
                        MessageBox.Show("El patrón se ha dado de baja correctamente");
                        cargarPatronesEnGrid();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error al dar de baja el patrón", "Error de baja");
                    }
                }
            }
        }
    }
}

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
                List<Patron> listaPatrones = new List<Patron>();
                listaPatrones = PatronDAO.obtenerListaPatronesCompleta();
                tablaPatrones.AutoGenerateColumns = true;
                tablaPatrones.ItemsSource = listaPatrones;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

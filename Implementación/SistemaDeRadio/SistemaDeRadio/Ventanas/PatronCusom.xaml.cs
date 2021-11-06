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
        public PatronCusom()
        {
            InitializeComponent();
            cargarGenerosCombo();
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
                try
                {
                    PatronDAO.registrarPatronNuevo(patronGuardar);
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cargarGenerosCombo()
        {
            List<Genero> listaGeneros = null;
            try
            {
                listaGeneros = GeneroDAO.obtenerGeneros();
                foreach (Genero genero in listaGeneros)
                {
                    cbGeneros.Items.Add(genero);
                }
            }catch (NullReferenceException ex)
            {
                MessageBox.Show("Ocurrio un error de conexión, intentélo de nuevo más tarde", "Error al cargar los datos");
            }
        }
    }
}

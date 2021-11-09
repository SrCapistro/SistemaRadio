using SistemaDeRadio.DAO;
using SistemaDeRadio.POCO;
using SistemaDeRadio.Ventanas;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaDeRadio
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static String estacion = "";

        private void btnConectar_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_iniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            String nombreUsuario = txt_usuario.Text;
            String contraseñaUsuario = txt_contraseña.Password;

            if(nombreUsuario.Length > 0 && contraseñaUsuario.Length > 0)
            {
                Usuario userRespuesta = UsuarioDAO.obtenerLogin(nombreUsuario, contraseñaUsuario);
                if(userRespuesta != null)
                {
                    MessageBox.Show("Bienvenido al sistema " + userRespuesta.NombreUsr + " Tipo: " + userRespuesta.TipoUsr);
                    estacion = userRespuesta.EstacionUsr;
                    abrirVentanaPrincipal();
                }
                else
                {
                    MessageBox.Show("Datos incorrectos, favor de verificarlos", "Error");
                }
            }
            else
            {
                MessageBox.Show("Usuario y contraseña obligatorios", "Campos vacios");
            }
        }

        public void abrirVentanaPrincipal()
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
            pantallaPrincipal.Show();
            this.Close();
        }
    }
}

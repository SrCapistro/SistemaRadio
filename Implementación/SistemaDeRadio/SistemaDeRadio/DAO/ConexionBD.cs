using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.DAO
{
    class ConexionBD
    {
        public void conectarBD()
        {
            String servidor = "localhost";
            String puerto = "3306";
            String user = "root";
            String password = "Trujillo17.";

            String conexion = "server=" + servidor + "; port=" + puerto + "; user=" + user + "; password=" + password + "; database= ejemplo;";

            MySqlConnection conectarBD = new MySqlConnection(conexion);

            try
            {
                conectarBD.Open();
                if (conectarBD != null)
                {
                    Console.WriteLine("Conexión exitosa");

                }
                else
                {
                    Console.WriteLine("Conexión NO exitosa");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

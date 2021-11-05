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
        public static MySqlConnection getConnetion()
        {
            String servidor = "bqsg3zw0kj8i15aq8xxa-mysql.services.clever-cloud.com";
            String puerto = "3306";
            String user = "uwe4mt0lhwelrvrp";
            String password = "PUt79sgdxDTq1lAer8gX";
            String db = "bqsg3zw0kj8i15aq8xxa";

            String conexion = "server=" + servidor + "; port=" + puerto + "; user=" + user + "; password=" + password + "; database=" + db + ";";

            MySqlConnection connMysql = new MySqlConnection(conexion);
            try
            {
                connMysql.Open();
                if (connMysql != null)
                {
                    return connMysql;

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return null;
        }
    }
}

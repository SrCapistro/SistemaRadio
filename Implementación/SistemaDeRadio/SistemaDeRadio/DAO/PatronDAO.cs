using MySql.Data.MySqlClient;
using SistemaDeRadio.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.DAO
{
    class PatronDAO
    {
        public static int registrarPatronNuevo(Patron patronRegistrar)
        {
            int resultado = 0;
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    String query = "INSERT INTO mus_patrones VALUES(@PTRN_NOMBRE, @PTRN_USO);";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("@PTRN_NOMBRE", patronRegistrar.NombrePatron);
                    command.Parameters.AddWithValue("@PTRN_USO", 0);
                    resultado = command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
            return resultado;
        }
    }
}

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

        public static bool comprobarExistenciaPatron(String nombrePatron)
        {
            bool existe = false;
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if(conn!= null)
                {
                    String SQL = String.Format("SELECT * FROM mus_patrones WHERE PTRN_NOMBRE = '{0}';", nombrePatron);
                    MySqlCommand command = new MySqlCommand(SQL, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Patron patronObtenido = new Patron();
                        patronObtenido.NombrePatron = Convert.ToString(reader["PTRN_NOMBRE"]);
                        if (patronObtenido.NombrePatron.Equals(nombrePatron))
                        {
                            existe = true;
                        }
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return existe;
        }

        public static int registrarListaDePatron(List<Cancion> listaCancionesPatron, String nombrePatron)
        {
            int resultado = 0;
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if(conn != null)
                {
                    foreach(Cancion cancion in listaCancionesPatron)
                    {
                        String SQL = "INSERT INTO mus_listacanciones VALUES(@LIST_COMENTARIOS, @LIST_PATRON, @LIST_IDCANCION);";
                        MySqlCommand command = new MySqlCommand(SQL, conn);
                        command.Parameters.AddWithValue("@LIST_COMENTARIOS", "");
                        command.Parameters.AddWithValue("@LIST_PATRON", nombrePatron);
                        command.Parameters.AddWithValue("@LIST_IDCANCION", cancion.CancionID);
                        resultado = command.ExecuteNonQuery();
                    }
                    conn.Close ();
                }
            }catch(Exception ex)
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

        public static List<Patron> obtenerPatrones()
        {
            List<Patron> patrones = new List<Patron>();
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                String consulta = "SELECT ptrn_nombre FROM mus_patrones;";
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    Patron patron = new Patron();
                    patron.NombrePatron = (!leer.IsDBNull(0)) ? leer.GetString("ptrn_nombre") : "";
                    patrones.Add(patron);
                }
                leer.Close();
                comando.Dispose();
            }
            return patrones;
        }
    }
}

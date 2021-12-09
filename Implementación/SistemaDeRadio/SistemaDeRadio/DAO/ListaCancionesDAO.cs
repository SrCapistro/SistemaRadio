using MySql.Data.MySqlClient;
using SistemaDeRadio.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.DAO
{
    class ListaCancionesDAO
    {

        public static List<ListaCanciones> obtenerCancionesDeUnPatron(string nombrePatron)
        {
            List<ListaCanciones> canciones = new List<ListaCanciones>();
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                String consulta = string.Format("SELECT c.can_id, c.can_titulo as Canciones, lc.list_comentarios as Comentarios, lc.list_patron FROM mus_canciones c " +
                    "LEFT JOIN mus_listacanciones lc ON c.CAN_ID = lc.LIST_IDCANCION WHERE lc.LIST_PATRON = '{0}';", nombrePatron);
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    ListaCanciones lista = new ListaCanciones();
                    lista.IdCancion = (!leer.IsDBNull(0)) ? leer.GetInt32("can_id") : 0;
                    lista.NombreCancion = (!leer.IsDBNull(1)) ? leer.GetString("Canciones") : "";
                    lista.Comentarios = (!leer.IsDBNull(2)) ? leer.GetString("Comentarios") : "";
                    lista.NombrePatron = (!leer.IsDBNull(3)) ? leer.GetString("list_patron") : "";
                    canciones.Add(lista);
                }
                leer.Close();
                comando.Dispose();
            }
            return canciones;
        }

        public static List<Cancion> obtenerCancionesPorNombre(string nombre)
        {
            List<Cancion> cancionesRegistradas = new List<Cancion>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    String query = String.Format("SELECT FROM mus_canciones WHERE CAN_TITULO = '{0}';", nombre);
                    MySqlCommand command = new MySqlCommand(query, conn);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cancion cancion = new Cancion();
                        cancion.CancionID = (long)reader["CAN_ID"];
                        cancion.CancionTitulo = reader.GetString(1);
                        cancion.CancionCategoria = (long)reader["CAN_CATEGORIA"];
                        cancion.CancionGenero = (long)reader["CAN_GENERO"];
                        cancion.CancionClave = reader.GetString(4);
                        cancion.CancionDias = reader.GetString(5);
                        cancion.CancionAutor = (long)reader["CAN_CANTANTE"];
                        cancionesRegistradas.Add(cancion);
                    }
                    command.Dispose();
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExcepción en CancionDAO en método obtenerCancionesPorNombre():");
                Console.WriteLine(e.Message);
                Console.WriteLine("----------------------------------------------------------------\n");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return cancionesRegistradas;
        }

        public static List<Cancion> obtenerCanciones()
        {
            List<Cancion> canciones = new List<Cancion>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    String query = String.Format("SELECT * FROM mus_canciones;");
                    MySqlCommand command = new MySqlCommand(query, conn);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cancion cancion = new Cancion();
                        cancion.CancionID = (long)reader["CAN_ID"];
                        cancion.CancionTitulo = reader.GetString(1);
                        cancion.CancionCategoria = (long)reader["CAN_CATEGORIA"];
                        cancion.CancionGenero = (long)reader["CAN_GENERO"];
                        cancion.CancionClave = reader.GetString(4);
                        cancion.CancionDias = reader.GetString(5);
                        cancion.CancionAutor = (long)reader["CAN_CANTANTE"];
                        canciones.Add(cancion);
                    }
                    command.Dispose();
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExcepción en CancionDAO en método obtenerTodasLasCanciones():");
                Console.WriteLine(e.Message);
                Console.WriteLine("----------------------------------------------------------------\n");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return canciones;
        }

    }
}

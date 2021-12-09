using MySql.Data.MySqlClient;
using SistemaDeRadio.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.DAO
{
    class CancionDAO
    {
        public static Cancion obtenerCancionesPatron(long categoriaID, long generoID, long cancionID)
        {
            Cancion cancionObtenida = null;
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    if (esUltimoRegistro(cancionID))
                    {
                        String SQL = String.Format("SELECT * FROM mus_canciones " +
                       "WHERE CAN_CATEGORIA = {0} AND CAN_GENERO = {1} order by CAN_ID ASC LIMIT 1;", categoriaID, generoID, cancionID);
                        MySqlCommand command = new MySqlCommand(SQL, conn);
                        MySqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            cancionObtenida = new Cancion();
                            cancionObtenida.CancionID = Convert.ToInt64(reader["CAN_ID"]);
                            cancionObtenida.CancionTitulo = Convert.ToString(reader["CAN_TITULO"]);
                            cancionObtenida.CancionCategoria = Convert.ToInt64(reader["CAN_CATEGORIA"]);
                            cancionObtenida.CancionGenero = Convert.ToInt64(reader["CAN_GENERO"]);
                            cancionObtenida.CancionClave = Convert.ToString(reader["CAN_CLAVE"]);
                            cancionObtenida.CancionDias = Convert.ToString(reader["CAN_DIAS"]);
                            cancionObtenida.CancionAutor = Convert.ToInt64(reader["CAN_CANTANTE"]);
                        }
                        reader.Close();
                        command.Dispose();
                    }
                    else
                    {
                        String SQL = String.Format("SELECT * FROM mus_canciones " +
                       "WHERE CAN_CATEGORIA = {0} AND CAN_GENERO = {1} AND CAN_ID > {2} LIMIT 1;", categoriaID, generoID, cancionID);
                        MySqlCommand command = new MySqlCommand(SQL, conn);
                        MySqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            cancionObtenida = new Cancion();
                            cancionObtenida.CancionID = Convert.ToInt64(reader["CAN_ID"]);
                            cancionObtenida.CancionTitulo = Convert.ToString(reader["CAN_TITULO"]);
                            cancionObtenida.CancionCategoria = Convert.ToInt64(reader["CAN_CATEGORIA"]);
                            cancionObtenida.CancionGenero = Convert.ToInt64(reader["CAN_GENERO"]);
                            cancionObtenida.CancionClave = Convert.ToString(reader["CAN_CLAVE"]);
                            cancionObtenida.CancionDias = Convert.ToString(reader["CAN_DIAS"]);
                            cancionObtenida.CancionAutor = Convert.ToInt64(reader["CAN_CANTANTE"]);
                        }
                        reader.Close();
                        command.Dispose();
                    }
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return cancionObtenida;

        }

        public static bool esUltimoRegistro(long cancionID)
        {
            bool esUltimo = false;
            MySqlConnection conn = null;
            try
            {
                long valorObtenido = 0;
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    String SQL = String.Format("select MAX(mus_canciones.CAN_ID) from mus_canciones;");
                    MySqlCommand command = new MySqlCommand(SQL, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        valorObtenido = reader.GetInt32(0);
                    }
                    reader.Close();
                    command.Dispose();
                }
                if (valorObtenido == cancionID)
                {
                    esUltimo = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return esUltimo;
        }

        public static int obtenerUltimaCancionLinea(long categoriaID, long generoID)
        {
            int idCancion = 0;
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    String SQL = String.Format("select ml.LIST_IDCANCION from mus_listacanciones ml  "+
                            "where LIST_IDCATEGORIA = {0} and LIST_IDGENERO = {1} " +
                           "order by LIST_IDCANCION desc limit 1; ", categoriaID, generoID);
                    MySqlCommand command = new MySqlCommand(SQL, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        idCancion = reader.GetInt32(0);
                    }
                    reader.Close();
                    command.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return idCancion;
        }

        public static int contarCancionesLinea(long categoriaID, long generoID)
        {
            int numeroCanciones = 0;
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    String SQL = String.Format("SELECT COUNT(1) FROM mus_canciones " +
                        "WHERE CAN_CATEGORIA = {0} AND CAN_GENERO = {1};", categoriaID, generoID);
                    MySqlCommand command = new MySqlCommand(SQL, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        numeroCanciones = reader.GetInt32(0);
                    }
                    reader.Close();
                    command.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return numeroCanciones;
        }

        public static int eliminarListaLineasActualizaras(String nombrePatron)
        {
            int seBorro = 0;
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    String SQL = String.Format("DELETE FROM mus_listacanciones WHERE LIST_PATRON = '{0}'", nombrePatron);
                    MySqlCommand command = new MySqlCommand(SQL, conn);
                    seBorro = command.ExecuteNonQuery();
                    command.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return seBorro;
        }

        public static void agregarCancion(string nombre, long categoria, long genero, string clave, string dias, long artista)
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    MySqlCommand command;
                    MySqlDataReader dataReader;
                    String query = String.Format("INSERT INTO mus_canciones " +
                        "(CAN_TITULO, CAN_CATEGORIA, CAN_GENERO, CAN_CLAVE, CAN_DIAS, CAN_CANTANTE) " +
                        "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');", nombre, categoria, genero, clave, dias, artista);
                    command = new MySqlCommand(query, conn);
                    dataReader = command.ExecuteReader();
                    dataReader.Close();
                    command.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExcepción en CancionDAO en método agregarCancion():");
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
        }

        public static void modificarCancion(string nombre, long categoria, long genero,  long artista, long cancionID)
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    MySqlCommand command;
                    MySqlDataReader dataReader;
                    String query = String.Format("UPDATE mus_canciones " +
                        "SET CAN_TITULO = '{0}', CAN_CATEGORIA = '{1}', CAN_GENERO = '{2}', CAN_CANTANTE = '{3}' " +
                        "WHERE CAN_ID = '{4}'", nombre, categoria, genero, artista, cancionID);
                    command = new MySqlCommand(query, conn);
                    dataReader = command.ExecuteReader();
                    dataReader.Close();
                    command.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExcepción en CancionDAO en método modificarCancion():");
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
        }

        public static void eliminarCancion(long cancionID)
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    MySqlCommand command;
                    MySqlDataReader dataReader;
                    String query = String.Format("DELETE FROM mus_canciones " +
                        "WHERE CAN_ID = '{0}'", cancionID);
                    command = new MySqlCommand(query, conn);
                    dataReader = command.ExecuteReader();
                    dataReader.Close();
                    command.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExcepción en CancionDAO en método eliminarCancion():");
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
        }
<<<<<<< HEAD
// <<<<<<< HEAD
        
// =======
=======
//<<<<<<< HEAD
        
//=======
>>>>>>> 4e8db1803dba787a78041a6cf58e6ec9094b282f

        public static List<Cancion> buscarCancionesPorNombre(string cadenaDeBusqueda)
        {
            List<Cancion> canciones = new List<Cancion>();
            MySqlConnection conn = null;
            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                String consulta = string.Format("SELECT CAN_ID, CAN_TITULO as Titulo from mus_canciones WHERE CAN_TITULO LIKE '%{0}%' LIMIT 5;", cadenaDeBusqueda);
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    Cancion cancion = new Cancion();
                    cancion.CancionTitulo = (!leer.IsDBNull(0)) ? leer.GetString("Titulo") : "";
                    canciones.Add(cancion);
                }
                conn.Close();
                comando.Dispose();
            }
            return canciones;
        }

//>>>>>>> ddd737cf10eef125dbbbd6529f01da2dee089445
    }
}

using MySql.Data.MySqlClient;
using SistemaDeRadio.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.DAO
{
    class ArtistaDAO
    {

        public static void agregarArtista(string nombre)
        {
            string estado = "Habilitado";
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    MySqlCommand command;
                    MySqlDataReader dataReader;
                    String query = String.Format("INSERT INTO mus_cantantes (CTN_NOMBRE, CNT_ESTADO) VALUES('{0}', '{1}');", nombre, estado);
                    command = new MySqlCommand(query, conn);
                    dataReader = command.ExecuteReader();
                    dataReader.Close();
                    command.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExcepción en ArtistaDAO en método agregarArtista():");
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

        public static void inhabilitarArtista(long artistaID)
        {
            string estado = "Inhabilitado";
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    MySqlCommand command;
                    MySqlDataReader dataReader;
                    String query = String.Format("UPDATE mus_cantantes " +
                        "SET CNT_ESTADO = '{0}' WHERE CNT_ID = '{1}'", estado, artistaID);
                    command = new MySqlCommand(query, conn);
                    dataReader = command.ExecuteReader();
                    dataReader.Close();
                    command.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExcepción en ArtistaDAO en método inhabilitarArtista():");
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

        public static List<Artista> obtenerArtistas()
        {
            List<Artista> artistasRegistradas = new List<Artista>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
<<<<<<< HEAD
                    String query = "SELECT FROM mus_cantantes WHERE CNT_ESTADO = 'Inhabilitado';";
=======
                    String query = "SELECT * FROM mus_cantantes;";
>>>>>>> 4e8db1803dba787a78041a6cf58e6ec9094b282f
                    MySqlCommand command = new MySqlCommand(query, conn);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Artista artista = new Artista();
                        artista.ArtistaID = (long)reader["CNT_ID"];
<<<<<<< HEAD
                        artista.ArtistaNombre = reader.GetString(1);
                        artista.ArtistaEstado = reader.GetString(2);
=======
                        artista.ArtistaNombre = reader["CNT_NOMBRE"].ToString();
                        artista.ArtistaEstado = reader["CNT_ESTADO"].ToString();
>>>>>>> 4e8db1803dba787a78041a6cf58e6ec9094b282f
                        artistasRegistradas.Add(artista);
                    }
                    command.Dispose();
                    reader.Close();
                }
            }
<<<<<<< HEAD
            catch (NullReferenceException e)
            {
                Console.WriteLine("\nExcepción en ArtistaDAO en método obtenerArtistas():");
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
            return artistasRegistradas;
        }

        public static List<Artista> obtenerArtistaPorNombre(string nombre)
        {
            List<Artista> artistasRegistradas = new List<Artista>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    String query = String.Format("SELECT FROM mus_cantantes WHERE CNT_NOMBRE = '{0}';", nombre);
                    MySqlCommand command = new MySqlCommand(query, conn);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Artista artista = new Artista();
                        artista.ArtistaID = (long)reader["CNT_ID"];
                        artista.ArtistaNombre = reader.GetString(1);
                        artista.ArtistaEstado = reader.GetString(2);
                        artistasRegistradas.Add(artista);
                    }
                    command.Dispose();
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExcepción en ArtistaDAO en método obtenerArtistasPorNombre():");
                Console.WriteLine(e.Message);
                Console.WriteLine("----------------------------------------------------------------\n");
=======
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.StackTrace);
>>>>>>> 4e8db1803dba787a78041a6cf58e6ec9094b282f
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return artistasRegistradas;
        }

    }
}

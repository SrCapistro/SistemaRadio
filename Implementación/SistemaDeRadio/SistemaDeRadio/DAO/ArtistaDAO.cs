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
                    String query = "SELECT * FROM mus_cantantes;";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Artista artista = new Artista();
                        artista.ArtistaID = (long)reader["CNT_ID"];
                        artista.ArtistaNombre = reader["CNT_NOMBRE"].ToString();
                        artista.ArtistaEstado = reader["CNT_ESTADO"].ToString();
                        artistasRegistradas.Add(artista);
                    }
                    command.Dispose();
                    reader.Close();
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.StackTrace);
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

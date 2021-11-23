using MySql.Data.MySqlClient;
using SistemaDeRadio.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.DAO
{
    class GeneroDAO
    {
        public static List<Genero> obtenerGeneros()
        {
            List <Genero> generosRegistrados = new List<Genero> ();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    String query = "SELECT * FROM mus_generos;";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Genero genero = new Genero();
                        genero.GeneroID = (long)reader["GNR_ID"];
                        genero.GeneroNombre = reader.GetString(1);
                        generosRegistrados.Add(genero);
                    }
                    command.Dispose();
                    reader.Close(); 
                }
            }catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
            return generosRegistrados;
        }

        public static List<Genero> obtenerGeneroPorCategoria(long idCategoria)
        {
            List<Genero> generosRegistrados = new List<Genero>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    String query = String.Format("select distinct mg.GNR_ID, mg.GNR_NOMBRE from mus_generos mg " +
                        "join mus_canciones mc on mc.CAN_CATEGORIA = {0} and mg.GNR_ID = mc.CAN_GENERO;", idCategoria);
                    MySqlCommand command = new MySqlCommand(query, conn);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Genero genero = new Genero();
                        genero.GeneroID = (long) reader["GNR_ID"];
                        genero.GeneroNombre = reader.GetString(1);
                        generosRegistrados.Add(genero);
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
            return generosRegistrados;
        }

        public static void agregarGenero(string nombre)
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    MySqlCommand command;
                    MySqlDataReader dataReader;
                    String query = String.Format("INSERT INTO mus_generos (GNR_NOMBRE) VALUES('{0}');", nombre);
                    command = new MySqlCommand(query, conn);
                    dataReader = command.ExecuteReader();
                    dataReader.Close();
                    command.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nExcepción en GeneroDAO en método agregarGenero():");
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

    }
}

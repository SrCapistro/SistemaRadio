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
                        Console.WriteLine(genero.GeneroNombre);
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
    }
}

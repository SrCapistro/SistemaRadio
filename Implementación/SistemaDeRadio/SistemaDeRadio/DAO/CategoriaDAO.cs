using MySql.Data.MySqlClient;
using SistemaDeRadio.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.DAO
{
    class CategoriaDAO
    {
        public static List<Categoria> obtenerCategorias()
        {
            List<Categoria> categoriasRegistradas = new List<Categoria>();
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    String query = "SELECT * FROM mus_categorias;";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Categoria categoria = new Categoria();
                        categoria.CategoriaID = (long)reader["CAT_ID"];
                        categoria.CategoriaNombre = reader["CAT_NOMBRE"].ToString();
                        categoriasRegistradas.Add(categoria);
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
            return categoriasRegistradas;
        }
    }
}

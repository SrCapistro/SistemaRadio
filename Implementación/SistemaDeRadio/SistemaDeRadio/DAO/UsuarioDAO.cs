using MySql.Data.MySqlClient;
using SistemaDeRadio.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.DAO
{
    class UsuarioDAO
    {
        public static Usuario obtenerLogin(String nombreUsuario, String contraseña)
        {
            Usuario usr = null;
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if(conn != null)
                {
                    MySqlCommand command;
                    MySqlDataReader reader;
                    String query = String.Format("SELECT * from mus_usuarios where USR_NOMBREUSUARIO = '{0}' and USR_CONTRA = '{1}';",
                        nombreUsuario, contraseña);
                    command = new MySqlCommand(query, conn);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        usr = new Usuario();
                        usr.EstacionUsr = Convert.ToString(reader["USR_ESTACION"]);
                        usr.NombreUsr = Convert.ToString(reader["USR_NOMBREUSUARIO"]);
                        usr.ContraUsr = contraseña;
                        usr.TipoUsr = Convert.ToString(reader["USR_TIPO"]);
                    }
                    reader.Close();
                    command.Dispose();
                }

            }catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return usr;
        }

    }
}

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
                        usr.EstacionUsr = (!reader.IsDBNull(0)) ? reader.GetString(0) : "";
                        usr.NombreUsr = (reader.IsDBNull(1)) ? reader.GetString(1) : "";
                        usr.ContraUsr = (reader.IsDBNull(2)) ? reader.GetString(2) : "";
                        usr.TipoUsr = (reader.IsDBNull(3)) ? reader.GetString(3) : "";
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

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SistemaDeRadio.DAO
{
    class FormatoDAO
    {
        /*public static int registrarFormato(int idHorario, string nombrePatron, int ordenElementos, DataGridRow row, DataGrid dgFormato)
        {
            int resultado = 0;
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if(conn!= null)
            {
                string consulta = "INSERT INTO mus_formato VALUES (@idHorarioPrograma, @idPatron, @nombreElemento, @comentarios, @ordenElementos);";
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                foreach (DataGridRow rows in dgFormato.Items)
                {
                    comando.Parameters.AddWithValue("@idHorarioPrograma", idHorario);
                comando.Parameters.AddWithValue("@idPatron", nombrePatron);
                    comando.Parameters.Add("@nombreElemento", MySqlDbType.VarChar).Value = rows.GetValue("").ToString;
                }
                
                
            }
        }*/
    }
}

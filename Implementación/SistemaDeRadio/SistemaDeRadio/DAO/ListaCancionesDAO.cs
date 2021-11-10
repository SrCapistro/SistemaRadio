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
    }
}

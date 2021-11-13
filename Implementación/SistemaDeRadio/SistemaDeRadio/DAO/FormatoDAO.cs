using MySql.Data.MySqlClient;
using SistemaDeRadio.POCO;
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
        public static int registrarFormato(List<Formato> formatos)
        {
            int resultado = 0;
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if(conn!= null)
            {
                int tamañoLista = formatos.Count();
                int contador = 0;
                while (contador < tamañoLista)
                {
                    string consulta = "INSERT INTO mus_formato (idHorarioPrograma, idPatron, nombreElemento, comentarios, ordenElementos) VALUES (@idHorarioPrograma, @idPatron, @nombreElemento, @comentarios, @ordenElementos);";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@idHorarioPrograma", formatos[contador].IdHorarioPrograma);
                    comando.Parameters.AddWithValue("idPatron", formatos[contador].NombrePatron);
                    comando.Parameters.AddWithValue("@nombreElemento", formatos[contador].NombreElemento);
                    comando.Parameters.AddWithValue("@comentarios", formatos[contador].Comentarios);
                    comando.Parameters.AddWithValue("@ordenElementos", formatos[contador].OrdenElementos);
                    comando.ExecuteNonQuery();
                    contador++;
                }
                conn.Close();
                resultado = contador;
                
            }
            return resultado;
        }

        public static string obtenerPatronDeUnFormato(int idHorario)
        {
            string patron = "";
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                string consulta = string.Format("SELECT idPatron FROM mus_formato WHERE idHorarioPrograma = '{0}' GROUP BY idPatron;", idHorario);
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    patron = (!leer.IsDBNull(0)) ? leer.GetString("idPatron") : "";
                }
                leer.Close();
                comando.Dispose();
            }
            return patron;
        }


        //Metodo para obtener los elementos correspondientes de un programa segun la tabla de formato, por eso en esta clase
        public static List<Formato> obtenerElementosDelPrograma(int idHorario)
        {
            List<Formato> elementosFormato = new List<Formato>();
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {

                String consulta = string.Format("SELECT f.idHorarioPrograma, f.idPatron, f.nombreElemento, f.comentarios, f.ordenElementos " +
                    "FROM mus_formato f INNER JOIN mus_horario h ON f.idHorarioPrograma = {0} " +
                    "GROUP BY f.idHorarioPrograma, f.idPatron, f.nombreElemento, f.comentarios, f.ordenElementos", idHorario);

                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    Formato formato = new Formato();
                    formato.IdHorarioPrograma = (!leer.IsDBNull(0)) ? leer.GetInt32("idHorarioPrograma") : 0;
                    formato.NombrePatron = (!leer.IsDBNull(1)) ? leer.GetString("idPatron") : "";
                    formato.NombreElemento = (!leer.IsDBNull(2)) ? leer.GetString("nombreElemento") : "";
                    formato.Comentarios = (!leer.IsDBNull(3)) ? leer.GetString("comentarios") : "";
                    formato.OrdenElementos = (!leer.IsDBNull(4)) ? leer.GetInt32("ordenElementos") : 0;
                    elementosFormato.Add(formato);
                }
                leer.Close();
                comando.Dispose();
            }
            return elementosFormato;
        }
    }
}

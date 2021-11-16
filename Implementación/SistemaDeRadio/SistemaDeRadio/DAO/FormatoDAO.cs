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

        public static int actualizarFormato(List<Formato> formato, int idHorario)
        {
            int resultado = 0;
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                int tamañoLista = formato.Count();
                int contador = 0;
                while (contador < tamañoLista)
                {
                    string consulta = "UPDATE mus_formato set nombreElemento = @nombreElemento, comentarios = @comentarios WHERE idHorarioPrograma = @idHorarioPrograma " +
                        "AND ordenElementos = @ordenElementos;";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@nombreElemento", formato[contador].NombreElemento);
                    comando.Parameters.AddWithValue("@comentarios", formato[contador].Comentarios);
                    comando.Parameters.AddWithValue("@idHorarioPrograma", idHorario);
                    comando.Parameters.AddWithValue("@ordenElementos", contador);
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

<<<<<<< HEAD
        public static List<Formato> obtenerFormatoDeProgramaEnOrden(int idHorarioPrograma, string nombrePatron)
        {
            List<Formato> formatoObtenido = new List<Formato>();
=======
        public static List<ReporteProgramacionDelDia> obtenerElementosParaReporteDelDia(String estacion, String diaSemana)
        {
            List<ReporteProgramacionDelDia> elementosReporte = new List<ReporteProgramacionDelDia>();
>>>>>>> 2fd20b1b3f9dc1f582828af596faac96e5cf02fa
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
<<<<<<< HEAD
                string consulta = string.Format("SELECT nombreElemento, comentarios FROM mus_formato WHERE idHorarioPrograma = {0} and idPatron = '{1}' " +
                    "ORDER BY ordenElementos;", idHorarioPrograma, nombrePatron);
=======

                String consulta = string.Format("SELECT h.idPrograma, h.horaInicio, h.horaFin, f.nombreElemento, f.comentarios, f.idPatron, p.estacion " +
                    "FROM mus_horario h INNER JOIN mus_formato f ON h.idHorario = f.idHorarioPrograma INNER JOIN mus_programas p " +
                    "ON h.idPrograma = p.nombre AND p.estacion = '{0}' AND h.diaProgramado = '{1}' " +
                    "GROUP BY h.idPrograma, h.horaInicio, h.horaFin, f.nombreElemento, f.comentarios, f.idPatron, p.estacion ", estacion, diaSemana);

>>>>>>> 2fd20b1b3f9dc1f582828af596faac96e5cf02fa
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
<<<<<<< HEAD
                    Formato formato = new Formato();
                    formato.NombreElemento = leer.GetString("nombreElemento");
                    formato.Comentarios = leer.GetString("comentarios");
                    formatoObtenido.Add(formato);
=======
                    ReporteProgramacionDelDia reporte = new ReporteProgramacionDelDia();
                    reporte.NombrePrograma = (!leer.IsDBNull(0)) ? leer.GetString("idPrograma") : "";
                    reporte.HoraInicio = (!leer.IsDBNull(1)) ? leer.GetString("horaInicio") : "";
                    reporte.HoraFin = (!leer.IsDBNull(2)) ? leer.GetString("horaFin") : "";
                    reporte.NombreElemento = (!leer.IsDBNull(3)) ? leer.GetString("nombreElemento") : "";
                    reporte.Comentario = (!leer.IsDBNull(4)) ? leer.GetString("comentarios") : "";
                    reporte.NombrePatron = (!leer.IsDBNull(5)) ? leer.GetString("idPatron") : "";
                    reporte.NombreEstacion = (!leer.IsDBNull(6)) ? leer.GetString("estacion") : "";
                    elementosReporte.Add(reporte);
>>>>>>> 2fd20b1b3f9dc1f582828af596faac96e5cf02fa
                }
                leer.Close();
                comando.Dispose();
            }
<<<<<<< HEAD
            return formatoObtenido;
        }

        public static int desagendarFormato(int idHorario)
        {
            int resultado = 0;

            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {

                string consulta = string.Format("DELETE FROM mus_formato WHERE idHorarioPrograma = {0}", idHorario);
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                resultado = comando.ExecuteNonQuery();
                conn.Close();
            }
            return resultado;
        }
=======
            return elementosReporte;
        }

>>>>>>> 2fd20b1b3f9dc1f582828af596faac96e5cf02fa

    }
}

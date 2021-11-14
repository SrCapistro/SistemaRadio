using MySql.Data.MySqlClient;
using SistemaDeRadio.POCO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.DAO
{
    class ProgramaDAO
    {

        public static List<Programa> obtenerProgramasProgramados(String diaSemana, String estacion)
        {
            List<Programa> programas = new List<Programa>();
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                String consulta = String.Format("SELECT p.nombre, p.estacion, h.horaInicio, h.horaFin, h.diaProgramado, h.idHorario " +
                    "FROM mus_programas p LEFT JOIN mus_horario h ON  p.nombre = h.idPrograma WHERE p.estacion = '{0}' and h.diaProgramado = '{1}' " +
                    "and p.estatus = 'Activo';", estacion, diaSemana);
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    Programa programa = new Programa();
                    programa.NombrePrograma = (!leer.IsDBNull(0)) ? leer.GetString("nombre") : "";
                    programa.Estacion = (!leer.IsDBNull(1)) ? leer.GetString("estacion") : "";
                    programa.HoraInicio = (!leer.IsDBNull(2)) ? leer.GetString("horaInicio") : "";
                    programa.HoraFin = (!leer.IsDBNull(3)) ? leer.GetString("horaFin") : "";
                    programa.FechaProgramada = (!leer.IsDBNull(4)) ? leer.GetString("diaProgramado") : "";
                    programa.IdHorario = (!leer.IsDBNull(5)) ? leer.GetInt32("idHorario") : 0;
                    programas.Add(programa);
                }
                leer.Close();
                comando.Dispose();
            }
            return programas;
        } 

        public static List<string> obtenerHorasInicio()
        {
            List<string> horas = new List<string>();
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if(conn != null)
            {
                string consulta = "SELECT horaInicio FROM horas;";
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    string hora = "";
                    hora = (!leer.IsDBNull(0)) ? leer.GetString("horaInicio") : "";
                    horas.Add(hora);
                }
                leer.Close();
                comando.Dispose();
            }
            return horas;
        }

        public static List<string> obtenerHorasFin()
        {
            List<string> horas = new List<string>();
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                string consulta = "SELECT horaFin FROM horas;";
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    string hora = "";
                    hora = (!leer.IsDBNull(0)) ? leer.GetString("horaFin") : "";
                    horas.Add(hora);
                }
                leer.Close();
                comando.Dispose();
            }
            return horas;
        }

        public static List<Programa> obtenerTodosLosProgramas(string estacion)
        {
            List<Programa> programas = new List<Programa>();
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                String consulta = string.Format("SELECT * FROM mus_programas WHERE estatus = 'Activo' and estacion = '{0}'", estacion);
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    Programa programa = new Programa();
                    programa.NombrePrograma = (!leer.IsDBNull(0)) ? leer.GetString("nombre") : "";
                    programa.Estacion = (!leer.IsDBNull(2)) ? leer.GetString("estacion") : "";
                    programas.Add(programa);
                }
                leer.Close();
                comando.Dispose();
            }
            return programas;
        }

        public static Boolean verificarProgramaRegistrado(string nombrePrograma)
        {
            Boolean hayRegistro = false;
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                String consulta = string.Format("SELECT nombre FROM mus_programas WHERE nombre = '{0}'", nombrePrograma);
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    hayRegistro = true;
                }
                leer.Close();
                comando.Dispose();
            }
            return hayRegistro;
        }

        public static int registrarPrograma(string nombre, string estacion)
        {
            int resultado = 0;
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                String consulta = "INSERT INTO mus_programas (nombre, estacion, estatus) VALUES (@nombre, @estacion, @estatus)";
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@estacion", estacion);
                comando.Parameters.AddWithValue("@estatus", "Activo");
                resultado = comando.ExecuteNonQuery();
                conn.Close();
                comando.Dispose();
            }
            return resultado;
        }

        public static List<string> obtenerElementos()
        {
            List<string> elementos = new List<string>();
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                string consulta = "SELECT * FROM mus_elementos;";
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    string elemento = "";
                    elemento = (!leer.IsDBNull(0)) ? leer.GetString("nombreElemento") : "";
                    elementos.Add(elemento);
                }
                leer.Close();
                comando.Dispose();
            }
            return elementos;
        }

        public static int agendarPrograma(String horaInicio, String horaFin, String diaProgramado, String idPrograma)
        {
            int resultado = 0;
            List<Programa> programas = new List<Programa>();

            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {

                string consulta = "INSERT INTO mus_horario (horaInicio, horaFin, diaProgramado, idPrograma) VALUES(@horaInicio, @horaFin, @diaProgramado, @idPrograma);";
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                comando.Parameters.AddWithValue("@horaInicio", horaInicio);
                comando.Parameters.AddWithValue("@horaFin", horaFin);
                comando.Parameters.AddWithValue("@diaProgramado", diaProgramado);
                comando.Parameters.AddWithValue("@idPrograma", idPrograma);
                resultado = comando.ExecuteNonQuery();
                conn.Close();
            }
            return resultado;
        }

        public static int obtenerUltimoProgramaAgendado()
        {
            int ultimoIdAgendado = 0;
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                string consulta = "SELECT MAX(idHorario) as idHorario from mus_horario;";
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    ultimoIdAgendado = (!leer.IsDBNull(0)) ? leer.GetInt32("idHorario") : 0;
                }
                leer.Close();
                comando.Dispose();
            }

            return ultimoIdAgendado;
        }

        public static List<Programa> obtenerProgramaActual(string hora, string fecha, string estacion)
        {
            List<Programa> programas = new List<Programa>();
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                
                String consulta = string.Format("SELECT h.idHorario, h.horaInicio, h.horaFin, h.diaProgramado, h.idPrograma, p.estacion " +
                    "FROM mus_horario h LEFT JOIN mus_programas p ON h.idPrograma = p.nombre WHERE h.horaInicio LIKE '{0}' " +
                    "AND h.diaProgramado = '{1}' AND p.estacion = '{2}'", hora, fecha, estacion);

                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    Programa programa = new Programa();
                    programa.IdHorario = (!leer.IsDBNull(0)) ? leer.GetInt32("idHorario") : 0;
                    programa.HoraInicio = (!leer.IsDBNull(1)) ? leer.GetString("horaInicio") : "";
                    programa.HoraFin = (!leer.IsDBNull(2)) ? leer.GetString("horaFin") : "";
                    programa.FechaProgramada = (!leer.IsDBNull(3)) ? leer.GetString("diaProgramado") : "";
                    programa.NombrePrograma = (!leer.IsDBNull(4)) ? leer.GetString("idPrograma") : "";
                    programa.Estacion = (!leer.IsDBNull(5)) ? leer.GetString("estacion") : "";
                    programas.Add(programa);
                }
                leer.Close();
                comando.Dispose();
            }
            return programas;
        }

        public static List<string> obtenerHorasInicioProgramadas(string diaProgramado)
        {
            List<string> horariosInicio = new List<string>();
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                string consulta = string.Format("SELECT horaInicio FROM mus_horario WHERE diaProgramado = '{0}';", diaProgramado);
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    string horaInicio = leer.GetString("horaInicio");
                    horariosInicio.Add(horaInicio);
                }
                leer.Close();
                comando.Dispose();
            }

            return horariosInicio;
        }

        public static List<string> obtenerHorasFinProgramadas(string diaProgramado)
        {
            List<string> horariosFin = new List<string>();
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                string consulta = string.Format("SELECT horaFin FROM mus_horario WHERE diaProgramado = '{0}';", diaProgramado);
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    string horaFin = leer.GetString("horaFin");
                    horariosFin.Add(horaFin);
                }
                leer.Close();
                comando.Dispose();
            }

            return horariosFin;
        }
    }
}

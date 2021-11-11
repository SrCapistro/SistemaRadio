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

        public static List<Programa> obtenerProgramasProgramados(String fecha, String estacion)
        {
            List<Programa> programas = new List<Programa>();
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                String consulta = String.Format("SELECT p.nombre, p.estacion, h.horaInicio, h.horaFin, h.diaProgramado " +
                    "FROM mus_programas p LEFT JOIN mus_horario h ON  p.nombre = h.idPrograma WHERE p.estacion = '{0}' and h.diaProgramado = '{1}' " +
                    "and p.estatus = 'Activo';", estacion, fecha);
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
                    programas.Add(programa);
                }
                leer.Close();
                comando.Dispose();
            }
            return programas;
        } 

        public static List<string> obtenerHoras()
        {
            List<string> horas = new List<string>();
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if(conn != null)
            {
                string consulta = "SELECT * FROM horas;";
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    string hora = "";
                    hora = (!leer.IsDBNull(0)) ? leer.GetString("hora") : "";
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

<<<<<<< HEAD
        public static int agendarPrograma(String horaInicio, String horaFin, String diaProgramado, String idPatron)
        {
            int resultado = 0;
=======
        public static List<Programa> obtenerProgramaActual(string hora)
        {
            List<Programa> programas = new List<Programa>();
>>>>>>> 1c0324a8ac1d95015bc53222e5cd0b12e7b0afd0
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
<<<<<<< HEAD
                string consulta = "INSERT INTO mus_horario VALUES (@horaInicio, @horaFin, @diaProgramado, @idPatron);";
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                comando.Parameters.AddWithValue("@horaInicio", horaInicio);
                comando.Parameters.AddWithValue("@horaFin", horaFin);
                comando.Parameters.AddWithValue("@diaProgramado", diaProgramado);
                comando.Parameters.AddWithValue("@idPatron", idPatron);
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
=======
                String consulta = string.Format("SELECT h.horaInicio, h.horaFin, h.diaProgramado, h.idPrograma FROM mus_horario h WHERE h.horaInicio LIKE '{0}'", hora);

                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    Programa programa = new Programa();
                    programa.HoraInicio = (!leer.IsDBNull(0)) ? leer.GetString("horaInicio") : "";
                    programa.HoraFin = (!leer.IsDBNull(1)) ? leer.GetString("horaFin") : "";
                    programa.FechaProgramada = (!leer.IsDBNull(2)) ? leer.GetString("diaProgramado") : "";
                    programa.NombrePrograma = (!leer.IsDBNull(3)) ? leer.GetString("idPrograma") : "";
                    programas.Add(programa);
>>>>>>> 1c0324a8ac1d95015bc53222e5cd0b12e7b0afd0
                }
                leer.Close();
                comando.Dispose();
            }
<<<<<<< HEAD
            return ultimoIdAgendado;
        }

=======
            return programas;
        }


>>>>>>> 1c0324a8ac1d95015bc53222e5cd0b12e7b0afd0
    }
}

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
            if(conn != null)
            {
                String consulta = String.Format("SELECT p.idPrograma, p.nombre, p.estacion, h.horaInicio, h.horaFin, h.diaProgramado " +
                    "FROM mus_programas p LEFT JOIN mus_horario h ON  p.idPrograma = h.idPrograma WHERE p.estacion = '{0}' and h.diaProgramado = '{1}' " +
                    "and p.estatus = 'Activo';", estacion, fecha);
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    Programa programa = new Programa();
                    programa.IdPrograma = (!leer.IsDBNull(0)) ? leer.GetInt32("idPrograma") : 0;
                    programa.NombrePrograma = (!leer.IsDBNull(1)) ? leer.GetString("nombre"): "";
                    programa.Estacion = (!leer.IsDBNull(2)) ? leer.GetString("estacion") : "";
                    programa.HoraInicio = (!leer.IsDBNull(3)) ? leer.GetString("horaInicio") : "";
                    programa.HoraFin = (!leer.IsDBNull(4)) ? leer.GetString("horaFin") : "";
                    programa.FechaProgramada = (!leer.IsDBNull(5)) ? leer.GetString("diaProgramado") : "";
                    programas.Add(programa);
                }
                leer.Close();
                comando.Dispose();
            }
            return programas;
        }
    }
}

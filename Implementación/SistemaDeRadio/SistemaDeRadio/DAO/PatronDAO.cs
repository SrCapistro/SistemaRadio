using MySql.Data.MySqlClient;
using SistemaDeRadio.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.DAO
{
    class PatronDAO
    {
        public static int registrarPatronNuevo(Patron patronRegistrar)
        {
            int resultado = 0;
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    String query = "INSERT INTO mus_patrones VALUES(@PTRN_NOMBRE, @PTRN_USO, @PTRN_STATUS);";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("@PTRN_NOMBRE", patronRegistrar.NombrePatron);
                    command.Parameters.AddWithValue("@PTRN_USO", 0);
                    command.Parameters.AddWithValue("@PTRN_STATUS", "Activo");
                    resultado = command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
            return resultado;
        }

        public static bool comprobarExistenciaPatron(String nombrePatron)
        {
            bool existe = false;
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if(conn!= null)
                {
                    String SQL = String.Format("SELECT * FROM mus_patrones WHERE PTRN_NOMBRE = '{0}';", nombrePatron);
                    MySqlCommand command = new MySqlCommand(SQL, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Patron patronObtenido = new Patron();
                        patronObtenido.NombrePatron = Convert.ToString(reader["PTRN_NOMBRE"]);
                        if (patronObtenido.NombrePatron.Equals(nombrePatron))
                        {
                            existe = true;
                        }
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return existe;
        }

        public static int registrarListaDePatron(List<Cancion> listaCancionesPatron, String nombrePatron)
        {
            int resultado = 0;
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                if(conn != null)
                {
                    foreach(Cancion cancion in listaCancionesPatron)
                    {
                        String SQL = "INSERT INTO mus_listacanciones VALUES(@LIST_COMENTARIOS, @LIST_PATRON, @LIST_IDCANCION, @LIST_IDCATEGORIA" +
                            ", @LIST_IDGENERO);";
                        MySqlCommand command = new MySqlCommand(SQL, conn);
                        command.Parameters.AddWithValue("@LIST_COMENTARIOS", "");
                        command.Parameters.AddWithValue("@LIST_PATRON", nombrePatron);
                        command.Parameters.AddWithValue("@LIST_IDCANCION", cancion.CancionID);
                        command.Parameters.AddWithValue("@LIST_IDCATEGORIA", cancion.CancionCategoria);
                        command.Parameters.AddWithValue("@LIST_IDGENERO", cancion.CancionGenero);
                        resultado = command.ExecuteNonQuery();
                    }
                    conn.Close ();
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
            return resultado;
        }

        public static List<Patron> obtenerPatrones()
        {
            List<Patron> patrones = new List<Patron>();
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                String consulta = "SELECT ptrn_nombre FROM mus_patrones where PTRN_STATUS = 'Activo';";
                MySqlCommand comando = new MySqlCommand(consulta, conn);
                MySqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    Patron patron = new Patron();
                    patron.NombrePatron = (!leer.IsDBNull(0)) ? leer.GetString("ptrn_nombre") : "";
                    patrones.Add(patron);
                }
                leer.Close();
                comando.Dispose();
            }
            return patrones;
        }

        public static List<Patron> obtenerListaPatronesCompleta()
        {
            List<Patron> patrones = new List<Patron>();
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                String consulta = "SELECT * from mus_patrones where PTRN_STATUS = 'Activo';";
                MySqlCommand comando = new MySqlCommand(@consulta, conn);
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Patron patron = new Patron();
                    patron.NombrePatron = (!reader.IsDBNull(0)) ? reader.GetString("PTRN_NOMBRE") : "";
                    patron.UsoPatron = Convert.ToInt32(reader["PTRN_USO"]);
                    patrones.Add(patron);
                }
                reader.Close();
                comando.Dispose();
            }
            return patrones;
        }

        public static void actualizarPatron(String patronNombre, String patronViejo) 
        { 
            MySqlConnection conn = null;

            conn = ConexionBD.getConnetion();
            if (conn != null)
            {
                String consultaFormato = String.Format("update mus_formato set mus_formato.idPatron = '{0}' where mus_formato.idPatron = '{1}'", patronNombre, patronViejo);
                String consultaCanciones = String.Format("update mus_listacanciones set mus_listacanciones.LIST_PATRON = '{0}' where mus_listacanciones.LIST_PATRON = '{1}';", patronNombre, patronViejo);
                String consultaPatron = String.Format("UPDATE mus_patrones SET PTRN_NOMBRE = '{0}' WHERE PTRN_NOMBRE = '{1}'", patronNombre, patronViejo);
                MySqlCommand comandoFormato = new MySqlCommand(consultaFormato, conn);
                MySqlCommand comandoCanciones = new MySqlCommand(consultaCanciones, conn);
                MySqlCommand comandoPatron = new MySqlCommand(consultaPatron, conn);
                comandoFormato.ExecuteNonQuery();
                comandoCanciones.ExecuteNonQuery();
                comandoPatron.ExecuteNonQuery();
                comandoFormato.Dispose();
                comandoCanciones.Dispose();
                comandoPatron.Dispose();
            }
        }

        public static int darBajaPatron(String nombrePatron)
        {
            int resultado = 0;
            MySqlConnection conn = null;
            try
            {
                conn = ConexionBD.getConnetion();
                String query = String.Format("update mus_patrones SET PTRN_STATUS = 'Inactivo' where PTRN_NOMBRE = '{0}';", nombrePatron);
                MySqlCommand command = new MySqlCommand(query, conn);
                resultado = command.ExecuteNonQuery();
                command.Dispose();
                conn.Close();
            }catch (Exception ex)
            {
                resultado = 0;
            }
            return resultado;

        }

        public static List<LineaPatron> obtenerLineasPatron(String nombrePatron)
        {
            List<LineaPatron> lineaPatrons = new List<LineaPatron>();
            MySqlConnection conn = null;

            try
            {
                conn = ConexionBD.getConnetion();
                if (conn != null)
                {
                    String consulta = String.Format("select ml.LIST_IDCATEGORIA, mc.CAT_NOMBRE, ml.LIST_IDGENERO, mg.GNR_NOMBRE," +
                        "(select count(*) from mus_canciones mc2 where mc2.CAN_CATEGORIA = ml.LIST_IDCATEGORIA and mc2.CAN_GENERO = ml.LIST_IDGENERO) as LIN_CANTIDADCANCIONES " +
                        "from mus_listacanciones ml " +
                        "join mus_categorias mc on ml.LIST_IDCATEGORIA = mc.CAT_ID join mus_generos mg " +
                        "on mg.GNR_ID = ml.LIST_IDGENERO and ml.LIST_PATRON = '{0}';", nombrePatron);
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    MySqlDataReader leer = comando.ExecuteReader();
                    while (leer.Read())
                    {
                        LineaPatron line = new LineaPatron();
                        line.CategoriaLineaID = (!leer.IsDBNull(0)) ? leer.GetInt64("LIST_IDCATEGORIA") : 0;
                        line.CategoriaLinea = (!leer.IsDBNull(1)) ? leer.GetString("CAT_NOMBRE") : "";
                        line.GenerolineaID = (!leer.IsDBNull(2)) ? leer.GetInt64("LIST_IDGENERO") : 0;
                        line.GeneroLinea = (!leer.IsDBNull(3)) ? leer.GetString("GNR_NOMBRE") : "";
                        line.NumeroCanciones = (!leer.IsDBNull(4)) ? leer.GetInt32("LIN_CANTIDADCANCIONES") : 0;
                        lineaPatrons.Add(line);
                    }
                    leer.Close();
                    comando.Dispose();
                }
            }
            catch { throw new Exception(); }
            return lineaPatrons;
        } 
        
        public static int aumentarUsoDePatron(string nombrePatron)
        {
            int resultado = 0;
            MySqlConnection conn = null;
            conn = ConexionBD.getConnetion();
            String query = String.Format("update mus_patrones set PTRN_USO = (PTRN_USO + 1) where PTRN_NOMBRE = '{0}';", nombrePatron);
            MySqlCommand command = new MySqlCommand(query, conn);
            resultado = command.ExecuteNonQuery();
            command.Dispose();
            conn.Close();
            return resultado;
        }
    }
}

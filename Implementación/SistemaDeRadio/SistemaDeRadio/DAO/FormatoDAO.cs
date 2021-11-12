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
    }
}

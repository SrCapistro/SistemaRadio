using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.POCO
{
    class Formato
    {
        private int idFormato;
        private int idHorarioPrograma;
        private string nombrePatron;
        private string nombreElemento;
        private string comentarios;
        private int ordenElementos;

        public int IdFormato { get => idFormato; set => idFormato = value; }
        public int IdHorarioPrograma { get => idHorarioPrograma; set => idHorarioPrograma = value; }
        public string NombrePatron { get => nombrePatron; set => nombrePatron = value; }
        public string NombreElemento { get => nombreElemento; set => nombreElemento = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        public int OrdenElementos { get => ordenElementos; set => ordenElementos = value; }
    }
}

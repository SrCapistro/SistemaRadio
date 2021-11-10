using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.POCO
{
    class ListaCanciones
    {
        private string comentarios;
        private int idCancion;
        private string nombreCancion;
        private string nombrePatron;

        public string Comentarios { get => comentarios; set => comentarios = value; }
        public int IdCancion { get => idCancion; set => idCancion = value; }
        public string NombreCancion { get => nombreCancion; set => nombreCancion = value; }
        public string NombrePatron { get => nombrePatron; set => nombrePatron = value; }
        
    }
}

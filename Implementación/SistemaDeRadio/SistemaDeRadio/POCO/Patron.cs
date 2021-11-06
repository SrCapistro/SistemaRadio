using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.POCO
{
    class Patron
    {
        private String nombrePatron;
        private String usoPatron;
        private List<Cancion> canciones;
        
        public string NombrePatron { get => nombrePatron; set => nombrePatron = value; }
        public string UsoPatron { get => usoPatron; set => usoPatron = value; }
        internal List<Cancion> Canciones { get => canciones; set => canciones = value; }
    }
}

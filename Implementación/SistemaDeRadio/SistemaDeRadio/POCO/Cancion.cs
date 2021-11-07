using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.POCO
{
    class Cancion
    {
        private long cancionID;
        private String cancionTitulo;
        private long cancionCategoria;
        private long cancionGenero;
        private String cancionClave;
        private String cancionDias;
        private long cancionAutor;

        public long CancionID { get => cancionID; set => cancionID = value; }
        public string CancionTitulo { get => cancionTitulo; set => cancionTitulo = value; }
        public long CancionCategoria { get => cancionCategoria; set => cancionCategoria = value; }
        public long CancionGenero { get => cancionGenero; set => cancionGenero = value; }
        public string CancionClave { get => cancionClave; set => cancionClave = value; }
        public string CancionDias { get => cancionDias; set => cancionDias = value; }
        public long CancionAutor { get => cancionAutor; set => cancionAutor = value; }
    }
}

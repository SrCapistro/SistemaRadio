using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.POCO
{
    class Cancion
    {
        private int cancionID;
        private String cancionTitulo;
        private int cancionCategoria;
        private int cancionGenero;
        private String cancionClave;
        private String cancionDias;
        private int cancionAutor;

        public int CancionID { get => cancionID; set => cancionID = value; }
        public string CancionTitulo { get => cancionTitulo; set => cancionTitulo = value; }
        public int CancionCategoria { get => cancionCategoria; set => cancionCategoria = value; }
        public int CancionGenero { get => cancionGenero; set => cancionGenero = value; }
        public string CancionClave { get => cancionClave; set => cancionClave = value; }
        public string CancionDias { get => cancionDias; set => cancionDias = value; }
        public int CancionAutor { get => cancionAutor; set => cancionAutor = value; }
    }
}

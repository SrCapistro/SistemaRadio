using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.POCO
{
    class LineaPatron
    {
        private String generoLinea;
        private String categoriaLinea;
        private long generolineaID;
        private long categoriaLineaID;
        private int numeroCanciones;

        public string GeneroLinea { get => generoLinea; set => generoLinea = value; }
        public string CategoriaLinea { get => categoriaLinea; set => categoriaLinea = value; }
        public int NumeroCanciones { get => numeroCanciones; set => numeroCanciones = value; }
        public long GenerolineaID { get => generolineaID; set => generolineaID = value; }
        public long CategoriaLineaID { get => categoriaLineaID; set => categoriaLineaID = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.POCO
{
    class Artista
    {
        private long artistaID;
        private String artistaNombre;
        private String artistaEstado;

        public long ArtistaID { get => artistaID; set => artistaID = value; }
        public string ArtistaNombre { get => artistaNombre; set => artistaNombre = value; }
        public string ArtistaEstado { get => artistaEstado; set => artistaEstado = value; }
    }
}

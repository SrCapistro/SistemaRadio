using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.POCO
{
    class Genero
    {
        private int generoID;
        private String generoNombre;

        public int GeneroID { get => generoID; set => generoID = value; }
        public string GeneroNombre { get => generoNombre; set => generoNombre = value; }
    }
}

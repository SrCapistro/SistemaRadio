using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.POCO
{
    class Usuario
    {
        private String estacionUsr;
        private String nombreUsr;
        private String contraUsr;
        private String tipoUsr;

        public String EstacionUsr{ get => estacionUsr; set => estacionUsr = value;}
        public String NombreUsr { get => nombreUsr; set => nombreUsr = value;}
        public string ContraUsr { get => contraUsr; set => contraUsr = value; }
        public String TipoUsr { get => tipoUsr; set => tipoUsr = value; }
    }
}

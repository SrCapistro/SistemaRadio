using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.POCO
{
    class Programa
    {
        private long idPrograma;
        private String nombrePrograma;
        private String estacion;
        private String horaInicio;
        private String horaFin;
        private String fechaProgramada;

        public long IdPrograma { get => idPrograma; set => idPrograma = value; }
        public string NombrePrograma { get => nombrePrograma; set => nombrePrograma = value; }
        public string Estacion { get => estacion; set => estacion = value; }
        public string HoraInicio { get => horaInicio; set => horaInicio = value; }
        public string HoraFin { get => horaFin; set => horaFin = value; }
        public string FechaProgramada { get => fechaProgramada; set => fechaProgramada = value; }
    }
}

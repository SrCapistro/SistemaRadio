using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.POCO
{
    class ReporteProgramacionDelDia
    {
        private String nombrePrograma;
        private String horaInicio;
        private String horaFin;
        private String nombreElemento;
        private String comentario;
        private String nombrePatron;
        private String nombreEstacion;

        public string NombrePrograma { get => nombrePrograma; set => nombrePrograma = value; }
        public string HoraInicio { get => horaInicio; set => horaInicio = value; }
        public string HoraFin { get => horaFin; set => horaFin = value; }
        public string NombreElemento { get => nombreElemento; set => nombreElemento = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        public string NombrePatron { get => nombrePatron; set => nombrePatron = value; }
        public string NombreEstacion { get => nombreEstacion; set => nombreEstacion = value; }
    }
}

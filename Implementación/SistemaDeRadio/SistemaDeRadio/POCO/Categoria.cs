using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeRadio.POCO
{
    class Categoria
    {
        private long categoriaID;
        private String categoriaNombre;

        public long CategoriaID { get => categoriaID; set => categoriaID = value; }
        public string CategoriaNombre { get => categoriaNombre; set => categoriaNombre = value; }
    }
}

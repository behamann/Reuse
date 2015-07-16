using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reuse.Models
{
    public class Categoria
    {

        public int categoriaID { get; set; }
        public String titulo { get; set; }
        public static List<Categoria> getCategorias()
        {
            var db = new ReuseContext();
            var categorias = db.Categorias.ToList();
            return categorias;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reuse.Models
{
    public class SubCategoria
    {        
        public int subCategoriaID { get; set; }
        public int categoriaID { get; set; }
        public String titulo { get; set; }
        public Categoria categoria { get; set; }
    }
}
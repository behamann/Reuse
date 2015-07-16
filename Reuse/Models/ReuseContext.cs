using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Reuse.Models
{
    public class ReuseContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ReuseContext() : base("name=ReuseContext")
        {
        }

        public System.Data.Entity.DbSet<Reuse.Models.Tipo> Tipoes { get; set; }

        public System.Data.Entity.DbSet<Reuse.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<Reuse.Models.Instituicao> Instituicaos { get; set; }

        public System.Data.Entity.DbSet<Reuse.Models.Pessoa> Pessoas { get; set; }

        public System.Data.Entity.DbSet<Reuse.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<Reuse.Models.SubCategoria> SubCategorias { get; set; }

        public System.Data.Entity.DbSet<Reuse.Models.Anuncio> Anuncios { get; set; }

        public System.Data.Entity.DbSet<Reuse.Models.Mensagem> Mensagems { get; set; }
    }
}

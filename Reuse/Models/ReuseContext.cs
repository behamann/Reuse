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

        public DbSet<Tipo> Tipoes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Instituicao> Instituicaos { get; set; }

        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<SubCategoria> SubCategorias { get; set; }

        public DbSet<Anuncio> Anuncios { get; set; }

        public DbSet<Mensagem> Mensagems { get; set; }

        public DbSet<Imagem> Imagens { get; set; }

        public DbSet<Avatar> Avatar { get; set; }
    }
}

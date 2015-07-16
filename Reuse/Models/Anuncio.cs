using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reuse.Models
{
    public class Anuncio
    {

        public int anuncioID { get; set; }
        public int pessoaID { get; set; }
        public int categoriaID { get; set; }
        public String subCategoria { get; set; }
        public String condicao { get; set; }
        public String titulo { get; set; }
        public String descricao { get; set; }
        public String img { get; set; }
        //tipo pedido = 0, tipo ofereco = 1
        public bool tipo { get; set; }
        public virtual Pessoa pessoa { get; set; }
        public virtual Categoria categoria { get; set; }
        public bool ativo { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reuse.Models
{
    public abstract class Pessoa
    {

        public int pessoaID { get; set; }
        public String nome { get; set; }
        public String email { get; set; }
        public String endereco { get; set; }
        public String cep { get; set; }
        public String bairro { get; set; }
        public String cidade { get; set; }
        public String estado { get; set; }
        public String telefone { get; set; }
        public String celular { get; set; }
        public virtual ICollection<Anuncio> Anuncios { get; set; }

    }
}
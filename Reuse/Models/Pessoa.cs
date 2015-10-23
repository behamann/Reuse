using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reuse.Models
{
    public abstract class Pessoa
    {

        public int pessoaID { get; set; }

        [DisplayName("Nome")]
        public String Name { get; set; }
        [DisplayName("Email")]
        public String email { get; set; }
        [DisplayName("Endereço")]
        public String endereco { get; set; }
        [DisplayName("CEP")]
        public String cep { get; set; }
        [DisplayName("Bairro")]
        public String bairro { get; set; }
        [DisplayName("Cidade")]
        public String cidade { get; set; }
        [DisplayName("Estado")]
        public String estado { get; set; }
        [DisplayName("Telefone")]
        public String telefone { get; set; }
        [DisplayName("Celular")]
        public String celular { get; set; }
        [DisplayName("Imagem")]
        public virtual ICollection<Avatar> avatar { get; set; }

    }
}
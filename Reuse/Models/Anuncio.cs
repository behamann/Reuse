using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reuse.Models
{
    public class Anuncio
    {

        public int anuncioID { get; set; }
        public int pessoaID { get; set; }
        public int categoriaID { get; set; }

        [DisplayName("Subcategoria")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public String subCategoria { get; set; }

        [DisplayName("Condição")]
        public String condicao { get; set; }

        [DisplayName("Título")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public String titulo { get; set; }

        [DisplayName("Desrição")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public String descricao { get; set; }
        //tipo pedido = 0, tipo ofereco = 1
        public bool tipo { get; set; }
        public virtual Pessoa pessoa { get; set; }
        public virtual Categoria categoria { get; set; }

        [DisplayName("Imagem")]
        public virtual ICollection<Imagem> imagens { get; set; }

        [DisplayName("URL do vídeo")]
        public string video { get; set; }
        public bool ativo { get; set; }

    }
}
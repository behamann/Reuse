using Reuse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Reuse.Models
{
    public class Usuario : Pessoa
    {

        [DisplayName("Itens Doados")]
        public int itensDoados { get; set; }
        [DisplayName("Itens Pedidos")]
        public int itensPedidos { get; set; }
        public bool medalha { get; set; }

    }
}
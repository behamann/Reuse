using Reuse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reuse.Models
{
    public class Usuario : Pessoa
    {
         
        public int itensDoados { get; set; }
        public int itensPedidos { get; set; }
        public bool medalha { get; set; }

    }
}
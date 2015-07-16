using Reuse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reuse.Models
{
    public class Instituicao : Pessoa
    {
        public String nomeContato { get; set; }
        public string cnpj { get; set; }
        public int tipoID { get; set; }
        public virtual Tipo tipo { get; set; }

        public static List<Tipo> getTipos()
        {
            return new ReuseContext().Tipoes.ToList();
        }
    }
}
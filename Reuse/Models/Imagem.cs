using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reuse.Models
{
    public class Imagem
    {
        public int imagemID { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public int anuncioID { get; set; }
        public virtual Anuncio anuncio { get; set; }
    }
}
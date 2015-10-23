using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reuse.Models
{
    public class Mensagem
    {
        public int MensagemID { get; set; }
        public Anuncio Anuncio { get; set; }
        public DateTime DataPostada { get; set; }
        public Usuario Remetente { get; set; }
        public Pessoa Destinatario { get; set; }

        public Mensagem(Anuncio anuncio, Usuario remetente, Pessoa destinatario)
        {
            this.Anuncio = anuncio;
            this.DataPostada = DateTime.Now;
            this.Remetente = remetente;
            this.Destinatario = destinatario;
        }

        public Mensagem() { }
    }
}
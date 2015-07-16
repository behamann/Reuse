using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reuse.Models
{
    public class Mensagem
    {
        public int MensagemID { get; set; }
        public int AnuncioID { get; set; }
        public int RemID { get; set; }
        public String TipoAnuncio { get; set; }
        public String Conteudo { get; set; }
        public DateTime DataPostada { get; set; }
        public String PessoaRem { get; set; }
        public String PessoaDes { get; set; }

        public Mensagem(int anuncioID, int remid, String tipoAnuncio, String conteudo, String remetente, String destinatario)
        {
            this.AnuncioID = anuncioID;
            this.RemID = remid;
            this.TipoAnuncio = tipoAnuncio;
            this.Conteudo = conteudo;
            this.DataPostada = DateTime.Now;
            this.PessoaRem = remetente;
            this.PessoaDes = destinatario;
        }

        public Mensagem() { }
    }
}
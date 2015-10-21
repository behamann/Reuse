using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Reuse.Classes
{
    [DataContract]
    public class Response
    {
        [DataMember(Name = "cep")]
        public string Cep { get; set; }
        [DataMember(Name = "logradouro")]
        public string Logradouro { get; set; }
        [DataMember(Name = "complemento")]
        public string Complemento { get; set; }
        [DataMember(Name = "bairro")]
        public string Bairro { get; set; }
        [DataMember(Name = "localidade")]
        public string Localidade { get; set; }
        [DataMember(Name = "uf")]
        public string UF { get; set; }
    }
}
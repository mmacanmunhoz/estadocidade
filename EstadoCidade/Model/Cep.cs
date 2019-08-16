using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstadoCidade.Model
{
    [BsonIgnoreExtraElements]
    public class Cep
    {
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public string Endereco { get; set; }
    }
}

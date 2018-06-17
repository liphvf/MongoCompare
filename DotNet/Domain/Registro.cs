using System;
using MongoDB.Bson.Serialization.Attributes;

namespace M101N.Domain
{
    public class Registro
    {
        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string CodigoFiscal { get; set; }
    }
}

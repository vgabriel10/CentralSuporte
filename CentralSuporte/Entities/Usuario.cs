using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralSuporte.Entities
{
    class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("nome")]
        public string Nome { get; set; } = string.Empty;

        //[BsonElement("preco")]
        //public double Preco { get; set; }
    }
}

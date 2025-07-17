

using CentralSuporte.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CentralSuporte.Entities
{
    public class Chamado
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Cargo { get; set; }
        public Prioridade Prioridade { get; set; }
        public Status Status { get; set; }
        public string Responsavel { get; set; }
        public string ResponsavelId { get; set; }
        public DateTime DataAbertura { get; set; } = DateTime.Now;
        public DateTime? DataFechamento { get; set; }
    }
}

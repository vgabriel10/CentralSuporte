

using CentralSuporte.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CentralSuporte.Entities
{
    public class Chamado
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public Prioridade Prioridade { get; set; } 
        public Status Status { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string UsuarioId { get; set; } = string.Empty;
        public string Responsavel { get; set; } = string.Empty;
        public string ResponsavelId { get; set; } = string.Empty;
        public DateTime DataAbertura { get; set; } = DateTime.Now;
        public DateTime? DataFechamento { get; set; }
    }
}

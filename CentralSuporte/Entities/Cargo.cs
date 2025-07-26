

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CentralSuporte.Entities
{
    public class Cargo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("nome")]
        public string Nome { get; set; } = string.Empty;
    }
}

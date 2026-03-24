using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace controlcbtis.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
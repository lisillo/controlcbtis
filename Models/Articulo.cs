using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace controlcbtis.Models
{
    public class Articulo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Nombre { get; set; }
        public int Cantidad { get; set; }
    }
}
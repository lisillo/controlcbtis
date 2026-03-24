using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace controlcbtis.Models
{
    public class Alumno
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Nombre { get; set; }
        public string Grupo { get; set; }
        public string Matricula { get; set; }
    }
}
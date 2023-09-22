using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_cooking.Models
{
    public class PersonSport
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty; 
        [BsonElement("personId")]
        public string PersonId { get; set; } = String.Empty;
        [BsonElement("sportId")]
        public string SportId { get; set; } = String.Empty;
    }
}

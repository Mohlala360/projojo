using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_cooking.Models
{
    [BsonIgnoreExtraElements]
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("fistName")]
        public string FirstName { get; set; } = String.Empty;
        [BsonElement("lastName")]
        public string LastName { get; set; } = String.Empty;
        [BsonElement("isAuthorized")]
        public bool IsAuthorized { get; set; }
        [BsonElement("isEnabled")]
        public bool IsEnabled { get; set; }
        [BsonElement("isValid")]
        public bool IsValid { get; set; }
        [BsonElement("isPallndrome")]
        public bool IsPallndrome { get; set; }

    }
}

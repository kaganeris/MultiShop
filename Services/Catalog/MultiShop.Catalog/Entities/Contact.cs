using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Bunun bir Id olduğunu uygulamaya belirttik
        public string ContactId { get; set; } // MongoDB'de ID'ler string olarak tutulur.
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime SendDate { get; set; }
    }
}

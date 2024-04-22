using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Bunun bir Id olduğunu uygulamaya belirttik
        public string CategoryID { get; set; } // MongoDB'de ID'ler string olarak tutulur.
        public string CategoryName { get; set; }
    }
}

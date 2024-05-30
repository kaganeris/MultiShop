using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class Brand
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Bunun bir Id olduğunu uygulamaya belirttik
        public string BrandId { get; set; } // MongoDB'de ID'ler string olarak tutulur.
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
    }
}

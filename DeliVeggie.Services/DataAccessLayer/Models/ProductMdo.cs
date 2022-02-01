using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DeliVeggie.Services.Models
{      
    [BsonIgnoreExtraElements]
    public class ProductMdo
    {       
        public string ProductId { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
    }
}
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LaundryAPI.Models
{
    public class LaundryItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string OrderId { get; set; }

        public string ClothType { get; set; }

        public int Quantity { get; set; }

        public decimal Weight { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal LineTotal { get; set; }
    }
}
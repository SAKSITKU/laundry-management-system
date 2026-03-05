using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LaundryAPI.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string order_id { get; set; }

        public int  user_id { get; set; }

        public string wash_type { get; set; }

        public decimal total_amount { get; set; }

        public string order_status { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? completed_at { get; set; }

        public string note { get; set; }
    }
}
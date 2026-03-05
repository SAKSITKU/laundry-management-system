using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LaundryAPI.Models
{
    public class Payment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string OrderId { get; set; }

        public decimal AmountPaid { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentStatus { get; set; }

        public string PaymentSlip { get; set; }

        public DateTime VerifiedAt { get; set; }
    }
}
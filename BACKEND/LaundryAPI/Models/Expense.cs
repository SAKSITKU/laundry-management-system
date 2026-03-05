using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LaundryAPI.Models
{
    public class Expense
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ExpenseType { get; set; }

        public string ExpenseDescription { get; set; }

        public decimal Amount { get; set; }

        public DateTime ExpenseDate { get; set; }

        public string CreatedBy { get; set; }
    }
}
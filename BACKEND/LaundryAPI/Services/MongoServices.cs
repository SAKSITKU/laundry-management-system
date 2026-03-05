using MongoDB.Driver;
using LaundryAPI.Models;

namespace LaundryAPI.Services
{
    public class MongoService
    {
        private readonly IMongoDatabase _database;

        public MongoService(IConfiguration configuration)
        {
            var connectionString = configuration["MongoDB:ConnectionString"];
            var databaseName = configuration["MongoDB:DatabaseName"];

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Order> Orders =>
            _database.GetCollection<Order>("orders");
    }
}
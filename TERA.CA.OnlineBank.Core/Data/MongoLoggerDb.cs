using MongoDB.Bson;
using MongoDB.Driver;

namespace TERA.CA.OnlineBank.Core.Data
{
    public class MongoLoggerDb//gamoviyeneb mongo db s logebs shesanaxad
    {
        private readonly MongoClient client;
        public virtual IMongoCollection<BsonDocument> Logs { get; set; }

        public MongoLoggerDb()
        {
            client = new MongoClient();
            var database = client.GetDatabase("LogTerasData");
            Logs = database.GetCollection<BsonDocument>("TerasLogs");
        }
    }
}

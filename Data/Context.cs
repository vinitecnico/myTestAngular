using Microsoft.Extensions.Options;
using MongoDB.Driver;
using myTestAngular.Models;

namespace myTestAngular.Data
{
    public class Context
    {
        private readonly IMongoDatabase _database = null;

        public Context (IOptions<Settings> settings) {
            var client = new MongoClient (settings.Value.ConnectionString);
            if (client != null) {
                _database = client.GetDatabase (settings.Value.Database);
            }
        }

        public IMongoCollection<PointSheet> PointSheets {
            get {
                return _database.GetCollection<PointSheet> ("pointSheet");
            }
        }
    }
}
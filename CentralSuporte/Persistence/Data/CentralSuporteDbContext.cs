using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralSuporte.Persistence.Data
{
    class CentralSuporteDbContext
    {
        private readonly IMongoDatabase _database;

        public CentralSuporteDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string nomeColecao)
        {
            return _database.GetCollection<T>(nomeColecao);
        }
    }
}

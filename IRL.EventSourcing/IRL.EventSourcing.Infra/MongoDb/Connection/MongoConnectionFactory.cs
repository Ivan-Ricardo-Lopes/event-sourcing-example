using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.EventSourcing.Infra.MongoDb.Connection
{
    public class MongoConnectionFactory : IMongoConnectionFactory
    {
        private readonly string connectionString;
        private readonly string databaseName;

        public MongoConnectionFactory(string connectionString, string databaseName)
        {
            this.connectionString = connectionString;
            this.databaseName = databaseName;
        }

        public IMongoDatabase MongoDatabase()
        {
            var client = new MongoClient(connectionString);
            return client.GetDatabase(databaseName);
        }
    }
}
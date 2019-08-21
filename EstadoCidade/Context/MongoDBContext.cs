using EstadoCidade.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstadoCidade.Context
{
    public class MongoDbContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
        private IMongoDatabase _database { get; }

        public MongoDbContext()
        {
            try
            {
                var mongoClient = new MongoClient(ConnectionString);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        public IMongoCollection<Cep> Ceps
        {
            get
            {
                return _database.GetCollection<Cep>("Cep");
            }
        }

    }
}


using EstadoCidade.Context;
using EstadoCidade.Interfaces;
using EstadoCidade.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstadoCidade.Services
{
    public class CepServices : ICepServices
    {
        public List<Cep> GetCepByNumber(string number)
        {
            MongoDbContext dbContext = new MongoDbContext();
            var collection = dbContext.Ceps;
            List<Cep> lstCep = collection.Find<Cep>(x => x.CEP.Equals(number)).ToList<Cep>();

            return lstCep;
        }

        public long GetQtdCeps()
        {
            MongoDbContext dbContext = new MongoDbContext();
            
            var collection = dbContext.Ceps;
            return collection.Count(new BsonDocument());

        }
    }
}

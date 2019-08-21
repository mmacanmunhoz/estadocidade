using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using EstadoCidade.Context;
using EstadoCidade.Interfaces;
using EstadoCidade.Model;
using EstadoCidade.Services;
using EstadoCidade.Util;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EstadoCidade.Controllers
{
    [Route("api/Importacao/")]

    public class ImportacaoController : Controller
    {
        private readonly ICepServices _cepServices;
        public ImportacaoController(ICepServices cepServices)
        {
            _cepServices = cepServices;
        }
        private static JArray LerArquivo()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Jsons\ceps.json";
            return ReadFile.ReadJson(path);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public bool ImportaCep()
        {
            try
            {
                if (_cepServices.GetQtdCeps().Equals(0))
                {
                    List<Cep> result = new List<Cep>();
                    using (WebClient client = new WebClient())
                    {
                        string path = AppDomain.CurrentDomain.BaseDirectory + @"Jsons\ceps.json";
                        using (StreamReader sr = new StreamReader(client.OpenRead(path)))
                        {
                            using (JsonReader reader = new JsonTextReader(sr))
                            {
                                JsonSerializer serializer = new JsonSerializer();
                                result = serializer.Deserialize<List<Cep>>(reader);
                            }
                        }
                    }
                    MongoDbContext db = new MongoDbContext();
                    db.Ceps.InsertMany(result);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }
    }
}
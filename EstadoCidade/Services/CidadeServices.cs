using EstadoCidade.Interfaces;
using EstadoCidade.Model;
using EstadoCidade.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadoCidade.Services
{
    public class CidadeServices : ICidadesService
    {
        public IEstadosServices _estadosServices;

        public CidadeServices(IEstadosServices estadosServices)
        {
            _estadosServices = estadosServices;
        }

        private static JArray LerArquivo()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Jsons\Cidades.json";
            return ReadFile.Read(path);
        }

        public List<CidadeModel> GetCidades()
        {
            JArray obj = LerArquivo();
            List<CidadeModel> lst = obj.ToObject<List<CidadeModel>>();

            return lst;
        }

        public List<CidadeModel> GetCidadesById(string id)
        {
            JArray obj = LerArquivo();
            List<CidadeModel> lst = obj.ToObject<List<CidadeModel>>();

            lst = lst.Where(x => x.ID == id).ToList<CidadeModel>();

            return lst;
        }

        public List<CidadeModel> GetCidadesByUf(string ID)
        {
            JArray obj = LerArquivo();
            List<CidadeModel> lst = obj.ToObject<List<CidadeModel>>();

            lst = lst.Where(x => x.Estado == ID).ToList<CidadeModel>();

            return lst;
        }

        public List<CidadeModel> GetCidadesByNome(string ID)
        {
            JArray obj = LerArquivo();
            List<CidadeModel> lst = obj.ToObject<List<CidadeModel>>();

            lst = lst.Where(x => x.Nome.ToLower().Contains(ID.ToLower())).ToList<CidadeModel>();

            return lst;
        }
    }
}

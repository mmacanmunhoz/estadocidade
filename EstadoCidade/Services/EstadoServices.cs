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
    public class EstadosServices : IEstadosServices
    {
        private static JArray LerArquivo()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Jsons\Estados.json";
            return ReadFile.ReadJson(path);
        }

        public List<EstadoModel> GetEstados()
        {
            JArray obj = LerArquivo();
            List<EstadoModel> lst = obj.ToObject<List<EstadoModel>>();

            return lst;
        }

        public List<EstadoModel> GetEstadosById(string id)
        {
            JArray obj = LerArquivo();
            List<EstadoModel> lst = obj.ToObject<List<EstadoModel>>();
            lst = lst.Where(x => x.ID == id).ToList<EstadoModel>();


            return lst;
        }
        public List<EstadoModel> GetEstadosByNome(string nome)
        {
            JArray obj = LerArquivo();
            List<EstadoModel> lst = obj.ToObject<List<EstadoModel>>();

            lst = lst.Where(x => x.Nome.ToLower().Contains(nome.ToLower())).ToList<EstadoModel>();


            return lst;
        }
    }
}

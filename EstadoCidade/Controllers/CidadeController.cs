using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstadoCidade.Interfaces;
using EstadoCidade.Model;
using Microsoft.AspNetCore.Mvc;

namespace EstadoCidade.Controllers
{
    [Route("api/Cidades/")]
    public class CidadeController : Controller
    {
        private readonly ICidadesService _cidadeServices;
        public CidadeController(ICidadesService cidadesService)
        {
            _cidadeServices = cidadesService;
        }

        [HttpGet]
        public List<CidadeModel> GetCidades()
        {
            return _cidadeServices.GetCidades();
        }

        [HttpGet]
        [Route("{id}")]
        public List<CidadeModel> GetCidadeByID(string id)
        {
            return _cidadeServices.GetCidadesById(id);
        }

        [HttpGet]
        [Route("UF/{id}")]
        public List<CidadeModel> GetCidadeByUF(string id)
        {
            return _cidadeServices.GetCidadesByUf(id);
        }

        [HttpGet]
        [Route("Nome/{nome}")]
        public List<CidadeModel> GetCidadeByNome(string nome)
        {
            return _cidadeServices.GetCidadesByNome(nome);
        }
    }
}

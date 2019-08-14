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
        /// <summary>
        /// Retorna todas as cidades do json de cidades
        /// </summary>
        /// <returns>List de CidadeModel</returns>
        [HttpGet]
        public List<CidadeModel> GetCidades()
        {
            return _cidadeServices.GetCidades();
        }
        /// <summary>
        /// Retorna lista de cidades do id solicitado
        /// </summary>
        /// <param name="id">String</param>
        /// <returns>Lista de CidadeModel</returns>
        [HttpGet]
        [Route("{id}")]
        public List<CidadeModel> GetCidadeByID(string id)
        {
            return _cidadeServices.GetCidadesById(id);
        }
        /// <summary>
        /// Retona a lista de cidades de acordo com o uf solicitado
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>Lista de CidadeModel</returns>
        [HttpGet]
        [Route("UF/{id}")]
        public List<CidadeModel> GetCidadeByUF(string id)
        {
            return _cidadeServices.GetCidadesByUf(id);
        }
        /// <summary>
        /// Retorna lista de cidades com nome que contenha o parametro solicitado
        /// </summary>
        /// <param name="nome">string</param>
        /// <returns>Lista de CidadeModel</returns>
        [HttpGet]
        [Route("Nome/{nome}")]
        public List<CidadeModel> GetCidadeByNome(string nome)
        {
            return _cidadeServices.GetCidadesByNome(nome);
        }
    }
}

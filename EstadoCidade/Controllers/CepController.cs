using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstadoCidade.Interfaces;
using EstadoCidade.Model;
using Microsoft.AspNetCore.Mvc;

namespace EstadoCidade.Controllers
{
    [Route("api/Cep/")]
    public class CepController : Controller
    {
        private readonly ICepServices _cepServices;
        public CepController(ICepServices cepService)
        {
            _cepServices = cepService;
        }
        /// <summary>
        /// Busca de Cep pelo numero
        /// </summary>
        /// <param name="numero">string</param>
        /// <returns>List de cep</returns>
        [HttpGet]
        public List<Cep> GetCep(string numero)
        {
            return _cepServices.GetCepByNumber(numero);
        }
    }
}
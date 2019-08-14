using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstadoCidade.Interfaces;
using EstadoCidade.Model;
using Microsoft.AspNetCore.Mvc;

namespace EstadoCidade.Controllers
{
    [Route("api/Estados/")]
    public class EstadosController : Controller
    {
        private readonly IEstadosServices _estadosServices;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="estadosServices"></param>
        public EstadosController(IEstadosServices estadosServices)
        {
            _estadosServices = estadosServices;
        }
        /// <summary>
        /// Retorna todos os estados brasileiros
        /// </summary>
        /// <returns>Lista EstadoModel</returns>
        [HttpGet]
        public List<EstadoModel> GetEstados()
        {
            return _estadosServices.GetEstados();
        }

        /// <summary>
        /// Retorna todos os estados de acordo com o id solicitado
        /// </summary>
        /// <param name="id">String</param>
        /// <returns>Lista EstadoModel</returns>
        [HttpGet]
        [Route("{id}")]
        public List<EstadoModel> GetEstadosByID(string id)
        {
            return _estadosServices.GetEstadosById(id);
        }
        /// <summary>
        /// Retorna todos os estados de acordo que contenha o nome solicitado
        /// </summary>
        /// <param name="nome">string</param>
        /// <returns>Lista EstadoModel</returns>
        [HttpGet]
        [Route("/Nome/{nome}")]
        public List<EstadoModel> GetEstadosByNome(string nome)
        {
            return _estadosServices.GetEstadosByNome(nome);
        }
    }
}
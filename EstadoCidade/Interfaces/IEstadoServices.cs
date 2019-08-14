using EstadoCidade.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstadoCidade.Interfaces
{
    public interface IEstadosServices
    {
        List<EstadoModel> GetEstados();
        List<EstadoModel> GetEstadosById(string id);
        List<EstadoModel> GetEstadosByNome(string nome);
    }
}

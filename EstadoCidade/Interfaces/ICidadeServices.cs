using EstadoCidade.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstadoCidade.Interfaces
{
    public interface ICidadesService
    {
        List<CidadeModel> GetCidades();
        List<CidadeModel> GetCidadesById(string ID);
        List<CidadeModel> GetCidadesByUf(string ID);
        List<CidadeModel> GetCidadesByNome(string ID);
    }
}

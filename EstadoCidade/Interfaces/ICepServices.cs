using EstadoCidade.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstadoCidade.Interfaces
{
    public interface ICepServices
    {
        List<Cep> GetCepByNumber(string number);
        long GetQtdCeps();
    }
}

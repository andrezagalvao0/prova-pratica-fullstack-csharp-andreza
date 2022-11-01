using IPC.Correios.Core.Models;
using IPC.Correios.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.Interfaces
{
    interface ICEPRepository
    {
        List<UF> BuscarEstados();
        List<Municipio> BuscarMunicipio(string sigla);

        List<Logradouro> BuscarLogradouro(int codigoMunicipio);

        ResultadoViewModel BuscarCEP(int codigoLogradouro);

    }
}

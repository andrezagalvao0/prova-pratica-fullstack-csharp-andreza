using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.ViewModels
{
    public class ResultadoViewModel
    {
        public int CEP { get; set; }
        public int CodigoLogradouro { get; set; }

        public string Logradouro { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
    }
}

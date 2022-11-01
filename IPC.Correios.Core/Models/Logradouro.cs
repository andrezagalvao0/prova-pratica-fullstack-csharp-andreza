using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.Models
{
    public class Logradouro
    {
        public string NomeLogradouro { get; set; } 
        public int CodigoLogradouro { get; set; }
        public int CodigoMunicipio { get; set; }
        public int CEP { get; set; }
    }
}

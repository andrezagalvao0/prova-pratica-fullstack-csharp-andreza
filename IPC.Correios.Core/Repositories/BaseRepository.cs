using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.Repositories
{
    public class BaseRepository
    {
        protected string[] ObterRegistros(string PATH)
        {
            return File.ReadAllLines(PATH);
        }

        public string[] ExtrairCampos(string valor)
        {
            string[] valores = valor.Split('@');

            return valores;
        }
    }
}

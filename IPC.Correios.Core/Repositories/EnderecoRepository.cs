using IPC.Correios.Core.Interfaces;
using IPC.Correios.Core.Models;
using IPC.Correios.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.Repositories
{
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        private string PATH_LOCALIDADE = @"C:\prova-pratica-fullstack-csharp\IPC.Correios.Core\App_Data\Correios\LOG_LOCALIDADE.txt";
        private string PATH_LOGRADOURO = @"C:\prova-pratica-fullstack-csharp\IPC.Correios.Core\App_Data\Correios\LOG_LOGRADOURO_SC.TXT";

        public ResultadoViewModel BuscarEndereco(int CEP)
        {
            string[] logradouros = ObterRegistros(PATH_LOGRADOURO);
            string[] localidades = ObterRegistros(PATH_LOCALIDADE);

            foreach(var logradouro in logradouros)
            {
                if(logradouro.Contains("@" + CEP.ToString() + "@"))
                {
                    string[] valoresLogradouro = ExtrairCampos(logradouro);

                    Logradouro objLogradouro = new Logradouro
                    {
                        CodigoLogradouro = int.Parse(valoresLogradouro[0]),
                        CodigoMunicipio = int.Parse(valoresLogradouro[2]),
                        CEP = int.Parse(valoresLogradouro[7]),
                        NomeLogradouro = valoresLogradouro[10]
                    };

                    foreach (var localidade in localidades)
                    {
                        if (localidade.StartsWith(objLogradouro.CodigoMunicipio.ToString()))
                        {
                            string[] valoresLocalidade = ExtrairCampos(localidade);

                            Localidade localidadeOBJ = new Localidade
                            {
                                CodigoMunicipio = int.Parse(valoresLocalidade[0]),
                                UF = valoresLocalidade[1],
                                NomeMunicipio = valoresLocalidade[2]
                            };

                            ResultadoViewModel resultadoViewModel = new ResultadoViewModel
                            {
                                CEP = objLogradouro.CEP,
                                CodigoLogradouro = objLogradouro.CodigoLogradouro,
                                Logradouro = objLogradouro.NomeLogradouro,
                                UF = localidadeOBJ.UF,
                                Municipio = localidadeOBJ.NomeMunicipio
                            };

                            return resultadoViewModel;
                        }
                    }
                }
            }
            return null;
        }
    }
}

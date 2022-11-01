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
    public class CEPRepository : BaseRepository, ICEPRepository
    {
        private string PATH_LOCALIDADE = @"C:\prova-pratica-fullstack-csharp\IPC.Correios.Core\App_Data\Correios\LOG_LOCALIDADE.txt";
        private string PATH_LOGRADOURO = @"C:\prova-pratica-fullstack-csharp\IPC.Correios.Core\App_Data\Correios\LOG_LOGRADOURO_SC.TXT";

        public List<UF> BuscarEstados()
        {
            string[] localidades = ObterRegistros(PATH_LOCALIDADE);  
            List<UF> estado = new List<UF>();

            foreach(var localidade in localidades)
            {
                string[] valoresLocalidade = ExtrairCampos(localidade);

                UF uf = new UF()
                {
                    Sigla = valoresLocalidade[1]
                };

                var siglaBuscada = estado.Where(item => item.Sigla == uf.Sigla);

                if (!siglaBuscada.Any())
                    estado.Add(uf);
                
            }

            return estado;
        }

        public List<Municipio> BuscarMunicipio(string sigla)
        {
            string[] localidades = ObterRegistros(PATH_LOCALIDADE);
            List<Municipio> municipios = new List<Municipio>(); 

            foreach(var localidade in localidades)
            {
                if (localidade.Contains("@"+sigla+"@"))
                {
                    string[] valoresLocalidade = ExtrairCampos(localidade);

                    Municipio municipio = new Municipio()
                    {
                        CodigoMunicipio = int.Parse(valoresLocalidade[0]),
                        UF = valoresLocalidade[1],
                        Nome = valoresLocalidade[2]
                    };

                    municipios.Add(municipio);
                }
            }

            return municipios;
        }

        public List<Logradouro> BuscarLogradouro(int codigoMunicipio)
        {
            string[] logradouros = ObterRegistros(PATH_LOGRADOURO);
            List<Logradouro> listaLogradouros = new List<Logradouro>();

            foreach(var logradouro in logradouros)
            {
                string[] valoresLogradouro = ExtrairCampos(logradouro);

                Logradouro objLogradouro = new Logradouro
                {
                    CodigoLogradouro = int.Parse(valoresLogradouro[0]),
                    CodigoMunicipio = int.Parse(valoresLogradouro[2]),
                    CEP = int.Parse(valoresLogradouro[7]),
                    NomeLogradouro = valoresLogradouro[10],
                };

                if(objLogradouro.CodigoMunicipio == codigoMunicipio)
                {
                    listaLogradouros.Add(objLogradouro);    
                }
            }

            return listaLogradouros;
        }

        public ResultadoViewModel BuscarCEP(int codigoLogradouro)
        {
            string[] logradouros = ObterRegistros(PATH_LOGRADOURO);
            string[] localidades = ObterRegistros(PATH_LOCALIDADE);

            foreach(var logradouro in logradouros)
            {
                if (logradouro.StartsWith(codigoLogradouro.ToString()))
                {
                    string[] valoresLogradouro = ExtrairCampos(logradouro);

                    Logradouro objLogradouro = new Logradouro
                    {
                        CodigoLogradouro = int.Parse(valoresLogradouro[0]),
                        CodigoMunicipio = int.Parse(valoresLogradouro[2]),
                        CEP = int.Parse(valoresLogradouro[7]),
                        NomeLogradouro = valoresLogradouro[10]
                    };

                    foreach(var localidade in localidades)
                    {
                        if (localidade.StartsWith(objLogradouro.CodigoMunicipio.ToString()))
                        {
                            string[] valoresLocaridade = ExtrairCampos(localidade);

                            Localidade objLocalidade = new Localidade
                            {
                                CodigoMunicipio = int.Parse(valoresLocaridade[0]),
                                UF = valoresLocaridade[1],
                                NomeMunicipio = valoresLocaridade[2]
                            };

                            ResultadoViewModel resultadoViewModel = new ResultadoViewModel
                            {
                                CEP = objLogradouro.CEP,
                                CodigoLogradouro = objLogradouro.CodigoLogradouro,
                                Logradouro = objLogradouro.NomeLogradouro,
                                UF = objLocalidade.UF,
                                Municipio = objLocalidade.NomeMunicipio
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

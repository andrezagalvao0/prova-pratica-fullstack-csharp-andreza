using IPC.Correios.Core.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.Tests
{
    [TestFixture]
    public class CEPRepositoryTest
    {
        private CEPRepository CEPRepository;

        [SetUp]
        public void Setup()
        {
            CEPRepository = new CEPRepository();
        }

        [Test]
        public void BuscarEstados()
        {
            Assert.IsNotEmpty(CEPRepository.BuscarEstados());
        }

        [Test]
        public void BuscarMunicipios()
        {
            string sigla = "SC";

            Assert.IsNotEmpty(CEPRepository.BuscarMunicipio(sigla));
        }

        [Test]
        public void BuscarLogradouros()
        {
            int codigoMunicipio = 8377;

            Assert.IsNotEmpty(CEPRepository.BuscarLogradouro(codigoMunicipio));
        }

        [Test]
        public void BuscarCEP()
        {
            int codigoLogradouro = 1000034;

            Assert.IsNotNull(CEPRepository.BuscarCEP(codigoLogradouro));
        }

        [Test]
        public void BuscarCEPNãoEncontrado()
        {
            int codigoLogradouro = 89095812;

            Assert.IsNull(CEPRepository.BuscarCEP(codigoLogradouro));
        }
    }
}

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
    public class EnderecoRepositoryTest
    {
        private EnderecoRepository EnderecoRepository;

        [SetUp]
        public void Setup()
        {
            EnderecoRepository = new EnderecoRepository();
        }

        [Test]
        public void BuscarEndereco()
        {
            int CEP = 88356105;

            Assert.IsNotNull(EnderecoRepository.BuscarEndereco(CEP));
        }
    }
}

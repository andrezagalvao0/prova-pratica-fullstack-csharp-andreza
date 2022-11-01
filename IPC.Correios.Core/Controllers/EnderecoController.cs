using IPC.Correios.Core.Interfaces;
using IPC.Correios.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IPC.Correios.Core.Controllers
{
    public class EnderecoController : Controller
    {
        private IEnderecoRepository EnderecoRepository { get; set; }

        public EnderecoController()
        {
            EnderecoRepository = new EnderecoRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BuscarEndereco(int cep)
        {
            return View(EnderecoRepository.BuscarEndereco(cep));
        }
    }
}

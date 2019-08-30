using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretariaDoMeioAmbiente.Models;
using SecretariaDoMeioAmbiente.Services;

namespace SecretariaDoMeioAmbiente.Controllers
{
    public class CadastroController : Controller
    {
        private CadastroService _cadastroContext;

        public CadastroController(CadastroService context)
        {
            _cadastroContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Cadastro cadastro)
        {
            if(ModelState.IsValid)
            {
                _cadastroContext.Cadastrar(cadastro);

                TempData["MSG_S"] = "Cadastro realizado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View();
            
        }

        [HttpGet]
        public IActionResult Atualizar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm]Cadastro cadastro)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Excluir()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
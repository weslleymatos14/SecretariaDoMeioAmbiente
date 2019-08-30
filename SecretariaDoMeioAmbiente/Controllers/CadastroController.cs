using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretariaDoMeioAmbiente.Libraries.Login;
using SecretariaDoMeioAmbiente.Models;
using SecretariaDoMeioAmbiente.Services;

namespace SecretariaDoMeioAmbiente.Controllers
{
    public class CadastroController : Controller
    {
        private CadastroService _cadastroContext;
        private LoginCadastro _loginCadastro;

        public CadastroController(CadastroService context, LoginCadastro loginCadastro)
        {
            _cadastroContext = context;
            _loginCadastro = loginCadastro;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm]Cadastro cadastro)
        {
            Cadastro cadastroDB = _cadastroContext.Login(cadastro.Email, cadastro.Senha);
            if (cadastroDB != null)
            {
                _loginCadastro.Login(cadastroDB);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["MSG_E"] = "Usuário e/ou senha inválido!";
                return View();
            }
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
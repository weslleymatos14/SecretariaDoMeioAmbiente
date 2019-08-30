using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretariaDoMeioAmbiente.Libraries.Filters;
using SecretariaDoMeioAmbiente.Libraries.Login;
using SecretariaDoMeioAmbiente.Models;
using SecretariaDoMeioAmbiente.Services;

namespace SecretariaDoMeioAmbiente.Controllers
{
    [CadastroAutorizacao]
    public class HomeController : Controller
    {
        private LoginCadastro _loginCadastro;

        public HomeController(LoginCadastro loginCadastro)
        {
            _loginCadastro = loginCadastro;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Logout()
        {
            _loginCadastro.Logout();
            return RedirectToAction("Index", "Cadastro");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SecretariaDoMeioAmbiente.Libraries.Login;
using SecretariaDoMeioAmbiente.Models;
using System;

namespace SecretariaDoMeioAmbiente.Libraries.Filters
{
    public class CadastroAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        private LoginCadastro _loginCadastro;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginCadastro = (LoginCadastro)context.HttpContext.RequestServices.GetService(typeof(LoginCadastro));

            Cadastro cadastro = _loginCadastro.GetLogin();
           
            if (cadastro == null)
            {
                context.Result = new RedirectToActionResult("Index", "Cadastro", null);
            }
        }
    }
}

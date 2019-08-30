using Newtonsoft.Json;
using SecretariaDoMeioAmbiente.Models;


namespace SecretariaDoMeioAmbiente.Libraries.Login
{
    public class LoginCadastro
    {
        private readonly string Key = "Login.Cadastro";
        private readonly Session.Session _session;

        public LoginCadastro(Session.Session session)
        {
            _session = session;
        }

        public void Login(Cadastro Cadastro)
        {
            string clienteJson = JsonConvert.SerializeObject(Cadastro);
            _session.Cadastrar(Key, clienteJson);
        }

        public Cadastro GetLogin()
        {
            if (_session.Existe(Key))
            {
                string cadastroJson = _session.Consultar(Key);
                return JsonConvert.DeserializeObject<Cadastro>(cadastroJson);
            }
            else
            {
                return null;
            }
        }

        public void Logout()
        {
            _session.RemoverTodos();
        }

    }
}

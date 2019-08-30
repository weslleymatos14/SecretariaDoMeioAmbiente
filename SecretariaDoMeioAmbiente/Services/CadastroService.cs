using SecretariaDoMeioAmbiente.Data;
using SecretariaDoMeioAmbiente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretariaDoMeioAmbiente.Services
{
    public class CadastroService
    {
        private SecretariaDoMeioAmbienteContext _context;

        public CadastroService(SecretariaDoMeioAmbienteContext context)
        {
            _context = context;
        }

        public void Cadastrar(Cadastro cadastro)
        {
            _context.Cadastros.Add(cadastro);
            _context.SaveChanges();
        }

        public void Atualizar(Cadastro cadastro)
        {
            if (Existe(cadastro.Id) != false)
                _context.Cadastros.Remove(cadastro);

            _context.Cadastros.Add(cadastro);
            _context.SaveChanges();

        }

        public void Excluir(Cadastro cadastro)
        {
            if (Existe(cadastro.Id) != false)
                _context.Cadastros.Remove(cadastro);

            _context.SaveChanges();
        }

        public bool Existe(int id)
        {
            var existe = _context.Cadastros.Find(id);
            if (existe != null)
                return true;

            return false;
        }

        public Cadastro Login(string email, string senha)
        {
            var cadastro = _context.Cadastros.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
            return cadastro;

        }
    }
}

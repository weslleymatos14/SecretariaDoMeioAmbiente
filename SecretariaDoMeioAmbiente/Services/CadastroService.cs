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
        }

        public void Atualizar(Cadastro cadastro)
        {
            if (Existe(cadastro.Id) != false)
                _context.Cadastros.Remove(cadastro);

            _context.Cadastros.Add(cadastro);

        }

        public void Excluir(Cadastro cadastro)
        {
            if (Existe(cadastro.Id) != false)
                _context.Cadastros.Remove(cadastro);
        }

        public bool Existe(int id)
        {
            var existe = _context.Cadastros.Find(id);
            if (existe != null)
                return true;

            return false;
        }
    }
}

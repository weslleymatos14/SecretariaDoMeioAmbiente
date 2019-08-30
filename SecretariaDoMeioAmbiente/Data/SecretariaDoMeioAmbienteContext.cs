using Microsoft.EntityFrameworkCore;
using SecretariaDoMeioAmbiente.Models;

namespace SecretariaDoMeioAmbiente.Data
{
    public class SecretariaDoMeioAmbienteContext : DbContext
    {
        public SecretariaDoMeioAmbienteContext(DbContextOptions<SecretariaDoMeioAmbienteContext> options) : base(options)
        {          
        }

        public DbSet<Cadastro> Cadastros { get; set; }
    }
}

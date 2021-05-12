using System.Data.Entity;

namespace Cadastro_Sistema.Data
{
    public class Context : DbContext
    {
        public Context() : base("name=Context")
        {
        }

        public DbSet<Models.Funcionario> Funcionarios { get; set; }
    }
}

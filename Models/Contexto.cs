using Microsoft.EntityFrameworkCore;

namespace ProjetoFuncionarios.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Funcionario>? Funcionário { get; set; }
        public DbSet<Escala>? Escala { get; set; }
        public DbSet<Cargo>? Cargo { get; set; }
        public DbSet<Ponto> Ponto { get; set; }
    }
}

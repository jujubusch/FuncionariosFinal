using Microsoft.EntityFrameworkCore;

namespace FuncionariosFinal.Models
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
        public DbSet<Funcionario> Funcionario { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace ProjetoOrla.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }

        public DbSet<Inicio> Inicio { get; set; }
    }
}

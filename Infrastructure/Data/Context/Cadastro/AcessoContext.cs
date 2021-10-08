using Domain.Acesso.UsuarioAgreggate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context.Cadastro
{
    public class AcessoContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=dbSystem;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcessoContext).Assembly);
        }
    }
}
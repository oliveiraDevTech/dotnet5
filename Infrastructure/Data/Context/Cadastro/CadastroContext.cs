using Domain.Cadastro.EmpresaAgreggate;
using Domain.Cadastro.EnderecoAggregate;
using Domain.Cadastro.EstoqueAgreggate;
using Domain.Cadastro.FornecedorAgreggate;
using Domain.Cadastro.ProdutoAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context.Cadastro
{
    public class CadastroContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<MovimentoEstoque> MovimentoEstoque { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=dbSystem;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastroContext).Assembly);
        }
    }
}
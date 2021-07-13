using Domain.Cadastro.FornecedorAgreggate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Cadastro.Configuration
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedores");

            builder.HasOne(c => c.Empresa);

            builder.HasMany(c => c.Produtos);

            builder.Ignore(c => c.Notifications);
        }
    }
}
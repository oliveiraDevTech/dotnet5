using Domain.Cadastro.EstoqueAgreggate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Cadastro.Configuration
{
    public class EstoqueConfigure : IEntityTypeConfiguration<Estoque>

    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("Estoques");

            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Quantidade, cnpj =>
            {
                cnpj.Property(c => c.Valor).HasColumnName("Quantidade")
                                            .IsRequired();

                cnpj.Property(c => c.Unidade).IsRequired();
            });

            builder.HasOne(c => c.Produto);

            builder.HasMany(c => c.Movimentos);

            builder.HasOne(c => c.Fornecedor);

            builder.Property(x => x.Fabricacao)
                   .IsRequired();

            builder.Property(x => x.Vencimento);

            builder.Ignore(c => c.Notifications);
        }
    }
}
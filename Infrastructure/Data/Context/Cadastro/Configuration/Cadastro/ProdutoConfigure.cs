using Domain.Cadastro.ProdutoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Cadastro.Configuration
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(c => c.Id);

            builder.Property(x => x.Codigo)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.Descricao)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.Tipo)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.OwnsOne(x => x.Medida, medida =>
            {
                medida.Property(c => c.Altura);

                medida.Property(c => c.Comprimento);

                medida.Property(c => c.Largura);
            });

            builder.OwnsOne(x => x.Peso, peso =>
            {
                peso.Property(c => c.Valor)
                    .HasColumnName("Peso");
            });

            builder.OwnsOne(x => x.Preco, preco =>
            {
                preco.Property(c => c.Valor).HasColumnName("Preco");

                preco.OwnsOne(c => c.Imposto, imposto =>
                {
                    imposto.Property(c => c.Cofins);
                    imposto.Property(c => c.Pis);
                    imposto.Property(c => c.Ipi);
                    imposto.Property(c => c.Icms);
                });
            });

            builder.Ignore(c => c.Notifications);
        }
    }
}
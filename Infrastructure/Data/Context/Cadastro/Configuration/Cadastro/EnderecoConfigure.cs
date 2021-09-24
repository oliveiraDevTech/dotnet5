using Domain.Cadastro.EnderecoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Cadastro.Configuration
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Pais)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Estado)
                   .IsRequired()
                   .HasMaxLength(2);

            builder.Property(x => x.Cidade)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Bairro)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.Rua)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.Numero)
                   .IsRequired();

            builder.Property(x => x.Complemento)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Referencia)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Ignore(c => c.Notifications);
        }
    }
}
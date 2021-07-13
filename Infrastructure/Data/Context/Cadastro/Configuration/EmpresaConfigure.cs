using Domain.Cadastro.EmpresaAgreggate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Cadastro.Configuration
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas");

            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Cnpj, cnpj =>
            {
                cnpj.Property(c => c.Codigo).HasColumnName("Cnpj")
                                            .HasMaxLength(14)
                                            .IsRequired();

                cnpj.Ignore(c => c.CodigoFormatado);
            });

            builder.Property(x => x.RazaoSocial)
                   .HasColumnName("RazaoSocial")
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.Nome)
                   .HasColumnName("Nome")
                   .HasMaxLength(150);

            builder.HasOne(x => x.Endereco);

            builder.Property(x => x.Tipo)
                   .HasColumnName("Tipo")
                   .IsRequired()
                   .HasMaxLength(14);

            builder.Ignore(c => c.Notifications);
        }
    }
}
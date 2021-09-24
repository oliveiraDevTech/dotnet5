using Domain.Cadastro.EstoqueAgreggate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Cadastro.Configuration
{
    public class MovimentoEstoqueConfigure : IEntityTypeConfiguration<MovimentoEstoque>

    {
        public void Configure(EntityTypeBuilder<MovimentoEstoque> builder)
        {
            builder.ToTable("Estoques_Movimentos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Lancamento)
                   .IsRequired();

            builder.Property(x => x.Tipo)
                   .HasColumnName("Tipo")
                   .IsRequired()
                   .HasMaxLength(14);

            builder.Ignore(c => c.Notifications);
        }
    }
}
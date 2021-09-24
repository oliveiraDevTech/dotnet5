using Domain.Acesso.UsuarioAgreggate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Cadastro.Configuration.Acesso
{
    public class UsuarioConfigure : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Login)
               .HasColumnName("Nome")
               .IsRequired()
               .HasMaxLength(250);

            builder.Property(x => x.Senha)
                   .HasColumnName("Senha")
                   .HasMaxLength(50);
        }
    }
}
using Domain.Cadastro.EmpresaAgreggate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Cadastro.Configuration
{
    public class FilialMap : IEntityTypeConfiguration<Filial>
    {
        public void Configure(EntityTypeBuilder<Filial> builder)
        {
            builder.HasOne(x => x.Matriz);
        }
    }
}
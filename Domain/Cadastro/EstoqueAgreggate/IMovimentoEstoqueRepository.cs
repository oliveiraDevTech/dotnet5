using Core.Infrastructure.Data;
using System.Threading.Tasks;

namespace Domain.Cadastro.EstoqueAgreggate
{
    public interface IMovimentoEstoqueRepository<TDbContext> : IRepository<MovimentoEstoque, long>
    {
        TDbContext DbContext { get; }

        Task<int> Insert(MovimentoEstoque estoque);
    }
}
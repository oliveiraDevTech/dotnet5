using Core.Infrastructure.Data;
using System.Threading.Tasks;

namespace Domain.Cadastro.EstoqueAgreggate
{
    public interface IEstoqueRepository<TDbcontext> : IRepository<Estoque, long>
    {
        TDbcontext DbContext { get; }

        Task<int> Insert(Estoque estoque);

        Task<int> Update(Estoque estoque);
    }
}
using Domain.Cadastro.EstoqueAgreggate;
using System.Threading.Tasks;

namespace Infrastructure.Data.Context.Cadastro.Repository
{
    public class MovimentoEstoqueRepository : IMovimentoEstoqueRepository<CadastroContext>
    {
        public CadastroContext DbContext => _cadastroContext;

        private readonly CadastroContext _cadastroContext;

        public MovimentoEstoqueRepository(CadastroContext cadastroContext)
        {
            _cadastroContext = cadastroContext;
        }

        public Task<int> Insert(MovimentoEstoque movimentoEstoque)
        {
            DbContext.MovimentoEstoque.Add(movimentoEstoque);
            return Commit();
        }

        private Task<int> Commit() => DbContext.SaveChangesAsync();
    }
}
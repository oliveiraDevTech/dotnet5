using Domain.Cadastro.EstoqueAgreggate;
using System.Threading.Tasks;

namespace Infrastructure.Data.Context.Cadastro.Repository
{
    public class EstoqueRepository : IEstoqueRepository<CadastroContext>
    {
        public CadastroContext DbContext => _cadastroContext;

        private readonly CadastroContext _cadastroContext;

        public EstoqueRepository(CadastroContext cadastroContext)
        {
            _cadastroContext = cadastroContext;
        }

        public async Task<int> Insert(Estoque estoque)
        {
            DbContext.Estoque.Add(estoque);
            return await Commit();
        }

        public async Task<int> Update(Estoque estoque)
        {
            DbContext.Estoque.Update(estoque);
            return await Commit();
        }

        private Task<int> Commit() => DbContext.SaveChangesAsync();
    }
}
using Domain.Cadastro.EmpresaAgreggate;
using Domain.Cadastro.EnderecoAggregate;
using Domain.Cadastro.EstoqueAgreggate;
using Domain.Cadastro.FornecedorAgreggate;
using Domain.Cadastro.ProdutoAggregate;
using Infrastructure.Data.Context.Cadastro.Repository;

namespace Infrastructure.Data.Context.Cadastro.UnitOfWork
{
    public class CadastroUnitOfWork : ICadastroUnitOfWork<CadastroContext>
    {
        public CadastroContext DbContext => _cadastroContext;

        public IEmpresaRepository EmpresaRepository => EmpresaRepository != null ? EmpresaRepository : new EmpresaRepository();
        public IProdutoRepository ProdutoRepository => ProdutoRepository != null ? ProdutoRepository : new ProdutoRepository();
        public IFornecedorRepository FornecedorRepository => FornecedorRepository != null ? FornecedorRepository : new FornecedorRepository();
        public IEnderecoRepository EnderecoRepository => EnderecoRepository != null ? EnderecoRepository : new EnderecoRepository();
        public IEstoqueRepository<CadastroContext> EstoqueRepository => EstoqueRepository != null ? EstoqueRepository : new EstoqueRepository(DbContext);
        public IMovimentoEstoqueRepository<CadastroContext> MovimentoEstoqueRepository => MovimentoEstoqueRepository != null ? MovimentoEstoqueRepository : new MovimentoEstoqueRepository(DbContext);

        private readonly CadastroContext _cadastroContext;

        public CadastroUnitOfWork(CadastroContext cadastroContext)
        {
            _cadastroContext = cadastroContext;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public void RollbackBack()
        {
            DbContext.Dispose();
        }
    }
}
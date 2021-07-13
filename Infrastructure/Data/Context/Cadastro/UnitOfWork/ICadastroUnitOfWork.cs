using Core.UnitOfWork;
using Domain.Cadastro.EmpresaAgreggate;
using Domain.Cadastro.EnderecoAggregate;
using Domain.Cadastro.EstoqueAgreggate;
using Domain.Cadastro.FornecedorAgreggate;
using Domain.Cadastro.ProdutoAggregate;

namespace Infrastructure.Data.Context.Cadastro.UnitOfWork
{
    public interface ICadastroUnitOfWork<TDbContext> : IUnitOfWork
    {
        TDbContext DbContext { get; }
        IEmpresaRepository EmpresaRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        IFornecedorRepository FornecedorRepository { get; }
        IEnderecoRepository EnderecoRepository { get; }
        IEstoqueRepository<TDbContext> EstoqueRepository { get; }
        IMovimentoEstoqueRepository<TDbContext> MovimentoEstoqueRepository { get; }
    }
}
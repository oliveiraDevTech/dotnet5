using Core.Domain.Enumerator;
using Domain.Cadastro.ProdutoAggregate.ValueObject;

namespace Domain.Cadastro.ProdutoAggregate.Factory
{
    public interface IImpostoFactory
    {
        public Imposto Criar(Estado estado);
    }
}
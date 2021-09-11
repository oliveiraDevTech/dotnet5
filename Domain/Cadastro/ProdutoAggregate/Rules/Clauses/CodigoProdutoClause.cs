using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.ProdutoAggregate.Rules.Clauses
{
    internal class CodigoProdutoClause : Rule<Produto>
    {
        public override void Validar(Produto produto)
        {
            AddNotifications(new Contract<Notification>().IsGreaterThan(produto.Codigo, 25, nameof(produto.Codigo), "Codigo do produto não pode ser maior que 25 caracteres")
                                                         .IsNotNull(produto.Codigo, nameof(produto.Codigo), "Código do produto é uma informação inválida"));
        }
    }
}
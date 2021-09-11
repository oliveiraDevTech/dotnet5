using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.ProdutoAggregate.Rules.Clauses
{
    internal class DescricaoProdutoClause : Rule<Produto>
    {
        public override void Validar(Produto produto)
        {
            AddNotifications(new Contract<Notification>().IsGreaterThan(produto.Descricao, 250, nameof(produto.Descricao), "Descrição do produto não pode ser maior que 250 caracteres")
                                           .IsNotNull(produto.Descricao, nameof(produto.Descricao), "Descrição do produto é uma informação inválida"));
        }
    }
}
using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.ProdutoAggregate.Rules.Clauses
{
    internal class ValorClause : Rule<Produto>
    {
        private const string Mensagem = "Valor do Peso é inválido";

        public override void Validar(Produto produto)
        {
            AddNotifications(new Contract<Notification>().IsNotNull(produto.Preco.Valor, nameof(produto.Preco.Valor), Mensagem));
        }
    }
}
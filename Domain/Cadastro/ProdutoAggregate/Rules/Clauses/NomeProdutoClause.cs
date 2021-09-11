using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.ProdutoAggregate.Rules.Clauses
{
    public class NomeProdutoClause : Rule<Produto>
    {
        public override void Validar(Produto produto)
        {
            AddNotifications(new Contract<Notification>().IsNotNullOrEmpty(produto.Nome, nameof(produto.Nome), "Nome do produto não pode ser vazio ou nulo")
                                           .IsLowerThan(produto.Nome, 2, nameof(produto.Nome), "Nome do produto não pode ser menor que 2 caracteres")
                                           .IsGreaterThan(produto.Nome, 150, nameof(produto.Nome), "Nome do produto não pode ser maior que 150 caracteres"));
        }
    }
}
using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EnderecoAggregate.Rules.Clauses
{
    public class CidadeClause : Rule<Endereco>
    {
        private const string Mensagem = "Cidade não pode ser nulo";
        private const string Mensagem2 = "Cidade menor que 5";
        private const string Mensagem3 = "Cidade maior que 150";

        public override void Validar(Endereco endereco)
        {
            AddNotifications(new Contract<Notification>().IsNotNullOrEmpty(endereco.Cidade, nameof(endereco.Cidade), Mensagem)
                                 .IsGreaterOrEqualsThan(endereco.Cidade, 2, nameof(endereco.Cidade), Mensagem2)
                                 .IsLowerOrEqualsThan(endereco.Cidade, 100, nameof(endereco.Cidade), Mensagem3));
        }
    }
}
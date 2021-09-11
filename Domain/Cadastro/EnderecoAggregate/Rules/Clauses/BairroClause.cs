using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EnderecoAggregate.Rules.Clauses
{
    public class BairroClause : Rule<Endereco>
    {
        private const string Mensagem = "Bairro não pode ser nulo";
        private const string Mensagem2 = "Bairro menor que 2";
        private const string Mensagem3 = "Bairro maior que 100";

        public override void Validar(Endereco endereco)
        {
            AddNotifications(new Contract<Notification>().IsNotNullOrEmpty(endereco.Bairro, nameof(endereco.Bairro), Mensagem)
                                 .IsGreaterOrEqualsThan(endereco.Bairro, 2, nameof(endereco.Bairro), Mensagem2)
                                 .IsLowerOrEqualsThan(endereco.Bairro, 100, nameof(endereco.Bairro), Mensagem3));
        }
    }
}
using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EnderecoAggregate.Rules.Clauses
{
    public class ComplementoClause : Rule<Endereco>
    {
        private const string Mensagem = "Bairro não pode ser nulo";
        private const string Mensagem2 = "Bairro menor que 2";
        private const string Mensagem3 = "Bairro maior que 100";

        public override void Validar(Endereco endereco)
        {
            AddNotifications(new Contract<Notification>().IsNotNullOrEmpty(endereco.Complemento, nameof(endereco.Complemento), "Complemento não pode ser nulo")
                                 .IsGreaterOrEqualsThan(endereco.Complemento, 2, nameof(endereco.Complemento), "Complemento menor que 2")
                                 .IsLowerOrEqualsThan(endereco.Complemento, 150, nameof(endereco.Complemento), "Complemento maior que 150"));
        }
    }
}
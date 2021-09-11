using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EnderecoAggregate.Rules.Clauses
{
    public class ReferenciaClause : Rule<Endereco>
    {
        private const string Mensagem = "Bairro não pode ser nulo";
        private const string Mensagem2 = "Bairro menor que 2";
        private const string Mensagem3 = "Bairro maior que 250";

        public override void Validar(Endereco endereco)
        {
            AddNotifications(new Contract<Notification>().IsNotNullOrEmpty(endereco.Referencia, nameof(endereco.Referencia), Mensagem)
                                                         .IsGreaterOrEqualsThan(endereco.Referencia, 2, nameof(endereco.Referencia), Mensagem2)
                                                         .IsLowerOrEqualsThan(endereco.Referencia, 250, nameof(endereco.Referencia), Mensagem3));
        }
    }
}
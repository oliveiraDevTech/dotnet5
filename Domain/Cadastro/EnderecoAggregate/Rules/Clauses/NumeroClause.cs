using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EnderecoAggregate.Rules.Clauses
{
    public class NumeroClause : Rule<Endereco>
    {
        private const string Mensagem = "Numero não pode ser 0";

        public override void Validar(Endereco endereco)
        {
            AddNotifications(new Contract<Notification>().AreNotEquals(0, endereco.Numero, nameof(endereco.Numero), Mensagem));
        }
    }
}
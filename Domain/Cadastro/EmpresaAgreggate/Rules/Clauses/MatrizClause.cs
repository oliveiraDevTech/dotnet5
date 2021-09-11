using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EmpresaAgreggate.Rules.Clauses
{
    public class MatrizClause : Rule<Filial>
    {
        private const string _mensagem = "Matriz da Filial não pode ser nulo";

        public override void Validar(Filial filial)
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNull(filial.Matriz, nameof(filial.Matriz), _mensagem));
        }
    }
}
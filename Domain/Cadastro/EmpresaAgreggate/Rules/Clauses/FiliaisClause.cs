using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EmpresaAgreggate.Rules.Clauses
{
    public class FiliaisClause : Rule<Matriz>
    {
        public override void Validar(Matriz matriz)
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNull(matriz.Filiais, nameof(matriz.Filiais), "Matriz da Filial não pode ser nulo"));
        }
    }
}
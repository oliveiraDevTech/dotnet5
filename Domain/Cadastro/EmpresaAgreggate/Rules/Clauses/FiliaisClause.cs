using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EmpresaAgreggate.Rules.Clauses
{
    public class FiliaisClause : MatrizRule
    {
        private const string Mensagem = "Matriz da Filial não pode ser nulo";

        public override void Validar(Matriz matriz)
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNull(matriz.Filiais, nameof(matriz.Filiais), Mensagem));
        }
    }
}
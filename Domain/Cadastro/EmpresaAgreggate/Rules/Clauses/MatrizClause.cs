using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EmpresaAgreggate.Rules.Clauses
{
    public class MatrizClause : FilialRule
    {
        private const string Mensagem = "Matriz da Filial não pode ser nulo";

        public override void Validar(Filial filial)
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNull(filial.Matriz, nameof(filial.Matriz), Mensagem));
        }
    }
}
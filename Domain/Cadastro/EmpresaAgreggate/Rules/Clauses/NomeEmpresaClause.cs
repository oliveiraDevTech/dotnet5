using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EmpresaAgreggate.Rules.Clauses
{
    public class NomeEmpresaClause : Rule<Empresa>
    {
        private const string _mensagem = "Nome da Empresa não pode ser nulo";
        private const string _mensagem2 = "Nome da Empresa menor que 5";
        private const string _mensagem3 = "Nome da Empresa maior que 150";

        public override void Validar(Empresa empresa)
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(empresa.Nome, nameof(empresa.Nome), _mensagem)
                .IsGreaterOrEqualsThan(empresa.Nome, 5, nameof(empresa.Nome), _mensagem2)
                .IsLowerOrEqualsThan(empresa.Nome, 150, nameof(empresa.Nome), _mensagem3));
        }
    }
}
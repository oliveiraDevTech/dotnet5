using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EmpresaAgreggate.Rules
{
    public class NomeEmpresaClause : EmpresaRule
    {
        private const string Mensagem = "Nome da Empresa não pode ser nulo";
        private const string Mensagem2 = "Nome da Empresa menor que 5";
        private const string Mensagem3 = "Nome da Empresa maior que 150";
        public override void Validar(Empresa empresa)
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(empresa.Nome, nameof(empresa.Nome), Mensagem)
                .IsGreaterOrEqualsThan(empresa.Nome, 5, nameof(empresa.Nome), Mensagem2)
                .IsLowerOrEqualsThan(empresa.Nome, 150, nameof(empresa.Nome), Mensagem3));
        }
    }
}
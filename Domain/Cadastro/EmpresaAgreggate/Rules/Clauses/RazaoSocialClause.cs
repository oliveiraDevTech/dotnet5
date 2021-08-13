using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EmpresaAgreggate.Rules
{
    public class RazaoSocialClause : EmpresaRule
    {
        private const string Mensagem = "Razao Social da Empresa não pode ser nulo";
        private const string Mensagem2 = "Razao Social da Empresa menor que 5";
        private const string Mensagem3 = "Razao Social da Empresa maior que 150";
        public override void Validar(Empresa empresa)
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(empresa.RazaoSocial, nameof(empresa.RazaoSocial), Mensagem)
                .IsGreaterOrEqualsThan(empresa.RazaoSocial, 5, nameof(empresa.RazaoSocial), Mensagem2)
                .IsLowerOrEqualsThan(empresa.RazaoSocial, 150, nameof(empresa.RazaoSocial), Mensagem3));
        }
    }
}
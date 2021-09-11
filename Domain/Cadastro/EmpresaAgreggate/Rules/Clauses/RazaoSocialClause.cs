using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EmpresaAgreggate.Rules.Clauses
{
    public class RazaoSocialClause : Rule<Empresa>
    {
        private const string _mensagem = "Razao Social da Empresa não pode ser nulo";
        private const string _mensagem2 = "Razao Social da Empresa menor que 5";
        private const string _mensagem3 = "Razao Social da Empresa maior que 150";

        public override void Validar(Empresa empresa)
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(empresa.RazaoSocial, nameof(empresa.RazaoSocial), _mensagem)
                .IsGreaterOrEqualsThan(empresa.RazaoSocial, 5, nameof(empresa.RazaoSocial), _mensagem2)
                .IsLowerOrEqualsThan(empresa.RazaoSocial, 150, nameof(empresa.RazaoSocial), _mensagem3));
        }
    }
}
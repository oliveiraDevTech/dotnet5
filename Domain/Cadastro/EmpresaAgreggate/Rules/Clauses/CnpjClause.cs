using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EmpresaAgreggate.Rules.Clauses
{
    internal class CnpjClause : EmpresaRule
    {
        private const string Mensagem3 = "Razao Social da Empresa maior que 150";

        public override void Validar(Empresa empresa)
        {
            AddNotifications(new Contract<Notification>().IsNotNull(empresa.Cnpj.Codigo, nameof(empresa.Cnpj.Codigo), "Codigo do CNPJ é inválido"));
        }
    }
}
using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EmpresaAgreggate.Rules.Clauses
{
    internal class CnpjClause : Rule<Empresa>
    {
        private const string _mensagem = "Codigo do CNPJ é inválido";

        public override void Validar(Empresa empresa)
        {
            AddNotifications(new Contract<Notification>().IsNotNull(empresa.Cnpj.Codigo, nameof(empresa.Cnpj.Codigo), _mensagem));
        }
    }
}
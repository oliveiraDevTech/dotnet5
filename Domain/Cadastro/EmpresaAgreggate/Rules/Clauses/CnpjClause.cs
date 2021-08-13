using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cadastro.EmpresaAgreggate.Rules.Clauses
{
    class CnpjClause : EmpresaRule
    {
        private const string Mensagem3 = "Razao Social da Empresa maior que 150";
        public override void Validar(Empresa empresa)
        {
            AddNotifications(new Contract<Notification>().IsNotNull(empresa.Cnpj.Codigo, nameof(empresa.Cnpj.Codigo), "Codigo do CNPJ é inválido"));
        }
    }
}
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet5.Domain.Aggregate.EmpresaAggregate.Rule.Regras
{
    public class CnpjRule : EmpresaRule, IEmpresaRule
    {
        public override void AddNotifications(IEnumerable<Notification> notifications)
        {
            throw new NotImplementedException();
        }

        public override void Validar(Empresa empresa)
        {
            AddNotifications(new Contract<Empresa>().Requires().IsNull(empresa.CNPJ, "Erro no CNPJ"));
        }
    }
}

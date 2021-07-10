using Dotnet5.Domain.Aggregate.EmpresaAggregate.Rule.Regras;
using Flunt.Notifications;
using System.Collections.Generic;

namespace Dotnet5.Domain.Aggregate.EmpresaAggregate.Rule
{
    public static class ListaRegrasEmpresa
    {
        public static List<IEmpresaRule> ObterRegras()
        {
            return new List<IEmpresaRule>
            {
                new CnpjRule()
            };
        }
    }
}

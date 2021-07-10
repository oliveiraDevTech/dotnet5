using Dotnet5.Core.Domain;
using Dotnet5.Domain.Aggregate.EmpresaAggregate.Rule;
using System;

namespace Dotnet5.Domain.Aggregate.EmpresaAggregate
{
    public class Empresa : Entity<Int64>
    {
        public virtual string RazaoSocial { get; private set; }
        public virtual string CNPJ { get; private set; }

        protected override void Validar()
        {
            foreach (var regra in ListaRegrasEmpresa.ObterRegras())
            {
                regra.Validar(this);
                AddNotifications(regra.Notifications);
            };
        }
    }
}

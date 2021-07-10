using Flunt.Notifications;
using System.Collections.Generic;

namespace Dotnet5.Domain.Aggregate.EmpresaAggregate.Rule
{
    public interface IEmpresaRule : INotifiable
    {
        public IReadOnlyCollection<Notification> Notifications { get; }
        void Validar(Empresa empresa);
        bool DeveExecutar(Empresa empresa);
    }
}

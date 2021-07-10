
using Flunt.Notifications;
using System;
using System.Collections.Generic;

namespace Dotnet5.Domain.Aggregate.EmpresaAggregate.Rule
{
    public abstract class EmpresaRule : Notifiable<Notification>, IEmpresaRule
    {
        public abstract void AddNotifications(IEnumerable<Notification> notifications);

        public virtual bool DeveExecutar(Empresa empresa)
        {
            return true;
        }

        public virtual void Validar(Empresa empresa)
        {
            throw new NotImplementedException();
        }
    }
}

using Flunt.Notifications;
using System.Collections.Generic;

namespace Domain.Cadastro.EmpresaAgreggate
{
    public abstract class EmpresaRule : Notifiable<Notification>, IEmpresaRule
    {
        public void AddNotifications(IEnumerable<Notification> notifications) => base.AddNotifications((IReadOnlyCollection<Notification>)notifications);

        public virtual bool DeveExecutar(Empresa empresa) => true;

        public abstract void Validar(Empresa empresa);
    }
}

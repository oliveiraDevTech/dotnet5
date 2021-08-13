using Core.Domain;
using Flunt.Notifications;
using System.Collections.Generic;

namespace Domain.Cadastro.EmpresaAgreggate
{
    public abstract class FilialRule : Notifiable<Notification>, IRule<Filial>
    {

        public void AddNotifications(IEnumerable<Notification> notifications) => base.AddNotifications((IReadOnlyCollection<Notification>)notifications);

        public virtual bool DeveExecutar(Filial filial) => false;

        public abstract void Validar(Filial filial);

    }
}

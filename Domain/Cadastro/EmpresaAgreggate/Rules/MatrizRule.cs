using Core.Domain;
using Flunt.Notifications;
using System.Collections.Generic;

namespace Domain.Cadastro.EmpresaAgreggate.Rules
{
    public abstract class MatrizRule : Notifiable<Notification>, IRule<Matriz>
    {
        public void AddNotifications(IEnumerable<Notification> notifications) => base.AddNotifications((IReadOnlyCollection<Notification>)notifications);

        public virtual bool DeveExecutar(Matriz matriz) => false;

        public abstract void Validar(Matriz matriz);
    }
}
using Flunt.Notifications;
using System.Collections.Generic;

namespace Core.Domain
{
    public abstract class Rule<Entity> : Notifiable<Notification>, IRule<Entity>
    {
        public void AddNotifications(IEnumerable<Notification> notifications) => base.AddNotifications((IReadOnlyCollection<Notification>)notifications);

        public virtual bool DeveExecutar(Entity entidade) => true;

        public abstract void Validar(Entity entidade);
    }
}
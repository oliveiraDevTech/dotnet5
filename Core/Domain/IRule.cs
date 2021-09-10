using Flunt.Notifications;
using System.Collections.Generic;

namespace Core.Domain
{
    public interface IRule<T> : INotifiable
    {
        public IReadOnlyCollection<Notification> Notifications { get; }

        void Validar(T entity);

        bool DeveExecutar(T entity);
    }
}
using Flunt.Notifications;

namespace Dotnet5.Core.Domain
{
    public abstract class Entity<IdType> : Notifiable<Notification>
    {
        public virtual IdType Id { get; protected set; }

        protected abstract void Validar();
    }
}

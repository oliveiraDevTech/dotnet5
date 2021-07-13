using Flunt.Notifications;
using Flunt.Validations;

namespace Core.Domain.Entity
{
    public interface IEntity
    {
        public void Validate();
        public Contract<Notification> Contract();
    }
}
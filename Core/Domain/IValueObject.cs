using Flunt.Notifications;
using Flunt.Validations;

namespace Core.Domain
{
    public interface IValueObject
    {
        public Contract<Notification> Contract();
    }
}
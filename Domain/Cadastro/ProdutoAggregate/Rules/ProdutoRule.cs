using Core.Domain;
using Flunt.Notifications;
using System.Collections.Generic;

namespace Domain.Cadastro.ProdutoAggregate.Rules
{
    public abstract class ProdutoRule : Notifiable<Notification>, IRule<Produto>
    {
        public void AddNotifications(IEnumerable<Notification> notifications) => base.AddNotifications((IReadOnlyCollection<Notification>)notifications);

        public virtual bool DeveExecutar(Produto produto) => false;

        public abstract void Validar(Produto produto);
    }
}
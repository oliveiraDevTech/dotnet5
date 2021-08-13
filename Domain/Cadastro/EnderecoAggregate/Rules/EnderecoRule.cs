﻿using Core.Domain;
using Domain.Cadastro.EnderecoAggregate;
using Flunt.Notifications;
using System.Collections.Generic;

namespace Domain.Cadastro.EmpresaAgreggate
{
    public abstract class EnderecoRule : Notifiable<Notification>, IRule<Endereco>
    {
        public void AddNotifications(IEnumerable<Notification> notifications) => base.AddNotifications((IReadOnlyCollection<Notification>)notifications);

        public virtual bool DeveExecutar(Endereco endereco) => false;

        public abstract void Validar(Endereco endereco);
    }
}
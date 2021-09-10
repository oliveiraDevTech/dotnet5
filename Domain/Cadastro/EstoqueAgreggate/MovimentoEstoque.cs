using Core.Domain.Entity;
using Domain.Cadastro.EstoqueAgreggate.Enumerators;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Domain.Cadastro.EstoqueAgreggate
{
    public class MovimentoEstoque : Entity<long>, IEntity
    {
        public MovimentoEstoque(TipoMovimento tipo, DateTime lancamento)
        {
            Tipo = tipo;
            Lancamento = lancamento;

            Validate();
        }

        public TipoMovimento Tipo { get; private set; }
        public DateTime Lancamento { get; private set; }

        public static Contract<Notification> Contract()
        {
            return new Contract<Notification>();
        }

        public virtual void Validate()
        {
            AddNotifications(Contract());
        }
    }
}
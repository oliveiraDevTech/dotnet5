using Core.Domain;
using DomainDrivenDesign.Core.Models;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace Domain.Cadastro.ProdutoAggregate.ValueObject
{
    public class Peso : ValueObject<Peso>, IValueObject
    {
        public decimal Valor { get; internal set; }

        public Peso(decimal valor = 0M)
        {
            Valor = ArredondarDuasCasas(valor);
        }

        public Contract<Notification> Contract()
        {
            return new Contract<Notification>().IsNotNull(Valor, nameof(Valor), "Valor do Peso é inválido");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }

        private static decimal ArredondarDuasCasas(decimal valor) => Math.Round(valor, 2, MidpointRounding.AwayFromZero);
    }
}
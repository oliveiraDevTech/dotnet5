using Core.Domain;
using DomainDrivenDesign.Core.Models;
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

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }

        private static decimal ArredondarDuasCasas(decimal valor) => Math.Round(valor, 2, MidpointRounding.AwayFromZero);
    }
}
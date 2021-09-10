using Core.Domain;
using DomainDrivenDesign.Core.Models;
using System;
using System.Collections.Generic;

namespace Domain.Cadastro.ProdutoAggregate.ValueObject
{
    public class Imposto : ValueObject<Imposto>, IValueObject
    {
        public Imposto(decimal pis = 0M, decimal cofins = 0M, decimal icms = 0M, decimal ipi = 0M)
        {
            Pis = ArredondarDuasCasas(pis);
            Cofins = ArredondarDuasCasas(cofins);
            Icms = ArredondarDuasCasas(icms);
            Ipi = ArredondarDuasCasas(ipi);
        }

        protected Imposto()
        {
        }

        public decimal Pis { get; private set; }
        public decimal Cofins { get; private set; }
        public decimal Icms { get; private set; }
        public decimal Ipi { get; private set; }

        public decimal SomarImpostos() => Pis + Cofins + Icms + Ipi;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }

        private static decimal ArredondarDuasCasas(decimal valor) => Math.Round(valor, 2, MidpointRounding.AwayFromZero);
    }
}
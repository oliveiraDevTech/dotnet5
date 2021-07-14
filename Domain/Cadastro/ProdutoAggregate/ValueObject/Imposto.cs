using Core.Domain;
using DomainDrivenDesign.Core.Models;
using Flunt.Notifications;
using Flunt.Validations;
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

        public decimal Pis { get; private set; }
        public decimal Cofins { get; private set; }
        public decimal Icms { get; private set; }
        public decimal Ipi { get; private set; }

        public decimal SomarImpostos() => Pis + Cofins + Icms + Ipi;

        public Contract<Notification> Contract()
        {
            return new Contract<Notification>().IsNotNull(Pis, nameof(Pis), "O Imposto de Pis é inválido")
                                 .IsNotNull(Cofins, nameof(Cofins), "O Imposto de Cofins é inválido")
                                 .IsNotNull(Icms, nameof(Icms), "O Imposto de Icms é inválido")
                                 .IsNotNull(Ipi, nameof(Ipi), "O Imposto de Ipi é inválido");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }

        private static decimal ArredondarDuasCasas(decimal valor) => Math.Round(valor, 2, MidpointRounding.AwayFromZero);
    }
}
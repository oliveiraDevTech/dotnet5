using Core.Domain;
using DomainDrivenDesign.Core.Models;
using System;
using System.Collections.Generic;

namespace Domain.Cadastro.ProdutoAggregate.ValueObject
{
    public class Medida : ValueObject<Medida>, IValueObject
    {
        public Medida(decimal altura = 0M, decimal largura = 0M, decimal comprimento = 0M)
        {
            Altura = ArredondarDuasCasas(altura);
            Largura = ArredondarDuasCasas(largura);
            Comprimento = ArredondarDuasCasas(comprimento);
        }

        public decimal Altura { get; internal set; }
        public decimal Largura { get; internal set; }
        public decimal Comprimento { get; internal set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }

        private static decimal ArredondarDuasCasas(decimal valor) => Math.Round(valor, 2, MidpointRounding.AwayFromZero);
    }
}
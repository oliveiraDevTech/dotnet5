using Core.Domain;
using Domain.Cadastro.ProdutoAggregate.Enumerators;
using DomainDrivenDesign.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Domain.Cadastro.ProdutoAggregate.ValueObject
{
    public class Preco : ValueObject<Preco>, IValueObject
    {
        public Preco(decimal valor, Imposto imposto)
        {
            Valor = valor;
            Imposto = imposto;
        }

        protected Preco()
        {
        }

        public decimal Valor { get; private set; }
        public Imposto Imposto { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }

        public decimal CalularValorComImposto() => Valor * Imposto.SomarImpostos();

        public string ConverterEmMoeda(Moeda moeda)
        {
            switch (moeda)
            {
                case Moeda.Real:
                    return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "R$ {0:#,###.##}", Valor);

                case Moeda.Dolar:
                    return string.Format(CultureInfo.GetCultureInfo("en-US"), "US$ {0:#.###,##}", Valor);

                default:
                    break;
            }

            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "R$ {0:#,###.##}", Valor);
        }
    }
}
using Core.Domain;
using Domain.Cadastro.ProdutoAggregate.Enumerators;
using DomainDrivenDesign.Core.Models;
using Flunt.Notifications;
using Flunt.Validations;
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

        public Preco()
        {
        }

        public decimal Valor { get; private set; }
        public Imposto Imposto { get; private set; }

        public Contract<Notification> Contract()
        {
            return new Contract<Notification>().IsNotNull(Valor, nameof(Valor), "Valor do Peso é inválido");
        }

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
using Core.Domain;
using Domain.Cadastro.EstoqueAgreggate.Enumerators;
using DomainDrivenDesign.Core.Models;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace Domain.Cadastro.EstoqueAgreggate.ValueObjects
{
    public class Quantidade : ValueObject<Quantidade>, IValueObject
    {
        public Quantidade(double valor, UnidadeMedida unidade = UnidadeMedida.Unidade)
        {
            Valor = valor;
            Unidade = unidade;
        }

        public double Valor { get; internal set; }
        public UnidadeMedida Unidade { get; internal set; }

        public Contract<Notification> Contract()
        {
            return new Contract<Notification>().IsNotNull(Valor, nameof(Valor), "Valor da Quantidade é inválido")
                                 .IsNotNull(Unidade, nameof(Unidade), "Unidade de Medida da Quantidade é inválido");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
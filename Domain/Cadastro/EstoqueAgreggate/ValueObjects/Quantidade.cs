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

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
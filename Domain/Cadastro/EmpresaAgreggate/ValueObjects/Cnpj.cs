using Core.Domain;
using DomainDrivenDesign.Core.Models;
using System.Collections.Generic;

namespace Domain.Cadastro.EmpresaAgreggate.ValueObjects
{
    public class Cnpj : ValueObject<Cnpj>, IValueObject
    {
        public Cnpj(string codigo) => Codigo = codigo;

        public string Codigo { get; }
        public string CodigoFormatado { get => CodigoFormatado; private set => CodigoFormatado = Codigo; }

        //public Contract<Notification> Contract()
        //{
        //    return new Contract<Notification>();
        //}

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }
    }
}
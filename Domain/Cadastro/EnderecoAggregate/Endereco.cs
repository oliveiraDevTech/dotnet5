using Core.Domain.Entity;
using Core.Domain.Enumerator;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Domain.Cadastro.EnderecoAggregate
{
    public class Endereco : Entity<Int64>, IEntity
    {
        public Endereco(string pais, Estado estado, string cidade, string bairro, string rua, int numero, string complemento, string referencia)
        {
            Pais = pais;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Referencia = referencia;

            Validate();
        }

        public string Pais { get; private set; }
        public Estado Estado { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Referencia { get; private set; }

        public Contract<Notification> Contract()
        {
            return new Contract<Notification>().IsNotNullOrEmpty(Pais, nameof(Pais), "Pais inválido")
                                 //.HasMinLen(Pais, 2, nameof(Pais), "Pais precisa ter no mínimo 2 caracteres")
                                 //.HasMaxLen(Pais, 50, nameof(Pais), "Pais precisa ter no máximo 50 caracteres")
                                 .IsNotNullOrEmpty(Cidade, nameof(Cidade), "Cidade não pode ser nulo")
                                 //.HasMinLen(Cidade, 2, nameof(Cidade), "Cidade menor que 5")
                                 //.HasMaxLen(Cidade, 100, nameof(Cidade), "Cidade maior que 150")
                                 .IsNotNullOrEmpty(Bairro, nameof(Bairro), "Bairro não pode ser nulo")
                                 //.HasMinLen(Bairro, 2, nameof(Bairro), "Bairro menor que 2")
                                 //.HasMaxLen(Bairro, 100, nameof(Bairro), "Bairro maior que 100")
                                 .IsNotNullOrEmpty(Rua, nameof(Rua), "Rua não pode ser nulo")
                                 //.HasMinLen(Rua, 2, nameof(Rua), "Rua menor que 2")
                                 //.HasMaxLen(Rua, 150, nameof(Rua), "Rua maior que 150")
                                 .AreNotEquals(0, Numero, nameof(Numero), "Numero não pode ser 0")
                                 .IsNotNullOrEmpty(Complemento, nameof(Complemento), "Complemento não pode ser nulo")
                                 //.HasMinLen(Complemento, 2, nameof(Complemento), "Complemento menor que 2")
                                 //.HasMaxLen(Complemento, 150, nameof(Complemento), "Complemento maior que 150")
                                 .IsNotNullOrEmpty(Referencia, nameof(Referencia), "Bairro não pode ser nulo");
                                 //.HasMinLen(Referencia, 2, nameof(Referencia), "Bairro menor que 2")
                                 //.HasMaxLen(Referencia, 250, nameof(Referencia), "Bairro maior que 250");
        }

        public virtual void Validate()
        {
            AddNotifications(Contract());
        }
    }
}
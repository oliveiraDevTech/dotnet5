using Core.Domain.Entity;
using Core.Domain.Enumerator;
using Domain.Cadastro.EnderecoAggregate.Rules.RulesList;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Linq;

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
            return new Contract<Notification>()
                                 .AreNotEquals(0, Numero, nameof(Numero), "Numero não pode ser 0")
                                 .IsNotNullOrEmpty(Complemento, nameof(Complemento), "Complemento não pode ser nulo")
                                 //.HasMinLen(Complemento, 2, nameof(Complemento), "Complemento menor que 2")
                                 //.HasMaxLen(Complemento, 150, nameof(Complemento), "Complemento maior que 150")
                                 .IsNotNullOrEmpty(Referencia, nameof(Referencia), "Bairro não pode ser nulo");
                                 //.HasMinLen(Referencia, 2, nameof(Referencia), "Bairro menor que 2")
                                 //.HasMaxLen(Referencia, 250, nameof(Referencia), "Bairro maior que 250");
        }

        protected override void RuleValidate()
        {
            foreach (var regra in EnderecoRulesList.ObterRegras().Where(x => x.DeveExecutar(this)))
            {
                regra.Validar(this);
                AddNotifications(regra.Notifications);
            }
        }

        public virtual void Validate()
        {
            AddNotifications(Contract());
        }
    }
}
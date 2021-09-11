using Core.Domain.Entity;
using Core.Domain.Enumerator;
using Domain.Cadastro.EnderecoAggregate.Rules.RulesList;
using System;
using System.Linq;

namespace Domain.Cadastro.EnderecoAggregate
{
    public class Endereco : Entity<Int64>, IEntity
    {
        protected Endereco()
        {
        }

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

        public virtual void Validate()
        {
            foreach (var regra in EnderecoRule.ObterRegras().Where(x => x.DeveExecutar(this)))
            {
                regra.Validar(this);
                AddNotifications(regra.Notifications);
            }
        }
    }
}
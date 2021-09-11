using Core.Domain.Entity;
using Domain.Cadastro.EmpresaAgreggate.Enumerators;
using Domain.Cadastro.EmpresaAgreggate.Rules;
using Domain.Cadastro.EmpresaAgreggate.ValueObjects;
using Domain.Cadastro.EnderecoAggregate;
using System.Linq;

namespace Domain.Cadastro.EmpresaAgreggate
{
    public abstract class Empresa : Entity<long>, IEntity
    {
        protected Empresa()
        {
        }

        public Empresa(Cnpj cnpj, string razaoSocial, string nome, Endereco endereco, TipoEmpresa tipo)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            Nome = nome;
            Endereco = endereco;
            Tipo = tipo;

            Validate();
        }

        public Cnpj Cnpj { get; protected set; }
        public string RazaoSocial { get; protected set; }
        public string Nome { get; protected set; }
        public Endereco Endereco { get; protected set; }
        public TipoEmpresa Tipo { get; protected set; }

        public virtual void Validate()
        {
            foreach (var regra in EmpresaRule.ObterRegras().Where(x => x.DeveExecutar(this)))
            {
                regra.Validar(this);
                AddNotifications(regra.Notifications);
            }
        }
    }
}
using Domain.Cadastro.EmpresaAgreggate.Enumerators;
using Domain.Cadastro.EmpresaAgreggate.ValueObjects;
using Domain.Cadastro.EnderecoAggregate;
using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;

namespace Domain.Cadastro.EmpresaAgreggate
{
    public class Matriz : Empresa
    {
        protected Matriz()
        {

        }

        public IEnumerable<Filial> Filiais { get; protected set; }

        public Matriz(IEnumerable<Filial> filiais, Cnpj cnpj, string razaoSocial, string nome, Endereco endereco, TipoEmpresa tipo) : base(cnpj, razaoSocial, nome, endereco, tipo)
        {
            Filiais = filiais;
        }
        public override void Validate()
        {
            RuleValidate();

            AddNotifications(Endereco.Notifications);
            AddNotifications(Cnpj.Contract());
            AddNotifications(new Contract<Notification>());
        }

        protected override void RuleValidate()
        {
            base.RuleValidate();
        }
    }
}

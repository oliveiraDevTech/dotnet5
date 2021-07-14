using Domain.Cadastro.EmpresaAgreggate.Enumerators;
using Domain.Cadastro.EmpresaAgreggate.ValueObjects;
using Domain.Cadastro.EnderecoAggregate;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EmpresaAgreggate
{
    public class Filial : Empresa
    {
        public Filial()
        {

        }
        public Empresa Matriz { get; protected set; }

        public Filial(Empresa matriz, Cnpj cnpj, string razaoSocial, string nomeEmpresa, Endereco endereco) : base(cnpj, razaoSocial, nomeEmpresa, endereco, TipoEmpresa.Filial)
        {
            Matriz = matriz;
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

        //public new Contract<Notification> Contract()
        //{
        //    return new Contract<Notification>().IsNotNull(Matriz, nameof(Matriz), "Matriz da Filial não pode ser nulo");
        //}
    }
}
using Core.Domain.Entity;
using Domain.Cadastro.EmpresaAgreggate.Enumerators;
using Domain.Cadastro.EmpresaAgreggate.ValueObjects;
using Domain.Cadastro.EnderecoAggregate;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EmpresaAgreggate
{
    public class Empresa : Entity<long>, IEntity
    {
        public Empresa()
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
            AddNotifications(Contract());
            AddNotifications(Endereco.Notifications);
            AddNotifications(Cnpj.Contract());

            if (Tipo.Equals(TipoEmpresa.Filial))
                AddNotification(nameof(Tipo), "Tipo da empresa não pode ser filial");
        }

        public Contract<Notification> Contract()
        {
            return new Contract<Notification>().IsNotNullOrEmpty(Nome, nameof(Nome), "Nome da Empresa não pode ser nulo")
                                           //.HasMinLen(Nome, 5, nameof(Nome), "Nome da Empresa menor que 5")
                                           //.HasMaxLen(Nome, 150, nameof(Nome), "Nome da Empresa maior que 150")
                                           .IsNotNullOrEmpty(RazaoSocial, nameof(RazaoSocial), "Razao Social da Empresa não pode ser nulo");
                                           //.HasMinLen(RazaoSocial, 5, nameof(RazaoSocial), "Razao Social da Empresa menor que 5")
                                           //.HasMaxLen(RazaoSocial, 150, nameof(RazaoSocial), "Razao Social da Empresa maior que 150");
        }
    }
}
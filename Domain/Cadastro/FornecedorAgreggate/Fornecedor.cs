using Core.Domain.Entity;
using Domain.Cadastro.EmpresaAgreggate;
using Domain.Cadastro.ProdutoAggregate;
using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Cadastro.FornecedorAgreggate
{
    public class Fornecedor : Entity<long>, IEntity
    {
        public Fornecedor(Empresa empresa, IEnumerable<Produto> produtos)
        {
            Empresa = empresa;
            Produtos = produtos;

            Validate();
        }

        protected Fornecedor()
        {
        }

        public Empresa Empresa { get; private set; }
        public IEnumerable<Produto> Produtos { get; private set; }

        public Contract<Notification> Contract()
        {
            return new Contract<Notification>().IsTrue(Empresa.IsValid, "Empresa", "Empresa vinculada ao Fornecedor apresenta problemas")
                                 .IsTrue(Produtos.Any(x => x.IsValid), "Produtos", "Produtos Vinculados ao fornecedor apresentam problemas");
        }

        public virtual void Validate()
        {
            AddNotifications(Contract());
            AddNotifications(Empresa.Notifications);
            //TODO: ADICIONAR AS NOTIFICATIONS DE PRODUTOS
            //AddNotifications(Produtos.FirstOrDefault().Select(x => x.Notifications));
        }
    }
}
using Core.Domain.Entity;
using Domain.Cadastro.EmpresaAgreggate;
using Domain.Cadastro.ProdutoAggregate;
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

        public virtual void Validate()
        {
            AddNotifications(Empresa.Notifications);

            foreach (var notification in Produtos.Select(x => x.Notifications).Where(x => x.Any()))
                AddNotifications(notification);
        }
    }
}
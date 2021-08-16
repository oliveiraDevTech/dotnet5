using Core.Domain.Entity;
using Domain.Cadastro.EstoqueAgreggate.ValueObjects;
using Domain.Cadastro.FornecedorAgreggate;
using Domain.Cadastro.ProdutoAggregate;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace Domain.Cadastro.EstoqueAgreggate
{
    public class Estoque : Entity<long>, IEntity
    {
        protected Estoque() { }

        public Estoque(Quantidade quantidade, Produto produto, Fornecedor fornecedor, IEnumerable<MovimentoEstoque> movimentos, DateTime fabricacao, DateTime? vencimento)
        {
            Quantidade = quantidade;
            Produto = produto;
            Fornecedor = fornecedor;
            Movimentos = movimentos;
            Fabricacao = fabricacao;
            Vencimento = vencimento;
        }

        public Quantidade Quantidade { get; private set; }
        public Produto Produto { get; private set; }
        public Fornecedor Fornecedor { get; private set; }
        public IEnumerable<MovimentoEstoque> Movimentos { get; private set; }
        public DateTime Fabricacao { get; private set; }
        public DateTime? Vencimento { get; private set; }

        public static Contract<Notification> Contract()
        {
            return new Contract<Notification>();
        }

        public virtual void Validate()
        {
            AddNotifications(Contract());
            AddNotifications(Quantidade.Contract());
            AddNotifications(Produto.Notifications);
            AddNotifications(Fornecedor.Notifications);
        }
    }
}
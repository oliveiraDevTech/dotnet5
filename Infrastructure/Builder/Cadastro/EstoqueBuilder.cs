using Domain.Cadastro.EstoqueAgreggate;
using Domain.Cadastro.EstoqueAgreggate.ValueObjects;
using Domain.Cadastro.FornecedorAgreggate;
using Domain.Cadastro.ProdutoAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Builder.Cadastro
{
    public class EstoqueBuilder
    {
        private Quantidade _quantidade;
        private Produto _produto;
        private Fornecedor _fornecedor;
        private IEnumerable<MovimentoEstoque> _movimentos;
        private DateTime _fabricacao;
        private DateTime? _vencimento;

        public EstoqueBuilder()
        {
            _quantidade = new Quantidade(1);
            _produto = new ProdutoBuilder().Build();
            _fornecedor = new FornecedorBuilder().Build();
            _movimentos = new List<MovimentoEstoque>() { new MovimentoEstoqueBuilder().Build() };
            _fabricacao = DateTime.UtcNow.AddHours(-3);
            _vencimento = null;
        }

        public EstoqueBuilder(Quantidade quantidade, Produto produto, Fornecedor fornecedor, IEnumerable<MovimentoEstoque> movimentos, DateTime fabricacao, DateTime? vencimento)
        {
            _quantidade = quantidade;
            _produto = produto;
            _fornecedor = fornecedor;
            _movimentos = movimentos;
            _fabricacao = fabricacao;
            _vencimento = vencimento;
        }

        public EstoqueBuilder ComQuantidade(Quantidade quantidade)
        {
            _quantidade = quantidade;
            return this;
        }

        public EstoqueBuilder ComProduto(Produto produto)
        {
            _produto = produto;
            return this;
        }

        public EstoqueBuilder Comfornecedor(Fornecedor fornecedor)
        {
            _fornecedor = fornecedor;
            return this;
        }

        public EstoqueBuilder ComMovimentos(IEnumerable<MovimentoEstoque> movimentoEstoques)
        {
            _movimentos = movimentoEstoques;
            return this;
        }

        public EstoqueBuilder ComFabricacao(DateTime fabricacao)
        {
            _fabricacao = fabricacao;
            return this;
        }

        public EstoqueBuilder ComVencimento(DateTime? vencimento)
        {
            _vencimento = vencimento;
            return this;
        }

        public Estoque Build() => new Estoque(_quantidade, _produto, _fornecedor, _movimentos, _fabricacao, _vencimento);
    }
}
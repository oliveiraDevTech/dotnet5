using Domain.Cadastro.EmpresaAgreggate;
using Domain.Cadastro.FornecedorAgreggate;
using Domain.Cadastro.ProdutoAggregate;
using System.Collections.Generic;

namespace Infrastructure.Builder.Cadastro
{
    public class FornecedorBuilder
    {
        private Empresa _empresa;
        private IEnumerable<Produto> _produtos;

        public FornecedorBuilder(Empresa empresa, IEnumerable<Produto> produtos)
        {
            _empresa = empresa;
            _produtos = produtos;
        }

        public FornecedorBuilder()
        {
            _empresa = new MatrizBuilder().Build();
            _produtos = new List<Produto>() { new ProdutoBuilder().Build() };
        }

        public FornecedorBuilder ComEmpresa(Empresa empresa)
        {
            _empresa = empresa;
            return this;
        }

        public FornecedorBuilder ComProdutos(IEnumerable<Produto> produtos)
        {
            _produtos = produtos;
            return this;
        }

        public Fornecedor Build() => new(_empresa, _produtos);
    }
}
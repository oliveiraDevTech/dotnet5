using Domain.Cadastro.ProdutoAggregate;
using Domain.Cadastro.ProdutoAggregate.Enumerators;
using Domain.Cadastro.ProdutoAggregate.ValueObject;

namespace Infrastructure.Builder.Cadastro
{
    public class ProdutoBuilder
    {
        private string _nome;
        private string _codigo;
        private TipoProduto _tipo;
        private string _descricao;
        private Peso _peso;
        private Medida _medida;
        private Preco _preco;

        public ProdutoBuilder()
        {
            _nome = "Nome Padrão";
            _codigo = "CPD0000";
            _tipo = TipoProduto.Acabado;
            _descricao = "Descrição Padrão";
            _peso = new Peso();
            _medida = new Medida();
            _preco = new Preco(0, new Imposto());
        }

        public ProdutoBuilder(string nome, string codigo, TipoProduto tipo, string descricao, Peso peso, Medida medida, Preco preco)
        {
            _nome = nome;
            _codigo = codigo;
            _tipo = tipo;
            _descricao = descricao;
            _peso = peso;
            _medida = medida;
            _preco = preco;
        }

        public ProdutoBuilder ComCodigo(string codigo)
        {
            _codigo = codigo;
            return this;
        }

        public ProdutoBuilder ComMedida(Medida medida)
        {
            _medida = medida;
            return this;
        }

        public ProdutoBuilder ComPeso(Peso peso)
        {
            _peso = peso;
            return this;
        }

        public ProdutoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public ProdutoBuilder ComTipo(TipoProduto tipo)
        {
            _tipo = tipo;
            return this;
        }

        public ProdutoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public ProdutoBuilder ComPreco(Preco preco)
        {
            _preco = preco;
            return this;
        }

        public Produto Build() => new(_nome, _codigo, _tipo, _descricao, _peso, _medida, _preco);
    }
}
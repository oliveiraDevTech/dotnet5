using Domain.Cadastro.EstoqueAgreggate;
using Domain.Cadastro.EstoqueAgreggate.Enumerators;
using System;

namespace Infrastructure.Builder.Cadastro
{
    public class MovimentoEstoqueBuilder
    {
        private TipoMovimento _tipo;
        private DateTime _lancamento;

        public MovimentoEstoqueBuilder(TipoMovimento tipo, DateTime lancamento)
        {
            _tipo = tipo;
            _lancamento = lancamento;
        }

        public MovimentoEstoqueBuilder()
        {
            _tipo = TipoMovimento.Entrada;
            _lancamento = DateTime.UtcNow.AddHours(-3);
        }

        public MovimentoEstoqueBuilder ComTipo(TipoMovimento tipoMovimento)
        {
            _tipo = tipoMovimento;
            return this;
        }

        public MovimentoEstoqueBuilder ComLancamento(DateTime lancamento)
        {
            _lancamento = lancamento;
            return this;
        }

        public MovimentoEstoque Build() => new(_tipo, _lancamento);
    }
}
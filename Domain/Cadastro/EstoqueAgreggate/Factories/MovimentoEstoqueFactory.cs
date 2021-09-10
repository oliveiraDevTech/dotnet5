using Domain.Cadastro.EstoqueAgreggate.Enumerators;
using System;

namespace Domain.Cadastro.EstoqueAgreggate.Factories
{
    public class MovimentoEstoqueFactory : IMovimentoEstoqueFactory
    {
        public MovimentoEstoque Criar(double quantidadeAntiga, double quantidadeNova, bool perda = false)
        {
            if (quantidadeAntiga > quantidadeNova && !perda)
            {
                return new MovimentoEstoque(TipoMovimento.Saida, DateTime.Now);
            }
            else if (quantidadeAntiga > quantidadeNova && perda)
            {
                return new MovimentoEstoque(TipoMovimento.Perda, DateTime.Now);
            }
            else if (quantidadeAntiga == quantidadeNova)
            {
                return new MovimentoEstoque(TipoMovimento.Ajuste, DateTime.Now);
            }

            return new MovimentoEstoque(TipoMovimento.Entrada, DateTime.Now);
        }
    }
}
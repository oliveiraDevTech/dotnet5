using Domain.Cadastro.EstoqueAgreggate.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Cadastro.EstoqueAgreggate.Factories
{
    public interface IMovimentoEstoqueFactory
    {
        MovimentoEstoque Criar(double quantidadeAntiga, double quantidadeNova, bool perda = false);
    }
}

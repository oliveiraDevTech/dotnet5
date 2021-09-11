using Core.Domain;
using Domain.Cadastro.EstoqueAgreggate.Rules.Clauses;
using System;
using System.Collections.Generic;

namespace Domain.Cadastro.EstoqueAgreggate.Rules
{
    public static class EstoqueRule
    {
        public static List<Rule<Estoque>> ObterRegras()
        {
            return new List<Rule<Estoque>>
            {
                new QuantidadeClause()
            };
        }
    }
}
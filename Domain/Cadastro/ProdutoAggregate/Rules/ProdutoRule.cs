using Core.Domain;
using Domain.Cadastro.ProdutoAggregate.Rules.Clauses;
using System.Collections.Generic;

namespace Domain.Cadastro.ProdutoAggregate.Rules
{
    public static class ProdutoRule
    {
        public static List<Rule<Produto>> ObterRegras()
        {
            return new List<Rule<Produto>>
            {
                new CodigoProdutoClause(),
                new DescricaoProdutoClause(),
                new ImpostoClause(),
                new MedidaClause(),
                new NomeProdutoClause(),
                new PesoClause(),
                new ValorClause()
            };
        }
    }
}
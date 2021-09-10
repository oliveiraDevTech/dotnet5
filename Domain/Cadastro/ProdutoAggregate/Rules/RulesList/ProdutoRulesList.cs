using Domain.Cadastro.ProdutoAggregate.Rules.Clauses;
using System.Collections.Generic;

namespace Domain.Cadastro.ProdutoAggregate.Rules.RulesList
{
    public static class ProdutoRulesList
    {
        public static List<ProdutoRule> ObterRegras()
        {
            return new List<ProdutoRule>
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

using Core.Domain;
using Domain.Cadastro.EnderecoAggregate.Rules.Clauses;
using System.Collections.Generic;

namespace Domain.Cadastro.EnderecoAggregate.Rules.RulesList
{
    public static class EnderecoRule
    {
        public static List<Rule<Endereco>> ObterRegras()
        {
            return new List<Rule<Endereco>>
            {
                new PaisClause(),
                new CidadeClause(),
                new BairroClause(),
                new RuaClause(),
                new ReferenciaClause(),
                new NumeroClause(),
                new ComplementoClause()
            };
        }
    }
}
using Domain.Cadastro.EmpresaAgreggate;
using Domain.Cadastro.EnderecoAggregate.Rules.Clauses;
using System.Collections.Generic;

namespace Domain.Cadastro.EnderecoAggregate.Rules.RulesList
{
    class EnderecoRulesList
    {
        public static List<EnderecoRule> ObterRegras()
        {
            return new List<EnderecoRule>
            {
                new PaisClause(),
                new CidadeClause(),
                new BairroClause(),
                new RuaClause()
            };
        }
    }
}

using Domain.Cadastro.EmpresaAgreggate.Rules.Clauses;
using System.Collections.Generic;

namespace Domain.Cadastro.EmpresaAgreggate.Rules.RulesList
{
    public static class MatrizRulesList
    {
        public static List<MatrizRule> ObterRegras()
        {
            return new List<MatrizRule>
            {
                new FiliaisClause()
            };
        }
    }
}
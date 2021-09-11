using Core.Domain;
using Domain.Cadastro.EmpresaAgreggate.Rules.Clauses;
using System.Collections.Generic;

namespace Domain.Cadastro.EmpresaAgreggate.Rules
{
    public static class EmpresaRule
    {
        public static List<Rule<Empresa>> ObterRegras()
        {
            return new List<Rule<Empresa>>
            {
                new NomeEmpresaClause(),
                new RazaoSocialClause(),
                new CnpjClause()
            };
        }
    }
}
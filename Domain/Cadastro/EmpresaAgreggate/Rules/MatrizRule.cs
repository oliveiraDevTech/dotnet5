using Core.Domain;
using Domain.Cadastro.EmpresaAgreggate.Rules.Clauses;
using System.Collections.Generic;

namespace Domain.Cadastro.EmpresaAgreggate.Rules
{
    public static class MatrizRule
    {
        public static List<Rule<Matriz>> ObterRegras()
        {
            return new List<Rule<Matriz>>
            {
                new FiliaisClause()
            };
        }
    }
}
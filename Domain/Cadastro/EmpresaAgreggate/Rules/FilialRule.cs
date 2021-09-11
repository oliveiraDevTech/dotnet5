using Core.Domain;
using Domain.Cadastro.EmpresaAgreggate.Rules.Clauses;
using System.Collections.Generic;

namespace Domain.Cadastro.EmpresaAgreggate.Rules
{
    public static class FilialRule
    {
        public static List<Rule<Filial>> ObterRegras()
        {
            return new List<Rule<Filial>>
            {
                new MatrizClause()
            };
        }
    }
}
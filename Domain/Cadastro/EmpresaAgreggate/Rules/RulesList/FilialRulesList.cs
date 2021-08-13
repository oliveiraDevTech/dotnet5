using System.Collections.Generic;

namespace Domain.Cadastro.EmpresaAgreggate.Rules
{
    public static class FilialRulesList
    {
        public static List<FilialRule> ObterRegras()
        {
            return new List<FilialRule>
            {
                new MatrizClause()
            };
        }
    }
}

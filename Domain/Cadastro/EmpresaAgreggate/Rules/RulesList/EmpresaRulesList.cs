﻿using System.Collections.Generic;

namespace Domain.Cadastro.EmpresaAgreggate.Rules
{
    public static class ListaRegrasEmpresa
    {
        public static List<EmpresaRule> ObterRegras()
        {
            return new List<EmpresaRule>
            {
                new NomeEmpresaClause(),
                new RazaoSocialClause()
            };
        }
    }
}
using System.Collections.Generic;

namespace Domain.Cadastro.EmpresaAgreggate.Rules
{
    public static class ListaRegrasEmpresa
    {
        public static List<IEmpresaRule> ObterRegras()
        {
            return new List<IEmpresaRule>
            {
                new NomeEmpresaRule(),
                new RazaoSocialRule()
            };
        }
    }
}

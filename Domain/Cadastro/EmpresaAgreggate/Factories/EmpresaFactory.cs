using Domain.Cadastro.EmpresaAgreggate.Enumerators;
using Domain.Cadastro.EmpresaAgreggate.ValueObjects;
using Domain.Cadastro.EnderecoAggregate;

namespace Domain.Cadastro.EmpresaAgreggate.Factories
{
    public class EmpresaFactory : IEmpresaFactory
    {
        public Empresa Criar(Empresa matriz, Cnpj cnpj, string razaoSocial, string nomeEmpresa, Endereco endereco, TipoEmpresa tipoEmpresa)
        {
            if (tipoEmpresa.Equals(TipoEmpresa.Filial))
                return new Filial(matriz, cnpj, razaoSocial, nomeEmpresa, endereco);

            return new Empresa(cnpj, razaoSocial, nomeEmpresa, endereco, tipoEmpresa);
        }
    }
}
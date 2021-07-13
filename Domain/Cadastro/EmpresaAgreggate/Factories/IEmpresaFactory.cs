using Domain.Cadastro.EmpresaAgreggate.Enumerators;
using Domain.Cadastro.EmpresaAgreggate.ValueObjects;
using Domain.Cadastro.EnderecoAggregate;

namespace Domain.Cadastro.EmpresaAgreggate.Factories
{
    public interface IEmpresaFactory
    {
        Empresa Criar(Empresa matriz, Cnpj cnpj, string razaoSocial, string nomeEmpresa, Endereco endereco, TipoEmpresa tipoEmpresa);
    }
}
using Domain.Cadastro.EmpresaAgreggate.Enumerators;
using Domain.Cadastro.EmpresaAgreggate.ValueObjects;
using Domain.Cadastro.EnderecoAggregate;
using System.Collections.Generic;

namespace Domain.Cadastro.EmpresaAgreggate.Factories
{
    public class EmpresaFactory : IEmpresaFactory
    {
        public Empresa Criar(Empresa empresa, Cnpj cnpj, string razaoSocial, string nomeEmpresa, Endereco endereco, TipoEmpresa tipoEmpresa)
        {
            if (tipoEmpresa.Equals(TipoEmpresa.Filial))
                return new Filial((Matriz)empresa, cnpj, razaoSocial, nomeEmpresa, endereco);

            return new Matriz(new List<Filial>(), cnpj, razaoSocial, nomeEmpresa, endereco, tipoEmpresa);
        }
    }
}
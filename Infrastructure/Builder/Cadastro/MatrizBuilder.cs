using Core.Domain.Enumerator;
using Domain.Cadastro.EmpresaAgreggate;
using Domain.Cadastro.EmpresaAgreggate.Enumerators;
using Domain.Cadastro.EmpresaAgreggate.ValueObjects;
using Domain.Cadastro.EnderecoAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Builder.Cadastro
{
    public class MatrizBuilder
    {
        protected Cnpj _cnpj;
        protected string _razaoSocial;
        protected string _nomeEmpresa;
        protected Endereco _endereco;
        protected TipoEmpresa _tipoEmpresa;
        protected IEnumerable<Filial> _filiais;

        public MatrizBuilder()
        {
            _cnpj = new Cnpj("12345678901234");
            _razaoSocial = "Empresa Brasileira";
            _nomeEmpresa = "Brasil Corp";
            _endereco = new Endereco("Brasil", Estado.RJ, "Rio de Janeiro", "Copacabana", "Rua 123", 125, "Casa A", "Proximo ao Metro");
            _tipoEmpresa = TipoEmpresa.Grande;
            _filiais = (IEnumerable<Filial>)new FilialBuilder().Build();
        }

        public MatrizBuilder(Cnpj cnpj, string razaoSocial, string nomeEmpresa, Endereco endereco, TipoEmpresa tipoEmpresa, IEnumerable<Filial> filiais)
        {
            if (razaoSocial is null)
            {
                throw new ArgumentNullException(nameof(razaoSocial));
            }

            _cnpj = cnpj;
            _razaoSocial = nomeEmpresa;
            _nomeEmpresa = nomeEmpresa;
            _endereco = endereco;
            _tipoEmpresa = tipoEmpresa;
            _filiais = filiais;
        }

        public MatrizBuilder ComCnpj(Cnpj cnpj)
        {
            _cnpj = cnpj;
            return this;
        }

        public MatrizBuilder ComRazaoSocial(string razaoSocial)
        {
            _razaoSocial = razaoSocial;
            return this;
        }

        public MatrizBuilder ComNomeEmpresa(string nomeEmpresa)
        {
            _nomeEmpresa = nomeEmpresa;
            return this;
        }

        public MatrizBuilder ComEndereco(Endereco endereco)
        {
            _endereco = endereco;
            return this;
        }

        public MatrizBuilder ComTipoEmpresa(TipoEmpresa tipoEmpresa)
        {
            _tipoEmpresa = tipoEmpresa;
            return this;
        }

        public MatrizBuilder ComFiliais(IEnumerable<Filial> filiais)
        {
            _filiais = filiais;
            return this;
        }

        public Matriz Build() => new(_filiais, _cnpj, _razaoSocial, _nomeEmpresa, _endereco, _tipoEmpresa);
    }
}
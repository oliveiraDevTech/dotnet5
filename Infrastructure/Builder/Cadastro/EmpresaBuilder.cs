using Core.Domain.Enumerator;
using Domain.Cadastro.EmpresaAgreggate;
using Domain.Cadastro.EmpresaAgreggate.Enumerators;
using Domain.Cadastro.EmpresaAgreggate.ValueObjects;
using Domain.Cadastro.EnderecoAggregate;

namespace Infrastructure.Builder.Cadastro
{
    public class EmpresaBuilder
    {
        protected Cnpj _cnpj;
        protected string _razaoSocial;
        protected string _nomeEmpresa;
        protected Endereco _endereco;
        protected TipoEmpresa _tipoEmpresa;

        public EmpresaBuilder()
        {
            _cnpj = new Cnpj("12345678901234");
            _razaoSocial = "Empresa Brasileira";
            _nomeEmpresa = "Brasil Corp";
            _endereco = new Endereco("Brasil", Estado.RJ, "Rio de Janeiro", "Copacabana", "Rua 123", 125, "Casa A", "Proximo ao Metro");
            _tipoEmpresa = TipoEmpresa.Grande;
        }

        public EmpresaBuilder(Cnpj cnpj, string razaoSocial, string nomeEmpresa, Endereco endereco, TipoEmpresa tipoEmpresa)
        {
            _cnpj = cnpj;
            _razaoSocial = nomeEmpresa;
            _nomeEmpresa = nomeEmpresa;
            _endereco = endereco;
            _tipoEmpresa = tipoEmpresa;
        }

        public EmpresaBuilder ComCnpj(Cnpj cnpj)
        {
            _cnpj = cnpj;
            return this;
        }

        public EmpresaBuilder ComRazaoSocial(string razaoSocial)
        {
            _razaoSocial = razaoSocial;
            return this;
        }

        public EmpresaBuilder ComNomeEmpresa(string nomeEmpresa)
        {
            _nomeEmpresa = nomeEmpresa;
            return this;
        }

        public EmpresaBuilder ComEndereco(Endereco endereco)
        {
            _endereco = endereco;
            return this;
        }

        public EmpresaBuilder ComTipoEmpresa(TipoEmpresa tipoEmpresa)
        {
            _tipoEmpresa = tipoEmpresa;
            return this;
        }

        public Empresa Build() => new Empresa(_cnpj, _razaoSocial, _nomeEmpresa, _endereco, _tipoEmpresa);
    }
}
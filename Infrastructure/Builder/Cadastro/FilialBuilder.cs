using Core.Domain.Enumerator;
using Domain.Cadastro.EmpresaAgreggate;
using Domain.Cadastro.EmpresaAgreggate.Enumerators;
using Domain.Cadastro.EmpresaAgreggate.ValueObjects;
using Domain.Cadastro.EnderecoAggregate;

namespace Infrastructure.Builder.Cadastro
{
    public class FilialBuilder
    {
        private Matriz _matriz;
        protected Cnpj _cnpj;
        protected string _razaoSocial;
        protected string _nomeEmpresa;
        protected Endereco _endereco;
        protected TipoEmpresa _tipoEmpresa;

        public FilialBuilder()
        {
            _matriz = new MatrizBuilder().Build();
            _cnpj = new Cnpj("12345678901234");
            _razaoSocial = "Filial da Empresa Brasileira";
            _nomeEmpresa = "Filial Brasil Corp";
            _endereco = new Endereco("Brasil", Estado.RJ, "Rio de Janeiro", "Ipanema", "Rua 456", 125, "Casa B", "Proximo a praia");
            _tipoEmpresa = TipoEmpresa.Filial;
        }

        public FilialBuilder(Matriz matriz, Cnpj cnpj, string razaoSocial, string nomeEmpresa, Endereco endereco)
        {
            _matriz = matriz;
            _cnpj = cnpj;
            _razaoSocial = nomeEmpresa;
            _nomeEmpresa = nomeEmpresa;
            _endereco = endereco;
            _tipoEmpresa = TipoEmpresa.Filial;
        }

        public FilialBuilder ComMatriz(Matriz matriz)
        {
            _matriz = matriz;
            return this;
        }

        public Filial Build() => new Filial(_matriz, _cnpj, _razaoSocial, _nomeEmpresa, _endereco);
    }
}
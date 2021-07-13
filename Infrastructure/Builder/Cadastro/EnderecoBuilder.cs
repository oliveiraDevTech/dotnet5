using Core.Domain.Enumerator;
using Domain.Cadastro.EnderecoAggregate;

namespace Infrastructure.Builder.Cadastro
{
    public class EnderecoBuilder
    {
        private string _pais;
        private Estado _estado;
        private string _cidade;
        private string _bairro;
        private string _rua;
        private int _numero;
        private string _complemento;
        private string _referencia;

        public EnderecoBuilder(string pais, Estado estado, string cidade, string bairro, string rua, int numero, string complemento, string referencia)
        {
            _pais = pais;
            _estado = estado;
            _cidade = cidade;
            _bairro = bairro;
            _rua = rua;
            _numero = numero;
            _complemento = complemento;
            _referencia = referencia;
        }

        public EnderecoBuilder()
        {
            _pais = "Brasil";
            _estado = Estado.RJ;
            _cidade = "Rio de Janeiro";
            _bairro = "Bangu";
            _rua = "Rua 123";
            _numero = 456;
            _complemento = "Casa 2";
            _referencia = "Próximo ao mercado";
        }

        public EnderecoBuilder ComPais(string pais)
        {
            _pais = pais;
            return this;
        }

        public EnderecoBuilder ComEstado(Estado estado)
        {
            _estado = estado;
            return this;
        }

        public EnderecoBuilder ComCidade(string cidade)
        {
            _cidade = cidade;
            return this;
        }

        public EnderecoBuilder ComBairro(string bairro)
        {
            _bairro = bairro;
            return this;
        }

        public EnderecoBuilder ComRua(string rua)
        {
            _rua = rua;
            return this;
        }

        public EnderecoBuilder ComComplemento(string complemento)
        {
            _complemento = complemento;
            return this;
        }

        public EnderecoBuilder ComReferencia(string referencia)
        {
            _referencia = referencia;
            return this;
        }

        public Endereco Build() => new Endereco(_pais, _estado, _cidade, _bairro, _rua, _numero, _complemento, _referencia);
    }
}
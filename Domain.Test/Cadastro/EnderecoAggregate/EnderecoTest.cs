using Core.Domain.Enumerator;
using FluentAssertions;
using Infrastructure.Builder.Cadastro;
using Xunit;

namespace Domain.Test.Agregates.EnderecoAgreggate
{
    public class EnderecoTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("a")]
        [InlineData("asoidniojs andioasd asnd ioas dnio asndnioasn di idnasidasoiioasniosnioasnda donasoi")]
        [InlineData("")]
        [Trait("Test Category", "UnityTest")]
        public void CriarEndereco_Quando_PaisInIsValido_DeveFalhar(string pais)
        {
            //Arrange
            var sut = new EnderecoBuilder().ComPais(pais).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        [Trait("Test Category", "UnityTest")]
        public void CriarEndereco_Quando_EstadoIsValido_DevePassar()
        {
            //Arrange
            var sut = new EnderecoBuilder().ComEstado(Estado.RJ).Build();
            //Act
            var result = sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("a")]
        [InlineData(" aiushiua sbniua bsiuab siuab siuba uisbaui sba iub uasbuai asoidniojs andioasd asnd ioas dnio asndnioasn di idnasidasoiioasniosnioasnda donasoi")]
        [InlineData("")]
        [Trait("Test Category", "UnityTest")]
        public void CriarEndereco_Quando_CidadeInIsValida_DeveFalhar(string cidade)
        {
            //Arrange
            var sut = new EnderecoBuilder().ComCidade(cidade).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("a")]
        [InlineData(" aiushiua sbniua bsiuab siuab siuba uisbaui sba iub uasbuai asoidniojs andioasd asnd ioas dnio asndnioasn di idnasidasoiioasniosnioasnda donasoi")]
        [InlineData("")]
        [Trait("Test Category", "UnityTest")]
        public void CriarEndereco_Quando_BairroInIsValido_DeveFalhar(string bairro)
        {
            //Arrange
            var sut = new EnderecoBuilder().ComBairro(bairro).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("a")]
        [InlineData(" aiushiua sbnia asa sassasasasasdkaoisnmas as  qwewasd asd asua bsiuab siuab siuba uisbaui sba iub uasbuai asoidniojs andioasd asnd ioas dnio asndnioasn di idnasidasoiioasniosnioasnda donasoi")]
        [InlineData("")]
        [Trait("Test Category", "UnityTest")]
        public void CriarEndereco_Quando_RuaInIsValida_DeveFalhar(string rua)
        {
            //Arrange
            var sut = new EnderecoBuilder().ComRua(rua).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("a")]
        [InlineData(" aiushiua sbnia asa sassasasasasdkaoisnmas as  qwewasd asd asua bsiuab siuab siuba uisbaui sba iub uasbuai asoidniojs andioasd asnd ioas dnio asndnioasn di idnasidasoiioasniosnioasnda donasoi")]
        [InlineData("")]
        [Trait("Test Category", "UnityTest")]
        public void CriarEndereco_Quando_ComplementoInIsValido_DeveFalhar(string complemento)
        {
            //Arrange
            var sut = new EnderecoBuilder().ComComplemento(complemento).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }


        [Theory]
        [InlineData(null)]
        [InlineData("a")]
        [InlineData(" aiushiua sbnia asa sassasasasasdasdkasoidnoia sndoians dioasn dioansd nasdo asi dnasiodnasoidnasodaikaoisnmas as  qwewasd asd asua bsiuab siuab siuba uisbaui sba iub uasbuai asoidniojs andioasd asnd ioas dnio asndnioasn di idnasidasoiioasniosnioasnda donasoi")]
        [InlineData("")]
        [Trait("Test Category", "UnityTest")]
        public void CriarEndereco_Quando_ReferenciaInIsValida_DeveFalhar(string referencia)
        {
            //Arrange
            var sut = new EnderecoBuilder().ComReferencia(referencia).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        [Trait("Test Category", "UnityTest")]
        public void CriarEndereco_Quando_EnderecoIsValido_DevePassar()
        {
            //Arrange
            var sut = new EnderecoBuilder().Build();
            //Act
            var result = sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }
    }
}

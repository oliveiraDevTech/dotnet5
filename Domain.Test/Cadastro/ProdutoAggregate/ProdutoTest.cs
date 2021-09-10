using Domain.Cadastro.ProdutoAggregate.ValueObject;
using FluentAssertions;
using Infrastructure.Builder.Cadastro;
using Xunit;

namespace Domain.Test.Agregates.ProdutoAgreggate
{
    public class ProdutoTest
    {
        [Theory]
        [InlineData("n")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("asdioasiodniasndaisndiuasndiuansdiuansdiunasiudnasuinduiasndiunasduinasudnasiudnasiundiuasndiuasnduinasdndaisndiuasndiuansdiuansdiunasiudnasuinduiasndiunasduinasudnasiudnasiundiuasndiuasnduinasd")]
        [Trait("Test Category", "UnityTest")]
        public void CriarProduto_Quando_NomeErrado_Deve_Falhar(string nome)
        {
            //Arrange
            var sut = new ProdutoBuilder().ComNome(nome).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901")]
        [Trait("Test Category", "UnityTest")]
        public void CriarProduto_Quando_CodigoErrado_Deve_Falhar(string codigo)
        {
            //Arrange
            var sut = new ProdutoBuilder().ComCodigo(codigo).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("sadniaosndioasndio ansiodnasidnasio ndiosandiasndioas nidoanidnasoid nioasdioasndiadnasioniandia sn dias idnasio daindoiasndia snioasio iasdioasdiasndiona siodna isondiasndioasdi nasi nasiodiasn diasndionasidnasiodnioasndioasndionasidonaisondaiosndioasn diasndioansdinasdoinasoidnasiodnaisondisand asdi asdioasjid asd")]
        [Trait("Test Category", "UnityTest")]
        public void CriarProduto_Quando_DescricaoErrada_Deve_Falhar(string descricao)
        {
            //Arrange
            var sut = new ProdutoBuilder().ComDescricao(descricao).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [Trait("Test Category", "UnityTest")]
        public void CriarProduto_Quando_PesoNulo_Deve_Falhar(Peso peso)
        {
            //Arrange
            var sut = new ProdutoBuilder().ComPeso(peso).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [Trait("Test Category", "UnityTest")]
        public void CriarProduto_Quando_MedidaNula_Deve_Falhar(Medida medida)
        {
            //Arrange
            var sut = new ProdutoBuilder().ComMedida(medida).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        [Trait("Test Category", "UnityTest")]
        public void CriarProduto_Quando_IsValido_Deve_Passar()
        {
            //Arrange
            var sut = new ProdutoBuilder().Build();
            //Act
            var result = sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }
    }
}
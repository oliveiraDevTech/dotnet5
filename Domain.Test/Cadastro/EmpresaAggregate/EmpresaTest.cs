using Bogus;
using Domain.Cadastro.EmpresaAgreggate.ValueObjects;
using FluentAssertions;
using Infrastructure.Builder.Cadastro;
using Xunit;

namespace Domain.Test.Agregattes.EmpresaAgreggates
{
    public class EmpresaTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("123123123")]
        [InlineData("abcde")]
        [InlineData("")]
        [Trait("Test Category", "UnityTest")]
        public void CriarEmpresa_Quando_CNPJInIsValido_Deve_Falhar(string cnpj)
        {
            //Arrange
            var _cnpj = new Cnpj(cnpj);
            var sut = new EmpresaBuilder().ComCnpj(_cnpj).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        //TODO: ADICIONAR TESTE DE RAZAO SOCIAL

        [Theory]
        [InlineData("12345678901234")]
        [Trait("Test Category", "UnityTest")]
        public void CriarEmpresa_Quando_CNPJIsValido_Deve_Passar(string cnpj)
        {
            //Arrange
            var _cnpj = new Cnpj(cnpj);
            var sut = new EmpresaBuilder().ComCnpj(_cnpj).Build();
            //Act
            var result = sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("nome")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("asdioasiodniasndaisndiuasndiuansdiuansdiunasiudnasuinduiasndiunasduinasudnasiudnasiundiuasndiuasnduinasdndaisndiuasndiuansdiuansdiunasiudnasuinduiasndiunasduinasudnasiudnasiundiuasndiuasnduinasd")]
        [Trait("Test Category", "UnityTest")]
        public void CriarEmpresa_Quando_NomeEmpresaInIsValido_Deve_Falhar(string nomeEmpresa)
        {   
            //Arrange
            var sut = new EmpresaBuilder().ComNomeEmpresa(nomeEmpresa).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        [Trait("Test Category", "UnityTest")]
        public void CriarEmpresa_Quando_NomeEmpresaIsValido_Deve_Passar()
        {
            //Arrange
            var name = new Faker().Name.FullName();
            var sut = new EmpresaBuilder().ComNomeEmpresa(name).Build();
            //Act
            var result = sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }
    }
}


using Domain.Cadastro.EmpresaAgreggate.ValueObjects;
using FluentAssertions;
using Infrastructure.Builder.Cadastro;
using Xunit;

namespace Domain.Test.Cadastro.EmpresaAggregate
{
    public class FilialTest
    {
        [Fact]
        [Trait("Test Category", "UnityTest")]
        public void CriarEmpresa_Quando_CNPJInIsValido_Deve_Falhar()
        {
            //Arrange
            var _matriz = new EmpresaBuilder().Build();
            var sut = new FilialBuilder().ComMatriz(_matriz).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

    }
}

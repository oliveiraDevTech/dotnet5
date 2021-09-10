using Domain.Cadastro.EmpresaAgreggate;
using Domain.Cadastro.ProdutoAggregate;
using FluentAssertions;
using Infrastructure.Builder.Cadastro;
using System.Collections.Generic;
using Xunit;

namespace Domain.Test.Agregates.FornecedorAgreggate
{
    public class FornecedorTest
    {
        [Theory]
        [InlineData(null)]
        [Trait("Test Category", "UnityTest")]
        public void CriarFornecedor_Quando_EmpresaNula_Deve_Falhar(Empresa empresa)
        {
            //Arrange
            var produtos = new List<Produto>() { new ProdutoBuilder().Build() };
            var sut = new FornecedorBuilder().ComEmpresa(empresa)
                                             .ComProdutos(produtos)
                                             .Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [Trait("Test Category", "UnityTest")]
        public void CriarFornecedor_Quando_ProdutoNulo_Deve_Falhar(List<Produto> produtos)
        {
            //Arrange
            var empresa = new MatrizBuilder().Build();
            var sut = new FornecedorBuilder().ComEmpresa(empresa)
                                             .ComProdutos(produtos)
                                             .Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        [Trait("Test Category", "UnityTest")]
        public void CriarFornecedor_Quando_PropriedadesCorretas_Deve_Passar()
        {
            //Arrange
            var produtos = new List<Produto>() { new ProdutoBuilder().Build() };
            var empresa = new MatrizBuilder().Build();
            var sut = new FornecedorBuilder().ComEmpresa(empresa)
                                             .ComProdutos(produtos)
                                             .Build();
            //Act
            var result = sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }
    }
}
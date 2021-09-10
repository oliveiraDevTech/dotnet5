using Domain.Cadastro.EstoqueAgreggate;
using Domain.Cadastro.ProdutoAggregate;
using FluentAssertions;
using Infrastructure.Builder.Cadastro;
using System;
using System.Collections.Generic;
using Xunit;

namespace Domain.Test.Agregates.EstoqueAgreggate
{
    public class EstoqueTest
    {
        [Theory]
        [InlineData(null)]
        [Trait("Test Category", "UnityTest")]
        public void CriarEstoque_Quando_ProdutoInIsValido_DeveFalhar(Produto produto)
        {
            //Arrange
            var sut = new EstoqueBuilder().ComProduto(produto).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        [Trait("Test Category", "UnityTest")]
        public void CriarEstoque_Quando_MovimentosIsValidos_DevePassar()
        {
            //Arrange
            var movimentos = new List<MovimentoEstoque>();
            var sut = new EstoqueBuilder().ComMovimentos(movimentos).Build();
            //Act
            var result = sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [Trait("Test Category", "UnityTest")]
        public void CriarEstoque_Quando_VencimentoInIsValido_DeveFalhar(DateTime? vencimento)
        {
            //Arrange
            var sut = new EstoqueBuilder().ComVencimento(vencimento).Build();
            //Act
            var result = !sut.IsValid;
            //Assert
            result.Should().BeTrue();
        }
    }
}
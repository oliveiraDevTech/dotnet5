using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Cadastro.Dto
{
    public class EstoqueDto
    {
        [Required]
        public QuantidadeDto Quantidade { get; set; }

        [Required]
        public ProdutoDto Produto { get; set; }

        [Required]
        public FornecedorDto Fornecedor { get; set; }

        [Required]
        public IEnumerable<MovimentoEstoqueDto> Movimentos { get; set; }

        [Required]
        public DateTime Fabricacao { get; set; }

        public DateTime? Vencimento { get; set; }
    }
}
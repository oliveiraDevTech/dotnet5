using Domain.Cadastro.EstoqueAgreggate.Enumerators;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Cadastro.Dto
{
    public class MovimentoEstoqueDto
    {
        [Required]
        public TipoMovimento Tipo { get; set; }

        [Required]
        public DateTime Lancamento { get; set; }
    }
}
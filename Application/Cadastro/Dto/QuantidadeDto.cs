using Domain.Cadastro.EstoqueAgreggate.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace Application.Cadastro.Dto
{
    public class QuantidadeDto
    {
        [Required]
        public double Valor { get; internal set; }

        [Required]
        public UnidadeMedida Unidade { get; internal set; }
    }
}
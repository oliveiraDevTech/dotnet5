using Core.Application;
using System.ComponentModel.DataAnnotations;

namespace Application.Cadastro.Dto
{
    public class MedidaDto : IDto
    {
        [Required]
        public decimal Altura { get; set; }

        [Required]
        public decimal Largura { get; set; }

        [Required]
        public decimal Comprimento { get; set; }
    }
}
using Core.Application;
using System.ComponentModel.DataAnnotations;

namespace Application.Cadastro.Dto
{
    public class ImpostoDto : IDto
    {
        [Required]
        public decimal Pis { get; set; }

        [Required]
        public decimal Cofins { get; set; }

        [Required]
        public decimal Icms { get; set; }

        [Required]
        public decimal Ipi { get; set; }
    }
}
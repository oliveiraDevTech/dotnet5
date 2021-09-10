using Core.Application;
using Core.Domain.Enumerator;
using System.ComponentModel.DataAnnotations;

namespace Application.Cadastro.Dto
{
    public class EnderecoDto : IDto
    {
        [Required]
        public string Pais { get; set; }

        [Required]
        public Estado Estado { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        public int Numero { get; set; }

        public string Complemento { get; set; }
        public string Referencia { get; set; }
    }
}
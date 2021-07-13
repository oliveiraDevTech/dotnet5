using Core.Application;
using System.ComponentModel.DataAnnotations;

namespace Application.Cadastro.Dto
{
    public class EmpresaDto : IDto
    {
        [Required]
        public string RazaoSocial { get; set; }

        [Required]
        public string Cnpj { get; set; }

        public string NomeEmpresa { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string TipoEmpresa { get; set; }
    }
}
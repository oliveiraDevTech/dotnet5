using Core.Application;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Cadastro.Dto
{
    public class FornecedorDto : IDto
    {
        [Required]
        public EmpresaDto Empresa { get; set; }

        [Required]
        public IEnumerable<ProdutoDto> Produtos { get; set; }
    }
}
using Core.Application;
using System.ComponentModel.DataAnnotations;

namespace Application.Cadastro.Dto
{
    public class ProdutoDto : IDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Descricao { get; set; }

        public string Peso { get; set; }

        public MedidaDto Medida { get; set; }

        [Required]
        public decimal Preco { get; private set; }

        [Required]
        public ImpostoDto Imposto { get; private set; }
    }
}
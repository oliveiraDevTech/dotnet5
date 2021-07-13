using Application.Cadastro.Modules.EstoqueModule.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("v1/estoque")]
    public class EstoqueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstoqueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(AdicionarEstoqueCommand estoqueCommand) 
        {
            var retorno = await _mediator.Send(estoqueCommand);

            if (retorno.IsValid)
            {
                return UnprocessableEntity(retorno.Errors);
            }

            return Created(string.Empty, null);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AdicionarEstoqueCommand estoqueCommand)
        {
            var retorno = await _mediator.Send(estoqueCommand);

            if (retorno.IsValid)
            {
                return UnprocessableEntity(retorno.Errors);
            }

            return Created(string.Empty, null);
        }
    }
}

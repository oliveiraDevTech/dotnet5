using Application.Cadastro.Dto.Acesso;
using Application.Cadastro.Modules.AcessoModule.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Acesso.AcessoModule.Services;

namespace Api.Controllers
{
    [Route("v1")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioService _usuarioService;

        public AcessoController(IMediator mediator, IUsuarioService usuarioService)

        {
            _mediator = mediator;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("validar")]
        [AllowAnonymous]
        public async Task<IActionResult> ValidarUsuario(UsuarioDto usuarioDto)
        {
            var retorno = await _usuarioService.ValidadeUser(usuarioDto);

            if (retorno)
                return new OkResult();

            return new NoContentResult();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("token")]
        public async Task<IActionResult> GerarToken(GerarToken gerarToken)
        {
            var retorno = await _mediator.Send(gerarToken);

            if (retorno.IsValid)
            {
                return UnprocessableEntity(retorno.Errors);
            }

            return Created(retorno.Value().Chave, null);
        }
    }
}
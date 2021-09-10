using Application.Cadastro.Dto;
using Application.Cadastro.Modules.EnderecoModule.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("v1/endereco")]
    public class EnderecoController : ControllerBase, IGenericController<EnderecoDto, long>
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(EnderecoDto empresaDto)
        {
            var retorno = await _enderecoService.Create(empresaDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IEnumerable<EnderecoDto> empresasDto)
        {
            var retorno = await _enderecoService.Create(empresasDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var retorno = await _enderecoService.Delete(id);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(IEnumerable<EnderecoDto> empresasDto)
        {
            var retorno = await _enderecoService.Delete(empresasDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(EnderecoDto empresasDto)
        {
            var retorno = await _enderecoService.Delete(empresasDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var retorno = await _enderecoService.Get(id);

            if (retorno.IsValid)
            {
                return BadRequest(retorno);
            }

            return Ok(retorno);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var retorno = await _enderecoService.GetAll();

            if (retorno.IsValid)
            {
                return BadRequest(retorno);
            }

            return Ok(retorno);
        }

        [HttpPut]
        public async Task<IActionResult> Update(IEnumerable<EnderecoDto> empresasDto)
        {
            var retorno = await _enderecoService.Update(empresasDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpPut]
        public async Task<IActionResult> Update(EnderecoDto empresaDto)
        {
            var retorno = await _enderecoService.Update(empresaDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }
    }
}
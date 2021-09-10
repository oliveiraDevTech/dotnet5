using Application.Cadastro.Dto;
using Application.Cadastro.Modules.FornecedorModule.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("v1/fornecedor")]
    public class FornecedorController : ControllerBase, IGenericController<FornecedorDto, long>
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(FornecedorDto fornecedorDto)
        {
            var retorno = await _fornecedorService.Create(fornecedorDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IEnumerable<FornecedorDto> fornecedorService)
        {
            var retorno = await _fornecedorService.Create(fornecedorService);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var retorno = await _fornecedorService.Delete(id);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(IEnumerable<FornecedorDto> fornecedorDtos)
        {
            var retorno = await _fornecedorService.Delete(fornecedorDtos);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(FornecedorDto fornecedorDto)
        {
            var retorno = await _fornecedorService.Delete(fornecedorDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var retorno = await _fornecedorService.Get(id);

            if (retorno.IsValid)
            {
                return BadRequest(retorno);
            }

            return Ok(retorno);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var retorno = await _fornecedorService.GetAll();

            if (retorno.IsValid)
            {
                return BadRequest(retorno);
            }

            return Ok(retorno);
        }

        [HttpPut]
        public async Task<IActionResult> Update(IEnumerable<FornecedorDto> fornecedorDto)
        {
            var retorno = await _fornecedorService.Update(fornecedorDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpPut]
        public async Task<IActionResult> Update(FornecedorDto fornecedorDto)
        {
            var retorno = await _fornecedorService.Update(fornecedorDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }
    }
}
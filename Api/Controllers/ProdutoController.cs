using Application.Cadastro.Dto;
using Application.Cadastro.Modules.ProdutoModule;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class ProdutoController : ControllerBase, IGenericController<ProdutoDto, long>
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProdutoDto entidadeDto)
        {
            var retorno = await _produtoService.Create(entidadeDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IEnumerable<ProdutoDto> entidadeDto)
        {
            var retorno = await _produtoService.Create(entidadeDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var retorno = await _produtoService.Delete(id);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(IEnumerable<ProdutoDto> entidadeDto)
        {
            var retorno = await _produtoService.Delete(entidadeDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ProdutoDto entidadeDto)
        {
            var retorno = await _produtoService.Delete(entidadeDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var retorno = await _produtoService.Get(id);

            if (retorno.IsValid)
            {
                return BadRequest(retorno);
            }

            return Ok(retorno);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var retorno = await _produtoService.GetAll();

            if (retorno.IsValid)
            {
                return BadRequest(retorno);
            }

            return Ok(retorno);
        }

        [HttpPut]
        public async Task<IActionResult> Update(IEnumerable<ProdutoDto> entidadeDto)
        {
            var retorno = await _produtoService.Update(entidadeDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProdutoDto entidadeDto)
        {
            var retorno = await _produtoService.Update(entidadeDto);

            if (retorno.IsValid)
            {
                return Ok(retorno);
            }

            return BadRequest(retorno);
        }
    }
}
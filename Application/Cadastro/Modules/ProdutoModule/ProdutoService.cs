using Application.Cadastro.Dto;
using AutoMapper;
using Core.Application.Shared;
using Core.Infrastructure.Data;
using Domain.Cadastro.ProdutoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Cadastro.Modules.ProdutoModule
{
    public class ProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Produto, long> _genericRepository;
        private readonly IDtoResult<ProdutoDto> _dtoResult;
        private readonly IMessageResult _messageResult;

        public ProdutoService(IMapper mapper, IGenericRepository<Produto, long> genericRepository, IDtoResult<ProdutoDto> dtoResult, IMessageResult messageResult, IMessageResult messageResult2)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
            _dtoResult = dtoResult;
            _messageResult = messageResult;
            _messageResult = messageResult2;
        }

        public async Task<IMessageResult> Create(ProdutoDto produtoDto)
        {
            var empresa = _mapper.Map<Produto>(produtoDto);

            try
            {
                await _genericRepository.Insert(empresa);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }

        public async Task<IMessageResult> Create(IEnumerable<ProdutoDto> produtosDto)
        {
            var empresa = _mapper.Map<IEnumerable<Produto>>(produtosDto);
            try
            {
                await _genericRepository.Insert(empresa);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }

        public async Task<IMessageResult> Delete(long id)
        {
            try
            {
                await _genericRepository.Delete(id);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }

        public async Task<IMessageResult> Delete(IEnumerable<ProdutoDto> produtosDto)
        {
            try
            {
                var empresas = _mapper.Map<IEnumerable<Produto>>(produtosDto);

                await _genericRepository.Delete(empresas);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }

        public async Task<IMessageResult> Delete(ProdutoDto produtoDto)
        {
            try
            {
                var empresa = _mapper.Map<IEnumerable<Produto>>(produtoDto);

                await _genericRepository.Delete(empresa);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }

        public async Task<IDtoResult<ProdutoDto>> Get(long id)
        {
            var resultado = await _genericRepository.Get(id);

            var resultadoDto = _mapper.Map<ProdutoDto>(resultado);

            if (resultado.Id == 0)
                return _dtoResult.Fail(new ProdutoDto(), "Vazio");

            return _dtoResult.Success(resultadoDto);
        }

        public async Task<IDtoResult<ProdutoDto>> GetAll()
        {
            var resultados = await _genericRepository.GetAll();

            var resultadosDto = _mapper.Map<IEnumerable<ProdutoDto>>(resultados);

            if (!resultadosDto.Any())
                return _dtoResult.Fail(new ProdutoDto(), "Vazio");

            return _dtoResult.Success(resultadosDto);
        }

        public async Task<IMessageResult> Update(IEnumerable<ProdutoDto> produtosDto)
        {
            var empresas = _mapper.Map<IEnumerable<Produto>>(produtosDto);

            try
            {
                await _genericRepository.Update(empresas);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }

        public async Task<IMessageResult> Update(ProdutoDto produtoDto)
        {
            var empresas = _mapper.Map<Produto>(produtoDto);

            try
            {
                await _genericRepository.Update(empresas);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }
    }
}
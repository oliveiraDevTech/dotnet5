using Application.Cadastro.Dto;
using AutoMapper;
using Core.Application.Shared;
using Core.Infrastructure.Data;
using Domain.Cadastro.EstoqueAgreggate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Cadastro.Modules.EstoqueModule.Services
{
    internal class EstoqueService : IEstoqueService

    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Estoque, long> _genericRepository;
        private readonly IDtoResult<EstoqueDto> _dtoResult;
        private readonly IMessageResult _messageResult;

        public EstoqueService(IMapper mapper, IGenericRepository<Estoque, long> genericRepository, IDtoResult<EstoqueDto> dtoResult, IMessageResult messageResult)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
            _dtoResult = dtoResult;
            _messageResult = messageResult;
        }

        public async Task<IMessageResult> Create(EstoqueDto estoqueDto)
        {
            try
            {
                var empresa = _mapper.Map<Estoque>(estoqueDto);

                if (!empresa.IsValid)
                    return _messageResult.Fail("Erro");

                await _genericRepository.Insert(empresa);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }

        public async Task<IMessageResult> Create(IEnumerable<EstoqueDto> enderecosDto)
        {
            var empresa = _mapper.Map<IEnumerable<Estoque>>(enderecosDto);
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

        public async Task<IMessageResult> Delete(IEnumerable<EstoqueDto> enderecosDto)
        {
            try
            {
                var empresas = _mapper.Map<IEnumerable<Estoque>>(enderecosDto);

                await _genericRepository.Delete(empresas);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }

        public async Task<IMessageResult> Delete(EstoqueDto estoqueDto)
        {
            try
            {
                var empresa = _mapper.Map<IEnumerable<Estoque>>(estoqueDto);

                await _genericRepository.Delete(empresa);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }

        public async Task<IDtoResult<EstoqueDto>> Get(long id)
        {
            var resultado = await _genericRepository.Get(id);

            var resultadoDto = _mapper.Map<EstoqueDto>(resultado);

            if (resultado.Id == 0)
                return _dtoResult.Fail(new EstoqueDto(), "Vazio");

            return _dtoResult.Success(resultadoDto);
        }

        public async Task<IDtoResult<EstoqueDto>> GetAll()
        {
            var resultados = await _genericRepository.GetAll();

            var resultadosDto = _mapper.Map<IEnumerable<EstoqueDto>>(resultados);

            if (!resultadosDto.Any())
                return _dtoResult.Fail(new EstoqueDto(), "Vazio");

            return _dtoResult.Success(resultadosDto);
        }

        public async Task<IMessageResult> Update(IEnumerable<EstoqueDto> enderecosDto)
        {
            var empresas = _mapper.Map<IEnumerable<Estoque>>(enderecosDto);

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

        public async Task<IMessageResult> Update(EstoqueDto estoqueDto)
        {
            var empresas = _mapper.Map<Estoque>(estoqueDto);

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
using Application.Cadastro.Dto;
using AutoMapper;
using Core.Application.Shared;
using Core.Infrastructure.Data;
using Domain.Cadastro.EnderecoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Cadastro.Modules.EnderecoModule.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Endereco, long> _genericRepository;
        private readonly IDtoResult<EnderecoDto> _dtoResult;
        private readonly IMessageResult _messageResult;

        public EnderecoService(IMapper mapper, IGenericRepository<Endereco, long> genericRepository, IDtoResult<EnderecoDto> dtoResult, IMessageResult messageResult)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
            _dtoResult = dtoResult;
            _messageResult = messageResult;
        }

        public async Task<IMessageResult> Create(EnderecoDto enderecoDto)
        {
            var empresa = _mapper.Map<Endereco>(enderecoDto);

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

        public async Task<IMessageResult> Create(IEnumerable<EnderecoDto> enderecosDto)
        {
            var empresa = _mapper.Map<IEnumerable<Endereco>>(enderecosDto);
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

        public async Task<IMessageResult> Delete(IEnumerable<EnderecoDto> enderecosDto)
        {
            try
            {
                var empresas = _mapper.Map<IEnumerable<Endereco>>(enderecosDto);

                await _genericRepository.Delete(empresas);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }

        public async Task<IMessageResult> Delete(EnderecoDto enderecoDto)
        {
            try
            {
                var empresa = _mapper.Map<IEnumerable<Endereco>>(enderecoDto);

                await _genericRepository.Delete(empresa);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }

        public async Task<IDtoResult<EnderecoDto>> Get(long id)
        {
            var resultado = await _genericRepository.Get(id);

            var resultadoDto = _mapper.Map<EnderecoDto>(resultado);

            if (resultado.Id == 0)
                return _dtoResult.Fail(new EnderecoDto(), "Vazio");

            return _dtoResult.Success(resultadoDto);
        }

        public async Task<IDtoResult<EnderecoDto>> GetAll()
        {
            var resultados = await _genericRepository.GetAll();

            var resultadosDto = _mapper.Map<IEnumerable<EnderecoDto>>(resultados);

            if (!resultadosDto.Any())
                return _dtoResult.Fail(new EnderecoDto(), "Vazio");

            return _dtoResult.Success(resultadosDto);
        }

        public async Task<IMessageResult> Update(IEnumerable<EnderecoDto> enderecosDto)
        {
            var empresas = _mapper.Map<IEnumerable<Endereco>>(enderecosDto);

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

        public async Task<IMessageResult> Update(EnderecoDto enderecoDto)
        {
            var empresas = _mapper.Map<Endereco>(enderecoDto);

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
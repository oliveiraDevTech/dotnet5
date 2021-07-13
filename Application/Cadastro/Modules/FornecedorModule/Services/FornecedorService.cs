using Application.Cadastro.Dto;
using AutoMapper;
using Core.Application.Shared;
using Core.Infrastructure.Data;
using Domain.Cadastro.FornecedorAgreggate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Cadastro.Modules.FornecedorModule.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Fornecedor, long> _genericRepository;
        private readonly IDtoResult<FornecedorDto> _dtoResult;
        private readonly IMessageResult _messageResult;

        public FornecedorService(IMapper mapper, IGenericRepository<Fornecedor, long> genericRepository, IDtoResult<FornecedorDto> dtoResult, IMessageResult messageResult, IMessageResult messageResult2)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
            _dtoResult = dtoResult;
            _messageResult = messageResult;
            _messageResult = messageResult2;
        }

        public async Task<IMessageResult> Create(FornecedorDto fornecedorDto)
        {
            var empresa = _mapper.Map<Fornecedor>(fornecedorDto);

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

        public async Task<IMessageResult> Create(IEnumerable<FornecedorDto> fornecedoresDto)
        {
            var empresa = _mapper.Map<IEnumerable<Fornecedor>>(fornecedoresDto);
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

        public async Task<IMessageResult> Delete(IEnumerable<FornecedorDto> fornecedoresDto)
        {
            try
            {
                var empresas = _mapper.Map<IEnumerable<Fornecedor>>(fornecedoresDto);

                await _genericRepository.Delete(empresas);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }

        public async Task<IMessageResult> Delete(FornecedorDto fornecedorDto)
        {
            try
            {
                var empresa = _mapper.Map<IEnumerable<Fornecedor>>(fornecedorDto);

                await _genericRepository.Delete(empresa);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }

        public async Task<IDtoResult<FornecedorDto>> Get(long id)
        {
            var resultado = await _genericRepository.Get(id);

            var resultadoDto = _mapper.Map<FornecedorDto>(resultado);

            if (resultado.Id == 0)
                return _dtoResult.Fail(new FornecedorDto(), "Vazio");

            return _dtoResult.Success(resultadoDto);
        }

        public async Task<IDtoResult<FornecedorDto>> GetAll()
        {
            var resultados = await _genericRepository.GetAll();

            var resultadosDto = _mapper.Map<IEnumerable<FornecedorDto>>(resultados);

            if (!resultadosDto.Any())
                return _dtoResult.Fail(new FornecedorDto(), "Vazio");

            return _dtoResult.Success(resultadosDto);
        }

        public async Task<IMessageResult> Update(IEnumerable<FornecedorDto> fornecedoresDto)
        {
            var empresas = _mapper.Map<IEnumerable<Fornecedor>>(fornecedoresDto);

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

        public async Task<IMessageResult> Update(FornecedorDto fornecedorDto)
        {
            var empresas = _mapper.Map<Fornecedor>(fornecedorDto);

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
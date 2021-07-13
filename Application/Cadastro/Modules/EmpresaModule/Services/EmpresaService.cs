using Application.Cadastro.Dto;
using AutoMapper;
using Core.Application.Shared;
using Core.Infrastructure.Data;
using Domain.Cadastro.EmpresaAgreggate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Cadastro.Modules.EmpresaModule.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Empresa, long> _genericRepository;
        private readonly IDtoResult<EmpresaDto> _dtoResult;
        private readonly IMessageResult _messageResult;

        public EmpresaService(IMapper mapper, IGenericRepository<Empresa, long> genericRepository, IDtoResult<EmpresaDto> dtoResult, IMessageResult messageResult)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
            _dtoResult = dtoResult;
            _messageResult = messageResult;
        }

        public async Task<IMessageResult> Create(EmpresaDto empresaDto)
        {
            var empresa = _mapper.Map<Empresa>(empresaDto);

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

        public async Task<IMessageResult> Create(IEnumerable<EmpresaDto> empresasDto)
        {
            var empresa = _mapper.Map<IEnumerable<Empresa>>(empresasDto);
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

        public async Task<IMessageResult> Delete(IEnumerable<EmpresaDto> empresasDto)
        {
            try
            {
                var empresas = _mapper.Map<IEnumerable<Empresa>>(empresasDto);

                await _genericRepository.Delete(empresas);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }

        public async Task<IMessageResult> Delete(EmpresaDto empresaDto)
        {
            try
            {
                var empresa = _mapper.Map<IEnumerable<Empresa>>(empresaDto);

                await _genericRepository.Delete(empresa);
            }
            catch (Exception)
            {
                return _messageResult.Fail("Erro");
            }

            return _messageResult.Success("Sucesso");
        }

        public async Task<IDtoResult<EmpresaDto>> Get(long id)
        {
            var resultado = await _genericRepository.Get(id);

            var resultadoDto = _mapper.Map<EmpresaDto>(resultado);

            if (resultado.Id == 0)
                return _dtoResult.Fail(new EmpresaDto(), "Vazio");

            return _dtoResult.Success(resultadoDto);
        }

        public async Task<IDtoResult<EmpresaDto>> GetAll()
        {
            var resultados = await _genericRepository.GetAll();

            var resultadosDto = _mapper.Map<IEnumerable<EmpresaDto>>(resultados);

            if (!resultadosDto.Any())
                return _dtoResult.Fail(new EmpresaDto(), "Vazio");

            return _dtoResult.Success(resultadosDto);
        }

        public async Task<IMessageResult> Update(IEnumerable<EmpresaDto> empresasDto)
        {
            var empresas = _mapper.Map<IEnumerable<Empresa>>(empresasDto);

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

        public async Task<IMessageResult> Update(EmpresaDto empresaDto)
        {
            var empresas = _mapper.Map<Empresa>(empresaDto);

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
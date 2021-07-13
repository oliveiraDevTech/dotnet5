using Application.Cadastro.Dto;
using Core.Application.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Cadastro.Modules.EmpresaModule.Services
{
    public interface IEmpresaService
    {
        Task<IMessageResult> Create(EmpresaDto empresaDto);

        Task<IMessageResult> Create(IEnumerable<EmpresaDto> empresasDto);

        Task<IMessageResult> Delete(long id);

        Task<IMessageResult> Delete(IEnumerable<EmpresaDto> empresasDto);

        Task<IMessageResult> Delete(EmpresaDto empresaDto);

        Task<IDtoResult<EmpresaDto>> Get(long id);

        Task<IDtoResult<EmpresaDto>> GetAll();

        Task<IMessageResult> Update(IEnumerable<EmpresaDto> empresasDto);

        Task<IMessageResult> Update(EmpresaDto empresasDto);
    }
}
using Application.Cadastro.Dto;
using Core.Application.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Cadastro.Modules.FornecedorModule.Services
{
    public interface IFornecedorService
    {
        Task<IMessageResult> Create(FornecedorDto fornecedorDto);

        Task<IMessageResult> Create(IEnumerable<FornecedorDto> fornecedoresDto);

        Task<IMessageResult> Delete(long id);

        Task<IMessageResult> Delete(IEnumerable<FornecedorDto> fornecedoresDto);

        Task<IMessageResult> Delete(FornecedorDto fornecedorDto);

        Task<IDtoResult<FornecedorDto>> Get(long id);

        Task<IDtoResult<FornecedorDto>> GetAll();

        Task<IMessageResult> Update(IEnumerable<FornecedorDto> fornecedoresDto);

        Task<IMessageResult> Update(FornecedorDto fornecedoresDto);
    }
}
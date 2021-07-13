using Application.Cadastro.Dto;
using Core.Application.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Cadastro.Modules.EnderecoModule.Services
{
    public interface IEnderecoService
    {
        Task<IMessageResult> Create(EnderecoDto enderecoDto);

        Task<IMessageResult> Create(IEnumerable<EnderecoDto> enderecosDto);

        Task<IMessageResult> Delete(long id);

        Task<IMessageResult> Delete(IEnumerable<EnderecoDto> enderecosDto);

        Task<IMessageResult> Delete(EnderecoDto enderecoDto);

        Task<IDtoResult<EnderecoDto>> Get(long id);

        Task<IDtoResult<EnderecoDto>> GetAll();

        Task<IMessageResult> Update(IEnumerable<EnderecoDto> enderecosDto);

        Task<IMessageResult> Update(EnderecoDto enderecosDto);
    }
}
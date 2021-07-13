using Application.Cadastro.Dto;
using Core.Application.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Cadastro.Modules.EstoqueModule.Services
{
    public interface IEstoqueService
    {
        Task<IMessageResult> Create(EstoqueDto estoqueDto);

        Task<IMessageResult> Create(IEnumerable<EstoqueDto> estoquesDto);

        Task<IMessageResult> Delete(long id);

        Task<IMessageResult> Delete(IEnumerable<EstoqueDto> empresasDto);

        Task<IMessageResult> Delete(EstoqueDto estoqueDto);

        Task<IDtoResult<EstoqueDto>> Get(long id);

        Task<IDtoResult<EstoqueDto>> GetAll();

        Task<IMessageResult> Update(IEnumerable<EstoqueDto> estoquesDto);

        Task<IMessageResult> Update(EstoqueDto empresasDto);
    }
}
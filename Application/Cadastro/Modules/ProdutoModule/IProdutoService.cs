using Application.Cadastro.Dto;
using Core.Application.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Cadastro.Modules.ProdutoModule
{
    public interface IProdutoService
    {
        Task<IMessageResult> Create(ProdutoDto produtoDto);

        Task<IMessageResult> Create(IEnumerable<ProdutoDto> produtosDto);

        Task<IMessageResult> Delete(long id);

        Task<IMessageResult> Delete(IEnumerable<ProdutoDto> produtosDto);

        Task<IMessageResult> Delete(ProdutoDto produtoDto);

        Task<IDtoResult<ProdutoDto>> Get(long id);

        Task<IDtoResult<ProdutoDto>> GetAll();

        Task<IMessageResult> Update(IEnumerable<ProdutoDto> produtosDto);

        Task<IMessageResult> Update(ProdutoDto produtosDto);
    }
}
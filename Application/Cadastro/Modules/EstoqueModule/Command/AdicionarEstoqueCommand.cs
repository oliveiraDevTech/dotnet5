using Application.Cadastro.Dto;
using Core.Application.Shared;
using MediatR;

namespace Application.Cadastro.Modules.EstoqueModule.Command
{
    public class AdicionarEstoqueCommand : IRequest<CommandResult<EstoqueDto>>
    {
        internal EstoqueDto EstoqueDto { get; set; }
    }
}
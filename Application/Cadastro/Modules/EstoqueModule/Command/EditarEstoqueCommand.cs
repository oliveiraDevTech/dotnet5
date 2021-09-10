using Application.Cadastro.Dto;
using Core.Application.Shared;
using MediatR;

namespace Application.Cadastro.Modules.EstoqueModule.Command
{
    public class EditarEstoqueCommand : IRequest<CommandResult<EstoqueDto>>
    {
        internal EstoqueDto EstoqueDto { get; set; }
        internal bool Perda { get; set; }
    }
}
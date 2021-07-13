using Application.Cadastro.Dto;
using AutoMapper;
using Core.Application.Shared;
using Domain.Cadastro.EstoqueAgreggate;
using Domain.Cadastro.EstoqueAgreggate.Factories;
using Infrastructure.Data.Context.Cadastro;
using Infrastructure.Data.Context.Cadastro.UnitOfWork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cadastro.Modules.EstoqueModule.Command
{
    public class AdicionarEstoqueCommandHandler : IRequestHandler<AdicionarEstoqueCommand, ICommandResult<EstoqueDto>>
    {
        private readonly ICadastroUnitOfWork<CadastroContext> _cadastroUnitOfWork;
        private readonly IMapper _mapper;
        private readonly IMovimentoEstoqueFactory _movimentoEstoqueFactory;
        private readonly ICommandResult<EstoqueDto> _commandResult;

        public AdicionarEstoqueCommandHandler(ICadastroUnitOfWork<CadastroContext> cadastroUnitOfWork, IMapper mapper, IMovimentoEstoqueFactory movimentoEstoqueFactory, ICommandResult<EstoqueDto> commandResult)
        {
            _cadastroUnitOfWork = cadastroUnitOfWork;
            _mapper = mapper;
            _movimentoEstoqueFactory = movimentoEstoqueFactory;
            _commandResult = commandResult;
        }

        public async Task<ICommandResult<EstoqueDto>> Handle(AdicionarEstoqueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var estoqueNovo = _mapper.Map<Estoque>(request.EstoqueDto);

                if (!estoqueNovo.IsValid)
                    return _commandResult.Fail(request.EstoqueDto, "Erro");

                var movimentoEstoque = _movimentoEstoqueFactory.Criar(0, estoqueNovo.Quantidade.Valor);

                await _cadastroUnitOfWork.EstoqueRepository.Insert(estoqueNovo);
                await _cadastroUnitOfWork.MovimentoEstoqueRepository.Insert(movimentoEstoque);

                _cadastroUnitOfWork.Commit();

                return _commandResult.Success(request.EstoqueDto);
            }
            catch (Exception)
            {
                return _commandResult.Fail(request.EstoqueDto, "Erro");
            }
        }
    }
}
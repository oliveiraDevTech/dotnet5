using Application.Cadastro.Dto;
using AutoMapper;
using Core.Application.Shared;
using Core.Infrastructure.Data;
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
    public class EditarEstoqueCommandHandler : IRequestHandler<EditarEstoqueCommand, ICommandResult<EstoqueDto>>
    {
        private readonly ICadastroUnitOfWork<CadastroContext> _cadastroUnitOfWork;
        private readonly IGenericRepository<Estoque, long> _genericRepository;
        private readonly IMovimentoEstoqueFactory _movimentoEstoqueFactory;
        private readonly IMapper _mapper;
        private readonly ICommandResult<EstoqueDto> _commandResult;

        public EditarEstoqueCommandHandler(ICadastroUnitOfWork<CadastroContext> cadastroUnitOfWork, IGenericRepository<Estoque, long> genericRepository, IMovimentoEstoqueFactory movimentoEstoqueFactory, IMapper mapper, ICommandResult<EstoqueDto> commandResult)
        {
            _cadastroUnitOfWork = cadastroUnitOfWork;
            _genericRepository = genericRepository;
            _movimentoEstoqueFactory = movimentoEstoqueFactory;
            _mapper = mapper;
            _commandResult = commandResult;
        }

        public async Task<ICommandResult<EstoqueDto>> Handle(EditarEstoqueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var estoqueNovo = _mapper.Map<Estoque>(request.EstoqueDto);

                if (!estoqueNovo.IsValid)
                    return _commandResult.Fail(request.EstoqueDto, "Erro");

                var estoqueAntigo = await _genericRepository.Get(estoqueNovo.Id);

                if (estoqueAntigo.Id == 0)
                    return _commandResult.Fail(request.EstoqueDto, "Erro");

                var movimentoEstoque = _movimentoEstoqueFactory.Criar(estoqueAntigo.Quantidade.Valor, estoqueNovo.Quantidade.Valor, request.Perda);
                
                estoqueAntigo.ModifyByEntity(estoqueNovo);

                await _cadastroUnitOfWork.EstoqueRepository.Update(estoqueAntigo);
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

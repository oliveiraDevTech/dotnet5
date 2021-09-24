using Application.Cadastro.Dto.Acesso;
using Core.Application.Shared;
using Domain.Acesso.UsuarioAgreggate;
using MediatR;

namespace Application.Cadastro.Modules.AcessoModule.Command
{
    public class GerarToken : IRequest<CommandResult<TokenDto>>
    {
        public Usuario Usuario { get; private set; }

        public GerarToken(Usuario usuario)
        {
            Usuario = usuario;
        }
    }
}
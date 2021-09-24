using Application.Cadastro.Dto.Acesso;
using Core.Application.Shared;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Application.Cadastro.Modules.AcessoModule.Settings;

namespace Application.Cadastro.Modules.AcessoModule.Command
{
    public class GerarTokenHandler : IRequestHandler<GerarToken, ICommandResult<TokenDto>>
    {
        private readonly ICommandResult<TokenDto> _commandResult;

        public GerarTokenHandler(ICommandResult<TokenDto> commandResult)
        {
            _commandResult = commandResult;
        }

        public async Task<ICommandResult<TokenDto>> Handle(GerarToken request, CancellationToken cancellationToken)
        {
            var tokenDto = new TokenDto();

            var taskToken = new Task<string>(() => GenerateNewToken(request));

            tokenDto.Chave = await taskToken;

            return _commandResult.Success(tokenDto);
        }

        private string GenerateNewToken(GerarToken request)
        {
            JwtSecurityTokenHandler tokenHandler;
            SecurityTokenDescriptor tokenDescriptor;

            tokenHandler = new JwtSecurityTokenHandler();
            var key = TokenConfigurations.Enconding;
            tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, request.Usuario.Nome),
                    new Claim(ClaimTypes.Role, request.Usuario.Role)
                }),
                Expires = TokenConfigurations.DateExpire,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
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
        private TokenDto _tokenDto;
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public GerarTokenHandler(ICommandResult<TokenDto> commandResult)
        {
            _commandResult = commandResult;
            _tokenDto = new TokenDto();
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task<ICommandResult<TokenDto>> Handle(GerarToken request, CancellationToken cancellationToken)
        {
            var taskToken = new Task<string>(() => GenerateNewToken(request));

            _tokenDto.Chave = await taskToken;

            return _commandResult.Success(_tokenDto);
        }

        private string GenerateNewToken(GerarToken request)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, request.Usuario.Login),
                    new Claim(ClaimTypes.Role, request.Usuario.Role)
                }),
                Expires = TokenConfigurations.DateExpire,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(TokenConfigurations.Enconding), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = _jwtSecurityTokenHandler.CreateToken(tokenDescriptor);

            return _jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}
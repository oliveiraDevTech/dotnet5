using Application.Cadastro.Dto.Acesso;
using AutoMapper;
using Domain.Acesso.UsuarioAgreggate;
using Infrastructure.Data.Context.Cadastro;
using System.Threading.Tasks;

namespace Application.Acesso.AcessoModule.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository<AcessoContext> _usuarioRepository;

        public UsuarioService(IMapper mapper, IUsuarioRepository<AcessoContext> usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public Task<bool> ValidadeUser(UsuarioDto usuarioDto)
        {
            var Usuario = _mapper.Map<Usuario>(usuarioDto);

            return _usuarioRepository.FindUserExists(Usuario);
        }
    }
}
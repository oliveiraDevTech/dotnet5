using Application.Cadastro.Dto.Acesso;
using System.Threading.Tasks;

namespace Application.Acesso.AcessoModule.Services
{
    public interface IUsuarioService
    {
        Task<bool> ValidadeUser(UsuarioDto usuarioDto);
    }
}
using Core.Infrastructure.Data;
using System.Threading.Tasks;

namespace Domain.Acesso.UsuarioAgreggate
{
    public interface IUsuarioRepository<TDbcontext> : IRepository<Usuario, long>
    {
        TDbcontext DbContext { get; }

        Task<bool> FindUserExists(Usuario usuario);
    }
}
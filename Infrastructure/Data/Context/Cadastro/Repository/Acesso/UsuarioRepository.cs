using Domain.Acesso.UsuarioAgreggate;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Context.Cadastro.Repository.Acesso
{
    public class UsuarioRepository : IUsuarioRepository<AcessoContext>
    {
        public AcessoContext DbContext { get; }

        public Task<bool> FindUserExists(Usuario usuario)
        {
            return DbContext.Usuario.Where(x => x.Login == usuario.Login && x.Senha == usuario.Senha).AnyAsync();
        }
    }
}
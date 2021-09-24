using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Cadastro.EstoqueAgreggate.Events
{
    public class EstoqueAltreradoNotificationHandle : INotificationHandler<EstoqueAlterado>
    {
        public Task Handle(EstoqueAlterado notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
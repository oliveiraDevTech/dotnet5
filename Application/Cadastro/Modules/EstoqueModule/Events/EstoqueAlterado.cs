using MediatR;

namespace Domain.Cadastro.EstoqueAgreggate.Events
{
    public class EstoqueAlterado : INotification
    {
        public string Nome { get; }

        public EstoqueAlterado(string nome)
        {
            Nome = nome;
        }
    }
}
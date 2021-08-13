using Domain.Cadastro.EmpresaAgreggate;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EnderecoAggregate.Rules.Clauses
{
    public class PaisClause : EnderecoRule
    {
        private const string Mensagem = "Pais inválido";
        private const string Mensagem2 = "Pais precisa ter no mínimo 2 caracteres";
        private const string Mensagem3 = "Pais precisa ter no máximo 50 caracteres";
        public override void Validar(Endereco endereco)
        {
            AddNotifications(new Contract<Notification>().IsNotNullOrEmpty(endereco.Pais, nameof(endereco.Pais), Mensagem)
                                 .IsGreaterOrEqualsThan(endereco.Pais, 2, nameof(endereco.Pais), Mensagem2)
                                 .IsLowerOrEqualsThan(endereco.Pais, 50, nameof(endereco.Pais), Mensagem3));
        }
    }
}

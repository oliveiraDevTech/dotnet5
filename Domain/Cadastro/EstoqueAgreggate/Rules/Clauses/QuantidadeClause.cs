using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.EstoqueAgreggate.Rules.Clauses
{
    public class QuantidadeClause : Rule<Estoque>
    {
        private const string _mensagem = "Valor da Quantidade é inválido";
        private const string _mensagem2 = "Unidade de Medida da Quantidade é inválido";

        public override void Validar(Estoque estoque)
        {
            AddNotifications(new Contract<Notification>().IsNotNull(estoque.Quantidade.Valor, nameof(estoque.Quantidade.Valor), _mensagem)
                                 .IsNotNull(estoque.Quantidade.Unidade, nameof(estoque.Quantidade.Unidade), _mensagem2));
        }
    }
}
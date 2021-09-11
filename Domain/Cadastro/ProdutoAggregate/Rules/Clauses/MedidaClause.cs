using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.ProdutoAggregate.Rules.Clauses
{
    internal class MedidaClause : Rule<Produto>
    {
        public override void Validar(Produto produto)
        {
            AddNotifications(new Contract<Notification>().IsNotNull(produto.Medida.Altura, nameof(produto.Medida.Altura), "Altura da Medida é inválida")
                                 .IsNotNull(produto.Medida.Largura, nameof(produto.Medida.Largura), "Largura da Medida é inválida")
                                 .IsNotNull(produto.Medida.Comprimento, nameof(produto.Medida.Comprimento), "Comprimento da Medida é inválida"));
        }
    }
}
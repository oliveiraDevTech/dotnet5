using Core.Domain;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.ProdutoAggregate.Rules.Clauses
{
    internal class ImpostoClause : Rule<Produto>
    {
        private const string Mensagem = "O Imposto de Pis é inválido";
        private const string Mensagem2 = "O Imposto de Cofins é inválido";
        private const string Mensagem3 = "O Imposto de Icms é inválido";
        private const string Mensagem4 = "O Imposto de Ipi é inválido";

        public override void Validar(Produto produto)
        {
            AddNotifications(new Contract<Notification>().IsNotNull(produto.Preco.Imposto.Pis, nameof(produto.Preco.Imposto.Pis), Mensagem)
                                 .IsNotNull(produto.Preco.Imposto.Cofins, nameof(produto.Preco.Imposto.Cofins), Mensagem2)
                                 .IsNotNull(produto.Preco.Imposto.Icms, nameof(produto.Preco.Imposto.Icms), Mensagem3)
                                 .IsNotNull(produto.Preco.Imposto.Ipi, nameof(produto.Preco.Imposto.Ipi), Mensagem4));
        }
    }
}
using Core.Domain.Entity;
using Domain.Cadastro.ProdutoAggregate.Enumerators;
using Domain.Cadastro.ProdutoAggregate.ValueObject;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Cadastro.ProdutoAggregate
{
    public class Produto : Entity<long>, IEntity
    {
        public Produto(string nome, string codigo, TipoProduto tipo, string descricao, Peso peso, Medida medida, Preco preco)
        {
            Nome = nome;
            Codigo = codigo;
            Tipo = tipo;
            Descricao = descricao;
            Peso = peso;
            Medida = medida;
            Preco = preco;

            Validate();
        }

        protected Produto()
        {
        }

        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public TipoProduto Tipo { get; private set; }
        public string Descricao { get; private set; }
        public Peso Peso { get; private set; }
        public Medida Medida { get; private set; }
        public Preco Preco { get; private set; }

        public Contract<Notification> Contract()
        {
            return new Contract<Notification>().IsNotNullOrEmpty(Nome, nameof(Nome), "Nome do produto não pode ser vazio ou nulo")
                                           //.HasMinLen(Nome, 2, nameof(Nome), "Nome do produto não pode ser menor que 2 caracteres")
                                           //.HasMaxLen(Nome, 150, nameof(Nome), "Nome do produto não pode ser maior que 150 caracteres")
                                           //.HasMaxLen(Codigo, 25, nameof(Codigo), "Codigo do produto não pode ser maior que 25 caracteres")
                                           .IsNotNull(Codigo, nameof(Codigo), "Código do produto é uma informação inválida")
                                           //.HasMaxLen(Descricao, 250, nameof(Descricao), "Descrição do produto não pode ser maior que 250 caracteres")
                                           .IsNotNull(Descricao, nameof(Descricao), "Descrição do produto é uma informação inválida")
                                           .IsNotNull(Peso, nameof(Peso), "Peso do produto é uma informação inválida")
                                           .IsNotNull(Medida, nameof(Medida), "Medida do produto é uma informação inválida");
        }

        public virtual void Validate()
        {
            AddNotifications(Contract());
            AddNotifications(Peso.Contract());
            AddNotifications(Medida.Contract());
            AddNotifications(Preco.Contract());
        }

        protected override void RuleValidate()
        {
            throw new System.NotImplementedException();
        }
    }
}
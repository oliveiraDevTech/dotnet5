using Core.Domain.Entity;
using Domain.Cadastro.ProdutoAggregate.Enumerators;
using Domain.Cadastro.ProdutoAggregate.Rules;
using Domain.Cadastro.ProdutoAggregate.ValueObject;
using System.Linq;

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

        public virtual void Validate()
        {
            {
                foreach (var regra in ProdutoRule.ObterRegras().Where(x => x.DeveExecutar(this)))
                {
                    regra.Validar(this);
                    AddNotifications(regra.Notifications);
                }
            }
        }
    }
}
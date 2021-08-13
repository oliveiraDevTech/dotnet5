using Domain.Cadastro.EmpresaAgreggate;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cadastro.EnderecoAggregate.Rules.Clauses
{
    public class RuaClause : EnderecoRule
    {
        private const string Mensagem = "Rua não pode ser nulo";
        private const string Mensagem2 = "Rua menor que 2";
        private const string Mensagem3 = "Rua maior que 150";
        public override void Validar(Endereco endereco)
        {
            AddNotifications(new Contract<Notification>().IsNotNullOrEmpty(endereco.Rua, nameof(endereco.Rua), Mensagem)
                                 .IsGreaterOrEqualsThan(endereco.Rua, 2, nameof(endereco.Rua), Mensagem2)
                                 .IsLowerOrEqualsThan(endereco.Rua, 150, nameof(endereco.Rua), Mensagem3));
        }
    }
}

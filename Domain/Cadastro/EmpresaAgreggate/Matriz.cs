using Domain.Cadastro.EmpresaAgreggate.Enumerators;
using Domain.Cadastro.EmpresaAgreggate.Rules;
using Domain.Cadastro.EmpresaAgreggate.ValueObjects;
using Domain.Cadastro.EnderecoAggregate;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Cadastro.EmpresaAgreggate
{
    public class Matriz : Empresa
    {
        protected Matriz()
        {
        }

        public IEnumerable<Filial> Filiais { get; protected set; }

        public Matriz(IEnumerable<Filial> filiais, Cnpj cnpj, string razaoSocial, string nome, Endereco endereco, TipoEmpresa tipo) : base(cnpj, razaoSocial, nome, endereco, tipo)
        {
            Filiais = filiais;
        }

        public override void Validate()
        {
            base.Validate();

            foreach (var regra in MatrizRule.ObterRegras().Where(x => x.DeveExecutar(this)))
            {
                regra.Validar(this);
                AddNotifications(regra.Notifications);
            }
        }
    }
}
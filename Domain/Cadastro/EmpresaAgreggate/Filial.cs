﻿using Domain.Cadastro.EmpresaAgreggate.Enumerators;
using Domain.Cadastro.EmpresaAgreggate.Rules;
using Domain.Cadastro.EmpresaAgreggate.ValueObjects;
using Domain.Cadastro.EnderecoAggregate;
using Flunt.Notifications;
using Flunt.Validations;
using System.Linq;

namespace Domain.Cadastro.EmpresaAgreggate
{
    public class Filial : Empresa
    {
        protected Filial()
        {

        }
        public Matriz Matriz { get; protected set; }

        public Filial(Matriz matriz, Cnpj cnpj, string razaoSocial, string nomeEmpresa, Endereco endereco) : base(cnpj, razaoSocial, nomeEmpresa, endereco, TipoEmpresa.Filial)
        {
            Matriz = matriz;
        }

        public override void Validate()
        {
            RuleValidate();

            AddNotifications(Endereco.Notifications);
            AddNotifications(Cnpj.Contract());
            AddNotifications(new Contract<Notification>());
        }

        protected override void RuleValidate()
        {
            base.RuleValidate();

            foreach (var regra in FilialRulesList.ObterRegras().Where(x => x.DeveExecutar(this)))
            {
                regra.Validar(this);
                AddNotifications(regra.Notifications);
            }
        }
    }
}
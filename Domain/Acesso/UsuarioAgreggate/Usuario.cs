using Core.Domain.Entity;
using Domain.Acesso.UsuarioAgreggate.ValueObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Acesso.UsuarioAgreggate
{
    public class Usuario : Entity<long>, IEntity
    {
        public Usuario(long id, string nome, Senha senha, string role)
        {
            Id = id;
            Nome = nome;
            Senha = senha;
            Role = role;
        }

        protected Usuario()
        {
        }

        public Senha Senha { get; private set; }
        public string Nome { get; private set; }
        public string Role { get; private set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
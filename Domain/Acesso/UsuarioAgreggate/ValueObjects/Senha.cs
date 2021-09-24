using Core.Domain;
using DomainDrivenDesign.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Acesso.UsuarioAgreggate.ValueObjects
{
    public class Senha : ValueObject<Senha>, IValueObject, IEquatable<string>
    {
        public byte[] Valor { get; private set; }

        public Senha(string senha)
        {
            var senhaArray = Encoding.UTF8.GetBytes(senha);
            Valor = Encriptar(senhaArray);
        }

        public Senha(byte[] senha)
        {
            Valor = Encriptar(senha);
        }

        protected Senha()
        {
        }

        private const string _publickey = "12345678";
        private const string _secretkey = "87654321";

        private MemoryStream _ms = new MemoryStream();
        private byte[] _secretkeyByte = Encoding.UTF8.GetBytes(_secretkey);
        private byte[] _publickeybyte = Encoding.UTF8.GetBytes(_publickey);

        private byte[] Encriptar(byte[] senha)
        {
            try
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    var encrypt = des.CreateEncryptor(_publickeybyte, _secretkeyByte);

                    Criptografia(senha, encrypt);
                    return _ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private string Decriptar(byte[] senha)
        {
            try
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    var decrypt = des.CreateDecryptor(_publickeybyte, _secretkeyByte);

                    Criptografia(senha, decrypt);
                    return Encoding.UTF8.GetString(_ms.ToArray());
                }
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }

        private void Criptografia(byte[] senhaArray, ICryptoTransform a)
        {
            var cs = new CryptoStream(_ms, a, CryptoStreamMode.Write);
            cs.Write(senhaArray, 0, senhaArray.Length);
            cs.FlushFinalBlock();
        }

        public bool Equals(string senha)
        {
            var valor = Decriptar(Valor);

            return senha.Equals(valor);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
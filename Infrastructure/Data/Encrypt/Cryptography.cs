using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Data.Encrypt
{
    public class Cryptography
    {
        private const string _publickey = "12345678";
        private const string _secretkey = "87654321";
        private MemoryStream _ms;
        private byte[] _secretkeyByte;
        private byte[] _publickeybyte;

        public Cryptography(string senha)
        {
            _ms = new MemoryStream();
            _secretkeyByte = Encoding.UTF8.GetBytes(_secretkey);
            _publickeybyte = Encoding.UTF8.GetBytes(_publickey);
        }

        public Cryptography(byte[] senha)
        {
            _ms = new MemoryStream();
            _secretkeyByte = Encoding.UTF8.GetBytes(_secretkey);
            _publickeybyte = Encoding.UTF8.GetBytes(_publickey);
        }

        public byte[] Encriptar(string senha)
        {
            try
            {
                var senhaArray = Encoding.UTF8.GetBytes(senha);

                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    var encrypt = des.CreateEncryptor(_publickeybyte, _secretkeyByte);

                    Cryptgraphy(senhaArray, encrypt);
                    return _ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public string Decriptar(byte[] senhaArray)
        {
            try
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    var decrypt = des.CreateDecryptor(_publickeybyte, _secretkeyByte);

                    Cryptgraphy(senhaArray, decrypt);
                    return Encoding.UTF8.GetString(_ms.ToArray());
                }
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }

        private void Cryptgraphy(byte[] senhaArray, ICryptoTransform a)
        {
            var cs = new CryptoStream(_ms, a, CryptoStreamMode.Write);
            cs.Write(senhaArray, 0, senhaArray.Length);
            cs.FlushFinalBlock();
        }
    }
}
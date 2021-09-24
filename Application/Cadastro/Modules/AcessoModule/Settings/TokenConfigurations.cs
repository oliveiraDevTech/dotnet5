using System;
using System.Text;

namespace Application.Cadastro.Modules.AcessoModule.Settings
{
    public static class TokenConfigurations
    {
        public static string SecretKey = "fG43RRfs32x770SZb0BjROn9fiZiDmRcaz62j9js2OybUhjk";
        public static DateTime DateExpire = DateTime.UtcNow.AddHours(2);
        public static byte[] Enconding => Encoding.ASCII.GetBytes(TokenConfigurations.SecretKey);
    }
}
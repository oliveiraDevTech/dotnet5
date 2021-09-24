namespace Domain.Acesso.UsuarioAgreggate
{
    internal class TokenConfiguration
    {
        public string Audience { get; private set; }
        public string Issuer { get; private set; }
        public int Seconds { get; private set; }
    }
}
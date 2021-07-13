using System;

namespace Application.Cadastro.Modules.EmpresaModule.Exceptions
{
    internal class FalhaAoInserirException : Exception
    {
        private const string message = "Erro! Ocorreu problema ao inserir.";

        public FalhaAoInserirException() : base()
        {
        }

        public FalhaAoInserirException(string message) : base(message)
        {
        }

        public FalhaAoInserirException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
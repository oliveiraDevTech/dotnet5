using System.Collections.Generic;

namespace Core.Application.Shared
{
    public class MessageResult : IMessageResult
    {
        public IReadOnlyCollection<string> Errors => _errors;
        public IReadOnlyCollection<string> Asserts => _asserts;
        public bool IsValid => _IsValid;

        private bool _IsValid;
        private readonly List<string> _errors;
        private readonly List<string> _asserts;

        public MessageResult()
        {
            _errors = new List<string>();
            _asserts = new List<string>();
        }

        public IMessageResult Fail(string error)
        {
            _IsValid = false;
            _errors.Add(error);
            return this;
        }

        public IMessageResult Fail(IEnumerable<string> error)
        {
            _IsValid = false;
            _errors.AddRange(error);
            return this;
        }

        public IMessageResult Success(string success)
        {
            _IsValid = true;
            _asserts.Add(success);
            return this;
        }

        public IMessageResult Success(IEnumerable<string> success)
        {
            _IsValid = true;
            _asserts.AddRange(success);
            return this;
        }
    }
}
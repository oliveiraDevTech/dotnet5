using System.Collections.Generic;

namespace Core.Application.Shared
{
    public class CommandResult<T> : ICommandResult<T>
    {
        private T _entity;
        private bool _IsValid;
        private readonly List<string> _errors;

        public CommandResult(T entity)
        {
            _entity = entity;
            _IsValid = true;
            _errors = new List<string>();
        }

        public CommandResult()
        {
        }

        public IReadOnlyCollection<string> Errors => _errors;

        public bool IsValid => _IsValid;

        public ICommandResult<T> Fail(T entity, IEnumerable<string> errors)
        {
            _entity = entity;
            _errors.AddRange(errors);
            _IsValid = false;

            return this;
        }

        public ICommandResult<T> Fail(T entity, string error)
        {
            _entity = entity;
            _errors.Add(error);
            _IsValid = false;

            return this;
        }

        public ICommandResult<T> Success(T entity)
        {
            _entity = entity;

            return this;
        }

        public T Value() => _entity;
    }
}
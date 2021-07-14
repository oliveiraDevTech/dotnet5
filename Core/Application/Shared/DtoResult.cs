using System.Collections.Generic;

namespace Core.Application.Shared
{
    public class DtoResult<Dto> : IDtoResult<Dto>
    {
        public IReadOnlyCollection<Dto> Values => _dtos;
        public IReadOnlyCollection<string> Errors => _errors;
        public bool IsValid => _IsValid;
        private readonly List<Dto> _dtos;
        private readonly List<string> _errors;
        private bool _IsValid;

        public DtoResult()
        {
            _errors = new List<string>();
            _dtos = new List<Dto>();
        }

        public IDtoResult<Dto> Fail(Dto entity, IEnumerable<string> errors)
        {
            _IsValid = false;
            _errors.AddRange(errors);
            return this;
        }

        public IDtoResult<Dto> Fail(Dto entity, string error)
        {
            _IsValid = false;
            _errors.Add(error);
            return this;
        }

        public IDtoResult<Dto> Success(IEnumerable<Dto> entities)
        {
            _IsValid = true;
            _dtos.AddRange(entities);
            return this;
        }

        public IDtoResult<Dto> Success(Dto value)
        {
            _IsValid = true;
            _dtos.Add(value);
            return this;
        }
    }
}
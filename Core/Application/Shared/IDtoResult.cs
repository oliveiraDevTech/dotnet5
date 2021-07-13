using System.Collections.Generic;

namespace Core.Application.Shared
{
    public interface IDtoResult<TDto> : IResult
    {
        IReadOnlyCollection<TDto> Values { get; }

        IDtoResult<TDto> Success(IEnumerable<TDto> entities);

        IDtoResult<TDto> Success(TDto entity);

        IDtoResult<TDto> Fail(TDto entity, IEnumerable<string> errors);

        IDtoResult<TDto> Fail(TDto entity, string error);
    }
}
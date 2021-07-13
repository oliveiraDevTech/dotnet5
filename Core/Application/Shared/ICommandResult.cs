using System.Collections.Generic;

namespace Core.Application.Shared
{
    public interface ICommandResult<T> : IResult
    {
        T Value();

        ICommandResult<T> Fail(T entity, IEnumerable<string> errors);

        ICommandResult<T> Fail(T entity, string error);

        ICommandResult<T> Success(T entity);
    }
}
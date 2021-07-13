using System.Collections.Generic;

namespace Core.Application.Shared
{
    public interface IMessageResult : IResult
    {
        IReadOnlyCollection<string> Asserts { get; }

        IMessageResult Success(string success);

        IMessageResult Fail(string error);

        IMessageResult Success(IEnumerable<string> success);

        IMessageResult Fail(IEnumerable<string> error);
    }
}
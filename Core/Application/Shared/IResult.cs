using System.Collections.Generic;

namespace Core.Application.Shared
{
    public interface IResult
    {
        IReadOnlyCollection<string> Errors { get; }
        bool IsValid { get; }
    }
}
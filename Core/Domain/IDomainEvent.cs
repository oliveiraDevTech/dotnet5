using System;

namespace Core.Domain
{
    public interface IDomainEvent
    {
        DateTime DateOcurred { get; }
    }
}
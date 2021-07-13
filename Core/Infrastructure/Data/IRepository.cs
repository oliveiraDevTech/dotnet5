using Core.Domain.Entity;

namespace Core.Infrastructure.Data
{
    public interface IRepository<TEntity, TId> where TEntity : Entity<TId>
    {
    }
}
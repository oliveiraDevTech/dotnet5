using Core.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Infrastructure.Data
{
    public interface IGenericRepository<TEntity, TId> where TEntity : Entity<TId>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Get(TId id);

        //IEnumerable<TEntity> Filter<KProperty>(int pageIndex, int pageCount, Expression<Func<TEntity, KProperty>> orderByExpression);

        Task<int> Insert(TEntity entity);

        Task<int> Insert(IEnumerable<TEntity> entities);

        Task<int> Update(TEntity entity);

        Task<int> Update(IEnumerable<TEntity> entities);

        Task<int> Delete(TEntity entity);

        Task<int> Delete(IEnumerable<TEntity> entities);

        Task<int> Delete(TId id);
    }
}
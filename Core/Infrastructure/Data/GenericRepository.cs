using Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Infrastructure.Data
{
    public abstract class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : Entity<TId>
    {
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly DbContext _dbContext;

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Get(TId id)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        //public IEnumerable<TEntity> Filter<KProperty>(int pageIndex, int pageCount, Expression<Func<TEntity, KProperty>> orderByExpression)
        //{
        //    return _dbContext.Set<TEntity>().Take(pageCount).Skip(pageIndex).OrderBy(orderByExpression);
        //}

        public async Task<int> Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return await Commit();
        }

        public async Task<int> Insert(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
            return await Commit();
        }

        public async Task<int> Update(TEntity entity)
        {
            var entityToModify = _dbContext.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(entity.Id));
            _dbContext.Set<TEntity>().Update(entity);
            return await Commit();
        }

        public async Task<int> Update(IEnumerable<TEntity> entities)
        {
            var entityToModify = _dbContext.Set<TEntity>().Where(x => entities.Select(x => x.Id).Contains(x.Id)).AsEnumerable();
            _dbContext.Set<TEntity>().UpdateRange(entities);
            return await Commit();
        }

        public async Task<int> Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return await Commit();
        }

        public async Task<int> Delete(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
            return await Commit();
        }

        public async Task<int> Delete(TId id)
        {
            var entityToRemove = _dbContext.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(id));
            _dbContext.Set<TEntity>().Remove(entityToRemove);
            return await Commit();
        }

        private Task<int> Commit() => _dbContext.SaveChangesAsync();
    }
}
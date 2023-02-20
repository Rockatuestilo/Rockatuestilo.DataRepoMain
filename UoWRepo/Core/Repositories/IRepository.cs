using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Repositories
{
    public interface IRepository<BaseTEntity> where BaseTEntity :  IBaseTEntity
    {
        BaseTEntity Get(int id);
        IEnumerable<BaseTEntity> GetAll();
        IEnumerable<BaseTEntity> Find(Expression<Func<BaseTEntity, bool>> predicate);
        
        IQueryable<BaseTEntity> GetAllQueryble();
        IQueryable<BaseTEntity> FindQueryble(Expression<Func<BaseTEntity, bool>> predicate);

        BaseTEntity SingleOrDefault(Expression<Func<BaseTEntity, bool>> predicate);
        BaseTEntity LastUpdatedRow();

        void Add(BaseTEntity entity);
        int AddWithIdentity(BaseTEntity entity);
        void AddRange(IEnumerable<BaseTEntity> entities);

        void Update(BaseTEntity entity);

        void AddOrUpdate(Expression<Func<BaseTEntity, bool>> predicate);

        void Remove(BaseTEntity entity);
        void RemoveRange(IEnumerable<BaseTEntity> entities);        
    }

    public interface IMemoryRepository<TEntity>:IRepository<TEntity> where TEntity : IBaseTEntity
    {
        DateTime? GetDateTimeOfCachingOfCurrentEntity();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.EFDomain;

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

        void Remove(BaseTEntity entity);
        void RemoveRange(IEnumerable<BaseTEntity> entities);        
    }

    public interface IMemoryRepository<TEntity>:IRepository<TEntity> where TEntity : IBaseTEntity
    {
        DateTime? GetDateTimeOfCachingOfCurrentEntity();
    }
    
    
    public interface IRepositoryAsQueryable<BaseTEntity> where BaseTEntity :  IBaseTEntity
    {
        Task<TEntity?> Get(int id);
        IQueryable<BaseTEntity> GetAllAsQueryble();
        IEnumerable<BaseTEntity> SingleOrDefaultAsync(Expression<Func<BaseTEntity, bool>> predicate);
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Repositories;

public interface IRepository<BaseTEntity> where BaseTEntity : IBaseTEntity
{
    // Synchronous Methods
    BaseTEntity Get(int id);
    IEnumerable<BaseTEntity> GetAll();
    IEnumerable<BaseTEntity> GetAllWithQueue();
    IEnumerable<BaseTEntity> Find(Expression<Func<BaseTEntity, bool>> predicate);
    BaseTEntity SingleOrDefault(Expression<Func<BaseTEntity, bool>> predicate);
    BaseTEntity LastUpdatedRow();
    void Add(BaseTEntity entity);
    int AddWithIdentity(BaseTEntity entity);

    [Obsolete("Use AddRangeAsync instead")]
    void AddRange(IEnumerable<BaseTEntity> entities);
        
    [Obsolete("Use UpdateAsync instead")]
    void Update(BaseTEntity entity);

    [Obsolete("Use RemoveAsync instead")]
    void Remove(BaseTEntity entity);
    
    [Obsolete("Use RemoveRangeAsync instead")]
    void RemoveRange(IEnumerable<BaseTEntity> entities);

    // Asynchronous Methods
    Task<List<BaseTEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<List<BaseTEntity>> FindAsync(Expression<Func<BaseTEntity, bool>> predicate,
        CancellationToken cancellationToken = default);
    
    Task AddRangeAsync(IEnumerable<BaseTEntity> entities, CancellationToken cancellationToken = default);
    Task<BaseTEntity> UpdateAndSaveAsync(BaseTEntity entity, CancellationToken cancellationToken = default);
    
    Task RemoveAndSaveAsync(BaseTEntity entity, CancellationToken cancellationToken = default);
    
    Task RemoveRangeAsync(IEnumerable<BaseTEntity> entities , CancellationToken cancellationToken = default);

    // Queryable Methods
    IQueryable<BaseTEntity> GetAllQueryble();
    IQueryable<BaseTEntity> FindQueryble(Expression<Func<BaseTEntity, bool>> predicate);
}


public interface IMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : IBaseTEntity
{
    DateTime? GetDateTimeOfCachingOfCurrentEntity();
}
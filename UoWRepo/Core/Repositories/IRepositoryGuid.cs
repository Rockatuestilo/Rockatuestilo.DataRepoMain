using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Repositories;

public interface IRepositoryGuid<BaseGuidTEntity> where BaseGuidTEntity : IBaseGuidTEntity
{
    // Synchronous Methods
    BaseGuidTEntity Get(Guid Guid);
    IEnumerable<BaseGuidTEntity> GetAll();
    IEnumerable<BaseGuidTEntity> GetAllWithQueue();
    IEnumerable<BaseGuidTEntity> Find(Expression<Func<BaseGuidTEntity, bool>> predicate);
    BaseGuidTEntity SingleOrDefault(Expression<Func<BaseGuidTEntity, bool>> predicate);
    BaseGuidTEntity LastUpdatedRow();
    void Add(BaseGuidTEntity entity);
    Guid AddWithIdentity(BaseGuidTEntity entity);

    [Obsolete("Use AddRangeAsync instead")]
    void AddRange(IEnumerable<BaseGuidTEntity> entities);
        
    [Obsolete("Use UpdateAsync instead")]
    void Update(BaseGuidTEntity entity);

    [Obsolete("Use RemoveAsync instead")]
    void Remove(BaseGuidTEntity entity);
    
    [Obsolete("Use RemoveRangeAsync instead")]
    void RemoveRange(IEnumerable<BaseGuidTEntity> entities);

    // Asynchronous Methods
    Task<List<BaseGuidTEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<List<BaseGuidTEntity>> FindAsync(Expression<Func<BaseGuidTEntity, bool>> predicate,
        CancellationToken cancellationToken = default);
    
    Task AddRangeAsync(IEnumerable<BaseGuidTEntity> entities, CancellationToken cancellationToken = default);
    Task<BaseGuidTEntity> UpdateAndSaveAsync(BaseGuidTEntity entity, CancellationToken cancellationToken = default);
    
    Task RemoveAndSaveAsync(BaseGuidTEntity entity, CancellationToken cancellationToken = default);
    
    Task RemoveRangeAsync(IEnumerable<BaseGuidTEntity> entities , CancellationToken cancellationToken = default);

    // Queryable Methods
    IQueryable<BaseGuidTEntity> GetAllQueryble();
    IQueryable<BaseGuidTEntity> FindQueryble(Expression<Func<BaseGuidTEntity, bool>> predicate);
}
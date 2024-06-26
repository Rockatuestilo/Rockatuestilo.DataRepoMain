using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.EFDomain;
using UoWRepo.Core.Repositories;
using UoWRepo.Persistence.Repositories;

namespace UoWRepo.Persistence.RepositoriesEf;

public class RepositoryEfGuid<TEntityGuid> : IRepositoryGuid<TEntityGuid> where TEntityGuid : BaseGuidTEntity
{
    protected readonly EFContext context;
    private readonly DbSet<TEntityGuid> entities;

    public RepositoryEfGuid(EFContext context)
    {
        this.context = context;
        entities = context.Set<TEntityGuid>();
    }

    public virtual void Add(TEntityGuid entity)
    {
        AddWithIdentity(entity);
    }

    public virtual Guid AddWithIdentity(TEntityGuid entity)
    {
        var value = entities.Add(entity);
        var fg =context.SaveChanges();
        return value.Entity.Guid;
    }

    public virtual void AddRange(IEnumerable<TEntityGuid> entitiesList)
    {
        entities.AddRange(entitiesList);
    }
    public static readonly ContextQueue contextQueue = new ContextQueue();
    public async virtual Task<IEnumerable<TEntityGuid>> GetAllAsync()
    {
        var list = await EntityFrameworkQueryableExtensions.ToListAsync(entities);
        
        
        return list;
    }

    public async Task<IEnumerable<TEntityGuid>> FindAsync(Expression<Func<TEntityGuid, bool>> predicate)
    {
        return await EntityFrameworkQueryableExtensions.ToListAsync(entities.Where(predicate));
    }

    public async Task AddRangeAsync(IEnumerable<TEntityGuid> incomingEntities)
    {
        await entities.AddRangeAsync(incomingEntities);
    }
    
    public async Task<TEntityGuid> UpdateAndSaveAsync(TEntityGuid entity)
    {
        return await Task.Run(()=> entities.Update(entity).Entity);
    }

    public async Task RemoveAndSaveAsync(TEntityGuid entity)
    {
        await Task.Run(()=> entities.Remove(entity));
    }

    public async Task RemoveRangeAsync(IEnumerable<TEntityGuid> entities)
    {
        await Task.Run(()=> this.entities.RemoveRange(entities));
            
    }



    public IEnumerable<BaseTEntity> Find(Expression<Func<BaseTEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public BaseTEntity SingleOrDefault(Expression<Func<BaseTEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }
    

    public void Add(BaseTEntity entity)
    {
        throw new NotImplementedException();
    }

    public int AddWithIdentity(BaseTEntity entity)
    {
        throw new NotImplementedException();
    }

    public void AddRange(IEnumerable<BaseTEntity> entities)
    {
        throw new NotImplementedException();
    }

    public void Update(BaseTEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Remove(BaseTEntity entity)
    {
        throw new NotImplementedException();
    }

    public void RemoveRange(IEnumerable<BaseTEntity> entities)
    {
        throw new NotImplementedException();
    }



    public Task<List<BaseTEntity>> FindAsync(Expression<Func<BaseTEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(IEnumerable<BaseTEntity> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<BaseTEntity> UpdateAndSaveAsync(BaseTEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAndSaveAsync(BaseTEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RemoveRangeAsync(IEnumerable<BaseTEntity> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }



    public IQueryable<BaseTEntity> FindQueryble(Expression<Func<BaseTEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IQueryable<BaseGuidTEntity> FindQueryble(Expression<Func<BaseGuidTEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public virtual IEnumerable<TEntityGuid> GetAllWithQueue()
    {
        
        var val = contextQueue.Queue(() => entities.ToList()).Result;
        
        return val;
    }

    public Task RemoveRangeAsync(IEnumerable<TEntityGuid> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntityGuid> GetAllQueryble()
    {
        return entities.AsQueryable();
    }

    public virtual IEnumerable<TEntityGuid> Find(Expression<Func<TEntityGuid, bool>> predicate)
    {
        return entities.Where(predicate).ToList();
    }

   

    public virtual IQueryable<TEntityGuid> FindQueryble(Expression<Func<TEntityGuid, bool>> predicate)
    {
        return entities.Where(predicate).AsQueryable();
    }

    public virtual TEntityGuid Get(Guid guid)
    {
        return entities.SingleOrDefault(x => x.Guid== guid);
    }



    public virtual IEnumerable<TEntityGuid> GetAll()
    {
        return entities.ToList();
    }

    public virtual void Remove(TEntityGuid entity)
    {
        entities.Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<TEntityGuid> entitiesList)
    {
        entities.RemoveRange(entitiesList);
        
        
        
        //throw new NotImplementedException();
        //context.HashtagsNews.Where(x => entities.Select(i => i.Id).Contains(x.Id)).Delete();
        //entities.RemoveRange(entitiesList);
    }

    public async Task<List<TEntityGuid>> GetAllAsync(CancellationToken cancellationTokens = default)
    {
        return await entities.ToListAsync(cancellationTokens);
    }

    public async Task<List<TEntityGuid>> FindAsync(Expression<Func<TEntityGuid, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await entities.Where(predicate).ToListAsync(cancellationToken);
    
    }

    public async Task AddRangeAsync(IEnumerable<TEntityGuid> entities, CancellationToken cancellationToken = default)
    {
        await this.entities.AddRangeAsync(entities, cancellationToken);
        //await context.AddRangeAsync(entities, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntityGuid> UpdateAndSaveAsync(TEntityGuid entity, CancellationToken cancellationToken = default)
    {
        entities.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task RemoveAndSaveAsync(TEntityGuid entity, CancellationToken cancellationToken = default)
    {
        entities.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public virtual TEntityGuid SingleOrDefault(Expression<Func<TEntityGuid, bool>> predicate)
    {
        return entities.SingleOrDefault(predicate);
    }

    public virtual void Update(TEntityGuid entity)
    {
        //FIXME:
        entities.Update(entity);

        //MAYBE: context.SaveChanges();
    }

    public virtual TEntityGuid LastUpdatedRow()
    {
        return entities.OrderByDescending(x => x.UpdatedDate).FirstOrDefault();
    }
}
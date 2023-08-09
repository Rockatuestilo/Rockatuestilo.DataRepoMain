using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using LinqToDB;
using Microsoft.EntityFrameworkCore;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Repositories;
using UoWRepo.Persistence.Repositories;

namespace UoWRepo.Persistence.RepositoriesEf;

public class RepositoryEf<TEntity> : IRepository<TEntity> where TEntity : BaseTEntity
{
    protected readonly EFContext context;
    private readonly DbSet<TEntity> entities;

    public RepositoryEf(EFContext context)
    {
        this.context = context;
        entities = context.Set<TEntity>();
    }

    public virtual void Add(TEntity entity)
    {
        AddWithIdentity(entity);
    }

    public virtual int AddWithIdentity(TEntity entity)
    {
        var value = entities.Add(entity);
        context.SaveChanges();
        return value.Entity.Id;
    }

    public virtual void AddRange(IEnumerable<TEntity> entitiesList)
    {
        entities.AddRange(entitiesList);
    }
    public static readonly ContextQueue contextQueue = new ContextQueue();
    public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var list = await EntityFrameworkQueryableExtensions.ToListAsync(entities);
        
        
        return list;
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await EntityFrameworkQueryableExtensions.ToListAsync(entities.Where(predicate));
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> incomingEntities)
    {
        await entities.AddRangeAsync(incomingEntities);
    }
    
    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        return await Task.Run(()=> entities.Update(entity).Entity);
    }

    public async Task RemoveAsync(TEntity entity)
    {
        await Task.Run(()=> entities.Remove(entity));
    }

    public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        await Task.Run(()=> this.entities.RemoveRange(entities));
            
    }

    public virtual IEnumerable<TEntity> GetAllWithQueue()
    {
        
        var val = contextQueue.Queue(() => entities.ToList()).Result;
        //return context.GetTable<TEntity>().AsParallel();
        return val;
    }

    public Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> GetAllQueryble()
    {
        return entities.AsQueryable();
    }

    public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return entities.Where(predicate).ToList();
    }

   

    public virtual IQueryable<TEntity> FindQueryble(Expression<Func<TEntity, bool>> predicate)
    {
        return entities.Where(predicate).AsQueryable();
    }

    public virtual TEntity Get(int id)
    {
        return entities.SingleOrDefault(x => x.Id == id);
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return entities.ToList();
    }

    public virtual void Remove(TEntity entity)
    {
        entities.Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<TEntity> entitiesList)
    {
        //throw new NotImplementedException();
        //context.HashtagsNews.Where(x => entities.Select(i => i.Id).Contains(x.Id)).Delete();
        //entities.RemoveRange(entitiesList);
    }

    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return entities.SingleOrDefault(predicate);
    }

    public virtual void Update(TEntity entity)
    {
        //FIXME:
        entities.Update(entity);

        //MAYBE: context.SaveChanges();
    }

    public virtual TEntity LastUpdatedRow()
    {
        return entities.OrderByDescending(x => x.UpdatedDate).FirstOrDefault();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using LinqToDB;
using LinqToDB.Data;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.Repositories;
/*
public class RepositoryWithLazy<TEntity> : IRepository<TEntity> where TEntity : Core.Domain.Linq2DbEntity, IBaseTEntity
{
    private static readonly Lazy<RepositoryWithLazy<TEntity>> instance = new Lazy<RepositoryWithLazy<TEntity>>(() => new RepositoryWithLazy<TEntity>(Linq2DbContext context));

    private readonly Linq2DbContext context;
    private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1);

    private RepositoryWithLazy(Linq2DbContext context)
    {
        this.context = context;
    }

    private RepositoryWithLazy(string connectionString)
    {
        context = new Linq2DbContext(connectionString);
    }

    private RepositoryWithLazy(string connectionString, bool onDemand = true)
    {
        context = new Linq2DbContext(connectionString);
    }

    public static RepositoryWithLazy<TEntity> Instance => instance.Value;

    public void Add(TEntity entity)
    {
        context.BeginTransaction();
        context.Insert(entity);
    }

    public int AddWithIdentity(TEntity entity)
    {
        context.BeginTransaction();
        return context.InsertWithInt32Identity(entity);
    }

    public void AddOrUpdate(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = context.GetTable<TEntity>().SingleOrDefault(predicate);

        if (entity == null)
        {
            entity = Activator.CreateInstance<TEntity>();
            predicate.Compile().Invoke(entity);
            context.Insert(entity);
        }
        else
        {
            predicate.Compile().Invoke(entity);
            context.Update(entity);
        }
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        context.BulkCopy(entities);
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return context.GetTable<TEntity>().Where(predicate).ToList();
    }

    public IQueryable<TEntity> GetAllQueryble()
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> FindQueryble(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> FindQueryable(Expression<Func<TEntity, bool>> predicate)
    {
        return context.GetTable<TEntity>().Where(predicate).AsQueryable();
    }

    public TEntity Get(int id)
    {
        return context.GetTable<TEntity>().SingleOrDefault(x => x.Id == id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return context.GetTable<TEntity>().ToList();
    }

    public IQueryable<TEntity> GetAllQueryable()
    {
        return context.GetTable<TEntity>().AsQueryable();
    }

    public void Remove(TEntity entity)
    {
        context.Delete(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        context.HashtagsNews.Where(x => entities.Select(i => i.Id).Contains(x.Id)).Delete();
    }

    public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return context.GetTable<TEntity>().SingleOrDefault(predicate);
    }

    public void Update(TEntity entity)
    {
        context.BeginTransaction();
        context.Update(entity);
    }

    public TEntity LastUpdatedRow()
    {
        return context.GetTable<TEntity>().OrderByDescending(x => x.UpdatedDate).FirstOrDefault();
    }
}

*/
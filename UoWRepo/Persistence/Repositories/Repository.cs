using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Data;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Configuration.ParallelRunning;
using UoWRepo.Core.Domain;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.Repositories;


using System;
using System.Collections.Generic;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Linq2DbEntity, IBaseTEntity
{
    protected Linq2DbContext _context;
    private string _connectionString;

    public Repository(Linq2DbContext context)
    {
        _context = context;
    }
    
    public Repository()
    {
        //_context = new Linq2DbContext("MySql.Data.MySqlClient", connectionString);
    }
    
    public Repository(string  connectionString)
    {
        _context = new Linq2DbContext("MySql.Data.MySqlClient", connectionString);
    }
   
    public Repository(string connectionString, bool onDemand = true)
    {
        _context = new Linq2DbContext("MySql.Data.MySqlClient", connectionString);
    }

    [Obsolete("Use AddAsync instead")]
    public virtual void Add(TEntity entity)
    {
        _context.Insert(entity);
    }

    public virtual int AddWithIdentity(TEntity entity)
    {
        return _context.InsertWithInt32Identity(entity);
    }

    public virtual void AddRange(IEnumerable<TEntity> entities)
    {
        _context.BulkCopy(entities);
    }

    public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.GetTable<TEntity>().Where(predicate).ToList();
    }


    public virtual IQueryable<TEntity> FindQueryble(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.GetTable<TEntity>().Where(predicate).AsQueryable();
    }

    public virtual TEntity Get(int id)
    {
        return _context.GetTable<TEntity>().SingleOrDefault(x => x.Id == id);
    }

    [SemaphoreActions(1)]
    public virtual IEnumerable<TEntity> GetAll()
    {
        return _context.GetTable<TEntity>().ToList();
    }

    [SemaphoreActions(1)]
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Task.Run(() => _context.GetTable<TEntity>().ToList());
    }

    [SemaphoreActions(1)]
    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Task.Run(() =>_context.GetTable<TEntity>().Where(predicate).ToList());
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await Task.Run(() => _context.BulkCopy(entities));
    }
    
    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _context.BulkCopyAsync(entities);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        await Task.Run( () => _context.Update(entity));
        return entity;
    }

    public async Task RemoveAsync(TEntity entity)
    {
        await Task.Run(() => _context.Delete(entity));
    }

    public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        await Task.Run(() => _context.HashtagsNews.Where(x => entities.Select(i => i.Id).Contains(x.Id)).Delete());
    }

    public static readonly ContextQueue contextQueue = new ContextQueue();
    public virtual IEnumerable<TEntity> GetAllWithQueue()
    {
        var val = contextQueue.Queue(() => _context.GetTable<TEntity>().ToList()).Result;
        
        return val;
    }

    public Task RemoveAndSaveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
         return _context.DeleteAsync(entity);
    }

    public Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return _context.DeleteAsync(entities);
    }

    public virtual IQueryable<TEntity> GetAllQueryble()
    {
        return _context.GetTable<TEntity>().AsQueryable();
    }

    public virtual void Remove(TEntity entity)
    {
        _context.Delete(entity);
    }

    public virtual void RemoveRange(IEnumerable<TEntity> entities)
    {
        _context.GetTable<TEntity>().Where(x => entities.Select(i => i.Id).Contains(x.Id)).Delete();
    }

    public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = _context.GetTable<TEntity>().ToListAsync(cancellationToken);

        return result;
    }

    public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var result = _context.GetTable<TEntity>().Where(predicate).ToListAsync(cancellationToken);

        return result;
    }

   

    public async Task<TEntity> UpdateAndSaveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Task.Run( () => _context.Update(entity));
        return entity;
    }
    
    public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.GetTable<TEntity>().SingleOrDefault(predicate);
    }

    public virtual void Update(TEntity entity)
    {
        _context.Update(entity);
    }

    public virtual TEntity LastUpdatedRow()
    {
        return _context.GetTable<TEntity>().OrderByDescending(x => x.UpdatedDate).FirstOrDefault();
    }

    public virtual void AddOrUpdate(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = _context.GetTable<TEntity>().SingleOrDefault(predicate);

        if (entity == null)
        {
            entity = Activator.CreateInstance<TEntity>();
            predicate.Compile().Invoke(entity);
            _context.Insert(entity);
        }
        else
        {
            predicate.Compile().Invoke(entity);
            _context.Update(entity);
        }
    }
}
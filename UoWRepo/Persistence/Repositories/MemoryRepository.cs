﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using LinqToDB;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Domain;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.Repositories;

public class MemoryRepository<TEntity> : Repository<TEntity>, IMemoryRepository<TEntity>
    where TEntity : Linq2DbEntity, IBaseTEntity
{
    protected static IDictionary<string, IEnumerable<TEntity>>
        TestList = new Dictionary<string, IEnumerable<TEntity>>();

    protected static IDictionary<string, DateTime> testListDateTimes = new Dictionary<string, DateTime>();

    protected new readonly Linq2DbContext context;
    //protected readonly Repository<TEntity> repository;

    private readonly IRepository<TEntity> repository;
    private IDictionary<string, IEnumerable<TEntity>> openWith = new Dictionary<string, IEnumerable<TEntity>>();


    public MemoryRepository(Linq2DbContext context, Repository<TEntity> repository) : base(context)
    {
        //this.MemoryContext = MemoryContext;
        this.repository = repository;
        this.context = context;
    }

    public override void Add(TEntity entity)
    {
        ResetMemory(entity);
        base.Add(entity);
    }

    public override int AddWithIdentity(TEntity entity)
    {
        ResetMemory(entity);
        return base.AddWithIdentity(entity);
    }

    public override void AddRange(IEnumerable<TEntity> entities)
    {
        ResetMemory(entities);
        base.AddRange(entities);
    }


    public override TEntity Get(int id)
    {
        var nameOfEntity = typeof(TEntity).Name;
        var result = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;

        if (result == null)
        {
            var entity = base.Get(id);
            return entity;
        }

        var whatIWasLooking = result.SingleOrDefault(x => x.Id == id);

        if (whatIWasLooking == null)
        {
            var entity = base.Get(id);
            return entity;
        }


        return result.SingleOrDefault(x => x.Id == id);
    }

    public override IEnumerable<TEntity> GetAll()
    {
        var nameOfEntity = typeof(TEntity).Name;
        var result = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;

        if (result == null)
        {
            AddEntityToCacheAndGetList<TEntity>();
            result = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;
        }

        return result;
    }
    
    public bool waitForIt = false;
    public override  IEnumerable<TEntity> GetAllWithQueue()
    {
        
        var methodQueue = new MethodQueue();
        
        var nameOfEntity = typeof(TEntity).Name;

        var result = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;
        //var result = entityQueue.Queue(() => TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value).Result;
        if (result == null)
        {
            var timeSpan = new TimeSpan(0, 0, 0, 0, 500);
            result =methodQueue.QueueCallsSync(() => AddEntityToCacheAndGetList<TEntity>(), timeSpan);
        }

        return result;
    }

    public override IQueryable<TEntity> FindQueryble(Expression<Func<TEntity, bool>> predicate)
    {
        var nameOfEntity = typeof(TEntity).Name;
        var result = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;

        if (result == null) AddEntityToCacheAndGetList<TEntity>();
        var result2 = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;

        var result3 = result2.Where(predicate.Compile()).AsQueryable();
        return result3;
    }

    public override IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        var nameOfEntity = typeof(TEntity).Name;
        var result = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;

        if (result == null) AddEntityToCacheAndGetList<TEntity>();
        var result2 = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;

        var result3 = result2.Where(predicate.Compile()).AsQueryable();
        return result3;
    }

    public override void Remove(TEntity entity)
    {
        ResetMemory(entity);
        base.Remove(entity);
    }

    public override void RemoveRange(IEnumerable<TEntity> entities)
    {
        ResetMemory(entities);
        base.RemoveRange(entities);
    }

    public override void Update(TEntity entity)
    {
        ResetMemory(entity);
        try
        {
            base.Update(entity);
        }
        catch (Exception e)
        {
            var mm = e.Message;
            Console.WriteLine(mm);
        }
    }

    public DateTime? GetDateTimeOfCachingOfCurrentEntity()
    {
        var nameOfEntity = typeof(TEntity).Name;
        return testListDateTimes.FirstOrDefault(x => x.Key == nameOfEntity).Value;
    }

    protected IEnumerable<TEntity> AddEntityToCacheAndGetList<T>()
    {
        ResetMemory<TEntity>();
        var nameOfEntity = typeof(T).Name;
        var liste = base.GetAll();

        try
        {
            TestList.Add(nameOfEntity, liste.ToList());
            testListDateTimes.Add(nameOfEntity, DateTime.Now);
        }
        catch (Exception)
        {
        }

        return liste;
    }
    
    protected async Task<IEnumerable<TEntity>> AddEntityToCacheAndGetListAsync<T>()
    {
        ResetMemory<TEntity>();
        var nameOfEntity = typeof(T).Name;
        var liste = await this.GetAllAsync();

        try
        {
            TestList.Add(nameOfEntity, liste.ToList());
            testListDateTimes.Add(nameOfEntity, DateTime.Now);
        }
        catch (Exception)
        {
        }

        return liste;
    }
    
    protected IEnumerable<TEntity> AddEntityToCacheAndGetListQueue<T>()
    {
        ResetMemory<TEntity>();
        var nameOfEntity = typeof(T).Name;
        var liste = base.GetAllWithQueue();

        try
        {
            TestList.Add(nameOfEntity, liste.ToList());
            testListDateTimes.Add(nameOfEntity, DateTime.Now);
        }
        catch (Exception)
        {
        }

        return liste;
    }

    protected void ResetMemory<T>()
    {
        var nameOfEntity = typeof(T).Name;
        var result = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;

        if (result != null) TestList.Remove(nameOfEntity);

        var result2 = testListDateTimes.FirstOrDefault(x => x.Key == nameOfEntity).Value;

        if (result2 != null) testListDateTimes.Remove(nameOfEntity);
    }


    protected void ResetMemory(TEntity entity)
    {
        var nameOfEntity = typeof(TEntity).Name;
        ResetMemory<TEntity>();
    }

    protected void ResetMemory(IEnumerable<TEntity> entities)
    {
        ResetMemory<TEntity>();
    }
}
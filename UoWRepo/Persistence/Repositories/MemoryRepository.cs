using System;
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
    private static string _connectionString;

    protected static IDictionary<string, IEnumerable<TEntity>>
        TestList = new Dictionary<string, IEnumerable<TEntity>>();

    protected static IDictionary<string, DateTime> testListDateTimes = new Dictionary<string, DateTime>();

    //protected new readonly Linq2DbContext context;
    //protected readonly Repository<TEntity> repository;

    private IRepository<TEntity> repository;
    private IDictionary<string, IEnumerable<TEntity>> openWith = new Dictionary<string, IEnumerable<TEntity>>();


    public MemoryRepository(Linq2DbContext context, Repository<TEntity> repository) : base(context)
    {
        //this.MemoryContext = MemoryContext;
        this.repository = repository;
    }
    
    public MemoryRepository(string connectionString, Repository<TEntity> repository) : base(connectionString)
    {
        //this.MemoryContext = MemoryContext;
        this.repository = repository;
    }
    
    public MemoryRepository(string connectionString, bool onDemand = true) : base(connectionString)
    {
        //this.MemoryContext = MemoryContext;
        this.repository = new Repository<TEntity>(connectionString, onDemand);
    }
    
    public MemoryRepository(string connectionString) : base(connectionString)
    {
        _connectionString = connectionString;
        //this.MemoryContext = MemoryContext;
        
    }
    
    /* BEGIN: actions that need base*/

    public override void Add(TEntity entity)
    {
        this.repository = new Repository<TEntity>(_connectionString, true);
        ResetMemory(entity);
        base.Add(entity);
    }

    public override int AddWithIdentity(TEntity entity)
    {
        this.repository = new Repository<TEntity>(_connectionString, true);
        ResetMemory(entity);
        return base.AddWithIdentity(entity);
    }

    public override void AddRange(IEnumerable<TEntity> entities)
    {
        this.repository = new Repository<TEntity>(_connectionString, true);
        ResetMemory(entities);
        base.AddRange(entities);
    }
    
    public override void Remove(TEntity entity)
    {
        this.repository = new Repository<TEntity>(_connectionString, true);
        ResetMemory(entity);
        base.Remove(entity);
    }
    
    public override void RemoveRange(IEnumerable<TEntity> entities)
    {
        this.repository = new Repository<TEntity>(_connectionString, true);
        ResetMemory(entities);
        base.RemoveRange(entities);
    }
    
    public override void Update(TEntity entity)
    {
        this.repository = new Repository<TEntity>(_connectionString, true);
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
    protected IEnumerable<TEntity> AddEntityToCacheAndGetList<T>()
    {
        ResetMemory<TEntity>();
        var nameOfEntity = typeof(T).Name;
        this.repository = new Repository<TEntity>(_connectionString, true);
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
    /* END: actions that need base*/
    
    /* BEGIN: actions that may need base base*/


    public override TEntity Get(int id)
    {
        var nameOfEntity = typeof(TEntity).Name;
        var result = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;

        if (result == null)
        {
            this.repository = new Repository<TEntity>(_connectionString, true);
            var entity = base.Get(id);
            return entity;
        }

        var whatIWasLooking = result.SingleOrDefault(x => x.Id == id);

        if (whatIWasLooking == null)
        {
            this.repository = new Repository<TEntity>(_connectionString, true);
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
    
    public override  IEnumerable<TEntity> GetAllWithQueue()
    {
        
        var methodQueue = new MethodQueue();
        
        var nameOfEntity = typeof(TEntity).Name;

        var result = TestList.FirstOrDefault(x => x.Key == nameOfEntity).Value;
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

    public DateTime? GetDateTimeOfCachingOfCurrentEntity()
    {
        var nameOfEntity = typeof(TEntity).Name;
        return testListDateTimes.FirstOrDefault(x => x.Key == nameOfEntity).Value;
    }

   
    
    protected async Task<IEnumerable<TEntity>> AddEntityToCacheAndGetListAsync<T>()
    {
        ResetMemory<TEntity>();
        this.repository = new Repository<TEntity>(_connectionString, true);
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
        this.repository = new Repository<TEntity>(_connectionString, true);
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
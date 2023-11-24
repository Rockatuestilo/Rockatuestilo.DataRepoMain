using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using Rockatuestilo.DataRepoMain.Tests.FakedData;
using Rockatuestilo.DataRepoMain.Tests.TestData.Users;
using UoWRepo.Core.EFDomain;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.EF;

public class UsersCrudsEf
{
    private IUnitOfWorkEf _unitOfWorkEf;
    private List<Users> bugusUsers = new();

    [SetUp]
    public void Setup()
    {
        var createFakeData = new CreateFakeData();
        bugusUsers = createFakeData.DoByNumberEf();

        var value = new ContextGenerator().CreateInMysql();

        _unitOfWorkEf = new UnityOfWorkEf(value);
    }

    [Test]
    public void Test1_add1()
    {
        var users = new TestDataUsers1().GetDataEf();

        _unitOfWorkEf.Users.Add(users[0]);

        var result = _unitOfWorkEf.Users.GetAll().ToList();

        Assert.AreEqual(result.Count, 1);
    }
    
    [Test]
    public void Test1_add1_2()
    {
        var users = new TestDataUsers1().GetDataEf();
        _unitOfWorkEf.Users.Add(users[0]);
        _unitOfWorkEf.Complete();


        Assert.Catch<Exception>(() => _unitOfWorkEf.Users.Add(users[0]));

    }
    
    [Test]
    public void Test2_retrieveListInParallel()
    {
        var users = new TestDataUsers1().GetDataEf();

        _unitOfWorkEf.Users.Add(users[0]);

        List<UoWRepo.Core.EFDomain.Users> result1 = null;
        List<Users> result2 = null;

        // Execute the retrieval of the list in parallel
        var task1 = Task.Run(() => _unitOfWorkEf.Users.GetAllWithQueue().ToList());
        var task2 = Task.Run(() => _unitOfWorkEf.Users.GetAllWithQueue().ToList());

        Task.WaitAll(task1, task2);

        result1 = task1.Result;
        result2 = task2.Result;

        Assert.AreEqual(result1.Count, 1);
        Assert.AreEqual(result2.Count, 1);
    }


    [Test]
    public void Test2_delete1()
    {
        var result = _unitOfWorkEf.Users.GetAll().ToList();

        if (result.Count > 0)
        {
            var idOfFirstUser = result[0].Id;

            var entitytoBeDeleted = _unitOfWorkEf.Users.FindQueryble(x => x.Id == idOfFirstUser).SingleOrDefault();

            _unitOfWorkEf.Users.Remove(entitytoBeDeleted);

            _unitOfWorkEf.Complete();

            var result2 = _unitOfWorkEf.Users.GetAll().ToList();

            Assert.AreEqual(result.Count, result2.Count + 1);
        }
    }
    
    [Test]
    public void Test2_retrieveListInParallelV20()
    {
        var users = new TestDataUsers1().GetDataEf();
        
        Random random = new Random();
        
        users = users.Select(user =>
        {
            user.Id = random.Next(500,1001); // Generate a new random Id
            return user;
        }).ToList();

        _unitOfWorkEf.Users.Add(users[0]);
        
        

        List<List<Users>> results = new List<List<Users>>();

        // Ejecutar las 20 tareas en paralelo
        var tasks = Enumerable.Range(0, 2)
            .Select(_ => Task.Run(() => _unitOfWorkEf.Users.GetAllWithQueue().ToList()))
            .ToList();
        
        

        Task.WaitAll(tasks.ToArray());

        results = tasks.Select(t => t.Result).ToList();
        
        
        foreach (var result in results)
        {
            Assert.GreaterOrEqual(result.Count, 1);
        }
        
        
        var tasksMixed = new List<Task>();

        for (int i = 0; i < 40; i++)
        {
            tasksMixed.Add( _unitOfWorkEf.Users.GetAllAsync());
            //tasksMixed.Add( _unitOfWorkEf.Users.GetAllAsync());
            //tasksMixed.Add(Task.Run(() => _unitOfWorkEf.Users.GetAllWithQueue().ToList()));
        }

        for (int i = 0; i < 2; i++)
        {
            tasksMixed.Add(Task.Run(() => _unitOfWorkEf.Roles.GetAllWithQueue().ToList()));
        }

        _unitOfWorkEf.Complete();

        Task.WaitAll(tasksMixed.ToArray());
        
        // Get the results from the tasks
        var userResults = tasks.Take(40).Select(t => t.Result).ToList();
        var roleResults = tasks.Take(20).Select(t => t.Result).ToList();
        
        //tasksMixed.Select(t => t.).ToList();
        
        //tasksMixed[0].Result.ForEach(t => Assert.GreaterOrEqual(t.Id, 1));
        
        userResults.ForEach(t => Assert.GreaterOrEqual(t.Count, 1));
        

       
    }

    [Test]
    public void Test3_AddMany1()
    {
        var users = new TestDataUsers1().GetDataEf();
        var result = _unitOfWorkEf.Users.GetAll().ToList();

        _unitOfWorkEf.Users.AddRange(users);
        var result2 = _unitOfWorkEf.Users.GetAll().ToList();
        var countShouldBe = result.Count + users.Count;
        Assert.GreaterOrEqual( users.Count, result2.Count);
    }


    [Test]
    public void Test4_SingleOrDefault()
    {
        var result = _unitOfWorkEf.Users.SingleOrDefault(x => x.Id == 1);

        Assert.NotNull(result);
    }


    [Test]
    public void Test4_GetAllQueryble()
    {
        var result = _unitOfWorkEf.Users.GetAllQueryble();

        Assert.NotNull(result);
    }


    [Test]
    public void Test5_GetLastTimeOfEntitySaved()
    {
        var result = _unitOfWorkEf.Users.GetDateTimeOfCachingOfCurrentEntity();

        Assert.NotNull(result);
    }

    [Test]
    public void Test5_GetLastTimeOfEntityUpdated()
    {
        var dateResult = _unitOfWorkEf.Users.GetDateTimeOfCachingOfCurrentEntity();


        var result = _unitOfWorkEf.Users.GetAll().ToList();

        if (result.Count > 0)
        {
            var idOfFirstUser = result[0].Id;

            var entitytoBeDeleted = _unitOfWorkEf.Users.FindQueryble(x => x.Id == idOfFirstUser).SingleOrDefault();

            _unitOfWorkEf.Users.Remove(entitytoBeDeleted);

            _unitOfWorkEf.Complete();

            var result2 = _unitOfWorkEf.Users.GetAll().ToList();

            Assert.AreEqual(result.Count, result2.Count + 1);
        }

        var dateResult2 = _unitOfWorkEf.Users.GetDateTimeOfCachingOfCurrentEntity();

        Assert.AreNotEqual(dateResult, dateResult2);
    }
}
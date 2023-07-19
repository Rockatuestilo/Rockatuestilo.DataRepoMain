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

        var value = new ContextGenerator().CreateInMemory();

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
    public void Test3_AddMany1()
    {
        var users = new TestDataUsers1().GetDataEf();
        var result = _unitOfWorkEf.Users.GetAll().ToList();

        _unitOfWorkEf.Users.AddRange(users);
        _unitOfWorkEf.Complete();

        var result2 = _unitOfWorkEf.Users.GetAll().ToList();

        var countShouldBe = result.Count + users.Count;
        Assert.AreEqual(result2.Count, countShouldBe);
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
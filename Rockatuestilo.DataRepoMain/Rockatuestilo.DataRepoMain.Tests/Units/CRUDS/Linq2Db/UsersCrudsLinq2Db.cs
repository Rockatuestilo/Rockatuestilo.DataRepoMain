using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using Rockatuestilo.DataRepoMain.Tests.TestData.Users;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.Linq2Db;

public class UsersCrudsLinq2Db
{
    [SetUp]
    public void Setup()
    {
        /*var connection =
       "Server=localhost;Port=13306;Database=cmsbackup5;Uid=user;Pwd=password;charset=utf8;SslMode=none;Convert Zero Datetime=True; Pooling=true;";

   var value_0 = new ContextGenerator(connection).CreateInMysql();

   var value = new ContextGenerator(connection).CreateInMysqlLinq2Db();*/

        /*var value = new ContextGenerator("mydb.db").CreateLinq2DbSqlite();

        _unitOfWork = new UnityOfWork(value.Item1);*/
        
        
        var connection =
            "Server=localhost;Port=13306;Database=cmsbackup604_test;Uid=root;Pwd=blueberrywater4;charset=utf8;SslMode=none;Convert Zero Datetime=True; Pooling=true;";

        //var value_0 = new ContextGenerator(connection).CreateInMysql();

        //var value = new ContextGenerator(connection).CreateInMysqlLinq2Db();

        var value = new ContextGenerator(connection).CreateContextAndStringByEnvironment("mysql");

        _unitOfWork = new UnityOfWork(value.Item1);
    }


    private IUnitOfWork _unitOfWork;

    [Test]
    public void Test1_add1()
    {
        var users = new TestDataUsers1().GetDataLinq2Db();

        _unitOfWork.Users.Add(users[0]);
        _unitOfWork.Complete();

        var result = _unitOfWork.Users.GetAll().ToList();


        Assert.AreEqual(result.Count, 1);
    }
    
    [Test]
    public void Test2_retrieveListInParallel()
    {
        var users = new TestDataUsers1().GetDataLinq2Db();

        _unitOfWork.Users.Add(users[0]);
        _unitOfWork.Complete();

        List<UoWRepo.Core.Domain.Users> result1 = null;
        List<UoWRepo.Core.Domain.Users> result2 = null;

        // Execute the retrieval of the list in parallel
        Parallel.Invoke(
            () => result1 = _unitOfWork.Users.GetAllWithQueue().ToList(),
                        () => result2 = _unitOfWork.Users.GetAllWithQueue().ToList()
        );

        Assert.AreEqual(result1.Count, 1);
        Assert.AreEqual(result2.Count, 1);
    }
    
    [Test]
    public void Test2_retrieveListInParallelV2()
    {
        var users = new TestDataUsers1().GetDataLinq2Db();

        _unitOfWork.Users.Add(users[0]);

        List<UoWRepo.Core.Domain.Users> result1 = null;
        List<UoWRepo.Core.Domain.Users> result2 = null;

        // Execute the retrieval of the list in parallel
        var task1 = Task.Run(() => _unitOfWork.Users.GetAllWithQueue().ToList());
        var task2 = Task.Run(() => _unitOfWork.Users.GetAllWithQueue().ToList());

        Task.WaitAll(task1);

        result1 = task1.Result;
        result2 = task2.Result;

        Assert.AreEqual(result1.Count, 1);
        Assert.AreEqual(result2.Count, 1);
    }


    /*

    [Test]
    public void Test2_delete1()
    {

        var result = _unitOfWork.Users.GetAll().ToList();

        if (result.Count > 0)
        {
            var idOfFirstUser = result[0].Id;

            var entitytoBeDeleted = _unitOfWork.Users.FindQueryble(x => x.Id == idOfFirstUser).SingleOrDefault();

            _unitOfWork.Users.Remove(entitytoBeDeleted);

            _unitOfWork.Complete();

            var result2 = _unitOfWork.Users.GetAll().ToList();

            Assert.AreEqual(result.Count, (result2.Count+1));

        }
    }

    [Test]
    public void Test3_AddMany1()
    {

        var users = new TestDataUsers1().GetDataEf();
        var result = _unitOfWork.Users.GetAll().ToList();

        _unitOfWork.Users.AddRange(users);
        _unitOfWork.Complete();

        var result2 = _unitOfWork.Users.GetAll().ToList();

        var countShouldBe = result.Count + users.Count;
        Assert.AreEqual(result2.Count, countShouldBe);
    }


    [Test]
    public void Test4_SingleOrDefault()
    {

        var result = _unitOfWork.Users.SingleOrDefault(x => x.Id == 1);

        Assert.NotNull(result);
    }


    [Test]
    public void Test4_GetAllQueryble()
    {

        var result = _unitOfWork.Users.GetAllQueryble();

        Assert.NotNull(result);
    }*/
}
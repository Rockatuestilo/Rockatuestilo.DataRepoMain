using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using UoWRepo.Core.Domain;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.CRUDS.Linq2Db;

public class UsersToRoleLinq2Db
{
    [SetUp]
    public void Setup()
    {
        var value = new ContextGenerator("test.sqlite1").CreateLinq2DbSqlite();

        _unitOfWork = new UnityOfWork(value.Item1);
            
    }
    
    private IUnitOfWork _unitOfWork;
    
    [Test]
    public void Test1_add1()
    {
        var value =new UsersToRoles();

        value.User = 1;
        value.RoleGuid = 1;

        _unitOfWork.UsersToRoles.Add(value);

        var result = _unitOfWork.Users.GetAll().ToList();
        Assert.AreEqual(result.Count, 1);
    }
}
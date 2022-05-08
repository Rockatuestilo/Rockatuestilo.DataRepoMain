using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using Rockatuestilo.DataRepoMain.Tests.TestData.Roles;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.CRUDS.Linq2Db;

public class RolesModelsLinq2Db
{
    [SetUp]
    public void Setup()
    {
        var value = new ContextGenerator("test.sqlite2").CreateLinq2DbSqlite();

        _unitOfWork = new UnityOfWork(value.Item1);
            
    }
    
    private IUnitOfWork _unitOfWork;
    
    [Test]
    public void Test1_add1()
    {
        var users = new TestDataRoles1().GetFirstExample();
            
        _unitOfWork.Roles.Add(users[0]);

        var result = _unitOfWork.Users.GetAll().ToList();


        Assert.AreEqual(result.Count, 1);


    }
}
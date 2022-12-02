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
        var connection =
            "Server=localhost;Port=13306;Database=cmsbackup5;Uid=user;Pwd=password;charset=utf8;SslMode=none;Convert Zero Datetime=True; Pooling=true;";
                    
        var value_0 = new ContextGenerator(connection).CreateInMysql();
        
        var value = new ContextGenerator(connection).CreateInMysqlLinq2Db();

        _unitOfWork = new UnityOfWork(value);
            
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
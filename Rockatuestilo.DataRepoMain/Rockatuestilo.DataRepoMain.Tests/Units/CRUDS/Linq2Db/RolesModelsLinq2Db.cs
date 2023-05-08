using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using Rockatuestilo.DataRepoMain.Tests.TestData.Roles;
using UoWRepo.Core.Configuration;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.Linq2Db;

public class RolesModelsLinq2Db
{
    [SetUp]
    public void Setup()
    {
        
        /*var connection =
            "Server=localhost;Port=13306;Database=cmsbackup5;Uid=user;Pwd=password;charset=utf8;SslMode=none;Convert Zero Datetime=True; Pooling=true;";
        
        var value_0 = new ContextGenerator(connection).CreateInMysql();
        
        var value = new ContextGenerator(connection).CreateInMysqlLinq2Db();*/
        
        (Linq2DbContext, string) value = new ContextGenerator("mydb.db").CreateLinq2DbSqlite();

        _unitOfWork = new UnityOfWork(value.Item1);
            
    }
    
    private IUnitOfWork _unitOfWork;
    
    [Test]
    public void Test1_add1()
    {
        var roleModelsList = new TestDataRoles1().GetRolesStatic();
        
        
            
        _unitOfWork.Roles.AddRange(roleModelsList);
        _unitOfWork.Complete();

        var result = _unitOfWork.Roles.GetAll().ToList();
        Assert.Greater(result.Count, 0);
    }
}
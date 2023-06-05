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
        
        var connection =
            "Server=localhost;Port=3306;Database=cmsbackup602;Uid=root;Pwd=blueberrywater4;ConnectionTimeout=600;DefaultCommandTimeout=600; Convert Zero Datetime=True;sqlservermode=True;SslMode=None;Pooling=true;";
        
        /*var value_0 = new ContextGenerator(connection).CreateInMysql();
        
        var value = new ContextGenerator(connection).CreateInMysqlLinq2Db();*/
        
        //(Linq2DbContext, string) value = new ContextGenerator("mydb.db").CreateLinq2DbSqlite();
        
        Linq2DbContext value = new ContextGenerator(connection).CreateInMysqlLinq2Db(connection);

        _unitOfWork = new UnityOfWork(value);
            
    }
    
    private IUnitOfWork _unitOfWork;
    
    [Test]
    public void Test1_add1()
    {
        var currentRoles = _unitOfWork.Roles.GetAll().ToList();
        if (currentRoles.Count > 0)
        {
            Assert.NotNull(currentRoles);
            return;
        }
           
       
        
        
        
        var roleModelsList = new TestDataRoles1().GetRolesStatic();

        _unitOfWork.Roles.AddRange(roleModelsList);
        _unitOfWork.Complete();

        var result = _unitOfWork.Roles.GetAll().ToList();
        Assert.Greater(result.Count, 0);
    }
}
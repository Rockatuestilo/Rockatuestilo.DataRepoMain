using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using Rockatuestilo.DataRepoMain.Tests.TestData.Roles;
using UoWRepo.Api;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.Linq2Db;

public class RolesModelsLinq2Db
{
    private IUnitOfWork _unitOfWork;
    private IUnitOfWorkLinq _unitOfWorkLinq;
    private UnitOfWorkMultiOrm _unitOfWorkMultiOrm;

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
        
        var connection2 = "server=localhost;user=root;password=blueberrywater4;database=cmsbackup604_test;Pooling=true;";
        var connection3 =
            "Server=localhost;Port=3306;Database=cmsbackup604_test;Uid=cms;blueberrywater4;ConnectionTimeout=600;DefaultCommandTimeout=600; Convert Zero Datetime=True;SslMode=None;Pooling=true;";

        //var value_0 = new ContextGenerator(connection).CreateInMysql();

        //var value = new ContextGenerator(connection).CreateInMysqlLinq2Db();

        var value = new ContextGenerator(connection).CreateContextAndStringByEnvironment("mysql");

        _unitOfWork = new UnityOfWork(connection2);
        _unitOfWorkMultiOrm = new UnitOfWorkMultiOrm(_unitOfWorkLinq);
        //_unitOfWorkLinq = new UnityOfWorkLinq(value.Item2);
    }

    [Test]
    public void Test1_add1()
    {
        var roleModelsList = new TestDataRoles1().GetRolesStatic();


        _unitOfWork.Roles.AddRange(roleModelsList);
        _unitOfWork.Complete();

        var result = _unitOfWork.Roles.GetAll().ToList();
        Assert.Greater(result.Count, 0);
    }
    
    [Test]
    public void Test2_GetAll()
    {
        var result = _unitOfWork.Roles.GetAll().ToList();
        Assert.Greater(result.Count, 0);
    }
    
    [Test]
    public void Test2_GetAllQueryble()
    {
        var result =_unitOfWork.Roles.GetAllQueryble().ToList();
        _unitOfWork.Complete();

        
        Assert.Greater(result.Count, 0);
    }
    
    [Test]
    public void Test3_Find()
    {
        var result =_unitOfWork.Roles.Find(x => x.Id == 1).ToList();
        _unitOfWork.Complete();

        
        Assert.Greater(result.Count, 0);
    }
    
    [Test]
    public void Test4_DeleteAll_AndAddAgain()
    {
        var roleModelsList = new TestDataRoles1().GetRolesStatic();


        _unitOfWork.Roles.GetAll();
        
        _unitOfWork.Roles.RemoveRange(_unitOfWork.Roles.GetAll());

        _unitOfWork.Complete();
        _unitOfWork.Roles.AddRange(roleModelsList);
        
        
        _unitOfWork.Complete();

        var result = _unitOfWork.Roles.GetAll().ToList();
        Assert.Greater(result.Count, 0);
    }
}
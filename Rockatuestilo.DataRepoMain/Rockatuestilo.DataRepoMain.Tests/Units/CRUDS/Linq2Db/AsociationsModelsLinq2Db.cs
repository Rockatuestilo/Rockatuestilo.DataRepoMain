using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using Rockatuestilo.DataRepoMain.Tests.TestData.Roles;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.Linq2Db;

public class AssociationsLinq2Db
{
    private IUnitOfWork _unitOfWork;
    private IUnitOfWorkLinq _unitOfWorkLinq;

    [SetUp]
    public void Setup()
    {
        /*var connection =
            "Server=localhost;Port=13306;Database=cmsbackup5;Uid=user;Pwd=password;charset=utf8;SslMode=none;Convert Zero Datetime=True; Pooling=true;";

        var value_0 = new ContextGenerator(connection).CreateInMysql();

        var value = new ContextGenerator(connection).CreateInMysqlLinq2Db();*/

        /*var value = new ContextGenerator("mydb.db").CreateLinq2DbSqlite();

        _unitOfWork = new UnityOfWork(value.Item1);*/
        
        
        var database = "cmsbackup_t1";
        var user = "root";
        var password = "blueberrywater4";
        var server = "localhost";
        var port = "3306";
            
        
        var connection =
            $"Server={server};Port={port};Database={database};Uid={user};Pwd={password};charset=utf8;SslMode=none;Convert Zero Datetime=True; Pooling=true;";
        
        var connection2 = $"server={server};user={user};password={password};database={database};Pooling=true;";
        var connection3 =
            $"Server={server};Port={port};Database={database};Uid={user};{password};ConnectionTimeout=600;DefaultCommandTimeout=600; Convert Zero Datetime=True;SslMode=None;Pooling=true;";

        //var value_0 = new ContextGenerator(connection).CreateInMysql();

        //var value = new ContextGenerator(connection).CreateInMysqlLinq2Db();

        var value = new ContextGenerator(connection).CreateContextAndStringByEnvironment("mysql");

        _unitOfWork = new UnityOfWork(connection2);
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
using System;
using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using UoWRepo.Core.LinqDomain;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.Linq2Db;

public class UsersToRoleLinq2Db
{
    private IUnitOfWork _unitOfWork;

    [SetUp]
    public void Setup()
    {
        var connection =
            "Server=localhost;Port=13306;Database=cmsbackup604_test;Uid=root;Pwd=blueberrywater4;charset=utf8;SslMode=none;Convert Zero Datetime=True; Pooling=true;";

        //var value_0 = new ContextGenerator(connection).CreateInMysql();

        //var value = new ContextGenerator(connection).CreateInMysqlLinq2Db();

        var value = new ContextGenerator(connection).CreateContextAndStringByEnvironment("mysql");

        _unitOfWork = new UnityOfWork(value.Item1);
    }

    [Test]
    public void Test1_add1()
    {
        var value = new UsersToRoles();

        value.User = 1;
        value.RoleGuid = 1;
        value.CreatedDate = DateTime.Now;
        value.UpdatedDate = DateTime.Now;


        _unitOfWork.UsersToRoles.Add(value);
        _unitOfWork.Complete();

        var result = _unitOfWork.UsersToRoles.GetAll().ToList();
        Assert.That(result.Count, Is.EqualTo(1));
    }
}
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.Tools.Contexts;
using UoWRepo.Core.EFDomain;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.EF;

public class TypeAssociationEf
{
    private IUnitOfWorkEf? _unitOfWorkEf;

    //[SetUp]
    public void Setup()
    {
        _unitOfWorkEf = ContextCreator.CreateContextEFCoreInSqlite("TypeAssociationEf");
    }
    
    [Test]
    public void CreateDifferentContextsAndRunCruds()
    {
        // in memory
        _unitOfWorkEf = ContextCreator.CreateContextEFCoreInMemory();
        RunCrudTest_add_get_update_delete();
        _unitOfWorkEf = null;
        // in sqlite
        _unitOfWorkEf = ContextCreator.CreateContextEFCoreInSqlite("TypeAssociationEf");
        RunCrudTest_add_get_update_delete();
        _unitOfWorkEf = null;
        // in mysql
        var connectionString =
            @"Server=localhost;Port=3306;charset=utf8;Database=cmsbackup_version_2023_12_28_0;charset=utf8;Uid=root;Pwd=blueberrywater4;charset=utf8;SslMode=none;Convert Zero Datetime=True; Pooling=true;";
        _unitOfWorkEf = ContextCreator.CreateContextEFCoreInMysql(connectionString);
        RunCrudTest_add_get_update_delete();
        _unitOfWorkEf = null;

    }
    
    [Test]
    public void CreateMysqlContextRunCruds()
    {
        // in mysql
        var connectionString =
            @"Server=localhost;Port=3306;charset=utf8;Database=cmsbackup_version_2023_12_28_0;charset=utf8;Uid=root;Pwd=blueberrywater4;charset=utf8;SslMode=none;Convert Zero Datetime=True; Pooling=true;";
        _unitOfWorkEf = ContextCreator.CreateContextEFCoreInMysql(connectionString);
        RunCrudTest_add_get_update_delete();
        _unitOfWorkEf = null;
    }

    
    

    [Test]
    public void RunCrudTest_add_get_update_delete()
    {
        Test1_add1();
        Test2_GetAll();
        Test2_GetAllQueryble();
        Test3_Find();
        Test4_DeleteAll();
        Test6_DeleteAll_AndAddAgain();
        Test5_GetByName();
        Test5_GetByNameAndEdit();

    }


    [Test]
    public void Test1_add1()
    {
        if (_unitOfWorkEf == null)
        {
            Setup();
        }
        
        var value = new TypeAssociation();
  
        value.TypeName = "news";
 
        
        var value2 = new TypeAssociation();

        value2.TypeName = "categories";

        
        var value3 = new TypeAssociation();

        value3.TypeName = "galleries";


        //var resultQueryable = _unitOfWorkEf.TypeAssociations.GetAllQueryble().ToQueryString();
        var result = _unitOfWorkEf.TypeAssociations.GetAllQueryble().ToList();
        

        if (result.Count == 0)
        {
            //var users = new TestDataUsers1().GetDataEf();

            _unitOfWorkEf.TypeAssociations.Add(value);
            _unitOfWorkEf.TypeAssociations.Add(value2);
            _unitOfWorkEf.TypeAssociations.Add(value3);
            _unitOfWorkEf.Complete();
        }

        result = _unitOfWorkEf.TypeAssociations.GetAll().ToList();

        Assert.AreEqual(result.Count, 3);

    }
    
    [Test]
    public void Test2_GetAll()
    {
        if (_unitOfWorkEf == null)
        {
            Setup();
            Test1_add1();
        }
        
        var result = _unitOfWorkEf!.TypeAssociations.GetAll().ToList();
        Assert.GreaterOrEqual(result.Count, 3);
    }
    
    [Test]
    public void Test2_GetAllQueryble()
    {
        if (_unitOfWorkEf == null)
        {
            Setup();
            Test1_add1();
        }
        
        var result =_unitOfWorkEf.TypeAssociations.GetAllQueryble().ToList();
        _unitOfWorkEf.Complete();
        Assert.GreaterOrEqual(result.Count, 3);
    }
    
    [Test]
    public void Test3_Find()
    {
        if (_unitOfWorkEf == null)
        {
            Setup();
            Test1_add1();
        }
        
        var g = _unitOfWorkEf.TypeAssociations.GetAll().ToList();
        
        var result =_unitOfWorkEf.TypeAssociations.Find(x => x.TypeName == "news").ToList();
        _unitOfWorkEf.Complete();

        
        Assert.Greater(result.Count, 0);
    }
    
    [Test]
    public void Test4_DeleteAll()
    {
        if (_unitOfWorkEf == null)
        {
            Setup();
            Test1_add1();
        }
        
        _unitOfWorkEf.TypeAssociations.RemoveRange(_unitOfWorkEf.TypeAssociations.GetAll());
        _unitOfWorkEf.Complete();
        
        var result = _unitOfWorkEf.TypeAssociations.GetAll().ToList();
        Assert.AreEqual(0, result.Count);
    }
    
    
    
    [Test]
    public void Test6_DeleteAll_AndAddAgain()
    {
        if (_unitOfWorkEf == null)
        {
            Setup();
            Test1_add1();
        }
        
        var value = new TypeAssociation();

        value.TypeName = "news";

        
        var value2 = new TypeAssociation();

        value2.TypeName = "categories";

        
        var value3 = new TypeAssociation();
        value3.TypeName = "galleries";

        
        _unitOfWorkEf.TypeAssociations.GetAll();
        
        _unitOfWorkEf.TypeAssociations.RemoveRange(_unitOfWorkEf.TypeAssociations.GetAll());
        _unitOfWorkEf.Complete();

        var value4 = new TypeAssociation();
        value4.TypeName = value3.TypeName;
        
        var value5 = new TypeAssociation();
        value5.TypeName = value2.TypeName;
        
        var value6 = new TypeAssociation();
        value6.TypeName = value.TypeName;
        
        
        
        _unitOfWorkEf.Complete();
        _unitOfWorkEf.TypeAssociations.Add(value4);
        _unitOfWorkEf.TypeAssociations.Add(value5);
        _unitOfWorkEf.TypeAssociations.Add(value6);
        
        
        _unitOfWorkEf.Complete();

        var result = _unitOfWorkEf.TypeAssociations.GetAll().ToList();
        Assert.GreaterOrEqual(3, result.Count());
    }
    
    [Test]
    public void Test5_GetByName()
    {
        if (_unitOfWorkEf == null)
        {
            Setup();
            Test1_add1();
        }
        
        var result =_unitOfWorkEf.TypeAssociations.Find(x => x.TypeName == "news").ToList();
        _unitOfWorkEf.Complete();

        
        Assert.Greater(result.Count, 0);
    }
    
    [Test]
    public void Test5_GetByNameAndEdit()
    {
        if (_unitOfWorkEf == null)
        {
            Setup();
            Test1_add1();
        }
        
        var result =_unitOfWorkEf.TypeAssociations.Find(x => x.TypeName == "news").ToList();
        _unitOfWorkEf.Complete();

        
        Assert.Greater(result.Count, 0);
        
        var value = result[0];
        value.TypeName = "news2";
        _unitOfWorkEf.Complete();
        
        var result2 =_unitOfWorkEf.TypeAssociations.Find(x => x.TypeName == "news2").ToList();
        _unitOfWorkEf.Complete();

        
        Assert.Greater(result2.Count, 0);
    }
}
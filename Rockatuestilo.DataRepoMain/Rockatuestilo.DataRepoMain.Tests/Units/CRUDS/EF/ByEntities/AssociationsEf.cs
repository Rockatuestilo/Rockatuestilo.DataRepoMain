using System;
using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.Tools.Contexts;
using UoWRepo.Core.EFDomain;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.EF.ByEntities;



public class AssociationsEf
{
    private IUnitOfWorkEf _unitOfWorkEf;

    [SetUp]
    public void Setup()
    {
        _unitOfWorkEf = ContextCreator.CreateContextEFCoreInMemory();
    }
    
    [Test]
    public void CreateDifferentContextsAndRunCruds()
    {
        // create lists of asserts
        
        
        
        // in memory
        _unitOfWorkEf = ContextCreator.CreateContextEFCoreInMemory();
        RunCrudTest_add_get_update_delete();
        _unitOfWorkEf = null;
        // in sqlite
        _unitOfWorkEf = ContextCreator.CreateContextEFCoreInSqlite("TypeAssociationEf");
        RunCrudTest_add_get_update_delete();
        _unitOfWorkEf = null;
        
        CreateMysqlContextRunCruds();
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
        /*/Test2_GetAll();
        Test2_GetAllQueryble();
        Test3_Find();
        Test4_DeleteAll();
        Test6_DeleteAll_AndAddAgain();
        Test5_GetByName();
        Test5_GetByNameAndEdit();*/

    }


    [Test]
    public void Test1_add1()
    {
        var value = new Associations();
        value.AssociatedGuid = Guid.NewGuid();
        
        value.ObjectGuid = Guid.NewGuid();
        value.ObjectTypeGuid = Guid.NewGuid();
        value.CreatedById = 1;
        value.UpdatedById = 1;
        
        var typeAssociation = new TypeAssociation();
  
        typeAssociation.TypeName = "news";

        var result = _unitOfWorkEf.Associations.GetAll().ToList();
 
        Assert.That(result.Count, Is.EqualTo(0));

        if (result.Count == 0)
        {
            _unitOfWorkEf.TypeAssociations.Add(typeAssociation);
            var savedTypeAssociation = _unitOfWorkEf.TypeAssociations.GetAll().FirstOrDefault();
            Assert.That(savedTypeAssociation?.TypeName, Is.Not.Null);
            value.AssociatedGuid = savedTypeAssociation!.Guid;
            

            _unitOfWorkEf.Associations.Add(value);
            _unitOfWorkEf.Complete();
        }

        result = _unitOfWorkEf.Associations.GetAll().ToList();

        Assert.That(result.Count, Is.GreaterThan(1));

        //IHashTags hashTags = result[0];
    }
}
using System;
using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using Rockatuestilo.DataRepoMain.Tests.TestData.CategoriesTestCollectionSpace;
using Rockatuestilo.DataRepoMain.Tests.TestData.Users;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.EF.ByEntities;

public class CategoriesCruds
{
    private IUnitOfWorkEf _unitOfWorkEf;
    private UsersCrudsEf _usersCrudsEf = new();

    [SetUp]
    public void Setup()
    {
        var value = new ContextGenerator().CreateInMysql();
        _unitOfWorkEf = new UnityOfWorkEf(value);
    
        _usersCrudsEf.SetupManual(_unitOfWorkEf);
        _usersCrudsEf.Test1_TryGetAnyUsersWithoutErrors();
    }
    
    // add teardown
    [TearDown]
    public void TearDown()
    {
        _usersCrudsEf.TearDown();
        
        _unitOfWorkEf = null;
    }

    [Test]
    public void Test1_add1_ShouldPass()
    {
        var result = _unitOfWorkEf.Users.GetAll().ToList();

        if (result.Count == 0)
        {
            var users = new TestDataUsers1().GetDataEf();

            _unitOfWorkEf.Users.AddRange(users);
            _unitOfWorkEf.Complete();
        }


        result = _unitOfWorkEf.Users.GetAll().ToList();

        var myUserToTest = result[0];

        var testDataCategories1 = new TestDataCategories1();

        var category1 = testDataCategories1.CreateFirstCategory();


        category1.CategoryOwner = myUserToTest.Id;
        category1.CreatedById = myUserToTest.Id;
        category1.UpdatedById = myUserToTest.Id;

        _unitOfWorkEf.Categories.Add(category1);

        var savedCategory = _unitOfWorkEf.Categories.Find(x => x.CategoryName == category1.CategoryName)
            .FirstOrDefault();
        _unitOfWorkEf.Complete();


        Assert.That(savedCategory, Is.Not.Null);
        Assert.That(savedCategory.CategoryOwner, Is.EqualTo(category1.CategoryOwner));
        Assert.That(savedCategory.CreatedById, Is.EqualTo(category1.CreatedById));
        Assert.That(savedCategory.CreatedDate, Is.EqualTo(category1.CreatedDate));
        Assert.That(savedCategory.LevelCategory, Is.EqualTo(category1.LevelCategory));

        Assert.That(savedCategory.UpdatedById, Is.EqualTo(category1.UpdatedById));
        Assert.That(savedCategory.UpdatedDate, Is.EqualTo(category1.UpdatedDate));
        Assert.That(savedCategory.Guid, Is.EqualTo(category1.Guid));

        // and guid not empty
        Assert.That(category1.Guid, Is.Not.EqualTo(Guid.Empty)); 
        

        var savedCategory2 = _unitOfWorkEf.Categories.Find(x => x.CategoryName == savedCategory.CategoryName)
            .FirstOrDefault();


        Assert.That(savedCategory2.Id, Is.EqualTo(savedCategory.Id));
    }
    
    
    [Test]
    public void Test1_add1_2_ShouldNotPass()
    {
        var result = _unitOfWorkEf.Users.GetAll().ToList();

        if (result.Count == 0)
        {
            var users = new TestDataUsers1().GetDataEf();

            _unitOfWorkEf.Users.AddRange(users);
            _unitOfWorkEf.Complete();
        }


        result = _unitOfWorkEf.Users.GetAll().ToList();

        var myUserToTest = result[0];

        var testDataCategories1 = new TestDataCategories1();

        var category1 = testDataCategories1.CreateFirstCategory();


        category1.CategoryOwner = myUserToTest.Id;
        category1.CreatedById = myUserToTest.Id;
        category1.UpdatedById = myUserToTest.Id;

        _unitOfWorkEf.Categories.Add(category1);

        var savedCategory = _unitOfWorkEf.Categories.Find(x => x.CategoryName == category1.CategoryName)
            .FirstOrDefault();
        _unitOfWorkEf.Complete();


        Assert.That(savedCategory, Is.Not.Null);
        Assert.That(savedCategory.CategoryOwner, Is.EqualTo(category1.CategoryOwner));
        Assert.That(savedCategory.CreatedById, Is.EqualTo(category1.CreatedById));
        Assert.That(savedCategory.CreatedDate, Is.EqualTo(category1.CreatedDate));
        Assert.That(savedCategory.LevelCategory, Is.EqualTo(category1.LevelCategory));

        Assert.That(savedCategory.UpdatedById, Is.EqualTo(category1.UpdatedById));
        Assert.That(savedCategory.UpdatedDate, Is.EqualTo(category1.UpdatedDate)); 

        var savedCategory2 = _unitOfWorkEf.Categories.Find(x => x.CategoryName == savedCategory.CategoryName)
            .FirstOrDefault();


        Assert.That(savedCategory2.Id, Is.EqualTo(savedCategory.Id));
   
    }

   
}
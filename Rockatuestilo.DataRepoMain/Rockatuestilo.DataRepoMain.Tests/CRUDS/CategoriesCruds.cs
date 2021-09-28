using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using Rockatuestilo.DataRepoMain.Tests.TestData.CategoriesTestCollectionSpace;
using Rockatuestilo.DataRepoMain.Tests.TestData.Users;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.CRUDS
{
    public class CategoriesCruds
    {
           
        [SetUp]
        public void Setup()
        {
            var value = new ContextGenerator().Create();
            _unitOfWorkEf = new UnityOfWorkEf(value);
        }

        private IUnitOfWorkEf _unitOfWorkEf;
        
        [Test]
        public void Test1_add1()
        {

            var result = _unitOfWorkEf.Users.GetAll().ToList();

            if (result.Count == 0)
            {
                var users = new TestDataUsers1().GetData();
            
                _unitOfWorkEf.Users.AddRange(users);
                _unitOfWorkEf.Complete();
            }
            
            
            result = _unitOfWorkEf.Users.GetAll().ToList();

            var myUserToTest = result[0];

            var testDataCategories1 = new TestDataCategories1();

            var category1 = testDataCategories1.CreateFirstCategory();


            category1.CategoryOwner = myUserToTest.Id;
            category1.CreatedbyId = myUserToTest.Id;
            category1.UpdatedbyId = myUserToTest.Id;
            
            _unitOfWorkEf.Categories.Add(category1);

            var savedCategory =_unitOfWorkEf.Categories.Find(x => x.CategoryName == category1.CategoryName).FirstOrDefault();
            _unitOfWorkEf.Complete();


            Assert.NotNull(savedCategory);
            Assert.AreEqual(category1.CategoryOwner, savedCategory.CategoryOwner);
            Assert.AreEqual(category1.CreatedbyId, savedCategory.CreatedbyId);
            Assert.AreEqual(category1.CreatedDate, savedCategory.CreatedDate);
            Assert.AreEqual(category1.LevelCategory, savedCategory.LevelCategory);
            
            Assert.AreEqual(category1.UpdatedbyId, savedCategory.UpdatedbyId);
            Assert.AreEqual(category1.UpdatedDate, savedCategory.UpdatedDate);
            
            var savedCategory2 =_unitOfWorkEf.Categories.Find(x => x.CategoryName == savedCategory.CategoryName).FirstOrDefault();
            
            
            Assert.AreEqual(savedCategory2.Id, savedCategory.Id);

        }

        [TearDown]
        
        public void DeleteEverything()
        {
            var users = _unitOfWorkEf.Users.GetAll().ToList();

            foreach (var user in users)
            {
                _unitOfWorkEf.Users.Remove(user);
                _unitOfWorkEf.Complete();
            }
            users = _unitOfWorkEf.Users.GetAll().ToList();
        }
    }
}
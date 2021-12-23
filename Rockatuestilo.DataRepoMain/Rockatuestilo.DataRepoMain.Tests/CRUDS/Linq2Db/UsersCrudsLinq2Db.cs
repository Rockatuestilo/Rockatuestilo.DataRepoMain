using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using Rockatuestilo.DataRepoMain.Tests.TestData.Users;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.CRUDS.Linq2Db
{
    public class UsersCrudsLinq2Db
    {
        
        [SetUp]
        public void Setup()
        {
            var value = new ContextGenerator().CreateInMemory();

            _unitOfWorkEf = new UnityOfWorkEf(value);
            
            
        }
        
        
        private IUnitOfWorkEf _unitOfWorkEf;
        
        [Test]
        public void Test1_add1()
        {
            var users = new TestDataUsers1().GetData();
            
            _unitOfWorkEf.Users.Add(users[0]);

            var result = _unitOfWorkEf.Users.GetAll().ToList();


            Assert.AreEqual(result.Count, 1);


        }
        
        
        [Test]
        public void Test2_delete1()
        {
            
            var result = _unitOfWorkEf.Users.GetAll().ToList();

            if (result.Count > 0)
            {
                var idOfFirstUser = result[0].Id;

                var entitytoBeDeleted = _unitOfWorkEf.Users.FindQueryble(x => x.Id == idOfFirstUser).SingleOrDefault();
                
                _unitOfWorkEf.Users.Remove(entitytoBeDeleted);

                _unitOfWorkEf.Complete();
                
                var result2 = _unitOfWorkEf.Users.GetAll().ToList();
                
                Assert.AreEqual(result.Count, (result2.Count+1));
                
            }
        }
        
        [Test]
        public void Test3_AddMany1()
        {
            
            var users = new TestDataUsers1().GetData();
            var result = _unitOfWorkEf.Users.GetAll().ToList();
            
            _unitOfWorkEf.Users.AddRange(users);
            _unitOfWorkEf.Complete();
            
            var result2 = _unitOfWorkEf.Users.GetAll().ToList();

            var countShouldBe = result.Count + users.Count;
            Assert.AreEqual(result2.Count, countShouldBe);
        }
        
        
        [Test]
        public void Test4_SingleOrDefault()
        {
            
            var result = _unitOfWorkEf.Users.SingleOrDefault(x => x.Id == 1);

            Assert.NotNull(result);
        }
        
        
        [Test]
        public void Test4_GetAllQueryble()
        {

            var result = _unitOfWorkEf.Users.GetAllQueryble();

            Assert.NotNull(result);
        }
    }
}
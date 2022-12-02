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
            var connection =
                "Server=localhost;Port=13306;Database=cmsbackup5;Uid=user;Pwd=password;charset=utf8;SslMode=none;Convert Zero Datetime=True; Pooling=true;";
                    
            var value_0 = new ContextGenerator(connection).CreateInMysql();
        
            var value = new ContextGenerator(connection).CreateInMysqlLinq2Db();

            _unitOfWork = new UnityOfWork(value);
            
        }
        
        
        private IUnitOfWork _unitOfWork;
        
        [Test]
        public void Test1_add1()
        {
            var users = new TestDataUsers1().GetDataLinq2Db();
            
            _unitOfWork.Users.Add(users[0]);

            var result = _unitOfWork.Users.GetAll().ToList();


            Assert.AreEqual(result.Count, 1);


        }
        /*
        
        [Test]
        public void Test2_delete1()
        {
            
            var result = _unitOfWork.Users.GetAll().ToList();

            if (result.Count > 0)
            {
                var idOfFirstUser = result[0].Id;

                var entitytoBeDeleted = _unitOfWork.Users.FindQueryble(x => x.Id == idOfFirstUser).SingleOrDefault();
                
                _unitOfWork.Users.Remove(entitytoBeDeleted);

                _unitOfWork.Complete();
                
                var result2 = _unitOfWork.Users.GetAll().ToList();
                
                Assert.AreEqual(result.Count, (result2.Count+1));
                
            }
        }
        
        [Test]
        public void Test3_AddMany1()
        {
            
            var users = new TestDataUsers1().GetDataEf();
            var result = _unitOfWork.Users.GetAll().ToList();
            
            _unitOfWork.Users.AddRange(users);
            _unitOfWork.Complete();
            
            var result2 = _unitOfWork.Users.GetAll().ToList();

            var countShouldBe = result.Count + users.Count;
            Assert.AreEqual(result2.Count, countShouldBe);
        }
        
        
        [Test]
        public void Test4_SingleOrDefault()
        {
            
            var result = _unitOfWork.Users.SingleOrDefault(x => x.Id == 1);

            Assert.NotNull(result);
        }
        
        
        [Test]
        public void Test4_GetAllQueryble()
        {

            var result = _unitOfWork.Users.GetAllQueryble();

            Assert.NotNull(result);
        }*/
    }
}
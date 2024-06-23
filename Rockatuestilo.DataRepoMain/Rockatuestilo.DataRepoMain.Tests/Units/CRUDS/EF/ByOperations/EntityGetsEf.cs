using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.EF.ByEntities;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.EF.ByOperations;

public class EntityGetsEf
{
    
    [Test]
    public void GetUsers()
    {
        UsersCrudsEf usersCrudsEf = new();
        usersCrudsEf.Setup();
        usersCrudsEf.Test1_TryGetAnyUsersWithoutErrors();
        
        Assert.Pass();
    }
    
    [Test]
    public  void GetNews()
    {
        NewsCruds newsCruds = new();
        newsCruds.Setup();
        newsCruds.Test1_AddNews();
        
        Assert.Pass();
    }
    
    [Test]
    public void GetUsersV2()
    {
        UsersCrudsEf usersCrudsEf = new();
        usersCrudsEf.Setup();
        usersCrudsEf.Test1_TryGetAnyUsersWithoutErrors();
        
        Assert.Pass();
    }
    
    [Test]
    public  void GetUsersAndNews()
    {
        
        var value = new ContextGenerator().CreateInMysql();
        var _unitOfWorkEf = new UnityOfWorkEf(value);
        /*NewsCruds newsCruds = new();
        newsCruds.Setup(_unitOfWorkEf);
        
        UsersCrudsEf usersCrudsEf = new();
        usersCrudsEf.Setup(_unitOfWorkEf);*/
        
        // get USers
        var users = _unitOfWorkEf.Users.GetAll();
        
        // get News
        var news = _unitOfWorkEf.News.GetAll();

        if (users == null || news == null)
        {
            
        }
        
        if (users?.Count() > 0 || news?.Count() > 0)
        {
            // get users guids in news
            var usersGuids = news.Select(x => x.OwnerUsersGuid).ToList().Take(3);

            foreach (var usersGuid in usersGuids)
            {
                var user = users.FirstOrDefault(x => x.Guid == usersGuid);
                
                if (user == null)
                {
                    Assert.Fail();
                }
            }
        }
        Assert.Pass();
    }
}
using System;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using UoWRepo.Core.EFDomain;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.CRUDS.EF;

[TestFixture]
public class NewsCruds
{
     
    private IUnitOfWorkEf _unitOfWorkEf;
    [SetUp]
    public void Setup()
    {
        var value = new ContextGenerator().CreateInMemory();
            
        //value.Database.Migrate();

        _unitOfWorkEf = new UnityOfWorkEf(value);
            
            
    }

    [Test] 
    public void Test1_CreateUser()
    {
        var news = new NewsEtty();

        news.NewsContent = "";
        news.NewsCreatedDate = DateTime.Now;
        news.NewsChangedById = 1;
        news.NewsPermission = 0;
        news.NewsPresentation = "";
        news.NewsTitle = "";
        news.PublicationDate = DateTime.Now;
        news.PublicationType = 0;
        news.TitleForUrl = "";
        news.ArticleVersion = 0;
        news.CategoryId = 1;
        news.UpdatedDate = DateTime.Now;
        news.HashtagsNewsId = 1;
        news.UserIdOwner = 1;
        
        
        
        _unitOfWorkEf.News.Add(news);
    }
}
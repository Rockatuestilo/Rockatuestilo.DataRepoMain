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

        news.Newscontent = "";
        news.Newscreateddate = DateTime.Now;
        news.Newschangedbyid = 1;
        news.Newspermission = 0;
        news.Newspresentation = "";
        news.Newstittel = "";
        news.Publicationdate = DateTime.Now;
        news.Publicationtype = 0;
        news.Titleforurl = "";
        news.ArticleVersion = "0";
        news.CategoryId = 1;
        news.UpdatedDate = DateTime.Now;
        news.HashtagsNewsId = 1;
        news.UserIdOwner = 1;
        
        
        
        _unitOfWorkEf.News.Add(news);
    }
}
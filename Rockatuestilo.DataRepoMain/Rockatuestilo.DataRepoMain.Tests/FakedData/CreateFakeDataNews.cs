using System.Collections.Generic;
using Bogus;
using UoWRepo.Core.EFDomain;
using UoWRepo.Core.LinqDomain;

namespace Rockatuestilo.DataRepoMain.Tests.FakedData;

public class CreateFakeDataNews
{
    public List<ArticleDataModel> DoByNumber(int howMany = 1000)
    {
        var newsList = new List<ArticleDataModel>();

        // create 1000 news
        for (var i = 0; i < howMany; i++)
        {
            var news = new Faker<ArticleDataModel>()
                .RuleFor(a => a.ArticleVersion, f => f.Random.Int(0, 2))
                //.RuleFor(a => a.CategoryId, f => f.Random.Int(0,2))
                //.RuleFor(a => a.GalleryId, f => f.Random.Int(0,2))
                //.RuleFor(a => a.HashtagsNewsId, f => f.Random.Int(0,2))
                .RuleFor(a => a.ChangedById, f => f.Random.Int(0, 2))
                .RuleFor(a => a.Content, f => f.Lorem.Paragraph())
                .RuleFor(a => a.CreatedDate, f => f.Date.Past())
                .RuleFor(a => a.Permission, f => f.Random.Int(0, 2))
                .RuleFor(a => a.Presentation, f => f.Lorem.Sentence())
                .RuleFor(a => a.Title, f => f.Lorem.Sentence())
                .RuleFor(a => a.PublicationDate, f => f.Date.Future())
                .RuleFor(a => a.PublicationType, f => f.Random.Int(0, 2))
                .RuleFor(a => a.TitleForUrl, f => f.Internet.Url())
                .RuleFor(a => a.UpdatedDate, f => f.Date.Recent())
                .RuleFor(a => a.Id, f => f.Random.Int(0, 2))
                .Generate();

            newsList.Add(news);
        }

        return newsList;
    }
}
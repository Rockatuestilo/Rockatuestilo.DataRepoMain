using System.Collections.Generic;
using Bogus;
using UoWRepo.Core.Domain;

namespace Rockatuestilo.DataRepoMain.Tests.FakedData;

public class CreateFakeDataNews
{
    public List<NewsEtty> DoByNumber(int howMany = 1000)
    {
        var newsList = new List<NewsEtty>();

        // create 1000 news
        for (var i = 0; i < howMany; i++)
        {
            var news = new Faker<NewsEtty>()
                .RuleFor(a => a.ArticleVersion, f => f.Random.Int(0, 2))
                //.RuleFor(a => a.CategoryId, f => f.Random.Int(0,2))
                //.RuleFor(a => a.GalleryId, f => f.Random.Int(0,2))
                //.RuleFor(a => a.HashtagsNewsId, f => f.Random.Int(0,2))
                .RuleFor(a => a.NewsChangedById, f => f.Random.Int(0, 2))
                .RuleFor(a => a.NewsContent, f => f.Lorem.Paragraph())
                .RuleFor(a => a.CreatedDate, f => f.Date.Past())
                .RuleFor(a => a.NewsPermission, f => f.Random.Int(0, 2))
                .RuleFor(a => a.NewsPresentation, f => f.Lorem.Sentence())
                .RuleFor(a => a.NewsTitle, f => f.Lorem.Sentence())
                .RuleFor(a => a.PublicationDate, f => f.Date.Future())
                .RuleFor(a => a.PublicationType, f => f.Random.Int(0, 2))
                .RuleFor(a => a.TitleForUrl, f => f.Internet.Url())
                .RuleFor(a => a.UpdatedDate, f => f.Date.Recent())
                .RuleFor(a => a.UserIdOwner, f => f.Random.Int(0, 2))
                .Generate();

            newsList.Add(news);
        }

        return newsList;
    }
}
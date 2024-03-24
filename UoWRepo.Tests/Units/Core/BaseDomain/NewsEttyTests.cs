using Bogus;
using UoWRepo.Core.BaseDomain;
using NewsEttyLinq2DB = UoWRepo.Core.Domain.NewsEtty; // Adjust namespace based on your project structure
using NewsEttyEfCore = UoWRepo.Core.EFDomain.NewsEtty;

namespace UoWRepo.Tests.Units.Core.BaseDomain;

public class NewsEttyTests
{

     public List<INewsEtty> CreateTestValuesValid<T>(int count = 50) where T : class, INewsEtty, new()
    {
        var faker = new Faker();
        
        var val = new Faker<T>();

        val
            // faker for index property that can be between 1 and 1000000
            .RuleFor(o => o.Id, f => f.Random.Number(1, 1000000))
            // faker for news Title for max 2000 characters
            //.RuleFor(o => o.NewsTitle, f => f.Lorem.Sentence(2000))
            .RuleFor(o => o.NewsTitle, _ => faker.Random.String2(2000))
            // faker for news Content for max 60000 characters
            //.RuleFor(o => o.NewsContent, f => f.Lorem.Sentence(60000))
            .RuleFor(o => o.NewsContent, _ => faker.Random.String2(60000))
            // faker for news Created Date that is a date between 2020 and 2025
            .RuleFor(o => o.CreatedDate, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2025, 1, 1)))
            // faker for news Last Update Date that is a date between 2020 and 2025 but newer than the created date
            .RuleFor(o => o.UpdatedDate, (f, u) => f.Date.Between(u.CreatedDate, new DateTime(2025, 1, 1)))
            // faker for news Permission that can be between 1 and 10
            .RuleFor(o => o.NewsPermission, f => f.Random.Number(1, 10))
            // faker for news Changed By ID that can be between 1 and 1000000
            .RuleFor(o => o.NewsChangedById, f => f.Random.Number(1, 1000000))
            // faker for category ID that can be between 1 and 100
            .RuleFor(o => o.CategoryId, f => f.Random.Number(1, 100))
            // faker for publication Type that can be between 1 and 10
            .RuleFor(o => o.PublicationType, f => f.Random.Number(1, 10))
            // faker for gallery ID that can be between 1 and 1000000
            .RuleFor(o => o.GalleryId, f => f.Random.Number(1, 1000000))
            // faker for news Presentation for max 2000 characters
            //.RuleFor(o => o.NewsPresentation, f => f.Lorem.Sentence(2000))
            .RuleFor(o => o.NewsPresentation, _ => faker.Random.String2(2000))
            // faker for publication Date that is a date between 2020 and 2025
            .RuleFor(o => o.PublicationDate, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2025, 1, 1)))
            // faker for Title For Url for max 500 characters
            //.RuleFor(o => o.TitleForUrl, f => f.Lorem.Sentence(500))
            .RuleFor(o => o.TitleForUrl, _ => faker.Random.String2(500))
            // faker for Hashtags News ID that can be between 1 and 1000000
            .RuleFor(o => o.HashtagsNewsId, f => f.Random.Number(1, 1000000))
            // faker for Article Version that can be between 1 and 1000000 and null
            .RuleFor(o => o.ArticleVersion, f => f.Random.Bool() ? (int?)null : f.Random.Number(1, 1000000));

        
        var testOrder = val.Generate(count);
        return testOrder.Cast<INewsEtty>().ToList();
    }
     
     public List<INewsEtty> CreateTestValuesInValid<T>(int count = 50) where T : class, INewsEtty, new()
    {
        var faker = new Faker();
        
        var val = new Faker<T>();
        
        val
             // faker for index property that can be between 1 and 1000000
            .RuleFor(o => o.Id, f => f.Random.Number(1, 1000000))
            // faker for news Title for max 2000 characters
            //.RuleFor(o => o.NewsTitle, f => f.Lorem.Sentence(2000))
            .RuleFor(o => o.NewsTitle, _ => faker.Random.String2(2001))
            // faker for news Content for max 60000 characters
            //.RuleFor(o => o.NewsContent, f => f.Lorem.Sentence(60000))
            .RuleFor(o => o.NewsContent, _ => faker.Random.String2(60001))
            // faker for news Created Date that is a date between 2020 and 2025
            .RuleFor(o => o.CreatedDate, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2025, 1, 1)))
            // faker for news Last Update Date that is a date between 2020 and 2025 but newer than the created date
            .RuleFor(o => o.UpdatedDate, (f, u) => f.Date.Between(u.CreatedDate, new DateTime(2025, 1, 1)))
            // faker for news Permission that can be between 1 and 10
            .RuleFor(o => o.NewsPermission, f => f.Random.Number(1, 10))
            // faker for news Changed By ID that can be between 1 and 1000000
            .RuleFor(o => o.NewsChangedById, f => f.Random.Number(1, 1000000))
            // faker for category ID that can be between 1 and 100
            .RuleFor(o => o.CategoryId, f => f.Random.Number(1, 100))
            // faker for publication Type that can be between 1 and 10
            .RuleFor(o => o.PublicationType, f => f.Random.Number(1, 10))
            // faker for gallery ID that can be between 1 and 1000000
            .RuleFor(o => o.GalleryId, f => f.Random.Number(1, 1000000))
            // faker for news Presentation for max 2000 characters
            //.RuleFor(o => o.NewsPresentation, f => f.Lorem.Sentence(2000))
            .RuleFor(o => o.NewsPresentation, _ => faker.Random.String2(2001))
            // faker for publication Date that is a date between 2020 and 2025
            .RuleFor(o => o.PublicationDate, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2025, 1, 1)))
            // faker for Title For Url for max 500 characters
            //.RuleFor(o => o.TitleForUrl, f => f.Lorem.Sentence(500))
            .RuleFor(o => o.TitleForUrl, _ =>faker.Random.String2(501))
            // faker for Hashtags News ID that can be between 1 and 1000000
            .RuleFor(o => o.HashtagsNewsId, f => f.Random.Number(1, 1000000))
            // faker for Article Version that can be between 1 and 1000000 and null
            .RuleFor(o => o.ArticleVersion, f => f.Random.Bool() ? (int?)null : f.Random.Number(1, 1000000));

        
        var testOrder = val.Generate(50);
        return testOrder.Cast<INewsEtty>().ToList();
    }

 
    
    [Test]

    public void ItShouldBeValid()
    {
        var values = CreateTestValuesValid<NewsEttyLinq2DB>(50);
        
        var json = System.Text.Json.JsonSerializer.Serialize(values);
        var newsEttyLinq2DBs = System.Text.Json.JsonSerializer.Deserialize<List<NewsEttyLinq2DB>>(json);
        var newsEttyEfCores = System.Text.Json.JsonSerializer.Deserialize<List<NewsEttyEfCore>>(json);
            

        
        // for loop
        for (int i = 0; i < values.Count; i++)
        {
            // Arrange
            var newsEttyLinq2Db = newsEttyLinq2DBs?[i];
            var newsEttyEfCore = newsEttyEfCores?[i];

            // Act
            var isValidLinq2DB = DynamicValidator.TryValidateObject(newsEttyLinq2Db!, out var validationErrorsLinq2Db);
            var isValidEfCore = DynamicValidator.TryValidateObject(newsEttyEfCore!, out var validationErrorsEfCore);
            //var isValid = newsEtty.IsValid();
            
            // both are equal
            Assert.That(isValidEfCore, Is.EqualTo(isValidLinq2DB));

            if (!isValidLinq2DB)
            {
                Console.WriteLine(string.Join("\n", validationErrorsLinq2Db));
            }

            if (!isValidEfCore)
            {
                Console.WriteLine(string.Join("\n", validationErrorsEfCore));
            }



            // Assert are equal
            Assert.IsTrue(isValidLinq2DB);
            Assert.IsTrue(isValidEfCore);
        }

    }
    
    [Test]
    public void ItShouldBeInValid()
    {
            
        
        var values = CreateTestValuesInValid<NewsEttyLinq2DB>(50);
        
        var json = System.Text.Json.JsonSerializer.Serialize(values);
        var newsEttyLinq2DBs = System.Text.Json.JsonSerializer.Deserialize<List<NewsEttyLinq2DB>>(json);
        var newsEttyEfCores = System.Text.Json.JsonSerializer.Deserialize<List<NewsEttyEfCore>>(json);
            
        DomainCommonTests domainCommonTests = new DomainCommonTests();
        
        // for loop
        for (int i = 0; i < values.Count; i++)
        {
            // Arrange
            var newsEttyLinq2Db = newsEttyLinq2DBs?[i];
            var newsEttyEfCore = newsEttyEfCores?[i];

            // Act
            var isValidLinq2DB = DynamicValidator.TryValidateObject(newsEttyLinq2Db!, out var validationErrorsLinq2Db);
            var isValidEfCore = DynamicValidator.TryValidateObject(newsEttyEfCore!, out var validationErrorsEfCore);
            //var isValid = newsEtty.IsValid();
            
            Assert.That(isValidEfCore, Is.EqualTo(isValidLinq2DB));

            if (!isValidLinq2DB)
            {
                Console.WriteLine(string.Join("\n", validationErrorsLinq2Db));
            }

            if (!isValidEfCore)
            {
                Console.WriteLine(string.Join("\n", validationErrorsEfCore));
            }
            
            domainCommonTests.CheckPropertiesEquality(newsEttyLinq2Db, newsEttyEfCore);



            // Assert are equal
            Assert.IsFalse(isValidLinq2DB);
            Assert.IsFalse(isValidEfCore);
        }
    }

}
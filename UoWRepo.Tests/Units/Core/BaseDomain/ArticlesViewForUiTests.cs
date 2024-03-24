using Bogus;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.Domain;


namespace UoWRepo.Tests.Units.Core.BaseDomain;

public class ArticlesViewForUiTests
{
    
     public List<IArticlesViewForUi> CreateTestValuesValid<T>(int count = 50) where T : class, IArticlesViewForUi, new()
    {
        var faker = new Faker();
        
        var val = new Faker<T>();

        val
            // faker for index property that can be between 1 and 1000000
            .RuleFor(o => o.Id, f => f.Random.Number(1, 1000000))
            // faker for Article ID that can be between 1 and 1000000
            .RuleFor(o => o.ArticleId, f => f.Random.Number(1, 1000000))
            // faker for UiString
            .RuleFor(o => o.UiString, f => f.Lorem.Sentence(2000))
            // faker for Created By ID that can be between 1 and 1000000
            .RuleFor(o => o.CreatedById, f => f.Random.Number(1, 1000000))
            // faker for Updated By ID that can be between 1 and 1000000
            .RuleFor(o => o.UpdatedById, f => f.Random.Number(1, 1000000))
            // faker for Last Update Of Article that is a date between 2020 and 2025
            .RuleFor(o => o.LastUpdateOfArticle, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2025, 1, 1)))
            // faker for Created Date that is a date between 2020 and 2025
            .RuleFor(o => o.CreatedDate, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2025, 1, 1)));
            
            

        
        var testOrder = val.Generate(count);
        return testOrder.Cast<IArticlesViewForUi>().ToList();
    }
     
     public List<IArticlesViewForUi> CreateTestValuesInValid<T>(int count = 50) where T : class, IArticlesViewForUi, new()
    {
        var faker = new Faker();
        
        var val = new Faker<T>();
        
        val
            // faker for index property that can be between 1 and 1000000
            .RuleFor(o => o.Id, f => f.Random.Number(1, 1000000))
            // faker for Article ID that can be between 1 and 1000000
            .RuleFor(o => o.ArticleId, f => -1)
            // faker for UiString
            .RuleFor(o => o.UiString, f => f.Lorem.Sentence(2000))
            // faker for Created By ID that can be between 1 and 1000000
            .RuleFor(o => o.CreatedById, _ => -1)
            // faker for Updated By ID that can be between 1 and 1000000
            .RuleFor(o => o.UpdatedById, f => f.Random.Number(1, 1000000))
            // faker for Last Update Of Article that is a date between 2020 and 2025
            .RuleFor(o => o.LastUpdateOfArticle, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2025, 1, 1)))
            // faker for Created Date that is a date between 2020 and 2025
            .RuleFor(o => o.CreatedDate, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2025, 1, 1)));


        
        var testOrder = val.Generate(50);
        return testOrder.Cast<IArticlesViewForUi>().ToList();
    }

 
    
    [Test]

    public void ItShouldBeValid()
    {
        var values = CreateTestValuesValid<ArticlesViewForUi>(50);
        
        var json = System.Text.Json.JsonSerializer.Serialize(values);
        var newsEttyLinq2DBs = System.Text.Json.JsonSerializer.Deserialize<List<ArticlesViewForUi>>(json);
        var newsEttyEfCores = System.Text.Json.JsonSerializer.Deserialize<List<ArticlesViewForUi>>(json);
            

        
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
            
        
        var values = CreateTestValuesInValid<ArticlesViewForUi>(50);
        
        var json = System.Text.Json.JsonSerializer.Serialize(values);
        var newsEttyLinq2DBs = System.Text.Json.JsonSerializer.Deserialize<List<ArticlesViewForUi>>(json);
        var newsEttyEfCores = System.Text.Json.JsonSerializer.Deserialize<List<ArticlesViewForUi>>(json);
            
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
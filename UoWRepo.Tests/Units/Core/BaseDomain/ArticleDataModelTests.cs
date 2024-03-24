using System.ComponentModel.DataAnnotations;
using Bogus;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.Domain;

namespace UoWRepo.Tests.Units.Core.BaseDomain;

public class ArticleDataModelTests
{

    public List<T> CreateTestValuesValidAutomatically<T>(int count = 50) where T : class, new()
    {
        // get type of T
        var type = typeof(T);
        // get all properties
        var properties = type.GetProperties();
        
        var fakerTyped = new Faker<T>();

        foreach (var property in properties)
        {
            // get type of property
            var propertyType = property.PropertyType;
            // check if property is nullable
            var isNullable = Nullable.GetUnderlyingType(propertyType) != null;
            // get type of property
            var propertyType2 = Nullable.GetUnderlyingType(propertyType) ?? propertyType;
            
            // check if property has any attributes
            var attributes = property.GetCustomAttributes(false);
            
            // check if property is string
            if (propertyType2 == typeof(string))
            {
                var stringLength = attributes.FirstOrDefault(x => x is StringLengthAttribute) as StringLengthAttribute;
                var stringLengthS = attributes.Where(x => x is StringLengthAttribute) as StringLengthAttribute;
                if(attributes.Any(x => x is StringLengthAttribute stringLength))
                {
                    
                    var faker = new Faker();
                    var value = faker.Random.String2(stringLength!.MaximumLength);
                    // faker for string
                    fakerTyped.RuleFor(property.Name, _ => value);
                    //fakerTyped.RuleFor(property.Name, _ => fakerTyped.Random.String2(stringLength.MaximumLength + 1));
                }
                else
                {
                    // faker for string
                    fakerTyped.RuleFor(property.Name, f => f.Random.String2(2000));
                }
                
                // faker for string
                //fakerTyped.RuleFor(property.Name, f => f.Random.String2(2000));
            }
            // check if property is int
            else if (propertyType2 == typeof(int))
            {
                // faker for int
                fakerTyped.RuleFor(property.Name, f => f.Random.Number(1, 1000000));
            }
            // check if property is DateTime
            else if (propertyType2 == typeof(DateTime))
            {
                // faker for DateTime
                fakerTyped.RuleFor(property.Name, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2025, 1, 1)));
            }
            // check if property is bool
            else if (propertyType2 == typeof(bool))
            {
                // faker for bool
                fakerTyped.RuleFor(property.Name, f => f.Random.Bool());
            }
            // check if property is nullable
            else if (isNullable)
            {
                // check if property is int?
                if (propertyType2 == typeof(int))
                {
                    // faker for int?
                    fakerTyped.RuleFor(property.Name, f => f.Random.Bool() ? (int?)null : f.Random.Number(1, 1000000));
                }
                // check if property is DateTime?
                else if (propertyType2 == typeof(DateTime))
                {
                    // faker for DateTime?
                    fakerTyped.RuleFor(property.Name, (f, u) => f.Random.Bool() ? (DateTime?)null : f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2025, 1, 1)));
                }
            }
            
        }
        
        var testOrder = fakerTyped.Generate(count);
        //return testOrder.Cast<INewsEtty>().ToList();
        return testOrder;
    }
     


 
    
    [Test]

    public void ItShouldBeValid()
    {
        var values = CreateTestValuesValidAutomatically<ArticleDataModel>(50);
        
        var json = System.Text.Json.JsonSerializer.Serialize(values);
        var newsEttyLinq2DBs = System.Text.Json.JsonSerializer.Deserialize<List<ArticleDataModel>>(json);
        var newsEttyEfCores = System.Text.Json.JsonSerializer.Deserialize<List<UoWRepo.Core.EFDomain.ArticleDataModel>>(json);
            

        
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
        AutomaticBogus automaticBogus = new AutomaticBogus();
        
        var values = automaticBogus.CreateTestValuesAutomatically<ArticleDataModel>(false, 50);
        
        var json = System.Text.Json.JsonSerializer.Serialize(values);
        var newsEttyLinq2DBs = System.Text.Json.JsonSerializer.Deserialize<List<ArticleDataModel>>(json);
        var newsEttyEfCores = System.Text.Json.JsonSerializer.Deserialize<List<UoWRepo.Core.EFDomain.ArticleDataModel>>(json);
            

        
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
            Assert.IsFalse(isValidLinq2DB);
            Assert.IsFalse(isValidEfCore);
        }
    }
    
}
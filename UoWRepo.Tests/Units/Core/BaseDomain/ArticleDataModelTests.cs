using System.ComponentModel.DataAnnotations;
using Bogus;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.EFDomain;
using UoWRepo.Core.LinqDomain;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace UoWRepo.Tests.Units.Core.BaseDomain;

public class ArticleDataModelTests
{
    
    // Método auxiliar para validar (similar a tu DynamicValidator)
    private bool TryValidateObject(object obj, out ICollection<ValidationResult> results)
    {
        var context = new ValidationContext(obj, serviceProvider: null, items: null);
        results = new List<ValidationResult>();
        return Validator.TryValidateObject(obj, context, results, validateAllProperties: true);
    }


    // Actualizado para usar IArticleDataModel
    public List<IArticleDataModel> CreateTestValuesValid<T>(int count = 50) where T : ArticleDataModel,  new()
    {
        var faker = new Faker();
        var val = new Faker<T>();

        val
            .RuleFor(o => o.Id, f => f.Random.Number(1, 1000000))
            .RuleFor(o => o.OwnerId, f => f.Random.Number(1, 1000000)) // Actualizado: OwnerId
            .RuleFor(o => o.Title, f => f.Random.String2(1, 2000))      // Actualizado: Title, longitud válida
            .RuleFor(o => o.Content, f => f.Random.String2(1, 60000)) // Actualizado: Content, longitud válida
            .RuleFor(o => o.CreatedDate, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2025, 1, 1)))
            .RuleFor(o => o.UpdatedDate, (f, u) => f.Date.Between(u.CreatedDate, new DateTime(2025, 1, 1)))
            .RuleFor(o => o.Permission, f => f.Random.Int(1, 10))    // Actualizado: Permission
            .RuleFor(o => o.ChangedById, f => f.Random.Int(1, 1000000)) // Actualizado: ChangedById
            .RuleFor(o => o.CategoryId, f => f.Random.Int(1, 100))      // Actualizado: CategoryId
            .RuleFor(o => o.PublicationType, f => f.Random.Int(0, 10)) // No cambia, default es 0
            .RuleFor(o => o.GalleryId, f => f.Random.Int(1, 1000000))   // Actualizado: GalleryId
            .RuleFor(o => o.Presentation, f => f.Random.String2(1, 2000)) // Actualizado: Presentation, longitud válida
            .RuleFor(o => o.PublicationDate, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2025, 1, 1)))
            .RuleFor(o => o.TitleForUrl, f => f.Random.String2(1, 500)) // Actualizado: TitleForUrl, longitud válida
            .RuleFor(o => o.HashtagsArticleId, f => f.Random.Int(1, 1000000)) // Actualizado: HashtagsArticleId (manteniendo nombre por ahora)
            .RuleFor(o => o.ArticleVersion, f => f.Random.Bool() ? (int?)null : f.Random.Number(1, 1000000)) // No cambia tipo
            .RuleFor(o => o.Guid, f => Guid.NewGuid()) // Añadido: Guid requerido
            .RuleFor(o => o.OwnerUsersGuid, f => Guid.NewGuid()); // Añadido: OwnerUsersGuid requerido

        var testValues = val.Generate(count);
        // Asegurar que los objetos base TEntity tengan valores (si es necesario)
        foreach (var item in testValues)
        {
            if (item is TEntity baseItem)
            {
                 // Si TEntity tiene propiedades como CreatedDate/UpdatedDate que deben coincidir
                 // y no están cubiertas por IArticleDataModel, ajústalas aquí si es necesario.
                 // Ejemplo: baseItem.CreatedDate = item.CreatedDate; (si TEntity las tiene y IArticleDataModel no)
                 // En este caso, IArticleDataModel parece incluirlas, así que podría no ser necesario.
            }
        }

        return testValues.Cast<IArticleDataModel>().ToList();
    }

    // Actualizado para usar IArticleDataModel
    public List<IArticleDataModel> CreateTestValuesInValid<T>(int count = 50) where T : ArticleDataModel, new()
    {
        var faker = new Faker();
        var val = new Faker<T>();

        // Genera datos mayormente válidos, pero con algunas violaciones específicas
        val
            .RuleFor(o => o.Id, f => f.Random.Number(1, 1000000))
            .RuleFor(o => o.OwnerId, f => f.Random.Number(1, 1000000)) // Actualizado
            // Título inválido (demasiado largo)
            .RuleFor(o => o.Title, f => f.Random.String2(2001)) // Actualizado
            // Contenido válido (para aislar el error del título)
            .RuleFor(o => o.Content, f => f.Random.String2(1, 60000)) // Actualizado
            .RuleFor(o => o.CreatedDate, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2025, 1, 1)))
            .RuleFor(o => o.UpdatedDate, (f, u) => f.Date.Between(u.CreatedDate, new DateTime(2025, 1, 1)))
            .RuleFor(o => o.Permission, f => f.Random.Int(1, 10)) // Actualizado
            .RuleFor(o => o.ChangedById, f => f.Random.Int(1, 1000000)) // Actualizado
            .RuleFor(o => o.CategoryId, f => f.Random.Int(1, 100)) // Actualizado
            .RuleFor(o => o.PublicationType, f => f.Random.Int(0, 10))
            .RuleFor(o => o.GalleryId, f => f.Random.Int(1, 1000000)) // Actualizado
             // Presentation inválida (demasiado larga) - Opcional, comentar si solo se prueba Title
            //.RuleFor(o => o.Presentation, f => f.Random.String2(2001)) // Actualizado
            .RuleFor(o => o.Presentation, f => f.Random.String2(1, 2000)) // Dejar válido para probar solo Title
            .RuleFor(o => o.PublicationDate, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2025, 1, 1)))
             // TitleForUrl inválido (demasiado largo) - Opcional, comentar si solo se prueba Title
            //.RuleFor(o => o.TitleForUrl, f => f.Random.String2(501)) // Actualizado
            .RuleFor(o => o.TitleForUrl, f => f.Random.String2(1, 500)) // Dejar válido para probar solo Title
            .RuleFor(o => o.HashtagsArticleId, f => f.Random.Int(1, 1000000)) // Actualizado
            .RuleFor(o => o.ArticleVersion, f => f.Random.Bool() ? (int?)null : f.Random.Number(1, 1000000))
            // Guid y OwnerUsersGuid deben ser válidos porque son Required
            .RuleFor(o => o.Guid, f => Guid.NewGuid())
            .RuleFor(o => o.OwnerUsersGuid, f => Guid.NewGuid());


        var testValues = val.Generate(count);
         // Asegurar que los objetos base TEntity tengan valores (si es necesario)
        foreach (var item in testValues)
        {
            if (item is TEntity baseItem)
            {
                 // Ajustar si es necesario como en CreateTestValuesValid
            }
        }
        return testValues.Cast<IArticleDataModel>().ToList();
    }


    [Test]
    public void ItShouldBeValid()
    {
        // Usar la nueva clase ArticleDataModel directamente
        var values = CreateTestValuesValid<ArticleDataModel>(50);

        foreach(var article in values)
        {
            // Act
            // Usa el método de validación auxiliar o tu DynamicValidator si prefieres
            var isValid = TryValidateObject(article, out var validationErrors);

            // Assert
            Assert.That(isValid, Is.True, $"Validation failed for valid object: {string.Join(", ", validationErrors.Select(e => e.ErrorMessage))}");
             if (!isValid)
            {
                 Console.WriteLine($"Validation failed unexpectedly for Article ID (Bogus): {article.Id}");
                 Console.WriteLine(string.Join("\n", validationErrors.Select(e => $"{e.MemberNames.FirstOrDefault()}: {e.ErrorMessage}")));
            }
        }
    }

    [Test]
    public void ItShouldBeInValidV2()
    {
        // Usar la nueva clase ArticleDataModel directamente
        var values = CreateTestValuesInValid<ArticleDataModel>(50);

         foreach(var article in values)
        {
            // Act
            var isValid = TryValidateObject(article, out var validationErrors);

             // Assert
            Assert.That(isValid, Is.False, "Validation succeeded for invalid object.");

            if (isValid)
            {
                 Console.WriteLine($"Validation succeeded unexpectedly for Article ID (Bogus): {article.Id}");
            }
            /* // Opcional: Verificar que el error es el esperado (ej: longitud del título)
            else
            {
                 Assert.That(validationErrors.Any(e => e.MemberNames.Contains("Title") && e.ErrorMessage.Contains("length")), Is.True, "Expected Title length validation error was not found.");
                 Console.WriteLine($"Expected validation error found for Article ID (Bogus): {article.Id} -> Title length");
            }
            */
        }
    }
    

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

    public void ItShouldBeValidV3()
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
            Assert.That(isValidLinq2DB, Is.True);
            Assert.That(isValidEfCore, Is.True);
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
            Assert.That(isValidLinq2DB, Is.False);
            Assert.That(isValidEfCore, Is.False);
        }
    }
    
}
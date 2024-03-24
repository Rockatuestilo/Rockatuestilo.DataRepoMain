using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Bogus;

namespace UoWRepo.Tests.Units.Core.BaseDomain;

public class AutomaticBogus
{
    public List<T> CreateTestValuesAutomatically<T>(bool valid = true, int count = 50) where T : class, new()
    {
        // get type of T
        var type = typeof(T);
        // get all properties
        var properties = type.GetProperties();
        
        var fakerTyped = new Faker<T>();

        foreach (var property in properties)
        {
            ProtertyRuleGeneration(property, fakerTyped, valid);
        }
        
        var testOrder = fakerTyped.Generate(count);
        return testOrder;
    }

    private static void ProtertyRuleGeneration<T>(PropertyInfo property, Faker<T> fakerTyped, bool valid) where T : class, new()
    {
        // get type of property
        var propertyType = property.PropertyType;
        // check if property is nullable
        var isNullable = Nullable.GetUnderlyingType(propertyType) != null;
        // get type of property
        var propertyType2 = Nullable.GetUnderlyingType(propertyType) ?? propertyType;
        
        // check if property has any attributes
        var attributes = property.GetCustomAttributes(false);
        
        
        
        /*var requiredAttribute = attributes.FirstOrDefault(x => x is RequiredAttribute) as RequiredAttribute;
        
        if(requiredAttribute is not null)
        {
            var value = valid ? null : "";
            fakerTyped.RuleFor(property.Name, _ => value);
        }*/

        
            
        // check if property is string
        if (propertyType2 == typeof(string))
        {
            var stringLength = attributes?.FirstOrDefault(x => x is StringLengthAttribute) as StringLengthAttribute;
            if(stringLength is not null)
            {
                    
                var faker = new Faker();
                if(valid)
                {
               
                    // faker for string
                    fakerTyped.RuleFor(property.Name, _ => faker.Random.String2(stringLength!.MaximumLength));
                }
                else
                {
                    // faker for string
                    fakerTyped.RuleFor(property.Name, _ => faker.Random.String2(stringLength!.MaximumLength+1));
                }
          
            }
            else
            {
                // faker for string
                fakerTyped.RuleFor(property.Name, f => f.Random.String2(200));
            }
            
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
}
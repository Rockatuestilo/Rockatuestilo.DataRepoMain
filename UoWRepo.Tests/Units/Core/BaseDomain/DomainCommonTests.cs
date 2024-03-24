namespace UoWRepo.Tests.Units.Core.BaseDomain;

[TestFixture]
public class DomainCommonTests
{
    
    public void CheckPropertiesEquality(object hashTagV1, object hashTagV2)
    {
       
    
        var propertiesV1 = hashTagV1.GetType().GetProperties();
        var propertiesV2 = hashTagV2.GetType().GetProperties();

        // Act and Assert
        Assert.That(propertiesV2.Length, Is.EqualTo(propertiesV1.Length), "The number of properties does not match.");

        foreach (var propertyV1 in propertiesV1)
        {
            var propertyV2 = propertiesV2.FirstOrDefault(p => p.Name == propertyV1.Name);
            Assert.IsNotNull(propertyV2, $"Property {propertyV1.Name} is not found in HashTags version 2.");

            // Check type
            Assert.That(propertyV2!.PropertyType, Is.EqualTo(propertyV1.PropertyType), $"Property types for {propertyV1.Name} do not match.");

            // Check nullability
            bool isNullableV1 = Nullable.GetUnderlyingType(propertyV1.PropertyType) != null || !propertyV1.PropertyType.IsValueType;
            bool isNullableV2 = Nullable.GetUnderlyingType(propertyV2.PropertyType) != null || !propertyV2.PropertyType.IsValueType;

            Assert.That(isNullableV2, Is.EqualTo(isNullableV1), $"Nullability for {propertyV1.Name} does not match.");

            // var attributesV1 = propertyV1.Attributes;
            // var attributesV2 = propertyV2.Attributes;
            // var customAttirbutes = propertyV1.GetCustomAttributes();


        }
    }

}
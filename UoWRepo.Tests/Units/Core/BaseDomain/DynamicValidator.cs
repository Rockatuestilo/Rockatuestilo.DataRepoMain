using System.ComponentModel.DataAnnotations;

namespace UoWRepo.Tests.Units.Core.BaseDomain;

public static class DynamicValidator
{
    public static bool TryValidateObject(object obj, out List<string> validationErrors)
    {
        validationErrors = new List<string>();
        var properties = obj.GetType().GetProperties();

        foreach (var property in properties)
        {
            var value = property.GetValue(obj);
            var attributes = property.GetCustomAttributes(false);

            foreach (var attribute in attributes)
            {
                // Required attribute validation
                if (attribute is RequiredAttribute)
                {
                    if (value == null || (property.PropertyType == typeof(string) && string.IsNullOrEmpty(value.ToString())))
                    {
                        validationErrors.Add($"{property.Name} is required.");
                    }
                }

                // StringLength attribute validation
                if (attribute is StringLengthAttribute stringLength)
                {
                    var stringValue = value as string;
                    if (stringValue != null && stringValue.Length > stringLength.MaximumLength)
                    {
                        validationErrors.Add($"{property.Name} exceeds maximum length of {stringLength.MaximumLength}.");
                    }
                }

                // Add more attribute checks as needed (e.g., Range, CustomAttributes, etc.)
                if (attribute is System.ComponentModel.DataAnnotations.RangeAttribute range && value is int intValue && (intValue < (int)range.Minimum || intValue > (int)range.Maximum))
                {
                    validationErrors.Add($"{property.Name} is out of range.");
                }
            }

            // DateTime validity check (example of a specific type check without attribute)
            if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
            {
                var dateTimeValue = (DateTime?)value;
                if (dateTimeValue == DateTime.MinValue)
                {
                    validationErrors.Add($"{property.Name} has an invalid date.");
                }
            }
        }

        return !validationErrors.Any();
    }
}
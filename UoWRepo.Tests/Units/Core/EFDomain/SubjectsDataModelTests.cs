using System.ComponentModel.DataAnnotations;
using Bogus;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace UoWRepo.Tests.Units.Core.EFDomain;

public class SubjectsDataModelTests
    {
        // Método auxiliar para validar objetos con DataAnnotations
        private bool TryValidateObject(object obj, out ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(obj, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, context, results, validateAllProperties: true);
        }

        // Genera una lista de SubjectsDataModel válidos
        public List<SubjectsDataModel> CreateValidSubjects(int count = 50)
        {
            var faker = new Faker<SubjectsDataModel>()
                .RuleFor(s => s.Guid, _ => Guid.NewGuid())
                .RuleFor(s => s.Name, f => f.Random.String2(1, 1024))              // longitud ≤ 1024 :contentReference[oaicite:0]{index=0}:contentReference[oaicite:1]{index=1}
                .RuleFor(s => s.SubjectTypeGuid, _ => Guid.NewGuid())             // FK requerido :contentReference[oaicite:2]{index=2}:contentReference[oaicite:3]{index=3}
                .RuleFor(s => s.Description, f => f.Random.Bool() 
                                                    ? f.Lorem.Paragraph() 
                                                    : null)                       // opcional
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(1))
                .RuleFor(s => s.UpdatedDate, (f, s) => f.Date.Between(s.CreatedDate, DateTime.Now));

            return faker.Generate(count);
        }

        // Genera una lista de SubjectsDataModel intencionalmente inválidos
        public List<SubjectsDataModel> CreateInvalidSubjects(int count = 50)
        {
            var faker = new Faker<SubjectsDataModel>()
                .RuleFor(s => s.Guid, _ => Guid.NewGuid())
                // Nombre demasiado largo
                .RuleFor(s => s.Name, f => f.Random.String2(1025))                // excede 1024 :contentReference[oaicite:4]{index=4}:contentReference[oaicite:5]{index=5}
                .RuleFor(s => s.SubjectTypeGuid, _ => Guid.NewGuid())
                .RuleFor(s => s.Description, f => f.Lorem.Locale) // longitud ≤ 1000 :contentReference[oaicite:6]{index=6}:contentReference[oaicite:7]{index=7}
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(1))
                .RuleFor(s => s.UpdatedDate, (f, s) => f.Date.Between(s.CreatedDate, DateTime.Now));

            return faker.Generate(count);
        }

        [Test]
        public void ItShouldBeValid()
        {
            var validSubjects = CreateValidSubjects(50);

            foreach (var subject in validSubjects)
            {
                bool isValid = TryValidateObject(subject, out var errors);
                Assert.That(isValid, Is.True, 
                    $"Validation failed for valid SubjectsDataModel: {string.Join("; ", errors.Select(e => e.ErrorMessage))}");
            }
        }

        [Test]
        public void ItShouldBeInvalid()
        {
            var invalidSubjects = CreateInvalidSubjects(50);

            foreach (var subject in invalidSubjects)
            {
                bool isValid = TryValidateObject(subject, out var errors);
                Assert.That(isValid, Is.False, "Validation unexpectedly succeeded for invalid SubjectsDataModel.");

                // Comprobamos que al menos haya un error de longitud en Name
                Assert.That(errors.Any(e => e.MemberNames.Contains("Name") 
                                            && e.ErrorMessage.Contains("maximum length")), 
                    Is.True, "Expected a Name length validation error.");
            }
        }
    }